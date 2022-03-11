using Server.Engines.Publishing;

namespace Server.Items
{
	public class SongOfSamlethe : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"A Song of Samlethe", "Sandra",
				new BookPageInfo
				(
					"The first bear did",
					"swim by day,",
					"And it did sleep by",
					"night.",
					"It kept itself within",
					"its cave",
					"and ate by starry",
					"light."
				),
				new BookPageInfo
				(
					"",
					"The second bear it did",
					"cavort",
					"'Neath canopies of",
					"trees,",
					"And danced its",
					"strange bearish sort",
					"Of joy for all to see."
				),
				new BookPageInfo
				(
					"",
					"The first bear, well,",
					"'twas hunted,",
					"And today adorns a",
					"floor.",
					"Its ruggish face has",
					"been dented",
					"By footfalls and the"
				),
				new BookPageInfo
				(
					"door.",
					"",
					"The second bear did",
					"step once",
					"Into a mushroom ring,",
					"And now does dance",
					"the dunce",
					"For wisps and"
				),
				new BookPageInfo
				(
					"unseen things.",
					"",
					"So do not dance, and",
					"do not sleep,",
					"Or else be led astray!",
					"For bears all end up",
					"six feet deep",
					"At the end of"
				),
				new BookPageInfo
				(
					"Samlethe's day."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public SongOfSamlethe() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public SongOfSamlethe(Serial serial) : base(serial)
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