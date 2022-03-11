using Server.Items;

namespace Server.Engines.Events
{
	public class BlackLotusHood : ClothNinjaHood
	{
		public override int LabelNumber => 1070919;  // Black Lotus Hood

		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 11;
		public override int BaseColdResistance => 15;
		public override int BasePoisonResistance => 11;
		public override int BaseEnergyResistance => 11;

		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		[Constructable]
		public BlackLotusHood() : base()
		{
			Attributes.LowerManaCost = 6;
			Attributes.AttackChance = 6;
			ClothingAttributes.SelfRepair = 5;
		}

		public BlackLotusHood(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version == 0)
			{
				MaxHitPoints = 255;
				HitPoints = 255;
			}
		}
	}
}