using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Trammel
		{
			public static DecorationList[] AmbitiousSolenQueenQuest { get; } = Register(DecorationTarget.Trammel, "Ambitious Solen Queen Quest", new DecorationList[]
			{
				#region Entries
				
				new("Red Ambitious Solen Queen", typeof(Spawner), 7955, "Spawn=RedAmbitiousSolenQueen;Count=1;HomeRange=14", new DecorationEntry[]
				{
					new(5790, 1983, 2, ""),
				}),
				
				#endregion
			});
		}
	}
}
