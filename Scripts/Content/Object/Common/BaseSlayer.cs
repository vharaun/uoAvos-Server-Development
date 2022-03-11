using Server.Mobiles;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	public interface ISlayer
	{
		SlayerName Slayer { get; set; }
		SlayerName Slayer2 { get; set; }
	}

	public enum SlayerName
	{
		None,
		Silver,
		OrcSlaying,
		TrollSlaughter,
		OgreTrashing,
		Repond,
		DragonSlaying,
		Terathan,
		SnakesBane,
		LizardmanSlaughter,
		ReptilianDeath,
		DaemonDismissal,
		GargoylesFoe,
		BalronDamnation,
		Exorcism,
		Ophidian,
		SpidersDeath,
		ScorpionsBane,
		ArachnidDoom,
		FlameDousing,
		WaterDissipation,
		Vacuum,
		ElementalHealth,
		EarthShatter,
		BloodDrinking,
		SummerWind,
		ElementalBan, // Bane?
		Fey
	}

	public enum CheckSlayerResult
	{
		None,
		Slayer,
		Opposition
	}

	public class SlayerEntry
	{
		private SlayerGroup m_Group;
		private readonly SlayerName m_Name;
		private readonly Type[] m_Types;

		public SlayerGroup Group { get => m_Group; set => m_Group = value; }
		public SlayerName Name => m_Name;
		public Type[] Types => m_Types;

		private static readonly int[] m_AosTitles = new int[]
			{
				1060479, // undead slayer
				1060470, // orc slayer
				1060480, // troll slayer
				1060468, // ogre slayer
				1060472, // repond slayer
				1060462, // dragon slayer
				1060478, // terathan slayer
				1060475, // snake slayer
				1060467, // lizardman slayer
				1060473, // reptile slayer
				1060460, // demon slayer
				1060466, // gargoyle slayer
				1017396, // Balron Damnation
				1060461, // demon slayer
				1060469, // ophidian slayer
				1060477, // spider slayer
				1060474, // scorpion slayer
				1060458, // arachnid slayer
				1060465, // fire elemental slayer
				1060481, // water elemental slayer
				1060457, // air elemental slayer
				1060471, // poison elemental slayer
				1060463, // earth elemental slayer
				1060459, // blood elemental slayer
				1060476, // snow elemental slayer
				1060464, // elemental slayer
				1070855  // fey slayer
			};

		private static readonly int[] m_OldTitles = new int[]
			{
				1017384, // Silver
				1017385, // Orc Slaying
				1017386, // Troll Slaughter
				1017387, // Ogre Thrashing
				1017388, // Repond
				1017389, // Dragon Slaying
				1017390, // Terathan
				1017391, // Snake's Bane
				1017392, // Lizardman Slaughter
				1017393, // Reptilian Death
				1017394, // Daemon Dismissal
				1017395, // Gargoyle's Foe
				1017396, // Balron Damnation
				1017397, // Exorcism
				1017398, // Ophidian
				1017399, // Spider's Death
				1017400, // Scorpion's Bane
				1017401, // Arachnid Doom
				1017402, // Flame Dousing
				1017403, // Water Dissipation
				1017404, // Vacuum
				1017405, // Elemental Health
				1017406, // Earth Shatter
				1017407, // Blood Drinking
				1017408, // Summer Wind
				1017409, // Elemental Ban
				1070855  // fey slayer
			};

		public int Title
		{
			get
			{
				var titles = (Core.AOS ? m_AosTitles : m_OldTitles);

				return titles[(int)m_Name - 1];
			}
		}

		public SlayerEntry(SlayerName name, params Type[] types)
		{
			m_Name = name;
			m_Types = types;
		}

		public bool Slays(Mobile m)
		{
			var t = m.GetType();

			for (var i = 0; i < m_Types.Length; ++i)
			{
				if (m_Types[i].IsAssignableFrom(t))
				{
					return true;
				}
			}

			return false;
		}
	}

	public class SlayerGroup
	{
		private static readonly SlayerEntry[] m_TotalEntries;
		private static readonly SlayerGroup[] m_Groups;

		public static SlayerEntry[] TotalEntries => m_TotalEntries;

		public static SlayerGroup[] Groups => m_Groups;

		public static SlayerEntry GetEntryByName(SlayerName name)
		{
			var v = (int)name;

			if (v >= 0 && v < m_TotalEntries.Length)
			{
				return m_TotalEntries[v];
			}

			return null;
		}

		public static SlayerName GetLootSlayerType(Type type)
		{
			for (var i = 0; i < m_Groups.Length; ++i)
			{
				var group = m_Groups[i];
				var foundOn = group.FoundOn;

				var inGroup = false;

				for (var j = 0; foundOn != null && !inGroup && j < foundOn.Length; ++j)
				{
					inGroup = (foundOn[j] == type);
				}

				if (inGroup)
				{
					var index = Utility.Random(1 + group.Entries.Length);

					if (index == 0)
					{
						return group.m_Super.Name;
					}

					return group.Entries[index - 1].Name;
				}
			}

			return SlayerName.Silver;
		}

		static SlayerGroup()
		{
			var humanoid = new SlayerGroup();
			var undead = new SlayerGroup();
			var elemental = new SlayerGroup();
			var abyss = new SlayerGroup();
			var arachnid = new SlayerGroup();
			var reptilian = new SlayerGroup();
			var fey = new SlayerGroup();

			humanoid.Opposition = new SlayerGroup[] { undead };
			humanoid.FoundOn = new Type[] { typeof(BoneKnight), typeof(Lich), typeof(LichLord) };
			humanoid.Super = new SlayerEntry(SlayerName.Repond, typeof(ArcticOgreLord), typeof(Cyclops), typeof(Ettin), typeof(EvilMage), typeof(EvilMageLord), typeof(FrostTroll), typeof(MeerCaptain), typeof(MeerEternal), typeof(MeerMage), typeof(MeerWarrior), typeof(Ogre), typeof(OgreLord), typeof(Orc), typeof(OrcBomber), typeof(OrcBrute), typeof(OrcCaptain), /*typeof( OrcChopper ), typeof( OrcScout ),*/ typeof(OrcishLord), typeof(OrcishMage), typeof(Ratman), typeof(RatmanArcher), typeof(RatmanMage), typeof(SavageRider), typeof(SavageShaman), typeof(Savage), typeof(Titan), typeof(Troglodyte), typeof(Troll));
			humanoid.Entries = new SlayerEntry[]
				{
					new SlayerEntry( SlayerName.OgreTrashing, typeof( Ogre ), typeof( OgreLord ), typeof( ArcticOgreLord ) ),
					new SlayerEntry( SlayerName.OrcSlaying, typeof( Orc ), typeof( OrcBomber ), typeof( OrcBrute ), typeof( OrcCaptain ),/* typeof( OrcChopper ), typeof( OrcScout ),*/ typeof( OrcishLord ), typeof( OrcishMage ) ),
					new SlayerEntry( SlayerName.TrollSlaughter, typeof( Troll ), typeof( FrostTroll ) )
				};

			undead.Opposition = new SlayerGroup[] { humanoid };
			undead.Super = new SlayerEntry(SlayerName.Silver, typeof(AncientLich), typeof(Bogle), typeof(BoneKnight), typeof(BoneMagi),/* typeof( DarkGuardian ), */typeof(DarknightCreeper), typeof(FleshGolem), typeof(Ghoul), typeof(GoreFiend), typeof(HellSteed), typeof(LadyOfTheSnow), typeof(Lich), typeof(LichLord), typeof(Mummy), typeof(PestilentBandage), typeof(Revenant), typeof(RevenantLion), typeof(RottingCorpse), typeof(Shade), typeof(ShadowKnight), typeof(SkeletalKnight), typeof(SkeletalMage), typeof(SkeletalMount), typeof(Skeleton), typeof(Spectre), typeof(Wraith), typeof(Zombie));
			undead.Entries = new SlayerEntry[0];

			fey.Opposition = new SlayerGroup[] { abyss };
			fey.Super = new SlayerEntry(SlayerName.Fey, typeof(Centaur), typeof(CuSidhe), typeof(EtherealWarrior), typeof(Kirin), typeof(LordOaks), typeof(Pixie), typeof(Silvani), typeof(Treefellow), typeof(Unicorn), typeof(Wisp), typeof(MLDryad), typeof(Satyr));
			fey.Entries = new SlayerEntry[0];

			elemental.Opposition = new SlayerGroup[] { abyss };
			elemental.FoundOn = new Type[] { typeof(Balron), typeof(Daemon) };
			elemental.Super = new SlayerEntry(SlayerName.ElementalBan, typeof(AcidElemental), typeof(AgapiteElemental), typeof(AirElemental), typeof(SummonedAirElemental), typeof(BloodElemental), typeof(BronzeElemental), typeof(CopperElemental), typeof(CrystalElemental), typeof(DullCopperElemental), typeof(EarthElemental), typeof(SummonedEarthElemental), typeof(Efreet), typeof(FireElemental), typeof(SummonedFireElemental), typeof(GoldenElemental), typeof(IceElemental), typeof(KazeKemono), typeof(PoisonElemental), typeof(RaiJu), typeof(SandVortex), typeof(ShadowIronElemental), typeof(SnowElemental), typeof(ValoriteElemental), typeof(VeriteElemental), typeof(WaterElemental), typeof(SummonedWaterElemental));
			elemental.Entries = new SlayerEntry[]
				{
					new SlayerEntry( SlayerName.BloodDrinking, typeof( BloodElemental ) ),
					new SlayerEntry( SlayerName.EarthShatter, typeof( AgapiteElemental ), typeof( BronzeElemental ), typeof( CopperElemental ), typeof( DullCopperElemental ), typeof( EarthElemental ), typeof( SummonedEarthElemental ), typeof( GoldenElemental ), typeof( ShadowIronElemental ), typeof( ValoriteElemental ), typeof( VeriteElemental ) ),
					new SlayerEntry( SlayerName.ElementalHealth, typeof( PoisonElemental ) ),
					new SlayerEntry( SlayerName.FlameDousing, typeof( FireElemental ), typeof( SummonedFireElemental ) ),
					new SlayerEntry( SlayerName.SummerWind, typeof( SnowElemental ), typeof( IceElemental ) ),
					new SlayerEntry( SlayerName.Vacuum, typeof( AirElemental ), typeof( SummonedAirElemental ) ),
					new SlayerEntry( SlayerName.WaterDissipation, typeof( WaterElemental ), typeof( SummonedWaterElemental ) )
				};

			abyss.Opposition = new SlayerGroup[] { elemental, fey };
			abyss.FoundOn = new Type[] { typeof(BloodElemental) };

			if (Core.AOS)
			{
				abyss.Super = new SlayerEntry(SlayerName.Exorcism, typeof(AbysmalHorror), typeof(ArcaneDaemon), typeof(Balron), typeof(BoneDemon), typeof(ChaosDaemon), typeof(Daemon), typeof(SummonedDaemon), typeof(DemonKnight), typeof(Devourer), typeof(EnslavedGargoyle), typeof(FanDancer), typeof(FireGargoyle), typeof(Gargoyle), typeof(GargoyleDestroyer), typeof(GargoyleEnforcer), typeof(Gibberling), typeof(HordeMinion), typeof(IceFiend), typeof(Imp), typeof(Impaler), typeof(Moloch), typeof(Oni), typeof(Ravager), typeof(Semidar), typeof(StoneGargoyle), typeof(Succubus), typeof(TsukiWolf));

				abyss.Entries = new SlayerEntry[]
					{
						// Daemon Dismissal & Balron Damnation have been removed and moved up to super slayer on OSI.
						new SlayerEntry( SlayerName.GargoylesFoe, typeof( EnslavedGargoyle ), typeof( FireGargoyle ), typeof( Gargoyle ), typeof( GargoyleDestroyer ), typeof( GargoyleEnforcer ), typeof( StoneGargoyle ) ),
					};
			}
			else
			{
				abyss.Super = new SlayerEntry(SlayerName.Exorcism, typeof(AbysmalHorror), typeof(Balron), typeof(BoneDemon), typeof(ChaosDaemon), typeof(Daemon), typeof(SummonedDaemon), typeof(DemonKnight), typeof(Devourer), typeof(Gargoyle), typeof(FireGargoyle), typeof(Gibberling), typeof(HordeMinion), typeof(IceFiend), typeof(Imp), typeof(Impaler), typeof(Ravager), typeof(StoneGargoyle), typeof(ArcaneDaemon), typeof(EnslavedGargoyle), typeof(GargoyleDestroyer), typeof(GargoyleEnforcer), typeof(Moloch));

				abyss.Entries = new SlayerEntry[]
					{
						new SlayerEntry( SlayerName.DaemonDismissal, typeof( AbysmalHorror ), typeof( Balron ), typeof( BoneDemon ), typeof( ChaosDaemon ), typeof( Daemon ), typeof( SummonedDaemon ), typeof( DemonKnight ), typeof( Devourer ), typeof( Gibberling ), typeof( HordeMinion ), typeof( IceFiend ), typeof( Imp ), typeof( Impaler ), typeof( Ravager ), typeof( ArcaneDaemon ), typeof( Moloch ) ),
						new SlayerEntry( SlayerName.GargoylesFoe, typeof( FireGargoyle ), typeof( Gargoyle ), typeof( StoneGargoyle ), typeof( EnslavedGargoyle ), typeof( GargoyleDestroyer ), typeof( GargoyleEnforcer ) ),
						new SlayerEntry( SlayerName.BalronDamnation, typeof( Balron ) )
					};
			}

			arachnid.Opposition = new SlayerGroup[] { reptilian };
			arachnid.FoundOn = new Type[] { typeof(AncientWyrm), typeof(GreaterDragon), typeof(Dragon), typeof(OphidianMatriarch), typeof(ShadowWyrm) };
			arachnid.Super = new SlayerEntry(SlayerName.ArachnidDoom, typeof(DreadSpider), typeof(FrostSpider), typeof(GiantBlackWidow), typeof(GiantSpider), typeof(Mephitis), typeof(Scorpion), typeof(TerathanAvenger), typeof(TerathanDrone), typeof(TerathanMatriarch), typeof(TerathanWarrior));
			arachnid.Entries = new SlayerEntry[]
				{
					new SlayerEntry( SlayerName.ScorpionsBane, typeof( Scorpion ) ),
					new SlayerEntry( SlayerName.SpidersDeath, typeof( DreadSpider ), typeof( FrostSpider ), typeof( GiantBlackWidow ), typeof( GiantSpider ), typeof( Mephitis ) ),
					new SlayerEntry( SlayerName.Terathan, typeof( TerathanAvenger ), typeof( TerathanDrone ), typeof( TerathanMatriarch ), typeof( TerathanWarrior ) )
				};

			reptilian.Opposition = new SlayerGroup[] { arachnid };
			reptilian.FoundOn = new Type[] { typeof(TerathanAvenger), typeof(TerathanMatriarch) };
			reptilian.Super = new SlayerEntry(SlayerName.ReptilianDeath, typeof(AncientWyrm), typeof(DeepSeaSerpent), typeof(GreaterDragon), typeof(Dragon), typeof(Drake), typeof(GiantIceWorm), typeof(IceSerpent), typeof(GiantSerpent), typeof(Hiryu), typeof(IceSnake), typeof(JukaLord), typeof(JukaMage), typeof(JukaWarrior), typeof(LavaSerpent), typeof(LavaSnake), typeof(LesserHiryu), typeof(Lizardman), typeof(OphidianArchmage), typeof(OphidianKnight), typeof(OphidianMage), typeof(OphidianMatriarch), typeof(OphidianWarrior), typeof(Reptalon), typeof(SeaSerpent), typeof(Serado), typeof(SerpentineDragon), typeof(ShadowWyrm), typeof(SilverSerpent), typeof(SkeletalDragon), typeof(Snake), typeof(SwampDragon), typeof(WhiteWyrm), typeof(Wyvern), typeof(Yamandon));
			reptilian.Entries = new SlayerEntry[]
				{
					new SlayerEntry( SlayerName.DragonSlaying, typeof( AncientWyrm ), typeof( GreaterDragon ), typeof( Dragon ), typeof( Drake ), typeof( Hiryu ), typeof( LesserHiryu ), typeof( Reptalon ), typeof( SerpentineDragon ), typeof( ShadowWyrm ), typeof( SkeletalDragon ), typeof( SwampDragon ), typeof( WhiteWyrm ), typeof( Wyvern ) ),
					new SlayerEntry( SlayerName.LizardmanSlaughter, typeof( Lizardman ) ),
					new SlayerEntry( SlayerName.Ophidian, typeof( OphidianArchmage ), typeof( OphidianKnight ), typeof( OphidianMage ), typeof( OphidianMatriarch ), typeof( OphidianWarrior ) ),
					new SlayerEntry( SlayerName.SnakesBane, typeof( DeepSeaSerpent ), typeof( GiantIceWorm ), typeof( GiantSerpent ), typeof( IceSerpent ), typeof( IceSnake ), typeof( LavaSerpent ), typeof( LavaSnake ), typeof( SeaSerpent ), typeof( Serado ), typeof( SilverSerpent ), typeof( Snake ), typeof( Yamandon ) )
				};

			m_Groups = new SlayerGroup[]
				{
					humanoid,
					undead,
					elemental,
					abyss,
					arachnid,
					reptilian,
					fey
				};

			m_TotalEntries = CompileEntries(m_Groups);
		}

		private static SlayerEntry[] CompileEntries(SlayerGroup[] groups)
		{
			var entries = new SlayerEntry[28];

			for (var i = 0; i < groups.Length; ++i)
			{
				var g = groups[i];

				g.Super.Group = g;

				entries[(int)g.Super.Name] = g.Super;

				for (var j = 0; j < g.Entries.Length; ++j)
				{
					g.Entries[j].Group = g;
					entries[(int)g.Entries[j].Name] = g.Entries[j];
				}
			}

			return entries;
		}

		private SlayerGroup[] m_Opposition;
		private SlayerEntry m_Super;
		private SlayerEntry[] m_Entries;
		private Type[] m_FoundOn;

		public SlayerGroup[] Opposition { get => m_Opposition; set => m_Opposition = value; }
		public SlayerEntry Super { get => m_Super; set => m_Super = value; }
		public SlayerEntry[] Entries { get => m_Entries; set => m_Entries = value; }
		public Type[] FoundOn { get => m_FoundOn; set => m_FoundOn = value; }

		public bool OppositionSuperSlays(Mobile m)
		{
			for (var i = 0; i < Opposition.Length; i++)
			{
				if (Opposition[i].Super.Slays(m))
				{
					return true;
				}
			}

			return false;
		}

		public SlayerGroup()
		{
		}
	}

	public enum TalismanSlayerName
	{
		None,
		Bear,
		Vermin,
		Bat,
		Mage,
		Beetle,
		Bird,
		Ice,
		Flame,
		Bovine
	}

	public static class TalismanSlayer
	{
		private static readonly Dictionary<TalismanSlayerName, Type[]> m_Table = new Dictionary<TalismanSlayerName, Type[]>();

		public static void Initialize()
		{
			m_Table[TalismanSlayerName.Bear] = new Type[]
			{
				typeof( GrizzlyBear ), typeof( BlackBear ), typeof( BrownBear ), typeof( PolarBear ) //, typeof( Grobu )
			};

			m_Table[TalismanSlayerName.Vermin] = new Type[]
			{
				typeof( RatmanMage ), typeof( RatmanMage ), typeof( RatmanArcher ), typeof( Barracoon),
				typeof( Ratman ), typeof( Sewerrat ), typeof( Rat ), typeof( GiantRat ) //, typeof( Chiikkaha )
			};

			m_Table[TalismanSlayerName.Bat] = new Type[]
			{
				typeof( Mongbat ), typeof( StrongMongbat ), typeof( VampireBat )
			};

			m_Table[TalismanSlayerName.Mage] = new Type[]
			{
				typeof( EvilMage ), typeof( EvilMageLord ), typeof( AncientLich ), typeof( Lich ), typeof( LichLord ),
				typeof( SkeletalMage ), typeof( BoneMagi ), typeof( OrcishMage ), typeof( KhaldunZealot ), typeof( JukaMage ),
			};

			m_Table[TalismanSlayerName.Beetle] = new Type[]
			{
				typeof( Beetle ), typeof( RuneBeetle ), typeof( FireBeetle ), typeof( DeathwatchBeetle ),
				typeof( DeathwatchBeetleHatchling )
			};

			m_Table[TalismanSlayerName.Bird] = new Type[]
			{
				typeof( Bird ), typeof( TropicalBird ), typeof( Chicken ), typeof( Crane ),
				typeof( DesertOstard ), typeof( Eagle ), typeof( ForestOstard ), typeof( FrenziedOstard ),
				typeof( Phoenix ), /*typeof( Pyre ), typeof( Swoop ), typeof( Saliva ),*/ typeof( Harpy ),
				typeof( StoneHarpy ) // ?????
			};

			m_Table[TalismanSlayerName.Ice] = new Type[]
			{
				typeof( ArcticOgreLord ), typeof( IceElemental ), typeof( SnowElemental ), typeof( FrostOoze ),
				typeof( IceFiend ), /*typeof( UnfrozenMummy ),*/ typeof( FrostSpider ), typeof( LadyOfTheSnow ),
				typeof( FrostTroll ),

				  // TODO WinterReaper, check
				typeof( IceSnake ), typeof( SnowLeopard ), typeof( PolarBear ),  typeof( IceSerpent ), typeof( GiantIceWorm )
			};

			m_Table[TalismanSlayerName.Flame] = new Type[]
			{
				typeof( FireBeetle ), typeof( HellHound ), typeof( LavaSerpent ), typeof( FireElemental ),
				typeof( PredatorHellCat ), typeof( Phoenix ), typeof( FireGargoyle ), typeof( HellCat ),
				/*typeof( Pyre ),*/ typeof( FireSteed ), typeof( LavaLizard ),

				// TODO check
				typeof( LavaSnake ),
			};

			m_Table[TalismanSlayerName.Bovine] = new Type[]
			{
				typeof( Cow ), typeof( Bull ), typeof( Gaman ) /*, typeof( MinotaurCaptain ),
				typeof( MinotaurScout ), typeof( Minotaur )*/

				// TODO TormentedMinotaur
			};
		}

		public static bool Slays(TalismanSlayerName name, Mobile m)
		{
			if (!m_Table.ContainsKey(name))
			{
				return false;
			}

			var types = m_Table[name];

			if (types == null || m == null)
			{
				return false;
			}

			var type = m.GetType();

			for (var i = 0; i < types.Length; i++)
			{
				if (types[i].IsAssignableFrom(type))
				{
					return true;
				}
			}

			return false;
		}
	}
}