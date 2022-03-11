using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Felucca
		{
			public static DecorationList[] AmbitiousSolenQueenQuest { get; } = Register(DecorationTarget.Felucca, "Ambitious Solen Queen Quest", new DecorationList[]
			{
				#region Entries
				
				new("Black Ambitious Solen Queen", typeof(Spawner), 7955, "Spawn=BlackAmbitiousSolenQueen;Count=1;HomeRange=14", new DecorationEntry[]
				{
					new(5790, 1983, 2, ""),
				}),
				
				#endregion
			});
		}
	}
}
