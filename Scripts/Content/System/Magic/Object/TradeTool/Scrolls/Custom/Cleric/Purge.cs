
namespace Server.Items
{
	public class PurgeScroll : SpellScroll
	{
		[Constructable]
		public PurgeScroll() : this(1)
		{
		}

		[Constructable]
		public PurgeScroll(int amount) : base(SpellName.Purge, 0x1F6D, amount)
		{
		}

		public PurgeScroll(Serial serial) : base(serial)
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
