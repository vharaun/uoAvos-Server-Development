using Server.ContextMenus;
using Server.Engines.BulkOrders;
using Server.Factions;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Multis;
using Server.Network;
using Server.Regions;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
	public interface IShopSellInfo
	{
		//get display name for an item
		string GetNameFor(Item item);

		//get price for an item which the player is selling
		int GetSellPriceFor(Item item);

		//get price for an item which the player is buying
		int GetBuyPriceFor(Item item);

		//can we sell this item to this vendor?
		bool IsSellable(Item item);

		//What do we sell?
		Type[] Types { get; }

		//does the vendor resell this item?
		bool IsResellable(Item item);
	}

	public interface IBuyItemInfo
	{
		//get a new instance of an object (we just bought it)
		IEntity GetEntity();

		int ControlSlots { get; }

		int PriceScalar { get; set; }

		//display price of the item
		int Price { get; }

		//display name of the item
		string Name { get; }

		//display hue
		int Hue { get; }

		//display id
		int ItemID { get; }

		//amount in stock
		int Amount { get; set; }

		//max amount in stock
		int MaxAmount { get; }

		//Attempt to restock with item, (return true if restock sucessful)
		bool Restock(Item item, int amount);

		//called when its time for the whole shop to restock
		void OnRestock();
	}
}

namespace Server.ContextMenus
{
	public class VendorSellEntry : ContextMenuEntry
	{
		private readonly BaseVendor m_Vendor;

		public VendorSellEntry(Mobile from, BaseVendor vendor)
			: base(6104, 8)
		{
			m_Vendor = vendor;
			Enabled = vendor.CheckVendorAccess(from);
		}

		public override void OnClick()
		{
			m_Vendor.VendorSell(Owner.From);
		}
	}

	public class VendorBuyEntry : ContextMenuEntry
	{
		private readonly BaseVendor m_Vendor;

		public VendorBuyEntry(Mobile from, BaseVendor vendor)
			: base(6103, 8)
		{
			m_Vendor = vendor;
			Enabled = vendor.CheckVendorAccess(from);
		}

		public override void OnClick()
		{
			m_Vendor.VendorBuy(Owner.From);
		}
	}
}

namespace Server.Mobiles
{
	public enum VendorShoeType
	{
		None,
		Shoes,
		Boots,
		Sandals,
		ThighBoots
	}

	public abstract class BaseVendor : BaseCreature, IVendor
	{
		private const int MaxSell = 500;

		protected abstract List<SBInfo> SBInfos { get; }

		private readonly ArrayList m_ArmorBuyInfo = new ArrayList();
		private readonly ArrayList m_ArmorSellInfo = new ArrayList();

		#region Holiday Season Events

		/// Christmas
		private DateTime m_NextNaughtyOrNice;

		/// Easter
		private DateTime m_NextEggfest;

		/// Halloween
		private DateTime m_NextTrickOrTreat;

		/// NewYear
		private DateTime m_NextFatherTime;

		/// SaintPatrick
		private DateTime m_NextPotsOGold;

		/// Valentine
		private DateTime m_NextCupidsKiss;

		#endregion

		public override bool CanTeach => true;

		public override bool BardImmune => true;

		public override bool PlayerRangeSensitive => true;

		public virtual bool IsActiveVendor => true;
		public virtual bool IsActiveBuyer => IsActiveVendor;  // response to vendor SELL
		public virtual bool IsActiveSeller => IsActiveVendor;  // repsonse to vendor BUY

		public virtual NpcGuild NpcGuild => NpcGuild.None;

		public NpcGuildInfo NpcGuildInfo => NpcGuildInfo.Find(this);

		public override bool IsInvulnerable => true;

		#region Holiday Season Events

		/// Christmas
		public virtual DateTime NextNaughtyOrNice { get => m_NextNaughtyOrNice; set => m_NextNaughtyOrNice = value; }

		/// Easter
		public virtual DateTime NextEggfest { get => m_NextEggfest; set => m_NextEggfest = value; }

		/// Halloween
		public virtual DateTime NextTrickOrTreat { get => m_NextTrickOrTreat; set => m_NextTrickOrTreat = value; }

		/// NewYear
		public virtual DateTime NextFatherTime { get => m_NextFatherTime; set => m_NextFatherTime = value; }

		/// SaintPatrick
		public virtual DateTime NextPotsOGold { get => m_NextPotsOGold; set => m_NextPotsOGold = value; }

		/// Valentine
		public virtual DateTime NextCupidsKiss { get => m_NextCupidsKiss; set => m_NextCupidsKiss = value; }

		#endregion

		public override bool ShowFameTitle => false;

		public virtual bool IsValidBulkOrder(Item item)
		{
			return false;
		}

		public virtual Item CreateBulkOrder(Mobile from, bool fromContextMenu)
		{
			return null;
		}

		public virtual bool SupportsBulkOrders(Mobile from)
		{
			return false;
		}

		public virtual TimeSpan GetNextBulkOrder(Mobile from)
		{
			return TimeSpan.Zero;
		}

		public virtual void OnSuccessfulBulkOrderReceive(Mobile from)
		{
		}

		private Town m_HomeTown;

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Town HomeTown
		{
			get => m_HomeTown ?? Town.FromRegion(Region);
			set
			{
				m_HomeTown = value;

				InvalidateProperties();
			}
		}

		public virtual int GetPriceScalar(Mobile buyer)
		{
			var scalar = 100;

			if (NpcGuild != NpcGuild.None && buyer is PlayerMobile player && player.NpcGuild == NpcGuild)
			{
				scalar -= NpcGuildInfo.VendorDiscount;
			}

			var town = HomeTown;

			if (town != null)
			{
				scalar += town.Tax;
			}

			return Math.Max(0, scalar);
		}

		public void UpdateBuyInfo(Mobile buyer)
		{
			var priceScalar = GetPriceScalar(buyer);

			var buyinfo = (IBuyItemInfo[])m_ArmorBuyInfo.ToArray(typeof(IBuyItemInfo));

			if (buyinfo != null)
			{
				foreach (var info in buyinfo)
				{
					info.PriceScalar = priceScalar;
				}
			}
		}

		private class BulkOrderInfoEntry : ContextMenuEntry
		{
			private readonly Mobile m_From;
			private readonly BaseVendor m_Vendor;

			public BulkOrderInfoEntry(Mobile from, BaseVendor vendor)
				: base(6152)
			{
				m_From = from;
				m_Vendor = vendor;
			}

			public override void OnClick()
			{
				if (m_Vendor.SupportsBulkOrders(m_From))
				{
					var ts = m_Vendor.GetNextBulkOrder(m_From);

					var totalSeconds = (int)ts.TotalSeconds;
					var totalHours = (totalSeconds + 3599) / 3600;
					var totalMinutes = (totalSeconds + 59) / 60;

					if (((Core.SE) ? totalMinutes == 0 : totalHours == 0))
					{
						m_From.SendLocalizedMessage(1049038); // You can get an order now.

						if (Core.AOS)
						{
							var bulkOrder = m_Vendor.CreateBulkOrder(m_From, true);

							if (bulkOrder is LargeBOD)
							{
								m_From.SendGump(new LargeBODAcceptGump(m_From, (LargeBOD)bulkOrder));
							}
							else if (bulkOrder is SmallBOD)
							{
								m_From.SendGump(new SmallBODAcceptGump(m_From, (SmallBOD)bulkOrder));
							}
						}
					}
					else
					{
						var oldSpeechHue = m_Vendor.SpeechHue;
						m_Vendor.SpeechHue = 0x3B2;

						if (Core.SE)
						{
							m_Vendor.SayTo(m_From, 1072058, totalMinutes.ToString()); // An offer may be available in about ~1_minutes~ minutes.
						}
						else
						{
							m_Vendor.SayTo(m_From, 1049039, totalHours.ToString()); // An offer may be available in about ~1_hours~ hours.
						}

						m_Vendor.SpeechHue = oldSpeechHue;
					}
				}
			}
		}

		public BaseVendor(string title)
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Currencies = new();

			LoadSBInfo();

			Title = title;
			InitBody();
			InitOutfit();

			Container pack;
			//these packs MUST exist, or the client will crash when the packets are sent
			pack = new Backpack {
				Layer = Layer.ShopBuy,
				Movable = false,
				Visible = false
			};
			AddItem(pack);

			pack = new Backpack {
				Layer = Layer.ShopResale,
				Movable = false,
				Visible = false
			};
			AddItem(pack);

			LastRestock = DateTime.UtcNow;
		}

		public BaseVendor(Serial serial)
			: base(serial)
		{
		}

		#region Currencies

		protected readonly Dictionary<Mobile, TypeAmount> m_SelectedCurrencies = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Currencies Currencies { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool CurrenciesLocal { get; set; } = true;

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool CurrenciesInherit { get; set; } = true;

		public IEnumerable<TypeAmount> CurrenciesSupported
		{
			get
			{
				if (CurrenciesLocal)
				{
					foreach (var entry in Currencies.ActiveEntries)
					{
						yield return entry;
					}
				}

				if (CurrenciesInherit)
				{
					var reg = Region;

					while (reg != null)
					{
						if (reg is BaseRegion br && br.Currencies?.Count > 0)
						{
							foreach (var entry in br.Currencies.ActiveEntries)
							{
								yield return entry;
							}
						}

						reg = reg.Parent;
					}
				}
			}
		}

		#endregion

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public DateTime LastRestock { get; set; }

		public virtual TimeSpan RestockDelay => TimeSpan.FromHours(1);

		public Container BuyPack
		{
			get
			{
				var pack = FindItemOnLayer(Layer.ShopBuy) as Container;

				if (pack == null)
				{
					pack = new Backpack {
						Layer = Layer.ShopBuy,
						Visible = false
					};
					AddItem(pack);
				}

				return pack;
			}
		}

		public abstract void InitSBInfo();

		public virtual bool IsTokunoVendor => (Map == Map.Tokuno);

		protected void LoadSBInfo()
		{
			LastRestock = DateTime.UtcNow;

			for (var i = 0; i < m_ArmorBuyInfo.Count; ++i)
			{
				var buy = m_ArmorBuyInfo[i] as GenericBuyInfo;

				if (buy != null)
				{
					buy.DeleteDisplayEntity();
				}
			}

			SBInfos.Clear();

			InitSBInfo();

			m_ArmorBuyInfo.Clear();
			m_ArmorSellInfo.Clear();

			for (var i = 0; i < SBInfos.Count; i++)
			{
				var sbInfo = SBInfos[i];
				m_ArmorBuyInfo.AddRange(sbInfo.BuyInfo);
				m_ArmorSellInfo.Add(sbInfo.SellInfo);
			}
		}

		public virtual bool GetGender()
		{
			return Utility.RandomBool();
		}

		public virtual void InitBody()
		{
			InitStats(100, 100, 25);

			SpeechHue = Utility.RandomDyedHue();
			Hue = Utility.RandomSkinHue();

			if (Female = GetGender())
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

		public virtual int GetRandomHue()
		{
			switch (Utility.Random(5))
			{
				default:
				case 0: return Utility.RandomBlueHue();
				case 1: return Utility.RandomGreenHue();
				case 2: return Utility.RandomRedHue();
				case 3: return Utility.RandomYellowHue();
				case 4: return Utility.RandomNeutralHue();
			}
		}

		public virtual int GetShoeHue()
		{
			if (0.1 > Utility.RandomDouble())
			{
				return 0;
			}

			return Utility.RandomNeutralHue();
		}

		public virtual VendorShoeType ShoeType => VendorShoeType.Shoes;

		public virtual void CheckMorph()
		{
			if (CheckGargoyle())
			{
				return;
			}

			if (CheckNecromancer())
			{
				return;
			}

			CheckTokuno();
		}

		public virtual bool CheckTokuno()
		{
			if (Map != Map.Tokuno)
			{
				return false;
			}

			NameList n;

			if (Female)
			{
				n = NameList.GetNameList("tokuno female");
			}
			else
			{
				n = NameList.GetNameList("tokuno male");
			}

			if (!n.ContainsName(Name))
			{
				TurnToTokuno();
			}

			return true;
		}

		public virtual void TurnToTokuno()
		{
			if (Female)
			{
				Name = NameList.RandomName("tokuno female");
			}
			else
			{
				Name = NameList.RandomName("tokuno male");
			}
		}

		public virtual bool CheckGargoyle()
		{
			var map = Map;

			if (map != Map.Ilshenar)
			{
				return false;
			}

			if (!Region.IsPartOf("Gargoyle City"))
			{
				return false;
			}

			if (Body != 0x2F6 || (Hue & 0x8000) == 0)
			{
				TurnToGargoyle();
			}

			return true;
		}

		public virtual bool CheckNecromancer()
		{
			var map = Map;

			if (map != Map.Malas)
			{
				return false;
			}

			if (!Region.IsPartOf("Umbra"))
			{
				return false;
			}

			if (Hue != 0x83E8)
			{
				TurnToNecromancer();
			}

			return true;
		}

		public override void OnAfterSpawn()
		{
			CheckMorph();
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			m_SelectedCurrencies.Clear();
		}

		protected override void OnMapChange(Map oldMap)
		{
			base.OnMapChange(oldMap);

			CheckMorph();

			LoadSBInfo();
		}

		public virtual int GetRandomNecromancerHue()
		{
			switch (Utility.Random(20))
			{
				case 0: return 0;
				case 1: return 0x4E9;
				default: return Utility.RandomList(0x485, 0x497);
			}
		}

		public virtual void TurnToNecromancer()
		{
			for (var i = 0; i < Items.Count; ++i)
			{
				var item = Items[i];

				if (item is Hair || item is Beard)
				{
					item.Hue = 0;
				}
				else if (item is BaseClothing || item is BaseWeapon || item is BaseArmor || item is BaseTool)
				{
					item.Hue = GetRandomNecromancerHue();
				}
			}

			HairHue = 0;
			FacialHairHue = 0;

			Hue = 0x83E8;
		}

		public virtual void TurnToGargoyle()
		{
			for (var i = 0; i < Items.Count; ++i)
			{
				var item = Items[i];

				if (item is BaseClothing || item is Hair || item is Beard)
				{
					item.Delete();
				}
			}

			HairItemID = 0;
			FacialHairItemID = 0;

			Body = 0x2F6;
			Hue = Utility.RandomBrightHue() | 0x8000;
			Name = NameList.RandomName("gargoyle vendor");

			CapitalizeTitle();
		}

		public virtual void CapitalizeTitle()
		{
			var title = Title;

			if (title == null)
			{
				return;
			}

			var split = title.Split(' ');

			for (var i = 0; i < split.Length; ++i)
			{
				if (Insensitive.Equals(split[i], "the"))
				{
					continue;
				}

				if (split[i].Length > 1)
				{
					split[i] = Char.ToUpper(split[i][0]) + split[i].Substring(1);
				}
				else if (split[i].Length > 0)
				{
					split[i] = Char.ToUpper(split[i][0]).ToString();
				}
			}

			Title = String.Join(" ", split);
		}

		public virtual int GetHairHue()
		{
			return Utility.RandomHairHue();
		}

		public virtual void InitOutfit()
		{
			switch (Utility.Random(3))
			{
				case 0: AddItem(new FancyShirt(GetRandomHue())); break;
				case 1: AddItem(new Doublet(GetRandomHue())); break;
				case 2: AddItem(new Shirt(GetRandomHue())); break;
			}

			switch (ShoeType)
			{
				case VendorShoeType.Shoes: AddItem(new Shoes(GetShoeHue())); break;
				case VendorShoeType.Boots: AddItem(new Boots(GetShoeHue())); break;
				case VendorShoeType.Sandals: AddItem(new Sandals(GetShoeHue())); break;
				case VendorShoeType.ThighBoots: AddItem(new ThighBoots(GetShoeHue())); break;
			}

			var hairHue = GetHairHue();

			Utility.AssignRandomHair(this, hairHue);
			Utility.AssignRandomFacialHair(this, hairHue);

			if (Female)
			{
				switch (Utility.Random(6))
				{
					case 0: AddItem(new ShortPants(GetRandomHue())); break;
					case 1:
					case 2: AddItem(new Kilt(GetRandomHue())); break;
					case 3:
					case 4:
					case 5: AddItem(new Skirt(GetRandomHue())); break;
				}
			}
			else
			{
				switch (Utility.Random(2))
				{
					case 0: AddItem(new LongPants(GetRandomHue())); break;
					case 1: AddItem(new ShortPants(GetRandomHue())); break;
				}
			}

			PackGold(100, 200);
		}

		public virtual void Restock()
		{
			LastRestock = DateTime.UtcNow;

			var buyInfo = GetBuyInfo();

			foreach (var bii in buyInfo)
			{
				bii.OnRestock();
			}
		}

		private static readonly TimeSpan InventoryDecayTime = TimeSpan.FromHours(1.0);

		public virtual bool AllowBuyer(Mobile buyer, bool message)
		{
			if (!IsActiveSeller)
			{
				return false;
			}

			if (!buyer.CheckAlive(message))
			{
				return false;
			}

			if (!CheckVendorAccess(buyer))
			{
				if (message)
				{
					Say(501522); // I shall not treat with scum like thee!
				}

				return false;
			}

			return true;
		}

		public void VendorBuy(Mobile from)
		{
			if (!AllowBuyer(from, true))
			{
				return;
			}

			if (from.Player)
			{
				var gump = CurrencyUtility.BeginSelectCurrency(from, true, CurrenciesSupported, (p, t) =>
				{
					m_SelectedCurrencies[from] = t;

					OnVendorBuy(from);
				});

				if (gump != null)
				{
					return;
				}
			}

			OnVendorBuy(from);
		}
		
		protected virtual void OnVendorBuy(Mobile from)
		{
			if (!AllowBuyer(from, true))
			{
				m_SelectedCurrencies.Remove(from);
				return;
			}

			if (!m_SelectedCurrencies.TryGetValue(from, out var currency))
			{
				currency = Currencies.GoldEntry;
			}

			if (DateTime.UtcNow - LastRestock > RestockDelay)
			{
				Restock();
			}

			UpdateBuyInfo(from);

			var count = 0;
			List<BuyItemState> list;
			var buyInfo = GetBuyInfo();
			var sellInfo = GetSellInfo();

			list = new List<BuyItemState>(buyInfo.Length);
			var cont = BuyPack;

			List<ObjectPropertyList> opls = null;

			for (var idx = 0; idx < buyInfo.Length; idx++)
			{
				var buyItem = buyInfo[idx];

				if (buyItem.Amount <= 0 || list.Count >= 250)
				{
					continue;
				}

				// NOTE: Only GBI supported; if you use another implementation of IBuyItemInfo, this will crash
				var gbi = (GenericBuyInfo)buyItem;
				var disp = gbi.GetDisplayEntity();

				if (!CurrencyUtility.ConvertGoldToCurrency(buyItem.Price, currency, out var price))
				{
					continue;
				}

				list.Add(new BuyItemState(buyItem.Name, cont.Serial, disp == null ? 0x7FC0FFEE : disp.Serial, price, buyItem.Amount, buyItem.ItemID, buyItem.Hue));
				count++;

				if (opls == null)
				{
					opls = new List<ObjectPropertyList>();
				}

				if (disp is Item item)
				{
					opls.Add(item.PropertyList);
				}
				else if (disp is Mobile mobile)
				{
					opls.Add(mobile.PropertyList);
				}
			}

			var playerItems = cont.Items;

			for (var i = playerItems.Count - 1; i >= 0; --i)
			{
				if (i >= playerItems.Count)
				{
					continue;
				}

				var item = playerItems[i];

				if (item.LastMoved + InventoryDecayTime <= DateTime.UtcNow)
				{
					item.Delete();
				}
			}

			for (var i = 0; i < playerItems.Count; ++i)
			{
				var item = playerItems[i];

				var price = 0;
				string name = null;

				foreach (var ssi in sellInfo)
				{
					if (ssi.IsSellable(item))
					{
						price = ssi.GetBuyPriceFor(item);
						name = ssi.GetNameFor(item);
						break;
					}
				}

				if (name != null && list.Count < 250)
				{
					if (!CurrencyUtility.ConvertGoldToCurrency(price, currency, out price))
					{
						continue;
					}

					list.Add(new BuyItemState(name, cont.Serial, item.Serial, price, item.Amount, item.ItemID, item.Hue));
					count++;

					if (opls == null)
					{
						opls = new List<ObjectPropertyList>();
					}

					opls.Add(item.PropertyList);
				}
			}

			//one (not all) of the packets uses a byte to describe number of items in the list.  Osi = dumb.
			//if ( list.Count > 255 )
			//	Console.WriteLine( "Vendor Warning: Vendor {0} has more than 255 buy items, may cause client errors!", this );

			if (list.Count > 0)
			{
				list.Sort(new BuyItemStateComparer());

				SendPacksTo(from);

				var ns = from.NetState;

				if (ns == null)
				{
					return;
				}

				if (ns.ContainerGridLines)
				{
					from.Send(new VendorBuyContent6017(list));
				}
				else
				{
					from.Send(new VendorBuyContent(list));
				}

				from.Send(new VendorBuyList(this, list));

				if (ns.HighSeas)
				{
					from.Send(new DisplayBuyListHS(this));
				}
				else
				{
					from.Send(new DisplayBuyList(this));
				}

				from.Send(new MobileStatusExtended(from));//make sure their gold amount is sent

				if (opls != null)
				{
					for (var i = 0; i < opls.Count; ++i)
					{
						from.Send(opls[i]);
					}
				}

				SayTo(from, 500186); // Greetings.  Have a look around.
			}
		}

		public virtual void SendPacksTo(Mobile from)
		{
			var pack = FindItemOnLayer(Layer.ShopBuy);

			if (pack == null)
			{
				pack = new Backpack {
					Layer = Layer.ShopBuy,
					Movable = false,
					Visible = false
				};
				AddItem(pack);
			}

			from.Send(new EquipUpdate(pack));

			pack = FindItemOnLayer(Layer.ShopSell);

			if (pack != null)
			{
				from.Send(new EquipUpdate(pack));
			}

			pack = FindItemOnLayer(Layer.ShopResale);

			if (pack == null)
			{
				pack = new Backpack {
					Layer = Layer.ShopResale,
					Movable = false,
					Visible = false
				};
				AddItem(pack);
			}

			from.Send(new EquipUpdate(pack));
		}

		public virtual bool AllowSeller(Mobile seller, bool message)
		{
			if (!IsActiveBuyer)
			{
				return false;
			}

			if (!seller.CheckAlive(message))
			{
				return false;
			}

			if (!CheckVendorAccess(seller))
			{
				if (message)
				{
					Say(501522); // I shall not treat with scum like thee!
				}

				return false;
			}

			return true;
		}

		public void VendorSell(Mobile from)
		{
			if (!AllowSeller(from, true))
			{
				return;
			}

			if (from.Player)
			{
				var gump = CurrencyUtility.BeginSelectCurrency(from, true, CurrenciesSupported, (p, t) =>
				{
					m_SelectedCurrencies[from] = t;

					OnVendorSell(from);
				});

				if (gump != null)
				{
					return;
				}
			}

			OnVendorSell(from);
		}

		protected virtual void OnVendorSell(Mobile from)
		{
			if (!AllowSeller(from, true))
			{
				m_SelectedCurrencies.Remove(from);
				return;
			}

			if (!m_SelectedCurrencies.TryGetValue(from, out var currency))
			{
				currency = Currencies.GoldEntry;
			}

			var pack = from.Backpack;

			if (pack != null)
			{
				var info = GetSellInfo();

				var table = new List<SellItemState>();

				foreach (var ssi in info)
				{
					var items = pack.FindItemsByType(ssi.Types);

					foreach (var item in items)
					{
						if (item is Container c && c.Items.Count != 0)
						{
							continue;
						}

						if (item.Parent is LockableContainer lockable && lockable.Locked)
						{
							continue;
						}

						if (item.Movable && item.IsStandardLoot() && ssi.IsSellable(item))
						{
							if (CurrencyUtility.ConvertGoldToCurrency(ssi.GetSellPriceFor(item), currency, out var price))
							{
								table.Add(new SellItemState(item, price, ssi.GetNameFor(item)));
							}
						}
					}
				}

				if (table.Count > 0)
				{
					SendPacksTo(from);

					from.Send(new VendorSellList(this, table));
				}
				else
				{
					Say(true, "You have nothing I would be interested in.");
				}
			}
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			/* TODO: Thou art giving me? and fame/karma for gold gifts */

			if (dropped is SmallBOD || dropped is LargeBOD)
			{
				var pm = from as PlayerMobile;

				if (Core.ML && pm != null && pm.NextBODTurnInTime > DateTime.UtcNow)
				{
					SayTo(from, 1079976); // You'll have to wait a few seconds while I inspect the last order.
					return false;
				}
				else if (!IsValidBulkOrder(dropped))
				{
					SayTo(from, 1045130); // That order is for some other shopkeeper.
					return false;
				}
				else if ((dropped is SmallBOD sb && !sb.Complete) || (dropped is LargeBOD lb && !lb.Complete))
				{
					SayTo(from, 1045131); // You have not completed the order yet.
					return false;
				}

				Item reward = null;
				int gold = 0, fame = 0;

				if (dropped is SmallBOD sbod)
				{
					sbod.GetRewards(out reward, out gold, out fame);
				}
				else if(dropped is LargeBOD lbod)
				{
					lbod.GetRewards(out reward, out gold, out fame);
				}

				from.SendSound(0x3D);

				SayTo(from, 1045132); // Thank you so much!  Here is a reward for your effort.

				if (reward != null)
				{
					from.AddToBackpack(reward);
				}

				if (gold > 1000)
				{
					from.AddToBackpack(new BankCheck(gold));
				}
				else if (gold > 0)
				{
					from.AddToBackpack(new Gold(gold));
				}

				Titles.AwardFame(from, fame, true);

				OnSuccessfulBulkOrderReceive(from);

				if (Core.ML && pm != null)
				{
					pm.NextBODTurnInTime = DateTime.UtcNow + TimeSpan.FromSeconds(10.0);
				}

				dropped.Delete();
				return true;
			}

			return base.OnDragDrop(from, dropped);
		}

		private GenericBuyInfo LookupDisplayObject(object obj)
		{
			var buyInfo = GetBuyInfo();

			for (var i = 0; i < buyInfo.Length; ++i)
			{
				var gbi = (GenericBuyInfo)buyInfo[i];

				if (gbi.GetDisplayEntity() == obj)
				{
					return gbi;
				}
			}

			return null;
		}

		private static void ProcessSinglePurchase(BuyItemResponse buy, IBuyItemInfo bii, List<BuyItemResponse> validBuy, ref int controlSlots, ref bool fullPurchase, ref int totalCost)
		{
			var amount = buy.Amount;

			if (amount > bii.Amount)
			{
				amount = bii.Amount;
			}

			if (amount <= 0)
			{
				return;
			}

			var slots = bii.ControlSlots * amount;

			if (controlSlots >= slots)
			{
				controlSlots -= slots;
			}
			else
			{
				fullPurchase = false;
				return;
			}

			totalCost += bii.Price * amount;
			validBuy.Add(buy);
		}

		private static void ProcessValidPurchase(int amount, IBuyItemInfo bii, Mobile buyer, Container cont)
		{
			if (amount > bii.Amount)
			{
				amount = bii.Amount;
			}

			if (amount < 1)
			{
				return;
			}

			bii.Amount -= amount;

			var o = bii.GetEntity();

			if (o is Item item)
			{
				if (item.Stackable)
				{
					item.Amount = amount;

					if (cont == null || !cont.TryDropItem(buyer, item, false))
					{
						item.MoveToWorld(buyer.Location, buyer.Map);
					}
				}
				else
				{
					item.Amount = 1;

					if (cont == null || !cont.TryDropItem(buyer, item, false))
					{
						item.MoveToWorld(buyer.Location, buyer.Map);
					}

					for (var i = 1; i < amount; i++)
					{
						if (bii.GetEntity() is Item obj)
						{
							obj.Amount = 1;

							if (cont == null || !cont.TryDropItem(buyer, obj, false))
							{
								obj.MoveToWorld(buyer.Location, buyer.Map);
							}
						}
					}
				}
			}
			else if (o is Mobile mobile)
			{
				mobile.Direction = (Direction)Utility.Random(8);
				mobile.MoveToWorld(buyer.Location, buyer.Map);
				mobile.PlaySound(mobile.GetIdleSound());

				if (mobile is BaseCreature creature)
				{
					creature.SetControlMaster(buyer);
					creature.ControlOrder = OrderType.Stop;
				}

				for (var i = 1; i < amount; ++i)
				{
					if (bii.GetEntity() is Mobile obj)
					{
						obj.Direction = (Direction)Utility.Random(8);
						obj.MoveToWorld(buyer.Location, buyer.Map);
						obj.PlaySound(obj.GetIdleSound());

						if (obj is BaseCreature pet)
						{
							pet.SetControlMaster(buyer);
							pet.ControlOrder = OrderType.Stop;
						}
					}
				}
			}
		}

		public virtual bool OnBuyItems(Mobile buyer, List<BuyItemResponse> list)
		{
			if (m_SelectedCurrencies.TryGetValue(buyer, out var currency))
			{
				m_SelectedCurrencies.Remove(buyer);
			}
			else
			{
				currency = Currencies.GoldEntry;
			}

			if (!AllowBuyer(buyer, true))
			{
				return false;
			}

			UpdateBuyInfo(buyer);

			//var buyInfo = GetBuyInfo();
			var info = GetSellInfo();
			var totalCost = 0;
			var validBuy = new List<BuyItemResponse>(list.Count);
			Container cont;
			var bought = false;
			var fromBank = false;
			var fullPurchase = true;
			var controlSlots = buyer.FollowersMax - buyer.Followers;

			foreach (var buy in list)
			{
				var ser = buy.Serial;
				var amount = buy.Amount;

				if (ser.IsItem)
				{
					var item = World.FindItem(ser);

					if (item == null)
					{
						continue;
					}

					var gbi = LookupDisplayObject(item);

					if (gbi != null)
					{
						ProcessSinglePurchase(buy, gbi, validBuy, ref controlSlots, ref fullPurchase, ref totalCost);
					}
					else if (item != BuyPack && item.IsChildOf(BuyPack))
					{
						if (amount > item.Amount)
						{
							amount = item.Amount;
						}

						if (amount <= 0)
						{
							continue;
						}

						foreach (var ssi in info)
						{
							if (ssi.IsSellable(item) && ssi.IsResellable(item))
							{
								if (CurrencyUtility.ConvertGoldToCurrency(ssi.GetBuyPriceFor(item), currency, out var price))
								{
									totalCost += price * amount;
									validBuy.Add(buy);
								}

								break;
							}
						}
					}
				}
				else if (ser.IsMobile)
				{
					var mob = World.FindMobile(ser);

					if (mob == null)
					{
						continue;
					}

					var gbi = LookupDisplayObject(mob);

					if (gbi != null)
					{
						ProcessSinglePurchase(buy, gbi, validBuy, ref controlSlots, ref fullPurchase, ref totalCost);
					}
				}
			}//foreach

			if (fullPurchase && validBuy.Count == 0)
			{
				SayTo(buyer, 500190); // Thou hast bought nothing!
			}
			else if (validBuy.Count == 0)
			{
				SayTo(buyer, 500187); // Your order cannot be fulfilled, please try again.
			}

			if (validBuy.Count == 0)
			{
				return false;
			}

			bought = buyer.AccessLevel >= AccessLevel.GameMaster;
			cont = buyer.Backpack;

			if (!bought && cont != null)
			{
				bought = cont.ConsumeTotal(currency, totalCost);
			}

			if (!bought && CurrencyUtility.ConvertGoldToCurrency(2000, currency, out var petty) && totalCost > petty)
			{
				fromBank = true;

				bought = CurrencyUtility.WithdrawFromBank(buyer, currency, totalCost, false);
			}

			if (!bought)
			{
				if (fromBank)
				{
					SayTo(buyer, 500191); // Begging thy pardon, but thy bank account lacks these funds.
				}
				else
				{
					SayTo(buyer, 500192); // Begging thy pardon, but thou canst not afford that.
				}

				return false;
			}
			
			buyer.PlaySound(0x32);

			cont = buyer.Backpack ?? buyer.BankBox;

			foreach (var buy in validBuy)
			{
				var ser = buy.Serial;
				var amount = buy.Amount;

				if (amount < 1)
				{
					continue;
				}

				if (ser.IsItem)
				{
					var item = World.FindItem(ser);

					if (item == null)
					{
						continue;
					}

					var gbi = LookupDisplayObject(item);

					if (gbi != null)
					{
						ProcessValidPurchase(amount, gbi, buyer, cont);
						continue;
					}

					if (amount > item.Amount)
					{
						amount = item.Amount;
					}

					foreach (var ssi in info)
					{
						if (ssi.IsSellable(item) && ssi.IsResellable(item))
						{
							Item buyItem;

							if (amount >= item.Amount)
							{
								buyItem = item;
							}
							else
							{
								buyItem = LiftItemDupe(item, item.Amount - amount);

								if (buyItem == null)
								{
									buyItem = item;
								}
							}

							if (cont == null || !cont.TryDropItem(buyer, buyItem, false))
							{
								buyItem.MoveToWorld(buyer.Location, buyer.Map);
							}

							break;
						}
					}
				}
				else if (ser.IsMobile)
				{
					var mob = World.FindMobile(ser);

					if (mob == null)
					{
						continue;
					}

					var gbi = LookupDisplayObject(mob);

					if (gbi != null)
					{
						ProcessValidPurchase(amount, gbi, buyer, cont);
					}
				}
			}//foreach

			var charged = $"{totalCost:N0} {Utility.FriendlyName(currency)}";

			if (fullPurchase)
			{
				if (buyer.AccessLevel >= AccessLevel.GameMaster)
				{
					SayTo(buyer, true, $"I would not presume to charge thee anything, master {buyer.RawName}.  Here are the goods you requested.");
				}
				else if (fromBank)
				{
					SayTo(buyer, true, $"The total of your purchase is {charged}, which has been drawn from your bank account.  My thanks for the patronage.");
				}
				else
				{
					SayTo(buyer, true, $"The total of your purchase is {charged}.  My thanks for the patronage.");
				}
			}
			else
			{
				if (buyer.AccessLevel >= AccessLevel.GameMaster)
				{
					SayTo(buyer, true, $"I would not presume to charge thee anything, master {buyer.RawName}.  Unfortunately, I could not sell you all the goods you requested.");
				}
				else if (fromBank)
				{
					SayTo(buyer, true, $"The total of thy purchase is {charged}, which has been withdrawn from your bank account.  My thanks for the patronage.  Unfortunately, I could not sell you all the goods you requested.");
				}
				else
				{
					SayTo(buyer, true, $"The total of thy purchase is {charged}.  My thanks for the patronage.  Unfortunately, I could not sell you all the goods you requested.");
				}
			}

			return true;
		}

		private AccessLevel m_VendorAccessLevel = AccessLevel.Player;

		[CommandProperty(AccessLevel.GameMaster)]
		public AccessLevel VendorAccessLevel
		{
			get => m_VendorAccessLevel;
			set => m_VendorAccessLevel = value;
		}

		public virtual bool CheckVendorAccess(Mobile from)
		{
			if (from.AccessLevel < m_VendorAccessLevel)
			{
				from.SendMessage("You can't trade with this vendor");

				SayTo(from, true, "My apologies, I cannot sell to you at this time");

				return false;
			}

			var reg = Region.GetRegion<GuardedRegion>();

			if (reg != null && !reg.CheckVendorAccess(this, from))
			{
				return false;
			}

			if (Region != from.Region)
			{
				reg = from.Region.GetRegion<GuardedRegion>();

				if (reg != null && !reg.CheckVendorAccess(this, from))
				{
					return false;
				}
			}

			if (Reputation.IsEnemy(this, from))
			{
				return false;
			}

			return true;
		}

		public override bool IsEnemy(Mobile m)
		{
			return base.IsEnemy(m);
		}

		public virtual bool OnSellItems(Mobile seller, List<SellItemResponse> list)
		{
			if (m_SelectedCurrencies.TryGetValue(seller, out var currency))
			{
				m_SelectedCurrencies.Remove(seller);
			}
			else
			{
				currency = Currencies.GoldEntry;
			}

			if (!AllowSeller(seller, true))
			{
				return false;
			}

			seller.PlaySound(0x32);

			var info = GetSellInfo();
			var buyInfo = GetBuyInfo();
			var give = 0;
			var sold = 0;
			Container cont;

			foreach (var resp in list)
			{
				if (resp.Item.RootParent != seller || resp.Amount <= 0 || !resp.Item.IsStandardLoot() || !resp.Item.Movable || (resp.Item is Container c && c.Items.Count != 0))
				{
					continue;
				}

				foreach (var ssi in info)
				{
					if (!ssi.IsSellable(resp.Item))
					{
						continue;
					}

					var amount = Math.Min(resp.Amount, resp.Item.Amount);

					if (amount <= 0)
					{
						continue;
					}

					if (!CurrencyUtility.ConvertGoldToCurrency(ssi.GetSellPriceFor(resp.Item), currency, out _))
					{
						continue;
					}

					sold++;
					break;
				}
			}

			if (sold > MaxSell)
			{
				SayTo(seller, true, $"You may only sell {MaxSell:N0} items at a time!");
				return false;
			}

			if (sold == 0)
			{
				return true;
			}

			var index = list.Count;

			while (--index >= 0)
			{
				if (index >= list.Count)
				{
					continue;
				}

				var resp = list[index];

				if (resp.Item.RootParent != seller || resp.Amount <= 0 || !resp.Item.Movable || !resp.Item.IsStandardLoot() || (resp.Item is Container c && c.Items.Count != 0))
				{
					list.RemoveAt(index);
					continue;
				}

				foreach (var ssi in info)
				{
					if (!ssi.IsSellable(resp.Item))
					{
						list.RemoveAt(index);
						continue;
					}

					var amount = Math.Min(resp.Amount, resp.Item.Amount);

					if (amount <= 0)
					{
						list.RemoveAt(index);
						continue;
					}

					if (!CurrencyUtility.ConvertGoldToCurrency(ssi.GetSellPriceFor(resp.Item), currency, out var worth))
					{
						list.RemoveAt(index);
						continue;
					}

					give += worth * amount;
					break;
				}
			}

			if (give > 0 && CurrencyUtility.DepositToBank(seller, currency, give, true))
			{
				seller.PlaySound(0x0037); //Gold dropping sound

				foreach (var resp in list)
				{
					foreach (var ssi in info)
					{
						var amount = Math.Min(resp.Amount, resp.Item.Amount);

						if (ssi.IsResellable(resp.Item))
						{
							var found = false;

							foreach (var bii in buyInfo)
							{
								if (bii.Restock(resp.Item, amount))
								{
									resp.Item.Consume(amount);

									found = true;

									break;
								}
							}

							if (!found)
							{
								cont = BuyPack;

								if (amount < resp.Item.Amount)
								{
									var item = LiftItemDupe(resp.Item, resp.Item.Amount - amount);

									if (item != null)
									{
										item.SetLastMoved();
										cont.DropItem(item);
									}
									else
									{
										resp.Item.SetLastMoved();
										cont.DropItem(resp.Item);
									}
								}
								else
								{
									resp.Item.SetLastMoved();
									cont.DropItem(resp.Item);
								}
							}
						}
						else
						{
							resp.Item.Consume(amount);
						}

						break;
					}
				}

				if (SupportsBulkOrders(seller))
				{
					var bulkOrder = CreateBulkOrder(seller, false);

					if (bulkOrder is LargeBOD lbod)
					{
						seller.SendGump(new LargeBODAcceptGump(seller, lbod));
					}
					else if (bulkOrder is SmallBOD sbod)
					{
						seller.SendGump(new SmallBODAcceptGump(seller, sbod));
					}
				}
			}

			return true;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(5); // version

			Town.WriteReference(writer, m_HomeTown);

			Currencies.Serialize(writer);

			writer.Write(CurrenciesLocal);
			writer.Write(CurrenciesInherit);

			writer.Write((int)VendorAccessLevel);

			var sbInfos = SBInfos;

			for (var i = 0; sbInfos != null && i < sbInfos.Count; ++i)
			{
				var sbInfo = sbInfos[i];
				var buyInfo = sbInfo.BuyInfo;

				for (var j = 0; buyInfo != null && j < buyInfo.Count; ++j)
				{
					var gbi = buyInfo[j];

					var maxAmount = gbi.MaxAmount;
					var doubled = 0;

					switch (maxAmount)
					{
						case 40: doubled = 1; break;
						case 80: doubled = 2; break;
						case 160: doubled = 3; break;
						case 320: doubled = 4; break;
						case 640: doubled = 5; break;
						case 999: doubled = 6; break;
					}

					if (doubled > 0)
					{
						writer.WriteEncodedInt(1 + ((j * sbInfos.Count) + i));
						writer.WriteEncodedInt(doubled);
					}
				}
			}

			writer.WriteEncodedInt(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			LoadSBInfo();

			var sbInfos = SBInfos;

			switch (version)
			{
				case 5:
				case 4:
					{
						m_HomeTown = Town.ReadReference(reader);
						goto case 3;
					}
				case 3:
					{
						Currencies.Deserialize(reader);

						if (version >= 5)
						{
							CurrenciesLocal = reader.ReadBool();
							CurrenciesInherit = reader.ReadBool();
						}
						
						goto case 2;
					}
				case 2:
					{
						m_VendorAccessLevel = (AccessLevel)reader.ReadInt();
						goto case 1;
					}
				case 1:
					{
						int index;

						while ((index = reader.ReadEncodedInt()) > 0)
						{
							var doubled = reader.ReadEncodedInt();

							if (sbInfos != null)
							{
								index -= 1;
								var sbInfoIndex = index % sbInfos.Count;
								var buyInfoIndex = index / sbInfos.Count;

								if (sbInfoIndex >= 0 && sbInfoIndex < sbInfos.Count)
								{
									var sbInfo = sbInfos[sbInfoIndex];
									var buyInfo = sbInfo.BuyInfo;

									if (buyInfo != null && buyInfoIndex >= 0 && buyInfoIndex < buyInfo.Count)
									{
										var gbi = buyInfo[buyInfoIndex];

										var amount = 20;

										switch (doubled)
										{
											case 1: amount = 40; break;
											case 2: amount = 80; break;
											case 3: amount = 160; break;
											case 4: amount = 320; break;
											case 5: amount = 640; break;
											case 6: amount = 999; break;
										}

										gbi.Amount = gbi.MaxAmount = amount;
									}
								}
							}
						}

						break;
					}
			}

			if (IsParagon)
			{
				IsParagon = false;
			}

			Timer.DelayCall(CheckMorph);
		}

		public override void AddCustomContextEntries(Mobile from, List<ContextMenuEntry> list)
		{
			if (from.Alive && IsActiveVendor)
			{
				if (SupportsBulkOrders(from))
				{
					list.Add(new BulkOrderInfoEntry(from, this));
				}

				if (IsActiveSeller)
				{
					list.Add(new VendorBuyEntry(from, this));
				}

				if (IsActiveBuyer)
				{
					list.Add(new VendorSellEntry(from, this));
				}
			}

			base.AddCustomContextEntries(from, list);
		}

		public virtual IShopSellInfo[] GetSellInfo()
		{
			return (IShopSellInfo[])m_ArmorSellInfo.ToArray(typeof(IShopSellInfo));
		}

		public virtual IBuyItemInfo[] GetBuyInfo()
		{
			return (IBuyItemInfo[])m_ArmorBuyInfo.ToArray(typeof(IBuyItemInfo));
		}
	}

	public class VendorInventory
	{
		public static readonly TimeSpan GracePeriod = TimeSpan.FromDays(7.0);

		private BaseHouse m_House;
		private string m_VendorName;
		private string m_ShopName;
		private Mobile m_Owner;

		private readonly List<Item> m_Items;
		private int m_Gold;

		private readonly DateTime m_ExpireTime;
		private readonly Timer m_ExpireTimer;

		public VendorInventory(BaseHouse house, Mobile owner, string vendorName, string shopName)
		{
			m_House = house;
			m_Owner = owner;
			m_VendorName = vendorName;
			m_ShopName = shopName;

			m_Items = new List<Item>();

			m_ExpireTime = DateTime.UtcNow + GracePeriod;
			m_ExpireTimer = new ExpireTimer(this, GracePeriod);
			m_ExpireTimer.Start();
		}

		public BaseHouse House
		{
			get => m_House;
			set => m_House = value;
		}

		public string VendorName
		{
			get => m_VendorName;
			set => m_VendorName = value;
		}

		public string ShopName
		{
			get => m_ShopName;
			set => m_ShopName = value;
		}

		public Mobile Owner
		{
			get => m_Owner;
			set => m_Owner = value;
		}

		public List<Item> Items => m_Items;

		public int Gold
		{
			get => m_Gold;
			set => m_Gold = value;
		}

		public DateTime ExpireTime => m_ExpireTime;

		public void AddItem(Item item)
		{
			item.Internalize();
			m_Items.Add(item);
		}

		public void Delete()
		{
			foreach (var item in Items)
			{
				item.Delete();
			}

			Items.Clear();
			Gold = 0;

			if (House != null)
			{
				House.VendorInventories.Remove(this);
			}

			m_ExpireTimer.Stop();
		}

		public void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_Owner);
			writer.Write(m_VendorName);
			writer.Write(m_ShopName);

			writer.Write(m_Items, true);
			writer.Write(m_Gold);

			writer.WriteDeltaTime(m_ExpireTime);
		}

		public VendorInventory(BaseHouse house, GenericReader reader)
		{
			m_House = house;

			var version = reader.ReadEncodedInt();

			m_Owner = reader.ReadMobile();
			m_VendorName = reader.ReadString();
			m_ShopName = reader.ReadString();

			m_Items = reader.ReadStrongItemList();
			m_Gold = reader.ReadInt();

			m_ExpireTime = reader.ReadDeltaTime();

			if (m_Items.Count == 0 && m_Gold == 0)
			{
				Timer.DelayCall(TimeSpan.Zero, Delete);
			}
			else
			{
				var delay = m_ExpireTime - DateTime.UtcNow;
				m_ExpireTimer = new ExpireTimer(this, delay > TimeSpan.Zero ? delay : TimeSpan.Zero);
				m_ExpireTimer.Start();
			}
		}

		private class ExpireTimer : Timer
		{
			private readonly VendorInventory m_Inventory;

			public ExpireTimer(VendorInventory inventory, TimeSpan delay) : base(delay)
			{
				m_Inventory = inventory;

				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				var house = m_Inventory.House;

				if (house != null)
				{
					if (m_Inventory.Gold > 0)
					{
						if (house.MovingCrate == null)
						{
							house.MovingCrate = new MovingCrate(house);
						}

						Banker.Deposit(house.MovingCrate, m_Inventory.Gold);
					}

					foreach (var item in m_Inventory.Items)
					{
						if (!item.Deleted)
						{
							house.DropToMovingCrate(item);
						}
					}

					m_Inventory.Gold = 0;
					m_Inventory.Items.Clear();
				}

				m_Inventory.Delete();
			}
		}
	}

	#region Server Vendor Sell And Buy Info

	public abstract class SBInfo
	{
		public static readonly List<SBInfo> Empty = new List<SBInfo>();

		public SBInfo()
		{
		}

		public abstract IShopSellInfo SellInfo { get; }
		public abstract List<GenericBuyInfo> BuyInfo { get; }
	}

	public class GenericSellInfo : IShopSellInfo
	{
		private readonly Dictionary<Type, int> m_Table = new Dictionary<Type, int>();
		private Type[] m_Types;

		public GenericSellInfo()
		{
		}

		public void Add(Type type, int price)
		{
			m_Table[type] = price;
			m_Types = null;
		}

		public int GetSellPriceFor(Item item)
		{
			var price = 0;
			m_Table.TryGetValue(item.GetType(), out price);

			if (item is BaseArmor)
			{
				var armor = (BaseArmor)item;

				if (armor.Quality == ArmorQuality.Low)
				{
					price = (int)(price * 0.60);
				}
				else if (armor.Quality == ArmorQuality.Exceptional)
				{
					price = (int)(price * 1.25);
				}

				price += 100 * (int)armor.Durability;

				price += 100 * (int)armor.ProtectionLevel;

				if (price < 1)
				{
					price = 1;
				}
			}
			else if (item is BaseWeapon)
			{
				var weapon = (BaseWeapon)item;

				if (weapon.Quality == WeaponQuality.Low)
				{
					price = (int)(price * 0.60);
				}
				else if (weapon.Quality == WeaponQuality.Exceptional)
				{
					price = (int)(price * 1.25);
				}

				price += 100 * (int)weapon.DurabilityLevel;

				price += 100 * (int)weapon.DamageLevel;

				if (price < 1)
				{
					price = 1;
				}
			}
			else if (item is BaseBeverage)
			{
				int price1 = price, price2 = price;

				if (item is Pitcher)
				{ price1 = 3; price2 = 5; }
				else if (item is BeverageBottle)
				{ price1 = 3; price2 = 3; }
				else if (item is Jug)
				{ price1 = 6; price2 = 6; }

				var bev = (BaseBeverage)item;

				if (bev.IsEmpty || bev.Content == BeverageType.Milk)
				{
					price = price1;
				}
				else
				{
					price = price2;
				}
			}

			return price;
		}

		public int GetBuyPriceFor(Item item)
		{
			return (int)(1.90 * GetSellPriceFor(item));
		}

		public Type[] Types
		{
			get
			{
				if (m_Types == null)
				{
					m_Types = new Type[m_Table.Keys.Count];
					m_Table.Keys.CopyTo(m_Types, 0);
				}

				return m_Types;
			}
		}

		public string GetNameFor(Item item)
		{
			if (item.Name != null)
			{
				return item.Name;
			}
			else
			{
				return item.LabelNumber.ToString();
			}
		}

		public bool IsSellable(Item item)
		{
			if (item.Nontransferable)
			{
				return false;
			}

			//if ( item.Hue != 0 )
			//return false;

			return IsInList(item.GetType());
		}

		public bool IsResellable(Item item)
		{
			if (item.Nontransferable)
			{
				return false;
			}

			//if ( item.Hue != 0 )
			//return false;

			return IsInList(item.GetType());
		}

		public bool IsInList(Type type)
		{
			return m_Table.ContainsKey(type);
		}
	}

	public class GenericBuyInfo : IBuyItemInfo
	{
		private class DisplayCache : Container
		{
			private static DisplayCache m_Cache;

			public static DisplayCache Cache
			{
				get
				{
					if (m_Cache == null || m_Cache.Deleted)
					{
						m_Cache = new DisplayCache();
					}

					return m_Cache;
				}
			}

			private Dictionary<Type, IEntity> m_Table;
			private List<Mobile> m_Mobiles;

			public DisplayCache() : base(0)
			{
				m_Table = new Dictionary<Type, IEntity>();
				m_Mobiles = new List<Mobile>();
			}

			public IEntity Lookup(Type key)
			{
				IEntity e = null;
				m_Table.TryGetValue(key, out e);
				return e;
			}

			public void Store(Type key, IEntity obj, bool cache)
			{
				if (cache)
				{
					m_Table[key] = obj;
				}

				if (obj is Item)
				{
					AddItem((Item)obj);
				}
				else if (obj is Mobile)
				{
					m_Mobiles.Add((Mobile)obj);
				}
			}

			public DisplayCache(Serial serial) : base(serial)
			{
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				for (var i = 0; i < m_Mobiles.Count; ++i)
				{
					m_Mobiles[i].Delete();
				}

				m_Mobiles.Clear();

				for (var i = Items.Count - 1; i >= 0; --i)
				{
					if (i < Items.Count)
					{
						Items[i].Delete();
					}
				}

				if (m_Cache == this)
				{
					m_Cache = null;
				}
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(0); // version

				writer.Write(m_Mobiles);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				var version = reader.ReadInt();

				m_Mobiles = reader.ReadStrongMobileList();

				for (var i = 0; i < m_Mobiles.Count; ++i)
				{
					m_Mobiles[i].Delete();
				}

				m_Mobiles.Clear();

				for (var i = Items.Count - 1; i >= 0; --i)
				{
					if (i < Items.Count)
					{
						Items[i].Delete();
					}
				}

				if (m_Cache == null)
				{
					m_Cache = this;
				}
				else
				{
					Delete();
				}

				m_Table = new Dictionary<Type, IEntity>();
			}
		}

		private Type m_Type;
		private string m_Name;
		private int m_Price;
		private int m_MaxAmount, m_Amount;
		private int m_ItemID;
		private int m_Hue;
		private object[] m_Args;
		private IEntity m_DisplayEntity;

		public virtual int ControlSlots => 0;

		public virtual bool CanCacheDisplay => false;  //return ( m_Args == null || m_Args.Length == 0 ); } 

		private bool IsDeleted(IEntity obj)
		{
			return obj.Deleted;
		}

		public void DeleteDisplayEntity()
		{
			if (m_DisplayEntity == null)
			{
				return;
			}

			m_DisplayEntity.Delete();
			m_DisplayEntity = null;
		}

		public IEntity GetDisplayEntity()
		{
			if (m_DisplayEntity != null && !IsDeleted(m_DisplayEntity))
			{
				return m_DisplayEntity;
			}

			var canCache = CanCacheDisplay;

			if (canCache)
			{
				m_DisplayEntity = DisplayCache.Cache.Lookup(m_Type);
			}

			if (m_DisplayEntity == null || IsDeleted(m_DisplayEntity))
			{
				m_DisplayEntity = GetEntity();
			}

			DisplayCache.Cache.Store(m_Type, m_DisplayEntity, canCache);

			return m_DisplayEntity;
		}

		public Type Type
		{
			get => m_Type;
			set => m_Type = value;
		}

		public string Name
		{
			get => m_Name;
			set => m_Name = value;
		}

		public int DefaultPrice => m_PriceScalar;

		private int m_PriceScalar;

		public int PriceScalar
		{
			get => m_PriceScalar;
			set => m_PriceScalar = value;
		}

		public int Price
		{
			get
			{
				if (m_PriceScalar != 0)
				{
					if (m_Price > 5000000)
					{
						long price = m_Price;

						price *= m_PriceScalar;
						price += 50;
						price /= 100;

						if (price > Int32.MaxValue)
						{
							price = Int32.MaxValue;
						}

						return (int)price;
					}

					return (((m_Price * m_PriceScalar) + 50) / 100);
				}

				return m_Price;
			}
			set => m_Price = value;
		}

		public int ItemID
		{
			get => m_ItemID;
			set => m_ItemID = value;
		}

		public int Hue
		{
			get => m_Hue;
			set => m_Hue = value;
		}

		public int Amount
		{
			get => m_Amount;
			set { if (value < 0) { value = 0; } m_Amount = value; }
		}

		public int MaxAmount
		{
			get => m_MaxAmount;
			set => m_MaxAmount = value;
		}

		public object[] Args
		{
			get => m_Args;
			set => m_Args = value;
		}

		public GenericBuyInfo(Type type, int price, int amount, int itemID, int hue) : this(null, type, price, amount, itemID, hue, null)
		{
		}

		public GenericBuyInfo(string name, Type type, int price, int amount, int itemID, int hue) : this(name, type, price, amount, itemID, hue, null)
		{
		}

		public GenericBuyInfo(Type type, int price, int amount, int itemID, int hue, object[] args) : this(null, type, price, amount, itemID, hue, args)
		{
		}

		public GenericBuyInfo(string name, Type type, int price, int amount, int itemID, int hue, object[] args)
		{
			m_Type = type;
			m_Price = price;
			m_MaxAmount = m_Amount = amount;
			m_ItemID = itemID;
			m_Hue = hue;
			m_Args = args;

			if (name == null)
			{
				m_Name = itemID < 0x4000 ? (1020000 + itemID).ToString() : (1078872 + itemID).ToString();
			}
			else
			{
				m_Name = name;
			}
		}

		//get a new instance of an object (we just bought it)
		public virtual IEntity GetEntity()
		{
			if (m_Args == null || m_Args.Length == 0)
			{
				return (IEntity)Activator.CreateInstance(m_Type);
			}

			return (IEntity)Activator.CreateInstance(m_Type, m_Args);
			//return (Item)Activator.CreateInstance( m_Type );
		}

		//Attempt to restock with item, (return true if restock sucessful)
		public bool Restock(Item item, int amount)
		{
			return false;
			/*if ( item.GetType() == m_Type )
			{
				if ( item is BaseWeapon )
				{
					BaseWeapon weapon = (BaseWeapon)item;

					if ( weapon.Quality == WeaponQuality.Low || weapon.Quality == WeaponQuality.Exceptional || (int)weapon.DurabilityLevel > 0 || (int)weapon.DamageLevel > 0 || (int)weapon.AccuracyLevel > 0 )
						return false;
				}

				if ( item is BaseArmor )
				{
					BaseArmor armor = (BaseArmor)item;

					if ( armor.Quality == ArmorQuality.Low || armor.Quality == ArmorQuality.Exceptional || (int)armor.Durability > 0 || (int)armor.ProtectionLevel > 0 )
						return false;
				}

				m_Amount += amount;

				return true;
			}
			else
			{
				return false;
			}*/
		}

		public void OnRestock()
		{
			if (m_Amount <= 0)
			{
				/*
					Core.ML using this vendor system is undefined behavior, so being
					as it lends itself to an abusable exploit to cause ingame havok
					and the stackable items are not found to be over 20 items, this is
					changed until there is a better solution.
				*/

				object Obj_Disp = GetDisplayEntity();

				if (Core.ML && Obj_Disp is Item && !(Obj_Disp as Item).Stackable)
				{
					m_MaxAmount = Math.Min(20, m_MaxAmount);
				}
				else
				{
					m_MaxAmount = Math.Min(999, m_MaxAmount * 2);
				}
			}
			else
			{
				/* NOTE: According to UO.com, the quantity is halved if the item does not reach 0
				 * Here we implement differently: the quantity is halved only if less than half
				 * of the maximum quantity was bought. That is, if more than half is sold, then
				 * there's clearly a demand and we should not cut down on the stock.
				 */

				var halfQuantity = m_MaxAmount;

				if (halfQuantity >= 999)
				{
					halfQuantity = 640;
				}
				else if (halfQuantity > 20)
				{
					halfQuantity /= 2;
				}

				if (m_Amount >= halfQuantity)
				{
					m_MaxAmount = halfQuantity;
				}
			}

			m_Amount = m_MaxAmount;
		}
	}

	public class AnimalBuyInfo : GenericBuyInfo
	{
		private readonly int m_ControlSlots;

		public AnimalBuyInfo(int controlSlots, Type type, int price, int amount, int itemID, int hue) : this(controlSlots, null, type, price, amount, itemID, hue)
		{
		}

		public AnimalBuyInfo(int controlSlots, string name, Type type, int price, int amount, int itemID, int hue) : base(name, type, price, amount, itemID, hue)
		{
			m_ControlSlots = controlSlots;
		}

		public override int ControlSlots => m_ControlSlots;
	}

	public class BeverageBuyInfo : GenericBuyInfo
	{
		private readonly BeverageType m_Content;

		public override bool CanCacheDisplay => false;

		public BeverageBuyInfo(Type type, BeverageType content, int price, int amount, int itemID, int hue) : this(null, type, content, price, amount, itemID, hue)
		{
		}

		public BeverageBuyInfo(string name, Type type, BeverageType content, int price, int amount, int itemID, int hue) : base(name, type, price, amount, itemID, hue)
		{
			m_Content = content;

			if (type == typeof(Pitcher))
			{
				Name = (1048128 + (int)content).ToString();
			}
			else if (type == typeof(BeverageBottle))
			{
				Name = (1042959 + (int)content).ToString();
			}
			else if (type == typeof(Jug))
			{
				Name = (1042965 + (int)content).ToString();
			}
		}

		public override IEntity GetEntity()
		{
			return (IEntity)Activator.CreateInstance(Type, new object[] { m_Content });
		}
	}

	public class PresetMapBuyInfo : GenericBuyInfo
	{
		private readonly PresetMapEntry m_Entry;

		public override bool CanCacheDisplay => false;

		public PresetMapBuyInfo(PresetMapEntry entry, int price, int amount) : base(entry.Name.ToString(), null, price, amount, 0x14EC, 0)
		{
			m_Entry = entry;
		}

		public override IEntity GetEntity()
		{
			return new PresetMap(m_Entry);
		}
	}

	#endregion
}