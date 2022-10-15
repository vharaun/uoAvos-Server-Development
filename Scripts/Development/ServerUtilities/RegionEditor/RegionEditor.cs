using Server.Commands;
using Server.Tools.Controls;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Server.Tools
{
	public partial class RegionEditor : Form
	{
		public static event EventHandler<RegionEditor> EditorStarting, EditorStarted;
		public static event EventHandler<RegionEditor> EditorClosing, EditorClosed;

		private static volatile Thread m_Thread;
		private static volatile RegionEditor m_Instance;

		[CallPriority(Int32.MaxValue)]
		public static void Configure()
		{
			CommandSystem.Register("ExternalRegionEditor", AccessLevel.Administrator, e =>
			{
				if (e.Arguments?.Length > 0)
				{
					var arg = e.GetString(0);

					if (Insensitive.Equals(arg, "open"))
					{
						var result = OpenEditor();

						switch (result)
						{
							case false:
								e.Mobile.SendMessage(0x33, "The Region Editor application was already started on the host machine.");
								break;
							case true:
								e.Mobile.SendMessage(0x55, "The Region Editor application was started on the host machine.");
								break;
							case null: // error
								e.Mobile.SendMessage(0x22, "The Region Editor application could not be started on the host machine.");
								break;
						}

						return;
					}

					if (Insensitive.Equals(arg, "close"))
					{
						var result = CloseEditor();

						switch (result)
						{
							case false:
								e.Mobile.SendMessage(0x33, "The Region Editor application was not running on the host machine.");
								break;
							case true:
								e.Mobile.SendMessage(0x55, "The Region Editor application is no longer running on the host machine.");
								break;
							case null: // error
								e.Mobile.SendMessage(0x22, "The Region Editor application may still be running on the host machine.");
								break;
						}

						return;
					}
				}

				e.Mobile.SendMessage($"Usage: {CommandSystem.Prefix}{e.Command} <open|close>");
			});
		}

		public static bool? OpenEditor()
		{
			if (m_Thread?.IsAlive == true)
			{
				return false;
			}

			try
			{
				m_Thread = new Thread(Run)
				{
					Name = "Region Editor"
				};

				// required for drag/drop api interaction
				m_Thread.SetApartmentState(ApartmentState.STA);

				m_Thread.Start();

				while (!m_Thread.IsAlive)
				{
					Thread.Sleep(1);
				}

				return true;
			}
			catch
			{
				return null;
			}
		}

		public static bool? CloseEditor()
		{
			try
			{
				m_Instance?.Invoke(m_Instance.Close);
				m_Instance?.Invoke(m_Instance.Dispose);
			}
			catch
			{ }
			finally
			{
				m_Instance = null;
			}

			if (m_Thread?.IsAlive == true)
			{
				try
				{
					m_Thread.Join(0);
				}
				catch
				{
					return null;
				}
				finally
				{
					m_Thread = null;
				}

				return true;
			}

			return false;
		}

		private static void Run()
		{
			Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (m_Instance?.IsDisposed != false)
			{
				m_Instance = new RegionEditor();
			}

			Application.Run(m_Instance);
		}

		private volatile bool m_UpdatingTree, m_UpdatingImage, m_ScrollToView, m_ExtenalEventsState;

		private TreeNode m_DragNodeGhost, m_DragOverLast;

		private RegionEditor()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			InitializeComponent();

			Canvas.MapUpdated += OnCanvasMapUpdated;
			Canvas.MapRegionUpdated += OnCanvasMapRegionUpdated;
			Canvas.MapImageUpdating += OnCanvasMapImageUpdating;
			Canvas.MapImageUpdated += OnCanvasMapImageUpdated;

			Regions.BeforeSelect += OnRegionsBeforeSelect;
			Regions.AfterSelect += OnRegionsAfterSelect;
			Regions.BeforeLabelEdit += OnRegionsBeforeLabelEdit;
			Regions.AfterLabelEdit += OnRegionsAfterLabelEdit;

			Regions.ItemDrag += OnRegionsItemDrag;
			Regions.DragEnter += OnRegionsDragEnter;
			Regions.DragOver += OnRegionsDragOver;
			Regions.DragDrop += OnRegionsDragDrop;
		}

		private void SetExternalEvents(bool state)
		{
			if (m_ExtenalEventsState == state)
			{
				return;
			}

			if (m_ExtenalEventsState = state)
			{
				Server.Region.OnRegistered += OnRegionRegistered;
				Server.Region.OnUnregistered += OnRegionUnregistered;
				Server.Region.OnNameChanged += OnRegionNameChanged;

				Map.RegionAdded += OnMapRegionAdded;
				Map.RegionRemoved += OnMapRegionRemoved;
			}
			else
			{
				Server.Region.OnRegistered -= OnRegionRegistered;
				Server.Region.OnUnregistered -= OnRegionUnregistered;
				Server.Region.OnNameChanged -= OnRegionNameChanged;

				Map.RegionAdded -= OnMapRegionAdded;
				Map.RegionRemoved -= OnMapRegionRemoved;
			}
		}
		/*
		private new void Invoke(Action action)
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
		*/
		private void InvokeAsync(Action action)
		{
			if (action != null)
			{
				BeginInvoke(action);
			}
		}

		private void Invoke(EventHandler<RegionEditor> callback)
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

			SetExternalEvents(true);

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

			SetExternalEvents(false);

			Invoke(EditorClosed);
		}

		private void OnCanvasMapUpdated(object sender, MapCanvas e)
		{
			SyncRegionsSelection();

			Props.SelectedObject = null;
		}

		private void OnCanvasMapRegionUpdated(object sender, MapCanvas e)
		{
			SyncRegionsSelection();

			Props.SelectedObject = e.MapRegion;

			if (m_ScrollToView && !m_UpdatingImage)
			{
				m_ScrollToView = false;

				e.ScrollRegionIntoView();
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

				e.ScrollRegionIntoView();
			}
		}

		private void OnRegionsItemDrag(object sender, ItemDragEventArgs e)
		{
			if (e.Button == MouseButtons.Left && e.Item is RegionTreeNode draggedNode)
			{
				Canvas.MapRegion = draggedNode.MapRegion;

				m_DragNodeGhost ??= new()
				{
					ForeColor = Color.Green
				};

				m_DragNodeGhost.Remove();

				m_DragNodeGhost.Tag = draggedNode;
				m_DragNodeGhost.Text = draggedNode.Text;

				Regions.DoDragDrop(draggedNode, DragDropEffects.Move | DragDropEffects.Scroll);
			}
		}

		private void OnRegionsDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.AllowedEffect;
		}

		private void OnRegionsDragOver(object sender, DragEventArgs e)
		{
			if (!e.Effect.HasFlag(DragDropEffects.Move))
			{
				return;
			}

			if (e.Data.GetData(typeof(RegionTreeNode)) is RegionTreeNode draggedNode)
			{
				var targetPoint = Regions.PointToClient(new Point(e.X, e.Y));
				var targetNode = Regions.GetNodeAt(targetPoint);

				if (targetNode != m_DragOverLast)
				{
					Regions.BeginUpdate();

					m_DragNodeGhost.Remove();

					m_DragOverLast = targetNode;

					if (targetNode is MapTreeNode m)
					{
						if (m.Map == draggedNode.MapRegion.Map && !ContainsNode(draggedNode, m))
						{
							m.Nodes.Insert(0, m_DragNodeGhost);

							m.Expand();
						}
					}
					else if (targetNode is RegionTreeNode r)
					{
						if (draggedNode != r && !ContainsNode(draggedNode, r))
						{
							r.Nodes.Insert(0, m_DragNodeGhost);

							r.Expand();
						}
					}

					Regions.EndUpdate();
				}
				else 
				{
					Regions.Scroll(targetPoint, 10);
				}
			}
		}

		private void OnRegionsDragDrop(object sender, DragEventArgs e)
		{
			Regions.BeginUpdate();

			m_DragNodeGhost.Remove();

			m_DragNodeGhost.Tag = null;
			m_DragNodeGhost.Text = null;

			m_DragOverLast = null;

			if (!e.Effect.HasFlag(DragDropEffects.Move))
			{
				return;
			}

			if (e.Data.GetData(typeof(RegionTreeNode)) is RegionTreeNode draggedNode)
			{
				var targetPoint = Regions.PointToClient(new Point(e.X, e.Y));
				var targetNode = Regions.GetNodeAt(targetPoint);

				if (targetNode is MapTreeNode m)
				{
					if (m.Map == draggedNode.MapRegion.Map && !ContainsNode(draggedNode, m))
					{
						draggedNode.Remove();

						m.Nodes.Insert(0, draggedNode);

						m.Expand();

						draggedNode.MapRegion.Parent = null;

						Regions.SelectedNode = draggedNode;
					}
				}
				else if (targetNode is RegionTreeNode r)
				{
					if (draggedNode != r && !ContainsNode(draggedNode, r))
					{
						draggedNode.Remove();

						r.Nodes.Insert(0, draggedNode);

						r.Expand();

						draggedNode.MapRegion.Parent = r.MapRegion;

						Regions.SelectedNode = draggedNode;
					}
				}
			}

			Regions.EndUpdate();
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

		private void OnRegionsBeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (e.Node is RegionTreeNode n && n.MapRegion?.Deleted == false)
			{
				if (String.IsNullOrWhiteSpace(e.Label))
				{
					e.CancelEdit = true;
				}
			}
			else
			{
				e.CancelEdit = true;
			}
		}

		private void OnRegionsAfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (e.Node is RegionTreeNode n && n.MapRegion?.Deleted == false)
			{
				if (String.IsNullOrWhiteSpace(e.Label))
				{
					e.CancelEdit = true;
				}

				if (!e.CancelEdit)
				{
					n.MapRegion.Name = e.Label;
				}
			}
			else
			{
				e.CancelEdit = true;
			}
		}

		private void OnRegionRegistered(Region reg)
		{
			if (World.Loaded)
			{
				if (Canvas.MapRegion == reg)
				{
					SyncRegionsSelection(reg);
				}
				else
				{
					UpdateRegionsTree();
				}
			}
		}

		private void OnRegionUnregistered(Region reg)
		{
			if (World.Loaded)
			{
				if (Canvas.MapRegion == reg)
				{
					SyncRegionsSelection(reg);
				}
				else
				{
					UpdateRegionsTree();
				}
			}
		}

		private void OnRegionNameChanged(Region reg, string oldName)
		{
			if (World.Loaded)
			{
				var node = Regions[reg];

				if (node != null)
				{
					node.Text = reg.Name;
				}

				if (Props.SelectedObject == reg)
				{
					Props.Refresh();
					Props.Update();
				}
			}
		}

		private void OnMapRegionAdded(Map map, Region reg)
		{
		}

		private void OnMapRegionRemoved(Map map, Region reg)
		{
		}

		private void SyncRegionsSelection()
		{
			if (Canvas.MapRegion != null)
			{
				SyncRegionsSelection(Canvas.MapRegion);
			}
			else if (Canvas.Map != null)
			{
				SyncRegionsSelection(Canvas.Map);
			}
			else
			{
				SyncRegionsSelection(null);
			}
		}

		private void SyncRegionsSelection(object obj)
		{
			Invoke(() =>
			{
				Regions.Select();

				if (obj is Map map)
				{
					var n = Regions[map];

					if (n != null && n.IsValid)
					{
						n.EnsureVisible();

						Regions.SelectedNode = n;
					}
				}
				else if (obj is Region reg)
				{
					var n = Regions[reg];

					if (n != null && n.IsValid)
					{
						n.EnsureVisible();

						Regions.SelectedNode = n;
					}
				}
				else if (obj is Type t)
				{
					if (t.Equals(typeof(Map)))
					{
						if (Regions.SelectedNode is MapTreeNode m)
						{
							Regions.SelectedNode = m.Parent;
						}
					}
					else if (t.Equals(typeof(Region)))
					{
						if (Regions.SelectedNode is RegionTreeNode r)
						{
							Regions.SelectedNode = r.Parent;
						}
					}
				}
				else
				{
					Regions.SelectedNode = Regions.SelectedNode?.Parent;
				}
			});
		}

		public void UpdateRegionsTree()
		{
			if (Thread.CurrentThread != Core.Thread)
			{
				while (Server.Region.Generating)
				{
					Thread.Sleep(1);
				}
			}

			Invoke(() =>
			{
				if (m_UpdatingTree)
				{
					return;
				}

				m_UpdatingTree = true;

				Regions.BeginUpdate();

				foreach (var map in Map.AllMaps)
				{
					RecursiveAddMap(Regions.Nodes, map);
				}

				Regions.EndUpdate();

				m_UpdatingTree = false;
			});
		}

		private void RecursiveAddMap(TreeNodeCollection root, Map map)
		{
			if (map == null || map == Map.Internal || !Map.AllMaps.Contains(map))
			{
				return;
			}

			MapTreeNode node = null;

			var key = MapTreeNode.GetTreeKey(map);

			if (root.ContainsKey(key))
			{
				node = (MapTreeNode)root[key];

				if (!node.IsValid)
				{
					root.Remove(node);

					node = null;
				}
			}

			if (node == null)
			{
				root.Add(node = new(map));
			}

			var index = node.Nodes.Count;

			while (--index >= 0)
			{
				if (node.Nodes[index] is RegionTreeNode n)
				{
					if (!n.IsValid)
					{
						node.Nodes.RemoveAt(index);
					}
				}
			}

			foreach (var region in map.Regions.ToArray())
			{
				if (region != null && region.Parent == null)
				{
					RecursiveAddRegion(node.Nodes, region);
				}
			}
		}

		private void RecursiveAddRegion(TreeNodeCollection root, Region region)
		{
			if (region == null || region.Deleted || region.IsDefault || !region.Registered)
			{
				return;
			}

			RegionTreeNode node = null;

			var key = RegionTreeNode.GetTreeKey(region);

			if (root.ContainsKey(key))
			{
				node = (RegionTreeNode)root[key];

				if (!node.IsValid)
				{
					root.Remove(node);

					node = null;
				}
			}

			if (node == null)
			{
				root.Add(node = new(region));
			}

			var index = node.Nodes.Count;

			while (--index >= 0)
			{
				if (node.Nodes[index] is RegionTreeNode n)
				{
					if (!n.IsValid)
					{
						node.Nodes.RemoveAt(index);
					}
				}
			}

			foreach (var child in region.Children)
			{
				RecursiveAddRegion(node.Nodes, child);
			}
		}

		private static bool ContainsNode(TreeNode node1, TreeNode node2)
		{
			return node2?.Parent != null && (node2.Parent == node1 || ContainsNode(node1, node2.Parent));
		}
	}
}

namespace Server.Tools.Controls
{
	public class MapRegionsTree : TreeView
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr ptr, int msg, int wParam, int lParam);

		private static TreeNode Search(TreeNodeCollection root, string k, bool recurse)
		{
			if (root == null)
			{
				return null;
			}

			foreach (TreeNode n in root)
			{
				if (n.Name == k)
				{
					return n;
				}

				if (recurse)
				{
					var c = Search(n.Nodes, k, true);

					if (c != null)
					{
						return c;
					}
				}
			}

			return null;
		}

		public MapTreeNode this[Map map]
		{
			get
			{
				if (map != null)
				{
					var key = MapTreeNode.GetTreeKey(map);

					return Search(Nodes, key, false) as MapTreeNode;
				}

				return null;
			}
		}

		public RegionTreeNode this[Region reg]
		{
			get
			{
				if (reg != null && reg.Map != null)
				{
					var root = this[reg.Map];

					if (root != null)
					{
						var key = RegionTreeNode.GetTreeKey(reg);

						return Search(root.Nodes, key, true) as RegionTreeNode;
					}
				}

				return null;
			}
		}

		public MapRegionsTree()
		{
			TreeViewNodeSorter = new NodeComparer();
		}

		internal void Scroll(Point client, int distance)
		{
			if (client.Y < distance)
			{
				while (client.Y < distance)
				{
					_ = SendMessage(Handle, 277, 0, 0);

					client.Y += distance;
				}
			}
			else if (client.Y + distance > Height)
			{
				while (client.Y + distance > Height)
				{
					_ = SendMessage(Handle, 277, 1, 0);

					client.Y -= distance;
				}
			}
		}

		private class NodeComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				if (x is TreeNode nx && nx.Tag is RegionTreeNode)
				{
					return -1; // ghost nodes from dragging always appear at the top
				}

				if (y is TreeNode ny && ny.Tag is RegionTreeNode)
				{
					return 1; // ghost nodes from dragging always appear at the top
				}

				if (x is MapTreeNode a && y is MapTreeNode b && a.Level == b.Level)
				{
					return 0; // no sorting for same-level map nodes
				}

				return StringComparer.InvariantCultureIgnoreCase.Compare(x?.ToString(), y?.ToString());
			}
		}
	}

	public class MapTreeNode : TreeNode
	{
		public static string GetTreeKey(Map map)
		{
			return $"{map.MapIndex}:{map}";
		}

		public Map Map { get; }

		public bool IsValid => Map != null && Map != Map.Internal && Map.AllMaps.Contains(Map);

		public MapTreeNode(Map map)
		{
			Map = map;

			Text = map.ToString();

			Name = GetTreeKey(map);
		}
	}

	public class RegionTreeNode : TreeNode
	{
		public static string GetTreeKey(Region region)
		{
			return $"{region.Id}";
		}

		public Region MapRegion { get; }

		public bool IsValid => MapRegion != null && !MapRegion.Deleted && !MapRegion.IsDefault && MapRegion.Registered;

		public RegionTreeNode(Region region)
		{
			MapRegion = region;

			Text = region.ToString();

			Name = GetTreeKey(region);
		}
	}

	public class RegionPropertyGrid : PropertyGrid
	{
		private readonly Wrapper _Wrapper = new();

		public new Region SelectedObject
		{
			get
			{
				if (base.SelectedObject is Wrapper wrapper)
				{
					return wrapper.Region;
				}

				return null;
			}
			set
			{
				base.SelectedObject = null;

				_Wrapper.Region = value;

				base.SelectedObject = _Wrapper;

				Refresh();
			}
		}

		[TypeConverter(typeof(Converter))]
		private sealed class Wrapper : TypeConverter
		{
			private PropertyDescriptorCollection m_Properties;

			private Region m_Region;

			[Browsable(false)]
			public Region Region
			{
				get => m_Region;
				set
				{
					if (m_Region == value)
					{
						return;
					}

					m_Properties = null;

					m_Region = value;

					if (m_Region == null)
					{
						return;
					}

					var props = new HashSet<Descriptor>();

					var type = m_Region.GetType();

					foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
					{
						if (prop.PropertyType.IsEnum || prop.PropertyType.IsPrimitive || prop.PropertyType.Equals(typeof(string)))
						{
							props.Add(new Descriptor(m_Region, prop));
						}
					}

					m_Properties = new PropertyDescriptorCollection(props.ToArray(), false);

					props.Clear();
					props.TrimExcess();
				}
			}

			public object this[string property]
			{
				get
				{
					if (m_Properties?[property] is Descriptor prop)
					{
						return prop.GetValue(Region);
					}

					return null;
				}
				set
				{
					if (m_Properties?[property] is Descriptor prop)
					{
						prop.SetValue(Region, value);
					}
				}
			}

			public object this[PropertyInfo property] { get => this[property.Name]; set => this[property.Name] = value; }

			private sealed class Converter : ExpandableObjectConverter
			{
				public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
				{
					if (value is Wrapper wrapper)
					{
						return wrapper.m_Properties;
					}

					return null;
				}
			}

			private sealed class Descriptor : PropertyDescriptor
			{
				public Region Region { get; }
				public PropertyInfo Property { get; }

				public CommandPropertyAttribute CPA { get; }

				public object DefaultValue { get; }

				public override Type PropertyType => Property.PropertyType;
				public override Type ComponentType => typeof(Wrapper);

				public override bool IsReadOnly => Property.CanRead && (!Property.CanWrite || CPA?.ReadOnly == true);

				public override string Category => Property.DeclaringType.Name;

				public override string Name => Property.Name;

				public override string DisplayName => Property.Name;

				public override bool DesignTimeOnly => false;

				public override bool IsBrowsable => !IsReadOnly;

				public Descriptor(Region region, PropertyInfo property)
					: base(property.Name, null)
				{
					Region = region;
					Property = property;

					DefaultValue = Property.GetValue(Region);

					CPA = Property.GetCustomAttribute<CommandPropertyAttribute>();
				}

				public override string ToString()
				{
					return DisplayName;
				}

				public override bool ShouldSerializeValue(object component)
				{
					if (component is Wrapper wrapper)
					{
						return wrapper[Property] != null;
					}

					return false;
				}

				public override bool CanResetValue(object component)
				{
					return !IsReadOnly;
				}

				public override void ResetValue(object component)
				{
					if (component is Wrapper wrapper)
					{
						wrapper[Property] = DefaultValue;
					}
					else if (component is Region region)
					{
						Property.SetValue(region, DefaultValue);
					}
				}

				public override void SetValue(object component, object value)
				{
					if (component is Wrapper wrapper)
					{
						wrapper[Property] = value;
					}
					else if (component is Region region)
					{
						Property.SetValue(region, value);
					}
				}

				public override object GetValue(object component)
				{
					if (component is Wrapper wrapper)
					{
						return wrapper[Property];
					}

					if (component is Region region)
					{
						return Property.GetValue(region);
					}

					return null;
				}
			}
		}
	}

	public class MapCanvasZoom : Panel
	{
		private Bitmap m_ZoomImage;
		private Graphics m_ZoomGraphics;

		protected override Cursor DefaultCursor => Cursors.SizeAll;

		public MapCanvasZoom()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			AutoSize = false;
			AutoSizeMode = AutoSizeMode.GrowOnly;
			BackColor = Color.Transparent;
			Cursor = Cursors.SizeAll;
			DoubleBuffered = true;
			Margin = new Padding(0);
			Padding = new Padding(0);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (Visible)
			{
				if (m_Dragging == null)
				{
					var p = Cursor.Position;
					var s = Size;

					var inW = (s.Width - 1) / 8;
					var inH = (s.Height - 1) / 8;

					var zoomInput = new Rectangle(p.X - inW, p.Y - inH, inW * 2, inH * 2);

					if (m_ZoomImage == null || m_ZoomImage.Width != zoomInput.Width || m_ZoomImage.Height != zoomInput.Height)
					{
						m_ZoomImage?.Dispose();
						m_ZoomGraphics?.Dispose();

						m_ZoomImage = new Bitmap(zoomInput.Width, zoomInput.Height);
						m_ZoomGraphics = Graphics.FromImage(m_ZoomImage);
					}

					m_ZoomGraphics.Clear(Color.Transparent);

					m_ZoomGraphics.CopyFromScreen(zoomInput.Location, Point.Empty, zoomInput.Size, CopyPixelOperation.SourceCopy);

					e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
					e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
					e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
					e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
					e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

					e.Graphics.DrawImage(m_ZoomImage, new Rectangle(Point.Empty, s), new RectangleF(Point.Empty, m_ZoomImage.Size), GraphicsUnit.Pixel);

					var clip = e.ClipRectangle;

					var cur = Cursors.Cross;
					var curS = cur.Size;
					var curP = new Point(clip.X + (clip.Width / 2) - (curS.Width / 2), clip.Y + (clip.Height / 2) - (curS.Height / 2));

					cur.Draw(e.Graphics, new Rectangle(curP, curS));
				}
				else
				{
					m_ZoomGraphics.Clear(Color.LightSkyBlue);
				}
			}

			base.OnPaint(e);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			var s = Size;

			if (s.Width % 2 != 1)
			{
				++s.Width;
			}

			if (s.Height % 2 != 1)
			{
				++s.Height;
			}

			Size = s;
		}

		private Point? m_Dragging;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			m_Dragging = new Point(e.X, e.Y);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			m_Dragging = null;
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);

			m_Dragging = null;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (m_Dragging != null)
			{
				var x = Math.Max(0, Location.X + (e.X - m_Dragging.Value.X));
				var y = Math.Max(0, Location.Y + (e.Y - m_Dragging.Value.Y));

				if (x + Size.Width > Parent.Bounds.Right)
				{
					x = Parent.Bounds.Right - Size.Width;
				}

				if (y + Size.Height > Parent.Bounds.Bottom)
				{
					y = Parent.Bounds.Bottom - Size.Height;
				}

				Location = new Point(x, y);
			}
		}
	}
}
