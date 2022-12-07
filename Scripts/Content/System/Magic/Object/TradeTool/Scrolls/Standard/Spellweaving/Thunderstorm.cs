namespace Server.Items
{
	public class ThunderstormScroll : SpellScroll
	{
		[Constructable]
		public ThunderstormScroll()
			: this(1)
		{
		}

		[Constructable]
		public ThunderstormScroll(int amount) : base(SpellName.Thunderstorm, 0x2D55, amount)
		{
		}

		public ThunderstormScroll(Serial serial)
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