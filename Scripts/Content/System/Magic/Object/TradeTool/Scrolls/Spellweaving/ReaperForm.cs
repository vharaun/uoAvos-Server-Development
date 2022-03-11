namespace Server.Items
{
	public class ReaperFormScroll : SpellScroll
	{
		[Constructable]
		public ReaperFormScroll()
			: this(1)
		{
		}

		[Constructable]
		public ReaperFormScroll(int amount)
			: base(608, 0x2D59, amount)
		{
			Hue = 0x8FD;
		}

		public ReaperFormScroll(Serial serial)
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