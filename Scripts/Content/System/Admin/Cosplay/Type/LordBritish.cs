namespace Server.Items
{
	public class LordBritishCostume : BaseAdminCosplay
	{
		[Constructable]
		public LordBritishCostume() : base(AccessLevel.GameMaster, 0x0, 0x2042)
		{
		}

		public LordBritishCostume(Serial serial) : base(serial)
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