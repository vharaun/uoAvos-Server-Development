namespace Server.Items
{
	public class ArcaneCircleScroll : SpellScroll
	{
		[Constructable]
		public ArcaneCircleScroll()
			: this(1)
		{
		}

		[Constructable]
		public ArcaneCircleScroll(int amount) : base(SpellName.ArcaneCircle, 0x2D51, amount)
		{
		}

		public ArcaneCircleScroll(Serial serial)
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