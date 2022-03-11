using Server.ContextMenus;

using System.Collections.Generic;

namespace Server.Items.Staff
{
	public class RingOfReduction : BaseRing
	{
		private Mobile m_Owner;
		public Point3D m_HomeLocation;
		public Map m_HomeMap;

		private AccessLevel m_StaffLevel;

		[Constructable]
		public RingOfReduction() : base(0x108a)
		{
			LootType = LootType.Blessed;
			Weight = 1.0;
			Hue = 2406;
			Name = "An Unassigned Ring";

			Attributes.RegenHits = 100;
			Attributes.RegenStam = 100;
			Attributes.RegenMana = 100;

			Attributes.LowerRegCost = 100;
			Attributes.LowerManaCost = 100;

			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 3;
		}

		public RingOfReduction(Serial serial) : base(serial)
		{
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D HomeLocation
		{
			get => m_HomeLocation;
			set => m_HomeLocation = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Map HomeMap
		{
			get => m_HomeMap;
			set => m_HomeMap = value;
		}

		private class GoHomeEntry : ContextMenuEntry
		{
			private readonly RingOfReduction m_Item;
			private readonly Mobile m_Mobile;

			public GoHomeEntry(Mobile from, Item item) : base(5134) // uses "Goto Loc" entry
			{
				m_Item = (RingOfReduction)item;
				m_Mobile = from;
			}

			public override void OnClick()
			{
				m_Mobile.Location = m_Item.HomeLocation;
				if (m_Item.HomeMap != null)
				{
					m_Mobile.Map = m_Item.HomeMap;
				}
			}
		}

		private class SetHomeEntry : ContextMenuEntry
		{
			private readonly RingOfReduction m_Item;
			private readonly Mobile m_Mobile;

			public SetHomeEntry(Mobile from, Item item) : base(2055) // uses "Mark" entry
			{
				m_Item = (RingOfReduction)item;
				m_Mobile = from;
			}

			public override void OnClick()
			{
				m_Item.HomeLocation = m_Mobile.Location;
				m_Item.HomeMap = m_Mobile.Map;
				m_Mobile.SendMessage("The home location on your ring has been set to your current position.");
			}
		}

		public static void GetContextMenuEntries(Mobile from, Item item, List<ContextMenuEntry> list)
		{
			list.Add(new GoHomeEntry(from, item));
			list.Add(new SetHomeEntry(from, item));
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			if (m_Owner == null)
			{
				return;
			}
			else
			{
				if (m_Owner != from)
				{
					from.SendMessage("This ring is not yours to use.");
					return;
				}
				else
				{
					base.GetContextMenuEntries(from, list);
					RingOfReduction.GetContextMenuEntries(from, this, list);
				}
			}
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (m_Owner == null && from.AccessLevel == AccessLevel.Player)
			{
				from.SendMessage("Only the server administration can use this item!");
				//this.Delete();
			}

			else if (m_Owner == null && from.AccessLevel == AccessLevel.Counselor)
			{
				from.SendMessage("Only the server administration can use this item!");
				//this.Delete();
			}

			else if (m_Owner == null)
			{
				m_Owner = from;
				Name = m_Owner.Name.ToString() + "'s Ring of Reduction";
				HomeLocation = from.Location;
				HomeMap = from.Map;
				from.SendMessage("This ring has been assigned to you.");
			}
			else
			{
				if (m_Owner != from)
				{
					from.SendMessage("This item has not been assigned to you!");
					return;
				}
				else
				{
					SwitchAccessLevels(from);
				}

			}
		}

		private void SwitchAccessLevels(Mobile from)
		{
			if (from.AccessLevel == AccessLevel.Player)
			{
				from.AccessLevel = m_StaffLevel;
				from.Blessed = true;
			}
			else
			{
				m_StaffLevel = from.AccessLevel;
				from.AccessLevel = AccessLevel.Player;
				from.Blessed = false;
			}
		}

		public override bool OnEquip(Mobile from)
		{
			if (from.AccessLevel < AccessLevel.GameMaster)
			{
				from.SendMessage("This ring can only be used by server administrators!");
				//this.Delete();
			}
			return true;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(1); //Version 1

			writer.Write(m_HomeLocation);
			writer.Write(m_HomeMap);
			writer.Write(m_Owner);

			writer.Write((int)m_StaffLevel);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
			switch (version)
			{
				case 1:
					{
						m_HomeLocation = reader.ReadPoint3D();
						m_HomeMap = reader.ReadMap();
						m_Owner = reader.ReadMobile();
					}
					goto case 0;
				case 0:
					{
						m_StaffLevel = (AccessLevel)reader.ReadInt();
						break;
					}
			}
		}
	}
}