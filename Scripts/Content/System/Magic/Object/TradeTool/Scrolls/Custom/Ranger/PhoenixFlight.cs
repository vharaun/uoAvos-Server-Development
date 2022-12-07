
namespace Server.Items
{
	public class PhoenixFlightScroll : SpellScroll
	{
		[Constructable]
		public PhoenixFlightScroll() : this(1)
		{
		}

		[Constructable]
		public PhoenixFlightScroll(int amount) : base(SpellName.PhoenixFlight, 0x1F6D, amount)
		{
		}

		public PhoenixFlightScroll(Serial serial) : base(serial)
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
