
namespace Server.Items
{
	public class BeastPackScroll : SpellScroll
	{
		[Constructable]
		public BeastPackScroll() : this(1)
		{
		}

		[Constructable]
		public BeastPackScroll(int amount) : base(SpellName.BeastPack, 0x1F6D, amount)
		{
		}

		public BeastPackScroll(Serial serial) : base(serial)
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
