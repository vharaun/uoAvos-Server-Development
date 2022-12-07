namespace Server.Items
{
	public class HumanAbilityBook : RacialAbilityBook
	{
		public override sealed Race Race => Race.Human;

		public override sealed SpellSchool School => SpellSchool.Human;

		[Constructable]
		public HumanAbilityBook()
		{ }

		public HumanAbilityBook(Serial serial)
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
