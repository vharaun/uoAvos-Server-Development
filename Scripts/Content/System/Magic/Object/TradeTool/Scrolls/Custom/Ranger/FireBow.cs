
namespace Server.Items
{
	public class FireBowScroll : SpellScroll
	{
		[Constructable]
		public FireBowScroll() : this(1)
		{
		}

		[Constructable]
		public FireBowScroll(int amount) : base(SpellName.FireBow, 0x1F6D, amount)
		{
		}

		public FireBowScroll(Serial serial) : base(serial)
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
