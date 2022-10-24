namespace Server.Items
{
	public class BookOfNinjitsu : Spellbook
	{
		public override sealed SpellSchool School => SpellSchool.Ninjitsu;

		public override bool FillSpells => true;

		[Constructable]
		public BookOfNinjitsu()
			: base(0UL, 0x23A0)
		{
		}

		public BookOfNinjitsu(Serial serial) 
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