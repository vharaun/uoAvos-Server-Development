using Server.Accounting;
using Server.ContextMenus;
using Server.Diagnostics;
using Server.Gumps;
using Server.HuePickers;
using Server.Items;
using Server.Menus;
using Server.Mobiles;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using CV = Server.ClientVersion;

namespace Server.Network
{
	public class BufferPool
	{
		private static List<BufferPool> m_Pools = new List<BufferPool>();

		public static List<BufferPool> Pools { get => m_Pools; set => m_Pools = value; }

		private readonly string m_Name;

		private readonly int m_InitialCapacity;
		private readonly int m_BufferSize;

		private int m_Misses;

		private readonly Queue<byte[]> m_FreeBuffers;

		public void GetInfo(out string name, out int freeCount, out int initialCapacity, out int currentCapacity, out int bufferSize, out int misses)
		{
			lock (this)
			{
				name = m_Name;
				freeCount = m_FreeBuffers.Count;
				initialCapacity = m_InitialCapacity;
				currentCapacity = m_InitialCapacity * (1 + m_Misses);
				bufferSize = m_BufferSize;
				misses = m_Misses;
			}
		}

		public BufferPool(string name, int initialCapacity, int bufferSize)
		{
			m_Name = name;

			m_InitialCapacity = initialCapacity;
			m_BufferSize = bufferSize;

			m_FreeBuffers = new Queue<byte[]>(initialCapacity);

			for (var i = 0; i < initialCapacity; ++i)
			{
				m_FreeBuffers.Enqueue(new byte[bufferSize]);
			}

			lock (m_Pools)
			{
				m_Pools.Add(this);
			}
		}

		public byte[] AcquireBuffer()
		{
			lock (this)
			{
				if (m_FreeBuffers.Count > 0)
				{
					return m_FreeBuffers.Dequeue();
				}

				++m_Misses;

				for (var i = 0; i < m_InitialCapacity; ++i)
				{
					m_FreeBuffers.Enqueue(new byte[m_BufferSize]);
				}

				return m_FreeBuffers.Dequeue();
			}
		}

		public void ReleaseBuffer(byte[] buffer)
		{
			if (buffer == null)
			{
				return;
			}

			lock (this)
			{
				m_FreeBuffers.Enqueue(buffer);
			}
		}

		public void Free()
		{
			lock (m_Pools)
			{
				m_Pools.Remove(this);
			}
		}
	}

	public class ByteQueue
	{
		private int m_Head;
		private int m_Tail;
		private int m_Size;

		private byte[] m_Buffer;

		public int Length => m_Size;

		public ByteQueue()
		{
			m_Buffer = new byte[2048];
		}

		public void Clear()
		{
			m_Head = 0;
			m_Tail = 0;
			m_Size = 0;
		}

		private void SetCapacity(int capacity)
		{
			var newBuffer = new byte[capacity];

			if (m_Size > 0)
			{
				if (m_Head < m_Tail)
				{
					Buffer.BlockCopy(m_Buffer, m_Head, newBuffer, 0, m_Size);
				}
				else
				{
					Buffer.BlockCopy(m_Buffer, m_Head, newBuffer, 0, m_Buffer.Length - m_Head);
					Buffer.BlockCopy(m_Buffer, 0, newBuffer, m_Buffer.Length - m_Head, m_Tail);
				}
			}

			m_Head = 0;
			m_Tail = m_Size;
			m_Buffer = newBuffer;
		}

		public byte GetPacketID()
		{
			if (m_Size >= 1)
			{
				return m_Buffer[m_Head];
			}

			return 0xFF;
		}

		public int GetPacketLength()
		{
			if (m_Size >= 3)
			{
				return (m_Buffer[(m_Head + 1) % m_Buffer.Length] << 8) | m_Buffer[(m_Head + 2) % m_Buffer.Length];
			}

			return 0;
		}

		public int Dequeue(byte[] buffer, int offset, int size)
		{
			if (size > m_Size)
			{
				size = m_Size;
			}

			if (size == 0)
			{
				return 0;
			}

			if (m_Head < m_Tail)
			{
				Buffer.BlockCopy(m_Buffer, m_Head, buffer, offset, size);
			}
			else
			{
				var rightLength = (m_Buffer.Length - m_Head);

				if (rightLength >= size)
				{
					Buffer.BlockCopy(m_Buffer, m_Head, buffer, offset, size);
				}
				else
				{
					Buffer.BlockCopy(m_Buffer, m_Head, buffer, offset, rightLength);
					Buffer.BlockCopy(m_Buffer, 0, buffer, offset + rightLength, size - rightLength);
				}
			}

			m_Head = (m_Head + size) % m_Buffer.Length;
			m_Size -= size;

			if (m_Size == 0)
			{
				m_Head = 0;
				m_Tail = 0;
			}

			return size;
		}

		public void Enqueue(byte[] buffer, int offset, int size)
		{
			if ((m_Size + size) > m_Buffer.Length)
			{
				SetCapacity((m_Size + size + 2047) & ~2047);
			}

			if (m_Head < m_Tail)
			{
				var rightLength = (m_Buffer.Length - m_Tail);

				if (rightLength >= size)
				{
					Buffer.BlockCopy(buffer, offset, m_Buffer, m_Tail, size);
				}
				else
				{
					Buffer.BlockCopy(buffer, offset, m_Buffer, m_Tail, rightLength);
					Buffer.BlockCopy(buffer, offset + rightLength, m_Buffer, 0, size - rightLength);
				}
			}
			else
			{
				Buffer.BlockCopy(buffer, offset, m_Buffer, m_Tail, size);
			}

			m_Tail = (m_Tail + size) % m_Buffer.Length;
			m_Size += size;
		}
	}

	public class SendQueue
	{
		public class Gram
		{
			private static readonly Stack<Gram> _pool = new Stack<Gram>();

			public static Gram Acquire()
			{
				lock (_pool)
				{
					Gram gram;

					if (_pool.Count > 0)
					{
						gram = _pool.Pop();
					}
					else
					{
						gram = new Gram();
					}

					gram._buffer = AcquireBuffer();
					gram._length = 0;

					return gram;
				}
			}

			private byte[] _buffer;
			private int _length;

			public byte[] Buffer => _buffer;

			public int Length => _length;

			public int Available => (_buffer.Length - _length);

			public bool IsFull => (_length == _buffer.Length);

			private Gram()
			{
			}

			public int Write(byte[] buffer, int offset, int length)
			{
				var write = Math.Min(length, Available);

				System.Buffer.BlockCopy(buffer, offset, _buffer, _length, write);

				_length += write;

				return write;
			}

			public void Release()
			{
				lock (_pool)
				{
					_pool.Push(this);
					ReleaseBuffer(_buffer);
				}
			}
		}

		private static int m_CoalesceBufferSize = 512;
		private static BufferPool m_UnusedBuffers = new BufferPool("Coalesced", 2048, m_CoalesceBufferSize);

		public static int CoalesceBufferSize
		{
			get => m_CoalesceBufferSize;
			set
			{
				if (m_CoalesceBufferSize == value)
				{
					return;
				}

				var old = m_UnusedBuffers;

				lock (old)
				{
					if (m_UnusedBuffers != null)
					{
						m_UnusedBuffers.Free();
					}

					m_CoalesceBufferSize = value;
					m_UnusedBuffers = new BufferPool("Coalesced", 2048, m_CoalesceBufferSize);
				}
			}
		}

		public static byte[] AcquireBuffer()
		{
			lock (m_UnusedBuffers)
			{
				return m_UnusedBuffers.AcquireBuffer();
			}
		}

		public static void ReleaseBuffer(byte[] buffer)
		{
			lock (m_UnusedBuffers)
			{
				if (buffer != null && buffer.Length == m_CoalesceBufferSize)
				{
					m_UnusedBuffers.ReleaseBuffer(buffer);
				}
			}
		}

		private readonly Queue<Gram> _pending;

		private Gram _buffered;

		public bool IsFlushReady => (_pending.Count == 0 && _buffered != null);

		public bool IsEmpty => (_pending.Count == 0 && _buffered == null);

		public SendQueue()
		{
			_pending = new Queue<Gram>();
		}

		public Gram CheckFlushReady()
		{
			var gram = _buffered;
			_pending.Enqueue(_buffered);
			_buffered = null;
			return gram;
		}

		public Gram Dequeue()
		{
			Gram gram = null;

			if (_pending.Count > 0)
			{
				_pending.Dequeue().Release();

				if (_pending.Count > 0)
				{
					gram = _pending.Peek();
				}
			}

			return gram;
		}

		private const int PendingCap = 256 * 1024;

		public Gram Enqueue(byte[] buffer, int length)
		{
			return Enqueue(buffer, 0, length);
		}

		public Gram Enqueue(byte[] buffer, int offset, int length)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			else if (!(offset >= 0 && offset < buffer.Length))
			{
				throw new ArgumentOutOfRangeException("offset", offset, "Offset must be greater than or equal to zero and less than the size of the buffer.");
			}
			else if (length < 0 || length > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero or greater than the size of the buffer.");
			}
			else if ((buffer.Length - offset) < length)
			{
				throw new ArgumentException("Offset and length do not point to a valid segment within the buffer.");
			}

			var existingBytes = (_pending.Count * m_CoalesceBufferSize) + (_buffered == null ? 0 : _buffered.Length);

			if ((existingBytes + length) > PendingCap)
			{
				throw new CapacityExceededException();
			}

			Gram gram = null;

			while (length > 0)
			{
				if (_buffered == null)
				{ // nothing yet buffered
					_buffered = Gram.Acquire();
				}

				var bytesWritten = _buffered.Write(buffer, offset, length);

				offset += bytesWritten;
				length -= bytesWritten;

				if (_buffered.IsFull)
				{
					if (_pending.Count == 0)
					{
						gram = _buffered;
					}

					_pending.Enqueue(_buffered);
					_buffered = null;
				}
			}

			return gram;
		}

		public void Clear()
		{
			if (_buffered != null)
			{
				_buffered.Release();
				_buffered = null;
			}

			while (_pending.Count > 0)
			{
				_pending.Dequeue().Release();
			}
		}
	}

	[Serializable]
	public sealed class CapacityExceededException : Exception
	{
		public CapacityExceededException()
			: base("Too much data pending.")
		{
		}
	}

	/// <summary>
	/// Handles Outgoing Packet Compression For The Network
	/// </summary>
	public enum ZLibQuality : int
	{
		Default = -1,
		None = 0,
		Speed = 1,
		Size = 9
	}

	public enum ZLibError : int
	{
		VersionError = -6,
		BufferError = -5,
		MemoryError = -4,
		DataError = -3,
		StreamError = -2,
		FileError = -1,

		Okay = 0,

		StreamEnd = 1,
		NeedDictionary = 2
	}

	public interface ICompressor
	{
		string Version
		{
			get;
		}

		ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength);
		ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality);

		ZLibError Decompress(byte[] dest, ref int destLength, byte[] source, int sourceLength);
	}

	public static class Compression
	{
		private static readonly int[] _huffmanTable = new int[514]
		{
			0x2, 0x000, 0x5, 0x01F, 0x6, 0x022, 0x7, 0x034, 0x7, 0x075, 0x6, 0x028, 0x6, 0x03B, 0x7, 0x032,
			0x8, 0x0E0, 0x8, 0x062, 0x7, 0x056, 0x8, 0x079, 0x9, 0x19D, 0x8, 0x097, 0x6, 0x02A, 0x7, 0x057,
			0x8, 0x071, 0x8, 0x05B, 0x9, 0x1CC, 0x8, 0x0A7, 0x7, 0x025, 0x7, 0x04F, 0x8, 0x066, 0x8, 0x07D,
			0x9, 0x191, 0x9, 0x1CE, 0x7, 0x03F, 0x9, 0x090, 0x8, 0x059, 0x8, 0x07B, 0x8, 0x091, 0x8, 0x0C6,
			0x6, 0x02D, 0x9, 0x186, 0x8, 0x06F, 0x9, 0x093, 0xA, 0x1CC, 0x8, 0x05A, 0xA, 0x1AE, 0xA, 0x1C0,
			0x9, 0x148, 0x9, 0x14A, 0x9, 0x082, 0xA, 0x19F, 0x9, 0x171, 0x9, 0x120, 0x9, 0x0E7, 0xA, 0x1F3,
			0x9, 0x14B, 0x9, 0x100, 0x9, 0x190, 0x6, 0x013, 0x9, 0x161, 0x9, 0x125, 0x9, 0x133, 0x9, 0x195,
			0x9, 0x173, 0x9, 0x1CA, 0x9, 0x086, 0x9, 0x1E9, 0x9, 0x0DB, 0x9, 0x1EC, 0x9, 0x08B, 0x9, 0x085,
			0x5, 0x00A, 0x8, 0x096, 0x8, 0x09C, 0x9, 0x1C3, 0x9, 0x19C, 0x9, 0x08F, 0x9, 0x18F, 0x9, 0x091,
			0x9, 0x087, 0x9, 0x0C6, 0x9, 0x177, 0x9, 0x089, 0x9, 0x0D6, 0x9, 0x08C, 0x9, 0x1EE, 0x9, 0x1EB,
			0x9, 0x084, 0x9, 0x164, 0x9, 0x175, 0x9, 0x1CD, 0x8, 0x05E, 0x9, 0x088, 0x9, 0x12B, 0x9, 0x172,
			0x9, 0x10A, 0x9, 0x08D, 0x9, 0x13A, 0x9, 0x11C, 0xA, 0x1E1, 0xA, 0x1E0, 0x9, 0x187, 0xA, 0x1DC,
			0xA, 0x1DF, 0x7, 0x074, 0x9, 0x19F, 0x8, 0x08D, 0x8, 0x0E4, 0x7, 0x079, 0x9, 0x0EA, 0x9, 0x0E1,
			0x8, 0x040, 0x7, 0x041, 0x9, 0x10B, 0x9, 0x0B0, 0x8, 0x06A, 0x8, 0x0C1, 0x7, 0x071, 0x7, 0x078,
			0x8, 0x0B1, 0x9, 0x14C, 0x7, 0x043, 0x8, 0x076, 0x7, 0x066, 0x7, 0x04D, 0x9, 0x08A, 0x6, 0x02F,
			0x8, 0x0C9, 0x9, 0x0CE, 0x9, 0x149, 0x9, 0x160, 0xA, 0x1BA, 0xA, 0x19E, 0xA, 0x39F, 0x9, 0x0E5,
			0x9, 0x194, 0x9, 0x184, 0x9, 0x126, 0x7, 0x030, 0x8, 0x06C, 0x9, 0x121, 0x9, 0x1E8, 0xA, 0x1C1,
			0xA, 0x11D, 0xA, 0x163, 0xA, 0x385, 0xA, 0x3DB, 0xA, 0x17D, 0xA, 0x106, 0xA, 0x397, 0xA, 0x24E,
			0x7, 0x02E, 0x8, 0x098, 0xA, 0x33C, 0xA, 0x32E, 0xA, 0x1E9, 0x9, 0x0BF, 0xA, 0x3DF, 0xA, 0x1DD,
			0xA, 0x32D, 0xA, 0x2ED, 0xA, 0x30B, 0xA, 0x107, 0xA, 0x2E8, 0xA, 0x3DE, 0xA, 0x125, 0xA, 0x1E8,
			0x9, 0x0E9, 0xA, 0x1CD, 0xA, 0x1B5, 0x9, 0x165, 0xA, 0x232, 0xA, 0x2E1, 0xB, 0x3AE, 0xB, 0x3C6,
			0xB, 0x3E2, 0xA, 0x205, 0xA, 0x29A, 0xA, 0x248, 0xA, 0x2CD, 0xA, 0x23B, 0xB, 0x3C5, 0xA, 0x251,
			0xA, 0x2E9, 0xA, 0x252, 0x9, 0x1EA, 0xB, 0x3A0, 0xB, 0x391, 0xA, 0x23C, 0xB, 0x392, 0xB, 0x3D5,
			0xA, 0x233, 0xA, 0x2CC, 0xB, 0x390, 0xA, 0x1BB, 0xB, 0x3A1, 0xB, 0x3C4, 0xA, 0x211, 0xA, 0x203,
			0x9, 0x12A, 0xA, 0x231, 0xB, 0x3E0, 0xA, 0x29B, 0xB, 0x3D7, 0xA, 0x202, 0xB, 0x3AD, 0xA, 0x213,
			0xA, 0x253, 0xA, 0x32C, 0xA, 0x23D, 0xA, 0x23F, 0xA, 0x32F, 0xA, 0x11C, 0xA, 0x384, 0xA, 0x31C,
			0xA, 0x17C, 0xA, 0x30A, 0xA, 0x2E0, 0xA, 0x276, 0xA, 0x250, 0xB, 0x3E3, 0xA, 0x396, 0xA, 0x18F,
			0xA, 0x204, 0xA, 0x206, 0xA, 0x230, 0xA, 0x265, 0xA, 0x212, 0xA, 0x23E, 0xB, 0x3AC, 0xB, 0x393,
			0xB, 0x3E1, 0xA, 0x1DE, 0xB, 0x3D6, 0xA, 0x31D, 0xB, 0x3E5, 0xB, 0x3E4, 0xA, 0x207, 0xB, 0x3C7,
			0xA, 0x277, 0xB, 0x3D4, 0x8, 0x0C0, 0xA, 0x162, 0xA, 0x3DA, 0xA, 0x124, 0xA, 0x1B4, 0xA, 0x264,
			0xA, 0x33D, 0xA, 0x1D1, 0xA, 0x1AF, 0xA, 0x39E, 0xA, 0x24F, 0xB, 0x373, 0xA, 0x249, 0xB, 0x372,
			0x9, 0x167, 0xA, 0x210, 0xA, 0x23A, 0xA, 0x1B8, 0xB, 0x3AF, 0xA, 0x18E, 0xA, 0x2EC, 0x7, 0x062,
			0x4, 0x00D
		};

		private const int CountIndex = 0;
		private const int ValueIndex = 1;

		// UO packets may not exceed 64kb in length
		private const int BufferSize = 0x10000;

		// Optimal compression ratio is 2 / 8;  worst compression ratio is 11 / 8
		private const int MinimalCodeLength = 2;
		private const int MaximalCodeLength = 11;

		// Fixed overhead, in bits, per compression call
		private const int TerminalCodeLength = 4;

		// If our input exceeds this length, we cannot possibly compress it within the buffer
		private const int DefiniteOverflow = ((BufferSize * 8) - TerminalCodeLength) / MinimalCodeLength;

		// If our input exceeds this length, we may potentially overflow the buffer
		private const int PossibleOverflow = ((BufferSize * 8) - TerminalCodeLength) / MaximalCodeLength;

		public static unsafe void Compress(byte[] input, int offset, int count, byte[] output, ref int length)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			else if (offset < 0 || offset >= input.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			else if (count < 0 || count > input.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			else if ((input.Length - offset) < count)
			{
				throw new ArgumentException();
			}

			length = 0;

			if (count > DefiniteOverflow)
			{
				return;
			}

			var bitCount = 0;
			var bitValue = 0;

			fixed (int* pTable = _huffmanTable)
			{
				int* pEntry;

				fixed (byte* pInputBuffer = input)
				{
					byte* pInput = pInputBuffer + offset, pInputEnd = pInput + count;

					fixed (byte* pOutputBuffer = output)
					{
						byte* pOutput = pOutputBuffer, pOutputEnd = pOutput + BufferSize;

						while (pInput < pInputEnd)
						{
							pEntry = &pTable[*pInput++ << 1];

							bitCount += pEntry[CountIndex];

							bitValue <<= pEntry[CountIndex];
							bitValue |= pEntry[ValueIndex];

							while (bitCount >= 8)
							{
								bitCount -= 8;

								if (pOutput < pOutputEnd)
								{
									*pOutput++ = (byte)(bitValue >> bitCount);
								}
								else
								{
									length = 0;
									return;
								}
							}
						}

						// terminal code
						pEntry = &pTable[0x200];

						bitCount += pEntry[CountIndex];

						bitValue <<= pEntry[CountIndex];
						bitValue |= pEntry[ValueIndex];

						// align on byte boundary
						if ((bitCount & 7) != 0)
						{
							bitValue <<= (8 - (bitCount & 7));
							bitCount += (8 - (bitCount & 7));
						}

						while (bitCount >= 8)
						{
							bitCount -= 8;

							if (pOutput < pOutputEnd)
							{
								*pOutput++ = (byte)(bitValue >> bitCount);
							}
							else
							{
								length = 0;
								return;
							}
						}

						length = (int)(pOutput - pOutputBuffer);
						return;
					}
				}
			}
		}

		public static readonly ICompressor Compressor;

		static Compression()
		{
			if (Core.Unix)
			{
				if (Core.Is64Bit)
				{
					Compressor = new CompressorUnix64();
				}
				else
				{
					Compressor = new CompressorUnix32();
				}
			}
			else if (Core.Is64Bit)
			{
				Compressor = new Compressor64();
			}
			else
			{
				Compressor = new Compressor32();
			}
		}

		public static ZLibError Pack(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return Compressor.Compress(dest, ref destLength, source, sourceLength);
		}

		public static ZLibError Pack(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality)
		{
			return Compressor.Compress(dest, ref destLength, source, sourceLength, quality);
		}

		public static ZLibError Unpack(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return Compressor.Decompress(dest, ref destLength, source, sourceLength);
		}
	}

	public sealed class Compressor32 : ICompressor
	{
		internal class SafeNativeMethods
		{
			[DllImport("zlibwapi32")]
			internal static extern string zlibVersion();

			[DllImport("zlibwapi32")]
			internal static extern ZLibError compress(byte[] dest, ref int destLength, byte[] source, int sourceLength);

			[DllImport("zlibwapi32")]
			internal static extern ZLibError compress2(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality);

			[DllImport("zlibwapi32")]
			internal static extern ZLibError uncompress(byte[] dest, ref int destLen, byte[] source, int sourceLen);
		}

		public Compressor32()
		{
		}

		public string Version => SafeNativeMethods.zlibVersion();

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.compress(dest, ref destLength, source, sourceLength);
		}

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality)
		{
			return SafeNativeMethods.compress2(dest, ref destLength, source, sourceLength, quality);
		}

		public ZLibError Decompress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.uncompress(dest, ref destLength, source, sourceLength);
		}
	}

	public sealed class Compressor64 : ICompressor
	{
		internal class SafeNativeMethods
		{
			[DllImport("zlibwapi64")]
			internal static extern string zlibVersion();

			[DllImport("zlibwapi64")]
			internal static extern ZLibError compress(byte[] dest, ref int destLength, byte[] source, int sourceLength);

			[DllImport("zlibwapi64")]
			internal static extern ZLibError compress2(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality);

			[DllImport("zlibwapi64")]
			internal static extern ZLibError uncompress(byte[] dest, ref int destLen, byte[] source, int sourceLen);
		}

		public Compressor64()
		{
		}

		public string Version => SafeNativeMethods.zlibVersion();

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.compress(dest, ref destLength, source, sourceLength);
		}

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality)
		{
			return SafeNativeMethods.compress2(dest, ref destLength, source, sourceLength, quality);
		}

		public ZLibError Decompress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.uncompress(dest, ref destLength, source, sourceLength);
		}
	}

	public sealed class CompressorUnix32 : ICompressor
	{
		internal class SafeNativeMethods
		{
			[DllImport("libz")]
			internal static extern string zlibVersion();

			[DllImport("libz")]
			internal static extern ZLibError compress(byte[] dest, ref int destLength, byte[] source, int sourceLength);

			[DllImport("libz")]
			internal static extern ZLibError compress2(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality);

			[DllImport("libz")]
			internal static extern ZLibError uncompress(byte[] dest, ref int destLen, byte[] source, int sourceLen);
		}

		public CompressorUnix32()
		{
		}

		public string Version => SafeNativeMethods.zlibVersion();

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.compress(dest, ref destLength, source, sourceLength);
		}

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality)
		{
			return SafeNativeMethods.compress2(dest, ref destLength, source, sourceLength, quality);
		}

		public ZLibError Decompress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.uncompress(dest, ref destLength, source, sourceLength);
		}
	}

	public sealed class CompressorUnix64 : ICompressor
	{
		internal class SafeNativeMethods
		{
			[DllImport("libz")]
			internal static extern string zlibVersion();

			[DllImport("libz")]
			internal static extern ZLibError compress(byte[] dest, ref ulong destLength, byte[] source, int sourceLength);

			[DllImport("libz")]
			internal static extern ZLibError compress2(byte[] dest, ref ulong destLength, byte[] source, int sourceLength, ZLibQuality quality);

			[DllImport("libz")]
			internal static extern ZLibError uncompress(byte[] dest, ref ulong destLen, byte[] source, int sourceLen);
		}

		public CompressorUnix64()
		{
		}

		public string Version => SafeNativeMethods.zlibVersion();

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			var destLengthLong = (ulong)destLength;
			var z = SafeNativeMethods.compress(dest, ref destLengthLong, source, sourceLength);
			destLength = (int)destLengthLong;
			return z;
		}

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality)
		{
			var destLengthLong = (ulong)destLength;
			var z = SafeNativeMethods.compress2(dest, ref destLengthLong, source, sourceLength, quality);
			destLength = (int)destLengthLong;
			return z;
		}

		public ZLibError Decompress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			var destLengthLong = (ulong)destLength;
			var z = SafeNativeMethods.uncompress(dest, ref destLengthLong, source, sourceLength);
			destLength = (int)destLengthLong;
			return z;
		}
	}

	/// <summary>
	/// Handles Server And Client Packet Information 
	/// </summary>
	public delegate void OnPacketReceive(NetState state, PacketReader pvSrc);
	public delegate bool ThrottlePacketCallback(NetState state);

	public class PacketHandler
	{
		private readonly int m_PacketID;
		private readonly int m_Length;
		private readonly bool m_Ingame;
		private readonly OnPacketReceive m_OnReceive;
		private ThrottlePacketCallback m_ThrottleCallback;

		public PacketHandler(int packetID, int length, bool ingame, OnPacketReceive onReceive)
		{
			m_PacketID = packetID;
			m_Length = length;
			m_Ingame = ingame;
			m_OnReceive = onReceive;
		}

		public int PacketID => m_PacketID;

		public int Length => m_Length;

		public OnPacketReceive OnReceive => m_OnReceive;

		public ThrottlePacketCallback ThrottleCallback
		{
			get => m_ThrottleCallback;
			set => m_ThrottleCallback = value;
		}

		public bool Ingame => m_Ingame;
	}

	public enum MessageType
	{
		Regular = 0x00,
		System = 0x01,
		Emote = 0x02,
		Label = 0x06,
		Focus = 0x07,
		Whisper = 0x08,
		Yell = 0x09,
		Spell = 0x0A,

		Guild = 0x0D,
		Alliance = 0x0E,
		Command = 0x0F,

		Encoded = 0xC0
	}

	public static class PacketHandlers
	{
		private static readonly PacketHandler[] m_Handlers;
		private static readonly PacketHandler[] m_6017Handlers;

		private static readonly PacketHandler[] m_ExtendedHandlersLow;
		private static readonly Dictionary<int, PacketHandler> m_ExtendedHandlersHigh;

		private static readonly EncodedPacketHandler[] m_EncodedHandlersLow;
		private static readonly Dictionary<int, EncodedPacketHandler> m_EncodedHandlersHigh;

		public static PacketHandler[] Handlers => m_Handlers;

		static PacketHandlers()
		{
			m_Handlers = new PacketHandler[0x100];
			m_6017Handlers = new PacketHandler[0x100];

			m_ExtendedHandlersLow = new PacketHandler[0x100];
			m_ExtendedHandlersHigh = new Dictionary<int, PacketHandler>();

			m_EncodedHandlersLow = new EncodedPacketHandler[0x100];
			m_EncodedHandlersHigh = new Dictionary<int, EncodedPacketHandler>();

			Register(0x00, 104, false, new OnPacketReceive(CreateCharacter));
			Register(0x01, 5, false, new OnPacketReceive(Disconnect));
			Register(0x02, 7, true, new OnPacketReceive(MovementReq));
			Register(0x03, 0, true, new OnPacketReceive(AsciiSpeech));
			Register(0x04, 2, true, new OnPacketReceive(GodModeRequest));
			Register(0x05, 5, true, new OnPacketReceive(AttackReq));
			Register(0x06, 5, true, new OnPacketReceive(UseReq));
			Register(0x07, 7, true, new OnPacketReceive(LiftReq));
			Register(0x08, 14, true, new OnPacketReceive(DropReq));
			Register(0x09, 5, true, new OnPacketReceive(LookReq));
			Register(0x0A, 11, true, new OnPacketReceive(Edit));
			Register(0x12, 0, true, new OnPacketReceive(TextCommand));
			Register(0x13, 10, true, new OnPacketReceive(EquipReq));
			Register(0x14, 6, true, new OnPacketReceive(ChangeZ));
			Register(0x22, 3, true, new OnPacketReceive(Resynchronize));
			Register(0x2C, 2, true, new OnPacketReceive(DeathStatusResponse));
			Register(0x34, 10, true, new OnPacketReceive(MobileQuery));
			Register(0x3A, 0, true, new OnPacketReceive(ChangeSkillLock));
			Register(0x3B, 0, true, new OnPacketReceive(VendorBuyReply));
			Register(0x47, 11, true, new OnPacketReceive(NewTerrain));
			Register(0x48, 73, true, new OnPacketReceive(NewAnimData));
			Register(0x58, 106, true, new OnPacketReceive(NewRegion));
			Register(0x5D, 73, false, new OnPacketReceive(PlayCharacter));
			Register(0x61, 9, true, new OnPacketReceive(DeleteStatic));
			Register(0x6C, 19, true, new OnPacketReceive(TargetResponse));
			Register(0x6F, 0, true, new OnPacketReceive(SecureTrade));
			Register(0x72, 5, true, new OnPacketReceive(SetWarMode));
			Register(0x73, 2, false, new OnPacketReceive(PingReq));
			Register(0x75, 35, true, new OnPacketReceive(RenameRequest));
			Register(0x79, 9, true, new OnPacketReceive(ResourceQuery));
			Register(0x7E, 2, true, new OnPacketReceive(GodviewQuery));
			Register(0x7D, 13, true, new OnPacketReceive(MenuResponse));
			Register(0x80, 62, false, new OnPacketReceive(AccountLogin));
			Register(0x83, 39, false, new OnPacketReceive(DeleteCharacter));
			Register(0x91, 65, false, new OnPacketReceive(GameLogin));
			Register(0x95, 9, true, new OnPacketReceive(HuePickerResponse));
			Register(0x96, 0, true, new OnPacketReceive(GameCentralMoniter));
			Register(0x98, 0, true, new OnPacketReceive(MobileNameRequest));
			Register(0x9A, 0, true, new OnPacketReceive(AsciiPromptResponse));
			Register(0x9B, 258, true, new OnPacketReceive(HelpRequest));
			Register(0x9D, 51, true, new OnPacketReceive(GMSingle));
			Register(0x9F, 0, true, new OnPacketReceive(VendorSellReply));
			Register(0xA0, 3, false, new OnPacketReceive(PlayServer));
			Register(0xA4, 149, false, new OnPacketReceive(SystemInfo));
			Register(0xA7, 4, true, new OnPacketReceive(RequestScrollWindow));
			Register(0xAD, 0, true, new OnPacketReceive(UnicodeSpeech));
			Register(0xB1, 0, true, new OnPacketReceive(DisplayGumpResponse));
			Register(0xB5, 64, true, new OnPacketReceive(ChatRequest));
			Register(0xB6, 9, true, new OnPacketReceive(ObjectHelpRequest));
			Register(0xB8, 0, true, new OnPacketReceive(ProfileReq));
			Register(0xBB, 9, false, new OnPacketReceive(AccountID));
			Register(0xBD, 0, false, new OnPacketReceive(ClientVersion));
			Register(0xBE, 0, true, new OnPacketReceive(AssistVersion));
			Register(0xBF, 0, true, new OnPacketReceive(ExtendedCommand));
			Register(0xC2, 0, true, new OnPacketReceive(UnicodePromptResponse));
			Register(0xC8, 2, true, new OnPacketReceive(SetUpdateRange));
			Register(0xC9, 6, true, new OnPacketReceive(TripTime));
			Register(0xCA, 6, true, new OnPacketReceive(UTripTime));
			Register(0xCF, 0, false, new OnPacketReceive(AccountLogin));
			Register(0xD0, 0, true, new OnPacketReceive(ConfigurationFile));
			Register(0xD1, 2, true, new OnPacketReceive(LogoutReq));
			Register(0xD6, 0, true, new OnPacketReceive(BatchQueryProperties));
			Register(0xD7, 0, true, new OnPacketReceive(EncodedCommand));
			Register(0xE1, 0, false, new OnPacketReceive(ClientType));
			Register(0xEF, 21, false, new OnPacketReceive(LoginServerSeed));
			Register(0xF4, 0, false, new OnPacketReceive(CrashReport));
			Register(0xF8, 106, false, new OnPacketReceive(CreateCharacter70160));
			Register(0xFB, 2, false, new OnPacketReceive(PublicHouseContent));

			Register6017(0x08, 15, true, new OnPacketReceive(DropReq6017));

			RegisterExtended(0x05, false, new OnPacketReceive(ScreenSize));
			RegisterExtended(0x06, true, new OnPacketReceive(PartyMessage));
			RegisterExtended(0x07, true, new OnPacketReceive(QuestArrow));
			RegisterExtended(0x09, true, new OnPacketReceive(DisarmRequest));
			RegisterExtended(0x0A, true, new OnPacketReceive(StunRequest));
			RegisterExtended(0x0B, false, new OnPacketReceive(Language));
			RegisterExtended(0x0C, true, new OnPacketReceive(CloseStatus));
			RegisterExtended(0x0E, true, new OnPacketReceive(Animate));
			RegisterExtended(0x0F, false, new OnPacketReceive(Empty)); // What's this?
			RegisterExtended(0x10, true, new OnPacketReceive(QueryProperties));
			RegisterExtended(0x13, true, new OnPacketReceive(ContextMenuRequest));
			RegisterExtended(0x15, true, new OnPacketReceive(ContextMenuResponse));
			RegisterExtended(0x1A, true, new OnPacketReceive(StatLockChange));
			RegisterExtended(0x1C, true, new OnPacketReceive(CastSpell));
			RegisterExtended(0x24, false, new OnPacketReceive(UnhandledBF));
			RegisterExtended(0x2C, true, new OnPacketReceive(BandageTarget));
			RegisterExtended(0x32, true, new OnPacketReceive(ToggleFlying));

			RegisterEncoded(0x19, true, new OnEncodedPacketReceive(SetAbility));
			RegisterEncoded(0x28, true, new OnEncodedPacketReceive(GuildGumpRequest));

			RegisterEncoded(0x32, true, new OnEncodedPacketReceive(QuestGumpRequest));
		}

		public static void Register(int packetID, int length, bool ingame, OnPacketReceive onReceive)
		{
			m_Handlers[packetID] = new PacketHandler(packetID, length, ingame, onReceive);

			if (m_6017Handlers[packetID] == null)
			{
				m_6017Handlers[packetID] = new PacketHandler(packetID, length, ingame, onReceive);
			}
		}

		public static PacketHandler GetHandler(int packetID)
		{
			return m_Handlers[packetID];
		}

		public static void Register6017(int packetID, int length, bool ingame, OnPacketReceive onReceive)
		{
			m_6017Handlers[packetID] = new PacketHandler(packetID, length, ingame, onReceive);
		}

		public static PacketHandler Get6017Handler(int packetID)
		{
			return m_6017Handlers[packetID];
		}

		public static void RegisterExtended(int packetID, bool ingame, OnPacketReceive onReceive)
		{
			if (packetID >= 0 && packetID < 0x100)
			{
				m_ExtendedHandlersLow[packetID] = new PacketHandler(packetID, 0, ingame, onReceive);
			}
			else
			{
				m_ExtendedHandlersHigh[packetID] = new PacketHandler(packetID, 0, ingame, onReceive);
			}
		}

		public static PacketHandler GetExtendedHandler(int packetID)
		{
			if (packetID >= 0 && packetID < 0x100)
			{
				return m_ExtendedHandlersLow[packetID];
			}
			else
			{
				PacketHandler handler;
				m_ExtendedHandlersHigh.TryGetValue(packetID, out handler);
				return handler;
			}
		}

		public static void RemoveExtendedHandler(int packetID)
		{
			if (packetID >= 0 && packetID < 0x100)
			{
				m_ExtendedHandlersLow[packetID] = null;
			}
			else
			{
				m_ExtendedHandlersHigh.Remove(packetID);
			}
		}

		public static void RegisterEncoded(int packetID, bool ingame, OnEncodedPacketReceive onReceive)
		{
			if (packetID >= 0 && packetID < 0x100)
			{
				m_EncodedHandlersLow[packetID] = new EncodedPacketHandler(packetID, ingame, onReceive);
			}
			else
			{
				m_EncodedHandlersHigh[packetID] = new EncodedPacketHandler(packetID, ingame, onReceive);
			}
		}

		public static EncodedPacketHandler GetEncodedHandler(int packetID)
		{
			if (packetID >= 0 && packetID < 0x100)
			{
				return m_EncodedHandlersLow[packetID];
			}
			else
			{
				EncodedPacketHandler handler;
				m_EncodedHandlersHigh.TryGetValue(packetID, out handler);
				return handler;
			}
		}

		public static void RemoveEncodedHandler(int packetID)
		{
			if (packetID >= 0 && packetID < 0x100)
			{
				m_EncodedHandlersLow[packetID] = null;
			}
			else
			{
				m_EncodedHandlersHigh.Remove(packetID);
			}
		}

		public static void RegisterThrottler(int packetID, ThrottlePacketCallback t)
		{
			var ph = GetHandler(packetID);

			if (ph != null)
			{
				ph.ThrottleCallback = t;
			}

			ph = Get6017Handler(packetID);

			if (ph != null)
			{
				ph.ThrottleCallback = t;
			}
		}

		private static void UnhandledBF(NetState state, PacketReader pvSrc)
		{
		}

		public static void Empty(NetState state, PacketReader pvSrc)
		{
		}

		public static void SetAbility(NetState state, IEntity e, EncodedReader reader)
		{
			EventSink.InvokeSetAbility(new SetAbilityEventArgs(state.Mobile, reader.ReadInt32()));
		}

		public static void GuildGumpRequest(NetState state, IEntity e, EncodedReader reader)
		{
			EventSink.InvokeGuildGumpRequest(new GuildGumpRequestArgs(state.Mobile));
		}

		public static void QuestGumpRequest(NetState state, IEntity e, EncodedReader reader)
		{
			EventSink.InvokeQuestGumpRequest(new QuestGumpRequestArgs(state.Mobile));
		}

		public static void EncodedCommand(NetState state, PacketReader pvSrc)
		{
			var e = World.FindEntity(pvSrc.ReadInt32());
			int packetID = pvSrc.ReadUInt16();

			var ph = GetEncodedHandler(packetID);

			if (ph != null)
			{
				if (ph.Ingame && state.Mobile == null)
				{
					Console.WriteLine("Client: {0}: Sent ingame packet (0xD7x{1:X2}) before having been attached to a mobile", state, packetID);
					state.Dispose();
				}
				else if (ph.Ingame && state.Mobile.Deleted)
				{
					state.Dispose();
				}
				else
				{
					ph.OnReceive(state, e, new EncodedReader(pvSrc));
				}
			}
			else
			{
				pvSrc.Trace(state);
			}
		}

		public static void RenameRequest(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;
			var targ = World.FindMobile(pvSrc.ReadInt32());

			if (targ != null)
			{
				EventSink.InvokeRenameRequest(new RenameRequestEventArgs(from, targ, pvSrc.ReadStringSafe()));
			}
		}

		public static void ChatRequest(NetState state, PacketReader pvSrc)
		{
			EventSink.InvokeChatRequest(new ChatRequestEventArgs(state.Mobile));
		}

		public static void SecureTrade(NetState state, PacketReader pvSrc)
		{
			switch (pvSrc.ReadByte())
			{
				case 1: // Cancel
					{
						Serial serial = pvSrc.ReadInt32();

						var cont = World.FindItem(serial) as SecureTradeContainer;

						if (cont != null && cont.Trade != null && (cont.Trade.From.Mobile == state.Mobile || cont.Trade.To.Mobile == state.Mobile))
						{
							cont.Trade.Cancel();
						}

						break;
					}
				case 2: // Check
					{
						Serial serial = pvSrc.ReadInt32();

						var cont = World.FindItem(serial) as SecureTradeContainer;

						if (cont != null)
						{
							var trade = cont.Trade;

							var value = (pvSrc.ReadInt32() != 0);

							if (trade != null && trade.From.Mobile == state.Mobile)
							{
								trade.From.Accepted = value;
								trade.Update();
							}
							else if (trade != null && trade.To.Mobile == state.Mobile)
							{
								trade.To.Accepted = value;
								trade.Update();
							}
						}

						break;
					}
				case 3: // Update Gold
					{
						Serial serial = pvSrc.ReadInt32();

						var cont = World.FindItem(serial) as SecureTradeContainer;

						if (cont != null)
						{
							var gold = pvSrc.ReadInt32();
							var plat = pvSrc.ReadInt32();

							var trade = cont.Trade;

							if (trade != null)
							{
								if (trade.From.Mobile == state.Mobile)
								{
									trade.From.Gold = gold;
									trade.From.Plat = plat;
									trade.UpdateFromCurrency();
								}
								else if (trade.To.Mobile == state.Mobile)
								{
									trade.To.Gold = gold;
									trade.To.Plat = plat;
									trade.UpdateToCurrency();
								}
							}
						}
					}
					break;
			}
		}

		public static void VendorBuyReply(NetState state, PacketReader pvSrc)
		{
			pvSrc.Seek(1, SeekOrigin.Begin);

			int msgSize = pvSrc.ReadUInt16();
			var vendor = World.FindMobile(pvSrc.ReadInt32());
			var flag = pvSrc.ReadByte();

			if (vendor == null)
			{
				return;
			}
			else if (vendor.Deleted || !Utility.RangeCheck(vendor.Location, state.Mobile.Location, 10))
			{
				state.Send(new EndVendorBuy(vendor));
				return;
			}

			if (flag == 0x02)
			{
				msgSize -= 1 + 2 + 4 + 1;

				if ((msgSize / 7) > 100)
				{
					return;
				}

				var buyList = new List<BuyItemResponse>(msgSize / 7);
				for (; msgSize > 0; msgSize -= 7)
				{
					var layer = pvSrc.ReadByte();
					Serial serial = pvSrc.ReadInt32();
					int amount = pvSrc.ReadInt16();

					buyList.Add(new BuyItemResponse(serial, amount));
				}

				if (buyList.Count > 0)
				{
					var v = vendor as IVendor;

					if (v != null && v.OnBuyItems(state.Mobile, buyList))
					{
						state.Send(new EndVendorBuy(vendor));
					}
				}
			}
			else
			{
				state.Send(new EndVendorBuy(vendor));
			}
		}

		public static void VendorSellReply(NetState state, PacketReader pvSrc)
		{
			Serial serial = pvSrc.ReadInt32();
			var vendor = World.FindMobile(serial);

			if (vendor == null)
			{
				return;
			}
			else if (vendor.Deleted || !Utility.RangeCheck(vendor.Location, state.Mobile.Location, 10))
			{
				state.Send(new EndVendorSell(vendor));
				return;
			}

			int count = pvSrc.ReadUInt16();
			if (count < 100 && pvSrc.Size == (1 + 2 + 4 + 2 + (count * 6)))
			{
				var sellList = new List<SellItemResponse>(count);

				for (var i = 0; i < count; i++)
				{
					var item = World.FindItem(pvSrc.ReadInt32());
					int Amount = pvSrc.ReadInt16();

					if (item != null && Amount > 0)
					{
						sellList.Add(new SellItemResponse(item, Amount));
					}
				}

				if (sellList.Count > 0)
				{
					var v = vendor as IVendor;

					if (v != null && v.OnSellItems(state.Mobile, sellList))
					{
						state.Send(new EndVendorSell(vendor));
					}
				}
			}
		}

		public static void DeleteCharacter(NetState state, PacketReader pvSrc)
		{
			pvSrc.Seek(30, SeekOrigin.Current);
			var index = pvSrc.ReadInt32();

			EventSink.InvokeDeleteRequest(new DeleteRequestEventArgs(state, index));
		}

		public static void ResourceQuery(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
			}
		}

		public static void GameCentralMoniter(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
				int type = pvSrc.ReadByte();
				var num1 = pvSrc.ReadInt32();

				Console.WriteLine("God Client: {0}: Game central moniter", state);
				Console.WriteLine(" - Type: {0}", type);
				Console.WriteLine(" - Number: {0}", num1);

				pvSrc.Trace(state);
			}
		}

		public static void GodviewQuery(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
				Console.WriteLine("God Client: {0}: Godview query 0x{1:X}", state, pvSrc.ReadByte());
			}
		}

		public static void GMSingle(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
				pvSrc.Trace(state);
			}
		}

		public static void DeathStatusResponse(NetState state, PacketReader pvSrc)
		{
			// Ignored
		}

		public static void ObjectHelpRequest(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;

			Serial serial = pvSrc.ReadInt32();
			int unk = pvSrc.ReadByte();
			var lang = pvSrc.ReadString(3);

			if (serial.IsItem)
			{
				var item = World.FindItem(serial);

				if (item != null && from.Map == item.Map && Utility.InUpdateRange(item.GetWorldLocation(), from.Location) && from.CanSee(item))
				{
					item.OnHelpRequest(from);
				}
			}
			else if (serial.IsMobile)
			{
				var m = World.FindMobile(serial);

				if (m != null && from.Map == m.Map && Utility.InUpdateRange(m.Location, from.Location) && from.CanSee(m))
				{
					m.OnHelpRequest(m);
				}
			}
		}

		public static void MobileNameRequest(NetState state, PacketReader pvSrc)
		{
			var m = World.FindMobile(pvSrc.ReadInt32());

			if (m != null && Utility.InUpdateRange(state.Mobile, m) && state.Mobile.CanSee(m))
			{
				state.Send(new MobileName(m));
			}
		}

		public static void RequestScrollWindow(NetState state, PacketReader pvSrc)
		{
			int lastTip = pvSrc.ReadInt16();
			int type = pvSrc.ReadByte();
		}

		public static void AttackReq(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;
			var m = World.FindMobile(pvSrc.ReadInt32());

			if (m != null)
			{
				from.Attack(m);
			}
		}

		public static void HuePickerResponse(NetState state, PacketReader pvSrc)
		{
			var serial = pvSrc.ReadInt32();
			int value = pvSrc.ReadInt16();
			var hue = pvSrc.ReadInt16() & 0x3FFF;

			hue = Utility.ClipDyedHue(hue);

			foreach (var huePicker in state.HuePickers)
			{
				if (huePicker.Serial == serial)
				{
					state.RemoveHuePicker(huePicker);

					huePicker.OnResponse(hue);

					break;
				}
			}
		}

		public static void TripTime(NetState state, PacketReader pvSrc)
		{
			int unk1 = pvSrc.ReadByte();
			var unk2 = pvSrc.ReadInt32();

			state.Send(new TripTimeResponse(unk1));
		}

		public static void UTripTime(NetState state, PacketReader pvSrc)
		{
			int unk1 = pvSrc.ReadByte();
			var unk2 = pvSrc.ReadInt32();

			state.Send(new UTripTimeResponse(unk1));
		}

		public static void ChangeZ(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
				int x = pvSrc.ReadInt16();
				int y = pvSrc.ReadInt16();
				int z = pvSrc.ReadSByte();

				Console.WriteLine("God Client: {0}: Change Z ({1}, {2}, {3})", state, x, y, z);
			}
		}

		public static void SystemInfo(NetState state, PacketReader pvSrc)
		{
			int v1 = pvSrc.ReadByte();
			int v2 = pvSrc.ReadUInt16();
			int v3 = pvSrc.ReadByte();
			var s1 = pvSrc.ReadString(32);
			var s2 = pvSrc.ReadString(32);
			var s3 = pvSrc.ReadString(32);
			var s4 = pvSrc.ReadString(32);
			int v4 = pvSrc.ReadUInt16();
			int v5 = pvSrc.ReadUInt16();
			var v6 = pvSrc.ReadInt32();
			var v7 = pvSrc.ReadInt32();
			var v8 = pvSrc.ReadInt32();
		}

		public static void Edit(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
				int type = pvSrc.ReadByte(); // 10 = static, 7 = npc, 4 = dynamic
				int x = pvSrc.ReadInt16();
				int y = pvSrc.ReadInt16();
				int id = pvSrc.ReadInt16();
				int z = pvSrc.ReadSByte();
				int hue = pvSrc.ReadUInt16();

				Console.WriteLine("God Client: {0}: Edit {6} ({1}, {2}, {3}) 0x{4:X} (0x{5:X})", state, x, y, z, id, hue, type);
			}
		}

		public static void DeleteStatic(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
				int x = pvSrc.ReadInt16();
				int y = pvSrc.ReadInt16();
				int z = pvSrc.ReadInt16();
				int id = pvSrc.ReadUInt16();

				Console.WriteLine("God Client: {0}: Delete Static ({1}, {2}, {3}) 0x{4:X}", state, x, y, z, id);
			}
		}

		public static void NewAnimData(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
				Console.WriteLine("God Client: {0}: New tile animation", state);

				pvSrc.Trace(state);
			}
		}

		public static void NewTerrain(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
				int x = pvSrc.ReadInt16();
				int y = pvSrc.ReadInt16();
				int id = pvSrc.ReadUInt16();
				int width = pvSrc.ReadInt16();
				int height = pvSrc.ReadInt16();

				Console.WriteLine("God Client: {0}: New Terrain ({1}, {2})+({3}, {4}) 0x{5:X4}", state, x, y, width, height, id);
			}
		}

		public static void NewRegion(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
				var name = pvSrc.ReadString(40);
				var unk = pvSrc.ReadInt32();
				int x = pvSrc.ReadInt16();
				int y = pvSrc.ReadInt16();
				int width = pvSrc.ReadInt16();
				int height = pvSrc.ReadInt16();
				int zStart = pvSrc.ReadInt16();
				int zEnd = pvSrc.ReadInt16();
				var desc = pvSrc.ReadString(40);
				int soundFX = pvSrc.ReadInt16();
				int music = pvSrc.ReadInt16();
				int nightFX = pvSrc.ReadInt16();
				int dungeon = pvSrc.ReadByte();
				int light = pvSrc.ReadInt16();

				Console.WriteLine("God Client: {0}: New Region '{1}' ('{2}')", state, name, desc);
			}
		}

		public static void AccountID(NetState state, PacketReader pvSrc)
		{
		}

		public static bool VerifyGC(NetState state)
		{
			if (state.Mobile == null || state.Mobile.AccessLevel <= AccessLevel.Counselor)
			{
				if (state.Running)
				{
					Console.WriteLine("Warning: {0}: Player using godclient, disconnecting", state);
				}

				state.Dispose();
				return false;
			}
			else
			{
				return true;
			}
		}

		public static void TextCommand(NetState state, PacketReader pvSrc)
		{
			int type = pvSrc.ReadByte();
			var command = pvSrc.ReadString();

			var m = state.Mobile;

			switch (type)
			{
				case 0x00: // Go
					{
						if (VerifyGC(state))
						{
							try
							{
								var split = command.Split(' ');

								var x = Utility.ToInt32(split[0]);
								var y = Utility.ToInt32(split[1]);

								int z;

								if (split.Length >= 3)
								{
									z = Utility.ToInt32(split[2]);
								}
								else if (m.Map != null)
								{
									z = m.Map.GetAverageZ(x, y);
								}
								else
								{
									z = 0;
								}

								m.Location = new Point3D(x, y, z);
							}
							catch
							{
							}
						}

						break;
					}
				case 0xC7: // Animate
					{
						EventSink.InvokeAnimateRequest(new AnimateRequestEventArgs(m, command));

						break;
					}
				case 0x24: // Use skill
					{
						int skillIndex;

						if (!Int32.TryParse(command.Split(' ')[0], out skillIndex))
						{
							break;
						}

						Skills.UseSkill(m, skillIndex);

						break;
					}
				case 0x43: // Open spellbook
					{
						int booktype;

						if (!Int32.TryParse(command, out booktype))
						{
							booktype = 1;
						}

						EventSink.InvokeOpenSpellbookRequest(new OpenSpellbookRequestEventArgs(m, booktype));

						break;
					}
				case 0x27: // Cast spell from book
					{
						var split = command.Split(' ');

						if (split.Length > 0)
						{
							var spellID = Utility.ToInt32(split[0]) - 1;
							var serial = split.Length > 1 ? Utility.ToInt32(split[1]) : -1;

							EventSink.InvokeCastSpellRequest(new CastSpellRequestEventArgs(m, spellID, World.FindItem(serial)));
						}

						break;
					}
				case 0x58: // Open door
					{
						EventSink.InvokeOpenDoorMacroUsed(new OpenDoorMacroEventArgs(m));

						break;
					}
				case 0x56: // Cast spell from macro
					{
						var spellID = Utility.ToInt32(command) - 1;

						EventSink.InvokeCastSpellRequest(new CastSpellRequestEventArgs(m, spellID, null));

						break;
					}
				case 0xF4: // Invoke virtues from macro
					{
						var virtueID = Utility.ToInt32(command) - 1;

						EventSink.InvokeVirtueMacroRequest(new VirtueMacroRequestEventArgs(m, virtueID));

						break;
					}
				case 0x2F: // Old scroll double click
					{
						/*
						 * This command is still sent for items 0xEF3 - 0xEF9
						 *
						 * Command is one of three, depending on the item ID of the scroll:
						 * - [scroll serial]
						 * - [scroll serial] [target serial]
						 * - [scroll serial] [x] [y] [z]
						 */
						break;
					}
				default:
					{
						Console.WriteLine("Client: {0}: Unknown text-command type 0x{1:X2}: {2}", state, type, command);
						break;
					}
			}
		}

		public static void GodModeRequest(NetState state, PacketReader pvSrc)
		{
			if (VerifyGC(state))
			{
				state.Send(new GodModeReply(pvSrc.ReadBoolean()));
			}
		}

		public static void AsciiPromptResponse(NetState state, PacketReader pvSrc)
		{
			var serial = pvSrc.ReadInt32();
			var prompt = pvSrc.ReadInt32();
			var type = pvSrc.ReadInt32();
			var text = pvSrc.ReadStringSafe();

			if (text.Length > 128)
			{
				return;
			}

			var from = state.Mobile;
			var p = from.Prompt;

			if (p != null && p.Serial == serial && p.Serial == prompt)
			{
				from.Prompt = null;

				if (type == 0)
				{
					p.OnCancel(from);
				}
				else
				{
					p.OnResponse(from, text);
				}
			}
		}

		public static void UnicodePromptResponse(NetState state, PacketReader pvSrc)
		{
			var serial = pvSrc.ReadInt32();
			var prompt = pvSrc.ReadInt32();
			var type = pvSrc.ReadInt32();
			var lang = pvSrc.ReadString(4);
			var text = pvSrc.ReadUnicodeStringLESafe();

			if (text.Length > 128)
			{
				return;
			}

			var from = state.Mobile;
			var p = from.Prompt;

			if (p != null && p.Serial == serial && p.Serial == prompt)
			{
				from.Prompt = null;

				if (type == 0)
				{
					p.OnCancel(from);
				}
				else
				{
					p.OnResponse(from, text);
				}
			}
		}

		public static void MenuResponse(NetState state, PacketReader pvSrc)
		{
			var serial = pvSrc.ReadInt32();
			int menuID = pvSrc.ReadInt16(); // unused in our implementation
			int index = pvSrc.ReadInt16();
			int itemID = pvSrc.ReadInt16();
			int hue = pvSrc.ReadInt16();

			index -= 1; // convert from 1-based to 0-based

			foreach (var menu in state.Menus)
			{
				if (menu.Serial == serial)
				{
					state.RemoveMenu(menu);

					if (index >= 0 && index < menu.EntryLength)
					{
						menu.OnResponse(state, index);
					}
					else
					{
						menu.OnCancel(state);
					}

					break;
				}
			}
		}

		public static void ProfileReq(NetState state, PacketReader pvSrc)
		{
			int type = pvSrc.ReadByte();
			Serial serial = pvSrc.ReadInt32();

			var beholder = state.Mobile;
			var beheld = World.FindMobile(serial);

			if (beheld == null)
			{
				return;
			}

			switch (type)
			{
				case 0x00: // display request
					{
						EventSink.InvokeProfileRequest(new ProfileRequestEventArgs(beholder, beheld));

						break;
					}
				case 0x01: // edit request
					{
						pvSrc.ReadInt16(); // Skip
						int length = pvSrc.ReadUInt16();

						if (length > 511)
						{
							return;
						}

						var text = pvSrc.ReadUnicodeString(length);

						EventSink.InvokeChangeProfileRequest(new ChangeProfileRequestEventArgs(beholder, beheld, text));

						break;
					}
			}
		}

		public static void Disconnect(NetState state, PacketReader pvSrc)
		{
			var minusOne = pvSrc.ReadInt32();
		}

		public static void LiftReq(NetState state, PacketReader pvSrc)
		{
			Serial serial = pvSrc.ReadInt32();
			int amount = pvSrc.ReadUInt16();
			var item = World.FindItem(serial);

			bool rejected;
			LRReason reject;

			state.Mobile.Lift(item, amount, out rejected, out reject);
		}

		public static void EquipReq(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;
			var item = from.Holding;

			var valid = (item != null && item.HeldBy == from && item.Map == Map.Internal);

			from.Holding = null;

			if (!valid)
			{
				return;
			}

			pvSrc.Seek(5, SeekOrigin.Current);
			var to = World.FindMobile(pvSrc.ReadInt32());

			if (to == null)
			{
				to = from;
			}

			if (!to.AllowEquipFrom(from) || !to.EquipItem(item))
			{
				item.Bounce(from);
			}

			item.ClearBounce();
		}

		public static void DropReq(NetState state, PacketReader pvSrc)
		{
			pvSrc.ReadInt32(); // serial, ignored
			int x = pvSrc.ReadInt16();
			int y = pvSrc.ReadInt16();
			int z = pvSrc.ReadSByte();
			Serial dest = pvSrc.ReadInt32();

			var loc = new Point3D(x, y, z);

			var from = state.Mobile;

			if (dest.IsMobile)
			{
				from.Drop(World.FindMobile(dest), loc);
			}
			else if (dest.IsItem)
			{
				var item = World.FindItem(dest);

				if (item is BaseMulti && ((BaseMulti)item).AllowsRelativeDrop)
				{
					loc.m_X += item.X;
					loc.m_Y += item.Y;
					from.Drop(loc);
				}
				else
				{
					from.Drop(item, loc);
				}
			}
			else
			{
				from.Drop(loc);
			}
		}

		public static void DropReq6017(NetState state, PacketReader pvSrc)
		{
			pvSrc.ReadInt32(); // serial, ignored
			int x = pvSrc.ReadInt16();
			int y = pvSrc.ReadInt16();
			int z = pvSrc.ReadSByte();
			pvSrc.ReadByte(); // Grid Location?
			Serial dest = pvSrc.ReadInt32();

			var loc = new Point3D(x, y, z);

			var from = state.Mobile;

			if (dest.IsMobile)
			{
				from.Drop(World.FindMobile(dest), loc);
			}
			else if (dest.IsItem)
			{
				var item = World.FindItem(dest);

				if (item is BaseMulti && ((BaseMulti)item).AllowsRelativeDrop)
				{
					loc.m_X += item.X;
					loc.m_Y += item.Y;
					from.Drop(loc);
				}
				else
				{
					from.Drop(item, loc);
				}
			}
			else
			{
				from.Drop(loc);
			}
		}

		public static void ConfigurationFile(NetState state, PacketReader pvSrc)
		{
		}

		public static void LogoutReq(NetState state, PacketReader pvSrc)
		{
			state.Send(new LogoutAck());
		}

		public static void ChangeSkillLock(NetState state, PacketReader pvSrc)
		{
			var s = state.Mobile.Skills[pvSrc.ReadInt16()];

			if (s != null)
			{
				s.SetLockNoRelay((SkillLock)pvSrc.ReadByte());
			}
		}

		public static void HelpRequest(NetState state, PacketReader pvSrc)
		{
			EventSink.InvokeHelpRequest(new HelpRequestEventArgs(state.Mobile));
		}

		public static void TargetResponse(NetState state, PacketReader pvSrc)
		{
			int type = pvSrc.ReadByte();
			var targetID = pvSrc.ReadInt32();
			int flags = pvSrc.ReadByte();
			Serial serial = pvSrc.ReadInt32();
			int x = pvSrc.ReadInt16(), y = pvSrc.ReadInt16(), z = pvSrc.ReadInt16();
			int graphic = pvSrc.ReadUInt16();

			if (targetID == unchecked((int)0xDEADBEEF))
			{
				return;
			}

			var from = state.Mobile;

			var t = from.Target;

			if (t != null)
			{
				var prof = TargetProfile.Acquire(t.GetType());

				if (prof != null)
				{
					prof.Start();
				}

				try
				{
					if (x == -1 && y == -1 && !serial.IsValid)
					{
						// User pressed escape
						t.Cancel(from, TargetCancelType.Canceled);
					}
					else if (Target.TargetIDValidation && t.TargetID != targetID)
					{
						// Sanity, prevent fake target
						return;
					}
					else
					{
						object toTarget;

						if (type == 1)
						{
							if (graphic == 0)
							{
								toTarget = new LandTarget(new Point3D(x, y, z), from.Map);
							}
							else
							{
								var map = from.Map;

								if (map == null || map == Map.Internal)
								{
									t.Cancel(from, TargetCancelType.Canceled);
									return;
								}
								else
								{
									var tiles = map.Tiles.GetStaticTiles(x, y, !t.DisallowMultis);

									var valid = false;
									var hue = 0;

									if (state.HighSeas)
									{
										var id = TileData.ItemTable[graphic & TileData.MaxItemValue];
										if (id.Surface)
										{
											z -= id.Height;
										}
									}

									for (var i = 0; !valid && i < tiles.Length; ++i)
									{
										if (tiles[i].Z == z && tiles[i].ID == graphic)
										{
											valid = true;
											hue = tiles[i].Hue;
										}
									}

									if (!valid)
									{
										t.Cancel(from, TargetCancelType.Canceled);
										return;
									}
									else
									{
										toTarget = new StaticTarget(new Point3D(x, y, z), graphic, hue);
									}
								}
							}
						}
						else if (serial.IsMobile)
						{
							toTarget = World.FindMobile(serial);
						}
						else if (serial.IsItem)
						{
							toTarget = World.FindItem(serial);
						}
						else
						{
							t.Cancel(from, TargetCancelType.Canceled);
							return;
						}

						t.Invoke(from, toTarget);
					}
				}
				finally
				{
					if (prof != null)
					{
						prof.Finish();
					}
				}
			}
		}

		public static void DisplayGumpResponse(NetState state, PacketReader pvSrc)
		{
			var serial = pvSrc.ReadInt32();
			var typeID = pvSrc.ReadInt32();
			var buttonID = pvSrc.ReadInt32();

			foreach (var gump in state.Gumps)
			{
				if (gump.Serial == serial && gump.TypeID == typeID)
				{
					var buttonExists = buttonID == 0; // 0 is always 'close'

					if (!buttonExists)
					{
						foreach (var e in gump.Entries)
						{
							if (e is GumpButton && ((GumpButton)e).ButtonID == buttonID)
							{
								buttonExists = true;
								break;
							}

							if (e is GumpImageTileButton && ((GumpImageTileButton)e).ButtonID == buttonID)
							{
								buttonExists = true;
								break;
							}
						}
					}

					if (!buttonExists)
					{
						state.WriteConsole("Invalid gump response, disconnecting...");
						state.Dispose();
						return;
					}

					var switchCount = pvSrc.ReadInt32();

					if (switchCount < 0 || switchCount > gump.m_Switches)
					{
						state.WriteConsole("Invalid gump response, disconnecting...");
						state.Dispose();
						return;
					}

					var switches = new int[switchCount];

					for (var j = 0; j < switches.Length; ++j)
					{
						switches[j] = pvSrc.ReadInt32();
					}

					var textCount = pvSrc.ReadInt32();

					if (textCount < 0 || textCount > gump.m_TextEntries)
					{
						state.WriteConsole("Invalid gump response, disconnecting...");
						state.Dispose();
						return;
					}

					var textEntries = new TextRelay[textCount];

					for (var j = 0; j < textEntries.Length; ++j)
					{
						int entryID = pvSrc.ReadUInt16();
						int textLength = pvSrc.ReadUInt16();

						if (textLength > 239)
						{
							state.WriteConsole("Invalid gump response, disconnecting...");
							state.Dispose();
							return;
						}

						var text = pvSrc.ReadUnicodeStringSafe(textLength);
						textEntries[j] = new TextRelay(entryID, text);
					}

					state.RemoveGump(gump);

					var prof = GumpProfile.Acquire(gump.GetType());

					if (prof != null)
					{
						prof.Start();
					}

					gump.OnResponse(state, new RelayInfo(buttonID, switches, textEntries));

					if (prof != null)
					{
						prof.Finish();
					}

					return;
				}
			}

			if (typeID == 461)
			{ // Virtue gump
				var switchCount = pvSrc.ReadInt32();

				if (buttonID == 1 && switchCount > 0)
				{
					var beheld = World.FindMobile(pvSrc.ReadInt32());

					if (beheld != null)
					{
						EventSink.InvokeVirtueGumpRequest(new VirtueGumpRequestEventArgs(state.Mobile, beheld));
					}
				}
				else
				{
					var beheld = World.FindMobile(serial);

					if (beheld != null)
					{
						EventSink.InvokeVirtueItemRequest(new VirtueItemRequestEventArgs(state.Mobile, beheld, buttonID));
					}
				}
			}
		}

		public static void SetWarMode(NetState state, PacketReader pvSrc)
		{
			state.Mobile.DelayChangeWarmode(pvSrc.ReadBoolean());
		}

		public static void Resynchronize(NetState state, PacketReader pvSrc)
		{
			var m = state.Mobile;

			if (state.StygianAbyss)
			{
				state.Send(new MobileUpdate(m));
			}
			else
			{
				state.Send(new MobileUpdateOld(m));
			}

			state.Send(MobileIncoming.Create(state, m, m));

			m.SendEverything();

			state.Sequence = 0;

			m.ClearFastwalkStack();
		}

		private static readonly int[] m_EmptyInts = new int[0];

		public static void AsciiSpeech(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;

			var type = (MessageType)pvSrc.ReadByte();
			int hue = pvSrc.ReadInt16();
			pvSrc.ReadInt16(); // font
			var text = pvSrc.ReadStringSafe().Trim();

			if (text.Length <= 0 || text.Length > 128)
			{
				return;
			}

			if (!Enum.IsDefined(typeof(MessageType), type))
			{
				type = MessageType.Regular;
			}

			from.DoSpeech(text, m_EmptyInts, type, Utility.ClipDyedHue(hue));
		}

		private static readonly KeywordList m_KeywordList = new KeywordList();

		public static void UnicodeSpeech(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;

			var type = (MessageType)pvSrc.ReadByte();
			int hue = pvSrc.ReadInt16();
			pvSrc.ReadInt16(); // font
			var lang = pvSrc.ReadString(4);
			string text;

			var isEncoded = (type & MessageType.Encoded) != 0;
			int[] keywords;

			if (isEncoded)
			{
				int value = pvSrc.ReadInt16();
				var count = (value & 0xFFF0) >> 4;
				var hold = value & 0xF;

				if (count < 0 || count > 50)
				{
					return;
				}

				var keyList = m_KeywordList;

				for (var i = 0; i < count; ++i)
				{
					int speechID;

					if ((i & 1) == 0)
					{
						hold <<= 8;
						hold |= pvSrc.ReadByte();
						speechID = hold;
						hold = 0;
					}
					else
					{
						value = pvSrc.ReadInt16();
						speechID = (value & 0xFFF0) >> 4;
						hold = value & 0xF;
					}

					if (!keyList.Contains(speechID))
					{
						keyList.Add(speechID);
					}
				}

				text = pvSrc.ReadUTF8StringSafe();

				keywords = keyList.ToArray();
			}
			else
			{
				text = pvSrc.ReadUnicodeStringSafe();

				keywords = m_EmptyInts;
			}

			text = text.Trim();

			if (text.Length <= 0 || text.Length > 128)
			{
				return;
			}

			type &= ~MessageType.Encoded;

			if (!Enum.IsDefined(typeof(MessageType), type))
			{
				type = MessageType.Regular;
			}

			from.Language = lang;
			from.DoSpeech(text, keywords, type, Utility.ClipDyedHue(hue));
		}

		public static void UseReq(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;

			if (from.AccessLevel >= AccessLevel.Counselor || Core.TickCount - from.NextActionTime >= 0)
			{
				var value = pvSrc.ReadInt32();

				if ((value & ~0x7FFFFFFF) != 0)
				{
					from.OnPaperdollRequest();
				}
				else
				{
					Serial s = value;

					if (s.IsMobile)
					{
						var m = World.FindMobile(s);

						if (m != null && !m.Deleted)
						{
							from.Use(m);
						}
					}
					else if (s.IsItem)
					{
						var item = World.FindItem(s);

						if (item != null && !item.Deleted)
						{
							from.Use(item);
						}
					}
				}

				from.NextActionTime = Core.TickCount + Mobile.ActionDelay;
			}
			else
			{
				from.SendActionMessage();
			}
		}

		private static bool m_SingleClickProps;

		public static bool SingleClickProps
		{
			get => m_SingleClickProps;
			set => m_SingleClickProps = value;
		}

		public static void LookReq(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;

			Serial s = pvSrc.ReadInt32();

			if (s.IsMobile)
			{
				var m = World.FindMobile(s);

				if (m != null && from.CanSee(m) && Utility.InUpdateRange(from, m))
				{
					if (m_SingleClickProps)
					{
						m.OnAosSingleClick(from);
					}
					else
					{
						if (from.Region.OnSingleClick(from, m))
						{
							m.OnSingleClick(from);
						}
					}
				}
			}
			else if (s.IsItem)
			{
				var item = World.FindItem(s);

				if (item != null && !item.Deleted && from.CanSee(item) && Utility.InUpdateRange(from.Location, item.GetWorldLocation()))
				{
					if (m_SingleClickProps)
					{
						item.OnAosSingleClick(from);
					}
					else if (from.Region.OnSingleClick(from, item))
					{
						if (item.Parent is Item)
						{
							((Item)item.Parent).OnSingleClickContained(from, item);
						}

						item.OnSingleClick(from);
					}
				}
			}
		}

		public static void PingReq(NetState state, PacketReader pvSrc)
		{
			state.Send(PingAck.Instantiate(pvSrc.ReadByte()));
		}

		public static void SetUpdateRange(NetState state, PacketReader pvSrc)
		{
			state.Send(ChangeUpdateRange.Instantiate(18));
		}

		private const int BadFood = unchecked((int)0xBAADF00D);
		private const int BadUOTD = unchecked((int)0xFFCEFFCE);

		public static void MovementReq(NetState state, PacketReader pvSrc)
		{
			var dir = (Direction)pvSrc.ReadByte();
			int seq = pvSrc.ReadByte();
			var key = pvSrc.ReadInt32();

			var m = state.Mobile;

			if ((state.Sequence == 0 && seq != 0) || !m.Move(dir))
			{
				state.Send(new MovementRej(seq, m));
				state.Sequence = 0;

				m.ClearFastwalkStack();
			}
			else
			{
				++seq;

				if (seq == 256)
				{
					seq = 1;
				}

				state.Sequence = seq;
			}
		}

		public static int[] m_ValidAnimations = new int[]
			{
				6, 21, 32, 33,
				100, 101, 102,
				103, 104, 105,
				106, 107, 108,
				109, 110, 111,
				112, 113, 114,
				115, 116, 117,
				118, 119, 120,
				121, 123, 124,
				125, 126, 127,
				128
			};

		public static int[] ValidAnimations { get => m_ValidAnimations; set => m_ValidAnimations = value; }

		public static void Animate(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;
			var action = pvSrc.ReadInt32();

			var ok = false;

			for (var i = 0; !ok && i < m_ValidAnimations.Length; ++i)
			{
				ok = (action == m_ValidAnimations[i]);
			}

			if (from != null && ok && from.Alive && from.Body.IsHuman && !from.Mounted)
			{
				from.Animate(action, 7, 1, true, false, 0);
			}
		}

		public static void QuestArrow(NetState state, PacketReader pvSrc)
		{
			var rightClick = pvSrc.ReadBoolean();
			var from = state.Mobile;

			if (from != null && from.QuestArrow != null)
			{
				from.QuestArrow.OnClick(rightClick);
			}
		}

		public static void ExtendedCommand(NetState state, PacketReader pvSrc)
		{
			int packetID = pvSrc.ReadUInt16();

			var ph = GetExtendedHandler(packetID);

			if (ph != null)
			{
				if (ph.Ingame && state.Mobile == null)
				{
					Console.WriteLine("Client: {0}: Sent ingame packet (0xBFx{1:X2}) before having been attached to a mobile", state, packetID);
					state.Dispose();
				}
				else if (ph.Ingame && state.Mobile.Deleted)
				{
					state.Dispose();
				}
				else
				{
					ph.OnReceive(state, pvSrc);
				}
			}
			else
			{
				pvSrc.Trace(state);
			}
		}

		public static void CastSpell(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;

			if (from == null)
			{
				return;
			}

			Item spellbook = null;

			if (pvSrc.ReadInt16() == 1)
			{
				spellbook = World.FindItem(pvSrc.ReadInt32());
			}

			var spellID = pvSrc.ReadInt16() - 1;

			EventSink.InvokeCastSpellRequest(new CastSpellRequestEventArgs(from, spellID, spellbook));
		}

		public static void BandageTarget(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;

			if (from == null)
			{
				return;
			}

			if (from.AccessLevel >= AccessLevel.Counselor || Core.TickCount - from.NextActionTime >= 0)
			{
				var bandage = World.FindItem(pvSrc.ReadInt32());

				if (bandage == null)
				{
					return;
				}

				var target = World.FindMobile(pvSrc.ReadInt32());

				if (target == null)
				{
					return;
				}

				EventSink.InvokeBandageTargetRequest(new BandageTargetRequestEventArgs(from, bandage, target));

				from.NextActionTime = Core.TickCount + Mobile.ActionDelay;
			}
			else
			{
				from.SendActionMessage();
			}
		}

		public static void ToggleFlying(NetState state, PacketReader pvSrc)
		{
			state.Mobile.ToggleFlying();
		}
		public static void BatchQueryProperties(NetState state, PacketReader pvSrc)
		{
			if (!ObjectPropertyList.Enabled)
			{
				return;
			}

			var from = state.Mobile;

			var length = pvSrc.Size - 3;

			if (length < 0 || (length % 4) != 0)
			{
				return;
			}

			var count = length / 4;

			for (var i = 0; i < count; ++i)
			{
				Serial s = pvSrc.ReadInt32();

				if (s.IsMobile)
				{
					var m = World.FindMobile(s);

					if (m != null && from.CanSee(m) && Utility.InUpdateRange(from, m))
					{
						m.SendPropertiesTo(from);
					}
				}
				else if (s.IsItem)
				{
					var item = World.FindItem(s);

					if (item != null && !item.Deleted && from.CanSee(item) && Utility.InUpdateRange(from.Location, item.GetWorldLocation()))
					{
						item.SendPropertiesTo(from);
					}
				}
			}
		}

		public static void QueryProperties(NetState state, PacketReader pvSrc)
		{
			if (!ObjectPropertyList.Enabled)
			{
				return;
			}

			var from = state.Mobile;

			Serial s = pvSrc.ReadInt32();

			if (s.IsMobile)
			{
				var m = World.FindMobile(s);

				if (m != null && from.CanSee(m) && Utility.InUpdateRange(from, m))
				{
					m.SendPropertiesTo(from);
				}
			}
			else if (s.IsItem)
			{
				var item = World.FindItem(s);

				if (item != null && !item.Deleted && from.CanSee(item) && Utility.InUpdateRange(from.Location, item.GetWorldLocation()))
				{
					item.SendPropertiesTo(from);
				}
			}
		}

		public static void PartyMessage(NetState state, PacketReader pvSrc)
		{
			if (state.Mobile == null)
			{
				return;
			}

			switch (pvSrc.ReadByte())
			{
				case 0x01: PartyMessage_AddMember(state, pvSrc); break;
				case 0x02: PartyMessage_RemoveMember(state, pvSrc); break;
				case 0x03: PartyMessage_PrivateMessage(state, pvSrc); break;
				case 0x04: PartyMessage_PublicMessage(state, pvSrc); break;
				case 0x06: PartyMessage_SetCanLoot(state, pvSrc); break;
				case 0x08: PartyMessage_Accept(state, pvSrc); break;
				case 0x09: PartyMessage_Decline(state, pvSrc); break;
				default: pvSrc.Trace(state); break;
			}
		}

		public static void PartyMessage_AddMember(NetState state, PacketReader pvSrc)
		{
			if (PartyCommands.Handler != null)
			{
				PartyCommands.Handler.OnAdd(state.Mobile);
			}
		}

		public static void PartyMessage_RemoveMember(NetState state, PacketReader pvSrc)
		{
			if (PartyCommands.Handler != null)
			{
				PartyCommands.Handler.OnRemove(state.Mobile, World.FindMobile(pvSrc.ReadInt32()));
			}
		}

		public static void PartyMessage_PrivateMessage(NetState state, PacketReader pvSrc)
		{
			if (PartyCommands.Handler != null)
			{
				PartyCommands.Handler.OnPrivateMessage(state.Mobile, World.FindMobile(pvSrc.ReadInt32()), pvSrc.ReadUnicodeStringSafe());
			}
		}

		public static void PartyMessage_PublicMessage(NetState state, PacketReader pvSrc)
		{
			if (PartyCommands.Handler != null)
			{
				PartyCommands.Handler.OnPublicMessage(state.Mobile, pvSrc.ReadUnicodeStringSafe());
			}
		}

		public static void PartyMessage_SetCanLoot(NetState state, PacketReader pvSrc)
		{
			if (PartyCommands.Handler != null)
			{
				PartyCommands.Handler.OnSetCanLoot(state.Mobile, pvSrc.ReadBoolean());
			}
		}

		public static void PartyMessage_Accept(NetState state, PacketReader pvSrc)
		{
			if (PartyCommands.Handler != null)
			{
				PartyCommands.Handler.OnAccept(state.Mobile, World.FindMobile(pvSrc.ReadInt32()));
			}
		}

		public static void PartyMessage_Decline(NetState state, PacketReader pvSrc)
		{
			if (PartyCommands.Handler != null)
			{
				PartyCommands.Handler.OnDecline(state.Mobile, World.FindMobile(pvSrc.ReadInt32()));
			}
		}

		public static void StunRequest(NetState state, PacketReader pvSrc)
		{
			EventSink.InvokeStunRequest(new StunRequestEventArgs(state.Mobile));
		}

		public static void DisarmRequest(NetState state, PacketReader pvSrc)
		{
			EventSink.InvokeDisarmRequest(new DisarmRequestEventArgs(state.Mobile));
		}

		public static void StatLockChange(NetState state, PacketReader pvSrc)
		{
			int stat = pvSrc.ReadByte();
			int lockValue = pvSrc.ReadByte();

			if (lockValue > 2)
			{
				lockValue = 0;
			}

			var m = state.Mobile;

			if (m != null)
			{
				switch (stat)
				{
					case 0: m.StrLock = (StatLockType)lockValue; break;
					case 1: m.DexLock = (StatLockType)lockValue; break;
					case 2: m.IntLock = (StatLockType)lockValue; break;
				}
			}
		}

		public static void ScreenSize(NetState state, PacketReader pvSrc)
		{
			var width = pvSrc.ReadInt32();
			var unk = pvSrc.ReadInt32();
		}

		public static void ContextMenuResponse(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;

			if (from != null)
			{
				var menu = from.ContextMenu;

				from.ContextMenu = null;

				if (menu != null && from != null && from == menu.From)
				{
					var entity = World.FindEntity(pvSrc.ReadInt32());

					if (entity != null && entity == menu.Target && from.CanSee(entity))
					{
						Point3D p;

						if (entity is Mobile)
						{
							p = entity.Location;
						}
						else if (entity is Item)
						{
							p = ((Item)entity).GetWorldLocation();
						}
						else
						{
							return;
						}

						int index = pvSrc.ReadUInt16();

						if (index >= 0 && index < menu.Entries.Length)
						{
							var e = menu.Entries[index];

							var range = e.Range;

							if (range == -1)
							{
								range = 18;
							}

							if (e.Enabled && from.InRange(p, range))
							{
								e.OnClick();
							}
						}
					}
				}
			}
		}

		public static void ContextMenuRequest(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;
			var target = World.FindEntity(pvSrc.ReadInt32());

			if (from != null && target != null && from.Map == target.Map && from.CanSee(target))
			{
				if (target is Mobile && !Utility.InUpdateRange(from.Location, target.Location))
				{
					return;
				}
				else if (target is Item && !Utility.InUpdateRange(from.Location, ((Item)target).GetWorldLocation()))
				{
					return;
				}

				if (!from.CheckContextMenuDisplay(target))
				{
					return;
				}

				var c = new ContextMenu(from, target);

				if (c.Entries.Length > 0)
				{
					if (target is Item)
					{
						object root = ((Item)target).RootParent;

						if (root is Mobile && root != from && ((Mobile)root).AccessLevel >= from.AccessLevel)
						{
							for (var i = 0; i < c.Entries.Length; ++i)
							{
								if (!c.Entries[i].NonLocalUse)
								{
									c.Entries[i].Enabled = false;
								}
							}
						}
					}

					from.ContextMenu = c;
				}
			}
		}

		public static void CloseStatus(NetState state, PacketReader pvSrc)
		{
			Serial serial = pvSrc.ReadInt32();
		}

		public static void Language(NetState state, PacketReader pvSrc)
		{
			var lang = pvSrc.ReadString(4);

			if (state.Mobile != null)
			{
				state.Mobile.Language = lang;
			}
		}

		public static void AssistVersion(NetState state, PacketReader pvSrc)
		{
			var unk = pvSrc.ReadInt32();
			var av = pvSrc.ReadString();
		}

		public static void ClientVersion(NetState state, PacketReader pvSrc)
		{
			var version = state.Version = new CV(pvSrc.ReadString());

			EventSink.InvokeClientVersionReceived(new ClientVersionReceivedArgs(state, version));
		}

		public static void ClientType(NetState state, PacketReader pvSrc)
		{
			pvSrc.ReadUInt16();

			int type = pvSrc.ReadUInt16();
			var version = state.Version = new CV(pvSrc.ReadString());

			//EventSink.InvokeClientVersionReceived( new ClientVersionReceivedArgs( state, version ) );//todo
		}

		public static void MobileQuery(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;

			pvSrc.ReadInt32(); // 0xEDEDEDED
			int type = pvSrc.ReadByte();
			var m = World.FindMobile(pvSrc.ReadInt32());

			if (m != null)
			{
				switch (type)
				{
					case 0x00: // Unknown, sent by godclient
						{
							if (VerifyGC(state))
							{
								Console.WriteLine("God Client: {0}: Query 0x{1:X2} on {2} '{3}'", state, type, m.Serial, m.Name);
							}

							break;
						}
					case 0x04: // Stats
						{
							m.OnStatsQuery(from);
							break;
						}
					case 0x05:
						{
							m.OnSkillsQuery(from);
							break;
						}
					default:
						{
							pvSrc.Trace(state);
							break;
						}
				}
			}
		}

		public delegate void PlayCharCallback(NetState state, bool val);

		public static PlayCharCallback ThirdPartyAuthCallback = null, ThirdPartyHackedCallback = null;

		private static readonly byte[] m_ThirdPartyAuthKey = new byte[]
			{
				0x9, 0x11, 0x83, (byte)'+', 0x4, 0x17, 0x83,
				0x5, 0x24, 0x85,
				0x7, 0x17, 0x87,
				0x6, 0x19, 0x88,
			};

		private class LoginTimer : Timer
		{
			private readonly NetState m_State;
			private readonly Mobile m_Mobile;

			public LoginTimer(NetState state, Mobile m) : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
			{
				m_State = state;
				m_Mobile = m;
			}

			protected override void OnTick()
			{
				if (m_State == null)
				{
					Stop();
				}

				if (m_State.Version != null)
				{
					m_State.BlockAllPackets = false;
					DoLogin(m_State, m_Mobile);
					Stop();
				}
			}
		}

		public static void PlayCharacter(NetState state, PacketReader pvSrc)
		{
			pvSrc.ReadInt32(); // 0xEDEDEDED

			var name = pvSrc.ReadString(30);

			pvSrc.Seek(2, SeekOrigin.Current);
			var flags = pvSrc.ReadInt32();

			if (FeatureProtection.DisabledFeatures != 0 && ThirdPartyAuthCallback != null)
			{
				var authOK = false;

				var razorFeatures = (((ulong)pvSrc.ReadUInt32()) << 32) | pvSrc.ReadUInt32();

				if (razorFeatures == (ulong)FeatureProtection.DisabledFeatures)
				{
					var match = true;
					for (var i = 0; match && i < m_ThirdPartyAuthKey.Length; i++)
					{
						match = match && pvSrc.ReadByte() == m_ThirdPartyAuthKey[i];
					}

					if (match)
					{
						authOK = true;
					}
				}
				else
				{
					pvSrc.Seek(16, SeekOrigin.Current);
				}

				ThirdPartyAuthCallback(state, authOK);
			}
			else
			{
				pvSrc.Seek(24, SeekOrigin.Current);
			}

			if (ThirdPartyHackedCallback != null)
			{
				pvSrc.Seek(-2, SeekOrigin.Current);
				if (pvSrc.ReadUInt16() == 0xDEAD)
				{
					ThirdPartyHackedCallback(state, true);
				}
			}

			if (!state.Running)
			{
				return;
			}

			var charSlot = pvSrc.ReadInt32();
			var clientIP = pvSrc.ReadInt32();

			var a = state.Account;

			if (a == null || charSlot < 0 || charSlot >= a.Length)
			{
				state.Dispose();
			}
			else
			{
				var m = a[charSlot];

				// Check if anyone is using this account
				for (var i = 0; i < a.Length; ++i)
				{
					var check = a[i];

					if (check != null && check.Map != Map.Internal && check != m)
					{
						Console.WriteLine("Login: {0}: Account in use", state);
						state.Send(new PopupMessage(PMMessage.CharInWorld));
						return;
					}
				}

				if (m == null)
				{
					state.Dispose();
				}
				else
				{
					if (m.NetState != null)
					{
						m.NetState.Dispose();
					}

					NetState.ProcessDisposedQueue();

					state.Send(new ClientVersionReq());

					state.BlockAllPackets = true;

					state.Flags = (ClientFlags)flags;

					state.Mobile = m;
					m.NetState = state;

					new LoginTimer(state, m).Start();
				}
			}
		}

		public static void DoLogin(NetState state, Mobile m)
		{
			state.Send(new LoginConfirm(m));

			if (m.Map != null)
			{
				state.Send(new MapChange(m));
			}

			state.Send(new MapPatches());

			state.Send(SeasonChange.Instantiate(m.GetSeason(), true));

			state.Send(SupportedFeatures.Instantiate(state));

			state.Sequence = 0;

			if (state.NewMobileIncoming)
			{
				state.Send(new MobileUpdate(m));
				state.Send(new MobileUpdate(m));

				m.CheckLightLevels(true);

				state.Send(new MobileUpdate(m));

				state.Send(new MobileIncoming(m, m));
				//state.Send( new MobileAttributes( m ) );
				state.Send(new MobileStatus(m, m));
				state.Send(Server.Network.SetWarMode.Instantiate(m.Warmode));

				m.SendEverything();

				state.Send(SupportedFeatures.Instantiate(state));
				state.Send(new MobileUpdate(m));
				//state.Send( new MobileAttributes( m ) );
				state.Send(new MobileStatus(m, m));
				state.Send(Server.Network.SetWarMode.Instantiate(m.Warmode));
				state.Send(new MobileIncoming(m, m));
			}
			else if (state.StygianAbyss)
			{
				state.Send(new MobileUpdate(m));
				state.Send(new MobileUpdate(m));

				m.CheckLightLevels(true);

				state.Send(new MobileUpdate(m));

				state.Send(new MobileIncomingSA(m, m));
				//state.Send( new MobileAttributes( m ) );
				state.Send(new MobileStatus(m, m));
				state.Send(Server.Network.SetWarMode.Instantiate(m.Warmode));

				m.SendEverything();

				state.Send(SupportedFeatures.Instantiate(state));
				state.Send(new MobileUpdate(m));
				//state.Send( new MobileAttributes( m ) );
				state.Send(new MobileStatus(m, m));
				state.Send(Server.Network.SetWarMode.Instantiate(m.Warmode));
				state.Send(new MobileIncomingSA(m, m));
			}
			else
			{
				state.Send(new MobileUpdateOld(m));
				state.Send(new MobileUpdateOld(m));

				m.CheckLightLevels(true);

				state.Send(new MobileUpdateOld(m));

				state.Send(new MobileIncomingOld(m, m));
				//state.Send( new MobileAttributes( m ) );
				state.Send(new MobileStatus(m, m));
				state.Send(Server.Network.SetWarMode.Instantiate(m.Warmode));

				m.SendEverything();

				state.Send(SupportedFeatures.Instantiate(state));
				state.Send(new MobileUpdateOld(m));
				//state.Send( new MobileAttributes( m ) );
				state.Send(new MobileStatus(m, m));
				state.Send(Server.Network.SetWarMode.Instantiate(m.Warmode));
				state.Send(new MobileIncomingOld(m, m));
			}

			state.Send(LoginComplete.Instance);
			state.Send(new CurrentTime());
			state.Send(SeasonChange.Instantiate(m.GetSeason(), true));
			state.Send(new MapChange(m));

			EventSink.InvokeLogin(new LoginEventArgs(m));

			m.ClearFastwalkStack();
		}

		public static void CreateCharacter(NetState state, PacketReader pvSrc)
		{
			var unk1 = pvSrc.ReadInt32();
			var unk2 = pvSrc.ReadInt32();
			int unk3 = pvSrc.ReadByte();
			var name = pvSrc.ReadString(30);

			pvSrc.Seek(2, SeekOrigin.Current);
			var flags = pvSrc.ReadInt32();
			pvSrc.Seek(8, SeekOrigin.Current);
			int prof = pvSrc.ReadByte();
			pvSrc.Seek(15, SeekOrigin.Current);

			//bool female = pvSrc.ReadBoolean();

			int genderRace = pvSrc.ReadByte();

			int str = pvSrc.ReadByte();
			int dex = pvSrc.ReadByte();
			int intl = pvSrc.ReadByte();
			int is1 = pvSrc.ReadByte();
			int vs1 = pvSrc.ReadByte();
			int is2 = pvSrc.ReadByte();
			int vs2 = pvSrc.ReadByte();
			int is3 = pvSrc.ReadByte();
			int vs3 = pvSrc.ReadByte();
			int hue = pvSrc.ReadUInt16();
			int hairVal = pvSrc.ReadInt16();
			int hairHue = pvSrc.ReadInt16();
			int hairValf = pvSrc.ReadInt16();
			int hairHuef = pvSrc.ReadInt16();
			pvSrc.ReadByte();
			int cityIndex = pvSrc.ReadByte();
			var charSlot = pvSrc.ReadInt32();
			var clientIP = pvSrc.ReadInt32();
			int shirtHue = pvSrc.ReadInt16();
			int pantsHue = pvSrc.ReadInt16();

			/*
			Pre-7.0.0.0:
			0x00, 0x01 -> Human Male, Human Female
			0x02, 0x03 -> Elf Male, Elf Female

			Post-7.0.0.0:
			0x00, 0x01
			0x02, 0x03 -> Human Male, Human Female
			0x04, 0x05 -> Elf Male, Elf Female
			0x05, 0x06 -> Gargoyle Male, Gargoyle Female
			*/

			var female = ((genderRace % 2) != 0);

			Race race = null;

			if (state.StygianAbyss)
			{
				var raceID = (byte)(genderRace < 4 ? 0 : ((genderRace / 2) - 1));
				race = Race.Races[raceID];
			}
			else
			{
				race = Race.Races[(byte)(genderRace / 2)];
			}

			if (race == null)
			{
				race = Race.DefaultRace;
			}

			var info = state.CityInfo;
			var a = state.Account;

			if (info == null || a == null || cityIndex < 0 || cityIndex >= info.Length)
			{
				state.Dispose();
			}
			else
			{
				// Check if anyone is using this account
				for (var i = 0; i < a.Length; ++i)
				{
					var check = a[i];

					if (check != null && check.Map != Map.Internal)
					{
						Console.WriteLine("Login: {0}: Account in use", state);
						state.Send(new PopupMessage(PMMessage.CharInWorld));
						return;
					}
				}

				state.Flags = (ClientFlags)flags;

				var args = new CharacterCreatedEventArgs(
					state, a,
					name, female, hue,
					str, dex, intl,
					info[cityIndex],
					new SkillNameValue[3]
					{
						new SkillNameValue( (SkillName)is1, vs1 ),
						new SkillNameValue( (SkillName)is2, vs2 ),
						new SkillNameValue( (SkillName)is3, vs3 ),
					},
					shirtHue, pantsHue,
					hairVal, hairHue,
					hairValf, hairHuef,
					prof,
					race
					);

				state.Send(new ClientVersionReq());

				state.BlockAllPackets = true;

				EventSink.InvokeCharacterCreated(args);

				var m = args.Mobile;

				if (m != null)
				{
					state.Mobile = m;
					m.NetState = state;
					new LoginTimer(state, m).Start();
				}
				else
				{
					state.BlockAllPackets = false;
					state.Dispose();
				}
			}
		}

		public static void CreateCharacter70160(NetState state, PacketReader pvSrc)
		{
			var unk1 = pvSrc.ReadInt32();
			var unk2 = pvSrc.ReadInt32();
			int unk3 = pvSrc.ReadByte();
			var name = pvSrc.ReadString(30);

			pvSrc.Seek(2, SeekOrigin.Current);
			var flags = pvSrc.ReadInt32();
			pvSrc.Seek(8, SeekOrigin.Current);
			int prof = pvSrc.ReadByte();
			pvSrc.Seek(15, SeekOrigin.Current);

			int genderRace = pvSrc.ReadByte();

			int str = pvSrc.ReadByte();
			int dex = pvSrc.ReadByte();
			int intl = pvSrc.ReadByte();
			int is1 = pvSrc.ReadByte();
			int vs1 = pvSrc.ReadByte();
			int is2 = pvSrc.ReadByte();
			int vs2 = pvSrc.ReadByte();
			int is3 = pvSrc.ReadByte();
			int vs3 = pvSrc.ReadByte();
			int is4 = pvSrc.ReadByte();
			int vs4 = pvSrc.ReadByte();

			int hue = pvSrc.ReadUInt16();
			int hairVal = pvSrc.ReadInt16();
			int hairHue = pvSrc.ReadInt16();
			int hairValf = pvSrc.ReadInt16();
			int hairHuef = pvSrc.ReadInt16();
			pvSrc.ReadByte();
			int cityIndex = pvSrc.ReadByte();
			var charSlot = pvSrc.ReadInt32();
			var clientIP = pvSrc.ReadInt32();
			int shirtHue = pvSrc.ReadInt16();
			int pantsHue = pvSrc.ReadInt16();

			/*
			0x00, 0x01
			0x02, 0x03 -> Human Male, Human Female
			0x04, 0x05 -> Elf Male, Elf Female
			0x05, 0x06 -> Gargoyle Male, Gargoyle Female
			*/

			var female = ((genderRace % 2) != 0);

			Race race = null;

			var raceID = (byte)(genderRace < 4 ? 0 : ((genderRace / 2) - 1));
			race = Race.Races[raceID];

			if (race == null)
			{
				race = Race.DefaultRace;
			}

			var info = state.CityInfo;
			var a = state.Account;

			if (info == null || a == null || cityIndex < 0 || cityIndex >= info.Length)
			{
				state.Dispose();
			}
			else
			{
				// Check if anyone is using this account
				for (var i = 0; i < a.Length; ++i)
				{
					var check = a[i];

					if (check != null && check.Map != Map.Internal)
					{
						Console.WriteLine("Login: {0}: Account in use", state);
						state.Send(new PopupMessage(PMMessage.CharInWorld));
						return;
					}
				}

				state.Flags = (ClientFlags)flags;

				var args = new CharacterCreatedEventArgs(
					state, a,
					name, female, hue,
					str, dex, intl,
					info[cityIndex],
					new SkillNameValue[4]
					{
						new SkillNameValue( (SkillName)is1, vs1 ),
						new SkillNameValue( (SkillName)is2, vs2 ),
						new SkillNameValue( (SkillName)is3, vs3 ),
						new SkillNameValue( (SkillName)is4, vs4 ),
					},
					shirtHue, pantsHue,
					hairVal, hairHue,
					hairValf, hairHuef,
					prof,
					race
					);

				state.Send(new ClientVersionReq());

				state.BlockAllPackets = true;

				EventSink.InvokeCharacterCreated(args);

				var m = args.Mobile;

				if (m != null)
				{
					state.Mobile = m;
					m.NetState = state;
					new LoginTimer(state, m).Start();
				}
				else
				{
					state.BlockAllPackets = false;
					state.Dispose();
				}
			}
		}

		public static void PublicHouseContent(NetState state, PacketReader pvSrc)
		{
			//state.Mobile.PublicHouseContent = pvSrc.ReadBoolean();
		}

		private static bool m_ClientVerification = true;

		public static bool ClientVerification
		{
			get => m_ClientVerification;
			set => m_ClientVerification = value;
		}

		internal struct AuthIDPersistence
		{
			public DateTime Age;
			public ClientVersion Version;

			public AuthIDPersistence(ClientVersion v)
			{
				Age = DateTime.UtcNow;
				Version = v;
			}
		}

		private const int m_AuthIDWindowSize = 128;
		private static readonly Dictionary<int, AuthIDPersistence> m_AuthIDWindow = new Dictionary<int, AuthIDPersistence>(m_AuthIDWindowSize);

		private static int GenerateAuthID(NetState state)
		{
			if (m_AuthIDWindow.Count == m_AuthIDWindowSize)
			{
				var oldestID = 0;
				var oldest = DateTime.MaxValue;

				foreach (var kvp in m_AuthIDWindow)
				{
					if (kvp.Value.Age < oldest)
					{
						oldestID = kvp.Key;
						oldest = kvp.Value.Age;
					}
				}

				m_AuthIDWindow.Remove(oldestID);
			}

			int authID;

			do
			{
				authID = Utility.Random(1, Int32.MaxValue - 1);

				if (Utility.RandomBool())
				{
					authID |= 1 << 31;
				}
			} while (m_AuthIDWindow.ContainsKey(authID));

			m_AuthIDWindow[authID] = new AuthIDPersistence(state.Version);

			return authID;
		}

		public static void GameLogin(NetState state, PacketReader pvSrc)
		{
			if (state.SentFirstPacket)
			{
				state.Dispose();
				return;
			}

			state.SentFirstPacket = true;

			var authID = pvSrc.ReadInt32();

			if (m_AuthIDWindow.ContainsKey(authID))
			{
				var ap = m_AuthIDWindow[authID];
				m_AuthIDWindow.Remove(authID);

				state.Version = ap.Version;
			}
			else if (m_ClientVerification)
			{
				Console.WriteLine("Login: {0}: Invalid client detected, disconnecting", state);
				state.Dispose();
				return;
			}

			if (state.m_AuthID != 0 && authID != state.m_AuthID)
			{
				Console.WriteLine("Login: {0}: Invalid client detected, disconnecting", state);
				state.Dispose();
				return;
			}
			else if (state.m_AuthID == 0 && authID != state.m_Seed)
			{
				Console.WriteLine("Login: {0}: Invalid client detected, disconnecting", state);
				state.Dispose();
				return;
			}

			var username = pvSrc.ReadString(30);
			var password = pvSrc.ReadString(30);

			var e = new GameLoginEventArgs(state, username, password);

			EventSink.InvokeGameLogin(e);

			if (e.Accepted)
			{
				state.CityInfo = e.CityInfo;
				state.CompressionEnabled = true;

				state.Send(SupportedFeatures.Instantiate(state));

				if (state.NewCharacterList)
				{
					state.Send(new CharacterList(state.Account, state.CityInfo));
				}
				else
				{
					state.Send(new CharacterListOld(state.Account, state.CityInfo));
				}
			}
			else
			{
				state.Dispose();
			}
		}

		public static void PlayServer(NetState state, PacketReader pvSrc)
		{
			int index = pvSrc.ReadInt16();
			var info = state.ServerInfo;
			var a = state.Account;

			if (info == null || a == null || index < 0 || index >= info.Length)
			{
				state.Dispose();
			}
			else
			{
				var si = info[index];

				state.m_AuthID = PlayServerAck.m_AuthID = GenerateAuthID(state);

				state.SentFirstPacket = false;
				state.Send(new PlayServerAck(si));
			}
		}

		public static void LoginServerSeed(NetState state, PacketReader pvSrc)
		{
			state.m_Seed = pvSrc.ReadInt32();
			state.Seeded = true;

			if (state.m_Seed == 0)
			{
				Console.WriteLine("Login: {0}: Invalid client detected, disconnecting", state);
				state.Dispose();
				return;
			}

			var clientMaj = pvSrc.ReadInt32();
			var clientMin = pvSrc.ReadInt32();
			var clientRev = pvSrc.ReadInt32();
			var clientPat = pvSrc.ReadInt32();

			state.Version = new ClientVersion(clientMaj, clientMin, clientRev, clientPat);
		}

		public static void CrashReport(NetState state, PacketReader pvSrc)
		{
			var clientMaj = pvSrc.ReadByte();
			var clientMin = pvSrc.ReadByte();
			var clientRev = pvSrc.ReadByte();
			var clientPat = pvSrc.ReadByte();

			var x = pvSrc.ReadUInt16();
			var y = pvSrc.ReadUInt16();
			var z = pvSrc.ReadSByte();
			var map = pvSrc.ReadByte();

			var account = pvSrc.ReadString(32);
			var character = pvSrc.ReadString(32);
			var ip = pvSrc.ReadString(15);

			var unk1 = pvSrc.ReadInt32();
			var exception = pvSrc.ReadInt32();

			var process = pvSrc.ReadString(100);
			var report = pvSrc.ReadString(100);

			pvSrc.ReadByte(); // 0x00

			var offset = pvSrc.ReadInt32();

			int count = pvSrc.ReadByte();

			for (var i = 0; i < count; i++)
			{
				var address = pvSrc.ReadInt32();
			}
		}

		public static void AccountLogin(NetState state, PacketReader pvSrc)
		{
			if (state.SentFirstPacket)
			{
				state.Dispose();
				return;
			}

			state.SentFirstPacket = true;

			var username = pvSrc.ReadString(30);
			var password = pvSrc.ReadString(30);

			var e = new AccountLoginEventArgs(state, username, password);

			EventSink.InvokeAccountLogin(e);

			if (e.Accepted)
			{
				AccountLogin_ReplyAck(state);
			}
			else
			{
				AccountLogin_ReplyRej(state, e.RejectReason);
			}
		}

		public static void AccountLogin_ReplyAck(NetState state)
		{
			var e = new ServerListEventArgs(state, state.Account);

			EventSink.InvokeServerList(e);

			if (e.Rejected)
			{
				state.Account = null;
				state.Send(new AccountLoginRej(ALRReason.BadComm));
				state.Dispose();
			}
			else
			{
				var info = e.Servers.ToArray();

				state.ServerInfo = info;

				state.Send(new AccountLoginAck(info));
			}
		}

		public static void AccountLogin_ReplyRej(NetState state, ALRReason reason)
		{
			state.Send(new AccountLoginRej(reason));
			state.Dispose();
		}
	}

	public interface IPacketEncoder
	{
		void EncodeOutgoingPacket(NetState to, ref byte[] buffer, ref int length);
		void DecodeIncomingPacket(NetState from, ref byte[] buffer, ref int length);
	}

	public delegate void NetStateCreatedCallback(NetState ns);

	public class NetState : IComparable<NetState>
	{
		private Socket m_Socket;
		private readonly IPAddress m_Address;
		private ByteQueue m_Buffer;
		private byte[] m_RecvBuffer;
		private readonly SendQueue m_SendQueue;
		private bool m_Seeded;
		private bool m_Running;

#if NewAsyncSockets
		private SocketAsyncEventArgs m_ReceiveEventArgs, m_SendEventArgs;
#else
		private AsyncCallback m_OnReceive, m_OnSend;
#endif

		private readonly MessagePump m_MessagePump;
		private ServerInfo[] m_ServerInfo;
		private IAccount m_Account;
		private Mobile m_Mobile;
		private CityInfo[] m_CityInfo;
		private List<Gump> m_Gumps;
		private List<HuePicker> m_HuePickers;
		private List<IMenu> m_Menus;
		private readonly List<SecureTrade> m_Trades;
		private int m_Sequence;
		private bool m_CompressionEnabled;
		private readonly string m_ToString;
		private ClientVersion m_Version;
		private bool m_SentFirstPacket;
		private bool m_BlockAllPackets;

		private readonly DateTime m_ConnectedOn;

		public DateTime ConnectedOn => m_ConnectedOn;

		public TimeSpan ConnectedFor => (DateTime.UtcNow - m_ConnectedOn);

		internal int m_Seed;
		internal int m_AuthID;

		public IPAddress Address => m_Address;

		private ClientFlags m_Flags;

		private static bool m_Paused;

		[Flags]
		private enum AsyncState
		{
			Pending = 0x01,
			Paused = 0x02
		}

		private AsyncState m_AsyncState;
		private readonly object m_AsyncLock = new object();

		private IPacketEncoder m_Encoder = null;

		public IPacketEncoder PacketEncoder
		{
			get => m_Encoder;
			set => m_Encoder = value;
		}

		private static NetStateCreatedCallback m_CreatedCallback;

		public static NetStateCreatedCallback CreatedCallback
		{
			get => m_CreatedCallback;
			set => m_CreatedCallback = value;
		}

		public bool SentFirstPacket
		{
			get => m_SentFirstPacket;
			set => m_SentFirstPacket = value;
		}

		public bool BlockAllPackets
		{
			get => m_BlockAllPackets;
			set => m_BlockAllPackets = value;
		}

		public ClientFlags Flags
		{
			get => m_Flags;
			set => m_Flags = value;
		}

		public ClientVersion Version
		{
			get => m_Version;
			set
			{
				m_Version = value;

				if (value >= m_Version704565)
				{
					_ProtocolChanges = ProtocolChanges.Version704565;
				}
				else if (value >= m_Version70331)
				{
					_ProtocolChanges = ProtocolChanges.Version70331;
				}
				else if (value >= m_Version70300)
				{
					_ProtocolChanges = ProtocolChanges.Version70300;
				}
				else if (value >= m_Version70160)
				{
					_ProtocolChanges = ProtocolChanges.Version70160;
				}
				else if (value >= m_Version70130)
				{
					_ProtocolChanges = ProtocolChanges.Version70130;
				}
				else if (value >= m_Version7090)
				{
					_ProtocolChanges = ProtocolChanges.Version7090;
				}
				else if (value >= m_Version7000)
				{
					_ProtocolChanges = ProtocolChanges.Version7000;
				}
				else if (value >= m_Version60142)
				{
					_ProtocolChanges = ProtocolChanges.Version60142;
				}
				else if (value >= m_Version6017)
				{
					_ProtocolChanges = ProtocolChanges.Version6017;
				}
				else if (value >= m_Version6000)
				{
					_ProtocolChanges = ProtocolChanges.Version6000;
				}
				else if (value >= m_Version502b)
				{
					_ProtocolChanges = ProtocolChanges.Version502b;
				}
				else if (value >= m_Version500a)
				{
					_ProtocolChanges = ProtocolChanges.Version500a;
				}
				else if (value >= m_Version407a)
				{
					_ProtocolChanges = ProtocolChanges.Version407a;
				}
				else if (value >= m_Version400a)
				{
					_ProtocolChanges = ProtocolChanges.Version400a;
				}
			}
		}

		private static readonly ClientVersion m_Version400a = new ClientVersion("4.0.0a");
		private static readonly ClientVersion m_Version407a = new ClientVersion("4.0.7a");
		private static readonly ClientVersion m_Version500a = new ClientVersion("5.0.0a");
		private static readonly ClientVersion m_Version502b = new ClientVersion("5.0.2b");
		private static readonly ClientVersion m_Version6000 = new ClientVersion("6.0.0.0");
		private static readonly ClientVersion m_Version6017 = new ClientVersion("6.0.1.7");
		private static readonly ClientVersion m_Version60142 = new ClientVersion("6.0.14.2");
		private static readonly ClientVersion m_Version7000 = new ClientVersion("7.0.0.0");
		private static readonly ClientVersion m_Version7090 = new ClientVersion("7.0.9.0");
		private static readonly ClientVersion m_Version70130 = new ClientVersion("7.0.13.0");
		private static readonly ClientVersion m_Version70160 = new ClientVersion("7.0.16.0");
		private static readonly ClientVersion m_Version70300 = new ClientVersion("7.0.30.0");
		private static readonly ClientVersion m_Version70331 = new ClientVersion("7.0.33.1");
		private static readonly ClientVersion m_Version704565 = new ClientVersion("7.0.45.65");

		private ProtocolChanges _ProtocolChanges;

		private enum ProtocolChanges
		{
			NewSpellbook = 0x00000001,
			DamagePacket = 0x00000002,
			Unpack = 0x00000004,
			BuffIcon = 0x00000008,
			NewHaven = 0x00000010,
			ContainerGridLines = 0x00000020,
			ExtendedSupportedFeatures = 0x00000040,
			StygianAbyss = 0x00000080,
			HighSeas = 0x00000100,
			NewCharacterList = 0x00000200,
			NewCharacterCreation = 0x00000400,
			ExtendedStatus = 0x00000800,
			NewMobileIncoming = 0x00001000,
			NewSecureTrading = 0x00002000,

			Version400a = NewSpellbook,
			Version407a = Version400a | DamagePacket,
			Version500a = Version407a | Unpack,
			Version502b = Version500a | BuffIcon,
			Version6000 = Version502b | NewHaven,
			Version6017 = Version6000 | ContainerGridLines,
			Version60142 = Version6017 | ExtendedSupportedFeatures,
			Version7000 = Version60142 | StygianAbyss,
			Version7090 = Version7000 | HighSeas,
			Version70130 = Version7090 | NewCharacterList,
			Version70160 = Version70130 | NewCharacterCreation,
			Version70300 = Version70160 | ExtendedStatus,
			Version70331 = Version70300 | NewMobileIncoming,
			Version704565 = Version70331 | NewSecureTrading
		}

		public bool NewSpellbook => ((_ProtocolChanges & ProtocolChanges.NewSpellbook) != 0);
		public bool DamagePacket => ((_ProtocolChanges & ProtocolChanges.DamagePacket) != 0);
		public bool Unpack => ((_ProtocolChanges & ProtocolChanges.Unpack) != 0);
		public bool BuffIcon => ((_ProtocolChanges & ProtocolChanges.BuffIcon) != 0);
		public bool NewHaven => ((_ProtocolChanges & ProtocolChanges.NewHaven) != 0);
		public bool ContainerGridLines => ((_ProtocolChanges & ProtocolChanges.ContainerGridLines) != 0);
		public bool ExtendedSupportedFeatures => ((_ProtocolChanges & ProtocolChanges.ExtendedSupportedFeatures) != 0);
		public bool StygianAbyss => ((_ProtocolChanges & ProtocolChanges.StygianAbyss) != 0);
		public bool HighSeas => ((_ProtocolChanges & ProtocolChanges.HighSeas) != 0);
		public bool NewCharacterList => ((_ProtocolChanges & ProtocolChanges.NewCharacterList) != 0);
		public bool NewCharacterCreation => ((_ProtocolChanges & ProtocolChanges.NewCharacterCreation) != 0);
		public bool ExtendedStatus => ((_ProtocolChanges & ProtocolChanges.ExtendedStatus) != 0);
		public bool NewMobileIncoming => ((_ProtocolChanges & ProtocolChanges.NewMobileIncoming) != 0);
		public bool NewSecureTrading => ((_ProtocolChanges & ProtocolChanges.NewSecureTrading) != 0);

		public bool IsUOTDClient => ((m_Flags & ClientFlags.UOTD) != 0 || (m_Version != null && m_Version.Type == ClientType.UOTD));

		public bool IsSAClient => (m_Version != null && m_Version.Type == ClientType.SA);

		public List<SecureTrade> Trades => m_Trades;

		public void ValidateAllTrades()
		{
			for (var i = m_Trades.Count - 1; i >= 0; --i)
			{
				if (i >= m_Trades.Count)
				{
					continue;
				}

				var trade = m_Trades[i];

				if (trade.From.Mobile.Deleted || trade.To.Mobile.Deleted || !trade.From.Mobile.Alive || !trade.To.Mobile.Alive || !trade.From.Mobile.InRange(trade.To.Mobile, 2) || trade.From.Mobile.Map != trade.To.Mobile.Map)
				{
					trade.Cancel();
				}
			}
		}

		public void CancelAllTrades()
		{
			for (var i = m_Trades.Count - 1; i >= 0; --i)
			{
				if (i < m_Trades.Count)
				{
					m_Trades[i].Cancel();
				}
			}
		}

		public void RemoveTrade(SecureTrade trade)
		{
			m_Trades.Remove(trade);
		}

		public SecureTrade FindTrade(Mobile m)
		{
			for (var i = 0; i < m_Trades.Count; ++i)
			{
				var trade = m_Trades[i];

				if (trade.From.Mobile == m || trade.To.Mobile == m)
				{
					return trade;
				}
			}

			return null;
		}

		public SecureTradeContainer FindTradeContainer(Mobile m)
		{
			for (var i = 0; i < m_Trades.Count; ++i)
			{
				var trade = m_Trades[i];

				var from = trade.From;
				var to = trade.To;

				if (from.Mobile == m_Mobile && to.Mobile == m)
				{
					return from.Container;
				}
				else if (from.Mobile == m && to.Mobile == m_Mobile)
				{
					return to.Container;
				}
			}

			return null;
		}

		public SecureTradeContainer AddTrade(NetState state)
		{
			var newTrade = new SecureTrade(m_Mobile, state.m_Mobile);

			m_Trades.Add(newTrade);
			state.m_Trades.Add(newTrade);

			return newTrade.From.Container;
		}

		public bool CompressionEnabled
		{
			get => m_CompressionEnabled;
			set => m_CompressionEnabled = value;
		}

		public int Sequence
		{
			get => m_Sequence;
			set => m_Sequence = value;
		}

		public List<Gump> Gumps => m_Gumps;

		public List<HuePicker> HuePickers => m_HuePickers;

		public List<IMenu> Menus => m_Menus;

		private static int m_GumpCap = 512, m_HuePickerCap = 512, m_MenuCap = 512;

		public static int GumpCap
		{
			get => m_GumpCap;
			set => m_GumpCap = value;
		}

		public static int HuePickerCap
		{
			get => m_HuePickerCap;
			set => m_HuePickerCap = value;
		}

		public static int MenuCap
		{
			get => m_MenuCap;
			set => m_MenuCap = value;
		}

		public void WriteConsole(string text)
		{
			Console.WriteLine("Client: {0}: {1}", this, text);
		}

		public void WriteConsole(string format, params object[] args)
		{
			WriteConsole(String.Format(format, args));
		}

		public void AddMenu(IMenu menu)
		{
			if (m_Menus == null)
			{
				m_Menus = new List<IMenu>();
			}

			if (m_Menus.Count < m_MenuCap)
			{
				m_Menus.Add(menu);
			}
			else
			{
				WriteConsole("Exceeded menu cap, disconnecting...");
				Dispose();
			}
		}

		public void RemoveMenu(IMenu menu)
		{
			if (m_Menus != null)
			{
				m_Menus.Remove(menu);
			}
		}

		public void RemoveMenu(int index)
		{
			if (m_Menus != null)
			{
				m_Menus.RemoveAt(index);
			}
		}

		public void ClearMenus()
		{
			if (m_Menus != null)
			{
				m_Menus.Clear();
			}
		}

		public void AddHuePicker(HuePicker huePicker)
		{
			if (m_HuePickers == null)
			{
				m_HuePickers = new List<HuePicker>();
			}

			if (m_HuePickers.Count < m_HuePickerCap)
			{
				m_HuePickers.Add(huePicker);
			}
			else
			{
				WriteConsole("Exceeded hue picker cap, disconnecting...");
				Dispose();
			}
		}

		public void RemoveHuePicker(HuePicker huePicker)
		{
			if (m_HuePickers != null)
			{
				m_HuePickers.Remove(huePicker);
			}
		}

		public void RemoveHuePicker(int index)
		{
			if (m_HuePickers != null)
			{
				m_HuePickers.RemoveAt(index);
			}
		}

		public void ClearHuePickers()
		{
			if (m_HuePickers != null)
			{
				m_HuePickers.Clear();
			}
		}

		public void AddGump(Gump gump)
		{
			if (m_Gumps == null)
			{
				m_Gumps = new List<Gump>();
			}

			if (m_Gumps.Count < m_GumpCap)
			{
				m_Gumps.Add(gump);
			}
			else
			{
				WriteConsole("Exceeded gump cap, disconnecting...");
				Dispose();
			}
		}

		public void RemoveGump(Gump gump)
		{
			if (m_Gumps != null)
			{
				m_Gumps.Remove(gump);
			}
		}

		public void RemoveGump(int index)
		{
			if (m_Gumps != null)
			{
				m_Gumps.RemoveAt(index);
			}
		}

		public void ClearGumps()
		{
			if (m_Gumps != null)
			{
				m_Gumps.Clear();
			}
		}

		public void LaunchBrowser(string url)
		{
			Send(new MessageLocalized(Serial.MinusOne, -1, MessageType.Label, 0x35, 3, 501231, "", ""));
			Send(new LaunchBrowser(url));
		}

		public CityInfo[] CityInfo
		{
			get => m_CityInfo;
			set => m_CityInfo = value;
		}

		public Mobile Mobile
		{
			get => m_Mobile;
			set => m_Mobile = value;
		}

		public ServerInfo[] ServerInfo
		{
			get => m_ServerInfo;
			set => m_ServerInfo = value;
		}

		public IAccount Account
		{
			get => m_Account;
			set => m_Account = value;
		}

		public override string ToString()
		{
			return m_ToString;
		}

		private static readonly List<NetState> m_Instances = new List<NetState>();

		public static List<NetState> Instances => m_Instances;

		private static readonly BufferPool m_ReceiveBufferPool = new BufferPool("Receive", 2048, 2048);

		public NetState(Socket socket, MessagePump messagePump)
		{
			m_Socket = socket;
			m_Buffer = new ByteQueue();
			m_Seeded = false;
			m_Running = false;
			m_RecvBuffer = m_ReceiveBufferPool.AcquireBuffer();
			m_MessagePump = messagePump;
			m_Gumps = new List<Gump>();
			m_HuePickers = new List<HuePicker>();
			m_Menus = new List<IMenu>();
			m_Trades = new List<SecureTrade>();

			m_SendQueue = new SendQueue();

			m_NextCheckActivity = Core.TickCount + 30000;

			m_Instances.Add(this);

			try
			{
				m_Address = Utility.Intern(((IPEndPoint)m_Socket.RemoteEndPoint).Address);
				m_ToString = m_Address.ToString();
			}
			catch (Exception ex)
			{
				TraceException(ex);
				m_Address = IPAddress.None;
				m_ToString = "(error)";
			}

			m_ConnectedOn = DateTime.UtcNow;

			if (m_CreatedCallback != null)
			{
				m_CreatedCallback(this);
			}
		}

		private bool _sending;
		private readonly object _sendL = new object();

		public virtual void Send(Packet p)
		{
			if (m_Socket == null || m_BlockAllPackets)
			{
				p.OnSend();
				return;
			}

			int length;
			var buffer = p.Compile(m_CompressionEnabled, out length);

			if (buffer != null)
			{
				if (buffer.Length <= 0 || length <= 0)
				{
					p.OnSend();
					return;
				}

				PacketSendProfile prof = null;

				if (Core.Profiling)
				{
					prof = PacketSendProfile.Acquire(p.GetType());
				}

				if (prof != null)
				{
					prof.Start();
				}

				if (m_Encoder != null)
				{
					m_Encoder.EncodeOutgoingPacket(this, ref buffer, ref length);
				}

				try
				{
					SendQueue.Gram gram;

					lock (_sendL)
					{
						lock (m_SendQueue)
						{
							gram = m_SendQueue.Enqueue(buffer, length);
						}

						if (gram != null && !_sending)
						{
							_sending = true;
#if NewAsyncSockets
							m_SendEventArgs.SetBuffer( gram.Buffer, 0, gram.Length );
							Send_Start();
#else
							try
							{
								m_Socket.BeginSend(gram.Buffer, 0, gram.Length, SocketFlags.None, m_OnSend, m_Socket);
							}
							catch (Exception ex)
							{
								TraceException(ex);
								Dispose(false);
							}
#endif
						}
					}
				}
				catch (CapacityExceededException)
				{
					Console.WriteLine("Client: {0}: Too much data pending, disconnecting...", this);
					Dispose(false);
				}

				p.OnSend();

				if (prof != null)
				{
					prof.Finish(length);
				}
			}
			else
			{
				Console.WriteLine("Client: {0}: null buffer send, disconnecting...", this);
				using (var op = new StreamWriter("null_send.log", true))
				{
					op.WriteLine("{0} Client: {1}: null buffer send, disconnecting...", DateTime.UtcNow, this);
					op.WriteLine(new System.Diagnostics.StackTrace());
				}
				Dispose();
			}
		}

#if NewAsyncSockets
		public void Start() {
			m_ReceiveEventArgs = new SocketAsyncEventArgs();
			m_ReceiveEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>( Receive_Completion );
			m_ReceiveEventArgs.SetBuffer( m_RecvBuffer, 0, m_RecvBuffer.Length );

			m_SendEventArgs = new SocketAsyncEventArgs();
			m_SendEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>( Send_Completion );

			m_Running = true;

			if ( m_Socket == null || m_Paused ) {
				return;
			}

			Receive_Start();
		}

		private void Receive_Start()
		{
			try {
				bool result = false;

				do {
					lock ( m_AsyncLock ) {
						if ( ( m_AsyncState & ( AsyncState.Pending | AsyncState.Paused ) ) == 0 ) {
							m_AsyncState |= AsyncState.Pending;
							result = !m_Socket.ReceiveAsync( m_ReceiveEventArgs );

							if ( result )
								Receive_Process( m_ReceiveEventArgs );
						}
					}
				} while ( result );
			} catch ( Exception ex ) {
				TraceException( ex );
				Dispose( false );
			}
		}

		private void Receive_Completion( object sender, SocketAsyncEventArgs e )
		{
			Receive_Process( e );

			if ( !m_Disposing )
				Receive_Start();
		}

		private void Receive_Process( SocketAsyncEventArgs e )
		{
			int byteCount = e.BytesTransferred;

			if ( e.SocketError != SocketError.Success || byteCount <= 0 ) {
				Dispose( false );
				return;
			} else if ( m_Disposing ) {
				return;
			}

			m_NextCheckActivity = Core.TickCount + 90000;

			byte[] buffer = m_RecvBuffer;

			if ( m_Encoder != null )
				m_Encoder.DecodeIncomingPacket( this, ref buffer, ref byteCount );

			lock ( m_Buffer )
				m_Buffer.Enqueue( buffer, 0, byteCount );

			m_MessagePump.OnReceive( this );

			lock ( m_AsyncLock ) {
				m_AsyncState &= ~AsyncState.Pending;
			}
		}

		private void Send_Start()
		{
			try {
				bool result = false;

				do {
					result = !m_Socket.SendAsync( m_SendEventArgs );

					if ( result )
						Send_Process( m_SendEventArgs );
				} while ( result ); 
			} catch ( Exception ex ) {
				TraceException( ex );
				Dispose( false );
			}
		}

		private void Send_Completion( object sender, SocketAsyncEventArgs e )
		{
			Send_Process( e );

			if ( m_Disposing )
				return;

			if ( m_CoalesceSleep >= 0 ) {
				Thread.Sleep( m_CoalesceSleep );
			}

			SendQueue.Gram gram;

			lock ( m_SendQueue ) {
				gram = m_SendQueue.Dequeue();

				if (gram == null && m_SendQueue.IsFlushReady)
					gram = m_SendQueue.CheckFlushReady();
			}

			if ( gram != null ) {
				m_SendEventArgs.SetBuffer( gram.Buffer, 0, gram.Length );
				Send_Start();
			} else {
				lock (_sendL)
					_sending = false;
			}
		}

		private void Send_Process( SocketAsyncEventArgs e )
		{
			int bytes = e.BytesTransferred;

			if ( e.SocketError != SocketError.Success || bytes <= 0 ) {
				Dispose( false );
				return;
			}

			m_NextCheckActivity = Core.TickCount + 90000;
		}

		public static void Pause() {
			m_Paused = true;

			for ( int i = 0; i < m_Instances.Count; ++i ) {
				NetState ns = m_Instances[i];

				lock ( ns.m_AsyncLock ) {
					ns.m_AsyncState |= AsyncState.Paused;
				}
			}
		}

		public static void Resume() {
			m_Paused = false;

			for ( int i = 0; i < m_Instances.Count; ++i ) {
				NetState ns = m_Instances[i];

				if ( ns.m_Socket == null ) {
					continue;
				}

				lock ( ns.m_AsyncLock ) {
					ns.m_AsyncState &= ~AsyncState.Paused;

					if ( ( ns.m_AsyncState & AsyncState.Pending ) == 0 )
						ns.Receive_Start();
				}
			}
		}

		public bool Flush() {
			if ( m_Socket == null )
					return false;

			lock (_sendL) {
				if (_sending)
					return false;

				SendQueue.Gram gram;

				lock ( m_SendQueue ) {
					if (!m_SendQueue.IsFlushReady)
						return false;

					gram = m_SendQueue.CheckFlushReady();
				}

				if ( gram != null ) {
					_sending = true;
					m_SendEventArgs.SetBuffer( gram.Buffer, 0, gram.Length );
					Send_Start();
				}
			}

			return false;
		}

#else

		public void Start()
		{
			m_OnReceive = new AsyncCallback(OnReceive);
			m_OnSend = new AsyncCallback(OnSend);

			m_Running = true;

			if (m_Socket == null || m_Paused)
			{
				return;
			}

			try
			{
				lock (m_AsyncLock)
				{
					if ((m_AsyncState & (AsyncState.Pending | AsyncState.Paused)) == 0)
					{
						InternalBeginReceive();
					}
				}
			}
			catch (Exception ex)
			{
				TraceException(ex);
				Dispose(false);
			}
		}

		private void InternalBeginReceive()
		{
			m_AsyncState |= AsyncState.Pending;

			m_Socket.BeginReceive(m_RecvBuffer, 0, m_RecvBuffer.Length, SocketFlags.None, m_OnReceive, m_Socket);
		}

		private void OnReceive(IAsyncResult asyncResult)
		{
			var s = (Socket)asyncResult.AsyncState;

			try
			{
				var byteCount = s.EndReceive(asyncResult);

				if (byteCount > 0)
				{
					m_NextCheckActivity = Core.TickCount + 90000;

					var buffer = m_RecvBuffer;

					if (m_Encoder != null)
					{
						m_Encoder.DecodeIncomingPacket(this, ref buffer, ref byteCount);
					}

					lock (m_Buffer)
					{
						m_Buffer.Enqueue(buffer, 0, byteCount);
					}

					m_MessagePump.OnReceive(this);

					lock (m_AsyncLock)
					{
						m_AsyncState &= ~AsyncState.Pending;

						if ((m_AsyncState & AsyncState.Paused) == 0)
						{
							try
							{
								InternalBeginReceive();
							}
							catch (Exception ex)
							{
								TraceException(ex);
								Dispose(false);
							}
						}
					}
				}
				else
				{
					Dispose(false);
				}
			}
			catch
			{
				Dispose(false);
			}
		}

		private void OnSend(IAsyncResult asyncResult)
		{
			var s = (Socket)asyncResult.AsyncState;

			try
			{
				var bytes = s.EndSend(asyncResult);

				if (bytes <= 0)
				{
					Dispose(false);
					return;
				}

				m_NextCheckActivity = Core.TickCount + 90000;

				if (m_CoalesceSleep >= 0)
				{
					Thread.Sleep(m_CoalesceSleep);
				}

				SendQueue.Gram gram;

				lock (m_SendQueue)
				{
					gram = m_SendQueue.Dequeue();

					if (gram == null && m_SendQueue.IsFlushReady)
					{
						gram = m_SendQueue.CheckFlushReady();
					}
				}

				if (gram != null)
				{
					try
					{
						s.BeginSend(gram.Buffer, 0, gram.Length, SocketFlags.None, m_OnSend, s);
					}
					catch (Exception ex)
					{
						TraceException(ex);
						Dispose(false);
					}
				}
				else
				{
					lock (_sendL)
					{
						_sending = false;
					}
				}
			}
			catch (Exception)
			{
				Dispose(false);
			}
		}

		public static void Pause()
		{
			m_Paused = true;

			for (var i = 0; i < m_Instances.Count; ++i)
			{
				var ns = m_Instances[i];

				lock (ns.m_AsyncLock)
				{
					ns.m_AsyncState |= AsyncState.Paused;
				}
			}
		}

		public static void Resume()
		{
			m_Paused = false;

			for (var i = 0; i < m_Instances.Count; ++i)
			{
				var ns = m_Instances[i];

				if (ns.m_Socket == null)
				{
					continue;
				}

				lock (ns.m_AsyncLock)
				{
					ns.m_AsyncState &= ~AsyncState.Paused;

					try
					{
						if ((ns.m_AsyncState & AsyncState.Pending) == 0)
						{
							ns.InternalBeginReceive();
						}
					}
					catch (Exception ex)
					{
						TraceException(ex);
						ns.Dispose(false);
					}
				}
			}
		}

		public bool Flush()
		{
			if (m_Socket == null)
			{
				return false;
			}

			lock (_sendL)
			{
				if (_sending)
				{
					return false;
				}

				SendQueue.Gram gram;

				lock (m_SendQueue)
				{
					if (!m_SendQueue.IsFlushReady)
					{
						return false;
					}

					gram = m_SendQueue.CheckFlushReady();
				}

				if (gram != null)
				{
					try
					{
						_sending = true;
						m_Socket.BeginSend(gram.Buffer, 0, gram.Length, SocketFlags.None, m_OnSend, m_Socket);
						return true;
					}
					catch (Exception ex)
					{
						TraceException(ex);
						Dispose(false);
					}
				}
			}

			return false;
		}
#endif

		public PacketHandler GetHandler(int packetID)
		{
			if (ContainerGridLines)
			{
				return PacketHandlers.Get6017Handler(packetID);
			}
			else
			{
				return PacketHandlers.GetHandler(packetID);
			}
		}

		public static void FlushAll()
		{
			if (m_Instances.Count >= 1024)
			{
				Parallel.ForEach(m_Instances, ns => ns.Flush());
			}
			else
			{
				for (var i = 0; i < m_Instances.Count; ++i)
				{
					m_Instances[i].Flush();
				}
			}
		}

		private static int m_CoalesceSleep = -1;

		public static int CoalesceSleep
		{
			get => m_CoalesceSleep;
			set => m_CoalesceSleep = value;
		}

		private long m_NextCheckActivity;

		public void CheckAlive(long curTicks)
		{
			if (m_Socket == null)
			{
				return;
			}

			if (m_NextCheckActivity - curTicks >= 0)
			{
				return;
			}

			Console.WriteLine("Client: {0}: Disconnecting due to inactivity...", this);

			Dispose();
			return;
		}

		public static void TraceException(Exception ex)
		{
			if (!Core.Debug)
			{
				return;
			}

			try
			{
				using (var op = new StreamWriter("network-errors.log", true))
				{
					op.WriteLine("# {0}", DateTime.UtcNow);

					op.WriteLine(ex);

					op.WriteLine();
					op.WriteLine();
				}
			}
			catch
			{
			}

			try
			{
				Console.WriteLine(ex);
			}
			catch
			{
			}
		}

		private bool m_Disposing;

		public bool IsDisposing => m_Disposing;

		public void Dispose()
		{
			Dispose(true);
		}

		public virtual void Dispose(bool flush)
		{
			if (m_Socket == null || m_Disposing)
			{
				return;
			}

			m_Disposing = true;

			if (flush)
			{
				flush = Flush();
			}

			try
			{
				m_Socket.Shutdown(SocketShutdown.Both);
			}
			catch (SocketException ex)
			{
				TraceException(ex);
			}

			try
			{
				m_Socket.Close();
			}
			catch (SocketException ex)
			{
				TraceException(ex);
			}

			if (m_RecvBuffer != null)
			{
				lock (m_ReceiveBufferPool)
				{
					m_ReceiveBufferPool.ReleaseBuffer(m_RecvBuffer);
				}
			}

			m_Socket = null;

			m_Buffer = null;
			m_RecvBuffer = null;

#if NewAsyncSockets
			m_ReceiveEventArgs = null;
			m_SendEventArgs = null;
#else
			m_OnReceive = null;
			m_OnSend = null;
#endif

			m_Running = false;

			lock (m_Disposed)
			{
				m_Disposed.Enqueue(this);
			}

			lock (m_SendQueue)
			{
				if ( /*!flush &&*/ !m_SendQueue.IsEmpty)
				{
					m_SendQueue.Clear();
				}
			}
		}

		public static void Initialize()
		{
			Timer.DelayCall(TimeSpan.FromMinutes(1.0), TimeSpan.FromMinutes(1.5), CheckAllAlive);
		}

		public static void CheckAllAlive()
		{
			try
			{
				var curTicks = Core.TickCount;

				if (m_Instances.Count >= 1024)
				{
					Parallel.ForEach(m_Instances, ns => ns.CheckAlive(curTicks));
				}
				else
				{
					for (var i = 0; i < m_Instances.Count; ++i)
					{
						m_Instances[i].CheckAlive(curTicks);
					}
				}
			}
			catch (Exception ex)
			{
				TraceException(ex);
			}
		}

		private static readonly Queue<NetState> m_Disposed = new Queue<NetState>();

		public static void ProcessDisposedQueue()
		{
			lock (m_Disposed)
			{
				var breakout = 0;

				while (breakout < 200 && m_Disposed.Count > 0)
				{
					++breakout;
					var ns = m_Disposed.Dequeue();

					var m = ns.m_Mobile;
					var a = ns.m_Account;

					if (m != null)
					{
						m.NetState = null;
						ns.m_Mobile = null;
					}

					ns.m_Gumps.Clear();
					ns.m_Menus.Clear();
					ns.m_HuePickers.Clear();
					ns.m_Account = null;
					ns.m_ServerInfo = null;
					ns.m_CityInfo = null;

					m_Instances.Remove(ns);

					if (a != null)
					{
						ns.WriteConsole("Disconnected. [{0} Online] [{1}]", m_Instances.Count, a);
					}
					else
					{
						ns.WriteConsole("Disconnected. [{0} Online]", m_Instances.Count);
					}
				}
			}
		}

		public bool Running => m_Running;

		public bool Seeded
		{
			get => m_Seeded;
			set => m_Seeded = value;
		}

		public Socket Socket => m_Socket;

		public ByteQueue Buffer => m_Buffer;

		public ExpansionInfo ExpansionInfo
		{
			get
			{
				for (var i = ExpansionInfo.Table.Length - 1; i >= 0; i--)
				{
					var info = ExpansionInfo.Table[i];

					if ((info.RequiredClient != null && Version >= info.RequiredClient) || ((Flags & info.ClientFlags) != 0))
					{
						return info;
					}
				}

				return ExpansionInfo.GetInfo(Expansion.None);
			}
		}

		public Expansion Expansion => (Expansion)ExpansionInfo.ID;

		public bool SupportsExpansion(ExpansionInfo info, bool checkCoreExpansion)
		{
			if (info == null || (checkCoreExpansion && (int)Core.Expansion < info.ID))
			{
				return false;
			}

			if (info.RequiredClient != null)
			{
				return (Version >= info.RequiredClient);
			}

			return ((Flags & info.ClientFlags) != 0);
		}

		public bool SupportsExpansion(Expansion ex, bool checkCoreExpansion)
		{
			return SupportsExpansion(ExpansionInfo.GetInfo(ex), checkCoreExpansion);
		}

		public bool SupportsExpansion(Expansion ex)
		{
			return SupportsExpansion(ex, true);
		}

		public bool SupportsExpansion(ExpansionInfo info)
		{
			return SupportsExpansion(info, true);
		}

		public int CompareTo(NetState other)
		{
			if (other == null)
			{
				return 1;
			}

			return m_ToString.CompareTo(other.m_ToString);
		}
	}

	public delegate void OnEncodedPacketReceive(NetState state, IEntity ent, EncodedReader pvSrc);

	public class EncodedPacketHandler
	{
		private readonly int m_PacketID;
		private readonly bool m_Ingame;
		private readonly OnEncodedPacketReceive m_OnReceive;

		public EncodedPacketHandler(int packetID, bool ingame, OnEncodedPacketReceive onReceive)
		{
			m_PacketID = packetID;
			m_Ingame = ingame;
			m_OnReceive = onReceive;
		}

		public int PacketID => m_PacketID;

		public OnEncodedPacketReceive OnReceive => m_OnReceive;

		public bool Ingame => m_Ingame;
	}

	public class EncodedReader
	{
		private readonly PacketReader m_Reader;

		public EncodedReader(PacketReader reader)
		{
			m_Reader = reader;
		}

		public byte[] Buffer => m_Reader.Buffer;

		public void Trace(NetState state)
		{
			m_Reader.Trace(state);
		}

		public int ReadInt32()
		{
			if (m_Reader.ReadByte() != 0)
			{
				return 0;
			}

			return m_Reader.ReadInt32();
		}

		public Point3D ReadPoint3D()
		{
			if (m_Reader.ReadByte() != 3)
			{
				return Point3D.Zero;
			}

			return new Point3D(m_Reader.ReadInt16(), m_Reader.ReadInt16(), m_Reader.ReadByte());
		}

		public string ReadUnicodeStringSafe()
		{
			if (m_Reader.ReadByte() != 2)
			{
				return "";
			}

			int length = m_Reader.ReadUInt16();

			return m_Reader.ReadUnicodeStringSafe(length);
		}

		public string ReadUnicodeString()
		{
			if (m_Reader.ReadByte() != 2)
			{
				return "";
			}

			int length = m_Reader.ReadUInt16();

			return m_Reader.ReadUnicodeString(length);
		}
	}

	/// <summary>
	/// Handles Functionality For Writing Primitive Binary Data
	/// </summary>
	public class PacketWriter
	{
		private static readonly Stack<PacketWriter> m_Pool = new Stack<PacketWriter>();

		public static PacketWriter CreateInstance()
		{
			return CreateInstance(32);
		}

		public static PacketWriter CreateInstance(int capacity)
		{
			PacketWriter pw = null;

			lock (m_Pool)
			{
				if (m_Pool.Count > 0)
				{
					pw = m_Pool.Pop();

					if (pw != null)
					{
						pw.m_Capacity = capacity;
						pw.m_Stream.SetLength(0);
					}
				}
			}

			if (pw == null)
			{
				pw = new PacketWriter(capacity);
			}

			return pw;
		}

		public static void ReleaseInstance(PacketWriter pw)
		{
			lock (m_Pool)
			{
				if (!m_Pool.Contains(pw))
				{
					m_Pool.Push(pw);
				}
				else
				{
					try
					{
						using (var op = new StreamWriter("neterr.log"))
						{
							op.WriteLine("{0}\tInstance pool contains writer", DateTime.UtcNow);
						}
					}
					catch
					{
						Console.WriteLine("net error");
					}
				}
			}
		}

		/// <summary>
		/// Internal stream which holds the entire packet.
		/// </summary>
		private readonly MemoryStream m_Stream;

		private int m_Capacity;

		/// <summary>
		/// Internal format buffer.
		/// </summary>
		private readonly byte[] m_Buffer = new byte[4];

		/// <summary>
		/// Instantiates a new PacketWriter instance with the default capacity of 4 bytes.
		/// </summary>
		public PacketWriter() : this(32)
		{
		}

		/// <summary>
		/// Instantiates a new PacketWriter instance with a given capacity.
		/// </summary>
		/// <param name="capacity">Initial capacity for the internal stream.</param>
		public PacketWriter(int capacity)
		{
			m_Stream = new MemoryStream(capacity);
			m_Capacity = capacity;
		}

		/// <summary>
		/// Writes a 1-byte boolean value to the underlying stream. False is represented by 0, true by 1.
		/// </summary>
		public void Write(bool value)
		{
			m_Stream.WriteByte((byte)(value ? 1 : 0));
		}

		/// <summary>
		/// Writes a 1-byte unsigned integer value to the underlying stream.
		/// </summary>
		public void Write(byte value)
		{
			m_Stream.WriteByte(value);
		}

		/// <summary>
		/// Writes a 1-byte signed integer value to the underlying stream.
		/// </summary>
		public void Write(sbyte value)
		{
			m_Stream.WriteByte((byte)value);
		}

		/// <summary>
		/// Writes a 2-byte signed integer value to the underlying stream.
		/// </summary>
		public void Write(short value)
		{
			m_Buffer[0] = (byte)(value >> 8);
			m_Buffer[1] = (byte)value;

			m_Stream.Write(m_Buffer, 0, 2);
		}

		/// <summary>
		/// Writes a 2-byte unsigned integer value to the underlying stream.
		/// </summary>
		public void Write(ushort value)
		{
			m_Buffer[0] = (byte)(value >> 8);
			m_Buffer[1] = (byte)value;

			m_Stream.Write(m_Buffer, 0, 2);
		}

		/// <summary>
		/// Writes a 4-byte signed integer value to the underlying stream.
		/// </summary>
		public void Write(int value)
		{
			m_Buffer[0] = (byte)(value >> 24);
			m_Buffer[1] = (byte)(value >> 16);
			m_Buffer[2] = (byte)(value >> 8);
			m_Buffer[3] = (byte)value;

			m_Stream.Write(m_Buffer, 0, 4);
		}

		/// <summary>
		/// Writes a 4-byte unsigned integer value to the underlying stream.
		/// </summary>
		public void Write(uint value)
		{
			m_Buffer[0] = (byte)(value >> 24);
			m_Buffer[1] = (byte)(value >> 16);
			m_Buffer[2] = (byte)(value >> 8);
			m_Buffer[3] = (byte)value;

			m_Stream.Write(m_Buffer, 0, 4);
		}

		/// <summary>
		/// Writes a sequence of bytes to the underlying stream
		/// </summary>
		public void Write(byte[] buffer, int offset, int size)
		{
			m_Stream.Write(buffer, offset, size);
		}

		/// <summary>
		/// Writes a fixed-length ASCII-encoded string value to the underlying stream. To fit (size), the string content is either truncated or padded with null characters.
		/// </summary>
		public void WriteAsciiFixed(string value, int size)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteAsciiFixed() with null value");
				value = String.Empty;
			}

			var length = value.Length;

			m_Stream.SetLength(m_Stream.Length + size);

			if (length >= size)
			{
				m_Stream.Position += Encoding.ASCII.GetBytes(value, 0, size, m_Stream.GetBuffer(), (int)m_Stream.Position);
			}
			else
			{
				Encoding.ASCII.GetBytes(value, 0, length, m_Stream.GetBuffer(), (int)m_Stream.Position);
				m_Stream.Position += size;
			}

			/*byte[] buffer = Encoding.ASCII.GetBytes( value );

			if ( buffer.Length >= size )
			{
				m_Stream.Write( buffer, 0, size );
			}
			else
			{
				m_Stream.Write( buffer, 0, buffer.Length );
				Fill( size - buffer.Length );
			}*/
		}

		/// <summary>
		/// Writes a dynamic-length ASCII-encoded string value to the underlying stream, followed by a 1-byte null character.
		/// </summary>
		public void WriteAsciiNull(string value)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteAsciiNull() with null value");
				value = String.Empty;
			}

			var length = value.Length;

			m_Stream.SetLength(m_Stream.Length + length + 1);

			Encoding.ASCII.GetBytes(value, 0, length, m_Stream.GetBuffer(), (int)m_Stream.Position);
			m_Stream.Position += length + 1;

			/*byte[] buffer = Encoding.ASCII.GetBytes( value );

			m_Stream.Write( buffer, 0, buffer.Length );
			m_Stream.WriteByte( 0 );*/
		}

		/// <summary>
		/// Writes a dynamic-length little-endian unicode string value to the underlying stream, followed by a 2-byte null character.
		/// </summary>
		public void WriteLittleUniNull(string value)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteLittleUniNull() with null value");
				value = String.Empty;
			}

			var length = value.Length;

			m_Stream.SetLength(m_Stream.Length + ((length + 1) * 2));

			m_Stream.Position += Encoding.Unicode.GetBytes(value, 0, length, m_Stream.GetBuffer(), (int)m_Stream.Position);
			m_Stream.Position += 2;

			/*byte[] buffer = Encoding.Unicode.GetBytes( value );

			m_Stream.Write( buffer, 0, buffer.Length );

			m_Buffer[0] = 0;
			m_Buffer[1] = 0;
			m_Stream.Write( m_Buffer, 0, 2 );*/
		}

		/// <summary>
		/// Writes a fixed-length little-endian unicode string value to the underlying stream. To fit (size), the string content is either truncated or padded with null characters.
		/// </summary>
		public void WriteLittleUniFixed(string value, int size)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteLittleUniFixed() with null value");
				value = String.Empty;
			}

			size *= 2;

			var length = value.Length;

			m_Stream.SetLength(m_Stream.Length + size);

			if ((length * 2) >= size)
			{
				m_Stream.Position += Encoding.Unicode.GetBytes(value, 0, length, m_Stream.GetBuffer(), (int)m_Stream.Position);
			}
			else
			{
				Encoding.Unicode.GetBytes(value, 0, length, m_Stream.GetBuffer(), (int)m_Stream.Position);
				m_Stream.Position += size;
			}

			/*size *= 2;

			byte[] buffer = Encoding.Unicode.GetBytes( value );

			if ( buffer.Length >= size )
			{
				m_Stream.Write( buffer, 0, size );
			}
			else
			{
				m_Stream.Write( buffer, 0, buffer.Length );
				Fill( size - buffer.Length );
			}*/
		}

		/// <summary>
		/// Writes a dynamic-length big-endian unicode string value to the underlying stream, followed by a 2-byte null character.
		/// </summary>
		public void WriteBigUniNull(string value)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteBigUniNull() with null value");
				value = String.Empty;
			}

			var length = value.Length;

			m_Stream.SetLength(m_Stream.Length + ((length + 1) * 2));

			m_Stream.Position += Encoding.BigEndianUnicode.GetBytes(value, 0, length, m_Stream.GetBuffer(), (int)m_Stream.Position);
			m_Stream.Position += 2;

			/*byte[] buffer = Encoding.BigEndianUnicode.GetBytes( value );

			m_Stream.Write( buffer, 0, buffer.Length );

			m_Buffer[0] = 0;
			m_Buffer[1] = 0;
			m_Stream.Write( m_Buffer, 0, 2 );*/
		}

		/// <summary>
		/// Writes a fixed-length big-endian unicode string value to the underlying stream. To fit (size), the string content is either truncated or padded with null characters.
		/// </summary>
		public void WriteBigUniFixed(string value, int size)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteBigUniFixed() with null value");
				value = String.Empty;
			}

			size *= 2;

			var length = value.Length;

			m_Stream.SetLength(m_Stream.Length + size);

			if ((length * 2) >= size)
			{
				m_Stream.Position += Encoding.BigEndianUnicode.GetBytes(value, 0, length, m_Stream.GetBuffer(), (int)m_Stream.Position);
			}
			else
			{
				Encoding.BigEndianUnicode.GetBytes(value, 0, length, m_Stream.GetBuffer(), (int)m_Stream.Position);
				m_Stream.Position += size;
			}

			/*size *= 2;

			byte[] buffer = Encoding.BigEndianUnicode.GetBytes( value );

			if ( buffer.Length >= size )
			{
				m_Stream.Write( buffer, 0, size );
			}
			else
			{
				m_Stream.Write( buffer, 0, buffer.Length );
				Fill( size - buffer.Length );
			}*/
		}

		/// <summary>
		/// Fills the stream from the current position up to (capacity) with 0x00's
		/// </summary>
		public void Fill()
		{
			Fill((int)(m_Capacity - m_Stream.Length));
		}

		/// <summary>
		/// Writes a number of 0x00 byte values to the underlying stream.
		/// </summary>
		public void Fill(int length)
		{
			if (m_Stream.Position == m_Stream.Length)
			{
				m_Stream.SetLength(m_Stream.Length + length);
				m_Stream.Seek(0, SeekOrigin.End);
			}
			else
			{
				m_Stream.Write(new byte[length], 0, length);
			}
		}

		/// <summary>
		/// Gets the total stream length.
		/// </summary>
		public long Length => m_Stream.Length;

		/// <summary>
		/// Gets or sets the current stream position.
		/// </summary>
		public long Position
		{
			get => m_Stream.Position;
			set => m_Stream.Position = value;
		}

		/// <summary>
		/// The internal stream used by this PacketWriter instance.
		/// </summary>
		public MemoryStream UnderlyingStream => m_Stream;

		/// <summary>
		/// Offsets the current position from an origin.
		/// </summary>
		public long Seek(long offset, SeekOrigin origin)
		{
			return m_Stream.Seek(offset, origin);
		}

		/// <summary>
		/// Gets the entire stream content as a byte array.
		/// </summary>
		public byte[] ToArray()
		{
			return m_Stream.ToArray();
		}
	}

	public class PacketReader
	{
		private readonly byte[] m_Data;
		private readonly int m_Size;
		private int m_Index;

		public PacketReader(byte[] data, int size, bool fixedSize)
		{
			m_Data = data;
			m_Size = size;
			m_Index = fixedSize ? 1 : 3;
		}

		public byte[] Buffer => m_Data;

		public int Size => m_Size;

		public void Trace(NetState state)
		{
			try
			{
				using (var sw = new StreamWriter("Packets.log", true))
				{
					var buffer = m_Data;

					if (buffer.Length > 0)
					{
						sw.WriteLine("Client: {0}: Unhandled packet 0x{1:X2}", state, buffer[0]);
					}

					using (var ms = new MemoryStream(buffer))
					{
						Utility.FormatBuffer(sw, ms, buffer.Length);
					}

					sw.WriteLine();
					sw.WriteLine();
				}
			}
			catch
			{
			}
		}

		public int Seek(int offset, SeekOrigin origin)
		{
			switch (origin)
			{
				case SeekOrigin.Begin: m_Index = offset; break;
				case SeekOrigin.Current: m_Index += offset; break;
				case SeekOrigin.End: m_Index = m_Size - offset; break;
			}

			return m_Index;
		}

		public int ReadInt32()
		{
			if ((m_Index + 4) > m_Size)
			{
				return 0;
			}

			return (m_Data[m_Index++] << 24)
				 | (m_Data[m_Index++] << 16)
				 | (m_Data[m_Index++] << 8)
				 | m_Data[m_Index++];
		}

		public short ReadInt16()
		{
			if ((m_Index + 2) > m_Size)
			{
				return 0;
			}

			return (short)((m_Data[m_Index++] << 8) | m_Data[m_Index++]);
		}

		public byte ReadByte()
		{
			if ((m_Index + 1) > m_Size)
			{
				return 0;
			}

			return m_Data[m_Index++];
		}

		public uint ReadUInt32()
		{
			if ((m_Index + 4) > m_Size)
			{
				return 0;
			}

			return (uint)((m_Data[m_Index++] << 24) | (m_Data[m_Index++] << 16) | (m_Data[m_Index++] << 8) | m_Data[m_Index++]);
		}

		public ushort ReadUInt16()
		{
			if ((m_Index + 2) > m_Size)
			{
				return 0;
			}

			return (ushort)((m_Data[m_Index++] << 8) | m_Data[m_Index++]);
		}

		public sbyte ReadSByte()
		{
			if ((m_Index + 1) > m_Size)
			{
				return 0;
			}

			return (sbyte)m_Data[m_Index++];
		}

		public bool ReadBoolean()
		{
			if ((m_Index + 1) > m_Size)
			{
				return false;
			}

			return (m_Data[m_Index++] != 0);
		}

		public string ReadUnicodeStringLE()
		{
			var sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < m_Size && (c = (m_Data[m_Index++] | (m_Data[m_Index++] << 8))) != 0)
			{
				sb.Append((char)c);
			}

			return sb.ToString();
		}

		public string ReadUnicodeStringLESafe(int fixedLength)
		{
			var bound = m_Index + (fixedLength << 1);
			var end = bound;

			if (bound > m_Size)
			{
				bound = m_Size;
			}

			var sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < bound && (c = (m_Data[m_Index++] | (m_Data[m_Index++] << 8))) != 0)
			{
				if (IsSafeChar(c))
				{
					sb.Append((char)c);
				}
			}

			m_Index = end;

			return sb.ToString();
		}

		public string ReadUnicodeStringLESafe()
		{
			var sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < m_Size && (c = (m_Data[m_Index++] | (m_Data[m_Index++] << 8))) != 0)
			{
				if (IsSafeChar(c))
				{
					sb.Append((char)c);
				}
			}

			return sb.ToString();
		}

		public string ReadUnicodeStringSafe()
		{
			var sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < m_Size && (c = ((m_Data[m_Index++] << 8) | m_Data[m_Index++])) != 0)
			{
				if (IsSafeChar(c))
				{
					sb.Append((char)c);
				}
			}

			return sb.ToString();
		}

		public string ReadUnicodeString()
		{
			var sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < m_Size && (c = ((m_Data[m_Index++] << 8) | m_Data[m_Index++])) != 0)
			{
				sb.Append((char)c);
			}

			return sb.ToString();
		}

		public bool IsSafeChar(int c)
		{
			return (c >= 0x20 && c < 0xFFFE);
		}

		public string ReadUTF8StringSafe(int fixedLength)
		{
			if (m_Index >= m_Size)
			{
				m_Index += fixedLength;
				return String.Empty;
			}

			var bound = m_Index + fixedLength;
			//int end   = bound;

			if (bound > m_Size)
			{
				bound = m_Size;
			}

			var count = 0;
			var index = m_Index;
			var start = m_Index;

			while (index < bound && m_Data[index++] != 0)
			{
				++count;
			}

			index = 0;

			var buffer = new byte[count];
			var value = 0;

			while (m_Index < bound && (value = m_Data[m_Index++]) != 0)
			{
				buffer[index++] = (byte)value;
			}

			var s = Utility.UTF8.GetString(buffer);

			var isSafe = true;

			for (var i = 0; isSafe && i < s.Length; ++i)
			{
				isSafe = IsSafeChar(s[i]);
			}

			m_Index = start + fixedLength;

			if (isSafe)
			{
				return s;
			}

			var sb = new StringBuilder(s.Length);

			for (var i = 0; i < s.Length; ++i)
			{
				if (IsSafeChar(s[i]))
				{
					sb.Append(s[i]);
				}
			}

			return sb.ToString();
		}

		public string ReadUTF8StringSafe()
		{
			if (m_Index >= m_Size)
			{
				return String.Empty;
			}

			var count = 0;
			var index = m_Index;

			while (index < m_Size && m_Data[index++] != 0)
			{
				++count;
			}

			index = 0;

			var buffer = new byte[count];
			var value = 0;

			while (m_Index < m_Size && (value = m_Data[m_Index++]) != 0)
			{
				buffer[index++] = (byte)value;
			}

			var s = Utility.UTF8.GetString(buffer);

			var isSafe = true;

			for (var i = 0; isSafe && i < s.Length; ++i)
			{
				isSafe = IsSafeChar(s[i]);
			}

			if (isSafe)
			{
				return s;
			}

			var sb = new StringBuilder(s.Length);

			for (var i = 0; i < s.Length; ++i)
			{
				if (IsSafeChar(s[i]))
				{
					sb.Append(s[i]);
				}
			}

			return sb.ToString();
		}

		public string ReadUTF8String()
		{
			if (m_Index >= m_Size)
			{
				return String.Empty;
			}

			var count = 0;
			var index = m_Index;

			while (index < m_Size && m_Data[index++] != 0)
			{
				++count;
			}

			index = 0;

			var buffer = new byte[count];
			var value = 0;

			while (m_Index < m_Size && (value = m_Data[m_Index++]) != 0)
			{
				buffer[index++] = (byte)value;
			}

			return Utility.UTF8.GetString(buffer);
		}

		public string ReadString()
		{
			var sb = new StringBuilder();

			int c;

			while (m_Index < m_Size && (c = m_Data[m_Index++]) != 0)
			{
				sb.Append((char)c);
			}

			return sb.ToString();
		}

		public string ReadStringSafe()
		{
			var sb = new StringBuilder();

			int c;

			while (m_Index < m_Size && (c = m_Data[m_Index++]) != 0)
			{
				if (IsSafeChar(c))
				{
					sb.Append((char)c);
				}
			}

			return sb.ToString();
		}

		public string ReadUnicodeStringSafe(int fixedLength)
		{
			var bound = m_Index + (fixedLength << 1);
			var end = bound;

			if (bound > m_Size)
			{
				bound = m_Size;
			}

			var sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < bound && (c = ((m_Data[m_Index++] << 8) | m_Data[m_Index++])) != 0)
			{
				if (IsSafeChar(c))
				{
					sb.Append((char)c);
				}
			}

			m_Index = end;

			return sb.ToString();
		}

		public string ReadUnicodeString(int fixedLength)
		{
			var bound = m_Index + (fixedLength << 1);
			var end = bound;

			if (bound > m_Size)
			{
				bound = m_Size;
			}

			var sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < bound && (c = ((m_Data[m_Index++] << 8) | m_Data[m_Index++])) != 0)
			{
				sb.Append((char)c);
			}

			m_Index = end;

			return sb.ToString();
		}

		public string ReadStringSafe(int fixedLength)
		{
			var bound = m_Index + fixedLength;
			var end = bound;

			if (bound > m_Size)
			{
				bound = m_Size;
			}

			var sb = new StringBuilder();

			int c;

			while (m_Index < bound && (c = m_Data[m_Index++]) != 0)
			{
				if (IsSafeChar(c))
				{
					sb.Append((char)c);
				}
			}

			m_Index = end;

			return sb.ToString();
		}

		public string ReadString(int fixedLength)
		{
			var bound = m_Index + fixedLength;
			var end = bound;

			if (bound > m_Size)
			{
				bound = m_Size;
			}

			var sb = new StringBuilder();

			int c;

			while (m_Index < bound && (c = m_Data[m_Index++]) != 0)
			{
				sb.Append((char)c);
			}

			m_Index = end;

			return sb.ToString();
		}
	}

	/// <summary>
	/// Handles Local Server IP And Port Connections
	/// </summary>
	public class Listener : IDisposable
	{
		private Socket m_Listener;

		private readonly Queue<Socket> m_Accepted;
		private readonly object m_AcceptedSyncRoot;

#if NewAsyncSockets
		private SocketAsyncEventArgs m_EventArgs;
#else
		private readonly AsyncCallback m_OnAccept;
#endif

		private static readonly Socket[] m_EmptySockets = new Socket[0];

		private static IPEndPoint[] m_EndPoints;

		public static IPEndPoint[] EndPoints
		{
			get => m_EndPoints;
			set => m_EndPoints = value;
		}

		public Listener(IPEndPoint ipep)
		{
			m_Accepted = new Queue<Socket>();
			m_AcceptedSyncRoot = ((ICollection)m_Accepted).SyncRoot;

			m_Listener = Bind(ipep);

			if (m_Listener == null)
			{
				return;
			}

			DisplayListener();

#if NewAsyncSockets
			m_EventArgs = new SocketAsyncEventArgs();
			m_EventArgs.Completed += new EventHandler<SocketAsyncEventArgs>( Accept_Completion );
			Accept_Start();
#else
			m_OnAccept = new AsyncCallback(OnAccept);
			try
			{
				var res = m_Listener.BeginAccept(m_OnAccept, m_Listener);
			}
			catch (SocketException ex)
			{
				NetState.TraceException(ex);
			}
			catch (ObjectDisposedException)
			{
			}
#endif
		}

		private Socket Bind(IPEndPoint ipep)
		{
			var s = new Socket(ipep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			try
			{
				s.LingerState.Enabled = false;
				s.ExclusiveAddressUse = false;

				s.Bind(ipep);
				s.Listen(8);

				return s;
			}
			catch (Exception e)
			{
				if (e is SocketException)
				{
					var se = (SocketException)e;

					if (se.ErrorCode == 10048)
					{ // WSAEADDRINUSE
						Console.WriteLine("Listener Failed: {0}:{1} (In Use)", ipep.Address, ipep.Port);
					}
					else if (se.ErrorCode == 10049)
					{ // WSAEADDRNOTAVAIL
						Console.WriteLine("Listener Failed: {0}:{1} (Unavailable)", ipep.Address, ipep.Port);
					}
					else
					{
						Console.WriteLine("Listener Exception:");
						Console.WriteLine(e);
					}
				}

				return null;
			}
		}

		private void DisplayListener()
		{
			var ipep = m_Listener.LocalEndPoint as IPEndPoint;

			if (ipep == null)
			{
				return;
			}

			if (ipep.Address.Equals(IPAddress.Any) || ipep.Address.Equals(IPAddress.IPv6Any))
			{
				var adapters = NetworkInterface.GetAllNetworkInterfaces();
				foreach (var adapter in adapters)
				{
					var properties = adapter.GetIPProperties();
					foreach (IPAddressInformation unicast in properties.UnicastAddresses)
					{
						if (ipep.AddressFamily == unicast.Address.AddressFamily)
						{
							Console.WriteLine("Listening: {0}:{1}", unicast.Address, ipep.Port);
						}
					}
				}
				/*
				try {
					Console.WriteLine( "Listening: {0}:{1}", IPAddress.Loopback, ipep.Port );
					IPHostEntry iphe = Dns.GetHostEntry( Dns.GetHostName() );
					IPAddress[] ip = iphe.AddressList;
					for ( int i = 0; i < ip.Length; ++i )
						Console.WriteLine( "Listening: {0}:{1}", ip[i], ipep.Port );
				}
				catch { }
				*/
			}
			else
			{
				Console.WriteLine("Listening: {0}:{1}", ipep.Address, ipep.Port);
			}
		}

#if NewAsyncSockets
		private void Accept_Start()
		{
			bool result = false;

			do {
				try {
					result = !m_Listener.AcceptAsync( m_EventArgs );
				} catch ( SocketException ex ) {
					NetState.TraceException( ex );
					break;
				} catch ( ObjectDisposedException ) {
					break;
				}

				if ( result )
					Accept_Process( m_EventArgs );
			} while ( result );
		}

		private void Accept_Completion( object sender, SocketAsyncEventArgs e )
		{
			Accept_Process( e );

			Accept_Start();
		}

		private void Accept_Process( SocketAsyncEventArgs e )
		{
			if ( e.SocketError == SocketError.Success && VerifySocket( e.AcceptSocket ) ) {
				Enqueue( e.AcceptSocket );
			} else {
				Release( e.AcceptSocket );
			}

			e.AcceptSocket = null;
		}

#else

		private void OnAccept(IAsyncResult asyncResult)
		{
			var listener = (Socket)asyncResult.AsyncState;

			Socket accepted = null;

			try
			{
				accepted = listener.EndAccept(asyncResult);
			}
			catch (SocketException ex)
			{
				NetState.TraceException(ex);
			}
			catch (ObjectDisposedException)
			{
				return;
			}

			if (accepted != null)
			{
				if (VerifySocket(accepted))
				{
					Enqueue(accepted);
				}
				else
				{
					Release(accepted);
				}
			}

			try
			{
				listener.BeginAccept(m_OnAccept, listener);
			}
			catch (SocketException ex)
			{
				NetState.TraceException(ex);
			}
			catch (ObjectDisposedException)
			{
			}
		}
#endif

		private bool VerifySocket(Socket socket)
		{
			try
			{
				var args = new SocketConnectEventArgs(socket);

				EventSink.InvokeSocketConnect(args);

				return args.AllowConnection;
			}
			catch (Exception ex)
			{
				NetState.TraceException(ex);

				return false;
			}
		}

		private void Enqueue(Socket socket)
		{
			lock (m_AcceptedSyncRoot)
			{
				m_Accepted.Enqueue(socket);
			}

			Core.Set();
		}

		private void Release(Socket socket)
		{
			try
			{
				socket.Shutdown(SocketShutdown.Both);
			}
			catch (SocketException ex)
			{
				NetState.TraceException(ex);
			}

			try
			{
				socket.Close();
			}
			catch (SocketException ex)
			{
				NetState.TraceException(ex);
			}
		}

		public Socket[] Slice()
		{
			Socket[] array;

			lock (m_AcceptedSyncRoot)
			{
				if (m_Accepted.Count == 0)
				{
					return m_EmptySockets;
				}

				array = m_Accepted.ToArray();
				m_Accepted.Clear();
			}

			return array;
		}

		public void Dispose(bool disposing)
		{
			if (disposing)
			{
				var socket = Interlocked.Exchange<Socket>(ref m_Listener, null);

				if (socket != null)
				{
					socket.Close();
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}

	public class MessagePump
	{
		private Listener[] m_Listeners;
		private Queue<NetState> m_Queue;
		private Queue<NetState> m_WorkingQueue;
		private readonly Queue<NetState> m_Throttled;

		public MessagePump()
		{
			var ipep = Listener.EndPoints;

			m_Listeners = new Listener[ipep.Length];

			var success = false;

			do
			{
				for (var i = 0; i < ipep.Length; i++)
				{
					var l = new Listener(ipep[i]);
					if (!success && l != null)
					{
						success = true;
					}

					m_Listeners[i] = l;
				}

				if (!success)
				{
					Console.WriteLine("Retrying...");
					Thread.Sleep(10000);
				}
			} while (!success);

			m_Queue = new Queue<NetState>();
			m_WorkingQueue = new Queue<NetState>();
			m_Throttled = new Queue<NetState>();
		}

		public Listener[] Listeners
		{
			get => m_Listeners;
			set => m_Listeners = value;
		}

		public void AddListener(Listener l)
		{
			var old = m_Listeners;

			m_Listeners = new Listener[old.Length + 1];

			for (var i = 0; i < old.Length; ++i)
			{
				m_Listeners[i] = old[i];
			}

			m_Listeners[old.Length] = l;
		}

		private void CheckListener()
		{
			for (var j = 0; j < m_Listeners.Length; ++j)
			{
				var accepted = m_Listeners[j].Slice();

				for (var i = 0; i < accepted.Length; ++i)
				{
					var ns = new NetState(accepted[i], this);
					ns.Start();

					if (ns.Running)
					{
						Console.WriteLine("Client: {0}: Connected. [{1} Online]", ns, NetState.Instances.Count);
					}
				}
			}
		}

		public void OnReceive(NetState ns)
		{
			lock (this)
			{
				m_Queue.Enqueue(ns);
			}

			Core.Set();
		}

		public void Slice()
		{
			CheckListener();

			lock (this)
			{
				var temp = m_WorkingQueue;
				m_WorkingQueue = m_Queue;
				m_Queue = temp;
			}

			while (m_WorkingQueue.Count > 0)
			{
				var ns = m_WorkingQueue.Dequeue();

				if (ns.Running)
				{
					HandleReceive(ns);
				}
			}

			lock (this)
			{
				while (m_Throttled.Count > 0)
				{
					m_Queue.Enqueue(m_Throttled.Dequeue());
				}
			}
		}

		private const int BufferSize = 4096;
		private readonly BufferPool m_Buffers = new BufferPool("Processor", 4, BufferSize);

		private bool HandleSeed(NetState ns, ByteQueue buffer)
		{
			if (buffer.GetPacketID() == 0xEF)
			{
				// new packet in client	6.0.5.0	replaces the traditional seed method with a	seed packet
				// 0xEF	= 239 =	multicast IP, so this should never appear in a normal seed.	 So	this is	backwards compatible with older	clients.
				ns.Seeded = true;
				return true;
			}
			else if (buffer.Length >= 4)
			{
				var m_Peek = new byte[4];

				buffer.Dequeue(m_Peek, 0, 4);

				var seed = (m_Peek[0] << 24) | (m_Peek[1] << 16) | (m_Peek[2] << 8) | m_Peek[3];

				if (seed == 0)
				{
					Console.WriteLine("Login: {0}: Invalid client detected, disconnecting", ns);
					ns.Dispose();
					return false;
				}

				ns.m_Seed = seed;
				ns.Seeded = true;
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool CheckEncrypted(NetState ns, int packetID)
		{
			if (!ns.SentFirstPacket && packetID != 0xF0 && packetID != 0xF1 && packetID != 0xCF && packetID != 0x80 && packetID != 0x91 && packetID != 0xA4 && packetID != 0xEF)
			{
				Console.WriteLine("Client: {0}: Encrypted client detected, disconnecting", ns);
				ns.Dispose();
				return true;
			}
			return false;
		}

		public void HandleReceive(NetState ns)
		{
			var buffer = ns.Buffer;

			if (buffer == null || buffer.Length <= 0)
			{
				return;
			}

			lock (buffer)
			{
				if (!ns.Seeded)
				{
					if (!HandleSeed(ns, buffer))
					{
						return;
					}
				}

				var length = buffer.Length;

				while (length > 0 && ns.Running)
				{
					int packetID = buffer.GetPacketID();

					if (CheckEncrypted(ns, packetID))
					{
						break;
					}

					var handler = ns.GetHandler(packetID);

					if (handler == null)
					{
						var data = new byte[length];
						length = buffer.Dequeue(data, 0, length);
						new PacketReader(data, length, false).Trace(ns);
						break;
					}

					var packetLength = handler.Length;

					if (packetLength <= 0)
					{
						if (length >= 3)
						{
							packetLength = buffer.GetPacketLength();

							if (packetLength < 3)
							{
								ns.Dispose();
								break;
							}
						}
						else
						{
							break;
						}
					}

					if (length >= packetLength)
					{
						if (handler.Ingame)
						{
							if (ns.Mobile == null)
							{
								Console.WriteLine("Client: {0}: Sent ingame packet (0x{1:X2}) before having been attached to a mobile", ns, packetID);
								ns.Dispose();
								break;
							}
							else if (ns.Mobile.Deleted)
							{
								ns.Dispose();
								break;
							}
						}

						var throttler = handler.ThrottleCallback;

						if (throttler != null && !throttler(ns))
						{
							m_Throttled.Enqueue(ns);
							return;
						}

						PacketReceiveProfile prof = null;

						if (Core.Profiling)
						{
							prof = PacketReceiveProfile.Acquire(packetID);
						}

						if (prof != null)
						{
							prof.Start();
						}

						byte[] packetBuffer;

						if (BufferSize >= packetLength)
						{
							packetBuffer = m_Buffers.AcquireBuffer();
						}
						else
						{
							packetBuffer = new byte[packetLength];
						}

						packetLength = buffer.Dequeue(packetBuffer, 0, packetLength);

						var r = new PacketReader(packetBuffer, packetLength, handler.Length != 0);

						handler.OnReceive(ns, r);
						length = buffer.Length;

						if (BufferSize >= packetLength)
						{
							m_Buffers.ReleaseBuffer(packetBuffer);
						}

						if (prof != null)
						{
							prof.Finish(packetLength);
						}
					}
					else
					{
						break;
					}
				}
			}
		}
	}
}