using Server.Items;

namespace Server.Engines.Events
{
	public class RuneBeetleCarapace : PlateDo
	{
		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		public override int LabelNumber => 1070968;  // Rune Beetle Carapace

		public override int BaseColdResistance => 14;
		public override int BaseEnergyResistance => 14;

		[Constructable]
		public RuneBeetleCarapace() : base()
		{
			Attributes.BonusMana = 10;
			Attributes.RegenMana = 3;
			Attributes.LowerManaCost = 15;
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
		}

		public RuneBeetleCarapace(Serial serial) : base(serial)
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
	}
}