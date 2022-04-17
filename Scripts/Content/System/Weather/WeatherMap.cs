using Server.Items;

namespace Server.Engines.Weather
{
	public class WeatherMap : MapItem
	{
		public override string DefaultName => "weather map";

		[Constructable]
		public WeatherMap()
		{
			SetDisplay(0, 0, 5119, 4095, 400, 400);
		}

		public override void OnDoubleClick(Mobile from)
		{
			var facet = from.Map;

			if (facet == null)
			{
				return;
			}

			var list = Weather.GetWeatherList(facet);

			ClearPins();

			foreach (var w in list)
			{
				foreach (var a in w.Area)
				{
					foreach (var p in a.Points)
					{
						AddWorldPin(p.X, p.Y);
					}
				}
			}

			base.OnDoubleClick(from);
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