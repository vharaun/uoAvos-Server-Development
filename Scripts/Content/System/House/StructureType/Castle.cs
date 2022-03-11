using Server.Multis.Deeds;

namespace Server.Multis
{
	public class Castle : BaseHouse
	{
		public static Rectangle2D[] AreaArray = new Rectangle2D[] { new Rectangle2D(-15, -15, 31, 31), new Rectangle2D(-1, 16, 4, 1) };

		public override int DefaultPrice => 1022800;

		public override Rectangle2D[] Area => AreaArray;
		public override Point3D BaseBanLocation => new Point3D(5, 17, 0);

		public Castle(Mobile owner) : base(0x7E, owner, 4076, 28)
		{
			var keyValue = CreateKeys(owner);

			AddSouthDoors(false, 0, 15, 6, keyValue);

			SetSign(5, 17, 16);

			AddSouthDoors(false, 0, 11, 6, true);
			AddSouthDoors(false, 0, 5, 6, false);
			AddSouthDoors(false, -1, -11, 6, false);
		}

		public Castle(Serial serial) : base(serial)
		{
		}

		public override HouseDeed GetDeed() { return new CastleDeed(); }

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
	public class CastleDeed : HouseDeed
	{
		[Constructable]
		public CastleDeed() : base(0x7E, new Point3D(0, 16, 0))
		{
		}

		public CastleDeed(Serial serial) : base(serial)
		{
		}

		public override BaseHouse GetHouse(Mobile owner)
		{
			return new Castle(owner);
		}

		public override int LabelNumber => 1041224;
		public override Rectangle2D[] Area => Castle.AreaArray;

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