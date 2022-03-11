using Server.Items;

namespace Server.Engines.Events
{
	public class LegsOfStability : PlateSuneate
	{
		public override int LabelNumber => 1070925;  // Legs of Stability

		public override int BasePhysicalResistance => 20;
		public override int BasePoisonResistance => 18;

		[Constructable]
		public LegsOfStability() : base()
		{
			Attributes.BonusStam = 5;

			ArmorAttributes.SelfRepair = 3;
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
		}

		public LegsOfStability(Serial serial) : base(serial)
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