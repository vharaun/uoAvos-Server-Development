namespace Server.Items
{
	public class WhiteChocolate : CandyCane
	{
		public override int LabelNumber => 1079996;  // White chocolate
		public override double DefaultWeight => 1.0;

		[Constructable]
		public WhiteChocolate()
			: base(0xF11)
		{
			Hue = 0x47E;
			LootType = LootType.Regular;
		}

		public WhiteChocolate(Serial serial)
			: base(serial)
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