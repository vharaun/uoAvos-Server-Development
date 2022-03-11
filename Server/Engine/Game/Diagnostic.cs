
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Server.Diagnostics
{
	public abstract class BaseProfile
	{
		public static void WriteAll<T>(TextWriter op, IEnumerable<T> profiles) where T : BaseProfile
		{
			var list = new List<T>(profiles);

			list.Sort(delegate (T a, T b)
			{
				return -a.TotalTime.CompareTo(b.TotalTime);
			});

			foreach (var prof in list)
			{
				prof.WriteTo(op);
				op.WriteLine();
			}
		}

		private readonly string _name;

		private long _count;

		private TimeSpan _totalTime;
		private TimeSpan _peakTime;

		private readonly Stopwatch _stopwatch;

		public string Name => _name;

		public long Count => _count;

		public TimeSpan AverageTime => TimeSpan.FromTicks(_totalTime.Ticks / Math.Max(1, _count));

		public TimeSpan PeakTime => _peakTime;

		public TimeSpan TotalTime => _totalTime;

		protected BaseProfile(string name)
		{
			_name = name;

			_stopwatch = new Stopwatch();
		}

		public virtual void Start()
		{
			if (_stopwatch.IsRunning)
			{
				_stopwatch.Reset();
			}

			_stopwatch.Start();
		}

		public virtual void Finish()
		{
			var elapsed = _stopwatch.Elapsed;

			_totalTime += elapsed;

			if (elapsed > _peakTime)
			{
				_peakTime = elapsed;
			}

			_count++;

			_stopwatch.Reset();
		}

		public virtual void WriteTo(TextWriter op)
		{
			op.Write("{0,-100} {1,12:N0} {2,12:F5} {3,-12:F5} {4,12:F5}", Name, Count, AverageTime.TotalSeconds, PeakTime.TotalSeconds, TotalTime.TotalSeconds);
		}
	}

	/// <summary>
	/// Gump Diagnostics
	/// </summary>
	public class GumpProfile : BaseProfile
	{
		private static readonly Dictionary<Type, GumpProfile> _profiles = new Dictionary<Type, GumpProfile>();

		public static IEnumerable<GumpProfile> Profiles => _profiles.Values;

		public static GumpProfile Acquire(Type type)
		{
			if (!Core.Profiling)
			{
				return null;
			}

			GumpProfile prof;

			if (!_profiles.TryGetValue(type, out prof))
			{
				_profiles.Add(type, prof = new GumpProfile(type));
			}

			return prof;
		}

		public GumpProfile(Type type)
			: base(type.FullName)
		{
		}
	}

	/// <summary>
	/// Packet Diagnostics
	/// </summary>
	public abstract class BasePacketProfile : BaseProfile
	{
		private long _totalLength;

		public long TotalLength => _totalLength;

		public double AverageLength => (double)_totalLength / Math.Max(1, Count);

		protected BasePacketProfile(string name)
			: base(name)
		{
		}

		public void Finish(int length)
		{
			Finish();

			_totalLength += length;
		}

		public override void WriteTo(TextWriter op)
		{
			base.WriteTo(op);

			op.Write("\t{0,12:F2} {1,-12:N0}", AverageLength, TotalLength);
		}
	}

	public class PacketSendProfile : BasePacketProfile
	{
		private static readonly Dictionary<Type, PacketSendProfile> _profiles = new Dictionary<Type, PacketSendProfile>();

		public static IEnumerable<PacketSendProfile> Profiles => _profiles.Values;

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static PacketSendProfile Acquire(Type type)
		{
			PacketSendProfile prof;

			if (!_profiles.TryGetValue(type, out prof))
			{
				_profiles.Add(type, prof = new PacketSendProfile(type));
			}

			return prof;
		}

		private long _created;

		public void Increment()
		{
			Interlocked.Increment(ref _created);
		}

		public PacketSendProfile(Type type)
			: base(type.FullName)
		{
		}

		public override void WriteTo(TextWriter op)
		{
			base.WriteTo(op);

			op.Write("\t{0,12:N0}", _created);
		}
	}

	public class PacketReceiveProfile : BasePacketProfile
	{
		private static readonly Dictionary<int, PacketReceiveProfile> _profiles = new Dictionary<int, PacketReceiveProfile>();

		public static IEnumerable<PacketReceiveProfile> Profiles => _profiles.Values;

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static PacketReceiveProfile Acquire(int packetId)
		{
			PacketReceiveProfile prof;

			if (!_profiles.TryGetValue(packetId, out prof))
			{
				_profiles.Add(packetId, prof = new PacketReceiveProfile(packetId));
			}

			return prof;
		}

		public PacketReceiveProfile(int packetId)
			: base(String.Format("0x{0:X2}", packetId))
		{
		}
	}

	/// <summary>
	/// Target Diagnostics
	/// </summary>
	public class TargetProfile : BaseProfile
	{
		private static readonly Dictionary<Type, TargetProfile> _profiles = new Dictionary<Type, TargetProfile>();

		public static IEnumerable<TargetProfile> Profiles => _profiles.Values;

		public static TargetProfile Acquire(Type type)
		{
			if (!Core.Profiling)
			{
				return null;
			}

			TargetProfile prof;

			if (!_profiles.TryGetValue(type, out prof))
			{
				_profiles.Add(type, prof = new TargetProfile(type));
			}

			return prof;
		}

		public TargetProfile(Type type)
			: base(type.FullName)
		{
		}
	}

	/// <summary>
	/// Timer Diagnostics
	/// </summary>
	public class TimerProfile : BaseProfile
	{
		private static readonly Dictionary<string, TimerProfile> _profiles = new Dictionary<string, TimerProfile>();

		public static IEnumerable<TimerProfile> Profiles => _profiles.Values;

		public static TimerProfile Acquire(string name)
		{
			if (!Core.Profiling)
			{
				return null;
			}

			TimerProfile prof;

			if (!_profiles.TryGetValue(name, out prof))
			{
				_profiles.Add(name, prof = new TimerProfile(name));
			}

			return prof;
		}

		private long _created, _started, _stopped;

		public long Created
		{
			get => _created;
			set => _created = value;
		}

		public long Started
		{
			get => _started;
			set => _started = value;
		}

		public long Stopped
		{
			get => _stopped;
			set => _stopped = value;
		}

		public TimerProfile(string name)
			: base(name)
		{
		}

		public override void WriteTo(TextWriter op)
		{
			base.WriteTo(op);

			op.Write("\t{0,12:N0} {1,12:N0} {2,-12:N0}", _created, _started, _stopped);
		}
	}
}