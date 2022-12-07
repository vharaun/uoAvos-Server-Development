
namespace Server.Items
{
	public class AnimalCompanionScroll : SpellScroll
	{
		[Constructable]
		public AnimalCompanionScroll() : this(1)
		{
		}

		[Constructable]
		public AnimalCompanionScroll(int amount) : base(SpellName.AnimalCompanion, 0x1F6D, amount)
		{
		}

		public AnimalCompanionScroll(Serial serial) : base(serial)
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
