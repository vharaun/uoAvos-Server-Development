using Server.Multis.Deeds;

namespace Server.Multis
{
	public class TwoStoryVilla : BaseHouse
	{
		public static Rectangle2D[] AreaArray = new Rectangle2D[] { new Rectangle2D(-5, -5, 11, 11), new Rectangle2D(2, 6, 4, 1) };

		public override int DefaultPrice => 136500;

		public override HousePlacementEntry ConvertEntry => HousePlacementEntry.TwoStoryFoundations[31];

		public override Rectangle2D[] Area => AreaArray;
		public override Point3D BaseBanLocation => new Point3D(3, 8, 0);

		public TwoStoryVilla(Mobile owner) : base(0x9E, owner, 1100, 8)
		{
			var keyValue = CreateKeys(owner);

			AddSouthDoors(3, 1, 5, keyValue);

			SetSign(3, 8, 24);

			AddEastDoor(1, 0, 25);
			AddSouthDoor(-3, -1, 25);
		}

		public TwoStoryVilla(Serial serial) : base(serial)
		{
		}

		public override HouseDeed GetDeed() { return new VillaDeed(); }

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
	public class VillaDeed : HouseDeed
	{
		[Constructable]
		public VillaDeed() : base(0x9E, new Point3D(3, 6, 0))
		{
		}

		public VillaDeed(Serial serial) : base(serial)
		{
		}

		public override BaseHouse GetHouse(Mobile owner)
		{
			return new TwoStoryVilla(owner);
		}

		public override int LabelNumber => 1041240;
		public override Rectangle2D[] Area => TwoStoryVilla.AreaArray;

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