namespace Server.Items
{
	public class BookOfMysticism : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Mysticism;

		[Constructable]
		public BookOfMysticism()
			: this(0UL)
		{
		}

		[Constructable]
		public BookOfMysticism(ulong content)
			: base(content, 0x2D9D)
		{
		}

		public BookOfMysticism(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadEncodedInt();
		}
	}
}