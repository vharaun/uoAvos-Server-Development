using System;

namespace Server.Items
{
	public class WorldMap : MapItem
	{
		[Constructable]
		public WorldMap()
		{
			SetDisplay(Map.Felucca, 400, 400);
		}

		public override void CraftInit(Mobile from)
		{
			// Unlike the others, world map is not based on crafted location
			var center = from.Map.Bounds.Center;

			var skillValue = from.Skills[SkillName.Cartography].Value;

			var dist = Math.Clamp(64 + (int)(skillValue * 20), 0, 200);
			var size = Math.Clamp(25 + (int)(skillValue * 6.6), 200, 400);

			SetDisplay(from.Map, center.X - dist, center.Y - dist, center.X + dist, center.Y + dist, size, size);
		}

		public override int LabelNumber => 1015233;  // world map

		public WorldMap(Serial serial) : base(serial)
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