using Server.Items;

namespace Server.Mobiles
{
	[CorpseName("a dryad corpse")]
	public class DryadFamiliar : BaseFamiliar
	{
		[Constructable]
		public DryadFamiliar()
			: base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "a dryad";
			Body = 401;
			Hue = 33770;
			BaseSoundID = 0x4B0;

			SetStr(200);
			SetDex(200);
			SetInt(100);

			SetHits(175);
			SetStam(50);

			SetDamage(6, 9);

			SetDamageType(ResistanceType.Physical, 50);
			SetDamageType(ResistanceType.Energy, 50);

			SetResistance(ResistanceType.Physical, 40, 50);
			SetResistance(ResistanceType.Fire, 30, 40);
			SetResistance(ResistanceType.Cold, 35, 45);
			SetResistance(ResistanceType.Poison, 50, 60);
			SetResistance(ResistanceType.Energy, 70, 80);

			SetSkill(SkillName.Meditation, 110.0);
			SetSkill(SkillName.EvalInt, 110.0);
			SetSkill(SkillName.Magery, 110.0);
			SetSkill(SkillName.MagicResist, 110.0);
			SetSkill(SkillName.Tactics, 110.0);
			SetSkill(SkillName.Wrestling, 110.0);

			VirtualArmor = 45;
			ControlSlots = 2;

			Utility.AssignRandomHair(this, true);

			AddItem(new BodySash
			{
				Hue = Utility.RandomList(1165, 1166, 1167, 1168, 1169, 1170, 1171, 1172),
				Movable = false
			});

			AddItem(new Sandals
			{
				Hue = Utility.RandomList(1165, 1166, 1167, 1168, 1169, 1170, 1171, 1172),
				Movable = false
			});

			AddItem(new LeatherSkirt
			{
				Hue = Utility.RandomList(1165, 1166, 1167, 1168, 1169, 1170, 1171, 1172),
				Movable = false
			});

			AddItem(new FlowerGarland()
			{
				Hue = Utility.RandomList(1165, 1166, 1167, 1168, 1169, 1170, 1171, 1172),
				Movable = false
			});
		}

		public DryadFamiliar(Serial serial)
			: base(serial)
		{
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
