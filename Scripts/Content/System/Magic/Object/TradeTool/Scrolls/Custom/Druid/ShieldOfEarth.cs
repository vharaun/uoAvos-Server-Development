
namespace Server.Items
{
	public class ShieldOfEarthScroll : SpellScroll
	{
		[Constructable]
		public ShieldOfEarthScroll() : this(1)
		{
		}

		[Constructable]
		public ShieldOfEarthScroll(int amount) : base(SpellName.ShieldOfEarth, 0x1F6D, amount)
		{
			Hue = 0x7D1;
		}

		public ShieldOfEarthScroll(Serial serial) : base(serial)
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
