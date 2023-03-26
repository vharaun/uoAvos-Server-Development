
namespace Server.Items
{
	public class ShadowBlendScroll : SpellScroll
	{
		[Constructable]
		public ShadowBlendScroll() : this(1)
		{
		}

		[Constructable]
		public ShadowBlendScroll(int amount) : base(SpellName.ShadowBlend, 0x1F6D, amount)
		{
		}

		public ShadowBlendScroll(Serial serial) : base(serial)
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
