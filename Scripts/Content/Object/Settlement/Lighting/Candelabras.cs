
using System;

namespace Server.Items
{
	/// Candelabra
	public class Candelabra : BaseLight, IShipwreckedItem
	{
		public override int LitItemID => 0xB1D;
		public override int UnlitItemID => 0xA27;

		[Constructable]
		public Candelabra() : base(0xA27)
		{
			Duration = TimeSpan.Zero; // Never burnt out
			Burning = false;
			Light = LightType.Circle225;
			Weight = 3.0;
		}

		public Candelabra(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(1);

			writer.Write(m_IsShipwreckedItem);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_IsShipwreckedItem = reader.ReadBool();
						break;
					}
			}
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			if (m_IsShipwreckedItem)
			{
				list.Add(1041645); // recovered from a shipwreck
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			base.OnSingleClick(from);

			if (m_IsShipwreckedItem)
			{
				LabelTo(from, 1041645); //recovered from a shipwreck
			}
		}

		#region IShipwreckedItem Members

		private bool m_IsShipwreckedItem;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsShipwreckedItem
		{
			get => m_IsShipwreckedItem;
			set => m_IsShipwreckedItem = value;
		}
		#endregion
	}

	/// CandelabraStand
	public class CandelabraStand : BaseLight
	{
		public override int LitItemID => 0xB26;
		public override int UnlitItemID => 0xA29;

		[Constructable]
		public CandelabraStand() : base(0xA29)
		{
			Duration = TimeSpan.Zero; // Never burnt out
			Burning = false;
			Light = LightType.Circle225;
			Weight = 20.0;
		}

		public CandelabraStand(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}