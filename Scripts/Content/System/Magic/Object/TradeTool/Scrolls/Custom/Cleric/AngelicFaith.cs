
namespace Server.Items
{
	public class AngelicFaithScroll : SpellScroll
	{
		[Constructable]
		public AngelicFaithScroll() : this(1)
		{
		}

		[Constructable]
		public AngelicFaithScroll(int amount) : base(SpellName.AngelicFaith, 0x1F6D, amount)
		{
		}

		public AngelicFaithScroll(Serial serial) : base(serial)
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
