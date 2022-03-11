using Server.Engines.Publishing;

namespace Server.Items
{
	public class TreatiseOnAlchemy : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Treatise on Alchemy", "Felicia Hierophant",
				new BookPageInfo
				(
					"    The alchemical",
					"arts are notable for",
					"their deceptive",
					"simplicity. 'Tis true",
					"that to our best",
					"knowledge currently,",
					"there are but eight",
					"valid potions that can"
				),
				new BookPageInfo
				(
					"be made (though I",
					"emphasize that new",
					"discoveries may",
					"always await).",
					"However, the delicate",
					"balance of confecting",
					"the potions is",
					"difficult indeed, and"
				),
				new BookPageInfo
				(
					"requires great skill.",
					"    To give thee an",
					"example of the",
					"simpler potions that",
					"can be created by",
					"those well-versed in",
					"the subtleties of",
					"alchemy:"
				),
				new BookPageInfo
				(
					"    Black pearl, that",
					"rare substance that is",
					"oft found lying",
					"unannounced upon the",
					"surface of the",
					"ground, when",
					"properly crushed",
					"with mortar and"
				),
				new BookPageInfo
				(
					"pestle, can yield a",
					"fine powder. Said",
					"powder in the proper",
					"proportions when",
					"mixed via the",
					"alchemical arts can",
					"yield a wonderfully",
					"refreshing drink."
				),
				new BookPageInfo
				(
					"    The revolting blood",
					"moss so gingerly",
					"scraped off of",
					"windowsills by",
					"fastidious housewives",
					"is but a tiny cousin to",
					"the wilder version,",
					"which when properly"
				),
				new BookPageInfo
				(
					"prepared yields a",
					"magical liquid that for",
					"a time can make the",
					"imbiber a more agile",
					"and dextrous",
					"individual.",
					"    However, beware",
					"of the deadly"
				),
				new BookPageInfo
				(
					"nightshade, for it",
					"yields a deceptively",
					"sweet-tasting poison",
					"that can prove highly",
					"fatal to the drinker,",
					"and in fact is also",
					"used by assassins to",
					"coat their blades."
				),
				new BookPageInfo
				(
					"Fortunately, this",
					"latter art of poisoning",
					"is little known!",
					"    There is much to",
					"reward the student of",
					"alchemy, indeed. The",
					"rumours of longtime",
					"alchemists losing"
				),
				new BookPageInfo
				(
					"their hair and",
					"acquiring an",
					"unhealthy pallor, not",
					"to mention unsightly",
					"blotches upon their",
					"once-fair skin, are",
					"unhappily, true. Yet",
					"the joys of the mind"
				),
				new BookPageInfo
				(
					"make up for the",
					"complete loss of",
					"interest that others",
					"may have in thee as",
					"an object of",
					"courtship, and I have",
					"never regretted that",
					"choice. Honestly,"
				),
				new BookPageInfo
				(
					"truly. Not once."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public TreatiseOnAlchemy() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public TreatiseOnAlchemy(Serial serial) : base(serial)
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