
namespace Server.Items
{
	public class LureStoneScroll : SpellScroll
	{
		[Constructable]
		public LureStoneScroll() : this(1)
		{
		}

		[Constructable]
		public LureStoneScroll(int amount) : base(SpellName.LureStone, 0x1F6D, amount)
		{
		}

		public LureStoneScroll(Serial serial) : base(serial)
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
