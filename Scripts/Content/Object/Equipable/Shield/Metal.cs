namespace Server.Items
{
	/// BronzeShield
	public class BronzeShield : BaseShield
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 1;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 0;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 35;

		public override int ArmorBase => 10;

		[Constructable]
		public BronzeShield() : base(0x1B72)
		{
			Weight = 6.0;
		}

		public BronzeShield(Serial serial) : base(serial)
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

	/// Buckler
	public class Buckler : BaseShield
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 0;

		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;

		public override int AosStrReq => 20;

		public override int ArmorBase => 7;

		[Constructable]
		public Buckler() : base(0x1B73)
		{
			Weight = 5.0;
		}

		public Buckler(Serial serial) : base(serial)
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

	/// HeaterShield
	public class HeaterShield : BaseShield
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 1;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 0;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 90;

		public override int ArmorBase => 23;

		[Constructable]
		public HeaterShield() : base(0x1B76)
		{
			Weight = 8.0;
		}

		public HeaterShield(Serial serial) : base(serial)
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

	/// MetalShield
	public class MetalShield : BaseShield
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 1;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 0;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 45;

		public override int ArmorBase => 11;

		[Constructable]
		public MetalShield() : base(0x1B7B)
		{
			Weight = 6.0;
		}

		public MetalShield(Serial serial) : base(serial)
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

	/// MetalKiteShield
	public class MetalKiteShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 1;

		public override int InitMinHits => 45;
		public override int InitMaxHits => 60;

		public override int AosStrReq => 45;

		public override int ArmorBase => 16;

		[Constructable]
		public MetalKiteShield() : base(0x1B74)
		{
			Weight = 7.0;
		}

		public MetalKiteShield(Serial serial) : base(serial)
		{
		}

		public bool Dye(Mobile from, DyeTub sender)
		{
			if (Deleted)
			{
				return false;
			}

			Hue = sender.DyedHue;

			return true;
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (Weight == 5.0)
			{
				Weight = 7.0;
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);//version
		}
	}
}