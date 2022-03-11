using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Trammel
		{
			public static DecorationList[] CollectorQuest { get; } = Register(DecorationTarget.Trammel, "Collector Quest", new DecorationList[]
			{
				#region Entries
				
				new("Elwood McCarrin", typeof(Spawner), 7955, "Spawn=ElwoodMcCarrin;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(3666, 2652, 0, ""),
				}),
				new("Alberta Giacco", typeof(Spawner), 7955, "Spawn=AlbertaGiacco;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(2899, 709, 0, ""),
				}),
				new("Gabriel Piete", typeof(Spawner), 7955, "Spawn=GabrielPiete;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(1443, 1557, 51, ""),
				}),
				new("Impresario", typeof(Spawner), 7955, "Spawn=Impresario;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(1454, 1593, 20, ""),
					new(3738, 1230, 0, ""),
					new(3736, 1220, 2, ""),
					new(1429, 4011, 0, ""),
					new(1424, 4008, 0, ""),
				}),
				new("Tomas O'Neerlan", typeof(Spawner), 7955, "Spawn=TomasONeerlan;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(1839, 2674, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
