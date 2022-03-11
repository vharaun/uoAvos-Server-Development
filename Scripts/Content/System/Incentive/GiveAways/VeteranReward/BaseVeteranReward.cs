using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Multis;
using Server.Network;

using System;
using System.Collections.Generic;

namespace Server.Engines.VeteranRewards
{
	public interface IRewardItem
	{
		bool IsRewardItem { get; set; }
	}

	public partial class RewardSystem
	{
		private static RewardCategory[] m_Categories;
		private static RewardList[] m_Lists;

		public static RewardCategory[] Categories
		{
			get
			{
				if (m_Categories == null)
				{
					SetupRewardTables();
				}

				return m_Categories;
			}
		}

		public static RewardList[] Lists
		{
			get
			{
				if (m_Lists == null)
				{
					SetupRewardTables();
				}

				return m_Lists;
			}
		}

		public static bool Enabled = true; // change to true to enable vet rewards
		public static bool SkillCapRewards = true; // assuming vet rewards are enabled, should total skill cap bonuses be awarded? (720 skills total at 4th level)
		public static TimeSpan RewardInterval = TimeSpan.FromDays(30.0);

		public static bool HasAccess(Mobile mob, RewardCategory category)
		{
			var entries = category.Entries;

			for (var j = 0; j < entries.Count; ++j)
			{
				//RewardEntry entry = entries[j];
				if (RewardSystem.HasAccess(mob, entries[j]))
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasAccess(Mobile mob, RewardEntry entry)
		{
			if (Core.Expansion < entry.RequiredExpansion)
			{
				return false;
			}

			TimeSpan ts;
			return HasAccess(mob, entry.List, out ts);
		}

		public static bool HasAccess(Mobile mob, RewardList list, out TimeSpan ts)
		{
			if (list == null)
			{
				ts = TimeSpan.Zero;
				return false;
			}

			var acct = mob.Account as Account;

			if (acct == null)
			{
				ts = TimeSpan.Zero;
				return false;
			}

			var totalTime = (DateTime.UtcNow - acct.Created);

			ts = (list.Age - totalTime);

			if (ts <= TimeSpan.Zero)
			{
				return true;
			}

			return false;
		}

		public static int GetRewardLevel(Mobile mob)
		{
			var acct = mob.Account as Account;

			if (acct == null)
			{
				return 0;
			}

			return GetRewardLevel(acct);
		}

		public static int GetRewardLevel(Account acct)
		{
			var totalTime = (DateTime.UtcNow - acct.Created);

			var level = (int)(totalTime.TotalDays / RewardInterval.TotalDays);

			if (level < 0)
			{
				level = 0;
			}

			return level;
		}

		public static bool HasHalfLevel(Mobile mob)
		{
			var acct = mob.Account as Account;

			if (acct == null)
			{
				return false;
			}

			return HasHalfLevel(acct);
		}

		public static bool HasHalfLevel(Account acct)
		{
			var totalTime = (DateTime.UtcNow - acct.Created);

			var level = (totalTime.TotalDays / RewardInterval.TotalDays);

			return level >= 0.5;
		}

		public static bool ConsumeRewardPoint(Mobile mob)
		{
			int cur, max;

			ComputeRewardInfo(mob, out cur, out max);

			if (cur >= max)
			{
				return false;
			}

			var acct = mob.Account as Account;

			if (acct == null)
			{
				return false;
			}

			//if ( mob.AccessLevel < AccessLevel.GameMaster )
			acct.SetTag("numRewardsChosen", (cur + 1).ToString());

			return true;
		}

		public static void ComputeRewardInfo(Mobile mob, out int cur, out int max)
		{
			int level;

			ComputeRewardInfo(mob, out cur, out max, out level);
		}

		public static void ComputeRewardInfo(Mobile mob, out int cur, out int max, out int level)
		{
			var acct = mob.Account as Account;

			if (acct == null)
			{
				cur = max = level = 0;
				return;
			}

			level = GetRewardLevel(acct);

			if (level == 0)
			{
				cur = max = 0;
				return;
			}

			var tag = acct.GetTag("numRewardsChosen");

			if (String.IsNullOrEmpty(tag))
			{
				cur = 0;
			}
			else
			{
				cur = Utility.ToInt32(tag);
			}

			if (level >= 6)
			{
				max = 9 + ((level - 6) * 2);
			}
			else
			{
				max = 2 + level;
			}
		}

		public static bool CheckIsUsableBy(Mobile from, Item item, object[] args)
		{
			if (m_Lists == null)
			{
				SetupRewardTables();
			}

			var isRelaxedRules = (item is DyeTub || item is MonsterStatuette);

			var type = item.GetType();

			for (var i = 0; i < m_Lists.Length; ++i)
			{
				var list = m_Lists[i];
				var entries = list.Entries;
				TimeSpan ts;

				for (var j = 0; j < entries.Length; ++j)
				{
					if (entries[j].ItemType == type)
					{
						if (args == null && entries[j].Args.Length == 0)
						{
							if ((!isRelaxedRules || i > 0) && !HasAccess(from, list, out ts))
							{
								from.SendLocalizedMessage(1008126, true, Math.Ceiling(ts.TotalDays / 30.0).ToString()); // Your account is not old enough to use this item. Months until you can use this item : 
								return false;
							}

							return true;
						}

						if (args.Length == entries[j].Args.Length)
						{
							var match = true;

							for (var k = 0; match && k < args.Length; ++k)
							{
								match = (args[k].Equals(entries[j].Args[k]));
							}

							if (match)
							{
								if ((!isRelaxedRules || i > 0) && !HasAccess(from, list, out ts))
								{
									from.SendLocalizedMessage(1008126, true, Math.Ceiling(ts.TotalDays / 30.0).ToString()); // Your account is not old enough to use this item. Months until you can use this item : 
									return false;
								}

								return true;
							}
						}
					}
				}
			}

			// no entry?
			return true;
		}

		public static int GetRewardYearLabel(Item item, object[] args)
		{
			var level = GetRewardYear(item, args);

			return 1076216 + ((level < 10) ? level : (level < 12) ? ((level - 9) + 4240) : ((level - 11) + 37585));
		}

		public static int GetRewardYear(Item item, object[] args)
		{
			if (m_Lists == null)
			{
				SetupRewardTables();
			}

			var type = item.GetType();

			for (var i = 0; i < m_Lists.Length; ++i)
			{
				var list = m_Lists[i];
				var entries = list.Entries;

				for (var j = 0; j < entries.Length; ++j)
				{
					if (entries[j].ItemType == type)
					{
						if (args == null && entries[j].Args.Length == 0)
						{
							return i + 1;
						}

						if (args.Length == entries[j].Args.Length)
						{
							var match = true;

							for (var k = 0; match && k < args.Length; ++k)
							{
								match = (args[k].Equals(entries[j].Args[k]));
							}

							if (match)
							{
								return i + 1;
							}
						}
					}
				}
			}

			// no entry?
			return 0;
		}

		public static void Initialize()
		{
			if (Enabled)
			{
				EventSink.Login += new LoginEventHandler(EventSink_Login);
			}
		}

		private static void EventSink_Login(LoginEventArgs e)
		{
			if (!e.Mobile.Alive)
			{
				return;
			}

			int cur, max, level;

			ComputeRewardInfo(e.Mobile, out cur, out max, out level);

			if (e.Mobile.SkillsCap == 7000 || e.Mobile.SkillsCap == 7050 || e.Mobile.SkillsCap == 7100 || e.Mobile.SkillsCap == 7150 || e.Mobile.SkillsCap == 7200)
			{
				if (level > 4)
				{
					level = 4;
				}
				else if (level < 0)
				{
					level = 0;
				}

				if (SkillCapRewards)
				{
					e.Mobile.SkillsCap = 7000 + (level * 50);
				}
				else
				{
					e.Mobile.SkillsCap = 7000;
				}
			}

			if (Core.ML && e.Mobile is PlayerMobile && !((PlayerMobile)e.Mobile).HasStatReward && HasHalfLevel(e.Mobile))
			{
				((PlayerMobile)e.Mobile).HasStatReward = true;
				e.Mobile.StatCap += 5;
			}

			if (cur < max)
			{
				e.Mobile.SendGump(new RewardNoticeGump(e.Mobile));
			}
		}
	}

	public class RewardEntry
	{
		private RewardList m_List;
		private readonly RewardCategory m_Category;
		private readonly Type m_ItemType;
		private readonly Expansion m_RequiredExpansion;
		private readonly int m_Name;
		private readonly string m_NameString;
		private readonly object[] m_Args;

		public RewardList List { get => m_List; set => m_List = value; }
		public RewardCategory Category => m_Category;
		public Type ItemType => m_ItemType;
		public Expansion RequiredExpansion => m_RequiredExpansion;
		public int Name => m_Name;
		public string NameString => m_NameString;
		public object[] Args => m_Args;

		public Item Construct()
		{
			try
			{
				var item = Activator.CreateInstance(m_ItemType, m_Args) as Item;

				if (item is IRewardItem)
				{
					((IRewardItem)item).IsRewardItem = true;
				}

				return item;
			}
			catch
			{
			}

			return null;
		}

		public RewardEntry(RewardCategory category, int name, Type itemType, params object[] args)
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = Expansion.None;
			m_Name = name;
			m_Args = args;
			category.Entries.Add(this);
		}

		public RewardEntry(RewardCategory category, string name, Type itemType, params object[] args)
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = Expansion.None;
			m_NameString = name;
			m_Args = args;
			category.Entries.Add(this);
		}

		public RewardEntry(RewardCategory category, int name, Type itemType, Expansion requiredExpansion, params object[] args)
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = requiredExpansion;
			m_Name = name;
			m_Args = args;
			category.Entries.Add(this);
		}

		public RewardEntry(RewardCategory category, string name, Type itemType, Expansion requiredExpansion, params object[] args)
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = requiredExpansion;
			m_NameString = name;
			m_Args = args;
			category.Entries.Add(this);
		}
	}

	public class RewardCategory
	{
		private readonly int m_Name;
		private readonly string m_NameString;
		private readonly List<RewardEntry> m_Entries;

		public int Name => m_Name;
		public string NameString => m_NameString;
		public List<RewardEntry> Entries => m_Entries;

		public RewardCategory(int name)
		{
			m_Name = name;
			m_Entries = new List<RewardEntry>();
		}

		public RewardCategory(string name)
		{
			m_NameString = name;
			m_Entries = new List<RewardEntry>();
		}
	}

	public class RewardList
	{
		private readonly TimeSpan m_Age;
		private readonly RewardEntry[] m_Entries;

		public TimeSpan Age => m_Age;
		public RewardEntry[] Entries => m_Entries;

		public RewardList(TimeSpan interval, int index, RewardEntry[] entries)
		{
			m_Age = TimeSpan.FromDays(interval.TotalDays * index);
			m_Entries = entries;

			for (var i = 0; i < entries.Length; ++i)
			{
				entries[i].List = this;
			}
		}
	}

	public class RewardNoticeGump : Gump
	{
		private readonly Mobile m_From;

		public RewardNoticeGump(Mobile from) : base(0, 0)
		{
			m_From = from;

			from.CloseGump(typeof(RewardNoticeGump));

			AddPage(0);

			AddBackground(10, 10, 500, 135, 2600);

			/* You have reward items available.
			 * Click 'ok' below to get the selection menu or 'cancel' to be prompted upon your next login.
			 */
			AddHtmlLocalized(52, 35, 420, 55, 1006046, true, true);

			AddButton(60, 95, 4005, 4007, 1, GumpButtonType.Reply, 0);
			AddHtmlLocalized(95, 96, 150, 35, 1006044, false, false); // Ok

			AddButton(285, 95, 4017, 4019, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(320, 96, 150, 35, 1006045, false, false); // Cancel
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 1)
			{
				m_From.SendGump(new RewardChoiceGump(m_From));
			}
		}
	}

	public class RewardChoiceGump : Gump
	{
		private readonly Mobile m_From;

		private void RenderBackground()
		{
			AddPage(0);

			AddBackground(10, 10, 600, 450, 2600);

			AddButton(530, 415, 4017, 4019, 0, GumpButtonType.Reply, 0);

			AddButton(60, 415, 4014, 4016, 0, GumpButtonType.Page, 1);
			AddHtmlLocalized(95, 415, 200, 20, 1049755, false, false); // Main Menu
		}

		private void RenderCategories()
		{
			var rewardInterval = RewardSystem.RewardInterval;

			string intervalAsString;

			if (rewardInterval == TimeSpan.FromDays(30.0))
			{
				intervalAsString = "month";
			}
			else if (rewardInterval == TimeSpan.FromDays(60.0))
			{
				intervalAsString = "two months";
			}
			else if (rewardInterval == TimeSpan.FromDays(90.0))
			{
				intervalAsString = "three months";
			}
			else if (rewardInterval == TimeSpan.FromDays(365.0))
			{
				intervalAsString = "year";
			}
			else
			{
				intervalAsString = String.Format("{0} day{1}", rewardInterval.TotalDays, rewardInterval.TotalDays == 1 ? "" : "s");
			}

			AddPage(1);

			AddHtml(60, 35, 500, 70, "<B>Ultima Online Rewards Program</B><BR>" +
									"Thank you for being a part of the Ultima Online community for a full " + intervalAsString + ".  " +
									"As a token of our appreciation,  you may select from the following in-game reward items listed below.  " +
									"The gift items will be attributed to the character you have logged-in with on the shard you are on when you chose the item(s).  " +
									"The number of rewards you are entitled to are listed below and are for your entire account.  " +
									"To read more about these rewards before making a selection, feel free to visit the uo.com site at " +
									"<A HREF=\"http://www.uo.com/rewards\">http://www.uo.com/rewards</A>.", true, true);

			int cur, max;

			RewardSystem.ComputeRewardInfo(m_From, out cur, out max);

			AddHtmlLocalized(60, 105, 300, 35, 1006006, false, false); // Your current total of rewards to choose:
			AddLabel(370, 107, 50, (max - cur).ToString());

			AddHtmlLocalized(60, 140, 300, 35, 1006007, false, false); // You have already chosen:
			AddLabel(370, 142, 50, cur.ToString());

			var categories = RewardSystem.Categories;

			var page = 2;

			for (var i = 0; i < categories.Length; ++i)
			{
				if (!RewardSystem.HasAccess(m_From, categories[i]))
				{
					page += 1;
					continue;
				}

				AddButton(100, 180 + (i * 40), 4005, 4005, 0, GumpButtonType.Page, page);

				page += PagesPerCategory(categories[i]);

				if (categories[i].NameString != null)
				{
					AddHtml(135, 180 + (i * 40), 300, 20, categories[i].NameString, false, false);
				}
				else
				{
					AddHtmlLocalized(135, 180 + (i * 40), 300, 20, categories[i].Name, false, false);
				}
			}

			page = 2;

			for (var i = 0; i < categories.Length; ++i)
			{
				RenderCategory(categories[i], i, ref page);
			}
		}

		private int PagesPerCategory(RewardCategory category)
		{
			var entries = category.Entries;
			int j = 0, i = 0;

			for (j = 0; j < entries.Count; j++)
			{
				if (RewardSystem.HasAccess(m_From, entries[j]))
				{
					i++;
				}
			}

			return (int)Math.Ceiling(i / 24.0);
		}

		private int GetButtonID(int type, int index)
		{
			return 2 + (index * 20) + type;
		}

		private void RenderCategory(RewardCategory category, int index, ref int page)
		{
			AddPage(page);

			var entries = category.Entries;

			var i = 0;

			for (var j = 0; j < entries.Count; ++j)
			{
				var entry = entries[j];

				if (!RewardSystem.HasAccess(m_From, entry))
				{
					continue;
				}

				if (i == 24)
				{
					AddButton(305, 415, 0xFA5, 0xFA7, 0, GumpButtonType.Page, ++page);
					AddHtmlLocalized(340, 415, 200, 20, 1011066, false, false); // Next page

					AddPage(page);

					AddButton(270, 415, 0xFAE, 0xFB0, 0, GumpButtonType.Page, page - 1);
					AddHtmlLocalized(185, 415, 200, 20, 1011067, false, false); // Previous page

					i = 0;
				}

				AddButton(55 + ((i / 12) * 250), 80 + ((i % 12) * 25), 5540, 5541, GetButtonID(index, j), GumpButtonType.Reply, 0);

				if (entry.NameString != null)
				{
					AddHtml(80 + ((i / 12) * 250), 80 + ((i % 12) * 25), 250, 20, entry.NameString, false, false);
				}
				else
				{
					AddHtmlLocalized(80 + ((i / 12) * 250), 80 + ((i % 12) * 25), 250, 20, entry.Name, false, false);
				}

				++i;
			}

			page += 1;
		}

		public RewardChoiceGump(Mobile from) : base(0, 0)
		{
			m_From = from;

			from.CloseGump(typeof(RewardChoiceGump));

			RenderBackground();
			RenderCategories();
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var buttonID = info.ButtonID - 1;

			if (buttonID == 0)
			{
				int cur, max;

				RewardSystem.ComputeRewardInfo(m_From, out cur, out max);

				if (cur < max)
				{
					m_From.SendGump(new RewardNoticeGump(m_From));
				}
			}
			else
			{
				--buttonID;

				var type = (buttonID % 20);
				var index = (buttonID / 20);

				var categories = RewardSystem.Categories;

				if (type >= 0 && type < categories.Length)
				{
					var category = categories[type];

					if (index >= 0 && index < category.Entries.Count)
					{
						var entry = category.Entries[index];

						if (!RewardSystem.HasAccess(m_From, entry))
						{
							return;
						}

						m_From.SendGump(new RewardConfirmGump(m_From, entry));
					}
				}
			}
		}
	}

	public class RewardConfirmGump : Gump
	{
		private readonly Mobile m_From;
		private readonly RewardEntry m_Entry;

		public RewardConfirmGump(Mobile from, RewardEntry entry) : base(0, 0)
		{
			m_From = from;
			m_Entry = entry;

			from.CloseGump(typeof(RewardConfirmGump));

			AddPage(0);

			AddBackground(10, 10, 500, 300, 2600);

			AddHtmlLocalized(30, 55, 300, 35, 1006000, false, false); // You have selected:

			if (entry.NameString != null)
			{
				AddHtml(335, 55, 150, 35, entry.NameString, false, false);
			}
			else
			{
				AddHtmlLocalized(335, 55, 150, 35, entry.Name, false, false);
			}

			AddHtmlLocalized(30, 95, 300, 35, 1006001, false, false); // This will be assigned to this character:
			AddLabel(335, 95, 0, from.Name);

			AddHtmlLocalized(35, 160, 450, 90, 1006002, true, true); // Are you sure you wish to select this reward for this character?  You will not be able to transfer this reward to another character on another shard.  Click 'ok' below to confirm your selection or 'cancel' to go back to the selection screen.

			AddButton(60, 265, 4005, 4007, 1, GumpButtonType.Reply, 0);
			AddHtmlLocalized(95, 266, 150, 35, 1006044, false, false); // Ok

			AddButton(295, 265, 4017, 4019, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(330, 266, 150, 35, 1006045, false, false); // Cancel
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 1)
			{
				if (!RewardSystem.HasAccess(m_From, m_Entry))
				{
					return;
				}

				var item = m_Entry.Construct();

				if (item != null)
				{
					if (item is Server.Items.RedSoulstone)
					{
						((Server.Items.RedSoulstone)item).Account = m_From.Account.Username;
					}

					if (RewardSystem.ConsumeRewardPoint(m_From))
					{
						m_From.AddToBackpack(item);
					}
					else
					{
						item.Delete();
					}
				}
			}

			int cur, max;

			RewardSystem.ComputeRewardInfo(m_From, out cur, out max);

			if (cur < max)
			{
				m_From.SendGump(new RewardNoticeGump(m_From));
			}
		}
	}
}

namespace Server.Gumps
{
	public interface IRewardOption
	{
		void GetOptions(RewardOptionList list);
		void OnOptionSelected(Mobile from, int choice);
	}

	public class RewardOptionGump : Gump
	{
		private readonly RewardOptionList m_Options = new RewardOptionList();
		private readonly IRewardOption m_Option;

		public RewardOptionGump(IRewardOption option) : this(option, 0)
		{
		}

		public RewardOptionGump(IRewardOption option, int title) : base(60, 36)
		{
			m_Option = option;

			if (m_Option != null)
			{
				m_Option.GetOptions(m_Options);
			}

			AddPage(0);

			AddBackground(0, 0, 273, 324, 0x13BE);
			AddImageTiled(10, 10, 253, 20, 0xA40);
			AddImageTiled(10, 40, 253, 244, 0xA40);
			AddImageTiled(10, 294, 253, 20, 0xA40);
			AddAlphaRegion(10, 10, 253, 304);

			AddButton(10, 294, 0xFB1, 0xFB2, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(45, 296, 450, 20, 1060051, 0x7FFF, false, false); // CANCEL

			if (title > 0)
			{
				AddHtmlLocalized(14, 12, 273, 20, title, 0x7FFF, false, false);
			}
			else
			{
				AddHtmlLocalized(14, 12, 273, 20, 1080392, 0x7FFF, false, false); // Select your choice from the menu below.
			}

			AddPage(1);

			for (var i = 0; i < m_Options.Count; i++)
			{
				AddButton(19, 49 + i * 24, 0x845, 0x846, m_Options[i].ID, GumpButtonType.Reply, 0);
				AddHtmlLocalized(44, 47 + i * 24, 213, 20, m_Options[i].Cliloc, 0x7FFF, false, false);
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (m_Option != null && Contains(info.ButtonID))
			{
				m_Option.OnOptionSelected(sender.Mobile, info.ButtonID);
			}
		}

		private bool Contains(int chosen)
		{
			if (m_Options == null)
			{
				return false;
			}

			foreach (var option in m_Options)
			{
				if (option.ID == chosen)
				{
					return true;
				}
			}

			return false;
		}
	}

	public class RewardOption
	{
		private readonly int m_ID;
		private readonly int m_Cliloc;

		public int ID => m_ID;
		public int Cliloc => m_Cliloc;

		public RewardOption(int id, int cliloc)
		{
			m_ID = id;
			m_Cliloc = cliloc;
		}
	}

	public class RewardOptionList : List<RewardOption>
	{
		public RewardOptionList() : base()
		{
		}

		public void Add(int id, int cliloc)
		{
			Add(new RewardOption(id, cliloc));
		}
	}

	/// Redeed A Deeded Reward
	public class RewardDemolitionGump : Gump
	{
		private readonly IAddon m_Addon;

		private enum Buttons
		{
			Cancel,
			Confirm,
		}

		public RewardDemolitionGump(IAddon addon, int question) : base(150, 50)
		{
			m_Addon = addon;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddBackground(0, 0, 220, 170, 0x13BE);
			AddBackground(10, 10, 200, 150, 0xBB8);

			AddHtmlLocalized(20, 30, 180, 60, question, false, false); // Do you wish to re-deed this decoration?

			AddHtmlLocalized(55, 100, 150, 25, 1011011, false, false); // CONTINUE
			AddButton(20, 100, 0xFA5, 0xFA7, (int)Buttons.Confirm, GumpButtonType.Reply, 0);

			AddHtmlLocalized(55, 125, 150, 25, 1011012, false, false); // CANCEL
			AddButton(20, 125, 0xFA5, 0xFA7, (int)Buttons.Cancel, GumpButtonType.Reply, 0);
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var item = m_Addon as Item;

			if (item == null || item.Deleted)
			{
				return;
			}

			if (info.ButtonID == (int)Buttons.Confirm)
			{
				var m = sender.Mobile;
				var house = BaseHouse.FindHouseAt(m);

				if (house != null && house.IsOwner(m))
				{
					if (m.InRange(item.Location, 2))
					{
						var deed = m_Addon.Deed;

						if (deed != null)
						{
							m.AddToBackpack(deed);
							house.Addons.Remove(item);
							item.Delete();
						}
					}
					else
					{
						m.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
					}
				}
				else
				{
					m.SendLocalizedMessage(1049784); // You can only re-deed this decoration if you are the house owner or originally placed the decoration.
				}
			}
		}
	}
}