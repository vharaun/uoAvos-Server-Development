using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] WitchApprenticeQuest { get; } = Register(DecorationTarget.Britannia, "Witch Apprentice Quest", new DecorationList[]
			{
				#region Entries
				
				new("Grizelda", typeof(Spawner), 7955, "Spawn=Grizelda;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(850, 1544, 0, ""),
				}),
				new("Captain Blackheart", typeof(Spawner), 7955, "Spawn=Blackheart;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(2679, 2234, 2, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(844, 1547, 0, ""),
					new(860, 1547, 0, ""),
				}),
				new("Lantern", typeof(Lantern), 2581, "", new DecorationEntry[]
				{
					new(851, 1537, 0, ""),
				}),
				new("Grasses", typeof(Static), 3253, "", new DecorationEntry[]
				{
					new(851, 1549, 0, ""),
				}),
				new("Empty Tub", typeof(Static), 3715, "", new DecorationEntry[]
				{
					new(855, 1534, 0, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4020, "", new DecorationEntry[]
				{
					new(856, 1537, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(858, 1538, 0, ""),
				}),
				new("Pitchfork", typeof(Pitchfork), 3719, "", new DecorationEntry[]
				{
					new(861, 1546, 0, ""),
				}),
				new("Stew", typeof(Static), 2416, "", new DecorationEntry[]
				{
					new(849, 1544, 8, ""),
				}),
				new("Fire Pit", typeof(Static), 4012, "", new DecorationEntry[]
				{
					new(849, 1544, 0, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(849, 1544, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
