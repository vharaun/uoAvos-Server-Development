using Server.Engines.Publishing;

namespace Server.Items
{
	public class DeceitDungeonOfHorror : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Deceit: A Dungeon of Horrors", "Mercenary Justin",
				new BookPageInfo
				(
					"  My employers have",
					"oft taken me into this",
					"den of hideous",
					"creatures, and I",
					"thought that it",
					"behooved me to write",
					"down what I know of",
					"it, now that I am"
				),
				new BookPageInfo
				(
					"retired from the life",
					"of an adventurer for",
					"hire.",
					"  Deceit was once a",
					"temple to forgotten",
					"powers of old. It was",
					"taken over by mages",
					"who eventually were"
				),
				new BookPageInfo
				(
					"driven out by the",
					"depredations of their",
					"own evil lackeys.",
					"However, many of",
					"the magical traps and",
					"devices that they",
					"placed for their",
					"defenses remain,"
				),
				new BookPageInfo
				(
					"particularly those the",
					"wizards used to",
					"protect their",
					"treasures.",
					"  The dungeon is",
					"mystically linked by",
					"crystal balls placed in",
					"different locations."
				),
				new BookPageInfo
				(
					"These magical orbs do",
					"transmit speech, and",
					"even have memory of",
					"things that have been",
					"said near them. No",
					"doubt they once",
					"served as a warning",
					"system"
				),
				new BookPageInfo
				(
					"  Be wary of a",
					"brazier that giveth",
					"warning when",
					"approached; thou canst",
					"use it to summon",
					"deadly creatures.",
					"  There be a",
					"tantalizing chest,"
				),
				new BookPageInfo
				(
					"undoubtedly full of",
					"treasure, that cannot",
					"be reached save past a",
					"complex set of",
					"pressure plates that",
					"trigger deadly spikes.",
					"As I never had",
					"sufficient folk with"
				),
				new BookPageInfo
				(
					"me to unlock the",
					"puzzle, I never",
					"obtained the riches",
					"that awaited there.",
					"  Do not investigate",
					"iron maidens too",
					"closely, for they may",
					"suck you within"
				),
				new BookPageInfo
				(
					"them!",
					"  There is one place",
					"where a deadly trap",
					"can only be disarmed",
					"by making use of a",
					"statue that cleverly",
					"conceals a lever.",
					"  Oft one encounters"
				),
				new BookPageInfo
				(
					"the deadly exploding",
					"toadstool; the ones in",
					"Deceit are deadlier",
					"than most, as they",
					"explode continually.",
					"Likewise, the very",
					"pools of water and",
					"slime on the floor"
				),
				new BookPageInfo
				(
					"may poison thee.",
					"  The most magical",
					"device in the dungeon",
					"is a mystical bridge",
					"that can only be",
					"triggered by a level",
					"embedded in the floor.",
					"Be wary however,"
				),
				new BookPageInfo
				(
					"for the bridge thus",
					"created doth burst",
					"into flame when one",
					"passeth across it!"
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public DeceitDungeonOfHorror() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public DeceitDungeonOfHorror(Serial serial) : base(serial)
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