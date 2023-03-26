using Server.Network;
using Server.Regions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Engines.Weather
{
	[PropertyObject]
	public partial class Weather
	{
		private static readonly Dictionary<Map, HashSet<Weather>> m_WeatherByFacet = new();

		public static HashSet<Weather> GetWeatherList(Map facet)
		{
			if (facet == null)
			{
				return null;
			}

			if (!m_WeatherByFacet.TryGetValue(facet, out var list) || list == null)
			{
				m_WeatherByFacet[facet] = list = new();
			}

			return list;
		}

		public static void Unregister(Weather w)
		{
			GetWeatherList(w?.Facet)?.Remove(w);
		}

		public static void Register(Weather w)
		{
			GetWeatherList(w?.Facet)?.Add(w);
		}

		public static Weather Register(Map facet, int temperature, int chanceOfPercipitation, int chanceOfExtremeTemperature, params Poly2D[] area)
		{
			return new Weather(facet, area, temperature, chanceOfPercipitation, chanceOfExtremeTemperature, TimeSpan.FromSeconds(30.0));
		}

		private Timer m_Timer;

		[CommandProperty(AccessLevel.Counselor, true)]
		public Map Facet { get; private set; }

		//[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Poly2D[] Area { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public int Temperature { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public int ChanceOfPercipitation { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public int ChanceOfExtremeTemperature { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool Enabled { get => m_Timer.Running; set => m_Timer.Running = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public TimeSpan Interval { get => m_Timer.Interval; set => m_Timer.Interval = value; }

		[CommandProperty(AccessLevel.Counselor, true)]
		public int Stage { get; protected set; }

		[CommandProperty(AccessLevel.Counselor, true)]
		public bool IsActive { get; protected set; }

		[CommandProperty(AccessLevel.Counselor, true)]
		public bool IsExtremeTemperature { get; protected set; }

		[CommandProperty(AccessLevel.Counselor, true)]
		public bool IsRegistered => GetWeatherList(Facet)?.Contains(this) == true;

		public Weather(Map facet, Poly2D[] area, int temperature, int chanceOfPercipitation, int chanceOfExtremeTemperature, TimeSpan interval)
		{
			Facet = facet;

			Area = area;

			Temperature = temperature;

			ChanceOfPercipitation = chanceOfPercipitation;
			ChanceOfExtremeTemperature = chanceOfExtremeTemperature;

			Init(interval);

			Register(this);
		}

		public Weather(GenericReader reader)
		{
			Deserialize(reader);

			Register(this);
		}

		public override string ToString()
		{
			return String.Join(", ", Area);
		}

		private void Init(TimeSpan interval)
		{
			m_Timer?.Stop();

			m_Timer = Timer.DelayCall(TimeSpan.FromSeconds((0.2 + (Utility.RandomDouble() * 0.8)) * interval.TotalSeconds), interval, OnTick);
		}

		public bool Intersects(Poly2D area)
		{
			for (var i = 0; i < Area.Length; i++)
			{
				if (Area[i].Intersects(area))
				{
					return true;
				}
			}

			return false;
		}

		protected virtual void OnTick()
		{
			if (Stage == 0)
			{
				Delta();
			}

			if (IsActive)
			{
				Process();
			}

			Stage++;
			Stage %= 30;
		}

		protected virtual void Delta()
		{
			IsActive = ChanceOfPercipitation > Utility.Random(100);
			IsExtremeTemperature = ChanceOfExtremeTemperature > Utility.Random(100);
		}

		protected virtual void Process()
		{
			int type, density, temperature;

			temperature = Temperature;

			if (IsExtremeTemperature)
			{
				temperature *= -1;
			}

			if (Stage < 15)
			{
				density = Stage * 5;
			}
			else
			{
				density = 150 - (Stage * 5);

				if (density < 10)
				{
					density = 10;
				}
				else if (density > 70)
				{
					density = 70;
				}
			}

			if (density == 0)
			{
				type = 0xFE;
			}
			else if (temperature > 0)
			{
				type = 0;
			}
			else
			{
				type = 2;
			}

			SendPacket(type, density, temperature);
		}

		protected virtual void SendPacket(int type, int density, int temperature)
		{
			var states = NetState.Instances;

			WeatherUpdate weatherPacket = null;

			for (var i = 0; i < states.Count; ++i)
			{
				var ns = states[i];
				var mob = ns.Mobile;

				if (mob == null || mob.Map != Facet)
				{
					continue;
				}

				var contains = Area.Length == 0;

				for (var j = 0; !contains && j < Area.Length; ++j)
				{
					contains = Area[j].Contains(mob.Location);
				}

				if (!contains)
				{
					continue;
				}

				if (weatherPacket == null)
				{
					weatherPacket = Packet.Acquire(new WeatherUpdate(type, density, temperature));
				}

				ns.Send(weatherPacket);
			}

			Packet.Release(weatherPacket);
		}

		public virtual void Serialize(GenericWriter writer)
		{
			writer.Write(0);

			writer.Write(Facet);

			writer.Write(Area.Length);

			for (var i = 0; i < Area.Length; i++)
			{
				writer.Write(Area[i]);
			}

			writer.Write(Temperature);

			writer.Write(ChanceOfPercipitation);
			writer.Write(ChanceOfExtremeTemperature);

			writer.Write(Enabled);
			writer.Write(Interval);

			writer.Write(Stage);

			writer.Write(IsActive);
			writer.Write(IsExtremeTemperature);
		}

		public virtual void Deserialize(GenericReader reader)
		{
			reader.ReadInt();

			Facet = reader.ReadMap();

			Area = new Poly2D[reader.ReadInt()];

			for (var i = 0; i < Area.Length; i++)
			{
				Area[i] = reader.ReadPoly2D();
			}

			Temperature = reader.ReadInt();

			ChanceOfPercipitation = reader.ReadInt();
			ChanceOfExtremeTemperature = reader.ReadInt();

			var enabled = reader.ReadBool();
			var interval = reader.ReadTimeSpan();

			Stage = reader.ReadInt();

			IsActive = reader.ReadBool();
			IsExtremeTemperature = reader.ReadBool();

			Init(interval);

			Enabled = enabled;
		}
	}

	public sealed class DynamicWeather : Weather
	{
		public static DynamicWeather Register(Map facet, int temperature, int chanceOfPercipitation, int chanceOfExtremeTemperature, int moveSpeed, int width, int height, Rectangle2D bounds)
		{
			var area = Rectangle2D.Empty;
			var isValid = false;

			for (var j = 0; j < 10; ++j)
			{
				area = new Rectangle2D(bounds.X + Utility.Random(bounds.Width - width), bounds.Y + Utility.Random(bounds.Height - height), width, height);

				if (!CheckWeatherConflict(facet, null, area))
				{
					isValid = true;
				}

				if (isValid)
				{
					break;
				}
			}

			if (isValid)
			{
				var w = new DynamicWeather(facet, area, bounds, moveSpeed, temperature, chanceOfPercipitation, chanceOfExtremeTemperature, TimeSpan.FromSeconds(30.0));

				return w;
			}

			return null;
		}

		private static bool CheckWeatherConflict(Map facet, Weather exclude, Poly2D area)
		{
			var list = GetWeatherList(facet);

			if (list == null)
			{
				return false;
			}

			foreach (var w in list)
			{
				if (w != exclude && w.Intersects(area))
				{
					return true;
				}
			}

			return false;
		}

		[CommandProperty(AccessLevel.Counselor, true)]
		public Rectangle2D Bounds { get; private set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public int MoveSpeed { get; set; }

		[CommandProperty(AccessLevel.Counselor, true)]
		public int MoveAngleX { get; private set; }

		[CommandProperty(AccessLevel.Counselor, true)]
		public int MoveAngleY { get; private set; }

		private DynamicWeather(Map facet, Rectangle2D area, Rectangle2D bounds, int speed, int temperature, int chanceOfPercipitation, int chanceOfExtremeTemperature, TimeSpan interval)
			: base(facet, new Poly2D[] { area }, temperature, chanceOfPercipitation, chanceOfExtremeTemperature, interval)
		{
			Bounds = bounds;
			MoveSpeed = speed;
		}

		protected override void Delta()
		{
			base.Delta();

			if (MoveSpeed > 0)
			{
				RecalculateMovementAngle();
			}
		}

		protected override void Process()
		{
			if (Stage > 0 && MoveSpeed > 0)
			{
				MoveForward();
			}

			base.Process();
		}

		private void RecalculateMovementAngle()
		{
			var angle = Utility.RandomDouble() * Math.PI * 2.0;

			MoveAngleX = (int)(100 * Math.Cos(angle));
			MoveAngleY = (int)(100 * Math.Sin(angle));
		}

		private void MoveForward()
		{
			static bool contains(Rectangle2D bounds, Poly2D area)
			{
				var areaBounds = area.Bounds;

				if (areaBounds.X < bounds.X)
				{
					return false;
				}

				if (areaBounds.Y < bounds.Y)
				{
					return false;
				}

				if (areaBounds.X + areaBounds.Width > bounds.X + bounds.Width)
				{
					return false;
				}

				if (areaBounds.Y + areaBounds.Height > bounds.Y + bounds.Height)
				{
					return false;
				}

				return true;
			};

			if (Area.Length == 0)
			{
				return;
			}

			for (var i = 0; i < 5; i++) // try 5 times to find a valid spot
			{
				var xOffset = MoveSpeed * MoveAngleX / 100;
				var yOffset = MoveSpeed * MoveAngleY / 100;

				for (var j = 0; j < Area.Length; j++)
				{
					var area = new Poly2D(Area[j].Points.Select(p => new Point2D(p.X + xOffset, p.Y + yOffset)));

					if (!CheckWeatherConflict(Facet, this, area) && contains(Bounds, area))
					{
						Area[j] = area;
						continue;
					}

					RecalculateMovementAngle();
				}
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(Bounds);

			writer.Write(MoveSpeed);
			writer.Write(MoveAngleY);
			writer.Write(MoveAngleY);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();

			Bounds = reader.ReadRect2D();

			MoveSpeed = reader.ReadInt();
			MoveAngleY = reader.ReadInt();
			MoveAngleY = reader.ReadInt();
		}
	}

	public sealed class RegionalWeather : Weather
	{
		private static Poly2D[] Convert(Poly3D[] area)
		{
			var newArea = new Poly2D[area.Length];

			for (var i = 0; i < area.Length; i++)
			{
				newArea[i] = area[i];
			}

			return newArea;
		}

		[CommandProperty(AccessLevel.Counselor, true)]
		public BaseRegion Region { get; private set; }

		public RegionalWeather(BaseRegion region)
			: base(region.Map, Convert(region.Area), region.DefaultTemperature, region.DefaultPercipitationChance, region.DefaultExtremeTemperatureChance, TimeSpan.FromSeconds(30))
		{
			Region = region;

			Enabled = false;
		}

		public RegionalWeather(GenericReader reader)
			: base(reader)
		{ }

		public void Update()
		{
			if (Region.Area.Length != Area.Length)
			{
				Area = Convert(Region.Area);
				return;
			}

			for (var i = 0; i < Region.Area.Length; i++)
			{
				if (!Enumerable.SequenceEqual(Region.Area[i].Points, Area[i].Points))
				{
					Area = Convert(Region.Area);
					return;
				}
			}
		}

		protected override void OnTick()
		{
			if (Region?.Deleted != false)
			{
				Region = null;
				Enabled = false;

				Unregister(this);
			}
			else if (Region.Registered)
			{
				base.OnTick();
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(Region);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();

			Region = reader.ReadRegion<BaseRegion>();
		}
	}

	public sealed class WeatherRegion : BaseRegion
	{
		public override bool WeatherSupported => true;

		public WeatherRegion(string name, Map map, int priority, params Rectangle2D[] area) : base(name, map, priority, area)
		{
		}

		public WeatherRegion(string name, Map map, int priority, params Poly2D[] area) : base(name, map, priority, area)
		{
		}

		public WeatherRegion(string name, Map map, int priority, params Rectangle3D[] area) : base(name, map, priority, area)
		{
		}

		public WeatherRegion(string name, Map map, int priority, params Poly3D[] area) : base(name, map, priority, area)
		{
		}

		public WeatherRegion(string name, Map map, Region parent, params Rectangle2D[] area) : base(name, map, parent, area)
		{
		}

		public WeatherRegion(string name, Map map, Region parent, params Poly2D[] area) : base(name, map, parent, area)
		{
		}

		public WeatherRegion(string name, Map map, Region parent, params Rectangle3D[] area) : base(name, map, parent, area)
		{
		}

		public WeatherRegion(string name, Map map, Region parent, params Poly3D[] area) : base(name, map, parent, area)
		{
		}

		public WeatherRegion(RegionDefinition def, Map map, Region parent) : base(def, map, parent)
		{
		}

		public WeatherRegion(int id) : base(id)
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

			reader.ReadInt();
		}
	}
}