
namespace Server.Items
{
	public class BlendWithForestScroll : SpellScroll
	{
		[Constructable]
		public BlendWithForestScroll() : this(1)
		{
		}

		[Constructable]
		public BlendWithForestScroll(int amount) : base(SpellName.BlendWithForest, 0x1F6D, amount)
		{
		}

		public BlendWithForestScroll(Serial serial) : base(serial)
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
