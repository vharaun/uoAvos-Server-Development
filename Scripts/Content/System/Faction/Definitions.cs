//#define OSI_FACTIONS

#if OSI_FACTIONS
namespace Server.Factions
{
	public sealed class Minax : Faction
	{
		public static Minax Instance { get; private set; }

		public override FactionDefinition Definition { get; } = new(
			0,
			FactionEthic.Evil,
			1645, // Primary Faction Hue: Dark Red
			1109, // 2nd Faction Hue Hue: Shadow
			1645, // JoinStone Hue: Dark Red
			1645, // Broadcast Hue: Dark Red
			0x78, 0x3EAF, // War Horse: BodyValue, ItemID
			"Minax", "minax", "Min",
			new TextDefinition(1011534, "MINAX"),
			new TextDefinition(1060769, "Minax faction"),
			new TextDefinition(1011421, "<center>FOLLOWERS OF MINAX</center>"),
			new TextDefinition(1011448,
				"The followers of Minax have taken control in the old lands, " +
				"and intend to hold it for as long as they can. Allying themselves " +
				"with orcs, headless, gazers, trolls, and other beasts, they seek " +
				"revenge against Lord British, for slights both real and imagined, " +
				"though some of the followers wish only to wreak havoc on the " +
				"unsuspecting populace."),
			new TextDefinition(1011453, "This city is controlled by Minax."),
			new TextDefinition(1042252, "This sigil has been corrupted by the Followers of Minax"),
			new TextDefinition(1041043, "The faction signup stone for the Followers of Minax"),
			new TextDefinition(1041381, "The Faction Stone of Minax"),
			new TextDefinition(1011463, ": Minax"),
			new TextDefinition(1005190, "Followers of Minax will now be ignored."),
			new TextDefinition(1005191, "Followers of Minax will now be told to go away."),
			new TextDefinition(1005192, "Followers of Minax will now be hanged by their toes."),
			new StrongholdDefinition(
				new Poly2D[]
				{
					new Rectangle2D( 1097, 2570, 70, 50 ) // Stronghold Border
				},
				new Point3D(1172, 2593, 0),  // Faction JoinStone
				new Point3D(1117, 2587, 18), // Faction Management Stone
				new Point3D[]
				{
					new Point3D( 1113, 2601, 18 ), // Town Sigil Display
					new Point3D( 1113, 2598, 18 ), // Town Sigil Display
					new Point3D( 1113, 2595, 18 ), // Town Sigil Display
					new Point3D( 1113, 2592, 18 ), // Town Sigil Display
					new Point3D( 1116, 2601, 18 ), // Town Sigil Display
					new Point3D( 1116, 2598, 18 ), // Town Sigil Display
					new Point3D( 1116, 2595, 18 ), // Town Sigil Display
					new Point3D( 1116, 2592, 18 )  // Town Sigil Display
				}),
			new RankDefinition[]
			{
				new RankDefinition( 10, 991, 8, new TextDefinition( 1060784, "Avenger of Mondain" ) ),
				new RankDefinition(  9, 950, 7, new TextDefinition( 1060783, "Dread Knight" ) ),
				new RankDefinition(  8, 900, 6, new TextDefinition( 1060782, "Warlord" ) ),
				new RankDefinition(  7, 800, 6, new TextDefinition( 1060782, "Warlord" ) ),
				new RankDefinition(  6, 700, 5, new TextDefinition( 1060781, "Executioner" ) ),
				new RankDefinition(  5, 600, 5, new TextDefinition( 1060781, "Executioner" ) ),
				new RankDefinition(  4, 500, 5, new TextDefinition( 1060781, "Executioner" ) ),
				new RankDefinition(  3, 400, 4, new TextDefinition( 1060780, "Defiler" ) ),
				new RankDefinition(  2, 200, 4, new TextDefinition( 1060780, "Defiler" ) ),
				new RankDefinition(  1,   0, 4, new TextDefinition( 1060780, "Defiler" ) )
			},
			new GuardDefinition[]
			{
				new GuardDefinition( typeof( FactionHenchman ),     0x1403, 5000, 1000, 10,     new TextDefinition( 1011526, "HENCHMAN" ),      new TextDefinition( 1011510, "Hire Henchman" ) ),
				new GuardDefinition( typeof( FactionMercenary ),    0x0F62, 6000, 2000, 10,     new TextDefinition( 1011527, "MERCENARY" ),     new TextDefinition( 1011511, "Hire Mercenary" ) ),
				new GuardDefinition( typeof( FactionBerserker ),    0x0F4B, 7000, 3000, 10,     new TextDefinition( 1011505, "BERSERKER" ),     new TextDefinition( 1011499, "Hire Berserker" ) ),
				new GuardDefinition( typeof( FactionDragoon ),      0x1439, 8000, 4000, 10,     new TextDefinition( 1011506, "DRAGOON" ),       new TextDefinition( 1011500, "Hire Dragoon" ) ),
			}
		);

		private Minax()
		{
			Instance = new();
		}
	}

	public sealed class CouncilOfMages : Faction
	{
		public static CouncilOfMages Instance { get; private set; }

		public override FactionDefinition Definition { get; } = new(
			1,
			FactionEthic.Good,
			1325, // Primary Faction Hue: Blue
			1310, // 2nd Faction Hue Hue: Blue-White
			1325, // JoinStone Hue: Blue
			1325, // Broadcast Hue: Blue
			0x77, 0x3EB1, // War Horse: BodyValue, ItemID
			"Council of Mages", "council", "CoM",
			new TextDefinition(1011535, "COUNCIL OF MAGES"),
			new TextDefinition(1060770, "Council of Mages faction"),
			new TextDefinition(1011422, "<center>COUNCIL OF MAGES</center>"),
			new TextDefinition(1011449,
				"The council of Mages have their roots in the city of Moonglow, where " +
				"they once convened. They began as a small movement, dedicated to " +
				"calling forth the Stranger, who saved the lands once before.  A " +
				"series of war and murders and misbegotten trials by those loyal to " +
				"Lord British has caused the group to take up the banner of war."),
			new TextDefinition(1011455, "This city is controlled by the Council of Mages."),
			new TextDefinition(1042253, "This sigil has been corrupted by the Council of Mages"),
			new TextDefinition(1041044, "The faction signup stone for the Council of Mages"),
			new TextDefinition(1041382, "The Faction Stone of the Council of Mages"),
			new TextDefinition(1011464, ": Council of Mages"),
			new TextDefinition(1005187, "Members of the Council of Mages will now be ignored."),
			new TextDefinition(1005188, "Members of the Council of Mages will now be warned to leave."),
			new TextDefinition(1005189, "Members of the Council of Mages will now be beaten with a stick."),
			// Moonglow
			new StrongholdDefinition(
				new Poly2D[]
				{
					new Rectangle2D( 4463, 1487, 15, 35 ), // Stronghold Border
					new Rectangle2D( 4450, 1522, 35, 48 ), // Stronghold Border
				},
				new Point3D(4469, 1486, 0), // Faction JoinStone
				new Point3D(4457, 1544, 0), // Faction Management Stone
				new Point3D[]
				{
					new Point3D( 4464, 1534, 21 ), // Town Sigil Display
					new Point3D( 4470, 1536, 21 ), // Town Sigil Display
					new Point3D( 4468, 1534, 21 ), // Town Sigil Display
					new Point3D( 4470, 1534, 21 ), // Town Sigil Display
					new Point3D( 4468, 1536, 21 ), // Town Sigil Display
					new Point3D( 4466, 1534, 21 ), // Town Sigil Display
					new Point3D( 4466, 1536, 21 ), // Town Sigil Display
					new Point3D( 4464, 1536, 21 )  // Town Sigil Display
				}),

			#region Old Faction Stronghold Location: Magincia

			///	new StrongholdDefinition(
			///		new Rectangle2D[]
			///		{
			///			new Rectangle2D( 3756, 2232, 4, 23 ),
			///			new Rectangle2D( 3760, 2227, 60, 28 ),
			///			new Rectangle2D( 3782, 2219, 18, 8 ),
			///			new Rectangle2D( 3778, 2255, 35, 17 )
			///		},
			///		new Point3D( 3750, 2241, 20 ), // Faction Join Stone
			///		new Point3D( 3795, 2259, 20 ), // Faction Management Stone
			///		new Point3D[]
			///		{
			///			new Point3D( 3793, 2255, 20 ), // Town Sigil Display
			///			new Point3D( 3793, 2252, 20 ), // Town Sigil Display
			///			new Point3D( 3793, 2249, 20 ), // Town Sigil Display
			///			new Point3D( 3793, 2246, 20 ), // Town Sigil Display
			///			new Point3D( 3797, 2255, 20 ), // Town Sigil Display
			///			new Point3D( 3797, 2252, 20 ), // Town Sigil Display
			///			new Point3D( 3797, 2249, 20 ), // Town Sigil Display
			///			new Point3D( 3797, 2246, 20 )  // Town Sigil Display
			///		} ),

			#endregion

			new RankDefinition[]
			{
				new RankDefinition( 10, 991, 8, new TextDefinition( 1060789, "Inquisitor of the Council" ) ),
				new RankDefinition(  9, 950, 7, new TextDefinition( 1060788, "Archon of Principle" ) ),
				new RankDefinition(  8, 900, 6, new TextDefinition( 1060787, "Luminary" ) ),
				new RankDefinition(  7, 800, 6, new TextDefinition( 1060787, "Luminary" ) ),
				new RankDefinition(  6, 700, 5, new TextDefinition( 1060786, "Diviner" ) ),
				new RankDefinition(  5, 600, 5, new TextDefinition( 1060786, "Diviner" ) ),
				new RankDefinition(  4, 500, 5, new TextDefinition( 1060786, "Diviner" ) ),
				new RankDefinition(  3, 400, 4, new TextDefinition( 1060785, "Mystic" ) ),
				new RankDefinition(  2, 200, 4, new TextDefinition( 1060785, "Mystic" ) ),
				new RankDefinition(  1,   0, 4, new TextDefinition( 1060785, "Mystic" ) )
			},
			new GuardDefinition[]
			{
				new GuardDefinition( typeof( FactionHenchman ),     0x1403, 5000, 1000, 10,     new TextDefinition( 1011526, "HENCHMAN" ),      new TextDefinition( 1011510, "Hire Henchman" ) ),
				new GuardDefinition( typeof( FactionMercenary ),    0x0F62, 6000, 2000, 10,     new TextDefinition( 1011527, "MERCENARY" ),     new TextDefinition( 1011511, "Hire Mercenary" ) ),
				new GuardDefinition( typeof( FactionSorceress ),    0x0E89, 7000, 3000, 10,     new TextDefinition( 1011507, "SORCERESS" ),     new TextDefinition( 1011501, "Hire Sorceress" ) ),
				new GuardDefinition( typeof( FactionWizard ),       0x13F8, 8000, 4000, 10,     new TextDefinition( 1011508, "ELDER WIZARD" ),  new TextDefinition( 1011502, "Hire Elder Wizard" ) ),
			}
		);

		public CouncilOfMages()
		{
			Instance = new();
		}
	}

	public sealed class TrueBritannians : Faction
	{
		public static TrueBritannians Instance { get; private set; }

		public override FactionDefinition Definition { get; } = new(
			2,
			FactionEthic.Good,
			1254, // Primary Faction Hue: Dark Purple
			2125, // 2nd Faction Hue Hue: Gold
			2214, // JoinStone Hue: Gold
			2125, // Broadcast Hue: Gold
			0x76, 0x3EB2, // War Horse: BodyValue, ItemID
			"True Britannians", "true", "TB",
			new TextDefinition(1011536, "LORD BRITISH"),
			new TextDefinition(1060771, "True Britannians faction"),
			new TextDefinition(1011423, "<center>TRUE BRITANNIANS</center>"),
			new TextDefinition(1011450,
				"True Britannians are loyal to the throne of Lord British. They refuse " +
				"to give up their homelands to the vile Minax, and detest the Shadowlords " +
				"for their evil ways. In addition, the Council of Mages threatens the " +
				"existence of their ruler, and as such they have armed themselves, and " +
				"prepare for war with all."),
			new TextDefinition(1011454, "This city is controlled by Lord British."),
			new TextDefinition(1042254, "This sigil has been corrupted by the True Britannians"),
			new TextDefinition(1041045, "The faction signup stone for the True Britannians"),
			new TextDefinition(1041383, "The Faction Stone of the True Britannians"),
			new TextDefinition(1011465, ": True Britannians"),
			new TextDefinition(1005181, "Followers of Lord British will now be ignored."),
			new TextDefinition(1005182, "Followers of Lord British will now be warned of their impending doom."),
			new TextDefinition(1005183, "Followers of Lord British will now be attacked on sight."),
			new StrongholdDefinition(
				new Poly2D[]
				{
					new Rectangle2D( 1292, 1556, 25, 25 ),  // Stronghold Border
					new Rectangle2D( 1292, 1676, 120, 25 ), // Stronghold Border
					new Rectangle2D( 1388, 1556, 25, 25 ),	// Stronghold Border
					new Rectangle2D( 1317, 1563, 71, 18 ),	// Stronghold Border
					new Rectangle2D( 1300, 1581, 105, 95 ), // Stronghold Border
					new Rectangle2D( 1405, 1612, 12, 21 ),  // Stronghold Border
					new Rectangle2D( 1405, 1633, 11, 5 )    // Stronghold Border
				},
				new Point3D(1419, 1622, 20), // Faction JoinStone
				new Point3D(1330, 1621, 50), // Faction Management Stone
				new Point3D[]
				{
					new Point3D( 1328, 1627, 50 ), // Town Sigil Display
					new Point3D( 1328, 1621, 50 ), // Town Sigil Display
					new Point3D( 1334, 1627, 50 ), // Town Sigil Display
					new Point3D( 1334, 1621, 50 ), // Town Sigil Display
					new Point3D( 1340, 1627, 50 ), // Town Sigil Display
					new Point3D( 1340, 1621, 50 ), // Town Sigil Display
					new Point3D( 1345, 1621, 50 ), // Town Sigil Display
					new Point3D( 1345, 1627, 50 )  // Town Sigil Display
				}),
			new RankDefinition[]
			{
				new RankDefinition( 10, 991, 8, new TextDefinition( 1060794, "Knight of the Codex" ) ),
				new RankDefinition(  9, 950, 7, new TextDefinition( 1060793, "Knight of Virtue" ) ),
				new RankDefinition(  8, 900, 6, new TextDefinition( 1060792, "Crusader" ) ),
				new RankDefinition(  7, 800, 6, new TextDefinition( 1060792, "Crusader" ) ),
				new RankDefinition(  6, 700, 5, new TextDefinition( 1060791, "Sentinel" ) ),
				new RankDefinition(  5, 600, 5, new TextDefinition( 1060791, "Sentinel" ) ),
				new RankDefinition(  4, 500, 5, new TextDefinition( 1060791, "Sentinel" ) ),
				new RankDefinition(  3, 400, 4, new TextDefinition( 1060790, "Defender" ) ),
				new RankDefinition(  2, 200, 4, new TextDefinition( 1060790, "Defender" ) ),
				new RankDefinition(  1,   0, 4, new TextDefinition( 1060790, "Defender" ) )
			},
			new GuardDefinition[]
			{
				new GuardDefinition( typeof( FactionHenchman ),     0x1403, 5000, 1000, 10,     new TextDefinition( 1011526, "HENCHMAN" ),      new TextDefinition( 1011510, "Hire Henchman" ) ),
				new GuardDefinition( typeof( FactionMercenary ),    0x0F62, 6000, 2000, 10,     new TextDefinition( 1011527, "MERCENARY" ),     new TextDefinition( 1011511, "Hire Mercenary" ) ),
				new GuardDefinition( typeof( FactionKnight ),       0x0F4D, 7000, 3000, 10,     new TextDefinition( 1011528, "KNIGHT" ),        new TextDefinition( 1011497, "Hire Knight" ) ),
				new GuardDefinition( typeof( FactionPaladin ),      0x143F, 8000, 4000, 10,     new TextDefinition( 1011529, "PALADIN" ),       new TextDefinition( 1011498, "Hire Paladin" ) ),
			}
		);

		public TrueBritannians()
		{
			Instance = new();
		}
	}

	public sealed class Shadowlords : Faction
	{
		public static Shadowlords Instance { get; private set; }

		public override FactionDefinition Definition { get; } = new(
			3,
			FactionEthic.Evil,
			1109, // Primary Faction Hue: Shadow
			2211, // 2nd Faction Hue Hue: Green
			1109, // JoinStone Hue: Shadow
			2211, // Broadcast Hue: Green
			0x79, 0x3EB0, // War Horse: BodyValue, ItemID
			"Shadowlords", "shadow", "SL",
			new TextDefinition(1011537, "SHADOWLORDS"),
			new TextDefinition(1060772, "Shadowlords faction"),
			new TextDefinition(1011424, "<center>SHADES OF DARKNESS</center>"),
			new TextDefinition(1011451,
				"The Shadowlords are a faction that has sprung up within the ranks of " +
				"Minax. Comprised mostly of undead and those who would seek to be " +
				"necromancers, they pose a threat to both the sides of good and evil. " +
				"Their plans have disrupted the hold Minax has over Felucca, and their " +
				"ultimate goal is to destroy all life."),
			new TextDefinition(1011456, "This city is controlled by the Shadowlords."),
			new TextDefinition(1042255, "This sigil has been corrupted by the Shadowlords"),
			new TextDefinition(1041046, "The faction signup stone for the Shadowlords"),
			new TextDefinition(1041384, "The Faction Stone of the Shadowlords"),
			new TextDefinition(1011466, ": Shadowlords"),
			new TextDefinition(1005184, "Minions of the Shadowlords will now be ignored."),
			new TextDefinition(1005185, "Minions of the Shadowlords will now be warned of their impending deaths."),
			new TextDefinition(1005186, "Minions of the Shadowlords will now be attacked at will."),
			new StrongholdDefinition(
				new Poly2D[]
				{
					new Rectangle2D( 960, 688, 8, 9 ),  // Stronghold Border
					new Rectangle2D( 944, 697, 24, 23 ) // Stronghold Border
				},
				new Point3D(969, 768, 0), // Faction JoinStone
				new Point3D(947, 713, 0), // Faction Management Stone
				new Point3D[]
				{
					new Point3D( 953, 713, 20 ), // Town Sigil Display
					new Point3D( 953, 709, 20 ), // Town Sigil Display
					new Point3D( 953, 705, 20 ), // Town Sigil Display
					new Point3D( 953, 701, 20 ), // Town Sigil Display
					new Point3D( 957, 713, 20 ), // Town Sigil Display
					new Point3D( 957, 709, 20 ), // Town Sigil Display
					new Point3D( 957, 705, 20 ), // Town Sigil Display
					new Point3D( 957, 701, 20 )  // Town Sigil Display
				}),
			new RankDefinition[]
			{
				new RankDefinition( 10, 991, 8, new TextDefinition( 1060799, "Purveyor of Darkness" ) ),
				new RankDefinition(  9, 950, 7, new TextDefinition( 1060798, "Agent of Evil" ) ),
				new RankDefinition(  8, 900, 6, new TextDefinition( 1060797, "Bringer of Sorrow" ) ),
				new RankDefinition(  7, 800, 6, new TextDefinition( 1060797, "Bringer of Sorrow" ) ),
				new RankDefinition(  6, 700, 5, new TextDefinition( 1060796, "Keeper of Lies" ) ),
				new RankDefinition(  5, 600, 5, new TextDefinition( 1060796, "Keeper of Lies" ) ),
				new RankDefinition(  4, 500, 5, new TextDefinition( 1060796, "Keeper of Lies" ) ),
				new RankDefinition(  3, 400, 4, new TextDefinition( 1060795, "Servant" ) ),
				new RankDefinition(  2, 200, 4, new TextDefinition( 1060795, "Servant" ) ),
				new RankDefinition(  1,   0, 4, new TextDefinition( 1060795, "Servant" ) )
			},
			new GuardDefinition[]
			{
				new GuardDefinition( typeof( FactionHenchman ),     0x1403, 5000, 1000, 10,     new TextDefinition( 1011526, "HENCHMAN" ),      new TextDefinition( 1011510, "Hire Henchman" ) ),
				new GuardDefinition( typeof( FactionMercenary ),    0x0F62, 6000, 2000, 10,     new TextDefinition( 1011527, "MERCENARY" ),     new TextDefinition( 1011511, "Hire Mercenary" ) ),
				new GuardDefinition( typeof( FactionDeathKnight ),  0x0F45, 7000, 3000, 10,     new TextDefinition( 1011512, "DEATH KNIGHT" ),  new TextDefinition( 1011503, "Hire Death Knight" ) ),
				new GuardDefinition( typeof( FactionNecromancer ),  0x13F8, 8000, 4000, 10,     new TextDefinition( 1011513, "SHADOW MAGE" ),   new TextDefinition( 1011504, "Hire Shadow Mage" ) ),
			}
		);

		public Shadowlords()
		{
			Instance = new();
		}
	}
}
#endif