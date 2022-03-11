namespace Server.Items
{
	public class SquirrelFormTalisman : BaseFormTalisman
	{
		public override TalismanForm Form => TalismanForm.Squirrel;

		[Constructable]
		public SquirrelFormTalisman() : base()
		{
		}

		public SquirrelFormTalisman(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); //version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}