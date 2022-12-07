namespace Server.Items
{
	public class SummonFiendScroll : SpellScroll
	{
		[Constructable]
		public SummonFiendScroll()
			: this(1)
		{
		}

		[Constructable]
		public SummonFiendScroll(int amount) : base(SpellName.SummonFiend, 0x2D58, amount)
		{
		}

		public SummonFiendScroll(Serial serial)
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