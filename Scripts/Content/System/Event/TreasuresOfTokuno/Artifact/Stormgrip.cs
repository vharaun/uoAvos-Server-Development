using Server.Items;

namespace Server.Engines.Events
{
	public class Stormgrip : LeatherNinjaMitts
	{
		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		public override int LabelNumber => 1070970;  // Stormgrip

		public override int BasePhysicalResistance => 10;
		public override int BaseColdResistance => 18;
		public override int BaseEnergyResistance => 18;

		[Constructable]
		public Stormgrip() : base()
		{
			Attributes.BonusInt = 8;
			Attributes.Luck = 125;
			Attributes.WeaponDamage = 25;
		}

		public Stormgrip(Serial serial) : base(serial)
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