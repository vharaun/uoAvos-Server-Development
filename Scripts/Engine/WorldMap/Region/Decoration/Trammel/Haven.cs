using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Trammel
		{
			public static DecorationList[] Haven { get; } = Register(DecorationTarget.Trammel, "Haven", new DecorationList[]
			{
				#region Entries
				
				new("Ankh", typeof(AnkhNorth), 4, "", new DecorationEntry[]
				{
					new(3606, 2582, 10, ""),
				}),
				new("Stone Wall", typeof(Static), 28, "", new DecorationEntry[]
				{
					new(3738, 2679, 40, ""),
				}),
				new("Plaster Wall", typeof(Static), 335, "", new DecorationEntry[]
				{
					new(3673, 2583, 0, ""),
				}),
				new("Wall", typeof(Static), 1104, "Hue=0x482", new DecorationEntry[]
				{
					new(3606, 2582, 0, ""),
				}),
				new("Wall", typeof(Static), 1105, "Hue=0x482", new DecorationEntry[]
				{
					new(3606, 2581, 0, ""),
				}),
				new("Wall", typeof(Static), 1106, "Hue=0x482", new DecorationEntry[]
				{
					new(3605, 2582, 0, ""),
				}),
				new("Wall", typeof(Static), 1107, "Hue=0x482", new DecorationEntry[]
				{
					new(3605, 2581, 0, ""),
				}),
				new("Marble Floor", typeof(Static), 1174, "Hue=0x482", new DecorationEntry[]
				{
					new(3606, 2582, 5, ""),
				}),
				new("Slate Roof", typeof(Static), 1430, "", new DecorationEntry[]
				{
					new(3680, 2600, 20, ""),
					new(3681, 2600, 17, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(3656, 2508, 0, ""),
					new(3624, 2548, 0, ""),
					new(3624, 2546, 0, ""),
				}),
				new("Oven", typeof(StoneOvenSouthAddon), 2352, "", new DecorationEntry[]
				{
					new(3666, 2639, 0, ""),
					new(3653, 2464, 0, ""),
				}),
				new("Fireplace", typeof(Static), 2399, "", new DecorationEntry[]
				{
					new(3741, 2680, 40, ""),
				}),
				new("Fireplace", typeof(Static), 2400, "", new DecorationEntry[]
				{
					new(3740, 2680, 40, ""),
				}),
				new("Fireplace", typeof(StoneFireplaceSouthAddon), 2401, "", new DecorationEntry[]
				{
					new(3650, 2464, 0, ""),
					new(3669, 2640, 0, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(3736, 2572, 40, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2601, "Unlit", new DecorationEntry[]
				{
					new(3638, 2550, 0, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(3697, 2472, 0, ""),
					new(3738, 2561, 40, ""),
					new(3745, 2680, 40, ""),
					new(3605, 2568, 20, ""),
					new(3604, 2568, 20, ""),
					new(3610, 2464, 0, ""),
					new(3705, 2584, 20, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(3728, 2634, 40, ""),
					new(3632, 2501, 0, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2616, "", new DecorationEntry[]
				{
					new(3600, 2505, 0, ""),
					new(3608, 2498, 0, ""),
					new(3632, 2544, 0, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(3602, 2504, 0, ""),
					new(3609, 2496, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(3632, 2497, 0, ""),
					new(3696, 2478, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(3629, 2566, 20, ""),
					new(3602, 2568, 20, ""),
					new(3619, 2472, 0, ""),
					new(3617, 2472, 0, ""),
					new(3609, 2504, 0, ""),
					new(3620, 2472, 0, ""),
					new(3599, 2568, 20, ""),
					new(3622, 2475, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(3619, 2475, 0, ""),
					new(3621, 2475, 0, ""),
					new(3616, 2472, 0, ""),
					new(3630, 2566, 20, ""),
					new(3600, 2568, 20, ""),
					new(3634, 2566, 20, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(3608, 2505, 0, ""),
					new(3648, 2473, 0, ""),
					new(3648, 2470, 0, ""),
					new(3623, 2567, 20, ""),
					new(3626, 2566, 20, ""),
					new(3696, 2473, 0, ""),
					new(3632, 2550, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(3626, 2568, 20, ""),
					new(3623, 2565, 20, ""),
					new(3632, 2549, 0, ""),
					new(3648, 2476, 0, ""),
					new(3648, 2471, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(3622, 2472, 0, ""),
					new(3618, 2475, 0, ""),
					new(3620, 2475, 0, ""),
					new(3635, 2566, 20, ""),
					new(3601, 2568, 20, ""),
					new(3590, 2568, 20, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2716, "", new DecorationEntry[]
				{
					new(3648, 2475, 0, ""),
					new(3648, 2472, 0, ""),
					new(3623, 2568, 20, ""),
					new(3623, 2569, 20, ""),
					new(3626, 2567, 20, ""),
					new(3623, 2566, 20, ""),
				}),
				new("Lamp Post", typeof(LampPost1), 2848, "", new DecorationEntry[]
				{
					new(3735, 2640, 40, ""),
					new(3720, 2655, 20, ""),
					new(3657, 2521, 0, ""),
					new(3657, 2622, 0, ""),
					new(3657, 2654, 0, ""),
					new(3657, 2633, 0, ""),
					new(3657, 2478, 0, ""),
					new(3646, 2607, 0, ""),
					new(3646, 2625, 0, ""),
					new(3651, 2510, 0, ""),
					new(3658, 2568, 0, ""),
					new(3658, 2563, 0, ""),
					new(3657, 2545, 0, ""),
					new(3678, 2521, 0, ""),
					new(3678, 2489, 0, ""),
					new(3614, 2593, 0, ""),
					new(3672, 2633, 0, ""),
					new(3669, 2478, 0, ""),
					new(3669, 2545, 0, ""),
					new(3711, 2592, 20, ""),
					new(3614, 2480, 0, ""),
					new(3743, 2568, 40, ""),
					new(3672, 2510, 0, ""),
					new(3645, 2478, 0, ""),
					new(3646, 2534, 0, ""),
					new(3646, 2521, 0, ""),
					new(3625, 2510, 0, ""),
					new(3694, 2521, 0, ""),
					new(3625, 2489, 0, ""),
					new(3616, 2504, 0, ""),
					new(3632, 2536, 0, ""),
					new(3646, 2545, 0, ""),
					new(3646, 2582, 0, ""),
					new(3615, 2520, 0, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(3672, 2542, 0, ""),
					new(3614, 2510, 0, ""),
				}),
				new("Counter", typeof(Static), 2878, "", new DecorationEntry[]
				{
					new(3590, 2594, 0, ""),
					new(3589, 2594, 0, ""),
				}),
				new("Counter", typeof(Static), 2880, "", new DecorationEntry[]
				{
					new(3588, 2594, 0, ""),
					new(3591, 2594, 0, ""),
				}),
				new("Wooden Signpost", typeof(Static), 2968, "", new DecorationEntry[]
				{
					new(3666, 2512, 0, ""),
				}),
				new("Red Moongate", typeof(Static), 3546, "Hue=0x482;Light=Circle300", new DecorationEntry[]
				{
					new(3632, 2566, 0, ""),
					new(3632, 2566, 20, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3644, "", new DecorationEntry[]
				{
					new(3679, 2593, 0, ""),
					new(3624, 2538, 0, ""),
					new(3624, 2537, 0, ""),
					new(3671, 2595, 0, ""),
					new(3673, 2590, 0, ""),
					new(3678, 2592, 0, ""),
					new(3674, 2588, 0, ""),
					new(3679, 2592, 0, ""),
					new(3672, 2596, 0, ""),
					new(3674, 2587, 0, ""),
					new(3672, 2595, 0, ""),
					new(3673, 2587, 0, ""),
					new(3673, 2589, 0, ""),
					new(3671, 2596, 0, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(3673, 2588, 0, ""),
					new(3624, 2536, 0, ""),
					new(3675, 2587, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(3627, 2618, 4, ""),
					new(3595, 2584, 20, ""),
					new(3595, 2583, 20, ""),
				}),
				new("Metal Chest", typeof(FillableMetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(3677, 2587, -2, ""),
					new(3678, 2587, -2, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(3737, 2561, 40, ""),
					new(3730, 2632, 40, ""),
					new(3709, 2584, 20, ""),
				}),
				new("Fire Pit", typeof(Static), 4012, "Light=Circle225", new DecorationEntry[]
				{
					new(3704, 2596, 20, ""),
					new(3736, 2572, 40, ""),
				}),
				new("Anvil", typeof(AnvilEastAddon), 4015, "", new DecorationEntry[]
				{
					new(3607, 2599, 0, ""),
				}),
				new("Anvil", typeof(AnvilSouthAddon), 4016, "", new DecorationEntry[]
				{
					new(3605, 2598, 0, ""),
					new(3602, 2599, 0, ""),
					new(3644, 2618, 0, ""),
					new(3644, 2615, 0, ""),
					new(3597, 2603, 0, ""),
					new(3593, 2596, 0, ""),
					new(3603, 2603, 0, ""),
				}),
				new("Forge", typeof(SmallForgeAddon), 4017, "", new DecorationEntry[]
				{
					new(3608, 2599, 0, ""),
					new(3592, 2596, 0, ""),
					new(3603, 2604, 0, ""),
					new(3644, 2614, 0, ""),
					new(3605, 2597, 0, ""),
					new(3602, 2598, 0, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelEastAddon), 4121, "", new DecorationEntry[]
				{
					new(3691, 2485, 0, ""),
				}),
				new("Upright Loom", typeof(LoomSouthAddon), 4193, "", new DecorationEntry[]
				{
					new(3692, 2482, 0, ""),
				}),
				new("Stone Face", typeof(StoneFaceTrapNoDamage), 4349, "", new DecorationEntry[]
				{
					new(3607, 2581, 0, ""),
					new(3604, 2581, 0, ""),
				}),
				new("Magical Sparkles", typeof(Static), 4435, "", new DecorationEntry[]
				{
					new(3606, 2582, 0, ""),
					new(3607, 2582, 0, ""),
					new(3607, 2583, 0, ""),
					new(3607, 2583, 7, ""),
					new(3608, 2582, 15, ""),
				}),
				new("Potted Tree", typeof(Static), 4552, "", new DecorationEntry[]
				{
					new(3637, 2496, 0, ""),
				}),
				new("Potted Tree", typeof(Static), 4553, "", new DecorationEntry[]
				{
					new(3704, 2584, 20, ""),
					new(3608, 2504, 0, ""),
					new(3680, 2477, 0, ""),
					new(3633, 2496, 0, ""),
				}),
				new("Flowerpot", typeof(Static), 4554, "", new DecorationEntry[]
				{
					new(3728, 2632, 40, ""),
					new(3600, 2504, 0, ""),
				}),
				new("Flowerpot", typeof(Static), 4555, "", new DecorationEntry[]
				{
					new(3608, 2501, 7, ""),
				}),
				new("Flour Mill", typeof(FlourMillSouthAddon), 6444, "", new DecorationEntry[]
				{
					new(3629, 2536, 0, ""),
				}),
				new("Bellows", typeof(LargeForgeEastAddon), 6534, "", new DecorationEntry[]
				{
					new(3644, 2619, 0, ""),
					new(3596, 2601, 0, ""),
				}),
				new("Archery Butte", typeof(ArcheryButte), 4107, "", new DecorationEntry[]
				{
					new(3744, 2576, 40, ""),
					new(3747, 2576, 40, ""),
				}),
				new("Armoire", typeof(Armoire), 2639, "", new DecorationEntry[]
				{
					new(3641, 2464, 0, ""),
					new(3624, 2632, 0, ""),
					new(3664, 2497, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2906, "", new DecorationEntry[]
				{
					new(3713, 2649, 20, ""),
					new(3665, 2530, 0, ""),
					new(3665, 2532, 0, ""),
					new(3673, 2540, 0, ""),
					new(3673, 2538, 0, ""),
					new(3673, 2536, 0, ""),
					new(3673, 2534, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2908, "", new DecorationEntry[]
				{
					new(3732, 2633, 40, ""),
					new(3666, 2621, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2909, "", new DecorationEntry[]
				{
					new(3737, 2564, 40, ""),
					new(3676, 2534, 0, ""),
					new(3676, 2536, 0, ""),
					new(3676, 2538, 0, ""),
					new(3676, 2540, 0, ""),
					new(3705, 2588, 20, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1677, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(3626, 2621, 0, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1679, "Facing=NorthCW", new DecorationEntry[]
				{
					new(3626, 2620, 0, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(3665, 2648, 5, ""),
					new(3664, 2648, 0, ""),
					new(3664, 2648, 5, ""),
					new(3664, 2649, 5, ""),
					new(3669, 2663, 3, ""),
					new(3669, 2662, -2, ""),
					new(3668, 2662, -2, ""),
					new(3668, 2662, 3, ""),
					new(3668, 2663, -2, ""),
					new(3668, 2663, 3, ""),
					new(3648, 2680, -2, ""),
					new(3648, 2680, 3, ""),
					new(3659, 2666, -2, ""),
					new(3659, 2665, -2, ""),
					new(3658, 2665, -2, ""),
					new(3661, 2673, -2, ""),
					new(3661, 2673, 3, ""),
					new(3647, 2662, -2, ""),
					new(3647, 2662, 3, ""),
					new(3646, 2662, -2, ""),
					new(3646, 2662, 3, ""),
					new(3646, 2663, -2, ""),
					new(3646, 2663, 3, ""),
					new(3647, 2679, -2, ""),
					new(3647, 2679, 3, ""),
					new(3647, 2680, -2, ""),
					new(3647, 2680, 3, ""),
					new(3665, 2648, 0, ""),
					new(3664, 2649, 0, ""),
					new(3669, 2663, -2, ""),
					new(3669, 2662, 3, ""),
					new(3644, 2649, 2, ""),
					new(3645, 2649, -2, ""),
					new(3652, 2654, 5, ""),
					new(3651, 2654, 5, ""),
					new(3652, 2654, 0, ""),
					new(3652, 2655, 0, ""),
					new(3645, 2650, 2, ""),
					new(3644, 2649, -3, ""),
					new(3645, 2650, -3, ""),
					new(3651, 2654, 0, ""),
					new(3652, 2655, 5, ""),
					new(3651, 2655, 5, ""),
					new(3651, 2655, 0, ""),
					new(3645, 2649, 3, ""),
				}),
				new("Bottle Of Wine", typeof(BeverageBottle), 2503, "Content=Wine", new DecorationEntry[]
				{
					new(3666, 2651, 6, ""),
					new(3672, 2653, 6, ""),
					new(3676, 2648, 6, ""),
					new(3668, 2651, 6, ""),
				}),
				new("Board%S", typeof(Board), 7127, "", new DecorationEntry[]
				{
					new(3640, 2507, 0, ""),
				}),
				new("Bulletin Board", typeof(BulletinBoard), 7774, "", new DecorationEntry[]
				{
					new(3673, 2624, 0, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(3638, 2550, 0, ""),
					new(3670, 2528, 0, ""),
					new(3656, 2528, 0, ""),
					new(3677, 2542, 0, ""),
					new(3670, 2608, 0, ""),
					new(3672, 2622, 0, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(3669, 2651, 6, ""),
					new(3704, 2653, 26, ""),
					new(3714, 2648, 26, ""),
					new(3733, 2632, 46, ""),
					new(3603, 2504, 6, ""),
					new(3608, 2499, 6, ""),
					new(3629, 2632, 6, ""),
					new(3652, 2475, 6, ""),
					new(3654, 2464, 6, ""),
					new(3669, 2496, 6, ""),
					new(3704, 2587, 26, ""),
					new(3736, 2563, 46, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6228, "", new DecorationEntry[]
				{
					new(3628, 2545, 6, ""),
					new(3634, 2531, 6, ""),
				}),
				new("Game Board", typeof(CheckerBoard), 4006, "", new DecorationEntry[]
				{
					new(3672, 2649, 4, ""),
				}),
				new("Cleaver", typeof(Cleaver), 3778, "", new DecorationEntry[]
				{
					new(3704, 2649, 26, ""),
				}),
				new("Clock", typeof(Clock), 4172, "", new DecorationEntry[]
				{
					new(3659, 2504, 3, ""),
				}),
				new("Clock Frame%S%", typeof(ClockFrame), 4173, "", new DecorationEntry[]
				{
					new(3662, 2507, 2, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1705, "Facing=WestCCW", new DecorationEntry[]
				{
					new(3676, 2591, 0, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1711, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(3607, 2507, 0, ""),
					new(3639, 2499, 0, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(3626, 2632, 0, ""),
					new(3666, 2496, 0, ""),
					new(3666, 2613, 0, ""),
					new(3666, 2608, 0, ""),
					new(3674, 2613, 0, ""),
					new(3675, 2618, 0, ""),
					new(3675, 2608, 0, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(3640, 2466, 0, ""),
				}),
				new("Drum", typeof(Drums), 3740, "", new DecorationEntry[]
				{
					new(3674, 2534, 6, ""),
					new(3675, 2540, 6, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(3608, 2496, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(3586, 2568, 20, ""),
					new(3622, 2472, 0, ""),
					new(3600, 2568, 20, ""),
					new(3601, 2568, 20, ""),
					new(3634, 2632, 0, ""),
					new(3637, 2632, 0, ""),
					new(3616, 2472, 0, ""),
					new(3621, 2475, 0, ""),
					new(3619, 2475, 0, ""),
					new(3620, 2475, 0, ""),
					new(3618, 2475, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(3590, 2568, 20, ""),
					new(3633, 2632, 0, ""),
					new(3636, 2632, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(3584, 2569, 20, ""),
					new(3584, 2573, 20, ""),
					new(3648, 2471, 0, ""),
					new(3648, 2472, 0, ""),
					new(3648, 2475, 0, ""),
					new(3648, 2476, 0, ""),
					new(3632, 2549, 0, ""),
				}),
				new("Gears", typeof(Gears), 4179, "", new DecorationEntry[]
				{
					new(3665, 2504, 6, ""),
					new(3658, 2504, 6, ""),
				}),
				new("Standing Harp", typeof(Harp), 3761, "", new DecorationEntry[]
				{
					new(3663, 2528, 0, ""),
					new(3664, 2528, 0, ""),
					new(3665, 2528, 0, ""),
					new(3673, 2528, 0, ""),
					new(3676, 2528, 0, ""),
				}),
				new("Iron Gate", typeof(IronGate), 2092, "Facing=SouthCW", new DecorationEntry[]
				{
					new(3423, 2651, 47, ""),
				}),
				new("Iron Gate", typeof(IronGate), 2094, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(3423, 2650, 47, ""),
				}),
				new("Lamp Post", typeof(LampPost1), 2848, "Light=Circle300", new DecorationEntry[]
				{
					new(3613, 2582, 0, ""),
					new(3614, 2624, 0, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3644, "", new DecorationEntry[]
				{
					new(3674, 2587, 3, ""),
					new(3673, 2587, 9, ""),
					new(3673, 2587, 6, ""),
					new(3673, 2587, 3, ""),
					new(3671, 2595, 6, ""),
					new(3672, 2595, 6, ""),
					new(3671, 2595, 3, ""),
					new(3624, 2537, 6, ""),
					new(3624, 2537, 3, ""),
					new(3624, 2538, 3, ""),
					new(3671, 2596, 3, ""),
					new(3672, 2595, 3, ""),
					new(3672, 2596, 3, ""),
				}),
				new("Lute", typeof(Lute), 3763, "", new DecorationEntry[]
				{
					new(3674, 2538, 6, ""),
					new(3675, 2534, 6, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(3673, 2588, 3, ""),
					new(3673, 2588, 0, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(3624, 2536, 3, ""),
					new(3675, 2587, 6, ""),
					new(3675, 2587, 3, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW", new DecorationEntry[]
				{
					new(3599, 2575, 20, ""),
					new(3592, 2590, 20, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Facing=EastCCW", new DecorationEntry[]
				{
					new(3593, 2590, 20, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1661, "Facing=SouthCW", new DecorationEntry[]
				{
					new(3586, 2588, 0, ""),
					new(3594, 2581, 20, ""),
					new(3597, 2594, 20, ""),
					new(3612, 2588, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(3586, 2587, 0, ""),
					new(3594, 2580, 20, ""),
					new(3597, 2593, 20, ""),
					new(3612, 2587, 0, ""),
				}),
				new("Metal Chest", typeof(FillableMetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(3688, 2506, 0, ""),
					new(3688, 2505, 0, ""),
				}),
				new("Pickpocket Dip", typeof(PickpocketDipSouthAddon), 7872, "", new DecorationEntry[]
				{
					new(3698, 2507, 0, ""),
					new(3695, 2507, 0, ""),
					new(3691, 2509, 0, ""),
					new(3689, 2509, 0, ""),
				}),
				new("Pitcher Of Liquor", typeof(Pitcher), 8089, "Content=Liquor", new DecorationEntry[]
				{
					new(3664, 2643, 6, ""),
				}),
				new("Flowerpot", typeof(PottedPlant1), 4555, "", new DecorationEntry[]
				{
					new(3667, 2620, 6, ""),
				}),
				new("Potted Tree", typeof(PottedTree), 4552, "", new DecorationEntry[]
				{
					new(3600, 2504, 0, ""),
					new(3665, 2496, 0, ""),
				}),
				new("Potted Tree", typeof(PottedTree1), 4553, "", new DecorationEntry[]
				{
					new(3640, 2465, 0, ""),
				}),
				new("Small Fish", typeof(PrizedFish), 3542, "", new DecorationEntry[]
				{
					new(3669, 2659, -2, ""),
				}),
				new("Recall Rune", typeof(RecallRune), 7956, "Hue=50;Description=a haunted graveyard west of here;Marked=true;Target=(3422, 2653, 48);TargetMap=Trammel", new DecorationEntry[]
				{
					new(3594, 2581, 7, ""),
				}),
				new("Rope", typeof(Static), 5368, "", new DecorationEntry[]
				{
					new(3660, 2677, -2, ""),
					new(3632, 2632, 0, ""),
					new(3647, 2669, -2, ""),
				}),
				new("Rope", typeof(Static), 5370, "", new DecorationEntry[]
				{
					new(3669, 2660, -2, ""),
				}),
				new("Scissors", typeof(Scissors), 3998, "", new DecorationEntry[]
				{
					new(3692, 2478, 6, ""),
				}),
				new("Scissors", typeof(Scissors), 3999, "", new DecorationEntry[]
				{
					new(3688, 2484, 6, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor2), 804, "Facing=WestCW", new DecorationEntry[]
				{
					new(3522, 2993, 9, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor2), 806, "Facing=EastCCW", new DecorationEntry[]
				{
					new(3523, 2993, 9, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor2), 808, "Facing=WestCCW", new DecorationEntry[]
				{
					new(3430, 2990, 5, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor2), 810, "Facing=EastCW", new DecorationEntry[]
				{
					new(3431, 2990, 5, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor2), 818, "Facing=NorthCW", new DecorationEntry[]
				{
					new(3371, 2861, 7, ""),
				}),
				new("Sewing Kit", typeof(SewingKit), 3997, "", new DecorationEntry[]
				{
					new(3691, 2478, 6, ""),
				}),
				new("Music Stand", typeof(ShortMusicStand), 3766, "", new DecorationEntry[]
				{
					new(3660, 2528, 0, ""),
					new(3659, 2528, 0, ""),
					new(3661, 2528, 0, ""),
					new(3662, 2528, 0, ""),
					new(3666, 2528, 0, ""),
					new(3667, 2528, 0, ""),
					new(3668, 2528, 0, ""),
					new(3669, 2528, 0, ""),
				}),
				new("Skinning Knife", typeof(SkinningKnife), 3780, "", new DecorationEntry[]
				{
					new(3736, 2682, 46, ""),
				}),
				new("Pile%S% Of Wool", typeof(Static), 4127, "", new DecorationEntry[]
				{
					new(3691, 2466, 0, ""),
					new(3693, 2469, 0, ""),
				}),
				new("Wood Curls", typeof(Static), 4152, "", new DecorationEntry[]
				{
					new(3668, 2509, 0, ""),
					new(3668, 2506, 0, ""),
					new(3659, 2506, 0, ""),
					new(3645, 2498, 0, ""),
					new(3642, 2506, 0, ""),
					new(3643, 2503, 0, ""),
				}),
				new("Sack Of Flour", typeof(Static), 4153, "", new DecorationEntry[]
				{
					new(3666, 2643, 0, ""),
				}),
				new("Loom Bench", typeof(Static), 4170, "", new DecorationEntry[]
				{
					new(3692, 2482, 0, ""),
				}),
				new("Magical Sparkles", typeof(Static), 4435, "", new DecorationEntry[]
				{
					new(3597, 2582, 0, ""),
				}),
				new("Potted Tree", typeof(Static), 4553, "", new DecorationEntry[]
				{
					new(3700, 2504, 0, ""),
					new(3697, 2504, 0, ""),
					new(3694, 2504, 0, ""),
				}),
				new("A Bulk Order Deed Completed By Hanse", typeof(LocalizedStatic), 5359, "LabelNumber=1048169;Hue=805", new DecorationEntry[]
				{
					new(3588, 2600, 6, ""),
				}),
				new("Plough", typeof(Static), 5376, "", new DecorationEntry[]
				{
					new(3740, 2645, 40, ""),
				}),
				new("Harrow", typeof(Static), 5381, "", new DecorationEntry[]
				{
					new(3740, 2643, 40, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(3417, 2494, 10, ""),
					new(3418, 2494, 5, ""),
					new(3417, 2493, 10, ""),
				}),
				new("Pewter Bowl", typeof(Static), 5629, "", new DecorationEntry[]
				{
					new(3654, 2465, 6, ""),
				}),
				new("Large Pewter Bowl", typeof(Static), 5635, "", new DecorationEntry[]
				{
					new(3654, 2467, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5983, "Hue=438", new DecorationEntry[]
				{
					new(3688, 2464, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5985, "Hue=53", new DecorationEntry[]
				{
					new(3691, 2464, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5986, "Hue=438", new DecorationEntry[]
				{
					new(3688, 2468, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5986, "Hue=53", new DecorationEntry[]
				{
					new(3690, 2464, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5987, "Hue=438", new DecorationEntry[]
				{
					new(3688, 2467, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5987, "Hue=53", new DecorationEntry[]
				{
					new(3692, 2464, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5988, "Hue=438", new DecorationEntry[]
				{
					new(3688, 2465, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5988, "Hue=53", new DecorationEntry[]
				{
					new(3693, 2464, 6, ""),
				}),
				new("Heating Stand", typeof(Static), 6222, "Light=Circle150", new DecorationEntry[]
				{
					new(3612, 2471, 6, ""),
					new(3610, 2477, 6, ""),
				}),
				new("Scales", typeof(Static), 6225, "", new DecorationEntry[]
				{
					new(3614, 2471, 6, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6232, "", new DecorationEntry[]
				{
					new(3611, 2474, 6, ""),
				}),
				new("Empty Vials", typeof(Static), 6235, "", new DecorationEntry[]
				{
					new(3613, 2471, 6, ""),
				}),
				new("Full Vials", typeof(Static), 6238, "", new DecorationEntry[]
				{
					new(3611, 2476, 6, ""),
				}),
				new("Dishing Stump", typeof(Static), 6245, "", new DecorationEntry[]
				{
					new(3745, 2689, 40, ""),
				}),
				new("Woodworker's Bench", typeof(Static), 6641, "", new DecorationEntry[]
				{
					new(3642, 2498, 0, ""),
				}),
				new("Woodworker's Bench", typeof(Static), 6642, "", new DecorationEntry[]
				{
					new(3642, 2497, 0, ""),
				}),
				new("Woodworker's Bench", typeof(Static), 6643, "", new DecorationEntry[]
				{
					new(3642, 2496, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 26, "", new DecorationEntry[]
				{
					new(3692, 2508, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 27, "", new DecorationEntry[]
				{
					new(3692, 2507, 0, ""),
					new(3692, 2504, 0, ""),
				}),
				new("Boards", typeof(Static), 7129, "", new DecorationEntry[]
				{
					new(3644, 2496, 0, ""),
					new(3643, 2496, 0, ""),
				}),
				new("Logs", typeof(Static), 7134, "", new DecorationEntry[]
				{
					new(3648, 2498, 0, ""),
					new(3640, 2508, 0, ""),
				}),
				new("Logs", typeof(Static), 7135, "", new DecorationEntry[]
				{
					new(3648, 2499, 0, ""),
					new(3648, 2500, 0, ""),
					new(3648, 2501, 0, ""),
					new(3648, 2503, 0, ""),
					new(3648, 2504, 0, ""),
					new(3640, 2509, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 28, "", new DecorationEntry[]
				{
					new(3689, 2508, 0, ""),
					new(3688, 2508, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 30, "", new DecorationEntry[]
				{
					new(3690, 2508, 0, ""),
				}),
				new("Raw Fish", typeof(Static), 7704, "", new DecorationEntry[]
				{
					new(3736, 2683, 46, ""),
				}),
				new("Books", typeof(Static), 7713, "", new DecorationEntry[]
				{
					new(3611, 2475, 6, ""),
				}),
				new("Books", typeof(Static), 7716, "", new DecorationEntry[]
				{
					new(3611, 2477, 6, ""),
				}),
				new("Books", typeof(Static), 7717, "", new DecorationEntry[]
				{
					new(3610, 2474, 6, ""),
				}),
				new("Dartboard", typeof(DartBoard), 7726, "", new DecorationEntry[]
				{
					new(3698, 2504, 0, ""),
					new(3695, 2504, 0, ""),
				}),
				new("Dartboard", typeof(DartBoard), 7727, "", new DecorationEntry[]
				{
					new(3688, 2512, 0, ""),
					new(3688, 2515, 0, ""),
				}),
				new("Trophy", typeof(Static), 7776, "", new DecorationEntry[]
				{
					new(3738, 2680, 40, ""),
				}),
				new("Trophy", typeof(Static), 7781, "", new DecorationEntry[]
				{
					new(3739, 2680, 40, ""),
				}),
				new("Trophy", typeof(Static), 7782, "", new DecorationEntry[]
				{
					new(3742, 2680, 40, ""),
				}),
				new("Trophy", typeof(Static), 7784, "", new DecorationEntry[]
				{
					new(3736, 2692, 40, ""),
				}),
				new("Trophy", typeof(Static), 7785, "", new DecorationEntry[]
				{
					new(3736, 2689, 40, ""),
				}),
				new("Trophy", typeof(Static), 7786, "", new DecorationEntry[]
				{
					new(3736, 2691, 40, ""),
				}),
				new("Trophy", typeof(Static), 7787, "", new DecorationEntry[]
				{
					new(3736, 2686, 40, ""),
				}),
				new("Tool Kit", typeof(Static), 7866, "", new DecorationEntry[]
				{
					new(3656, 2504, 6, ""),
				}),
				new("Tinker's Tools", typeof(Static), 7868, "", new DecorationEntry[]
				{
					new(3664, 2504, 6, ""),
				}),
				new("Stone Wall", typeof(Static), 33, "", new DecorationEntry[]
				{
					new(3691, 2508, 0, ""),
				}),
				new("Wooden Ramp", typeof(Static), 2170, "", new DecorationEntry[]
				{
					new(3695, 2761, 35, ""),
					new(3695, 2760, 35, ""),
					new(3695, 2759, 35, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(3735, 2645, 40, ""),
				}),
				new("Slab%S% Of Bacon", typeof(Static), 2423, "", new DecorationEntry[]
				{
					new(3704, 2650, 26, ""),
				}),
				new("Tray", typeof(Static), 2449, "", new DecorationEntry[]
				{
					new(3651, 2469, 6, ""),
				}),
				new("Tray", typeof(Static), 2450, "", new DecorationEntry[]
				{
					new(3664, 2644, 6, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2453, "", new DecorationEntry[]
				{
					new(3634, 2496, 6, ""),
					new(3667, 2651, 6, ""),
					new(3665, 2651, 6, ""),
					new(3672, 2652, 6, ""),
					new(3676, 2653, 6, ""),
					new(3736, 2565, 46, ""),
					new(3731, 2632, 46, ""),
					new(3627, 2632, 6, ""),
					new(3704, 2589, 26, ""),
					new(3676, 2649, 6, ""),
					new(3608, 2467, 6, ""),
				}),
				new("Mug", typeof(CeramicMug), 2456, "", new DecorationEntry[]
				{
					new(3650, 2474, 6, ""),
				}),
				new("Mug", typeof(CeramicMug), 2457, "", new DecorationEntry[]
				{
					new(3650, 2475, 6, ""),
				}),
				new("Knife", typeof(Knife), 2469, "", new DecorationEntry[]
				{
					new(3736, 2681, 46, ""),
				}),
				new("Metal Box", typeof(FillableMetalBox), 2472, "", new DecorationEntry[]
				{
					new(3688, 2472, 6, ""),
				}),
				new("Silverware", typeof(Static), 2494, "", new DecorationEntry[]
				{
					new(3651, 2474, 6, ""),
				}),
				new("Bottles Of Wine", typeof(Static), 2500, "", new DecorationEntry[]
				{
					new(3669, 2644, 0, ""),
					new(3664, 2642, 6, ""),
				}),
				new("Silverware", typeof(Static), 2516, "", new DecorationEntry[]
				{
					new(3732, 2632, 46, ""),
					new(3628, 2632, 6, ""),
					new(3651, 2475, 6, ""),
				}),
				new("Silverware", typeof(Static), 2517, "", new DecorationEntry[]
				{
					new(3704, 2588, 27, ""),
					new(3736, 2564, 46, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(3635, 2496, 6, ""),
					new(3736, 2564, 46, ""),
					new(3732, 2632, 46, ""),
					new(3628, 2632, 6, ""),
					new(3651, 2475, 6, ""),
					new(3651, 2474, 6, ""),
					new(3704, 2588, 26, ""),
					new(3608, 2466, 6, ""),
				}),
				new("Pot", typeof(Static), 2528, "", new DecorationEntry[]
				{
					new(3653, 2469, 6, ""),
				}),
				new("Pot", typeof(Static), 2529, "", new DecorationEntry[]
				{
					new(3652, 2469, 6, ""),
				}),
				new("Pot", typeof(Static), 2531, "", new DecorationEntry[]
				{
					new(3669, 2642, 0, ""),
					new(3664, 2641, 6, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(3584, 2577, 0, ""),
					new(3667, 2641, 0, ""),
					new(3651, 2465, 0, ""),
				}),
				new("Fork", typeof(Fork), 2548, "", new DecorationEntry[]
				{
					new(3635, 2496, 6, ""),
				}),
				new("Knife", typeof(Knife), 2550, "", new DecorationEntry[]
				{
					new(3635, 2496, 7, ""),
				}),
				new("Knife", typeof(Knife), 2551, "", new DecorationEntry[]
				{
					new(3608, 2466, 7, ""),
				}),
				new("Spoon", typeof(Spoon), 2552, "", new DecorationEntry[]
				{
					new(3635, 2496, 7, ""),
				}),
				new("Spoon", typeof(Spoon), 2553, "", new DecorationEntry[]
				{
					new(3608, 2466, 7, ""),
				}),
				new("Candle", typeof(Static), 2598, "Light=Circle150", new DecorationEntry[]
				{
					new(3688, 2476, 6, ""),
					new(3636, 2496, 6, ""),
				}),
				new("Candle", typeof(Static), 2598, "Light=Circle150", new DecorationEntry[]
				{
					new(3608, 2465, 6, ""),
				}),
				new("Candle", typeof(Static), 2842, "Light=Circle150", new DecorationEntry[]
				{
					new(3640, 2467, 6, ""),
				}),
				new("Table", typeof(Static), 2868, "Hue=1154", new DecorationEntry[]
				{
					new(3594, 2581, 0, ""),
				}),
				new("Table", typeof(Static), 2928, "", new DecorationEntry[]
				{
					new(3668, 2504, 0, ""),
					new(3664, 2504, 0, ""),
				}),
				new("Table", typeof(Static), 2929, "", new DecorationEntry[]
				{
					new(3669, 2504, 0, ""),
					new(3665, 2504, 0, ""),
				}),
				new("Wooden Signpost", typeof(Static), 2970, "", new DecorationEntry[]
				{
					new(3666, 2512, 0, ""),
				}),
				new("Debris", typeof(Static), 3117, "", new DecorationEntry[]
				{
					new(3669, 2506, 0, ""),
				}),
				new("Raw Cotton", typeof(Static), 3567, "", new DecorationEntry[]
				{
					new(3688, 2469, 0, ""),
				}),
				new("Knitting", typeof(Static), 3574, "", new DecorationEntry[]
				{
					new(3693, 2478, 6, ""),
				}),
				new("Chessmen", typeof(Static), 3604, "", new DecorationEntry[]
				{
					new(3672, 2648, 5, ""),
				}),
				new("Bloody Water", typeof(Static), 3619, "", new DecorationEntry[]
				{
					new(3736, 2684, 46, ""),
				}),
				new("Stump", typeof(Static), 3670, "", new DecorationEntry[]
				{
					new(3651, 2504, 0, ""),
				}),
				new("Strong Box", typeof(FillableMetalBox), 3712, "", new DecorationEntry[]
				{
					new(3668, 2597, 6, ""),
				}),
				new("Sheet Music", typeof(Static), 3775, "", new DecorationEntry[]
				{
					new(3674, 2528, 0, ""),
					new(3675, 2528, 0, ""),
				}),
				new("Dress Form", typeof(Static), 3782, "", new DecorationEntry[]
				{
					new(3690, 2468, 0, ""),
					new(3688, 2480, 0, ""),
				}),
				new("Dress Form", typeof(Static), 3783, "", new DecorationEntry[]
				{
					new(3693, 2467, 0, ""),
				}),
				new("Bolt%S% Of Cloth", typeof(Static), 3990, "Hue=438", new DecorationEntry[]
				{
					new(3693, 2479, 0, ""),
					new(3692, 2479, 0, ""),
				}),
				new("Bolt%S% Of Cloth", typeof(Static), 3991, "Hue=53", new DecorationEntry[]
				{
					new(3692, 2465, 0, ""),
				}),
				new("Bolt%S% Of Cloth", typeof(Static), 3992, "Hue=438", new DecorationEntry[]
				{
					new(3689, 2467, 0, ""),
					new(3689, 2482, 0, ""),
				}),
				new("Bolt%S% Of Cloth", typeof(Static), 3994, "Hue=438", new DecorationEntry[]
				{
					new(3689, 2466, 0, ""),
					new(3689, 2483, 0, ""),
				}),
				new("Bolt%S% Of Cloth", typeof(Static), 3996, "Hue=38", new DecorationEntry[]
				{
					new(3693, 2465, 0, ""),
				}),
				new("Playing Cards", typeof(Static), 4003, "", new DecorationEntry[]
				{
					new(3676, 2652, 6, ""),
				}),
				new("Fire Pit", typeof(Static), 4012, "", new DecorationEntry[]
				{
					new(3735, 2645, 40, ""),
				}),
				new("Backgammon Game", typeof(Backgammon), 4013, "", new DecorationEntry[]
				{
					new(3676, 2650, 4, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(3661, 2672, -2, ""),
					new(3671, 2665, -2, ""),
					new(3645, 2674, -2, ""),
				}),
				new("Hanse's Ancient Smithy Hammer", typeof(LocalizedStatic), 4020, "LabelNumber=1048173;Hue=1154", new DecorationEntry[]
				{
					new(3459, 2777, 25, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(3688, 2474, 6, ""),
					new(3714, 2649, 26, ""),
					new(3640, 2468, 6, ""),
					new(3608, 2500, 6, ""),
					new(3666, 2531, 6, ""),
					new(3675, 2532, 6, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(3604, 2504, 6, ""),
					new(3668, 2496, 6, ""),
					new(3666, 2620, 6, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(3688, 2474, 6, ""),
					new(3714, 2649, 26, ""),
					new(3640, 2468, 6, ""),
					new(3608, 2500, 6, ""),
					new(3666, 2531, 6, ""),
					new(3675, 2532, 6, ""),
				}),
				new("Fireplace", typeof(StoneFireplaceEastAddon), 2393, "", new DecorationEntry[]
				{
					new(3584, 2581, 20, ""),
				}),
				new("Fireplace", typeof(StoneFireplaceSouthAddon), 2401, "", new DecorationEntry[]
				{
					new(3741, 2680, 40, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(3584, 2575, 0, ""),
					new(3584, 2578, 0, ""),
				}),
				new("Stool", typeof(Stool), 2602, "", new DecorationEntry[]
				{
					new(3664, 2652, 0, ""),
					new(3665, 2652, 0, ""),
					new(3666, 2652, 0, ""),
					new(3667, 2652, 0, ""),
					new(3668, 2652, 0, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1765, "Facing=WestCW", new DecorationEntry[]
				{
					new(3606, 2573, 0, ""),
					new(3595, 2567, 0, ""),
					new(3601, 2573, 0, ""),
					new(3596, 2573, 0, ""),
					new(3592, 2580, 0, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1773, "Facing=SouthCW", new DecorationEntry[]
				{
					new(3692, 2506, 0, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1775, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(3692, 2505, 0, ""),
				}),
				new("Music Stand", typeof(TallMusicStand), 3771, "", new DecorationEntry[]
				{
					new(3674, 2528, 0, ""),
					new(3675, 2528, 0, ""),
				}),
				new("Tambourine", typeof(Tambourine), 3741, "", new DecorationEntry[]
				{
					new(3675, 2536, 6, ""),
					new(3674, 2540, 6, ""),
				}),
				new("Tambourine", typeof(TambourineTassel), 3742, "", new DecorationEntry[]
				{
					new(3674, 2536, 6, ""),
					new(3675, 2538, 6, ""),
				}),
				new("Tool Kit", typeof(TinkerTools), 7864, "", new DecorationEntry[]
				{
					new(3668, 2504, 6, ""),
				}),
				new("Training Dummy", typeof(TrainingDummy), 4208, "", new DecorationEntry[]
				{
					new(3730, 2576, 40, ""),
					new(3733, 2576, 40, ""),
				}),
				new("Training Dummy", typeof(TrainingDummy), 4212, "", new DecorationEntry[]
				{
					new(3728, 2586, 40, ""),
					new(3728, 2581, 40, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(3673, 2532, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(3627, 2529, 0, ""),
					new(3651, 2473, 0, ""),
					new(3666, 2619, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(3689, 2474, 0, ""),
					new(3641, 2468, 0, ""),
					new(3667, 2531, 0, ""),
					new(3676, 2532, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(3635, 2497, 0, ""),
					new(3651, 2476, 0, ""),
					new(3668, 2497, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2898, "", new DecorationEntry[]
				{
					new(3608, 2509, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(3613, 2504, 0, ""),
					new(3739, 2687, 40, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2900, "", new DecorationEntry[]
				{
					new(3604, 2505, 0, ""),
					new(3739, 2690, 40, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2901, "", new DecorationEntry[]
				{
					new(3609, 2500, 0, ""),
				}),
				new("Wooden Chest", typeof(FillableWoodenChest), 3650, "", new DecorationEntry[]
				{
					new(3674, 2611, 0, ""),
					new(3674, 2622, 0, ""),
				}),
				new("Wooden Chest", typeof(FillableWoodenChest), 3651, "", new DecorationEntry[]
				{
					new(3665, 2613, 0, ""),
					new(3678, 2613, 0, ""),
					new(3664, 2608, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
