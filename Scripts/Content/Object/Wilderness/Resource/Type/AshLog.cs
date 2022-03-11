namespace Server.Items
{
	public class AshLog : Log
	{
		[Constructable]
		public AshLog()
			: this(1)
		{
		}

		[Constructable]
		public AshLog(int amount)
			: base(CraftResource.AshWood, amount)
		{
		}

		public AshLog(Serial serial)
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
			if (!TryCreateBoards(from, 80, new AshBoard()))
			{
				return false;
			}

			return true;
		}
	}
}