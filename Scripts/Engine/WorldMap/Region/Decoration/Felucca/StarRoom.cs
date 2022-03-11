using Server.Engines.CannedEvil;
using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Felucca
		{
			public static DecorationList[] StarRoom { get; } = Register(DecorationTarget.Felucca, "Star Room", new DecorationList[]
			{
				#region Entries
				
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5171, 1586, 0)", new DecorationEntry[]
				{
					new(5140, 1773, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5143, 1774, 0);SoundID=0x1FE", new DecorationEntry[]
				{
					new(5172, 1589, -4, ""),
				}),
				new("Champion Skull Platform", typeof(ChampionSkullPlatform), 1, "", new DecorationEntry[]
				{
					new(5140, 1761, 1, ""),
				}),
				new("Dark Moongate", typeof(LocalizedStatic), 8147, "LabelNumber=1049498;Light=Circle300", new DecorationEntry[]
				{
					new(5172, 1589, -4, ""),
				}),
				new("Music Stand", typeof(Static), 3770, "", new DecorationEntry[]
				{
					new(5155, 1762, 1, ""),
				}),
				new("Music Stand", typeof(Static), 3771, "", new DecorationEntry[]
				{
					new(5151, 1758, 0, ""),
				}),
				new("Sheet Music", typeof(Static), 3775, "", new DecorationEntry[]
				{
					new(5151, 1758, 0, ""),
				}),
				new("Moongate", typeof(PublicMoongate), 3948, "", new DecorationEntry[]
				{
					new(5153, 1760, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
