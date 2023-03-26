namespace Server.Items
{
	public class PetrifiedWood : BaseReagent, ICommodity
	{
		int ICommodity.DescriptionNumber => LabelNumber;
		bool ICommodity.IsDeedable => true;

		[Constructable]
		public PetrifiedWood() : this(1)
		{
		}

		[Constructable]
		public PetrifiedWood(int amount) : base(0x97A, amount)
		{
			Hue = 0x46C;
			Name = "petrified wood";
		}

		public PetrifiedWood(Serial serial) : base(serial)
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
