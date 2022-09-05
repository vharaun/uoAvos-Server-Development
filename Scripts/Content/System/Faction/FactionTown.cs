using System;

namespace Server.Factions
{
	public class Britain : Town
	{
		public Britain()
		{
			Definition =
				new TownDefinition(
					0,
					0x1869,
					"Britain",
					"Britain",
					new TextDefinition(1011433, "BRITAIN"),
					new TextDefinition(1011561, "TOWN STONE FOR BRITAIN"),
					new TextDefinition(1041034, "The Faction Sigil Monolith of Britain"),
					new TextDefinition(1041404, "The Faction Town Sigil Monolith of Britain"),
					new TextDefinition(1041413, "Faction Town Stone of Britain"),
					new TextDefinition(1041395, "Faction Town Sigil of Britain"),
					new TextDefinition(1041386, "Corrupted Faction Town Sigil of Britain"),
					new Point3D(1592, 1680, 10), // Town Sigil Location
					new Point3D(1588, 1676, 10), // Town Stone Location
					new TownReputationDefinition(this, "Britain Township")
				);
		}
	}

	public class Magincia : Town
	{
		public Magincia()
		{
			Definition =
				new TownDefinition(
					7,
					0x1870,
					"Magincia",
					"Magincia",
					new TextDefinition(1011440, "MAGINCIA"),
					new TextDefinition(1011568, "TOWN STONE FOR MAGINCIA"),
					new TextDefinition(1041041, "The Faction Sigil Monolith of Magincia"),
					new TextDefinition(1041411, "The Faction Town Sigil Monolith of Magincia"),
					new TextDefinition(1041420, "Faction Town Stone of Magincia"),
					new TextDefinition(1041402, "Faction Town Sigil of Magincia"),
					new TextDefinition(1041393, "Corrupted Faction Town Sigil of Magincia"),
					new Point3D(3714, 2235, 20), // Town Sigil Location
					new Point3D(3712, 2230, 20), // Town Stone Location
					new TownReputationDefinition(this, "Magincia Township")
				);
		}
	}

	public class Minoc : Town
	{
		public Minoc()
		{
			Definition =
				new TownDefinition(
					2,
					0x186B,
					"Minoc",
					"Minoc",
					new TextDefinition(1011437, "MINOC"),
					new TextDefinition(1011564, "TOWN STONE FOR MINOC"),
					new TextDefinition(1041036, "The Faction Sigil Monolith of Minoc"),
					new TextDefinition(1041406, "The Faction Town Sigil Monolith Minoc"),
					new TextDefinition(1041415, "Faction Town Stone of Minoc"),
					new TextDefinition(1041397, "Faction Town Sigil of Minoc"),
					new TextDefinition(1041388, "Corrupted Faction Town Sigil of Minoc"),
					new Point3D(2471, 439, 15), // Town Sigil Location
					new Point3D(2469, 445, 15), // Town Stone Location
					new TownReputationDefinition(this, "Minoc Township")
				);
		}
	}

	public class Moonglow : Town
	{
		public Moonglow()
		{
			Definition =
				new TownDefinition(
					3,
					0x186C,
					"Moonglow",
					"Moonglow",
					new TextDefinition(1011435, "MOONGLOW"),
					new TextDefinition(1011563, "TOWN STONE FOR MOONGLOW"),
					new TextDefinition(1041037, "The Faction Sigil Monolith of Moonglow"),
					new TextDefinition(1041407, "The Faction Town Sigil Monolith of Moonglow"),
					new TextDefinition(1041416, "Faction Town Stone of Moonglow"),
					new TextDefinition(1041398, "Faction Town Sigil of Moonglow"),
					new TextDefinition(1041389, "Corrupted Faction Town Sigil of Moonglow"),
					new Point3D(4436, 1083, 0), // Town Sigil Location
					new Point3D(4432, 1086, 0), // Town Stone Location
					new TownReputationDefinition(this, "Moonglow Township")
				);
		}
	}

	public class SkaraBrae : Town
	{
		public SkaraBrae()
		{
			Definition =
				new TownDefinition(
					6,
					0x186F,
					"Skara Brae",
					"Skara Brae",
					new TextDefinition(1011439, "SKARA BRAE"),
					new TextDefinition(1011567, "TOWN STONE FOR SKARA BRAE"),
					new TextDefinition(1041040, "The Faction Sigil Monolith of Skara Brae"),
					new TextDefinition(1041410, "The Faction Town Sigil Monolith of Skara Brae"),
					new TextDefinition(1041419, "Faction Town Stone of Skara Brae"),
					new TextDefinition(1041401, "Faction Town Sigil of Skara Brae"),
					new TextDefinition(1041392, "Corrupted Faction Town Sigil of Skara Brae"),
					new Point3D(576, 2200, 0), // Town Sigil Location
					new Point3D(572, 2196, 0), // Town Stone Location
					new TownReputationDefinition(this, "Skara Brae Township")
				);
		}
	}

	public class Trinsic : Town
	{
		public Trinsic()
		{
			Definition =
				new TownDefinition(
					1,
					0x186A,
					"Trinsic",
					"Trinsic",
					new TextDefinition(1011434, "TRINSIC"),
					new TextDefinition(1011562, "TOWN STONE FOR TRINSIC"),
					new TextDefinition(1041035, "The Faction Sigil Monolith of Trinsic"),
					new TextDefinition(1041405, "The Faction Town Sigil Monolith of Trinsic"),
					new TextDefinition(1041414, "Faction Town Stone of Trinsic"),
					new TextDefinition(1041396, "Faction Town Sigil of Trinsic"),
					new TextDefinition(1041387, "Corrupted Faction Town Sigil of Trinsic"),
					new Point3D(1914, 2717, 20), // Town Sigil Location
					new Point3D(1909, 2720, 20), // Town Stone Location
					new TownReputationDefinition(this, "Trinsic Township")
				);
		}
	}

	public class Vesper : Town
	{
		public Vesper()
		{
			Definition =
				new TownDefinition(
					5,
					0x186E,
					"Vesper",
					"Vesper",
					new TextDefinition(1016413, "VESPER"),
					new TextDefinition(1011566, "TOWN STONE FOR VESPER"),
					new TextDefinition(1041039, "The Faction Sigil Monolith of Vesper"),
					new TextDefinition(1041409, "The Faction Town Sigil Monolith of Vesper"),
					new TextDefinition(1041418, "Faction Town Stone of Vesper"),
					new TextDefinition(1041400, "Faction Town Sigil of Vesper"),
					new TextDefinition(1041391, "Corrupted Faction Town Sigil of Vesper"),
					new Point3D(2982, 818, 0), // Town Sigil Location
					new Point3D(2985, 821, 0), // Town Stone Location
					new TownReputationDefinition(this, "Vesper Township")
				);
		}
	}

	public class Yew : Town
	{
		public Yew()
		{
			Definition =
				new TownDefinition(
					4,
					0x186D,
					"Yew",
					"Yew",
					new TextDefinition(1011438, "YEW"),
					new TextDefinition(1011565, "TOWN STONE FOR YEW"),
					new TextDefinition(1041038, "The Faction Sigil Monolith of Yew"),
					new TextDefinition(1041408, "The Faction Town Sigil Monolith of Yew"),
					new TextDefinition(1041417, "Faction Town Stone of Yew"),
					new TextDefinition(1041399, "Faction Town Sigil of Yew"),
					new TextDefinition(1041390, "Corrupted Faction Town Sigil of Yew"),
					new Point3D(548, 979, 0), // Town Sigil Location
					new Point3D(542, 980, 0), // Town Stone Location
					new TownReputationDefinition(this, "Yew Township")
				);
		}
	}
}