using Server.Items;

namespace Server.Engines.Weather
{
	public class WeatherMap : MapItem
	{
		public override string DefaultName => "weather map";

		[Constructable]
		public WeatherMap()
		{
			SetDisplay(Map.Felucca, 400, 400);
		}

		public override void DisplayTo(Mobile from)
		{
			SetDisplay(from.Map, 400, 400);

			ClearPins();

			foreach (var w in Weather.GetWeatherList(from.Map))
			{
				foreach (var a in w.Area)
				{
					foreach (var p in a.Points)
					{
						AddWorldPin(p.X, p.Y);
					}
				}
			}

			base.DisplayTo(from);
		}

		public WeatherMap(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}