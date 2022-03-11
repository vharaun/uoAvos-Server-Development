namespace Server.Items
{
	[FlipableAttribute(0x1BD7, 0x1BDA)]
	public class Board : Item, ICommodity
	{
		private CraftResource m_Resource;

		[CommandProperty(AccessLevel.GameMaster)]
		public CraftResource Resource
		{
			get => m_Resource;
			set { m_Resource = value; InvalidateProperties(); }
		}

		int ICommodity.DescriptionNumber
		{
			get
			{
				if (m_Resource >= CraftResource.OakWood && m_Resource <= CraftResource.YewWood)
				{
					return 1075052 + ((int)m_Resource - (int)CraftResource.OakWood);
				}

				switch (m_Resource)
				{
					case CraftResource.Bloodwood: return 1075055;
					case CraftResource.Frostwood: return 1075056;
					case CraftResource.Heartwood: return 1075062;   //WHY Osi.  Why?
				}

				return LabelNumber;
			}
		}

		bool ICommodity.IsDeedable => true;

		[Constructable]
		public Board()
			: this(1)
		{
		}

		[Constructable]
		public Board(int amount)
			: this(CraftResource.RegularWood, amount)
		{
		}

		public Board(Serial serial)
			: base(serial)
		{
		}

		[Constructable]
		public Board(CraftResource resource) : this(resource, 1)
		{
		}

		[Constructable]
		public Board(CraftResource resource, int amount)
			: base(0x1BD7)
		{
			Stackable = true;
			Amount = amount;

			m_Resource = resource;
			Hue = CraftResources.GetHue(resource);
		}

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

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(3);

			writer.Write((int)m_Resource);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 3:
				case 2:
					{
						m_Resource = (CraftResource)reader.ReadInt();
						break;
					}
			}

			if ((version == 0 && Weight == 0.1) || (version <= 2 && Weight == 2))
			{
				Weight = -1;
			}

			if (version <= 1)
			{
				m_Resource = CraftResource.RegularWood;
			}
		}
	}
}