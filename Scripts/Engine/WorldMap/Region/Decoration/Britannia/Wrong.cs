using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Wrong { get; } = Register(DecorationTarget.Britannia, "Wrong", new DecorationList[]
			{
				#region Entries
				
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5690, 569, 25)", new DecorationEntry[]
				{
					new(5827, 593, 0, ""),
					new(5829, 593, 0, ""),
					new(5871, 531, 15, ""),
					new(5870, 530, 15, ""),
					new(5871, 530, 15, ""),
					new(5870, 531, 15, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5703, 639, 0)", new DecorationEntry[]
				{
					new(5867, 528, 15, ""),
					new(5868, 528, 15, ""),
					new(5868, 529, 15, ""),
					new(5867, 529, 15, ""),
					new(5705, 625, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5793, 527, 10)", new DecorationEntry[]
				{
					new(5698, 662, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5829, 595, 0)", new DecorationEntry[]
				{
					new(5733, 554, 20, ""),
					new(5690, 569, 25, ""),
				}),
				new("Sparkle", typeof(Static), 14170, "", new DecorationEntry[]
				{
					new(5703, 639, 0, ""),
					new(5706, 625, 0, ""),
					new(5698, 662, 0, ""),
					new(5732, 554, 24, ""),
					new(5792, 525, 10, ""),
					new(5827, 593, 0, ""),
					new(5829, 593, 0, ""),
					new(5690, 569, 25, ""),
					new(5867, 528, 15, ""),
					new(5872, 532, 24, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(5683, 521, 0, ""),
					new(5678, 521, 0, ""),
					new(5682, 521, 0, ""),
				}),
				new("Spike Trap", typeof(GiantSpikeTrap), 1, "", new DecorationEntry[]
				{
					new(5653, 568, 20, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4506, "", new DecorationEntry[]
				{
					new(5700, 529, 0, ""),
					new(5793, 568, 10, ""),
					new(5679, 525, 0, ""),
					new(5800, 542, 10, ""),
					new(5657, 556, 20, ""),
					new(5862, 549, 15, ""),
					new(5669, 564, 20, ""),
					new(5673, 521, 0, ""),
					new(5798, 585, 10, ""),
					new(5736, 566, 22, ""),
					new(5826, 534, 0, ""),
					new(5829, 522, 0, ""),
					new(5666, 569, 20, ""),
					new(5875, 553, 15, ""),
					new(5687, 526, 0, ""),
					new(5691, 522, 0, ""),
					new(5790, 561, 10, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1683, "Facing=NorthCW", new DecorationEntry[]
				{
					new(5857, 562, 15, ""),
					new(5857, 570, 15, ""),
					new(5857, 578, 15, ""),
					new(5857, 586, 15, ""),
					new(5857, 594, 15, ""),
					new(5848, 580, 15, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1679, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5863, 554, 15, ""),
					new(5797, 594, 10, ""),
					new(5797, 555, 10, ""),
					new(5797, 587, 10, ""),
					new(5797, 579, 10, ""),
					new(5797, 571, 10, ""),
					new(5797, 563, 10, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1677, "Facing=SouthCW", new DecorationEntry[]
				{
					new(5863, 555, 15, ""),
					new(5797, 595, 10, ""),
					new(5797, 588, 10, ""),
					new(5797, 580, 10, ""),
					new(5797, 556, 10, ""),
					new(5797, 572, 10, ""),
					new(5797, 564, 10, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(5703, 661, 0, ""),
					new(5786, 554, 10, ""),
					new(5786, 555, 10, ""),
					new(5786, 556, 10, ""),
					new(5786, 557, 10, ""),
					new(5703, 664, 0, ""),
					new(5703, 663, 0, ""),
					new(5703, 662, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5709, 659, 0, ""),
					new(5708, 659, 0, ""),
					new(5706, 659, 0, ""),
					new(5648, 549, 22, ""),
					new(5727, 554, 20, ""),
					new(5718, 549, 20, ""),
					new(5707, 659, 0, ""),
				}),
				new("Switch", typeof(Static), 4239, "", new DecorationEntry[]
				{
					new(5786, 589, 24, ""),
					new(5798, 593, 24, ""),
					new(5786, 572, 24, ""),
					new(5849, 586, 15, ""),
					new(5798, 581, 23, ""),
				}),
				new("Floor Saw", typeof(SawTrap), 4524, "", new DecorationEntry[]
				{
					new(5864, 546, 15, ""),
					new(5790, 560, 10, ""),
					new(5651, 556, 20, ""),
					new(5821, 526, 0, ""),
					new(5867, 546, 15, ""),
					new(5680, 526, 0, ""),
					new(5731, 555, 20, ""),
					new(5693, 536, 0, ""),
					new(5651, 554, 20, ""),
					new(5732, 573, 20, ""),
					new(5702, 532, 0, ""),
					new(5679, 529, 0, ""),
					new(5727, 557, 20, ""),
					new(5833, 532, 0, ""),
					new(5802, 559, 10, ""),
					new(5796, 546, 10, ""),
					new(5860, 546, 15, ""),
					new(5869, 553, 15, ""),
					new(5695, 538, 0, ""),
				}),
				new("Iron Maiden", typeof(Static), 4683, "", new DecorationEntry[]
				{
					new(5698, 524, 0, ""),
				}),
				new("Floor Saw", typeof(SawTrap), 4529, "", new DecorationEntry[]
				{
					new(5792, 554, 10, ""),
					new(5717, 550, 20, ""),
					new(5731, 566, 20, ""),
					new(5714, 569, 20, ""),
					new(5683, 533, 0, ""),
					new(5687, 531, 0, ""),
					new(5664, 557, 20, ""),
					new(5865, 549, 15, ""),
					new(5793, 594, 10, ""),
					new(5724, 563, 20, ""),
					new(5656, 553, 20, ""),
					new(5680, 532, 0, ""),
					new(5681, 526, 0, ""),
					new(5665, 561, 20, ""),
					new(5666, 564, 20, ""),
					new(5651, 564, 20, ""),
					new(5682, 529, 0, ""),
				}),
				new("Switch", typeof(Static), 4240, "", new DecorationEntry[]
				{
					new(5786, 589, 24, ""),
					new(5798, 581, 10, ""),
					new(5786, 572, 24, ""),
					new(5798, 581, 23, ""),
				}),
				new("Glowing Rune", typeof(Static), 3679, "", new DecorationEntry[]
				{
					new(5699, 663, 0, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1671, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5667, 567, 20, ""),
					new(5727, 567, 20, ""),
					new(5653, 567, 20, ""),
					new(5660, 567, 20, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1669, "Facing=WestCW", new DecorationEntry[]
				{
					new(5666, 567, 20, ""),
					new(5726, 567, 20, ""),
					new(5652, 567, 20, ""),
					new(5659, 567, 20, ""),
				}),
				new("Switch", typeof(Static), 4241, "", new DecorationEntry[]
				{
					new(5650, 568, 30, ""),
					new(5657, 568, 30, ""),
					new(5664, 568, 30, ""),
				}),
				new("Switch", typeof(Static), 4242, "", new DecorationEntry[]
				{
					new(5793, 592, 24, ""),
					new(5657, 568, 30, ""),
					new(5793, 560, 24, ""),
					new(5792, 576, 24, ""),
					new(5650, 568, 30, ""),
					new(5664, 568, 30, ""),
				}),
				new("Whip", typeof(Static), 5742, "", new DecorationEntry[]
				{
					new(5864, 540, 21, ""),
				}),
				new("Wooden Box", typeof(Static), 2474, "", new DecorationEntry[]
				{
					new(5667, 549, 22, ""),
				}),
				new("Gas Trap", typeof(GasTrap), 4412, "", new DecorationEntry[]
				{
					new(5682, 531, 0, ""),
					new(5828, 531, 0, ""),
					new(5833, 538, 0, ""),
					new(5684, 533, 0, ""),
					new(5693, 521, 0, ""),
					new(5787, 550, 10, ""),
					new(5680, 528, 0, ""),
					new(5834, 535, 0, ""),
					new(5680, 530, 0, ""),
					new(5689, 529, 0, ""),
					new(5687, 541, 0, ""),
					new(5827, 534, 0, ""),
					new(5691, 526, 0, ""),
					new(5729, 561, 20, ""),
					new(5722, 549, 20, ""),
				}),
				new("Butcher Knife", typeof(Static), 5111, "", new DecorationEntry[]
				{
					new(5703, 527, 7, ""),
				}),
				new("Skinning Knife", typeof(Static), 3780, "", new DecorationEntry[]
				{
					new(5703, 526, 7, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4512, "", new DecorationEntry[]
				{
					new(5832, 527, 0, ""),
					new(5874, 541, 15, ""),
					new(5682, 535, 0, ""),
					new(5694, 533, 0, ""),
					new(5825, 523, 0, ""),
					new(5681, 523, 0, ""),
					new(5782, 572, 10, ""),
					new(5661, 549, 22, ""),
					new(5720, 571, 20, ""),
					new(5735, 563, 20, ""),
					new(5733, 572, 20, ""),
					new(5791, 571, 10, ""),
					new(5792, 544, 10, ""),
					new(5829, 525, 0, ""),
					new(5674, 528, 0, ""),
					new(5674, 527, 0, ""),
					new(5835, 528, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW", new DecorationEntry[]
				{
					new(2044, 233, 13, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Facing=EastCCW", new DecorationEntry[]
				{
					new(2045, 233, 13, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1681, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(5848, 581, 15, ""),
					new(5857, 563, 15, ""),
					new(5857, 571, 15, ""),
					new(5857, 579, 15, ""),
					new(5857, 587, 15, ""),
					new(5857, 595, 15, ""),
				}),
				new("Mushroom", typeof(MushroomTrap), 4389, "", new DecorationEntry[]
				{
					new(5724, 560, 20, ""),
					new(5834, 534, 0, ""),
					new(5658, 554, 20, ""),
					new(5665, 557, 20, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(5718, 554, 23, ""),
					new(5715, 556, 20, ""),
					new(5715, 556, 23, ""),
					new(5718, 554, 20, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(5678, 529, 0, ""),
					new(5734, 549, 20, ""),
				}),
				new("Dungeon Wall", typeof(SecretDungeonDoor), 792, "Facing=WestCCW", new DecorationEntry[]
				{
					new(5679, 520, 0, ""),
					new(5722, 553, 20, ""),
				}),
				new("Stone Pavers", typeof(Static), 1305, "", new DecorationEntry[]
				{
					new(5677, 521, 0, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(5786, 544, 10, ""),
					new(5672, 526, 0, ""),
				}),
				new("Hammer", typeof(Static), 4139, "", new DecorationEntry[]
				{
					new(5791, 542, 16, ""),
					new(5863, 541, 21, ""),
				}),
				new("Pickaxe", typeof(Static), 3717, "", new DecorationEntry[]
				{
					new(5790, 543, 16, ""),
				}),
				new("Dagger", typeof(Static), 3921, "", new DecorationEntry[]
				{
					new(5790, 542, 16, ""),
				}),
				new("Cleaver", typeof(Static), 3778, "", new DecorationEntry[]
				{
					new(5702, 526, 7, ""),
				}),
				new("Strong Box", typeof(MetalBox), 3712, "", new DecorationEntry[]
				{
					new(5669, 520, 0, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4020, "", new DecorationEntry[]
				{
					new(5863, 542, 21, ""),
				}),
				new("Whip", typeof(Static), 5743, "", new DecorationEntry[]
				{
					new(5862, 542, 21, ""),
				}),
				new("Rusty Iron Key", typeof(Static), 4115, "", new DecorationEntry[]
				{
					new(5851, 571, 15, ""),
				}),
				new("Dungeon Wall", typeof(SecretDungeonDoor), 794, "Facing=EastCW", new DecorationEntry[]
				{
					new(5652, 552, 20, ""),
				}),
				new("Alchemical Symbol", typeof(Static), 6178, "", new DecorationEntry[]
				{
					new(2041, 232, 34, ""),
				}),
				new("Stone", typeof(Static), 1955, "", new DecorationEntry[]
				{
					new(5692, 566, 20, ""),
				}),
				new("Rock", typeof(Static), 6003, "", new DecorationEntry[]
				{
					new(5694, 564, 3, ""),
					new(5694, 565, 16, ""),
				}),
				new("Rock", typeof(Static), 6008, "", new DecorationEntry[]
				{
					new(5694, 566, 20, ""),
				}),
				
				#endregion
			});
		}
	}
}
