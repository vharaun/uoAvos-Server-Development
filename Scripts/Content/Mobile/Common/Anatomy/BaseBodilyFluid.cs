using Server.Mobiles;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	/// AcidSlime
	public class AcidSlime : Item
	{
		private readonly TimeSpan m_Duration;
		private readonly int m_MinDamage;
		private readonly int m_MaxDamage;
		private readonly DateTime m_Created;
		private bool m_Drying;
		private readonly Timer m_Timer;

		[Constructable]
		public AcidSlime() : this(TimeSpan.FromSeconds(10.0), 5, 10)
		{
		}

		public override string DefaultName => "slime";

		[Constructable]
		public AcidSlime(TimeSpan duration, int minDamage, int maxDamage)
			: base(0x122A)
		{
			Hue = 0x3F;
			Movable = false;
			m_MinDamage = minDamage;
			m_MaxDamage = maxDamage;
			m_Created = DateTime.UtcNow;
			m_Duration = duration;
			m_Timer = Timer.DelayCall(TimeSpan.Zero, TimeSpan.FromSeconds(1), OnTick);
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}
		}

		private void OnTick()
		{
			var now = DateTime.UtcNow;
			var age = now - m_Created;

			if (age > m_Duration)
			{
				Delete();
			}
			else
			{
				if (!m_Drying && age > (m_Duration - age))
				{
					m_Drying = true;
					ItemID = 0x122B;
				}

				var toDamage = new List<Mobile>();

				foreach (var m in GetMobilesInRange(0))
				{
					var bc = m as BaseCreature;
					if (m.Alive && !m.IsDeadBondedPet && (bc == null || bc.Controlled || bc.Summoned))
					{
						toDamage.Add(m);
					}
				}

				for (var i = 0; i < toDamage.Count; i++)
				{
					Damage(toDamage[i]);
				}
			}
		}

		public override bool OnMoveOver(Mobile m)
		{
			Damage(m);
			return true;
		}

		public void Damage(Mobile m)
		{
			var damage = Utility.RandomMinMax(m_MinDamage, m_MaxDamage);
			if (Core.AOS)
			{
				AOS.Damage(m, damage, 0, 0, 0, 100, 0);
			}
			else
			{
				m.Damage(damage);
			}
		}

		public AcidSlime(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
		}

		public override void Deserialize(GenericReader reader)
		{
		}
	}

	/// Blood
	public class Blood : Item
	{
		[Constructable]
		public Blood() : this(Utility.RandomList(0x1645, 0x122A, 0x122B, 0x122C, 0x122D, 0x122E, 0x122F))
		{
		}

		[Constructable]
		public Blood(int itemID) : base(itemID)
		{
			Movable = false;

			new InternalTimer(this).Start();
		}

		public Blood(Serial serial) : base(serial)
		{
			new InternalTimer(this).Start();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Blood;

			public InternalTimer(Item blood) : base(TimeSpan.FromSeconds(5.0))
			{
				Priority = TimerPriority.OneSecond;

				m_Blood = blood;
			}

			protected override void OnTick()
			{
				m_Blood.Delete();
			}
		}
	}

	/// PoolOfAcid
	public class PoolOfAcid : Item
	{
		private readonly TimeSpan m_Duration;
		private readonly int m_MinDamage;
		private readonly int m_MaxDamage;
		private readonly DateTime m_Created;
		private bool m_Drying;
		private readonly Timer m_Timer;

		[Constructable]
		public PoolOfAcid() : this(TimeSpan.FromSeconds(10.0), 2, 5)
		{
		}

		public override string DefaultName => "a pool of acid";

		[Constructable]
		public PoolOfAcid(TimeSpan duration, int minDamage, int maxDamage)
			: base(0x122A)
		{
			Hue = 0x3F;
			Movable = false;

			m_MinDamage = minDamage;
			m_MaxDamage = maxDamage;
			m_Created = DateTime.UtcNow;
			m_Duration = duration;

			m_Timer = Timer.DelayCall(TimeSpan.Zero, TimeSpan.FromSeconds(1), OnTick);
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}
		}

		private void OnTick()
		{
			var now = DateTime.UtcNow;
			var age = now - m_Created;

			if (age > m_Duration)
			{
				Delete();
			}
			else
			{
				if (!m_Drying && age > (m_Duration - age))
				{
					m_Drying = true;
					ItemID = 0x122B;
				}

				var toDamage = new List<Mobile>();

				foreach (var m in GetMobilesInRange(0))
				{
					var bc = m as BaseCreature;

					if (m.Alive && !m.IsDeadBondedPet && (bc == null || bc.Controlled || bc.Summoned))
					{
						toDamage.Add(m);
					}
				}

				for (var i = 0; i < toDamage.Count; i++)
				{
					Damage(toDamage[i]);
				}
			}
		}
		public override bool OnMoveOver(Mobile m)
		{
			Damage(m);
			return true;
		}

		public void Damage(Mobile m)
		{
			m.Damage(Utility.RandomMinMax(m_MinDamage, m_MaxDamage));
		}

		public PoolOfAcid(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			//Don't serialize these
		}

		public override void Deserialize(GenericReader reader)
		{
		}
	}
}