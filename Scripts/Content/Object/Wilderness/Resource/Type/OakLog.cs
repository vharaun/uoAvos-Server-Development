namespace Server.Items
{
	public class OakLog : Log
	{
		[Constructable]
		public OakLog()
			: this(1)
		{
		}

		[Constructable]
		public OakLog(int amount)
			: base(CraftResource.OakWood, amount)
		{
		}

		public OakLog(Serial serial)
			: base(serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 65, new OakBoard()))
			{
				return false;
			}

			return true;
		}
	}
}