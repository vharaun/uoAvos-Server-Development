using Server.Items;

namespace Server.Engines.ChainQuests.Items
{
	public class HallowedSpellbook : BookOfMagery
	{
		public override int LabelNumber => 1077620;  // Hallowed Spellbook

		[Constructable]
		public HallowedSpellbook() : base(0x3FFFFFFFFUL)
		{
			LootType = LootType.Blessed;

			Slayer = SlayerName.Silver;
		}

		public HallowedSpellbook(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}