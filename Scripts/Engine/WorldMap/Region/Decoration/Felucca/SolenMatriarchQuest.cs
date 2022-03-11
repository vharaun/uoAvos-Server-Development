using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Felucca
		{
			public static DecorationList[] SolenMatriarchQuest { get; } = Register(DecorationTarget.Felucca, "Solen Matriarch Quest", new DecorationList[]
			{
				#region Entries
				
				new("Black Solen Matriarch", typeof(Spawner), 7955, "Spawn=BlackSolenMatriarch;Count=1;HomeRange=14", new DecorationEntry[]
				{
					new(5776, 1898, 22, ""),
				}),
				
				#endregion
			});
		}
	}
}
