namespace Server.Items
{
	public class BookOfSpellweaving : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Spellweaving;

		[Constructable]
		public BookOfSpellweaving() 
			: this(0UL)
		{
		}

		[Constructable]
		public BookOfSpellweaving(ulong content) 
			: base(content, 0x2D50)
		{
		}

		public BookOfSpellweaving(Serial serial) 
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