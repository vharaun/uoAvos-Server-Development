namespace Server.Items
{
	public class DestroyingAngel : BaseReagent, ICommodity
	{
		int ICommodity.DescriptionNumber => LabelNumber;
		bool ICommodity.IsDeedable => true;

		[Constructable]
		public DestroyingAngel() : this(1)
		{
		}

		[Constructable]
		public DestroyingAngel(int amount) : base(9911, amount)
		{
			Hue = 1153;
			Name = "destroying angel";
		}

		public DestroyingAngel(Serial serial) : base(serial)
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
