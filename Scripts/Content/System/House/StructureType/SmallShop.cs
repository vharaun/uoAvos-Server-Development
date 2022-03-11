using Server.Items;
using Server.Multis.Deeds;

namespace Server.Multis
{
	public class SmallShop : BaseHouse
	{
		public override Rectangle2D[] Area => (ItemID == 0x40A2 ? AreaArray1 : AreaArray2);
		public override Point3D BaseBanLocation => new Point3D(3, 4, 0);

		public override int DefaultPrice => 63000;

		public override HousePlacementEntry ConvertEntry => HousePlacementEntry.TwoStoryFoundations[0];

		public static Rectangle2D[] AreaArray1 = new Rectangle2D[] { new Rectangle2D(-3, -3, 7, 7), new Rectangle2D(-1, 4, 4, 1) };
		public static Rectangle2D[] AreaArray2 = new Rectangle2D[] { new Rectangle2D(-3, -3, 7, 7), new Rectangle2D(-2, 4, 3, 1) };

		public SmallShop(Mobile owner, int id) : base(id, owner, 425, 3)
		{
			var keyValue = CreateKeys(owner);

			var door = MakeDoor(false, DoorFacing.EastCW);

			door.Locked = true;
			door.KeyValue = keyValue;

			if (door is BaseHouseDoor)
			{
				((BaseHouseDoor)door).Facing = DoorFacing.EastCCW;
			}

			AddDoor(door, -2, 0, id == 0xA2 ? 24 : 27);

			//AddSouthDoor( false, -2, 0, 27 - (id == 0xA2 ? 3 : 0), keyValue );

			SetSign(3, 4, 7 - (id == 0xA2 ? 2 : 0));
		}

		public SmallShop(Serial serial) : base(serial)
		{
		}

		public override HouseDeed GetDeed()
		{
			switch (ItemID)
			{
				case 0xA0: return new StoneWorkshopDeed();
				case 0xA2:
				default: return new MarbleWorkshopDeed();
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}

namespace Server.Multis.Deeds
{
	public class StoneWorkshopDeed : HouseDeed
	{
		[Constructable]
		public StoneWorkshopDeed() : base(0xA0, new Point3D(-1, 4, 0))
		{
		}

		public StoneWorkshopDeed(Serial serial) : base(serial)
		{
		}

		public override BaseHouse GetHouse(Mobile owner)
		{
			return new SmallShop(owner, 0xA0);
		}

		public override int LabelNumber => 1041241;
		public override Rectangle2D[] Area => SmallShop.AreaArray2;

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

	public class MarbleWorkshopDeed : HouseDeed
	{
		[Constructable]
		public MarbleWorkshopDeed() : base(0xA2, new Point3D(-1, 4, 0))
		{
		}

		public MarbleWorkshopDeed(Serial serial) : base(serial)
		{
		}

		public override BaseHouse GetHouse(Mobile owner)
		{
			return new SmallShop(owner, 0xA2);
		}

		public override int LabelNumber => 1041242;
		public override Rectangle2D[] Area => SmallShop.AreaArray1;

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