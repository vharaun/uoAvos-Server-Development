
namespace Server.Items
{
	public class NaturesPassageScroll : SpellScroll
	{
		[Constructable]
		public NaturesPassageScroll() : this(1)
		{
		}

		[Constructable]
		public NaturesPassageScroll(int amount) : base(SpellName.NaturesPassage, 0x1F6D, amount)
		{
		}

		public NaturesPassageScroll(Serial serial) : base(serial)
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
