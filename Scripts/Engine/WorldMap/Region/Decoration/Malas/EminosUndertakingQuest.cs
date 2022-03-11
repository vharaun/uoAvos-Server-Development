using Server.Engines.Quests.Items;
using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Malas
		{
			public static DecorationList[] EminosUndertakingQuest { get; } = Register(DecorationTarget.Malas, "Eminos Undertaking Quest", new DecorationList[]
			{
				#region Entries
				
				new("Moongate", typeof(Static), 8151, "Hue=0x3F1", new DecorationEntry[]
				{
					new(375, 802, 1, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(770, 1209, 25);MapDest=Tokuno", new DecorationEntry[]
				{
					new(375, 802, 1, ""),
				}),
				new("Ankh", typeof(AnkhNorth), 4, "Hue=0xFA", new DecorationEntry[]
				{
					new(397, 801, 4, ""),
				}),
				new("Emino", typeof(Spawner), 7955, "Spawn=Emino;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(411, 810, -1, ""),
				}),
				new("Zoel", typeof(Spawner), 7955, "Spawn=Zoel;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(388, 817, -1, ""),
				}),
				new("Hidden Figures", typeof(Spawner), 7955, "Spawn=HiddenFigure;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(403, 1118, 0, ""),
					new(405, 1118, 0, ""),
					new(403, 1110, 0, ""),
					new(403, 1112, 0, ""),
					new(403, 1103, 0, ""),
					new(404, 1101, 0, ""),
					new(419, 1118, 0, ""),
					new(418, 1120, 0, ""),
					new(419, 1111, 0, ""),
					new(418, 1109, 0, ""),
					new(419, 1102, 0, ""),
					new(418, 1103, 0, ""),
				}),
				new("Enshrouded Figure", typeof(Spawner), 7955, "Spawn=EnshroudedFigure;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(403, 1094, 0, ""),
				}),
				new("Jedah Entille", typeof(Spawner), 7955, "Spawn=JedahEntille;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(404, 1093, 0, ""),
				}),
				new("Guardian Barrier", typeof(GuardianBarrier), 14695, "", new DecorationEntry[]
				{
					new(404, 1140, 0, ""),
					new(405, 1140, 0, ""),
					new(406, 1140, 0, ""),
					new(407, 1140, 0, ""),
					new(408, 1140, 0, ""),
					new(409, 1140, 0, ""),
				}),
				new("Green Teleporters", typeof(GreenNinjaQuestTeleporter), 1308, "", new DecorationEntry[]
				{
					new(418, 804, -1, ""),
				}),
				new("", typeof(Static), 1308, "Hue=0x17E", new DecorationEntry[]
				{
					new(412, 1123, 0, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(417, 806, -1)", new DecorationEntry[]
				{
					new(412, 1123, 0, ""),
				}),
				new("Blue Teleporters", typeof(BlueNinjaQuestTeleporter), 1308, "", new DecorationEntry[]
				{
					new(423, 805, -1, ""),
				}),
				new("", typeof(Static), 1308, "Hue=0x2", new DecorationEntry[]
				{
					new(411, 1117, 0, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(422, 806, -1)", new DecorationEntry[]
				{
					new(411, 1117, 0, ""),
				}),
				new("Red Teleporter", typeof(Static), 1308, "Hue=0x21", new DecorationEntry[]
				{
					new(421, 1092, 0, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(391, 803, -1)", new DecorationEntry[]
				{
					new(421, 1092, 0, ""),
				}),
				new("White Teleporters", typeof(WhiteNinjaQuestTeleporter), 1308, "", new DecorationEntry[]
				{
					new(392, 802, -1, ""),
				}),
				new("", typeof(Static), 1308, "Hue=0x47E", new DecorationEntry[]
				{
					new(412, 1086, 0, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(391, 803, -1)", new DecorationEntry[]
				{
					new(412, 1086, 0, ""),
				}),
				new("Wooden Chest", typeof(EminosKatanaChest), 3650, "", new DecorationEntry[]
				{
					new(393, 989, -15, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4506, "", new DecorationEntry[]
				{
					new(418, 1084, 0, ""),
				}),
				new("Floor Saw", typeof(SawTrap), 4524, "", new DecorationEntry[]
				{
					new(421, 1077, 0, ""),
				}),
				new("Hole", typeof(FireColumnTrap), 7025, "", new DecorationEntry[]
				{
					new(403, 1073, 0, ""),
					new(410, 1050, 0, ""),
					new(408, 1044, 0, ""),
					new(409, 1044, 0, ""),
					new(410, 1044, 0, ""),
					new(411, 1044, 0, ""),
					new(412, 1044, 0, ""),
					new(413, 1044, 0, ""),
				}),
				new("Haramaki-Do", typeof(Static), 9844, "Hue=0x48C", new DecorationEntry[]
				{
					new(409, 1009, -13, ""),
				}),
				new("War Mace", typeof(Static), 5126, "Hue=0x47E", new DecorationEntry[]
				{
					new(409, 1008, -13, ""),
				}),
				new("Kabuto", typeof(Static), 9069, "Hue=0x48C", new DecorationEntry[]
				{
					new(409, 1008, -13, ""),
				}),
				new("Chest", typeof(OrnateWoodenChest), 10253, "", new DecorationEntry[]
				{
					new(436, 999, -15, ""),
				}),
				new("Kimono", typeof(Static), 9857, "", new DecorationEntry[]
				{
					new(396, 1149, 0, ""),
				}),
				new("Ninja Pants", typeof(Static), 9809, "Hue=0x530", new DecorationEntry[]
				{
					new(397, 1146, 1, ""),
				}),
				new("Ninja Mask", typeof(Static), 9892, "Hue=0x530", new DecorationEntry[]
				{
					new(395, 1146, 0, ""),
				}),
				new("Ninja Shirt", typeof(Static), 9832, "Hue=0x530", new DecorationEntry[]
				{
					new(396, 1146, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
