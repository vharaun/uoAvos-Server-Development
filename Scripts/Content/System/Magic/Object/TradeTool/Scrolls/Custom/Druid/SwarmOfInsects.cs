
namespace Server.Items
{
	public class SwarmOfInsectsScroll : SpellScroll
	{
		[Constructable]
		public SwarmOfInsectsScroll() : this(1)
		{
		}

		[Constructable]
		public SwarmOfInsectsScroll(int amount) : base(SpellName.SwarmOfInsects, 0x1F6D, amount)
		{
		}

		public SwarmOfInsectsScroll(Serial serial) : base(serial)
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
