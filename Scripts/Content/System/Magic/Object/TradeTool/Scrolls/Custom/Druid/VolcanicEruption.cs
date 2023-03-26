
namespace Server.Items
{
	public class VolcanicEruptionScroll : SpellScroll
	{
		[Constructable]
		public VolcanicEruptionScroll() : this(1)
		{
		}

		[Constructable]
		public VolcanicEruptionScroll(int amount) : base(SpellName.VolcanicEruption, 0x1F6D, amount)
		{
		}

		public VolcanicEruptionScroll(Serial serial) : base(serial)
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
