namespace Server.Items
{
	public class FarmableSmallPumpkin : FarmableCrop
	{
		public static int GetCropID()
		{
			return Utility.Random(3166, 3);
		}

		public override Item GetCropObject()
		{
			var smallpumpkin = new SmallPumpkin {
				ItemID = Utility.Random(3178, 3)
			};

			return smallpumpkin;
		}

		public override int GetPickedID()
		{
			return Utility.Random(3166, 3);
		}

		[Constructable]
		public FarmableSmallPumpkin()
			: base(GetCropID())
		{
		}

		public FarmableSmallPumpkin(Serial serial)
			: base(serial)
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