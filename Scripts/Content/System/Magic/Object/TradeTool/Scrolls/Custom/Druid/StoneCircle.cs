
namespace Server.Items
{
	public class StoneCircleScroll : SpellScroll
	{
		[Constructable]
		public StoneCircleScroll() : this(1)
		{
		}

		[Constructable]
		public StoneCircleScroll(int amount) : base(SpellName.StoneCircle, 0x1F6D, amount)
		{
		}

		public StoneCircleScroll(Serial serial) : base(serial)
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
