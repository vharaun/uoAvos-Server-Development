namespace Server.Items
{
	public class EvilOmenScroll : SpellScroll
	{
		[Constructable]
		public EvilOmenScroll() : this(1)
		{
		}

		[Constructable]
		public EvilOmenScroll(int amount) : base(SpellName.EvilOmen, 0x2264, amount)
		{
		}

		public EvilOmenScroll(Serial serial) : base(serial)
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