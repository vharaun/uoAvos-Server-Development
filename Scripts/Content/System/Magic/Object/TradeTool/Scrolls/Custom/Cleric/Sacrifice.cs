
namespace Server.Items
{
	public class SacrificeScroll : SpellScroll
	{
		[Constructable]
		public SacrificeScroll() : this(1)
		{
		}

		[Constructable]
		public SacrificeScroll(int amount) : base(SpellName.Sacrifice, 0x1F6D, amount)
		{
		}

		public SacrificeScroll(Serial serial) : base(serial)
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
