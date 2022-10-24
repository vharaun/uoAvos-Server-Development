namespace Server.Items
{
	public class ElfAbilityBook : RacialAbilityBook
	{
		public override sealed Race Race => Race.Elf;

		public override sealed SpellSchool School => SpellSchool.Elf;

		[Constructable]
		public ElfAbilityBook()
		{ }

		public ElfAbilityBook(Serial serial)
			: base(serial)
		{ }

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadEncodedInt(); // version
		}
	}
}
