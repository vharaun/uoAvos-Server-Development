#region Developer Notations

/// Static Weather:
/// Format: Weather.Register( facet, temperature, chanceOfPercipitation, chanceOfExtremeTemperature, <area ...> );

/// Dynamic weather:
/// Format: DynamicWeather.Register( facet, temperature, chanceOfPercipitation, chanceOfExtremeTemperature, moveSpeed, width, height, bounds );

#endregion

namespace Server.Engines.Weather
{
	public static class DaggerIslandWeather
	{
		public static void Initialize()
		{
			var facets = new Map[] { Map.Felucca, Map.Trammel };

			foreach (var facet in facets)
			{
				Weather.Register(facet, - 15, 100, 5, new Rectangle2D(3850, 160, 390, 320), new Rectangle2D(3900, 480, 380, 180), new Rectangle2D(4160, 660, 150, 110));
			}
		}
	}
}