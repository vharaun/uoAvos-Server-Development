using Server.Engines.Publishing;

namespace Server.Items
{
	public class BritannianFlora : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Britannian Flora: A Casual Guide", "Herbert the Lost",
				new BookPageInfo
				(
					"  Oft 'pon rambling",
					"through the woods",
					"avoiding bears have I",
					"spotted some plant",
					"whose like I have",
					"never seen before,",
					"and concluded that I",
					"was a blithering idiot"
				),
				new BookPageInfo
				(
					"for failing to notice it",
					"in the past. Equally",
					"as oft have I",
					"concluded that I was a",
					"worse idiot for not",
					"running faster from",
					"the bear.",
					"  While not all my"
				),
				new BookPageInfo
				(
					"readers may share",
					"my proclivities for",
					"tree-climbing, it",
					"occurred to me that",
					"mayhap mine",
					"information might",
					"serve some humble",
					"purpose."
				),
				new BookPageInfo
				(
					"  The two most",
					"unique flowering",
					"plants in the",
					"Britannian",
					"countryside are the",
					"orfleur and the",
					"whiteflower, also",
					"called white horns."
				),
				new BookPageInfo
				(
					"  The orfleur is",
					"notable for its",
					"massive orange-red",
					"blossoms, which",
					"dwarf marigolds like",
					"the sun dwarfs your",
					"common fireball spell.",
					"The odor of said"
				),
				new BookPageInfo
				(
					"blooms is best",
					"described as",
					"peppermint-apple,",
					"with a dash of garlic.",
					"'Tis a popular potted",
					"plant despite, or",
					"perhaps because of,",
					"its exotic nature."
				),
				new BookPageInfo
				(
					"  Whiteflowers exude",
					"a subtle fragrance not",
					"unlike that of freshly",
					"shaven wood mixed",
					"with cool lemon ice.",
					"Their tall stands",
					"always droop with the",
					"heavy weight of the"
				),
				new BookPageInfo
				(
					"massive blooms, oft",
					"as large as a child's",
					"head.",
					"  The flowers are so",
					"large that one may",
					"scoop out the pollen in",
					"handfuls, and during",
					"the spring season"
				),
				new BookPageInfo
				(
					"many a prank hath",
					"been played by idle",
					"boys 'pon their",
					"sisters by dumping",
					"said pollen into their",
					"clothing drawers,",
					"causing sneezes for",
					"days."
				),
				new BookPageInfo
				(
					"  The most",
					"interesting native tree",
					"to Britannia is the",
					"spider tree. The",
					"reason for its naming",
					"is obscure, but may",
					"have to do with the",
					"twisted gray stalks"
				),
				new BookPageInfo
				(
					"from which the",
					"spherical canopy",
					"sprouts. 'Tis",
					"something of a",
					"misnomer to term",
					"these \"trunks\" as",
					"they are spindly and",
					"flexible. Spider trees"
				),
				new BookPageInfo
				(
					"provide a fresh,",
					"piney smell to a room",
					"and are therefore",
					"often potted.",
					"  In jungle climes,",
					"one finds the blade",
					"plant, whose sharp",
					"leaves oft collect"
				),
				new BookPageInfo
				(
					"water for the thirsty",
					"traveler, yet can",
					"draw blood easily.",
					"  The deadliest plant,",
					"if you can call a",
					"fungus such, is the",
					"Exploding Red Spotted",
					"Toadstool. No pattern"
				),
				new BookPageInfo
				(
					"can be discerned to",
					"its habitats save",
					"malice, for merely",
					"approaching results in",
					"the cap exploding",
					"with powder, noxious",
					"gas, and tiny painful",
					"pellets flying in all"
				),
				new BookPageInfo
				(
					"directions.",
					"Unfortunately, 'tis",
					"impossible to tell it",
					"apart from the",
					"Ordinary Red Spotted",
					"Toadstool save through",
					"experimentation.",
					"  Truly odd among the"
				),
				new BookPageInfo
				(
					"varied flora of",
					"Britannia, however,",
					"are those which bear",
					"names clearly alien to",
					"our tongue. Among",
					"these I name the",
					"Tuscany pine (for I",
					"have never seen a"
				),
				new BookPageInfo
				(
					"region of this world",
					"named Tuscany), the",
					"o'hii tree, whose very",
					"name sounds like",
					"some tropical isle, and",
					"the welsh poppy,",
					"which while",
					"different from the"
				),
				new BookPageInfo
				(
					"ordinary poppy in",
					"color and appearance,",
					"is prefaced with the",
					"odd word \"welsh,\"",
					"which as far as I",
					"know means to forgo",
					"paying a debt."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public BritannianFlora() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public BritannianFlora(Serial serial) : base(serial)
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