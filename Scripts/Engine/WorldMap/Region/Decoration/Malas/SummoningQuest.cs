using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Malas
		{
			public static DecorationList[] SummoningQuest { get; } = Register(DecorationTarget.Malas, "Summoning Quest", new DecorationList[]
			{
				#region Entries
				
				new("Victoria Spawner", typeof(Spawner), 7955, "Spawn=Victoria;HomeRange=2;Count=1;MinDelay=00:01:00;MinDelay=00:01:00", new DecorationEntry[]
				{
					new(423, 195, -1, ""),
				}),
				new("Altar For Summoning Bone Demons", typeof(SummoningAltar), 4630, "", new DecorationEntry[]
				{
					new(441, 205, -1, ""),
				}),
				new("Bell For Summoning Chyloth", typeof(BellOfTheDead), 2330, "", new DecorationEntry[]
				{
					new(417, 246, 23, ""),
				}),
				new("No Teleporting On Chyloth's Spot", typeof(Blocker), 8612, "", new DecorationEntry[]
				{
					new(417, 246, 7, ""),
				}),
				new("Teleporter (Pad) From First Boat To Second", typeof(Static), 6178, "Hue=0x44E", new DecorationEntry[]
				{
					new(408, 254, 2, ""),
				}),
				new("Teleporter (Obj) From First Boat To Second", typeof(Teleporter), 7107, "PointDest=(428, 318, 2)", new DecorationEntry[]
				{
					new(407, 254, 2, ""),
					new(408, 254, 2, ""),
					new(409, 254, 2, ""),
				}),
				new("Teleporter (Pad) From Second Boat To Land", typeof(Static), 6178, "Hue=0x44E", new DecorationEntry[]
				{
					new(428, 321, 2, ""),
				}),
				new("Teleporter (Obj) From Second Boat To Land", typeof(Teleporter), 7107, "PointDest=(422, 327, -1);DestEffect=true;SoundID=0x1FE", new DecorationEntry[]
				{
					new(427, 321, 2, ""),
					new(428, 321, 2, ""),
					new(429, 321, 2, ""),
				}),
				new("Daemon Bones", typeof(Static), 3968, "", new DecorationEntry[]
				{
					new(421, 198, -1, ""),
					new(422, 195, -1, ""),
				}),
				new("Book - The Akashic Records", typeof(LocalizedStatic), 4030, "Hue=0x482;LabelNumber=1060023", new DecorationEntry[]
				{
					new(420, 192, 8, ""),
				}),
				
				#endregion
			});
		}
	}
}
