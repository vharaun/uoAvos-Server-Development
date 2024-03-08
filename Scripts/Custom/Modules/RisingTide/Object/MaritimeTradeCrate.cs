﻿using Server.Factions;
using System;

namespace Server.Items
{
	/// MaritimeTradeCrate
	[Furniture]
	[Flipable(0xA2C4, 0xA2C5)]
	public class MaritimeTradeCrate : LockableContainer
	{
		[Constructable]
		public MaritimeTradeCrate() : base(0xA2C4)
		{
			GumpID = 0x9CDF;
		}

		public MaritimeTradeCrate(Serial serial) : base(serial)
		{
		}

		//public static void Initialize()
		//{
		//	TileData.ItemTable[0xA2C4].Flags |= TileFlag.Container;
		//	TileData.ItemTable[0xA2C5].Flags |= TileFlag.Container;
		//}

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
}


//using System;

//using Server;
//using Server.Items;
//using Server.Mobiles;
//using Server.Engines.CityLoyalty;
//using Server.Engines.RisingTide;

namespace Server.Items
{
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
		private CargoQuality _CargoQuality;
		private CargoType _CargoType;
		private Town _City;

		[CommandProperty(AccessLevel.GameMaster)]
		public CargoQuality CargoQuality
		{
			get { return _CargoQuality; }
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
			get { return _CargoType; }
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
		public Town City { get { return _City; } set { _City = value; InvalidateProperties(); } }

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
			//switch (Utility.Random(8))
			//{
			//	default:
			//	case 0: return CargoType.Cloth;
			//	case 1: return CargoType.Jewelry;
			//	case 2: return CargoType.Wood;
			//	case 3: return CargoType.Metal;
			//	case 4: return CargoType.Munitions;
			//	case 5: return CargoType.Granite;
			//	case 6: return CargoType.Reagents;
			//	case 7: return CargoType.Glassware;
			//}
		}

		public int GetAwardAmount()
		{
			int amount;

			switch (_CargoQuality)
			{
				default:
				case CargoQuality.Grandmaster: amount = Utility.RandomMinMax(100, 200); break;
				case CargoQuality.Exalted: amount = Utility.RandomMinMax(500, 600); break;
				case CargoQuality.Legendary: amount = Utility.RandomMinMax(1000, 1100); break;
				case CargoQuality.Mythical: amount = Utility.RandomMinMax(10000, 15000); break;
			}

			return amount;
		}

		public override void AddNameProperty(ObjectPropertyList list)
		{
			//list.Add(1158906, String.Format("#{0}", CityLoyaltySystem.GetCityLocalization(_City).ToString())); // Maritime Trade Cargo Destined for ~1_CITY~
			//list.Add(1158906, $"{CityLoyaltySystem.GetCityLocalization(_City):#}"); // Maritime Trade Cargo Destined for ~1_CITY~
			list.Add(1158906, $"{City:#}");
		}

		public override void AddWeightProperty(ObjectPropertyList list)
		{
			base.AddWeightProperty(list);

			list.Add(_CargoQuality < CargoQuality.Mythical ? 1158903 + (int)_CargoQuality : 1158969, String.Format("#{0}", TypeLabel(_CargoType)));
		}

		public static int TypeLabel(CargoType type)
		{
			switch (type)
			{
				default:
				case CargoType.Cloth: return 1044286;
				case CargoType.Jewelry: return 1011172;
				case CargoType.Wood: return 1079435;
				case CargoType.Metal: return 1049567;
				case CargoType.Munitions: return 1158902;
				case CargoType.Granite: return 1158900;
				case CargoType.Reagents: return 1002127;
				case CargoType.Glassware: return 1158901;
			}
		}

		public MaritimeCargo(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);

			writer.Write((int)_CargoQuality);
			writer.Write((int)_CargoType);
			Town.WriteReference(writer, _City);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			_CargoQuality = (CargoQuality)reader.ReadInt();
			_CargoType = (CargoType)reader.ReadInt();
			_City = Town.ReadReference(reader);
		}
	}
}