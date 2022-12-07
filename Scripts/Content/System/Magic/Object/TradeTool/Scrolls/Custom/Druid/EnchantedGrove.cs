
namespace Server.Items
{
	public class EnchantedGroveScroll : SpellScroll
	{
		[Constructable]
		public EnchantedGroveScroll() : this(1)
		{
		}

		[Constructable]
		public EnchantedGroveScroll(int amount) : base(SpellName.EnchantedGrove, 0x1F6D, amount)
		{
		}

		public EnchantedGroveScroll(Serial serial) : base(serial)
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
