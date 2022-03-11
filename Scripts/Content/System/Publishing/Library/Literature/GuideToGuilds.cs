using Server.Engines.Publishing;

namespace Server.Items
{
	public class GuideToGuilds : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Beltran's Guide to Guilds", "Beltran",
				new BookPageInfo
				(
					"  This reference",
					"work is intended",
					"merely to serve as",
					"resource for those",
					"curious as to the full",
					"range of trades and",
					"societies extant in",
					"Britannia and nearby"
				),
				new BookPageInfo
				(
					"nations. For each",
					"trade or guild, their",
					"blazon is given.",
					"",
					"  Armourer's Guild.",
					"Gold bar above black",
					"bar."
				),
				new BookPageInfo
				(
					"  Association of",
					"Warriors. Blue cross",
					"on a red field.",
					"",
					"  Barters' Guild.",
					"Green and white",
					"stripes, diagonal."
				),
				new BookPageInfo
				(
					"  Blacksmith's Guild.",
					"Gold alongside black.",
					"",
					"  Federation of",
					"Rogues and Beggars.",
					"Red above black.",
					"",
					"  Fighters and"
				),
				new BookPageInfo
				(
					"Footmen. Blue",
					"horzontal bar on red",
					"field.",
					"",
					"  Guild of Archers.",
					"A gold swath parting",
					"red and blue."
				),
				new BookPageInfo
				(
					"  Guild of",
					"Armaments. Swath of",
					"gold on black field,",
					"gold accents.",
					"",
					"  Guild of Assassins.",
					"Black and red",
					"quartered."
				),
				new BookPageInfo
				(
					"",
					"  Guild of Barbers.",
					"Red and white",
					"stripes.",
					"",
					"  Guild of Cavalry and",
					"Horse. Vertical blue",
					"on a red field."
				),
				new BookPageInfo
				(
					"",
					"  Guild of",
					"Fishermen. Blue and",
					"white, quartered.",
					"",
					"  Guild of Mages.",
					"Purple and blue, in a",
					"crossed pennant"
				),
				new BookPageInfo
				(
					"pattern.",
					"",
					"  Guild of",
					"Provisioners. White",
					"bar above green bar.",
					"",
					"  Guild of Sorcery. A",
					"field divided"
				),
				new BookPageInfo
				(
					"diagonally in blue and",
					"purple.",
					"",
					"  Healers Guild. Gold",
					"swath dividing green",
					"from purple, gold",
					"accents."
				),
				new BookPageInfo
				(
					"  Lord British's",
					"Healers of Virtue.",
					"Golden ankh on dark",
					"green.",
					"",
					"  Masters of Illusion.",
					"Blue and purple",
					"checkers."
				),
				new BookPageInfo
				(
					"",
					"  Merchants' Guild.",
					"Gold coins on green",
					"field.",
					"",
					"  Mining Cooperative.",
					"A gold cross,",
					"quartering blue and"
				),
				new BookPageInfo
				(
					"black.",
					"",
					"  Order of Engineers.",
					"Purple, gold, and blue",
					"vertical.",
					"",
					"  Sailors' Maritime",
					"Association. A white"
				),
				new BookPageInfo
				(
					"bar centered on a blue",
					"field.",
					"",
					"  Seamen's Chapter.",
					"Blue and white in a",
					"crossed pennant",
					"pattern."
				),
				new BookPageInfo
				(
					"  Society of Cooks and",
					"Chefs. White and red",
					"diagonal fields",
					"checker on green",
					"field.",
					"",
					"  Society of",
					"Shipwrights. White"
				),
				new BookPageInfo
				(
					"diagonal above blue.",
					"",
					"  Society of Thieves.",
					"Black and red diagonal",
					"stripes.",
					"",
					"  Society of",
					"Weaponsmakers. Gold"
				),
				new BookPageInfo
				(
					"diagonal above black.",
					"",
					"  Tailor's Hall. Purple",
					"above gold above red.",
					"",
					"  The Bardic",
					"Collegium. Purple and",
					"red checkers on gold"
				),
				new BookPageInfo
				(
					"field.",
					"",
					"  Traders' Guild.",
					"White bar centered",
					"down green field."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public GuideToGuilds() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public GuideToGuilds(Serial serial) : base(serial)
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