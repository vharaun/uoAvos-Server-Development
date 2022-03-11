namespace Server.Items
{
	public class TrulyRareFish : BaseMagicFish
	{
		public override int Bonus => 5;
		public override StatType Type => StatType.Str;

		public override int LabelNumber => 1041075;  // truly rare fish

		[Constructable]
		public TrulyRareFish() : base(76)
		{
		}

		public TrulyRareFish(Serial serial) : base(serial)
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

			if (Hue == 376)
			{
				Hue = 76;
			}
		}
	}
}