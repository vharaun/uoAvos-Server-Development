
namespace Server.Items
{
	public class RestorativeSoilScroll : SpellScroll
	{
		[Constructable]
		public RestorativeSoilScroll() : this(1)
		{
		}

		[Constructable]
		public RestorativeSoilScroll(int amount) : base(SpellName.RestorativeSoil, 0x1F6D, amount)
		{
		}

		public RestorativeSoilScroll(Serial serial) : base(serial)
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
