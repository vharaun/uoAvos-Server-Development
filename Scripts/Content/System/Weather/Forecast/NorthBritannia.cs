#region Developer Notations

/// Static Weather:
/// Format: Weather.Register( facet, temperature, chanceOfPercipitation, chanceOfExtremeTemperature, <area ...> );

/// Dynamic weather:
/// Format: DynamicWeather.Register( facet, temperature, chanceOfPercipitation, chanceOfExtremeTemperature, moveSpeed, width, height, bounds );

#endregion

namespace Server.Engines.Weather
{
	public static class NorthBritanniaWeather
	{
		public static void Initialize() // Despise Entrance, North of Britain
		{
			var facets = new Map[] { Map.Felucca, Map.Trammel };

			foreach (var facet in facets)
			{
				Weather.Register(facet, +15, 50, 5, new Rectangle2D(1245, 1045, 250, 250));

				// Moves Weather Pattern Across The Entire Map
				for (var i = 0; i < 15; ++i)
				{
					DynamicWeather.Register(facet, +15, 100, 5, 8, 400, 400, new Rectangle2D(0, 0, 5120, 4096));
				}
			}
		}
	}
}