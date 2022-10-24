namespace Server.Items
{
	public class BookOfAvatars : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Avatar;

		[Constructable]
		public BookOfAvatars()
			: this(0UL)
		{
		}

		[Constructable]
		public BookOfAvatars(ulong content)
			: base(content, 0xEFA)
		{
		}

		public BookOfAvatars(Serial serial)
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
