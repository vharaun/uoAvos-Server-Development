using Server.Engines.Publishing;

namespace Server.Items
{
	public class RankingsOfTrades : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"The Rankings of Trades", "Lord Higginbotham",
				new BookPageInfo
				(
					"  Whilst 'tis true that",
					"within each trade, one",
					"finds differing titles",
					"and accolades granted",
					"to the members of a",
					"given guild,",
					"nonetheless for the",
					"betterment of trade"
				),
				new BookPageInfo
				(
					"and understanding,",
					"we must have a",
					"commonality of",
					"titling.",
					"  For those who may",
					"find themselves",
					"ignorant of the finer",
					"distinctions between a"
				),
				new BookPageInfo
				(
					"three-knot member of",
					"the Sailors' Maritime",
					"Association and a",
					"second thaumaturge,",
					"this book shall serve",
					"as a simple",
					"introduction to the",
					"common cant used"
				),
				new BookPageInfo
				(
					"when members of",
					"differing guilds and",
					"trade organizations",
					"must trade with each",
					"other and must",
					"establish relative",
					"credentials.",
					"  Neophyte"
				),
				new BookPageInfo
				(
					"Has shown interest",
					"in learning the craft",
					"and some meager",
					"talent.",
					"  Novice",
					"Is practicing basic",
					"skills but has not been",
					"admitted to full"
				),
				new BookPageInfo
				(
					"standing.",
					"  Apprentice",
					"A student of the",
					"discipline.",
					"  Journeyman",
					"Warranted to practice",
					"the discipline under",
					"the eyes of a tutor."
				),
				new BookPageInfo
				(
					"  Expert",
					"A full member of the",
					"guild.",
					"  Adept",
					"A member of the",
					"guild qualified to",
					"teach others.",
					"  Master"
				),
				new BookPageInfo
				(
					"Acknowledged as",
					"qualified to lead a hall",
					"or business.",
					"  Grandmaster",
					"Rarely a permanent",
					"title, granted in",
					"common parlance to",
					"those who have"
				),
				new BookPageInfo
				(
					"shown extreme",
					"mastery of their",
					"craft recently."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public RankingsOfTrades() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public RankingsOfTrades(Serial serial) : base(serial)
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