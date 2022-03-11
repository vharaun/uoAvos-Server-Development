using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Patches { get; } = Register(DecorationTarget.Britannia, "Patches", new DecorationList[]
			{
				#region Entries
				
				new("", typeof(Blocker), 8612, "", new DecorationEntry[]
				{
					new(5572, 628, 47, "", "Despise"),
					new(5572, 629, 47, "", "Despise"),
					new(5572, 630, 47, "", "Despise"),
					new(5505, 569, 41, "", "Despise"),
					new(5505, 570, 41, "", "Despise"),
					new(5505, 571, 41, "", "Despise"),
					new(5506, 569, 39, "", "Despise"),
					new(5506, 570, 39, "", "Despise"),
					new(5506, 571, 39, "", "Despise"),
					new(5507, 569, 49, "", "Despise"),
					new(5507, 570, 49, "", "Despise"),
					new(5507, 571, 49, "", "Despise"),
					new(5571, 632, 12, "", "Despise"),
					new(5571, 633, 12, "", "Despise"),
					new(5571, 634, 12, "", "Despise"),
					new(5523, 672, 37, "", "Despise"),
					new(5523, 673, 37, "", "Despise"),
					new(5523, 674, 37, "", "Despise"),
					new(5385, 755, -13, "", "Despise"),
					new(5385, 756, -13, "", "Despise"),
					new(5385, 757, -13, "", "Despise"),
					new(5410, 858, 57, "", "Despise"),
					new(5410, 859, 57, "", "Despise"),
					new(5410, 860, 57, "", "Despise"),
					new(6082, 144, -15, "", "Hythloth"),
					new(6082, 145, -15, "", "Hythloth"),
					new(6082, 146, -15, "", "Hythloth"),
					new(6058, 88, 29, "", "Hythloth"),
					new(6058, 89, 29, "", "Hythloth"),
					new(6058, 90, 29, "", "Hythloth"),
					new(6041, 192, 7, "", "Hythloth"),
					new(6041, 193, 7, "", "Hythloth"),
					new(6041, 194, 7, "", "Hythloth"),
					new(6042, 194, 10, "", "Hythloth"),
					new(6043, 194, 16, "", "Hythloth"),
					new(6044, 194, 16, "", "Hythloth"),
					new(6045, 194, 21, "", "Hythloth"),
					new(6046, 194, 22, "", "Hythloth"),
				}),
				new("Teleporter", typeof(Static), 6153, "", new DecorationEntry[]
				{
					new(1653, 2963, 0, ""),
					new(1677, 2987, 0, ""),
				}),
				new("Water", typeof(Static), 6039, "", new DecorationEntry[]
				{
					new(3807, 1204, -5, ""),
					new(3801, 1165, -5, ""),
					new(3584, 1258, -5, ""),
					new(3454, 104, -5, ""),
					new(3468, 114, -5, ""),
					new(3440, 176, -5, ""),
					new(3386, 174, -5, ""),
					new(3332, 194, -5, ""),
					new(3284, 90, -5, ""),
					new(3522, 366, -5, ""),
					new(3458, 384, -5, ""),
					new(3478, 394, -5, ""),
					new(3406, 520, -5, ""),
					new(3418, 580, -5, ""),
					new(3440, 554, -5, ""),
					new(3448, 546, -5, ""),
					new(3460, 536, -5, ""),
					new(3482, 512, -5, ""),
					new(3454, 628, -5, ""),
				}),
				new("Water", typeof(Static), 6040, "", new DecorationEntry[]
				{
					new(3812, 1202, -5, ""),
					new(3581, 1258, -5, ""),
					new(3585, 1258, -5, ""),
					new(3458, 106, -5, ""),
					new(3470, 116, -5, ""),
					new(3412, 192, -5, ""),
					new(3352, 178, -5, ""),
					new(3318, 194, -5, ""),
					new(3502, 334, -5, ""),
					new(3452, 378, -5, ""),
					new(3464, 388, -5, ""),
					new(3480, 396, -5, ""),
					new(3412, 524, -5, ""),
					new(3424, 576, -5, ""),
					new(3442, 552, -5, ""),
					new(3452, 540, -5, ""),
					new(3466, 522, -5, ""),
					new(3484, 514, -5, ""),
					new(3264, 726, -5, ""),
				}),
				new("Water", typeof(Static), 6041, "", new DecorationEntry[]
				{
					new(3813, 1201, -5, ""),
					new(3582, 1258, -5, ""),
					new(3586, 1258, -5, ""),
					new(3462, 108, -5, ""),
					new(3472, 118, -5, ""),
					new(3408, 190, -5, ""),
					new(3346, 182, -5, ""),
					new(3316, 194, -5, ""),
					new(3508, 338, -5, ""),
					new(3454, 380, -5, ""),
					new(3468, 390, -5, ""),
					new(3490, 406, -5, ""),
					new(3410, 586, -5, ""),
					new(3436, 560, -5, ""),
					new(3444, 550, -5, ""),
					new(3454, 538, -5, ""),
					new(3470, 514, -5, ""),
					new(3486, 516, -5, ""),
					new(3266, 724, -5, ""),
				}),
				new("Water", typeof(Static), 6042, "", new DecorationEntry[]
				{
					new(3799, 1165, -5, ""),
					new(3583, 1258, -5, ""),
					new(3587, 1258, -5, ""),
					new(3466, 112, -5, ""),
					new(3414, 94, -5, ""),
					new(3388, 174, -5, ""),
					new(3334, 192, -5, ""),
					new(3286, 90, -5, ""),
					new(3510, 340, -5, ""),
					new(3456, 382, -5, ""),
					new(3472, 392, -5, ""),
					new(3466, 458, -5, ""),
					new(3412, 584, -5, ""),
					new(3438, 556, -5, ""),
					new(3446, 548, -5, ""),
					new(3456, 538, -5, ""),
					new(3472, 512, -5, ""),
					new(3488, 580, -5, ""),
				}),
				
				#endregion
			});
		}
	}
}
