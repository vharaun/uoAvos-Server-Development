﻿using Server.ContextMenus;
using Server.Engines.Publishing;
using Server.Gumps;
using Server.HuePickers;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Multis;
using Server.Network;
using Server.Prompts;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Server.Gumps
{
	/// Player Vendor
	public class PlayerVendorBuyGump : Gump
	{
		private readonly PlayerVendor m_Vendor;
		private readonly VendorItem m_VI;

		public PlayerVendorBuyGump(PlayerVendor vendor, VendorItem vi) : base(100, 200)
		{
			m_Vendor = vendor;
			m_VI = vi;

			AddBackground(100, 10, 300, 150, 5054);

			AddHtmlLocalized(125, 20, 250, 24, 1019070, false, false); // You have agreed to purchase:

			if (!String.IsNullOrEmpty(vi.Description))
			{
				AddLabel(125, 45, 0, vi.Description);
			}
			else
			{
				AddHtmlLocalized(125, 45, 250, 24, 1019072, false, false); // an item without a description
			}

			AddHtmlLocalized(125, 70, 250, 24, 1019071, false, false); // for the amount of:
			AddLabel(125, 95, 0, vi.Price.ToString());

			AddButton(250, 130, 4005, 4007, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(282, 130, 100, 24, 1011012, false, false); // CANCEL

			AddButton(120, 130, 4005, 4007, 1, GumpButtonType.Reply, 0);
			AddHtmlLocalized(152, 130, 100, 24, 1011036, false, false); // OKAY
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			var from = state.Mobile;

			if (!m_Vendor.CanInteractWith(from, false))
			{
				return;
			}

			if (m_Vendor.IsOwner(from))
			{
				m_Vendor.SayTo(from, 503212); // You own this shop, just take what you want.
				return;
			}

			if (info.ButtonID == 1)
			{
				m_Vendor.Say(from.Name);

				if (!m_VI.Valid || !m_VI.Item.IsChildOf(m_Vendor.Backpack))
				{
					m_Vendor.SayTo(from, 503216); // You can't buy that.
					return;
				}

				var totalGold = 0;

				if (from.Backpack != null)
				{
					totalGold += from.Backpack.GetAmount(typeof(Gold));
				}

				totalGold += Banker.GetBalance(from);

				if (totalGold < m_VI.Price)
				{
					m_Vendor.SayTo(from, 503205); // You cannot afford this item.
				}
				else if (!from.PlaceInBackpack(m_VI.Item))
				{
					m_Vendor.SayTo(from, 503204); // You do not have room in your backpack for this.
				}
				else
				{
					var leftPrice = m_VI.Price;

					if (from.Backpack != null)
					{
						leftPrice -= from.Backpack.ConsumeUpTo(typeof(Gold), leftPrice);
					}

					if (leftPrice > 0)
					{
						Banker.Withdraw(from, leftPrice);
					}

					m_Vendor.HoldGold += m_VI.Price;

					from.SendLocalizedMessage(503201); // You take the item.
				}
			}
			else
			{
				from.SendLocalizedMessage(503207); // Cancelled purchase.
			}
		}
	}

	public class PlayerVendorOwnerGump : Gump
	{
		private readonly PlayerVendor m_Vendor;

		public PlayerVendorOwnerGump(PlayerVendor vendor) : base(50, 200)
		{
			m_Vendor = vendor;

			var perDay = m_Vendor.ChargePerDay;

			AddPage(0);
			AddBackground(25, 10, 530, 140, 5054);

			AddHtmlLocalized(425, 25, 120, 20, 1019068, false, false); // See goods
			AddButton(390, 25, 4005, 4007, 1, GumpButtonType.Reply, 0);
			AddHtmlLocalized(425, 48, 120, 20, 1019069, false, false); // Customize
			AddButton(390, 48, 4005, 4007, 2, GumpButtonType.Reply, 0);
			AddHtmlLocalized(425, 72, 120, 20, 1011012, false, false); // CANCEL
			AddButton(390, 71, 4005, 4007, 0, GumpButtonType.Reply, 0);

			AddHtmlLocalized(40, 72, 260, 20, 1038321, false, false); // Gold held for you:
			AddLabel(300, 72, 0, m_Vendor.HoldGold.ToString());
			AddHtmlLocalized(40, 96, 260, 20, 1038322, false, false); // Gold held in my account:
			AddLabel(300, 96, 0, m_Vendor.BankAccount.ToString());

			//AddHtmlLocalized( 40, 120, 260, 20, 1038324, false, false ); // My charge per day is:
			// Localization has changed, we must use a string here
			AddHtml(40, 120, 260, 20, "My charge per day is:", false, false);
			AddLabel(300, 120, 0, perDay.ToString());

			var days = (m_Vendor.HoldGold + m_Vendor.BankAccount) / ((double)perDay);

			AddHtmlLocalized(40, 25, 260, 20, 1038318, false, false); // Amount of days I can work: 
			AddLabel(300, 25, 0, ((int)days).ToString());
			AddHtmlLocalized(40, 48, 260, 20, 1038319, false, false); // Earth days: 
			AddLabel(300, 48, 0, ((int)(days / 12.0)).ToString());
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			var from = state.Mobile;

			if (!m_Vendor.CanInteractWith(from, true))
			{
				return;
			}

			switch (info.ButtonID)
			{
				case 1:
					{
						m_Vendor.OpenBackpack(from);

						break;
					}
				case 2:
					{
						from.SendGump(new PlayerVendorCustomizeGump(m_Vendor, from));

						break;
					}
			}
		}
	}

	public class NewPlayerVendorOwnerGump : Gump
	{
		private readonly PlayerVendor m_Vendor;

		public NewPlayerVendorOwnerGump(PlayerVendor vendor) : base(50, 200)
		{
			m_Vendor = vendor;

			var perRealWorldDay = vendor.ChargePerRealWorldDay;
			var goldHeld = vendor.HoldGold;

			AddBackground(25, 10, 530, 180, 0x13BE);

			AddImageTiled(35, 20, 510, 160, 0xA40);
			AddAlphaRegion(35, 20, 510, 160);

			AddImage(10, 0, 0x28DC);
			AddImage(537, 175, 0x28DC);
			AddImage(10, 175, 0x28DC);
			AddImage(537, 0, 0x28DC);

			if (goldHeld < perRealWorldDay)
			{
				var goldNeeded = perRealWorldDay - goldHeld;

				AddHtmlLocalized(40, 35, 260, 20, 1038320, 0x7FFF, false, false); // Gold needed for 1 day of vendor salary: 
				AddLabel(300, 35, 0x1F, goldNeeded.ToString());
			}
			else
			{
				var days = goldHeld / perRealWorldDay;

				AddHtmlLocalized(40, 35, 260, 20, 1038318, 0x7FFF, false, false); // # of days Vendor salary is paid for: 
				AddLabel(300, 35, 0x480, days.ToString());
			}

			AddHtmlLocalized(40, 58, 260, 20, 1038324, 0x7FFF, false, false); // My charge per real world day is: 
			AddLabel(300, 58, 0x480, perRealWorldDay.ToString());

			AddHtmlLocalized(40, 82, 260, 20, 1038322, 0x7FFF, false, false); // Gold held in my account: 
			AddLabel(300, 82, 0x480, goldHeld.ToString());

			AddHtmlLocalized(40, 108, 260, 20, 1062509, 0x7FFF, false, false); // Shop Name:
			AddLabel(140, 106, 0x66D, vendor.ShopName);

			if (vendor is RentedVendor)
			{
				int days, hours;
				((RentedVendor)vendor).ComputeRentalExpireDelay(out days, out hours);

				AddLabel(38, 132, 0x480, String.Format("Location rental will expire in {0} day{1} and {2} hour{3}.", days, days != 1 ? "s" : "", hours, hours != 1 ? "s" : ""));
			}

			AddButton(390, 24, 0x15E1, 0x15E5, 1, GumpButtonType.Reply, 0);
			AddHtmlLocalized(408, 21, 120, 20, 1019068, 0x7FFF, false, false); // See goods

			AddButton(390, 44, 0x15E1, 0x15E5, 2, GumpButtonType.Reply, 0);
			AddHtmlLocalized(408, 41, 120, 20, 1019069, 0x7FFF, false, false); // Customize

			AddButton(390, 64, 0x15E1, 0x15E5, 3, GumpButtonType.Reply, 0);
			AddHtmlLocalized(408, 61, 120, 20, 1062434, 0x7FFF, false, false); // Rename Shop

			AddButton(390, 84, 0x15E1, 0x15E5, 4, GumpButtonType.Reply, 0);
			AddHtmlLocalized(408, 81, 120, 20, 3006217, 0x7FFF, false, false); // Rename Vendor

			AddButton(390, 104, 0x15E1, 0x15E5, 5, GumpButtonType.Reply, 0);
			AddHtmlLocalized(408, 101, 120, 20, 3006123, 0x7FFF, false, false); // Open Paperdoll

			AddButton(390, 124, 0x15E1, 0x15E5, 6, GumpButtonType.Reply, 0);
			AddLabel(408, 121, 0x480, "Collect Gold");

			AddButton(390, 144, 0x15E1, 0x15E5, 7, GumpButtonType.Reply, 0);
			AddLabel(408, 141, 0x480, "Dismiss Vendor");

			AddButton(390, 162, 0x15E1, 0x15E5, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(408, 161, 120, 20, 1011012, 0x7FFF, false, false); // CANCEL
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			if (info.ButtonID == 1 || info.ButtonID == 2) // See goods or Customize
			{
				m_Vendor.CheckTeleport(from);
			}

			if (!m_Vendor.CanInteractWith(from, true))
			{
				return;
			}

			switch (info.ButtonID)
			{
				case 1: // See goods
					{
						m_Vendor.OpenBackpack(from);

						break;
					}
				case 2: // Customize
					{
						from.SendGump(new NewPlayerVendorCustomizeGump(m_Vendor));

						break;
					}
				case 3: // Rename Shop
					{
						m_Vendor.RenameShop(from);

						break;
					}
				case 4: // Rename Vendor
					{
						m_Vendor.Rename(from);

						break;
					}
				case 5: // Open Paperdoll
					{
						m_Vendor.DisplayPaperdollTo(from);

						break;
					}
				case 6: // Collect Gold
					{
						m_Vendor.CollectGold(from);

						break;
					}
				case 7: // Dismiss Vendor
					{
						m_Vendor.Dismiss(from);

						break;
					}
			}
		}
	}

	public class PlayerVendorCustomizeGump : Gump
	{
		private readonly Mobile m_Vendor;

		private class CustomItem
		{
			private readonly Type m_Type;
			private readonly int m_ItemID;
			private readonly int m_LocNum;
			private readonly int m_ArtNum;
			private readonly bool m_LongText;

			public CustomItem(int itemID, int loc) : this(null, itemID, loc, 0, false)
			{
			}

			public CustomItem(int itemID, int loc, bool longText) : this(null, itemID, loc, 0, longText)
			{
			}

			public CustomItem(Type type, int loc) : this(type, loc, 0)
			{
			}

			public CustomItem(Type type, int loc, int art) : this(type, 0, loc, art, false)
			{
			}

			public CustomItem(Type type, int itemID, int loc, int art, bool longText)
			{
				m_Type = type;
				m_ItemID = itemID;
				m_LocNum = loc;
				m_ArtNum = art;
				m_LongText = longText;
			}

			public Item Create()
			{
				if (m_Type == null)
				{
					return null;
				}

				Item i = null;

				try
				{
					var ctor = m_Type.GetConstructor(new Type[0]);
					if (ctor != null)
					{
						i = ctor.Invoke(null) as Item;
					}
				}
				catch
				{
				}

				return i;
			}

			public Type Type => m_Type;
			public int ItemID => m_ItemID;
			public int LocNumber => m_LocNum;
			public int ArtNumber => m_ArtNum;
			public bool LongText => m_LongText;
		}

		private class CustomCategory
		{
			private readonly CustomItem[] m_Entries;
			private readonly Layer m_Layer;
			private readonly bool m_CanDye;
			private readonly int m_LocNum;

			public CustomCategory(Layer layer, int loc, bool canDye, CustomItem[] items)
			{
				m_Entries = items;
				m_CanDye = canDye;
				m_Layer = layer;
				m_LocNum = loc;
			}

			public bool CanDye => m_CanDye;
			public CustomItem[] Entries => m_Entries;
			public Layer Layer => m_Layer;
			public int LocNumber => m_LocNum;
		}

		private static readonly CustomCategory[] Categories = new CustomCategory[]{
			new CustomCategory( Layer.InnerTorso, 1011357, true, new CustomItem[]{// Upper Torso
				new CustomItem( typeof( Shirt ),        1011359, 5399 ),
				new CustomItem( typeof( FancyShirt ),   1011360, 7933 ),
				new CustomItem( typeof( PlainDress ),   1011363, 7937 ),
				new CustomItem( typeof( FancyDress ),   1011364, 7935 ),
				new CustomItem( typeof( Robe ),         1011365, 7939 )
			} ),

			new CustomCategory( Layer.MiddleTorso, 1011371, true, new CustomItem[]{//Over chest
				new CustomItem( typeof( Doublet ),      1011358, 8059 ),
				new CustomItem( typeof( Tunic ),        1011361, 8097 ),
				new CustomItem( typeof( JesterSuit ),   1011366, 8095 ),
				new CustomItem( typeof( BodySash ),     1011372, 5441 ),
				new CustomItem( typeof( Surcoat ),      1011362, 8189 ),
				new CustomItem( typeof( HalfApron ),    1011373, 5435 ),
				new CustomItem( typeof( FullApron ),    1011374, 5437 ),
			} ),

			new CustomCategory( Layer.Shoes, 1011388, true, new CustomItem[]{//Footwear
				new CustomItem( typeof( Sandals ),      1011389, 5901 ),
				new CustomItem( typeof( Shoes ),        1011390, 5904 ),
				new CustomItem( typeof( Boots ),        1011391, 5899 ),
				new CustomItem( typeof( ThighBoots ),   1011392, 5906 ),
			} ),

			new CustomCategory( Layer.Helm, 1011375, true, new CustomItem[]{//Hats
				new CustomItem( typeof( SkullCap ),     1011376, 5444 ),
				new CustomItem( typeof( Bandana ),      1011377, 5440 ),
				new CustomItem( typeof( FloppyHat ),    1011378, 5907 ),
				new CustomItem( typeof( WideBrimHat ),  1011379, 5908 ),
				new CustomItem( typeof( Cap ),          1011380, 5909 ),
				new CustomItem( typeof( TallStrawHat ), 1011382, 5910 )
			} ),

			new CustomCategory( Layer.Helm, 1015319, true, new CustomItem[]{//More Hats
			    new CustomItem( typeof( StrawHat ),     1011382, 5911 ),
				new CustomItem( typeof( WizardsHat ),   1011383, 5912 ),
				new CustomItem( typeof( Bonnet ),       1011384, 5913 ),
				new CustomItem( typeof( FeatheredHat ), 1011385, 5914 ),
				new CustomItem( typeof( TricorneHat ),  1011386, 5915 ),
				new CustomItem( typeof( JesterHat ),    1011387, 5916 )
			} ),

			new CustomCategory( Layer.Pants, 1011367, true, new CustomItem[]{ //Lower Torso
				new CustomItem( typeof( LongPants ),    1011368, 5433 ),
				new CustomItem( typeof( Kilt ),         1011369, 5431 ),
				new CustomItem( typeof( Skirt ),        1011370, 5398 ),
			} ),

			new CustomCategory( Layer.Cloak, 1011393, true, new CustomItem[]{ // Back
				new CustomItem( typeof( Cloak ),        1011394, 5397 )
			} ),

			new CustomCategory( Layer.Hair, 1011395, true, new CustomItem[]{ // Hair
				new CustomItem( 0x203B,     1011052 ),
				new CustomItem( 0x203C,     1011053 ),
				new CustomItem( 0x203D,     1011054 ),
				new CustomItem( 0x2044,     1011055 ),
				new CustomItem( 0x2045,     1011047 ),
				new CustomItem( 0x204A,     1011050 ),
				new CustomItem( 0x2047,     1011396 ),
				new CustomItem( 0x2048,     1011048 ),
				new CustomItem( 0x2049,     1011049 ),
			} ),

			new CustomCategory( Layer.FacialHair, 1015320, true, new CustomItem[]{//Facial Hair
				new CustomItem( 0x2041,     1011062 ),
				new CustomItem( 0x203F,     1011060 ),
				new CustomItem( 0x204B,     1015321, true ),
				new CustomItem( 0x203E,     1011061 ),
				new CustomItem( 0x204C,     1015322, true ),
				new CustomItem( 0x2040,     1015323 ),
				new CustomItem( 0x204D,     1011401 ),
			} ),

			new CustomCategory( Layer.FirstValid, 1011397, false, new CustomItem[]{//Held items
				new CustomItem( typeof( FishingPole ),  1011406, 3520 ),
				new CustomItem( typeof( Pickaxe ),      1011407, 3717 ),
				new CustomItem( typeof( Pitchfork ),    1011408, 3720 ),
				new CustomItem( typeof( Cleaver ),      1015324, 3778 ),
				new CustomItem( typeof( Mace ),         1011409, 3933 ),
				new CustomItem( typeof( Torch ),        1011410, 3940 ),
				new CustomItem( typeof( Hammer ),       1011411, 4020 ),
				new CustomItem( typeof( Longsword ),    1011412, 3936 ),
				new CustomItem( typeof( GnarledStaff ), 1011413, 5113 )
			} ),

			new CustomCategory( Layer.FirstValid, 1015325, false, new CustomItem[]{//More held items
				new CustomItem( typeof( Crossbow ),     1011414, 3920 ),
				new CustomItem( typeof( WarMace ),      1011415, 5126 ),
				new CustomItem( typeof( TwoHandedAxe ), 1011416, 5186 ),
				new CustomItem( typeof( Spear ),        1011417, 3939 ),
				new CustomItem( typeof( Katana ),       1011418, 5118 ),
				new CustomItem( typeof( Spellbook ),    1011419, 3834 )
			} )
		};

		public PlayerVendorCustomizeGump(Mobile v, Mobile from) : base(30, 40)
		{
			m_Vendor = v;
			int x, y;

			from.CloseGump(typeof(PlayerVendorCustomizeGump));

			AddPage(0);
			AddBackground(0, 0, 585, 393, 5054);
			AddBackground(195, 36, 387, 275, 3000);
			AddHtmlLocalized(10, 10, 565, 18, 1011356, false, false); // <center>VENDOR CUSTOMIZATION MENU</center>
			AddHtmlLocalized(60, 355, 150, 18, 1011036, false, false); // OKAY
			AddButton(25, 355, 4005, 4007, 1, GumpButtonType.Reply, 0);
			AddHtmlLocalized(320, 355, 150, 18, 1011012, false, false); // CANCEL
			AddButton(285, 355, 4005, 4007, 0, GumpButtonType.Reply, 0);

			y = 35;
			for (var i = 0; i < Categories.Length; i++)
			{
				var cat = Categories[i];
				AddHtmlLocalized(5, y, 150, 25, cat.LocNumber, true, false);
				AddButton(155, y, 4005, 4007, 0, GumpButtonType.Page, i + 1);
				y += 25;
			}

			for (var i = 0; i < Categories.Length; i++)
			{
				var cat = Categories[i];
				AddPage(i + 1);

				for (var c = 0; c < cat.Entries.Length; c++)
				{
					var entry = cat.Entries[c];
					x = 198 + (c % 3) * 129;
					y = 38 + (c / 3) * 67;

					AddHtmlLocalized(x, y, 100, entry.LongText ? 36 : 18, entry.LocNumber, false, false);

					if (entry.ArtNumber != 0)
					{
						AddItem(x + 20, y + 25, entry.ArtNumber);
					}

					AddRadio(x, y + (entry.LongText ? 40 : 20), 210, 211, false, (c << 8) + i);
				}

				if (cat.CanDye)
				{
					AddHtmlLocalized(327, 239, 100, 18, 1011402, false, false); // Color
					AddRadio(327, 259, 210, 211, false, 100 + i);
				}

				AddHtmlLocalized(456, 239, 100, 18, 1011403, false, false); // Remove
				AddRadio(456, 259, 210, 211, false, 200 + i);
			}
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			if (m_Vendor.Deleted)
			{
				return;
			}

			var from = state.Mobile;

			if (m_Vendor is PlayerVendor && !((PlayerVendor)m_Vendor).CanInteractWith(from, true))
			{
				return;
			}

			if (m_Vendor is PlayerBarkeeper && !((PlayerBarkeeper)m_Vendor).IsOwner(from))
			{
				return;
			}

			if (info.ButtonID == 0)
			{
				if (m_Vendor is PlayerVendor) // do nothing for barkeeps
				{
					m_Vendor.Direction = m_Vendor.GetDirectionTo(from);
					m_Vendor.Animate(32, 5, 1, true, false, 0);//bow
					m_Vendor.SayTo(from, 1043310 + Utility.Random(12)); // a little random speech
				}
			}
			else if (info.ButtonID == 1 && info.Switches.Length > 0)
			{
				var cnum = info.Switches[0];
				var cat = cnum % 256;
				var ent = cnum >> 8;

				if (cat < Categories.Length && cat >= 0)
				{
					if (ent < Categories[cat].Entries.Length && ent >= 0)
					{
						var item = m_Vendor.FindItemOnLayer(Categories[cat].Layer);

						if (item != null)
						{
							item.Delete();
						}

						var items = m_Vendor.Items;

						for (var i = 0; item == null && i < items.Count; ++i)
						{
							var checkitem = items[i];
							var type = checkitem.GetType();

							for (var j = 0; item == null && j < Categories[cat].Entries.Length; ++j)
							{
								if (type == Categories[cat].Entries[j].Type)
								{
									item = checkitem;
								}
							}
						}

						if (item != null)
						{
							item.Delete();
						}

						if (Categories[cat].Layer == Layer.FacialHair)
						{
							if (m_Vendor.Female)
							{
								from.SendLocalizedMessage(1010639); // You cannot place facial hair on a woman!
							}
							else
							{
								var hue = m_Vendor.FacialHairHue;

								m_Vendor.FacialHairItemID = 0;
								m_Vendor.ProcessDelta(); // invalidate item ID for clients

								m_Vendor.FacialHairItemID = Categories[cat].Entries[ent].ItemID;
								m_Vendor.FacialHairHue = hue;
							}
						}
						else if (Categories[cat].Layer == Layer.Hair)
						{
							var hue = m_Vendor.HairHue;

							m_Vendor.HairItemID = 0;
							m_Vendor.ProcessDelta(); // invalidate item ID for clients

							m_Vendor.HairItemID = Categories[cat].Entries[ent].ItemID;
							m_Vendor.HairHue = hue;
						}
						else
						{
							item = Categories[cat].Entries[ent].Create();

							if (item != null)
							{
								item.Layer = Categories[cat].Layer;

								if (!m_Vendor.EquipItem(item))
								{
									item.Delete();
								}
							}
						}

						from.SendGump(new PlayerVendorCustomizeGump(m_Vendor, from));
					}
				}
				else
				{
					cat -= 100;

					if (cat < 100)
					{
						if (cat < Categories.Length && cat >= 0)
						{
							var category = Categories[cat];

							if (category.Layer == Layer.Hair)
							{
								new PVHairHuePicker(false, m_Vendor, from).SendTo(state);
							}
							else if (category.Layer == Layer.FacialHair)
							{
								new PVHairHuePicker(true, m_Vendor, from).SendTo(state);
							}
							else
							{
								Item item = null;

								var items = m_Vendor.Items;

								for (var i = 0; item == null && i < items.Count; ++i)
								{
									var checkitem = items[i];
									var type = checkitem.GetType();

									for (var j = 0; item == null && j < category.Entries.Length; ++j)
									{
										if (type == category.Entries[j].Type)
										{
											item = checkitem;
										}
									}
								}

								if (item != null)
								{
									new PVHuePicker(item, m_Vendor, from).SendTo(state);
								}
							}
						}
					}
					else
					{
						cat -= 100;

						if (cat < Categories.Length && cat >= 0)
						{
							var category = Categories[cat];

							if (category.Layer == Layer.Hair)
							{
								m_Vendor.HairItemID = 0;
							}
							else if (category.Layer == Layer.FacialHair)
							{
								m_Vendor.FacialHairItemID = 0;
							}
							else
							{
								Item item = null;

								var items = m_Vendor.Items;

								for (var i = 0; item == null && i < items.Count; ++i)
								{
									var checkitem = items[i];
									var type = checkitem.GetType();

									for (var j = 0; item == null && j < category.Entries.Length; ++j)
									{
										if (type == category.Entries[j].Type)
										{
											item = checkitem;
										}
									}
								}

								if (item != null)
								{
									item.Delete();
								}
							}

							from.SendGump(new PlayerVendorCustomizeGump(m_Vendor, from));
						}
					}
				}
			}
		}

		private class PVHuePicker : HuePicker
		{
			private readonly Item m_Item;
			private readonly Mobile m_Vendor;
			private readonly Mobile m_Mob;

			public PVHuePicker(Item item, Mobile v, Mobile from) : base(item.ItemID)
			{
				m_Item = item;
				m_Vendor = v;
				m_Mob = from;
			}

			public override void OnResponse(int hue)
			{
				if (m_Item.Deleted)
				{
					return;
				}

				if (m_Vendor is PlayerVendor && !((PlayerVendor)m_Vendor).CanInteractWith(m_Mob, true))
				{
					return;
				}

				if (m_Vendor is PlayerBarkeeper && !((PlayerBarkeeper)m_Vendor).IsOwner(m_Mob))
				{
					return;
				}

				m_Item.Hue = hue;
				m_Mob.SendGump(new PlayerVendorCustomizeGump(m_Vendor, m_Mob));
			}
		}

		private class PVHairHuePicker : HuePicker
		{
			private readonly bool m_FacialHair;
			private readonly Mobile m_Vendor;
			private readonly Mobile m_Mob;

			public PVHairHuePicker(bool facialHair, Mobile v, Mobile from) : base(0xFAB)
			{
				m_FacialHair = facialHair;
				m_Vendor = v;
				m_Mob = from;
			}

			public override void OnResponse(int hue)
			{
				if (m_Vendor.Deleted)
				{
					return;
				}

				if (m_Vendor is PlayerVendor && !((PlayerVendor)m_Vendor).CanInteractWith(m_Mob, true))
				{
					return;
				}

				if (m_Vendor is PlayerBarkeeper && !((PlayerBarkeeper)m_Vendor).IsOwner(m_Mob))
				{
					return;
				}

				if (m_FacialHair)
				{
					m_Vendor.FacialHairHue = hue;
				}
				else
				{
					m_Vendor.HairHue = hue;
				}

				m_Mob.SendGump(new PlayerVendorCustomizeGump(m_Vendor, m_Mob));
			}
		}
	}

	public class NewPlayerVendorCustomizeGump : Gump
	{
		private readonly PlayerVendor m_Vendor;

		private class HairOrBeard
		{
			private readonly int m_ItemID;
			private readonly int m_Name;

			public int ItemID => m_ItemID;
			public int Name => m_Name;

			public HairOrBeard(int itemID, int name)
			{
				m_ItemID = itemID;
				m_Name = name;
			}
		}

		private static readonly HairOrBeard[] m_HairStyles = new HairOrBeard[]
			{
				new HairOrBeard( 0x203B,    1011052 ),	// Short
				new HairOrBeard( 0x203C,    1011053 ),	// Long
				new HairOrBeard( 0x203D,    1011054 ),	// Ponytail
				new HairOrBeard( 0x2044,    1011055 ),	// Mohawk
				new HairOrBeard( 0x2045,    1011047 ),	// Pageboy
				new HairOrBeard( 0x204A,    1011050 ),	// Topknot
				new HairOrBeard( 0x2047,    1011396 ),	// Curly
				new HairOrBeard( 0x2048,    1011048 ),	// Receding
				new HairOrBeard( 0x2049,    1011049 )	// 2-tails
			};

		private static readonly HairOrBeard[] m_BeardStyles = new HairOrBeard[]
			{
				new HairOrBeard( 0x2041,    1011062 ),	// Mustache
				new HairOrBeard( 0x203F,    1011060 ),	// Short beard
				new HairOrBeard( 0x204B,    1015321 ),	// Short Beard & Moustache
				new HairOrBeard( 0x203E,    1011061 ),	// Long beard
				new HairOrBeard( 0x204C,    1015322 ),	// Long Beard & Moustache
				new HairOrBeard( 0x2040,    1015323 ),	// Goatee
				new HairOrBeard( 0x204D,    1011401 )	// Vandyke
			};

		public NewPlayerVendorCustomizeGump(PlayerVendor vendor) : base(50, 50)
		{
			m_Vendor = vendor;

			AddBackground(0, 0, 370, 370, 0x13BE);

			AddImageTiled(10, 10, 350, 20, 0xA40);
			AddImageTiled(10, 40, 350, 20, 0xA40);
			AddImageTiled(10, 70, 350, 260, 0xA40);
			AddImageTiled(10, 340, 350, 20, 0xA40);

			AddAlphaRegion(10, 10, 350, 350);

			AddHtmlLocalized(10, 12, 350, 18, 1011356, 0x7FFF, false, false); // <center>VENDOR CUSTOMIZATION MENU</center>

			AddHtmlLocalized(10, 42, 150, 18, 1062459, 0x421F, false, false); // <CENTER>HAIR</CENTER>

			for (var i = 0; i < m_HairStyles.Length; i++)
			{
				var hair = m_HairStyles[i];

				AddButton(10, 70 + i * 20, 0xFA5, 0xFA7, 0x100 | i, GumpButtonType.Reply, 0);
				AddHtmlLocalized(45, 72 + i * 20, 110, 18, hair.Name, 0x7FFF, false, false);
			}

			AddButton(10, 70 + m_HairStyles.Length * 20, 0xFB1, 0xFB3, 2, GumpButtonType.Reply, 0);
			AddHtmlLocalized(45, 72 + m_HairStyles.Length * 20, 110, 18, 1011403, 0x7FFF, false, false); // Remove

			AddButton(10, 70 + (m_HairStyles.Length + 1) * 20, 0xFA5, 0xFA7, 3, GumpButtonType.Reply, 0);
			AddHtmlLocalized(45, 72 + (m_HairStyles.Length + 1) * 20, 110, 18, 1011402, 0x7FFF, false, false); // Color

			if (vendor.Female)
			{
				AddButton(160, 290, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0);
				AddHtmlLocalized(195, 292, 160, 18, 1015327, 0x7FFF, false, false); // Male

				AddHtmlLocalized(195, 312, 160, 18, 1015328, 0x421F, false, false); // Female
			}
			else
			{
				AddHtmlLocalized(160, 42, 210, 18, 1062460, 0x421F, false, false); // <CENTER>BEARD</CENTER>

				for (var i = 0; i < m_BeardStyles.Length; i++)
				{
					var beard = m_BeardStyles[i];

					AddButton(160, 70 + i * 20, 0xFA5, 0xFA7, 0x200 | i, GumpButtonType.Reply, 0);
					AddHtmlLocalized(195, 72 + i * 20, 160, 18, beard.Name, 0x7FFF, false, false);
				}

				AddButton(160, 70 + m_BeardStyles.Length * 20, 0xFB1, 0xFB3, 4, GumpButtonType.Reply, 0);
				AddHtmlLocalized(195, 72 + m_BeardStyles.Length * 20, 160, 18, 1011403, 0x7FFF, false, false); // Remove

				AddButton(160, 70 + (m_BeardStyles.Length + 1) * 20, 0xFA5, 0xFA7, 5, GumpButtonType.Reply, 0);
				AddHtmlLocalized(195, 72 + (m_BeardStyles.Length + 1) * 20, 160, 18, 1011402, 0x7FFF, false, false); // Color

				AddHtmlLocalized(195, 292, 160, 18, 1015327, 0x421F, false, false); // Male

				AddButton(160, 310, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0);
				AddHtmlLocalized(195, 312, 160, 18, 1015328, 0x7FFF, false, false); // Female
			}

			AddButton(10, 340, 0xFA5, 0xFA7, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(45, 342, 305, 18, 1060675, 0x7FFF, false, false); // CLOSE
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			if (!m_Vendor.CanInteractWith(from, true))
			{
				return;
			}

			switch (info.ButtonID)
			{
				case 0: // CLOSE
					{
						m_Vendor.Direction = m_Vendor.GetDirectionTo(from);
						m_Vendor.Animate(32, 5, 1, true, false, 0); // bow
						m_Vendor.SayTo(from, 1043310 + Utility.Random(12)); // a little random speech

						break;
					}
				case 1: // Female/Male
					{
						if (m_Vendor.Female)
						{
							m_Vendor.BodyValue = 400;
							m_Vendor.Female = false;
						}
						else
						{
							m_Vendor.BodyValue = 401;
							m_Vendor.Female = true;

							m_Vendor.FacialHairItemID = 0;
						}

						from.SendGump(new NewPlayerVendorCustomizeGump(m_Vendor));

						break;
					}
				case 2: // Remove hair
					{
						m_Vendor.HairItemID = 0;

						from.SendGump(new NewPlayerVendorCustomizeGump(m_Vendor));

						break;
					}
				case 3: // Color hair
					{
						if (m_Vendor.HairItemID > 0)
						{
							new PVHuePicker(m_Vendor, false, from).SendTo(from.NetState);
						}
						else
						{
							from.SendGump(new NewPlayerVendorCustomizeGump(m_Vendor));
						}

						break;
					}
				case 4: // Remove beard
					{
						m_Vendor.FacialHairItemID = 0;

						from.SendGump(new NewPlayerVendorCustomizeGump(m_Vendor));

						break;
					}
				case 5: // Color beard
					{
						if (m_Vendor.FacialHairItemID > 0)
						{
							new PVHuePicker(m_Vendor, true, from).SendTo(from.NetState);
						}
						else
						{
							from.SendGump(new NewPlayerVendorCustomizeGump(m_Vendor));
						}

						break;
					}
				default:
					{
						var hairhue = 0;

						if ((info.ButtonID & 0x100) != 0) // Hair style selected
						{
							var index = info.ButtonID & 0xFF;

							if (index >= m_HairStyles.Length)
							{
								return;
							}

							var hairStyle = m_HairStyles[index];

							hairhue = m_Vendor.HairHue;

							m_Vendor.HairItemID = 0;
							m_Vendor.ProcessDelta();

							m_Vendor.HairItemID = hairStyle.ItemID;

							m_Vendor.HairHue = hairhue;

							from.SendGump(new NewPlayerVendorCustomizeGump(m_Vendor));
						}
						else if ((info.ButtonID & 0x200) != 0) // Beard style selected
						{
							if (m_Vendor.Female)
							{
								return;
							}

							var index = info.ButtonID & 0xFF;

							if (index >= m_BeardStyles.Length)
							{
								return;
							}

							var beardStyle = m_BeardStyles[index];

							hairhue = m_Vendor.FacialHairHue;

							m_Vendor.FacialHairItemID = 0;
							m_Vendor.ProcessDelta();

							m_Vendor.FacialHairItemID = beardStyle.ItemID;

							m_Vendor.FacialHairHue = hairhue;

							from.SendGump(new NewPlayerVendorCustomizeGump(m_Vendor));
						}

						break;
					}
			}
		}

		private class PVHuePicker : HuePicker
		{
			private readonly PlayerVendor m_Vendor;
			private readonly bool m_FacialHair;
			private readonly Mobile m_From;

			public PVHuePicker(PlayerVendor vendor, bool facialHair, Mobile from) : base(0xFAB)
			{
				m_Vendor = vendor;
				m_FacialHair = facialHair;
				m_From = from;
			}

			public override void OnResponse(int hue)
			{
				if (!m_Vendor.CanInteractWith(m_From, true))
				{
					return;
				}

				if (m_FacialHair)
				{
					m_Vendor.FacialHairHue = hue;
				}
				else
				{
					m_Vendor.HairHue = hue;
				}

				m_From.SendGump(new NewPlayerVendorCustomizeGump(m_Vendor));
			}
		}
	}

	/// Rented Vendor
	public abstract class BaseVendorRentalGump : Gump
	{
		protected enum GumpType
		{
			UnlockedContract,
			LockedContract,
			Offer,
			VendorLandlord,
			VendorRenter
		}

		protected BaseVendorRentalGump(GumpType type, VendorRentalDuration duration, int price, int renewalPrice,
			Mobile landlord, Mobile renter, bool landlordRenew, bool renterRenew, bool renew) : base(100, 100)
		{
			if (type == GumpType.Offer)
			{
				Closable = false;
			}

			AddPage(0);

			AddImage(0, 0, 0x1F40);
			AddImageTiled(20, 37, 300, 308, 0x1F42);
			AddImage(20, 325, 0x1F43);

			AddImage(35, 8, 0x39);
			AddImageTiled(65, 8, 257, 10, 0x3A);
			AddImage(290, 8, 0x3B);

			AddImageTiled(70, 55, 230, 2, 0x23C5);

			AddImage(32, 33, 0x2635);
			AddHtmlLocalized(70, 35, 270, 20, 1062353, 0x1, false, false); // Vendor Rental Contract


			AddPage(1);

			if (type != GumpType.UnlockedContract)
			{
				AddImage(65, 60, 0x827);
				AddHtmlLocalized(79, 58, 270, 20, 1062370, 0x1, false, false); // Landlord:
				AddLabel(150, 58, 0x64, landlord != null ? landlord.Name : "");

				AddImageTiled(70, 80, 230, 2, 0x23C5);
			}

			if (type == GumpType.UnlockedContract || type == GumpType.LockedContract)
			{
				AddButton(30, 96, 0x15E1, 0x15E5, 0, GumpButtonType.Page, 2);
			}

			AddHtmlLocalized(50, 95, 150, 20, 1062354, 0x1, false, false); // Contract Length
			AddHtmlLocalized(230, 95, 270, 20, duration.Name, 0x1, false, false);

			if (type == GumpType.UnlockedContract || type == GumpType.LockedContract)
			{
				AddButton(30, 116, 0x15E1, 0x15E5, 1, GumpButtonType.Reply, 0);
			}

			AddHtmlLocalized(50, 115, 150, 20, 1062356, 0x1, false, false); // Price Per Rental
			AddLabel(230, 115, 0x64, price > 0 ? price.ToString() : "FREE");

			AddImageTiled(50, 160, 250, 2, 0x23BF);

			if (type == GumpType.Offer)
			{
				AddButton(67, 180, 0x482, 0x483, 2, GumpButtonType.Reply, 0);
				AddHtmlLocalized(100, 180, 270, 20, 1049011, 0x28, false, false); // I accept!

				AddButton(67, 210, 0x47F, 0x480, 0, GumpButtonType.Reply, 0);
				AddHtmlLocalized(100, 210, 270, 20, 1049012, 0x28, false, false); // No thanks, I decline.
			}
			else
			{
				AddImage(49, 170, 0x61);
				AddHtmlLocalized(60, 170, 250, 20, 1062355, 0x1, false, false); // Renew On Expiration?

				if (type == GumpType.LockedContract || type == GumpType.UnlockedContract || type == GumpType.VendorLandlord)
				{
					AddButton(30, 192, 0x15E1, 0x15E5, 3, GumpButtonType.Reply, 0);
				}

				AddHtmlLocalized(85, 190, 250, 20, 1062359, 0x1, false, false); // Landlord:
				AddHtmlLocalized(230, 190, 270, 20, landlordRenew ? 1049717 : 1049718, 0x1, false, false); // YES / NO

				if (type == GumpType.VendorRenter)
				{
					AddButton(30, 212, 0x15E1, 0x15E5, 4, GumpButtonType.Reply, 0);
				}

				AddHtmlLocalized(85, 210, 250, 20, 1062360, 0x1, false, false); // Renter:
				AddHtmlLocalized(230, 210, 270, 20, renterRenew ? 1049717 : 1049718, 0x1, false, false); // YES / NO

				if (renew)
				{
					AddImage(49, 233, 0x939);
					AddHtmlLocalized(70, 230, 250, 20, 1062482, 0x1, false, false); // Contract WILL renew
				}
				else
				{
					AddImage(49, 233, 0x938);
					AddHtmlLocalized(70, 230, 250, 20, 1062483, 0x1, false, false); // Contract WILL NOT renew
				}
			}

			AddImageTiled(30, 283, 257, 30, 0x5D);
			AddImage(285, 283, 0x5E);
			AddImage(20, 288, 0x232C);

			if (type == GumpType.LockedContract)
			{
				AddButton(67, 295, 0x15E1, 0x15E5, 5, GumpButtonType.Reply, 0);
				AddHtmlLocalized(85, 294, 270, 20, 1062358, 0x28, false, false); // Offer Contract To Someone
			}
			else if (type == GumpType.VendorLandlord || type == GumpType.VendorRenter)
			{
				if (type == GumpType.VendorLandlord)
				{
					AddButton(30, 250, 0x15E1, 0x15E1, 6, GumpButtonType.Reply, 0);
				}

				AddHtmlLocalized(85, 250, 250, 20, 1062499, 0x1, false, false); // Renewal Price
				AddLabel(230, 250, 0x64, renewalPrice.ToString());

				AddHtmlLocalized(60, 294, 270, 20, 1062369, 0x1, false, false); // Renter:
				AddLabel(120, 293, 0x64, renter != null ? renter.Name : "");
			}


			if (type == GumpType.UnlockedContract || type == GumpType.LockedContract)
			{
				AddPage(2);

				for (var i = 0; i < VendorRentalDuration.Instances.Length; i++)
				{
					var durationItem = VendorRentalDuration.Instances[i];

					AddButton(30, 76 + i * 20, 0x15E1, 0x15E5, 0x10 | i, GumpButtonType.Reply, 1);
					AddHtmlLocalized(50, 75 + i * 20, 150, 20, durationItem.Name, 0x1, false, false);
				}
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			if (!IsValidResponse(from))
			{
				return;
			}

			if ((info.ButtonID & 0x10) != 0) // Contract duration
			{
				var index = info.ButtonID & 0xF;

				if (index < VendorRentalDuration.Instances.Length)
				{
					SetContractDuration(from, VendorRentalDuration.Instances[index]);
				}
			}
			else
			{
				switch (info.ButtonID)
				{
					case 1: // Price Per Rental
						SetPricePerRental(from);
						break;

					case 2: // Accept offer
						AcceptOffer(from);
						break;

					case 3: // Renew on expiration - landlord
						LandlordRenewOnExpiration(from);
						break;

					case 4: // Renew on expiration - renter
						RenterRenewOnExpiration(from);
						break;

					case 5: // Offer Contract To Someone
						OfferContract(from);
						break;

					case 6: // Renewal price
						SetRenewalPrice(from);
						break;

					default:
						Cancel(from);
						break;
				}
			}
		}

		protected abstract bool IsValidResponse(Mobile from);

		protected virtual void SetContractDuration(Mobile from, VendorRentalDuration duration)
		{
		}

		protected virtual void SetPricePerRental(Mobile from)
		{
		}

		protected virtual void AcceptOffer(Mobile from)
		{
		}

		protected virtual void LandlordRenewOnExpiration(Mobile from)
		{
		}

		protected virtual void RenterRenewOnExpiration(Mobile from)
		{
		}

		protected virtual void OfferContract(Mobile from)
		{
		}

		protected virtual void SetRenewalPrice(Mobile from)
		{
		}

		protected virtual void Cancel(Mobile from)
		{
		}
	}

	public class VendorRentalContractGump : BaseVendorRentalGump
	{
		private readonly VendorRentalContract m_Contract;

		public VendorRentalContractGump(VendorRentalContract contract, Mobile from) : base(
			contract.IsLockedDown ? GumpType.LockedContract : GumpType.UnlockedContract, contract.Duration,
			contract.Price, contract.Price, from, null, contract.LandlordRenew, false, false)
		{
			m_Contract = contract;
		}

		protected override bool IsValidResponse(Mobile from)
		{
			return m_Contract.IsUsableBy(from, true, true, true, true);
		}

		protected override void SetContractDuration(Mobile from, VendorRentalDuration duration)
		{
			m_Contract.Duration = duration;

			from.SendGump(new VendorRentalContractGump(m_Contract, from));
		}

		protected override void SetPricePerRental(Mobile from)
		{
			from.SendLocalizedMessage(1062365); // Please enter the amount of gold that should be charged for this contract (ESC to cancel):
			from.Prompt = new PricePerRentalPrompt(m_Contract);
		}

		protected override void LandlordRenewOnExpiration(Mobile from)
		{
			m_Contract.LandlordRenew = !m_Contract.LandlordRenew;

			from.SendGump(new VendorRentalContractGump(m_Contract, from));
		}

		protected override void OfferContract(Mobile from)
		{
			if (m_Contract.IsLandlord(from))
			{
				from.SendLocalizedMessage(1062371); // Please target the person you wish to offer this contract to.
				from.Target = new OfferContractTarget(m_Contract);
			}
		}

		private class PricePerRentalPrompt : Prompt
		{
			private readonly VendorRentalContract m_Contract;

			public PricePerRentalPrompt(VendorRentalContract contract)
			{
				m_Contract = contract;
			}

			public override void OnResponse(Mobile from, string text)
			{
				if (!m_Contract.IsUsableBy(from, true, true, true, true))
				{
					return;
				}

				text = text.Trim();

				int price;

				if (!Int32.TryParse(text, out price))
				{
					price = -1;
				}

				if (price < 0)
				{
					from.SendLocalizedMessage(1062485); // Invalid entry.  Rental fee set to 0.
					m_Contract.Price = 0;
				}
				else if (price > 5000000)
				{
					m_Contract.Price = 5000000;
				}
				else
				{
					m_Contract.Price = price;
				}

				from.SendGump(new VendorRentalContractGump(m_Contract, from));
			}

			public override void OnCancel(Mobile from)
			{
				if (m_Contract.IsUsableBy(from, true, true, true, true))
				{
					from.SendGump(new VendorRentalContractGump(m_Contract, from));
				}
			}
		}

		private class OfferContractTarget : Target
		{
			private readonly VendorRentalContract m_Contract;

			public OfferContractTarget(VendorRentalContract contract) : base(-1, false, TargetFlags.None)
			{
				m_Contract = contract;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (!m_Contract.IsUsableBy(from, true, false, true, true))
				{
					return;
				}

				var mob = targeted as Mobile;

				if (mob == null || !mob.Player || !mob.Alive || mob == from)
				{
					from.SendLocalizedMessage(1071984); //That is not a valid target for a rental contract!
				}
				else if (!mob.InRange(m_Contract, 5))
				{
					from.SendLocalizedMessage(501853); // Target is too far away.
				}
				else
				{
					from.SendLocalizedMessage(1062372); // Please wait while that person considers your offer.

					mob.SendLocalizedMessage(1062373, from.Name); // ~1_NAME~ is offering you a vendor rental.   If you choose to accept this offer, you have 30 seconds to do so.
					mob.SendGump(new VendorRentalOfferGump(m_Contract, from));

					m_Contract.Offeree = mob;
				}
			}

			protected override void OnTargetCancel(Mobile from, TargetCancelType cancelType)
			{
				from.SendLocalizedMessage(1062380); // You decide against offering the contract to anyone.
			}
		}
	}

	public class VendorRentalOfferGump : BaseVendorRentalGump
	{
		private readonly VendorRentalContract m_Contract;
		private readonly Mobile m_Landlord;

		public VendorRentalOfferGump(VendorRentalContract contract, Mobile landlord) : base(
			GumpType.Offer, contract.Duration, contract.Price, contract.Price,
			landlord, null, contract.LandlordRenew, false, false)
		{
			m_Contract = contract;
			m_Landlord = landlord;
		}

		protected override bool IsValidResponse(Mobile from)
		{
			return m_Contract.IsUsableBy(m_Landlord, true, false, false, false) && from.CheckAlive() && m_Contract.Offeree == from;
		}

		protected override void AcceptOffer(Mobile from)
		{
			m_Contract.Offeree = null;

			if (!m_Contract.Map.CanFit(m_Contract.Location, 16, false, false))
			{
				m_Landlord.SendLocalizedMessage(1062486); // A vendor cannot exist at that location.  Please try again.
				return;
			}

			var house = BaseHouse.FindHouseAt(m_Contract);
			if (house == null)
			{
				return;
			}

			var price = m_Contract.Price;
			int goldToGive;

			if (price > 0)
			{
				if (Banker.Withdraw(from, price))
				{
					from.SendLocalizedMessage(1060398, price.ToString()); // ~1_AMOUNT~ gold has been withdrawn from your bank box.

					var depositedGold = Banker.DepositUpTo(m_Landlord, price);
					goldToGive = price - depositedGold;

					if (depositedGold > 0)
					{
						m_Landlord.SendLocalizedMessage(1060397, price.ToString()); // ~1_AMOUNT~ gold has been deposited into your bank box.
					}

					if (goldToGive > 0)
					{
						m_Landlord.SendLocalizedMessage(500390); // Your bank box is full.
					}
				}
				else
				{
					from.SendLocalizedMessage(1062378); // You do not have enough gold in your bank account to cover the cost of the contract.
					m_Landlord.SendLocalizedMessage(1062374, from.Name); // ~1_NAME~ has declined your vendor rental offer.

					return;
				}
			}
			else
			{
				goldToGive = 0;
			}

			PlayerVendor vendor = new RentedVendor(from, house, m_Contract.Duration, price, m_Contract.LandlordRenew, goldToGive);
			vendor.MoveToWorld(m_Contract.Location, m_Contract.Map);

			m_Contract.Delete();

			from.SendLocalizedMessage(1062377); // You have accepted the offer and now own a vendor in this house.  Rental contract options and details may be viewed on this vendor via the 'Contract Options' context menu.
			m_Landlord.SendLocalizedMessage(1062376, from.Name); // ~1_NAME~ has accepted your vendor rental offer.  Rental contract details and options may be viewed on this vendor via the 'Contract Options' context menu.
		}

		protected override void Cancel(Mobile from)
		{
			m_Contract.Offeree = null;

			from.SendLocalizedMessage(1062375); // You decline the offer for a vendor space rental.
			m_Landlord.SendLocalizedMessage(1062374, from.Name); // ~1_NAME~ has declined your vendor rental offer.
		}
	}

	public class RenterVendorRentalGump : BaseVendorRentalGump
	{
		private readonly RentedVendor m_Vendor;

		public RenterVendorRentalGump(RentedVendor vendor) : base(
			GumpType.VendorRenter, vendor.RentalDuration, vendor.RentalPrice, vendor.RenewalPrice,
			vendor.Landlord, vendor.Owner, vendor.LandlordRenew, vendor.RenterRenew, vendor.Renew)
		{
			m_Vendor = vendor;
		}

		protected override bool IsValidResponse(Mobile from)
		{
			return m_Vendor.CanInteractWith(from, true);
		}

		protected override void RenterRenewOnExpiration(Mobile from)
		{
			m_Vendor.RenterRenew = !m_Vendor.RenterRenew;

			from.SendGump(new RenterVendorRentalGump(m_Vendor));
		}
	}

	public class LandlordVendorRentalGump : BaseVendorRentalGump
	{
		private readonly RentedVendor m_Vendor;

		public LandlordVendorRentalGump(RentedVendor vendor) : base(
			GumpType.VendorLandlord, vendor.RentalDuration, vendor.RentalPrice, vendor.RenewalPrice,
			vendor.Landlord, vendor.Owner, vendor.LandlordRenew, vendor.RenterRenew, vendor.Renew)
		{
			m_Vendor = vendor;
		}

		protected override bool IsValidResponse(Mobile from)
		{
			return m_Vendor.CanInteractWith(from, false) && m_Vendor.IsLandlord(from);
		}

		protected override void LandlordRenewOnExpiration(Mobile from)
		{
			m_Vendor.LandlordRenew = !m_Vendor.LandlordRenew;

			from.SendGump(new LandlordVendorRentalGump(m_Vendor));
		}

		protected override void SetRenewalPrice(Mobile from)
		{
			from.SendLocalizedMessage(1062500); // Enter contract renewal price:

			from.Prompt = new ContractRenewalPricePrompt(m_Vendor);
		}

		private class ContractRenewalPricePrompt : Prompt
		{
			private readonly RentedVendor m_Vendor;

			public ContractRenewalPricePrompt(RentedVendor vendor)
			{
				m_Vendor = vendor;
			}

			public override void OnResponse(Mobile from, string text)
			{
				if (!m_Vendor.CanInteractWith(from, false) || !m_Vendor.IsLandlord(from))
				{
					return;
				}

				text = text.Trim();

				int price;

				if (!Int32.TryParse(text, out price))
				{
					price = -1;
				}

				if (price < 0)
				{
					from.SendLocalizedMessage(1062485); // Invalid entry.  Rental fee set to 0.
					m_Vendor.RenewalPrice = 0;
				}
				else if (price > 5000000)
				{
					m_Vendor.RenewalPrice = 5000000;
				}
				else
				{
					m_Vendor.RenewalPrice = price;
				}

				m_Vendor.RenterRenew = false;

				from.SendGump(new LandlordVendorRentalGump(m_Vendor));
			}

			public override void OnCancel(Mobile from)
			{
				if (m_Vendor.CanInteractWith(from, false) && m_Vendor.IsLandlord(from))
				{
					from.SendGump(new LandlordVendorRentalGump(m_Vendor));
				}
			}
		}
	}

	public class VendorRentalRefundGump : Gump
	{
		private readonly RentedVendor m_Vendor;
		private readonly Mobile m_Landlord;
		private readonly int m_RefundAmount;

		public VendorRentalRefundGump(RentedVendor vendor, Mobile landlord, int refundAmount) : base(50, 50)
		{
			m_Vendor = vendor;
			m_Landlord = landlord;
			m_RefundAmount = refundAmount;

			AddBackground(0, 0, 420, 320, 0x13BE);

			AddImageTiled(10, 10, 400, 300, 0xA40);
			AddAlphaRegion(10, 10, 400, 300);

			/* The landlord for this vendor is offering you a partial refund of your rental fee
			 * in exchange for immediate termination of your rental contract.<BR><BR>
			 * 
			 * If you accept this offer, the vendor will be immediately dismissed.  You will then
			 * be able to claim the inventory and any funds the vendor may be holding for you via
			 * a context menu on the house sign for this house.
			 */
			AddHtmlLocalized(10, 10, 400, 150, 1062501, 0x7FFF, false, true);

			AddHtmlLocalized(10, 180, 150, 20, 1062508, 0x7FFF, false, false); // Vendor Name:
			AddLabel(160, 180, 0x480, vendor.Name);

			AddHtmlLocalized(10, 200, 150, 20, 1062509, 0x7FFF, false, false); // Shop Name:
			AddLabel(160, 200, 0x480, vendor.ShopName);

			AddHtmlLocalized(10, 220, 150, 20, 1062510, 0x7FFF, false, false); // Refund Amount:
			AddLabel(160, 220, 0x480, refundAmount.ToString());

			AddButton(10, 268, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0);
			AddHtmlLocalized(45, 268, 350, 20, 1062511, 0x7FFF, false, false); // Agree, and <strong>dismiss vendor</strong>

			AddButton(10, 288, 0xFA5, 0xFA7, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(45, 288, 350, 20, 1062512, 0x7FFF, false, false); // No, I want to <strong>keep my vendor</strong>
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			if (!m_Vendor.CanInteractWith(from, true) || !m_Vendor.CanInteractWith(m_Landlord, false) || !m_Vendor.IsLandlord(m_Landlord))
			{
				return;
			}

			if (info.ButtonID == 1)
			{
				if (Banker.Withdraw(m_Landlord, m_RefundAmount))
				{
					m_Landlord.SendLocalizedMessage(1060398, m_RefundAmount.ToString()); // ~1_AMOUNT~ gold has been withdrawn from your bank box.

					var depositedGold = Banker.DepositUpTo(from, m_RefundAmount);

					if (depositedGold > 0)
					{
						from.SendLocalizedMessage(1060397, depositedGold.ToString()); // ~1_AMOUNT~ gold has been deposited into your bank box.
					}

					m_Vendor.HoldGold += m_RefundAmount - depositedGold;

					m_Vendor.Destroy(false);

					from.SendLocalizedMessage(1071990); //Remember to claim your vendor's belongings from the house sign!
				}
				else
				{
					m_Landlord.SendLocalizedMessage(1062507); // You do not have that much money in your bank account.
				}
			}
			else
			{
				m_Landlord.SendLocalizedMessage(1062513); // The renter declined your offer.
			}
		}
	}

	/// House Sign: Reclaim Vendor
	public class ReclaimVendorGump : Gump
	{
		private readonly BaseHouse m_House;
		private readonly List<Mobile> m_Vendors;

		public ReclaimVendorGump(BaseHouse house) : base(50, 50)
		{
			m_House = house;
			m_Vendors = new(house.InternalizedVendors);

			AddBackground(0, 0, 170, 50 + m_Vendors.Count * 20, 0x13BE);

			AddImageTiled(10, 10, 150, 20, 0xA40);
			AddHtmlLocalized(10, 10, 150, 20, 1061827, 0x7FFF, false, false); // <CENTER>Reclaim Vendor</CENTER>

			AddImageTiled(10, 40, 150, m_Vendors.Count * 20, 0xA40);

			for (var i = 0; i < m_Vendors.Count; i++)
			{
				var y = 40 + i * 20;

				AddButton(10, y, 0xFA5, 0xFA7, i + 1, GumpButtonType.Reply, 0);
				AddLabel(45, y, 0x481, m_Vendors[i].Name);
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			if (info.ButtonID == 0 || !m_House.IsActive || !m_House.IsInside(from) || !m_House.IsOwner(from) || !from.CheckAlive())
			{
				return;
			}

			var index = info.ButtonID - 1;

			if (index < 0 || index >= m_Vendors.Count)
			{
				return;
			}

			var mob = m_Vendors[index];

			if (!m_House.InternalizedVendors.Contains(mob))
			{
				return;
			}

			if (mob.Deleted)
			{
				m_House.InternalizedVendors.Remove(mob);
			}
			else
			{
				bool vendor, contract;
				BaseHouse.IsThereVendor(from.Location, from.Map, out vendor, out contract);

				if (vendor)
				{
					from.SendLocalizedMessage(1062677); // You cannot place a vendor or barkeep at this location.
				}
				else if (contract)
				{
					from.SendLocalizedMessage(1062678); // You cannot place a vendor or barkeep on top of a rental contract!
				}
				else
				{
					m_House.InternalizedVendors.Remove(mob);
					mob.MoveToWorld(from.Location, from.Map);
				}
			}
		}
	}

	/// House Sign: Reclaim Vendor Inventory
	public class VendorInventoryGump : Gump
	{
		private readonly BaseHouse m_House;
		private readonly List<VendorInventory> m_Inventories;

		public VendorInventoryGump(BaseHouse house, Mobile from) : base(50, 50)
		{
			m_House = house;
			m_Inventories = new(house.VendorInventories);

			AddBackground(0, 0, 420, 50 + 20 * m_Inventories.Count, 0x13BE);

			AddImageTiled(10, 10, 400, 20, 0xA40);
			AddHtmlLocalized(15, 10, 200, 20, 1062435, 0x7FFF, false, false); // Reclaim Vendor Inventory
			AddHtmlLocalized(330, 10, 50, 20, 1062465, 0x7FFF, false, false); // Expires

			AddImageTiled(10, 40, 400, 20 * m_Inventories.Count, 0xA40);

			for (var i = 0; i < m_Inventories.Count; i++)
			{
				var inventory = m_Inventories[i];

				var y = 40 + 20 * i;

				if (inventory.Owner == from)
				{
					AddButton(10, y, 0xFA5, 0xFA7, i + 1, GumpButtonType.Reply, 0);
				}

				AddLabel(45, y, 0x481, String.Format("{0} ({1})", inventory.ShopName, inventory.VendorName));

				var expire = inventory.ExpireTime - DateTime.UtcNow;
				var hours = (int)expire.TotalHours;

				AddLabel(320, y, 0x481, hours.ToString());
				AddHtmlLocalized(350, y, 50, 20, 1062466, 0x7FFF, false, false); // hour(s)
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 0)
			{
				return;
			}

			var from = sender.Mobile;
			var sign = m_House.Sign;

			if (m_House.Deleted || sign == null || sign.Deleted || !from.CheckAlive())
			{
				return;
			}

			if (from.Map != sign.Map || !from.InRange(sign, 5))
			{
				from.SendLocalizedMessage(1062429); // You must be within five paces of the house sign to use this option.
				return;
			}

			var index = info.ButtonID - 1;
			if (index < 0 || index >= m_Inventories.Count)
			{
				return;
			}

			var inventory = (VendorInventory)m_Inventories[index];

			if (inventory.Owner != from || !m_House.VendorInventories.Contains(inventory))
			{
				return;
			}

			var totalItems = 0;
			var givenToBackpack = 0;
			var givenToBankBox = 0;
			for (var i = inventory.Items.Count - 1; i >= 0; i--)
			{
				var item = inventory.Items[i];

				if (item.Deleted)
				{
					inventory.Items.RemoveAt(i);
					continue;
				}

				totalItems += 1 + item.TotalItems;

				if (from.PlaceInBackpack(item))
				{
					inventory.Items.RemoveAt(i);
					givenToBackpack += 1 + item.TotalItems;
				}
				else if (from.BankBox.TryDropItem(from, item, false))
				{
					inventory.Items.RemoveAt(i);
					givenToBankBox += 1 + item.TotalItems;
				}
			}

			from.SendLocalizedMessage(1062436, totalItems.ToString() + "\t" + inventory.Gold.ToString()); // The vendor you selected had ~1_COUNT~ items in its inventory, and ~2_AMOUNT~ gold in its account.

			var givenGold = Banker.DepositUpTo(from, inventory.Gold);
			inventory.Gold -= givenGold;

			from.SendLocalizedMessage(1060397, givenGold.ToString()); // ~1_AMOUNT~ gold has been deposited into your bank box.
			from.SendLocalizedMessage(1062437, givenToBackpack.ToString() + "\t" + givenToBankBox.ToString()); // ~1_COUNT~ items have been removed from the shop inventory and placed in your backpack.  ~2_BANKCOUNT~ items were removed from the shop inventory and placed in your bank box.

			if (inventory.Gold > 0 || inventory.Items.Count > 0)
			{
				from.SendLocalizedMessage(1062440); // Some of the shop inventory would not fit in your backpack or bank box.  Please free up some room and try again.
			}
			else
			{
				inventory.Delete();
				from.SendLocalizedMessage(1062438); // The shop is now empty of inventory and funds, so it has been deleted.
			}
		}
	}
}

namespace Server.Mobiles
{
	/// Player Vendor
	[AttributeUsage(AttributeTargets.Class)]
	public class PlayerVendorTargetAttribute : Attribute
	{
		public PlayerVendorTargetAttribute()
		{
		}
	}

	public class VendorItem
	{
		private readonly Item m_Item;
		private readonly int m_Price;
		private string m_Description;
		private readonly DateTime m_Created;

		private bool m_Valid;

		public Item Item => m_Item;
		public int Price => m_Price;

		public string FormattedPrice
		{
			get
			{
				if (Core.ML)
				{
					return m_Price.ToString("N0", CultureInfo.GetCultureInfo("en-US"));
				}

				return m_Price.ToString();
			}
		}

		public string Description
		{
			get => m_Description;
			set
			{
				if (value != null)
				{
					m_Description = value;
				}
				else
				{
					m_Description = "";
				}

				if (Valid)
				{
					Item.InvalidateProperties();
				}
			}
		}

		public DateTime Created => m_Created;

		public bool IsForSale => Price >= 0;
		public bool IsForFree => Price == 0;

		public bool Valid => m_Valid;

		public VendorItem(Item item, int price, string description, DateTime created)
		{
			m_Item = item;
			m_Price = price;

			if (description != null)
			{
				m_Description = description;
			}
			else
			{
				m_Description = "";
			}

			m_Created = created;

			m_Valid = true;
		}

		public void Invalidate()
		{
			m_Valid = false;
		}
	}

	public class VendorBackpack : Backpack
	{
		public VendorBackpack()
		{
			Layer = Layer.Backpack;
			Weight = 1.0;
		}

		public override int DefaultMaxWeight => 0;

		public override bool CheckHold(Mobile m, Item item, bool message, bool checkItems, int plusItems, int plusWeight)
		{
			if (!base.CheckHold(m, item, message, checkItems, plusItems, plusWeight))
			{
				return false;
			}

			if (Ethics.Ethic.IsImbued(item, true))
			{
				if (message)
				{
					m.SendMessage("Imbued items may not be sold here.");
				}

				return false;
			}

			if (!BaseHouse.NewVendorSystem && Parent is PlayerVendor)
			{
				var house = ((PlayerVendor)Parent).House;

				if (house != null && house.IsAosRules && !house.CheckAosStorage(1 + item.TotalItems + plusItems))
				{
					if (message)
					{
						m.SendLocalizedMessage(1061839); // This action would exceed the secure storage limit of the house.
					}

					return false;
				}
			}

			return true;
		}

		public override bool IsAccessibleTo(Mobile m)
		{
			return true;
		}

		public override bool CheckItemUse(Mobile from, Item item)
		{
			if (!base.CheckItemUse(from, item))
			{
				return false;
			}

			if (item is Container || item is Engines.BulkOrders.BulkOrderBook)
			{
				return true;
			}

			from.SendLocalizedMessage(500447); // That is not accessible.
			return false;
		}

		public override bool CheckTarget(Mobile from, Target targ, object targeted)
		{
			if (!base.CheckTarget(from, targ, targeted))
			{
				return false;
			}

			if (from.AccessLevel >= AccessLevel.GameMaster)
			{
				return true;
			}

			return targ.GetType().IsDefined(typeof(PlayerVendorTargetAttribute), false);
		}

		public override void GetChildContextMenuEntries(Mobile from, List<ContextMenuEntry> list, Item item)
		{
			base.GetChildContextMenuEntries(from, list, item);

			var pv = RootParent as PlayerVendor;

			if (pv == null || pv.IsOwner(from))
			{
				return;
			}

			var vi = pv.GetVendorItem(item);

			if (vi != null)
			{
				list.Add(new BuyEntry(item));
			}
		}

		private class BuyEntry : ContextMenuEntry
		{
			private readonly Item m_Item;

			public BuyEntry(Item item) : base(6103)
			{
				m_Item = item;
			}

			public override bool NonLocalUse => true;

			public override void OnClick()
			{
				if (m_Item.Deleted)
				{
					return;
				}

				PlayerVendor.TryToBuy(m_Item, Owner.From);
			}
		}

		public override void GetChildNameProperties(ObjectPropertyList list, Item item)
		{
			base.GetChildNameProperties(list, item);

			var pv = RootParent as PlayerVendor;

			if (pv == null)
			{
				return;
			}

			var vi = pv.GetVendorItem(item);

			if (vi == null)
			{
				return;
			}

			if (!vi.IsForSale)
			{
				list.Add(1043307); // Price: Not for sale.
			}
			else if (vi.IsForFree)
			{
				list.Add(1043306); // Price: FREE!
			}
			else
			{
				list.Add(1043304, vi.FormattedPrice); // Price: ~1_COST~
			}
		}

		public override void GetChildProperties(ObjectPropertyList list, Item item)
		{
			base.GetChildProperties(list, item);

			var pv = RootParent as PlayerVendor;

			if (pv == null)
			{
				return;
			}

			var vi = pv.GetVendorItem(item);

			if (vi != null && vi.Description != null && vi.Description.Length > 0)
			{
				list.Add(1043305, vi.Description); // <br>Seller's Description:<br>"~1_DESC~"
			}
		}

		public override void OnSingleClickContained(Mobile from, Item item)
		{
			if (RootParent is PlayerVendor)
			{
				var vendor = (PlayerVendor)RootParent;

				var vi = vendor.GetVendorItem(item);

				if (vi != null)
				{
					if (!vi.IsForSale)
					{
						item.LabelTo(from, 1043307); // Price: Not for sale.
					}
					else if (vi.IsForFree)
					{
						item.LabelTo(from, 1043306); // Price: FREE!
					}
					else
					{
						item.LabelTo(from, 1043304, vi.FormattedPrice); // Price: ~1_COST~
					}

					if (!String.IsNullOrEmpty(vi.Description))
					{
						// The localized message (1043305) is no longer valid - <br>Seller's Description:<br>"~1_DESC~"
						item.LabelTo(from, "Description: {0}", vi.Description);
					}
				}
			}

			base.OnSingleClickContained(from, item);
		}

		public VendorBackpack(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	public class PlayerVendor : Mobile
	{
		private Dictionary<Item, VendorItem> m_SellItems;

		private Mobile m_Owner;
		private BaseHouse m_House;

		private int m_BankAccount;
		private int m_HoldGold;

		private string m_ShopName;

		private Timer m_PayTimer;
		private DateTime m_NextPayTime;

		private PlayerVendorPlaceholder m_Placeholder;

		public PlayerVendor(Mobile owner, BaseHouse house)
		{
			Owner = owner;
			House = house;

			if (BaseHouse.NewVendorSystem)
			{
				m_BankAccount = 0;
				m_HoldGold = 4;
			}
			else
			{
				m_BankAccount = 1000;
				m_HoldGold = 0;
			}

			ShopName = "Shop Not Yet Named";

			m_SellItems = new Dictionary<Item, VendorItem>();

			CantWalk = true;

			if (!Core.AOS)
			{
				NameHue = 0x35;
			}

			InitStats(100, 100, 25);
			InitBody();
			InitOutfit();

			var delay = PayTimer.GetInterval();

			m_PayTimer = new PayTimer(this, delay);
			m_PayTimer.Start();

			m_NextPayTime = DateTime.UtcNow + delay;
		}

		public PlayerVendor(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(2); // version

			writer.Write(BaseHouse.NewVendorSystem);
			writer.Write(m_ShopName);
			writer.WriteDeltaTime(m_NextPayTime);
			writer.Write(House);

			writer.Write(m_Owner);
			writer.Write(m_BankAccount);
			writer.Write(m_HoldGold);

			writer.Write(m_SellItems.Count);
			foreach (var vi in m_SellItems.Values)
			{
				writer.Write(vi.Item);
				writer.Write(vi.Price);
				writer.Write(vi.Description);

				writer.Write(vi.Created);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			var newVendorSystem = false;

			switch (version)
			{
				case 2:
				case 1:
					{
						newVendorSystem = reader.ReadBool();
						m_ShopName = reader.ReadString();
						m_NextPayTime = reader.ReadDeltaTime();
						House = (BaseHouse)reader.ReadItem();

						goto case 0;
					}
				case 0:
					{
						m_Owner = reader.ReadMobile();
						m_BankAccount = reader.ReadInt();
						m_HoldGold = reader.ReadInt();

						var count = reader.ReadInt();

						m_SellItems = new Dictionary<Item, VendorItem>(count);

						for (var i = 0; i < count; i++)
						{
							var item = reader.ReadItem();

							var price = reader.ReadInt();
							if (price > 100000000)
							{
								price = 100000000;
							}

							var description = reader.ReadString();

							var created = version < 1 ? DateTime.UtcNow : reader.ReadDateTime();

							if (item != null)
							{
								SetVendorItem(item, version < 1 && price <= 0 ? -1 : price, description, created);
							}
						}

						break;
					}
			}

			var newVendorSystemActivated = BaseHouse.NewVendorSystem && !newVendorSystem;

			if (version < 1 || newVendorSystemActivated)
			{
				if (version < 1)
				{
					m_ShopName = "Shop Not Yet Named";
					Timer.DelayCall(UpgradeFromVersion0, newVendorSystemActivated);
				}
				else
				{
					Timer.DelayCall(FixDresswear);
				}

				m_NextPayTime = DateTime.UtcNow + PayTimer.GetInterval();

				if (newVendorSystemActivated)
				{
					m_HoldGold += m_BankAccount;
					m_BankAccount = 0;
				}
			}

			if (version < 2 && RawStr == 75 && RawDex == 75 && RawInt == 75)
			{
				InitStats(100, 100, 25);
			}

			var delay = m_NextPayTime - DateTime.UtcNow;

			m_PayTimer = new PayTimer(this, delay > TimeSpan.Zero ? delay : TimeSpan.Zero);
			m_PayTimer.Start();

			Blessed = false;

			if (Core.AOS && NameHue == 0x35)
			{
				NameHue = -1;
			}
		}

		private void UpgradeFromVersion0(bool newVendorSystem)
		{
			var toRemove = new List<Item>();

			foreach (var vi in m_SellItems.Values)
			{
				if (!CanBeVendorItem(vi.Item))
				{
					toRemove.Add(vi.Item);
				}
				else
				{
					vi.Description = Utility.FixHtml(vi.Description);
				}
			}

			foreach (var item in toRemove)
			{
				RemoveVendorItem(item);
			}

			House = BaseHouse.FindHouseAt(this);

			if (newVendorSystem)
			{
				ActivateNewVendorSystem();
			}
		}

		private void ActivateNewVendorSystem()
		{
			FixDresswear();

			if (House != null && !House.IsOwner(Owner))
			{
				Destroy(false);
			}
		}

		public void InitBody()
		{
			Hue = Utility.RandomSkinHue();
			SpeechHue = 0x3B2;

			if (!Core.AOS)
			{
				NameHue = 0x35;
			}

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("female");
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
			}
		}

		public virtual void InitOutfit()
		{
			Item item = new FancyShirt(Utility.RandomNeutralHue()) {
				Layer = Layer.InnerTorso
			};
			AddItem(item);
			AddItem(new LongPants(Utility.RandomNeutralHue()));
			AddItem(new BodySash(Utility.RandomNeutralHue()));
			AddItem(new Boots(Utility.RandomNeutralHue()));
			AddItem(new Cloak(Utility.RandomNeutralHue()));

			Utility.AssignRandomHair(this);

			Container pack = new VendorBackpack {
				Movable = false
			};
			AddItem(pack);
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Owner
		{
			get => m_Owner;
			set => m_Owner = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BankAccount
		{
			get => m_BankAccount;
			set => m_BankAccount = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int HoldGold
		{
			get => m_HoldGold;
			set => m_HoldGold = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public string ShopName
		{
			get => m_ShopName;
			set
			{
				if (value == null)
				{
					m_ShopName = "";
				}
				else
				{
					m_ShopName = value;
				}

				InvalidateProperties();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime NextPayTime => m_NextPayTime;

		public PlayerVendorPlaceholder Placeholder
		{
			get => m_Placeholder;
			set => m_Placeholder = value;
		}

		public BaseHouse House
		{
			get => m_House;
			set
			{
				if (m_House != null)
				{
					m_House.PlayerVendors.Remove(this);
				}

				if (value != null)
				{
					value.PlayerVendors.Add(this);
				}

				m_House = value;
			}
		}

		public int ChargePerDay
		{
			get
			{
				if (BaseHouse.NewVendorSystem)
				{
					return ChargePerRealWorldDay / 12;
				}
				else
				{
					long total = 0;
					foreach (var vi in m_SellItems.Values)
					{
						total += vi.Price;
					}

					total -= 500;

					if (total < 0)
					{
						total = 0;
					}

					return (int)(20 + (total / 500));
				}
			}
		}

		public int ChargePerRealWorldDay
		{
			get
			{
				if (BaseHouse.NewVendorSystem)
				{
					long total = 0;
					foreach (var vi in m_SellItems.Values)
					{
						total += vi.Price;
					}

					return (int)(60 + (total / 500) * 3);
				}
				else
				{
					return ChargePerDay * 12;
				}
			}
		}

		public virtual bool IsOwner(Mobile m)
		{
			if (m.AccessLevel >= AccessLevel.GameMaster)
			{
				return true;
			}

			if (BaseHouse.NewVendorSystem && House != null)
			{
				return House.IsOwner(m);
			}
			else
			{
				return m == Owner;
			}
		}

		protected List<Item> GetItems()
		{
			var list = new List<Item>();

			foreach (var item in Items)
			{
				if (item.Movable && item != Backpack && item.Layer != Layer.Hair && item.Layer != Layer.FacialHair)
				{
					list.Add(item);
				}
			}

			if (Backpack != null)
			{
				list.AddRange(Backpack.Items);
			}

			return list;
		}

		public virtual void Destroy(bool toBackpack)
		{
			Return();

			if (!BaseHouse.NewVendorSystem)
			{
				FixDresswear();
			}

			/* Possible cases regarding item return:
			 * 
			 * 1. No item must be returned
			 *       -> do nothing.
			 * 2. ( toBackpack is false OR the vendor is in the internal map ) AND the vendor is associated with a AOS house
			 *       -> put the items into the moving crate or a vendor inventory,
			 *          depending on whether the vendor owner is also the house owner.
			 * 3. ( toBackpack is true OR the vendor isn't associated with any AOS house ) AND the vendor isn't in the internal map
			 *       -> put the items into a backpack.
			 * 4. The vendor isn't associated with any house AND it's in the internal map
			 *       -> do nothing (we can't do anything).
			 */

			var list = GetItems();

			if (list.Count > 0 || HoldGold > 0) // No case 1
			{
				if ((!toBackpack || Map == Map.Internal) && House != null && House.IsAosRules) // Case 2
				{
					if (House.IsOwner(Owner)) // Move to moving crate
					{
						if (House.MovingCrate == null)
						{
							House.MovingCrate = new MovingCrate(House);
						}

						if (HoldGold > 0)
						{
							Banker.Deposit(House.MovingCrate, HoldGold);
						}

						foreach (var item in list)
						{
							House.MovingCrate.DropItem(item);
						}
					}
					else // Move to vendor inventory
					{
						var inventory = new VendorInventory(House, Owner, Name, ShopName) {
							Gold = HoldGold
						};

						foreach (var item in list)
						{
							inventory.AddItem(item);
						}

						House.VendorInventories.Add(inventory);
					}
				}
				else if ((toBackpack || House == null || !House.IsAosRules) && Map != Map.Internal) // Case 3 - Move to backpack
				{
					Container backpack = new Backpack();

					if (HoldGold > 0)
					{
						Banker.Deposit(backpack, HoldGold);
					}

					foreach (var item in list)
					{
						backpack.DropItem(item);
					}

					backpack.MoveToWorld(Location, Map);
				}
			}

			Delete();
		}

		private void FixDresswear()
		{
			for (var i = 0; i < Items.Count; ++i)
			{
				var item = Items[i];

				if (item is BaseHat)
				{
					item.Layer = Layer.Helm;
				}
				else if (item is BaseMiddleTorso)
				{
					item.Layer = Layer.MiddleTorso;
				}
				else if (item is BaseOuterLegs)
				{
					item.Layer = Layer.OuterLegs;
				}
				else if (item is BaseOuterTorso)
				{
					item.Layer = Layer.OuterTorso;
				}
				else if (item is BasePants)
				{
					item.Layer = Layer.Pants;
				}
				else if (item is BaseShirt)
				{
					item.Layer = Layer.Shirt;
				}
				else if (item is BaseWaist)
				{
					item.Layer = Layer.Waist;
				}
				else if (item is BaseShoes)
				{
					if (item is Sandals)
					{
						item.Hue = 0;
					}

					item.Layer = Layer.Shoes;
				}
			}
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			m_PayTimer.Stop();

			House = null;

			if (Placeholder != null)
			{
				Placeholder.Delete();
			}
		}

		public override bool IsSnoop(Mobile from)
		{
			return false;
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (BaseHouse.NewVendorSystem)
			{
				list.Add(1062449, ShopName); // Shop Name: ~1_NAME~
			}
		}

		public VendorItem GetVendorItem(Item item)
		{
			VendorItem v = null;
			m_SellItems.TryGetValue(item, out v);
			return v;
		}

		private VendorItem SetVendorItem(Item item, int price, string description)
		{
			return SetVendorItem(item, price, description, DateTime.UtcNow);
		}

		private VendorItem SetVendorItem(Item item, int price, string description, DateTime created)
		{
			RemoveVendorItem(item);

			var vi = new VendorItem(item, price, description, created);
			m_SellItems[item] = vi;

			item.InvalidateProperties();

			return vi;
		}

		private void RemoveVendorItem(Item item)
		{
			var vi = GetVendorItem(item);

			if (vi != null)
			{
				vi.Invalidate();
				m_SellItems.Remove(item);

				foreach (var subItem in item.Items)
				{
					RemoveVendorItem(subItem);
				}

				item.InvalidateProperties();
			}
		}

		private bool CanBeVendorItem(Item item)
		{
			var parent = item.Parent as Item;

			if (parent == Backpack)
			{
				return true;
			}

			if (parent is Container)
			{
				var parentVI = GetVendorItem(parent);

				if (parentVI != null)
				{
					return !parentVI.IsForSale;
				}
			}

			return false;
		}

		public override void OnSubItemAdded(Item item)
		{
			base.OnSubItemAdded(item);

			if (GetVendorItem(item) == null && CanBeVendorItem(item))
			{
				// TODO: default price should be dependent to the type of object
				SetVendorItem(item, 999, "");
			}
		}

		public override void OnSubItemRemoved(Item item)
		{
			base.OnSubItemRemoved(item);

			if (item.GetBounce() == null)
			{
				RemoveVendorItem(item);
			}
		}

		public override void OnSubItemBounceCleared(Item item)
		{
			base.OnSubItemBounceCleared(item);

			if (!CanBeVendorItem(item))
			{
				RemoveVendorItem(item);
			}
		}

		public override void OnItemRemoved(Item item)
		{
			base.OnItemRemoved(item);

			if (item == Backpack)
			{
				foreach (var subItem in item.Items)
				{
					RemoveVendorItem(subItem);
				}
			}
		}

		public override bool OnDragDrop(Mobile from, Item item)
		{
			if (!IsOwner(from))
			{
				SayTo(from, 503209); // I can only take item from the shop owner.
				return false;
			}

			if (item is Gold)
			{
				if (BaseHouse.NewVendorSystem)
				{
					if (HoldGold < 1000000)
					{
						SayTo(from, 503210); // I'll take that to fund my services.

						HoldGold += item.Amount;
						item.Delete();

						return true;
					}
					else
					{
						from.SendLocalizedMessage(1062493); // Your vendor has sufficient funds for operation and cannot accept this gold.

						return false;
					}
				}
				else
				{
					if (BankAccount < 1000000)
					{
						SayTo(from, 503210); // I'll take that to fund my services.

						BankAccount += item.Amount;
						item.Delete();

						return true;
					}
					else
					{
						from.SendLocalizedMessage(1062493); // Your vendor has sufficient funds for operation and cannot accept this gold.

						return false;
					}
				}
			}
			else
			{
				var newItem = (GetVendorItem(item) == null);

				if (Backpack != null && Backpack.TryDropItem(from, item, false))
				{
					if (newItem)
					{
						OnItemGiven(from, item);
					}

					return true;
				}
				else
				{
					SayTo(from, 503211); // I can't carry any more.
					return false;
				}
			}
		}

		public override bool CheckNonlocalDrop(Mobile from, Item item, Item target)
		{
			if (IsOwner(from))
			{
				if (GetVendorItem(item) == null)
				{
					// We must wait until the item is added
					Timer.DelayCall(TimeSpan.Zero, NonLocalDropCallback, new object[] { from, item });
				}

				return true;
			}
			else
			{
				SayTo(from, 503209); // I can only take item from the shop owner.
				return false;
			}
		}

		private void NonLocalDropCallback(object state)
		{
			var aState = (object[])state;

			var from = (Mobile)aState[0];
			var item = (Item)aState[1];

			OnItemGiven(from, item);
		}

		private void OnItemGiven(Mobile from, Item item)
		{
			var vi = GetVendorItem(item);

			if (vi != null)
			{
				string name;
				if (!String.IsNullOrEmpty(item.Name))
				{
					name = item.Name;
				}
				else
				{
					name = "#" + item.LabelNumber.ToString();
				}

				from.SendLocalizedMessage(1043303, name); // Type in a price and description for ~1_ITEM~ (ESC=not for sale)
				from.Prompt = new VendorPricePrompt(this, vi);
			}
		}

		public override bool AllowEquipFrom(Mobile from)
		{
			if (BaseHouse.NewVendorSystem && IsOwner(from))
			{
				return true;
			}

			return base.AllowEquipFrom(from);
		}

		public override bool CheckNonlocalLift(Mobile from, Item item)
		{
			if (item.IsChildOf(Backpack))
			{
				if (IsOwner(from))
				{
					return true;
				}
				else
				{
					SayTo(from, 503223); // If you'd like to purchase an item, just ask.
					return false;
				}
			}
			else if (BaseHouse.NewVendorSystem && IsOwner(from))
			{
				return true;
			}

			return base.CheckNonlocalLift(from, item);
		}

		public bool CanInteractWith(Mobile from, bool ownerOnly)
		{
			if (!from.CanSee(this) || !Utility.InUpdateRange(from, this) || !from.CheckAlive())
			{
				return false;
			}

			if (ownerOnly)
			{
				return IsOwner(from);
			}

			if (House != null && House.IsBanned(from) && !IsOwner(from))
			{
				from.SendLocalizedMessage(1062674); // You can't shop from this home as you have been banned from this establishment.
				return false;
			}

			return true;
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsOwner(from))
			{
				SendOwnerGump(from);
			}
			else if (CanInteractWith(from, false))
			{
				OpenBackpack(from);
			}
		}

		public override void DisplayPaperdollTo(Mobile m)
		{
			if (BaseHouse.NewVendorSystem)
			{
				base.DisplayPaperdollTo(m);
			}
			else if (CanInteractWith(m, false))
			{
				OpenBackpack(m);
			}
		}

		public void SendOwnerGump(Mobile to)
		{
			if (BaseHouse.NewVendorSystem)
			{
				to.CloseGump(typeof(NewPlayerVendorOwnerGump));
				to.CloseGump(typeof(NewPlayerVendorCustomizeGump));

				to.SendGump(new NewPlayerVendorOwnerGump(this));
			}
			else
			{
				to.CloseGump(typeof(PlayerVendorOwnerGump));
				to.CloseGump(typeof(PlayerVendorCustomizeGump));

				to.SendGump(new PlayerVendorOwnerGump(this));
			}
		}

		public void OpenBackpack(Mobile from)
		{
			if (Backpack != null)
			{
				SayTo(from, IsOwner(from) ? 1010642 : 503208); // Take a look at my/your goods.

				Backpack.DisplayTo(from);
			}
		}

		public static void TryToBuy(Item item, Mobile from)
		{
			var vendor = item.RootParent as PlayerVendor;

			if (vendor == null || !vendor.CanInteractWith(from, false))
			{
				return;
			}

			if (vendor.IsOwner(from))
			{
				vendor.SayTo(from, 503212); // You own this shop, just take what you want.
				return;
			}

			var vi = vendor.GetVendorItem(item);

			if (vi == null)
			{
				vendor.SayTo(from, 503216); // You can't buy that.
			}
			else if (!vi.IsForSale)
			{
				vendor.SayTo(from, 503202); // This item is not for sale.
			}
			else if (vi.Created + TimeSpan.FromMinutes(1.0) > DateTime.UtcNow)
			{
				from.SendMessage("You cannot buy this item right now.  Please wait one minute and try again.");
			}
			else
			{
				from.CloseGump(typeof(PlayerVendorBuyGump));
				from.SendGump(new PlayerVendorBuyGump(vendor, vi));
			}
		}

		public void CollectGold(Mobile to)
		{
			if (HoldGold > 0)
			{
				SayTo(to, "How much of the {0} that I'm holding would you like?", HoldGold.ToString());
				to.SendMessage("Enter the amount of gold you wish to withdraw (ESC = CANCEL):");

				to.Prompt = new CollectGoldPrompt(this);
			}
			else
			{
				SayTo(to, 503215); // I am holding no gold for you.
			}
		}

		public int GiveGold(Mobile to, int amount)
		{
			if (amount <= 0)
			{
				return 0;
			}

			if (amount > HoldGold)
			{
				SayTo(to, "I'm sorry, but I'm only holding {0} gold for you.", HoldGold.ToString());
				return 0;
			}

			var amountGiven = Banker.DepositUpTo(to, amount);
			HoldGold -= amountGiven;

			if (amountGiven > 0)
			{
				to.SendLocalizedMessage(1060397, amountGiven.ToString()); // ~1_AMOUNT~ gold has been deposited into your bank box.
			}

			if (amountGiven == 0)
			{
				SayTo(to, 1070755); // Your bank box cannot hold the gold you are requesting.  I will keep the gold until you can take it.
			}
			else if (amount > amountGiven)
			{
				SayTo(to, 1070756); // I can only give you part of the gold now, as your bank box is too full to hold the full amount.
			}
			else if (HoldGold > 0)
			{
				SayTo(to, 1042639); // Your gold has been transferred.
			}
			else
			{
				SayTo(to, 503234); // All the gold I have been carrying for you has been deposited into your bank account.
			}

			return amountGiven;
		}

		public void Dismiss(Mobile from)
		{
			var pack = Backpack;

			if (pack != null && pack.Items.Count > 0)
			{
				SayTo(from, 1038325); // You cannot dismiss me while I am holding your goods.
				return;
			}

			if (HoldGold > 0)
			{
				GiveGold(from, HoldGold);

				if (HoldGold > 0)
				{
					return;
				}
			}

			Destroy(true);
		}

		public void Rename(Mobile from)
		{
			from.SendLocalizedMessage(1062494); // Enter a new name for your vendor (20 characters max):

			from.Prompt = new VendorNamePrompt(this);
		}

		public void RenameShop(Mobile from)
		{
			from.SendLocalizedMessage(1062433); // Enter a new name for your shop (20 chars max):

			from.Prompt = new ShopNamePrompt(this);
		}

		public bool CheckTeleport(Mobile to)
		{
			if (Deleted || !IsOwner(to) || House == null || Map == Map.Internal)
			{
				return false;
			}

			if (House.IsInside(to) || to.Map != House.Map || !House.InRange(to, 5))
			{
				return false;
			}

			if (Placeholder == null)
			{
				Placeholder = new PlayerVendorPlaceholder(this);
				Placeholder.MoveToWorld(Location, Map);

				MoveToWorld(to.Location, to.Map);

				to.SendLocalizedMessage(1062431); // This vendor has been moved out of the house to your current location temporarily.  The vendor will return home automatically after two minutes have passed once you are done managing its inventory or customizing it.
			}
			else
			{
				Placeholder.RestartTimer();

				to.SendLocalizedMessage(1062430); // This vendor is currently temporarily in a location outside its house.  The vendor will return home automatically after two minutes have passed once you are done managing its inventory or customizing it.
			}

			return true;
		}

		public void Return()
		{
			if (Placeholder != null)
			{
				Placeholder.Delete();
			}
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			if (from.Alive && Placeholder != null && IsOwner(from))
			{
				list.Add(new ReturnVendorEntry(this));
			}

			base.GetContextMenuEntries(from, list);
		}

		private class ReturnVendorEntry : ContextMenuEntry
		{
			private readonly PlayerVendor m_Vendor;

			public ReturnVendorEntry(PlayerVendor vendor) : base(6214)
			{
				m_Vendor = vendor;
			}

			public override void OnClick()
			{
				var from = Owner.From;

				if (!m_Vendor.Deleted && m_Vendor.IsOwner(from) && from.CheckAlive())
				{
					m_Vendor.Return();
				}
			}
		}

		public override bool HandlesOnSpeech(Mobile from)
		{
			return (from.Alive && from.GetDistanceToSqrt(this) <= 3);
		}

		public bool WasNamed(string speech)
		{
			return Name != null && Insensitive.StartsWith(speech, Name);
		}

		public override void OnSpeech(SpeechEventArgs e)
		{
			var from = e.Mobile;

			if (e.Handled || !from.Alive || from.GetDistanceToSqrt(this) > 3)
			{
				return;
			}

			if (e.HasKeyword(0x3C) || (e.HasKeyword(0x171) && WasNamed(e.Speech))) // vendor buy, *buy*
			{
				if (IsOwner(from))
				{
					SayTo(from, 503212); // You own this shop, just take what you want.
				}
				else if (House == null || !House.IsBanned(from))
				{
					from.SendLocalizedMessage(503213); // Select the item you wish to buy.
					from.Target = new PVBuyTarget();

					e.Handled = true;
				}
			}
			else if (e.HasKeyword(0x3D) || (e.HasKeyword(0x172) && WasNamed(e.Speech))) // vendor browse, *browse
			{
				if (House != null && House.IsBanned(from) && !IsOwner(from))
				{
					SayTo(from, 1062674); // You can't shop from this home as you have been banned from this establishment.
				}
				else
				{
					if (WasNamed(e.Speech))
					{
						OpenBackpack(from);
					}
					else
					{
						IPooledEnumerable mobiles = e.Mobile.GetMobilesInRange(2);

						foreach (Mobile m in mobiles)
						{
							if (m is PlayerVendor && m.CanSee(e.Mobile) && m.InLOS(e.Mobile))
							{
								((PlayerVendor)m).OpenBackpack(from);
							}
						}

						mobiles.Free();
					}

					e.Handled = true;
				}
			}
			else if (e.HasKeyword(0x3E) || (e.HasKeyword(0x173) && WasNamed(e.Speech))) // vendor collect, *collect
			{
				if (IsOwner(from))
				{
					CollectGold(from);

					e.Handled = true;
				}
			}
			else if (e.HasKeyword(0x3F) || (e.HasKeyword(0x174) && WasNamed(e.Speech))) // vendor status, *status
			{
				if (IsOwner(from))
				{
					SendOwnerGump(from);

					e.Handled = true;
				}
				else
				{
					SayTo(from, 503226); // What do you care? You don't run this shop.	
				}
			}
			else if (e.HasKeyword(0x40) || (e.HasKeyword(0x175) && WasNamed(e.Speech))) // vendor dismiss, *dismiss
			{
				if (IsOwner(from))
				{
					Dismiss(from);

					e.Handled = true;
				}
			}
			else if (e.HasKeyword(0x41) || (e.HasKeyword(0x176) && WasNamed(e.Speech))) // vendor cycle, *cycle
			{
				if (IsOwner(from))
				{
					Direction = GetDirectionTo(from);

					e.Handled = true;
				}
			}
		}

		private class PayTimer : Timer
		{
			public static TimeSpan GetInterval()
			{
				if (BaseHouse.NewVendorSystem)
				{
					return TimeSpan.FromDays(1.0);
				}
				else
				{
					return TimeSpan.FromMinutes(Clock.MinutesPerUODay);
				}
			}

			private readonly PlayerVendor m_Vendor;

			public PayTimer(PlayerVendor vendor, TimeSpan delay) : base(delay, GetInterval())
			{
				m_Vendor = vendor;

				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				m_Vendor.m_NextPayTime = DateTime.UtcNow + Interval;

				int pay;
				int totalGold;
				if (BaseHouse.NewVendorSystem)
				{
					pay = m_Vendor.ChargePerRealWorldDay;
					totalGold = m_Vendor.HoldGold;
				}
				else
				{
					pay = m_Vendor.ChargePerDay;
					totalGold = m_Vendor.BankAccount + m_Vendor.HoldGold;
				}

				if (pay > totalGold)
				{
					m_Vendor.Destroy(!BaseHouse.NewVendorSystem);
				}
				else
				{
					if (!BaseHouse.NewVendorSystem)
					{
						if (m_Vendor.BankAccount >= pay)
						{
							m_Vendor.BankAccount -= pay;
							pay = 0;
						}
						else
						{
							pay -= m_Vendor.BankAccount;
							m_Vendor.BankAccount = 0;
						}
					}

					m_Vendor.HoldGold -= pay;
				}
			}
		}

		[PlayerVendorTarget]
		private class PVBuyTarget : Target
		{
			public PVBuyTarget() : base(3, false, TargetFlags.None)
			{
				AllowNonlocal = true;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (targeted is Item)
				{
					TryToBuy((Item)targeted, from);
				}
			}
		}

		private class VendorPricePrompt : Prompt
		{
			private readonly PlayerVendor m_Vendor;
			private readonly VendorItem m_VI;

			public VendorPricePrompt(PlayerVendor vendor, VendorItem vi)
			{
				m_Vendor = vendor;
				m_VI = vi;
			}

			public override void OnResponse(Mobile from, string text)
			{
				if (!m_VI.Valid || !m_Vendor.CanInteractWith(from, true))
				{
					return;
				}

				string firstWord;

				var sep = text.IndexOfAny(new char[] { ' ', ',' });
				if (sep >= 0)
				{
					firstWord = text.Substring(0, sep);
				}
				else
				{
					firstWord = text;
				}

				int price;
				string description;

				if (Int32.TryParse(firstWord, out price))
				{
					if (sep >= 0)
					{
						description = text.Substring(sep + 1).Trim();
					}
					else
					{
						description = "";
					}
				}
				else
				{
					price = -1;
					description = text.Trim();
				}

				SetInfo(from, price, Utility.FixHtml(description));
			}

			public override void OnCancel(Mobile from)
			{
				if (!m_VI.Valid || !m_Vendor.CanInteractWith(from, true))
				{
					return;
				}

				SetInfo(from, -1, "");
			}

			private void SetInfo(Mobile from, int price, string description)
			{
				var item = m_VI.Item;

				var setPrice = false;

				if (price < 0) // Not for sale
				{
					price = -1;

					if (item is Container)
					{
						if (item is LockableContainer && ((LockableContainer)item).Locked)
						{
							m_Vendor.SayTo(from, 1043298); // Locked items may not be made not-for-sale.
						}
						else if (item.Items.Count > 0)
						{
							m_Vendor.SayTo(from, 1043299); // To be not for sale, all items in a container must be for sale.
						}
						else
						{
							setPrice = true;
						}
					}
					else if (item is BaseBook || item is Engines.BulkOrders.BulkOrderBook)
					{
						setPrice = true;
					}
					else
					{
						m_Vendor.SayTo(from, 1043301); // Only the following may be made not-for-sale: books, containers, keyrings, and items in for-sale containers.
					}
				}
				else
				{
					if (price > 100000000)
					{
						price = 100000000;
						from.SendMessage("You cannot price items above 100,000,000 gold.  The price has been adjusted.");
					}

					setPrice = true;
				}

				if (setPrice)
				{
					m_Vendor.SetVendorItem(item, price, description);
				}
				else
				{
					m_VI.Description = description;
				}
			}
		}

		private class CollectGoldPrompt : Prompt
		{
			private readonly PlayerVendor m_Vendor;

			public CollectGoldPrompt(PlayerVendor vendor)
			{
				m_Vendor = vendor;
			}

			public override void OnResponse(Mobile from, string text)
			{
				if (!m_Vendor.CanInteractWith(from, true))
				{
					return;
				}

				text = text.Trim();

				int amount;

				if (!Int32.TryParse(text, out amount))
				{
					amount = 0;
				}

				GiveGold(from, amount);
			}

			public override void OnCancel(Mobile from)
			{
				if (!m_Vendor.CanInteractWith(from, true))
				{
					return;
				}

				GiveGold(from, 0);
			}

			private void GiveGold(Mobile to, int amount)
			{
				if (amount <= 0)
				{
					m_Vendor.SayTo(to, "Very well. I will hold on to the money for now then.");
				}
				else
				{
					m_Vendor.GiveGold(to, amount);
				}
			}
		}

		private class VendorNamePrompt : Prompt
		{
			private readonly PlayerVendor m_Vendor;

			public VendorNamePrompt(PlayerVendor vendor)
			{
				m_Vendor = vendor;
			}

			public override void OnResponse(Mobile from, string text)
			{
				if (!m_Vendor.CanInteractWith(from, true))
				{
					return;
				}

				var name = text.Trim();

				if (!NameVerification.Validate(name, 1, 20, true, true, true, 0, NameVerification.Empty))
				{
					m_Vendor.SayTo(from, "That name is unacceptable.");
					return;
				}

				m_Vendor.Name = Utility.FixHtml(name);

				from.SendLocalizedMessage(1062496); // Your vendor has been renamed.

				from.SendGump(new NewPlayerVendorOwnerGump(m_Vendor));
			}
		}

		private class ShopNamePrompt : Prompt
		{
			private readonly PlayerVendor m_Vendor;

			public ShopNamePrompt(PlayerVendor vendor)
			{
				m_Vendor = vendor;
			}

			public override void OnResponse(Mobile from, string text)
			{
				if (!m_Vendor.CanInteractWith(from, true))
				{
					return;
				}

				var name = text.Trim();

				if (!NameVerification.Validate(name, 1, 20, true, true, true, 0, NameVerification.Empty))
				{
					m_Vendor.SayTo(from, "That name is unacceptable.");
					return;
				}

				m_Vendor.ShopName = Utility.FixHtml(name);

				from.SendGump(new NewPlayerVendorOwnerGump(m_Vendor));
			}
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

	}

	public class PlayerVendorPlaceholder : Item
	{
		private PlayerVendor m_Vendor;
		private readonly ExpireTimer m_Timer;

		[CommandProperty(AccessLevel.GameMaster)]
		public PlayerVendor Vendor => m_Vendor;

		public PlayerVendorPlaceholder(PlayerVendor vendor) : base(0x1F28)
		{
			Hue = 0x672;
			Movable = false;

			m_Vendor = vendor;

			m_Timer = new ExpireTimer(this);
			m_Timer.Start();
		}

		public PlayerVendorPlaceholder(Serial serial) : base(serial)
		{
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (m_Vendor != null)
			{
				list.Add(1062498, m_Vendor.Name); // reserved for vendor ~1_NAME~
			}
		}

		public void RestartTimer()
		{
			m_Timer.Stop();
			m_Timer.Start();
		}

		private class ExpireTimer : Timer
		{
			private readonly PlayerVendorPlaceholder m_Placeholder;

			public ExpireTimer(PlayerVendorPlaceholder placeholder) : base(TimeSpan.FromMinutes(2.0))
			{
				m_Placeholder = placeholder;

				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Placeholder.Delete();
			}
		}

		public override void OnDelete()
		{
			if (m_Vendor != null && !m_Vendor.Deleted)
			{
				m_Vendor.MoveToWorld(Location, Map);
				m_Vendor.Placeholder = null;
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0);

			writer.Write(m_Vendor);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();

			m_Vendor = (PlayerVendor)reader.ReadMobile();

			Timer.DelayCall(TimeSpan.Zero, Delete);
		}
	}

	/// Rented Vendor
	public class VendorRentalDuration
	{
		public static readonly VendorRentalDuration[] Instances = new VendorRentalDuration[]
			{
				new VendorRentalDuration( TimeSpan.FromDays(  7.0 ), 1062361 ),	// 1 Week
				new VendorRentalDuration( TimeSpan.FromDays( 14.0 ), 1062362 ),	// 2 Weeks
				new VendorRentalDuration( TimeSpan.FromDays( 21.0 ), 1062363 ),	// 3 Weeks
				new VendorRentalDuration( TimeSpan.FromDays( 28.0 ), 1062364 )	// 1 Month
			};

		private readonly TimeSpan m_Duration;
		private readonly int m_Name;

		public TimeSpan Duration => m_Duration;
		public int Name => m_Name;

		public int ID
		{
			get
			{
				for (var i = 0; i < Instances.Length; i++)
				{
					if (Instances[i] == this)
					{
						return i;
					}
				}

				return 0;
			}
		}

		private VendorRentalDuration(TimeSpan duration, int name)
		{
			m_Duration = duration;
			m_Name = name;
		}
	}

	public class RentedVendor : PlayerVendor
	{
		private VendorRentalDuration m_RentalDuration;
		private int m_RentalPrice;
		private bool m_LandlordRenew;
		private bool m_RenterRenew;
		private int m_RenewalPrice;

		private int m_RentalGold;

		private DateTime m_RentalExpireTime;
		private Timer m_RentalExpireTimer;

		public RentedVendor(Mobile owner, BaseHouse house, VendorRentalDuration duration, int rentalPrice, bool landlordRenew, int rentalGold) : base(owner, house)
		{
			m_RentalDuration = duration;
			m_RentalPrice = m_RenewalPrice = rentalPrice;
			m_LandlordRenew = landlordRenew;
			m_RenterRenew = false;

			m_RentalGold = rentalGold;

			m_RentalExpireTime = DateTime.UtcNow + duration.Duration;
			m_RentalExpireTimer = new RentalExpireTimer(this, duration.Duration);
			m_RentalExpireTimer.Start();
		}

		public RentedVendor(Serial serial) : base(serial)
		{
		}

		public VendorRentalDuration RentalDuration => m_RentalDuration;

		[CommandProperty(AccessLevel.GameMaster)]
		public int RentalPrice
		{
			get => m_RentalPrice;
			set => m_RentalPrice = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool LandlordRenew
		{
			get => m_LandlordRenew;
			set => m_LandlordRenew = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool RenterRenew
		{
			get => m_RenterRenew;
			set => m_RenterRenew = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Renew => LandlordRenew && RenterRenew && House != null && House.DecayType != DecayType.Condemned;

		[CommandProperty(AccessLevel.GameMaster)]
		public int RenewalPrice
		{
			get => m_RenewalPrice;
			set => m_RenewalPrice = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int RentalGold
		{
			get => m_RentalGold;
			set => m_RentalGold = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime RentalExpireTime => m_RentalExpireTime;

		public override bool IsOwner(Mobile m)
		{
			return m == Owner || m.AccessLevel >= AccessLevel.GameMaster || (Core.ML && AccountHandler.CheckAccount(m, Owner));
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Landlord
		{
			get
			{
				if (House != null)
				{
					return House.Owner;
				}

				return null;
			}
		}

		public bool IsLandlord(Mobile m)
		{
			return House != null && House.IsOwner(m);
		}

		public void ComputeRentalExpireDelay(out int days, out int hours)
		{
			var delay = RentalExpireTime - DateTime.UtcNow;

			if (delay <= TimeSpan.Zero)
			{
				days = 0;
				hours = 0;
			}
			else
			{
				days = delay.Days;
				hours = delay.Hours;
			}
		}

		public void SendRentalExpireMessage(Mobile to)
		{
			int days, hours;
			ComputeRentalExpireDelay(out days, out hours);

			to.SendLocalizedMessage(1062464, days.ToString() + "\t" + hours.ToString()); // The rental contract on this vendor will expire in ~1_DAY~ day(s) and ~2_HOUR~ hour(s).
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			m_RentalExpireTimer.Stop();
		}

		public override void Destroy(bool toBackpack)
		{
			if (RentalGold > 0 && House != null && House.IsAosRules)
			{
				if (House.MovingCrate == null)
				{
					House.MovingCrate = new MovingCrate(House);
				}

				Banker.Deposit(House.MovingCrate, RentalGold);
				RentalGold = 0;
			}

			base.Destroy(toBackpack);
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			if (from.Alive)
			{
				if (IsOwner(from))
				{
					list.Add(new ContractOptionsEntry(this));
				}
				else if (IsLandlord(from))
				{
					if (RentalGold > 0)
					{
						list.Add(new CollectRentEntry(this));
					}

					list.Add(new TerminateContractEntry(this));
					list.Add(new ContractOptionsEntry(this));
				}
			}

			base.GetContextMenuEntries(from, list);
		}

		private class ContractOptionsEntry : ContextMenuEntry
		{
			private readonly RentedVendor m_Vendor;

			public ContractOptionsEntry(RentedVendor vendor) : base(6209)
			{
				m_Vendor = vendor;
			}

			public override void OnClick()
			{
				var from = Owner.From;

				if (m_Vendor.Deleted || !from.CheckAlive())
				{
					return;
				}

				if (m_Vendor.IsOwner(from))
				{
					from.CloseGump(typeof(RenterVendorRentalGump));
					from.SendGump(new RenterVendorRentalGump(m_Vendor));

					m_Vendor.SendRentalExpireMessage(from);
				}
				else if (m_Vendor.IsLandlord(from))
				{
					from.CloseGump(typeof(LandlordVendorRentalGump));
					from.SendGump(new LandlordVendorRentalGump(m_Vendor));

					m_Vendor.SendRentalExpireMessage(from);
				}
			}
		}

		private class CollectRentEntry : ContextMenuEntry
		{
			private readonly RentedVendor m_Vendor;

			public CollectRentEntry(RentedVendor vendor) : base(6212)
			{
				m_Vendor = vendor;
			}

			public override void OnClick()
			{
				var from = Owner.From;

				if (m_Vendor.Deleted || !from.CheckAlive() || !m_Vendor.IsLandlord(from))
				{
					return;
				}

				if (m_Vendor.RentalGold > 0)
				{
					var depositedGold = Banker.DepositUpTo(from, m_Vendor.RentalGold);
					m_Vendor.RentalGold -= depositedGold;

					if (depositedGold > 0)
					{
						from.SendLocalizedMessage(1060397, depositedGold.ToString()); // ~1_AMOUNT~ gold has been deposited into your bank box.
					}

					if (m_Vendor.RentalGold > 0)
					{
						from.SendLocalizedMessage(500390); // Your bank box is full.
					}
				}
			}
		}

		private class TerminateContractEntry : ContextMenuEntry
		{
			private readonly RentedVendor m_Vendor;

			public TerminateContractEntry(RentedVendor vendor) : base(6218)
			{
				m_Vendor = vendor;
			}

			public override void OnClick()
			{
				var from = Owner.From;

				if (m_Vendor.Deleted || !from.CheckAlive() || !m_Vendor.IsLandlord(from))
				{
					return;
				}

				from.SendLocalizedMessage(1062503); // Enter the amount of gold you wish to offer the renter in exchange for immediate termination of this contract?
				from.Prompt = new RefundOfferPrompt(m_Vendor);
			}
		}

		private class RefundOfferPrompt : Prompt
		{
			private readonly RentedVendor m_Vendor;

			public RefundOfferPrompt(RentedVendor vendor)
			{
				m_Vendor = vendor;
			}

			public override void OnResponse(Mobile from, string text)
			{
				if (!m_Vendor.CanInteractWith(from, false) || !m_Vendor.IsLandlord(from))
				{
					return;
				}

				text = text.Trim();

				int amount;

				if (!Int32.TryParse(text, out amount))
				{
					amount = -1;
				}

				var owner = m_Vendor.Owner;
				if (owner == null)
				{
					return;
				}

				if (amount < 0)
				{
					from.SendLocalizedMessage(1062506); // You did not enter a valid amount.  Offer canceled.
				}
				else if (Banker.GetBalance(from) < amount)
				{
					from.SendLocalizedMessage(1062507); // You do not have that much money in your bank account.
				}
				else if (owner.Map != m_Vendor.Map || !owner.InRange(m_Vendor, 5))
				{
					from.SendLocalizedMessage(1062505); // The renter must be closer to the vendor in order for you to make this offer.
				}
				else
				{
					from.SendLocalizedMessage(1062504); // Please wait while the renter considers your offer.

					owner.CloseGump(typeof(VendorRentalRefundGump));
					owner.SendGump(new VendorRentalRefundGump(m_Vendor, from, amount));
				}
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version

			writer.WriteEncodedInt(m_RentalDuration.ID);

			writer.Write(m_RentalPrice);
			writer.Write(m_LandlordRenew);
			writer.Write(m_RenterRenew);
			writer.Write(m_RenewalPrice);

			writer.Write(m_RentalGold);

			writer.WriteDeltaTime(m_RentalExpireTime);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();

			var durationID = reader.ReadEncodedInt();
			if (durationID < VendorRentalDuration.Instances.Length)
			{
				m_RentalDuration = VendorRentalDuration.Instances[durationID];
			}
			else
			{
				m_RentalDuration = VendorRentalDuration.Instances[0];
			}

			m_RentalPrice = reader.ReadInt();
			m_LandlordRenew = reader.ReadBool();
			m_RenterRenew = reader.ReadBool();
			m_RenewalPrice = reader.ReadInt();

			m_RentalGold = reader.ReadInt();

			m_RentalExpireTime = reader.ReadDeltaTime();

			var delay = m_RentalExpireTime - DateTime.UtcNow;
			m_RentalExpireTimer = new RentalExpireTimer(this, delay > TimeSpan.Zero ? delay : TimeSpan.Zero);
			m_RentalExpireTimer.Start();
		}

		private class RentalExpireTimer : Timer
		{
			private readonly RentedVendor m_Vendor;

			public RentalExpireTimer(RentedVendor vendor, TimeSpan delay) : base(delay, vendor.RentalDuration.Duration)
			{
				m_Vendor = vendor;

				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				var renewalPrice = m_Vendor.RenewalPrice;

				if (m_Vendor.Renew && m_Vendor.HoldGold >= renewalPrice)
				{
					m_Vendor.HoldGold -= renewalPrice;
					m_Vendor.RentalGold += renewalPrice;

					m_Vendor.RentalPrice = renewalPrice;

					m_Vendor.m_RentalExpireTime = DateTime.UtcNow + m_Vendor.RentalDuration.Duration;
				}
				else
				{
					m_Vendor.Destroy(false);
				}
			}
		}
	}

	/// Player Barkeeper
	public class ChangeRumorMessagePrompt : Prompt
	{
		private readonly PlayerBarkeeper m_Barkeeper;
		private readonly int m_RumorIndex;

		public ChangeRumorMessagePrompt(PlayerBarkeeper barkeeper, int rumorIndex)
		{
			m_Barkeeper = barkeeper;
			m_RumorIndex = rumorIndex;
		}

		public override void OnCancel(Mobile from)
		{
			OnResponse(from, "");
		}

		public override void OnResponse(Mobile from, string text)
		{
			if (text.Length > 130)
			{
				text = text.Substring(0, 130);
			}

			m_Barkeeper.EndChangeRumor(from, m_RumorIndex, text);
		}
	}

	public class ChangeRumorKeywordPrompt : Prompt
	{
		private readonly PlayerBarkeeper m_Barkeeper;
		private readonly int m_RumorIndex;

		public ChangeRumorKeywordPrompt(PlayerBarkeeper barkeeper, int rumorIndex)
		{
			m_Barkeeper = barkeeper;
			m_RumorIndex = rumorIndex;
		}

		public override void OnCancel(Mobile from)
		{
			OnResponse(from, "");
		}

		public override void OnResponse(Mobile from, string text)
		{
			if (text.Length > 130)
			{
				text = text.Substring(0, 130);
			}

			m_Barkeeper.EndChangeKeyword(from, m_RumorIndex, text);
		}
	}

	public class ChangeTipMessagePrompt : Prompt
	{
		private readonly PlayerBarkeeper m_Barkeeper;

		public ChangeTipMessagePrompt(PlayerBarkeeper barkeeper)
		{
			m_Barkeeper = barkeeper;
		}

		public override void OnCancel(Mobile from)
		{
			OnResponse(from, "");
		}

		public override void OnResponse(Mobile from, string text)
		{
			if (text.Length > 130)
			{
				text = text.Substring(0, 130);
			}

			m_Barkeeper.EndChangeTip(from, text);
		}
	}

	public class BarkeeperRumor
	{
		private string m_Message;
		private string m_Keyword;

		public string Message { get => m_Message; set => m_Message = value; }
		public string Keyword { get => m_Keyword; set => m_Keyword = value; }

		public BarkeeperRumor(string message, string keyword)
		{
			m_Message = message;
			m_Keyword = keyword;
		}

		public static BarkeeperRumor Deserialize(GenericReader reader)
		{
			if (!reader.ReadBool())
			{
				return null;
			}

			return new BarkeeperRumor(reader.ReadString(), reader.ReadString());
		}

		public static void Serialize(GenericWriter writer, BarkeeperRumor rumor)
		{
			if (rumor == null)
			{
				writer.Write(false);
			}
			else
			{
				writer.Write(true);
				writer.Write(rumor.m_Message);
				writer.Write(rumor.m_Keyword);
			}
		}
	}

	public class ManageBarkeeperEntry : ContextMenuEntry
	{
		private readonly Mobile m_From;
		private readonly PlayerBarkeeper m_Barkeeper;

		public ManageBarkeeperEntry(Mobile from, PlayerBarkeeper barkeeper) : base(6151, 12)
		{
			m_From = from;
			m_Barkeeper = barkeeper;
		}

		public override void OnClick()
		{
			m_Barkeeper.BeginManagement(m_From);
		}
	}

	public class PlayerBarkeeper : BaseVendor
	{
		private Mobile m_Owner;
		private BaseHouse m_House;
		private string m_TipMessage;

		private BarkeeperRumor[] m_Rumors;

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Owner
		{
			get => m_Owner;
			set => m_Owner = value;
		}

		public BaseHouse House
		{
			get => m_House;
			set
			{
				if (m_House != null)
				{
					m_House.PlayerBarkeepers.Remove(this);
				}

				if (value != null)
				{
					value.PlayerBarkeepers.Add(this);
				}

				m_House = value;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public string TipMessage
		{
			get => m_TipMessage;
			set => m_TipMessage = value;
		}

		public override bool IsActiveBuyer => false;
		public override bool IsActiveSeller => (m_SBInfos.Count > 0);

		public override bool DisallowAllMoves => true;
		public override bool NoHouseRestrictions => true;

		public BarkeeperRumor[] Rumors => m_Rumors;

		public override VendorShoeType ShoeType => Utility.RandomBool() ? VendorShoeType.ThighBoots : VendorShoeType.Boots;

		public override bool GetGender()
		{
			return false; // always starts as male
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem(new HalfApron(Utility.RandomBrightHue()));

			var pack = Backpack;

			if (pack != null)
			{
				pack.Delete();
			}
		}

		public override void InitBody()
		{
			base.InitBody();

			if (BodyValue == 0x340 || BodyValue == 0x402)
			{
				Hue = 0;
			}
			else
			{
				Hue = 0x83F4; // hue is not random
			}

			var pack = Backpack;

			if (pack != null)
			{
				pack.Delete();
			}
		}

		public PlayerBarkeeper(Mobile owner, BaseHouse house) : base("the barkeeper")
		{
			m_Owner = owner;
			House = house;
			m_Rumors = new BarkeeperRumor[3];

			LoadSBInfo();
		}

		public override bool HandlesOnSpeech(Mobile from)
		{
			if (InRange(from, 3))
			{
				return true;
			}

			return base.HandlesOnSpeech(from);
		}

		private Timer m_NewsTimer;

		private void ShoutNews_Callback(object state)
		{
			var states = (object[])state;
			var tce = (TownCrierEntry)states[0];
			var index = (int)states[1];

			if (index < 0 || index >= tce.Lines.Length)
			{
				if (m_NewsTimer != null)
				{
					m_NewsTimer.Stop();
				}

				m_NewsTimer = null;
			}
			else
			{
				PublicOverheadMessage(MessageType.Regular, 0x3B2, false, tce.Lines[index]);
				states[1] = index + 1;
			}
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			House = null;
		}

		public override bool OnBeforeDeath()
		{
			if (!base.OnBeforeDeath())
			{
				return false;
			}

			var shoes = FindItemOnLayer(Layer.Shoes);

			if (shoes is Sandals)
			{
				shoes.Hue = 0;
			}

			return true;
		}

		public override void OnSpeech(SpeechEventArgs e)
		{
			base.OnSpeech(e);

			if (!e.Handled && InRange(e.Mobile, 3))
			{
				if (m_NewsTimer == null && e.HasKeyword(0x30)) // *news*
				{
					var tce = GlobalTownCrierEntryList.Instance.GetRandomEntry();

					if (tce == null)
					{
						PublicOverheadMessage(MessageType.Regular, 0x3B2, 1005643); // I have no news at this time.
					}
					else
					{
						m_NewsTimer = Timer.DelayCall(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(3.0), ShoutNews_Callback, new object[] { tce, 0 });

						PublicOverheadMessage(MessageType.Regular, 0x3B2, 502978); // Some of the latest news!
					}
				}

				for (var i = 0; i < m_Rumors.Length; ++i)
				{
					var rumor = m_Rumors[i];

					if (rumor == null)
					{
						continue;
					}

					var keyword = rumor.Keyword;

					if (keyword == null || (keyword = keyword.Trim()).Length == 0)
					{
						continue;
					}

					if (Insensitive.Equals(keyword, e.Speech))
					{
						var message = rumor.Message;

						if (message == null || (message = message.Trim()).Length == 0)
						{
							continue;
						}

						PublicOverheadMessage(MessageType.Regular, 0x3B2, false, message);
					}
				}
			}
		}

		public override bool CheckGold(Mobile from, Item dropped)
		{
			if (dropped is Gold)
			{
				var g = (Gold)dropped;

				if (g.Amount > 50)
				{
					PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, "I cannot accept so large a tip!", from.NetState);
				}
				else
				{
					var tip = m_TipMessage;

					if (tip == null || (tip = tip.Trim()).Length == 0)
					{
						PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, "It would not be fair of me to take your money and not offer you information in return.", from.NetState);
					}
					else
					{
						Direction = GetDirectionTo(from);
						PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, tip, from.NetState);

						g.Delete();
						return true;
					}
				}
			}

			return false;
		}

		public bool IsOwner(Mobile from)
		{
			if (from == null || from.Deleted || Deleted)
			{
				return false;
			}

			if (from.AccessLevel > AccessLevel.GameMaster)
			{
				return true;
			}

			return (m_Owner == from);
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			if (IsOwner(from) && from.InLOS(this))
			{
				list.Add(new ManageBarkeeperEntry(from, this));
			}
		}

		public void BeginManagement(Mobile from)
		{
			if (!IsOwner(from))
			{
				return;
			}

			from.SendGump(new BarkeeperGump(from, this));
		}

		public void Dismiss()
		{
			Delete();
		}

		public void BeginChangeRumor(Mobile from, int index)
		{
			if (index < 0 || index >= m_Rumors.Length)
			{
				return;
			}

			from.Prompt = new ChangeRumorMessagePrompt(this, index);
			PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, "Say what news you would like me to tell our guests.", from.NetState);
		}

		public void EndChangeRumor(Mobile from, int index, string text)
		{
			if (index < 0 || index >= m_Rumors.Length)
			{
				return;
			}

			if (m_Rumors[index] == null)
			{
				m_Rumors[index] = new BarkeeperRumor(text, null);
			}
			else
			{
				m_Rumors[index].Message = text;
			}

			from.Prompt = new ChangeRumorKeywordPrompt(this, index);
			PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, "What keyword should a guest say to me to get this news?", from.NetState);
		}

		public void EndChangeKeyword(Mobile from, int index, string text)
		{
			if (index < 0 || index >= m_Rumors.Length)
			{
				return;
			}

			if (m_Rumors[index] == null)
			{
				m_Rumors[index] = new BarkeeperRumor(null, text);
			}
			else
			{
				m_Rumors[index].Keyword = text;
			}

			PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, "I'll pass on the message.", from.NetState);
		}

		public void RemoveRumor(Mobile from, int index)
		{
			if (index < 0 || index >= m_Rumors.Length)
			{
				return;
			}

			m_Rumors[index] = null;
		}

		public void BeginChangeTip(Mobile from)
		{
			from.Prompt = new ChangeTipMessagePrompt(this);
			PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, "Say what you want me to tell guests when they give me a good tip.", from.NetState);
		}

		public void EndChangeTip(Mobile from, string text)
		{
			m_TipMessage = text;
			PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, "I'll say that to anyone who gives me a good tip.", from.NetState);
		}

		public void RemoveTip(Mobile from)
		{
			m_TipMessage = null;
		}

		public void BeginChangeTitle(Mobile from)
		{
			from.SendGump(new BarkeeperTitleGump(from, this));
		}

		public void EndChangeTitle(Mobile from, string title, bool vendor)
		{
			Title = title;

			LoadSBInfo();
		}

		public void CancelChangeTitle(Mobile from)
		{
			from.SendGump(new BarkeeperGump(from, this));
		}

		public void BeginChangeAppearance(Mobile from)
		{
			from.CloseGump(typeof(PlayerVendorCustomizeGump));
			from.SendGump(new PlayerVendorCustomizeGump(this, from));
		}

		public void ChangeGender(Mobile from)
		{
			Female = !Female;

			if (Female)
			{
				Body = 401;
				Name = NameList.RandomName("female");

				FacialHairItemID = 0;
			}
			else
			{
				Body = 400;
				Name = NameList.RandomName("male");
			}
		}

		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		public override void InitSBInfo()
		{
			if (Title == "the waiter" || Title == "the barkeeper" || Title == "the baker" || Title == "the innkeeper" || Title == "the chef")
			{
				if (m_SBInfos.Count == 0)
				{
					m_SBInfos.Add(new SBPlayerBarkeeper());
				}
			}
			else
			{
				m_SBInfos.Clear();
			}
		}

		public PlayerBarkeeper(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version;

			writer.Write(m_House);

			writer.Write(m_Owner);

			writer.WriteEncodedInt(m_Rumors.Length);

			for (var i = 0; i < m_Rumors.Length; ++i)
			{
				BarkeeperRumor.Serialize(writer, m_Rumors[i]);
			}

			writer.Write(m_TipMessage);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						House = (BaseHouse)reader.ReadItem();

						goto case 0;
					}
				case 0:
					{
						m_Owner = reader.ReadMobile();

						m_Rumors = new BarkeeperRumor[reader.ReadEncodedInt()];

						for (var i = 0; i < m_Rumors.Length; ++i)
						{
							m_Rumors[i] = BarkeeperRumor.Deserialize(reader);
						}

						m_TipMessage = reader.ReadString();

						break;
					}
			}

			if (version < 1)
			{
				Timer.DelayCall(TimeSpan.Zero, UpgradeFromVersion0);
			}
		}

		private void UpgradeFromVersion0()
		{
			House = BaseHouse.FindHouseAt(this);
		}
	}

	public class BarkeeperTitleGump : Gump
	{
		private readonly Mobile m_From;
		private readonly PlayerBarkeeper m_Barkeeper;

		private class Entry
		{
			public string m_Description;
			public string m_Title;
			public bool m_Vendor;

			public Entry(string desc) : this(desc, String.Format("the {0}", desc.ToLower()), false)
			{
			}

			public Entry(string desc, bool vendor) : this(desc, String.Format("the {0}", desc.ToLower()), vendor)
			{
			}

			public Entry(string desc, string title, bool vendor)
			{
				m_Description = desc;
				m_Title = title;
				m_Vendor = vendor;
			}
		}

		private static readonly Entry[] m_Entries = new Entry[]
			{
				new Entry( "Alchemist" ),
				new Entry( "Animal Tamer" ),
				new Entry( "Apothecary" ),
				new Entry( "Artist" ),
				new Entry( "Baker", true ),
				new Entry( "Bard" ),
				new Entry( "Barkeep", "the barkeeper", true ),
				new Entry( "Beggar" ),
				new Entry( "Blacksmith" ),
				new Entry( "Bounty Hunter" ),
				new Entry( "Brigand" ),
				new Entry( "Butler" ),
				new Entry( "Carpenter" ),
				new Entry( "Chef", true ),
				new Entry( "Commander" ),
				new Entry( "Curator" ),
				new Entry( "Drunkard" ),
				new Entry( "Farmer" ),
				new Entry( "Fisherman" ),
				new Entry( "Gambler" ),
				new Entry( "Gypsy" ),
				new Entry( "Herald" ),
				new Entry( "Herbalist" ),
				new Entry( "Hermit" ),
				new Entry( "Innkeeper", true ),
				new Entry( "Jailor" ),
				new Entry( "Jester" ),
				new Entry( "Librarian" ),
				new Entry( "Mage" ),
				new Entry( "Mercenary" ),
				new Entry( "Merchant" ),
				new Entry( "Messenger" ),
				new Entry( "Miner" ),
				new Entry( "Monk" ),
				new Entry( "Noble" ),
				new Entry( "Paladin" ),
				new Entry( "Peasant" ),
				new Entry( "Pirate" ),
				new Entry( "Prisoner" ),
				new Entry( "Prophet" ),
				new Entry( "Ranger" ),
				new Entry( "Sage" ),
				new Entry( "Sailor" ),
				new Entry( "Scholar" ),
				new Entry( "Scribe" ),
				new Entry( "Sentry" ),
				new Entry( "Servant" ),
				new Entry( "Shepherd" ),
				new Entry( "Soothsayer" ),
				new Entry( "Stoic" ),
				new Entry( "Storyteller" ),
				new Entry( "Tailor" ),
				new Entry( "Thief" ),
				new Entry( "Tinker" ),
				new Entry( "Town Crier" ),
				new Entry( "Treasure Hunter" ),
				new Entry( "Waiter", true ),
				new Entry( "Warrior" ),
				new Entry( "Watchman" ),
				new Entry( "No Title", null, false )
			};

		private void RenderBackground()
		{
			AddPage(0);

			AddBackground(30, 40, 585, 410, 5054);

			AddImage(30, 40, 9251);
			AddImage(180, 40, 9251);
			AddImage(30, 40, 9253);
			AddImage(30, 130, 9253);
			AddImage(598, 40, 9255);
			AddImage(598, 130, 9255);
			AddImage(30, 433, 9257);
			AddImage(180, 433, 9257);
			AddImage(30, 40, 9250);
			AddImage(598, 40, 9252);
			AddImage(598, 433, 9258);
			AddImage(30, 433, 9256);

			AddItem(30, 40, 6816);
			AddItem(30, 125, 6817);
			AddItem(30, 233, 6817);
			AddItem(30, 341, 6817);
			AddItem(580, 40, 6814);
			AddItem(588, 125, 6815);
			AddItem(588, 233, 6815);
			AddItem(588, 341, 6815);

			AddImage(560, 20, 1417);
			AddItem(580, 44, 4033);

			AddBackground(183, 25, 280, 30, 5054);

			AddImage(180, 25, 10460);
			AddImage(434, 25, 10460);

			AddHtml(223, 32, 200, 40, "BARKEEP CUSTOMIZATION MENU", false, false);
			AddBackground(243, 433, 150, 30, 5054);

			AddImage(240, 433, 10460);
			AddImage(375, 433, 10460);

			AddImage(80, 398, 2151);
			AddItem(72, 406, 2543);

			AddHtml(110, 412, 180, 25, "sells food and drink", false, false);
		}

		private void RenderPage(Entry[] entries, int page)
		{
			AddPage(1 + page);

			AddHtml(430, 70, 180, 25, String.Format("Page {0} of {1}", page + 1, (entries.Length + 19) / 20), false, false);

			for (int count = 0, i = (page * 20); count < 20 && i < entries.Length; ++count, ++i)
			{
				var entry = entries[i];

				AddButton(80 + ((count / 10) * 260), 100 + ((count % 10) * 30), 4005, 4007, 2 + i, GumpButtonType.Reply, 0);
				AddHtml(120 + ((count / 10) * 260), 100 + ((count % 10) * 30), entry.m_Vendor ? 148 : 180, 25, entry.m_Description, true, false);

				if (entry.m_Vendor)
				{
					AddImage(270 + ((count / 10) * 260), 98 + ((count % 10) * 30), 2151);
					AddItem(262 + ((count / 10) * 260), 106 + ((count % 10) * 30), 2543);
				}
			}

			AddButton(340, 400, 4005, 4007, 0, GumpButtonType.Page, 1 + ((page + 1) % ((entries.Length + 19) / 20)));
			AddHtml(380, 400, 180, 25, "More Job Titles", false, false);

			AddButton(338, 437, 4014, 4016, 1, GumpButtonType.Reply, 0);
			AddHtml(290, 440, 35, 40, "Back", false, false);
		}

		public BarkeeperTitleGump(Mobile from, PlayerBarkeeper barkeeper) : base(0, 0)
		{
			m_From = from;
			m_Barkeeper = barkeeper;

			from.CloseGump(typeof(BarkeeperGump));
			from.CloseGump(typeof(BarkeeperTitleGump));

			var entries = m_Entries;

			RenderBackground();

			var pageCount = (entries.Length + 19) / 20;

			for (var i = 0; i < pageCount; ++i)
			{
				RenderPage(entries, i);
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var buttonID = info.ButtonID;

			if (buttonID > 0)
			{
				--buttonID;

				if (buttonID > 0)
				{
					--buttonID;

					if (buttonID >= 0 && buttonID < m_Entries.Length)
					{
						m_Barkeeper.EndChangeTitle(m_From, m_Entries[buttonID].m_Title, m_Entries[buttonID].m_Vendor);
					}
				}
				else
				{
					m_Barkeeper.CancelChangeTitle(m_From);
				}
			}
		}
	}

	public class BarkeeperGump : Gump
	{
		private readonly Mobile m_From;
		private readonly PlayerBarkeeper m_Barkeeper;

		public void RenderBackground()
		{
			AddPage(0);

			AddBackground(30, 40, 585, 410, 5054);

			AddImage(30, 40, 9251);
			AddImage(180, 40, 9251);
			AddImage(30, 40, 9253);
			AddImage(30, 130, 9253);
			AddImage(598, 40, 9255);
			AddImage(598, 130, 9255);
			AddImage(30, 433, 9257);
			AddImage(180, 433, 9257);
			AddImage(30, 40, 9250);
			AddImage(598, 40, 9252);
			AddImage(598, 433, 9258);
			AddImage(30, 433, 9256);

			AddItem(30, 40, 6816);
			AddItem(30, 125, 6817);
			AddItem(30, 233, 6817);
			AddItem(30, 341, 6817);
			AddItem(580, 40, 6814);
			AddItem(588, 125, 6815);
			AddItem(588, 233, 6815);
			AddItem(588, 341, 6815);

			AddBackground(183, 25, 280, 30, 5054);

			AddImage(180, 25, 10460);
			AddImage(434, 25, 10460);
			AddImage(560, 20, 1417);

			AddHtml(223, 32, 200, 40, "BARKEEP CUSTOMIZATION MENU", false, false);
			AddBackground(243, 433, 150, 30, 5054);

			AddImage(240, 433, 10460);
			AddImage(375, 433, 10460);
		}

		public void RenderCategories()
		{
			AddPage(1);

			AddButton(130, 120, 4005, 4007, 0, GumpButtonType.Page, 2);
			AddHtml(170, 120, 200, 40, "Message Control", false, false);

			AddButton(130, 200, 4005, 4007, 0, GumpButtonType.Page, 8);
			AddHtml(170, 200, 200, 40, "Customize your barkeep", false, false);

			AddButton(130, 280, 4005, 4007, 0, GumpButtonType.Page, 3);
			AddHtml(170, 280, 200, 40, "Dismiss your barkeep", false, false);

			AddButton(338, 437, 4014, 4016, 0, GumpButtonType.Reply, 0);
			AddHtml(290, 440, 35, 40, "Back", false, false);

			AddItem(574, 43, 5360);
		}

		public void RenderMessageManagement()
		{
			AddPage(2);

			AddButton(130, 120, 4005, 4007, 0, GumpButtonType.Page, 4);
			AddHtml(170, 120, 380, 20, "Add or change a message and keyword", false, false);

			AddButton(130, 200, 4005, 4007, 0, GumpButtonType.Page, 5);
			AddHtml(170, 200, 380, 20, "Remove a message and keyword from your barkeep", false, false);

			AddButton(130, 280, 4005, 4007, 0, GumpButtonType.Page, 6);
			AddHtml(170, 280, 380, 20, "Add or change your barkeeper's tip message", false, false);

			AddButton(130, 360, 4005, 4007, 0, GumpButtonType.Page, 7);
			AddHtml(170, 360, 380, 20, "Delete your barkeepers tip message", false, false);

			AddButton(338, 437, 4014, 4016, 0, GumpButtonType.Page, 1);
			AddHtml(290, 440, 35, 40, "Back", false, false);

			AddItem(580, 46, 4030);
		}

		public void RenderDismissConfirmation()
		{
			AddPage(3);

			AddHtml(170, 160, 380, 20, "Are you sure you want to dismiss your barkeeper?", false, false);

			AddButton(205, 280, 4005, 4007, GetButtonID(0, 0), GumpButtonType.Reply, 0);
			AddHtml(240, 280, 100, 20, @"Yes", false, false);

			AddButton(395, 280, 4005, 4007, 0, GumpButtonType.Reply, 0);
			AddHtml(430, 280, 100, 20, "No", false, false);

			AddButton(338, 437, 4014, 4016, 0, GumpButtonType.Page, 1);
			AddHtml(290, 440, 35, 40, "Back", false, false);

			AddItem(574, 43, 5360);
			AddItem(584, 34, 6579);
		}

		public void RenderMessageManagement_Message_AddOrChange()
		{
			AddPage(4);

			AddHtml(250, 60, 500, 25, "Add or change a message", false, false);

			var rumors = m_Barkeeper.Rumors;

			for (var i = 0; i < rumors.Length; ++i)
			{
				var rumor = rumors[i];

				AddHtml(100, 70 + (i * 120), 50, 20, "Message", false, false);
				AddHtml(100, 90 + (i * 120), 450, 40, rumor == null ? "No current message" : rumor.Message, true, false);
				AddHtml(100, 130 + (i * 120), 50, 20, "Keyword", false, false);
				AddHtml(100, 150 + (i * 120), 450, 40, rumor == null ? "None" : rumor.Keyword, true, false);

				AddButton(60, 90 + (i * 120), 4005, 4007, GetButtonID(1, i), GumpButtonType.Reply, 0);
			}

			AddButton(338, 437, 4014, 4016, 0, GumpButtonType.Page, 2);
			AddHtml(290, 440, 35, 40, "Back", false, false);

			AddItem(580, 46, 4030);
		}

		public void RenderMessageManagement_Message_Remove()
		{
			AddPage(5);

			AddHtml(190, 60, 500, 25, "Choose the message you would like to remove", false, false);

			var rumors = m_Barkeeper.Rumors;

			for (var i = 0; i < rumors.Length; ++i)
			{
				var rumor = rumors[i];

				AddHtml(100, 70 + (i * 120), 50, 20, "Message", false, false);
				AddHtml(100, 90 + (i * 120), 450, 40, rumor == null ? "No current message" : rumor.Message, true, false);
				AddHtml(100, 130 + (i * 120), 50, 20, "Keyword", false, false);
				AddHtml(100, 150 + (i * 120), 450, 40, rumor == null ? "None" : rumor.Keyword, true, false);

				AddButton(60, 90 + (i * 120), 4005, 4007, GetButtonID(2, i), GumpButtonType.Reply, 0);
			}

			AddButton(338, 437, 4014, 4016, 0, GumpButtonType.Page, 2);
			AddHtml(290, 440, 35, 40, "Back", false, false);

			AddItem(580, 46, 4030);
		}

		private int GetButtonID(int type, int index)
		{
			return 1 + (index * 6) + type;
		}

		private void RenderMessageManagement_Tip_AddOrChange()
		{
			AddPage(6);

			AddHtml(250, 95, 500, 20, "Change this tip message", false, false);
			AddHtml(100, 190, 50, 20, "Message", false, false);
			AddHtml(100, 210, 450, 40, m_Barkeeper.TipMessage == null ? "No current message" : m_Barkeeper.TipMessage, true, false);

			AddButton(60, 210, 4005, 4007, GetButtonID(3, 0), GumpButtonType.Reply, 0);

			AddButton(338, 437, 4014, 4016, 0, GumpButtonType.Page, 2);
			AddHtml(290, 440, 35, 40, "Back", false, false);

			AddItem(580, 46, 4030);
		}

		private void RenderMessageManagement_Tip_Remove()
		{
			AddPage(7);

			AddHtml(250, 95, 500, 20, "Remove this tip message", false, false);
			AddHtml(100, 190, 50, 20, "Message", false, false);
			AddHtml(100, 210, 450, 40, m_Barkeeper.TipMessage == null ? "No current message" : m_Barkeeper.TipMessage, true, false);

			AddButton(60, 210, 4005, 4007, GetButtonID(4, 0), GumpButtonType.Reply, 0);

			AddButton(338, 437, 4014, 4016, 0, GumpButtonType.Page, 2);
			AddHtml(290, 440, 35, 40, "Back", false, false);

			AddItem(580, 46, 4030);
		}

		private void RenderAppearanceCategories()
		{
			AddPage(8);

			AddButton(130, 120, 4005, 4007, GetButtonID(5, 0), GumpButtonType.Reply, 0);
			AddHtml(170, 120, 120, 20, "Title", false, false);

			if (m_Barkeeper.BodyValue != 0x340 && m_Barkeeper.BodyValue != 0x402)
			{
				AddButton(130, 200, 4005, 4007, GetButtonID(5, 1), GumpButtonType.Reply, 0);
				AddHtml(170, 200, 120, 20, "Appearance", false, false);

				AddButton(130, 280, 4005, 4007, GetButtonID(5, 2), GumpButtonType.Reply, 0);
				AddHtml(170, 280, 120, 20, "Male / Female", false, false);

				AddButton(338, 437, 4014, 4016, 0, GumpButtonType.Page, 1);
				AddHtml(290, 440, 35, 40, "Back", false, false);
			}

			AddItem(580, 44, 4033);
		}

		public BarkeeperGump(Mobile from, PlayerBarkeeper barkeeper) : base(0, 0)
		{
			m_From = from;
			m_Barkeeper = barkeeper;

			from.CloseGump(typeof(BarkeeperGump));
			from.CloseGump(typeof(BarkeeperTitleGump));

			RenderBackground();
			RenderCategories();
			RenderMessageManagement();
			RenderDismissConfirmation();
			RenderMessageManagement_Message_AddOrChange();
			RenderMessageManagement_Message_Remove();
			RenderMessageManagement_Tip_AddOrChange();
			RenderMessageManagement_Tip_Remove();
			RenderAppearanceCategories();
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			if (!m_Barkeeper.IsOwner(m_From))
			{
				return;
			}

			var index = info.ButtonID - 1;

			if (index < 0)
			{
				return;
			}

			var type = index % 6;
			index /= 6;

			switch (type)
			{
				case 0: // Controls
					{
						switch (index)
						{
							case 0: // Dismiss
								{
									m_Barkeeper.Dismiss();
									break;
								}
						}

						break;
					}
				case 1: // Change message
					{
						m_Barkeeper.BeginChangeRumor(m_From, index);
						break;
					}
				case 2: // Remove message
					{
						m_Barkeeper.RemoveRumor(m_From, index);
						break;
					}
				case 3: // Change tip
					{
						m_Barkeeper.BeginChangeTip(m_From);
						break;
					}
				case 4: // Remove tip
					{
						m_Barkeeper.RemoveTip(m_From);
						break;
					}
				case 5: // Appearance category selection
					{
						switch (index)
						{
							case 0: m_Barkeeper.BeginChangeTitle(m_From); break;
							case 1: m_Barkeeper.BeginChangeAppearance(m_From); break;
							case 2: m_Barkeeper.ChangeGender(m_From); break;
						}

						break;
					}
			}
		}
	}
}