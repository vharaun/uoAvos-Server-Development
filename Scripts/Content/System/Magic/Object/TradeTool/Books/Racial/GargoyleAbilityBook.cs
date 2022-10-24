namespace Server.Items
{
	public class GargoyleAbilityBook : RacialAbilityBook
	{
		public override sealed Race Race => Race.Gargoyle;

		public override sealed SpellSchool School => SpellSchool.Gargoyle;

		[Constructable]
		public GargoyleAbilityBook()
		{ }

		public GargoyleAbilityBook(Serial serial)
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
