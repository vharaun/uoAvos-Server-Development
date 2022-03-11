namespace Server.Items
{
	public class CocoaLiquor : Item
	{
		public override int LabelNumber => 1080007;  // Cocoa liquor
		public override double DefaultWeight => 1.0;

		[Constructable]
		public CocoaLiquor()
			: base(0x103F)
		{
			Hue = 0x46A;
		}

		public CocoaLiquor(Serial serial)
			: base(serial)
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