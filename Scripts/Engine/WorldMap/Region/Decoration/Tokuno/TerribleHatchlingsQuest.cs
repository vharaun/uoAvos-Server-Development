using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Tokuno
		{
			public static DecorationList[] TerribleHatchlingsQuest { get; } = Register(DecorationTarget.Tokuno, "Terrible Hatchlings Quest", new DecorationList[]
			{
				#region Entries
				
				new("Ansella Gryen", typeof(Spawner), 7955, "Spawn=AnsellaGryen;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(760, 1200, 25, ""),
				}),
				
				#endregion
			});
		}
	}
}
