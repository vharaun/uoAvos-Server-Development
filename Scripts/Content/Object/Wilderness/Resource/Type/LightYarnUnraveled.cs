namespace Server.Items
{
	public class LightYarnUnraveled : BaseClothMaterial
	{
		[Constructable]
		public LightYarnUnraveled() : this(1)
		{
		}

		[Constructable]
		public LightYarnUnraveled(int amount) : base(0xE1F, amount)
		{
		}

		public LightYarnUnraveled(Serial serial) : base(serial)
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