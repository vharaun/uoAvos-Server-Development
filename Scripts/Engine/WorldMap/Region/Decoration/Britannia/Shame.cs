using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Shame { get; } = Register(DecorationTarget.Britannia, "Shame", new DecorationList[]
			{
				#region Entries
				
				new("Lever", typeof(Static), 4238, "", new DecorationEntry[]
				{
					new(5420, 240, 10, ""),
				}),
				new("Water", typeof(Static), 6043, "", new DecorationEntry[]
				{
					new(5705, 41, -5, ""),
					new(5706, 41, -5, ""),
					new(5751, 17, -5, ""),
					new(5560, 212, -5, ""),
					new(5672, 43, -5, ""),
					new(5461, 195, -5, ""),
					new(5516, 245, -5, ""),
					new(5546, 15, -5, ""),
					new(5620, 66, -5, ""),
					new(5425, 200, -5, ""),
					new(5424, 198, -5, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4512, "", new DecorationEntry[]
				{
					new(5591, 241, 0, ""),
					new(5607, 18, 10, ""),
					new(5570, 117, 5, ""),
					new(5616, 189, 0, ""),
					new(5553, 204, 0, ""),
					new(5430, 139, 20, ""),
					new(5588, 218, 0, ""),
				}),
				new("Wooden Box", typeof(Static), 3709, "", new DecorationEntry[]
				{
					new(5424, 114, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5415, 241, 10, ""),
					new(5406, 42, 30, ""),
					new(5465, 101, 35, ""),
					new(5445, 184, 0, ""),
					new(5573, 114, 5, ""),
					new(5403, 150, 20, ""),
					new(5568, 119, 5, ""),
					new(5808, 13, 0, ""),
					new(5384, 147, 20, ""),
					new(5472, 181, 0, ""),
					new(5477, 180, 0, ""),
					new(5868, 118, 10, ""),
					new(5384, 13, 30, ""),
					new(5736, 53, 0, ""),
					new(5384, 145, 20, ""),
					new(5384, 149, 20, ""),
					new(5404, 60, -20, ""),
				}),
				new("Stalagmites", typeof(Static), 2276, "", new DecorationEntry[]
				{
					new(5409, 138, 10, ""),
					new(5411, 137, 10, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(5456, 82, 20, ""),
					new(5456, 84, 20, ""),
					new(5456, 84, 25, ""),
					new(5577, 186, 0, ""),
					new(5523, 214, 0, ""),
					new(5523, 214, 5, ""),
					new(5524, 212, 0, ""),
					new(5524, 212, 5, ""),
					new(5608, 30, 10, ""),
					new(5575, 190, 10, ""),
					new(5576, 186, 10, ""),
					new(5442, 178, 5, ""),
					new(5442, 177, 5, ""),
					new(5442, 177, 10, ""),
					new(5441, 177, 5, ""),
					new(5441, 177, 0, ""),
					new(5440, 182, 5, ""),
					new(5440, 182, 0, ""),
					new(5440, 179, 10, ""),
					new(5440, 179, 0, ""),
					new(5440, 178, 5, ""),
					new(5440, 178, 0, ""),
					new(5440, 177, 5, ""),
					new(5440, 177, 10, ""),
					new(5440, 177, 0, ""),
					new(5440, 179, 5, ""),
					new(5442, 177, 0, ""),
					new(5442, 178, 0, ""),
					new(5436, 102, 20, ""),
					new(5437, 102, 20, ""),
					new(5728, 90, 5, ""),
					new(5437, 102, 25, ""),
					new(5455, 84, 20, ""),
					new(5455, 84, 25, ""),
					new(5489, 58, 20, ""),
					new(5489, 59, 20, ""),
					new(5489, 59, 25, ""),
					new(5491, 60, 20, ""),
					new(5609, 30, 10, ""),
					new(5610, 29, 10, ""),
					new(5610, 29, 15, ""),
					new(5727, 90, 5, ""),
					new(5727, 91, 0, ""),
					new(5522, 60, 0, ""),
					new(5522, 60, 5, ""),
					new(5522, 61, 0, ""),
					new(5522, 61, 5, ""),
					new(5522, 62, 0, ""),
					new(5388, 205, 10, ""),
					new(5733, 89, 0, ""),
					new(5734, 88, 0, ""),
					new(5734, 88, 5, ""),
					new(5734, 89, 0, ""),
					new(5510, 222, 0, ""),
					new(5522, 200, 5, ""),
					new(5510, 221, 5, ""),
					new(5510, 221, 0, ""),
					new(5509, 222, 5, ""),
					new(5509, 222, 0, ""),
					new(5574, 190, 10, ""),
					new(5576, 185, 0, ""),
					new(5576, 186, 5, ""),
					new(5727, 90, 0, ""),
					new(5439, 182, 5, ""),
					new(5439, 182, 0, ""),
					new(5434, 181, 5, ""),
					new(5434, 180, 5, ""),
					new(5434, 180, 10, ""),
					new(5434, 180, 0, ""),
					new(5433, 181, 0, ""),
					new(5433, 180, 5, ""),
					new(5433, 180, 10, ""),
					new(5433, 180, 0, ""),
					new(5433, 181, 10, ""),
					new(5434, 181, 0, ""),
					new(5578, 190, 5, ""),
					new(5578, 190, 10, ""),
					new(5578, 190, 0, ""),
					new(5578, 189, 5, ""),
					new(5578, 189, 0, ""),
					new(5577, 190, 5, ""),
					new(5577, 190, 0, ""),
					new(5577, 185, 5, ""),
					new(5577, 185, 0, ""),
					new(5576, 186, 0, ""),
					new(5576, 185, 5, ""),
					new(5727, 91, 5, ""),
					new(5728, 90, 0, ""),
					new(5433, 181, 5, ""),
					new(5433, 180, 15, ""),
					new(5733, 88, 0, ""),
					new(5733, 88, 5, ""),
					new(5734, 89, 5, ""),
					new(5569, 189, 5, ""),
					new(5522, 201, 0, ""),
					new(5523, 201, 5, ""),
					new(5523, 201, 0, ""),
					new(5523, 200, 5, ""),
					new(5523, 200, 0, ""),
					new(5522, 201, 5, ""),
					new(5609, 12, 10, ""),
					new(5522, 200, 0, ""),
					new(5395, 40, 30, ""),
					new(5395, 40, 35, ""),
					new(5396, 40, 30, ""),
					new(5525, 204, 0, ""),
					new(5525, 204, 5, ""),
					new(5569, 188, 15, ""),
					new(5569, 188, 0, ""),
					new(5575, 190, 5, ""),
					new(5610, 10, 10, ""),
					new(5610, 10, 15, ""),
					new(5610, 11, 10, ""),
					new(5611, 11, 10, ""),
					new(5611, 11, 15, ""),
					new(5575, 190, 0, ""),
					new(5574, 190, 5, ""),
					new(5574, 190, 0, ""),
					new(5571, 188, 0, ""),
					new(5570, 190, 5, ""),
					new(5570, 190, 0, ""),
					new(5570, 189, 5, ""),
					new(5570, 189, 0, ""),
					new(5570, 188, 5, ""),
					new(5570, 188, 0, ""),
					new(5569, 190, 5, ""),
					new(5569, 190, 10, ""),
					new(5569, 190, 0, ""),
					new(5569, 189, 10, ""),
					new(5569, 189, 0, ""),
					new(5569, 188, 5, ""),
					new(5569, 188, 10, ""),
				}),
				new("Gas Trap", typeof(GasTrap), 4412, "", new DecorationEntry[]
				{
					new(5540, 213, 0, ""),
					new(5552, 203, 0, ""),
					new(5427, 215, 0, ""),
					new(5413, 192, 0, ""),
					new(5538, 188, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(5424, 45, 10, ""),
					new(5434, 195, 22, ""),
					new(5621, 27, 10, ""),
					new(5494, 57, 20, ""),
					new(5440, 191, 22, ""),
					new(5817, 78, 0, ""),
					new(5698, 19, 10, ""),
					new(5525, 62, 0, ""),
					new(5422, 244, 10, ""),
					new(5608, 8, 10, ""),
					new(5480, 198, 0, ""),
				}),
				new("Wooden Planks", typeof(Static), 1222, "", new DecorationEntry[]
				{
					new(5460, 185, 0, ""),
					new(5460, 187, 0, ""),
					new(5460, 186, 0, ""),
					new(5460, 188, 0, ""),
				}),
				new("Water", typeof(Static), 6044, "", new DecorationEntry[]
				{
					new(5617, 57, -5, ""),
					new(5554, 10, -5, ""),
				}),
				new("Plate Helm", typeof(Static), 5138, "", new DecorationEntry[]
				{
					new(5829, 23, 13, ""),
				}),
				new("Water", typeof(Static), 6042, "", new DecorationEntry[]
				{
					new(5596, 74, -5, ""),
					new(5611, 61, -5, ""),
					new(5549, 15, -5, ""),
					new(5617, 64, -5, ""),
					new(5621, 67, -5, ""),
				}),
				new("Stone Pillar", typeof(Static), 474, "", new DecorationEntry[]
				{
					new(5570, 186, 44, ""),
					new(5570, 190, 44, ""),
					new(5574, 186, 44, ""),
					new(5570, 194, 44, ""),
					new(5570, 197, 44, ""),
					new(5570, 201, 44, ""),
					new(5570, 205, 44, ""),
					new(5574, 198, 44, ""),
					new(5574, 193, 44, ""),
					new(5575, 189, 44, ""),
					new(5575, 190, 44, ""),
					new(5575, 191, 44, ""),
					new(5575, 192, 44, ""),
					new(5575, 193, 44, ""),
					new(5575, 198, 44, ""),
					new(5575, 199, 44, ""),
					new(5575, 200, 44, ""),
					new(5575, 201, 44, ""),
					new(5575, 202, 44, ""),
					new(5574, 205, 44, ""),
					new(5576, 198, 44, ""),
					new(5576, 193, 44, ""),
					new(5577, 193, 44, ""),
					new(5577, 198, 44, ""),
					new(5578, 198, 44, ""),
					new(5578, 193, 44, ""),
					new(5578, 186, 44, ""),
					new(5578, 205, 44, ""),
					new(5579, 202, 44, ""),
					new(5579, 201, 44, ""),
					new(5579, 200, 44, ""),
					new(5579, 199, 44, ""),
					new(5579, 197, 44, ""),
					new(5579, 196, 44, ""),
					new(5579, 195, 44, ""),
					new(5579, 194, 44, ""),
					new(5579, 193, 44, ""),
					new(5579, 192, 44, ""),
					new(5579, 191, 44, ""),
					new(5579, 190, 44, ""),
					new(5579, 189, 44, ""),
					new(5580, 189, 44, ""),
					new(5580, 191, 44, ""),
					new(5580, 192, 44, ""),
					new(5580, 193, 44, ""),
					new(5580, 194, 44, ""),
					new(5580, 195, 44, ""),
					new(5580, 196, 44, ""),
					new(5580, 197, 44, ""),
					new(5580, 198, 44, ""),
					new(5580, 199, 44, ""),
					new(5580, 200, 44, ""),
					new(5580, 201, 44, ""),
					new(5580, 202, 44, ""),
					new(5581, 205, 44, ""),
					new(5581, 198, 44, ""),
					new(5581, 193, 44, ""),
					new(5581, 186, 44, ""),
					new(5582, 193, 44, ""),
					new(5583, 193, 44, ""),
					new(5585, 186, 44, ""),
					new(5584, 189, 44, ""),
					new(5584, 190, 44, ""),
					new(5584, 191, 44, ""),
					new(5584, 193, 44, ""),
					new(5584, 198, 44, ""),
					new(5584, 199, 44, ""),
					new(5584, 200, 44, ""),
					new(5584, 201, 44, ""),
					new(5585, 193, 44, ""),
					new(5585, 198, 44, ""),
					new(5585, 205, 44, ""),
					new(5589, 205, 44, ""),
					new(5589, 201, 44, ""),
					new(5589, 197, 44, ""),
					new(5589, 194, 44, ""),
					new(5589, 190, 44, ""),
					new(5589, 186, 44, ""),
					new(5580, 190, 44, ""),
					new(5584, 192, 44, ""),
					new(5579, 198, 44, ""),
					new(5582, 198, 44, ""),
					new(5583, 198, 44, ""),
					new(5584, 202, 44, ""),
				}),
				new("Bottle Of Liquor", typeof(BeverageBottle), 2459, "Content=Liquor", new DecorationEntry[]
				{
					new(5405, 41, 30, ""),
					new(5402, 46, 30, ""),
					new(5404, 43, 30, ""),
					new(5399, 40, 30, ""),
				}),
				new("Bedroll", typeof(Static), 2647, "", new DecorationEntry[]
				{
					new(5514, 215, 0, ""),
					new(5526, 58, 0, ""),
					new(5515, 220, 0, ""),
				}),
				new("Switch", typeof(Static), 4242, "", new DecorationEntry[]
				{
					new(5569, 199, 11, ""),
					new(5492, 200, 16, ""),
					new(5493, 200, 16, ""),
					new(5595, 62, 12, ""),
					new(5448, 184, 11, ""),
					new(5581, 192, 11, ""),
				}),
				new("Bedroll", typeof(Static), 2649, "", new DecorationEntry[]
				{
					new(5523, 54, 0, ""),
					new(5524, 57, 0, ""),
					new(5489, 50, 20, ""),
					new(5493, 50, 20, ""),
					new(5528, 50, 0, ""),
					new(5519, 216, 0, ""),
					new(5514, 215, 0, ""),
				}),
				new("Empty Jar", typeof(Static), 4101, "", new DecorationEntry[]
				{
					new(5728, 92, 0, ""),
					new(5728, 93, 0, ""),
					new(5727, 92, 0, ""),
				}),
				new("Lantern", typeof(Lantern), 2594, "", new DecorationEntry[]
				{
					new(5405, 43, 30, ""),
					new(5465, 184, 12, ""),
					new(5465, 189, 13, ""),
					new(5390, 43, 20, ""),
					new(5449, 81, 20, ""),
					new(5392, 89, 20, ""),
				}),
				new("Vase", typeof(Static), 2886, "", new DecorationEntry[]
				{
					new(5734, 94, 0, ""),
				}),
				new("Glowing Rune", typeof(Static), 3679, "", new DecorationEntry[]
				{
					new(5736, 48, 5, ""),
				}),
				new("Glowing Rune", typeof(Static), 3676, "", new DecorationEntry[]
				{
					new(5736, 50, 5, ""),
				}),
				new("Glowing Rune", typeof(Static), 3682, "", new DecorationEntry[]
				{
					new(5738, 48, 5, ""),
				}),
				new("Glowing Rune", typeof(Static), 3685, "", new DecorationEntry[]
				{
					new(5738, 50, 5, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1733, "Facing=WestCW", new DecorationEntry[]
				{
					new(5540, 183, 0, ""),
					new(5517, 178, 0, ""),
					new(5445, 183, 22, ""),
					new(5434, 190, 22, ""),
					new(5506, 167, 0, ""),
				}),
				new("Floor Saw", typeof(SawTrap), 4529, "", new DecorationEntry[]
				{
					new(5579, 199, 0, ""),
					new(5421, 140, 10, ""),
					new(5569, 191, 44, ""),
					new(5571, 118, 5, ""),
					new(5598, 228, 0, ""),
				}),
				new("Barrel", typeof(Barrel), 4014, "", new DecorationEntry[]
				{
					new(5406, 43, 30, ""),
					new(5492, 56, 20, ""),
					new(5393, 46, 30, ""),
					new(5406, 44, 31, ""),
					new(5614, 15, 10, ""),
					new(5534, 45, 0, ""),
					new(5728, 91, 0, ""),
					new(5604, 20, 10, ""),
					new(5435, 98, 20, ""),
					new(5523, 204, 0, ""),
					new(5503, 224, 0, ""),
					new(5501, 217, 0, ""),
					new(5497, 220, 0, ""),
					new(5525, 59, 0, ""),
					new(5452, 83, 20, ""),
				}),
				new("Platemail Gloves", typeof(Static), 5144, "", new DecorationEntry[]
				{
					new(5779, 27, 0, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(5402, 43, 30, ""),
					new(5491, 52, 20, ""),
					new(5516, 216, 0, ""),
					new(5524, 50, 0, ""),
				}),
				new("Pickaxe", typeof(Static), 3717, "", new DecorationEntry[]
				{
					new(5514, 218, 0, ""),
					new(5512, 221, 0, ""),
					new(5428, 113, 0, ""),
					new(5434, 99, 20, ""),
				}),
				new("Backpack", typeof(Static), 3701, "", new DecorationEntry[]
				{
					new(5513, 220, 0, ""),
					new(5728, 94, 0, ""),
					new(5449, 82, 20, ""),
				}),
				new("Backpack", typeof(Backpack), 2482, "", new DecorationEntry[]
				{
					new(5518, 214, 0, ""),
					new(5513, 213, 0, ""),
				}),
				new("Bedroll", typeof(Static), 2645, "", new DecorationEntry[]
				{
					new(5515, 220, 0, ""),
				}),
				new("Switch", typeof(Static), 4239, "", new DecorationEntry[]
				{
					new(5433, 189, 11, ""),
					new(5600, 57, 13, ""),
					new(5433, 195, 12, ""),
				}),
				new("Floor Saw", typeof(SawTrap), 4524, "", new DecorationEntry[]
				{
					new(5615, 237, 0, ""),
					new(5573, 217, 0, ""),
					new(5572, 222, 0, ""),
					new(5441, 186, 22, ""),
					new(5572, 203, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5703, 58, 2, ""),
					new(5475, 196, 0, ""),
					new(5819, 82, 0, ""),
					new(5483, 205, 0, ""),
					new(5436, 182, 0, ""),
					new(5477, 201, 0, ""),
					new(5572, 117, 5, ""),
				}),
				new("Cot", typeof(Static), 4605, "", new DecorationEntry[]
				{
					new(5433, 194, 22, ""),
				}),
				new("Broken Chair", typeof(Static), 3097, "", new DecorationEntry[]
				{
					new(5435, 185, 0, ""),
					new(5441, 186, 0, ""),
					new(5447, 194, 22, ""),
					new(5581, 195, 22, ""),
					new(5582, 203, 22, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1741, "Facing=SouthCW", new DecorationEntry[]
				{
					new(5441, 194, 0, ""),
					new(5441, 193, 22, ""),
					new(5443, 180, 0, ""),
					new(5442, 179, 22, ""),
					new(5440, 187, 22, ""),
					new(5447, 187, 0, ""),
					new(5823, 51, 0, ""),
					new(5818, 54, 0, ""),
					new(5579, 202, 22, ""),
					new(5583, 195, 0, ""),
					new(5577, 188, 22, ""),
					new(5579, 187, 0, ""),
					new(5504, 179, 0, ""),
				}),
				new("Switch", typeof(Static), 4241, "", new DecorationEntry[]
				{
					new(5595, 62, 12, ""),
					new(5493, 200, 16, ""),
					new(5581, 192, 11, ""),
				}),
				new("Crate", typeof(SmallCrate), 3710, "", new DecorationEntry[]
				{
					new(5395, 145, 20, "// spawning"),
					new(5587, 136, 10, "// spawning"),
					new(5731, 93, 0, ""),
					new(5731, 94, 0, ""),
					new(5731, 94, 2, ""),
					new(5732, 94, 2, ""),
					new(5731, 93, 2, ""),
					new(5732, 94, 0, ""),
				}),
				new("Bed", typeof(Static), 4562, "", new DecorationEntry[]
				{
					new(5451, 177, 22, ""),
					new(5447, 177, 22, ""),
					new(5575, 199, 22, ""),
					new(5586, 185, 22, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1743, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5447, 186, 0, ""),
					new(5823, 50, 0, ""),
					new(5583, 194, 0, ""),
					new(5504, 178, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(5416, 243, 10, ""),
					new(5604, 28, 10, ""),
					new(5741, 48, 0, ""),
					new(5699, 86, 0, ""),
				}),
				new("Cloak", typeof(Static), 5397, "Hue=0x26", new DecorationEntry[]
				{
					new(5564, 227, 0, ""),
				}),
				new("Switch", typeof(Static), 4240, "", new DecorationEntry[]
				{
					new(5600, 57, 13, ""),
					new(5433, 195, 12, ""),
				}),
				new("Lever", typeof(Static), 4236, "", new DecorationEntry[]
				{
					new(5420, 240, 10, ""),
					new(5496, 205, 0, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(5399, 146, 20, "// spawning"),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(5594, 245, 0, ""),
					new(5487, 194, 0, ""),
					new(5414, 243, 10, ""),
					new(5607, 210, 0, ""),
					new(5582, 193, 0, ""),
				}),
				new("Fishing Net", typeof(Static), 3530, "", new DecorationEntry[]
				{
					new(5500, 221, 0, ""),
				}),
				new("Fishing Net", typeof(Static), 3529, "", new DecorationEntry[]
				{
					new(5500, 222, 0, ""),
				}),
				new("Small Crate", typeof(SmallCrate), 2473, "", new DecorationEntry[]
				{
					new(5588, 137, 10, "// spawning"),
				}),
				new("Bedroll", typeof(Static), 2646, "", new DecorationEntry[]
				{
					new(5514, 215, 0, ""),
					new(5489, 50, 20, ""),
					new(5401, 41, 30, ""),
					new(5401, 46, 30, ""),
					new(5404, 41, 30, ""),
					new(5404, 46, 30, ""),
					new(5451, 82, 20, ""),
					new(5523, 54, 0, ""),
					new(5524, 57, 0, ""),
					new(5519, 216, 0, ""),
					new(5526, 58, 0, ""),
					new(5528, 50, 0, ""),
				}),
				new("Cave Floor", typeof(Static), 1340, "", new DecorationEntry[]
				{
					new(5518, 175, 0, ""),
				}),
				new("Dungeon Wall", typeof(Static), 578, "", new DecorationEntry[]
				{
					new(5541, 172, 0, ""),
					new(5541, 168, 0, ""),
					new(5541, 169, 0, ""),
					new(5541, 171, 0, ""),
				}),
				new("Water Tub", typeof(Static), 3707, "", new DecorationEntry[]
				{
					new(5435, 98, 20, ""),
				}),
				new("Pickaxe", typeof(Static), 3718, "", new DecorationEntry[]
				{
					new(5430, 113, 0, ""),
					new(5452, 87, 20, ""),
					new(5511, 222, 0, ""),
					new(5520, 216, 0, ""),
				}),
				new("Wooden Logs", typeof(Static), 1290, "", new DecorationEntry[]
				{
					new(5542, 13, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1745, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(5578, 202, 0, ""),
					new(5575, 195, 22, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(5728, 95, 0, ""),
					new(5727, 94, 0, ""),
					new(5727, 94, 3, ""),
					new(5727, 95, 0, ""),
					new(5727, 95, 3, ""),
					new(5727, 95, 6, ""),
					new(5727, 93, 0, ""),
				}),
				new("Stalagmites", typeof(Static), 2272, "", new DecorationEntry[]
				{
					new(5482, 25, -30, ""),
					new(5481, 25, -30, ""),
					new(5481, 27, -30, ""),
					new(5482, 27, -30, ""),
					new(5482, 26, -30, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(5728, 91, 0, ""),
				}),
				new("Bottle", typeof(Static), 3839, "", new DecorationEntry[]
				{
					new(5436, 188, 28, ""),
				}),
				new("Cloak", typeof(Static), 5397, "Hue=0x1B5", new DecorationEntry[]
				{
					new(5557, 138, 20, ""),
				}),
				new("Dungeon Wall", typeof(SecretDungeonDoor), 798, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5541, 170, 0, ""),
				}),
				new("Flowstone", typeof(Static), 2274, "", new DecorationEntry[]
				{
					new(5410, 137, 10, ""),
				}),
				new("Shoes", typeof(Static), 5903, "", new DecorationEntry[]
				{
					new(5579, 195, 0, ""),
				}),
				new("Long Pants", typeof(Static), 5433, "", new DecorationEntry[]
				{
					new(5579, 195, 0, ""),
				}),
				new("Shirt", typeof(Static), 5399, "", new DecorationEntry[]
				{
					new(5579, 195, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1737, "Facing=WestCCW", new DecorationEntry[]
				{
					new(5581, 191, 22, ""),
					new(5435, 190, 0, ""),
					new(5570, 198, 0, ""),
					new(5571, 198, 22, ""),
					new(5507, 182, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1739, "Facing=EastCW", new DecorationEntry[]
				{
					new(5508, 182, 0, ""),
				}),
				new("Wooden Planks", typeof(Static), 1224, "", new DecorationEntry[]
				{
					new(5456, 186, 0, ""),
					new(5456, 185, 0, ""),
					new(5456, 187, 0, ""),
					new(5456, 188, 0, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4506, "", new DecorationEntry[]
				{
					new(5576, 202, 0, ""),
					new(5403, 230, 10, ""),
				}),
				new("Bottles Of Liquor", typeof(Static), 2462, "", new DecorationEntry[]
				{
					new(5394, 40, 30, ""),
				}),
				new("Bottles Of Liquor", typeof(Static), 2461, "", new DecorationEntry[]
				{
					new(5398, 44, 30, ""),
				}),
				new("Mushroom", typeof(MushroomTrap), 4389, "", new DecorationEntry[]
				{
					new(5868, 56, 0, ""),
				}),
				new("Water", typeof(Static), 6041, "", new DecorationEntry[]
				{
					new(5436, 168, -5, ""),
					new(5461, 195, -5, ""),
				}),
				new("Candle", typeof(CandleLarge), 2598, "", new DecorationEntry[]
				{
					new(5438, 186, 4, ""),
				}),
				new("Stone Face", typeof(Static), 4349, "", new DecorationEntry[]
				{
					new(5434, 184, 22, ""),
					new(5436, 184, 22, ""),
					new(5438, 184, 22, ""),
					new(5572, 192, 22, ""),
				}),
				new("Cot", typeof(Static), 4606, "", new DecorationEntry[]
				{
					new(5434, 194, 22, ""),
				}),
				new("Bottle", typeof(Static), 3840, "", new DecorationEntry[]
				{
					new(5436, 185, 28, ""),
				}),
				new("Bottle", typeof(Static), 3843, "", new DecorationEntry[]
				{
					new(5436, 185, 28, ""),
				}),
				new("Broken Chair", typeof(Static), 3098, "", new DecorationEntry[]
				{
					new(5436, 186, 23, ""),
					new(5437, 188, 22, ""),
					new(5438, 195, 0, ""),
					new(5441, 187, 0, ""),
					new(5443, 192, 0, ""),
					new(5444, 195, 22, ""),
					new(5571, 203, 22, ""),
					new(5575, 203, 0, ""),
					new(5582, 202, 0, ""),
				}),
				new("Bottle", typeof(Static), 3625, "", new DecorationEntry[]
				{
					new(5436, 188, 28, ""),
				}),
				new("Cot", typeof(Static), 4607, "", new DecorationEntry[]
				{
					new(5436, 191, 22, ""),
					new(5438, 191, 22, ""),
				}),
				new("Cot", typeof(Static), 4608, "", new DecorationEntry[]
				{
					new(5436, 192, 22, ""),
					new(5438, 192, 22, ""),
				}),
				new("Broken Chair", typeof(Static), 3102, "", new DecorationEntry[]
				{
					new(5436, 195, 0, ""),
					new(5573, 202, 0, ""),
				}),
				new("Gas Trap", typeof(Static), 4520, "", new DecorationEntry[]
				{
					new(5441, 181, 0, ""),
					new(5569, 159, -10, ""),
					new(5579, 155, -10, ""),
				}),
				new("Bed", typeof(Static), 4565, "", new DecorationEntry[]
				{
					new(5445, 177, 22, ""),
					new(5449, 177, 22, ""),
					new(5573, 199, 22, ""),
					new(5584, 185, 22, ""),
				}),
				new("Bed", typeof(Static), 4564, "", new DecorationEntry[]
				{
					new(5445, 179, 22, ""),
					new(5449, 179, 22, ""),
					new(5573, 201, 22, ""),
					new(5584, 187, 22, ""),
				}),
				new("Bed", typeof(Static), 4563, "", new DecorationEntry[]
				{
					new(5447, 179, 22, ""),
					new(5451, 179, 22, ""),
					new(5575, 201, 22, ""),
				}),
				new("Stalagmites", typeof(Static), 2281, "", new DecorationEntry[]
				{
					new(5479, 26, -30, ""),
				}),
				new("Bedroll", typeof(Static), 2648, "", new DecorationEntry[]
				{
					new(5515, 220, 0, ""),
				}),
				new("Dirt", typeof(Static), 12789, "", new DecorationEntry[]
				{
					new(5491, 22, -52, ""),
				}),
				new("Dyeing Tub", typeof(DyeTub), 4011, "Hue=0x35", new DecorationEntry[]
				{
					new(5494, 52, 20, ""),
				}),
				new("Iron Ore", typeof(Static), 6585, "Hue=0x973", new DecorationEntry[]
				{
					new(5609, 14, 11, ""),
				}),
				new("Fishing Net", typeof(Static), 3538, "", new DecorationEntry[]
				{
					new(5499, 220, 0, ""),
				}),
				new("Fishing Net", typeof(Static), 3539, "", new DecorationEntry[]
				{
					new(5499, 221, 0, ""),
				}),
				new("Fishing Net", typeof(Static), 3540, "", new DecorationEntry[]
				{
					new(5499, 222, 0, ""),
				}),
				new("Fishing Net", typeof(Static), 3528, "", new DecorationEntry[]
				{
					new(5500, 220, 0, ""),
				}),
				new("Fishing Net", typeof(Static), 3537, "", new DecorationEntry[]
				{
					new(5501, 220, 0, ""),
				}),
				new("Fishing Net", typeof(Static), 3531, "", new DecorationEntry[]
				{
					new(5501, 221, 0, ""),
				}),
				new("Fishing Net", typeof(Static), 3541, "", new DecorationEntry[]
				{
					new(5501, 222, 0, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(5820, 85, 0, "// spawning"),
					new(5585, 137, 10, "// spawning"),
				}),
				new("Keg", typeof(Keg), 3711, "", new DecorationEntry[]
				{
					new(5522, 203, 0, ""),
					new(5521, 202, 0, ""),
					new(5520, 203, 0, ""),
					new(5520, 202, 0, ""),
					new(5450, 92, 20, ""),
					new(5450, 91, 20, ""),
					new(5449, 92, 20, ""),
					new(5449, 91, 20, ""),
					new(5448, 91, 20, ""),
				}),
				new("Stone Stairs", typeof(Static), 1957, "", new DecorationEntry[]
				{
					new(5516, 174, -23, ""),
				}),
				new("Dungeon Wall", typeof(Static), 579, "", new DecorationEntry[]
				{
					new(5541, 173, 0, ""),
				}),
				new("Water", typeof(Static), 6040, "", new DecorationEntry[]
				{
					new(5550, 13, -5, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(5389, 223, 10, ""),
					new(5572, 192, 0, ""),
				}),
				new("Cloak", typeof(Static), 5397, "", new DecorationEntry[]
				{
					new(5572, 20, 0, ""),
				}),
				new("Stone Face", typeof(Static), 4367, "", new DecorationEntry[]
				{
					new(5569, 201, 0, ""),
				}),
				new("Bed", typeof(Static), 4559, "", new DecorationEntry[]
				{
					new(5586, 187, 22, ""),
				}),
				new("Fitting", typeof(Static), 4395, "", new DecorationEntry[]
				{
					new(5589, 192, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
