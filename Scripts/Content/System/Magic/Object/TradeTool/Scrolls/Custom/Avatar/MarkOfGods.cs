
namespace Server.Items
{
	public class MarkOfGodsScroll : SpellScroll
	{
		[Constructable]
		public MarkOfGodsScroll() : this(1)
		{
		}

		[Constructable]
		public MarkOfGodsScroll(int amount) : base(SpellName.MarkOfGods, 0x1F6D, amount)
		{
		}

		public MarkOfGodsScroll(Serial serial) : base(serial)
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
