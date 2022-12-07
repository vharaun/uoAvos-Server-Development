namespace Server.Items
{
	public class ArcaneEmpowermentScroll : SpellScroll
	{
		[Constructable]
		public ArcaneEmpowermentScroll()
			: this(1)
		{
		}

		[Constructable]
		public ArcaneEmpowermentScroll(int amount) : base(SpellName.ArcaneEmpowerment, 0x2D60, amount)
		{
		}

		public ArcaneEmpowermentScroll(Serial serial)
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