
namespace Server.Items
{
	public class RestorationScroll : SpellScroll
	{
		[Constructable]
		public RestorationScroll() : this(1)
		{
		}

		[Constructable]
		public RestorationScroll(int amount) : base(SpellName.Restoration, 0x1F6D, amount)
		{
		}

		public RestorationScroll(Serial serial) : base(serial)
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
