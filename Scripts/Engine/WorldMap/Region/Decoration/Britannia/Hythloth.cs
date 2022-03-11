using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Hythloth { get; } = Register(DecorationTarget.Britannia, "Hythloth", new DecorationList[]
			{
				#region Entries
				
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5970, 147, 22)", new DecorationEntry[]
				{
					new(5926, 145, 22, ""),
					new(5926, 146, 22, ""),
					new(5926, 147, 22, ""),
					new(5926, 148, 22, ""),
					new(5926, 149, 22, ""),
					new(5933, 146, 22, ""),
					new(5933, 145, 22, ""),
					new(5933, 149, 22, ""),
					new(5944, 148, 22, ""),
					new(5944, 147, 22, ""),
					new(5944, 146, 22, ""),
					new(5944, 145, 22, ""),
					new(5944, 144, 22, ""),
					new(5955, 148, 22, ""),
					new(5955, 146, 22, ""),
					new(5955, 145, 22, ""),
					new(5955, 144, 22, ""),
					new(5955, 149, 22, ""),
					new(5955, 150, 22, ""),
					new(5963, 146, 22, ""),
					new(5963, 145, 22, ""),
					new(5963, 144, 22, ""),
					new(5933, 147, 22, ""),
					new(5963, 148, 22, ""),
					new(5963, 147, 22, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(6041, 204, 22)", new DecorationEntry[]
				{
					new(6044, 226, 44, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(6050, 227, 44)", new DecorationEntry[]
				{
					new(6039, 204, 22, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(6107, 176, 0)", new DecorationEntry[]
				{
					new(6115, 176, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(6124, 155, 0)", new DecorationEntry[]
				{
					new(6107, 179, 0, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(5948, 216, 22, ""),
					new(5904, 109, 0, ""),
					new(5979, 24, 22, ""),
					new(6044, 195, 21, ""),
					new(5922, 229, 44, ""),
					new(6060, 101, 28, ""),
					new(5987, 47, 22, ""),
					new(5916, 60, 22, ""),
					new(5989, 26, 22, ""),
					new(5913, 57, 22, ""),
					new(5965, 227, 22, ""),
					new(5930, 74, 0, ""),
					new(5961, 56, 0, ""),
					new(5966, 66, 0, ""),
					new(6080, 93, 22, ""),
					new(5985, 47, 22, ""),
					new(6085, 93, 25, ""),
					new(5986, 184, 44, ""),
					new(5988, 46, 22, ""),
					new(6026, 196, 22, ""),
					new(6060, 101, 25, ""),
					new(6061, 101, 22, ""),
					new(6062, 101, 25, ""),
					new(5918, 91, 0, ""),
					new(5919, 236, 44, ""),
					new(6080, 91, 22, ""),
					new(6085, 94, 22, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(5987, 186, 44, ""),
					new(6044, 221, 44, ""),
					new(5961, 71, 0, ""),
					new(6081, 44, 22, ""),
					new(5943, 67, 0, ""),
					new(6100, 35, 27, ""),
					new(6037, 199, 22, ""),
					new(6040, 230, 44, ""),
					new(5997, 56, 22, ""),
					new(5976, 83, 0, ""),
					new(6057, 40, 0, ""),
					new(6034, 204, 22, ""),
					new(6108, 34, 22, ""),
					new(6056, 161, 0, ""),
					new(6053, 40, 0, ""),
					new(6088, 170, 0, ""),
					new(6085, 88, 22, ""),
				}),
				new("Small Crate", typeof(SmallCrate), 2473, "", new DecorationEntry[]
				{
					new(5925, 84, 0, ""),
					new(5987, 35, 22, ""),
					new(5915, 54, 22, ""),
					new(5989, 40, 22, ""),
					new(5965, 222, 25, ""),
					new(6122, 166, 0, ""),
					new(6084, 92, 25, ""),
					new(6043, 230, 44, ""),
					new(5994, 144, 3, ""),
					new(6061, 101, 25, ""),
					new(5910, 106, 0, ""),
					new(5908, 51, 22, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(5967, 74, 0, ""),
					new(5987, 81, 0, ""),
					new(5984, 32, 22, ""),
					new(6056, 97, 22, ""),
					new(6056, 98, 22, ""),
					new(6056, 98, 25, ""),
					new(6080, 90, 22, ""),
					new(6080, 91, 25, ""),
					new(6080, 92, 25, ""),
					new(6080, 93, 25, ""),
					new(5947, 216, 22, ""),
					new(6056, 99, 22, ""),
					new(5961, 79, 0, ""),
					new(5984, 149, 0, ""),
					new(5965, 222, 22, ""),
					new(6104, 93, 0, ""),
					new(5989, 185, 44, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5965, 216, 22, ""),
					new(5912, 237, 44, ""),
					new(6068, 97, 22, ""),
					new(6080, 184, 0, ""),
					new(5944, 233, 22, ""),
					new(5931, 84, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(6120, 160, 0, ""),
					new(5988, 188, 44, ""),
					new(6109, 42, 22, ""),
					new(5913, 229, 44, ""),
					new(5974, 84, 0, ""),
					new(5976, 191, 44, ""),
					new(6110, 68, 0, ""),
					new(6069, 92, 22, ""),
					new(6059, 157, 0, ""),
					new(6083, 40, 22, ""),
					new(6080, 40, 22, ""),
					new(5948, 66, 0, ""),
					new(5993, 149, 0, ""),
					new(6122, 229, 22, ""),
					new(5905, 108, 0, ""),
					new(6037, 203, 22, ""),
					new(6085, 88, 22, ""),
					new(5917, 234, 44, ""),
					new(5929, 71, 0, ""),
					new(6117, 227, 22, ""),
				}),
				new("Saw", typeof(Static), 4148, "", new DecorationEntry[]
				{
					new(5952, 230, 28, ""),
				}),
				new("Fitting", typeof(Static), 4395, "", new DecorationEntry[]
				{
					new(5953, 200, 22, ""),
					new(5956, 200, 22, ""),
					new(5954, 200, 22, ""),
					new(5955, 200, 22, ""),
					new(5957, 200, 22, ""),
					new(6107, 152, -22, ""),
				}),
				new("Scroll%S%", typeof(Static), 3639, "", new DecorationEntry[]
				{
					new(5953, 213, 22, ""),
					new(5936, 188, 22, ""),
					new(5959, 217, 22, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(6112, 211, 22, ""),
				}),
				new("Heart", typeof(Static), 7405, "", new DecorationEntry[]
				{
					new(5954, 228, 28, ""),
					new(5961, 225, 28, ""),
					new(6059, 69, 0, ""),
					new(6112, 226, 28, ""),
					new(5949, 226, 28, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(6109, 93, 0, ""),
					new(5978, 171, 0, ""),
					new(6026, 198, 22, ""),
					new(6054, 159, 0, ""),
					new(6104, 82, 0, ""),
					new(6108, 70, 0, ""),
					new(6089, 172, 0, ""),
					new(5926, 81, 0, ""),
					new(5989, 188, 44, ""),
					new(5989, 169, 0, ""),
					new(5966, 69, 0, ""),
					new(6115, 223, 22, ""),
					new(5976, 194, 44, ""),
				}),
				new("Flask Stand", typeof(Static), 6185, "", new DecorationEntry[]
				{
					new(6112, 80, 6, ""),
				}),
				new("Wooden Box", typeof(Static), 3709, "", new DecorationEntry[]
				{
					new(6113, 227, 28, ""),
					new(5976, 189, 47, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1671, "Facing=EastCCW", new DecorationEntry[]
				{
					new(6115, 87, 0, ""),
					new(6107, 87, 0, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1669, "Facing=WestCW", new DecorationEntry[]
				{
					new(6114, 87, 0, ""),
					new(6106, 87, 0, ""),
					new(5980, 28, 22, ""),
					new(5989, 28, 22, ""),
					new(5985, 28, 22, ""),
				}),
				new("Floor Saw", typeof(SawTrap), 4524, "", new DecorationEntry[]
				{
					new(6068, 63, 0, ""),
					new(5967, 152, 0, ""),
					new(5962, 154, 0, ""),
					new(5915, 96, 0, ""),
					new(6065, 63, 0, ""),
					new(6071, 63, 0, ""),
					new(6070, 63, 0, ""),
					new(5988, 32, 22, ""),
					new(6039, 201, 22, ""),
					new(6066, 63, 0, ""),
					new(6067, 63, 0, ""),
					new(6069, 63, 0, ""),
				}),
				new("Bottle", typeof(Static), 3837, "", new DecorationEntry[]
				{
					new(6113, 80, 6, ""),
				}),
				new("Thigh Boots", typeof(Static), 5906, "", new DecorationEntry[]
				{
					new(5952, 238, 22, ""),
					new(5959, 222, 22, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4020, "", new DecorationEntry[]
				{
					new(5958, 226, 28, ""),
				}),
				new("Hammer", typeof(Static), 4138, "", new DecorationEntry[]
				{
					new(5952, 226, 28, ""),
				}),
				new("Butcher Knife", typeof(Static), 5110, "", new DecorationEntry[]
				{
					new(5957, 217, 22, ""),
					new(5983, 174, 0, ""),
					new(5926, 240, 44, ""),
					new(5944, 147, 22, ""),
				}),
				new("Skinning Knife", typeof(Static), 3780, "", new DecorationEntry[]
				{
					new(5955, 221, 22, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1737, "Facing=WestCCW", new DecorationEntry[]
				{
					new(5955, 215, 22, ""),
					new(6082, 87, 22, ""),
					new(6061, 42, 0, ""),
					new(6049, 42, 0, ""),
					new(5987, 55, 22, ""),
					new(6069, 87, 22, ""),
					new(5994, 95, 0, ""),
					new(5914, 95, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1739, "Facing=EastCW", new DecorationEntry[]
				{
					new(5956, 215, 22, ""),
					new(6070, 87, 22, ""),
					new(5915, 95, 0, ""),
					new(6050, 42, 0, ""),
					new(6083, 87, 22, ""),
					new(6062, 42, 0, ""),
					new(5988, 55, 22, ""),
					new(5995, 95, 0, ""),
				}),
				new("Gnarled Staff", typeof(Static), 5113, "", new DecorationEntry[]
				{
					new(5956, 214, 22, ""),
					new(5978, 193, 44, ""),
					new(5924, 240, 44, ""),
					new(5926, 213, 22, ""),
					new(5948, 223, 22, ""),
					new(5949, 176, 0, ""),
					new(5946, 173, 0, ""),
					new(5916, 225, 44, ""),
					new(5915, 184, 22, ""),
				}),
				new("Leather Gorget", typeof(Static), 5063, "", new DecorationEntry[]
				{
					new(5952, 210, 22, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5909, 101, 0, ""),
					new(6121, 152, 0, ""),
					new(6122, 154, 0, ""),
					new(6119, 208, 22, ""),
					new(6082, 42, 22, ""),
					new(5910, 110, 0, ""),
					new(6121, 208, 22, ""),
					new(6124, 152, 0, ""),
					new(5922, 86, 0, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(5953, 176, 0, ""),
					new(5978, 200, 44, ""),
					new(5976, 200, 44, ""),
					new(5924, 229, 44, ""),
					new(5944, 170, 0, ""),
					new(5965, 223, 22, ""),
					new(5989, 221, 44, ""),
				}),
				new("Kite Shield", typeof(Static), 7028, "", new DecorationEntry[]
				{
					new(5952, 165, 0, ""),
					new(5968, 219, 22, ""),
					new(5933, 201, 22, ""),
					new(5916, 226, 44, ""),
					new(5942, 147, 22, ""),
					new(5961, 196, 22, ""),
					new(5963, 156, 0, ""),
					new(5959, 233, 22, ""),
					new(5930, 221, 44, ""),
				}),
				new("Buckler", typeof(Static), 7027, "", new DecorationEntry[]
				{
					new(5959, 155, 0, ""),
					new(5977, 202, 44, ""),
					new(5980, 184, 44, ""),
					new(5971, 176, 0, ""),
					new(5914, 169, 22, ""),
				}),
				new("Broadsword", typeof(Static), 3934, "", new DecorationEntry[]
				{
					new(5953, 157, 0, ""),
				}),
				new("Ringmail Leggings", typeof(Static), 5104, "", new DecorationEntry[]
				{
					new(5952, 153, 0, ""),
				}),
				new("Blank Scroll%S%", typeof(Static), 3827, "", new DecorationEntry[]
				{
					new(5960, 209, 22, ""),
					new(5952, 145, 22, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1683, "Facing=NorthCW", new DecorationEntry[]
				{
					new(6103, 67, 0, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1681, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(6103, 68, 0, ""),
				}),
				new("Bloody Water", typeof(Static), 3619, "", new DecorationEntry[]
				{
					new(5960, 227, 28, ""),
					new(6114, 81, 6, ""),
					new(5958, 225, 28, ""),
					new(5947, 225, 26, ""),
				}),
				new("Skeleton", typeof(Static), 7039, "", new DecorationEntry[]
				{
					new(6059, 64, 0, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(5989, 29, 22, ""),
					new(6048, 53, 0, ""),
					new(6061, 40, 0, ""),
					new(6106, 42, 27, ""),
					new(5912, 227, 44, ""),
					new(6125, 229, 22, ""),
					new(6048, 43, 0, ""),
					new(5976, 29, 22, ""),
					new(6062, 54, 0, ""),
					new(5994, 68, 28, ""),
					new(6100, 42, 27, ""),
					new(6117, 208, 22, ""),
					new(5990, 56, 22, ""),
					new(6112, 215, 22, ""),
				}),
				new("Small Web", typeof(Static), 4308, "", new DecorationEntry[]
				{
					new(5961, 144, 22, ""),
					new(5915, 48, 22, ""),
					new(5930, 48, 22, ""),
					new(5975, 168, 0, ""),
					new(5980, 216, 44, ""),
					new(5984, 144, 0, ""),
					new(5984, 80, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1741, "Facing=SouthCW", new DecorationEntry[]
				{
					new(5967, 236, 22, ""),
					new(5959, 28, 0, ""),
					new(5927, 220, 44, ""),
					new(6087, 156, -22, ""),
					new(6111, 220, 22, ""),
					new(5951, 99, 22, ""),
					new(5919, 156, 22, ""),
					new(5919, 52, 22, ""),
					new(6079, 172, 0, ""),
					new(5911, 28, 44, ""),
					new(6063, 52, 0, ""),
					new(6047, 204, 22, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1743, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5967, 235, 22, ""),
					new(5959, 27, 0, ""),
					new(5927, 219, 44, ""),
					new(6063, 51, 0, ""),
					new(6087, 155, -22, ""),
					new(6111, 219, 22, ""),
					new(5951, 98, 22, ""),
					new(5919, 155, 22, ""),
					new(5919, 51, 22, ""),
					new(6079, 171, 0, ""),
					new(5911, 27, 44, ""),
					new(6047, 203, 22, ""),
				}),
				new("Orange Potion", typeof(Static), 3847, "", new DecorationEntry[]
				{
					new(6052, 155, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1958, "", new DecorationEntry[]
				{
					new(5961, 46, 17, ""),
				}),
				new("Torch%Es%", typeof(Static), 3940, "", new DecorationEntry[]
				{
					new(6062, 90, 22, ""),
				}),
				new("Crate", typeof(SmallCrate), 3710, "", new DecorationEntry[]
				{
					new(5983, 81, 0, ""),
					new(6063, 101, 25, ""),
					new(5982, 84, 0, ""),
					new(5908, 53, 22, ""),
					new(5974, 81, 0, ""),
					new(5916, 58, 22, ""),
					new(6060, 101, 31, ""),
					new(6080, 90, 25, ""),
					new(6084, 93, 25, ""),
					new(5932, 65, 0, ""),
					new(5958, 68, 0, ""),
					new(6085, 93, 25, ""),
				}),
				new("Gas Trap", typeof(GasTrap), 4412, "", new DecorationEntry[]
				{
					new(5952, 78, 22, ""),
					new(5963, 88, 0, ""),
				}),
				new("Bag", typeof(Bag), 3702, "", new DecorationEntry[]
				{
					new(5949, 228, 22, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(5972, 172, 0, ""),
					new(5984, 24, 22, ""),
					new(6084, 92, 22, ""),
					new(5989, 30, 22, ""),
					new(6060, 102, 22, ""),
					new(5985, 184, 44, ""),
					new(6045, 196, 22, ""),
					new(5984, 154, 0, ""),
					new(5914, 93, 0, ""),
				}),
				new("Cleaver", typeof(Static), 3779, "", new DecorationEntry[]
				{
					new(5946, 171, 0, ""),
					new(5920, 184, 22, ""),
					new(5948, 225, 26, ""),
					new(5944, 218, 22, ""),
					new(5944, 148, 22, ""),
					new(5937, 180, 22, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4512, "", new DecorationEntry[]
				{
					new(5962, 217, 22, ""),
					new(5947, 76, 22, ""),
					new(5944, 225, 22, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(5907, 16, 44, ""),
					new(6057, 206, 22, ""),
				}),
				new("Keg", typeof(Keg), 3711, "", new DecorationEntry[]
				{
					new(6041, 224, 44, ""),
					new(6040, 227, 44, ""),
					new(5944, 169, 0, ""),
					new(5944, 168, 0, ""),
					new(5908, 28, 44, ""),
					new(5904, 27, 44, ""),
					new(5908, 17, 44, ""),
					new(5988, 221, 44, ""),
					new(5988, 220, 44, ""),
					new(5931, 48, 22, ""),
					new(6033, 204, 22, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(6040, 226, 44, ""),
					new(6057, 101, 22, ""),
					new(5977, 201, 44, ""),
					new(6032, 201, 22, ""),
					new(5952, 176, 0, ""),
					new(5959, 237, 22, ""),
					new(5915, 92, 0, ""),
					new(6056, 100, 22, ""),
					new(6056, 101, 22, ""),
					new(5985, 173, 0, ""),
					new(5912, 231, 44, ""),
					new(5917, 60, 22, ""),
					new(5907, 16, 44, ""),
					new(5965, 225, 22, ""),
					new(5965, 224, 22, ""),
					new(6056, 96, 22, ""),
					new(6069, 100, 22, ""),
					new(6069, 101, 22, ""),
					new(6032, 202, 22, ""),
					new(6032, 204, 22, ""),
					new(6032, 205, 22, ""),
					new(6033, 205, 22, ""),
					new(6034, 205, 22, ""),
					new(6040, 225, 44, ""),
					new(5908, 19, 44, ""),
					new(6084, 93, 22, ""),
				}),
				new("Cocoon", typeof(Static), 4316, "", new DecorationEntry[]
				{
					new(5981, 24, 22, ""),
					new(5940, 96, 22, ""),
				}),
				new("Clean Bandage%S%", typeof(Static), 3617, "", new DecorationEntry[]
				{
					new(5960, 225, 28, ""),
				}),
				new("Quarter Staff", typeof(Static), 3721, "", new DecorationEntry[]
				{
					new(5978, 238, 22, ""),
					new(5912, 191, 22, ""),
					new(5963, 183, 1, ""),
				}),
				new("Leather Sleeves", typeof(Static), 5061, "", new DecorationEntry[]
				{
					new(5981, 228, 44, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(6065, 97, 22, ""),
					new(6084, 176, 0, ""),
					new(6085, 42, 22, ""),
					new(6040, 223, 44, ""),
					new(5977, 187, 44, ""),
					new(6079, 40, 22, ""),
					new(6120, 152, 0, ""),
					new(6040, 221, 44, ""),
					new(5980, 188, 44, ""),
					new(6057, 162, 0, ""),
					new(6108, 68, 0, ""),
				}),
				new("Gnarled Staff", typeof(Static), 5112, "", new DecorationEntry[]
				{
					new(5992, 175, 0, ""),
					new(5960, 179, 0, ""),
					new(5974, 147, 22, ""),
					new(5931, 190, 22, ""),
				}),
				new("Studded Tunic", typeof(Static), 5083, "", new DecorationEntry[]
				{
					new(5995, 158, 0, ""),
					new(5966, 231, 22, ""),
				}),
				new("Crossbow", typeof(Static), 3920, "", new DecorationEntry[]
				{
					new(5977, 206, 44, ""),
				}),
				new("Garbage", typeof(Static), 4335, "", new DecorationEntry[]
				{
					new(5985, 33, 22, ""),
					new(5912, 50, 22, ""),
					new(5912, 59, 22, ""),
					new(5917, 26, 44, ""),
					new(5923, 35, 44, ""),
					new(5924, 25, 44, ""),
					new(5924, 44, -40, ""),
					new(5925, 44, 22, ""),
					new(5938, 105, 22, ""),
					new(5938, 109, 22, ""),
					new(5941, 103, 22, ""),
					new(5945, 108, 22, ""),
					new(5972, 51, 22, ""),
					new(5987, 149, 0, ""),
					new(5987, 153, 0, ""),
					new(5988, 158, 0, ""),
					new(5988, 40, 22, ""),
					new(5989, 161, 0, ""),
					new(5989, 167, 0, ""),
					new(5990, 146, 0, ""),
					new(5993, 154, 0, ""),
					new(5995, 104, 0, ""),
					new(5995, 147, 0, ""),
					new(5996, 100, 0, ""),
					new(5974, 172, 15, ""),
				}),
				new("Pickaxe", typeof(Static), 3718, "", new DecorationEntry[]
				{
					new(5976, 186, 44, ""),
					new(5919, 222, 44, ""),
				}),
				new("Pouch", typeof(Static), 3705, "", new DecorationEntry[]
				{
					new(5922, 229, 47, ""),
				}),
				new("Garbage", typeof(Static), 4337, "", new DecorationEntry[]
				{
					new(5987, 147, 0, ""),
					new(5993, 102, 0, ""),
					new(5997, 101, 0, ""),
					new(5913, 28, 44, ""),
					new(5924, 25, 44, ""),
					new(5924, 31, 44, ""),
					new(5924, 42, 22, ""),
					new(5932, 51, 22, ""),
					new(5936, 49, 22, ""),
					new(5938, 101, 22, ""),
					new(5939, 107, 22, ""),
					new(5940, 101, 22, ""),
					new(5940, 103, 22, ""),
					new(5942, 102, 22, ""),
					new(5943, 103, 22, ""),
					new(5945, 101, 22, ""),
					new(5945, 98, 22, ""),
					new(5946, 105, 22, ""),
					new(5947, 104, 22, ""),
					new(5947, 106, 22, ""),
					new(5947, 52, 22, ""),
					new(5948, 97, 22, ""),
					new(5955, 98, 22, ""),
					new(5956, 89, 22, ""),
					new(5957, 97, 22, ""),
					new(5976, 50, 22, ""),
					new(5979, 172, 0, ""),
					new(5983, 51, 22, ""),
					new(5985, 33, 22, ""),
					new(5985, 44, 22, ""),
					new(5987, 154, 0, ""),
					new(5987, 172, 0, ""),
					new(5990, 148, 0, ""),
					new(5990, 154, 0, ""),
					new(5993, 147, 0, ""),
					new(5993, 154, 0, ""),
					new(5995, 151, 0, ""),
					new(6108, 90, 0, ""),
					new(6112, 90, 0, ""),
				}),
				new("Carrot%S%", typeof(Static), 3191, "", new DecorationEntry[]
				{
					new(5989, 104, 6, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1735, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5988, 31, 22, ""),
					new(6083, 47, 22, ""),
					new(6100, 47, 22, ""),
					new(5987, 207, 44, ""),
					new(5988, 159, 0, ""),
					new(6060, 167, 0, ""),
				}),
				new("Blood Moss", typeof(Static), 3963, "", new DecorationEntry[]
				{
					new(2678, 712, 0, ""),
				}),
				new("Garbage", typeof(Static), 4336, "", new DecorationEntry[]
				{
					new(5988, 46, 22, ""),
					new(5914, 26, 44, ""),
					new(5917, 29, 44, ""),
					new(5922, 37, 44, ""),
					new(5924, 25, 44, ""),
					new(5925, 44, 22, ""),
					new(5936, 49, 22, ""),
					new(5938, 51, 22, ""),
					new(5939, 106, 22, ""),
					new(5941, 108, 22, ""),
					new(5943, 100, 22, ""),
					new(5943, 99, 22, ""),
					new(5945, 102, 22, ""),
					new(5946, 104, 22, ""),
					new(5947, 106, 22, ""),
					new(5955, 92, 22, ""),
					new(5955, 98, 22, ""),
					new(5975, 52, 22, ""),
					new(6116, 90, 0, ""),
					new(5985, 36, 22, ""),
					new(5986, 162, 0, ""),
					new(5986, 163, 0, ""),
					new(5987, 163, 0, ""),
					new(5997, 100, 0, ""),
					new(5968, 172, 15, ""),
					new(6107, 92, 0, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(6063, 101, 22, ""),
					new(5977, 30, 22, ""),
					new(5994, 144, 0, ""),
					new(5976, 189, 44, ""),
					new(6080, 92, 22, ""),
					new(6080, 93, 22, ""),
					new(6085, 93, 22, ""),
					new(5986, 33, 22, ""),
					new(5982, 29, 22, ""),
					new(6045, 195, 22, ""),
					new(6060, 101, 22, ""),
					new(6061, 102, 22, ""),
					new(6062, 101, 22, ""),
					new(5958, 67, 0, ""),
					new(6064, 101, 22, ""),
					new(6064, 101, 25, ""),
					new(5929, 76, 0, ""),
					new(6080, 90, 22, ""),
					new(6080, 91, 22, ""),
					new(6085, 92, 22, ""),
					new(6084, 93, 22, ""),
				}),
				new("Wand", typeof(Static), 3571, "", new DecorationEntry[]
				{
					new(5921, 226, 44, ""),
					new(5966, 174, 0, ""),
				}),
				new("Platemail Arms", typeof(Static), 5143, "", new DecorationEntry[]
				{
					new(5921, 222, 44, ""),
				}),
				new("Plate Helm", typeof(Static), 5145, "", new DecorationEntry[]
				{
					new(5925, 203, 22, ""),
				}),
				new("Close Helm", typeof(Static), 5129, "", new DecorationEntry[]
				{
					new(5925, 200, 22, ""),
					new(5926, 169, 1, ""),
				}),
				new("Stone", typeof(Static), 1955, "", new DecorationEntry[]
				{
					new(5904, 16, 59, ""),
					new(5905, 16, 59, ""),
					new(5906, 16, 59, ""),
					new(6040, 217, 59, ""),
					new(6103, 32, 22, ""),
				}),
				new("Broken Armoire", typeof(Static), 3090, "", new DecorationEntry[]
				{
					new(5904, 50, 22, ""),
				}),
				new("Stone Pavers", typeof(Static), 1314, "", new DecorationEntry[]
				{
					new(5904, 97, 0, ""),
					new(6044, 226, 44, ""),
				}),
				new("Pitchfork", typeof(Static), 3719, "", new DecorationEntry[]
				{
					new(5926, 158, 22, ""),
					new(5990, 144, 0, ""),
				}),
				new("Platemail Gloves", typeof(Static), 5140, "", new DecorationEntry[]
				{
					new(5923, 155, 22, ""),
				}),
				new("Stone Pavers", typeof(Static), 1316, "", new DecorationEntry[]
				{
					new(5905, 96, 0, ""),
					new(5973, 169, 0, ""),
					new(6107, 179, 0, ""),
				}),
				new("Stone Pavers", typeof(Static), 1315, "", new DecorationEntry[]
				{
					new(5905, 97, 0, ""),
				}),
				new("Sparkle", typeof(Static), 14186, "", new DecorationEntry[]
				{
					new(5905, 97, 0, ""),
					new(5973, 169, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1956, "", new DecorationEntry[]
				{
					new(5906, 17, 59, ""),
					new(5905, 17, 59, ""),
					new(5904, 17, 59, ""),
				}),
				new("Ruined Painting", typeof(Static), 3116, "", new DecorationEntry[]
				{
					new(5906, 48, 22, ""),
				}),
				new("Candlabra", typeof(CandelabraStand), 2601, "", new DecorationEntry[]
				{
					new(6048, 43, 0, ""),
					new(6062, 54, 0, ""),
					new(5989, 29, 22, ""),
					new(5990, 56, 22, ""),
					new(6112, 215, 22, ""),
				}),
				new("Pelvis Bone", typeof(Static), 6934, "", new DecorationEntry[]
				{
					new(6057, 67, 0, ""),
					new(6058, 68, 0, ""),
				}),
				new("Jaw Bone", typeof(Static), 6932, "", new DecorationEntry[]
				{
					new(6059, 67, 0, ""),
				}),
				new("Bottle", typeof(Static), 3628, "", new DecorationEntry[]
				{
					new(5993, 65, 28, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1745, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(6103, 84, 0, ""),
					new(6103, 180, 0, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1677, "Facing=SouthCW", new DecorationEntry[]
				{
					new(6063, 67, 0, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1679, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(6063, 66, 0, ""),
				}),
				new("Bones", typeof(Static), 3792, "", new DecorationEntry[]
				{
					new(6058, 66, 0, ""),
					new(6106, 68, 0, ""),
				}),
				new("Sheets", typeof(Static), 3123, "", new DecorationEntry[]
				{
					new(5908, 48, 22, ""),
				}),
				new("Pan Of Cookies", typeof(Static), 5643, "", new DecorationEntry[]
				{
					new(5989, 105, 6, ""),
				}),
				new("Pizza%S%", typeof(Static), 4160, "", new DecorationEntry[]
				{
					new(5990, 103, 6, ""),
				}),
				new("Ham%S%", typeof(Static), 2505, "", new DecorationEntry[]
				{
					new(5991, 105, 6, ""),
				}),
				new("Debris", typeof(Static), 3117, "", new DecorationEntry[]
				{
					new(5910, 49, 22, ""),
					new(5985, 145, 0, ""),
					new(5986, 160, 0, ""),
					new(5996, 68, 22, ""),
					new(5997, 97, 0, ""),
				}),
				new("Debris", typeof(Static), 3118, "", new DecorationEntry[]
				{
					new(5910, 50, 22, ""),
					new(5956, 50, 22, ""),
					new(5979, 168, 0, ""),
					new(5984, 145, 0, ""),
					new(5996, 67, 22, ""),
					new(5997, 98, 0, ""),
				}),
				new("Head", typeof(Static), 7401, "", new DecorationEntry[]
				{
					new(6035, 198, 22, ""),
					new(6119, 218, 32, ""),
				}),
				new("Wall Torch", typeof(Static), 2565, "", new DecorationEntry[]
				{
					new(5912, 203, 37, ""),
				}),
				new("Gold Belt", typeof(Static), 5430, "", new DecorationEntry[]
				{
					new(5912, 206, 22, ""),
				}),
				new("Stone Pavers", typeof(Static), 1313, "", new DecorationEntry[]
				{
					new(6039, 204, 22, ""),
					new(5904, 96, 0, ""),
				}),
				new("Covered Chair", typeof(Static), 3095, "", new DecorationEntry[]
				{
					new(5912, 48, 22, ""),
				}),
				new("Stone Face", typeof(StoneFaceTrap), 4348, "", new DecorationEntry[]
				{
					new(5913, 101, 0, ""),
					new(5909, 101, 0, ""),
				}),
				new("Scroll%S%", typeof(Static), 3641, "", new DecorationEntry[]
				{
					new(5913, 163, 22, ""),
					new(5920, 224, 44, ""),
					new(5956, 208, 22, ""),
				}),
				new("Statue", typeof(Static), 4646, "", new DecorationEntry[]
				{
					new(5913, 240, 44, ""),
				}),
				new("Stone Stairs", typeof(Static), 1957, "", new DecorationEntry[]
				{
					new(5922, 168, 4, ""),
					new(5922, 169, 4, ""),
					new(5922, 170, 4, ""),
					new(5923, 168, -1, ""),
					new(5923, 169, -1, ""),
					new(5923, 170, -1, ""),
				}),
				new("Open Sack Of Flour", typeof(Static), 4154, "", new DecorationEntry[]
				{
					new(5990, 108, 0, ""),
				}),
				new("Garbage", typeof(Static), 4334, "", new DecorationEntry[]
				{
					new(5913, 50, 22, ""),
					new(5913, 59, 22, ""),
					new(5922, 29, 44, ""),
					new(5924, 25, 44, ""),
					new(5924, 41, 44, ""),
					new(5924, 42, -40, ""),
					new(5924, 43, 22, ""),
					new(5925, 44, -40, ""),
					new(5937, 109, 22, ""),
					new(5938, 99, 22, ""),
					new(5939, 100, 22, ""),
					new(5944, 104, 22, ""),
					new(5945, 108, 22, ""),
					new(5947, 97, 22, ""),
					new(5948, 99, 22, ""),
					new(5967, 50, 22, ""),
					new(5985, 148, 0, ""),
					new(5985, 170, 0, ""),
					new(5985, 33, 22, ""),
					new(5988, 52, 22, ""),
					new(5997, 100, 0, ""),
					new(5997, 99, 0, ""),
					new(5965, 171, 15, ""),
					new(5948, 97, 22, ""),
				}),
				new("Bench", typeof(Static), 2918, "", new DecorationEntry[]
				{
					new(5914, 229, 44, ""),
				}),
				new("Scroll%S%", typeof(Static), 3638, "", new DecorationEntry[]
				{
					new(5915, 169, 22, ""),
					new(5961, 197, 22, ""),
					new(5991, 224, 44, ""),
				}),
				new("Bench", typeof(Static), 2917, "", new DecorationEntry[]
				{
					new(5915, 229, 44, ""),
				}),
				new("Skull With Candle", typeof(Static), 6230, "", new DecorationEntry[]
				{
					new(6061, 48, 6, ""),
					new(5993, 59, 28, ""),
					new(5993, 66, 28, ""),
				}),
				new("Dungeon Wall", typeof(Static), 762, "", new DecorationEntry[]
				{
					new(6046, 195, 21, ""),
				}),
				new("Lever", typeof(Static), 4245, "", new DecorationEntry[]
				{
					new(5985, 37, 22, ""),
					new(5987, 37, 22, ""),
					new(5985, 34, 22, ""),
					new(5987, 34, 22, ""),
				}),
				new("Rock", typeof(Static), 6002, "", new DecorationEntry[]
				{
					new(6109, 155, -22, ""),
					new(6110, 155, -22, ""),
					new(6106, 152, -22, ""),
					new(6107, 154, -22, ""),
					new(6107, 152, -22, ""),
					new(6106, 154, -22, ""),
					new(6106, 153, -22, ""),
					new(6111, 152, -22, ""),
					new(6110, 152, -22, ""),
					new(6110, 154, -22, ""),
					new(6109, 153, -22, ""),
					new(6109, 152, -22, ""),
					new(6108, 153, -22, ""),
					new(6108, 152, -22, ""),
					new(6110, 153, -22, ""),
					new(6109, 154, -22, ""),
					new(6105, 152, -22, ""),
					new(6108, 155, -22, ""),
					new(6109, 156, -22, ""),
					new(6110, 156, -22, ""),
					new(6110, 157, -22, ""),
					new(6107, 152, -23, ""),
					new(6107, 153, -22, ""),
					new(6108, 154, -22, ""),
				}),
				new("Roast Pig%S%", typeof(Static), 2492, "", new DecorationEntry[]
				{
					new(5991, 82, 6, ""),
				}),
				new("Leg", typeof(Static), 7394, "", new DecorationEntry[]
				{
					new(6053, 160, 0, ""),
				}),
				new("Pile Of Garbage", typeof(Static), 4338, "", new DecorationEntry[]
				{
					new(5917, 48, 22, ""),
					new(5942, 96, 22, ""),
					new(5997, 96, 0, ""),
				}),
				new("Scroll%S%", typeof(Static), 3640, "", new DecorationEntry[]
				{
					new(5918, 228, 44, ""),
				}),
				new("Body Part", typeof(Static), 7402, "", new DecorationEntry[]
				{
					new(6056, 161, 0, ""),
				}),
				new("Wand", typeof(Static), 3570, "", new DecorationEntry[]
				{
					new(5947, 240, 22, ""),
					new(5970, 156, 7, ""),
					new(5934, 224, 44, ""),
				}),
				new("Small Web", typeof(Static), 4311, "", new DecorationEntry[]
				{
					new(5920, 144, 22, ""),
					new(5944, 166, 0, ""),
					new(5952, 93, 22, ""),
					new(5976, 83, 0, ""),
					new(5995, 144, 0, ""),
				}),
				new("Dungeon Wall", typeof(Static), 577, "", new DecorationEntry[]
				{
					new(5920, 167, 0, ""),
					new(5920, 167, 22, ""),
					new(5921, 167, 0, ""),
					new(5921, 167, 22, ""),
					new(5922, 167, 0, ""),
					new(5922, 167, 22, ""),
					new(5923, 167, 0, ""),
					new(5924, 167, 0, ""),
					new(5924, 167, 22, ""),
					new(5925, 167, 22, ""),
					new(5926, 167, 22, ""),
					new(5926, 167, 3, ""),
					new(5927, 228, 44, ""),
					new(5991, 71, 22, ""),
					new(5993, 71, 22, ""),
					new(5994, 71, 22, ""),
					new(6068, 87, 22, ""),
					new(5923, 167, 22, ""),
					new(5925, 167, 0, ""),
				}),
				new("Arm", typeof(Static), 7397, "", new DecorationEntry[]
				{
					new(6057, 154, 0, ""),
					new(6053, 155, 0, ""),
				}),
				new("Wall Torch", typeof(Static), 2570, "", new DecorationEntry[]
				{
					new(5922, 200, 37, ""),
				}),
				new("Scroll%S%", typeof(Static), 3830, "", new DecorationEntry[]
				{
					new(5922, 232, 44, ""),
					new(5949, 166, 0, ""),
				}),
				new("Pile Of Garbage", typeof(Static), 4339, "", new DecorationEntry[]
				{
					new(5922, 40, 22, ""),
					new(5949, 96, 22, ""),
					new(5984, 145, 1, ""),
				}),
				new("Mandrake Root%S%", typeof(Static), 3974, "", new DecorationEntry[]
				{
					new(2682, 679, 0, ""),
				}),
				new("Bones", typeof(Static), 3791, "", new DecorationEntry[]
				{
					new(5948, 229, 22, ""),
					new(5948, 97, 22, ""),
				}),
				new("Lever", typeof(Static), 4243, "", new DecorationEntry[]
				{
					new(5985, 37, 22, ""),
					new(5985, 34, 22, ""),
					new(5987, 34, 22, ""),
					new(5987, 37, 22, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4506, "", new DecorationEntry[]
				{
					new(5973, 236, 22, ""),
					new(5956, 66, 0, ""),
					new(5968, 233, 22, ""),
					new(6040, 204, 22, ""),
					new(6040, 199, 22, ""),
					new(6033, 202, 22, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(6060, 47, 6, ""),
					new(5948, 221, 34, ""),
					new(6107, 83, 6, ""),
				}),
				new("Bones", typeof(Static), 3790, "", new DecorationEntry[]
				{
					new(5945, 216, 22, ""),
				}),
				new("Dungeon Wall", typeof(Static), 578, "", new DecorationEntry[]
				{
					new(5927, 228, 44, ""),
				}),
				new("Bascinet", typeof(Static), 5133, "", new DecorationEntry[]
				{
					new(5950, 166, 0, ""),
				}),
				new("Heating Stand", typeof(HeatingStand), 6218, "", new DecorationEntry[]
				{
					new(5994, 58, 30, ""),
					new(6108, 82, 6, ""),
					new(5945, 219, 34, ""),
				}),
				new("Scroll%S%", typeof(Static), 3831, "", new DecorationEntry[]
				{
					new(5934, 222, 44, ""),
					new(5962, 204, 22, ""),
				}),
				new("Dungeon Arch", typeof(Static), 586, "", new DecorationEntry[]
				{
					new(6067, 87, 22, ""),
					new(6067, 83, 22, ""),
				}),
				new("Small Web", typeof(Static), 4309, "", new DecorationEntry[]
				{
					new(5936, 109, 22, ""),
					new(5952, 101, 22, ""),
					new(5957, 73, 22, ""),
				}),
				new("Ham%S%", typeof(Static), 2515, "", new DecorationEntry[]
				{
					new(5991, 83, 6, ""),
					new(5990, 81, 6, ""),
				}),
				new("Web", typeof(Static), 4285, "", new DecorationEntry[]
				{
					new(5939, 103, 22, ""),
				}),
				new("Cocoon", typeof(Static), 4314, "", new DecorationEntry[]
				{
					new(5939, 96, 22, ""),
				}),
				new("Web", typeof(Static), 4286, "", new DecorationEntry[]
				{
					new(5940, 102, 22, ""),
				}),
				new("Bracelet", typeof(Static), 4230, "", new DecorationEntry[]
				{
					new(5940, 148, 22, ""),
					new(5949, 231, 22, ""),
					new(5964, 173, 0, ""),
					new(5984, 221, 44, ""),
				}),
				new("Web", typeof(Static), 4287, "", new DecorationEntry[]
				{
					new(5941, 101, 22, ""),
				}),
				new("Web", typeof(Static), 4288, "", new DecorationEntry[]
				{
					new(5942, 100, 22, ""),
				}),
				new("Cave Floor", typeof(Static), 1342, "", new DecorationEntry[]
				{
					new(5943, 176, 22, ""),
					new(5943, 180, 22, ""),
					new(5943, 181, 22, ""),
				}),
				new("Cave Floor", typeof(Static), 1339, "", new DecorationEntry[]
				{
					new(5943, 177, 22, ""),
					new(5943, 178, 22, ""),
					new(5957, 51, 22, ""),
					new(5957, 52, 22, ""),
				}),
				new("Cave Floor", typeof(Static), 1340, "", new DecorationEntry[]
				{
					new(5943, 179, 22, ""),
					new(5945, 173, 0, ""),
					new(5945, 175, 0, ""),
					new(5945, 176, 0, ""),
				}),
				new("Small Web", typeof(Static), 4307, "", new DecorationEntry[]
				{
					new(5943, 96, 22, ""),
					new(5952, 200, 22, ""),
					new(5971, 73, 0, ""),
					new(5984, 154, 0, ""),
					new(5986, 200, 44, ""),
				}),
				new("Web", typeof(Static), 4289, "", new DecorationEntry[]
				{
					new(5943, 99, 22, ""),
				}),
				new("Cave Floor", typeof(Static), 1341, "", new DecorationEntry[]
				{
					new(5944, 173, 0, ""),
					new(5945, 174, 0, ""),
				}),
				new("Crystal Ball", typeof(Static), 3629, "", new DecorationEntry[]
				{
					new(5944, 222, 22, ""),
					new(5949, 147, 22, ""),
					new(5961, 223, 22, ""),
					new(5922, 170, 9, ""),
				}),
				new("Entrails", typeof(Static), 7407, "", new DecorationEntry[]
				{
					new(6058, 160, 0, ""),
					new(6118, 228, 22, ""),
				}),
				new("Dyeing Tub", typeof(DyeTub), 4011, "", new DecorationEntry[]
				{
					new(5945, 216, 22, ""),
				}),
				new("Flask", typeof(Static), 6212, "", new DecorationEntry[]
				{
					new(5945, 219, 34, ""),
					new(6108, 82, 6, ""),
					new(5990, 105, 6, ""),
				}),
				new("Empty Vials", typeof(Static), 6236, "", new DecorationEntry[]
				{
					new(5945, 220, 34, ""),
					new(5993, 62, 28, ""),
					new(6109, 80, 6, ""),
				}),
				new("Skull With Candle", typeof(Static), 6229, "", new DecorationEntry[]
				{
					new(5945, 222, 34, ""),
					new(5950, 219, 34, ""),
					new(5987, 63, 34, ""),
					new(5987, 67, 34, ""),
					new(6112, 224, 28, ""),
				}),
				new("Tribal Mask", typeof(Static), 5451, "", new DecorationEntry[]
				{
					new(5974, 236, 22, ""),
				}),
				new("Full Jars", typeof(Static), 3657, "", new DecorationEntry[]
				{
					new(5946, 220, 34, ""),
				}),
				new("Flask", typeof(Static), 6199, "", new DecorationEntry[]
				{
					new(5946, 222, 34, ""),
				}),
				new("Scroll%S%", typeof(Static), 3828, "", new DecorationEntry[]
				{
					new(5946, 228, 22, ""),
				}),
				new("Necklace", typeof(Static), 4232, "", new DecorationEntry[]
				{
					new(5972, 173, 0, ""),
					new(5913, 234, 44, ""),
					new(5988, 205, 44, ""),
					new(5984, 158, 0, ""),
				}),
				new("Ring", typeof(Static), 4234, "", new DecorationEntry[]
				{
					new(5971, 168, 0, ""),
					new(5919, 222, 44, ""),
					new(5961, 200, 22, ""),
				}),
				new("Stool", typeof(Stool), 2602, "", new DecorationEntry[]
				{
					new(5947, 220, 28, ""),
				}),
				new("Full Jar", typeof(Static), 4102, "", new DecorationEntry[]
				{
					new(5947, 222, 34, ""),
				}),
				new("Web", typeof(Static), 4305, "", new DecorationEntry[]
				{
					new(5948, 101, 22, ""),
				}),
				new("Brain", typeof(Static), 7408, "", new DecorationEntry[]
				{
					new(5948, 233, 28, ""),
					new(5949, 229, 28, ""),
				}),
				new("Studded Sleeves", typeof(Static), 5076, "", new DecorationEntry[]
				{
					new(5968, 145, 22, ""),
					new(5915, 227, 44, ""),
					new(5919, 204, 22, ""),
				}),
				new("Web", typeof(Static), 4304, "", new DecorationEntry[]
				{
					new(5949, 100, 22, ""),
				}),
				new("Scales", typeof(Scales), 6225, "", new DecorationEntry[]
				{
					new(5949, 219, 34, ""),
					new(6108, 80, 6, ""),
					new(6112, 227, 28, ""),
				}),
				new("Full Vials", typeof(Static), 6238, "", new DecorationEntry[]
				{
					new(5949, 222, 34, ""),
					new(5993, 60, 28, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1773, "Facing=SouthCW", new DecorationEntry[]
				{
					new(6031, 198, 22, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1775, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(6031, 197, 22, ""),
				}),
				new("Empty Jars", typeof(Static), 3652, "", new DecorationEntry[]
				{
					new(5950, 220, 34, ""),
				}),
				new("Blood", typeof(Static), 4651, "", new DecorationEntry[]
				{
					new(5950, 222, 22, ""),
					new(5986, 102, 6, ""),
					new(6124, 212, 22, ""),
				}),
				new("Blood Smear", typeof(Static), 4655, "", new DecorationEntry[]
				{
					new(5950, 226, 22, ""),
					new(5986, 103, 6, ""),
					new(5909, 105, 0, ""),
				}),
				new("Dovetail Saw", typeof(Static), 4137, "", new DecorationEntry[]
				{
					new(5950, 226, 28, ""),
				}),
				new("Torso", typeof(Static), 7392, "", new DecorationEntry[]
				{
					new(5950, 233, 28, ""),
					new(5963, 84, 6, ""),
					new(5990, 83, 6, ""),
				}),
				new("Pelvis Bone", typeof(Static), 6933, "", new DecorationEntry[]
				{
					new(5950, 234, 28, ""),
					new(5950, 225, 28, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(6108, 83, 6, ""),
					new(5961, 228, 28, ""),
				}),
				new("Web", typeof(Static), 4303, "", new DecorationEntry[]
				{
					new(5950, 99, 22, ""),
				}),
				new("Block", typeof(Static), 4723, "", new DecorationEntry[]
				{
					new(5951, 218, 22, ""),
					new(5986, 98, 6, ""),
				}),
				new("Blood", typeof(Static), 4652, "", new DecorationEntry[]
				{
					new(5951, 220, 22, ""),
					new(5947, 226, 22, ""),
				}),
				new("Legs", typeof(Static), 7399, "", new DecorationEntry[]
				{
					new(5951, 225, 28, ""),
				}),
				new("Flask", typeof(Static), 6190, "", new DecorationEntry[]
				{
					new(6111, 81, 6, ""),
				}),
				new("Web", typeof(Static), 4302, "", new DecorationEntry[]
				{
					new(5951, 98, 22, ""),
				}),
				new("Scroll%S%", typeof(Static), 3832, "", new DecorationEntry[]
				{
					new(5953, 229, 22, ""),
					new(5982, 210, 44, ""),
				}),
				new("Book", typeof(TreatiseOnAlchemy), 4079, "", new DecorationEntry[]
				{
					new(6113, 225, 28, ""),
				}),
				new("Book", typeof(ArmsAndWeaponsPrimer), 4079, "Name=the life of a travelling minstrel", new DecorationEntry[]
				{
					new(5985, 66, 36, ""),
				}),
				new("Blood", typeof(Static), 4654, "", new DecorationEntry[]
				{
					new(5954, 227, 22, ""),
				}),
				new("Studded Gloves", typeof(Static), 5077, "", new DecorationEntry[]
				{
					new(5914, 185, 22, ""),
				}),
				new("Flask", typeof(Static), 6191, "", new DecorationEntry[]
				{
					new(6114, 80, 6, ""),
					new(5993, 61, 28, ""),
				}),
				new("Flask", typeof(Static), 6196, "", new DecorationEntry[]
				{
					new(6115, 81, 6, ""),
				}),
				new("Flask", typeof(Static), 6194, "", new DecorationEntry[]
				{
					new(6115, 83, 6, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1733, "Facing=WestCW", new DecorationEntry[]
				{
					new(6082, 47, 22, ""),
					new(6099, 47, 22, ""),
					new(5986, 207, 44, ""),
					new(5987, 159, 0, ""),
					new(5987, 31, 22, ""),
					new(6059, 167, 0, ""),
				}),
				new("Bloody Bandage%S%", typeof(Static), 3616, "", new DecorationEntry[]
				{
					new(5958, 227, 28, ""),
					new(5959, 224, 22, ""),
					new(5959, 225, 28, ""),
				}),
				new("Hay", typeof(Static), 4150, "", new DecorationEntry[]
				{
					new(5959, 228, 22, ""),
					new(5963, 218, 22, ""),
					new(5964, 217, 22, ""),
					new(5965, 218, 22, ""),
				}),
				new("Barber Scissors", typeof(Static), 3581, "", new DecorationEntry[]
				{
					new(5959, 228, 28, ""),
				}),
				new("Kite Shield", typeof(Static), 7032, "", new DecorationEntry[]
				{
					new(5992, 158, 0, ""),
					new(5995, 148, 0, ""),
					new(5928, 213, 44, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2717, "", new DecorationEntry[]
				{
					new(5996, 144, 0, ""),
				}),
				new("Statue", typeof(Static), 4644, "", new DecorationEntry[]
				{
					new(5960, 188, 11, ""),
				}),
				new("Chisels", typeof(Static), 4135, "", new DecorationEntry[]
				{
					new(5960, 226, 28, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(5960, 228, 28, ""),
				}),
				new("Hay", typeof(Static), 4151, "", new DecorationEntry[]
				{
					new(5961, 217, 22, ""),
					new(5962, 223, 22, ""),
					new(5963, 221, 22, ""),
				}),
				new("Mortar And Pestle", typeof(Static), 3739, "", new DecorationEntry[]
				{
					new(5961, 226, 28, ""),
					new(5994, 59, 28, ""),
					new(6114, 228, 28, ""),
				}),
				new("Saw", typeof(Static), 4149, "", new DecorationEntry[]
				{
					new(5961, 226, 28, ""),
				}),
				new("Glass", typeof(Static), 8065, "", new DecorationEntry[]
				{
					new(5961, 227, 28, ""),
				}),
				new("Bottle", typeof(Static), 3626, "", new DecorationEntry[]
				{
					new(5961, 227, 28, ""),
				}),
				new("Statue", typeof(Static), 4647, "", new DecorationEntry[]
				{
					new(5964, 181, 0, ""),
				}),
				new("Blood", typeof(Static), 4653, "", new DecorationEntry[]
				{
					new(5964, 218, 22, ""),
				}),
				new("Head", typeof(Static), 7393, "", new DecorationEntry[]
				{
					new(5965, 77, 6, ""),
					new(5946, 225, 28, ""),
					new(6113, 226, 28, ""),
				}),
				new("Scroll%S%", typeof(Static), 3829, "", new DecorationEntry[]
				{
					new(5968, 197, 22, ""),
				}),
				new("Brazier", typeof(Brazier), 3633, "", new DecorationEntry[]
				{
					new(5971, 232, 22, ""),
				}),
				new("Egg Case Web", typeof(Static), 4312, "", new DecorationEntry[]
				{
					new(5976, 24, 32, ""),
					new(5986, 24, 22, ""),
				}),
				new("Egg Case", typeof(Static), 4313, "", new DecorationEntry[]
				{
					new(5976, 24, 32, ""),
					new(5986, 24, 22, ""),
					new(5994, 60, 28, ""),
					new(5994, 63, 28, ""),
				}),
				new("Altar", typeof(Static), 4630, "", new DecorationEntry[]
				{
					new(5977, 25, 22, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6228, "", new DecorationEntry[]
				{
					new(6113, 81, 6, ""),
				}),
				new("Foot Stool", typeof(FootStool), 2910, "", new DecorationEntry[]
				{
					new(5980, 29, 22, ""),
				}),
				new("Web", typeof(Static), 4317, "", new DecorationEntry[]
				{
					new(5981, 24, 22, ""),
				}),
				new("Small Web", typeof(Static), 4310, "", new DecorationEntry[]
				{
					new(5983, 168, 0, ""),
				}),
				new("Beef Carcass", typeof(Static), 6258, "", new DecorationEntry[]
				{
					new(5984, 101, 0, ""),
					new(5984, 97, 0, ""),
					new(5984, 99, 0, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(5984, 104, -1, ""),
				}),
				new("Broken Furniture", typeof(Static), 3109, "", new DecorationEntry[]
				{
					new(5984, 156, 0, ""),
				}),
				new("Small Web", typeof(Static), 4306, "", new DecorationEntry[]
				{
					new(5984, 160, 0, ""),
				}),
				new("Bread Loa%Ves/F%", typeof(Static), 4155, "", new DecorationEntry[]
				{
					new(5959, 228, 28, ""),
				}),
				new("Damaged Books", typeof(Static), 3094, "", new DecorationEntry[]
				{
					new(5985, 156, 0, ""),
				}),
				new("Flask", typeof(Static), 6215, "", new DecorationEntry[]
				{
					new(5985, 63, 34, ""),
				}),
				new("Book", typeof(TaleOfThreeTribes), 4080, "", new DecorationEntry[]
				{
					new(5985, 64, 36, ""),
				}),
				new("Book", typeof(DiversityOfOurLand), 4084, "", new DecorationEntry[]
				{
					new(5985, 65, 36, ""),
				}),
				new("Bottle", typeof(Static), 3627, "", new DecorationEntry[]
				{
					new(5985, 66, 36, ""),
					new(5993, 58, 28, ""),
				}),
				new("Block", typeof(Static), 4721, "", new DecorationEntry[]
				{
					new(5986, 100, 6, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2901, "", new DecorationEntry[]
				{
					new(5986, 65, 28, ""),
				}),
				new("Sheep Carcass", typeof(Static), 6259, "", new DecorationEntry[]
				{
					new(5986, 96, 0, ""),
					new(5988, 96, 0, ""),
					new(5991, 96, 0, ""),
				}),
				new("Block", typeof(Static), 4722, "", new DecorationEntry[]
				{
					new(5986, 99, 6, ""),
				}),
				new("Block", typeof(Static), 4720, "", new DecorationEntry[]
				{
					new(5987, 100, 6, ""),
				}),
				new("", typeof(Static), 5401, "", new DecorationEntry[]
				{
					new(5987, 31, 22, ""),
				}),
				new("Brazier", typeof(Static), 3635, "", new DecorationEntry[]
				{
					new(5917, 195, 22, ""),
				}),
				new("Earrings", typeof(Static), 4231, "", new DecorationEntry[]
				{
					new(5937, 149, 22, ""),
					new(5960, 176, 0, ""),
					new(5919, 202, 22, ""),
				}),
				new("Candelabra", typeof(Candelabra), 2845, "", new DecorationEntry[]
				{
					new(6103, 38, 31, ""),
				}),
				new("Bones", typeof(Static), 3789, "", new DecorationEntry[]
				{
					new(5939, 99, 22, ""),
				}),
				new("Bones", typeof(Static), 3787, "", new DecorationEntry[]
				{
					new(5940, 98, 22, ""),
				}),
				new("Rusty Iron Key", typeof(Static), 4115, "", new DecorationEntry[]
				{
					new(5987, 58, 22, ""),
				}),
				new("Body Part", typeof(Static), 7395, "", new DecorationEntry[]
				{
					new(5987, 83, 0, ""),
				}),
				new("Block", typeof(Static), 4718, "", new DecorationEntry[]
				{
					new(5987, 98, 6, ""),
				}),
				new("Block", typeof(Static), 4719, "", new DecorationEntry[]
				{
					new(5987, 99, 6, ""),
				}),
				new("Block", typeof(Static), 4715, "", new DecorationEntry[]
				{
					new(5988, 100, 6, ""),
				}),
				new("Hourglass", typeof(Static), 6163, "", new DecorationEntry[]
				{
					new(5988, 104, 6, ""),
					new(5994, 64, 28, ""),
				}),
				new("Slab%S% Of Bacon", typeof(Static), 2423, "", new DecorationEntry[]
				{
					new(5990, 80, 6, ""),
				}),
				new("Block", typeof(Static), 4717, "", new DecorationEntry[]
				{
					new(5988, 98, 6, ""),
				}),
				new("Block", typeof(Static), 4716, "", new DecorationEntry[]
				{
					new(5988, 99, 6, ""),
				}),
				new("Body", typeof(Static), 7390, "", new DecorationEntry[]
				{
					new(5989, 103, 6, ""),
				}),
				new("Wall Torch", typeof(Static), 2573, "", new DecorationEntry[]
				{
					new(5989, 184, 59, ""),
					new(5908, 16, 59, ""),
					new(5984, 184, 59, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1747, "Facing=NorthCW", new DecorationEntry[]
				{
					new(6103, 179, 0, ""),
					new(6103, 83, 0, ""),
				}),
				new("Rolling Pin", typeof(Static), 4163, "", new DecorationEntry[]
				{
					new(5990, 104, 6, ""),
				}),
				new("Floor Saw", typeof(SawTrap), 4529, "", new DecorationEntry[]
				{
					new(5966, 96, 0, ""),
				}),
				new("Counter", typeof(Static), 2879, "", new DecorationEntry[]
				{
					new(5990, 80, 0, ""),
					new(5990, 81, 0, ""),
					new(5990, 82, 0, ""),
					new(5990, 83, 0, ""),
					new(5990, 84, 0, ""),
					new(5991, 80, 0, ""),
					new(5991, 81, 0, ""),
					new(5991, 82, 0, ""),
					new(5991, 83, 0, ""),
					new(5991, 84, 0, ""),
				}),
				new("Flour Sifter", typeof(Static), 4158, "", new DecorationEntry[]
				{
					new(5991, 103, 6, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(5991, 104, 6, ""),
				}),
				new("Vines", typeof(Static), 3168, "", new DecorationEntry[]
				{
					new(5991, 80, 6, ""),
				}),
				new("Arm", typeof(Static), 7389, "", new DecorationEntry[]
				{
					new(5991, 84, 6, ""),
				}),
				new("Bottles Of Wine", typeof(Static), 2501, "", new DecorationEntry[]
				{
					new(5992, 104, 6, ""),
				}),
				new("Ruined Bookcase", typeof(Static), 3092, "", new DecorationEntry[]
				{
					new(5992, 144, 0, ""),
				}),
				new("Flask", typeof(Static), 6200, "", new DecorationEntry[]
				{
					new(5993, 58, 28, ""),
				}),
				new("Scales", typeof(Static), 6226, "", new DecorationEntry[]
				{
					new(5993, 63, 28, ""),
				}),
				new("Bottle", typeof(Static), 3625, "", new DecorationEntry[]
				{
					new(5993, 64, 28, ""),
				}),
				new("Flask", typeof(Static), 6211, "", new DecorationEntry[]
				{
					new(5993, 64, 28, ""),
				}),
				new("Bottle", typeof(Static), 3840, "", new DecorationEntry[]
				{
					new(5994, 61, 28, ""),
					new(6115, 81, 6, ""),
				}),
				new("Flask", typeof(Static), 6198, "", new DecorationEntry[]
				{
					new(5994, 65, 28, ""),
				}),
				new("Flask", typeof(Static), 6193, "", new DecorationEntry[]
				{
					new(5994, 66, 28, ""),
				}),
				new("Heating Stand", typeof(Static), 6220, "", new DecorationEntry[]
				{
					new(5994, 66, 28, ""),
				}),
				new("Bones", typeof(Static), 3788, "", new DecorationEntry[]
				{
					new(5944, 216, 22, ""),
				}),
				new("Crook", typeof(Static), 5109, "", new DecorationEntry[]
				{
					new(5963, 237, 22, ""),
					new(5988, 164, 0, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2715, "", new DecorationEntry[]
				{
					new(5960, 216, 22, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2711, "", new DecorationEntry[]
				{
					new(5961, 216, 22, ""),
					new(5963, 216, 22, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2712, "", new DecorationEntry[]
				{
					new(5962, 216, 22, ""),
				}),
				new("Club", typeof(Static), 5044, "", new DecorationEntry[]
				{
					new(5963, 178, 0, ""),
				}),
				new("Mace", typeof(Static), 3932, "", new DecorationEntry[]
				{
					new(5967, 160, 0, ""),
				}),
				new("Stone Pavers", typeof(Static), 1309, "", new DecorationEntry[]
				{
					new(6041, 204, 22, ""),
					new(6046, 226, 44, ""),
				}),
				new("Broken Chair", typeof(Static), 3097, "", new DecorationEntry[]
				{
					new(5905, 51, 22, ""),
					new(5913, 60, 22, ""),
				}),
				new("Candelabra", typeof(Static), 2856, "", new DecorationEntry[]
				{
					new(6048, 40, 0, ""),
				}),
				new("Skinning Knife", typeof(Static), 3781, "", new DecorationEntry[]
				{
					new(5947, 226, 26, ""),
				}),
				new("Cave Floor", typeof(Static), 1343, "", new DecorationEntry[]
				{
					new(5975, 172, 16, ""),
				}),
				new("Platemail", typeof(Static), 5141, "", new DecorationEntry[]
				{
					new(5911, 183, 22, ""),
				}),
				new("Legs", typeof(Static), 7403, "", new DecorationEntry[]
				{
					new(6060, 158, 0, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(6060, 48, 6, ""),
				}),
				new("Raw Bird%S%", typeof(Static), 2489, "", new DecorationEntry[]
				{
					new(5990, 82, 6, ""),
				}),
				new("Watermelon%S%", typeof(Static), 3164, "", new DecorationEntry[]
				{
					new(5990, 84, 6, ""),
				}),
				new("Sack Of Flour", typeof(Static), 4153, "", new DecorationEntry[]
				{
					new(5989, 109, 0, ""),
				}),
				new("Wooden Box", typeof(Static), 2474, "", new DecorationEntry[]
				{
					new(6056, 98, 28, ""),
				}),
				new("Dungeon Arch", typeof(Static), 582, "", new DecorationEntry[]
				{
					new(6067, 80, 22, ""),
					new(6067, 84, 22, ""),
				}),
				new("Dungeon Arch", typeof(Static), 584, "", new DecorationEntry[]
				{
					new(6067, 81, 22, ""),
					new(6067, 85, 22, ""),
					new(6067, 86, 22, ""),
					new(6067, 82, 22, ""),
				}),
				new("Platemail Gorget", typeof(Static), 5139, "", new DecorationEntry[]
				{
					new(5984, 153, 0, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2718, "", new DecorationEntry[]
				{
					new(5984, 148, 0, ""),
				}),
				new("Studded Gorget", typeof(Static), 5078, "", new DecorationEntry[]
				{
					new(5984, 149, 0, ""),
				}),
				new("Butcher Knife", typeof(Static), 5111, "", new DecorationEntry[]
				{
					new(5986, 104, 6, ""),
				}),
				new("Bottle", typeof(Static), 3622, "", new DecorationEntry[]
				{
					new(6107, 80, 6, ""),
				}),
				new("Deck%S% Of Tarot", typeof(Static), 4779, "", new DecorationEntry[]
				{
					new(6114, 224, 28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2713, "", new DecorationEntry[]
				{
					new(5985, 68, 28, ""),
					new(5985, 62, 28, ""),
				}),
				new("Garlic", typeof(Static), 3972, "", new DecorationEntry[]
				{
					new(2682, 678, 0, ""),
				}),
				new("Long Pants", typeof(Static), 5433, "", new DecorationEntry[]
				{
					new(5987, 31, 22, ""),
				}),
				new("Blood", typeof(Static), 7442, "", new DecorationEntry[]
				{
					new(6086, 178, 0, ""),
				}),
				new("Skeleton With Meat", typeof(Static), 6941, "", new DecorationEntry[]
				{
					new(6056, 67, 0, ""),
				}),
				new("Mug Of Ale", typeof(GlassMug), 2542, "", new DecorationEntry[]
				{
					new(5961, 227, 28, ""),
				}),
				new("Rock", typeof(Static), 6003, "", new DecorationEntry[]
				{
					new(6106, 153, -22, ""),
				}),
				new("Rock", typeof(Static), 6004, "", new DecorationEntry[]
				{
					new(6106, 154, -22, ""),
				}),
				new("Rock", typeof(Static), 6001, "", new DecorationEntry[]
				{
					new(6107, 154, -22, ""),
				}),
				new("Blood", typeof(Static), 4650, "", new DecorationEntry[]
				{
					new(6107, 156, -22, ""),
				}),
				new("Stone Pavers", typeof(Static), 1312, "", new DecorationEntry[]
				{
					new(6107, 176, 0, ""),
					new(6115, 176, 0, ""),
					new(6115, 179, 0, ""),
				}),
				new("Flask", typeof(Static), 6189, "", new DecorationEntry[]
				{
					new(6108, 81, 6, ""),
				}),
				new("Bottle", typeof(Static), 3836, "", new DecorationEntry[]
				{
					new(6110, 80, 6, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2896, "", new DecorationEntry[]
				{
					new(6111, 82, 0, ""),
				}),
				new("Large Battle Axe", typeof(Static), 5115, "", new DecorationEntry[]
				{
					new(5933, 224, 44, ""),
				}),
				new("Chainmail  Coif", typeof(Static), 5051, "", new DecorationEntry[]
				{
					new(5930, 208, 35, ""),
				}),
				new("Green Potion", typeof(Static), 3850, "", new DecorationEntry[]
				{
					new(5931, 84, 0, ""),
				}),
				new("Empty Vials", typeof(Static), 6235, "", new DecorationEntry[]
				{
					new(6114, 223, 28, ""),
				}),
				new("Hourglass", typeof(Static), 6160, "", new DecorationEntry[]
				{
					new(6114, 82, 6, ""),
				}),
				new("Torso", typeof(Static), 7400, "", new DecorationEntry[]
				{
					new(6118, 226, 22, ""),
				}),
				
				#endregion
			});
		}
	}
}
