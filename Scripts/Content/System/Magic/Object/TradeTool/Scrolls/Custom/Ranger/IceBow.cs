
namespace Server.Items
{
	public class IceBowScroll : SpellScroll
	{
		[Constructable]
		public IceBowScroll() : this(1)
		{
		}

		[Constructable]
		public IceBowScroll(int amount) : base(SpellName.IceBow, 0x1F6D, amount)
		{
		}

		public IceBowScroll(Serial serial) : base(serial)
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
