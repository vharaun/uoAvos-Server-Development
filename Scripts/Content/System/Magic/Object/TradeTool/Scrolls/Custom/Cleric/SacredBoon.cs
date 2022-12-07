
namespace Server.Items
{
	public class SacredBoonScroll : SpellScroll
	{
		[Constructable]
		public SacredBoonScroll() : this(1)
		{
		}

		[Constructable]
		public SacredBoonScroll(int amount) : base(SpellName.SacredBoon, 0x1F6D, amount)
		{
		}

		public SacredBoonScroll(Serial serial) : base(serial)
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
