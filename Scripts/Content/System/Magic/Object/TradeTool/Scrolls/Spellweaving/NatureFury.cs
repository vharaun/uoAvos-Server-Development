namespace Server.Items
{
	public class NatureFuryScroll : SpellScroll
	{
		[Constructable]
		public NatureFuryScroll()
			: this(1)
		{
		}

		[Constructable]
		public NatureFuryScroll(int amount)
			: base(605, 0x2D56, amount)
		{
			Hue = 0x8FD;
		}

		public NatureFuryScroll(Serial serial)
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