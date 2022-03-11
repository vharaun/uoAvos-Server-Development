using Server.Items;

namespace Server.Engines.Events
{
	public class KasaOfTheRajin : Kasa
	{
		public override int LabelNumber => 1070969;  // Kasa of the Raj-in

		public override int BasePhysicalResistance => 12;
		public override int BaseFireResistance => 17;
		public override int BaseColdResistance => 21;
		public override int BasePoisonResistance => 17;
		public override int BaseEnergyResistance => 17;

		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		[Constructable]
		public KasaOfTheRajin() : base()
		{
			Attributes.SpellDamage = 12;
		}

		public KasaOfTheRajin(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(2);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version <= 1)
			{
				MaxHitPoints = 255;
				HitPoints = 255;
			}

			if (version == 0)
			{
				LootType = LootType.Regular;
			}
		}
	}
}