namespace Server.Items
{
	public class DarkChocolate : CandyCane
	{
		public override int LabelNumber => 1079994;  // Dark chocolate
		public override double DefaultWeight => 1.0;

		[Constructable]
		public DarkChocolate()
			: base(0xF10)
		{
			Hue = 0x465;
			LootType = LootType.Regular;
		}

		public DarkChocolate(Serial serial)
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