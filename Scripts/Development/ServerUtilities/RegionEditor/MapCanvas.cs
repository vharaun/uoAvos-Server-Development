using Server.Network;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Tools
{
	public partial class MapCanvas : UserControl
	{
		public const int DefVertexRadius = 3;
		public const int MinVertexRadius = 1;
		public const int MaxVertexRadius = 5;

		public static Point Convert(Point2D p)
		{
			return new Point(p.X, p.Y);
		}

		public static Point Convert(Point3D p)
		{
			return new Point(p.X, p.Y);
		}

		private ToolTip m_Tooltip;

		private Bitmap m_RegionOverlay, m_MobileOverlay;

		private volatile int m_PolyIndex, m_PointIndex;

		private volatile Map m_Map;

		[Browsable(false)]
		public Map Map { get => m_Map; set => SetMap(value); }

		private volatile Region m_MapRegion;

		[Browsable(false)]
		public Region MapRegion { get => m_MapRegion; set => SetMapRegion(value, -1, -1); }

		[Browsable(false)]
		public Image Image { get => Canvas.Image; private set => SetImage(value); }

		private volatile int m_VertexRadius = DefVertexRadius;

		[Browsable(true), DefaultValue(DefVertexRadius)]
		public int VertexRadius { get => m_VertexRadius; set => Invoke(() => m_VertexRadius = Math.Clamp(value, MinVertexRadius, MaxVertexRadius)); }

		public event EventHandler<MapCanvas> MapUpdated, MapRegionUpdated, MapImageUpdating, MapImageUpdated;

		public MapCanvas()
		{
			InitializeComponent();

			Canvas.Paint += OnCanvasPaint;
			Canvas.MouseClick += OnCanvasMouseClick;
			Canvas.MouseEnter += OnCanvasMouseEnter;
			Canvas.MouseLeave += OnCanvasMouseLeave;
			Canvas.MouseMove += OnCanvasMouseMove;
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
			if (action != null)
			{
				return Task.Run(action);
			}

			return Task.CompletedTask;
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

					UpdateOverlays(true);
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
					m_MapRegion = null;
					m_PolyIndex = -1;
					m_PointIndex = -1;

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
				var oldRegion = m_MapRegion;

				if (region == null || region.Deleted || region.IsDefault || !region.Registered || region.Map == null || region.Map == Map.Internal)
				{
					m_MapRegion = null;
					m_PolyIndex = -1;
					m_PointIndex = -1;
				}
				else if (m_MapRegion != region)
				{
					m_Map = region.Map;
					m_MapRegion = region;
					m_PolyIndex = polyIndex;
					m_PointIndex = pointIndex;
				}
				else
				{
					m_PolyIndex = polyIndex;
					m_PointIndex = pointIndex;
				}

				if (oldMap != m_Map)
				{
					UpdateCanvas();
				}
				else
				{
					UpdateOverlays(true);
				}

				if (oldMap != m_Map)
				{
					Invoke(MapUpdated);
				}

				if (oldRegion != m_MapRegion)
				{
					Invoke(MapRegionUpdated);
				}
			});
		}

		private void UpdateCanvas()
		{
			Invoke(() =>
			{
				Invoke(MapImageUpdating);

				var image = Image;

				if (image != null && Equals(Image.RawFormat, ImageFormat.MemoryBmp))
				{
					image.Dispose();
				}

				SetImage(Properties.Resources.LoadingIcon);

				InvokeAsync(() =>
				{
					SetImage(m_Map?.GetMapImage(true));

					Invoke(MapImageUpdated);
				});
			});
		}

		private void UpdateOverlays(bool refresh)
		{
			Invoke(() =>
			{
				UpdateMobileOverlay(false);
				UpdateRegionOverlay(false);

				if (refresh)
				{
					Refresh();
				}
			});
		}

		private bool EnsureOverlay(ref Bitmap image)
		{
			if (m_Map == null || Image == null || !Equals(Image.RawFormat, ImageFormat.MemoryBmp))
			{
				return false;
			}

			if (image == null || image.Width != Image.Width || image.Height != Image.Height)
			{
				var overlay = new Bitmap(Image.Width, Image.Height, Image.PixelFormat);

				overlay.MakeTransparent();

				image = overlay;
			}

			return true;
		}

		private void UpdateMobileOverlay(bool refresh)
		{
			Invoke(() =>
			{
				if (EnsureOverlay(ref m_MobileOverlay))
				{
					using var g = Graphics.FromImage(m_MobileOverlay);

					g.PageUnit = GraphicsUnit.Pixel;

					g.Clear(Color.Transparent);

					if (NetState.Instances.Count > 0)
					{
						var gray = Brushes.Gray;
						var blue = Brushes.SkyBlue;
						var red = Brushes.OrangeRed;
						var green = Brushes.LawnGreen;
						var yellow = Brushes.Yellow;
						var white = Brushes.White;

						foreach (var ns in NetState.Instances)
						{
							var m = ns.Mobile;

							if (m?.Deleted == false)
							{
								if (m.Map == m_Map)
								{
									var tool = m.Blessed ? yellow : m.Kills >= 5 ? red : m.Criminal ? gray : blue;

									g.FillRectangle(tool, m.Location.X, m.Location.Y, 1, 1);
								}
								else if (m.LogoutMap == m_Map)
								{
									g.FillRectangle(white, m.LogoutLocation.X, m.LogoutLocation.Y, 1, 1);
								}
							}
						}
					}
				}
				else
				{
					m_MobileOverlay?.Dispose();
					m_MobileOverlay = null;
				}

				if (refresh)
				{
					Refresh();
				}
			});
		}

		private void UpdateRegionOverlay(bool refresh)
		{
			Invoke(() =>
			{
				if (EnsureOverlay(ref m_RegionOverlay))
				{
					using var g = Graphics.FromImage(m_RegionOverlay);

					g.Clear(Color.Transparent);

					foreach (var region in m_Map.Regions)
					{
						if (m_MapRegion != region)
						{
							DrawRegion(g, region);
						}
					}

					DrawRegion(g, m_MapRegion);
				}
				else
				{
					m_RegionOverlay?.Dispose();
					m_RegionOverlay = null;
				}

				if (refresh)
				{
					Refresh();
				}
			});
		}

		private void DrawRegion(Graphics g, Region region)
		{
			if (region == null || region.Deleted || region.IsDefault || !region.Registered || region.Map != m_Map)
			{
				return;
			}

			var greenBrush = Brushes.LightGreen;
			var yellowBrush = Brushes.Yellow;
			var whiteBrush = Brushes.White;
			var grayBrush = Brushes.Gray;

			var yellowPen = Pens.Yellow;
			var whitePen = Pens.White;
			var greyPen = Pens.Gray;

			using var font = new Font(Font, FontStyle.Italic);

			var pointRadi = VertexRadius;
			var pointSize = (pointRadi * 2) + 1;

			var selectedRegion = m_MapRegion == region;

			var area = region.Area;

			for (var polyIndex = 0; polyIndex < area.Length; polyIndex++)
			{
				var poly = area[polyIndex];

				if (selectedRegion && m_PolyIndex == polyIndex)
				{
					continue;
				}

				for (int i = 0, n = 1; i < poly.Count; i = n++)
				{
					var p1 = poly[i];
					var p2 = poly[n % poly.Count];

					g.DrawLine(selectedRegion ? whitePen : greyPen, p1.X, p1.Y, p2.X, p2.Y);
				}

				for (var i = 0; i < poly.Count; i++)
				{
					var p = poly[i];

					if (selectedRegion)
					{
						g.FillRectangle(whiteBrush, p.X - pointRadi, p.Y - pointRadi, pointSize, pointSize);
						g.FillRectangle(grayBrush, p.X - pointRadi + 1, p.Y - pointRadi + 1, pointSize - 2, pointSize - 2);
						g.FillRectangle(whiteBrush, p.X, p.Y, 1, 1);
					}
					else
					{
						g.FillRectangle(grayBrush, p.X - pointRadi + 1, p.Y - pointRadi + 1, pointSize - 2, pointSize - 2);
					}
				}
			}

			if (selectedRegion && m_PolyIndex >= 0)
			{
				var poly = area[m_PolyIndex];

				for (int i = 0, n = 1; i < poly.Count; i = n++)
				{
					var p1 = poly[i];
					var p2 = poly[n % poly.Count];

					g.DrawLine(yellowPen, p1.X, p1.Y, p2.X, p2.Y);
				}

				for (var i = 0; i < poly.Count; i++)
				{
					var p = poly[i];

					if (m_PointIndex == i)
					{
						g.FillRectangle(yellowBrush, p.X - pointRadi, p.Y - pointRadi, pointSize, pointSize);
						g.FillRectangle(greenBrush, p.X - pointRadi + 1, p.Y - pointRadi + 1, pointSize - 2, pointSize - 2);
						g.FillRectangle(yellowBrush, p.X, p.Y, 1, 1);
					}
					else
					{
						g.FillRectangle(whiteBrush, p.X - pointRadi, p.Y - pointRadi, pointSize, pointSize);
						g.FillRectangle(grayBrush, p.X - pointRadi + 1, p.Y - pointRadi + 1, pointSize - 2, pointSize - 2);
						g.FillRectangle(whiteBrush, p.X, p.Y, 1, 1);
					}
				}
			}
		}

		private void OnCanvasPaint(object sender, PaintEventArgs e)
		{
			if (m_Map == null)
			{
				return;
			}

			if (sender == Canvas)
			{
				//e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
				//e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
				e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
				e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;

				if (m_MobileOverlay != null)
				{
					e.Graphics.DrawImage(m_MobileOverlay, Canvas.ClientRectangle);
				}

				if (m_RegionOverlay != null)
				{
					e.Graphics.DrawImage(m_RegionOverlay, Canvas.ClientRectangle);
				}
			}
		}

		private void OnCanvasMouseClick(object sender, MouseEventArgs e)
		{
			if (m_Map == null)
			{
				return;
			}

			int x = e.X, y = e.Y;

			TranslateToCanvas(true, ref x, ref y);

			if (GetData(x, y, out var region, out var polyIndex, out var pointIndex))
			{
			}

			if (e.Button == MouseButtons.Left)
			{
				SetMapRegion(region, polyIndex, pointIndex);
			}
		}

		private void OnCanvasMouseMove(object sender, MouseEventArgs e)
		{
			if (m_Map == null)
			{
				return;
			}

			int x = e.X, y = e.Y;

			TranslateToCanvas(true, ref x, ref y);

			if (GetData(x, y, out var region, out var polyIdx, out var pointIdx))
			{
			}

			Cursor.Current = Canvas.Cursor = pointIdx >= 0 ? Cursors.SizeAll : Cursors.Cross;

			if (m_Tooltip != null)
			{
				var p = new Point(x, y);

				p.Offset(-HorizontalScroll.Value, -VerticalScroll.Value);
				p.Offset(20, 20);

				if (region != null)
				{
					m_Tooltip.Show($"({x}, {y}) {region} [{polyIdx}, {pointIdx}]", this, p);
				}
				else
				{
					m_Tooltip.Show($"({x}, {y})", this, p);
				}
			}

			//UpdateZoomOverlay(true);
		}

		private void OnCanvasMouseEnter(object sender, EventArgs e)
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

		private void OnCanvasMouseLeave(object sender, EventArgs e)
		{
			m_Tooltip?.Hide(this);
		}

		private void TranslateToCanvas(bool relative, ref int x, ref int y)
		{
			if (!relative)
			{
				x += HorizontalScroll.Value;
				y += VerticalScroll.Value;
			}
		}

		private bool GetData(int x, int y, out Region region, out int polyIdx, out int pointIdx)
		{
			region = Server.Region.Find(x, y, m_Map);

			if (!region.IsDefault)
			{
				return GetPoly(region.Area, x, y, out polyIdx, out pointIdx);
			}

			var delta = VertexRadius;

			var minX = x - delta;
			var minY = y - delta;

			var maxX = x + delta;
			var maxY = y + delta;

			for (var xx = minX; xx <= maxX; xx++)
			{
				for (var yy = minY; yy <= maxY; yy++)
				{
					region = Server.Region.Find(xx, yy, m_Map);

					if (!region.IsDefault && GetPoly(region.Area, xx, yy, out polyIdx, out pointIdx))
					{
						return true;
					}
				}
			}

			region = null;
			polyIdx = -1;
			pointIdx = -1;

			return false;
		}

		private bool GetPoly(Poly3D[] area, int x, int y, out int polyIdx, out int pointIdx)
		{
			for (var polyIndex = 0; polyIndex < area.Length; polyIndex++)
			{
				var poly = area[polyIndex];

				if (GetPoint(poly, x, y, out pointIdx))
				{
					polyIdx = polyIndex;

					return true;
				}

				if (poly.Contains(x, y))
				{
					polyIdx = polyIndex;

					return true;
				}
			}

			polyIdx = -1;
			pointIdx = -1;

			return false;
		}

		private bool GetPoint(Poly3D poly, int x, int y, out int pointIdx)
		{
			var delta = VertexRadius;

			var minX = x - delta;
			var minY = y - delta;

			var maxX = x + delta;
			var maxY = y + delta;

			for (var pointIndex = 0; pointIndex < poly.Count; pointIndex++)
			{
				var point = poly[pointIndex];

				if (point.X >= minX && point.Y >= minY && point.X <= maxX && point.Y <= maxY)
				{
					pointIdx = pointIndex;

					return true;
				}
			}

			pointIdx = -1;

			return false;
		}

		public void ScrollRegionIntoView()
		{
			ScrollRegionIntoView(m_MapRegion);
		}

		public void ScrollRegionIntoView(Region region)
		{
			Invoke(() =>
			{
				if (region != null && !region.Deleted && !region.IsDefault && region.Registered && region.Map == m_Map)
				{
					SuspendLayout();

					// NOTE: values are updated twice to fix a native scrolling desync bug
					HorizontalScroll.Value = HorizontalScroll.Value = Math.Clamp(region.GoLocation.X - (ClientSize.Width / 2), HorizontalScroll.Minimum, HorizontalScroll.Maximum);
					VerticalScroll.Value = VerticalScroll.Value = Math.Clamp(region.GoLocation.Y - (ClientSize.Height / 2), VerticalScroll.Minimum, VerticalScroll.Maximum);

					ResumeLayout(true);
				}
			});
		}
	}
}
