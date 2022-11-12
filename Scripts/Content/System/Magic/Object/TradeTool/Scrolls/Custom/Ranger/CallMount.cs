
namespace Server.Items
{
	public class CallMountScroll : SpellScroll
	{
		[Constructable]
		public CallMountScroll() : this(1)
		{
		}

		[Constructable]
		public CallMountScroll(int amount) : base(SpellName.CallMount, 0x1F6D, amount)
		{
			Hue = 0x9F6;
		}

		public CallMountScroll(Serial serial) : base(serial)
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
