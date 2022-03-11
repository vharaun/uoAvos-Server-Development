using Server.Items;

namespace Server.Engines.Events
{
	public class AncientSamuraiDo : PlateDo
	{
		public override int LabelNumber => 1070926;  // Ancient Samurai Do

		public override int BasePhysicalResistance => 15;
		public override int BaseFireResistance => 12;
		public override int BaseColdResistance => 10;
		public override int BasePoisonResistance => 11;
		public override int BaseEnergyResistance => 8;

		[Constructable]
		public AncientSamuraiDo() : base()
		{
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
			SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
		}

		public AncientSamuraiDo(Serial serial) : base(serial)
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

			var version = reader.ReadInt();
		}

		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;
	}
}