using Server.Engines.Publishing;

namespace Server.Items
{
	public class VirtueBook : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Virtue", "Lord British",
				new BookPageInfo
				(
					"  Within this world",
					"live people with many",
					"different ideals, and",
					"this is good. Yet what",
					"is it within the people",
					"of our land that sorts",
					"out the good from the",
					"evil, the cherished"
				),
				new BookPageInfo
				(
					"form the disdained?",
					"Virtue, I say it is,",
					"and virtue is the",
					"logical outcome of a",
					"people who wish to",
					"live together in a",
					"bonded society.",
					"  For without Virtues"
				),
				new BookPageInfo
				(
					"as a code of conduct",
					"which people maintain",
					"in their relations",
					"with each other, the",
					"fabric of that society",
					"will become weakened.",
					"For a society to grow",
					"and prosper for all,"
				),
				new BookPageInfo
				(
					"each must grant the",
					"others a common base",
					"of consideration.",
					"  I call this base the",
					"Virtues. For though",
					"one person might gain",
					"personal advantage by",
					"breaching such a"
				),
				new BookPageInfo
				(
					"code, the society as a",
					"whole would suffer.",
					"  There are three",
					"Principle Virtues that",
					"should guide people to",
					"enlightenment. These",
					"are: Truth, Love and",
					"Courage. From all the"
				),
				new BookPageInfo
				(
					"infinite reasons one",
					"may have to found an",
					"action, such as greed",
					"or charity, envy or",
					"pity, the three",
					"Principle Virtues",
					"stand out.",
					"  In fact all other"
				),
				new BookPageInfo
				(
					"virtues and vices can",
					"be show to be built",
					"from these principles",
					"and their opposite",
					"corruption's of",
					"Falsehood, Hatred and",
					"Cowardice. These",
					"three Principles can"
				),
				new BookPageInfo
				(
					"be combined in eight",
					"ways, which I will",
					"call the eight virtues.",
					"The eight virtues",
					"which we should",
					"build our society upon",
					"follow.",
					" Truth alone becomes"
				),
				new BookPageInfo
				(
					"Honesty, for without",
					"honesty between our",
					"people, how can we",
					"build the trust which",
					"is needed to",
					"maximize our",
					"successes.",
					" Love alone becomes"
				),
				new BookPageInfo
				(
					"compassion, for at",
					"some time or another",
					"all of us will need the",
					"compassion of others,",
					"and most likely",
					"compassion will be",
					"shown to those who",
					"have shown it."
				),
				new BookPageInfo
				(
					" Courage alone",
					"becomes Valor,",
					"without valor our",
					"people will never",
					"reach into the",
					"unknown or to the",
					"risky and will never",
					"achieve."
				),
				new BookPageInfo
				(
					" Truth tempered by",
					"Love give us Justice,",
					"for only in a loving",
					"search for the truth",
					"can one dispense fair",
					"Justice, rather than",
					"create a cold and",
					"callous people."
				),
				new BookPageInfo
				(
					" Love and Courage",
					"give us Sacrifice, for",
					"a people who love each",
					"other will be willing",
					"to make personal",
					"sacrifices to help",
					"other in need, which",
					"one day, may be"
				),
				new BookPageInfo
				(
					"needed in return.",
					" Courage and Truth",
					"give us Honor, great",
					"knights know this",
					"well, that chivalric",
					"honor can be found",
					"by adhering to this",
					"code of conduct."
				),
				new BookPageInfo
				(
					" Combining Truth,",
					"Love and Courage",
					"suggest the virtue of",
					"Spirituality the virtue",
					"that causes one to be",
					"introspective, to",
					"wonder about ones",
					"place in this world"
				),
				new BookPageInfo
				(
					"and whether one's",
					"deeds will be recorded",
					"as a gift to the world",
					"or a plague.",
					" The final Virtue is",
					"more complicated. For",
					"the eighth combination",
					"is that devoid of"
				),
				new BookPageInfo
				(
					"Truth, Love or",
					"Courage which can",
					"only exist in a state",
					"of great Pride, which",
					"of course is not a",
					"virtue at all. Perhaps",
					"this trick of fate is a",
					"test to see if one can"
				),
				new BookPageInfo
				(
					"realize that the true",
					"virtue is that of",
					"Humility. I feel that",
					"the people of",
					"Magincia fail to see",
					"this to such a degree",
					"that I would not be",
					"surprised if some ill"
				),
				new BookPageInfo
				(
					"fate awaited their",
					"future.",
					" Thus from the",
					"infinite possibilities",
					"which spawned the",
					"Three Principles of",
					"Truth, Love and",
					"Courage, come the"
				),
				new BookPageInfo
				(
					"Eight Virtues of",
					"Honesty, Compassion,",
					"Valor, Justice,",
					"Sacrifice, Honor,",
					"Spirituality, and",
					"Humility."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public VirtueBook() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public VirtueBook(Serial serial) : base(serial)
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