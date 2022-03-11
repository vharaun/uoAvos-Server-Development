namespace Server.Items
{
	public class PrizedFish : BaseMagicFish
	{
		public override int Bonus => 5;
		public override StatType Type => StatType.Int;

		public override int LabelNumber => 1041073;  // prized fish

		[Constructable]
		public PrizedFish() : base(51)
		{
		}

		public PrizedFish(Serial serial) : base(serial)
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

			if (Hue == 151)
			{
				Hue = 51;
			}
		}
	}
}