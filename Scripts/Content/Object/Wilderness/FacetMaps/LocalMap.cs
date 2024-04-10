namespace Server.Items
{
	public class LocalMap : MapItem
	{
		[Constructable]
		public LocalMap()
		{
			SetDisplay(Map.Felucca, 200, 200);
		}

		public override void CraftInit(Mobile from)
		{
			var skillValue = from.Skills[SkillName.Cartography].Value;
			var dist = 64 + (int)(skillValue * 2);

			SetDisplay(from.Map, from.X - dist, from.Y - dist, from.X + dist, from.Y + dist);
		}

		public override int LabelNumber => 1015230;  // local map

		public LocalMap(Serial serial) : base(serial)
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