using Server.Multis.Deeds;

namespace Server.Multis
{
	public class LargeMarbleHouse : BaseHouse
	{
		public static Rectangle2D[] AreaArray = new Rectangle2D[] { new Rectangle2D(-7, -7, 15, 14), new Rectangle2D(-6, 7, 6, 1) };

		public override int DefaultPrice => 192000;

		public override HousePlacementEntry ConvertEntry => HousePlacementEntry.ThreeStoryFoundations[29];
		public override int ConvertOffsetY => -1;

		public override Rectangle2D[] Area => AreaArray;
		public override Point3D BaseBanLocation => new Point3D(1, 8, 0);

		public LargeMarbleHouse(Mobile owner) : base(0x96, owner, 1370, 10)
		{
			var keyValue = CreateKeys(owner);

			AddSouthDoors(false, -4, 3, 4, keyValue);

			SetSign(1, 8, 11);
		}

		public LargeMarbleHouse(Serial serial) : base(serial)
		{
		}

		public override HouseDeed GetDeed() { return new LargeMarbleDeed(); }

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
	public class LargeMarbleDeed : HouseDeed
	{
		[Constructable]
		public LargeMarbleDeed() : base(0x96, new Point3D(-4, 7, 0))
		{
		}

		public LargeMarbleDeed(Serial serial) : base(serial)
		{
		}

		public override BaseHouse GetHouse(Mobile owner)
		{
			return new LargeMarbleHouse(owner);
		}

		public override int LabelNumber => 1041236;
		public override Rectangle2D[] Area => LargeMarbleHouse.AreaArray;

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