using Server.Engines.Publishing;

namespace Server.Items
{
	public class BurningOfTrinsic : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"The Burning of Trinsic", "Japheth of Trinsic",
				new BookPageInfo
				(
					"    'Twas a sight to",
					"see, the sunlight",
					"falling lightly on the",
					"sandstone walls of",
					"Trinsic 'pon a",
					"morning in spring.",
					"    Children ran along",
					"the parapets and"
				),
				new BookPageInfo
				(
					"walkways, their",
					"laughter and running",
					"providing music to the",
					"daybreak, despite",
					"their oft-ragged",
					"clothing.",
					"    And I was one of",
					"those young ones,"
				),
				new BookPageInfo
				(
					"letting my joy rise",
					"up to the skies.",
					"    Little did we all",
					"know of the darker",
					"days that would lie",
					"ahead, for we were",
					"too young.",
					"    Had we but gained"
				),
				new BookPageInfo
				(
					"access to the quiet",
					"councils held in the",
					"Paladin tower as it",
					"faced the sea,",
					"councils lit by",
					"candlelight and",
					"worry, we would",
					"have learned more of"
				),
				new BookPageInfo
				(
					"the fears of",
					"imminent attack from",
					"the forest, where",
					"foul creatures born",
					"of dank caves and",
					"darkness were",
					"marauding ever more",
					"often into the lands"
				),
				new BookPageInfo
				(
					"around Trinsic's",
					"moat.",
					"    But we were",
					"children! The",
					"parapets and the moat",
					"were places to play,",
					"not stout defenses,",
					"and we gave no"
				),
				new BookPageInfo
				(
					"thought to the",
					"necessities that must",
					"have required their",
					"construction.",
					"    We used to reach",
					"the sheltered",
					"orchards on the lee",
					"side of the parapet"
				),
				new BookPageInfo
				(
					"walls, where the",
					"southern river cut",
					"through the city, by",
					"swimming across the",
					"water.",
					"    The rich folk who",
					"lived in the great",
					"manses there would"
				),
				new BookPageInfo
				(
					"shout from their",
					"windows and shake",
					"their fists, for we",
					"would run through",
					"their gardens and",
					"tear up the delicate",
					"foxgloves and",
					"orfleurs with our"
				),
				new BookPageInfo
				(
					"unshod dirty feet.",
					"Then we would dive",
					"into the water and",
					"splash merrily to the",
					"fruit trees.",
					"    The southern",
					"river lazily slid",
					"under the an ungated"
				),
				new BookPageInfo
				(
					"arch in the mighty",
					"wall, and we would",
					"lay on the grassy",
					"bank and watch it",
					"gurgle by the lily",
					"pads.",
					"    That spring that",
					"pleasant spot became"
				),
				new BookPageInfo
				(
					"the doorway through",
					"which our city of",
					"Trinsic let in the",
					"monstrous deformed",
					"humanoids that",
					"savaged us. I lay upon",
					"that grassy bank and",
					"watched them wade"
				),
				new BookPageInfo
				(
					"in, their coarse hair",
					"wet and matted, algae",
					"and muck festooning",
					"their wild brows.",
					"    They caught sight",
					"of a quicksilver girl",
					"with bright blond hair",
					"and lively eyes. Her"
				),
				new BookPageInfo
				(
					"name was Leyla, and",
					"that spring I had held",
					"fond dreams of",
					"holding her hand and",
					"sharing flavored ice",
					"while dangling our",
					"feet off the small",
					"bridge by Smugglers"
				),
				new BookPageInfo
				(
					"Gate.",
					"    And I said nothing",
					"when they caught",
					"her, and did not cry",
					"out when they",
					"dragged her off",
					"through that breach in",
					"our wall, and did not"
				),
				new BookPageInfo
				(
					"warn the city when I",
					"saw the helmeted orc",
					"captains call the",
					"charge upon the",
					"mansions.",
					"    Blame me not, for",
					"I was but a child, and",
					"one who hid in the"
				),
				new BookPageInfo
				(
					"branches of the peach",
					"trees, all a-tremble",
					"whilst I watched the",
					"smoke rise from Sean",
					"the tailor's, and fire",
					"lash out at the roof of",
					"witchy Eleanor's",
					"tavern."
				),
				new BookPageInfo
				(
					"    To this day I have",
					"had no word of",
					"Leyla, and to this",
					"day the smell of",
					"burning wood can",
					"conjure terrible",
					"dreams. Yet with the",
					"eyes of adulthood, 'tis"
				),
				new BookPageInfo
				(
					"possible to examine",
					"the flaws in the",
					"defense of Trinsic on",
					"that fateful day, and",
					"the reasons why our",
					"walls are now",
					"double-thick, and",
					"why our buildings"
				),
				new BookPageInfo
				(
					"are now built as",
					"fortresses within a",
					"somber fortified city.",
					"    While I can look",
					"out from the top of",
					"the new Paladin",
					"tower, and spy the",
					"mighty white sails"
				),
				new BookPageInfo
				(
					"across the barrier",
					"island, and can",
					"descry the small",
					"hollow south of the",
					"city where gypsies",
					"are wont to camp, I",
					"can also envision the",
					"city as it might be"
				),
				new BookPageInfo
				(
					"burning, and I bless",
					"the bargain we made:",
					"space for safety,",
					"grace for sturdiness,",
					"and wood for stone.",
					"    Whilst I live, I",
					"shall not see Trinsic",
					"burn, and no more"
				),
				new BookPageInfo
				(
					"cries of little girls",
					"will haunt the sleep",
					"of our fair citizens.",
					"    - Japheth, Paladin",
					"Guildmaster of the",
					"City of Trinsic"
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public BurningOfTrinsic() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public BurningOfTrinsic(Serial serial) : base(serial)
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