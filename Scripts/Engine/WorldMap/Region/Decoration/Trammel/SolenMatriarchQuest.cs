using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Trammel
		{
			public static DecorationList[] SolenMatriarchQuest { get; } = Register(DecorationTarget.Trammel, "Solen Matriarch Quest", new DecorationList[]
			{
				#region Entries
				
				new("Red Solen Matriarch", typeof(Spawner), 7955, "Spawn=RedSolenMatriarch;Count=1;HomeRange=14", new DecorationEntry[]
				{
					new(5776, 1898, 22, ""),
				}),
				
				#endregion
			});
		}
	}
}
