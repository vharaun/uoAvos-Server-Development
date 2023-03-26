
namespace Server.Items
{
	public class SpringOfLifeScroll : SpellScroll
	{
		[Constructable]
		public SpringOfLifeScroll() : this(1)
		{
		}

		[Constructable]
		public SpringOfLifeScroll(int amount) : base(SpellName.SpringOfLife, 0x1F6D, amount)
		{
		}

		public SpringOfLifeScroll(Serial serial) : base(serial)
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
