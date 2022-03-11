namespace Server.Items
{
	public class LargeMushroom : Item
	{
		public override bool ForceShowProperties => true;

		[Constructable]
		public LargeMushroom() : base(Utility.RandomMinMax(0x222E, 0x2231))
		{
			Name = "a mushroom";
		}

		public LargeMushroom(Serial serial) : base(serial)
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