namespace Server.Items
{
	public class CakeMix : CookableFood
	{
		public override int LabelNumber => 1041002;  // cake mix

		[Constructable]
		public CakeMix() : base(0x103F, 40)
		{
			Weight = 1.0;
		}

		public override Food Cook()
		{
			return new Cake();
		}

		public CakeMix(Serial serial) : base(serial)
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