
namespace Server.Items
{
	public class IntimidationScroll : SpellScroll
	{
		[Constructable]
		public IntimidationScroll() : this(1)
		{
		}

		[Constructable]
		public IntimidationScroll(int amount) : base(SpellName.Intimidation, 0x1F6D, amount)
		{
		}

		public IntimidationScroll(Serial serial) : base(serial)
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
