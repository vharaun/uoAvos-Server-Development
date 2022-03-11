using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class BravehornsMate : Hind
	{
		[Constructable]
		public BravehornsMate()
		{
			Name = "bravehorn's mate";
			Tamable = false;
		}

		public BravehornsMate(Serial serial)
			: base(serial)
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