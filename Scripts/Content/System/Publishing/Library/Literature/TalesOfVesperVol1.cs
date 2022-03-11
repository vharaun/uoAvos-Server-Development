using Server.Engines.Publishing;

namespace Server.Items
{
	public class TalesOfVesperVol1 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Classic Tales of Vesper, Volume 1", "Clarke's Printery",
				new BookPageInfo
				(
					"'Tis an Honor to",
					"present to Thee these",
					"Tales collected from",
					"Ages Past. In this",
					"Inaugural Volume, we",
					"present this Verse",
					"oft Recited as a",
					"Lullabye for sleepy"
				),
				new BookPageInfo
				(
					"Children.",
					"",
					"Preface",
					"by Guilhem the",
					"Scholar",
					"",
					"  The meaning of this",
					"verse has oft been"
				),
				new BookPageInfo
				(
					"discussed in halls of",
					"scholarly sorts, for",
					"its mysterious",
					"singsongy melody is",
					"oddly disturbing to",
					"adult ears, though",
					"children seem to find",
					"it restful as they"
				),
				new BookPageInfo
				(
					"sleep. Perhaps it is",
					"but the remnant of a",
					"longer ballad once",
					"extant, for there are",
					"internal indications",
					"that it once told a",
					"longer story about",
					"ill-fated lovers, and a"
				),
				new BookPageInfo
				(
					"magical experiment",
					"gone awry. However,",
					"poetic license and the",
					"folk process has",
					"distorted the words",
					"until now the locale of",
					"the tale is no more",
					"than \"in the wind,\""
				),
				new BookPageInfo
				(
					"which while it serves",
					"a pleasingly",
					"metaphorical purpose,",
					"fails to inform the",
					"listener as to any real",
					"locale!",
					"  Another possibility",
					"is that this is some"
				),
				new BookPageInfo
				(
					"form of creation",
					"myth explaining the",
					"genesis of the various",
					"humanoid creatures",
					"that roam the lands of",
					"Britannia. It does not",
					"take a stretch of the",
					"imagination to name"
				),
				new BookPageInfo
				(
					"the middle verse's",
					"\"girl becomes tree\" as",
					"a possible explanation",
					"for the reaper, for in",
					"the area surrounding",
					"Minoc, reapers are",
					"oft referred to among",
					"the lumberjacking"
				),
				new BookPageInfo
				(
					"community as",
					"\"widowmakers.\" That",
					"these creatures are",
					"of arcane origin is",
					"assumed, but the",
					"verse seems to imply",
					"a long ago creator, and",
					"uses the antique"
				),
				new BookPageInfo
				(
					"magickal terminology",
					"of \"plaiting strands",
					"of ether\" that is so",
					"often found in",
					"ancient texts. In",
					"addition, the",
					"reference to",
					"\"snakehills\" may"
				),
				new BookPageInfo
				(
					"profitably be regarded",
					"as a reference to an",
					"actual location, such",
					"as perhaps a local",
					"term for the",
					"Serpent's Spine.",
					"  A commoner",
					"interpretation is that"
				),
				new BookPageInfo
				(
					"like many nursery",
					"rhymes, it is a",
					"simple explanation",
					"for death, wherein",
					"the wind snatches up",
					"boys and girls and",
					"when they sleep in",
					"order to keep the"
				),
				new BookPageInfo
				(
					"balance of the world.",
					"Notable tales have",
					"been written for",
					"children of",
					"adventures in \"the",
					"Snakehills,\" which",
					"are presumed to be an",
					"Afterworld whence"
				),
				new BookPageInfo
				(
					"the spirit lives on. A",
					"grim lullabye, to be",
					"sure, but no worse",
					"than \"lest I die before",
					"I wake\" surely.",
					"  In either case, 'tis",
					"an old favorite,",
					"herein printed for"
				),
				new BookPageInfo
				(
					"the first time for",
					"thy enjoyment and",
					"perusal!",
					"",
					"In the Wind where",
					"the Balance",
					"Is Whispered in",
					"Hallways"
				),
				new BookPageInfo
				(
					"In the Wind where",
					"the Magic",
					"Flows All through the",
					"Night",
					"There live Mages and",
					"Mages",
					"With Robes made of",
					"Whole Days"
				),
				new BookPageInfo
				(
					"Reading Books full of",
					"Doings",
					"Printed on Light",
					"",
					"In the Wind where",
					"the Lovers",
					"Are Crossed under",
					"Shadows"
				),
				new BookPageInfo
				(
					"Where they Meet and",
					"are Parted",
					"By the Orders of",
					"Fate",
					"The Girl becomes",
					"Tree,",
					"And thus becomes",
					"Widow"
				),
				new BookPageInfo
				(
					"The Boy becomes",
					"Earth",
					"And Wanders Till",
					"Late",
					"",
					"In the Wind are the",
					"Monsters",
					"First Born First"
				),
				new BookPageInfo
				(
					"Created",
					"When Chanting and",
					"Ether",
					"Mix Meddling and",
					"Nigh",
					"Fear going to Wind,",
					"Fear Finding its",
					"Plaitings,"
				),
				new BookPageInfo
				(
					"Go Not to the",
					"Snakehills",
					"Lest You Care to Die"
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public TalesOfVesperVol1() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public TalesOfVesperVol1(Serial serial) : base(serial)
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