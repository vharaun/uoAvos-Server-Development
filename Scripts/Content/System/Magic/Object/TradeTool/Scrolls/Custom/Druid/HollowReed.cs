
namespace Server.Items
{
	public class HollowReedScroll : SpellScroll
	{
		[Constructable]
		public HollowReedScroll() : this(1)
		{
		}

		[Constructable]
		public HollowReedScroll(int amount) : base(SpellName.HollowReed, 0x1F6D, amount)
		{
		}

		public HollowReedScroll(Serial serial) : base(serial)
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
