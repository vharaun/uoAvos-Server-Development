namespace Server.Items
{
	public class DullCopperGranite : BaseGranite
	{
		[Constructable]
		public DullCopperGranite() : base(CraftResource.DullCopper)
		{
		}

		public DullCopperGranite(Serial serial) : base(serial)
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