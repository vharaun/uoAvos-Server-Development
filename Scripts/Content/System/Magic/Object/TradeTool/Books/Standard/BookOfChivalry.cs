namespace Server.Items
{
	public class BookOfChivalry : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Chivalry;

		public override bool FillSpells => true;

		[Constructable]
		public BookOfChivalry()
			: base(0UL, 0x2252)
		{
		}

		public BookOfChivalry(Serial serial) 
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