namespace Server.Items
{
	public class BookOfDruids : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Druid;

		[Constructable]
		public BookOfDruids()
			: this(0UL)
		{
		}

		[Constructable]
		public BookOfDruids(ulong content)
			: base(content, 0xEFA)
		{
		}

		public BookOfDruids(Serial serial)
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
