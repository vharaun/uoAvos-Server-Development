using Server.Engines.Publishing;

namespace Server.Items
{
	public class BirdsOfBritannia : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Birds of Britannia", "Thom the Heathen",
				new BookPageInfo
				(
					"   The WREN is a",
					"tiny insect-eating",
					"bird with a loud voice.",
					" The cheerful trills",
					"of Wrens are",
					"extraordinarily",
					"varied and melodious.",
					"    The SWALLOW"
				),
				new BookPageInfo
				(
					"is easily recognized",
					"by its forked tail.",
					"Swallows catch",
					"insects in flight, and",
					"have squeaky,",
					"twittering songs.",
					"    The WARBLER is",
					"an exceptional singer,"
				),
				new BookPageInfo
				(
					"whose extensive",
					"songs combine the",
					"best qualities of",
					"Wrens and Swallows.",
					"    The NUTHATCH",
					"climbs down trees",
					"head first, searching",
					"for insects in the"
				),
				new BookPageInfo
				(
					"bark.  It sings a",
					"repetitive series of",
					"notes with a nasal",
					"tone quality.",
					"    The agile",
					"CHICKADEE has a",
					"buzzy",
					"\"chick-a-dee-dee\""
				),
				new BookPageInfo
				(
					"call, from which its",
					"name is derived.  Its",
					"song is a series of",
					"whistled notes.",
					"    The THRUSH is a",
					"brown bird with a",
					"spotted breast, which",
					"eats worms and"
				),
				new BookPageInfo
				(
					"snails, and has a",
					"beautiful singing",
					"voice.  Thrushes use",
					"a stone as an anvil to",
					"smash the shells of",
					"snails.",
					"    The little",
					"NIGHTINGALE is"
				),
				new BookPageInfo
				(
					"also known for its",
					"beautiful song, which",
					"it sings even at night.",
					"    The STARLING",
					"is a small dark bird",
					"with a yellow bill and",
					"a squeaky,",
					"high-pitched song."
				),
				new BookPageInfo
				(
					"Starlings can mimic",
					"the sounds of other",
					"birds.",
					"    The SKYLARK",
					"sings a series of",
					"high-pitched",
					"melodious trills in",
					"flight."
				),
				new BookPageInfo
				(
					"    The FINCH is a",
					"small seed-eating bird",
					"with a conical beak",
					"and a musical,",
					"warbling song.",
					"    The CROSSBILL",
					"is a kind of Finch",
					"with a strange"
				),
				new BookPageInfo
				(
					"crossed bill, which it",
					"uses to extract seeds",
					"from pine cones.",
					"    The CANARY is a",
					"kind of Finch that is",
					"often kept as a pet.",
					"Miners would often",
					"take Canaries"
				),
				new BookPageInfo
				(
					"underground with",
					"them, to warn them",
					"of the presence of",
					"hazardous vapors in",
					"the air.",
					"    The SPARROW",
					"weaves a nest of",
					"grass, and has an"
				),
				new BookPageInfo
				(
					"unmusical chirp for a",
					"voice.",
					"    The TOWHEE is a",
					"kind of Sparrow that",
					"continually reminds",
					"listeners to drink",
					"their tea.",
					"    The SHRIKE is a"
				),
				new BookPageInfo
				(
					"gray bird with a",
					"hooked bill.  Shrikes",
					"have the habit of",
					"impaling their prey",
					"on thorns.",
					"    The",
					"WOODPECKER has a",
					"pointed beak that is"
				),
				new BookPageInfo
				(
					"suitable for pecking at",
					"wood to get at the",
					"insects inside.",
					"    The",
					"KINGFISHER dives",
					"for fish, which it",
					"catches with its long,",
					"pointed beak."
				),
				new BookPageInfo
				(
					"    The TERN",
					"migrates over great",
					"distances, from one",
					"end of Britannia to",
					"the other each year.",
					"Terns dive from the",
					"air to catch fish.",
					"    The PLOVER is a"
				),
				new BookPageInfo
				(
					"bird that distracts",
					"predators by",
					"pretending to have a",
					"broken wing.",
					"    The LAPWING is",
					"a kind of Plover that",
					"has a long black crest.",
					"    The HAWK is a"
				),
				new BookPageInfo
				(
					"predator that feeds on",
					"small birds, mice,",
					"squirrels, and other",
					"small animals.  Small",
					"hawks are known as",
					"Kites.",
					"    The DOVE is a",
					"seed-eating bird with"
				),
				new BookPageInfo
				(
					"a peaceful reputation.",
					" Doves have a",
					"low-pitched cooing",
					"song.",
					"    The PARROT is a",
					"brightly colored bird",
					"with a hooked bill,",
					"favored as a"
				),
				new BookPageInfo
				(
					"companion by pirates.",
					" Parrots can be",
					"taught to imitate the",
					"human voice.",
					"    The CUCKOO is a",
					"devious bird that lays",
					"eggs in the nests of",
					"Warblers and other"
				),
				new BookPageInfo
				(
					"small birds.  Cuckoos",
					"have the uncanny",
					"ability to keep track",
					"of time, singing once",
					"at the beginning of",
					"each hour.",
					"    The",
					"ROADRUNNER is"
				),
				new BookPageInfo
				(
					"an unusual bird with",
					"a long tail, which",
					"runs swiftly along",
					"the ground hunting",
					"for lizards and",
					"snakes.",
					"    The SWIFT is a",
					"very agile bird that"
				),
				new BookPageInfo
				(
					"spends nearly its",
					"entire life in the air.",
					"With their mouths",
					"wide open, Swifts",
					"capture insects in",
					"mid-flight.",
					"    The",
					"HUMMINGBIRD is a"
				),
				new BookPageInfo
				(
					"cross between a",
					"Swift and a Fairy.",
					"These tiny, brightly",
					"colored birds hover",
					"magically near",
					"flowers, and live on",
					"the nectar they",
					"provide."
				),
				new BookPageInfo
				(
					"    The OWL is a",
					"reputedly wise bird",
					"that is active at night,",
					"unlike most birds.",
					"Owls have excellent",
					"night vision and",
					"low-pitched hooting",
					"calls.  Their wings"
				),
				new BookPageInfo
				(
					"are silent in flight.",
					"    The",
					"GOATSUCKER is a",
					"strange owl-like bird",
					"that is thought to live",
					"on the milk of goats.",
					"These mysterious",
					"birds make jarring"
				),
				new BookPageInfo
				(
					"sounds at night, for",
					"which reason they",
					"are also called",
					"Nightjars.",
					"    The DUCK is a",
					"bird that swims more",
					"often than it flies,",
					"and has a nasal voice"
				),
				new BookPageInfo
				(
					"that is described as a",
					"\"quack\".",
					"    The SWAN is a",
					"kind of long-necked",
					"Duck that is all white.",
					" Swans are usually",
					"voiceless, but they",
					"are said to have an"
				),
				new BookPageInfo
				(
					"extraordinarily",
					"beautiful song."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public BirdsOfBritannia() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public BirdsOfBritannia(Serial serial) : base(serial)
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