namespace Server.Engines.Stealables
{
	public class PlayingCards : Item
	{

		[Constructable]
		public PlayingCards() : base(0xFA3)
		{
			Movable = true;
			Stackable = false;
		}

		public PlayingCards(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}