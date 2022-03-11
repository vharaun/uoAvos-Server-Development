using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class PromotionalDeed_GM : Item
	{
		[Constructable]
		public PromotionalDeed_GM() : base(0x14EE)
		{
			Name = "A Gift Deed";
			Weight = 1.0;
			LootType = LootType.Blessed;
			Hue = 0x26;
		}

		public override void OnDoubleClick(Mobile from)
		{
			var pgd = from.Backpack.FindItemByType(typeof(PromotionalDeed_GM));
			if (pgd != null)
			{
				if (ItemID == 0x14EE)
				{
					ItemID = 0x14F0;
				}
				else if (ItemID == 0x14F0)
				{
					ItemID = 0x14EE;
				}

				from.SendGump(new PromotionalGift_GM(from, this));

				if (ItemID == 0x14EE)
				{
					from.CloseGump(typeof(PromotionalGift_GM));
				}
			}
			else
			{
				if (!IsChildOf(from.Backpack))
				{
					from.SendMessage("The Deed's Owner Shouldn't Have Dropped This!");
					Delete();
				}
			}
		}

		public void OnRemoved(object parent)
		{
			Mobile m = null;

			if (parent is Item)
			{
				m = ((Item)parent).RootParent as Mobile;
			}
			else if (parent is Mobile)
			{
				m = (Mobile)parent;
			}

			if (m != null)
			{
				m.CloseGump(typeof(PromotionalGift_GM));
			}
		}

		public PromotionalDeed_GM(Serial serial) : base(serial)
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

	public class PromotionalGift_GM : Gump
	{
		private readonly Item m_Deed;
		private readonly Mobile m_Mobile;

		#region Promotional Gift Gump Configuration

		public PromotionalGift_GM(Mobile from, Item deed) : base(0, 0)
		{
			m_Mobile = from;
			m_Deed = deed;

			var Aegis = new Aegis();

			{
				Closable = true;
				Disposable = true;
				Dragable = true;
				Resizable = false;

				AddPage(0);

				AddBackground(188, 91, 417, 430, 9390);
				AddAlphaRegion(218, 129, 356, 319);
				AddButton(227, 141, 2328, 2329, (int)Buttons.Button1, GumpButtonType.Reply, 1);
				AddButton(356, 141, 2328, 2329, (int)Buttons.Button2, GumpButtonType.Reply, 2);
				AddButton(484, 141, 2328, 2329, (int)Buttons.Button3, GumpButtonType.Reply, 3);
				AddButton(227, 219, 2328, 2329, (int)Buttons.Button4, GumpButtonType.Reply, 4);
				AddButton(356, 219, 2328, 2329, (int)Buttons.Button5, GumpButtonType.Reply, 5);
				AddButton(484, 219, 2328, 2329, (int)Buttons.Button6, GumpButtonType.Reply, 6);
				AddButton(227, 300, 2328, 2329, (int)Buttons.Button7, GumpButtonType.Reply, 7);
				AddButton(356, 300, 2328, 2329, (int)Buttons.Button8, GumpButtonType.Reply, 8);
				AddButton(484, 300, 2328, 2329, (int)Buttons.Button9, GumpButtonType.Reply, 9);
				AddButton(227, 378, 2328, 2329, (int)Buttons.Button10, GumpButtonType.Reply, 10);
				AddButton(356, 378, 2328, 2329, (int)Buttons.Button11, GumpButtonType.Reply, 11);
				AddButton(484, 378, 2328, 2329, (int)Buttons.Button12, GumpButtonType.Reply, 12);
				AddLabel(232, 132, 195, @"JAN    01");
				AddLabel(361, 132, 195, @"FEB    02");
				AddLabel(487, 132, 195, @"MAR    03");
				AddLabel(231, 211, 195, @"APR    04");
				AddLabel(359, 211, 195, @"MAY    05");
				AddLabel(487, 211, 195, @"JUN    06");
				AddLabel(232, 292, 195, @"JUL    07");
				AddLabel(360, 292, 195, @"AUG    08");
				AddLabel(488, 292, 195, @"SEP    09");
				AddLabel(233, 370, 195, @"OCT    10");
				AddLabel(363, 370, 195, @"NOV    11");
				AddLabel(490, 370, 195, @"DEC    12");
				AddLabel(356, 458, 190, @"PROMOTIONAL GIFT ITEMS");
				AddLabel(231, 458, 232, @"2011");
				AddLabel(422, 471, 695, @"SHADOWS EDGE");
				AddItem(261, 452, 9002);
				AddLabel(326, 95, 190, @"PLEASE SELECT A GIFT");
				AddButton(528, 455, 9005, 9004, (int)Buttons.Button0, GumpButtonType.Reply, 0);
			}
		}

		#endregion Edited By: A.A.R

		public enum Buttons
		{
			Button0,
			Button1,
			Button2,
			Button3,
			Button4,
			Button5,
			Button6,
			Button7,
			Button8,
			Button9,
			Button10,
			Button11,
			Button12,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button0:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}

				case (int)Buttons.Button1:
					{
						Item item = new Aegis();
						from.AddToBackpack(item);
						from.SendMessage("Your Reward Has Been Chosen, Enjoy!");
						from.CloseGump(typeof(PromotionalGift_GM));
						m_Deed.Delete();
						break;
					}

				case (int)Buttons.Button2:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
				case (int)Buttons.Button3:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
				case (int)Buttons.Button4:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
				case (int)Buttons.Button5:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
				case (int)Buttons.Button6:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
				case (int)Buttons.Button7:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
				case (int)Buttons.Button8:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
				case (int)Buttons.Button9:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
				case (int)Buttons.Button10:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
				case (int)Buttons.Button11:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
				case (int)Buttons.Button12:
					{
						from.CloseGump(typeof(PromotionalGift_GM));
						break;
					}
			}
		}
	}

	public class PromotionalDeed_PR : Item
	{
		[Constructable]
		public PromotionalDeed_PR() : base(0x14EE)
		{
			Name = "A Gift Deed";
			Weight = 1.0;
			LootType = LootType.Blessed;
			Hue = 0x3;
		}

		public override void OnDoubleClick(Mobile from)
		{
			var pgd = from.Backpack.FindItemByType(typeof(PromotionalDeed_PR));
			if (pgd != null)
			{
				if (ItemID == 0x14EE)
				{
					ItemID = 0x14F0;
				}
				else if (ItemID == 0x14F0)
				{
					ItemID = 0x14EE;
				}

				from.SendGump(new PromotionalGift_PR(from, this));

				if (ItemID == 0x14EE)
				{
					from.CloseGump(typeof(PromotionalGift_PR));
				}
			}
			else
			{
				if (!IsChildOf(from.Backpack))
				{
					from.SendMessage("The Deed's Owner Shouldn't Have Dropped This!");
					Delete();
				}
			}
		}

		public void OnRemoved(object parent)
		{
			Mobile m = null;

			if (parent is Item)
			{
				m = ((Item)parent).RootParent as Mobile;
			}
			else if (parent is Mobile)
			{
				m = (Mobile)parent;
			}

			if (m != null)
			{
				m.CloseGump(typeof(PromotionalGift_PR));
			}
		}

		public PromotionalDeed_PR(Serial serial) : base(serial)
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

	public class PromotionalGift_PR : Gump
	{
		private readonly Item m_Deed;
		private readonly Mobile m_Mobile;

		#region Promotional Gift Gump Configuration

		public PromotionalGift_PR(Mobile from, Item deed) : base(0, 0)
		{
			m_Mobile = from;
			m_Deed = deed;
			{
				Closable = true;
				Disposable = true;
				Dragable = true;
				Resizable = false;

				AddPage(0);

				AddBackground(188, 91, 417, 430, 9390);
				AddAlphaRegion(218, 129, 356, 319);
				AddButton(227, 141, 2328, 2329, (int)Buttons.Button1, GumpButtonType.Reply, 1);
				AddButton(356, 141, 2328, 2329, (int)Buttons.Button2, GumpButtonType.Reply, 2);
				AddButton(484, 141, 2328, 2329, (int)Buttons.Button3, GumpButtonType.Reply, 3);
				AddButton(227, 219, 2328, 2329, (int)Buttons.Button4, GumpButtonType.Reply, 4);
				AddButton(356, 219, 2328, 2329, (int)Buttons.Button5, GumpButtonType.Reply, 5);
				AddButton(484, 219, 2328, 2329, (int)Buttons.Button6, GumpButtonType.Reply, 6);
				AddButton(227, 300, 2328, 2329, (int)Buttons.Button7, GumpButtonType.Reply, 7);
				AddButton(356, 300, 2328, 2329, (int)Buttons.Button8, GumpButtonType.Reply, 8);
				AddButton(484, 300, 2328, 2329, (int)Buttons.Button9, GumpButtonType.Reply, 9);
				AddButton(227, 378, 2328, 2329, (int)Buttons.Button10, GumpButtonType.Reply, 10);
				AddButton(356, 378, 2328, 2329, (int)Buttons.Button11, GumpButtonType.Reply, 11);
				AddButton(484, 378, 2328, 2329, (int)Buttons.Button12, GumpButtonType.Reply, 12);
				AddLabel(232, 132, 195, @"JAN    01");
				AddLabel(361, 132, 195, @"FEB    02");
				AddLabel(487, 132, 195, @"MAR    03");
				AddLabel(231, 211, 195, @"APR    04");
				AddLabel(359, 211, 195, @"MAY    05");
				AddLabel(487, 211, 195, @"JUN    06");
				AddLabel(232, 292, 195, @"JUL    07");
				AddLabel(360, 292, 195, @"AUG    08");
				AddLabel(488, 292, 195, @"SEP    09");
				AddLabel(233, 370, 195, @"OCT    10");
				AddLabel(363, 370, 195, @"NOV    11");
				AddLabel(490, 370, 195, @"DEC    12");
				AddLabel(356, 458, 190, @"PROMOTIONAL GIFT ITEMS");
				AddLabel(231, 458, 232, @"2011");
				AddLabel(422, 471, 695, @"SHADOWS EDGE");
				AddItem(261, 452, 9002);
				AddLabel(326, 95, 190, @"PLEASE SELECT A GIFT");
				AddButton(528, 455, 9005, 9004, (int)Buttons.Button0, GumpButtonType.Reply, 0);
			}
		}

		#endregion Edited By: A.A.R

		public enum Buttons
		{
			Button0,
			Button1,
			Button2,
			Button3,
			Button4,
			Button5,
			Button6,
			Button7,
			Button8,
			Button9,
			Button10,
			Button11,
			Button12,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button0:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}

				case (int)Buttons.Button1:
					{
						Item item = new Dagger();
						from.AddToBackpack(item);
						from.SendMessage("Your Reward Has Been Chosen, Enjoy!");
						from.CloseGump(typeof(PromotionalGift_PR));
						m_Deed.Delete();
						break;
					}

				case (int)Buttons.Button2:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
				case (int)Buttons.Button3:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
				case (int)Buttons.Button4:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
				case (int)Buttons.Button5:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
				case (int)Buttons.Button6:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
				case (int)Buttons.Button7:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
				case (int)Buttons.Button8:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
				case (int)Buttons.Button9:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
				case (int)Buttons.Button10:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
				case (int)Buttons.Button11:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
				case (int)Buttons.Button12:
					{
						from.CloseGump(typeof(PromotionalGift_PR));
						break;
					}
			}
		}
	}
}