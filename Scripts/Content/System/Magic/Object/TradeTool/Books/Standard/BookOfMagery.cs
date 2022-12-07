namespace Server.Items
{
	public class BookOfMagery : Spellbook
    {
        public override sealed SpellSchool School => SpellSchool.Magery;

        [Constructable]
        public BookOfMagery()
            : this(0UL)
        {
		}

        [Constructable]
        public BookOfMagery(ulong content)
            : base(content, 0xEFA)
        { 
		}

        public BookOfMagery(Serial serial)
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
