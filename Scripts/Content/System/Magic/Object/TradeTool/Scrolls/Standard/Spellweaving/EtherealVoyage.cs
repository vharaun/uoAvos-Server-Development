namespace Server.Items
{
	public class EtherealVoyageScroll : SpellScroll
	{
		[Constructable]
		public EtherealVoyageScroll()
			: this(1)
		{
		}

		[Constructable]
		public EtherealVoyageScroll(int amount) : base(SpellName.EtherealVoyage, 0x2D5D, amount)
		{
		}

		public EtherealVoyageScroll(Serial serial)
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