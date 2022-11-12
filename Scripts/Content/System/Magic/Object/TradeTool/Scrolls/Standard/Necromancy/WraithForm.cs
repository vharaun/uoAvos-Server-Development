namespace Server.Items
{
	public class WraithFormScroll : SpellScroll
	{
		[Constructable]
		public WraithFormScroll() : this(1)
		{
		}

		[Constructable]
		public WraithFormScroll(int amount) : base(SpellName.WraithForm, 0x226F, amount)
		{
		}

		public WraithFormScroll(Serial serial) : base(serial)
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