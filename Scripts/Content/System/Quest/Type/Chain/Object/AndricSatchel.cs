using Server.Items;

namespace Server.Engines.ChainQuests.Items
{
	public class AndricSatchel : Backpack
	{
		[Constructable]
		public AndricSatchel()
		{
			Hue = Utility.RandomBrightHue();
			DropItem(new Feather(10));
			DropItem(new FletcherTools());
		}

		public AndricSatchel(Serial serial)
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