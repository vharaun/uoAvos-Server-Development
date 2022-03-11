using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Tokuno
		{
			public static DecorationList[] TreasuresOfTokuno { get; } = Register(DecorationTarget.Tokuno, "Treasures Of Tokuno", new DecorationList[]
			{
				#region Entries
				
				new("Ihara Soko", typeof(Spawner), 7955, "Spawn=IharaSoko;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(678, 1277, 47, ""),
				}),
				new("Blockers Around Him", typeof(Blocker), 8612, "", new DecorationEntry[]
				{
					new(677, 1277, 47, ""),
					new(679, 1277, 47, ""),
					new(678, 1276, 47, ""),
					new(678, 1278, 47, ""),
					new(677, 1276, 47, ""),
					new(677, 1278, 47, ""),
					new(679, 1276, 47, ""),
					new(679, 1278, 47, ""),
				}),
				
				#endregion
			});
		}
	}
}
