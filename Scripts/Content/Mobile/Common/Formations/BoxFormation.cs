#region References
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Server.Mobiles
{
	public class BoxFormation : Formation
	{
		public BoxFormation()
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

			var center = Location;

			for (var x = -range; x <= range; x++)
			{
				for (var y = -range; y <= range; y++)
				{
					yield return new Point2D(center.X + x, center.Y + y);
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