using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Cove { get; } = Register(DecorationTarget.Britannia, "Cove", new DecorationList[]
			{
				#region Entries
				
				new("Tent Wall", typeof(Static), 747, "Hue=0x33", new DecorationEntry[]
				{
					new(2333, 1220, 0, ""),
					new(2337, 1229, 0, ""),
					new(2342, 1214, 0, ""),
					new(2346, 1220, 0, ""),
				}),
				new("Tent Wall", typeof(Static), 748, "Hue=0x33", new DecorationEntry[]
				{
					new(2334, 1219, 0, ""),
					new(2338, 1228, 0, ""),
					new(2343, 1213, 0, ""),
					new(2347, 1219, 0, ""),
				}),
				new("Gruesome Standard", typeof(Static), 1055, "", new DecorationEntry[]
				{
					new(2338, 1214, 0, ""),
				}),
				new("Gruesome Standard", typeof(Static), 1056, "", new DecorationEntry[]
				{
					new(2347, 1217, 0, ""),
				}),
				new("Gruesome Standard", typeof(Static), 1064, "", new DecorationEntry[]
				{
					new(2329, 1221, 0, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(2337, 1221, 0, ""),
				}),
				new("Tray", typeof(Static), 2450, "", new DecorationEntry[]
				{
					new(2227, 1218, 6, ""),
					new(2236, 1187, 6, ""),
					new(2244, 1203, 6, ""),
					new(2259, 1217, 6, ""),
				}),
				new("Bottle Of Liquor", typeof(BeverageBottle), 2459, "Content=Liquor", new DecorationEntry[]
				{
					new(2228, 1218, 6, ""),
				}),
				new("Fork", typeof(Fork), 2467, "", new DecorationEntry[]
				{
					new(2227, 1217, 6, ""),
				}),
				new("Fork", typeof(Fork), 2468, "", new DecorationEntry[]
				{
					new(2237, 1187, 6, ""),
					new(2245, 1203, 6, ""),
					new(2260, 1217, 6, ""),
				}),
				new("Knife", typeof(Knife), 2469, "", new DecorationEntry[]
				{
					new(2227, 1217, 6, ""),
				}),
				new("Knife", typeof(Knife), 2470, "", new DecorationEntry[]
				{
					new(2237, 1187, 6, ""),
					new(2245, 1203, 6, ""),
					new(2260, 1217, 6, ""),
				}),
				new("Metal Box", typeof(FillableMetalBox), 2472, "", new DecorationEntry[]
				{
					new(2213, 1165, 6, ""),
				}),
				new("Spoon", typeof(Spoon), 2498, "", new DecorationEntry[]
				{
					new(2227, 1217, 6, ""),
				}),
				new("Spoon", typeof(Spoon), 2499, "", new DecorationEntry[]
				{
					new(2237, 1187, 7, ""),
					new(2245, 1203, 7, ""),
					new(2260, 1217, 7, ""),
				}),
				new("Bottle Of Wine", typeof(BeverageBottle), 2503, "Content=Wine", new DecorationEntry[]
				{
					new(2238, 1188, 6, ""),
					new(2246, 1204, 6, ""),
					new(2261, 1218, 6, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(2227, 1217, 6, ""),
					new(2228, 1217, 6, ""),
					new(2237, 1187, 6, ""),
					new(2237, 1188, 6, ""),
					new(2245, 1203, 6, ""),
					new(2245, 1204, 6, ""),
					new(2260, 1217, 6, ""),
					new(2260, 1218, 6, ""),
				}),
				new("Fork", typeof(Fork), 2548, "", new DecorationEntry[]
				{
					new(2237, 1188, 6, ""),
					new(2245, 1204, 6, ""),
					new(2260, 1218, 6, ""),
				}),
				new("Fork", typeof(Fork), 2549, "", new DecorationEntry[]
				{
					new(2228, 1217, 6, ""),
				}),
				new("Knife", typeof(Knife), 2550, "", new DecorationEntry[]
				{
					new(2237, 1188, 6, ""),
					new(2245, 1204, 6, ""),
					new(2260, 1218, 6, ""),
				}),
				new("Knife", typeof(Knife), 2551, "", new DecorationEntry[]
				{
					new(2228, 1217, 6, ""),
				}),
				new("Spoon", typeof(Spoon), 2552, "", new DecorationEntry[]
				{
					new(2237, 1188, 6, ""),
					new(2245, 1204, 6, ""),
					new(2260, 1218, 6, ""),
				}),
				new("Spoon", typeof(Spoon), 2553, "", new DecorationEntry[]
				{
					new(2228, 1217, 6, ""),
				}),
				new("Candle", typeof(CandleLarge), 2598, "Unlit", new DecorationEntry[]
				{
					new(2228, 1216, 6, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(2212, 1116, 26, ""),
					new(2212, 1116, 46, ""),
					new(2213, 1164, 6, ""),
					new(2213, 1168, 6, ""),
					new(2215, 1191, 6, ""),
					new(2217, 1195, 6, ""),
					new(2236, 1188, 6, ""),
					new(2243, 1228, 6, ""),
					new(2243, 1231, 6, ""),
					new(2244, 1204, 6, ""),
					new(2259, 1218, 6, ""),
					new(2275, 1198, 6, ""),
					new(2276, 1200, 26, ""),
					new(2283, 1226, 6, ""),
					new(2284, 1228, 26, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(2211, 1115, 20, ""),
					new(2212, 1166, 0, ""),
					new(2242, 1229, 0, ""),
					new(2275, 1199, 20, ""),
					new(2283, 1227, 20, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(2276, 1197, 0, ""),
					new(2284, 1225, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(2213, 1115, 40, ""),
				}),
				new("Chair", typeof(BambooChair), 2906, "", new DecorationEntry[]
				{
					new(2226, 1217, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2907, "", new DecorationEntry[]
				{
					new(2237, 1186, 0, ""),
					new(2245, 1202, 0, ""),
					new(2260, 1216, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2908, "", new DecorationEntry[]
				{
					new(2214, 1192, 0, ""),
					new(2237, 1189, 0, ""),
					new(2245, 1205, 0, ""),
					new(2260, 1219, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2909, "", new DecorationEntry[]
				{
					new(2229, 1217, 0, ""),
				}),
				new("Campfire", typeof(Static), 3555, "Light=Circle225", new DecorationEntry[]
				{
					new(2337, 1221, 0, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3644, "", new DecorationEntry[]
				{
					new(2252, 1190, -2, ""),
					new(2252, 1190, 1, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(2252, 1190, 4, ""),
					new(2253, 1190, -2, ""),
				}),
				new("Stump", typeof(Static), 3673, "", new DecorationEntry[]
				{
					new(2330, 1220, 0, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(2251, 1189, -2, ""),
					new(2251, 1189, 3, ""),
					new(2251, 1190, -2, ""),
					new(2252, 1189, -2, ""),
					new(2259, 1188, -2, ""),
					new(2259, 1188, 3, ""),
					new(2259, 1189, -2, ""),
					new(2259, 1189, 3, ""),
					new(2259, 1190, -2, ""),
					new(2260, 1188, -2, ""),
					new(2260, 1188, 3, ""),
					new(2260, 1189, -2, ""),
					new(2260, 1189, 3, ""),
					new(2260, 1190, -2, ""),
				}),
				new("Strong Box", typeof(FillableMetalBox), 3712, "", new DecorationEntry[]
				{
					new(2212, 1191, 6, ""),
					new(2240, 1231, 6, ""),
				}),
				new("Cleaver", typeof(Static), 3779, "", new DecorationEntry[]
				{
					new(2217, 1196, 6, ""),
				}),
				new("Skinning Knife", typeof(Static), 3781, "", new DecorationEntry[]
				{
					new(2212, 1196, 6, ""),
				}),
				new("Executioner's Axe", typeof(Static), 3910, "", new DecorationEntry[]
				{
					new(2331, 1219, 0, ""),
				}),
				new("Fire Pit", typeof(Static), 4012, "Light=Circle225", new DecorationEntry[]
				{
					new(2337, 1221, 0, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(2212, 1115, 26, ""),
					new(2212, 1115, 46, ""),
					new(2213, 1166, 6, ""),
					new(2243, 1229, 6, ""),
					new(2276, 1199, 26, ""),
					new(2284, 1227, 26, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(2214, 1191, 6, ""),
					new(2276, 1198, 6, ""),
					new(2284, 1226, 6, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(2213, 1166, 6, ""),
					new(2243, 1229, 6, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(2213, 1191, 6, ""),
				}),
				new("Glass Pitcher", typeof(Pitcher), 4086, "", new DecorationEntry[]
				{
					new(2261, 1217, 6, ""),
				}),
				new("Garbage", typeof(Static), 4334, "", new DecorationEntry[]
				{
					new(2332, 1221, 0, ""),
					new(2333, 1223, 0, ""),
					new(2336, 1221, 1, ""),
					new(2336, 1222, 0, ""),
					new(2338, 1214, 0, ""),
					new(2338, 1218, 0, ""),
					new(2338, 1224, 0, ""),
					new(2339, 1221, 2, ""),
					new(2340, 1220, 0, ""),
					new(2340, 1224, 0, ""),
				}),
				new("Butcher Knife", typeof(Static), 5111, "", new DecorationEntry[]
				{
					new(2212, 1195, 6, ""),
				}),
				new("Rope", typeof(Static), 5370, "", new DecorationEntry[]
				{
					new(2252, 1191, -2, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(2281, 1183, 0, ""),
				}),
				new("Skinned Goat", typeof(Static), 7816, "", new DecorationEntry[]
				{
					new(2329, 1225, 3, ""),
				}),
				new("Skinned Goat", typeof(Static), 7817, "", new DecorationEntry[]
				{
					new(2337, 1223, 0, ""),
				}),
				new("Skinned Deer", typeof(Static), 7824, "", new DecorationEntry[]
				{
					new(2342, 1221, 0, ""),
				}),
				new("Skinned Deer", typeof(Static), 7825, "", new DecorationEntry[]
				{
					new(2338, 1219, 0, ""),
					new(2339, 1219, 0, ""),
				}),
				new("Pitcher Of Water", typeof(Pitcher), 8093, "Content=Water", new DecorationEntry[]
				{
					new(2238, 1187, 6, ""),
					new(2246, 1203, 6, ""),
					new(2261, 1217, 6, ""),
				}),
				new("Pitcher Of Water", typeof(Pitcher), 8094, "Content=Water", new DecorationEntry[]
				{
					new(2227, 1216, 6, ""),
				}),
				
				#endregion
			});
		}
	}
}
