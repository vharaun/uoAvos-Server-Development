
namespace Server.Items
{
	public class HuntersAimScroll : SpellScroll
	{
		[Constructable]
		public HuntersAimScroll() : this(1)
		{
		}

		[Constructable]
		public HuntersAimScroll(int amount) : base(SpellName.HuntersAim, 0x1F6D, amount)
		{
		}

		public HuntersAimScroll(Serial serial) : base(serial)
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
