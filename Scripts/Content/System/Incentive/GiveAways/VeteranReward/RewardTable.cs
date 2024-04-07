using Server.Items;
using Server.Mobiles;

namespace Server.Engines.VeteranRewards
{
	public partial class RewardSystem
	{
		public static void SetupRewardTables()
		{
			var monsterStatues = new RewardCategory(1049750);
			var cloaksAndRobes = new RewardCategory(1049752);
			var etherealSteeds = new RewardCategory(1049751);
			var specialDyeTubs = new RewardCategory(1049753);
			var houseAddOns = new RewardCategory(1049754);
			var miscellaneous = new RewardCategory(1078596);

			m_Categories = new RewardCategory[]
				{
					monsterStatues,
					cloaksAndRobes,
					etherealSteeds,
					specialDyeTubs,
					houseAddOns,
					miscellaneous
				};

			const int Bronze = 0x972;
			const int Copper = 0x96D;
			const int Golden = 0x8A5;
			const int Agapite = 0x979;
			const int Verite = 0x89F;
			const int Valorite = 0x8AB;
			const int IceGreen = 0x47F;
			const int IceBlue = 0x482;
			const int DarkGray = 0x497;
			const int Fire = 0x489;
			const int IceWhite = 0x47E;
			const int JetBlack = 0x001;
			const int Pink = 0x490;
			const int Crimson = 0x485;

			m_Lists = new RewardList[]
			{
                #region Year 01 Veteran Rewards

                new RewardList( RewardInterval, 1, new RewardEntry[]
					{
						new RewardEntry( specialDyeTubs, 1006008, typeof( RewardBlackDyeTub ) ),
						new RewardEntry( specialDyeTubs, 1006013, typeof( FurnitureDyeTub ) ),
						new RewardEntry( specialDyeTubs, 1006047, typeof( SpecialDyeTub ) ),
						new RewardEntry( cloaksAndRobes, 1006009, typeof( RewardCloak ), Bronze, 1041286 ),
						new RewardEntry( cloaksAndRobes, 1006010, typeof( RewardRobe ), Bronze, 1041287 ),
						new RewardEntry( cloaksAndRobes, 1080366, typeof( RewardDress ), Expansion.ML, Bronze, 1080366 ),
						new RewardEntry( cloaksAndRobes, 1006011, typeof( RewardCloak ), Copper, 1041288 ),
						new RewardEntry( cloaksAndRobes, 1006012, typeof( RewardRobe ), Copper, 1041289 ),
						new RewardEntry( cloaksAndRobes, 1080367, typeof( RewardDress ), Expansion.ML, Copper, 1080367 ),
						new RewardEntry( monsterStatues, 1006024, typeof( MonsterStatuette ), MonsterStatuetteType.Crocodile ),
						new RewardEntry( monsterStatues, 1006025, typeof( MonsterStatuette ), MonsterStatuetteType.Daemon ),
						new RewardEntry( monsterStatues, 1006026, typeof( MonsterStatuette ), MonsterStatuetteType.Dragon ),
						new RewardEntry( monsterStatues, 1006027, typeof( MonsterStatuette ), MonsterStatuetteType.EarthElemental ),
						new RewardEntry( monsterStatues, 1006028, typeof( MonsterStatuette ), MonsterStatuetteType.Ettin ),
						new RewardEntry( monsterStatues, 1006029, typeof( MonsterStatuette ), MonsterStatuetteType.Gargoyle ),
						new RewardEntry( monsterStatues, 1006030, typeof( MonsterStatuette ), MonsterStatuetteType.Gorilla ),
						new RewardEntry( monsterStatues, 1006031, typeof( MonsterStatuette ), MonsterStatuetteType.Lich ),
						new RewardEntry( monsterStatues, 1006032, typeof( MonsterStatuette ), MonsterStatuetteType.Lizardman ),
						new RewardEntry( monsterStatues, 1006033, typeof( MonsterStatuette ), MonsterStatuetteType.Ogre ),
						new RewardEntry( monsterStatues, 1006034, typeof( MonsterStatuette ), MonsterStatuetteType.Orc ),
						new RewardEntry( monsterStatues, 1006035, typeof( MonsterStatuette ), MonsterStatuetteType.Ratman ),
						new RewardEntry( monsterStatues, 1006036, typeof( MonsterStatuette ), MonsterStatuetteType.Skeleton ),
						new RewardEntry( monsterStatues, 1006037, typeof( MonsterStatuette ), MonsterStatuetteType.Troll ),
						new RewardEntry( houseAddOns,    1062692, typeof( ContestMiniHouseDeed ), Expansion.AOS, MiniHouseType.MalasMountainPass ),
						new RewardEntry( houseAddOns,    1072216, typeof( ContestMiniHouseDeed ), Expansion.SE, MiniHouseType.ChurchAtNight ),
						new RewardEntry( miscellaneous,  1076155, typeof( RedSoulstone ), Expansion.ML ),
						new RewardEntry( miscellaneous,  1080523, typeof( CommodityDeedBox ), Expansion.ML ),
					} ),

                #endregion

                #region Year 02 Veteran Rewards

                new RewardList( RewardInterval, 2, new RewardEntry[]
					{
						new RewardEntry( specialDyeTubs, 1006052, typeof( LeatherDyeTub ) ),
						new RewardEntry( cloaksAndRobes, 1006014, typeof( RewardCloak ), Agapite, 1041290 ),
						new RewardEntry( cloaksAndRobes, 1006015, typeof( RewardRobe ), Agapite, 1041291 ),
						new RewardEntry( cloaksAndRobes, 1080369, typeof( RewardDress ), Expansion.ML, Agapite, 1080369 ),
						new RewardEntry( cloaksAndRobes, 1006016, typeof( RewardCloak ), Golden, 1041292 ),
						new RewardEntry( cloaksAndRobes, 1006017, typeof( RewardRobe ), Golden, 1041293 ),
						new RewardEntry( cloaksAndRobes, 1080368, typeof( RewardDress ), Expansion.ML, Golden, 1080368 ),
						new RewardEntry( houseAddOns,    1006048, typeof( BannerDeed ) ),
						new RewardEntry( houseAddOns,    1006049, typeof( FlamingHeadDeed ) ),
						new RewardEntry( houseAddOns,    1080409, typeof( MinotaurStatueDeed ), Expansion.ML )
					} ),

                #endregion

                #region Year 03 Veteran Rewards

                new RewardList( RewardInterval, 3, new RewardEntry[]
					{
						new RewardEntry( cloaksAndRobes, 1006020, typeof( RewardCloak ), Verite, 1041294 ),
						new RewardEntry( cloaksAndRobes, 1006021, typeof( RewardRobe ), Verite, 1041295 ),
						new RewardEntry( cloaksAndRobes, 1080370, typeof( RewardDress ), Expansion.ML, Verite, 1080370 ),
						new RewardEntry( cloaksAndRobes, 1006022, typeof( RewardCloak ), Valorite, 1041296 ),
						new RewardEntry( cloaksAndRobes, 1006023, typeof( RewardRobe ), Valorite, 1041297 ),
						new RewardEntry( cloaksAndRobes, 1080371, typeof( RewardDress ), Expansion.ML, Valorite, 1080371 ),
						new RewardEntry( monsterStatues, 1006038, typeof( MonsterStatuette ), MonsterStatuetteType.Cow ),
						new RewardEntry( monsterStatues, 1006039, typeof( MonsterStatuette ), MonsterStatuetteType.Zombie ),
						new RewardEntry( monsterStatues, 1006040, typeof( MonsterStatuette ), MonsterStatuetteType.Llama ),
						new RewardEntry( etherealSteeds, 1006019, typeof( EtherealHorse ) ),
						new RewardEntry( etherealSteeds, 1006050, typeof( EtherealOstard ) ),
						new RewardEntry( etherealSteeds, 1006051, typeof( EtherealLlama ) ),
						new RewardEntry( houseAddOns,    1080407, typeof( PottedCactusDeed ), Expansion.ML )

					} ),

                #endregion

                #region Year 04 Veteran Rewards

                new RewardList( RewardInterval, 4, new RewardEntry[]
					{
						new RewardEntry( specialDyeTubs, 1049740, typeof( RunebookDyeTub ) ),
						new RewardEntry( cloaksAndRobes, 1049725, typeof( RewardCloak ), DarkGray, 1049757 ),
						new RewardEntry( cloaksAndRobes, 1049726, typeof( RewardRobe ), DarkGray, 1049756 ),
						new RewardEntry( cloaksAndRobes, 1080374, typeof( RewardDress ), Expansion.ML, DarkGray, 1080374 ),
						new RewardEntry( cloaksAndRobes, 1049727, typeof( RewardCloak ), IceGreen, 1049759 ),
						new RewardEntry( cloaksAndRobes, 1049728, typeof( RewardRobe ), IceGreen, 1049758 ),
						new RewardEntry( cloaksAndRobes, 1080372, typeof( RewardDress ), Expansion.ML, IceGreen, 1080372 ),

						new RewardEntry( cloaksAndRobes, 1049729, typeof( RewardCloak ), IceBlue, 1049761 ),
						new RewardEntry( cloaksAndRobes, 1049730, typeof( RewardRobe ), IceBlue, 1049760 ),
						new RewardEntry( cloaksAndRobes, 1080373, typeof( RewardDress ), Expansion.ML, IceBlue, 1080373 ),
						new RewardEntry( monsterStatues, 1049742, typeof( MonsterStatuette ), MonsterStatuetteType.Ophidian ),
						new RewardEntry( monsterStatues, 1049743, typeof( MonsterStatuette ), MonsterStatuetteType.Reaper ),
						new RewardEntry( monsterStatues, 1049744, typeof( MonsterStatuette ), MonsterStatuetteType.Mongbat ),
						new RewardEntry( etherealSteeds, 1049746, typeof( EtherealKirin ) ),
						new RewardEntry( etherealSteeds, 1049745, typeof( EtherealUnicorn ) ),
						new RewardEntry( etherealSteeds, 1049747, typeof( EtherealRidgeback ) ),
						new RewardEntry( houseAddOns,    1049737, typeof( DecorativeShieldDeed ) ),
						new RewardEntry( houseAddOns,    1049738, typeof( HangingSkeletonDeed ) )
					} ),

                #endregion

                #region Year 05 Veteran Rewards

                new RewardList( RewardInterval, 5, new RewardEntry[]
					{
						new RewardEntry( specialDyeTubs, 1049741, typeof( StatuetteDyeTub ) ),
						new RewardEntry( cloaksAndRobes, 1049731, typeof( RewardCloak ), JetBlack, 1049763 ),
						new RewardEntry( cloaksAndRobes, 1049732, typeof( RewardRobe ), JetBlack, 1049762 ),
						new RewardEntry( cloaksAndRobes, 1080377, typeof( RewardDress ), Expansion.ML, JetBlack, 1080377 ),
						new RewardEntry( cloaksAndRobes, 1049733, typeof( RewardCloak ), IceWhite, 1049765 ),
						new RewardEntry( cloaksAndRobes, 1049734, typeof( RewardRobe ), IceWhite, 1049764 ),
						new RewardEntry( cloaksAndRobes, 1080376, typeof( RewardDress ), Expansion.ML, IceWhite, 1080376 ),
						new RewardEntry( cloaksAndRobes, 1049735, typeof( RewardCloak ), Fire, 1049767 ),
						new RewardEntry( cloaksAndRobes, 1049736, typeof( RewardRobe ), Fire, 1049766 ),
						new RewardEntry( cloaksAndRobes, 1080375, typeof( RewardDress ), Expansion.ML, Fire, 1080375 ),
						new RewardEntry( monsterStatues, 1049768, typeof( MonsterStatuette ), MonsterStatuetteType.Gazer ),
						new RewardEntry( monsterStatues, 1049769, typeof( MonsterStatuette ), MonsterStatuetteType.FireElemental ),
						new RewardEntry( monsterStatues, 1049770, typeof( MonsterStatuette ), MonsterStatuetteType.Wolf ),
						new RewardEntry( etherealSteeds, 1049749, typeof( EtherealSwampDragon ) ),
						new RewardEntry( etherealSteeds, 1049748, typeof( EtherealBeetle ) ),
						new RewardEntry( houseAddOns,    1049739, typeof( StoneAnkhDeed ) ),
						new RewardEntry( houseAddOns,    1080384, typeof( BloodyPentagramDeed ), Expansion.ML )
					} ),

                #endregion

                #region Year 06 Veteran Rewards

                new RewardList( RewardInterval, 6, new RewardEntry[]
					{
						new RewardEntry( houseAddOns,   1076188, typeof( CharacterStatueMaker ), Expansion.ML, StatueType.Jade ),
						new RewardEntry( houseAddOns,   1076189, typeof( CharacterStatueMaker ), Expansion.ML, StatueType.Marble ),
						new RewardEntry( houseAddOns,   1076190, typeof( CharacterStatueMaker ), Expansion.ML, StatueType.Bronze ),
						new RewardEntry( houseAddOns,   1080527, typeof( RewardBrazierDeed ), Expansion.ML )
					} ),

                #endregion

                #region Year 07 Veteran Rewards

                new RewardList( RewardInterval, 7, new RewardEntry[]
					{
						new RewardEntry( houseAddOns,   1076157, typeof( CannonDeed ), Expansion.ML ),
						new RewardEntry( houseAddOns,   1080550, typeof( TreeStumpDeed ), Expansion.ML )
					} ),

                #endregion

                #region Year 08 Veteran Rewards

                new RewardList( RewardInterval, 8, new RewardEntry[]
					{
						new RewardEntry( miscellaneous, 1076158, typeof( EngravingTool ), Expansion.ML )
					} ),

                #endregion

                #region Year 09 Veteran Rewards

                new RewardList( RewardInterval, 9, new RewardEntry[]
					{
						new RewardEntry( etherealSteeds,    1076159, typeof( RideablePolarBear ), Expansion.ML ),
						new RewardEntry( houseAddOns,       1080549, typeof( WallBannerDeed ), Expansion.ML )
					} ),

                #endregion

                #region Year 10 Veteran Rewards

                new RewardList( RewardInterval, 10, new RewardEntry[]
					{
						new RewardEntry( monsterStatues,    1080520, typeof( MonsterStatuette ), Expansion.ML, MonsterStatuetteType.Harrower ),
						new RewardEntry( monsterStatues,    1080521, typeof( MonsterStatuette ), Expansion.ML, MonsterStatuetteType.Efreet ),

						new RewardEntry( cloaksAndRobes,    1080382, typeof( RewardCloak ), Expansion.ML, Pink, 1080382 ),
						new RewardEntry( cloaksAndRobes,    1080380, typeof( RewardRobe ), Expansion.ML, Pink, 1080380 ),
						new RewardEntry( cloaksAndRobes,    1080378, typeof( RewardDress ), Expansion.ML, Pink, 1080378 ),
						new RewardEntry( cloaksAndRobes,    1080383, typeof( RewardCloak ), Expansion.ML, Crimson, 1080383 ),
						new RewardEntry( cloaksAndRobes,    1080381, typeof( RewardRobe ), Expansion.ML, Crimson, 1080381 ),
						new RewardEntry( cloaksAndRobes,    1080379, typeof( RewardDress ), Expansion.ML, Crimson, 1080379 ),

						new RewardEntry( etherealSteeds,    1080386, typeof( EtherealCuSidhe ), Expansion.ML ),

						new RewardEntry( houseAddOns,       1080548, typeof( MiningCartDeed ), Expansion.ML ),
						new RewardEntry( houseAddOns,       1080397, typeof( AnkhOfSacrificeDeed ), Expansion.ML )
					} ),

                #endregion

                #region Year 11 Veteran Rewards

                new RewardList( RewardInterval, 11, new RewardEntry[]
					{
						new RewardEntry( etherealSteeds,    1113908, typeof( EtherealReptalon ), Expansion.ML ),
					} ),

                #endregion

                #region Year 12 Veteran Rewards

                new RewardList( RewardInterval, 12, new RewardEntry[]
					{
						new RewardEntry( etherealSteeds,    1113813, typeof( EtherealHiryu ), Expansion.ML ),
					} ),

                #endregion
            };
		}
	}
}