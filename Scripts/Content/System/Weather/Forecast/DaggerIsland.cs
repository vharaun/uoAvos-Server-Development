#region Developer Notations

/// Static Weather:
/// Format: AddWeather( temperature, chanceOfPercipitation, chanceOfExtremeTemperature, <area ...> );

/// Dynamic weather:
/// Format: AddDynamicWeather( temperature, chanceOfPercipitation, chanceOfExtremeTemperature, moveSpeed, width, height, bounds );

#endregion

namespace Server.Engines.Weather
{
	public partial class Weather
	{
		public static void DaggerIsland() // Dagger Island
		{
			m_Facets = new Map[] { Map.Felucca, Map.Trammel };

			AddWeather(-15, 100, 5, new Rectangle2D(3850, 160, 390, 320), new Rectangle2D(3900, 480, 380, 180), new Rectangle2D(4160, 660, 150, 110));

			/// Moves Weather Pattern Across The Entire Map
			for (var i = 0; i < 15; ++i)
			{
				AddDynamicWeather(+15, 100, 5, 8, 400, 400, new Rectangle2D(0, 0, 5120, 4096));
			}
		}
	}
}