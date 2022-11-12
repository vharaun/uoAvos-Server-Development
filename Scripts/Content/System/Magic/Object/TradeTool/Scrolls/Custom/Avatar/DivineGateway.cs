
namespace Server.Items
{
	public class DivineGatewayScroll : SpellScroll
	{
		[Constructable]
		public DivineGatewayScroll() : this(1)
		{
		}

		[Constructable]
		public DivineGatewayScroll(int amount) : base(SpellName.DivineGateway, 0x1F6D, amount)
		{
		}

		public DivineGatewayScroll(Serial serial) : base(serial)
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
