
namespace Server.Items
{
	public class DivineLightScroll : SpellScroll
	{
		[Constructable]
		public DivineLightScroll() : this(1)
		{
		}

		[Constructable]
		public DivineLightScroll(int amount) : base(SpellName.DivineLight, 0x1F6D, amount)
		{
		}

		public DivineLightScroll(Serial serial) : base(serial)
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
