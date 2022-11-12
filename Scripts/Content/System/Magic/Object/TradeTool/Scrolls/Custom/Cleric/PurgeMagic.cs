
namespace Server.Items
{
	public class PurgeMagicScroll : SpellScroll
	{
		[Constructable]
		public PurgeMagicScroll() : this(1)
		{
		}

		[Constructable]
		public PurgeMagicScroll(int amount) : base(SpellName.PurgeMagic, 0x1F6D, amount)
		{
			Hue = 0xAA8;
		}

		public PurgeMagicScroll(Serial serial) : base(serial)
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
