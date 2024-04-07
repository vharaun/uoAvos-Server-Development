#region References
using System.Collections.Generic;
#endregion

namespace Server.Mobiles
{
	public class LineFormation : Formation
	{
		public LineFormation()
		{ }

		protected override IEnumerable<Point2D> ComputePoints()
		{
			var length = Count + ((Count - 1) * Separation);

			var rx = 0;
			var ry = 0;

			Movement.Movement.Offset(Commander.Direction, ref rx, ref ry);

			rx *= -1;
			ry *= -1;

			var end = new Point2D(X + (rx * (length + 1)), Y + (ry * (length + 1)));

			var i = -1;

			foreach (var p in Geometry.TraceLine2D(Location, end))
			{
				if (++i % Separation == 0)
				{
					yield return p;
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