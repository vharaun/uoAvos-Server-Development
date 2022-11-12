namespace Server.Items
{
	public class MindRotScroll : SpellScroll
	{
		[Constructable]
		public MindRotScroll() : this(1)
		{
		}

		[Constructable]
		public MindRotScroll(int amount) : base(SpellName.MindRot, 0x2267, amount)
		{
		}

		public MindRotScroll(Serial serial) : base(serial)
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