namespace Server.Items
{
	public class FarmableBananas : PickableCrop
	{
		public static int GetCropID()
		{
			return 0x0CAA; // Full Grown Tree
		}

		public override Item GetCropObject()
		{
			var banannas = new Bananas {
				ItemID = Utility.Random(0x1721, 2) // Banana Bunches 0x1721 and 0x1722 (At Random)
			};
			// Since The Graphics Are Next To One Another From Right To Left In The Art.mul and Artidx.mul
			// The Second Number '2' Randomizes The First Graphic '0x1721' With The Second '0x1722'
			return banannas;
		}

		public override int GetPickedID()
		{
			return 0x0CAA; // Full Grown Tree
		}

		[Constructable]
		public FarmableBananas() : base(GetCropID())
		{
		}

		public FarmableBananas(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}