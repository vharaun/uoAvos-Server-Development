using Server.Accounting;
using Server.Engines.ConPVP;
using Server.Factions;
using Server.Mobiles;
using Server.Network;

using System;
using System.Collections;
using System.Threading;

namespace Server.Engines.Reports
{
	public class Reports
	{
		public static bool Enabled = false;

		public static void Initialize()
		{
			if (!Enabled)
			{
				return;
			}

			m_StatsHistory = new SnapshotHistory();
			m_StatsHistory.Load();

			m_StaffHistory = new StaffHistory();
			m_StaffHistory.Load();

			var now = DateTime.UtcNow;

			var date = now.Date;
			var timeOfDay = now.TimeOfDay;

			m_GenerateTime = date + TimeSpan.FromHours(Math.Ceiling(timeOfDay.TotalHours));

			Timer.DelayCall(TimeSpan.FromMinutes(0.5), TimeSpan.FromMinutes(0.5), CheckRegenerate);
		}

		private static DateTime m_GenerateTime;

		public static void CheckRegenerate()
		{
			if (DateTime.UtcNow < m_GenerateTime)
			{
				return;
			}

			Generate();
			m_GenerateTime += TimeSpan.FromHours(1.0);
		}

		private static SnapshotHistory m_StatsHistory;
		private static StaffHistory m_StaffHistory;

		public static StaffHistory StaffHistory => m_StaffHistory;

		public static void Generate()
		{
			var ss = new Snapshot {
				TimeStamp = DateTime.UtcNow
			};

			FillSnapshot(ss);

			m_StatsHistory.Snapshots.Add(ss);
			m_StaffHistory.QueueStats.Add(new QueueStatus(Engines.Help.PageQueue.List.Count));

			ThreadPool.QueueUserWorkItem(new WaitCallback(UpdateOutput), ss);
		}

		private static void UpdateOutput(object state)
		{
			m_StatsHistory.Save();
			m_StaffHistory.Save();

#if !MONO
			var renderer = new HtmlRenderer("stats", (Snapshot)state, m_StatsHistory);
			renderer.Render();
			renderer.Upload();

			renderer = new HtmlRenderer("staff", m_StaffHistory);
			renderer.Render();
			renderer.Upload();
#endif
		}

		public static void FillSnapshot(Snapshot ss)
		{
			ss.Children.Add(CompileGeneralStats());
			ss.Children.Add(CompilePCByDL());
			ss.Children.Add(CompileTop15());
			ss.Children.Add(CompileDislikedArenas());
			ss.Children.Add(CompileStatChart());

			var obs = CompileSkillReports();

			for (var i = 0; i < obs.Length; ++i)
			{
				ss.Children.Add(obs[i]);
			}

			obs = CompileFactionReports();

			for (var i = 0; i < obs.Length; ++i)
			{
				ss.Children.Add(obs[i]);
			}
		}

		public static Report CompileGeneralStats()
		{
			var report = new Report("General Stats", "200");

			report.Columns.Add("50%", "left");
			report.Columns.Add("50%", "left");

			int npcs = 0, players = 0;

			foreach (var mob in World.Mobiles.Values)
			{
				if (mob.Player)
				{
					++players;
				}
				else
				{
					++npcs;
				}
			}

			report.Items.Add("NPCs", npcs, "N0");
			report.Items.Add("Players", players, "N0");
			report.Items.Add("Clients", NetState.Instances.Count, "N0");
			report.Items.Add("Accounts", Accounts.Count, "N0");
			report.Items.Add("Items", World.Items.Count, "N0");

			return report;
		}

		private static Chart CompilePCByDL()
		{
			var chart = new BarGraph("Player Count By Dueling Level", "graphs_pc_by_dl", 5, "Dueling Level", "Players", BarGraphRenderMode.Bars);

			var lastLevel = -1;
			ChartItem lastItem = null;

			var ladder = Ladder.Instance;

			if (ladder != null)
			{
				var entries = ladder.ToArrayList();

				for (var i = entries.Count - 1; i >= 0; --i)
				{
					var entry = (LadderEntry)entries[i];
					var level = Ladder.GetLevel(entry.Experience);

					if (lastItem == null || level != lastLevel)
					{
						chart.Items.Add(lastItem = new ChartItem(level.ToString(), 1));
						lastLevel = level;
					}
					else
					{
						lastItem.Value++;
					}
				}
			}

			return chart;
		}

		private static Report CompileTop15()
		{
			var report = new Report("Top 15 Duelists", "80%");

			report.Columns.Add("6%", "center", "Rank");
			report.Columns.Add("6%", "center", "Level");
			report.Columns.Add("6%", "center", "Guild");
			report.Columns.Add("70%", "left", "Name");
			report.Columns.Add("6%", "center", "Wins");
			report.Columns.Add("6%", "center", "Losses");

			var ladder = Ladder.Instance;

			if (ladder != null)
			{
				var entries = ladder.ToArrayList();

				for (var i = 0; i < entries.Count && i < 15; ++i)
				{
					var entry = (LadderEntry)entries[i];
					var level = Ladder.GetLevel(entry.Experience);
					var guild = "";

					if (entry.Mobile.Guild != null)
					{
						guild = entry.Mobile.Guild.Abbreviation;
					}

					var item = new ReportItem();

					item.Values.Add(LadderGump.Rank(entry.Index + 1));
					item.Values.Add(level.ToString(), "N0");
					item.Values.Add(guild);
					item.Values.Add(entry.Mobile.Name);
					item.Values.Add(entry.Wins.ToString(), "N0");
					item.Values.Add(entry.Losses.ToString(), "N0");

					report.Items.Add(item);
				}
			}

			return report;
		}

		private static Chart CompileDislikedArenas()
		{
			var chart = new PieChart("Most Disliked Arenas", "graphs_arenas_disliked", false);

			var prefs = Preferences.Instance;

			if (prefs != null)
			{
				var arenas = Arena.Arenas;

				for (var i = 0; i < arenas.Count; ++i)
				{
					var arena = arenas[i];

					var name = arena.Name;

					if (name != null)
					{
						chart.Items.Add(name, 0);
					}
				}

				var entries = prefs.Entries;

				for (var i = 0; i < entries.Count; ++i)
				{
					var entry = (PreferencesEntry)entries[i];
					var list = entry.Disliked;

					for (var j = 0; j < list.Count; ++j)
					{
						var disliked = (string)list[j];

						for (var k = 0; k < chart.Items.Count; ++k)
						{
							var item = chart.Items[k];

							if (item.Name == disliked)
							{
								++item.Value;
								break;
							}
						}
					}
				}
			}

			return chart;
		}

		public static Chart CompileStatChart()
		{
			var chart = new PieChart("Stat Distribution", "graphs_strdexint_distrib", true);

			var strItem = new ChartItem("Strength", 0);
			var dexItem = new ChartItem("Dexterity", 0);
			var intItem = new ChartItem("Intelligence", 0);

			foreach (var mob in World.Mobiles.Values)
			{
				if (mob.RawStatTotal == mob.StatCap && mob is PlayerMobile)
				{
					strItem.Value += mob.RawStr;
					dexItem.Value += mob.RawDex;
					intItem.Value += mob.RawInt;
				}
			}

			chart.Items.Add(strItem);
			chart.Items.Add(dexItem);
			chart.Items.Add(intItem);

			return chart;
		}

		public class SkillDistribution : IComparable
		{
			public SkillInfo m_Skill;
			public int m_NumberOfGMs;

			public SkillDistribution(SkillInfo skill)
			{
				m_Skill = skill;
			}

			public int CompareTo(object obj)
			{
				return (((SkillDistribution)obj).m_NumberOfGMs - m_NumberOfGMs);
			}
		}

		public static SkillDistribution[] GetSkillDistribution()
		{
			var skip = (Core.ML ? 0 : Core.SE ? 1 : Core.AOS ? 3 : 6);

			var distribs = new SkillDistribution[SkillInfo.Table.Length - skip];

			for (var i = 0; i < distribs.Length; ++i)
			{
				distribs[i] = new SkillDistribution(SkillInfo.Table[i]);
			}

			foreach (var mob in World.Mobiles.Values)
			{
				if (mob.SkillsTotal >= 1500 && mob.SkillsTotal <= 7200 && mob is PlayerMobile)
				{
					var skills = mob.Skills;

					for (var i = 0; i < skills.Length - skip; ++i)
					{
						var skill = skills[i];

						if (skill.BaseFixedPoint >= 1000)
						{
							distribs[i].m_NumberOfGMs++;
						}
					}
				}
			}

			return distribs;
		}

		public static PersistableObject[] CompileSkillReports()
		{
			var distribs = GetSkillDistribution();

			Array.Sort(distribs);

			return new PersistableObject[] { CompileSkillChart(distribs), CompileSkillReport(distribs) };
		}

		public static Report CompileSkillReport(SkillDistribution[] distribs)
		{
			var report = new Report("Skill Report", "300");

			report.Columns.Add("70%", "left", "Name");
			report.Columns.Add("30%", "center", "GMs");

			for (var i = 0; i < distribs.Length; ++i)
			{
				report.Items.Add(distribs[i].m_Skill.Name, distribs[i].m_NumberOfGMs, "N0");
			}

			return report;
		}

		public static Chart CompileSkillChart(SkillDistribution[] distribs)
		{
			var chart = new PieChart("GM Skill Distribution", "graphs_skill_distrib", true);

			for (var i = 0; i < 12; ++i)
			{
				chart.Items.Add(distribs[i].m_Skill.Name, distribs[i].m_NumberOfGMs);
			}

			var rem = 0;

			for (var i = 12; i < distribs.Length; ++i)
			{
				rem += distribs[i].m_NumberOfGMs;
			}

			chart.Items.Add("Other", rem);

			return chart;
		}

		public static PersistableObject[] CompileFactionReports()
		{
			return new PersistableObject[] { CompileFactionMembershipChart(), CompileFactionReport(), CompileFactionTownReport(), CompileSigilReport(), CompileFactionLeaderboard() };
		}

		public static Chart CompileFactionMembershipChart()
		{
			var chart = new PieChart("Faction Membership", "graphs_faction_membership", true);

			var factions = Faction.Factions;

			for (var i = 0; i < factions.Count; ++i)
			{
				chart.Items.Add(factions[i].Definition.FriendlyName, factions[i].Members.Count);
			}

			return chart;
		}

		public static Report CompileFactionLeaderboard()
		{
			var report = new Report("Faction Leaderboard", "60%");

			report.Columns.Add("28%", "center", "Name");
			report.Columns.Add("28%", "center", "Faction");
			report.Columns.Add("28%", "center", "Office");
			report.Columns.Add("16%", "center", "Kill Points");

			var list = new ArrayList();

			var factions = Faction.Factions;

			for (var i = 0; i < factions.Count; ++i)
			{
				var faction = factions[i];

				list.AddRange(faction.Members);
			}

			list.Sort();
			list.Reverse();

			for (var i = 0; i < list.Count && i < 15; ++i)
			{
				var pl = (PlayerState)list[i];

				string office;

				if (pl.Faction.Commander == pl.Mobile)
				{
					office = "Commanding Lord";
				}
				else if (pl.Finance != null)
				{
					office = String.Format("{0} Finance Minister", pl.Finance.Definition.FriendlyName);
				}
				else if (pl.Sheriff != null)
				{
					office = String.Format("{0} Sheriff", pl.Sheriff.Definition.FriendlyName);
				}
				else
				{
					office = "";
				}

				var item = new ReportItem();

				item.Values.Add(pl.Mobile.Name);
				item.Values.Add(pl.Faction.Definition.FriendlyName);
				item.Values.Add(office);
				item.Values.Add(pl.KillPoints.ToString(), "N0");

				report.Items.Add(item);
			}

			return report;
		}

		public static Report CompileFactionReport()
		{
			var report = new Report("Faction Statistics", "80%");

			report.Columns.Add("20%", "center", "Name");
			report.Columns.Add("20%", "center", "Commander");
			report.Columns.Add("15%", "center", "Members");
			report.Columns.Add("15%", "center", "Merchants");
			report.Columns.Add("15%", "center", "Kill Points");
			report.Columns.Add("15%", "center", "Silver");

			var factions = Faction.Factions;

			for (var i = 0; i < factions.Count; ++i)
			{
				var faction = factions[i];
				var members = faction.Members;

				var totalKillPoints = 0;
				var totalMerchants = 0;

				for (var j = 0; j < members.Count; ++j)
				{
					totalKillPoints += members[j].KillPoints;

					if (members[j].MerchantTitle != MerchantTitle.None)
					{
						++totalMerchants;
					}
				}

				var item = new ReportItem();

				item.Values.Add(faction.Definition.FriendlyName);
				item.Values.Add(faction.Commander == null ? "" : faction.Commander.Name);
				item.Values.Add(faction.Members.Count.ToString(), "N0");
				item.Values.Add(totalMerchants.ToString(), "N0");
				item.Values.Add(totalKillPoints.ToString(), "N0");
				item.Values.Add(faction.Silver.ToString(), "N0");

				report.Items.Add(item);
			}

			return report;
		}

		public static Report CompileSigilReport()
		{
			var report = new Report("Faction Town Sigils", "50%");

			report.Columns.Add("35%", "center", "Town");
			report.Columns.Add("35%", "center", "Controller");
			report.Columns.Add("30%", "center", "Capturable");

			var sigils = Sigil.Sigils;

			for (var i = 0; i < sigils.Count; ++i)
			{
				var sigil = sigils[i];

				var controller = "Unknown";

				var mob = sigil.RootParent as Mobile;

				if (mob != null)
				{
					var faction = Faction.Find(mob);

					if (faction != null)
					{
						controller = faction.Definition.FriendlyName;
					}
				}
				else if (sigil.LastMonolith != null && sigil.LastMonolith.Faction != null)
				{
					controller = sigil.LastMonolith.Faction.Definition.FriendlyName;
				}

				var item = new ReportItem();

				item.Values.Add(sigil.Town == null ? "" : sigil.Town.Definition.FriendlyName);
				item.Values.Add(controller);
				item.Values.Add(sigil.IsPurifying ? "No" : "Yes");

				report.Items.Add(item);
			}

			return report;
		}

		public static Report CompileFactionTownReport()
		{
			var report = new Report("Faction Towns", "80%");

			report.Columns.Add("20%", "center", "Name");
			report.Columns.Add("20%", "center", "Owner");
			report.Columns.Add("17%", "center", "Sheriff");
			report.Columns.Add("17%", "center", "Finance Minister");
			report.Columns.Add("13%", "center", "Silver");
			report.Columns.Add("13%", "center", "Prices");

			var towns = Town.Towns;

			for (var i = 0; i < towns.Count; ++i)
			{
				var town = towns[i];

				var prices = "Normal";

				if (town.Tax < 0)
				{
					prices = town.Tax.ToString() + "%";
				}
				else if (town.Tax > 0)
				{
					prices = "+" + town.Tax.ToString() + "%";
				}

				var item = new ReportItem();

				item.Values.Add(town.Definition.FriendlyName);
				item.Values.Add(town.Owner == null ? "Neutral" : town.Owner.Definition.FriendlyName);
				item.Values.Add(town.Sheriff == null ? "" : town.Sheriff.Name);
				item.Values.Add(town.Finance == null ? "" : town.Finance.Name);
				item.Values.Add(town.Silver.ToString(), "N0");
				item.Values.Add(prices);

				report.Items.Add(item);
			}

			return report;
		}
	}

	#region Report Engine

	public class Report : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType("rp", new ConstructCallback(Construct));

		private static PersistableObject Construct()
		{
			return new Report();
		}

		public override PersistableType TypeID => ThisTypeID;
		#endregion

		private string m_Name;
		private string m_Width;
		private readonly ReportColumnCollection m_Columns;
		private readonly ReportItemCollection m_Items;

		public string Name { get => m_Name; set => m_Name = value; }
		public string Width { get => m_Width; set => m_Width = value; }
		public ReportColumnCollection Columns => m_Columns;
		public ReportItemCollection Items => m_Items;

		private Report() : this(null, null)
		{
		}

		public Report(string name, string width)
		{
			m_Name = name;
			m_Width = width;
			m_Columns = new ReportColumnCollection();
			m_Items = new ReportItemCollection();
		}

		public override void SerializeAttributes(PersistanceWriter op)
		{
			op.SetString("n", m_Name);
			op.SetString("w", m_Width);
		}

		public override void DeserializeAttributes(PersistanceReader ip)
		{
			m_Name = Utility.Intern(ip.GetString("n"));
			m_Width = Utility.Intern(ip.GetString("w"));
		}

		public override void SerializeChildren(PersistanceWriter op)
		{
			for (var i = 0; i < m_Columns.Count; ++i)
			{
				m_Columns[i].Serialize(op);
			}

			for (var i = 0; i < m_Items.Count; ++i)
			{
				m_Items[i].Serialize(op);
			}
		}

		public override void DeserializeChildren(PersistanceReader ip)
		{
			while (ip.HasChild)
			{
				var child = ip.GetChild();

				if (child is ReportColumn)
				{
					m_Columns.Add((ReportColumn)child);
				}
				else if (child is ReportItem)
				{
					m_Items.Add((ReportItem)child);
				}
			}
		}
	}

	public class ReportColumn : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType("rc", new ConstructCallback(Construct));

		private static PersistableObject Construct()
		{
			return new ReportColumn();
		}

		public override PersistableType TypeID => ThisTypeID;
		#endregion

		private string m_Width;
		private string m_Align;
		private string m_Name;

		public string Width { get => m_Width; set => m_Width = value; }
		public string Align { get => m_Align; set => m_Align = value; }
		public string Name { get => m_Name; set => m_Name = value; }

		private ReportColumn()
		{
		}

		public ReportColumn(string width, string align) : this(width, align, null)
		{
		}

		public ReportColumn(string width, string align, string name)
		{
			m_Width = width;
			m_Align = align;
			m_Name = name;
		}

		public override void SerializeAttributes(PersistanceWriter op)
		{
			op.SetString("w", m_Width);
			op.SetString("a", m_Align);
			op.SetString("n", m_Name);
		}

		public override void DeserializeAttributes(PersistanceReader ip)
		{
			m_Width = Utility.Intern(ip.GetString("w"));
			m_Align = Utility.Intern(ip.GetString("a"));
			m_Name = Utility.Intern(ip.GetString("n"));
		}
	}

	/// <summary>
	/// Strongly typed collection of Server.Engines.Reports.ReportColumn.
	/// </summary>
	public class ReportColumnCollection : System.Collections.CollectionBase
	{

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ReportColumnCollection() :
				base()
		{
		}

		/// <summary>
		/// Gets or sets the value of the Server.Engines.Reports.ReportColumn at a specific position in the ReportColumnCollection.
		/// </summary>
		public Server.Engines.Reports.ReportColumn this[int index]
		{
			get => ((Server.Engines.Reports.ReportColumn)(List[index]));
			set => List[index] = value;
		}

		public int Add(string width, string align)
		{
			return Add(new ReportColumn(width, align));
		}

		public int Add(string width, string align, string name)
		{
			return Add(new ReportColumn(width, align, name));
		}

		/// <summary>
		/// Append a Server.Engines.Reports.ReportColumn entry to this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ReportColumn instance.</param>
		/// <returns>The position into which the new element was inserted.</returns>
		public int Add(Server.Engines.Reports.ReportColumn value)
		{
			return List.Add(value);
		}

		/// <summary>
		/// Determines whether a specified Server.Engines.Reports.ReportColumn instance is in this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ReportColumn instance to search for.</param>
		/// <returns>True if the Server.Engines.Reports.ReportColumn instance is in the collection; otherwise false.</returns>
		public bool Contains(Server.Engines.Reports.ReportColumn value)
		{
			return List.Contains(value);
		}

		/// <summary>
		/// Retrieve the index a specified Server.Engines.Reports.ReportColumn instance is in this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ReportColumn instance to find.</param>
		/// <returns>The zero-based index of the specified Server.Engines.Reports.ReportColumn instance. If the object is not found, the return value is -1.</returns>
		public int IndexOf(Server.Engines.Reports.ReportColumn value)
		{
			return List.IndexOf(value);
		}

		/// <summary>
		/// Removes a specified Server.Engines.Reports.ReportColumn instance from this collection.
		/// </summary>
		/// <param name="value">The Server.Engines.Reports.ReportColumn instance to remove.</param>
		public void Remove(Server.Engines.Reports.ReportColumn value)
		{
			List.Remove(value);
		}

		/// <summary>
		/// Returns an enumerator that can iterate through the Server.Engines.Reports.ReportColumn instance.
		/// </summary>
		/// <returns>An Server.Engines.Reports.ReportColumn's enumerator.</returns>
		public new ReportColumnCollectionEnumerator GetEnumerator()
		{
			return new ReportColumnCollectionEnumerator(this);
		}

		/// <summary>
		/// Insert a Server.Engines.Reports.ReportColumn instance into this collection at a specified index.
		/// </summary>
		/// <param name="index">Zero-based index.</param>
		/// <param name="value">The Server.Engines.Reports.ReportColumn instance to insert.</param>
		public void Insert(int index, Server.Engines.Reports.ReportColumn value)
		{
			List.Insert(index, value);
		}

		/// <summary>
		/// Strongly typed enumerator of Server.Engines.Reports.ReportColumn.
		/// </summary>
		public class ReportColumnCollectionEnumerator : System.Collections.IEnumerator
		{

			/// <summary>
			/// Current index
			/// </summary>
			private int _index;

			/// <summary>
			/// Current element pointed to.
			/// </summary>
			private Server.Engines.Reports.ReportColumn _currentElement;

			/// <summary>
			/// Collection to enumerate.
			/// </summary>
			private readonly ReportColumnCollection _collection;

			/// <summary>
			/// Default constructor for enumerator.
			/// </summary>
			/// <param name="collection">Instance of the collection to enumerate.</param>
			internal ReportColumnCollectionEnumerator(ReportColumnCollection collection)
			{
				_index = -1;
				_collection = collection;
			}

			/// <summary>
			/// Gets the Server.Engines.Reports.ReportColumn object in the enumerated ReportColumnCollection currently indexed by this instance.
			/// </summary>
			public Server.Engines.Reports.ReportColumn Current
			{
				get
				{
					if (((_index == -1)
								|| (_index >= _collection.Count)))
					{
						throw new System.IndexOutOfRangeException("Enumerator not started.");
					}
					else
					{
						return _currentElement;
					}
				}
			}

			/// <summary>
			/// Gets the current element in the collection.
			/// </summary>
			object IEnumerator.Current
			{
				get
				{
					if (((_index == -1)
								|| (_index >= _collection.Count)))
					{
						throw new System.IndexOutOfRangeException("Enumerator not started.");
					}
					else
					{
						return _currentElement;
					}
				}
			}

			/// <summary>
			/// Reset the cursor, so it points to the beginning of the enumerator.
			/// </summary>
			public void Reset()
			{
				_index = -1;
				_currentElement = null;
			}

			/// <summary>
			/// Advances the enumerator to the next queue of the enumeration, if one is currently available.
			/// </summary>
			/// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
			public bool MoveNext()
			{
				if ((_index
							< (_collection.Count - 1)))
				{
					_index = (_index + 1);
					_currentElement = _collection[_index];
					return true;
				}
				_index = _collection.Count;
				return false;
			}
		}
	}


	public class ItemValue : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType("iv", new ConstructCallback(Construct));

		private static PersistableObject Construct()
		{
			return new ItemValue();
		}

		public override PersistableType TypeID => ThisTypeID;
		#endregion

		private string m_Value;
		private string m_Format;

		public string Value { get => m_Value; set => m_Value = value; }
		public string Format { get => m_Format; set => m_Format = value; }

		private ItemValue()
		{
		}

		public ItemValue(string value) : this(value, null)
		{
		}

		public ItemValue(string value, string format)
		{
			m_Value = value;
			m_Format = format;
		}

		public override void SerializeAttributes(PersistanceWriter op)
		{
			op.SetString("v", m_Value);
			op.SetString("f", m_Format);
		}

		public override void DeserializeAttributes(PersistanceReader ip)
		{
			m_Value = ip.GetString("v");
			m_Format = Utility.Intern(ip.GetString("f"));

			if (m_Format == null)
			{
				Utility.Intern(ref m_Value);
			}
		}
	}

	/// <summary>
	/// Strongly typed collection of Server.Engines.Reports.ItemValue.
	/// </summary>
	public class ItemValueCollection : System.Collections.CollectionBase
	{

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ItemValueCollection() :
				base()
		{
		}

		/// <summary>
		/// Gets or sets the value of the Server.Engines.Reports.ItemValue at a specific position in the ItemValueCollection.
		/// </summary>
		public Server.Engines.Reports.ItemValue this[int index]
		{
			get => ((Server.Engines.Reports.ItemValue)(List[index]));
			set => List[index] = value;
		}

		public int Add(string value)
		{
			return Add(new ItemValue(value));
		}

		public int Add(string value, string format)
		{
			return Add(new ItemValue(value, format));
		}

		/// <summary>
		/// Append a Server.Engines.Reports.ItemValue entry to this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ItemValue instance.</param>
		/// <returns>The position into which the new element was inserted.</returns>
		public int Add(Server.Engines.Reports.ItemValue value)
		{
			return List.Add(value);
		}

		/// <summary>
		/// Determines whether a specified Server.Engines.Reports.ItemValue instance is in this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ItemValue instance to search for.</param>
		/// <returns>True if the Server.Engines.Reports.ItemValue instance is in the collection; otherwise false.</returns>
		public bool Contains(Server.Engines.Reports.ItemValue value)
		{
			return List.Contains(value);
		}

		/// <summary>
		/// Retrieve the index a specified Server.Engines.Reports.ItemValue instance is in this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ItemValue instance to find.</param>
		/// <returns>The zero-based index of the specified Server.Engines.Reports.ItemValue instance. If the object is not found, the return value is -1.</returns>
		public int IndexOf(Server.Engines.Reports.ItemValue value)
		{
			return List.IndexOf(value);
		}

		/// <summary>
		/// Removes a specified Server.Engines.Reports.ItemValue instance from this collection.
		/// </summary>
		/// <param name="value">The Server.Engines.Reports.ItemValue instance to remove.</param>
		public void Remove(Server.Engines.Reports.ItemValue value)
		{
			List.Remove(value);
		}

		/// <summary>
		/// Returns an enumerator that can iterate through the Server.Engines.Reports.ItemValue instance.
		/// </summary>
		/// <returns>An Server.Engines.Reports.ItemValue's enumerator.</returns>
		public new ItemValueCollectionEnumerator GetEnumerator()
		{
			return new ItemValueCollectionEnumerator(this);
		}

		/// <summary>
		/// Insert a Server.Engines.Reports.ItemValue instance into this collection at a specified index.
		/// </summary>
		/// <param name="index">Zero-based index.</param>
		/// <param name="value">The Server.Engines.Reports.ItemValue instance to insert.</param>
		public void Insert(int index, Server.Engines.Reports.ItemValue value)
		{
			List.Insert(index, value);
		}

		/// <summary>
		/// Strongly typed enumerator of Server.Engines.Reports.ItemValue.
		/// </summary>
		public class ItemValueCollectionEnumerator : System.Collections.IEnumerator
		{

			/// <summary>
			/// Current index
			/// </summary>
			private int _index;

			/// <summary>
			/// Current element pointed to.
			/// </summary>
			private Server.Engines.Reports.ItemValue _currentElement;

			/// <summary>
			/// Collection to enumerate.
			/// </summary>
			private readonly ItemValueCollection _collection;

			/// <summary>
			/// Default constructor for enumerator.
			/// </summary>
			/// <param name="collection">Instance of the collection to enumerate.</param>
			internal ItemValueCollectionEnumerator(ItemValueCollection collection)
			{
				_index = -1;
				_collection = collection;
			}

			/// <summary>
			/// Gets the Server.Engines.Reports.ItemValue object in the enumerated ItemValueCollection currently indexed by this instance.
			/// </summary>
			public Server.Engines.Reports.ItemValue Current
			{
				get
				{
					if (((_index == -1)
								|| (_index >= _collection.Count)))
					{
						throw new System.IndexOutOfRangeException("Enumerator not started.");
					}
					else
					{
						return _currentElement;
					}
				}
			}

			/// <summary>
			/// Gets the current element in the collection.
			/// </summary>
			object IEnumerator.Current
			{
				get
				{
					if (((_index == -1)
								|| (_index >= _collection.Count)))
					{
						throw new System.IndexOutOfRangeException("Enumerator not started.");
					}
					else
					{
						return _currentElement;
					}
				}
			}

			/// <summary>
			/// Reset the cursor, so it points to the beginning of the enumerator.
			/// </summary>
			public void Reset()
			{
				_index = -1;
				_currentElement = null;
			}

			/// <summary>
			/// Advances the enumerator to the next queue of the enumeration, if one is currently available.
			/// </summary>
			/// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
			public bool MoveNext()
			{
				if ((_index
							< (_collection.Count - 1)))
				{
					_index = (_index + 1);
					_currentElement = _collection[_index];
					return true;
				}
				_index = _collection.Count;
				return false;
			}
		}
	}

	public class ReportItem : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType("ri", new ConstructCallback(Construct));

		private static PersistableObject Construct()
		{
			return new ReportItem();
		}

		public override PersistableType TypeID => ThisTypeID;
		#endregion

		private readonly ItemValueCollection m_Values;

		public ItemValueCollection Values => m_Values;

		public ReportItem()
		{
			m_Values = new ItemValueCollection();
		}

		public override void SerializeChildren(PersistanceWriter op)
		{
			for (var i = 0; i < m_Values.Count; ++i)
			{
				m_Values[i].Serialize(op);
			}
		}

		public override void DeserializeChildren(PersistanceReader ip)
		{
			while (ip.HasChild)
			{
				m_Values.Add(ip.GetChild() as ItemValue);
			}
		}
	}

	/// <summary>
	/// Strongly typed collection of Server.Engines.Reports.ReportItem.
	/// </summary>
	public class ReportItemCollection : System.Collections.CollectionBase
	{

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ReportItemCollection() :
				base()
		{
		}

		/// <summary>
		/// Gets or sets the value of the Server.Engines.Reports.ReportItem at a specific position in the ReportItemCollection.
		/// </summary>
		public Server.Engines.Reports.ReportItem this[int index]
		{
			get => ((Server.Engines.Reports.ReportItem)(List[index]));
			set => List[index] = value;
		}

		public int Add(string name, object value)
		{
			return Add(name, value, null);
		}

		public int Add(string name, object value, string format)
		{
			var item = new ReportItem();

			item.Values.Add(name);
			item.Values.Add(value == null ? "" : value.ToString(), format);

			return Add(item);
		}

		/// <summary>
		/// Append a Server.Engines.Reports.ReportItem entry to this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ReportItem instance.</param>
		/// <returns>The position into which the new element was inserted.</returns>
		public int Add(Server.Engines.Reports.ReportItem value)
		{
			return List.Add(value);
		}

		/// <summary>
		/// Determines whether a specified Server.Engines.Reports.ReportItem instance is in this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ReportItem instance to search for.</param>
		/// <returns>True if the Server.Engines.Reports.ReportItem instance is in the collection; otherwise false.</returns>
		public bool Contains(Server.Engines.Reports.ReportItem value)
		{
			return List.Contains(value);
		}

		/// <summary>
		/// Retrieve the index a specified Server.Engines.Reports.ReportItem instance is in this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ReportItem instance to find.</param>
		/// <returns>The zero-based index of the specified Server.Engines.Reports.ReportItem instance. If the object is not found, the return value is -1.</returns>
		public int IndexOf(Server.Engines.Reports.ReportItem value)
		{
			return List.IndexOf(value);
		}

		/// <summary>
		/// Removes a specified Server.Engines.Reports.ReportItem instance from this collection.
		/// </summary>
		/// <param name="value">The Server.Engines.Reports.ReportItem instance to remove.</param>
		public void Remove(Server.Engines.Reports.ReportItem value)
		{
			List.Remove(value);
		}

		/// <summary>
		/// Returns an enumerator that can iterate through the Server.Engines.Reports.ReportItem instance.
		/// </summary>
		/// <returns>An Server.Engines.Reports.ReportItem's enumerator.</returns>
		public new ReportItemCollectionEnumerator GetEnumerator()
		{
			return new ReportItemCollectionEnumerator(this);
		}

		/// <summary>
		/// Insert a Server.Engines.Reports.ReportItem instance into this collection at a specified index.
		/// </summary>
		/// <param name="index">Zero-based index.</param>
		/// <param name="value">The Server.Engines.Reports.ReportItem instance to insert.</param>
		public void Insert(int index, Server.Engines.Reports.ReportItem value)
		{
			List.Insert(index, value);
		}

		/// <summary>
		/// Strongly typed enumerator of Server.Engines.Reports.ReportItem.
		/// </summary>
		public class ReportItemCollectionEnumerator : System.Collections.IEnumerator
		{

			/// <summary>
			/// Current index
			/// </summary>
			private int _index;

			/// <summary>
			/// Current element pointed to.
			/// </summary>
			private Server.Engines.Reports.ReportItem _currentElement;

			/// <summary>
			/// Collection to enumerate.
			/// </summary>
			private readonly ReportItemCollection _collection;

			/// <summary>
			/// Default constructor for enumerator.
			/// </summary>
			/// <param name="collection">Instance of the collection to enumerate.</param>
			internal ReportItemCollectionEnumerator(ReportItemCollection collection)
			{
				_index = -1;
				_collection = collection;
			}

			/// <summary>
			/// Gets the Server.Engines.Reports.ReportItem object in the enumerated ReportItemCollection currently indexed by this instance.
			/// </summary>
			public Server.Engines.Reports.ReportItem Current
			{
				get
				{
					if (((_index == -1)
								|| (_index >= _collection.Count)))
					{
						throw new System.IndexOutOfRangeException("Enumerator not started.");
					}
					else
					{
						return _currentElement;
					}
				}
			}

			/// <summary>
			/// Gets the current element in the collection.
			/// </summary>
			object IEnumerator.Current
			{
				get
				{
					if (((_index == -1)
								|| (_index >= _collection.Count)))
					{
						throw new System.IndexOutOfRangeException("Enumerator not started.");
					}
					else
					{
						return _currentElement;
					}
				}
			}

			/// <summary>
			/// Reset the cursor, so it points to the beginning of the enumerator.
			/// </summary>
			public void Reset()
			{
				_index = -1;
				_currentElement = null;
			}

			/// <summary>
			/// Advances the enumerator to the next queue of the enumeration, if one is currently available.
			/// </summary>
			/// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
			public bool MoveNext()
			{
				if ((_index
							< (_collection.Count - 1)))
				{
					_index = (_index + 1);
					_currentElement = _collection[_index];
					return true;
				}
				_index = _collection.Count;
				return false;
			}
		}
	}

	#endregion
}