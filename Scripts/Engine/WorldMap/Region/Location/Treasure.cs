using Server.Items;
using Server.Regions;

using System;

namespace Server
{
	public class TreasureRegion : BaseRegion
	{
		private const int Range = 5; // No house may be placed within 5 tiles of the treasure

		public TreasureRegion(int x, int y, Map map) : base(null, map, Region.DefaultPriority, new Rectangle2D(x - Range, y - Range, 1 + (Range * 2), 1 + (Range * 2)))
		{
			GoLocation = new Point3D(x, y, map.GetAverageZ(x, y));

			Register();
		}

		public static void Initialize()
		{
			for (var i = 0; i < TreasureMap.Locations.Length; i++)
			{
				var loc = TreasureMap.Locations[i];

				try
				{
					_ = new TreasureRegion(loc.X, loc.Y, Map.Felucca);
					_ = new TreasureRegion(loc.X, loc.Y, Map.Trammel);
				}
				catch (Exception e)
				{
					Console.WriteLine($"Warning: Invalid TreasureRegion: #{i}: {loc}");
					Console.WriteLine(e);
				}
			}
		}

		public override bool AllowHousing(Mobile from, Point3D p)
		{
			return false;
		}

		public override void OnEnter(Mobile m)
		{
			if (m.AccessLevel > AccessLevel.Player)
			{
				m.SendMessage("You have entered a protected treasure map area.");
			}
		}

		public override void OnExit(Mobile m)
		{
			if (m.AccessLevel > AccessLevel.Player)
			{
				m.SendMessage("You have left a protected treasure map area.");
			}
		}
	}
}