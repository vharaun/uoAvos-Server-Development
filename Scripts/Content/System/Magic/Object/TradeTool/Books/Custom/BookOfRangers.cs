namespace Server.Items
{
	public class BookOfRangers : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Ranger;

		[Constructable]
		public BookOfRangers()
			: this(0UL)
		{
		}

		[Constructable]
		public BookOfRangers(ulong content)
			: base(content, 0xEFA)
		{
		}

		public BookOfRangers(Serial serial)
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
