using Server.Engines.Publishing;

namespace Server.Items
{
	public class ChildrenTalesVol2 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Classic Children's Tales, Volume 2", "Guilhem, Editor",
				new BookPageInfo
				(
					"Clarke's Printery",
					"is Honored to",
					"Present Tales from",
					"Ages Past!",
					"    Guilhem the",
					"Scholar Shall End",
					"EachVolume with",
					"Staid Commentary."
				),
				new BookPageInfo
				(
					"",
					"THE RHYME",
					"Dance in the Star",
					"Chamber",
					"And Dance in the Pit",
					"And Eat of your",
					"Entrees",
					"In the Glass House"
				),
				new BookPageInfo
				(
					"you Sit",
					"",
					"COMMENTARY",
					"    A common feeding",
					"rhyme for little",
					"babies, 'tis thought",
					"that this little ditty is",
					"part of the corpus of"
				),
				new BookPageInfo
				(
					"legendary tales",
					"regarding the world",
					"before Sosaria (see",
					"the wonderful fables",
					"of Fabio the Poor for",
					"fictionalized versions",
					"of these stories, also",
					"available from this"
				),
				new BookPageInfo
				(
					"same publisher).",
					"    According to these",
					"old tales, which",
					"survive mostly in the",
					"hills and remote",
					"villages where Lord",
					"British is as yet a",
					"distant and mythical"
				),
				new BookPageInfo
				(
					"ruler, the gods of old",
					"(a fanciful notion!)",
					"met to discuss the",
					"progress of creating",
					"the world in mystical",
					"rooms. A simple",
					"analysis reveals these",
					"rooms to be mere"
				),
				new BookPageInfo
				(
					"mythological",
					"generalizations.",
					"    \"The Star",
					"Chamber\" is clearly a",
					"reference to the sky.",
					"\"The Pit\" is certainly",
					"an Underworld",
					"analogous to the"
				),
				new BookPageInfo
				(
					"Snakehills of other",
					"tales, and \"the Glass",
					"House\" is no doubt the",
					"vantage point from",
					"which the gods",
					"observed their",
					"creation. All is simple",
					"when seen from this"
				),
				new BookPageInfo
				(
					"perspective, leaving",
					"only the mysterious",
					"reference to dinners.",
					"Oddly enough, the",
					"rhyme is universally",
					"used only for",
					"midnight feedings,",
					"never during the day."
				),
				new BookPageInfo
				(
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public ChildrenTalesVol2() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public ChildrenTalesVol2(Serial serial) : base(serial)
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