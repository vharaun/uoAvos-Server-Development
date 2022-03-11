using Server.Engines.Publishing;

namespace Server.Items
{
	public class EthicalHedonism : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Ethical Hedonism: An Introduction", "Richard Garriott",
				new BookPageInfo
				(
					"  Societies oft have",
					"common codes of",
					"conduct which it",
					"expects all its people",
					"to abide by. Now,",
					"while 'tis true that",
					"this can offer some",
					"advantages, most of"
				),
				new BookPageInfo
				(
					"the codes I see today",
					"around Britannia have",
					"fatal flaws. Let us",
					"examine them.",
					"  First, there is",
					"Blackthorn's code of",
					"Chaos or basically",
					"Anarchy. Whereas"
				),
				new BookPageInfo
				(
					"this affords the",
					"individual maximum",
					"opportunity for",
					"individuality and even",
					"pursuit of personal",
					"happiness, it does not",
					"offer even basic",
					"interpersonal conduct"
				),
				new BookPageInfo
				(
					"codes to prevent",
					"people from killing",
					"each other.",
					"  Without such basic",
					"tenets, all the people",
					"will need to spend a",
					"significant portion of",
					"their time and effort"
				),
				new BookPageInfo
				(
					"towards personal",
					"protection and thus",
					"less time towards",
					"other more beneficial",
					"pursuits.",
					"  Then there are the",
					"moral codes that are",
					"so popular today."
				),
				new BookPageInfo
				(
					"These codes are built",
					"largely on historical",
					"tradition rather than",
					"current logic and thus",
					"are also antiquated.",
					"For example many",
					"moral codes we see",
					"today include"
				),
				new BookPageInfo
				(
					"statements about not",
					"eating certain foods",
					"that once were often",
					"poisonous, but today",
					"can be prepared",
					"safely.",
					"  Many forbid contact",
					"between young people"
				),
				new BookPageInfo
				(
					"of the opposite",
					"gender, which can in",
					"fact be hazardous; but",
					"the codes often have",
					"lost the context as to",
					"why this is done,",
					"instead merely calling",
					"it amoral. In this day"
				),
				new BookPageInfo
				(
					"and age to call that a",
					"necessary moral",
					"would need a new",
					"reasoning. I put forth",
					"that tradition is not",
					"enough",
					"  Then there are",
					"Lord British's"
				),
				new BookPageInfo
				(
					"Virtues. It strikes me",
					"that while a system",
					"of virtues is",
					"wonderful as a",
					"touchstone to guide a",
					"society to good",
					"behavior, these are",
					"but shades of the"
				),
				new BookPageInfo
				(
					"underlying truth as to",
					"why one may wish to",
					"live a life according to",
					"certain rules of",
					"conduct.",
					"  On the other hand,",
					"clearly the Virtues",
					"that I have heard"
				),
				new BookPageInfo
				(
					"Lord British speak of",
					"are clearly positive",
					"codes of conduct, far",
					"better than the world",
					"of anarchy that Lord",
					"Blackthorn suggests.",
					"Yet, are not these",
					"Virtues still derived"
				),
				new BookPageInfo
				(
					"from a set of",
					"principles which",
					"though they sound",
					"good, are difficult to",
					"pin down as actual,",
					"undeniable, rational",
					"truths?",
					"  Worse yet though"
				),
				new BookPageInfo
				(
					"imagine a society",
					"who's code of",
					"conduct was based on",
					"pure survival of the",
					"strongest. While this",
					"society may function",
					"and even accomplish",
					"much, it can be"
				),
				new BookPageInfo
				(
					"fairly argued that",
					"personal happiness",
					"would suffer greatly,",
					"except for those at",
					"the top. To rule that",
					"out, however, we",
					"must first believe",
					"that people have a"
				),
				new BookPageInfo
				(
					"right to pursue",
					"happiness.",
					"  I hope is a safe",
					"assumption that all",
					"beings wish to be",
					"happy; I will broadly",
					"describe this as",
					"Hedonism. Yet, if all"
				),
				new BookPageInfo
				(
					"people did is live a",
					"life of hedonism,",
					"their hedonism might",
					"be in conflict with",
					"those near them, so I",
					"will use the term",
					"Ethics to describe",
					"limits one might put"
				),
				new BookPageInfo
				(
					"on one's hedonistic",
					"tendencies to allow",
					"others to pursue their",
					"happiness as well.",
					"  Allow me to give",
					"this example: If one",
					"were to live alone on a",
					"desert isle, one could"
				),
				new BookPageInfo
				(
					"live a life of pure",
					"hedonism, for no",
					"action one might take",
					"could interfere with",
					"another's right to",
					"pursue their",
					"happiness. Poison the",
					"lake if you like, there"
				),
				new BookPageInfo
				(
					"is no one to blame but",
					"yourself!",
					"  Now suppose two",
					"of you live on that",
					"island. Thou dost not",
					"want thy neighbor to",
					"feel free to poison the",
					"lake. Would it not be"
				),
				new BookPageInfo
				(
					"better to consider it",
					"unethical to poison the",
					"lake without first",
					"thinking of those",
					"whose pursuit of",
					"happiness might be",
					"affected by this",
					"action?"
				),
				new BookPageInfo
				(
					"  I put forth that it is",
					"the fact that we as a",
					"people choose to live in",
					"groups known as a",
					"society that causes us",
					"to compromise our",
					"pure hedonism with",
					"logical ethics."
				),
				new BookPageInfo
				(
					"Likewise we accept",
					"not being able to kill",
					"others without",
					"reason, because our",
					"own pursuit of",
					"happiness would be",
					"greatly interfered",
					"with if we feared"
				),
				new BookPageInfo
				(
					"others would do the",
					"same to us. From",
					"this basis of logic can",
					"be formed the Tenets",
					"of Ethical Hedonism.",
					"  For more on this",
					"subject, see The",
					"Tenants of Ethical"
				),
				new BookPageInfo
				(
					"Hedonism, by",
					"Richard Garriott and",
					"Herman Miller."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public EthicalHedonism() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public EthicalHedonism(Serial serial) : base(serial)
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