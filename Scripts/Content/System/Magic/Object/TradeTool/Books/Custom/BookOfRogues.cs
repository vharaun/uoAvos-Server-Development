namespace Server.Items
{
	public class BookOfRogues : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Rogue;

		[Constructable]
		public BookOfRogues()
			: this(0UL)
		{
		}

		[Constructable]
		public BookOfRogues(ulong content)
			: base(content, 0xEFA)
		{
		}

		public BookOfRogues(Serial serial)
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
