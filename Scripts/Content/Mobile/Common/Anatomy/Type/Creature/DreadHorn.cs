namespace Server.Items
{
	#region Heads

	[Flipable(0x3156, 0x3157)]
	public class MangledHeadOfDreadhorn : Item
	{
		public override int LabelNumber => 1072088;  // The Mangled Head of Dread Horn

		[Constructable]
		public MangledHeadOfDreadhorn() : base(0x3156)
		{
		}

		public MangledHeadOfDreadhorn(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}


	[Flipable(0x315A, 0x315B)]
	public class PristineDreadHorn : Item
	{
		[Constructable]
		public PristineDreadHorn()
			: base(0x315A)
		{

		}

		public PristineDreadHorn(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	#endregion
}