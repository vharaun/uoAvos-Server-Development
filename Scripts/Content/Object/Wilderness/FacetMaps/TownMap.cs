using System;

namespace Server.Items
{
	public class TownMap : MapItem
	{
		[Constructable]
		public TownMap()
		{
			SetDisplay(Map.Felucca, 400, 400);
		}

		public override void CraftInit(Mobile from)
		{
			var skillValue = from.Skills[SkillName.Cartography].Value;

			var dist = Math.Clamp(64 + (int)(skillValue * 4), 0, 200);
			var size = Math.Clamp(32 + (int)(skillValue * 2), 200, 400);

			SetDisplay(from.Map, from.X - dist, from.Y - dist, from.X + dist, from.Y + dist, size, size);
		}

		public override int LabelNumber => 1015231;  // city map

		public TownMap(Serial serial) : base(serial)
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