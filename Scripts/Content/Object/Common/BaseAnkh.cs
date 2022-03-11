using Server.ContextMenus;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

using System.Collections.Generic;

namespace Server.Items
{
	public class Ankhs
	{
		public const int ResurrectRange = 2;
		public const int TitheRange = 2;
		public const int LockRange = 2;

		public static void GetContextMenuEntries(Mobile from, Item item, List<ContextMenuEntry> list)
		{
			if (from is PlayerMobile)
			{
				list.Add(new LockKarmaEntry((PlayerMobile)from));
			}

			list.Add(new ResurrectEntry(from, item));

			if (Core.AOS)
			{
				list.Add(new TitheEntry(from));
			}
		}

		public static void Resurrect(Mobile m, Item item)
		{
			if (m.Alive)
			{
				return;
			}

			if (!m.InRange(item.GetWorldLocation(), ResurrectRange))
			{
				m.SendLocalizedMessage(500446); // That is too far away.
			}
			else if (m.Map != null && m.Map.CanFit(m.Location, 16, false, false))
			{
				m.CloseGump(typeof(ResurrectGump));
				m.SendGump(new ResurrectGump(m, ResurrectMessage.VirtueShrine));
			}
			else
			{
				m.SendLocalizedMessage(502391); // Thou can not be resurrected there!
			}
		}

		private class ResurrectEntry : ContextMenuEntry
		{
			private readonly Mobile m_Mobile;
			private readonly Item m_Item;

			public ResurrectEntry(Mobile mobile, Item item) : base(6195, ResurrectRange)
			{
				m_Mobile = mobile;
				m_Item = item;

				Enabled = !m_Mobile.Alive;
			}

			public override void OnClick()
			{
				Resurrect(m_Mobile, m_Item);
			}
		}

		private class LockKarmaEntry : ContextMenuEntry
		{
			private readonly PlayerMobile m_Mobile;

			public LockKarmaEntry(PlayerMobile mobile) : base(mobile.KarmaLocked ? 6197 : 6196, LockRange)
			{
				m_Mobile = mobile;
			}

			public override void OnClick()
			{
				m_Mobile.KarmaLocked = !m_Mobile.KarmaLocked;

				if (m_Mobile.KarmaLocked)
				{
					m_Mobile.SendLocalizedMessage(1060192); // Your karma has been locked. Your karma can no longer be raised.
				}
				else
				{
					m_Mobile.SendLocalizedMessage(1060191); // Your karma has been unlocked. Your karma can be raised again.
				}
			}
		}

		private class TitheEntry : ContextMenuEntry
		{
			private readonly Mobile m_Mobile;

			public TitheEntry(Mobile mobile) : base(6198, TitheRange)
			{
				m_Mobile = mobile;

				Enabled = m_Mobile.Alive;
			}

			public override void OnClick()
			{
				if (m_Mobile.CheckAlive())
				{
					m_Mobile.SendGump(new TithingGump(m_Mobile, 0));
				}
			}
		}
	}

	public class TithingGump : Gump
	{
		private readonly Mobile m_From;
		private int m_Offer;

		public TithingGump(Mobile from, int offer) : base(160, 40)
		{
			var totalGold = from.TotalGold;

			if (offer > totalGold)
			{
				offer = totalGold;
			}
			else if (offer < 0)
			{
				offer = 0;
			}

			m_From = from;
			m_Offer = offer;

			AddPage(0);

			AddImage(30, 30, 102);

			AddHtmlLocalized(95, 100, 120, 100, 1060198, 0, false, false); // May your wealth bring blessings to those in need, if tithed upon this most sacred site.

			AddLabel(57, 274, 0, "Gold:");
			AddLabel(87, 274, 53, (totalGold - offer).ToString());

			AddLabel(137, 274, 0, "Tithe:");
			AddLabel(172, 274, 53, offer.ToString());

			AddButton(105, 230, 5220, 5220, 2, GumpButtonType.Reply, 0);
			AddButton(113, 230, 5222, 5222, 2, GumpButtonType.Reply, 0);
			AddLabel(108, 228, 0, "<");
			AddLabel(112, 228, 0, "<");

			AddButton(127, 230, 5223, 5223, 1, GumpButtonType.Reply, 0);
			AddLabel(131, 228, 0, "<");

			AddButton(147, 230, 5224, 5224, 3, GumpButtonType.Reply, 0);
			AddLabel(153, 228, 0, ">");

			AddButton(168, 230, 5220, 5220, 4, GumpButtonType.Reply, 0);
			AddButton(176, 230, 5222, 5222, 4, GumpButtonType.Reply, 0);
			AddLabel(172, 228, 0, ">");
			AddLabel(176, 228, 0, ">");

			AddButton(217, 272, 4023, 4024, 5, GumpButtonType.Reply, 0);
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			switch (info.ButtonID)
			{
				case 0:
					{
						// You have decided to tithe no gold to the shrine.
						m_From.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1060193);
						break;
					}
				case 1:
				case 2:
				case 3:
				case 4:
					{
						var offer = 0;

						switch (info.ButtonID)
						{
							case 1: offer = m_Offer - 100; break;
							case 2: offer = 0; break;
							case 3: offer = m_Offer + 100; break;
							case 4: offer = m_From.TotalGold; break;
						}

						m_From.SendGump(new TithingGump(m_From, offer));
						break;
					}
				case 5:
					{
						var totalGold = m_From.TotalGold;

						if (m_Offer > totalGold)
						{
							m_Offer = totalGold;
						}
						else if (m_Offer < 0)
						{
							m_Offer = 0;
						}

						if ((m_From.TithingPoints + m_Offer) > 100000) // TODO: What's the maximum?
						{
							m_Offer = (100000 - m_From.TithingPoints);
						}

						if (m_Offer <= 0)
						{
							// You have decided to tithe no gold to the shrine.
							m_From.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1060193);
							break;
						}

						var pack = m_From.Backpack;

						if (pack != null && pack.ConsumeTotal(typeof(Gold), m_Offer))
						{
							// You tithe gold to the shrine as a sign of devotion.
							m_From.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1060195);
							m_From.TithingPoints += m_Offer;

							m_From.PlaySound(0x243);
							m_From.PlaySound(0x2E6);
						}
						else
						{
							// You do not have enough gold to tithe that amount!
							m_From.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1060194);
						}

						break;
					}
			}
		}
	}
}