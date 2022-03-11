using Server.Engines.Quests.Items;
using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Trammel
		{
			public static DecorationList[] UzeraanTurmoilQuest { get; } = Register(DecorationTarget.Trammel, "Uzeraan Turmoil Quest", new DecorationList[]
			{
				#region Entries
				
				new("A Magical Teleporter", typeof(UzeraanTurmoilTeleporter), 6178, "", new DecorationEntry[]
				{
					new(3597, 2582, 0, ""),
				}),
				new("Metal Chest", typeof(DaemonBloodChest), 2475, "", new DecorationEntry[]
				{
					new(3456, 2558, 50, ""),
				}),
				new("Mansion Guard", typeof(Spawner), 7955, "Spawn=MansionGuard;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(3585, 2588, 0, ""),
					new(3585, 2586, 0, ""),
					new(3603, 2583, 0, ""),
					new(3613, 2586, 0, ""),
					new(3613, 2589, 0, ""),
				}),
				new("Uzeraan", typeof(Spawner), 7955, "Spawn=Uzeraan;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(3595, 2587, 0, ""),
				}),
				new("Schmendrick", typeof(Spawner), 7955, "Spawn=Schmendrick;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(5211, 1818, 0, ""),
				}),
				new("Schmendrick Apprentice Corpse", typeof(Spawner), 7955, "Spawn=SchmendrickApprenticeCorpse;Count=1;HomeRange=15;MinDelay=0:10:0;MaxDelay=0:10:0", new DecorationEntry[]
				{
					new(5261, 1831, 0, ""),
				}),
				new("Schmendrick Cave Teleporter", typeof(Static), 6178, "", new DecorationEntry[]
				{
					new(5260, 1841, 0, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(3613, 2592, 0)", new DecorationEntry[]
				{
					new(5260, 1841, 0, ""),
				}),
				new("Dryad", typeof(Spawner), 7955, "Spawn=Dryad;Count=1;HomeRange=2", new DecorationEntry[]
				{
					new(3555, 2698, 5, ""),
				}),
				new("Fire", typeof(Static), 6571, "", new DecorationEntry[]
				{
					new(5210, 1817, 0, ""),
					new(5211, 1814, 0, ""),
					new(5205, 1818, 0, ""),
				}),
				new("Sparkle", typeof(Static), 14154, "", new DecorationEntry[]
				{
					new(5208, 1817, 0, ""),
				}),
				new("Sparkle", typeof(Static), 14202, "", new DecorationEntry[]
				{
					new(5209, 1815, 0, ""),
				}),
				new("Sparkle", typeof(Static), 14186, "", new DecorationEntry[]
				{
					new(5208, 1815, 0, ""),
				}),
				new("Magical Sparkles", typeof(Static), 4435, "", new DecorationEntry[]
				{
					new(5207, 1816, 0, ""),
					new(5260, 1842, 0, ""),
					new(5261, 1841, 0, ""),
				}),
				new("Death Vortex", typeof(Static), 14217, "", new DecorationEntry[]
				{
					new(5208, 1815, 0, ""),
				}),
				new("Magical Sparkles", typeof(Static), 4438, "", new DecorationEntry[]
				{
					new(5261, 1841, 0, ""),
					new(5261, 1842, 0, ""),
				}),
				new("Cannon South", typeof(Cannon), 0, "CannonDirection=South", new DecorationEntry[]
				{
					new(3678, 2768, 33, ""),
					new(3675, 2767, 31, ""),
					new(3593, 2810, 50, ""),
				}),
				new("Cannon West", typeof(Cannon), 0, "CannonDirection=West", new DecorationEntry[]
				{
					new(3681, 2776, 39, ""),
					new(3683, 2779, 44, ""),
					new(3659, 2790, 47, ""),
					new(3705, 2832, 29, ""),
				}),
				new("Cannon East", typeof(Cannon), 0, "CannonDirection=East", new DecorationEntry[]
				{
					new(3662, 2795, 68, ""),
					new(3596, 2807, 50, ""),
				}),
				new("Cannon North", typeof(Cannon), 0, "CannonDirection=North", new DecorationEntry[]
				{
					new(3593, 2804, 50, ""),
					new(3702, 2837, 33, ""),
				}),
				new("Cannon Balls", typeof(Static), 3700, "", new DecorationEntry[]
				{
					new(3706, 2833, 24, ""),
					new(3595, 2808, 49, ""),
					new(3594, 2808, 50, ""),
					new(3663, 2793, 67, ""),
					new(3661, 2791, 53, ""),
					new(3662, 2793, 67, ""),
					new(3676, 2768, 32, ""),
					new(3676, 2767, 31, ""),
					new(3682, 2777, 41, ""),
					new(3683, 2777, 42, ""),
					new(3681, 2777, 40, ""),
				}),
				
				#endregion
			});
		}
	}
}
