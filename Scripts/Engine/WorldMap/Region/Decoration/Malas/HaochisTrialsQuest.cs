using Server.Engines.Quests.Items;
using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Malas
		{
			public static DecorationList[] HaochisTrialsQuest { get; } = Register(DecorationTarget.Malas, "Haochis Trials Quest", new DecorationList[]
			{
				#region Entries
				
				new("Candle", typeof(HonorCandle), 5171, "Unlit;Unprotected", new DecorationEntry[]
				{
					new(419, 731, 17, ""),
					new(420, 731, 17, ""),
					new(422, 731, 17, ""),
					new(421, 731, 17, ""),
				}),
				new("Stone Pavers", typeof(Static), 1308, "Hue=0xFA", new DecorationEntry[]
				{
					new(389, 704, -1, ""),
					new(426, 780, -1, ""),
					new(331, 769, -1, ""),
					new(355, 745, -1, ""),
					new(330, 706, -1, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(384, 733, -1);MapDest=Malas", new DecorationEntry[]
				{
					new(389, 704, -1, ""),
					new(426, 780, -1, ""),
					new(331, 769, -1, ""),
					new(355, 745, -1, ""),
					new(330, 706, -1, ""),
				}),
				new("Moongate", typeof(Static), 8151, "Hue=0xFA", new DecorationEntry[]
				{
					new(391, 777, -1, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(770, 1209, 25);MapDest=Tokuno", new DecorationEntry[]
				{
					new(391, 777, -1, ""),
				}),
				new("Ankh", typeof(AnkhNorth), 4, "Hue=0xFA", new DecorationEntry[]
				{
					new(351, 733, 18, ""),
					new(388, 724, 13, ""),
				}),
				new("Welcome To Your New Home, Samurai.", typeof(LocalizedSign), 3025, "LabelNumber=1063295", new DecorationEntry[]
				{
					new(369, 777, -1, ""),
				}),
				new("Chest", typeof(HaochisTreasureChest), 10257, "", new DecorationEntry[]
				{
					new(424, 704, 8, ""),
					new(424, 705, 8, ""),
					new(424, 706, 8, ""),
				}),
				new("Katana", typeof(Static), 5119, "Hue=0x482", new DecorationEntry[]
				{
					new(414, 703, 9, ""),
				}),
				new("Haochi's Katana Generator", typeof(HaochisKatanaGenerator), 7035, "", new DecorationEntry[]
				{
					new(415, 703, 1, ""),
				}),
				new("Haochi", typeof(Spawner), 7955, "Spawn=Haochi;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(377, 742, 1, ""),
				}),
				new("Haochi's Guardsmen", typeof(Spawner), 7955, "Spawn=HaochisGuardsman;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(367, 749, -1, ""),
					new(367, 750, -1, ""),
					new(367, 739, -1, ""),
					new(367, 740, -1, ""),
					new(367, 730, -1, ""),
					new(367, 729, -1, ""),
					new(379, 727, -1, ""),
					new(380, 727, -1, ""),
					new(392, 730, -1, ""),
					new(392, 731, -1, ""),
					new(392, 739, -1, ""),
					new(392, 740, -1, ""),
					new(397, 749, -1, ""),
					new(398, 748, -1, ""),
				}),
				new("Deadly Imp", typeof(Spawner), 7955, "Spawn=DeadlyImp;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(342, 736, -1, ""),
				}),
				new("Fierce Dragon", typeof(Spawner), 7955, "Spawn=FierceDragon;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(339, 741, -1, ""),
				}),
				new("Relnia", typeof(Spawner), 7955, "Spawn=Relnia;Count=1;HomeRange=0", new DecorationEntry[]
				{
					new(379, 710, -1, ""),
				}),
				
				#endregion
			});
		}
	}
}
