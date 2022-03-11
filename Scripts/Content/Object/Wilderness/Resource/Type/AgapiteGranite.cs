namespace Server.Items
{
	public class AgapiteGranite : BaseGranite
	{
		[Constructable]
		public AgapiteGranite() : base(CraftResource.Agapite)
		{
		}

		public AgapiteGranite(Serial serial) : base(serial)
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