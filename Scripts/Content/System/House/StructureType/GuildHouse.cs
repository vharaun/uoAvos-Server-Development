using Server.Multis.Deeds;

namespace Server.Multis
{
	public class GuildHouse : BaseHouse
	{
		public static Rectangle2D[] AreaArray = new Rectangle2D[] { new Rectangle2D(-7, -7, 14, 14), new Rectangle2D(-2, 7, 4, 1) };

		public override int DefaultPrice => 144500;

		public override HousePlacementEntry ConvertEntry => HousePlacementEntry.ThreeStoryFoundations[20];
		public override int ConvertOffsetX => -1;
		public override int ConvertOffsetY => -1;

		public override Rectangle2D[] Area => AreaArray;
		public override Point3D BaseBanLocation => new Point3D(4, 8, 0);

		public GuildHouse(Mobile owner) : base(0x74, owner, 1100, 8)
		{
			var keyValue = CreateKeys(owner);

			AddSouthDoors(-1, 6, 7, keyValue);

			SetSign(4, 8, 16);

			AddSouthDoor(-3, -1, 7);
			AddSouthDoor(3, -1, 7);
		}

		public GuildHouse(Serial serial) : base(serial)
		{
		}

		public override HouseDeed GetDeed() { return new BrickHouseDeed(); }

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
	public class BrickHouseDeed : HouseDeed
	{
		[Constructable]
		public BrickHouseDeed() : base(0x74, new Point3D(-1, 7, 0))
		{
		}

		public BrickHouseDeed(Serial serial) : base(serial)
		{
		}

		public override BaseHouse GetHouse(Mobile owner)
		{
			return new GuildHouse(owner);
		}

		public override int LabelNumber => 1041219;
		public override Rectangle2D[] Area => GuildHouse.AreaArray;

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