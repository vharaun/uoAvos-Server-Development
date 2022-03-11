using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] StudyOfSolenQuest { get; } = Register(DecorationTarget.Britannia, "Study Of Solen Quest", new DecorationList[]
			{
				#region Entries
				
				new("Naturalists", typeof(Spawner), 7955, "Spawn=Naturalist;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(1495, 1721, 7, ""),
					new(1414, 1594, 30, ""),
					new(1574, 1697, 35, ""),
					new(1393, 3769, 0, ""),
					new(5240, 174, 15, ""),
				}),
				
				#endregion
			});
		}
	}
}
