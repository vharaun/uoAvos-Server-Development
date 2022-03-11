
using System;
using System.Collections;

namespace Server.Engines.Reports
{
	public abstract class Chart : PersistableObject
	{
		protected string m_Name;
		protected string m_FileName;
		protected ChartItemCollection m_Items;

		public string Name { get => m_Name; set => m_Name = value; }
		public string FileName { get => m_FileName; set => m_FileName = value; }
		public ChartItemCollection Items => m_Items;

		public Chart()
		{
			m_Items = new ChartItemCollection();
		}

		public override void SerializeAttributes(PersistanceWriter op)
		{
			op.SetString("n", m_Name);
			op.SetString("f", m_FileName);
		}

		public override void DeserializeAttributes(PersistanceReader ip)
		{
			m_Name = Utility.Intern(ip.GetString("n"));
			m_FileName = Utility.Intern(ip.GetString("f"));
		}

		public override void SerializeChildren(PersistanceWriter op)
		{
			for (var i = 0; i < m_Items.Count; ++i)
			{
				m_Items[i].Serialize(op);
			}
		}

		public override void DeserializeChildren(PersistanceReader ip)
		{
			while (ip.HasChild)
			{
				m_Items.Add(ip.GetChild() as ChartItem);
			}
		}
	}

	public class ChartItem : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType("ci", new ConstructCallback(Construct));

		private static PersistableObject Construct()
		{
			return new ChartItem();
		}

		public override PersistableType TypeID => ThisTypeID;
		#endregion

		private string m_Name;
		private int m_Value;

		public string Name { get => m_Name; set => m_Name = value; }
		public int Value { get => m_Value; set => m_Value = value; }

		private ChartItem()
		{
		}

		public ChartItem(string name, int value)
		{
			m_Name = name;
			m_Value = value;
		}

		public override void SerializeAttributes(PersistanceWriter op)
		{
			op.SetString("n", m_Name);
			op.SetInt32("v", m_Value);
		}

		public override void DeserializeAttributes(PersistanceReader ip)
		{
			m_Name = Utility.Intern(ip.GetString("n"));
			m_Value = ip.GetInt32("v");
		}
	}

	/// <summary>
	/// Strongly typed collection of Server.Engines.Reports.ChartItem.
	/// </summary>
	public class ChartItemCollection : System.Collections.CollectionBase
	{

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ChartItemCollection() :
				base()
		{
		}

		/// <summary>
		/// Gets or sets the value of the Server.Engines.Reports.ChartItem at a specific position in the ChartItemCollection.
		/// </summary>
		public Server.Engines.Reports.ChartItem this[int index]
		{
			get => ((Server.Engines.Reports.ChartItem)(List[index]));
			set => List[index] = value;
		}

		public int Add(string name, int value)
		{
			return Add(new ChartItem(name, value));
		}

		/// <summary>
		/// Append a Server.Engines.Reports.ChartItem entry to this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ChartItem instance.</param>
		/// <returns>The position into which the new element was inserted.</returns>
		public int Add(Server.Engines.Reports.ChartItem value)
		{
			return List.Add(value);
		}

		/// <summary>
		/// Determines whether a specified Server.Engines.Reports.ChartItem instance is in this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ChartItem instance to search for.</param>
		/// <returns>True if the Server.Engines.Reports.ChartItem instance is in the collection; otherwise false.</returns>
		public bool Contains(Server.Engines.Reports.ChartItem value)
		{
			return List.Contains(value);
		}

		/// <summary>
		/// Retrieve the index a specified Server.Engines.Reports.ChartItem instance is in this collection.
		/// </summary>
		/// <param name="value">Server.Engines.Reports.ChartItem instance to find.</param>
		/// <returns>The zero-based index of the specified Server.Engines.Reports.ChartItem instance. If the object is not found, the return value is -1.</returns>
		public int IndexOf(Server.Engines.Reports.ChartItem value)
		{
			return List.IndexOf(value);
		}

		/// <summary>
		/// Removes a specified Server.Engines.Reports.ChartItem instance from this collection.
		/// </summary>
		/// <param name="value">The Server.Engines.Reports.ChartItem instance to remove.</param>
		public void Remove(Server.Engines.Reports.ChartItem value)
		{
			List.Remove(value);
		}

		/// <summary>
		/// Returns an enumerator that can iterate through the Server.Engines.Reports.ChartItem instance.
		/// </summary>
		/// <returns>An Server.Engines.Reports.ChartItem's enumerator.</returns>
		public new ChartItemCollectionEnumerator GetEnumerator()
		{
			return new ChartItemCollectionEnumerator(this);
		}

		/// <summary>
		/// Insert a Server.Engines.Reports.ChartItem instance into this collection at a specified index.
		/// </summary>
		/// <param name="index">Zero-based index.</param>
		/// <param name="value">The Server.Engines.Reports.ChartItem instance to insert.</param>
		public void Insert(int index, Server.Engines.Reports.ChartItem value)
		{
			List.Insert(index, value);
		}

		/// <summary>
		/// Strongly typed enumerator of Server.Engines.Reports.ChartItem.
		/// </summary>
		public class ChartItemCollectionEnumerator : System.Collections.IEnumerator
		{

			/// <summary>
			/// Current index
			/// </summary>
			private int _index;

			/// <summary>
			/// Current element pointed to.
			/// </summary>
			private Server.Engines.Reports.ChartItem _currentElement;

			/// <summary>
			/// Collection to enumerate.
			/// </summary>
			private readonly ChartItemCollection _collection;

			/// <summary>
			/// Default constructor for enumerator.
			/// </summary>
			/// <param name="collection">Instance of the collection to enumerate.</param>
			internal ChartItemCollectionEnumerator(ChartItemCollection collection)
			{
				_index = -1;
				_collection = collection;
			}

			/// <summary>
			/// Gets the Server.Engines.Reports.ChartItem object in the enumerated ChartItemCollection currently indexed by this instance.
			/// </summary>
			public Server.Engines.Reports.ChartItem Current
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

	public class PieChart : Chart
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType("pc", new ConstructCallback(Construct));

		private static PersistableObject Construct()
		{
			return new PieChart();
		}

		public override PersistableType TypeID => ThisTypeID;
		#endregion

		private bool m_ShowPercents;

		public bool ShowPercents { get => m_ShowPercents; set => m_ShowPercents = value; }

		public PieChart(string name, string fileName, bool showPercents)
		{
			m_Name = name;
			m_FileName = fileName;
			m_ShowPercents = showPercents;
		}

		private PieChart()
		{
		}

		public override void SerializeAttributes(PersistanceWriter op)
		{
			base.SerializeAttributes(op);

			op.SetBoolean("p", m_ShowPercents);
		}

		public override void DeserializeAttributes(PersistanceReader ip)
		{
			base.DeserializeAttributes(ip);

			m_ShowPercents = ip.GetBoolean("p");
		}
	}

	public enum BarGraphRenderMode
	{
		Bars,
		Lines
	}

	public class BarGraph : Chart
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType("bg", new ConstructCallback(Construct));

		private static PersistableObject Construct()
		{
			return new BarGraph();
		}

		public override PersistableType TypeID => ThisTypeID;
		#endregion

		private int m_Ticks;
		private BarGraphRenderMode m_RenderMode;

		private string m_xTitle;
		private string m_yTitle;

		private int m_FontSize = 7;
		private int m_Interval = 1;

		private BarRegion[] m_Regions;

		public int Ticks { get => m_Ticks; set => m_Ticks = value; }
		public BarGraphRenderMode RenderMode { get => m_RenderMode; set => m_RenderMode = value; }

		public string xTitle { get => m_xTitle; set => m_xTitle = value; }
		public string yTitle { get => m_yTitle; set => m_yTitle = value; }

		public int FontSize { get => m_FontSize; set => m_FontSize = value; }
		public int Interval { get => m_Interval; set => m_Interval = value; }

		public BarRegion[] Regions { get => m_Regions; set => m_Regions = value; }

		public BarGraph(string name, string fileName, int ticks, string xTitle, string yTitle, BarGraphRenderMode rm)
		{
			m_Name = name;
			m_FileName = fileName;
			m_Ticks = ticks;
			m_xTitle = xTitle;
			m_yTitle = yTitle;
			m_RenderMode = rm;
		}

		private BarGraph()
		{
		}

		public override void SerializeAttributes(PersistanceWriter op)
		{
			base.SerializeAttributes(op);

			op.SetInt32("t", m_Ticks);
			op.SetInt32("r", (int)m_RenderMode);

			op.SetString("x", m_xTitle);
			op.SetString("y", m_yTitle);

			op.SetInt32("s", m_FontSize);
			op.SetInt32("i", m_Interval);
		}

		public override void DeserializeAttributes(PersistanceReader ip)
		{
			base.DeserializeAttributes(ip);

			m_Ticks = ip.GetInt32("t");
			m_RenderMode = (BarGraphRenderMode)ip.GetInt32("r");

			m_xTitle = Utility.Intern(ip.GetString("x"));
			m_yTitle = Utility.Intern(ip.GetString("y"));

			m_FontSize = ip.GetInt32("s");
			m_Interval = ip.GetInt32("i");
		}

		public static int LookupReportValue(Snapshot ss, string reportName, string valueName)
		{
			for (var j = 0; j < ss.Children.Count; ++j)
			{
				var report = ss.Children[j] as Report;

				if (report == null || report.Name != reportName)
				{
					continue;
				}

				for (var k = 0; k < report.Items.Count; ++k)
				{
					var item = report.Items[k];

					if (item.Values[0].Value == valueName)
					{
						return Utility.ToInt32(item.Values[1].Value);
					}
				}

				break;
			}

			return -1;
		}

		public static BarGraph DailyAverage(SnapshotHistory history, string reportName, string valueName)
		{
			var totals = new int[24];
			var counts = new int[24];

			var min = history.Snapshots.Count - (7 * 24); // averages over one week

			if (min < 0)
			{
				min = 0;
			}

			for (var i = min; i < history.Snapshots.Count; ++i)
			{
				var ss = history.Snapshots[i];

				var val = LookupReportValue(ss, reportName, valueName);

				if (val == -1)
				{
					continue;
				}

				var hour = ss.TimeStamp.TimeOfDay.Hours;

				totals[hour] += val;
				counts[hour]++;
			}

			var barGraph = new BarGraph("Hourly average " + valueName, "graphs_" + valueName.ToLower() + "_avg", 10, "Time", valueName, BarGraphRenderMode.Lines) {
				m_FontSize = 6
			};

			for (var i = 7; i <= totals.Length + 7; ++i)
			{
				int val;

				if (counts[i % totals.Length] == 0)
				{
					val = 0;
				}
				else
				{
					val = (totals[i % totals.Length] + (counts[i % totals.Length] / 2)) / counts[i % totals.Length];
				}

				var realHours = i % totals.Length;
				int hours;

				if (realHours == 0)
				{
					hours = 12;
				}
				else if (realHours > 12)
				{
					hours = realHours - 12;
				}
				else
				{
					hours = realHours;
				}

				barGraph.Items.Add(hours + (realHours >= 12 ? " PM" : " AM"), val);
			}

			return barGraph;
		}

		public static BarGraph Growth(SnapshotHistory history, string reportName, string valueName)
		{
			var barGraph = new BarGraph("Growth of " + valueName + " over time", "graphs_" + valueName.ToLower() + "_growth", 10, "Time", valueName, BarGraphRenderMode.Lines) {
				FontSize = 6,
				Interval = 7
			};

			var startPeriod = history.Snapshots[0].TimeStamp.Date + TimeSpan.FromDays(1.0);
			var endPeriod = history.Snapshots[history.Snapshots.Count - 1].TimeStamp.Date;

			var regions = new ArrayList();

			var curDate = DateTime.MinValue;
			var curPeak = -1;
			var curLow = 1000;
			var curTotl = 0;
			var curCont = 0;
			var curValu = 0;

			for (var i = 0; i < history.Snapshots.Count; ++i)
			{
				var ss = history.Snapshots[i];
				var timeStamp = ss.TimeStamp;

				if (timeStamp < startPeriod || timeStamp >= endPeriod)
				{
					continue;
				}

				var val = LookupReportValue(ss, reportName, valueName);

				if (val == -1)
				{
					continue;
				}

				var thisDate = timeStamp.Date;

				if (curDate == DateTime.MinValue)
				{
					curDate = thisDate;
				}

				curCont++;
				curTotl += val;
				curValu = curTotl / curCont;

				if (curDate != thisDate && curValu >= 0)
				{
					var mnthName = thisDate.ToString("MMMM");

					if (regions.Count == 0)
					{
						regions.Add(new BarRegion(barGraph.Items.Count, barGraph.Items.Count, mnthName));
					}
					else
					{
						var region = (BarRegion)regions[regions.Count - 1];

						if (region.m_Name == mnthName)
						{
							region.m_RangeTo = barGraph.Items.Count;
						}
						else
						{
							regions.Add(new BarRegion(barGraph.Items.Count, barGraph.Items.Count, mnthName));
						}
					}

					barGraph.Items.Add(thisDate.Day.ToString(), curValu);

					curPeak = val;
					curLow = val;
				}
				else
				{
					if (val > curPeak)
					{
						curPeak = val;
					}

					if (val > 0 && val < curLow)
					{
						curLow = val;
					}
				}

				curDate = thisDate;
			}

			barGraph.Regions = (BarRegion[])regions.ToArray(typeof(BarRegion));

			return barGraph;
		}

		public static BarGraph OverTime(SnapshotHistory history, string reportName, string valueName, int step, int max, int ival)
		{
			var barGraph = new BarGraph(valueName + " over time", "graphs_" + valueName.ToLower() + "_ot", 10, "Time", valueName, BarGraphRenderMode.Lines);

			var ts = TimeSpan.FromHours((max * step) - 0.5);

			var mostRecent = history.Snapshots[history.Snapshots.Count - 1].TimeStamp;
			var minTime = mostRecent - ts;

			barGraph.FontSize = 6;
			barGraph.Interval = ival;

			var regions = new ArrayList();

			for (var i = 0; i < history.Snapshots.Count; ++i)
			{
				var ss = history.Snapshots[i];
				var timeStamp = ss.TimeStamp;

				if (timeStamp < minTime)
				{
					continue;
				}

				if ((i % step) != 0)
				{
					continue;
				}

				var val = LookupReportValue(ss, reportName, valueName);

				if (val == -1)
				{
					continue;
				}

				var realHours = timeStamp.TimeOfDay.Hours;
				int hours;

				if (realHours == 0)
				{
					hours = 12;
				}
				else if (realHours > 12)
				{
					hours = realHours - 12;
				}
				else
				{
					hours = realHours;
				}

				var dayName = timeStamp.DayOfWeek.ToString();

				if (regions.Count == 0)
				{
					regions.Add(new BarRegion(barGraph.Items.Count, barGraph.Items.Count, dayName));
				}
				else
				{
					var region = (BarRegion)regions[regions.Count - 1];

					if (region.m_Name == dayName)
					{
						region.m_RangeTo = barGraph.Items.Count;
					}
					else
					{
						regions.Add(new BarRegion(barGraph.Items.Count, barGraph.Items.Count, dayName));
					}
				}

				barGraph.Items.Add(hours + (realHours >= 12 ? " PM" : " AM"), val);
			}

			barGraph.Regions = (BarRegion[])regions.ToArray(typeof(BarRegion));

			return barGraph;
		}
	}
}