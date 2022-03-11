namespace Server.Items
{
	public class SkinnedFish : Food
	{
		[Constructable]
		public SkinnedFish() : base(Utility.Random(0x1E15, 2))
		{
			Name = "A Skinned Fish";
			FillFactor = 3;
		}

		public SkinnedFish(Serial serial) : base(serial)
		{
		}

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