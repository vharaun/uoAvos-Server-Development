
namespace Server.Items
{
	public class LightningBowScroll : SpellScroll
	{
		[Constructable]
		public LightningBowScroll() : this(1)
		{
		}

		[Constructable]
		public LightningBowScroll(int amount) : base(SpellName.LightningBow, 0x1F6D, amount)
		{
			Hue = 0x9F6;
		}

		public LightningBowScroll(Serial serial) : base(serial)
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
