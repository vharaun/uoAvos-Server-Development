namespace Server.Items
{
	public class BookOfNecromancy : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Necromancy;

		[Constructable]
		public BookOfNecromancy() 
			: this(0UL)
		{
		}

		[Constructable]
		public BookOfNecromancy(ulong content) 
			: base(content, 0x2253)
		{
		}

		public BookOfNecromancy(Serial serial) 
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