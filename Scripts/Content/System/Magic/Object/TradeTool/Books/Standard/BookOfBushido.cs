namespace Server.Items
{
	public class BookOfBushido : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Bushido;

		public override bool FillSpells => true;

		[Constructable]
		public BookOfBushido() 
			: base(0UL, 0x238C)
		{
		}

		public BookOfBushido(Serial serial) 
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