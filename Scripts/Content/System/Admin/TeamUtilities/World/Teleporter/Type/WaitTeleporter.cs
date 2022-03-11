
using System;
using System.Collections.Generic;

namespace Server.Items
{
	public class WaitTeleporter : KeywordTeleporter
	{
		private static Dictionary<Mobile, TeleportingInfo> m_Table;

		public static void Initialize()
		{
			m_Table = new Dictionary<Mobile, TeleportingInfo>();

			EventSink.Logout += new LogoutEventHandler(EventSink_Logout);
		}

		public static void EventSink_Logout(LogoutEventArgs e)
		{
			var from = e.Mobile;
			TeleportingInfo info;

			if (from == null || !m_Table.TryGetValue(from, out info))
			{
				return;
			}

			info.Timer.Stop();
			m_Table.Remove(from);
		}

		private int m_StartNumber;
		private string m_StartMessage;
		private int m_ProgressNumber;
		private string m_ProgressMessage;
		private bool m_ShowTimeRemaining;

		[CommandProperty(AccessLevel.GameMaster)]
		public int StartNumber
		{
			get => m_StartNumber;
			set => m_StartNumber = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public string StartMessage
		{
			get => m_StartMessage;
			set => m_StartMessage = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int ProgressNumber
		{
			get => m_ProgressNumber;
			set => m_ProgressNumber = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public string ProgressMessage
		{
			get => m_ProgressMessage;
			set => m_ProgressMessage = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool ShowTimeRemaining
		{
			get => m_ShowTimeRemaining;
			set => m_ShowTimeRemaining = value;
		}

		[Constructable]
		public WaitTeleporter()
		{
		}

		public static string FormatTime(TimeSpan ts)
		{
			if (ts.TotalHours >= 1)
			{
				var h = (int)Math.Round(ts.TotalHours);
				return String.Format("{0} hour{1}", h, (h == 1) ? "" : "s");
			}
			else if (ts.TotalMinutes >= 1)
			{
				var m = (int)Math.Round(ts.TotalMinutes);
				return String.Format("{0} minute{1}", m, (m == 1) ? "" : "s");
			}

			var s = Math.Max((int)Math.Round(ts.TotalSeconds), 0);
			return String.Format("{0} second{1}", s, (s == 1) ? "" : "s");
		}

		private void EndLock(Mobile m)
		{
			m.EndAction(this);
		}

		public override void StartTeleport(Mobile m)
		{
			TeleportingInfo info;

			if (m_Table.TryGetValue(m, out info))
			{
				if (info.Teleporter == this)
				{
					if (m.BeginAction(this))
					{
						if (m_ProgressMessage != null)
						{
							m.SendMessage(m_ProgressMessage);
						}
						else if (m_ProgressNumber != 0)
						{
							m.SendLocalizedMessage(m_ProgressNumber);
						}

						if (m_ShowTimeRemaining)
						{
							m.SendMessage("Time remaining: {0}", FormatTime(m_Table[m].Timer.Next - DateTime.UtcNow));
						}

						Timer.DelayCall<Mobile>(TimeSpan.FromSeconds(5), EndLock, m);
					}

					return;
				}
				else
				{
					info.Timer.Stop();
				}
			}

			if (m_StartMessage != null)
			{
				m.SendMessage(m_StartMessage);
			}
			else if (m_StartNumber != 0)
			{
				m.SendLocalizedMessage(m_StartNumber);
			}

			if (Delay == TimeSpan.Zero)
			{
				DoTeleport(m);
			}
			else
			{
				m_Table[m] = new TeleportingInfo(this, Timer.DelayCall<Mobile>(Delay, DoTeleport, m));
			}
		}

		public override void DoTeleport(Mobile m)
		{
			m_Table.Remove(m);

			base.DoTeleport(m);
		}

		public WaitTeleporter(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_StartNumber);
			writer.Write(m_StartMessage);
			writer.Write(m_ProgressNumber);
			writer.Write(m_ProgressMessage);
			writer.Write(m_ShowTimeRemaining);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			m_StartNumber = reader.ReadInt();
			m_StartMessage = reader.ReadString();
			m_ProgressNumber = reader.ReadInt();
			m_ProgressMessage = reader.ReadString();
			m_ShowTimeRemaining = reader.ReadBool();
		}

		private class TeleportingInfo
		{
			private readonly WaitTeleporter m_Teleporter;
			private readonly Timer m_Timer;

			public WaitTeleporter Teleporter => m_Teleporter;
			public Timer Timer => m_Timer;

			public TeleportingInfo(WaitTeleporter tele, Timer t)
			{
				m_Teleporter = tele;
				m_Timer = t;
			}
		}
	}
}