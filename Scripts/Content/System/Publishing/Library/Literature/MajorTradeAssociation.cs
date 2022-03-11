using Server.Engines.Publishing;

namespace Server.Items
{
	public class MajorTradeAssociation : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"The Major Trade Associations", "Pieter of Vesper",
				new BookPageInfo
				(
					"  There are ten major",
					"trade associations that",
					"operate legitimately in",
					"the lands of Britannia",
					"and among its trading",
					"partners. Many of",
					"these guilds are",
					"divided into local or"
				),
				new BookPageInfo
				(
					"specialty subguilds,",
					"who use the same",
					"colors but vary the",
					"heraldic pattern.",
					"  There are many",
					"lesser trade",
					"associations that have",
					"closed membership,"
				),
				new BookPageInfo
				(
					"and one can join them",
					"only by invitation.",
					"Beltran's Guide to",
					"Guilds is the",
					"definitive text on the",
					"full range of guilds",
					"and other associations",
					"in Britannia, and I"
				),
				new BookPageInfo
				(
					"heartily recommend",
					"it.",
					"  In what follows I",
					"have attempted to",
					"bring together the",
					"known information",
					"regarding these",
					"guilds. I offer thee"
				),
				new BookPageInfo
				(
					"the name, typical",
					"membership, heraldic",
					"colors, known",
					"specialty",
					"organizations within",
					"the larger guild, and",
					"any known",
					"affiliations to other"
				),
				new BookPageInfo
				(
					"guilds, which often",
					"occur because of",
					"trade reasons.",
					"",
					"The Guild of Arcane",
					"Arts",
					"Members: alchemists",
					"and wizards"
				),
				new BookPageInfo
				(
					"Colors: blue and purple",
					"Subguilds: Illusionists,",
					"Mages, Wizards",
					"Affiliations: Healer's",
					"Guild",
					"",
					"The Warrior's Guild",
					"Members:"
				),
				new BookPageInfo
				(
					"mercenaries,",
					"soldiery, guardsmen,",
					"weapons masters,",
					"paladins.",
					"Colors: Blue and red",
					"Subguilds: Cavalry,",
					"Fighters, Warriors",
					"Affiliations: League"
				),
				new BookPageInfo
				(
					"of Rangers",
					"",
					"League of Rangers",
					"Members: rangers,",
					"bowyers, animal",
					"trainers",
					"Colors: Red, gold and",
					"blue"
				),
				new BookPageInfo
				(
					"",
					"Guild of Healers",
					"Members: healers",
					"Colors: Green, gold,",
					"and purple",
					"Affiliations: Guild of",
					"Arcane Arts"
				),
				new BookPageInfo
				(
					"Mining Cooperative",
					"Members: miners",
					"Colors: blue and black",
					"checkers, with a gold",
					"cross",
					"Affiliations: Order of",
					"Engineers"
				),
				new BookPageInfo
				(
					"Merchants'",
					"Association",
					"Members:",
					"innkeepers,",
					"tavernkeepers,",
					"jewelers,",
					"provisioners",
					"Colors: gold coins on a"
				),
				new BookPageInfo
				(
					"green field for",
					"Merchants.  White",
					"and green for the",
					"others.",
					"Subguilds: Barters,",
					"Provisioners,",
					"Traders, Merchants"
				),
				new BookPageInfo
				(
					"Order of Engineers",
					"Members: tinkers and",
					"engineers",
					"Colors: Blue, gold, and",
					"purple vertical bars",
					"Affiliations: Mining",
					"Cooperative"
				),
				new BookPageInfo
				(
					"Society of Clothiers",
					"Members: tailors and",
					"weavers",
					"Colors: Purple, gold,",
					"and red horizontal",
					"bars",
					"",
					"Maritime Guild"
				),
				new BookPageInfo
				(
					"Members: fishermen,",
					"sailors, mapmakers,",
					"shipwrights",
					"Colors: blue and white",
					"Subguilds:",
					"Fishermen, Sailors,",
					"Shipwrights"
				),
				new BookPageInfo
				(
					"Bardic Collegium",
					"Members: bards,",
					"musicians,",
					"storytellers, and other",
					"performers",
					"Colors: Purple, red",
					"and gold checkerboard"
				),
				new BookPageInfo
				(
					"Society of Thieves",
					"Members: beggars,",
					"cutpurses, assassins,",
					"and brigands",
					"Colors: red and black",
					"Subguilds: Rogues",
					"(beggars), Assassins,",
					"Thieves"
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public MajorTradeAssociation() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public MajorTradeAssociation(Serial serial) : base(serial)
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