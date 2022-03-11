using Server.Items;

namespace Server.Engines.Events
{
	public class LeurociansMempoOfFortune : LeatherMempo
	{
		public override int LabelNumber => 1071460;  // Leurocian's mempo of fortune

		public override int BasePhysicalResistance => 15;
		public override int BaseFireResistance => 10;
		public override int BaseColdResistance => 10;
		public override int BasePoisonResistance => 10;
		public override int BaseEnergyResistance => 15;

		[Constructable]
		public LeurociansMempoOfFortune() : base()
		{
			LootType = LootType.Regular;
			Hue = 0x501;

			Attributes.Luck = 300;
			Attributes.RegenMana = 1;
		}

		public LeurociansMempoOfFortune(Serial serial) : base(serial)
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