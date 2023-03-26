using System;

namespace Server.Mobiles
{
	[CorpseName("a spirit eagle corpse")]
	public class EagleFamiliar : BaseFamiliar
	{
		private DateTime m_NextRestore;

		[Constructable]
		public EagleFamiliar()
		{
			Name = "a spirit eagle";
			Name = "an eagle";
			Body = 5;
			BaseSoundID = 0x2EE;
			Hue = 2213;

			SetStr(100);
			SetDex(90);
			SetInt(90);

			SetHits(60);
			SetStam(90);
			SetMana(0);

			SetDamage(5, 10);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 40, 50);
			SetResistance(ResistanceType.Fire, 25, 40);
			SetResistance(ResistanceType.Cold, 25, 40);
			SetResistance(ResistanceType.Poison, 25, 40);
			SetResistance(ResistanceType.Energy, 25, 40);

			SetSkill(SkillName.Wrestling, 85.1, 90.0);
			SetSkill(SkillName.Tactics, 50.0);

			ControlSlots = 1;
		}

		public EagleFamiliar(Serial serial)
			: base(serial)
		{
		}

		public override void OnThink()
		{
			base.OnThink();

			if (DateTime.UtcNow < m_NextRestore)
			{
				return;
			}

			m_NextRestore = DateTime.UtcNow.AddSeconds(2.0);

			var caster = GetMaster();

			if (caster != null)
			{
				++caster.Stam;
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
