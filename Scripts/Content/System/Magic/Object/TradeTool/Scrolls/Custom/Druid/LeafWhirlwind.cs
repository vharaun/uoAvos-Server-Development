
namespace Server.Items
{
	public class LeafWhirlwindScroll : SpellScroll
	{
		[Constructable]
		public LeafWhirlwindScroll() : this(1)
		{
		}

		[Constructable]
		public LeafWhirlwindScroll(int amount) : base(SpellName.LeafWhirlwind, 0x1F6D, amount)
		{
		}

		public LeafWhirlwindScroll(Serial serial) : base(serial)
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
