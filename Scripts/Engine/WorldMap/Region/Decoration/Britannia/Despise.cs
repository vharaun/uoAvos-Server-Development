using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Despise { get; } = Register(DecorationTarget.Britannia, "Despise", new DecorationList[]
			{
				#region Entries
				
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(5408, 607, 45, ""),
					new(5384, 552, 60, ""),
					new(5487, 631, 28, ""),
					new(5488, 630, 25, ""),
					new(5488, 631, 25, ""),
					new(5488, 631, 28, ""),
					new(5491, 574, 59, ""),
					new(5491, 574, 62, ""),
					new(5492, 574, 60, ""),
					new(5492, 574, 63, ""),
					new(5492, 576, 58, ""),
					new(5493, 574, 60, ""),
					new(5497, 623, 25, ""),
					new(5476, 898, 30, ""),
					new(5505, 629, 28, ""),
					new(5479, 560, 60, ""),
					new(5489, 575, 59, ""),
					new(5497, 520, 60, ""),
					new(5497, 624, 25, ""),
					new(5500, 520, 60, ""),
					new(5505, 629, 25, ""),
					new(5487, 631, 25, ""),
					new(5407, 612, 45, ""),
					new(5505, 629, 31, ""),
					new(5487, 631, 31, ""),
					new(5407, 612, 48, ""),
					new(5384, 521, 65, ""),
					new(5384, 552, 63, ""),
					new(5384, 552, 66, ""),
					new(5384, 553, 60, ""),
					new(5384, 554, 60, ""),
					new(5384, 555, 60, ""),
					new(5384, 555, 63, ""),
					new(5384, 555, 66, ""),
					new(5385, 525, 65, ""),
					new(5385, 527, 65, ""),
					new(5385, 552, 60, ""),
					new(5385, 552, 63, ""),
					new(5385, 679, 20, ""),
					new(5498, 520, 60, ""),
					new(5386, 552, 63, ""),
					new(5386, 552, 66, ""),
					new(5407, 611, 45, ""),
					new(5407, 611, 48, ""),
					new(5407, 611, 51, ""),
					new(5407, 613, 45, ""),
					new(5407, 613, 48, ""),
					new(5407, 613, 51, ""),
					new(5408, 613, 45, ""),
					new(5384, 522, 65, ""),
					new(5384, 525, 65, ""),
					new(5384, 526, 65, ""),
					new(5384, 526, 68, ""),
					new(5384, 527, 65, ""),
					new(5384, 553, 63, ""),
					new(5384, 556, 60, ""),
					new(5386, 552, 60, ""),
					new(5408, 613, 48, ""),
					new(5479, 560, 63, ""),
					new(5479, 561, 60, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(5485, 622, 31, ""),
					new(5490, 535, 60, ""),
					new(5491, 624, 25, ""),
					new(5485, 622, 25, ""),
					new(5485, 622, 28, ""),
					new(5487, 623, 25, ""),
					new(5489, 532, 60, ""),
					new(5489, 535, 60, ""),
					new(5598, 835, 50, ""),
					new(5544, 903, 10, ""),
					new(5612, 780, 60, ""),
					new(5613, 777, 60, ""),
					new(5384, 680, 20, ""),
					new(5433, 780, 60, ""),
					new(5484, 622, 25, ""),
					new(5484, 622, 28, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(5385, 520, 65, ""),
					new(5489, 528, 65, ""),
					new(5489, 528, 60, ""),
					new(5490, 528, 60, ""),
					new(5488, 534, 60, ""),
					new(5488, 532, 65, ""),
					new(5488, 532, 60, ""),
					new(5388, 552, 60, ""),
					new(5490, 528, 65, ""),
					new(5388, 553, 60, ""),
					new(5489, 631, 25, ""),
					new(5389, 552, 60, ""),
					new(5389, 553, 60, ""),
					new(5390, 552, 60, ""),
					new(5391, 552, 60, ""),
					new(5391, 552, 65, ""),
					new(5389, 552, 65, ""),
					new(5390, 552, 65, ""),
					new(5490, 573, 60, ""),
					new(5493, 528, 60, ""),
					new(5496, 528, 60, ""),
					new(5390, 552, 70, ""),
					new(5507, 520, 60, ""),
					new(5489, 630, 30, ""),
					new(5490, 630, 25, ""),
					new(5496, 522, 60, ""),
					new(5494, 625, 25, ""),
					new(5494, 625, 30, ""),
					new(5407, 605, 45, ""),
					new(5384, 681, 20, ""),
					new(5389, 528, 65, ""),
					new(5489, 630, 25, ""),
					new(5392, 520, 65, ""),
					new(5390, 528, 65, ""),
					new(5564, 899, 30, ""),
					new(5491, 528, 60, ""),
					new(5493, 529, 60, ""),
					new(5501, 528, 60, ""),
					new(5506, 520, 60, ""),
					new(5393, 520, 65, ""),
					new(5388, 552, 65, ""),
					new(5496, 522, 65, ""),
					new(5407, 605, 50, ""),
					new(5408, 605, 45, ""),
					new(5390, 528, 70, ""),
					new(5384, 529, 65, ""),
					new(5389, 529, 65, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(5388, 601, 45, ""),
					new(5488, 531, 60, ""),
					new(5488, 530, 60, ""),
					new(5388, 522, 65, ""),
					new(5510, 813, 60, ""),
					new(5510, 812, 60, ""),
					new(5386, 585, 45, ""),
					new(5608, 822, 60, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1735, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5387, 693, 20, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(5408, 929, 20, ""),
					new(5512, 656, 30, ""),
					new(5387, 698, 15, ""),
					new(5479, 564, 60, ""),
					new(5604, 807, 60, ""),
				}),
				new("Dirty Pot", typeof(Static), 2535, "", new DecorationEntry[]
				{
					new(5392, 525, 66, ""),
					new(5400, 590, 45, ""),
				}),
				new("Cauldron", typeof(Static), 2421, "", new DecorationEntry[]
				{
					new(5398, 907, 31, ""),
					new(5413, 723, 16, ""),
					new(5410, 664, 20, ""),
					new(5459, 741, 5, ""),
				}),
				new("Mushroom", typeof(Static), 3350, "", new DecorationEntry[]
				{
					new(5445, 977, 15, ""),
					new(5400, 929, 20, ""),
					new(5406, 932, 20, ""),
					new(5425, 878, 30, ""),
					new(5496, 542, 60, ""),
					new(5405, 920, 20, ""),
					new(5407, 575, 60, ""),
					new(5423, 893, 30, ""),
					new(5405, 885, 30, ""),
					new(5412, 881, 30, ""),
					new(5413, 892, 30, ""),
					new(5428, 906, 30, ""),
					new(5453, 970, 15, ""),
					new(5415, 904, 30, ""),
					new(5448, 533, 60, ""),
					new(5421, 527, 60, ""),
					new(5427, 957, 15, ""),
					new(5401, 576, 60, ""),
					new(5418, 909, 30, ""),
					new(5413, 934, 20, ""),
					new(5391, 896, 30, ""),
					new(5435, 557, 60, ""),
					new(5484, 544, 60, ""),
					new(5401, 918, 20, ""),
					new(5445, 962, 15, ""),
					new(5384, 897, 30, ""),
					new(5386, 888, 30, ""),
				}),
				new("Dirty Pot", typeof(Static), 2525, "", new DecorationEntry[]
				{
					new(5495, 624, 25, ""),
					new(5490, 623, 25, ""),
					new(5486, 631, 25, ""),
					new(5497, 625, 25, ""),
				}),
				new("Water", typeof(Static), 6043, "", new DecorationEntry[]
				{
					new(5401, 703, 14, ""),
					new(5395, 704, 14, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2453, "", new DecorationEntry[]
				{
					new(5497, 563, 65, ""),
					new(5506, 527, 60, ""),
					new(5499, 561, 65, ""),
					new(5508, 526, 60, ""),
					new(5501, 524, 60, ""),
					new(5503, 523, 60, ""),
					new(5503, 533, 60, ""),
					new(5504, 524, 60, ""),
					new(5505, 531, 60, ""),
				}),
				new("Keg", typeof(Keg), 3711, "", new DecorationEntry[]
				{
					new(5495, 625, 25, ""),
					new(5493, 625, 25, ""),
					new(5507, 653, 20, ""),
				}),
				new("Switch", typeof(Static), 4242, "", new DecorationEntry[]
				{
					new(5425, 569, 78, ""),
					new(5506, 625, 39, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(5395, 1004, 5, ""),
					new(5451, 870, 45, ""),
					new(5388, 698, 15, ""),
					new(5385, 698, 15, ""),
					new(5572, 895, 30, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(5490, 529, 60, ""),
					new(5514, 803, 60, ""),
					new(5565, 900, 30, ""),
				}),
				new("Small Crate", typeof(SmallCrate), 2473, "", new DecorationEntry[]
				{
					new(5517, 809, 60, ""),
					new(5613, 779, 60, ""),
					new(5385, 680, 20, ""),
					new(5387, 680, 20, ""),
					new(5391, 522, 65, ""),
				}),
				new("Dirty Frypan", typeof(Static), 2526, "", new DecorationEntry[]
				{
					new(5484, 622, 31, ""),
					new(5487, 624, 25, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(5390, 552, 60, ""),
					new(5496, 522, 60, ""),
					new(5489, 631, 25, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(5510, 660, 20, ""),
					new(5567, 897, 30, ""),
					new(5615, 776, 60, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(5504, 650, 30, ""),
					new(5384, 656, 30, ""),
					new(5539, 877, 30, ""),
					new(5386, 698, 15, ""),
					new(5505, 656, 30, ""),
					new(5391, 703, 15, ""),
					new(5614, 776, 60, ""),
					new(5401, 932, 20, ""),
					new(5587, 815, 45, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5553, 831, 45, ""),
					new(5567, 900, 30, ""),
					new(5390, 604, 30, ""),
					new(5394, 600, 45, ""),
					new(5555, 824, 45, ""),
					new(5387, 587, 45, ""),
					new(5539, 872, 45, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(5502, 541, 61, ""),
					new(5391, 966, 15, ""),
					new(5434, 853, 45, ""),
				}),
				new("Crate", typeof(SmallCrate), 3710, "", new DecorationEntry[]
				{
					new(5440, 843, 45, ""),
					new(5516, 808, 60, ""),
					new(5387, 590, 45, ""),
					new(5466, 826, 60, ""),
					new(5500, 536, 60, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5568, 899, 30, ""),
					new(5392, 981, 5, ""),
					new(5565, 824, 45, ""),
					new(5382, 658, 30, ""),
					new(5384, 819, 60, ""),
					new(5384, 820, 60, ""),
					new(5504, 532, 62, ""),
					new(5390, 698, 15, ""),
					new(5479, 563, 60, ""),
					new(5472, 760, 5, ""),
					new(5472, 761, 5, ""),
					new(5401, 978, 5, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1733, "Facing=WestCW", new DecorationEntry[]
				{
					new(5386, 693, 20, ""),
				}),
				new("Pot", typeof(Static), 2533, "", new DecorationEntry[]
				{
					new(5389, 527, 65, ""),
					new(5385, 525, 68, ""),
				}),
				new("Dirty Pot", typeof(Static), 2527, "", new DecorationEntry[]
				{
					new(5389, 591, 45, ""),
					new(5390, 591, 45, ""),
				}),
				new("Dirty Pan", typeof(Static), 2536, "", new DecorationEntry[]
				{
					new(5389, 591, 45, ""),
					new(5393, 586, 45, ""),
					new(5497, 523, 60, ""),
					new(5497, 527, 60, ""),
					new(5503, 533, 60, ""),
					new(5504, 524, 60, ""),
					new(5504, 530, 60, ""),
				}),
				new("Dirty Pot", typeof(Static), 2524, "", new DecorationEntry[]
				{
					new(5390, 525, 65, ""),
					new(5497, 564, 65, ""),
					new(5502, 531, 60, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(5391, 526, 65, ""),
					new(5500, 523, 60, ""),
				}),
				new("Water", typeof(Static), 6039, "", new DecorationEntry[]
				{
					new(5395, 705, 14, ""),
				}),
				new("Water", typeof(Static), 6044, "", new DecorationEntry[]
				{
					new(5395, 707, 14, ""),
				}),
				new("Water", typeof(Static), 6042, "", new DecorationEntry[]
				{
					new(5396, 705, 14, ""),
					new(5399, 703, 14, ""),
					new(5395, 703, 14, ""),
					new(5400, 703, 14, ""),
				}),
				new("Water", typeof(Static), 6041, "", new DecorationEntry[]
				{
					new(5397, 703, 14, ""),
					new(5397, 705, 14, ""),
				}),
				new("Ankh", typeof(RejuvinationAnkhWest), 3, "", new DecorationEntry[]
				{
					new(5425, 570, 65, ""),
				}),
				new("Fire Pit", typeof(Static), 4012, "", new DecorationEntry[]
				{
					new(5502, 541, 60, ""),
				}),
				new("Gruesome Standard", typeof(Static), 1055, "", new DecorationEntry[]
				{
					new(5507, 539, 70, ""),
				}),
				new("Blood Smear", typeof(Static), 4655, "", new DecorationEntry[]
				{
					new(5410, 550, 60, ""),
					new(5413, 549, 60, ""),
				}),
				new("Crystal Ball", typeof(Static), 3631, "", new DecorationEntry[]
				{
					new(5450, 1004, 19, ""),
				}),
				new("Stone", typeof(Static), 1955, "", new DecorationEntry[]
				{
					new(5453, 612, 45, ""),
				}),
				new("Stone", typeof(Static), 1928, "", new DecorationEntry[]
				{
					new(5458, 610, 45, ""),
				}),
				new("Ankh", typeof(RejuvinationAnkhNorth), 4, "", new DecorationEntry[]
				{
					new(5474, 525, 79, ""),
				}),
				new("Dirty Pot", typeof(Static), 2534, "", new DecorationEntry[]
				{
					new(5480, 630, 25, ""),
					new(5503, 529, 60, ""),
				}),
				new("Bone Arms", typeof(Static), 5203, "", new DecorationEntry[]
				{
					new(5561, 905, 30, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2506, "", new DecorationEntry[]
				{
					new(5498, 528, 60, ""),
					new(5502, 533, 60, ""),
				}),
				new("Skeleton", typeof(Static), 7039, "", new DecorationEntry[]
				{
					new(5501, 560, 65, ""),
				}),
				new("Campfire", typeof(Static), 3555, "", new DecorationEntry[]
				{
					new(5502, 541, 60, ""),
				}),
				new("Garbage", typeof(Static), 4334, "", new DecorationEntry[]
				{
					new(5502, 534, 60, ""),
				}),
				new("Skull Mug", typeof(Static), 4093, "", new DecorationEntry[]
				{
					new(5507, 529, 60, ""),
				}),
				
				#endregion
			});
		}
	}
}
