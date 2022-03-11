namespace Server.Items
{
	/// WoodenKiteShield
	public class WoodenKiteShield : BaseShield
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 1;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 20;

		public override int ArmorBase => 12;

		[Constructable]
		public WoodenKiteShield() : base(0x1B79)
		{
			Weight = 5.0;
		}

		public WoodenKiteShield(Serial serial) : base(serial)
		{
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (Weight == 7.0)
			{
				Weight = 5.0;
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);//version
		}
	}

	/// WoodenShield
	public class WoodenShield : BaseShield
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 1;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 25;

		public override int AosStrReq => 20;

		public override int ArmorBase => 8;

		[Constructable]
		public WoodenShield() : base(0x1B7A)
		{
			Weight = 5.0;
		}

		public WoodenShield(Serial serial) : base(serial)
		{
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);//version
		}
	}
}