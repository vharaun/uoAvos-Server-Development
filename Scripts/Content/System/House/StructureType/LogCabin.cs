using Server.Multis.Deeds;

namespace Server.Multis
{
	public class LogCabin : BaseHouse
	{
		public static Rectangle2D[] AreaArray = new Rectangle2D[] { new Rectangle2D(-3, -6, 8, 13) };

		public override int DefaultPrice => 97800;

		public override HousePlacementEntry ConvertEntry => HousePlacementEntry.TwoStoryFoundations[12];

		public override Rectangle2D[] Area => AreaArray;
		public override Point3D BaseBanLocation => new Point3D(5, 8, 0);

		public LogCabin(Mobile owner) : base(0x9A, owner, 1100, 8)
		{
			var keyValue = CreateKeys(owner);

			AddSouthDoor(1, 4, 8, keyValue);

			SetSign(5, 8, 20);

			AddSouthDoor(1, 0, 29);
		}

		public LogCabin(Serial serial) : base(serial)
		{
		}

		public override HouseDeed GetDeed() { return new LogCabinDeed(); }

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
	public class LogCabinDeed : HouseDeed
	{
		[Constructable]
		public LogCabinDeed() : base(0x9A, new Point3D(1, 6, 0))
		{
		}

		public LogCabinDeed(Serial serial) : base(serial)
		{
		}

		public override BaseHouse GetHouse(Mobile owner)
		{
			return new LogCabin(owner);
		}

		public override int LabelNumber => 1041238;
		public override Rectangle2D[] Area => LogCabin.AreaArray;

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