using Server.Items;

using System;

namespace Server.Mobiles
{
	[CorpseName("a pixie corpse")]
	public class PixieFamiliar : BaseFamiliar
	{
		private DateTime m_NextFlare;

		[Constructable]
		public PixieFamiliar()
		{
			Name = "a pixie";
			Body = 128;
			Hue = Utility.RandomList(0, 1176, 1174, 1172, 1171, 1170, 1164, 1159, 1152, 0);
			BaseSoundID = 0x467;

			SetStr(50);
			SetDex(60);
			SetInt(100);

			SetHits(50);
			SetStam(60);
			SetMana(0);

			SetDamage(5, 10);

			SetDamageType(ResistanceType.Energy, 100);

			SetResistance(ResistanceType.Physical, 10, 15);
			SetResistance(ResistanceType.Fire, 10, 15);
			SetResistance(ResistanceType.Cold, 10, 15);
			SetResistance(ResistanceType.Poison, 10, 15);
			SetResistance(ResistanceType.Energy, 99);

			SetSkill(SkillName.Wrestling, 40.0);
			SetSkill(SkillName.Tactics, 40.0);

			ControlSlots = 1;

			AddItem(new LightSource());
		}

		public PixieFamiliar(Serial serial)
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

			m_NextFlare = DateTime.UtcNow + TimeSpan.FromSeconds(5.0 + (25.0 * Utility.RandomDouble()));

			FixedEffect(0x37C4, 1, 12, 1109, 6);
			PlaySound(0x1D3);

			_ = Timer.DelayCall(TimeSpan.FromSeconds(0.5), Flare);
		}

		private void Flare()
		{
			var caster = GetMaster();

			if (caster == null)
			{
				return;
			}

			foreach (var m in GetMobilesInRange(5))
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
