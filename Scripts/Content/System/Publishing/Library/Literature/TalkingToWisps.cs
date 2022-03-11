using Server.Engines.Publishing;

namespace Server.Items
{
	public class TalkingToWisps : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Talking to Wisps", "Yorick ofMoonglow",
				new BookPageInfo
				(
					"This volume was",
					"sponsored by",
					"donations from Lord",
					"Blackthorn, ever a",
					"supporter of",
					"understanding the",
					"other sentient races",
					"of Britannia."
				),
				new BookPageInfo
				(
					"-",
					"  Wisps are the most",
					"intelligent of the",
					"nonhuman races",
					"inhabiting Britannia.",
					"'Tis claimed by the",
					"great sages that",
					"someday we shall be"
				),
				new BookPageInfo
				(
					"able to converse with",
					"them openly in our",
					"native",
					"tongue--indeed, we",
					"must hope that wisps",
					"learn our language,",
					"for it is not possible",
					"for humans to"
				),
				new BookPageInfo
				(
					"pronounce wispish!",
					"  The wispish",
					"language seems to",
					"only contain one",
					"vowel, the letter Y.",
					"However, the letters",
					"W, C, M, and L seem",
					"to be treated"
				),
				new BookPageInfo
				(
					"grammatically as",
					"vowels, and in",
					"addition every letter",
					"is followed by what",
					"sounds to the human",
					"ear like a glottal stop.",
					"It is possible that the",
					"glottal stop is"
				),
				new BookPageInfo
				(
					"considered a vowel as",
					"well.",
					"  Wisps do make use",
					"of what sound to us",
					"like pitch and",
					"emphasis shifts",
					"similar to",
					"exclamations and"
				),
				new BookPageInfo
				(
					"questions.",
					"  The average word is",
					"wispish seems to",
					"consist of three",
					"phonemes and three",
					"glottal stops, plus",
					"possibly a pitch shift.",
					"It often sounds like a"
				),
				new BookPageInfo
				(
					"fire burning or",
					"crackling. Some have",
					"speculated that what",
					"we are analyzing is",
					"in fact nothing more",
					"than the very air",
					"crackling near the",
					"wisp's glow, and not"
				),
				new BookPageInfo
				(
					"language, but this is",
					"of course unlikely."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public TalkingToWisps() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public TalkingToWisps(Serial serial) : base(serial)
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