using Server.Items;

namespace Server.Items
{
	public class GustarShroud : BaseOuterTorso
	{
		public override string DefaultName => " ";
		[Constructable]
		public GustarShroud() : base(0x2684)
		{
			Hue = 0x479;
		}

		public GustarShroud(Serial serial) : base(serial)
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