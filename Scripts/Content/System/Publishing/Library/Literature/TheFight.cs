using Server.Engines.Publishing;

namespace Server.Items
{
	public class TheFight : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"The Fight", "M. de la Garza",
				new BookPageInfo
				(
					"    A cold autumn's",
					"morning with misty",
					"fog secures a dozen",
					"brave knights,",
					"supplying hidden",
					"shelter from prying",
					"eyes deep in the",
					"foothills of the"
				),
				new BookPageInfo
				(
					"vibrant valley.",
					"Dragons soar like",
					"fierce warriors,",
					"circling around and",
					"around, then roaring",
					"like thunder, rallying",
					"all that listen.  The",
					"dragons land swiftly"
				),
				new BookPageInfo
				(
					"beside the proud",
					"warriors, bending",
					"necks and extending",
					"wings, lifting black",
					"claws and allowing",
					"valiant fighters to",
					"ride forth and win an",
					"arisen battle.  The"
				),
				new BookPageInfo
				(
					"increasing winds",
					"silence the sounds of",
					"combat, and they",
					"fight, standing their",
					"ground like mothers",
					"protecting their",
					"childern, bright",
					"armor flashing as"
				),
				new BookPageInfo
				(
					"each one falls.",
					"    A cold autumn's",
					"evening with misty",
					"fog cradles a dozen",
					"battered corpses of",
					"knights, creasing",
					"them in currents of",
					"winds that run deep"
				),
				new BookPageInfo
				(
					"in the foothills of the",
					"desolate valley.",
					"Dragons glide like",
					"silent angels, circling",
					"around and around,",
					"then calling like",
					"banshees; keening",
					"cries of mourning."
				),
				new BookPageInfo
				(
					"The dragons land",
					"heavily beside the",
					"peaceful bodies,",
					"bending necks and",
					"extending wings,",
					"lifting black claws",
					"and allowing valiant",
					"fighters to ride forth"
				),
				new BookPageInfo
				(
					"and win an arisen",
					"battle.  The increasing",
					"winds silence the",
					"sounds of combat, and",
					"they fight, standing",
					"their ground like",
					"mothers protecting",
					"their childern, bright"
				),
				new BookPageInfo
				(
					"armor flashing as",
					"each one falls.",
					"    A cold autumn's",
					"evening with misty",
					"fog cradles a dozen",
					"battered corpses of",
					"knights, creasing",
					"them in currents of"
				),
				new BookPageInfo
				(
					"winds that run deep",
					"in the foothills of the",
					"desolate valley.",
					"Dragons glide like",
					"silent angels, circling",
					"around and around,",
					"then calling like",
					"banshees; keening"
				),
				new BookPageInfo
				(
					"cries of mourning.",
					"The dragons land",
					"heavily beside the",
					"peaceful bodies,",
					"bending necks and",
					"extending wings,",
					"lifting black claws",
					"and pinching the"
				),
				new BookPageInfo
				(
					"sacred ground and",
					"new eternal home.",
					"The dying winds",
					"whistle among the",
					"dead in somber",
					"procession, and they",
					"lie, grasping weapons",
					"to protect themselves"
				),
				new BookPageInfo
				(
					"like knights still in",
					"battle, shattered",
					"armor shining like",
					"newly born stars."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public TheFight() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public TheFight(Serial serial) : base(serial)
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