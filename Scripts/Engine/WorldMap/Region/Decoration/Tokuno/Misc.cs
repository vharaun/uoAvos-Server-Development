using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Tokuno
		{
			public static DecorationList[] Misc { get; } = Register(DecorationTarget.Tokuno, "Misc", new DecorationList[]
			{
				#region Entries
				
				new("Ankh", typeof(Static), 2, "", new DecorationEntry[]
				{
					new(296, 712, 55, ""),
					new(780, 1219, 46, ""),
					new(1042, 508, 15, ""),
					new(1051, 508, 15, ""),
				}),
				new("Ankh", typeof(Static), 3, "", new DecorationEntry[]
				{
					new(296, 711, 55, ""),
					new(780, 1218, 46, ""),
					new(1042, 507, 15, ""),
					new(1051, 507, 15, ""),
				}),
				new("Ankh", typeof(Static), 4, "", new DecorationEntry[]
				{
					new(717, 1158, 27, ""),
				}),
				new("Ankh", typeof(Static), 5, "", new DecorationEntry[]
				{
					new(718, 1158, 27, ""),
				}),
				new("Backgammon Board", typeof(Backgammon), 3612, "", new DecorationEntry[]
				{
					new(691, 1255, 48, ""),
				}),
				new("Backgammon Game", typeof(Backgammon), 4013, "", new DecorationEntry[]
				{
					new(668, 1258, 47, ""),
				}),
				new("Archery Butte", typeof(ArcheryButte), 4107, "", new DecorationEntry[]
				{
					new(660, 1193, 25, ""),
					new(663, 1193, 25, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelEastAddon), 4121, "", new DecorationEntry[]
				{
					new(742, 1205, 25, ""),
					new(749, 1203, 25, ""),
				}),
				new("Upright Loom", typeof(LoomEastAddon), 4192, "", new DecorationEntry[]
				{
					new(742, 1208, 25, ""),
					new(742, 1219, 25, ""),
					new(750, 1208, 25, ""),
				}),
				new("Upright Loom", typeof(LoomSouthAddon), 4193, "", new DecorationEntry[]
				{
					new(746, 1218, 25, ""),
					new(746, 1213, 25, ""),
				}),
				new("Training Dummy", typeof(TrainingDummy), 4212, "", new DecorationEntry[]
				{
					new(662, 1206, 25, ""),
					new(662, 1212, 25, ""),
				}),
				new("Valor -> Shrine Of Isamu", typeof(LocalizedStatic), 5303, "LabelNumber=1070790", new DecorationEntry[]
				{
					new(1050, 517, 15, ""),
				}),
				new("Valor -> Shrine Of Isamu", typeof(LocalizedStatic), 5304, "LabelNumber=1070790", new DecorationEntry[]
				{
					new(1050, 518, 15, ""),
				}),
				new("Valor -> Shrine Of Isamu", typeof(LocalizedStatic), 5305, "LabelNumber=1070790", new DecorationEntry[]
				{
					new(1051, 518, 15, ""),
				}),
				new("Valor -> Shrine Of Isamu", typeof(LocalizedStatic), 5306, "LabelNumber=1070790", new DecorationEntry[]
				{
					new(1051, 517, 15, ""),
				}),
				new("Bellows", typeof(Static), 6522, "", new DecorationEntry[]
				{
					new(767, 1257, 25, ""),
					new(767, 1262, 25, ""),
				}),
				new("Bellows", typeof(Static), 6525, "", new DecorationEntry[]
				{
					new(767, 1257, 25, ""),
				}),
				new("Forge", typeof(Static), 6526, "Light=Circle300", new DecorationEntry[]
				{
					new(768, 1257, 25, ""),
					new(768, 1262, 25, ""),
				}),
				new("Forge", typeof(Static), 6530, "Light=Circle300", new DecorationEntry[]
				{
					new(769, 1257, 25, ""),
					new(769, 1262, 25, ""),
				}),
				new("Bellows", typeof(Static), 6534, "", new DecorationEntry[]
				{
					new(638, 1204, 52, ""),
					new(638, 1208, 32, ""),
				}),
				new("Forge", typeof(Static), 6538, "Light=Circle300", new DecorationEntry[]
				{
					new(638, 1205, 52, ""),
					new(638, 1209, 32, ""),
				}),
				new("Forge", typeof(Static), 6542, "Light=Circle300", new DecorationEntry[]
				{
					new(764, 1258, 25, ""),
				}),
				new("Forge", typeof(Static), 6545, "Light=Circle300", new DecorationEntry[]
				{
					new(764, 1258, 25, ""),
				}),
				new("Bellows", typeof(Static), 6546, "", new DecorationEntry[]
				{
					new(638, 1207, 52, ""),
					new(638, 1211, 32, ""),
				}),
				new("Forge", typeof(Static), 6550, "Light=Circle300", new DecorationEntry[]
				{
					new(638, 1206, 52, ""),
					new(638, 1210, 32, ""),
				}),
				new("Forge", typeof(Static), 6557, "Light=Circle300", new DecorationEntry[]
				{
					new(764, 1257, 25, ""),
				}),
				new("May The Town Of Zento Prosper.  Memorial Tree Planted By Dept And Maha.", typeof(LocalizedStatic), 9242, "LabelNumber=1063344", new DecorationEntry[]
				{
					new(748, 1231, 25, ""),
				}),
				
				#endregion
			});
		}
	}
}
