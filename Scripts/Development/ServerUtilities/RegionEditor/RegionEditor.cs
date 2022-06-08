using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;

namespace Server.Tools
{
	public partial class Editor : Form
	{
		public static event EventHandler<Editor> EditorStarting, EditorStarted;
		public static event EventHandler<Editor> EditorClosing, EditorClosed;

		private static volatile Thread m_Thread;
		private static volatile Editor m_Instance;

		[CallPriority(Int32.MaxValue)]
		public static void Configure()
		{
			EventSink.ServerStarted += () => Timer.DelayCall(Start);
		}

		private static void Start()
		{
			if (m_Instance?.IsDisposed != false)
			{
				m_Instance = new Editor();
			}

			if (m_Thread?.IsAlive != true)
			{
				m_Thread = new Thread(Run);

				m_Thread.Start();

				while (!m_Thread.IsAlive)
				{
					Thread.Sleep(1);
				}
			}
		}

		[STAThread]
		private static void Run()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.Run(m_Instance);
		}

		private volatile bool m_UpdatingTree, m_UpdatingImage, m_ScrollToView;

		private Editor()
		{
			InitializeComponent();

			Canvas.MapUpdated += OnCanvasMapUpdated;
			Canvas.MapRegionUpdated += OnCanvasMapRegionUpdated;
			Canvas.MapImageUpdating += OnCanvasMapImageUpdating;
			Canvas.MapImageUpdated += OnCanvasMapImageUpdated;

			Regions.BeforeSelect += OnRegionsBeforeSelect;
			Regions.AfterSelect += OnRegionsAfterSelect;

			Map.RegionAdded += OnMapRegionAdded;
			Map.RegionRemoved += OnMapRegionRemoved;
		}

		private void Invoke(Action action)
		{
			if (action == null)
			{
				return;
			}

			if (InvokeRequired)
			{
				base.Invoke(action);
			}
			else
			{
				action();
			}
		}

		private void InvokeAsync(Action action)
		{
			if (action != null)
			{
				BeginInvoke(action);
			}
		}

		private void Invoke(EventHandler<Editor> callback)
		{
			callback?.Invoke(this, this);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Invoke(EditorStarting);

			InvokeAsync(UpdateRegionsTree);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			Invoke(EditorStarted);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			Invoke(EditorClosing);
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			Invoke(EditorClosed);
		}

		private void OnRegionsBeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			e.Cancel = m_UpdatingImage;

			if (e.Action != TreeViewAction.Unknown)
			{
				m_ScrollToView = true;
			}
		}

		private void OnRegionsAfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Action != TreeViewAction.Unknown)
			{
				if (e.Node is MapTreeNode m)
				{
					Canvas.Map = m.Map;
				}
				else if (e.Node is RegionTreeNode r)
				{
					Canvas.MapRegion = r.MapRegion; 					
				}
			}
		}

		private void OnCanvasMapUpdated(object sender, MapCanvas e)
		{
			SyncRegionsSelection(e.Map);
		}

		private void OnCanvasMapRegionUpdated(object sender, MapCanvas e)
		{
			SyncRegionsSelection(e.MapRegion);

			if (m_ScrollToView && !m_UpdatingImage)
			{
				m_ScrollToView = false;

				Canvas.ScrollRegionIntoView();
			}
		}

		private void OnCanvasMapImageUpdating(object sender, MapCanvas e)
		{
			m_UpdatingImage = true;
			m_ScrollToView = true;
		}

		private void OnCanvasMapImageUpdated(object sender, MapCanvas e)
		{
			m_UpdatingImage = false;

			if (m_ScrollToView)
			{
				m_ScrollToView = false;

				Canvas.ScrollRegionIntoView();
			}
		}		

		private void OnMapRegionAdded(Map map, Region reg)
		{
			if (World.Loaded)
			{
				UpdateRegionsTree();

				SyncRegionsSelection(reg);
			}
		}

		private void OnMapRegionRemoved(Map map, Region reg)
		{
			if (World.Loaded)
			{
				InvalidateRegionsTree();

				SyncRegionsSelection(reg);
			}
		}

		private void SyncRegionsSelection(object obj)
		{
			Invoke(() =>
			{
				Regions.Select();

				if (obj is Map map)
				{
					if (Regions.SelectedNode is not MapTreeNode m || m.Map != map)
					{
						var n = Regions[map];

						if (n != null)
						{
							n.EnsureVisible();

							Regions.SelectedNode = n;
						}
					}
					else
					{
						m.EnsureVisible();
					}
				}
				else if (obj is Region reg)
				{
					if (reg.Deleted || reg.IsDefault || !reg.Registered)
					{
						if (Regions.SelectedNode is RegionTreeNode r && r.MapRegion == reg)
						{
							Regions.SelectedNode = null;
						}
					}
					else if (Regions.SelectedNode is not RegionTreeNode r || r.MapRegion != reg)
					{
						var n = Regions[reg];

						if (n != null)
						{
							n.EnsureVisible();

							Regions.SelectedNode = n;
						}
					}
					else
					{
						r.EnsureVisible();
					}
				}
				else if (obj is Type t)
				{
					if (t.IsAssignableFrom(typeof(Map)))
					{
						if (Regions.SelectedNode is MapTreeNode)
						{
							Regions.SelectedNode = null;
						}
					}
					else if (t.IsAssignableFrom(typeof(Region)))
					{
						if (Regions.SelectedNode is RegionTreeNode)
						{
							Regions.SelectedNode = null;
						}
					}
				}
			});
		}

		public void InvalidateRegionsTree()
		{
			InvalidateRegionsTree(Regions.Nodes);
		}

		private void InvalidateRegionsTree(TreeNodeCollection root)
		{
			Invoke(() =>
			{
				var index = root.Count;

				while (--index >= 0)
				{
					if (index < root.Count)
					{
						if (root[index] is MapTreeNode m)
						{
							if (m.Map == null || m.Map == Map.Internal || !Map.AllMaps.Contains(m.Map))
							{
								root.RemoveAt(index);
								continue;
							}

							InvalidateRegionsTree(m.Nodes);
						}
						else if (root[index] is RegionTreeNode r)
						{
							if (r.MapRegion == null || r.MapRegion.Deleted || r.MapRegion.IsDefault || !r.MapRegion.Registered)
							{
								root.RemoveAt(index);
								continue;
							}

							InvalidateRegionsTree(r.Nodes);
						}
					}
				}
			});
		}

		public void UpdateRegionsTree()
		{
			UpdateRegionsTree(Regions.Nodes);
		}

		private void UpdateRegionsTree(TreeNodeCollection root)
		{
			Invoke(() =>
			{
				if (m_UpdatingTree)
				{
					return;
				}

				m_UpdatingTree = true;

				try
				{
					Regions.BeginUpdate();

					foreach (var map in Map.AllMaps)
					{
						if (map != null && map != Map.Internal)
						{
							BuildRegionsTree(root, map);
						}
					}

					Regions.EndUpdate();
				}
				finally
				{
					m_UpdatingTree = false;
				}
			});
		}

		private static void RecursiveAddRegion(TreeNodeCollection c, Region r)
		{
			var n = new RegionTreeNode(r);

			c.Add(n);

			foreach (var cr in r.Children)
			{
				RecursiveAddRegion(n.Nodes, cr);
			}
		}

		private static void BuildRegionsTree(TreeNodeCollection root, Map map)
		{
			var key = map.ToString();

			MapTreeNode node;

			if (!root.ContainsKey(key))
			{
				node = new MapTreeNode(map);

				root.Add(node);
			}
			else
			{
				node = (MapTreeNode)root[key];

				node.Nodes.Clear();

				if (node.Map == null || node.Map == Map.Internal)
				{
					root.Remove(node);
					return;
				}
			}

			foreach (var region in map.Regions.ToArray())
			{
				if (!region.IsDefault && region.Parent == null)
				{
					RecursiveAddRegion(node.Nodes, region);
				}
			}
		}
	}

	public class MapRegionsTree : TreeView
	{
		public MapTreeNode this[Map map] { get => Nodes.Find(map.ToString(), false).OfType<MapTreeNode>().FirstOrDefault(n => n.Map == map); }

		public RegionTreeNode this[Region reg] { get => this[reg.Map]?.Nodes.Find(reg.ToString(), true).OfType<RegionTreeNode>().FirstOrDefault(n => n.MapRegion == reg); }

		public MapRegionsTree()
		{
			TreeViewNodeSorter = new NodeComparer();
		}

		private class NodeComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				return StringComparer.InvariantCultureIgnoreCase.Compare(x?.ToString(), y?.ToString());
			}
		}
	}

	public class MapTreeNode : TreeNode
	{
		public Map Map { get; }

		public MapTreeNode(Map map)
		{
			Map = map;
			
			Name = Text = map.ToString();
		}
	}

	public class RegionTreeNode : TreeNode
	{
		public Region MapRegion { get; }

		public RegionTreeNode(Region region)
		{
			MapRegion = region;

			Name = Text = region.ToString();
		}
	}
}
