namespace Server.Factions
{
	public sealed class Britain : Town
	{
		public Britain()
		{
			Definition = new
			(
				0,
				0x1869,
				"Britain",
				"Britain",
				"BRITAIN",
				"TOWN STONE FOR BRITAIN",
				"The Faction Sigil Monolith of Britain",
				"The Faction Town Sigil Monolith of Britain",
				"Faction Town Stone of Britain",
				"Faction Town Sigil of Britain",
				"Corrupted Faction Town Sigil of Britain",
				new Point3D(1592, 1680, 10), // Town Sigil Location
				new Point3D(1588, 1676, 10), // Town Stone Location
				new TownReputationDefinition
				(
					this, 
					"Britain Township",
					// https://www.uoguide.com/Britain
					"Renamed when the entire realm was given its new title -- when Lord Robert was defeated on the Crimson Plains -- Britain is the capital city of Britannia.\n" +
					"Lord British's seat of power is located at what could be considered the interior vertex of the angular continent.\n" +
					"It is situated beside a great river that runs from the eastern mountain range into Brittany Bay.\n" +
					"\n" +
					"For its size, Britain is a clean city, looking much like an English city at the end of the Medieval era, just on the cusp of the Renaissance.\n" +
					"Magnificent stone buildings intermixed with sturdy wood-and-plaster shops and homes.\n" +
					"In the middle of the walled-city is Lord British's marvelous castle, complete with moat and draw bridge.\n" +
					"Overall, Britain represents the latest and best of every discipline imaginable, second only to those communities that specialize in particular disciplines " +
					"(and only in the aspects relating to those specific disciplines).\n"
				)
			);
		}
	}

	public sealed class Trinsic : Town
	{
		public Trinsic()
		{
			Definition = new
			(
				1,
				0x186A,
				"Trinsic",
				"Trinsic",
				"TRINSIC",
				"TOWN STONE FOR TRINSIC",
				"The Faction Sigil Monolith of Trinsic",
				"The Faction Town Sigil Monolith of Trinsic",
				"Faction Town Stone of Trinsic",
				"Faction Town Sigil of Trinsic",
				"Corrupted Faction Town Sigil of Trinsic",
				new Point3D(1914, 2717, 20), // Town Sigil Location
				new Point3D(1909, 2720, 20), // Town Stone Location
				new TownReputationDefinition
				(
					this,
					"Trinsic Township",
					// https://www.uoguide.com/Trinsic
					"The second largest city in Britannia, Trinsic consists of a river delta area, which divides the town into two main areas, and two islands; Paladin Isle and Barrier Isle.\n" +
					"\n" +
					"A substantial stone wall surrounds the city and the river has been utilised to create a moat around the landward side.\n" +
					"A further, internal, wall divides the upper commercial area from the barracks and training area of the Paladins.\n"
				)
			);
		}
	}

	public sealed class Minoc : Town
	{
		public Minoc()
		{
			Definition = new
			(
				2,
				0x186B,
				"Minoc",
				"Minoc",
				"MINOC",
				"TOWN STONE FOR MINOC",
				"The Faction Sigil Monolith of Minoc",
				"The Faction Town Sigil Monolith Minoc",
				"Faction Town Stone of Minoc",
				"Faction Town Sigil of Minoc",
				"Corrupted Faction Town Sigil of Minoc",
				new Point3D(2471, 439, 15), // Town Sigil Location
				new Point3D(2469, 445, 15), // Town Stone Location
				new TownReputationDefinition
				(
					this,
					"Minoc Township",
					// https://www.uoguide.com/Minoc
					"Minoc is found in the north-eastern region of the realm, nestled within the mountains.\n" +
					"Although initially a community of artisans and gadgeteers, recently-discovered precious ores have turned it into a mining town.\n" +
					"\n" +
					"The Gadgeteers Guild is located in Minoc in order to provide easy access to the materials they need: the metals and ores, and the raw lumber.\n" +
					"Minoc produces most of the raw materials such as ore and lumber for Britain, Magincia, and Vesper.\n" +
					"\n" +
					"Mount Kendall, just to the east of town, is a towering peak with a system of caverns and rich mining prospects.\n"
				)
			);
		}
	}

	public sealed class Moonglow : Town
	{
		public Moonglow()
		{
			Definition = new
			(
				3,
				0x186C,
				"Moonglow",
				"Moonglow",
				"MOONGLOW",
				"TOWN STONE FOR MOONGLOW",
				"The Faction Sigil Monolith of Moonglow",
				"The Faction Town Sigil Monolith of Moonglow",
				"Faction Town Stone of Moonglow",
				"Faction Town Sigil of Moonglow",
				"Corrupted Faction Town Sigil of Moonglow",
				new Point3D(4436, 1083, 0), // Town Sigil Location
				new Point3D(4432, 1086, 0), // Town Stone Location
				new TownReputationDefinition
				(
					this,
					"Moonglow Township",
					// https://www.uoguide.com/Moonglow
					"Moonglow is found on the southern tip of Verity Isle, which was named to reflect the objective intellectual pursuits of the citys' populace.\n" +
					"\n" +
					"Although the buildings were designed and constructed by the architects and masons from mainland Britannia, the overall appearance of the city is one of function over form.\n" +
					"Buildings are sturdy and devoid of superfluous accouterments.\n" +
					"The streets are narrow, but straightforward and well-connected.\n" +
					"In many ways, the city looks like one large campus, with the Lycaeum as the central college.\n" +
					"\n" +
					"Much of the study that goes on in Moonglow, and especially at the Lycaeum, is of the arcane arts.\n" +
					"Nearly every form of sorcery, enchantment and potion is studied here, and most of the realms' research into new magic is performed here.\n" +
					"Almost every great wizard interested in enhancing his or her personal abilities, or in increasing Britannias' pool of abilities, has spent at least a few months within the walls of the Lycaeum.\n" +
					"\n" +
					"Not wanting to worry about inconveniences of daily life, the residents of Moonglow have worked hard to ensure they have every contemporary labor-saving device and invention known to the realm.\n" +
					"Although nearly all is imported, the keen minds quickly dissect and analyze the latest gadgets, as their understanding of technology is usually quite strong.\n"
				)
			);
		}
	}

	public sealed class Yew : Town
	{
		public Yew()
		{
			Definition = new
			(
				4,
				0x186D,
				"Yew",
				"Yew",
				"YEW",
				"TOWN STONE FOR YEW",
				"The Faction Sigil Monolith of Yew",
				"The Faction Town Sigil Monolith of Yew",
				"Faction Town Stone of Yew",
				"Faction Town Sigil of Yew",
				"Corrupted Faction Town Sigil of Yew",
				new Point3D(548, 979, 0), // Town Sigil Location
				new Point3D(542, 980, 0), // Town Stone Location
				new TownReputationDefinition
				(
					this, 
					"Yew Township",
					// https://www.uoguide.com/Yew
					"Yew is located in the northwest region of Britannia, on the edge of the Deep Forest.\n" +
					"\n" +
					"The pastoral city is named for the dense population of Yew trees that surround it.\n" +
					"Yew is less of a city than it is a collection of many homesteads.\n" +
					"Dirt roads connect most of the buildings, which lends credence to the claim that it is a community, but often a considerable distance lies between the house of the various residents.\n" +
					"\n" +
					"Deep within its woods is the hallowed Empath Abbey, home to diligent monks who are makers of the best wine in the land.\n" +
					"Most of the houses are simple wooden cabins, although the Abbey is made of stone for durability.\n" +
					"Also in the area is the Court of Truth.\n" +
					"The land’s second largest jail in Sosaria, it is made entirely of reinforced stone and looks like a smaller version of Lord British's Castle Britannia.\n" +
					"\n" +
					"The center of Yew proper is also the location of the portal to the Elf City of Heartwood.\n"
				)
			);
		}
	}

	public sealed class Vesper : Town
	{
		public Vesper()
		{
			Definition = new
			(
				5,
				0x186E,
				"Vesper",
				"Vesper",
				"VESPER",
				"TOWN STONE FOR VESPER",
				"The Faction Sigil Monolith of Vesper",
				"The Faction Town Sigil Monolith of Vesper",
				"Faction Town Stone of Vesper",
				"Faction Town Sigil of Vesper",
				"Corrupted Faction Town Sigil of Vesper",
				new Point3D(2982, 818, 0), // Town Sigil Location
				new Point3D(2985, 821, 0), // Town Stone Location
				new TownReputationDefinition
				(
					this, 
					"Vesper Township",
					// https://www.uoguide.com/Vesper
					"Vesper is located in north eastern Britannia, at the mouth of a river.\n" +
					"\n" +
					"The city is fragmented, being built on both banks of the river and over a dozen islands in the river mouth, the whole being connected by a series of bridges.\n" +
					"The city graveyard is on the West bank of the river and a stairway leading below one of the small buildings there gives access to a passageway to the Lost Lands.\n"
				)
			);
		}
	}

	public sealed class SkaraBrae : Town
	{
		public SkaraBrae()
		{
			Definition = new
			(
				6,
				0x186F,
				"Skara Brae",
				"Skara Brae",
				"SKARA BRAE",
				"TOWN STONE FOR SKARA BRAE",
				"The Faction Sigil Monolith of Skara Brae",
				"The Faction Town Sigil Monolith of Skara Brae",
				"Faction Town Stone of Skara Brae",
				"Faction Town Sigil of Skara Brae",
				"Corrupted Faction Town Sigil of Skara Brae",
				new Point3D(576, 2200, 0), // Town Sigil Location
				new Point3D(572, 2196, 0), // Town Stone Location
				new TownReputationDefinition
				(
					this,
					"Skara Brae Township",
					// https://www.uoguide.com/Skara_Brae
					"Skara Brae is the home of Rangers and is located on an island off the eastern coast of Britannia, " +
					"separated from the mainland by a channel which is traversed by means of a ferry between docks on the isle and on the mainland.\n" +
					"\n" +
					"The Ranger’s Hall along with several farms and homes is close to the mainland docks; " +
					"however most of the town’s traffic arrives and departs through the public moongate at the northeast corner of the isle.\n"
				)
			);
		}
	}

	public sealed class Magincia : Town
	{
		public Magincia()
		{
			Definition = new
			(
				7,
				0x1870,
				"Magincia",
				"Magincia",
				"MAGINCIA",
				"TOWN STONE FOR MAGINCIA",
				"The Faction Sigil Monolith of Magincia",
				"The Faction Town Sigil Monolith of Magincia",
				"Faction Town Stone of Magincia",
				"Faction Town Sigil of Magincia",
				"Corrupted Faction Town Sigil of Magincia",
				new Point3D(3714, 2235, 20), // Town Sigil Location
				new Point3D(3712, 2230, 20), // Town Stone Location
				new TownReputationDefinition
				(
					this, 
					"Magincia Township",
					// https://www.uoguide.com/Magincia
					"On the central island between Buccaneer's Den and Moonglow, Magincia was a natural target for plunder and magical side-effects.\n" +
					"Ironically, it was the latter that tend to reduce the frequency of the former.\n" +
					"\n" +
					"Home to the largest diamond mine in the realm, the residents of Magincia had experienced the sensation of too much money.\n" +
					"One of the many ways in which they had found to address this problem involved constructing ridiculously ornate buildings.\n" +
					"Structurally sound shops would often had additional columns and supports solely to provide additional places in which to inlay gemstones and gold.\n" +
					"The street signs were lettered in real silver, while the local watch wore badges that use precious metals to indicate rank.\n"
				)
			);
		}
	}
}