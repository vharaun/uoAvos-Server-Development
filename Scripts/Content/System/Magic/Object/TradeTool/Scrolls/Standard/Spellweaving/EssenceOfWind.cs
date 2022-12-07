namespace Server.Items
{
	public class EssenceOfWindScroll : SpellScroll
	{
		[Constructable]
		public EssenceOfWindScroll()
			: this(1)
		{
		}

		[Constructable]
		public EssenceOfWindScroll(int amount) : base(SpellName.EssenceOfWind, 0x2D5B, amount)
		{
		}

		public EssenceOfWindScroll(Serial serial)
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