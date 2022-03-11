namespace Server.Items
{
	/// BearMask
	public class BearMask : BaseHat
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 8;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public BearMask() : this(0)
		{
		}

		[Constructable]
		public BearMask(int hue) : base(0x1545, hue)
		{
			Weight = 5.0;
		}

		public override bool Dye(Mobile from, DyeTub sender)
		{
			from.SendLocalizedMessage(sender.FailMessage);
			return false;
		}

		public BearMask(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	/// DeerMask
	public class DeerMask : BaseHat
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 6;
		public override int BaseColdResistance => 8;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 7;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public DeerMask() : this(0)
		{
		}

		[Constructable]
		public DeerMask(int hue) : base(0x1547, hue)
		{
			Weight = 4.0;
		}

		public override bool Dye(Mobile from, DyeTub sender)
		{
			from.SendLocalizedMessage(sender.FailMessage);
			return false;
		}

		public DeerMask(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	/// HornedTribalMask
	public class HornedTribalMask : BaseHat
	{
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 9;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public HornedTribalMask() : this(0)
		{
		}

		[Constructable]
		public HornedTribalMask(int hue) : base(0x1549, hue)
		{
			Weight = 2.0;
		}

		public override bool Dye(Mobile from, DyeTub sender)
		{
			from.SendLocalizedMessage(sender.FailMessage);
			return false;
		}

		public HornedTribalMask(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	/// TribalMask
	public class TribalMask : BaseHat
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 6;
		public override int BasePoisonResistance => 10;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public TribalMask() : this(0)
		{
		}

		[Constructable]
		public TribalMask(int hue) : base(0x154B, hue)
		{
			Weight = 2.0;
		}

		public override bool Dye(Mobile from, DyeTub sender)
		{
			from.SendLocalizedMessage(sender.FailMessage);
			return false;
		}

		public TribalMask(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	/// OrcishKinMask
	public class OrcishKinMask : BaseHat
	{
		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 1;
		public override int BaseColdResistance => 7;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 8;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		public override bool Dye(Mobile from, DyeTub sender)
		{
			from.SendLocalizedMessage(sender.FailMessage);
			return false;
		}

		public override string DefaultName => "a mask of orcish kin";

		[Constructable]
		public OrcishKinMask() : this(0x8A4)
		{
		}

		[Constructable]
		public OrcishKinMask(int hue) : base(0x141B, hue)
		{
			Weight = 2.0;
		}

		public override bool CanEquip(Mobile m)
		{
			if (!base.CanEquip(m))
			{
				return false;
			}

			if (m.BodyMod == 183 || m.BodyMod == 184)
			{
				m.SendLocalizedMessage(1061629); // You can't do that while wearing savage kin paint.
				return false;
			}

			return true;
		}

		public override void OnAdded(IEntity parent)
		{
			base.OnAdded(parent);

			if (parent is Mobile)
			{
				Misc.Titles.AwardKarma((Mobile)parent, -20, true);
			}
		}

		public OrcishKinMask(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			/*if ( Hue != 0x8A4 )
				Hue = 0x8A4;*/
		}
	}

	/// SavageMask
	public class SavageMask : BaseHat
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 6;
		public override int BasePoisonResistance => 10;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		public static int GetRandomHue()
		{
			var v = Utility.RandomBirdHue();

			if (v == 2101)
			{
				v = 0;
			}

			return v;
		}

		public override bool Dye(Mobile from, DyeTub sender)
		{
			from.SendLocalizedMessage(sender.FailMessage);
			return false;
		}

		[Constructable]
		public SavageMask() : this(GetRandomHue())
		{
		}

		[Constructable]
		public SavageMask(int hue) : base(0x154B, hue)
		{
			Weight = 2.0;
		}

		public SavageMask(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			/*if ( Hue != 0 && (Hue < 2101 || Hue > 2130) )
				Hue = GetRandomHue();*/
		}
	}
}