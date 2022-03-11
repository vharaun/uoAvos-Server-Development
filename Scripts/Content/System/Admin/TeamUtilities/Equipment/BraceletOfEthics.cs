using Server.ContextMenus;
using Server.Gumps;
using Server.Network;

using System.Collections.Generic;

namespace Server.Items.Staff
{
	public enum BraceletEffect
	{
		StaffRules
	}

	public class BraceletOfEthics : BaseBracelet
	{
		private Mobile m_Owner;
		public Point3D m_HomeLocation;
		public Map m_HomeMap;

		public BraceletEffect mStaffRules;

		[CommandProperty(AccessLevel.GameMaster)]
		public BraceletEffect BraceletEffect
		{
			get => mStaffRules;
			set { if ((value <= BraceletEffect.StaffRules) && (value >= BraceletEffect.StaffRules)) { mStaffRules = value; } else { return; }; }
		}

		[Constructable]
		public BraceletOfEthics() : base(0x1086)
		{
			LootType = LootType.Blessed;
			Weight = 1.0;
			Hue = 2406;
			Name = "An Unassigned Bracelet";

			Attributes.BonusStr = 100;
			Attributes.BonusDex = 100;
			Attributes.BonusInt = 100;

			Attributes.BonusHits = 100;
			Attributes.BonusMana = 100;
			Attributes.BonusStam = 100;

			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 3;

			mStaffRules = BraceletEffect.StaffRules;
		}

		public void SendBraceletEffect(BraceletEffect mbe, Mobile m)
		{
			switch (mbe)
			{
				case BraceletEffect.StaffRules:
					{
						m.SendGump(new EthicsGump01());
						break;
					}
			}
		}

		public BraceletOfEthics(Serial serial) : base(serial)
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
			private readonly BraceletOfEthics m_Item;
			private readonly Mobile m_Mobile;

			public GoHomeEntry(Mobile from, Item item) : base(5134) // uses "Goto Loc" entry
			{
				m_Item = (BraceletOfEthics)item;
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
			private readonly BraceletOfEthics m_Item;
			private readonly Mobile m_Mobile;

			public SetHomeEntry(Mobile from, Item item) : base(2055) // uses "Mark" entry
			{
				m_Item = (BraceletOfEthics)item;
				m_Mobile = from;
			}

			public override void OnClick()
			{
				m_Item.HomeLocation = m_Mobile.Location;
				m_Item.HomeMap = m_Mobile.Map;
				m_Mobile.SendMessage("The home location on your bracelet has been set to your current position.");
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
					from.SendMessage("This bracelet is not yours to use.");
					return;
				}
				else
				{
					base.GetContextMenuEntries(from, list);
					BraceletOfEthics.GetContextMenuEntries(from, this, list);
				}
			}
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (from.AccessLevel > AccessLevel.Player)
			{
				if (from != null)
				{
					SendBraceletEffect(mStaffRules, from);
				}
				else
				{
					from.SendMessage("You're Not Able To Complete That Action!");
				}
			}

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
				Name = m_Owner.Name.ToString() + "'s Bracelet of Ethics";
				HomeLocation = from.Location;
				HomeMap = from.Map;
				from.SendMessage("This bracelet has been assigned to you.");
			}
			else
			{
				if (m_Owner != from)
				{
					from.SendMessage("This item has not been assigned to you!");
					return;
				}
			}
		}

		public override bool OnEquip(Mobile from)
		{
			if (from.AccessLevel < AccessLevel.GameMaster)
			{
				from.SendMessage("This bracelet can only be used by server administrators!");
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

			writer.Write((int)mStaffRules);
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
						mStaffRules = (BraceletEffect)reader.ReadInt();
						break;
					}
			}
		}
	}

	public class EthicsGump01 : Gump
	{
		public EthicsGump01() : base(0, 0)
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);
			AddBackground(84, 27, 636, 511, 3600);
			AddAlphaRegion(110, 54, 582, 433);
			AddBackground(122, 127, 32, 350, 9200);
			AddBackground(122, 67, 560, 41, 9200);
			AddLabel(133, 78, 95, @"ADMINISTRATIVE GUIDELINES");
			AddLabel(528, 78, 95, @"REVISION: 11-04-2012");
			AddImage(128, 139, 9905);
			AddHtml(167, 128, 512, 76, @"Staff members may not interfere with the general gameplay of the players, in the game world, unless there is an issue which has come up that must be handled; meaning you were paged to a location to handle a player dispute or player issue in which only live, in-game support personnel can handle. ", true, true);
			AddImage(129, 229, 9905);
			AddHtml(168, 218, 512, 76, @"Staff members may not uberfy players in the game world, nor are  they allowed to modify the stats of any creature, mobile, and/or player in an effort to create an unbalanced gaming environment. Staff is also prohibited from giving their own player characters advancements which would otherwise cause an unbalanced gaming environment.", true, true);
			AddImage(129, 320, 9905);
			AddHtml(168, 309, 512, 76, @"Staff members may not use their administrative account while playing any character off of their player account(s). Doing so would cause players to accuse us of using our powers unfairly to better advance our own characters for whatever reasons; it's better to avoid such accusations. ", true, true);
			AddImage(128, 410, 5541);
			AddHtml(168, 400, 512, 76, @"Disciplinary Action: (1st) First Offense: 5 day suspension from your rank and duties; (2nd) Second Offense: 10 day suspension from your rank and duties; (3rd) Third Offense: Indefinate suspension from your rank and duties. Any drama resulting after the third offense will result in the deletion of your accounts and termination of your ability to play on our server(s).", true, true);
			AddButton(650, 495, 4005, 4006, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			AddLabel(574, 498, 95, @"NEXT PAGE");
			AddLabel(133, 498, 95, @"01 - 02");
			AddButton(540, 497, 1150, 1151, (int)Buttons.Button2, GumpButtonType.Reply, 2);
		}

		public enum Buttons
		{
			Button1,
			Button2
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button1:
					{
						if (from.HasGump(typeof(EthicsGump01)))
						{
							from.CloseGump(typeof(EthicsGump01));
						}

						from.SendGump(new EthicsGump02());
						break;
					}
				case (int)Buttons.Button2:
					{
						from.CloseGump(typeof(EthicsGump01));
						break;
					}
			}
		}
	}

	public class EthicsGump02 : Gump
	{
		public EthicsGump02() : base(0, 0)
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);
			AddBackground(84, 27, 636, 511, 3600);
			AddAlphaRegion(110, 54, 582, 433);
			AddBackground(122, 127, 32, 350, 9200);
			AddBackground(122, 67, 560, 41, 9200);
			AddLabel(133, 78, 95, @"ADMINISTRATIVE GUIDELINES");
			AddLabel(528, 78, 95, @"REVISION: 11-04-2012");
			AddImage(128, 139, 9905);
			AddHtml(167, 128, 512, 76, @"Staff members are not to get involved with the following player issues under any circumstance: 
(Luring Creatures): moving creatures from one location to another location is part of the game's mechanics and therefore does not fall under harrassment.
(Lost or Stolen Items): players who lose items due to game mechanics are not entitled to get anything returned back to them; there is no way to prove who had which item and therefore this is an issue we simply cannot help with. 
(Spawn Camping): every player has an equal right to camp any spawn they favor for as long as they wish; this is part of the game's mechanics and therefore fair game.
(Spawn Blocking): players have different strategies and techniques they use while hunting and adventuring in the game world, spawn blocking is just one such strategy and is part of the game's mechanics.
(Player Stalking): players are expected to role-play and therefore stalking could be part of a player characters role-play personality. It's part of game mechanics so staff is to let this type of harassment go. This is a pvp server afterall so players should get used to being hunted!", true, true);
			AddImage(129, 229, 9905);
			AddHtml(168, 218, 512, 76, @"Staff members are required to answer any and all pages from players requesting assistance. If the pages fall under incidents that staff has been told not to get involved in then players must be notified that staff is unable to assist them in the manner they're expecting; get creative and make up an excuse! If players are paging because of harrassment issues, staff members are required to assist!
(Harrassment): is defined as any behavior which interferes with the game dynamics on the basis of sexuality. race, religion, and any out of character conversations which may be threatening, insulting, and violate a persons real world emotional state of being. 
(Disciplinary Action): on any harrassment call  is at the discretion of the staff member(s) involved. This includes, but is not limited to terminating a player account for such behavior; particularly in regards to sexual harrassment!
(On A Side Note): cyber sex is allowed among consenting players, if it is done in the privacy of their player homes or
in seclusion from the rest of the game world. Relationships are to be expected in every game such as this one.", true, true);
			AddImage(129, 320, 9905);
			AddHtml(168, 309, 512, 76, @"Staff members should not get too involved in guild war or player government disputes. This is a player-run server so please use discretion when handling issues regarding player behavior. If players are rude and disrespect staff members then staff can discipline them at their own discretion. For most page requests staff can simply redirect players to use the automated staff system.", true, true);
			AddImage(128, 410, 5541);
			AddHtml(168, 400, 512, 76, @"Disciplinary Action: (1st) First Offense: 24 hour suspension from the server; (2nd) Second Offense: 48 hour suspension from the server; (3rd) Third Offense: 72 hour suspension from the server. Any drama resulting after the third offense will result in the deletion of player accounts and termination of their ability to play on our server(s).", true, true);
			AddButton(650, 495, 4014, 4015, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			AddLabel(573, 498, 95, @"PREV PAGE");
			AddLabel(133, 498, 95, @"02 - 02");
			AddButton(540, 497, 1150, 1151, (int)Buttons.Button2, GumpButtonType.Reply, 2);
		}

		public enum Buttons
		{
			Button1,
			Button2
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button1:
					{
						if (from.HasGump(typeof(EthicsGump02)))
						{
							from.CloseGump(typeof(EthicsGump02));
						}

						from.SendGump(new EthicsGump01());
						break;
					}
				case (int)Buttons.Button2:
					{
						from.CloseGump(typeof(EthicsGump02));
						break;
					}

			}
		}
	}
}