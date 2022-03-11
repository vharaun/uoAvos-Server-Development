using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Deceit { get; } = Register(DecorationTarget.Britannia, "Deceit", new DecorationList[]
			{
				#region Entries
				
				new("Stone Pavers", typeof(Static), 1309, "", new DecorationEntry[]
				{
					new(5194, 579, 5, ""),
					new(5177, 572, 5, ""),
					new(5178, 572, 5, ""),
					new(5179, 572, 5, ""),
					new(5180, 572, 5, ""),
					new(5182, 572, 5, ""),
					new(5198, 579, 5, ""),
					new(5197, 579, 5, ""),
					new(5196, 579, 5, ""),
					new(5195, 579, 5, ""),
					new(5193, 579, 5, ""),
					new(5192, 579, 5, ""),
					new(5181, 572, 5, ""),
					new(5183, 572, 5, ""),
					new(5183, 579, 5, ""),
					new(5182, 579, 5, ""),
					new(5181, 579, 5, ""),
					new(5180, 579, 5, ""),
					new(5179, 579, 5, ""),
					new(5178, 579, 5, ""),
					new(5177, 579, 5, ""),
					new(5198, 572, 5, ""),
					new(5197, 572, 5, ""),
					new(5196, 572, 5, ""),
					new(5194, 572, 5, ""),
					new(5193, 572, 5, ""),
					new(5192, 572, 5, ""),
					new(5195, 572, 5, ""),
				}),
				new("Stone", typeof(Static), 1955, "", new DecorationEntry[]
				{
					new(5194, 579, 0, ""),
					new(5195, 579, 0, ""),
					new(5196, 579, 0, ""),
					new(5310, 740, 0, ""),
					new(5322, 740, 0, ""),
					new(5183, 579, 0, ""),
					new(5178, 579, 0, ""),
					new(5179, 579, 0, ""),
					new(5180, 579, 0, ""),
					new(5181, 579, 0, ""),
					new(5182, 579, 0, ""),
					new(5177, 579, 0, ""),
					new(5177, 572, 0, ""),
					new(5178, 572, 0, ""),
					new(5179, 572, 0, ""),
					new(5180, 572, 0, ""),
					new(5181, 572, 0, ""),
					new(5182, 572, 0, ""),
					new(5183, 572, 0, ""),
					new(5193, 579, 0, ""),
					new(5197, 579, 0, ""),
					new(5198, 579, 0, ""),
					new(5192, 579, 0, ""),
					new(5198, 572, 0, ""),
					new(5197, 572, 0, ""),
					new(5196, 572, 0, ""),
					new(5193, 572, 0, ""),
					new(5194, 572, 0, ""),
					new(5195, 572, 0, ""),
					new(5192, 572, 0, ""),
					new(5314, 740, 0, ""),
					new(5318, 740, 0, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(5281, 536, 0, ""),
					new(5281, 536, 10, ""),
					new(5282, 536, 0, ""),
					new(5336, 613, 0, ""),
					new(5336, 613, 5, ""),
					new(5280, 536, 0, ""),
					new(5281, 536, 5, ""),
					new(5296, 592, 5, ""),
					new(5296, 594, 0, ""),
					new(5300, 593, 0, ""),
					new(5298, 592, 0, ""),
					new(5296, 592, 0, ""),
					new(5296, 593, 0, ""),
					new(5296, 593, 5, ""),
					new(5297, 592, 0, ""),
					new(5297, 592, 5, ""),
					new(5280, 536, 5, ""),
					new(5280, 537, 0, ""),
					new(5192, 584, 0, ""),
					new(5197, 584, 0, ""),
					new(5197, 584, 5, ""),
					new(5197, 585, 0, ""),
					new(5197, 585, 5, ""),
					new(5198, 584, 0, ""),
					new(5198, 585, 0, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4512, "", new DecorationEntry[]
				{
					new(5133, 713, 0, ""),
					new(5322, 747, -20, ""),
					new(5220, 744, -20, ""),
					new(5187, 690, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(5150, 741, 0, ""),
					new(5312, 750, -20, ""),
					new(5141, 577, -50, ""),
				}),
				new("Crystal Ball", typeof(Static), 3631, "", new DecorationEntry[]
				{
					new(5211, 733, -15, ""),
					new(5228, 733, -17, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(5280, 541, 0, ""),
					new(5280, 541, 3, ""),
					new(5280, 543, 3, ""),
					new(5280, 701, 0, ""),
					new(5280, 701, 3, ""),
					new(5284, 688, 0, ""),
					new(5288, 611, 0, ""),
					new(5288, 611, 3, ""),
					new(5288, 612, 0, ""),
					new(5280, 700, 0, ""),
					new(5280, 700, 3, ""),
					new(5285, 688, 0, ""),
					new(5184, 629, 3, ""),
					new(5280, 542, 0, ""),
					new(5280, 542, 3, ""),
					new(5280, 542, 6, ""),
					new(5280, 543, 0, ""),
					new(5280, 543, 6, ""),
					new(5184, 629, 0, ""),
					new(5184, 629, 6, ""),
				}),
				new("Scroll%S%", typeof(Static), 3638, "", new DecorationEntry[]
				{
					new(5270, 664, 5, ""),
					new(5218, 724, -20, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4506, "", new DecorationEntry[]
				{
					new(5134, 715, 0, ""),
					new(5193, 689, 0, ""),
					new(5326, 745, -20, ""),
					new(5228, 701, -20, ""),
					new(5222, 733, -20, ""),
				}),
				new("Stone Stairs", typeof(Static), 1956, "", new DecorationEntry[]
				{
					new(5305, 531, 10, ""),
					new(5306, 649, 15, ""),
					new(5183, 573, 1, ""),
					new(5217, 587, -20, ""),
					new(5218, 762, -35, ""),
					new(5217, 586, -15, ""),
					new(5183, 580, 0, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(5280, 573, 0, ""),
					new(5280, 573, 6, ""),
					new(5283, 648, 0, ""),
					new(5340, 544, 0, ""),
					new(5341, 544, 0, ""),
					new(5285, 648, 3, ""),
					new(5339, 544, 0, ""),
					new(5340, 544, 3, ""),
					new(5341, 544, 3, ""),
					new(5341, 544, 6, ""),
					new(5342, 544, 0, ""),
					new(5342, 544, 3, ""),
					new(5342, 544, 6, ""),
					new(5342, 544, 9, ""),
					new(5284, 648, 0, ""),
					new(5285, 649, 0, ""),
					new(5285, 648, 0, ""),
					new(5280, 573, 3, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(5147, 611, -50, "// spawning"),
					new(5324, 570, 0, "// spawning"),
					new(5327, 751, -20, "// spawning"),
					new(5264, 676, 5, "// spawning"),
				}),
				new("Brazier", typeof(Brazier), 3634, "", new DecorationEntry[]
				{
					new(5294, 625, -5, ""),
					new(5297, 625, -5, ""),
					new(5294, 622, -5, ""),
					new(5297, 622, -5, ""),
					new(5309, 737, 0, ""),
				}),
				new("Scroll%S%", typeof(Static), 3642, "", new DecorationEntry[]
				{
					new(5315, 585, 0, ""),
					new(5188, 585, 0, ""),
					new(5161, 693, 0, ""),
				}),
				new("Stone Face", typeof(StoneFaceTrap), 4348, "", new DecorationEntry[]
				{
					new(5319, 581, 0, ""),
				}),
				new("Lever", typeof(Static), 4236, "", new DecorationEntry[]
				{
					new(5320, 568, 0, ""),
					new(5328, 544, 15, ""),
					new(5280, 552, 0, ""),
				}),
				new("Dungeon Wall", typeof(SecretDungeonDoor), 798, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5295, 675, 0, ""),
					new(5279, 649, 0, ""),
					new(5319, 708, 0, ""),
					new(5322, 583, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(5264, 693, 0, "// spawning"),
					new(5325, 570, 0, "// spawning"),
					new(5270, 688, 0, "// spawning"),
					new(5256, 677, 0, "// spawning"),
				}),
				new("Floor Saw", typeof(SawTrap), 4529, "", new DecorationEntry[]
				{
					new(5219, 725, -20, ""),
					new(5222, 734, -20, ""),
					new(5189, 652, 0, ""),
					new(5178, 661, 0, ""),
					new(5325, 748, -20, ""),
					new(5303, 736, 0, ""),
					new(5222, 712, -20, ""),
					new(5220, 685, -20, ""),
					new(5304, 735, 0, ""),
				}),
				new("Wand", typeof(Static), 3572, "", new DecorationEntry[]
				{
					new(5228, 694, -20, ""),
					new(5228, 730, -14, ""),
					new(5188, 694, 5, ""),
					new(5230, 562, 0, ""),
					new(5310, 589, 0, ""),
				}),
				new("Statue", typeof(Static), 4647, "", new DecorationEntry[]
				{
					new(5327, 538, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5153, 739, 0, "// spawning"),
					new(5150, 627, -50, "// spawning"),
					new(5144, 627, -50, "// spawning"),
					new(5320, 754, -20, "// spawning"),
					new(5203, 584, 0, "// spawning"),
				}),
				new("Studded Gorget", typeof(Static), 5078, "", new DecorationEntry[]
				{
					new(5201, 620, 0, ""),
					new(5334, 680, 0, ""),
				}),
				new("Scroll%S%", typeof(Static), 3833, "", new DecorationEntry[]
				{
					new(5292, 621, 0, ""),
					new(5187, 660, 0, ""),
				}),
				new("Woven Mat", typeof(Static), 4584, "", new DecorationEntry[]
				{
					new(5337, 549, 0, ""),
				}),
				new("Scroll%S%", typeof(Static), 3828, "", new DecorationEntry[]
				{
					new(5337, 589, 0, ""),
				}),
				new("Woven Mat", typeof(Static), 4585, "", new DecorationEntry[]
				{
					new(5338, 549, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1743, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5319, 675, 0, ""),
					new(5295, 579, 0, ""),
					new(5287, 675, 0, ""),
					new(5311, 603, 0, ""),
					new(5303, 627, 0, ""),
					new(5311, 579, 0, ""),
					new(5191, 558, 0, ""),
				}),
				new("Butcher Knife", typeof(Static), 5110, "", new DecorationEntry[]
				{
					new(5153, 613, -50, ""),
					new(5142, 658, 0, ""),
					new(5311, 722, 0, ""),
				}),
				new("Alchemical Symbol", typeof(Static), 6178, "Hue=0x482", new DecorationEntry[]
				{
					new(5336, 600, 0, ""),
					new(5336, 585, 0, ""),
				}),
				new("Bones", typeof(Static), 3792, "", new DecorationEntry[]
				{
					new(5341, 548, 0, ""),
				}),
				new("Gas Trap", typeof(GasTrap), 4412, "", new DecorationEntry[]
				{
					new(5314, 750, -20, ""),
					new(5305, 757, -20, ""),
					new(5155, 603, -50, ""),
					new(5158, 716, 0, ""),
					new(5189, 650, 0, ""),
				}),
				new("Statue", typeof(Static), 4648, "", new DecorationEntry[]
				{
					new(5267, 683, 0, ""),
					new(5128, 700, 0, ""),
					new(5282, 586, 13, ""),
					new(5282, 582, 13, ""),
					new(5266, 674, 5, ""),
					new(5266, 677, 5, ""),
				}),
				new("Red Potion", typeof(Static), 3851, "", new DecorationEntry[]
				{
					new(5211, 724, -16, ""),
					new(5227, 723, -17, ""),
				}),
				new("Straw Pillow", typeof(Static), 4587, "", new DecorationEntry[]
				{
					new(5337, 549, 1, ""),
				}),
				new("Broadsword", typeof(Static), 3934, "", new DecorationEntry[]
				{
					new(5266, 682, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1961, "", new DecorationEntry[]
				{
					new(5184, 580, 0, ""),
					new(5184, 573, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1957, "", new DecorationEntry[]
				{
					new(5184, 579, 0, ""),
					new(5184, 572, 0, ""),
					new(5190, 569, 0, ""),
					new(5190, 568, 0, ""),
					new(5186, 568, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1962, "", new DecorationEntry[]
				{
					new(5184, 578, 0, ""),
					new(5184, 571, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1960, "", new DecorationEntry[]
				{
					new(5176, 578, 0, ""),
					new(5176, 571, 0, ""),
					new(5191, 578, 0, ""),
					new(5191, 571, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1959, "", new DecorationEntry[]
				{
					new(5176, 579, 0, ""),
					new(5191, 579, 0, ""),
					new(5191, 572, 0, ""),
					new(5176, 572, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1963, "", new DecorationEntry[]
				{
					new(5176, 580, 0, ""),
					new(5176, 573, 0, ""),
					new(5191, 580, 0, ""),
					new(5191, 573, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1967, "", new DecorationEntry[]
				{
					new(5177, 580, 0, ""),
					new(5177, 573, 0, ""),
					new(5192, 580, 0, ""),
					new(5192, 573, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1964, "", new DecorationEntry[]
				{
					new(5177, 571, 0, ""),
					new(5192, 578, 0, ""),
					new(5192, 571, 0, ""),
					new(5177, 578, 0, ""),
				}),
				new("Dungeon Wall", typeof(Static), 577, "", new DecorationEntry[]
				{
					new(5152, 687, 0, ""),
					new(5153, 687, 0, ""),
					new(5154, 687, 0, ""),
					new(5156, 687, 0, ""),
					new(5157, 687, 0, ""),
					new(5158, 687, 0, ""),
					new(5159, 687, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5317, 582, 0, "// spawning"),
					new(5169, 599, 0, "// spawning"),
					new(5224, 571, 0, "// spawning"),
					new(5256, 675, 0, "// spawning"),
				}),
				new("Statue", typeof(Static), 4645, "", new DecorationEntry[]
				{
					new(5320, 758, -20, ""),
					new(5137, 579, -50, ""),
				}),
				new("Floor Saw", typeof(SawTrap), 4524, "", new DecorationEntry[]
				{
					new(5315, 735, 0, ""),
					new(5153, 611, -50, ""),
					new(5204, 655, 0, ""),
					new(5133, 714, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(5318, 581, 0, "// spawning"),
					new(5264, 688, 0, "// spawning"),
					new(5201, 584, 0, "// spawning"),
					new(5229, 570, 0, "// spawning"),
				}),
				new("Metal Door", typeof(MetalDoor2), 1739, "Facing=EastCW", new DecorationEntry[]
				{
					new(5283, 663, 0, ""),
					new(5307, 687, 0, ""),
					new(5323, 591, 0, ""),
					new(5321, 575, 0, ""),
					new(5283, 695, 0, ""),
					new(5283, 687, 0, ""),
					new(5284, 575, 0, ""),
					new(5331, 695, 0, ""),
					new(5307, 695, 0, ""),
					new(5188, 567, 0, ""),
					new(5284, 551, 0, ""),
					new(5156, 735, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1741, "Facing=SouthCW", new DecorationEntry[]
				{
					new(5311, 580, 0, ""),
					new(5287, 699, 0, ""),
					new(5319, 676, 0, ""),
					new(5295, 580, 0, ""),
					new(5303, 699, 0, ""),
					new(5303, 628, 0, ""),
					new(5191, 559, 0, ""),
					new(5311, 604, 0, ""),
					new(5287, 676, 0, ""),
				}),
				new("Kite Shield", typeof(Static), 7028, "", new DecorationEntry[]
				{
					new(5298, 608, 0, ""),
					new(5230, 562, 0, ""),
				}),
				new("Empty Tub", typeof(Static), 3715, "", new DecorationEntry[]
				{
					new(5338, 544, 0, ""),
				}),
				new("Earrings", typeof(Static), 4231, "", new DecorationEntry[]
				{
					new(5325, 603, -20, ""),
					new(5230, 691, -20, ""),
					new(5226, 563, 0, ""),
				}),
				new("Feathered Hat", typeof(Static), 5914, "", new DecorationEntry[]
				{
					new(5174, 570, 0, ""),
				}),
				new("Mushroom", typeof(MushroomTrap), 4389, "", new DecorationEntry[]
				{
					new(5304, 757, -20, ""),
					new(5327, 743, -20, ""),
					new(5319, 747, -20, ""),
					new(5310, 750, -20, ""),
				}),
				new("Heating Stand", typeof(HeatingStand), 6218, "", new DecorationEntry[]
				{
					new(5205, 611, 4, ""),
				}),
				new("Dungeon Wall", typeof(SecretDungeonDoor), 790, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5266, 687, 0, ""),
				}),
				new("Dungeon Wall", typeof(SecretDungeonDoor), 794, "Facing=EastCW", new DecorationEntry[]
				{
					new(5178, 583, 0, ""),
				}),
				new("Keg", typeof(Keg), 3711, "", new DecorationEntry[]
				{
					new(5196, 584, 0, ""),
					new(5195, 584, 0, ""),
					new(5296, 596, 0, ""),
				}),
				new("Small Crate", typeof(SmallCrate), 2473, "", new DecorationEntry[]
				{
					new(5320, 569, 0, ""),
					new(5150, 746, 0, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(5296, 595, 0, ""),
					new(5296, 595, 3, ""),
					new(5280, 654, 0, ""),
					new(5280, 658, 0, ""),
					new(5280, 653, 0, ""),
				}),
				new("Cleaver", typeof(Static), 3779, "", new DecorationEntry[]
				{
					new(5319, 744, -20, ""),
					new(5334, 550, 0, ""),
					new(5281, 688, 0, ""),
					new(5313, 549, 0, ""),
				}),
				new("Kite Shield", typeof(Static), 7032, "", new DecorationEntry[]
				{
					new(5333, 614, 0, ""),
				}),
				new("Empty Vial%S%", typeof(Static), 3620, "", new DecorationEntry[]
				{
					new(5212, 723, -14, ""),
				}),
				new("Dried Onions", typeof(Static), 3135, "", new DecorationEntry[]
				{
					new(5224, 573, 0, ""),
				}),
				new("Switch", typeof(Static), 4242, "", new DecorationEntry[]
				{
					new(5293, 672, 11, ""),
				}),
				new("Viking Sword", typeof(Static), 5049, "", new DecorationEntry[]
				{
					new(5324, 624, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1737, "Facing=WestCCW", new DecorationEntry[]
				{
					new(5283, 575, 0, ""),
					new(5330, 695, 0, ""),
					new(5322, 591, 0, ""),
					new(5187, 567, 0, ""),
					new(5283, 551, 0, ""),
					new(5320, 575, 0, ""),
					new(5139, 688, 0, ""),
					new(5155, 735, 0, ""),
				}),
				new("Ring", typeof(Static), 4234, "", new DecorationEntry[]
				{
					new(5294, 587, 0, ""),
				}),
				new("Blank Scroll%S%", typeof(Static), 3827, "", new DecorationEntry[]
				{
					new(5211, 730, -17, ""),
					new(5211, 732, -16, ""),
					new(5202, 608, 0, ""),
				}),
				new("Deer Mask", typeof(Static), 5448, "", new DecorationEntry[]
				{
					new(5141, 680, 0, ""),
				}),
				new("Dagger", typeof(Static), 3921, "", new DecorationEntry[]
				{
					new(5286, 573, 0, ""),
				}),
				new("Shoes", typeof(Static), 5903, "", new DecorationEntry[]
				{
					new(5286, 566, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1733, "Facing=WestCW", new DecorationEntry[]
				{
					new(5309, 734, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1735, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5310, 734, 0, ""),
				}),
				new("Long Pants", typeof(Static), 5433, "Hue=0x25", new DecorationEntry[]
				{
					new(5286, 566, 0, ""),
				}),
				new("Stone Chair", typeof(Static), 4633, "", new DecorationEntry[]
				{
					new(5137, 578, -50, ""),
					new(5165, 565, 0, ""),
					new(5165, 567, 0, ""),
					new(5165, 569, 0, ""),
				}),
				new("Shackles", typeof(Static), 4706, "", new DecorationEntry[]
				{
					new(5137, 587, -37, ""),
					new(5137, 594, -37, ""),
					new(5137, 597, -37, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6232, "", new DecorationEntry[]
				{
					new(5138, 577, -45, ""),
					new(5167, 566, 6, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2455, "", new DecorationEntry[]
				{
					new(5138, 593, -50, ""),
					new(5139, 587, -50, ""),
					new(5142, 586, -50, ""),
					new(5153, 584, -50, ""),
					new(5153, 590, -50, ""),
				}),
				new("Iron Maiden", typeof(Static), 4683, "", new DecorationEntry[]
				{
					new(5138, 611, -50, ""),
				}),
				new("Guillotine", typeof(Static), 4702, "", new DecorationEntry[]
				{
					new(5141, 611, -50, ""),
				}),
				new("Shackles", typeof(Static), 4707, "", new DecorationEntry[]
				{
					new(5142, 584, -37, ""),
					new(5138, 584, -37, ""),
					new(5152, 577, -37, ""),
					new(5154, 577, -37, ""),
				}),
				new("Shirt", typeof(Static), 5399, "Hue=0x25", new DecorationEntry[]
				{
					new(5286, 566, 0, ""),
				}),
				new("Wooden Shield", typeof(Static), 7034, "", new DecorationEntry[]
				{
					new(5282, 548, 0, ""),
				}),
				new("White Potion", typeof(Static), 3849, "", new DecorationEntry[]
				{
					new(5210, 724, -16, ""),
				}),
				new("Statue", typeof(Static), 4646, "", new DecorationEntry[]
				{
					new(5321, 747, -8, ""),
					new(5313, 747, -8, ""),
				}),
				new("Dirty Pot", typeof(Static), 2525, "", new DecorationEntry[]
				{
					new(5151, 584, -50, ""),
				}),
				new("Dirty Pan", typeof(Static), 2536, "", new DecorationEntry[]
				{
					new(5153, 595, -50, ""),
				}),
				new("Dungeon Wall", typeof(SecretDungeonDoor), 796, "Facing=SouthCW", new DecorationEntry[]
				{
					new(5263, 672, 0, ""),
				}),
				new("Black Potion", typeof(Static), 3846, "", new DecorationEntry[]
				{
					new(5226, 722, -15, ""),
				}),
				new("Blue Potion", typeof(Static), 3848, "", new DecorationEntry[]
				{
					new(5228, 722, -18, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1683, "Facing=NorthCW", new DecorationEntry[]
				{
					new(5150, 579, -50, ""),
					new(5150, 586, -50, ""),
					new(5150, 597, -50, ""),
					new(5150, 605, -50, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1679, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5144, 588, -50, ""),
					new(5144, 595, -50, ""),
					new(5144, 604, -50, ""),
				}),
				new("Goblet", typeof(Static), 2495, "", new DecorationEntry[]
				{
					new(5166, 565, 0, ""),
					new(5166, 570, 0, ""),
					new(5167, 567, 0, ""),
					new(5167, 569, 0, ""),
					new(5168, 564, 0, ""),
					new(5168, 570, 0, ""),
					new(5166, 567, 0, ""),
					new(5167, 564, 0, ""),
					new(5168, 566, 0, ""),
					new(5168, 568, 0, ""),
					new(5167, 565, 0, ""),
				}),
				new("Stone Chair", typeof(Static), 4632, "", new DecorationEntry[]
				{
					new(5167, 563, 0, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6228, "", new DecorationEntry[]
				{
					new(5167, 568, 7, ""),
				}),
				new("Stone Chair", typeof(Static), 4634, "", new DecorationEntry[]
				{
					new(5167, 571, 0, ""),
				}),
				new("Stone Face", typeof(StoneFaceTrap), 4341, "", new DecorationEntry[]
				{
					new(5168, 584, 0, ""),
				}),
				new("Stone Face", typeof(StoneFaceTrap), 4367, "", new DecorationEntry[]
				{
					new(5168, 599, 0, ""),
				}),
				new("Stone Chair", typeof(Static), 4635, "", new DecorationEntry[]
				{
					new(5169, 567, 0, ""),
					new(5169, 569, 0, ""),
					new(5169, 565, 0, ""),
					new(5202, 597, 0, ""),
					new(5202, 599, 0, ""),
					new(5202, 601, 0, ""),
				}),
				new("Scroll%S%", typeof(Static), 3640, "", new DecorationEntry[]
				{
					new(5169, 573, 0, ""),
					new(5186, 548, 0, ""),
				}),
				new("Scroll%S%", typeof(Static), 3832, "", new DecorationEntry[]
				{
					new(5173, 692, 0, ""),
					new(5174, 665, 0, ""),
				}),
				new("Bone", typeof(Static), 6930, "", new DecorationEntry[]
				{
					new(5184, 605, 0, ""),
				}),
				new("Close Helm", typeof(Static), 5129, "", new DecorationEntry[]
				{
					new(5129, 690, 0, ""),
				}),
				new("Brazier", typeof(Brazier), 3633, "", new DecorationEntry[]
				{
					new(5175, 615, 0, ""),
					new(5186, 573, 10, ""),
					new(5224, 560, 0, ""),
					new(5188, 573, 11, ""),
				}),
				new("Spike Trap", typeof(SpikeTrap), 4379, "", new DecorationEntry[]
				{
					new(5173, 592, 4, ""),
					new(5172, 592, 4, ""),
				}),
				new("Dungeon Wall", typeof(Static), 768, "", new DecorationEntry[]
				{
					new(5189, 574, 20, ""),
				}),
				new("Tricorne Hat", typeof(Static), 5915, "", new DecorationEntry[]
				{
					new(5190, 727, 0, ""),
				}),
				new("Scroll%S%", typeof(Static), 3831, "", new DecorationEntry[]
				{
					new(5195, 589, 0, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(5196, 609, 5, ""),
					new(5202, 621, 5, ""),
				}),
				new("Goblet", typeof(Static), 2458, "", new DecorationEntry[]
				{
					new(5197, 621, 3, ""),
					new(5198, 621, 3, ""),
					new(5205, 615, 9, ""),
					new(5205, 616, 9, ""),
				}),
				new("Scroll%S%", typeof(Static), 3829, "", new DecorationEntry[]
				{
					new(5197, 655, 0, ""),
				}),
				new("Crystal Ball", typeof(Static), 3630, "", new DecorationEntry[]
				{
					new(5201, 609, 8, ""),
					new(5225, 553, 5, ""),
					new(5199, 609, 7, ""),
				}),
				new("Batwing%S%", typeof(Static), 3960, "", new DecorationEntry[]
				{
					new(5205, 620, 5, ""),
				}),
				new("Statue", typeof(Static), 5019, "", new DecorationEntry[]
				{
					new(5317, 751, -8, ""),
					new(5309, 751, -8, ""),
				}),
				new("", typeof(Static), 5401, "", new DecorationEntry[]
				{
					new(5211, 554, -20, ""),
				}),
				new("Crystal Ball", typeof(Static), 3629, "", new DecorationEntry[]
				{
					new(5212, 736, -20, ""),
					new(5221, 532, 0, ""),
					new(5227, 735, -20, ""),
				}),
				new("Ankh", typeof(Static), 5, "", new DecorationEntry[]
				{
					new(5205, 774, 0, ""),
				}),
				new("Yellow Potion", typeof(Static), 3852, "", new DecorationEntry[]
				{
					new(5211, 723, -20, ""),
				}),
				new("Dried Flowers", typeof(Static), 3131, "", new DecorationEntry[]
				{
					new(5224, 572, 0, ""),
				}),
				new("Dried Flowers", typeof(Static), 3134, "", new DecorationEntry[]
				{
					new(5224, 573, 0, ""),
				}),
				new("Dried Herbs", typeof(Static), 3137, "", new DecorationEntry[]
				{
					new(5224, 574, 0, ""),
				}),
				new("Orange Potion", typeof(Static), 3847, "", new DecorationEntry[]
				{
					new(5228, 723, -17, ""),
				}),
				new("Platemail Gloves", typeof(Static), 5140, "", new DecorationEntry[]
				{
					new(5181, 587, 0, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(5174, 614, 0, ""),
					new(5174, 616, 2, ""),
					new(5176, 614, 2, ""),
					new(5176, 616, 3, ""),
					new(5226, 562, 0, ""),
				}),
				new("Chainmail Leggings", typeof(Static), 5054, "", new DecorationEntry[]
				{
					new(5306, 609, 0, ""),
				}),
				new("Bow", typeof(Static), 5042, "", new DecorationEntry[]
				{
					new(5221, 735, -20, ""),
				}),
				new("Goblet", typeof(Static), 2483, "", new DecorationEntry[]
				{
					new(5201, 597, 8, ""),
					new(5201, 600, 7, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(5201, 598, 6, ""),
				}),
				new("Candle", typeof(CandleLarge), 2598, "", new DecorationEntry[]
				{
					new(5226, 564, 2, ""),
					new(5228, 562, 2, ""),
					new(5228, 564, 3, ""),
				}),
				new("Switch", typeof(Static), 4239, "", new DecorationEntry[]
				{
					new(5305, 676, -12, ""),
				}),
				new("Stone Stairs", typeof(Static), 1958, "", new DecorationEntry[]
				{
					new(5183, 578, 0, ""),
					new(5183, 571, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1657, "Facing=WestCCW", new DecorationEntry[]
				{
					new(5155, 687, 1, ""),
				}),
				new("Heavy Crossbow", typeof(Static), 5117, "", new DecorationEntry[]
				{
					new(5339, 605, 0, ""),
					new(5192, 655, 0, ""),
				}),
				new("Chainmail  Coif", typeof(Static), 5051, "", new DecorationEntry[]
				{
					new(5193, 575, 0, ""),
				}),
				new("Wizard's Hat", typeof(Static), 5912, "Hue=0x151", new DecorationEntry[]
				{
					new(5307, 545, 0, ""),
				}),
				new("Bone Armor", typeof(Static), 5199, "", new DecorationEntry[]
				{
					new(5289, 542, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
