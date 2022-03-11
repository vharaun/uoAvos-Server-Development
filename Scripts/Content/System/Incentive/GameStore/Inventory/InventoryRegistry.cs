using Server.Engines.Events;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.UOStore
{
	public static partial class UltimaStore
	{
		public static void Initialize()
		{
			StoreCategory cat;

			#region Featured

			cat = StoreCategory.Featured;

			Register<SovereignCrate>(new TextDefinition[] { "Sovereign Crate", 1075202 }, 1156967, 0x2F59, 0, 0, 1000, cat);

			#endregion

			#region Character

			cat = StoreCategory.Character;

			Register<BlueSoulstone>("Blue SoulStone", 0, 0x2ADC, 0x9C62, 0, 100, cat); //Ink Well for now... Need soulstone graphic
			Register<SoulstoneFragment>("SoulStone Fragment", 0, 0x2AA1, 0x9C62, 0, 100, cat); //Ink Well for now... Need soulstone fragment graphic

			#endregion

			#region Equipment

			cat = StoreCategory.Equipment;

			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1070994 }, 1156906, 0, 0x9CA8, 0, 400, cat, ConstructPigments); // Nox Green
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1079584 }, 1156906, 0, 0x9CAF, 0, 400, cat, ConstructPigments); // Midnight Coal
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1070995 }, 1156906, 0, 0x9CA5, 0, 400, cat, ConstructPigments); // Rum Red
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1079580 }, 1156906, 0, 0x9CA4, 0, 400, cat, ConstructPigments); // Coal
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1079582 }, 1156906, 0, 0x9CA3, 0, 400, cat, ConstructPigments); // Storm Bronze
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1079581 }, 1156906, 0, 0x9CA2, 0, 400, cat, ConstructPigments); // Faded Gold
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1070988 }, 1156906, 0, 0x9CA1, 0, 400, cat, ConstructPigments); // Violet Courage Purple
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1079585 }, 1156906, 0, 0x9CA2, 0, 400, cat, ConstructPigments); // Faded Bronze
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1070996 }, 1156906, 0, 0x9C9F, 0, 400, cat, ConstructPigments); // Fire Orange
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1079586 }, 1156906, 0, 0x9C9E, 0, 400, cat, ConstructPigments); // Faded Rose
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1079583 }, 1156906, 0, 0x9CA7, 0, 400, cat, ConstructPigments); // Rose
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1079587 }, 1156906, 0, 0x9CA9, 0, 400, cat, ConstructPigments); // Deep Rose
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1070990 }, 1156906, 0, 0x9CAA, 0, 400, cat, ConstructPigments); // Luna White

			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1070992 }, 1156906, 0, 0x9CAF, 0, 400, cat, ConstructPigments); // Shadow Dancer Black
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1070989 }, 1156906, 0, 0x9CAE, 0, 400, cat, ConstructPigments); // Invulnerability Blue
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1070991 }, 1156906, 0, 0x9CAD, 0, 400, cat, ConstructPigments); // Dryad Green
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1070993 }, 1156906, 0, 0x9CAC, 0, 400, cat, ConstructPigments); // Berserker Red
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1079579 }, 1156906, 0, 0x9CAB, 0, 400, cat, ConstructPigments); // Faded Coal
			Register<PigmentsOfTokuno>(new TextDefinition[] { 1070933, 1070987 }, 1156906, 0, 0x9C9D, 0, 400, cat, ConstructPigments); // Paragon Gold

			Register<ReptalonFormTalisman>(new TextDefinition[] { 1157010, 1075202 }, 1156967, 0x2F59, 0, 0, 100, cat);
			Register<QuiverOfInfinity>(1075201, 1156971, 0x2B02, 0, 0, 100, cat);
			Register<CuSidheFormTalisman>(new TextDefinition[] { 1157010, 1031670 }, 1156970, 0x2F59, 0, 0, 100, cat);
			Register<FerretFormTalisman>(new TextDefinition[] { 1157010, 1031672 }, 1156969, 0x2F59, 0, 0, 100, cat);
			Register<LeggingsOfEmbers>(1062911, 1156956, 0x1411, 0, 0x2C, 100, cat);
			Register<ShaminoCrossbow>(1062915, 1156957, 0x26C3, 0, 0x504, 100, cat);
			Register<AncientSamuraiHelm>(1062923, 1156959, 0x236C, 0, 0, 100, cat);
			Register<HolySword>(1062921, 1156962, 0xF61, 0, 0x482, 100, cat);
			Register<DupresShield>(1075196, 1156963, 0x2B01, 0, 0, 100, cat);
			Register<OssianGrimoire>(1078148, 1156965, 0x2253, 0, 0, 100, cat);
			Register<SquirrelFormTalisman>(new TextDefinition[] { 1157010, 1031671 }, 1156966, 0x2F59, 0, 0, 100, cat);
			Register<EarringsOfProtection>(new TextDefinition[] { 1156821, 1156822 }, 1156659, 0, 0x9C66, 0, 200, cat, ConstructEarrings); // Physcial
			Register<EarringsOfProtection>(1071092, 1156659, 0, 0x9C66, 0, 200, cat, ConstructEarrings); // Fire
			Register<EarringsOfProtection>(1071093, 1156659, 0, 0x9C66, 0, 200, cat, ConstructEarrings); // Cold
			Register<EarringsOfProtection>(1071094, 1156659, 0, 0x9C66, 0, 200, cat, ConstructEarrings); // Poison
			Register<EarringsOfProtection>(1071095, 1156659, 0, 0x9C66, 0, 200, cat, ConstructEarrings); // Energy
			Register<HoodedShroudOfShadows>(1079727, 1156643, 0x2684, 0, 0x455, 1000, cat);

			#endregion

			#region Decoration

			cat = StoreCategory.Decorations;

			Register<MountedPixieWhiteDeed>(new TextDefinition[] { 1074482, 1156915 }, 1156974, 0x2A79, 0, 0, 100, cat);
			Register<MountedPixieLimeDeed>(new TextDefinition[] { 1074482, 1156914 }, 1156974, 0x2A77, 0, 0, 100, cat);
			Register<MountedPixieBlueDeed>(new TextDefinition[] { 1074482, 1156913 }, 1156974, 0x2A75, 0, 0, 100, cat);
			Register<MountedPixieOrangeDeed>(new TextDefinition[] { 1074482, 1156912 }, 1156974, 0x2A73, 0, 0, 100, cat);
			Register<MountedPixieGreenDeed>(new TextDefinition[] { 1074482, 1156911 }, 1156974, 0x2A71, 0, 0, 100, cat);
			Register<UnsettlingPortraitDeed>(1074480, 1156973, 0x2A65, 0, 0, 100, cat);
			Register<CreepyPortraitDeed>(1074481, 1156972, 0x2A69, 0, 0, 100, cat);
			//Register<DisturbingPortraitDeed>(1074479, 1156955, 0x2A5D, 0, 0, 100, cat);
			Register<DawnsMusicBox>(1075198, 1156968, 0x2AF9, 0, 0, 100, cat);
			Register<BedOfNailsDeed>(1074801, 1156975, 0, 0x9C8D, 0, 100, cat);
			Register<BrokenCoveredChairDeed>(1076257, 1156950, 0xC17, 0, 0, 100, cat);
			Register<BoilingCauldronDeed>(1076267, 1156949, 0, 0x9CB9, 0, 100, cat);
			Register<SuitOfGoldArmorDeed>(1076265, 1156943, 0x3DAA, 0, 0, 100, cat);
			Register<BrokenBedDeed>(1076263, 1156945, 0, 0x9C8F, 0, 100, cat);
			Register<BrokenArmoireDeed>(1076262, 1156946, 0xC12, 0, 0, 100, cat);
			Register<BrokenVanityDeed>(1076260, 1156947, 0, 0x9C90, 0, 100, cat);
			Register<BrokenBookcaseDeed>(1076258, 1156948, 0xC14, 0, 0, 100, cat);
			Register<SacrificialAltarDeed>(1074818, 1156954, 0, 0x9C8E, 0, 100, cat);
			Register<BrokenChestOfDrawersDeed>(1076261, 1156951, 0xC24, 0, 0, 100, cat);
			//Register<StandingBrokenChairDeed>(1076259, 1156952, 0xC1B, 0, 0, 100, cat);
			Register<FountainOfLifeDeed>(1075197, 1156964, 0x2AC0, 0, 0, 100, cat);
			Register<TapestryOfSosaria>(1062917, 1156961, 0x234E, 0, 0, 100, cat);
			Register<RoseOfTrinsic>(1062913, 1156960, 0x234D, 0, 0, 100, cat);
			Register<HearthOfHomeFireDeed>(1062919, 1156958, 0, 0x9C97, 0, 100, cat);

			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1157015 }, 1156916, 0, 0x9CB5, 0, 200, cat, ConstructMiniHouseDeed); // two story wood & plaster
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011317 }, 1156916, 0x22F5, 0, 0, 200, cat, ConstructMiniHouseDeed); // small stone tower
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011307 }, 1156916, 0x22E0, 0, 0, 200, cat, ConstructMiniHouseDeed); // wood and plaster house
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011308 }, 1156916, 0x22E1, 0, 0, 200, cat, ConstructMiniHouseDeed); // thathed-roof cottage
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011312 }, 1156916, 0, 0x9CB2, 0, 200, cat, ConstructMiniHouseDeed); // Tower
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011313 }, 1156916, 0, 0x9CB1, 0, 200, cat, ConstructMiniHouseDeed); // Small stone keep
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011314 }, 1156916, 0, 0x9CB0, 0, 200, cat, ConstructMiniHouseDeed); // Castle

			Register<HangingSwordsDeed>(1076272, 1156936, 0, 0x9C96, 0, 100, cat);
			Register<UnmadeBedDeed>(1076279, 1156935, 0, 0x9C9B, 0, 100, cat);
			Register<CurtainsDeed>(1076280, 1156934, 0, 0x9C93, 0, 100, cat);
			Register<TableWithOrangeClothDeed>(new TextDefinition[] { 1157012, 1157013 }, 1156933, 0x118E, 0, 0, 100, cat);

			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011320 }, 1156916, 0x22F3, 0, 0, 200, cat, ConstructMiniHouseDeed); // sanstone house with patio
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011316 }, 1156916, 0, 0x9CB3, 0, 200, cat, ConstructMiniHouseDeed); // marble house with patio
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011319 }, 1156916, 0x2300, 0, 0, 200, cat, ConstructMiniHouseDeed); // two story villa
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1157014 }, 1156916, 0, 0x9CB6, 0, 200, cat, ConstructMiniHouseDeed); // two story stone & plaster
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011315 }, 1156916, 0, 0x9CB4, 0, 200, cat, ConstructMiniHouseDeed); // Large house with patio
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011309 }, 1156916, 0, 0x9CB7, 0, 200, cat, ConstructMiniHouseDeed); // brick house
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011304 }, 1156916, 0x22C9, 0, 0, 200, cat, ConstructMiniHouseDeed); // field stone house
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011306 }, 1156916, 0x22DF, 0, 0, 200, cat, ConstructMiniHouseDeed); // wooden house
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011305 }, 1156916, 0x22DE, 0, 0, 200, cat, ConstructMiniHouseDeed); // small brick house
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011303 }, 1156916, 0x22E1, 0, 0, 200, cat, ConstructMiniHouseDeed); // stone and plaster house
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011318 }, 1156916, 0x22FB, 0, 0, 200, cat, ConstructMiniHouseDeed); // two-story log cabin
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011321 }, 1156916, 0x22F6, 0, 0, 200, cat, ConstructMiniHouseDeed); // small stone workshop
			Register<MiniHouseDeed>(new TextDefinition[] { 1062096, 1011322 }, 1156916, 0x22F4, 0, 0, 200, cat, ConstructMiniHouseDeed); // small marble workshop

			Register<TableWithBlueClothDeed>(1076276, 1156932, 0x118C, 0, 0, 100, cat);
			Register<CherryBlossomTreeDeed>(1076268, 1156940, 0, 0x9C91, 0, 100, cat);
			Register<IronMaidenDeed>(1076288, 1156924, 0x1249, 0, 0, 100, cat);
			Register<SmallFishingNetDeed>(1076286, 1156923, 0x1EA3, 0, 0, 100, cat);
			Register<StoneStatueDeed>(1076284, 1156922, 0, 0x9C9A, 0, 100, cat);
			Register<WallTorchDeed>(1076282, 1156921, 0x3D98, 0, 0, 100, cat);
			Register<HouseLadderDeed>(1076287, 1156920, 0x2FDE, 0, 0, 100, cat);
			Register<LargeFishingNetDeed>(1076285, 1156919, 0x3D8E, 0, 0, 100, cat);
			Register<FountainDeed>(1076283, 1156918, 0, 0x9C94, 0, 100, cat);
			Register<ScarecrowDeed>(1076608, 1156917, 0x1E34, 0, 0, 100, cat);
			Register<HangingAxesDeed>(1076271, 1156937, 0, 0x9C95, 0, 100, cat);
			Register<AppleTreeDeed>(1076269, 1156938, 0, 0x9C8C, 0, 100, cat);
			Register<GuillotineDeed>(1024656, 1156941, 0x125E, 0, 0, 100, cat);
			Register<SuitOfSilverArmorDeed>(1076266, 1156942, 0x3D86, 0, 0, 100, cat);
			Register<PeachTreeDeed>(1076270, 1156939, 0, 0x9C98, 0, 100, cat);
			Register<CherryBlossomTrunkDeed>(1076784, 1156925, 0x26EE, 0, 0, 100, cat);
			Register<PeachTrunkDeed>(1076786, 1156926, 0xD9C, 0, 0, 100, cat);
			Register<BrokenFallenChairDeed>(1076264, 1156944, 0xC19, 0, 0, 100, cat);
			Register<TableWithRedClothDeed>(1076277, 1156930, 0x118E, 0, 0, 100, cat);
			Register<VanityDeed>(1074027, 1156931, 0, 0x9C9C, 0, 100, cat);
			Register<AppleTrunkDeed>(1076785, 1156927, 0xD98, 0, 0, 100, cat);
			Register<TableWithPurpleClothDeed>(new TextDefinition[] { 1157011, 1157013 }, 1156929, 0x118B, 0, 0, 100, cat);
			Register<WoodenCoffinDeed>(1076274, 1156928, 0, 0x9C92, 0, 100, cat);
			Register<LampPost2>(1071089, 1156650, 0xB22, 0, 0, 200, cat, ConstructLampPost);

			#endregion

			#region Mounts

			cat = StoreCategory.Mounts;

			Register<ChargerOfTheFallen>(1075187, 1156646, 0x2D9C, 0, 0, 1000, cat);

			#endregion

			#region Miscellaneous

			cat = StoreCategory.Misc;

			#endregion

		}
	}
}