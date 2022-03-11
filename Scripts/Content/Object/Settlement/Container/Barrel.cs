namespace Server.Items
{
	/// Barrel
	public class Barrel : BaseContainer
	{
		[Constructable]
		public Barrel() : base(0xE77)
		{
			Weight = 25.0;
		}

		public Barrel(Serial serial) : base(serial)
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

			if (Weight == 0.0)
			{
				Weight = 25.0;
			}
		}
	}

	/// Keg
	public class Keg : BaseContainer
	{
		[Constructable]
		public Keg() : base(0xE7F)
		{
			Weight = 15.0;
		}

		public Keg(Serial serial) : base(serial)
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