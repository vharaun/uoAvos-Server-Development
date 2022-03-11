using Server.Regions;

using System;

namespace Server.Mobiles
{
	public class SummonedLavaSerpent : BaseTalismanSummon
	{
		[Constructable]
		public SummonedLavaSerpent() : base()
		{
			Name = "a lava serpent";
			Body = 90;
			BaseSoundID = 219;
		}

		public SummonedLavaSerpent(Serial serial) : base(serial)
		{
		}

		public override void OnThink()
		{
			if (m_NextWave < DateTime.UtcNow)
			{
				AreaHeatDamage();
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}

		private DateTime m_NextWave;

		public void AreaHeatDamage()
		{
			var mob = ControlMaster;

			if (mob != null)
			{
				if (mob.InRange(Location, 2))
				{
					if (mob.AccessLevel == AccessLevel.Player && mob.AccessLevel! > AccessLevel.Player)
					{
						AOS.Damage(mob, Utility.Random(2, 3), 0, 100, 0, 0, 0);
						mob.SendLocalizedMessage(1008112); // The intense heat is damaging you!
					}
				}

				var r = Region as GuardedRegion;

				if (r != null && mob.Alive)
				{
					foreach (var m in GetMobilesInRange(2))
					{
						if (!mob.CanBeHarmful(m))
						{
							mob.CriminalAction(false);
						}
					}
				}
			}

			m_NextWave = DateTime.UtcNow + TimeSpan.FromSeconds(3);
		}
	}
}