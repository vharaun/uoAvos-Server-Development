﻿namespace Server.Items
{
	public class WallChains : Item
	{

		[Constructable]
		public WallChains() : base(Utility.Random(6663, 2))
		{
			Name = "chains of the tormented";
			Weight = 1.0;
		}

		public WallChains(Serial serial) : base(serial)
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