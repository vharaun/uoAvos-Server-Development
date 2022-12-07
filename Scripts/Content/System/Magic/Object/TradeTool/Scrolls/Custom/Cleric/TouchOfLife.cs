
namespace Server.Items
{
	public class TouchOfLifeScroll : SpellScroll
	{
		[Constructable]
		public TouchOfLifeScroll() : this(1)
		{
		}

		[Constructable]
		public TouchOfLifeScroll(int amount) : base(SpellName.TouchOfLife, 0x1F6D, amount)
		{
		}

		public TouchOfLifeScroll(Serial serial) : base(serial)
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
