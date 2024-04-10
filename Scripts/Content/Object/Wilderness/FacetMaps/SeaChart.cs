using System;

namespace Server.Items
{
	public class SeaChart : MapItem
	{
		[Constructable]
		public SeaChart()
		{
			SetDisplay(Map.Felucca, 400, 400);
		}

		public override void CraftInit(Mobile from)
		{
			var skillValue = from.Skills[SkillName.Cartography].Value;

			var dist = Math.Clamp(64 + (int)(skillValue * 10), 0, 200);
			var size = Math.Clamp(24 + (int)(skillValue * 3.3), 200, 400);

			SetDisplay(from.Map, from.X - dist, from.Y - dist, from.X + dist, from.Y + dist, size, size);
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