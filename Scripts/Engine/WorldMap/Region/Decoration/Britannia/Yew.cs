using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Yew { get; } = Register(DecorationTarget.Britannia, "Yew", new DecorationList[]
			{
				#region Entries
				
				new("Ankh", typeof(AnkhNorth), 4, "", new DecorationEntry[]
				{
					new(634, 816, 0, ""),
				}),
				new("Book", typeof(MyStory), 4079, "", new DecorationEntry[]
				{
					new(337, 875, 0, ""),
				}),
				new("Book", typeof(TaleOfThreeTribes), 4079, "", new DecorationEntry[]
				{
					new(472, 840, 0, ""),
				}),
				new("Book", typeof(TamingDragons), 4079, "", new DecorationEntry[]
				{
					new(624, 836, 0, ""),
				}),
				new("Book", typeof(RegardingLlamas), 4079, "", new DecorationEntry[]
				{
					new(624, 842, 0, ""),
				}),
				new("Book", typeof(QuestOfVirtues), 4079, "", new DecorationEntry[]
				{
					new(627, 841, 0, ""),
				}),
				new("Book", typeof(DeceitDungeonOfHorror), 4079, "", new DecorationEntry[]
				{
					new(641, 852, 0, ""),
				}),
				new("Book", typeof(WildGirlOfTheForest), 4080, "", new DecorationEntry[]
				{
					new(337, 873, 0, ""),
				}),
				new("Book", typeof(VirtueBook), 4080, "", new DecorationEntry[]
				{
					new(337, 875, 20, ""),
				}),
				new("Book", typeof(LifeOfATravellingMinstrel), 4080, "", new DecorationEntry[]
				{
					new(338, 884, 20, ""),
				}),
				new("Book", typeof(RedBook), 4081, "", new DecorationEntry[]
				{
					new(336, 877, 6, ""),
					new(337, 883, 20, ""),
					new(338, 873, 20, ""),
					new(476, 840, 0, ""),
					new(625, 852, 0, ""),
					new(628, 836, 0, ""),
					new(640, 819, 26, ""),
					new(641, 849, 0, ""),
					new(643, 850, 6, ""),
				}),
				new("Book", typeof(BlueBook), 4082, "", new DecorationEntry[]
				{
					new(337, 873, 20, ""),
					new(339, 883, 0, ""),
					new(625, 832, 0, ""),
					new(628, 848, 0, ""),
					new(630, 819, 26, ""),
				}),
				new("Book", typeof(MajorTradeAssociation), 4084, "", new DecorationEntry[]
				{
					new(336, 877, 26, ""),
				}),
				new("Book", typeof(ChildrenTalesVol2), 4084, "", new DecorationEntry[]
				{
					new(338, 873, 0, ""),
				}),
				new("Book", typeof(TheFight), 4084, "", new DecorationEntry[]
				{
					new(473, 842, 0, ""),
				}),
				new("Book", typeof(EthicalHedonism), 4084, "", new DecorationEntry[]
				{
					new(562, 810, 4, ""),
				}),
				new("Book", typeof(GrammarOfOrcish), 4084, "", new DecorationEntry[]
				{
					new(631, 819, 26, ""),
				}),
				
				#endregion
			});
		}
	}
}
