#region Developer Notations

/// Static Weather:
/// Format: Weather.Register( facet, temperature, chanceOfPercipitation, chanceOfExtremeTemperature, <area ...> );

/// Dynamic weather:
/// Format: DynamicWeather.Register( facet, temperature, chanceOfPercipitation, chanceOfExtremeTemperature, moveSpeed, width, height, bounds );

#endregion

namespace Server.Engines.Weather
{
	public static class EastBritanniaWeather
	{
		public static void Initialize()
		{
			var facets = new Map[] { Map.Felucca, Map.Trammel };

			foreach (var facet in facets)
			{
				Weather.Register(facet, +15, 50, 5, new Rectangle2D(2425, 725, 250, 250));
			}
		}
	}
}