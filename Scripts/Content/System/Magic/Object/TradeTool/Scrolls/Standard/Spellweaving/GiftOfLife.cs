namespace Server.Items
{
	public class GiftOfLifeScroll : SpellScroll
	{
		[Constructable]
		public GiftOfLifeScroll()
			: this(1)
		{
		}

		[Constructable]
		public GiftOfLifeScroll(int amount) : base(SpellName.GiftOfLife, 0x2D5F, amount)
		{
		}

		public GiftOfLifeScroll(Serial serial)
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