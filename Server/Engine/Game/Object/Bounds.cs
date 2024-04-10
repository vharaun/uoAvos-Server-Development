
using System.Collections;
using System.Collections.Generic;

namespace Server
{
	public class ItemBounds : IEnumerable<Rectangle2D>
	{
		private static readonly Rectangle2D m_EmptyBounds = Rectangle2D.Empty;

		public static ItemBounds Table { get; } = new();

		private readonly bool[] m_Loaded;
		private readonly Rectangle2D[] m_Bounds;

		public int Length => m_Bounds.Length;

		public Rectangle2D this[int index] { get => GetBounds(index); set => SetBounds(index, value); }

		private ItemBounds()
		{
			m_Bounds = new Rectangle2D[TileData.ItemTable.Length];
			m_Loaded = new bool[m_Bounds.Length];
		}

		private Rectangle2D GetBounds(int index)
		{
			if (index < 0 || index >= m_Bounds.Length)
			{
				return m_EmptyBounds;
			}

			if (m_Loaded[index])
			{
				return m_Bounds[index];
			}

			m_Loaded[index] = true;

			var asset = Item.GetBitmap(index);

			if (asset != null)
			{
				Item.Measure(asset, out var xMin, out var yMin, out var xMax, out var yMax);

				m_Bounds[index].Set(xMin, yMin, xMax - xMin + 1, yMax - yMin + 1);
			}

			return m_Bounds[index];
		}

		private void SetBounds(int index, Rectangle2D value)
		{
			if (index < 0 || index >= m_Bounds.Length)
			{
				return;
			}

			m_Bounds[index] = value;
			m_Loaded[index] = value.X >= 0 && value.Y >= 0 && value.Width >= 0 && value.Height >= 0;
		}

		public IEnumerator<Rectangle2D> GetEnumerator()
		{
			for (var i = 0; i < m_Bounds.Length; i++)
			{
				yield return m_Bounds[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}