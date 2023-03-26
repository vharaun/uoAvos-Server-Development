
namespace Server.Items
{
	public class NoxBowScroll : SpellScroll
	{
		[Constructable]
		public NoxBowScroll() : this(1)
		{
		}

		[Constructable]
		public NoxBowScroll(int amount) : base(SpellName.NoxBow, 0x1F6D, amount)
		{
		}

		public NoxBowScroll(Serial serial) : base(serial)
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
