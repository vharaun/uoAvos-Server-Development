
namespace Server.Items
{
	public class BanishEvilScroll : SpellScroll
	{
		[Constructable]
		public BanishEvilScroll() : this(1)
		{
		}

		[Constructable]
		public BanishEvilScroll(int amount) : base(SpellName.BanishEvil, 0x1F6D, amount)
		{
		}

		public BanishEvilScroll(Serial serial) : base(serial)
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
