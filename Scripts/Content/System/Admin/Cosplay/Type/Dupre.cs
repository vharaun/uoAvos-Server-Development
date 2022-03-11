namespace Server.Items
{
	public class DupreCostume : BaseAdminCosplay
	{
		[Constructable]
		public DupreCostume() : base(AccessLevel.GameMaster, 0x0, 0x2050)
		{
		}

		public DupreCostume(Serial serial) : base(serial)
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