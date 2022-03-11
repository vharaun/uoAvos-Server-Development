using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Destard { get; } = Register(DecorationTarget.Britannia, "Destard", new DecorationList[]
			{
				#region Entries
				
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(5177, 1013, 0, ""),
					new(5247, 838, 20, ""),
					new(5247, 838, 23, ""),
					new(5312, 802, 0, ""),
					new(5313, 802, 0, ""),
					new(5313, 802, 3, ""),
					new(5320, 776, 0, ""),
					new(5144, 870, 0, ""),
					new(5153, 859, 3, ""),
					new(5177, 1014, 0, ""),
					new(5177, 1014, 3, ""),
					new(5178, 1014, 0, ""),
					new(5153, 859, 0, ""),
					new(5154, 859, 0, ""),
				}),
				new("Stalagmites", typeof(Static), 2281, "", new DecorationEntry[]
				{
					new(5149, 962, 25, ""),
					new(5145, 960, 25, ""),
					new(5142, 960, 25, ""),
					new(5140, 958, 25, ""),
					new(5139, 957, 25, ""),
					new(5131, 965, 25, ""),
					new(5131, 967, 25, ""),
					new(5131, 968, 25, ""),
					new(5131, 969, 25, ""),
					new(5131, 970, 25, ""),
					new(5132, 972, 25, ""),
					new(5136, 978, 25, ""),
					new(5132, 987, 25, ""),
					new(5133, 990, 25, ""),
					new(5153, 999, 0, ""),
					new(5153, 1001, 8, ""),
					new(5153, 1001, 0, ""),
					new(5155, 1001, 1, ""),
					new(5153, 1004, 25, ""),
					new(5153, 1005, 25, ""),
					new(5153, 1006, 25, ""),
					new(5155, 1008, 25, ""),
					new(5158, 1011, 25, ""),
					new(5165, 991, 25, ""),
					new(5166, 991, 25, ""),
					new(5136, 976, 25, ""),
					new(5151, 962, 25, ""),
					new(5150, 962, 25, ""),
					new(5148, 962, 25, ""),
					new(5147, 962, 25, ""),
					new(5147, 961, 25, ""),
					new(5146, 961, 25, ""),
					new(5143, 960, 25, ""),
					new(5142, 959, 25, ""),
					new(5141, 959, 25, ""),
					new(5140, 957, 25, ""),
					new(5131, 972, 25, ""),
					new(5132, 973, 25, ""),
					new(5133, 973, 25, ""),
					new(5133, 974, 25, ""),
					new(5134, 975, 25, ""),
					new(5135, 975, 25, ""),
					new(5135, 976, 25, ""),
					new(5135, 978, 25, ""),
					new(5135, 979, 25, ""),
					new(5134, 979, 25, ""),
					new(5133, 980, 25, ""),
					new(5132, 980, 25, ""),
					new(5132, 981, 25, ""),
					new(5132, 982, 25, ""),
					new(5132, 984, 25, ""),
					new(5132, 985, 25, ""),
					new(5132, 986, 25, ""),
					new(5132, 988, 25, ""),
					new(5132, 989, 25, ""),
					new(5133, 991, 25, ""),
					new(5133, 992, 25, ""),
					new(5133, 993, 25, ""),
					new(5133, 994, 25, ""),
					new(5133, 995, 25, ""),
					new(5155, 1000, 11, ""),
					new(5152, 999, 0, ""),
					new(5151, 999, 0, ""),
					new(5155, 1002, 1, ""),
					new(5153, 1006, 35, ""),
					new(5154, 1007, 25, ""),
					new(5145, 961, 25, ""),
					new(5160, 991, 25, ""),
					new(5161, 991, 25, ""),
					new(5162, 991, 25, ""),
					new(5163, 991, 25, ""),
					new(5164, 991, 25, ""),
					new(5136, 977, 25, ""),
					new(5154, 1001, 0, ""),
					new(5144, 960, 25, ""),
					new(5141, 958, 25, ""),
					new(5131, 966, 25, ""),
					new(5132, 983, 25, ""),
					new(5156, 1009, 25, ""),
					new(5159, 1011, 25, ""),
					new(5167, 992, 25, ""),
					new(5134, 974, 25, ""),
					new(5155, 999, 1, ""),
					new(5157, 1010, 25, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(5160, 910, 0, ""),
					new(5236, 938, -33, ""),
					new(5136, 994, 0, ""),
					new(5307, 810, 0, ""),
				}),
				new("Blood", typeof(Static), 4653, "", new DecorationEntry[]
				{
					new(5217, 907, -30, ""),
					new(5245, 954, -30, ""),
					new(5133, 844, 0, ""),
					new(5274, 969, -40, ""),
					new(5268, 948, -33, ""),
					new(5147, 862, 0, ""),
					new(5277, 933, -40, ""),
					new(5264, 925, -27, ""),
					new(5153, 874, 10, ""),
					new(5173, 957, 0, ""),
					new(5247, 969, -40, ""),
					new(5247, 898, -30, ""),
					new(5192, 969, 0, ""),
				}),
				new("Stalagmites", typeof(Static), 2282, "", new DecorationEntry[]
				{
					new(5163, 1004, 0, ""),
					new(5138, 957, 25, ""),
					new(5134, 957, 25, ""),
					new(5133, 957, 25, ""),
					new(5133, 958, 35, ""),
					new(5132, 959, 25, ""),
					new(5170, 993, 25, ""),
					new(5131, 962, 25, ""),
					new(5165, 996, 0, ""),
					new(5166, 997, 0, ""),
					new(5166, 999, 8, ""),
					new(5160, 998, -2, ""),
					new(5164, 1000, 5, ""),
					new(5165, 999, -2, ""),
					new(5165, 1000, -5, ""),
					new(5162, 1001, -5, ""),
					new(5164, 1001, -5, ""),
					new(5166, 1002, -2, ""),
					new(5168, 1002, 0, ""),
					new(5169, 993, 25, ""),
					new(5160, 1003, 0, ""),
					new(5137, 957, 25, ""),
					new(5135, 957, 25, ""),
					new(5133, 958, 25, ""),
					new(5131, 958, 25, ""),
					new(5131, 959, 25, ""),
					new(5131, 960, 25, ""),
					new(5131, 961, 25, ""),
					new(5131, 963, 25, ""),
					new(5131, 964, 25, ""),
					new(5161, 996, 0, ""),
					new(5162, 996, 0, ""),
					new(5163, 996, 0, ""),
					new(5160, 997, 0, ""),
					new(5161, 997, -2, ""),
					new(5163, 997, -2, ""),
					new(5164, 997, -2, ""),
					new(5167, 998, 0, ""),
					new(5167, 999, 10, ""),
					new(5164, 998, -2, ""),
					new(5164, 999, 5, ""),
					new(5162, 999, 5, ""),
					new(5161, 999, 5, ""),
					new(5160, 999, -2, ""),
					new(5161, 999, -5, ""),
					new(5162, 999, -5, ""),
					new(5164, 999, -5, ""),
					new(5166, 999, -2, ""),
					new(5168, 999, 0, ""),
					new(5168, 1000, 0, ""),
					new(5166, 1000, -2, ""),
					new(5164, 1000, -5, ""),
					new(5162, 1000, -5, ""),
					new(5161, 1000, -5, ""),
					new(5160, 1000, -2, ""),
					new(5166, 1003, 0, ""),
					new(5164, 1003, -2, ""),
					new(5160, 1004, 0, ""),
					new(5163, 1002, -5, ""),
					new(5171, 993, 25, ""),
					new(5172, 993, 25, ""),
					new(5173, 995, 35, ""),
					new(5173, 996, 35, ""),
					new(5173, 995, 25, ""),
					new(5174, 996, 25, ""),
					new(5174, 998, 35, ""),
					new(5174, 999, 35, ""),
					new(5174, 998, 25, ""),
					new(5175, 999, 25, ""),
					new(5176, 999, 25, ""),
					new(5177, 999, 25, ""),
					new(5175, 1000, 12, ""),
					new(5162, 1004, 0, ""),
					new(5136, 957, 25, ""),
					new(5164, 1004, 0, ""),
					new(5165, 1004, 0, ""),
					new(5132, 958, 25, ""),
					new(5160, 996, 0, ""),
					new(5162, 997, -2, ""),
					new(5163, 999, 5, ""),
					new(5164, 1001, 5, ""),
					new(5160, 1001, -2, ""),
					new(5161, 1001, -2, ""),
					new(5163, 1001, -5, ""),
					new(5166, 1002, 8, ""),
					new(5168, 1003, 0, ""),
					new(5165, 1003, -2, ""),
					new(5163, 1003, -2, ""),
					new(5162, 1003, -2, ""),
					new(5161, 1003, 0, ""),
					new(5161, 1004, 0, ""),
					new(5168, 993, 25, ""),
					new(5173, 996, 25, ""),
					new(5174, 999, 25, ""),
					new(5178, 999, 25, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(5133, 849, 0, ""),
					new(5324, 977, 0, ""),
					new(5154, 993, 0, ""),
					new(5309, 803, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5285, 850, 0, ""),
					new(5136, 959, 0, ""),
					new(5175, 830, 1, ""),
					new(5249, 940, -39, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(5144, 907, 0, ""),
					new(5311, 982, 0, ""),
					new(5311, 982, 3, ""),
					new(5311, 983, 0, ""),
					new(5311, 983, 3, ""),
					new(5311, 983, 6, ""),
					new(5312, 983, 0, ""),
				}),
				new("Empty Tub", typeof(Static), 3715, "", new DecorationEntry[]
				{
					new(5178, 845, 0, ""),
					new(5176, 848, 0, ""),
				}),
				new("Blood Smear", typeof(Static), 4655, "", new DecorationEntry[]
				{
					new(5263, 981, -30, ""),
					new(5271, 980, -27, ""),
					new(5265, 916, -40, ""),
					new(5254, 956, -30, ""),
					new(5177, 958, 0, ""),
					new(5200, 964, -27, ""),
					new(5183, 956, 0, ""),
					new(5248, 970, -30, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(5239, 944, -40, ""),
					new(5262, 899, -40, ""),
					new(5151, 990, 0, ""),
					new(5303, 809, 0, ""),
					new(5325, 983, 0, ""),
					new(5175, 1010, 0, ""),
				}),
				new("Blood", typeof(Static), 4654, "", new DecorationEntry[]
				{
					new(5247, 924, -40, ""),
					new(5183, 956, 0, ""),
					new(5142, 862, 10, ""),
					new(5246, 897, -40, ""),
					new(5181, 958, 0, ""),
					new(5221, 935, -39, ""),
					new(5130, 851, 10, ""),
					new(5255, 947, -34, ""),
				}),
				new("Stalagmites", typeof(Static), 2276, "", new DecorationEntry[]
				{
					new(5246, 837, 20, ""),
				}),
				new("Mushroom", typeof(Static), 3350, "", new DecorationEntry[]
				{
					new(5257, 790, 0, ""),
					new(5250, 850, 4, ""),
					new(5146, 905, 0, ""),
					new(5132, 841, 0, ""),
					new(5124, 904, 0, ""),
					new(5128, 898, 0, ""),
					new(5129, 898, 0, ""),
					new(5129, 899, 0, ""),
					new(5130, 898, 0, ""),
					new(5137, 901, 0, ""),
					new(5134, 847, 0, ""),
					new(5137, 902, 0, ""),
					new(5139, 905, 0, ""),
					new(5134, 840, 0, ""),
					new(5136, 843, 0, ""),
					new(5250, 794, 0, ""),
					new(5255, 794, 0, ""),
					new(5256, 793, 0, ""),
					new(5257, 794, 0, ""),
					new(5242, 788, 0, ""),
					new(5245, 791, 0, ""),
					new(5131, 899, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(5157, 901, 0, ""),
					new(5133, 964, 0, ""),
					new(5133, 967, 0, ""),
				}),
				new("Bones", typeof(Static), 3793, "", new DecorationEntry[]
				{
					new(5139, 831, 0, ""),
				}),
				new("Blood", typeof(Static), 4651, "", new DecorationEntry[]
				{
					new(5271, 968, -40, ""),
					new(5217, 907, -30, ""),
					new(5221, 935, -39, ""),
					new(5250, 909, -37, ""),
					new(5140, 857, 0, ""),
					new(5192, 970, 10, ""),
					new(5194, 961, 0, ""),
					new(5175, 957, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5205, 778, 0, ""),
					new(5311, 981, 0, ""),
					new(5311, 985, 0, ""),
					new(5175, 1009, 0, ""),
					new(5175, 1011, 0, ""),
					new(5163, 864, 0, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(5176, 1014, 0, ""),
					new(5179, 1014, 0, ""),
					new(5176, 1013, 0, ""),
					new(5176, 1014, 5, ""),
					new(5229, 828, 2, ""),
					new(5314, 776, 0, ""),
					new(5228, 828, 1, ""),
				}),
				new("Small Crate", typeof(SmallCrate), 2473, "", new DecorationEntry[]
				{
					new(5304, 809, 0, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(5277, 804, 1, ""),
					new(5196, 918, -40, ""),
				}),
				new("Blood", typeof(Static), 4652, "", new DecorationEntry[]
				{
					new(5184, 939, 0, ""),
					new(5271, 968, -40, ""),
					new(5181, 956, 0, ""),
					new(5234, 988, -15, ""),
					new(5278, 929, -40, ""),
					new(5217, 912, -30, ""),
				}),
				new("Flowstone", typeof(Static), 2274, "", new DecorationEntry[]
				{
					new(5139, 799, 0, ""),
				}),
				new("Blood", typeof(Static), 4650, "", new DecorationEntry[]
				{
					new(5217, 907, -30, ""),
					new(5180, 954, 0, ""),
					new(5202, 963, -29, ""),
					new(5244, 990, -28, ""),
				}),
				new("Dirty Pot", typeof(Static), 2534, "", new DecorationEntry[]
				{
					new(5153, 873, 0, ""),
				}),
				new("Knife", typeof(Knife), 2470, "", new DecorationEntry[]
				{
					new(5153, 871, 0, ""),
				}),
				new("Flowstone", typeof(Static), 2275, "", new DecorationEntry[]
				{
					new(5140, 799, 0, ""),
				}),
				new("Stalagmites", typeof(Static), 2273, "", new DecorationEntry[]
				{
					new(5140, 801, 0, ""),
					new(5139, 802, 0, ""),
					new(5139, 800, 0, ""),
					new(5140, 800, 0, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(5311, 800, 0, ""),
				}),
				new("Key Ring", typeof(Static), 4113, "", new DecorationEntry[]
				{
					new(5310, 804, 0, ""),
				}),
				new("Mace", typeof(Static), 3932, "", new DecorationEntry[]
				{
					new(5308, 805, 0, ""),
				}),
				new("Spoon", typeof(Spoon), 2499, "", new DecorationEntry[]
				{
					new(5152, 869, 0, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(5152, 873, 0, ""),
				}),
				new("Dirty Pot", typeof(Static), 2524, "", new DecorationEntry[]
				{
					new(5153, 868, 0, ""),
				}),
				new("Spoon", typeof(Spoon), 2553, "", new DecorationEntry[]
				{
					new(5157, 869, 0, ""),
				}),
				new("Dirty Pot", typeof(Static), 2527, "", new DecorationEntry[]
				{
					new(5156, 869, 0, ""),
					new(5201, 913, -40, ""),
				}),
				new("Bowl Of Lettuce", typeof(Static), 5632, "", new DecorationEntry[]
				{
					new(5156, 868, 0, ""),
				}),
				new("Iron Fence", typeof(Static), 2081, "", new DecorationEntry[]
				{
					new(5196, 793, 0, ""),
					new(5196, 794, 0, ""),
					new(5196, 795, 0, ""),
				}),
				new("Dirty Frypan", typeof(Static), 2526, "", new DecorationEntry[]
				{
					new(5201, 912, -40, ""),
				}),
				
				#endregion
			});
		}
	}
}
