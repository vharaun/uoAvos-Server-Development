
namespace Server.Items
{
	public class SlyFoxScroll : SpellScroll
	{
		[Constructable]
		public SlyFoxScroll() : this(1)
		{
		}

		[Constructable]
		public SlyFoxScroll(int amount) : base(SpellName.SlyFox, 0x1F6D, amount)
		{
		}

		public SlyFoxScroll(Serial serial) : base(serial)
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
