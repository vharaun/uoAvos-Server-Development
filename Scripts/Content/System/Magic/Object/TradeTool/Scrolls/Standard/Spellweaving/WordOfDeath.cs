namespace Server.Items
{
	public class WordOfDeathScroll : SpellScroll
	{
		[Constructable]
		public WordOfDeathScroll()
			: this(1)
		{
		}

		[Constructable]
		public WordOfDeathScroll(int amount) : base(SpellName.WordOfDeath, 0x2D5E, amount)
		{
			Hue = 0x8FD;
		}

		public WordOfDeathScroll(Serial serial)
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
}