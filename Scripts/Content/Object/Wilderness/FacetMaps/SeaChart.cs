namespace Server.Items
{
	public class SeaChart : MapItem
	{
		[Constructable]
		public SeaChart()
		{
			SetDisplay(0, 0, 5119, 4095, 400, 400);
		}

		public override void CraftInit(Mobile from)
		{
			var skillValue = from.Skills[SkillName.Cartography].Value;
			var dist = 64 + (int)(skillValue * 10);

			if (dist < 200)
			{
				dist = 200;
			}

			var size = 24 + (int)(skillValue * 3.3);

			if (size < 200)
			{
				size = 200;
			}
			else if (size > 400)
			{
				size = 400;
			}

			SetDisplay(from.X - dist, from.Y - dist, from.X + dist, from.Y + dist, size, size);
		}

		public override int LabelNumber => 1015232;  // sea chart

		public SeaChart(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}