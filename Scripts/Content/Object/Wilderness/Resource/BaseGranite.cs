namespace Server.Items
{
	public abstract class BaseGranite : Item
	{
		private CraftResource m_Resource;

		[CommandProperty(AccessLevel.GameMaster)]
		public CraftResource Resource
		{
			get => m_Resource;
			set { m_Resource = value; InvalidateProperties(); }
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version

			writer.Write((int)m_Resource);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
				case 0:
					{
						m_Resource = (CraftResource)reader.ReadInt();
						break;
					}
			}

			if (version < 1)
			{
				Stackable = Core.ML;
			}
		}

		public override double DefaultWeight => Core.ML ? 1.0 : 10.0;

		public BaseGranite(CraftResource resource) : base(0x1779)
		{
			Hue = CraftResources.GetHue(resource);
			Stackable = Core.ML;

			m_Resource = resource;
		}

		public BaseGranite(Serial serial) : base(serial)
		{
		}

		public override int LabelNumber => 1044607;  // high quality granite

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (!CraftResources.IsStandard(m_Resource))
			{
				var num = CraftResources.GetLocalizationNumber(m_Resource);

				if (num > 0)
				{
					list.Add(num);
				}
				else
				{
					list.Add(CraftResources.GetName(m_Resource));
				}
			}
		}
	}
}