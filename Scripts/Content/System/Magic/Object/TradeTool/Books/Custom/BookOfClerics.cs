namespace Server.Items
{
	public class BookOfClerics : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Cleric;

		[Constructable]
		public BookOfClerics()
			: this(0UL)
		{
		}

		[Constructable]
		public BookOfClerics(ulong content)
			: base(content, 0x2252)
		{
		}

		public BookOfClerics(Serial serial)
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
