namespace Server.Items
{
	public class SpringWater : BaseReagent, ICommodity
	{
		int ICommodity.DescriptionNumber => LabelNumber;
		bool ICommodity.IsDeedable => true;

		[Constructable]
		public SpringWater() : this(1)
		{
		}

		[Constructable]
		public SpringWater(int amount) : base(0xE24, amount)
		{
			Hue = 0x47F;
			Name = "spring water";
		}

		public SpringWater(Serial serial) : base(serial)
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
