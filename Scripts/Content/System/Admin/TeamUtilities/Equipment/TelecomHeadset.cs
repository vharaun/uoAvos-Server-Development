using Server.Commands;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Prompts;

using System.Collections;
using System.Collections.Generic;


namespace Server.Items.Staff
{
	/// Ear Pieces
	public class CommUnit : SilverEarrings
	{
		private Mobile m_Owner;
		public Point3D m_HomeLocation;
		public Map m_HomeMap;

		private string m_Channel;
		[CommandProperty(AccessLevel.GameMaster)]
		public string Channel
		{
			get => m_Channel;
			set => m_Channel = value;
		}
		[Constructable]
		public CommUnit()
		{
			LootType = LootType.Blessed;
			Weight = 1.0;
			Hue = 2406;
			Name = "An Unassigned Personal Communicator";
		}

		public override void OnDoubleClick(Mobile m)
		{
			m.Prompt = new SelectChannelPrompt(this);
			m.SendMessage(0, "Please enter the channel you wish to use.");

			if (m_Owner == null && m.AccessLevel == AccessLevel.Player)
			{
				m.SendMessage("Only the server administration can use this item!");
				//this.Delete();
			}

			else if (m_Owner == null && m.AccessLevel == AccessLevel.Counselor)
			{
				m.SendMessage("Only the server administration can use this item!");
				//this.Delete();
			}

			else if (m_Owner == null)
			{
				m_Owner = m;
				Name = m_Owner.Name.ToString() + "'s Personal Communicator";
				HomeLocation = m.Location;
				HomeMap = m.Map;
				m.SendMessage("This personal communicator has been assigned to you.");
			}
			else
			{
				if (m_Owner != m)
				{
					m.SendMessage("This item has not been assigned to you!");
					return;
				}
			}
		}

		public CommUnit(Serial serial) : base(serial)
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
			private readonly CommUnit m_Item;
			private readonly Mobile m_Mobile;

			public GoHomeEntry(Mobile from, Item item) : base(5134) // uses "Goto Loc" entry
			{
				m_Item = (CommUnit)item;
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
			private readonly CommUnit m_Item;
			private readonly Mobile m_Mobile;

			public SetHomeEntry(Mobile from, Item item) : base(2055) // uses "Mark" entry
			{
				m_Item = (CommUnit)item;
				m_Mobile = from;
			}

			public override void OnClick()
			{
				m_Item.HomeLocation = m_Mobile.Location;
				m_Item.HomeMap = m_Mobile.Map;
				m_Mobile.SendMessage("The home location on your personal communicator has been set to your current position.");
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
					from.SendMessage("This personal communicator is not yours to use.");
					return;
				}
				else
				{
					base.GetContextMenuEntries(from, list);
					CommUnit.GetContextMenuEntries(from, this, list);
				}
			}
		}

		public override bool OnEquip(Mobile from)
		{
			if (from.AccessLevel < AccessLevel.GameMaster)
			{
				from.SendMessage("This personal communicator can only be used by server administrators!");
				//this.Delete();
			}
			return true;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(1); // version

			writer.Write(m_HomeLocation);
			writer.Write(m_HomeMap);
			writer.Write(m_Owner);

			writer.Write(m_Channel);
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
						m_Channel = reader.ReadString();
						break;
					}
			}
		}

		private class SelectChannelPrompt : Prompt
		{
			private readonly CommUnit unit;

			public SelectChannelPrompt(CommUnit comm)
			{
				unit = comm;
			}
			public override void OnResponse(Mobile from, string text)
			{
				unit.Channel = text;
			}
		}
	}

	/// Comm System
	public class Comm
	{
		public static void Initialize()
		{
			CommandSystem.Register("Comm", AccessLevel.Player, new CommandEventHandler(Comm_OnCommand));
		}

		[Usage("Comm [string]")]
		[Description("If you have a comm unit equipped, will send a message to all others on the same facet as you with a like channel.")]
		private static void Comm_OnCommand(CommandEventArgs e)
		{
			var speechstring = e.ArgString;
			var m = e.Mobile;
			if (m != null)
			{
				var unit = m.FindItemOnLayer(Layer.Earrings) as CommUnit;
				if (unit != null)
				{
					var towerinrange = false;
					IPooledEnumerable eable = m.Map.GetItemsInRange(m.Location, 1000);
					foreach (Item i in eable)
					{
						if (i is CommTower && towerinrange == false)
						{
							towerinrange = true;
						}
					}
					eable.Free();
					var list = new ArrayList();
					foreach (var mob in World.Mobiles.Values)
					{
						var unit2 = mob.FindItemOnLayer(Layer.Earrings) as CommUnit;
						if (unit2 != null)
						{
							if (unit2.Channel == unit.Channel && mob is PlayerMobile)
							{
								list.Add(mob);
							}
						}
					}
					for (var i = 0; i < list.Count; ++i)
					{
						var mobile = (Mobile)list[i];
						mobile.SendMessage(0, "{0}: {1}", m.Name, speechstring);
					}
				}
			}
		}
		private class MessagePrompt : Prompt
		{
			private readonly CommUnit unit;
			private readonly Mobile m;
			public MessagePrompt(CommUnit comm, Mobile mob)
			{
				unit = comm;
				m = mob;
			}
			public override void OnResponse(Mobile from, string text)
			{
				var towerin = false;
				Item tower = null;
				IPooledEnumerable eable = m.Map.GetItemsInRange(m.Location, 500);
				foreach (Item i in eable)
				{
					if (i != null)
					{
						if (i is CommTower)
						{
							if (towerin != true)
							{
								towerin = true;
								tower = i;
							}
						}
					}
				}
				eable.Free();
				if (towerin != false)
				{
					if (tower != null)
					{
						var list = new ArrayList();
						IPooledEnumerable eable2 = tower.Map.GetMobilesInRange(tower.Location, 1000);
						foreach (Mobile mb in eable2)
						{
							if (mb != null)
							{
								if (mb is PlayerMobile)
								{
									var unit2 = mb.FindItemOnLayer(Layer.Earrings) as CommUnit;
									if (unit2 != null)
									{
										var channelgood = false;
										if (unit2.Channel == unit.Channel)
										{
											channelgood = true;
										}

										if (channelgood == true)
										{
											list.Add(mb);
										}
									}
								}
							}
						}
						eable2.Free();
						for (var i = 0; i < list.Count; ++i)
						{
							var mobile = (Mobile)list[i];
							mobile.SendMessage(0, "{0}: {1}", from.Name, text);
						}
					}
				}
				else
				{
					from.SendMessage(0, "You must be in range of a Comm Tower to use the Personal Communicator.");
				}
			}
		}
	}

	public class CommTower : Item
	{
		[Constructable]
		public CommTower() : base(2853)
		{
			Name = "Comm Tower";
			Movable = false;
		}

		public CommTower(Serial serial) : base(serial)
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