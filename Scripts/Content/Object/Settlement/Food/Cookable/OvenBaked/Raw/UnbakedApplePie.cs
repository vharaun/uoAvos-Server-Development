namespace Server.Items
{
	public class UnbakedApplePie : CookableFood
	{
		public override int LabelNumber => 1041336;  // unbaked apple pie

		[Constructable]
		public UnbakedApplePie() : base(0x1042, 25)
		{
			Weight = 1.0;
		}

		public override Food Cook()
		{
			return new ApplePie();
		}

		public UnbakedApplePie(Serial serial) : base(serial)
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