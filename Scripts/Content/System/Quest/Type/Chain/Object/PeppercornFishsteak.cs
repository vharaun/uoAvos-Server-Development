using Server.Items;

namespace Server.Items
{
	public class PeppercornFishsteak : SaltwaterFishSteak
	{
		public override int LabelNumber => 1075557;  // peppercorn fishsteak

		[Constructable]
		public PeppercornFishsteak() : base()
		{
			Hue = 0x222;
		}

		public PeppercornFishsteak(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // Version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}