using Server.ContextMenus;

using System.Collections.Generic;

namespace Server.Items.Staff
{
	[FlipableAttribute(0x2683, 0x2684)]
	public class RobeOfEntitlement : BaseOuterTorso
	{
		public Point3D m_HomeLocation;
		public Map m_HomeMap;

		[Constructable]
		public RobeOfEntitlement() : base(0x2683)
		{
			LootType = LootType.Blessed;
			Layer = Layer.OuterTorso;
			Weight = 5.0;
			Hue = 2406;
			Name = "A Hooded Shroud";
		}

		public override void OnDoubleClick(Mobile m)
		{
			if (Parent != m)
			{
				m.SendMessage("You must be wearing the robe to use it!");
			}
			else
			{
				if (ItemID == 0x2683 || ItemID == 0x2684)
				{
					m.SendMessage("You lower the hood.");
					m.PlaySound(0x57);
					ItemID = 0x1F03;
					Name = "A Hooded Shroud";
					m.Title = null;
					m.NameMod = null;

					m.RemoveItem(this);
					m.EquipItem(this);
				}

				else if (ItemID == 0x1F03 || ItemID == 0x1F04)
				{
					m.SendMessage("You raise the hood.");
					m.PlaySound(0x57);
					ItemID = 0x2683;
					Name = "A Hooded Shroud";

					m.RemoveItem(this);
					m.EquipItem(this);
				}
			}

			if (m.AccessLevel > AccessLevel.Player)
			{
				HomeLocation = m.Location;
				HomeMap = m.Map;
				return;
			}
		}

		public override bool OnEquip(Mobile from)
		{
			if (from.AccessLevel == AccessLevel.Owner && ItemID == 0x2683)
			{
				from.NameMod = null; //Change Your Character Name To Reflect The Server
				from.Title = "[SO]"; //Change Your Character Title To Fit Your Job Title
				Name = "Server Owner";
				Hue = 2406;
			}
			else if (from.AccessLevel == AccessLevel.Developer && ItemID == 0x2683)
			{
				from.NameMod = null; //Change Your Character Name To Reflect The Server
				from.Title = "[DE]"; //Change Your Character Title To Fit Your Job Title
				Name = "Developer";
				Hue = 798;
			}
			else if (from.AccessLevel == AccessLevel.Administrator && ItemID == 0x2683)
			{
				from.NameMod = null; //Change Your Character Name To Reflect The Server
				from.Title = "[AD]"; //Change Your Character Title To Fit Your Job Title
				Name = "Administrator";
				Hue = 687;
			}
			else if (from.AccessLevel == AccessLevel.Seer && ItemID == 0x2683)
			{
				from.NameMod = null; //Change Your Character Name To Reflect The Server
				from.Title = "[EM]"; //Change Your Character Title To Fit Your Job Title
				Name = "Event Moderator";
				Hue = 399;
			}
			else if (from.AccessLevel == AccessLevel.GameMaster && ItemID == 0x2683)
			{
				from.NameMod = null; //Change Your Character Name To Reflect The Server
				from.Title = "[GM]"; //Change Your Character Title To Fit Your Job Title
				Name = "Gamemaster";
				Hue = 1644;
			}
			else
			{
				from.NameMod = null;
				from.Title = null;
			}
			return base.OnEquip(from);
		}

		public override void OnRemoved(IEntity o)
		{
			if (o is Mobile)
			{
				((Mobile)o).NameMod = null;
				((Mobile)o).Title = null;
			}

			if (o is Mobile && ((Mobile)o).Murderer)
			{
				((Mobile)o).Criminal = true;
			}

			if (o is Mobile && ((Mobile)o).GuildTitle != null)
			{
				((Mobile)o).DisplayGuildTitle = true;
			}
			base.OnRemoved(o);
		}

		public RobeOfEntitlement(Serial serial) : base(serial)
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
			private readonly RobeOfEntitlement m_Item;
			private readonly Mobile m_Mobile;

			public GoHomeEntry(Mobile from, Item item) : base(5134) // uses "Goto Loc" entry
			{
				m_Item = (RobeOfEntitlement)item;
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
			private readonly RobeOfEntitlement m_Item;
			private readonly Mobile m_Mobile;

			public SetHomeEntry(Mobile from, Item item) : base(2055) // uses "Mark" entry
			{
				m_Item = (RobeOfEntitlement)item;
				m_Mobile = from;
			}

			public override void OnClick()
			{
				m_Item.HomeLocation = m_Mobile.Location;
				m_Item.HomeMap = m_Mobile.Map;
				m_Mobile.SendMessage("The home location on your robe has been set to your current position.");
			}
		}

		public static void GetContextMenuEntries(Mobile from, Item item, List<ContextMenuEntry> list)
		{
			list.Add(new GoHomeEntry(from, item));
			list.Add(new SetHomeEntry(from, item));
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);
			RobeOfEntitlement.GetContextMenuEntries(from, this, list);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(1); // version

			writer.Write(m_HomeLocation);
			writer.Write(m_HomeMap);
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
					}
					goto case 0;
				case 0:
					{
						break;
					}
			}
		}
	}
}