using Server.Diagnostics;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Server
{
	public enum TimerPriority
	{
		EveryTick,
		TenMS,
		TwentyFiveMS,
		FiftyMS,
		TwoFiftyMS,
		OneSecond,
		FiveSeconds,
		OneMinute
	}

	public class Timer
	{
		public static class TimerThread
		{
			private class TimerChangeEntry
			{
				public Timer m_Timer;
				public int m_NewIndex;
				public bool m_IsAdd;

				private TimerChangeEntry(Timer t, int newIndex, bool isAdd)
				{
					m_Timer = t;
					m_NewIndex = newIndex;
					m_IsAdd = isAdd;
				}

				public void Free()
				{
					lock (m_InstancePool)
					{
						if (m_InstancePool.Count < 200)
						{
							m_InstancePool.Enqueue(this);
						}
					}
				}

				private static readonly Queue<TimerChangeEntry> m_InstancePool = new();

				public static TimerChangeEntry GetInstance(Timer t, int newIndex, bool isAdd)
				{
					TimerChangeEntry e = null;

					lock (m_InstancePool)
					{
						if (m_InstancePool.Count > 0)
						{
							e = m_InstancePool.Dequeue();
						}
					}

					if (e != null)
					{
						e.m_Timer = t;
						e.m_NewIndex = newIndex;
						e.m_IsAdd = isAdd;
					}
					else
					{
						e = new TimerChangeEntry(t, newIndex, isAdd);
					}

					return e;
				}
			}

			private static readonly AutoResetEvent m_Signal = new(false);

			private static readonly Dictionary<Timer, TimerChangeEntry> m_Changed = new();

			private static readonly long[] m_NextPriorities = new long[8];

			private static readonly long[] m_PriorityDelays = new long[8]
			{
				0,
				10,
				25,
				50,
				250,
				1000,
				5000,
				60000
			};

			private static readonly List<Timer>[] m_Timers = new List<Timer>[8]
			{
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
			};

			public static void Dump(TextWriter tw)
			{
				for (var i = 0; i < 8; ++i)
				{
					tw.WriteLine("Priority: {0}", (TimerPriority)i);
					tw.WriteLine();

					var hash = new Dictionary<string, List<Timer>>();

					for (var j = 0; j < m_Timers[i].Count; ++j)
					{
						var t = m_Timers[i][j];

						var key = t.ToString();

						hash.TryGetValue(key, out var list);

						if (list == null)
						{
							hash[key] = list = new();
						}

						list.Add(t);
					}

					foreach (var kv in hash)
					{
						var key = kv.Key;
						var list = kv.Value;

						tw.WriteLine("Type: {0}; Count: {1}; Percent: {2}%", key, list.Count, (int)(100 * (list.Count / (double)m_Timers[i].Count)));
					}

					tw.WriteLine();
					tw.WriteLine();
				}
			}

			public static void Change(Timer t, int newIndex, bool isAdd)
			{
				lock (m_Changed)
				{
					m_Changed[t] = TimerChangeEntry.GetInstance(t, newIndex, isAdd);
				}

				m_Signal.Set();
			}

			public static void AddTimer(Timer t)
			{
				Change(t, (int)t.Priority, true);
			}

			public static void PriorityChange(Timer t, int newPrio)
			{
				Change(t, newPrio, false);
			}

			public static void RemoveTimer(Timer t)
			{
				Change(t, -1, false);
			}

			private static void ProcessChanged()
			{
				lock (m_Changed)
				{
					var curTicks = Core.TickCount;

					foreach (var tce in m_Changed.Values)
					{
						var timer = tce.m_Timer;
						var newIndex = tce.m_NewIndex;

						if (timer.m_List != null)
						{
							timer.m_List.Remove(timer);
						}

						if (tce.m_IsAdd)
						{
							timer.m_Next = curTicks + timer.m_Delay;
							timer.m_Index = 0;
						}

						if (newIndex >= 0)
						{
							timer.m_List = m_Timers[newIndex];
							timer.m_List.Add(timer);
						}
						else
						{
							timer.m_List = null;
						}

						tce.Free();
					}

					m_Changed.Clear();
				}
			}

			public static void Set()
			{
				m_Signal.Set();
			}

			[STAThread]
			public static void TimerMain()
			{
				long now;
				int i, j;
				bool loaded;

				while (!Core.Closing)
				{
					if (World.Loading || World.Saving)
					{
						m_Signal.WaitOne(1, false);
						continue;
					}

					ProcessChanged();

					loaded = false;

					for (i = 0; i < m_Timers.Length; i++)
					{
						now = Core.TickCount;

						if (now < m_NextPriorities[i])
						{
							break;
						}

						m_NextPriorities[i] = now + m_PriorityDelays[i];

						for (j = 0; j < m_Timers[i].Count; j++)
						{
							var t = m_Timers[i][j];

							if (!t.m_Queued && now > t.m_Next)
							{
								t.m_Queued = true;

								lock (m_Queue)
								{
									m_Queue.Enqueue(t);
								}

								loaded = true;

								++t.m_Index;

								if (t.m_Count != 0 && t.m_Index >= t.m_Count)
								{
									t.Stop();
								}
								else
								{
									t.m_Next = now + t.m_Interval;
								}
							}
						}
					}

					if (loaded)
					{
						Core.Set();
					}

					m_Signal.WaitOne(1, false);
				}
			}
		}

		private static readonly Queue<Timer> m_Queue = new();

		public static int BreakCount { get; set; } = 20000;

		public static void Slice()
		{
			lock (m_Queue)
			{
				var index = 0;

				while (index < BreakCount && m_Queue.Count != 0)
				{
					var t = m_Queue.Dequeue();
					var prof = t.GetProfile();

					if (prof != null)
					{
						prof.Start();
					}

					t.OnTick();
					t.m_Queued = false;
					++index;

					if (prof != null)
					{
						prof.Finish();
					}
				}
			}
		}

		public static TimerPriority ComputePriority(TimeSpan ts)
		{
			if (ts >= TimeSpan.FromMinutes(1.0))
			{
				return TimerPriority.FiveSeconds;
			}

			if (ts >= TimeSpan.FromSeconds(10.0))
			{
				return TimerPriority.OneSecond;
			}

			if (ts >= TimeSpan.FromSeconds(5.0))
			{
				return TimerPriority.TwoFiftyMS;
			}

			if (ts >= TimeSpan.FromSeconds(2.5))
			{
				return TimerPriority.FiftyMS;
			}

			if (ts >= TimeSpan.FromSeconds(1.0))
			{
				return TimerPriority.TwentyFiveMS;
			}

			if (ts >= TimeSpan.FromSeconds(0.5))
			{
				return TimerPriority.TenMS;
			}

			return TimerPriority.EveryTick;
		}

		private static string FormatDelegate(Delegate callback)
		{
			if (callback == null)
			{
				return "null";
			}

			return $"{callback.Method.DeclaringType.FullName}.{callback.Method.Name}";
		}

		public static void DumpInfo(TextWriter tw)
		{
			TimerThread.Dump(tw);
		}

		private List<Timer> m_List;

		private long m_Next;
		private long m_Delay;
		private long m_Interval;

		private bool m_Queued;
		private bool m_Running;

		private int m_Index;

		public int TickIndex => m_Index;

		private readonly int m_Count;

		public int TickCount => m_Count;

		private bool m_PrioritySet;

		private TimerPriority m_Priority;

		public TimerPriority Priority
		{
			get => m_Priority;
			set
			{
				if (!m_PrioritySet)
				{
					m_PrioritySet = true;
				}

				if (m_Priority != value)
				{
					m_Priority = value;

					if (m_Running)
					{
						TimerThread.PriorityChange(this, (int)m_Priority);
					}
				}
			}
		}

		public DateTime Next => DateTime.UtcNow.AddMilliseconds(m_Next - Core.TickCount);

		public TimeSpan Delay
		{
			get => TimeSpan.FromMilliseconds(m_Delay);
			set => m_Delay = (long)value.TotalMilliseconds;
		}

		public TimeSpan Interval
		{
			get => TimeSpan.FromMilliseconds(m_Interval);
			set => m_Interval = (long)value.TotalMilliseconds;
		}

		public bool Running
		{
			get => m_Running;
			set
			{
				if (value)
				{
					Start();
				}
				else
				{
					Stop();
				}
			}
		}

		public virtual bool DefRegCreation => true;

		public Timer(TimeSpan delay) 
			: this(delay, TimeSpan.Zero, 1)
		{
		}

		public Timer(TimeSpan delay, TimeSpan interval) 
			: this(delay, interval, 0)
		{
		}

		public Timer(TimeSpan delay, TimeSpan interval, int count)
		{
			m_Delay = (long)delay.TotalMilliseconds;
			m_Interval = (long)interval.TotalMilliseconds;

			m_Count = count;

			if (!m_PrioritySet)
			{
				if (count == 1)
				{
					m_Priority = ComputePriority(delay);
				}
				else
				{
					m_Priority = ComputePriority(interval);
				}

				m_PrioritySet = true;
			}

			if (DefRegCreation)
			{
				RegCreation();
			}
		}

		public TimerProfile GetProfile()
		{
			if (!Core.Profiling)
			{
				return null;
			}

			var name = ToString();

			if (name == null)
			{
				name = "null";
			}

			return TimerProfile.Acquire(name);
		}

		public void RegCreation()
		{
			var prof = GetProfile();

			if (prof != null)
			{
				prof.Created++;
			}
		}

		public void Start()
		{
			if (!m_Running)
			{
				m_Running = true;

				TimerThread.AddTimer(this);

				var prof = GetProfile();

				if (prof != null)
				{
					++prof.Started;
				}

				OnStart();
			}
		}

		public void Stop()
		{
			if (m_Running)
			{
				m_Running = false;

				TimerThread.RemoveTimer(this);

				var prof = GetProfile();

				if (prof != null)
				{
					++prof.Stopped;
				}

				OnStop();
			}
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void OnStop()
		{
		}

		protected virtual void OnTick()
		{
		}

		public override string ToString()
		{
			return GetType().FullName;
		}

		#region DelayCall(..)

		public static Timer DelayCall(Action callback)
		{
			return DelayCall(TimeSpan.Zero, TimeSpan.Zero, 1, callback);
		}

		public static Timer DelayCall(TimeSpan delay, Action callback)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback);
		}

		public static Timer DelayCall(TimeSpan delay, TimeSpan interval, Action callback)
		{
			return DelayCall(delay, interval, 0, callback);
		}

		public static Timer DelayCall(TimeSpan delay, TimeSpan interval, int count, Action callback)
		{
			return new DelayCallTimer(delay, interval, count, callback);
		}

		#endregion

		#region DelayCall<T>(..)

		public static Timer DelayCall<T>(Action<T> callback, T state)
		{
			return DelayCall(TimeSpan.Zero, TimeSpan.Zero, 1, callback, state);
		}

		public static Timer DelayCall<T>(TimeSpan delay, Action<T> callback, T state)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback, state);
		}

		public static Timer DelayCall<T>(TimeSpan delay, TimeSpan interval, Action<T> callback, T state)
		{
			return DelayCall(delay, interval, 0, callback, state);
		}

		public static Timer DelayCall<T>(TimeSpan delay, TimeSpan interval, int count, Action<T> callback, T state)
		{
			return new DelayStateCallTimer<T>(delay, interval, count, callback, state);
		}

		#endregion

		#region DelayCall<T1, T2>(..)

		public static Timer DelayCall<T1, T2>(Action<T1, T2> callback, T1 state1, T2 state2)
		{
			return DelayCall(TimeSpan.Zero, TimeSpan.Zero, 1, callback, state1, state2);
		}

		public static Timer DelayCall<T1, T2>(TimeSpan delay, Action<T1, T2> callback, T1 state1, T2 state2)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback, state1, state2);
		}

		public static Timer DelayCall<T1, T2>(TimeSpan delay, TimeSpan interval, Action<T1, T2> callback, T1 state1, T2 state2)
		{
			return DelayCall(delay, interval, 0, callback, state1, state2);
		}

		public static Timer DelayCall<T1, T2>(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2> callback, T1 state1, T2 state2)
		{
			return new DelayStateCallTimer<T1, T2>(delay, interval, count, callback, (state1, state2));
		}

		#endregion

		#region DelayCall<T1, T2, T3>(..)

		public static Timer DelayCall<T1, T2, T3>(Action<T1, T2, T3> callback, T1 state1, T2 state2, T3 state3)
		{
			return DelayCall(TimeSpan.Zero, TimeSpan.Zero, 1, callback, state1, state2, state3);
		}

		public static Timer DelayCall<T1, T2, T3>(TimeSpan delay, Action<T1, T2, T3> callback, T1 state1, T2 state2, T3 state3)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback, state1, state2, state3);
		}

		public static Timer DelayCall<T1, T2, T3>(TimeSpan delay, TimeSpan interval, Action<T1, T2, T3> callback, T1 state1, T2 state2, T3 state3)
		{
			return DelayCall(delay, interval, 0, callback, state1, state2, state3);
		}

		public static Timer DelayCall<T1, T2, T3>(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3> callback, T1 state1, T2 state2, T3 state3)
		{
			return new DelayStateCallTimer<T1, T2, T3>(delay, interval, count, callback, (state1, state2, state3));
		}

		#endregion

		#region DelayCall<T1, T2, T3, T4>(..)

		public static Timer DelayCall<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback, T1 state1, T2 state2, T3 state3, T4 state4)
		{
			return DelayCall(TimeSpan.Zero, TimeSpan.Zero, 1, callback, state1, state2, state3, state4);
		}

		public static Timer DelayCall<T1, T2, T3, T4>(TimeSpan delay, Action<T1, T2, T3, T4> callback, T1 state1, T2 state2, T3 state3, T4 state4)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback, state1, state2, state3, state4);
		}

		public static Timer DelayCall<T1, T2, T3, T4>(TimeSpan delay, TimeSpan interval, Action<T1, T2, T3, T4> callback, T1 state1, T2 state2, T3 state3, T4 state4)
		{
			return DelayCall(delay, interval, 0, callback, state1, state2, state3, state4);
		}

		public static Timer DelayCall<T1, T2, T3, T4>(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3, T4> callback, T1 state1, T2 state2, T3 state3, T4 state4)
		{
			return new DelayStateCallTimer<T1, T2, T3, T4>(delay, interval, count, callback, (state1, state2, state3, state4));
		}

		#endregion

		#region DelayCall<T1, T2, T3, T4, T5>(..)

		public static Timer DelayCall<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5)
		{
			return DelayCall(TimeSpan.Zero, TimeSpan.Zero, 1, callback, state1, state2, state3, state4, state5);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5>(TimeSpan delay, Action<T1, T2, T3, T4, T5> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback, state1, state2, state3, state4, state5);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5>(TimeSpan delay, TimeSpan interval, Action<T1, T2, T3, T4, T5> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5)
		{
			return DelayCall(delay, interval, 0, callback, state1, state2, state3, state4, state5);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5>(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3, T4, T5> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5)
		{
			return new DelayStateCallTimer<T1, T2, T3, T4, T5>(delay, interval, count, callback, (state1, state2, state3, state4, state5));
		}

		#endregion

		#region DelayCall<T1, T2, T3, T4, T5, T6>(..)

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6)
		{
			return DelayCall(TimeSpan.Zero, TimeSpan.Zero, 1, callback, state1, state2, state3, state4, state5, state6);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6>(TimeSpan delay, Action<T1, T2, T3, T4, T5, T6> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback, state1, state2, state3, state4, state5, state6);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6>(TimeSpan delay, TimeSpan interval, Action<T1, T2, T3, T4, T5, T6> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6)
		{
			return DelayCall(delay, interval, 0, callback, state1, state2, state3, state4, state5, state6);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6>(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3, T4, T5, T6> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6)
		{
			return new DelayStateCallTimer<T1, T2, T3, T4, T5, T6>(delay, interval, count, callback, (state1, state2, state3, state4, state5, state6));
		}

		#endregion

		#region DelayCall<T1, T2, T3, T4, T5, T6, T7>(..)

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6, T7 state7)
		{
			return DelayCall(TimeSpan.Zero, TimeSpan.Zero, 1, callback, state1, state2, state3, state4, state5, state6, state7);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6, T7>(TimeSpan delay, Action<T1, T2, T3, T4, T5, T6, T7> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6, T7 state7)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback, state1, state2, state3, state4, state5, state6, state7);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6, T7>(TimeSpan delay, TimeSpan interval, Action<T1, T2, T3, T4, T5, T6, T7> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6, T7 state7)
		{
			return DelayCall(delay, interval, 0, callback, state1, state2, state3, state4, state5, state6, state7);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6, T7>(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3, T4, T5, T6, T7> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6, T7 state7)
		{
			return new DelayStateCallTimer<T1, T2, T3, T4, T5, T6, T7>(delay, interval, count, callback, (state1, state2, state3, state4, state5, state6, state7));
		}

		#endregion

		#region DelayCall<T1, T2, T3, T4, T5, T6, T7, T8>(..)

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6, T7 state7, T8 state8)
		{
			return DelayCall(TimeSpan.Zero, TimeSpan.Zero, 1, callback, state1, state2, state3, state4, state5, state6, state7, state8);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6, T7, T8>(TimeSpan delay, Action<T1, T2, T3, T4, T5, T6, T7, T8> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6, T7 state7, T8 state8)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback, state1, state2, state3, state4, state5, state6, state7, state8);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6, T7, T8>(TimeSpan delay, TimeSpan interval, Action<T1, T2, T3, T4, T5, T6, T7, T8> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6, T7 state7, T8 state8)
		{
			return DelayCall(delay, interval, 0, callback, state1, state2, state3, state4, state5, state6, state7, state8);
		}

		public static Timer DelayCall<T1, T2, T3, T4, T5, T6, T7, T8>(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3, T4, T5, T6, T7, T8> callback, T1 state1, T2 state2, T3 state3, T4 state4, T5 state5, T6 state6, T7 state7, T8 state8)
		{
			return new DelayStateCallTimer<T1, T2, T3, T4, T5, T6, T7, T8>(delay, interval, count, callback, (state1, state2, state3, state4, state5, state6, state7, state8));
		}

		#endregion

		#region DelayCall Timers

		private class DelayCallTimer : Timer
		{
			private readonly Action m_Callback;

			public Action Callback => m_Callback;

			public override bool DefRegCreation => false;

			public DelayCallTimer(TimeSpan delay, TimeSpan interval, int count, Action callback) 
				: base(delay, interval, count)
			{
				m_Callback = callback;

				RegCreation();

				if (count == 1)
				{
					Priority = ComputePriority(delay);
				}
				else
				{
					Priority = ComputePriority(interval);
				}

				Start();
			}

			protected override void OnTick()
			{
				m_Callback?.Invoke();
			}

			public override string ToString()
			{
				return String.Format("DelayCallTimer[{0}]", FormatDelegate(m_Callback));
			}
		}

		private class DelayStateCallTimer<T> : Timer
		{
			private readonly Action<T> m_Callback;
			private readonly T m_State;

			public Action<T> Callback => m_Callback;

			public override bool DefRegCreation => false;

			public DelayStateCallTimer(TimeSpan delay, TimeSpan interval, int count, Action<T> callback, T state)
				: base(delay, interval, count)
			{
				m_Callback = callback;
				m_State = state;

				RegCreation();

				if (count == 1)
				{
					Priority = ComputePriority(delay);
				}
				else
				{
					Priority = ComputePriority(interval);
				}

				Start();
			}

			protected override void OnTick()
			{
				m_Callback?.Invoke(m_State);
			}

			public override string ToString()
			{
				return String.Format("DelayStateCall[{0}]", FormatDelegate(m_Callback));
			}
		}

		private class DelayStateCallTimer<T1, T2> : DelayStateCallTimer<(T1, T2)>
		{
			public DelayStateCallTimer(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2> callback, (T1, T2) state)
				: base(delay, interval, count, s => callback?.Invoke(s.Item1, s.Item2), state)
			{
			}
		}

		private class DelayStateCallTimer<T1, T2, T3> : DelayStateCallTimer<(T1, T2, T3)>
		{
			public DelayStateCallTimer(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3> callback, (T1, T2, T3) state)
				: base(delay, interval, count, s => callback?.Invoke(s.Item1, s.Item2, s.Item3), state)
			{
			}
		}

		private class DelayStateCallTimer<T1, T2, T3, T4> : DelayStateCallTimer<(T1, T2, T3, T4)>
		{
			public DelayStateCallTimer(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3, T4> callback, (T1, T2, T3, T4) state)
				: base(delay, interval, count, s => callback?.Invoke(s.Item1, s.Item2, s.Item3, s.Item4), state)
			{
			}
		}

		private class DelayStateCallTimer<T1, T2, T3, T4, T5> : DelayStateCallTimer<(T1, T2, T3, T4, T5)>
		{
			public DelayStateCallTimer(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3, T4, T5> callback, (T1, T2, T3, T4, T5) state)
				: base(delay, interval, count, s => callback?.Invoke(s.Item1, s.Item2, s.Item3, s.Item4, s.Item5), state)
			{
			}
		}

		private class DelayStateCallTimer<T1, T2, T3, T4, T5, T6> : DelayStateCallTimer<(T1, T2, T3, T4, T5, T6)>
		{
			public DelayStateCallTimer(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3, T4, T5, T6> callback, (T1, T2, T3, T4, T5, T6) state)
				: base(delay, interval, count, s => callback?.Invoke(s.Item1, s.Item2, s.Item3, s.Item4, s.Item5, s.Item6), state)
			{
			}
		}

		private class DelayStateCallTimer<T1, T2, T3, T4, T5, T6, T7> : DelayStateCallTimer<(T1, T2, T3, T4, T5, T6, T7)>
		{
			public DelayStateCallTimer(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3, T4, T5, T6, T7> callback, (T1, T2, T3, T4, T5, T6, T7) state)
				: base(delay, interval, count, s => callback?.Invoke(s.Item1, s.Item2, s.Item3, s.Item4, s.Item5, s.Item6, s.Item7), state)
			{
			}
		}

		private class DelayStateCallTimer<T1, T2, T3, T4, T5, T6, T7, T8> : DelayStateCallTimer<(T1, T2, T3, T4, T5, T6, T7, T8)>
		{
			public DelayStateCallTimer(TimeSpan delay, TimeSpan interval, int count, Action<T1, T2, T3, T4, T5, T6, T7, T8> callback, (T1, T2, T3, T4, T5, T6, T7, T8) state)
				: base(delay, interval, count, s => callback?.Invoke(s.Item1, s.Item2, s.Item3, s.Item4, s.Item5, s.Item6, s.Item7, s.Item8), state)
			{
			}
		}

		#endregion
	}
}