namespace Server.Items
{
	public class GiftOfRenewalScroll : SpellScroll
	{
		[Constructable]
		public GiftOfRenewalScroll()
			: this(1)
		{
		}

		[Constructable]
		public GiftOfRenewalScroll(int amount) : base(SpellName.GiftOfRenewal, 0x2D52, amount)
		{
		}

		public GiftOfRenewalScroll(Serial serial)
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