namespace Server.Items
{
	public class AttunementScroll : SpellScroll
	{
		[Constructable]
		public AttunementScroll()
			: this(1)
		{
		}

		[Constructable]
		public AttunementScroll(int amount) : base(SpellName.Attunement, 0x2D54, amount)
		{
		}

		public AttunementScroll(Serial serial)
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