using Server.Items;

using System;

namespace Server.Mobiles
{
	[CorpseName("a thunder hound corpse")]
	public class ThunderHoundFamiliar : BaseFamiliar
	{
		private DateTime m_NextFlare;

		public ThunderHoundFamiliar()
		{
			Name = "a thunder hound";
			Body = 98;
			Hue = 1176;
			BaseSoundID = 229;

			SetStr(90);
			SetDex(80);
			SetInt(40);

			SetHits(70);
			SetStam(70);
			SetMana(0);

			SetDamage(10, 20);

			SetDamageType(ResistanceType.Energy, 100);

			SetResistance(ResistanceType.Physical, 10, 15);
			SetResistance(ResistanceType.Fire, 10, 15);
			SetResistance(ResistanceType.Cold, 10, 15);
			SetResistance(ResistanceType.Poison, 10, 15);
			SetResistance(ResistanceType.Energy, 99);

			SetSkill(SkillName.Wrestling, 50.0);
			SetSkill(SkillName.Tactics, 50.0);

			ControlSlots = 1;

			AddItem(new LightSource());
		}

		public ThunderHoundFamiliar(Serial serial)
			: base(serial)
		{
		}

		public override void OnThink()
		{
			base.OnThink();

			if (DateTime.UtcNow < m_NextFlare)
			{
				return;
			}

			m_NextFlare = DateTime.UtcNow.AddSeconds(5.0 + (25.0 * Utility.RandomDouble()));

			FixedEffect(0x37C4, 1, 12, 1109, 6);
			PlaySound(230);

			_ = Timer.DelayCall(TimeSpan.FromSeconds(0.5), Flare);
		}

		private void Flare()
		{
			var caster = GetMaster();

			if (caster == null)
			{
				return;
			}

			var eable = GetMobilesInRange(5);

			foreach (var m in eable)
			{
				if (m.Player && m.Alive && !m.IsDeadBondedPet && m.Karma <= 0)
				{
					var friendly = true;

					for (var j = 0; friendly && j < caster.Aggressors.Count; ++j)
					{
						friendly = caster.Aggressors[j].Attacker != m;
					}

					for (var j = 0; friendly && j < caster.Aggressed.Count; ++j)
					{
						friendly = caster.Aggressed[j].Defender != m;
					}

					if (friendly)
					{
						m.FixedEffect(0x37C4, 1, 12, 1109, 3); // At player
						m.Mana += 1 - (m.Karma / 1000);
					}
				}
			}

			eable.Free();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadInt();
		}
	}
}
