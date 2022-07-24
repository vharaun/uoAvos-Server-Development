
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Server
{
	public static class HueData
	{
		private static readonly int[] m_Header = Array.Empty<int>();

		public static Hue[] List { get; } = new Hue[3000];

		public static bool CheckFile => Core.FindDataFile("hues.mul") != null;

		static HueData()
		{
			var index = 0;

			if (CheckFile)
			{
				var path = Core.FindDataFile("hues.mul");

				if (path != null)
				{
					using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						var blockCount = (int)fs.Length / 708;

						if (blockCount > 375)
						{
							blockCount = 375;
						}

						m_Header = new int[blockCount];

						var structsize = Marshal.SizeOf(typeof(HueEntry));
						var buffer = new byte[blockCount * (4 + 8 * structsize)];

						var gc = GCHandle.Alloc(buffer, GCHandleType.Pinned);

						try
						{
							fs.Read(buffer, 0, buffer.Length);

							long currpos = 0;

							for (var i = 0; i < blockCount; ++i)
							{
								var ptrheader = new IntPtr((long)gc.AddrOfPinnedObject() + currpos);

								currpos += 4;

								m_Header[i] = (int)Marshal.PtrToStructure(ptrheader, typeof(int));

								for (var j = 0; j < 8; ++j, ++index)
								{
									var ptr = new IntPtr((long)gc.AddrOfPinnedObject() + currpos);

									currpos += structsize;

									var cur = (HueEntry)Marshal.PtrToStructure(ptr, typeof(HueEntry));

									List[index] = new Hue(index, cur);
								}
							}
						}
						finally
						{
							gc.Free();
						}
					}
				}
			}

			while (index < List.Length)
			{
				List[index] = new Hue(index);

				++index;
			}
		}

		public static Hue GetHue(int index)
		{
			index &= 0x3FFF;

			if (index >= 0 && index < List.Length)
			{
				return List[index];
			}

			return List[0];
		}

		public static void ApplyTo(Bitmap bmp, int hue, bool onlyHueGrayPixels)
		{
			ApplyTo(bmp, GetHue(hue), onlyHueGrayPixels);
		}

		public static void ApplyTo(Bitmap bmp, Hue hue, bool onlyHueGrayPixels)
		{
			ApplyTo(bmp, hue?.Colors, onlyHueGrayPixels);
		}

		public static unsafe void ApplyTo(Bitmap bmp, Color[] colors, bool onlyHueGrayPixels)
		{
			try
			{
				var bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

				try
				{
					var stride = bd.Stride >> 2;
					var width = bd.Width;
					var height = bd.Height;
					var delta = stride - width;

					var pBuffer = (int*)bd.Scan0;
					var pLineEnd = pBuffer + width;
					var pImageEnd = pBuffer + (stride * height);

					int c, r, g, b;

					while (pBuffer < pImageEnd)
					{
						while (pBuffer < pLineEnd)
						{
							c = Convert16(*pBuffer);

							if (c != 0)
							{
								r = (c >> 10) & 0x1F;

								if (onlyHueGrayPixels)
								{
									g = (c >> 5) & 0x1F;
									b = c & 0x1F;

									if (r == g && r == b)
									{
										*pBuffer = colors[r].ToArgb();
									}
								}
								else
								{
									*pBuffer = colors[r].ToArgb();
								}
							}

							++pBuffer;
						}

						pBuffer += delta;
						pLineEnd += stride;
					}
				}
				finally
				{
					bmp.UnlockBits(bd);
				}
			}
			catch (Exception e)
			{
				if (Core.Debug)
				{
					Console.WriteLine($"[Ultima]: HueData.ApplyTo({nameof(bmp)}:{bmp}, {nameof(onlyHueGrayPixels)}:{onlyHueGrayPixels})\n{e}");
				}
			}
		}

		public static uint Convert32(ushort value)
		{
			uint argb;

			argb = ((value & 0x00007C00u) << 9) | ((value & 0x000003E0u) << 6) | ((value & 0x0000001Fu) << 3);
			argb = ((value & 0x00008000u) * 0x0001FE00u) | argb | ((argb >> 5) & 0x00070707u) | 0xFF000000u;

			return argb;
		}

		public static ushort Convert16(Color value)
		{
			return Convert16(value.ToArgb());
		}

		public static ushort Convert16(int value)
		{
			return Convert16((uint)value);
		}

		public static ushort Convert16(uint value)
		{
			return (ushort)(((value >> 16) & 0x00008000) | ((value >> 9) & 0x00007C00) | ((value >> 6) & 0x000003E0) | ((value >> 3) & 0x0000001F));
		}

		public static Color ConvertColor(ushort value)
		{
			return Color.FromArgb((int)Convert32(value));
		}

		public static uint ToArgb(int index, int block)
		{
			return (uint)(GetHue(index)?.Colors?[block].ToArgb() ?? 0);
		}

		public static ushort ToRgb(int index, int block)
		{
			return Convert16(ToArgb(index, block));
		}

		public sealed class Hue
		{
			public int Index { get; }

			public Color[] Colors { get; } = new Color[32];

			public string Name { get; }

			public Color TableStart { get; }
			public Color TableEnd { get; }

			internal Hue(int index)
			{
				Name = "Null";
				Index = index;
			}

			internal Hue(int index, HueEntry entry)
			{
				Index = index;

				for (var i = 0; i < 32; ++i)
				{
					Colors[i] = ConvertColor(entry.Colors[i]);
				}

				TableStart = ConvertColor(entry.TableStart);
				TableEnd = ConvertColor(entry.TableEnd);

				var count = 0;

				while (count < 20 && count < entry.Name.Length && entry.Name[count] != 0)
				{
					++count;
				}

				Name = Encoding.Default.GetString(entry.Name, 0, count);
				Name = Name.Replace("\n", " ");
			}

			public void ApplyTo(Bitmap bmp, bool onlyHueGrayPixels)
			{
				HueData.ApplyTo(bmp, Colors, onlyHueGrayPixels);
			}
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		internal struct HueEntry
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public ushort[] Colors;

			public ushort TableStart;
			public ushort TableEnd;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
			public byte[] Name;
		}
	}
}
