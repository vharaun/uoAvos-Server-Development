using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Felucca
		{
			public static DecorationList[] Ocllo { get; } = Register(DecorationTarget.Felucca, "Ocllo", new DecorationList[]
			{
				#region Entries
				
				new("Stone Wall", typeof(Static), 26, "", new DecorationEntry[]
				{
					new(3692, 2508, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 27, "", new DecorationEntry[]
				{
					new(3692, 2504, 0, ""),
					new(3692, 2505, 0, ""),
					new(3692, 2506, 0, ""),
					new(3692, 2507, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 28, "", new DecorationEntry[]
				{
					new(3688, 2508, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 30, "", new DecorationEntry[]
				{
					new(3691, 2508, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 33, "", new DecorationEntry[]
				{
					new(3689, 2508, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW", new DecorationEntry[]
				{
					new(3690, 2508, 0, ""),
				}),
				new("Chimney", typeof(Static), 2268, "", new DecorationEntry[]
				{
					new(3740, 2680, 64, ""),
				}),
				new("Chimney", typeof(Static), 2269, "", new DecorationEntry[]
				{
					new(3741, 2680, 64, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(3656, 2506, 0, ""),
				}),
				new("Oven", typeof(StoneOvenSouthAddon), 2352, "", new DecorationEntry[]
				{
					new(3615, 2568, 0, ""),
					new(3653, 2464, 0, ""),
					new(3666, 2639, 0, ""),
					new(3738, 2679, 40, ""),
				}),
				new("Fireplace", typeof(StoneFireplaceEastAddon), 2393, "", new DecorationEntry[]
				{
					new(3656, 2508, 0, ""),
				}),
				new("Fireplace", typeof(Static), 2399, "", new DecorationEntry[]
				{
					new(3650, 2464, 0, ""),
					new(3669, 2640, 0, ""),
					new(3741, 2680, 40, ""),
				}),
				new("Fireplace", typeof(Static), 2400, "", new DecorationEntry[]
				{
					new(3649, 2464, 0, ""),
					new(3668, 2640, 0, ""),
					new(3740, 2680, 40, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(3735, 2645, 40, ""),
					new(3736, 2572, 40, ""),
				}),
				new("Slab Of Bacon", typeof(Static), 2422, "", new DecorationEntry[]
				{
					new(3704, 2650, 26, ""),
				}),
				new("Tray", typeof(Static), 2449, "", new DecorationEntry[]
				{
					new(3651, 2469, 6, ""),
					new(3736, 2683, 46, ""),
				}),
				new("Tray", typeof(Static), 2450, "", new DecorationEntry[]
				{
					new(3658, 2504, 6, ""),
					new(3664, 2644, 6, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2453, "", new DecorationEntry[]
				{
					new(3595, 2600, 4, ""),
					new(3627, 2632, 4, ""),
					new(3634, 2496, 4, ""),
					new(3650, 2475, 4, ""),
					new(3672, 2652, 6, ""),
					new(3676, 2653, 4, ""),
					new(3731, 2632, 46, ""),
					new(3738, 2689, 44, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2454, "", new DecorationEntry[]
				{
					new(3650, 2474, 4, ""),
					new(3662, 2507, 4, ""),
					new(3738, 2688, 44, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2455, "", new DecorationEntry[]
				{
					new(3704, 2589, 26, ""),
					new(3736, 2565, 46, ""),
				}),
				new("Fork", typeof(Fork), 2468, "", new DecorationEntry[]
				{
					new(3651, 2474, 4, ""),
					new(3663, 2507, 4, ""),
					new(3739, 2688, 44, ""),
				}),
				new("Knife", typeof(Knife), 2470, "", new DecorationEntry[]
				{
					new(3651, 2474, 4, ""),
					new(3663, 2507, 4, ""),
					new(3739, 2688, 44, ""),
				}),
				new("Metal Box", typeof(FillableMetalBox), 2472, "", new DecorationEntry[]
				{
					new(3632, 2568, 6, ""),
					new(3641, 2596, 6, ""),
					new(3664, 2584, 6, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(3688, 2504, 0, ""),
					new(3690, 2504, 0, ""),
					new(3690, 2505, 0, ""),
				}),
				new("Sausage", typeof(Sausage), 2497, "", new DecorationEntry[]
				{
					new(3704, 2652, 26, ""),
				}),
				new("Spoon", typeof(Spoon), 2499, "", new DecorationEntry[]
				{
					new(3651, 2474, 4, ""),
					new(3663, 2507, 4, ""),
					new(3739, 2688, 44, ""),
				}),
				new("Bottles Of Wine", typeof(Static), 2500, "", new DecorationEntry[]
				{
					new(3664, 2642, 6, ""),
				}),
				new("Bottles Of Wine", typeof(Static), 2501, "", new DecorationEntry[]
				{
					new(3669, 2644, 0, ""),
				}),
				new("Bottle Of Wine", typeof(BeverageBottle), 2503, "Content=Wine", new DecorationEntry[]
				{
					new(3668, 2651, 6, ""),
					new(3672, 2653, 4, ""),
					new(3676, 2648, 4, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2506, "", new DecorationEntry[]
				{
					new(3608, 2467, 4, ""),
					new(3664, 2508, 4, ""),
					new(3665, 2651, 6, ""),
					new(3667, 2651, 6, ""),
					new(3676, 2649, 4, ""),
				}),
				new("Pitcher", typeof(Static), 2518, "", new DecorationEntry[]
				{
					new(3608, 2568, 6, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(3596, 2600, 4, ""),
					new(3608, 2466, 4, ""),
					new(3628, 2632, 4, ""),
					new(3635, 2496, 4, ""),
					new(3651, 2474, 4, ""),
					new(3651, 2475, 4, ""),
					new(3663, 2507, 4, ""),
					new(3663, 2508, 4, ""),
					new(3704, 2588, 26, ""),
					new(3732, 2632, 46, ""),
					new(3736, 2564, 46, ""),
					new(3739, 2688, 44, ""),
					new(3739, 2689, 44, ""),
				}),
				new("Pot", typeof(Static), 2528, "", new DecorationEntry[]
				{
					new(3653, 2469, 6, ""),
				}),
				new("Pot", typeof(Static), 2529, "", new DecorationEntry[]
				{
					new(3652, 2469, 6, ""),
					new(3737, 2681, 40, ""),
				}),
				new("Frypan", typeof(Static), 2530, "", new DecorationEntry[]
				{
					new(3657, 2504, 6, ""),
					new(3664, 2641, 6, ""),
				}),
				new("Pot", typeof(Static), 2531, "", new DecorationEntry[]
				{
					new(3659, 2504, 6, ""),
					new(3669, 2642, 0, ""),
					new(3738, 2683, 40, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(3610, 2569, 6, ""),
					new(3651, 2465, 0, ""),
					new(3657, 2508, 0, ""),
					new(3667, 2641, 0, ""),
					new(3739, 2680, 40, ""),
				}),
				new("Milk", typeof(Pitcher), 2544, "Content=Milk", new DecorationEntry[]
				{
					new(3664, 2643, 6, ""),
				}),
				new("Fork", typeof(Fork), 2548, "", new DecorationEntry[]
				{
					new(3596, 2600, 4, ""),
					new(3628, 2632, 4, ""),
					new(3635, 2496, 4, ""),
					new(3651, 2475, 4, ""),
					new(3663, 2508, 4, ""),
					new(3732, 2632, 46, ""),
					new(3739, 2689, 44, ""),
				}),
				new("Fork", typeof(Fork), 2549, "", new DecorationEntry[]
				{
					new(3608, 2466, 4, ""),
					new(3704, 2588, 26, ""),
					new(3736, 2564, 46, ""),
				}),
				new("Knife", typeof(Knife), 2550, "", new DecorationEntry[]
				{
					new(3596, 2600, 4, ""),
					new(3628, 2632, 4, ""),
					new(3635, 2496, 4, ""),
					new(3651, 2475, 4, ""),
					new(3663, 2508, 4, ""),
					new(3732, 2632, 46, ""),
					new(3739, 2689, 44, ""),
				}),
				new("Knife", typeof(Knife), 2551, "", new DecorationEntry[]
				{
					new(3608, 2466, 4, ""),
					new(3704, 2588, 26, ""),
					new(3736, 2564, 46, ""),
				}),
				new("Spoon", typeof(Spoon), 2552, "", new DecorationEntry[]
				{
					new(3596, 2600, 4, ""),
					new(3628, 2632, 4, ""),
					new(3635, 2496, 4, ""),
					new(3651, 2475, 4, ""),
					new(3663, 2508, 4, ""),
					new(3732, 2632, 46, ""),
					new(3739, 2689, 44, ""),
				}),
				new("Spoon", typeof(Spoon), 2553, "", new DecorationEntry[]
				{
					new(3608, 2466, 4, ""),
					new(3704, 2588, 26, ""),
					new(3736, 2564, 46, ""),
				}),
				new("Stool", typeof(Static), 2603, "", new DecorationEntry[]
				{
					new(3664, 2652, 0, ""),
					new(3665, 2652, 0, ""),
					new(3666, 2652, 0, ""),
					new(3667, 2652, 0, ""),
					new(3668, 2652, 0, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(3594, 2600, 0, ""),
					new(3610, 2464, 0, ""),
					new(3617, 2576, 0, ""),
					new(3626, 2632, 0, ""),
					new(3633, 2561, 0, ""),
					new(3633, 2592, 0, ""),
					new(3633, 2601, 0, ""),
					new(3666, 2496, 0, ""),
					new(3666, 2608, 0, ""),
					new(3666, 2613, 0, ""),
					new(3673, 2584, 0, ""),
					new(3674, 2613, 0, ""),
					new(3675, 2608, 0, ""),
					new(3675, 2618, 0, ""),
					new(3705, 2584, 20, ""),
					new(3738, 2561, 40, ""),
					new(3745, 2680, 40, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2608, "", new DecorationEntry[]
				{
					new(3633, 2544, 0, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(3632, 2501, 0, ""),
					new(3640, 2466, 0, ""),
					new(3728, 2634, 40, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2616, "", new DecorationEntry[]
				{
					new(3600, 2505, 0, ""),
					new(3608, 2498, 0, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(3602, 2504, 0, ""),
					new(3609, 2496, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2639, "", new DecorationEntry[]
				{
					new(3592, 2600, 0, ""),
					new(3621, 2576, 0, ""),
					new(3624, 2632, 0, ""),
					new(3635, 2561, 0, ""),
					new(3635, 2592, 0, ""),
					new(3641, 2464, 0, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2641, "", new DecorationEntry[]
				{
					new(3632, 2549, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(3632, 2497, 0, ""),
					new(3632, 2606, 0, ""),
					new(3664, 2497, 0, ""),
					new(3672, 2589, 0, ""),
					new(3744, 2685, 40, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(3609, 2504, 0, ""),
					new(3617, 2472, 0, ""),
					new(3619, 2472, 0, ""),
					new(3620, 2472, 0, ""),
					new(3622, 2475, 0, ""),
					new(3633, 2632, 0, ""),
					new(3640, 2592, 0, ""),
					new(3663, 2504, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(3609, 2469, 0, ""),
					new(3616, 2472, 0, ""),
					new(3619, 2475, 0, ""),
					new(3621, 2475, 0, ""),
					new(3634, 2632, 0, ""),
					new(3638, 2592, 0, ""),
					new(3664, 2504, 0, ""),
					new(3669, 2504, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(3608, 2470, 0, ""),
					new(3608, 2472, 0, ""),
					new(3608, 2505, 0, ""),
					new(3615, 2477, 0, ""),
					new(3632, 2602, 0, ""),
					new(3648, 2470, 0, ""),
					new(3648, 2473, 0, ""),
					new(3672, 2585, 0, ""),
					new(3736, 2686, 40, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(3608, 2473, 0, ""),
					new(3615, 2476, 0, ""),
					new(3648, 2471, 0, ""),
					new(3648, 2476, 0, ""),
					new(3736, 2688, 40, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(3618, 2475, 0, ""),
					new(3620, 2475, 0, ""),
					new(3622, 2472, 0, ""),
					new(3639, 2592, 0, ""),
					new(3665, 2504, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2716, "", new DecorationEntry[]
				{
					new(3615, 2475, 0, ""),
					new(3648, 2472, 0, ""),
					new(3648, 2475, 0, ""),
					new(3736, 2689, 40, ""),
					new(3736, 2692, 40, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2717, "", new DecorationEntry[]
				{
					new(3613, 2469, 0, ""),
					new(3614, 2469, 0, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2718, "", new DecorationEntry[]
				{
					new(3736, 2685, 40, ""),
					new(3736, 2691, 40, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(3597, 2600, 4, ""),
					new(3603, 2504, 4, ""),
					new(3604, 2573, 6, ""),
					new(3604, 2605, 6, ""),
					new(3608, 2465, 4, ""),
					new(3608, 2499, 4, ""),
					new(3611, 2477, 4, ""),
					new(3614, 2471, 4, ""),
					new(3624, 2605, 4, ""),
					new(3629, 2632, 4, ""),
					new(3631, 2500, 20, ""),
					new(3632, 2571, 6, ""),
					new(3636, 2496, 4, ""),
					new(3640, 2467, 4, ""),
					new(3641, 2594, 6, ""),
					new(3643, 2501, 6, ""),
					new(3652, 2475, 4, ""),
					new(3654, 2464, 6, ""),
					new(3656, 2504, 6, ""),
					new(3664, 2507, 4, ""),
					new(3664, 2588, 6, ""),
					new(3669, 2496, 4, ""),
					new(3669, 2651, 6, ""),
					new(3704, 2587, 26, ""),
					new(3704, 2653, 26, ""),
					new(3714, 2648, 26, ""),
					new(3733, 2632, 46, ""),
					new(3736, 2563, 46, ""),
					new(3740, 2688, 44, ""),
				}),
				new("Lamp Post", typeof(LampPost1), 2848, "", new DecorationEntry[]
				{
					new(3599, 2592, 0, ""),
					new(3611, 2582, 0, ""),
					new(3614, 2480, 0, ""),
					new(3614, 2593, 0, ""),
					new(3614, 2605, 0, ""),
					new(3614, 2617, 0, ""),
					new(3614, 2624, 0, ""),
					new(3615, 2520, 0, ""),
					new(3616, 2504, 0, ""),
					new(3625, 2489, 0, ""),
					new(3625, 2510, 0, ""),
					new(3625, 2593, 0, ""),
					new(3627, 2582, 0, ""),
					new(3632, 2536, 0, ""),
					new(3632, 2615, 0, ""),
					new(3645, 2478, 0, ""),
					new(3646, 2521, 0, ""),
					new(3646, 2534, 0, ""),
					new(3646, 2545, 0, ""),
					new(3646, 2582, 0, ""),
					new(3646, 2607, 0, ""),
					new(3646, 2614, 0, ""),
					new(3646, 2625, 0, ""),
					new(3651, 2510, 0, ""),
					new(3657, 2478, 0, ""),
					new(3657, 2521, 0, ""),
					new(3657, 2545, 0, ""),
					new(3657, 2598, 0, ""),
					new(3657, 2622, 0, ""),
					new(3657, 2633, 0, ""),
					new(3657, 2654, 0, ""),
					new(3658, 2563, 0, ""),
					new(3658, 2568, 0, ""),
					new(3669, 2478, 0, ""),
					new(3669, 2545, 0, ""),
					new(3672, 2510, 0, ""),
					new(3672, 2633, 0, ""),
					new(3678, 2489, 0, ""),
					new(3678, 2521, 0, ""),
					new(3689, 2480, 0, ""),
					new(3694, 2521, 0, ""),
					new(3711, 2592, 20, ""),
					new(3720, 2655, 20, ""),
					new(3735, 2640, 40, ""),
					new(3735, 2696, 40, ""),
					new(3743, 2568, 40, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(3614, 2510, 0, ""),
					new(3638, 2550, 0, ""),
					new(3656, 2528, 0, ""),
					new(3670, 2528, 0, ""),
					new(3670, 2608, 0, ""),
					new(3672, 2472, 0, ""),
					new(3672, 2542, 0, ""),
					new(3672, 2622, 0, ""),
					new(3677, 2542, 0, ""),
					new(3682, 2472, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2898, "", new DecorationEntry[]
				{
					new(3608, 2509, 0, ""),
					new(3625, 2531, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(3613, 2504, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2900, "", new DecorationEntry[]
				{
					new(3604, 2505, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2901, "", new DecorationEntry[]
				{
					new(3609, 2500, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(3672, 2473, 0, ""),
					new(3672, 2477, 0, ""),
					new(3673, 2532, 0, ""),
					new(3683, 2473, 0, ""),
					new(3683, 2475, 0, ""),
					new(3683, 2477, 0, ""),
					new(3685, 2473, 0, ""),
					new(3685, 2475, 0, ""),
					new(3685, 2477, 0, ""),
					new(3687, 2473, 0, ""),
					new(3687, 2475, 0, ""),
					new(3687, 2477, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(3602, 2572, 0, ""),
					new(3602, 2604, 0, ""),
					new(3613, 2470, 0, ""),
					new(3626, 2544, 0, ""),
					new(3627, 2529, 0, ""),
					new(3629, 2529, 0, ""),
					new(3631, 2529, 0, ""),
					new(3633, 2529, 0, ""),
					new(3634, 2636, 0, ""),
					new(3635, 2529, 0, ""),
					new(3642, 2500, 0, ""),
					new(3651, 2473, 0, ""),
					new(3663, 2506, 0, ""),
					new(3666, 2619, 0, ""),
					new(3674, 2472, 0, ""),
					new(3678, 2472, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(3625, 2606, 0, ""),
					new(3641, 2468, 0, ""),
					new(3665, 2586, 0, ""),
					new(3667, 2531, 0, ""),
					new(3676, 2532, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(3596, 2601, 0, ""),
					new(3626, 2546, 0, ""),
					new(3627, 2533, 0, ""),
					new(3629, 2533, 0, ""),
					new(3631, 2533, 0, ""),
					new(3633, 2533, 0, ""),
					new(3635, 2497, 0, ""),
					new(3635, 2533, 0, ""),
					new(3651, 2476, 0, ""),
					new(3663, 2509, 0, ""),
					new(3668, 2497, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2906, "", new DecorationEntry[]
				{
					new(3609, 2475, 0, ""),
					new(3609, 2476, 0, ""),
					new(3640, 2595, 0, ""),
					new(3665, 2530, 0, ""),
					new(3665, 2532, 0, ""),
					new(3673, 2534, 0, ""),
					new(3673, 2536, 0, ""),
					new(3673, 2538, 0, ""),
					new(3673, 2540, 0, ""),
					new(3713, 2649, 20, ""),
				}),
				new("Chair", typeof(BambooChair), 2907, "", new DecorationEntry[]
				{
					new(3739, 2687, 40, ""),
				}),
				new("Chair", typeof(BambooChair), 2908, "", new DecorationEntry[]
				{
					new(3666, 2621, 0, ""),
					new(3732, 2633, 40, ""),
					new(3739, 2690, 40, ""),
				}),
				new("Chair", typeof(BambooChair), 2909, "", new DecorationEntry[]
				{
					new(3609, 2466, 0, ""),
					new(3612, 2475, 0, ""),
					new(3612, 2476, 0, ""),
					new(3676, 2534, 0, ""),
					new(3676, 2536, 0, ""),
					new(3676, 2538, 0, ""),
					new(3676, 2540, 0, ""),
					new(3705, 2588, 20, ""),
					new(3737, 2564, 40, ""),
				}),
				new("Wooden Signpost", typeof(Static), 2968, "", new DecorationEntry[]
				{
					new(3666, 2512, 0, ""),
				}),
				new("Brass Sign", typeof(LocalizedSign), 3026, "LabelNumber=1023026", new DecorationEntry[]
				{
					new(3666, 2512, 0, ""),
				}),
				new("Small Fish", typeof(Static), 3542, "", new DecorationEntry[]
				{
					new(3648, 2668, -3, ""),
					new(3661, 2671, -3, ""),
					new(3669, 2659, -3, ""),
				}),
				new("Small Fish", typeof(Static), 3543, "", new DecorationEntry[]
				{
					new(3660, 2661, -3, ""),
					new(3662, 2670, -3, ""),
				}),
				new("Small Fish", typeof(Static), 3544, "", new DecorationEntry[]
				{
					new(3662, 2666, -3, ""),
					new(3666, 2660, -3, ""),
				}),
				new("Small Fish", typeof(Static), 3545, "", new DecorationEntry[]
				{
					new(3646, 2669, -3, ""),
					new(3663, 2672, -3, ""),
					new(3667, 2664, -3, ""),
				}),
				new("Knitting", typeof(Static), 3575, "", new DecorationEntry[]
				{
					new(3669, 2590, 6, ""),
				}),
				new("Pile Of Wool", typeof(Static), 3576, "", new DecorationEntry[]
				{
					new(3669, 2581, 0, ""),
				}),
				new("Bale Of Cotton", typeof(Static), 3577, "", new DecorationEntry[]
				{
					new(3664, 2581, 0, ""),
				}),
				new("Chessmen", typeof(Static), 3603, "", new DecorationEntry[]
				{
					new(3672, 2648, 4, ""),
				}),
				new("Chessmen", typeof(Static), 3604, "", new DecorationEntry[]
				{
					new(3672, 2648, 4, ""),
				}),
				new("Bloody Water", typeof(Static), 3619, "", new DecorationEntry[]
				{
					new(3625, 2603, 0, ""),
					new(3628, 2601, 0, ""),
					new(3629, 2609, 0, ""),
				}),
				new("Crystal Ball", typeof(Static), 3631, "Light=Circle150", new DecorationEntry[]
				{
					new(3626, 2545, 6, ""),
				}),
				new("Brazier", typeof(Brazier), 3633, "", new DecorationEntry[]
				{
					new(3624, 2536, 0, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3645, "", new DecorationEntry[]
				{
					new(3637, 2577, 0, ""),
					new(3637, 2577, 3, ""),
					new(3637, 2578, 0, ""),
					new(3637, 2578, 3, ""),
					new(3638, 2576, 0, ""),
					new(3638, 2576, 3, ""),
					new(3638, 2577, 0, ""),
					new(3638, 2577, 3, ""),
					new(3638, 2577, 6, ""),
					new(3638, 2578, 0, ""),
					new(3638, 2578, 3, ""),
					new(3638, 2578, 6, ""),
					new(3638, 2579, 0, ""),
					new(3638, 2579, 3, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(3633, 2568, 0, ""),
					new(3633, 2568, 3, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(3688, 2505, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(3744, 2681, 40, ""),
				}),
				new("Wooden Chest", typeof(FillableWoodenChest), 3650, "", new DecorationEntry[]
				{
					new(3674, 2611, 0, ""),
					new(3674, 2622, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(3690, 2506, 0, ""),
				}),
				new("Wooden Chest", typeof(FillableWoodenChest), 3651, "", new DecorationEntry[]
				{
					new(3665, 2608, 0, ""),
					new(3665, 2613, 0, ""),
					new(3678, 2613, 0, ""),
					new(3709, 2584, 20, ""),
					new(3730, 2632, 40, ""),
					new(3737, 2561, 40, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(3616, 2652, -3, ""),
					new(3616, 2653, -3, ""),
					new(3616, 2653, 2, ""),
					new(3616, 2654, -3, ""),
					new(3616, 2654, 2, ""),
					new(3629, 2574, 0, ""),
					new(3629, 2574, 5, ""),
					new(3630, 2574, 0, ""),
					new(3630, 2574, 5, ""),
					new(3631, 2574, 0, ""),
					new(3631, 2574, 5, ""),
					new(3632, 2574, 0, ""),
					new(3632, 2574, 5, ""),
					new(3632, 2575, 0, ""),
					new(3632, 2575, 5, ""),
					new(3644, 2649, -3, ""),
					new(3644, 2649, 2, ""),
					new(3645, 2649, -3, ""),
					new(3645, 2649, 2, ""),
					new(3645, 2650, -3, ""),
					new(3645, 2650, 2, ""),
					new(3646, 2662, -3, ""),
					new(3646, 2662, 2, ""),
					new(3646, 2663, -3, ""),
					new(3646, 2663, 2, ""),
					new(3647, 2662, -3, ""),
					new(3647, 2662, 2, ""),
					new(3647, 2679, -3, ""),
					new(3647, 2679, 2, ""),
					new(3647, 2680, -3, ""),
					new(3647, 2680, 2, ""),
					new(3648, 2680, -3, ""),
					new(3648, 2680, 2, ""),
					new(3651, 2654, 0, ""),
					new(3651, 2654, 5, ""),
					new(3651, 2655, 0, ""),
					new(3651, 2655, 5, ""),
					new(3652, 2654, 0, ""),
					new(3652, 2654, 5, ""),
					new(3652, 2655, 0, ""),
					new(3652, 2655, 5, ""),
					new(3658, 2665, -3, ""),
					new(3658, 2665, 2, ""),
					new(3659, 2665, -3, ""),
					new(3659, 2665, 2, ""),
					new(3659, 2666, -3, ""),
					new(3659, 2666, 2, ""),
					new(3661, 2673, -3, ""),
					new(3661, 2673, 2, ""),
					new(3664, 2648, 0, ""),
					new(3664, 2648, 5, ""),
					new(3664, 2648, 10, ""),
					new(3664, 2649, 0, ""),
					new(3664, 2649, 5, ""),
					new(3665, 2648, 0, ""),
					new(3665, 2648, 5, ""),
					new(3668, 2662, -3, ""),
					new(3668, 2662, 2, ""),
					new(3668, 2663, -3, ""),
					new(3668, 2663, 2, ""),
					new(3669, 2662, -3, ""),
					new(3669, 2662, 2, ""),
					new(3669, 2663, -3, ""),
					new(3669, 2663, 2, ""),
				}),
				new("Strong Box", typeof(FillableMetalBox), 3712, "", new DecorationEntry[]
				{
					new(3600, 2573, 6, ""),
					new(3600, 2605, 6, ""),
					new(3624, 2545, 6, ""),
					new(3640, 2501, 6, ""),
				}),
				new("Drum", typeof(Static), 3740, "", new DecorationEntry[]
				{
					new(3674, 2534, 4, ""),
					new(3675, 2540, 4, ""),
					new(3691, 2475, 0, ""),
				}),
				new("Tambourine", typeof(Static), 3741, "", new DecorationEntry[]
				{
					new(3674, 2540, 4, ""),
					new(3675, 2536, 4, ""),
				}),
				new("Tambourine", typeof(Static), 3742, "", new DecorationEntry[]
				{
					new(3674, 2536, 4, ""),
					new(3675, 2538, 4, ""),
					new(3691, 2477, 0, ""),
				}),
				new("Standing Harp", typeof(Static), 3761, "", new DecorationEntry[]
				{
					new(3663, 2528, 0, ""),
					new(3664, 2528, 0, ""),
					new(3665, 2528, 0, ""),
					new(3673, 2528, 0, ""),
					new(3676, 2528, 0, ""),
					new(3693, 2472, 2, ""),
					new(3693, 2476, 2, ""),
				}),
				new("Lute", typeof(Static), 3763, "", new DecorationEntry[]
				{
					new(3674, 2538, 4, ""),
					new(3675, 2534, 4, ""),
				}),
				new("Lute", typeof(Static), 3764, "", new DecorationEntry[]
				{
					new(3688, 2474, 0, ""),
				}),
				new("Music Stand", typeof(Static), 3766, "", new DecorationEntry[]
				{
					new(3659, 2528, 0, ""),
					new(3660, 2528, 0, ""),
					new(3661, 2528, 0, ""),
					new(3662, 2528, 0, ""),
				}),
				new("Music Stand", typeof(Static), 3771, "", new DecorationEntry[]
				{
					new(3666, 2528, 0, ""),
					new(3667, 2528, 0, ""),
					new(3668, 2528, 0, ""),
					new(3669, 2528, 0, ""),
					new(3674, 2528, 0, ""),
					new(3675, 2528, 0, ""),
				}),
				new("Music Stand", typeof(Static), 3772, "", new DecorationEntry[]
				{
					new(3690, 2473, 1, ""),
					new(3690, 2475, 1, ""),
					new(3690, 2477, 1, ""),
					new(3692, 2473, 1, ""),
					new(3692, 2477, 1, ""),
				}),
				new("Sheet Music", typeof(Static), 3775, "", new DecorationEntry[]
				{
					new(3674, 2528, 0, ""),
					new(3675, 2528, 0, ""),
				}),
				new("Sheet Music", typeof(Static), 3776, "", new DecorationEntry[]
				{
					new(3690, 2473, 1, ""),
					new(3690, 2475, 1, ""),
					new(3690, 2477, 1, ""),
					new(3692, 2473, 1, ""),
					new(3692, 2477, 1, ""),
				}),
				new("Cleaver", typeof(Static), 3778, "", new DecorationEntry[]
				{
					new(3704, 2649, 26, ""),
				}),
				new("Dress Form", typeof(Static), 3782, "", new DecorationEntry[]
				{
					new(3664, 2592, 0, ""),
					new(3666, 2580, 0, ""),
				}),
				new("Dress Form", typeof(Static), 3783, "", new DecorationEntry[]
				{
					new(3669, 2579, 0, ""),
				}),
				new("Easel With Canvas", typeof(Static), 3942, "", new DecorationEntry[]
				{
					new(3642, 2496, 0, ""),
				}),
				new("Easel", typeof(Static), 3943, "", new DecorationEntry[]
				{
					new(3640, 2510, 0, ""),
				}),
				new("Easel With Canvas", typeof(Static), 3944, "", new DecorationEntry[]
				{
					new(3640, 2508, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3990, "Hue=0x12", new DecorationEntry[]
				{
					new(3668, 2577, 0, ""),
					new(3668, 2591, 0, ""),
					new(3669, 2591, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3991, "Hue=0x26", new DecorationEntry[]
				{
					new(3668, 2577, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3992, "Hue=0x26", new DecorationEntry[]
				{
					new(3665, 2579, 0, ""),
					new(3665, 2594, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3993, "Hue=0x1D", new DecorationEntry[]
				{
					new(3665, 2579, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3994, "Hue=0x21", new DecorationEntry[]
				{
					new(3665, 2578, 0, ""),
					new(3665, 2595, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3995, "Hue=0x21", new DecorationEntry[]
				{
					new(3669, 2577, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3996, "Hue=0x26", new DecorationEntry[]
				{
					new(3669, 2577, 0, ""),
				}),
				new("Sewing Kit", typeof(Static), 3997, "", new DecorationEntry[]
				{
					new(3667, 2590, 6, ""),
				}),
				new("Scissors", typeof(Scissors), 3998, "", new DecorationEntry[]
				{
					new(3668, 2590, 6, ""),
				}),
				new("Scissors", typeof(Scissors), 3999, "", new DecorationEntry[]
				{
					new(3664, 2596, 6, ""),
				}),
				new("Playing Cards", typeof(Static), 4003, "", new DecorationEntry[]
				{
					new(3676, 2652, 4, ""),
				}),
				new("Chess Board", typeof(Chessboard), 4006, "", new DecorationEntry[]
				{
					new(3672, 2649, 4, ""),
				}),
				new("Dice And Cup", typeof(Dice), 4007, "", new DecorationEntry[]
				{
					new(3676, 2650, 4, ""),
				}),
				new("Dying Tub", typeof(DyeTub), 4011, "", new DecorationEntry[]
				{
					new(3642, 2600, 0, ""),
				}),
				new("Fire Pit", typeof(Static), 4012, "Light=Circle225", new DecorationEntry[]
				{
					new(3704, 2596, 20, ""),
					new(3735, 2645, 40, ""),
					new(3736, 2572, 40, ""),
				}),
				new("Backgammon Game", typeof(Backgammon), 4013, "", new DecorationEntry[]
				{
					new(3676, 2650, 4, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(3616, 2651, -3, ""),
					new(3632, 2649, -3, ""),
					new(3645, 2674, -3, ""),
					new(3661, 2672, -3, ""),
					new(3671, 2665, -3, ""),
				}),
				new("Anvil", typeof(AnvilSouthAddon), 4016, "", new DecorationEntry[]
				{
					new(3643, 2603, 0, ""),
				}),
				new("Forge", typeof(SmallForgeAddon), 4017, "", new DecorationEntry[]
				{
					new(3645, 2603, 0, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4020, "", new DecorationEntry[]
				{
					new(3643, 2604, 0, ""),
				}),
				new("Horse Shoes", typeof(Static), 4022, "", new DecorationEntry[]
				{
					new(3641, 2601, 4, ""),
				}),
				new("Tongs", typeof(Static), 4027, "", new DecorationEntry[]
				{
					new(3641, 2603, 4, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(3608, 2500, 4, ""),
					new(3624, 2606, 4, ""),
					new(3626, 2531, 4, ""),
					new(3640, 2468, 4, ""),
					new(3641, 2595, 6, ""),
					new(3664, 2586, 6, ""),
					new(3666, 2531, 4, ""),
					new(3675, 2532, 4, ""),
					new(3714, 2649, 26, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(3602, 2573, 6, ""),
					new(3602, 2605, 6, ""),
					new(3604, 2504, 4, ""),
					new(3613, 2471, 4, ""),
					new(3625, 2545, 6, ""),
					new(3634, 2571, 6, ""),
					new(3642, 2501, 6, ""),
					new(3666, 2620, 4, ""),
					new(3668, 2496, 4, ""),
					new(3676, 2472, 4, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(3608, 2500, 4, ""),
					new(3624, 2606, 4, ""),
					new(3626, 2531, 4, ""),
					new(3640, 2468, 4, ""),
					new(3641, 2595, 6, ""),
					new(3664, 2586, 6, ""),
					new(3666, 2531, 4, ""),
					new(3675, 2532, 4, ""),
					new(3714, 2649, 26, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(3602, 2573, 6, ""),
					new(3602, 2605, 6, ""),
					new(3604, 2504, 4, ""),
					new(3613, 2471, 4, ""),
					new(3625, 2545, 6, ""),
					new(3634, 2571, 6, ""),
					new(3642, 2501, 6, ""),
					new(3666, 2620, 4, ""),
					new(3668, 2496, 4, ""),
				}),
				new("Paints And Brush", typeof(Static), 4033, "", new DecorationEntry[]
				{
					new(3642, 2497, 0, ""),
				}),
				new("Book", typeof(CallToAnarchy), 4079, "", new DecorationEntry[]
				{
					new(3610, 2476, 4, ""),
				}),
				new("Book", typeof(GrammarOfOrcish), 4079, "", new DecorationEntry[]
				{
					new(3672, 2474, 4, ""),
				}),
				new("Book", typeof(RedBook), 4081, "", new DecorationEntry[]
				{
					new(3677, 2472, 4, ""),
				}),
				new("Book", typeof(BlueBook), 4082, "", new DecorationEntry[]
				{
					new(3610, 2474, 4, ""),
				}),
				new("Book", typeof(BritannianFlora), 4083, "", new DecorationEntry[]
				{
					new(3611, 2476, 4, ""),
				}),
				new("Book", typeof(BirdsOfBritannia), 4084, "", new DecorationEntry[]
				{
					new(3611, 2475, 4, ""),
				}),
				new("Book", typeof(TreatiseOnAlchemy), 4084, "", new DecorationEntry[]
				{
					new(3672, 2475, 4, ""),
				}),
				new("Spinning Wheel", typeof(Static), 4121, "", new DecorationEntry[]
				{
					new(3667, 2597, 0, ""),
				}),
				new("Pile Of Wool", typeof(Static), 4127, "", new DecorationEntry[]
				{
					new(3667, 2578, 0, ""),
				}),
				new("Sack Of Flour", typeof(Static), 4153, "", new DecorationEntry[]
				{
					new(3608, 2570, 0, ""),
					new(3621, 2568, 0, ""),
					new(3621, 2569, 0, ""),
				}),
				new("Open Sack Of Flour", typeof(Static), 4154, "", new DecorationEntry[]
				{
					new(3613, 2572, 0, ""),
					new(3614, 2573, 0, ""),
					new(3619, 2568, 6, ""),
					new(3740, 2682, 40, ""),
				}),
				new("Dough", typeof(Static), 4157, "", new DecorationEntry[]
				{
					new(3616, 2568, 6, ""),
				}),
				new("Cookie Mix", typeof(Static), 4159, "", new DecorationEntry[]
				{
					new(3611, 2568, 6, ""),
					new(3618, 2569, 6, ""),
				}),
				new("Rolling Pin", typeof(Static), 4163, "", new DecorationEntry[]
				{
					new(3610, 2568, 6, ""),
					new(3618, 2568, 6, ""),
				}),
				new("Loom Bench", typeof(Static), 4170, "", new DecorationEntry[]
				{
					new(3668, 2594, 0, ""),
				}),
				new("Upright Loom", typeof(LoomSouthAddon), 4193, "", new DecorationEntry[]
				{
					new(3668, 2594, 0, ""),
				}),
				new("Cut Leather", typeof(Static), 4200, "", new DecorationEntry[]
				{
					new(3605, 2619, 6, ""),
				}),
				new("Stretched Hide", typeof(Static), 4202, "", new DecorationEntry[]
				{
					new(3601, 2612, 0, ""),
				}),
				new("Stretched Hide", typeof(Static), 4203, "", new DecorationEntry[]
				{
					new(3601, 2614, 0, ""),
				}),
				new("Pile Of Hides", typeof(Static), 4216, "", new DecorationEntry[]
				{
					new(3605, 2617, 0, ""),
					new(3606, 2601, 0, ""),
				}),
				new("Pile Of Hides", typeof(Static), 4217, "", new DecorationEntry[]
				{
					new(3601, 2601, 0, ""),
					new(3603, 2621, 0, ""),
				}),
				new("Cut Leather", typeof(Static), 4225, "", new DecorationEntry[]
				{
					new(3603, 2600, 6, ""),
					new(3604, 2619, 6, ""),
				}),
				new("Cut Leather", typeof(Static), 4226, "", new DecorationEntry[]
				{
					new(3604, 2600, 6, ""),
				}),
				new("Garbage", typeof(Static), 4334, "", new DecorationEntry[]
				{
					new(3703, 2597, 20, ""),
					new(3706, 2596, 20, ""),
				}),
				new("Potted Tree", typeof(PottedTree), 4552, "", new DecorationEntry[]
				{
					new(3637, 2496, 0, ""),
					new(3641, 2592, 0, ""),
					new(3665, 2496, 0, ""),
					new(3736, 2687, 40, ""),
				}),
				new("Potted Tree", typeof(PottedTree1), 4553, "", new DecorationEntry[]
				{
					new(3600, 2568, 0, ""),
					new(3608, 2504, 0, ""),
					new(3633, 2496, 0, ""),
					new(3640, 2465, 0, ""),
					new(3656, 2589, 0, ""),
					new(3704, 2584, 20, ""),
				}),
				new("Flowerpot", typeof(PottedPlant), 4554, "", new DecorationEntry[]
				{
					new(3600, 2504, 0, ""),
					new(3632, 2544, 0, ""),
					new(3632, 2601, 0, ""),
					new(3637, 2561, 0, ""),
					new(3640, 2496, 0, ""),
					new(3673, 2472, 0, ""),
					new(3679, 2472, 0, ""),
					new(3728, 2632, 40, ""),
				}),
				new("Flowerpot", typeof(PottedPlant1), 4555, "", new DecorationEntry[]
				{
					new(3608, 2501, 7, ""),
					new(3632, 2569, 9, ""),
					new(3667, 2620, 7, ""),
				}),
				new("Flowerpot", typeof(PottedPlant2), 4556, "", new DecorationEntry[]
				{
					new(3636, 2571, 9, ""),
					new(3644, 2501, 9, ""),
				}),
				new("Fur", typeof(Static), 4596, "", new DecorationEntry[]
				{
					new(3604, 2615, 6, ""),
				}),
				new("Fur", typeof(Static), 4597, "", new DecorationEntry[]
				{
					new(3606, 2615, 6, ""),
				}),
				new("Fur", typeof(Static), 4598, "", new DecorationEntry[]
				{
					new(3604, 2609, 6, ""),
				}),
				new("Fur", typeof(Static), 4599, "", new DecorationEntry[]
				{
					new(3606, 2609, 6, ""),
				}),
				new("Fur", typeof(Static), 4600, "", new DecorationEntry[]
				{
					new(3600, 2613, 6, ""),
				}),
				new("Fur", typeof(Static), 4601, "", new DecorationEntry[]
				{
					new(3600, 2618, 6, ""),
				}),
				new("Fur", typeof(Static), 4602, "", new DecorationEntry[]
				{
					new(3600, 2611, 6, ""),
				}),
				new("Fur", typeof(Static), 4603, "", new DecorationEntry[]
				{
					new(3600, 2620, 6, ""),
				}),
				new("Tarot", typeof(Static), 4773, "", new DecorationEntry[]
				{
					new(3627, 2545, 6, ""),
				}),
				new("Moulding Board", typeof(Static), 5353, "", new DecorationEntry[]
				{
					new(3617, 2569, 6, ""),
				}),
				new("Moulding Board", typeof(Static), 5354, "", new DecorationEntry[]
				{
					new(3611, 2569, 7, ""),
				}),
				new("Ship Model", typeof(Static), 5363, "", new DecorationEntry[]
				{
					new(3635, 2637, 6, ""),
				}),
				new("Rope", typeof(Static), 5368, "", new DecorationEntry[]
				{
					new(3632, 2632, 0, ""),
					new(3647, 2669, -3, ""),
					new(3660, 2677, -3, ""),
				}),
				new("Rope", typeof(Static), 5370, "", new DecorationEntry[]
				{
					new(3669, 2660, -3, ""),
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
					new(3613, 2573, 0, ""),
				}),
				new("Bowl Of Carrots", typeof(Static), 5625, "", new DecorationEntry[]
				{
					new(3736, 2681, 46, ""),
				}),
				new("Pewter Bowl", typeof(Static), 5629, "", new DecorationEntry[]
				{
					new(3654, 2465, 6, ""),
				}),
				new("Bowl Of Lettuce", typeof(Static), 5632, "", new DecorationEntry[]
				{
					new(3736, 2682, 46, ""),
				}),
				new("Large Pewter Bowl", typeof(Static), 5635, "", new DecorationEntry[]
				{
					new(3654, 2467, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5983, "Hue=0x6C5", new DecorationEntry[]
				{
					new(3664, 2576, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5985, "Hue=0x4BD", new DecorationEntry[]
				{
					new(3667, 2576, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5986, "Hue=0x21", new DecorationEntry[]
				{
					new(3664, 2580, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5986, "Hue=0x72B", new DecorationEntry[]
				{
					new(3666, 2576, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5987, "Hue=0x522", new DecorationEntry[]
				{
					new(3668, 2576, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5987, "Hue=0x5F6", new DecorationEntry[]
				{
					new(3664, 2579, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5988, "Hue=0x58A", new DecorationEntry[]
				{
					new(3669, 2576, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5988, "Hue=0x64D", new DecorationEntry[]
				{
					new(3664, 2577, 6, ""),
				}),
				new("Rock", typeof(Static), 6008, "", new DecorationEntry[]
				{
					new(3767, 2718, 21, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6232, "", new DecorationEntry[]
				{
					new(3628, 2531, 4, ""),
					new(3628, 2545, 6, ""),
					new(3631, 2531, 4, ""),
					new(3634, 2531, 4, ""),
				}),
				new("Silver Wire", typeof(Static), 6263, "", new DecorationEntry[]
				{
					new(3641, 2602, 4, ""),
				}),
				new("Spilled Flour", typeof(Static), 6270, "", new DecorationEntry[]
				{
					new(3615, 2574, 0, ""),
				}),
				new("Spilled Flour", typeof(Static), 6271, "", new DecorationEntry[]
				{
					new(3610, 2572, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
