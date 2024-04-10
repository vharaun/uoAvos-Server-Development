#region References
using System;
using System.Collections.Generic;
#endregion

namespace Server.Mobiles
{
	public sealed class TriangleFormation : Formation
	{
		public TriangleFormation()
		{ }

		protected override IEnumerable<Point2D> ComputePoints()
		{
			var range = (int)Math.Ceiling(Math.Sqrt(Count));

			if (Separation > 0)
			{
				range *= Separation + 1;
			}

			range /= 2;

			if (range % 2 != 1)
			{
				++range;
			}
			
			var a = Angle2D.FromDirection((Direction)(((int)Facing + 4) % 8));

			var p1 = new Point2D(Location);
			var p2 = Angle2D.GetPoint2D(p1.X, p1.Y, a - 120, range);
			var p3 = Angle2D.GetPoint2D(p1.X, p1.Y, a + 120, range);

			var triangle = new Poly2D(p1, p2, p3);

			var center = triangle.Bounds.Center;

			for (var x = -range; x <= range; x++)
			{
				for (var y = -range; y <= range; y++)
				{
					if (triangle.Contains(center.X + x, center.Y + y))
					{
						yield return new Point2D(center.X + x, center.Y + y);
					}
				}
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadEncodedInt();
		}
	}
}