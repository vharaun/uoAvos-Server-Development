namespace Server.Items
{
	public abstract class BaseScales : Item, ICommodity
	{
		public override int LabelNumber => 1053139;  // dragon scales

		private CraftResource m_Resource;

		[CommandProperty(AccessLevel.GameMaster)]
		public CraftResource Resource
		{
			get => m_Resource;
			set { m_Resource = value; InvalidateProperties(); }
		}

		public override double DefaultWeight => 0.1;

		int ICommodity.DescriptionNumber => LabelNumber;
		bool ICommodity.IsDeedable => true;

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write((int)m_Resource);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Resource = (CraftResource)reader.ReadInt();
						break;
					}
			}
		}

		public BaseScales(CraftResource resource) : this(resource, 1)
		{
		}

		public BaseScales(CraftResource resource, int amount) : base(0x26B4)
		{
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue(resource);

			m_Resource = resource;
		}

		public BaseScales(Serial serial) : base(serial)
		{
		}
	}
}