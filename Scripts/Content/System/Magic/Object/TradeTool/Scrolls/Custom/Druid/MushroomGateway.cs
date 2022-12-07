
namespace Server.Items
{
	public class MushroomGatewayScroll : SpellScroll
	{
		[Constructable]
		public MushroomGatewayScroll() : this(1)
		{
		}

		[Constructable]
		public MushroomGatewayScroll(int amount) : base(SpellName.MushroomGateway, 0x1F6D, amount)
		{
		}

		public MushroomGatewayScroll(Serial serial) : base(serial)
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
