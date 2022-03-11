using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Minoc { get; } = Register(DecorationTarget.Britannia, "Minoc", new DecorationList[]
			{
				#region Entries
				
				new("Window", typeof(Static), 35, "", new DecorationEntry[]
				{
					new(2511, 522, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 37, "", new DecorationEntry[]
				{
					new(2505, 434, 35, ""),
				}),
				new("Log Wall", typeof(Static), 145, "", new DecorationEntry[]
				{
					new(2592, 610, 0, ""),
					new(2577, 588, 0, ""),
				}),
				new("Slate Roof", typeof(Static), 1407, "", new DecorationEntry[]
				{
					new(2499, 434, 35, ""),
					new(2510, 433, 35, ""),
				}),
				new("Slate Roof", typeof(Static), 1409, "", new DecorationEntry[]
				{
					new(2505, 433, 35, ""),
				}),
				new("Slate Roof", typeof(Static), 1411, "", new DecorationEntry[]
				{
					new(2498, 438, 35, ""),
				}),
				new("Slate Roof", typeof(Static), 1412, "", new DecorationEntry[]
				{
					new(2509, 433, 35, ""),
					new(2500, 435, 35, ""),
				}),
				new("Thatch Roof", typeof(Static), 1446, "", new DecorationEntry[]
				{
					new(2530, 584, 20, ""),
					new(2529, 560, 23, ""),
				}),
				new("Oven", typeof(StoneOvenSouthAddon), 2352, "", new DecorationEntry[]
				{
					new(2458, 397, 15, ""),
					new(2491, 472, 15, ""),
				}),
				new("Fireplace", typeof(StoneFireplaceSouthAddon), 2401, "", new DecorationEntry[]
				{
					new(2508, 544, 0, ""),
					new(2460, 397, 15, ""),
					new(2437, 435, 15, ""),
				}),
				new("Cauldron", typeof(Static), 2421, "", new DecorationEntry[]
				{
					new(2564, 677, 0, ""),
				}),
				new("Tray", typeof(Static), 2449, "", new DecorationEntry[]
				{
					new(2494, 474, 21, ""),
				}),
				new("Tray", typeof(Static), 2450, "", new DecorationEntry[]
				{
					new(2439, 435, 21, ""),
				}),
				new("Bottle Of Ale", typeof(BeverageBottle), 2463, "Content=Ale", new DecorationEntry[]
				{
					new(2548, 652, 5, ""),
					new(2549, 656, 5, ""),
					new(2549, 654, 5, ""),
					new(2479, 401, 19, ""),
					new(2483, 407, 19, ""),
					new(2500, 383, 4, ""),
					new(2517, 652, 5, ""),
					new(2517, 656, 5, ""),
					new(2532, 578, 6, ""),
					new(2468, 399, 19, ""),
					new(2454, 432, 21, ""),
					new(2480, 597, 6, ""),
					new(2484, 407, 19, ""),
					new(2485, 397, 19, ""),
					new(2421, 494, 21, ""),
					new(2421, 468, 21, ""),
					new(2468, 405, 19, ""),
					new(2491, 400, 19, ""),
					new(2486, 400, 19, ""),
					new(2593, 640, 6, ""),
					new(2480, 400, 19, ""),
					new(2468, 409, 19, ""),
					new(2417, 484, 21, ""),
					new(2593, 612, 6, ""),
					new(2522, 544, 6, ""),
					new(2493, 597, 6, ""),
					new(2598, 623, 6, ""),
					new(2508, 593, 6, ""),
					new(2450, 455, 21, ""),
					new(2516, 656, 5, ""),
					new(2474, 398, 19, ""),
					new(2491, 399, 19, ""),
					new(2473, 397, 19, ""),
					new(2486, 476, 19, ""),
					new(2618, 615, 6, ""),
					new(2467, 398, 19, ""),
					new(2501, 380, 4, ""),
				}),
				new("Fork", typeof(Fork), 2467, "", new DecorationEntry[]
				{
					new(2485, 400, 19, ""),
					new(2479, 397, 19, ""),
					new(2548, 654, 5, ""),
					new(2483, 408, 19, ""),
					new(2491, 397, 19, ""),
					new(2467, 406, 19, ""),
					new(2473, 400, 19, ""),
					new(2485, 399, 19, ""),
					new(2548, 656, 5, ""),
					new(2500, 382, 4, ""),
				}),
				new("Fork", typeof(Fork), 2468, "", new DecorationEntry[]
				{
					new(2487, 475, 19, ""),
				}),
				new("Knife", typeof(Knife), 2469, "", new DecorationEntry[]
				{
					new(2473, 400, 19, ""),
					new(2491, 397, 19, ""),
					new(2500, 382, 4, ""),
					new(2548, 654, 5, ""),
					new(2548, 656, 5, ""),
					new(2467, 406, 19, ""),
					new(2483, 408, 19, ""),
					new(2485, 400, 19, ""),
					new(2479, 397, 19, ""),
					new(2485, 399, 19, ""),
				}),
				new("Knife", typeof(Knife), 2470, "", new DecorationEntry[]
				{
					new(2487, 475, 19, ""),
				}),
				new("Metal Box", typeof(FillableMetalBox), 2472, "", new DecorationEntry[]
				{
					new(2580, 595, 6, ""),
					new(2452, 429, 21, ""),
					new(2528, 549, 6, ""),
					new(2462, 450, 21, ""),
					new(2437, 408, 21, ""),
					new(2520, 521, 6, ""),
				}),
				new("Bushel", typeof(Basket), 2476, "", new DecorationEntry[]
				{
					new(2492, 475, 15, ""),
				}),
				new("Spoon", typeof(Spoon), 2498, "", new DecorationEntry[]
				{
					new(2479, 397, 19, ""),
					new(2483, 408, 19, ""),
					new(2548, 654, 5, ""),
					new(2548, 656, 5, ""),
					new(2473, 400, 19, ""),
					new(2500, 382, 4, ""),
					new(2485, 400, 19, ""),
					new(2491, 397, 19, ""),
					new(2467, 406, 19, ""),
					new(2485, 399, 19, ""),
				}),
				new("Spoon", typeof(Spoon), 2499, "", new DecorationEntry[]
				{
					new(2487, 475, 19, ""),
				}),
				new("Ham", typeof(Static), 2515, "", new DecorationEntry[]
				{
					new(2432, 409, 21, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(2417, 483, 21, ""),
					new(2468, 407, 19, ""),
					new(2549, 652, 5, ""),
					new(2480, 596, 6, ""),
					new(2422, 494, 21, ""),
					new(2593, 639, 6, ""),
					new(2491, 397, 19, ""),
					new(2467, 406, 19, ""),
					new(2420, 468, 21, ""),
					new(2501, 383, 4, ""),
					new(2619, 615, 6, ""),
					new(2468, 397, 19, ""),
					new(2493, 596, 6, ""),
					new(2468, 401, 19, ""),
					new(2548, 656, 5, ""),
					new(2599, 623, 6, ""),
					new(2484, 406, 19, ""),
					new(2483, 408, 19, ""),
					new(2487, 475, 19, ""),
					new(2487, 476, 19, ""),
					new(2479, 397, 19, ""),
					new(2453, 432, 21, ""),
					new(2474, 400, 19, ""),
					new(2485, 399, 19, ""),
					new(2473, 400, 19, ""),
					new(2501, 381, 4, ""),
					new(2480, 398, 19, ""),
					new(2531, 578, 6, ""),
					new(2492, 400, 19, ""),
					new(2450, 454, 21, ""),
					new(2593, 613, 6, ""),
					new(2485, 400, 19, ""),
					new(2521, 544, 6, ""),
					new(2509, 593, 6, ""),
					new(2500, 382, 4, ""),
				}),
				new("Frypan", typeof(Static), 2530, "", new DecorationEntry[]
				{
					new(2437, 436, 15, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(2441, 437, 21, ""),
					new(2494, 472, 21, ""),
				}),
				new("Fork", typeof(Fork), 2548, "", new DecorationEntry[]
				{
					new(2420, 468, 21, ""),
					new(2531, 578, 6, ""),
					new(2599, 623, 6, ""),
					new(2619, 615, 6, ""),
					new(2521, 544, 6, ""),
					new(2509, 593, 6, ""),
					new(2453, 432, 21, ""),
					new(2422, 494, 21, ""),
					new(2487, 476, 19, ""),
				}),
				new("Fork", typeof(Fork), 2549, "", new DecorationEntry[]
				{
					new(2549, 652, 5, ""),
					new(2480, 398, 19, ""),
					new(2417, 483, 21, ""),
					new(2480, 596, 6, ""),
					new(2493, 596, 6, ""),
					new(2492, 400, 19, ""),
					new(2593, 613, 6, ""),
					new(2468, 407, 19, ""),
					new(2484, 406, 19, ""),
					new(2501, 381, 4, ""),
					new(2468, 401, 19, ""),
					new(2474, 400, 19, ""),
					new(2593, 639, 6, ""),
					new(2450, 454, 21, ""),
					new(2501, 383, 4, ""),
					new(2468, 397, 19, ""),
				}),
				new("Knife", typeof(Knife), 2550, "", new DecorationEntry[]
				{
					new(2509, 593, 6, ""),
					new(2420, 468, 21, ""),
					new(2453, 432, 21, ""),
					new(2531, 578, 6, ""),
					new(2521, 544, 6, ""),
					new(2619, 615, 6, ""),
					new(2599, 623, 6, ""),
					new(2487, 476, 19, ""),
					new(2422, 494, 21, ""),
				}),
				new("Knife", typeof(Knife), 2551, "", new DecorationEntry[]
				{
					new(2417, 483, 21, ""),
					new(2474, 400, 19, ""),
					new(2468, 397, 19, ""),
					new(2549, 652, 5, ""),
					new(2450, 454, 21, ""),
					new(2501, 381, 4, ""),
					new(2593, 639, 6, ""),
					new(2501, 383, 4, ""),
					new(2468, 407, 19, ""),
					new(2493, 596, 6, ""),
					new(2593, 613, 6, ""),
					new(2480, 398, 19, ""),
					new(2492, 400, 19, ""),
					new(2484, 406, 19, ""),
					new(2468, 401, 19, ""),
					new(2480, 596, 6, ""),
				}),
				new("Spoon", typeof(Spoon), 2552, "", new DecorationEntry[]
				{
					new(2599, 623, 6, ""),
					new(2619, 615, 6, ""),
					new(2487, 476, 19, ""),
					new(2453, 432, 21, ""),
					new(2531, 578, 6, ""),
					new(2521, 544, 6, ""),
					new(2509, 593, 6, ""),
					new(2422, 494, 21, ""),
					new(2420, 468, 21, ""),
				}),
				new("Spoon", typeof(Spoon), 2553, "", new DecorationEntry[]
				{
					new(2593, 639, 6, ""),
					new(2450, 454, 21, ""),
					new(2501, 383, 4, ""),
					new(2474, 400, 19, ""),
					new(2501, 381, 4, ""),
					new(2417, 483, 21, ""),
					new(2480, 398, 19, ""),
					new(2484, 406, 19, ""),
					new(2468, 397, 19, ""),
					new(2549, 652, 5, ""),
					new(2493, 596, 6, ""),
					new(2468, 401, 19, ""),
					new(2492, 400, 19, ""),
					new(2593, 613, 6, ""),
					new(2468, 407, 19, ""),
					new(2480, 596, 6, ""),
				}),
				new("Wall Torch", typeof(WallTorch), 2567, "Light=WestBig", new DecorationEntry[]
				{
					new(2426, 497, 29, ""),
					new(2424, 471, 29, ""),
					new(2603, 628, 14, ""),
				}),
				new("Wall Torch", typeof(WallTorch), 2572, "Light=NorthBig", new DecorationEntry[]
				{
					new(2598, 643, 15, ""),
					new(2620, 623, 14, ""),
				}),
				new("Bowl Of Flour", typeof(Static), 2590, "", new DecorationEntry[]
				{
					new(2435, 436, 15, ""),
				}),
				new("Lantern", typeof(Lantern), 2594, "", new DecorationEntry[]
				{
					new(2479, 405, 27, ""),
					new(2474, 405, 27, ""),
					new(2530, 658, 0, ""),
					new(2574, 603, 12, ""),
					new(2549, 657, 5, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(2616, 615, 0, ""),
					new(2596, 623, 0, ""),
					new(2492, 374, 0, ""),
					new(2508, 466, 15, ""),
					new(2496, 593, 0, ""),
					new(2417, 468, 15, ""),
					new(2482, 592, 0, ""),
					new(2419, 494, 15, ""),
					new(2502, 374, 0, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(2448, 434, 15, ""),
					new(2593, 636, 0, ""),
					new(2593, 610, 0, ""),
					new(2450, 451, 15, ""),
					new(2505, 595, 0, ""),
					new(2480, 469, 15, ""),
					new(2427, 429, 15, ""),
					new(2417, 480, 15, ""),
					new(2530, 581, 0, ""),
					new(2512, 522, 0, ""),
					new(2520, 547, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2639, "", new DecorationEntry[]
				{
					new(2494, 593, 0, ""),
					new(2514, 520, 0, ""),
					new(2452, 450, 15, ""),
					new(2494, 374, 0, ""),
					new(2595, 609, 0, ""),
					new(2595, 635, 0, ""),
					new(2500, 374, 0, ""),
					new(2419, 479, 15, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(2595, 625, 0, ""),
					new(2480, 467, 15, ""),
					new(2418, 496, 15, ""),
					new(2480, 593, 0, ""),
					new(2505, 594, 0, ""),
					new(2506, 468, 15, ""),
					new(2615, 617, 0, ""),
					new(2416, 470, 15, ""),
					new(2427, 431, 15, ""),
				}),
				new("Bedroll", typeof(Static), 2645, "", new DecorationEntry[]
				{
					new(2592, 523, 15, ""),
					new(2592, 525, 15, ""),
					new(2575, 535, 15, ""),
					new(2581, 518, 15, ""),
					new(2575, 531, 15, ""),
					new(2588, 538, 15, ""),
					new(2564, 526, 15, ""),
					new(2592, 521, 15, ""),
					new(2564, 522, 15, ""),
					new(2575, 533, 15, ""),
					new(2588, 536, 15, ""),
					new(2588, 534, 15, ""),
					new(2581, 520, 15, ""),
					new(2581, 522, 15, ""),
				}),
				new("Bedroll", typeof(Static), 2647, "", new DecorationEntry[]
				{
					new(2564, 524, 15, ""),
					new(2564, 526, 15, ""),
					new(2592, 525, 15, ""),
				}),
				new("Bedroll", typeof(Static), 2648, "", new DecorationEntry[]
				{
					new(2564, 526, 15, ""),
					new(2581, 522, 15, ""),
				}),
				new("Bed", typeof(Static), 2665, "", new DecorationEntry[]
				{
					new(2570, 595, 0, ""),
					new(2595, 627, 0, ""),
					new(2520, 549, 0, ""),
					new(2570, 591, 0, ""),
					new(2418, 498, 15, ""),
					new(2489, 376, 0, ""),
					new(2489, 378, 0, ""),
					new(2416, 472, 15, ""),
					new(2570, 593, 0, ""),
					new(2505, 597, 0, ""),
					new(2448, 436, 15, ""),
					new(2570, 589, 0, ""),
					new(2570, 599, 0, ""),
					new(2615, 619, 0, ""),
					new(2530, 583, 0, ""),
					new(2570, 597, 0, ""),
				}),
				new("Bed", typeof(Static), 2667, "", new DecorationEntry[]
				{
					new(2571, 591, 0, ""),
					new(2571, 589, 0, ""),
					new(2571, 593, 0, ""),
					new(2449, 436, 15, ""),
					new(2490, 376, 0, ""),
					new(2571, 595, 0, ""),
					new(2490, 378, 0, ""),
					new(2616, 619, 0, ""),
					new(2419, 498, 15, ""),
					new(2417, 472, 15, ""),
					new(2596, 627, 0, ""),
					new(2506, 597, 0, ""),
					new(2571, 597, 0, ""),
					new(2531, 583, 0, ""),
					new(2521, 549, 0, ""),
					new(2571, 599, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(2425, 552, 0, ""),
					new(2417, 520, 0, ""),
					new(2481, 472, 15, ""),
					new(2431, 528, 0, ""),
					new(2582, 595, 0, ""),
					new(2429, 435, 15, ""),
					new(2448, 483, 15, ""),
					new(2483, 592, 0, ""),
					new(2482, 472, 15, ""),
					new(2476, 424, 15, ""),
					new(2507, 471, 15, ""),
					new(2421, 528, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(2430, 528, 0, ""),
					new(2579, 595, 0, ""),
					new(2481, 592, 0, ""),
					new(2445, 483, 15, ""),
					new(2420, 528, 0, ""),
					new(2421, 520, 0, ""),
					new(2475, 424, 15, ""),
					new(2428, 435, 15, ""),
					new(2511, 471, 15, ""),
					new(2427, 552, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(2496, 434, 15, ""),
					new(2416, 522, 0, ""),
					new(2496, 429, 15, ""),
					new(2497, 381, 0, ""),
					new(2497, 387, 0, ""),
					new(2465, 560, 5, ""),
					new(2480, 473, 15, ""),
					new(2506, 472, 15, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(2497, 382, 0, ""),
					new(2496, 435, 15, ""),
					new(2465, 559, 5, ""),
					new(2497, 385, 0, ""),
					new(2416, 524, 0, ""),
					new(2496, 428, 15, ""),
					new(2480, 477, 15, ""),
					new(2443, 487, 15, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(2581, 595, 0, ""),
					new(2432, 528, 0, ""),
					new(2578, 595, 0, ""),
					new(2422, 528, 0, ""),
					new(2428, 552, 0, ""),
					new(2477, 424, 15, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2716, "", new DecorationEntry[]
				{
					new(2416, 525, 0, ""),
					new(2416, 521, 0, ""),
					new(2496, 430, 15, ""),
					new(2496, 433, 15, ""),
					new(2443, 486, 15, ""),
					new(2497, 384, 0, ""),
					new(2465, 558, 5, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(2462, 454, 21, ""),
					new(2511, 474, 21, ""),
					new(2520, 544, 6, ""),
					new(2446, 485, 19, ""),
					new(2454, 484, 19, ""),
					new(2520, 525, 6, ""),
					new(2427, 437, 19, ""),
					new(2450, 453, 21, ""),
					new(2501, 427, 19, ""),
					new(2528, 545, 6, ""),
					new(2530, 578, 6, ""),
					new(2500, 380, 4, ""),
					new(2452, 427, 21, ""),
					new(2480, 474, 19, ""),
					new(2452, 432, 21, ""),
					new(2531, 574, 6, ""),
					new(2505, 427, 19, ""),
					new(2454, 480, 19, ""),
					new(2441, 439, 21, ""),
					new(2488, 475, 19, ""),
					new(2437, 412, 21, ""),
				}),
				new("Candelabra", typeof(Candelabra), 2845, "", new DecorationEntry[]
				{
					new(2419, 522, 4, ""),
					new(2431, 523, 4, ""),
					new(2427, 554, 4, ""),
					new(2437, 523, 4, ""),
					new(2580, 599, 6, ""),
					new(2599, 609, 6, ""),
					new(2433, 528, 6, ""),
					new(2600, 623, 6, ""),
					new(2595, 629, 6, ""),
					new(2615, 621, 6, ""),
					new(2570, 587, 6, ""),
					new(2570, 601, 6, ""),
					new(2599, 635, 6, ""),
					new(2574, 592, 6, ""),
					new(2593, 614, 6, ""),
					new(2620, 615, 6, ""),
					new(2574, 596, 6, ""),
					new(2593, 638, 6, ""),
					new(2468, 563, 11, ""),
					new(2478, 567, 11, ""),
					new(2465, 553, 11, ""),
					new(2472, 563, 11, ""),
					new(2471, 553, 11, ""),
					new(2485, 399, 19, ""),
					new(2479, 399, 19, ""),
					new(2483, 407, 19, ""),
					new(2467, 407, 19, ""),
					new(2473, 399, 19, ""),
					new(2491, 399, 19, ""),
					new(2467, 399, 19, ""),
					new(2483, 428, 21, ""),
					new(2475, 426, 21, ""),
					new(2463, 397, 21, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(2486, 424, 15, ""),
					new(2422, 544, 2, ""),
					new(2457, 403, 15, ""),
					new(2429, 528, 0, ""),
					new(2486, 435, 15, ""),
					new(2422, 549, 0, ""),
					new(2481, 410, 15, ""),
					new(2423, 528, 0, ""),
					new(2465, 411, 15, ""),
					new(2495, 403, 15, ""),
					new(2416, 556, 0, ""),
					new(2416, 532, 0, ""),
					new(2416, 530, 0, ""),
					new(2416, 549, 0, ""),
					new(2480, 435, 15, ""),
					new(2478, 430, 15, ""),
					new(2416, 544, 2, ""),
					new(2478, 424, 15, ""),
				}),
				new("Wooden Bench", typeof(WoodenBench), 2861, "", new DecorationEntry[]
				{
					new(2418, 528, 0, ""),
					new(2426, 520, 0, ""),
					new(2427, 520, 0, ""),
					new(2425, 520, 0, ""),
					new(2424, 520, 0, ""),
				}),
				new("Counter", typeof(Static), 2878, "", new DecorationEntry[]
				{
					new(2510, 474, 15, ""),
					new(2509, 593, 0, ""),
					new(2508, 474, 15, ""),
					new(2516, 474, 15, ""),
					new(2599, 623, 0, ""),
					new(2560, 675, 0, ""),
					new(2619, 615, 0, ""),
					new(2516, 478, 15, ""),
					new(2461, 488, 15, ""),
					new(2561, 675, 0, ""),
					new(2420, 468, 15, ""),
					new(2422, 494, 15, ""),
					new(2463, 488, 15, ""),
					new(2521, 544, 0, ""),
					new(2518, 474, 15, ""),
					new(2461, 454, 15, ""),
					new(2531, 578, 0, ""),
					new(2518, 478, 15, ""),
					new(2463, 484, 15, ""),
					new(2453, 432, 15, ""),
					new(2461, 484, 15, ""),
					new(2471, 563, 5, ""),
					new(2469, 563, 5, ""),
					new(2440, 435, 15, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2898, "", new DecorationEntry[]
				{
					new(2418, 523, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(2434, 521, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(2531, 656, 1, ""),
					new(2451, 428, 15, ""),
					new(2498, 427, 15, ""),
					new(2474, 427, 15, ""),
					new(2445, 486, 15, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(2436, 521, 0, ""),
					new(2454, 477, 15, ""),
					new(2432, 521, 0, ""),
					new(2432, 437, 15, ""),
					new(2483, 425, 15, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(2481, 475, 15, ""),
					new(2420, 524, 0, ""),
					new(2420, 522, 0, ""),
					new(2581, 597, 0, ""),
					new(2434, 530, 0, ""),
					new(2428, 438, 15, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(2432, 440, 15, ""),
					new(2434, 525, 0, ""),
					new(2432, 525, 0, ""),
					new(2436, 525, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2906, "", new DecorationEntry[]
				{
					new(2452, 485, 15, ""),
					new(2515, 656, 1, ""),
					new(2515, 654, 1, ""),
					new(2515, 652, 1, ""),
					new(2461, 452, 15, ""),
					new(2547, 652, 1, ""),
					new(2547, 656, 1, ""),
					new(2547, 654, 1, ""),
					new(2481, 427, 15, ""),
					new(2481, 431, 15, ""),
					new(2481, 429, 15, ""),
					new(2436, 410, 15, ""),
					new(2519, 523, 0, ""),
					new(2452, 479, 15, ""),
					new(2452, 481, 15, ""),
					new(2452, 483, 15, ""),
					new(2499, 382, 0, ""),
					new(2527, 547, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2907, "", new DecorationEntry[]
				{
					new(2502, 425, 15, ""),
					new(2500, 425, 15, ""),
					new(2518, 478, 21, ""),
					new(2470, 562, 5, ""),
					new(2509, 473, 15, ""),
					new(2517, 479, 15, ""),
					new(2504, 425, 15, ""),
					new(2518, 479, 15, ""),
					new(2506, 425, 15, ""),
					new(2517, 478, 21, ""),
					new(2487, 474, 15, ""),
					new(2516, 478, 21, ""),
				}),
				new("Chair", typeof(BambooChair), 2908, "", new DecorationEntry[]
				{
					new(2506, 429, 15, ""),
					new(2502, 429, 15, ""),
					new(2487, 477, 15, ""),
					new(2531, 579, 0, ""),
					new(2509, 594, 0, ""),
					new(2504, 429, 15, ""),
					new(2599, 624, 0, ""),
					new(2453, 433, 15, ""),
					new(2619, 616, 0, ""),
					new(2500, 429, 15, ""),
					new(2420, 469, 15, ""),
					new(2521, 545, 0, ""),
					new(2422, 495, 15, ""),
				}),
				new("Chair", typeof(BambooChair), 2909, "", new DecorationEntry[]
				{
					new(2533, 655, 1, ""),
					new(2518, 652, 1, ""),
					new(2550, 654, 1, ""),
					new(2550, 652, 1, ""),
					new(2533, 657, 1, ""),
					new(2481, 596, 0, ""),
					new(2476, 427, 15, ""),
					new(2550, 656, 1, ""),
					new(2518, 656, 1, ""),
					new(2451, 454, 15, ""),
					new(2518, 654, 1, ""),
					new(2456, 483, 15, ""),
					new(2456, 481, 15, ""),
					new(2456, 479, 15, ""),
					new(2428, 555, 0, ""),
					new(2418, 483, 15, ""),
					new(2494, 596, 0, ""),
					new(2594, 613, 0, ""),
					new(2447, 486, 15, ""),
					new(2594, 639, 0, ""),
					new(2502, 381, 0, ""),
					new(2463, 461, 15, ""),
					new(2502, 383, 0, ""),
					new(2532, 575, 0, ""),
					new(2460, 461, 15, ""),
					new(2485, 431, 15, ""),
					new(2485, 429, 15, ""),
					new(2456, 485, 15, ""),
					new(2485, 427, 15, ""),
				}),
				new("Foot Stool", typeof(FootStool), 2910, "", new DecorationEntry[]
				{
					new(2464, 398, 15, ""),
					new(2464, 400, 15, ""),
				}),
				new("Bench", typeof(Static), 2911, "", new DecorationEntry[]
				{
					new(2487, 401, 15, ""),
					new(2485, 409, 15, ""),
					new(2481, 401, 15, ""),
					new(2475, 401, 15, ""),
					new(2482, 409, 15, ""),
					new(2466, 409, 15, ""),
					new(2472, 401, 15, ""),
					new(2466, 401, 15, ""),
					new(2469, 401, 15, ""),
					new(2478, 401, 15, ""),
					new(2484, 401, 15, ""),
					new(2493, 401, 15, ""),
					new(2490, 401, 15, ""),
					new(2469, 409, 15, ""),
				}),
				new("Bench", typeof(Static), 2912, "", new DecorationEntry[]
				{
					new(2472, 397, 15, ""),
					new(2484, 397, 15, ""),
					new(2481, 397, 15, ""),
					new(2478, 397, 15, ""),
					new(2475, 397, 15, ""),
					new(2482, 405, 15, ""),
					new(2485, 405, 15, ""),
					new(2466, 397, 15, ""),
					new(2469, 397, 15, ""),
					new(2466, 405, 15, ""),
					new(2487, 397, 15, ""),
					new(2490, 397, 15, ""),
					new(2493, 397, 15, ""),
					new(2469, 405, 15, ""),
				}),
				new("Bench", typeof(Static), 2913, "", new DecorationEntry[]
				{
					new(2493, 400, 15, ""),
					new(2481, 399, 15, ""),
					new(2481, 400, 15, ""),
					new(2481, 398, 15, ""),
					new(2490, 400, 15, ""),
					new(2485, 406, 15, ""),
					new(2485, 408, 15, ""),
					new(2484, 400, 15, ""),
					new(2484, 399, 15, ""),
					new(2487, 398, 15, ""),
					new(2490, 399, 15, ""),
					new(2482, 408, 15, ""),
					new(2482, 407, 15, ""),
					new(2469, 398, 15, ""),
					new(2466, 408, 15, ""),
					new(2469, 399, 15, ""),
					new(2487, 399, 15, ""),
					new(2469, 400, 15, ""),
					new(2466, 407, 15, ""),
					new(2466, 399, 15, ""),
					new(2466, 398, 15, ""),
					new(2466, 400, 15, ""),
					new(2466, 406, 15, ""),
					new(2493, 399, 15, ""),
					new(2475, 400, 15, ""),
					new(2475, 398, 15, ""),
					new(2478, 398, 15, ""),
					new(2478, 400, 15, ""),
					new(2478, 399, 15, ""),
					new(2472, 400, 15, ""),
					new(2469, 407, 15, ""),
					new(2485, 407, 15, ""),
					new(2469, 408, 15, ""),
					new(2472, 399, 15, ""),
					new(2472, 398, 15, ""),
					new(2487, 400, 15, ""),
					new(2475, 399, 15, ""),
					new(2484, 398, 15, ""),
					new(2490, 398, 15, ""),
					new(2482, 406, 15, ""),
					new(2469, 406, 15, ""),
					new(2493, 398, 15, ""),
				}),
				new("Bench", typeof(Static), 2917, "", new DecorationEntry[]
				{
					new(2418, 557, 0, ""),
					new(2418, 555, 0, ""),
					new(2418, 553, 0, ""),
					new(2422, 551, 0, ""),
					new(2418, 551, 0, ""),
					new(2422, 553, 0, ""),
					new(2422, 555, 0, ""),
				}),
				new("Bench", typeof(Static), 2918, "", new DecorationEntry[]
				{
					new(2416, 557, 0, ""),
					new(2420, 555, 0, ""),
					new(2420, 553, 0, ""),
					new(2416, 553, 0, ""),
					new(2416, 551, 0, ""),
					new(2420, 551, 0, ""),
					new(2416, 555, 0, ""),
				}),
				new("Bench", typeof(Static), 2919, "", new DecorationEntry[]
				{
					new(2421, 553, 0, ""),
					new(2421, 551, 0, ""),
					new(2417, 553, 0, ""),
					new(2421, 555, 0, ""),
					new(2417, 551, 0, ""),
					new(2417, 555, 0, ""),
					new(2417, 557, 0, ""),
				}),
				new("Wooden Signpost", typeof(Static), 2968, "", new DecorationEntry[]
				{
					new(2507, 440, 15, ""),
				}),
				new("Wooden Signpost", typeof(Static), 2970, "", new DecorationEntry[]
				{
					new(2436, 443, 15, ""),
				}),
				new("Broken Chair", typeof(Static), 3088, "", new DecorationEntry[]
				{
					new(2506, 476, 15, ""),
					new(2514, 476, 15, ""),
				}),
				new("Broken Chair", typeof(Static), 3089, "", new DecorationEntry[]
				{
					new(2519, 474, 21, ""),
				}),
				new("Chessmen", typeof(Static), 3603, "", new DecorationEntry[]
				{
					new(2516, 652, 6, ""),
					new(2491, 398, 19, ""),
					new(2467, 408, 20, ""),
				}),
				new("Chessmen", typeof(Static), 3604, "", new DecorationEntry[]
				{
					new(2491, 398, 19, ""),
					new(2516, 652, 6, ""),
					new(2467, 408, 20, ""),
				}),
				new("Cards", typeof(Static), 3607, "", new DecorationEntry[]
				{
					new(2516, 655, 5, ""),
					new(2483, 409, 19, ""),
					new(2473, 399, 19, ""),
				}),
				new("Cards", typeof(Static), 3608, "", new DecorationEntry[]
				{
					new(2516, 654, 5, ""),
					new(2483, 409, 19, ""),
					new(2473, 399, 19, ""),
				}),
				new("Cards", typeof(Static), 3609, "", new DecorationEntry[]
				{
					new(2517, 654, 5, ""),
					new(2484, 409, 19, ""),
					new(2474, 399, 19, ""),
				}),
				new("Backgammon Board", typeof(Backgammon), 3612, "", new DecorationEntry[]
				{
					new(2467, 400, 19, ""),
				}),
				new("Crystal Ball", typeof(Static), 3631, "Light=Circle150", new DecorationEntry[]
				{
					new(2532, 655, 8, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3645, "", new DecorationEntry[]
				{
					new(2534, 551, 0, ""),
					new(2534, 552, 0, ""),
					new(2533, 552, 0, ""),
					new(2456, 426, 15, ""),
					new(2533, 551, 3, ""),
					new(2456, 425, 18, ""),
					new(2456, 424, 15, ""),
					new(2456, 425, 15, ""),
					new(2456, 424, 21, ""),
					new(2533, 551, 0, ""),
					new(2534, 550, 0, ""),
					new(2534, 551, 3, ""),
					new(2533, 550, 0, ""),
					new(2456, 424, 18, ""),
					new(2534, 550, 6, ""),
					new(2534, 552, 6, ""),
					new(2534, 550, 3, ""),
					new(2534, 552, 3, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(2528, 553, 3, ""),
					new(2528, 552, 0, ""),
					new(2528, 553, 0, ""),
					new(2529, 557, 0, ""),
					new(2528, 558, 0, ""),
					new(2528, 557, 3, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(2498, 549, 0, ""),
					new(2500, 545, 0, ""),
					new(2497, 549, 0, ""),
					new(2498, 545, 0, ""),
					new(2496, 545, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(2522, 635, 1, ""),
					new(2498, 547, 0, ""),
					new(2541, 673, 1, ""),
					new(2522, 636, 1, ""),
					new(2541, 674, 1, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(2594, 520, 15, ""),
					new(2577, 530, 15, ""),
					new(2528, 670, 1, ""),
					new(2533, 652, 1, ""),
					new(2532, 652, 1, ""),
					new(2529, 670, 1, ""),
					new(2566, 521, 15, ""),
					new(2583, 517, 15, ""),
					new(2507, 632, 1, ""),
					new(2542, 632, 1, ""),
					new(2590, 533, 15, ""),
					new(2543, 632, 1, ""),
					new(2506, 632, 1, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(2449, 424, 15, ""),
					new(2457, 402, 15, ""),
					new(2528, 555, 0, ""),
					new(2448, 426, 20, ""),
					new(2457, 402, 20, ""),
					new(2457, 401, 20, ""),
					new(2448, 425, 20, ""),
					new(2448, 426, 15, ""),
					new(2528, 554, 5, ""),
					new(2528, 555, 10, ""),
					new(2448, 425, 15, ""),
					new(2448, 424, 20, ""),
					new(2528, 555, 5, ""),
					new(2449, 424, 20, ""),
					new(2528, 556, 0, ""),
					new(2528, 556, 5, ""),
					new(2529, 554, 0, ""),
					new(2529, 556, 0, ""),
					new(2448, 424, 25, ""),
					new(2457, 400, 15, ""),
					new(2457, 401, 15, ""),
				}),
				new("Water Tub", typeof(Static), 3707, "", new DecorationEntry[]
				{
					new(2520, 371, 23, ""),
					new(2515, 371, 23, ""),
					new(2530, 371, 23, ""),
					new(2525, 371, 23, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(2500, 547, 0, ""),
					new(2496, 547, 0, ""),
					new(2497, 545, 0, ""),
					new(2498, 547, 0, ""),
					new(2497, 547, 0, ""),
					new(2496, 549, 0, ""),
				}),
				new("Strong Box", typeof(FillableMetalBox), 3712, "", new DecorationEntry[]
				{
					new(2507, 474, 21, ""),
					new(2469, 563, 11, ""),
				}),
				new("Empty Tub", typeof(Static), 3715, "", new DecorationEntry[]
				{
					new(2525, 371, 23, ""),
					new(2515, 371, 23, ""),
					new(2530, 371, 23, ""),
					new(2520, 371, 23, ""),
				}),
				new("Pickaxe", typeof(Static), 3717, "", new DecorationEntry[]
				{
					new(2585, 520, 15, ""),
				}),
				new("Pickaxe", typeof(Static), 3718, "", new DecorationEntry[]
				{
					new(2581, 527, 15, ""),
					new(2589, 536, 15, ""),
					new(2593, 524, 15, ""),
					new(2504, 427, 21, ""),
					new(2463, 488, 21, ""),
					new(2565, 524, 15, ""),
					new(2596, 528, 15, ""),
					new(2461, 484, 21, ""),
				}),
				new("Drum", typeof(Static), 3740, "", new DecorationEntry[]
				{
					new(2416, 545, 0, ""),
				}),
				new("Tambourine", typeof(Static), 3741, "", new DecorationEntry[]
				{
					new(2420, 546, 0, ""),
				}),
				new("Standing Harp", typeof(Static), 3761, "", new DecorationEntry[]
				{
					new(2420, 544, 2, ""),
				}),
				new("Lute", typeof(Static), 3763, "", new DecorationEntry[]
				{
					new(2418, 546, 0, ""),
				}),
				new("Music Stand", typeof(Static), 3765, "", new DecorationEntry[]
				{
					new(2418, 547, 0, ""),
					new(2420, 547, 0, ""),
					new(2416, 546, 0, ""),
				}),
				new("Music Stand", typeof(Static), 3769, "", new DecorationEntry[]
				{
					new(2421, 545, 0, ""),
				}),
				new("Cleaver", typeof(Static), 3779, "", new DecorationEntry[]
				{
					new(2435, 403, 21, ""),
					new(2432, 412, 21, ""),
				}),
				new("Diamond", typeof(Static), 3880, "", new DecorationEntry[]
				{
					new(2460, 484, 21, ""),
				}),
				new("Saddle", typeof(Static), 3895, "", new DecorationEntry[]
				{
					new(2523, 380, 23, ""),
					new(2523, 382, 23, ""),
				}),
				new("Shovel", typeof(Static), 3898, "", new DecorationEntry[]
				{
					new(2593, 533, 15, ""),
					new(2582, 520, 15, ""),
				}),
				new("Horse Dung", typeof(Static), 3899, "", new DecorationEntry[]
				{
					new(2521, 385, 15, ""),
					new(2527, 378, 23, ""),
					new(2533, 376, 23, ""),
					new(2521, 376, 23, ""),
				}),
				new("Horse Dung", typeof(Static), 3900, "", new DecorationEntry[]
				{
					new(2524, 376, 23, ""),
					new(2516, 375, 23, ""),
					new(2535, 374, 23, ""),
					new(2527, 381, 22, ""),
				}),
				new("Game Board", typeof(Chessboard), 4006, "", new DecorationEntry[]
				{
					new(2516, 652, 5, ""),
					new(2467, 408, 19, ""),
					new(2492, 398, 19, ""),
				}),
				new("Dice And Cup", typeof(Dice), 4007, "", new DecorationEntry[]
				{
					new(2468, 400, 19, ""),
					new(2486, 397, 19, ""),
				}),
				new("Backgammon Game", typeof(Backgammon), 4013, "", new DecorationEntry[]
				{
					new(2486, 398, 19, ""),
				}),
				new("Anvil", typeof(AnvilEastAddon), 4015, "", new DecorationEntry[]
				{
					new(2560, 501, 0, ""),
					new(2534, 571, 0, ""),
					new(2467, 553, 5, ""),
				}),
				new("Anvil", typeof(AnvilSouthAddon), 4016, "", new DecorationEntry[]
				{
					new(2465, 556, 5, ""),
				}),
				new("Forge", typeof(SmallForgeAddon), 4017, "", new DecorationEntry[]
				{
					new(2561, 501, 0, ""),
					new(2535, 571, 0, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4020, "", new DecorationEntry[]
				{
					new(2534, 572, 0, ""),
					new(2465, 557, 5, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4021, "", new DecorationEntry[]
				{
					new(2468, 553, 5, ""),
				}),
				new("Tongs", typeof(Static), 4027, "", new DecorationEntry[]
				{
					new(2535, 572, 0, ""),
					new(2469, 553, 5, ""),
					new(2465, 555, 5, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(2462, 452, 21, ""),
					new(2528, 547, 6, ""),
					new(2531, 575, 6, ""),
					new(2427, 555, 4, ""),
					new(2480, 475, 19, ""),
					new(2433, 530, 6, ""),
					new(2475, 427, 19, ""),
					new(2437, 410, 21, ""),
					new(2419, 523, 4, ""),
					new(2446, 486, 19, ""),
					new(2499, 427, 19, ""),
					new(2520, 523, 6, ""),
					new(2427, 438, 19, ""),
					new(2580, 597, 6, ""),
					new(2452, 428, 21, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(2483, 426, 19, ""),
					new(2470, 563, 11, ""),
					new(2434, 522, 4, ""),
					new(2509, 474, 21, ""),
					new(2454, 478, 19, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(2419, 523, 4, ""),
					new(2520, 523, 6, ""),
					new(2475, 427, 19, ""),
					new(2580, 597, 6, ""),
					new(2499, 427, 19, ""),
					new(2462, 452, 21, ""),
					new(2480, 475, 19, ""),
					new(2528, 547, 6, ""),
					new(2437, 410, 21, ""),
					new(2446, 486, 19, ""),
					new(2427, 555, 4, ""),
					new(2427, 438, 19, ""),
					new(2531, 575, 6, ""),
					new(2433, 530, 6, ""),
					new(2452, 428, 21, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(2509, 474, 21, ""),
					new(2454, 478, 19, ""),
					new(2483, 426, 19, ""),
					new(2434, 522, 4, ""),
					new(2470, 563, 11, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4095, "", new DecorationEntry[]
				{
					new(2421, 468, 21, ""),
					new(2483, 406, 19, ""),
					new(2473, 400, 19, ""),
					new(2532, 578, 6, ""),
					new(2598, 623, 6, ""),
					new(2467, 409, 19, ""),
					new(2508, 593, 6, ""),
					new(2467, 399, 19, ""),
					new(2479, 400, 19, ""),
					new(2454, 432, 21, ""),
					new(2618, 615, 6, ""),
					new(2467, 401, 19, ""),
					new(2485, 401, 19, ""),
					new(2421, 494, 21, ""),
					new(2522, 544, 6, ""),
					new(2488, 476, 19, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4096, "", new DecorationEntry[]
				{
					new(2480, 399, 19, ""),
					new(2501, 384, 4, ""),
					new(2593, 640, 6, ""),
					new(2450, 455, 21, ""),
					new(2493, 597, 6, ""),
					new(2492, 401, 19, ""),
					new(2593, 612, 6, ""),
					new(2486, 399, 19, ""),
					new(2492, 399, 19, ""),
					new(2484, 408, 19, ""),
					new(2480, 597, 6, ""),
					new(2463, 400, 21, ""),
					new(2417, 484, 21, ""),
					new(2480, 401, 19, ""),
					new(2463, 398, 21, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4097, "", new DecorationEntry[]
				{
					new(2501, 382, 4, ""),
					new(2492, 397, 19, ""),
					new(2484, 405, 19, ""),
					new(2486, 401, 19, ""),
					new(2480, 397, 19, ""),
					new(2486, 475, 19, ""),
					new(2474, 397, 19, ""),
					new(2474, 401, 19, ""),
					new(2468, 406, 19, ""),
					new(2468, 398, 19, ""),
					new(2549, 651, 5, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4098, "", new DecorationEntry[]
				{
					new(2467, 407, 19, ""),
					new(2548, 653, 5, ""),
					new(2473, 398, 19, ""),
					new(2491, 401, 19, ""),
					new(2467, 405, 19, ""),
					new(2479, 398, 19, ""),
					new(2485, 398, 19, ""),
					new(2500, 381, 4, ""),
					new(2467, 397, 19, ""),
					new(2548, 655, 5, ""),
					new(2483, 405, 19, ""),
				}),
				new("Spittoon", typeof(Static), 4099, "", new DecorationEntry[]
				{
					new(2465, 404, 15, ""),
					new(2488, 397, 15, ""),
					new(2470, 397, 15, ""),
					new(2481, 404, 15, ""),
				}),
				new("Wash Basin", typeof(Static), 4104, "", new DecorationEntry[]
				{
					new(2574, 590, 6, ""),
					new(2574, 599, 6, ""),
					new(2574, 597, 6, ""),
				}),
				new("Archery Butte", typeof(ArcheryButte), 4107, "", new DecorationEntry[]
				{
					new(2514, 408, 15, ""),
				}),
				new("Hammer", typeof(Static), 4138, "", new DecorationEntry[]
				{
					new(2515, 474, 21, ""),
					new(2459, 461, 21, ""),
				}),
				new("Hammer", typeof(Static), 4139, "", new DecorationEntry[]
				{
					new(2462, 459, 21, ""),
				}),
				new("Nails", typeof(Static), 4142, "", new DecorationEntry[]
				{
					new(2515, 474, 21, ""),
				}),
				new("Jointing Plane", typeof(Static), 4144, "", new DecorationEntry[]
				{
					new(2517, 474, 21, ""),
				}),
				new("Saw", typeof(Static), 4149, "", new DecorationEntry[]
				{
					new(2510, 474, 21, ""),
					new(2461, 454, 21, ""),
				}),
				new("Clock Frame", typeof(Static), 4173, "", new DecorationEntry[]
				{
					new(2462, 462, 21, ""),
					new(2459, 460, 21, ""),
				}),
				new("Clock Parts", typeof(Static), 4175, "", new DecorationEntry[]
				{
					new(2459, 462, 21, ""),
				}),
				new("Axle With Gears", typeof(Static), 4177, "", new DecorationEntry[]
				{
					new(2462, 460, 21, ""),
				}),
				new("Gears", typeof(Static), 4179, "", new DecorationEntry[]
				{
					new(2459, 459, 21, ""),
				}),
				new("Hinge", typeof(Static), 4181, "", new DecorationEntry[]
				{
					new(2462, 461, 21, ""),
				}),
				new("Sextant", typeof(Static), 4183, "", new DecorationEntry[]
				{
					new(2459, 461, 21, ""),
				}),
				new("Sextant Parts", typeof(Static), 4186, "", new DecorationEntry[]
				{
					new(2462, 463, 21, ""),
				}),
				new("Axle", typeof(Static), 4188, "", new DecorationEntry[]
				{
					new(2459, 459, 21, ""),
				}),
				new("Springs", typeof(Static), 4189, "", new DecorationEntry[]
				{
					new(2462, 460, 21, ""),
				}),
				new("Training Dummy", typeof(TrainingDummy), 4208, "", new DecorationEntry[]
				{
					new(2480, 424, 15, ""),
				}),
				new("Cot", typeof(Static), 4605, "", new DecorationEntry[]
				{
					new(2504, 637, 2, ""),
					new(2504, 639, 2, ""),
					new(2504, 635, 2, ""),
					new(2541, 676, 2, ""),
					new(2539, 637, 2, ""),
					new(2525, 671, 2, ""),
					new(2522, 640, 2, ""),
					new(2522, 638, 2, ""),
					new(2539, 633, 2, ""),
					new(2525, 677, 2, ""),
					new(2525, 675, 2, ""),
					new(2525, 673, 2, ""),
					new(2539, 639, 2, ""),
					new(2541, 678, 2, ""),
					new(2539, 635, 2, ""),
					new(2530, 659, 2, ""),
				}),
				new("Cot", typeof(Static), 4606, "", new DecorationEntry[]
				{
					new(2526, 671, 2, ""),
					new(2505, 635, 2, ""),
					new(2526, 677, 2, ""),
					new(2540, 639, 2, ""),
					new(2505, 637, 2, ""),
					new(2526, 675, 2, ""),
					new(2542, 676, 2, ""),
					new(2542, 678, 2, ""),
					new(2526, 673, 2, ""),
					new(2531, 659, 2, ""),
					new(2540, 635, 2, ""),
					new(2540, 637, 2, ""),
					new(2523, 638, 2, ""),
					new(2540, 633, 2, ""),
					new(2523, 640, 2, ""),
					new(2505, 639, 2, ""),
				}),
				new("Cot", typeof(Static), 4607, "", new DecorationEntry[]
				{
					new(2508, 638, 2, ""),
					new(2524, 633, 2, ""),
					new(2526, 633, 2, ""),
					new(2545, 671, 2, ""),
					new(2543, 671, 2, ""),
				}),
				new("Cot", typeof(Static), 4608, "", new DecorationEntry[]
				{
					new(2508, 639, 2, ""),
					new(2545, 672, 2, ""),
					new(2543, 672, 2, ""),
					new(2526, 634, 2, ""),
					new(2524, 634, 2, ""),
				}),
				new("Sign", typeof(LocalizedSign), 4764, "LabelNumber=1016190", new DecorationEntry[]
				{
					new(2525, 498, 26, ""),
				}),
				new("Tarot", typeof(Static), 4774, "", new DecorationEntry[]
				{
					new(2532, 657, 7, ""),
				}),
				new("Mallet And Chisel", typeof(Static), 4787, "", new DecorationEntry[]
				{
					new(2462, 523, 5, ""),
					new(2468, 523, 5, ""),
				}),
				new("Brush", typeof(Static), 4977, "", new DecorationEntry[]
				{
					new(2519, 375, 23, ""),
					new(2536, 372, 23, ""),
				}),
				new("Brush", typeof(Static), 4979, "", new DecorationEntry[]
				{
					new(2530, 375, 23, ""),
				}),
				new("Bridle", typeof(Static), 4980, "", new DecorationEntry[]
				{
					new(2535, 375, 23, ""),
					new(2522, 384, 15, ""),
				}),
				new("Bridle", typeof(Static), 4981, "", new DecorationEntry[]
				{
					new(2524, 381, 23, ""),
				}),
				new("Skirt", typeof(Static), 5398, "", new DecorationEntry[]
				{
					new(2542, 673, 1, ""),
					new(2528, 673, 1, ""),
					new(2542, 638, 1, ""),
				}),
				new("Shirt", typeof(Static), 5399, "", new DecorationEntry[]
				{
					new(2545, 678, 0, ""),
					new(2523, 635, 0, ""),
				}),
				new("Shirt", typeof(Static), 5400, "", new DecorationEntry[]
				{
					new(2528, 675, 0, ""),
				}),
				new("Long Pants", typeof(Static), 5433, "", new DecorationEntry[]
				{
					new(2525, 637, 1, ""),
					new(2542, 635, 0, ""),
					new(2529, 672, 1, ""),
				}),
				new("Bandana", typeof(Static), 5439, "", new DecorationEntry[]
				{
					new(2522, 633, 1, ""),
					new(2541, 633, 1, ""),
				}),
				new("Skullcap", typeof(Static), 5443, "", new DecorationEntry[]
				{
					new(2540, 634, 0, ""),
				}),
				new("Skullcap", typeof(Static), 5444, "", new DecorationEntry[]
				{
					new(2527, 672, 1, ""),
					new(2523, 636, 1, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(2529, 555, 0, ""),
					new(2547, 634, 0, ""),
					new(2547, 639, 0, ""),
					new(2533, 672, 0, ""),
					new(2528, 554, 0, ""),
					new(2530, 640, 0, ""),
					new(2448, 424, 15, ""),
					new(2549, 678, 0, ""),
					new(2563, 674, 0, ""),
					new(2489, 472, 15, ""),
					new(2533, 677, 0, ""),
					new(2549, 673, 0, ""),
					new(2512, 639, 0, ""),
					new(2512, 634, 0, ""),
					new(2530, 635, 0, ""),
				}),
				new("Wooden Bowl", typeof(Static), 5624, "", new DecorationEntry[]
				{
					new(2435, 436, 15, ""),
				}),
				new("Large Pewter Bowl", typeof(Static), 5635, "", new DecorationEntry[]
				{
					new(2494, 475, 21, ""),
				}),
				new("Large Wooden Bowl", typeof(Static), 5637, "", new DecorationEntry[]
				{
					new(2441, 435, 21, ""),
				}),
				new("Raw Leg Of Lamb", typeof(Static), 5641, "", new DecorationEntry[]
				{
					new(2432, 411, 21, ""),
				}),
				new("Water", typeof(Static), 6039, "", new DecorationEntry[]
				{
					new(2589, 581, -5, ""),
				}),
				new("Bellows", typeof(Static), 6522, "", new DecorationEntry[]
				{
					new(2467, 557, 5, ""),
					new(2467, 555, 5, ""),
				}),
				new("Forge", typeof(Static), 6526, "Light=Circle300", new DecorationEntry[]
				{
					new(2468, 555, 5, ""),
					new(2468, 557, 5, ""),
				}),
				new("Forge", typeof(Static), 6530, "", new DecorationEntry[]
				{
					new(2469, 557, 5, ""),
					new(2469, 555, 5, ""),
				}),
				new("Ore", typeof(Static), 6584, "", new DecorationEntry[]
				{
					new(2590, 529, 15, ""),
					new(2452, 496, 18, ""),
					new(2572, 523, 15, ""),
					new(2587, 518, 15, ""),
					new(2464, 486, 15, ""),
				}),
				new("Ore", typeof(Static), 6584, "Amount=25", new DecorationEntry[]
				{
					new(2508, 433, 18, ""),
				}),
				new("Ore", typeof(Static), 6585, "Amount=9", new DecorationEntry[]
				{
					new(2509, 433, 18, ""),
				}),
				new("Ore", typeof(Static), 6585, "", new DecorationEntry[]
				{
					new(2463, 484, 21, ""),
					new(2587, 521, 15, ""),
					new(2599, 528, 15, ""),
					new(2506, 427, 20, ""),
				}),
				new("Ore", typeof(Static), 6586, "", new DecorationEntry[]
				{
					new(2585, 529, 15, ""),
					new(2582, 533, 15, ""),
					new(2595, 535, 15, ""),
					new(2599, 522, 15, ""),
					new(2580, 527, 15, ""),
					new(2459, 484, 15, ""),
					new(2461, 486, 15, ""),
					new(2569, 525, 15, ""),
					new(2503, 427, 19, ""),
				}),
				new("Bulletin Board", typeof(BulletinBoard), 7774, "", new DecorationEntry[]
				{
					new(2471, 397, 15, ""),
				}),
				new("Fancy Shirt", typeof(Static), 7933, "", new DecorationEntry[]
				{
					new(2541, 636, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
