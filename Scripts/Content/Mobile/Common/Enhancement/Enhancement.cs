using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Items
{
	public static class Enhancement
	{
		public static readonly Dictionary<Mobile, List<EnhancementAttributes>> EnhancementList = new();

		public static bool AddMobile(Mobile m)
		{
			if (!EnhancementList.ContainsKey(m))
			{
				EnhancementList[m] = new();
				return true;
			}

			return false;
		}

		/// <summary>
		/// Removes the mobile and/or attributes from the dictionary
		/// </summary>
		/// <param name="m"></param>
		/// <param name="title">null or default value will remove the entire entry. Add the title arg to remove only that element from the list.</param>
		/// <returns></returns>
		public static bool RemoveMobile(Mobile m, string title = null)
		{
			if (EnhancementList.TryGetValue(m, out var list) && list.Count > 0)
			{
				if (title != null)
				{
					var match = list.Find(attrs => attrs.Title == title);

					if (match != null && list.Remove(match))
					{
						m.RemoveStatMod("MagicalEnhancementStr");
						m.RemoveStatMod("MagicalEnhancementDex");
						m.RemoveStatMod("MagicalEnhancementInt");
					}
				}

				if (list.Count == 0 || title == null)
				{
					_ = EnhancementList.Remove(m);
				}

				m.CheckStatTimers();
				m.UpdateResistances();
				m.Delta(MobileDelta.Stat | MobileDelta.WeaponDamage | MobileDelta.Hits | MobileDelta.Stam | MobileDelta.Mana);

				m.Items.ForEach(i => i.InvalidateProperties());

				return true;
			}

			return false;
		}

		public static int GetValue(Mobile m, AosAttribute att)
		{
			if (m == null)
			{
				return 0;
			}

			if (EnhancementList.TryGetValue(m, out var list) && list.Count > 0)
			{
				return list.Sum(attrs => attrs.Attributes[att]);
			}

			return 0;
		}

		public static void SetValue(Mobile m, AosAttribute att, int value, string title)
		{
			if (!EnhancementList.TryGetValue(m, out var list))
			{
				EnhancementList[m] = list = new();
			}

			var match = list.Find(attrs => attrs.Title == title);

			if (match != null)
			{
				match.Attributes[att] = value;
			}
			else
			{
				match = new EnhancementAttributes(m, title);

				match.Attributes[att] = value;

				list.Add(match);
			}

			switch (att)
			{
				case AosAttribute.BonusStr:
					{
						m.RemoveStatMod("MagicalEnhancementStr");

						m.AddStatMod(new StatMod(StatType.Str, "MagicalEnhancementStr", value, TimeSpan.Zero));

						break;
					}
				case AosAttribute.BonusDex:
					{
						m.RemoveStatMod("MagicalEnhancementDex");

						m.AddStatMod(new StatMod(StatType.Dex, "MagicalEnhancementDex", value, TimeSpan.Zero));

						break;
					}
				case AosAttribute.BonusInt:
					{
						m.RemoveStatMod("MagicalEnhancementInt");

						m.AddStatMod(new StatMod(StatType.Int, "MagicalEnhancementInt", value, TimeSpan.Zero));

						break;
					}
			}

			m.CheckStatTimers();
			m.UpdateResistances();
			m.Delta(MobileDelta.Stat | MobileDelta.WeaponDamage | MobileDelta.Hits | MobileDelta.Stam | MobileDelta.Mana);
		}

		public static int GetValue(Mobile m, AosWeaponAttribute att)
		{
			if (m == null)
			{
				return 0;
			}

			if (EnhancementList.TryGetValue(m, out var list) && list.Count > 0)
			{
				return list.Sum(attrs => attrs.WeaponAttributes[att]);
			}

			return 0;
		}

		public static void SetValue(Mobile m, AosWeaponAttribute att, int value, string title)
		{
			if (!EnhancementList.TryGetValue(m, out var list))
			{
				EnhancementList[m] = list = new();
			}

			var match = list.Find(attrs => attrs.Title == title);

			if (match != null)
			{
				match.WeaponAttributes[att] = value;
			}
			else
			{
				match = new EnhancementAttributes(m, title);

				match.WeaponAttributes[att] = value;

				list.Add(match);
			}

			m.CheckStatTimers();
			m.UpdateResistances();
			m.Delta(MobileDelta.Stat | MobileDelta.WeaponDamage | MobileDelta.Hits | MobileDelta.Stam | MobileDelta.Mana);
		}

		public static int GetValue(Mobile m, AosArmorAttribute att)
		{
			if (m == null)
			{
				return 0;
			}

			if (EnhancementList.TryGetValue(m, out var list) && list.Count > 0)
			{
				return list.Sum(attrs => attrs.ArmorAttributes[att]);
			}

			return 0;
		}

		public static void SetValue(Mobile m, AosArmorAttribute att, int value, string title)
		{
			if (!EnhancementList.TryGetValue(m, out var list))
			{
				EnhancementList[m] = list = new();
			}

			var match = list.Find(attrs => attrs.Title == title);

			if (match != null)
			{
				match.ArmorAttributes[att] = value;
			}
			else
			{
				match = new EnhancementAttributes(m, title);

				match.ArmorAttributes[att] = value;

				list.Add(match);
			}

			m.CheckStatTimers();
			m.UpdateResistances();
			m.Delta(MobileDelta.Stat | MobileDelta.WeaponDamage | MobileDelta.Hits | MobileDelta.Stam | MobileDelta.Mana);
		}
	}
}