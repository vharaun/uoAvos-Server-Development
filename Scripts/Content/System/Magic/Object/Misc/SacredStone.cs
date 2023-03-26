using Server.Mobiles;
using Server.Network;

using System;

namespace Server.Items
{
	public class SacredStone : Item
	{
		public static int CampingRange { get; set; } = 5;

		private SecureTimer m_SecureTimer;
		private DecayTimer m_Timer;

		public override bool HandlesOnMovement => true;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool CampSecure { get; set; } = false;

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Camper { get; private set; }

		[Constructable]
		public SacredStone()
			: this(null)
		{ }

		public SacredStone(Mobile owner)
			: this(owner, 120.0)
		{ }

		public SacredStone(Mobile owner, double decayTime)
			: base(0x8E3)
		{
			Movable = false;
			Name = "Sacred Stone";

			Camper = owner;

			m_Timer = new DecayTimer(this, TimeSpan.FromSeconds(decayTime));
			m_Timer.Start();
		}

		public SacredStone(Serial serial)
			: base(serial)
		{
		}

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			if (m is PlayerMobile p && (Camper == null || Camper == p))
			{
				var inOldRange = Utility.InRange(oldLocation, Location, CampingRange);
				var inNewRange = Utility.InRange(m.Location, Location, CampingRange);

				if (inNewRange && !inOldRange)
				{
					Camper ??= m;

					StartSecureTimer();
				}
				else if (inOldRange && !inNewRange)
				{
					m.SendMessage("You have left the grove.");

					if (Camper == m)
					{
						Camper = null;
					}

					StopSecureTimer();
				}
			}
		}

		public void StartSecureTimer()
		{
			m_SecureTimer ??= new SecureTimer(this, TimeSpan.FromSeconds(20.0));

			Camper?.SendMessage("You start to feel secure");

			if (!m_SecureTimer.Running)
			{
				CampSecure = false;

				m_SecureTimer.Start();
			}
		}

		public void StopSecureTimer()
		{
			CampSecure = false;

			m_SecureTimer?.Stop();
			m_SecureTimer = null;
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			m_SecureTimer?.Stop();
			m_SecureTimer = null;

			m_Timer?.Stop();
			m_Timer = null;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(Camper);

			if (m_Timer?.Running == true)
			{
				writer.Write(m_Timer.Next - DateTime.UtcNow);
			}
			else
			{
				writer.Write(TimeSpan.Zero);
			}

			if (m_SecureTimer?.Running == true)
			{
				writer.Write(m_SecureTimer.Next - DateTime.UtcNow);
			}
			else
			{
				writer.Write(TimeSpan.Zero);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadInt();

			Camper = reader.ReadMobile();

			var duration = reader.ReadTimeSpan();

			if (duration > TimeSpan.Zero)
			{
				m_Timer = new DecayTimer(this, duration);
			}
			else
			{
				m_Timer = new DecayTimer(this, TimeSpan.Zero);
			}

			m_Timer.Start();

			duration = reader.ReadTimeSpan();

			if (duration > TimeSpan.Zero)
			{
				m_SecureTimer = new SecureTimer(this, duration);
			}
			else
			{
				m_SecureTimer = new SecureTimer(this, TimeSpan.Zero);
			}

			m_SecureTimer.Start();
		}

		private class SecureTimer : Timer
		{
			private readonly SacredStone m_Stone;

			public SecureTimer(SacredStone stone, TimeSpan duration)
				: base(duration)
			{
				m_Stone = stone;
			}

			protected override void OnTick()
			{
				m_Stone.CampSecure = true;

				m_Stone.PublicOverheadMessage(MessageType.Emote, 0x55, false, "*The power of the grove washes over you*");
			}
		}

		private class DecayTimer : Timer
		{
			private readonly SacredStone m_Stone;

			public DecayTimer(SacredStone stone, TimeSpan duration)
				: base(duration)
			{
				m_Stone = stone;
			}

			protected override void OnTick()
			{
				m_Stone.Delete();
			}
		}
	}
}
