namespace Server.Items
{
	/// MisoSoup
	public class MisoSoup : Food
	{
		[Constructable]
		public MisoSoup() : base(0x284D)
		{
			Stackable = false;
			Weight = 4.0;
			FillFactor = 2;
		}

		public MisoSoup(Serial serial) : base(serial)
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

	/// WhiteMisoSoup
	public class WhiteMisoSoup : Food
	{
		[Constructable]
		public WhiteMisoSoup() : base(0x284E)
		{
			Stackable = false;
			Weight = 4.0;
			FillFactor = 2;
		}

		public WhiteMisoSoup(Serial serial) : base(serial)
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

	/// RedMisoSoup
	public class RedMisoSoup : Food
	{
		[Constructable]
		public RedMisoSoup() : base(0x284F)
		{
			Stackable = false;
			Weight = 4.0;
			FillFactor = 2;
		}

		public RedMisoSoup(Serial serial) : base(serial)
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

	/// AwaseMisoSoup
	public class AwaseMisoSoup : Food
	{
		[Constructable]
		public AwaseMisoSoup() : base(0x2850)
		{
			Stackable = false;
			Weight = 4.0;
			FillFactor = 2;
		}

		public AwaseMisoSoup(Serial serial) : base(serial)
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
}