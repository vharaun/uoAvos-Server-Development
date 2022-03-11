namespace Server.Items
{
	public class VeriteGranite : BaseGranite
	{
		[Constructable]
		public VeriteGranite() : base(CraftResource.Verite)
		{
		}

		public VeriteGranite(Serial serial) : base(serial)
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