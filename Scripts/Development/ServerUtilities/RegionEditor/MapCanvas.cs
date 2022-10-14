using Server.Network;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Tools.Controls
{
	public partial class MapCanvas : UserControl
	{
		public const int DefVertexRadius = 2;
		public const int MinVertexRadius = 1;
		public const int MaxVertexRadius = 5;

		private static readonly Type[] m_RegionTypes, m_RegionSignature = new[] { typeof(RegionDefinition), typeof(Map), typeof(Region) };

		static MapCanvas()
		{
			m_RegionTypes = ScriptCompiler.Assemblies.SelectMany(a => a.GetTypes().Where(t => t.IsAssignableTo(typeof(Region)))).OrderBy(t => t.Name).ToArray();
		}

		public static Point2D Convert(Point p)
		{
			return new Point2D(p.X, p.Y);
		}

		public static Point Convert(Point2D p)
		{
			return new Point(p.X, p.Y);
		}

		public static Point Convert(Point3D p)
		{
			return new Point(p.X, p.Y);
		}

		private ToolTip m_Tooltip;

		private bool m_MouseDrag, m_EditingPoints, m_UpdatingImage;

		private Point m_MenuLocation = new(-1, -1);
		private Point m_MouseLocation = new(-1, -1);
		private Point m_MouseDragStart = new(-1, -1);
		private Point m_MouseDragCurrent = new(-1, -1);

		private readonly SelectionState m_Selection = new();

		public ZoomView ZoomView { get; set; } = new();

		[DefaultValue(false)]
		public bool ZoomEnabled { get; set; }

		private Map m_Map;

		[Browsable(false)]
		public Map Map { get => m_Map; set => SetMap(value); }

		[Browsable(false)]
		public Region MapRegion { get => m_Selection.Region; set => SetMapRegion(value, -1, -1); }

		[Browsable(false)]
		public Image Image { get => Canvas.Image; private set => SetImage(value); }

		private int m_VertexRadius = DefVertexRadius;

		[DefaultValue(DefVertexRadius)]
		public int VertexRadius { get => m_VertexRadius; set => Invoke(() => m_VertexRadius = Math.Clamp(value, MinVertexRadius, MaxVertexRadius)); }

		[Browsable(false)]
		public int ScrollX
		{
			get => Background.HorizontalScroll.Value;
			set
			{
				value = Math.Clamp(value, Background.HorizontalScroll.Minimum, Background.HorizontalScroll.Maximum);

				// NOTE: values are updated twice to fix a native scrolling desync bug
				Background.HorizontalScroll.Value = value;
				Background.HorizontalScroll.Value = value;
			}
		}

		[Browsable(false)]
		public int ScrollY
		{
			get => Background.VerticalScroll.Value;
			set
			{
				value = Math.Clamp(value, Background.VerticalScroll.Minimum, Background.VerticalScroll.Maximum);

				// NOTE: values are updated twice to fix a native scrolling desync bug
				Background.VerticalScroll.Value = value;
				Background.VerticalScroll.Value = value;
			}
		}

		public event EventHandler<MapCanvas> MapUpdated, MapRegionUpdated, MapImageUpdating, MapImageUpdated;

		protected override Cursor DefaultCursor => Cursors.Cross;

		public MapCanvas()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			InitializeComponent();

			DoubleBuffered = true;

			Canvas.Paint += OnCanvasPaint;
			Regions.Paint += OnRegionsPaint;
			Surface.Paint += OnSurfacePaint;

			Surface.MouseDown += OnSurfaceMouseDown;
			Surface.MouseUp += OnSurfaceMouseUp;
			Surface.MouseEnter += OnSurfaceMouseEnter;
			Surface.MouseLeave += OnSurfaceMouseLeave;
			Surface.MouseMove += OnSurfaceMouseMove;

			Menu.Opening += OnMenuOpening;
			Menu.Opened += OnMenuOpened;
			Menu.Closing += OnMenuClosing;
			Menu.Closed += OnMenuClosed;

			Menu.SuspendLayout();

			for (var i = 0; i < m_RegionTypes.Length; i++)
			{
				var type = m_RegionTypes[i];

				if (type.IsAbstract || type.GetConstructor(m_RegionSignature) == null)
				{
					continue;
				}

				var item = new ToolStripMenuItem(type.Name)
				{
					Tag = type,
					Image = Properties.Resources.StarIcon
				};

				item.Click += OnCreateRegion;

				MenuCreateRegion.DropDownItems.Add(item);
			}

			Menu.ResumeLayout();

			MenuDeleteRegion.Click += OnDeleteRegion;
			MenuDeleteBounds.Click += OnDeleteBounds;
			MenuDeletePoint.Click += OnDeletePoint;
			MenuInsertBounds.Click += OnInsertBounds;
		}

		private void OnCreateRegion(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem b && b.OwnerItem == MenuCreateRegion)
			{
				var type = (Type)b.Tag;

				var pos = m_MenuLocation;

				var region = Server.Region.CreateInstance(new(type.Name)
				{
					{ "Name", $"Region {Server.Region.NextID}" },
					{ "GoLocation", new Point3D(pos.X + 50, pos.Y + 50, 0) },
					{ pos.X, pos.Y, Server.Region.MinZ, 100, 100, Server.Region.MaxZ - Server.Region.MinZ }
				}, Map, null);

				if (region != null)
				{
					region.Register();

					SetMapRegion(region, 0, -1);
				}
			}
		}

		private void OnDeleteRegion(object sender, EventArgs e)
		{
			if (m_Selection.Region?.Deleted == false)
			{
				var region = m_Selection.Region;

				if (MapRegion == region)
				{
					MapRegion = region.Parent;

					region.Delete();

					UpdateOverlays();
				}
				else
				{
					region.Delete();

					m_Selection.Reset();

					UpdateOverlays();
				}
			}
		}

		private void OnDeleteBounds(object sender, EventArgs e)
		{
			if (m_Selection.Region?.Deleted == false && m_Selection.PolyIndex >= 0)
			{
				var area = m_Selection.Area;

				if (area.Length > 1)
				{
					m_Selection.Area = area.Where((p, i) => i != m_Selection.PolyIndex).ToArray();

					m_Selection.PolyIndex = -1;
					m_Selection.PointIndex = -1;

					UpdateOverlays();
				}
				else
				{
					OnDeleteRegion(sender, e);
				}
			}
		}

		private void OnDeletePoint(object sender, EventArgs e)
		{
			if (m_Selection.Region?.Deleted == false && m_Selection.PolyIndex >= 0 && m_Selection.PointIndex >= 0)
			{
				var poly = m_Selection.Poly;

				if (poly.Count > 3)
				{
					m_Selection.Poly = new(poly.MinZ, poly.MaxZ, poly.Points.Where((p, i) => i != m_Selection.PointIndex));

					m_Selection.PointIndex = -1;

					UpdateOverlays();
				}
				else
				{
					OnDeleteBounds(sender, e);
				}
			}
		}

		private void OnInsertBounds(object sender, EventArgs e)
		{
			if (m_Selection.Region?.Deleted == false)
			{
				var area = m_Selection.Area.ToList();

				var poly = area[0];

				var pb = poly.Bounds;
				var cx = pb.X + (pb.Width / 2);
				var cy = pb.Y + (pb.Height / 2);

				area.Add(new Rectangle3D(cx - 25, cy - 25, poly.MinZ, 50, 50, poly.MaxZ - poly.MinZ));

				Surface.SuspendLayout();

				m_Selection.PolyIndex = area.Count - 1;
				m_Selection.Area = area.ToArray();

				area.Clear();
				area.TrimExcess();

				Surface.ResumeLayout();

				UpdateOverlays();
			}
		}

		private void OnMenuOpening(object sender, CancelEventArgs e)
		{
			if (m_Map == null || m_UpdatingImage)
			{
				e.Cancel = true;
				return;
			}

			var enabled = m_Selection.Region?.Deleted == false;

			MenuDeleteRegion.Enabled = enabled;
			MenuInsertBounds.Enabled = enabled;
			MenuDeleteBounds.Enabled = enabled && m_Selection.PolyIndex >= 0;
			MenuDeletePoint.Enabled = enabled && m_Selection.PointIndex >= 0;
		}

		private void OnMenuOpened(object sender, EventArgs e)
		{
		}

		private void OnMenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
		{
		}

		private void OnMenuClosed(object sender, ToolStripDropDownClosedEventArgs e)
		{
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

		private static Task InvokeAsync(Action action)
		{
			return Task.Run(action);
		}

		private static Task<T> InvokeAsync<T>(Func<T> action)
		{
			return Task.Run(action);
		}

		private void Invoke(EventHandler<MapCanvas> callback)
		{
			callback?.Invoke(this, this);
		}

		private void SetImage(Image image)
		{
			Invoke(() =>
			{
				if (Canvas.Image != image)
				{
					Canvas.Image = image;

					UpdateOverlays();
				}
			});
		}

		private void SetMap(Map map)
		{
			Invoke(() =>
			{
				if (m_Map != map)
				{
					m_Map = map;

					m_Selection.Reset();

					UpdateCanvas();

					Invoke(MapUpdated);
				}
			});
		}

		private void SetMapRegion(Region region, int polyIndex, int pointIndex)
		{
			Invoke(() =>
			{
				var oldMap = m_Map;
				var oldRegion = m_Selection.Region;

				if (region == null || region.Deleted || region.IsDefault || !region.Registered || region.Map == null || region.Map == Map.Internal)
				{
					m_Selection.Reset();
				}
				else if (m_Selection.Region != region)
				{
					m_Map = region.Map;

					m_Selection.Region = region;
					m_Selection.PolyIndex = polyIndex;
					m_Selection.PointIndex = pointIndex;
				}
				else
				{
					m_Selection.PolyIndex = polyIndex;
					m_Selection.PointIndex = pointIndex;
				}

				if (m_Selection.Area?.Length > 0 && m_Selection.PolyIndex < 0)
				{
					m_Selection.PolyIndex = 0;
				}

				if (oldMap != m_Map)
				{
					UpdateCanvas();
				}
				else
				{
					UpdateOverlays();
				}

				if (oldMap != m_Map)
				{
					Invoke(MapUpdated);
				}

				if (oldRegion != m_Selection.Region)
				{
					Invoke(MapRegionUpdated);
				}
			});
		}

		public void UpdateCanvas()
		{
			Invoke(() =>
			{
				m_UpdatingImage = true;

				Invoke(MapImageUpdating);

				var image = Image;

				if (image != null && Equals(Image.RawFormat, ImageFormat.MemoryBmp))
				{
					image.Dispose();
				}

				SetImage(Properties.Resources.LoadingIcon);

				var task = InvokeAsync(() => m_Map?.GetMapImage(true));

				task.ContinueWith(o =>
				{
					SetImage(o.Result);

					m_UpdatingImage = false;

					UpdateOverlays();

					Invoke(MapImageUpdated);
				}, TaskContinuationOptions.ExecuteSynchronously);
			});
		}

		public void UpdateOverlays()
		{
			Invoke(Regions.Refresh);
			Invoke(Regions.Update);
		}

		private void DrawRegion(Graphics g, Region region)
		{
			if (region == null || region.Deleted || region.IsDefault || !region.Registered || region.Map != m_Map)
			{
				return;
			}

			var selectedRegion = m_Selection.Region == region;

			var area = region.Area;

			for (var polyIndex = 0; polyIndex < area.Length; polyIndex++)
			{
				if (!selectedRegion || m_Selection.PolyIndex != polyIndex)
				{
					DrawPoly(g, area[polyIndex], null, i => selectedRegion ? Pens.White : Pens.Gray, null, null);
				}
			}

			if (selectedRegion && m_Selection.PolyIndex >= 0)
			{
				DrawPoly(g, m_Selection.Poly, null, i => Pens.Yellow, i => m_Selection.PointIndex == i ? Brushes.White : Brushes.Gray, i => m_Selection.PointIndex == i ? Brushes.Yellow : Brushes.White);
			}
		}

		private void DrawPoly(Graphics g, Poly3D poly, Func<int, Point2D, Point2D> pointSelect, Func<int, Pen> lineTool, Func<int, Brush> pointTool, Func<int, Brush> fillTool)
		{
			if (g == null || poly.Count == 0 || (lineTool == null && pointTool == null && fillTool == null))
			{
				return;
			}

			if (lineTool != null)
			{
				for (int i = 0, n = 1; i < poly.Count; i = n++)
				{
					var lTool = lineTool.Invoke(i);

					if (lTool != null)
					{
						var p1 = poly[i];
						var p2 = poly[n % poly.Count];

						if (pointSelect != null)
						{
							p1 = pointSelect(i, p1);
							p2 = pointSelect(n % poly.Count, p2);
						}

						if (p1 != p2)
						{
							g.DrawLine(lTool, p1.X, p1.Y, p2.X, p2.Y);
						}
					}
				}
			}

			if (fillTool == null && pointTool == null)
			{
				return;
			}

			var pointRadi = VertexRadius;
			var pointSize = (pointRadi * 2) + 1;

			for (var i = 0; i < poly.Count; i++)
			{
				var pTool = pointTool?.Invoke(i);
				var fTool = fillTool?.Invoke(i);

				if (pTool == null && fTool == null)
				{
					continue;
				}

				var p = poly[i];

				if (pointSelect != null)
				{
					p = pointSelect(i, p);
				}

				if (pTool != null)
				{
					g.FillRectangle(pTool, p.X - pointRadi, p.Y - pointRadi, pointSize, pointSize);
				}

				if (fTool != null)
				{
					g.FillRectangle(fTool, p.X - pointRadi + 1, p.Y - pointRadi + 1, pointSize - 2, pointSize - 2);
				}

				if (pTool != null)
				{
					g.FillRectangle(pTool, p.X, p.Y, 1, 1);
				}
			}
		}

		private void OnCanvasPaint(object sender, PaintEventArgs e)
		{
			if (m_Map == null)
			{
				return;
			}

		}

		private void OnRegionsPaint(object sender, PaintEventArgs e)
		{
			if (m_Map == null || m_UpdatingImage)
			{
				return;
			}

			foreach (var region in m_Map.Regions)
			{
				if (m_Selection.Region != region)
				{
					DrawRegion(e.Graphics, region);
				}
			}

			DrawRegion(e.Graphics, m_Selection.Region);
		}

		private void OnSurfacePaint(object sender, PaintEventArgs e)
		{
			if (m_Map == null || m_UpdatingImage)
			{
				return;
			}

			if (m_EditingPoints && m_Selection.CanEdit)
			{
				DrawPoly(e.Graphics, m_Selection.Poly, (i, p) => i == m_Selection.PointIndex ? Convert(m_MouseDragCurrent) : p, i => Pens.SkyBlue, i => i == m_Selection.PointIndex ? Brushes.LightSkyBlue : Brushes.DeepSkyBlue, i => i == m_Selection.PointIndex ? Brushes.White : Brushes.SkyBlue);
			}
		}

		private void OnSurfaceMouseDown(object sender, MouseEventArgs e)
		{
			if (m_Map == null || m_UpdatingImage)
			{
				return;
			}

			int x = e.X, y = e.Y;

			switch (e.Button)
			{
				case MouseButtons.Left:
					{
						GetData(x, y, out var region, out var polyIdx, out var pointIdx);

						if (pointIdx >= 0)
						{
							SetMapRegion(region, polyIdx, pointIdx);

							m_MouseDragStart.X = x;
							m_MouseDragStart.Y = y;
						}
						else
						{
							m_MouseDragStart.X = -1;
							m_MouseDragStart.Y = -1;
						}

						m_MenuLocation.X = -1;
						m_MenuLocation.Y = -1;
					}
					break;
				case MouseButtons.Right:
					{
						GetData(x, y, out var region, out var polyIdx, out var pointIdx);

						SetMapRegion(region, polyIdx, pointIdx);

						m_MouseDragStart.X = -1;
						m_MouseDragStart.Y = -1;

						m_MenuLocation.X = x;
						m_MenuLocation.Y = y;
					}
					break;
				default:
					{
						m_MouseDragStart.X = -1;
						m_MouseDragStart.Y = -1;

						m_MenuLocation.X = -1;
						m_MenuLocation.Y = -1;
					}
					break;
			}
		}

		private void OnSurfaceMouseUp(object sender, MouseEventArgs e)
		{
			if (m_Map == null || m_UpdatingImage)
			{
				return;
			}

			int x = e.X, y = e.Y;

			if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
			{
				return;
			}

			if (e.Button == MouseButtons.Left && m_MouseDrag)
			{
				if (m_MouseDragStart.X >= 0 && m_MouseDragStart.Y >= 0 && (m_MouseDragStart.X != x || m_MouseDragStart.Y != y))
				{
					if (m_Selection.CanEdit)
					{
						m_Selection.Point = new Point2D(x, y);

						m_EditingPoints = false;

						UpdateOverlays();
					}
				}

				m_MouseDragStart.X = m_MouseDragCurrent.X = -1;
				m_MouseDragStart.Y = m_MouseDragCurrent.Y = -1;

				m_MouseDrag = false;
			}
			else
			{
				GetData(x, y, out var region, out var polyIdx, out var pointIdx);

				if (e.Button == MouseButtons.Left)
				{
					if (region != null && region == m_Selection.Region && polyIdx >= 0 && pointIdx < 0)
					{
						var area = region.Area;
						var poly = area[polyIdx];

						var p0 = new Point2D(x, y);

						for (int i = 0, n = 1; i < poly.Count; i = n++)
						{
							var p1 = poly[i];
							var p2 = poly[n % poly.Count];

							var p1p2 = (int)Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
							var p1p0 = (int)Math.Sqrt((p0.X - p1.X) * (p0.X - p1.X) + (p0.Y - p1.Y) * (p0.Y - p1.Y));
							var p0p2 = (int)Math.Sqrt((p2.X - p0.X) * (p2.X - p0.X) + (p2.Y - p0.Y) * (p2.Y - p0.Y));

							if (p1p2 == p1p0 + p0p2)
							{
								var points = new List<Point2D>(poly.Points);

								points.Insert(pointIdx = n, p0);

								area[polyIdx] = new Poly3D(poly.MinZ, poly.MaxZ, points);

								points.Clear();
								points.TrimExcess();

								Surface.SuspendLayout();

								region.Area = area;

								Surface.ResumeLayout(true);

								break;
							}
						}
					}
				}

				SetMapRegion(region, polyIdx, pointIdx);

				if (pointIdx >= 0)
				{
					Cursor.Current = Cursor = Cursors.SizeAll;
				}
				else
				{
					Cursor.Current = Cursor = Cursors.Cross;
				}
			}
		}

		private void OnSurfaceMouseMove(object sender, MouseEventArgs e)
		{
			if (m_Map == null)
			{
				return;
			}

			if (e.X == m_MouseLocation.X && e.Y == m_MouseLocation.Y)
			{
				return;
			}

			if (m_UpdatingImage)
			{
				Cursor.Current = Cursor = Cursors.WaitCursor;
				return;
			}

			int x = m_MouseLocation.X = e.X, y = m_MouseLocation.Y = e.Y;

			if (e.Button == MouseButtons.Left)
			{
				if (m_MouseDrag)
				{
					m_MouseDragCurrent.X = x;
					m_MouseDragCurrent.Y = y;

					if (m_EditingPoints && m_Selection.CanEdit)
					{
						Surface.Refresh();
					}
				}
				else if (m_MouseDragStart.X >= 0 && m_MouseDragStart.Y >= 0 && (m_MouseDragStart.X != x || m_MouseDragStart.Y != y))
				{
					m_MouseDrag = true;

					m_MouseDragCurrent.X = x;
					m_MouseDragCurrent.Y = y;

					m_EditingPoints = m_Selection.CanEdit;

					Surface.Refresh();
				}
			}

			var region = m_Selection.Region;
			var polyIdx = m_Selection.PolyIndex;
			var pointIdx = m_Selection.PointIndex;

			if (!m_EditingPoints)
			{
				GetData(x, y, out region, out polyIdx, out pointIdx);
			}

			if (ZoomEnabled)
			{
				if (region != null && region == m_Selection.Region && pointIdx >= 0)
				{
					ZoomView.Cursor = Cursors.SizeAll;
				}
				else
				{
					ZoomView.Cursor = Cursors.Cross;
				}

				ZoomView.Update(Surface, m_MouseLocation);

				Cursor.Current = Cursor = CursorHelper.GetCursor(ZoomView.OutputImage);
			}
			else if (region != null && region == m_Selection.Region)
			{
				if (pointIdx >= 0)
				{
					Cursor.Current = Cursor = Cursors.SizeAll;
				}
				else
				{
					Cursor.Current = Cursor = Cursors.Cross;
				}
			}
			else
			{
				Cursor.Current = Cursor = Cursors.Cross;
			}

			if (m_Tooltip != null)
			{
				var size = ZoomEnabled ? ZoomView.OutputImage.Size : Cursor.Size;

				var p = new Point(x + size.Width + -ScrollX, y + size.Height + -ScrollY);

				if (region != null)
				{
					if (m_EditingPoints)
					{
						m_Tooltip.Show($"(*{x}, *{y}) {region} [{polyIdx}, {pointIdx}]", this, p);
					}
					else
					{
						m_Tooltip.Show($"({x}, {y}) {region} [{polyIdx}]", this, p);
					}
				}
				else
				{
					m_Tooltip.Show($"({x}, {y})", this, p);
				}
			}
		}

		private void OnSurfaceMouseEnter(object sender, EventArgs e)
		{
			m_Tooltip ??= new ToolTip()
			{
				IsBalloon = false,
				UseAnimation = false,
				UseFading = false,
				InitialDelay = 0,
				ReshowDelay = 0,
				AutoPopDelay = 0,
			};
		}

		private void OnSurfaceMouseLeave(object sender, EventArgs e)
		{
			m_MouseLocation.X = -1;
			m_MouseLocation.Y = -1;

			m_Tooltip?.Hide(this);

			Surface.Refresh();
		}

		private void GetData(int x, int y, out Region region, out int polyIndex, out int pointIndex)
		{
			GetData(m_Map, x, y, VertexRadius, out region, out polyIndex, out pointIndex);
		}

		private void GetData(Map map, int x, int y, int pointRange, out Region region, out int polyIndex, out int pointIndex)
		{
			region = null;
			polyIndex = -1;
			pointIndex = -1;

			if (map == null)
			{
				return;
			}

			if (m_Selection.Region != null && m_Selection.PolyIndex >= 0)
			{
				var pointIdx = GetPoint(m_Selection.Poly, x, y, pointRange);

				if (pointIdx >= 0)
				{
					region = m_Selection.Region;
					polyIndex = m_Selection.PolyIndex;
					pointIndex = pointIdx;

					return;
				}
			}

			var sector = map.GetSector(x, y);

			foreach (var o in sector.RegionRects)
			{
				var reg = o.Key;

				if (!reg.IsDefault)
				{
					var polyIdx = GetPoly(reg.Area, x, y);

					if (polyIdx >= 0)
					{
						region = reg;
						polyIndex = polyIdx;

						if (region == m_Selection.Region && polyIndex == m_Selection.PolyIndex)
						{
							pointIndex = GetPoint(region.Area[polyIndex], x, y, pointRange);
						}

						return;
					}
				}
			}
		}

		private static int GetPoly(Poly3D[] area, int x, int y)
		{
			for (var polyIndex = area.Length - 1; polyIndex >= 0; polyIndex--)
			{
				if (area[polyIndex].Contains(x, y))
				{
					return polyIndex;
				}
			}

			return -1;
		}

		private static int GetPoint(Poly3D poly, int x, int y, int range)
		{
			var minX = x - range;
			var minY = y - range;

			var maxX = x + range;
			var maxY = y + range;

			for (var pointIndex = 0; pointIndex < poly.Count; pointIndex++)
			{
				var point = poly[pointIndex];

				if (point.X >= minX && point.Y >= minY && point.X <= maxX && point.Y <= maxY)
				{
					return pointIndex;
				}
			}

			return -1;
		}

		public void ScrollRegionIntoView()
		{
			ScrollRegionIntoView(m_Selection.Region);
		}

		public void ScrollRegionIntoView(Region region)
		{
			Invoke(() =>
			{
				if (region != null && !region.Deleted && !region.IsDefault && region.Registered && region.Map == m_Map)
				{
					SuspendLayout();

					ScrollX = region.GoLocation.X - (ClientSize.Width / 2);
					ScrollY = region.GoLocation.Y - (ClientSize.Height / 2);

					ResumeLayout(true);
				}
			});
		}

		private sealed class SelectionState
		{
			public Region Region { get; set; }

			public int PolyIndex { get; set; } = -1;
			public int PointIndex { get; set; } = -1;

			public bool CanEdit => Region?.Deleted == false && Poly != Poly3D.Empty && Point != Point2D.Zero;

			public Poly3D Poly
			{
				get
				{
					if (PolyIndex >= 0)
					{
						var region = Region;

						if (region != null && PolyIndex < region.Area.Length)
						{
							return region.Area[PolyIndex];
						}
					}

					return Poly3D.Empty;
				}
				set
				{
					if (PolyIndex >= 0)
					{
						var area = Area;

						if (area != null && PolyIndex < area.Length)
						{
							area[PolyIndex] = value;

							Area = area;
						}
					}
				}
			}

			public Point2D Point
			{
				get
				{
					if (PointIndex >= 0)
					{
						var poly = Poly;

						if (PointIndex < poly.Count)
						{
							return poly[PointIndex];
						}
					}

					return Point2D.Zero;
				}
				set
				{
					if (PointIndex >= 0)
					{
						var poly = Poly;

						if (PointIndex < poly.Count)
						{
							Poly = new Poly3D(poly.MinZ, poly.MaxZ, poly.Points.Select((p, i) => i == PointIndex ? value : p));
						}
					}
				}
			}

			public Poly3D[] Area
			{
				get => Region?.Area;
				set
				{
					if (Region != null)
					{
						Region.Area = value;
					}
				}
			}

			public void Validate()
			{
				Region?.Validate();
			}

			public void Reset()
			{
				Region = null;
				PolyIndex = -1;
				PointIndex = -1;
			}
		}

		private sealed class CanvasImage : PictureBox
		{
			public CanvasImage()
			{
				SetStyle(ControlStyles.SupportsTransparentBackColor, true);

				AutoSize = true;
				BackColor = Color.Transparent;
				DoubleBuffered = true;
				Margin = new Padding(0);
				Padding = new Padding(0);
			}
		}

		private sealed class CanvasLayer : Panel
		{
			public CanvasLayer()
			{
				SetStyle(ControlStyles.SupportsTransparentBackColor, true);

				AutoSize = true;
				AutoSizeMode = AutoSizeMode.GrowAndShrink;
				BackColor = Color.Transparent;
				Dock = DockStyle.Fill;
				DoubleBuffered = true;
				Margin = new Padding(0);
				Padding = new Padding(0);
			}
		}
	}

	public enum ZoomReticle
	{
		Ellipse,
		Rectangle
	}

	public sealed class ZoomView : IDisposable
	{
		[DllImport("gdi32.dll")]
		private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);

		[DllImport("gdi32.dll")]
		private static extern bool DeleteDC([In] IntPtr hdc);

		private static Dictionary<Rectangle, Rectangle> m_Cache = new();

		private static bool GetScreenBounds(Point formPoint, out Rectangle realBounds, out Rectangle formBounds)
		{
			realBounds = Rectangle.Empty;
			formBounds = Rectangle.Empty;

			if (m_Cache.Count > 0)
			{
				foreach (var o in m_Cache)
				{
					if (o.Key.Contains(formPoint))
					{
						formBounds = o.Key;
						realBounds = o.Value;

						return true;
					}
				}
			}

			foreach (var s in Screen.AllScreens)
			{
				if (s.Bounds.Contains(formPoint))
				{
					formBounds = s.Bounds;

					var hdc = CreateDC(null, s.DeviceName, null, IntPtr.Zero);

					realBounds = new Rectangle(0, 0, GetDeviceCaps(hdc, 118), GetDeviceCaps(hdc, 117));

					DeleteDC(hdc);

					m_Cache[formBounds] = realBounds;

					return true;
				}
			}

			return false;
		}

		public static void InvalidateScreens()
		{
			m_Cache.Clear();
		}

		private bool m_IsDisposed;

		private Rectangle m_InputBounds, m_OutputBounds;
		private Bitmap m_InputImage, m_OutputImage;
		private Graphics m_InputGraphics, m_OutputGraphics;

		private GraphicsPath m_Decoration;

		private Pen m_BorderPen;

		private Cursor m_Cursor;

		private PointF m_ScalePoint;
		private SizeF m_ScaleSize;

		[Browsable(false)]
		public Bitmap InputImage => m_InputImage;

		[Browsable(false)]
		public Bitmap OutputImage => m_OutputImage;

		[Browsable(true)]
		public Size SourceSize { get; set; } = new Size(16, 16);

		[Browsable(true)]
		public Size TargetSize { get; set; } = new Size(160, 160);

		[Browsable(true)]
		public ZoomReticle Reticle { get; set; } = ZoomReticle.Ellipse;

		[Browsable(true)]
		public Pen BorderPen { get; set; }

		[Browsable(true)]
		public Cursor Cursor { get; set; }

		public ZoomView()
		{
			BorderPen = m_BorderPen = new Pen(Color.White, 1.0f);
			Cursor = m_Cursor = new Cursor(Cursors.Cross.CopyHandle());
		}

		public void Update(Control targetControl, Point centerPoint)
		{
			var absolutePoint = targetControl.PointToScreen(centerPoint);

			if (!GetScreenBounds(absolutePoint, out var realScreenBounds, out var formScreenBounds))
			{
				return;
			}

			var sourceSize = SourceSize;
			var targetSize = TargetSize;

			if (realScreenBounds != formScreenBounds)
			{
				m_ScalePoint.X = (absolutePoint.X - formScreenBounds.X) / (float)formScreenBounds.Width;
				m_ScalePoint.Y = (absolutePoint.Y - formScreenBounds.Y) / (float)formScreenBounds.Height;

				m_ScaleSize.Width = realScreenBounds.Width / (float)formScreenBounds.Width;
				m_ScaleSize.Height = realScreenBounds.Height / (float)formScreenBounds.Height;

				absolutePoint.X = realScreenBounds.X + (int)(realScreenBounds.Width * m_ScalePoint.X);
				absolutePoint.Y = realScreenBounds.Y + (int)(realScreenBounds.Height * m_ScalePoint.Y);

				sourceSize.Width = (int)(sourceSize.Width * m_ScaleSize.Width);
				sourceSize.Height = (int)(sourceSize.Height * m_ScaleSize.Height);
			}
			else
			{
				m_ScalePoint.X = m_ScalePoint.Y = 1.0f;
				m_ScaleSize.Width = m_ScaleSize.Height = 1.0f;
			}

			if (sourceSize.Width % 2 == 1)
			{
				--sourceSize.Width;
			}

			if (sourceSize.Height % 2 == 1)
			{
				--sourceSize.Height;
			}

			if (targetSize.Width % 2 == 1)
			{
				--targetSize.Width;
			}

			if (targetSize.Height % 2 == 1)
			{
				--targetSize.Height;
			}

			m_InputBounds.X = absolutePoint.X - (sourceSize.Width / 2);
			m_InputBounds.Y = absolutePoint.Y - (sourceSize.Height / 2);
			m_InputBounds.Width = ++sourceSize.Width;
			m_InputBounds.Height = ++sourceSize.Height;

			if (m_InputImage == null || m_InputImage.Width != m_InputBounds.Width || m_InputImage.Height != m_InputBounds.Height)
			{
				m_InputGraphics?.Dispose();
				m_InputImage?.Dispose();

				m_InputGraphics = Graphics.FromImage(m_InputImage = new Bitmap(m_InputBounds.Width, m_InputBounds.Height));

				m_InputGraphics.CompositingMode = CompositingMode.SourceCopy;
				m_InputGraphics.CompositingQuality = CompositingQuality.Default;
				m_InputGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				m_InputGraphics.PixelOffsetMode = PixelOffsetMode.Half;
				m_InputGraphics.SmoothingMode = SmoothingMode.Default;
				m_InputGraphics.PageUnit = GraphicsUnit.Pixel;
				m_InputGraphics.PageScale = 1f;
			}

			m_InputGraphics.Clear(Color.Transparent);
			m_InputGraphics.CopyFromScreen(m_InputBounds.X, m_InputBounds.Y, 0, 0, m_InputBounds.Size, CopyPixelOperation.SourceCopy);

			m_OutputBounds.X = 0;
			m_OutputBounds.Y = 0;
			m_OutputBounds.Width = ++targetSize.Width;
			m_OutputBounds.Height = ++targetSize.Height;

			if (m_OutputImage == null || m_OutputImage.Width != m_OutputBounds.Width || m_OutputImage.Height != m_OutputBounds.Height)
			{
				m_OutputGraphics?.Dispose();
				m_OutputImage?.Dispose();

				m_OutputGraphics = Graphics.FromImage(m_OutputImage = new Bitmap(m_OutputBounds.Width, m_OutputBounds.Height));

				m_OutputGraphics.CompositingMode = CompositingMode.SourceCopy;
				m_OutputGraphics.CompositingQuality = CompositingQuality.Default;
				m_OutputGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				m_OutputGraphics.PixelOffsetMode = PixelOffsetMode.Half;
				m_OutputGraphics.SmoothingMode = SmoothingMode.Default;
				m_OutputGraphics.PageUnit = GraphicsUnit.Pixel;
				m_OutputGraphics.PageScale = 1f;
			}

			m_Decoration ??= new GraphicsPath();
			m_Decoration.Reset();

			var reticle = m_OutputBounds;

			switch (Reticle)
			{
				case ZoomReticle.Ellipse:
					{
						m_Decoration.AddEllipse(reticle);
					}
					break;
				case ZoomReticle.Rectangle:
					{
						++reticle.X;
						++reticle.Y;
						--reticle.Width;
						--reticle.Height;

						m_Decoration.AddRectangle(reticle);
					}
					break;
			}

			m_OutputGraphics.Clear(Color.Transparent);

			m_OutputGraphics.SetClip(m_Decoration);

			m_OutputGraphics.DrawImage(m_InputImage, m_OutputBounds, 0, 0, m_InputBounds.Width, m_InputBounds.Height, GraphicsUnit.Pixel);

			var cursorBounds = m_OutputBounds;

			cursorBounds.Inflate(-(cursorBounds.Width / 4), -(cursorBounds.Height / 4));

			Cursor.DrawStretched(m_OutputGraphics, cursorBounds);

			m_OutputGraphics.ResetClip();

			if (BorderPen?.Width > 0)
			{
				switch (Reticle)
				{
					case ZoomReticle.Ellipse: m_OutputGraphics.DrawEllipse(BorderPen, reticle); break;
					case ZoomReticle.Rectangle: m_OutputGraphics.DrawRectangle(BorderPen, reticle); break;
				}
			}
		}

		private void Dispose(bool disposing)
		{
			if (!m_IsDisposed)
			{
				if (disposing)
				{
					m_InputGraphics?.Dispose();
					m_InputGraphics = null;

					m_InputImage?.Dispose();
					m_InputImage = null;

					m_OutputGraphics?.Dispose();
					m_OutputGraphics = null;

					m_OutputImage?.Dispose();
					m_OutputImage = null;

					m_Decoration?.Dispose();
					m_Decoration = null;

					m_BorderPen?.Dispose();
					m_BorderPen = null;

					m_Cursor?.Dispose();
					m_Cursor = null;
				}

				m_IsDisposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}
	}

	public static class CursorHelper
	{
		private struct IconInfo
		{
			public bool fIcon;
			public int xHotspot;
			public int yHotspot;
			public IntPtr hbmMask;
			public IntPtr hbmColor;

			public void Reset()
			{
				fIcon = false;
				xHotspot = 0;
				yHotspot = 0;
				hbmMask = IntPtr.Zero;
				hbmColor = IntPtr.Zero;
			}
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

		[DllImport("user32.dll")]
		private static extern IntPtr CreateIconIndirect(ref IconInfo icon);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool DestroyIcon(IntPtr hIcon);

		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool DeleteObject(IntPtr hObject);

		[ThreadStatic]
		private static IconInfo m_Icon;

		[ThreadStatic]
		private static Cursor m_Cursor;

		public static Cursor GetCursor(Bitmap image)
		{
			return GetCursor(image, image.Width / 2, image.Height / 2);
		}

		public static Cursor GetCursor(Bitmap image, Point hotSpot)
		{
			return GetCursor(image, hotSpot.X, hotSpot.Y);
		}

		/// <summary>
		/// TODO: Fix GDI object leak
		/// </summary>
		public static Cursor GetCursor(Bitmap image, int xHotSpot, int yHotSpot)
		{
			if (m_Cursor != null)
			{
				if (Cursor.Current == m_Cursor)
				{
					Cursor.Current = Cursors.Default;
				}

				m_Cursor.Dispose();
				m_Cursor = null;
			}

			m_Icon.Reset();

			var handle = image.GetHicon();

			if (!GetIconInfo(handle, ref m_Icon))
			{
				return Cursors.Default;
			}

			m_Icon.fIcon = false;
			m_Icon.xHotspot = xHotSpot;
			m_Icon.yHotspot = yHotSpot;

			var cursorHandle = CreateIconIndirect(ref m_Icon);

			if (handle != IntPtr.Zero)
			{
				DestroyIcon(handle);
			}

			if (m_Icon.hbmColor != IntPtr.Zero)
			{
				DeleteObject(m_Icon.hbmColor);
			}

			if (m_Icon.hbmMask != IntPtr.Zero)
			{
				DeleteObject(m_Icon.hbmMask);
			}

			if (cursorHandle == IntPtr.Zero)
			{
				return Cursors.Default;
			}

			return m_Cursor = new Cursor(cursorHandle)
			{
				Tag = typeof(CursorHelper)
			};
		}
	}
}
