namespace Server.Items
{
	public class GameMasterRobe : BaseAdminUniform
	{
		[Constructable]
		public GameMasterRobe() : base(AccessLevel.GameMaster, 0x26, 0x204F)
		{
		}

		public GameMasterRobe(Serial serial) : base(serial)
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