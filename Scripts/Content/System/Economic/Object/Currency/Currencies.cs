
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Items
{
	/// <summary>
	/// <para>A collection of currency type definitions and their exchange rates relative to <see cref="Gold"/>.</para>
	/// <para>Only non-abstract <see cref="Item"/> types are supported as currencies.</para>
	/// <para>The <see cref="Gold"/> type cannot be added to this collection.</para>
	/// <para>The amount specified by each entry represents an exchange rate.</para>
	/// </summary>
	public class Currencies : TypeAmounts
	{
		public static readonly Type GoldType = typeof(Gold);

		/// <summary>
		/// Defaults be used when constructing a new <see cref="Currencies"/> collection using the default constructor. 
		/// </summary>
		public static readonly Currencies DefaultEntries = new();

		/// <summary>
		/// Limits the maximum value for the exchange rate of any given currency entry in a <see cref="Currencies"/> collection.
		/// </summary>
		public const int MaxExchangeRate = 1000;

		public Currencies()
		{
			DefaultEntries.CopyTo(this);
		}

		public Currencies(params TypeAmount[] entries)
			: base(entries)
		{ }

		public Currencies(IEnumerable<TypeAmount> entries)
			: base(entries)
		{ }

		public SelectCurrencyGump BeginSelectCurrency(Mobile player, SelectCurrencyCallback callback)
		{
			if (player?.Deleted != false || !player.Player)
			{
				return null;
			}

			var gump = new SelectCurrencyGump(player, 0, this, callback);

			if (player.SendGump(gump, false))
			{
				return gump;
			}

			return null;
		}

		public override bool IsValidType(Type type)
		{
			return base.IsValidType(type) && !type.IsAbstract && type.IsAssignableTo(typeof(Item)) && !type.IsAssignableTo(GoldType);
		}

		public override bool Set(Type type, int amount)
		{
			amount = Math.Clamp(amount, 0, MaxExchangeRate);

			return base.Set(type, amount);
		}

		public bool ConvertCurrencyToGold(Type sourceCurrency, int sourceAmount, out int goldAmount)
		{
			if (sourceCurrency == GoldType)
			{
				goldAmount = sourceAmount;
			}
			else if (TryGetAmount(sourceCurrency, out var rate))
			{
				goldAmount = (int)(sourceAmount / (rate / 100.0));
			}
			else
			{
				goldAmount = 0;
			}

			return goldAmount > 0;
		}

		public bool ConvertGoldToCurrency(int goldAmount, Type destCurrency, out int destAmount)
		{
			if (destCurrency == GoldType)
			{
				destAmount = goldAmount;
			}
			else if (TryGetAmount(destCurrency, out var rate))
			{
				destAmount = (int)(goldAmount * (rate / 100.0));
			}
			else
			{
				destAmount = 0;
			}

			return destAmount > 0;
		}

		public bool ConvertCurrency(Type sourceCurrency, int sourceAmount, Type destCurrency, out int destAmount)
		{
			if (ConvertCurrencyToGold(sourceCurrency, sourceAmount, out var goldAmount))
			{
				return ConvertGoldToCurrency(goldAmount, destCurrency, out destAmount);
			}

			destAmount = 0;

			return false;
		}

		public bool Withdraw(Mobile m, Type type, int amount, bool message)
		{
			var success = false;

			if (type == GoldType)
			{
				success = Banker.Withdraw(m, amount);
			}
			else if (IndexOf(type) >= 0)
			{
				var bank = m.FindBankNoCreate();

				if (bank?.Deleted == false)
				{
					success = bank.ConsumeTotal(type, amount);
				}
			}

			if (message)
			{
				if (success)
				{
					m.SendMessage(0x55, $"{amount:N0} {Utility.FriendlyName(type)} was withdrawn from your bank.");
				}
				else
				{
					m.SendMessage(0x22, $"You do not have enough {Utility.FriendlyName(type)} in your bank.");
				}
			}

			return success;
		}

		public bool Deposit(Mobile m, Type type, int amount, bool message)
		{
			return Deposit(m, null, type, amount, message);
		}

		public bool Deposit(Mobile m, Container cont, Type type, int amount, bool message)
		{
			if (cont?.Deleted != false)
			{
				cont = m.Backpack;
			}

			if (cont?.Deleted != false)
			{
				cont = m.Player ? m.BankBox : m.FindBankNoCreate();
			}

			if (cont?.Deleted != false)
			{
				return false;
			}

			var success = false;

			if (type == GoldType)
			{
				if (m.Player && cont == m.BankBox)
				{
					success = Banker.Deposit(m, amount);
				}
				else
				{
					Banker.Deposit(cont, amount);

					success = true;
				}
			}
			else if (IndexOf(type) >= 0)
			{
				var items = new HashSet<Item>();

				var remaining = amount;

				while (remaining > 0)
				{
					var item = Loot.Construct(type);

					if (item == null)
					{
						break;
					}

					if (item.Stackable)
					{
						item.Amount = Math.Min(60000, remaining);
					}

					_ = items.Add(item);

					if (cont.CheckHold(m, item, false, true))
					{
						remaining -= item.Amount;

						cont.DropItem(item);
					}
					else
					{
						break;
					}
				}

				success = remaining == 0;

				if (!success)
				{
					foreach (var item in items)
					{
						item.Delete();
					}
				}

				items.Clear();
				items.TrimExcess();
			}

			if (message)
			{
				if (cont is BankBox || cont.ParentsContain<BankBox>())
				{
					if (success)
					{
						m.SendMessage(0x55, $"{amount:N0} {Utility.FriendlyName(type)} was deposited to your bank.");
					}
					else
					{
						m.SendMessage(0x22, $"Could not deposit the {Utility.FriendlyName(type)} to your bank.");
					}
				}
				else
				{
					if (success)
					{
						m.SendMessage(0x55, $"You received {amount:N0} {Utility.FriendlyName(type)}.");
					}
					else
					{
						m.SendMessage(0x22, $"You have no room for the {Utility.FriendlyName(type)}.");
					}
				}
			}

			return success;
		}
	}

	public delegate void SelectCurrencyCallback(Mobile player, Currencies currencies, Type currency);

	public sealed class SelectCurrencyGump : BaseGridGump
	{
		private const int EntriesPerPage = 10;

		private readonly Mobile m_Player;

		private readonly int m_Page;

		private readonly Currencies m_Currencies;

		private readonly SelectCurrencyCallback m_Callback;

		private Dictionary<int, Action> m_Handlers;

		public override int BorderSize => 10;
		public override int OffsetSize => 1;

		public override int EntryHeight => 20;

		public override int OffsetGumpID => 0x2430;
		public override int HeaderGumpID => 0x243A;
		public override int EntryGumpID => 0x2458;
		public override int BackGumpID => 0x2486;

		public override int TextHue => 0;
		public override int TextOffsetX => 2;

		public const int PageLeftID1 = 0x25EA;
		public const int PageLeftID2 = 0x25EB;
		public const int PageLeftWidth = 16;
		public const int PageLeftHeight = 16;

		public const int PageRightID1 = 0x25E6;
		public const int PageRightID2 = 0x25E7;
		public const int PageRightWidth = 16;
		public const int PageRightHeight = 16;

		public SelectCurrencyGump(Mobile player, int page, Currencies currencies, SelectCurrencyCallback callback)
			: base(100, 100)
		{
			m_Player = player;
			m_Page = page;
			m_Currencies = currencies;
			m_Callback = callback;

			Closable = false;
			Disposable = false;
			Dragable = false;
			Resizable = false;

			AddNewPage();

			if (m_Page > 0)
			{
				AddEntryButton(20, PageLeftID1, PageLeftID2, 1, PageLeftWidth, PageLeftHeight);
			}
			else
			{
				AddEntryHeader(20);
			}

			AddEntryHtml(160, Center($"Page {m_Page + 1} of {(m_Currencies.Count + EntriesPerPage - 1) / EntriesPerPage}"));

			if ((m_Page + 1) * EntriesPerPage < m_Currencies.Count)
			{
				AddEntryButton(20, PageRightID1, PageRightID2, 2, PageRightWidth, PageRightHeight);
			}
			else
			{
				AddEntryHeader(20);
			}

			AddNewLine();
			AddEntryHtml(20 + OffsetSize + 160, "Currency<div align=right>GP %</div>");
			AddEntryHeader(20);

			AddNewLine();
			AddEntryHtml(20 + OffsetSize + 160, $"{Utility.FriendlyName(Currencies.GoldType)}<div align=right>{1.0:P}</div>");
			AddEntryButton(20, PageRightID1, PageRightID2, 3, PageRightWidth, PageRightHeight);

			var index = m_Page * EntriesPerPage;

			foreach (var entry in m_Currencies.Where(e => e.IsActive).OrderBy(e => e.Type.Name).Skip(index).Take(EntriesPerPage))
			{
				var bid = 4 + index++;
				var type = entry.Type;
				var rate = entry.Amount / 100.0;

				AddNewLine();
				AddEntryHtml(20 + OffsetSize + 160, $"{Utility.FriendlyName(type)}<div align=right>{rate:P}</div>");
				AddEntryButton(20, PageRightID1, PageRightID2, bid, PageRightWidth, PageRightHeight);

				m_Handlers ??= new();
				m_Handlers[bid] = () => m_Callback?.Invoke(m_Player, m_Currencies, type);
			}

			FinishPage();
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			switch (info.ButtonID)
			{
				case 0:
					{
						_ = m_Player.CloseGump(typeof(SelectCurrencyGump));

						return;
					}
				case 1:
					{
						if (m_Page > 0)
						{
							_ = m_Player.SendGump(new SelectCurrencyGump(m_Player, m_Page - 1, m_Currencies, m_Callback));
						}
						else
						{
							_ = m_Player.SendGump(new SelectCurrencyGump(m_Player, m_Page, m_Currencies, m_Callback));
						}

						return;
					}
				case 2:
					{
						if ((m_Page + 1) * EntriesPerPage < m_Currencies.Count)
						{
							_ = m_Player.SendGump(new SelectCurrencyGump(m_Player, m_Page + 1, m_Currencies, m_Callback));
						}
						else
						{
							_ = m_Player.SendGump(new SelectCurrencyGump(m_Player, m_Page, m_Currencies, m_Callback));
						}

						return;
					}
				case 3:
					{
						m_Callback?.Invoke(m_Player, m_Currencies, Currencies.GoldType);

						return;
					}
			}

			if (m_Handlers != null)
			{
				if (m_Handlers.TryGetValue(info.ButtonID - 4, out var handler))
				{
					handler?.Invoke();
				}

				m_Handlers.Clear();
				m_Handlers.TrimExcess();

				m_Handlers = null;
			}
		}
	}
}