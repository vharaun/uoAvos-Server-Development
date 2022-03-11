using Server.Multis.Deeds;

namespace Server.Multis
{
	public class Tower : BaseHouse
	{
		public static Rectangle2D[] AreaArray = new Rectangle2D[] { new Rectangle2D(-7, -7, 16, 14), new Rectangle2D(-1, 7, 4, 2), new Rectangle2D(-11, 0, 4, 7), new Rectangle2D(9, 0, 4, 7) };

		public override int DefaultPrice => 433200;

		public override HousePlacementEntry ConvertEntry => HousePlacementEntry.ThreeStoryFoundations[37];
		public override int ConvertOffsetY => -1;

		public override Rectangle2D[] Area => AreaArray;
		public override Point3D BaseBanLocation => new Point3D(5, 8, 0);

		public Tower(Mobile owner) : base(0x7A, owner, 2119, 15)
		{
			var keyValue = CreateKeys(owner);

			AddSouthDoors(false, 0, 6, 6, keyValue);

			SetSign(5, 8, 16);

			AddSouthDoor(false, 3, -2, 6);
			AddEastDoor(false, 1, 4, 26);
			AddEastDoor(false, 1, 4, 46);
		}

		public Tower(Serial serial) : base(serial)
		{
		}

		public override HouseDeed GetDeed() { return new TowerDeed(); }

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
	public class TowerDeed : HouseDeed
	{
		[Constructable]
		public TowerDeed() : base(0x7A, new Point3D(0, 7, 0))
		{
		}

		public TowerDeed(Serial serial) : base(serial)
		{
		}

		public override BaseHouse GetHouse(Mobile owner)
		{
			return new Tower(owner);
		}

		public override int LabelNumber => 1041222;
		public override Rectangle2D[] Area => Tower.AreaArray;

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