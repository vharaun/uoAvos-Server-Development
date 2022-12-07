
namespace Server.Items
{
	public class HammerOfFaithScroll : SpellScroll
	{
		[Constructable]
		public HammerOfFaithScroll() : this(1)
		{
		}

		[Constructable]
		public HammerOfFaithScroll(int amount) : base(SpellName.HammerOfFaith, 0x1F6D, amount)
		{
		}

		public HammerOfFaithScroll(Serial serial) : base(serial)
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
