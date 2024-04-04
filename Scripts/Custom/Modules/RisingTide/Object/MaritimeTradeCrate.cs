using Server.Factions;
using System;

namespace Server.Items
{
	/// MaritimeTradeCrate
	[Furniture]
	[Flipable(0xA2C4, 0xA2C5)]
	public class MaritimeTradeCrate : LockableContainer
	{
		public override int DefaultGumpID => 0x9CDF;
		public override double DefaultWeight => 5.0;

		[Constructable]
		public MaritimeTradeCrate() : base(0xA2C4)
		{
		}

		public MaritimeTradeCrate(Serial serial) : base(serial)
		{
		}

		public override int DefaultMaxItems => 625;
		public override int DefaultMaxWeight => 1600;
		
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	public enum CargoQuality
	{
		Grandmaster,
		Exalted,
		Legendary,
		Mythical
	}

	public enum CargoType
	{
		Cloth = 1257,
		Jewelry = 353,
		Wood = 1155,
		Metal = 1175,
		Munitions = 1157,
		Granite = 2498,
		Reagents = 1156,
		Glassware = 1158,
	}

	// 1158907 You recover maritime trade cargo!

	[Flipable(0xA2C4, 0xA2C5)]
	public class MaritimeCargo : Item
	{
		public override double DefaultWeight => 5.0;

		private CargoQuality _CargoQuality;
		private CargoType _CargoType;
		private Town _City;

		[CommandProperty(AccessLevel.GameMaster)]
		public CargoQuality CargoQuality
		{
			get => _CargoQuality;
			set
			{
				_CargoQuality = value;

				if (_CargoQuality == CargoQuality.Mythical)
				{
					Hue = 1177;
				}

				InvalidateProperties();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public CargoType CargoType
		{
			get => _CargoType;
			set
			{
				_CargoType = value;

				if (_CargoQuality != CargoQuality.Mythical && Hue != (int)_CargoType)
				{
					Hue = (int)_CargoType;
				}

				InvalidateProperties();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Town City { get => _City; set { _City = value; InvalidateProperties(); } }

		[Constructable]
		public MaritimeCargo()
			: this(RandomQuality(), RandomCity(), RandomType())
		{
		}

		[Constructable]
		public MaritimeCargo(CargoQuality quality)
			: this(quality, RandomCity(), RandomType())
		{
		}

		[Constructable]
		public MaritimeCargo(CargoQuality quality, Town city, CargoType type)
			: base(0xA2C4)
		{
			CargoQuality = quality;
			City = city;
			CargoType = type;
		}

		private static CargoQuality RandomQuality()
		{
			var random = Utility.RandomDouble();

			if (random < 0.05)
			{
				return CargoQuality.Legendary;
			}

			if (random < 0.33)
			{
				return CargoQuality.Exalted;
			}

			return CargoQuality.Grandmaster;
		}

		private static Town RandomCity()
		{
			return Utility.RandomList(Town.Towns);
		}

		private static CargoType RandomType()
		{
			return Utility.RandomEnum<CargoType>();
		}

		public int GetAwardAmount()
		{
			var amount = _CargoQuality switch
			{
				CargoQuality.Grandmaster => Utility.RandomMinMax(100, 200),
				CargoQuality.Exalted => Utility.RandomMinMax(500, 600),
				CargoQuality.Legendary => Utility.RandomMinMax(1000, 1100),
				CargoQuality.Mythical => Utility.RandomMinMax(10000, 15000),
				_ => 0,
			};
			return amount;
		}

		public override void AddNameProperty(ObjectPropertyList list)
		{
			list.Add(1158906, $"{City:#}");
		}

		public override void AddWeightProperty(ObjectPropertyList list)
		{
			base.AddWeightProperty(list);

			list.Add(_CargoQuality < CargoQuality.Mythical ? 1158903 + (int)_CargoQuality : 1158969, String.Format("#{0}", TypeLabel(_CargoType)));
		}

		public static int TypeLabel(CargoType type)
		{
			return type switch
			{
				CargoType.Jewelry => 1011172,
				CargoType.Wood => 1079435,
				CargoType.Metal => 1049567,
				CargoType.Munitions => 1158902,
				CargoType.Granite => 1158900,
				CargoType.Reagents => 1002127,
				CargoType.Glassware => 1158901,
				CargoType.Cloth => 1044286,
				_ => 0,
			};
		}

		public MaritimeCargo(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); //version placeholder

			writer.Write((int)_CargoQuality);
			writer.Write((int)_CargoType);
			Town.WriteReference(writer, _City);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			_ = reader.ReadInt(); //version placeholder

			_CargoQuality = (CargoQuality)reader.ReadInt();
			_CargoType = (CargoType)reader.ReadInt();
			_City = Town.ReadReference(reader);
		}
	}
}
