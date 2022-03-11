using Server.Multis.Deeds;

namespace Server.Multis
{
	public class SmallTower : BaseHouse
	{
		public static Rectangle2D[] AreaArray = new Rectangle2D[] { new Rectangle2D(-3, -3, 8, 7), new Rectangle2D(2, 4, 3, 1) };

		public override int DefaultPrice => 88500;

		public override HousePlacementEntry ConvertEntry => HousePlacementEntry.TwoStoryFoundations[6];

		public override Rectangle2D[] Area => AreaArray;
		public override Point3D BaseBanLocation => new Point3D(1, 4, 0);

		public SmallTower(Mobile owner) : base(0x98, owner, 580, 4)
		{
			var keyValue = CreateKeys(owner);

			AddSouthDoor(false, 3, 3, 6, keyValue);

			SetSign(1, 4, 5);
		}

		public SmallTower(Serial serial) : base(serial)
		{
		}

		public override HouseDeed GetDeed() { return new SmallTowerDeed(); }

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
	public class SmallTowerDeed : HouseDeed
	{
		[Constructable]
		public SmallTowerDeed() : base(0x98, new Point3D(3, 4, 0))
		{
		}

		public SmallTowerDeed(Serial serial) : base(serial)
		{
		}

		public override BaseHouse GetHouse(Mobile owner)
		{
			return new SmallTower(owner);
		}

		public override int LabelNumber => 1041237;
		public override Rectangle2D[] Area => SmallTower.AreaArray;

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