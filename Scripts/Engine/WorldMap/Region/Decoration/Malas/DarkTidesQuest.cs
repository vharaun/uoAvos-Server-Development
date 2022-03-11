using Server.Engines.Quests.Items;
using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Malas
		{
			public static DecorationList[] DarkTidesQuest { get; } = Register(DecorationTarget.Malas, "Dark Tides Quest", new DecorationList[]
			{
				#region Entries
				
				new("A Magical Teleporter", typeof(DarkTidesTeleporter), 6178, "", new DecorationEntry[]
				{
					new(2105, 1307, -50, ""),
					new(2018, 1226, -90, ""),
					new(1068, 458, -90, ""),
				}),
				new("Mardoth", typeof(Spawner), 7955, "Spawn=Mardoth;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(2110, 1306, -50, ""),
				}),
				new("Maabus Coffin", typeof(MaabusCoffin), 0, "SpawnLocation=(2024, 1224, -90)", new DecorationEntry[]
				{
					new(2023, 1223, -83, ""),
				}),
				new("Horus", typeof(Spawner), 7955, "Spawn=Horus;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(1192, 513, -90, ""),
				}),
				new("Crystal Cave Barrier", typeof(CrystalCaveBarrier), 14695, "", new DecorationEntry[]
				{
					new(1193, 512, -90, ""),
					new(1194, 512, -90, ""),
					new(1195, 512, -90, ""),
					new(1196, 512, -90, ""),
					new(1197, 512, -90, ""),
				}),
				new("Kronus Scroll Box", typeof(KronusScrollBox), 3712, "", new DecorationEntry[]
				{
					new(1185, 451, -90, ""),
				}),
				new("Vault Of Secrets Barrier", typeof(VaultOfSecretsBarrier), 1182, "", new DecorationEntry[]
				{
					new(1073, 450, -90, ""),
					new(1073, 451, -90, ""),
					new(1073, 452, -90, ""),
					new(1078, 450, -90, ""),
					new(1078, 451, -90, ""),
					new(1078, 452, -90, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "Hue=0x499", new DecorationEntry[]
				{
					new(1076, 453, -84, ""),
					new(1076, 449, -84, ""),
				}),
				new("Vault Of Secrets Sign", typeof(LocalizedSign), 3024, "Hue=0x482;LabelNumber=1060189", new DecorationEntry[]
				{
					new(1079, 454, -84, ""),
				}),
				new("Metal Signpost", typeof(Static), 2974, "", new DecorationEntry[]
				{
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(1185, 450, -90, ""),
					new(1185, 450, -87, ""),
					new(1200, 438, -87, ""),
					new(1203, 439, -90, ""),
					new(1185, 454, -87, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(1185, 448, -90, ""),
					new(1186, 439, -87, ""),
					new(1201, 438, -87, ""),
					new(1194, 447, -90, ""),
					new(1194, 448, -90, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "Hue=0x835", new DecorationEntry[]
				{
					new(1185, 447, -90, ""),
					new(1184, 446, -90, ""),
					new(1184, 443, -86, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "Hue=0x835", new DecorationEntry[]
				{
					new(1184, 445, -90, ""),
					new(1188, 437, -90, ""),
					new(1188, 437, -86, ""),
					new(1189, 437, -90, ""),
					new(1194, 438, -90, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(1184, 444, -90, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "Hue=0x849", new DecorationEntry[]
				{
					new(1184, 443, -90, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2714, "", new DecorationEntry[]
				{
					new(1185, 440, -90, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(1186, 439, -90, ""),
					new(1200, 438, -90, ""),
					new(1201, 438, -90, ""),
					new(1202, 439, -90, ""),
					new(1202, 439, -87, ""),
					new(1185, 454, -90, ""),
					new(1185, 453, -90, ""),
					new(1186, 453, -87, ""),
					new(1186, 453, -90, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "Hue=0x849", new DecorationEntry[]
				{
					new(1188, 437, -82, ""),
					new(1190, 437, -90, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "Hue=0x482", new DecorationEntry[]
				{
					new(1189, 437, -86, ""),
				}),
				new("Small Fish", typeof(Static), 3545, "", new DecorationEntry[]
				{
					new(1192, 438, -90, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2711, "", new DecorationEntry[]
				{
					new(1197, 437, -90, ""),
				}),
				
				#endregion
			});
		}
	}
}
