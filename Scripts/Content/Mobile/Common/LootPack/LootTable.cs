using Server.Engines.Publishing;
using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static BaseWand RandomWand() { return Construct(m_SpellWands) as BaseWand; }

		public static BaseClothing RandomClothing() { return Construct(m_Clothing) as BaseClothing; }

		public static BaseWeapon RandomRangedWeapon() { return Construct(m_RangedWeapons) as BaseWeapon; }

		public static BaseWeapon RandomWeapon() { return Construct(m_MeleeWeapons) as BaseWeapon; }

		public static BaseArmor RandomArmor() { return Construct(m_Armor) as BaseArmor; }

		public static BaseJewel RandomJewelry() { return Construct(m_Jewelry) as BaseJewel; }

		public static BaseHat RandomHat() { return Construct(m_Clothing) as BaseHat; }

		public static BaseShield RandomShield() { return Construct(m_Armor) as BaseShield; }

		public static BaseArmor RandomArmorOrShield() { return Construct(m_Armor) as BaseArmor; }

		public static Item RandomArmorOrHat() { return Construct(m_Armor, m_Clothing); }

		public static Item RandomWeaponOrJewelry() { return Construct(m_MeleeWeapons, m_Jewelry); }

		public static Item RandomArmorOrShieldOrJewelry() { return Construct(m_Armor, m_Clothing, m_Jewelry); }

		public static Item RandomArmorOrShieldOrWeapon() { return Construct(m_MeleeWeapons, m_RangedWeapons, m_Armor, m_Clothing); }

		public static Item RandomArmorOrShieldOrWeaponOrJewelry() { return Construct(m_MeleeWeapons, m_RangedWeapons, m_Armor, m_Clothing, m_Jewelry); }

		public static Item RandomGem() { return Construct(m_Gems); }

		public static Item RandomReagent() { return Construct(m_Reagents); }

		public static Item RandomNecromancyReagent() { return Construct(m_Reagents); }

		public static Item RandomPossibleReagent() { return Construct(m_Reagents); }

		public static Item RandomPotion() { return Construct(m_Potions); }

		public static BaseInstrument RandomInstrument() { return Construct(m_Instruments) as BaseInstrument; }

		public static Item RandomStatue() { return Construct(m_Statues); }

		public static BaseBook RandomLibraryBook() { return Construct(m_LibraryBooks) as BaseBook; }

		public static Item ChestOfHeirloomsContains() { return RandomArmorOrShieldOrWeaponOrJewelry(); }

		public static Item RandomScroll(SpellSchool school)
		{
			if (school == SpellSchool.Invalid)
			{
				return new BlankScroll();
			}

			var minID = (SpellName)school;
			var maxID = minID + (SpellRegistry.CountSpells(school) - 1);

			return RandomScroll(minID, maxID);
		}

		public static Item RandomScroll(SpellCircle circle)
		{
			return RandomScroll(circle, circle);
		}

		public static Item RandomScroll(SpellCircle min, SpellCircle max)
		{
			if (min > max)
			{
				(min, max) = (max, min);
			}

			if (min == SpellCircle.Invalid)
			{
				return new BlankScroll();
			}

			if (max == SpellCircle.Invalid)
			{
				max = min;
			}

			var minID = (SpellName)((int)min * 8);
			var maxID = (SpellName)((int)max * 8);

			return RandomScroll(minID, maxID);
		}

		public static Item RandomScroll(SpellName min, SpellName max)
		{
			if (min > max)
			{
				(min, max) = (max, min);
			}

			if (min == SpellName.Invalid)
			{
				return new BlankScroll();
			}

			if (max == SpellName.Invalid)
			{
				max = min;
			}

			var id = Utility.RandomMinMax(min, max);

			if (m_ScrollTypesByID.TryGetValue(id, out var type))
			{
				return Construct(type);
			}

			return new BlankScroll();
		}

		public static BaseTalisman RandomTalisman()
		{
			var talisman = new BaseTalisman(BaseTalisman.GetRandomItemID()) {
				Summoner = BaseTalisman.GetRandomSummoner()
			};

			if (talisman.Summoner.IsEmpty)
			{
				talisman.Removal = BaseTalisman.GetRandomRemoval();

				if (talisman.Removal != TalismanRemoval.None)
				{
					talisman.MaxCharges = BaseTalisman.GetRandomCharges();
					talisman.MaxChargeTime = 1200;
				}
			}
			else
			{
				talisman.MaxCharges = Utility.RandomMinMax(10, 50);

				if (talisman.Summoner.IsItem)
				{
					talisman.MaxChargeTime = 60;
				}
				else
				{
					talisman.MaxChargeTime = 1800;
				}
			}

			talisman.Blessed = BaseTalisman.GetRandomBlessed();
			talisman.Slayer = BaseTalisman.GetRandomSlayer();
			talisman.Protection = BaseTalisman.GetRandomProtection();
			talisman.Killer = BaseTalisman.GetRandomKiller();
			talisman.Skill = BaseTalisman.GetRandomSkill();
			talisman.ExceptionalBonus = BaseTalisman.GetRandomExceptional();
			talisman.SuccessBonus = BaseTalisman.GetRandomSuccessful();
			talisman.Charges = talisman.MaxCharges;

			return talisman;
		}
	}

	public partial class LootPack
	{
		public static LootPack Poor => Core.SE ? SePoor : Core.AOS ? AosPoor : OldPoor;

		public static LootPack Meager => Core.SE ? SeMeager : Core.AOS ? AosMeager : OldMeager;

		public static LootPack Average => Core.SE ? SeAverage : Core.AOS ? AosAverage : OldAverage;

		public static LootPack Rich => Core.SE ? SeRich : Core.AOS ? AosRich : OldRich;

		public static LootPack FilthyRich => Core.SE ? SeFilthyRich : Core.AOS ? AosFilthyRich : OldFilthyRich;

		public static LootPack UltraRich => Core.SE ? SeUltraRich : Core.AOS ? AosUltraRich : OldUltraRich;

		public static LootPack SuperBoss => Core.SE ? SeSuperBoss : Core.AOS ? AosSuperBoss : OldSuperBoss;

		public static readonly LootPackItem[] Gold = new LootPackItem[]
			{
				new LootPackItem( typeof( Gold ), 1 )
			};

		public static readonly LootPackItem[] Instruments = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseInstrument ), 1 )
			};

		public static readonly LootPackItem[] LowScrollItems = new LootPackItem[]
			{
				new LootPackItem( typeof( ClumsyScroll ), 1 )
			};

		public static readonly LootPackItem[] MedScrollItems = new LootPackItem[]
			{
				new LootPackItem( typeof( ArchCureScroll ), 1 )
			};

		public static readonly LootPackItem[] HighScrollItems = new LootPackItem[]
			{
				new LootPackItem( typeof( SummonAirElementalScroll ), 1 )
			};

		public static readonly LootPackItem[] GemItems = new LootPackItem[]
			{
				new LootPackItem( typeof( Amber ), 1 )
			};

		public static readonly LootPackItem[] PotionItems = new LootPackItem[]
			{
				new LootPackItem( typeof( AgilityPotion ), 1 ),
				new LootPackItem( typeof( StrengthPotion ), 1 ),
				new LootPackItem( typeof( RefreshPotion ), 1 ),
				new LootPackItem( typeof( LesserCurePotion ), 1 ),
				new LootPackItem( typeof( LesserHealPotion ), 1 ),
				new LootPackItem( typeof( LesserPoisonPotion ), 1 )
			};

		/// T2A Magic Items
		public static readonly LootPackItem[] OldMagicItems = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseJewel ), 1 ),
				new LootPackItem( typeof( BaseArmor ), 4 ),
				new LootPackItem( typeof( BaseWeapon ), 3 ),
				new LootPackItem( typeof( BaseRanged ), 1 ),
				new LootPackItem( typeof( BaseShield ), 1 )
			};

		/// AOS Magic Items
		public static readonly LootPackItem[] AosMagicItemsPoor = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseWeapon ), 3 ),
				new LootPackItem( typeof( BaseRanged ), 1 ),
				new LootPackItem( typeof( BaseArmor ), 4 ),
				new LootPackItem( typeof( BaseShield ), 1 ),
				new LootPackItem( typeof( BaseJewel ), 2 )
			};

		public static readonly LootPackItem[] AosMagicItemsMeagerType1 = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseWeapon ), 56 ),
				new LootPackItem( typeof( BaseRanged ), 14 ),
				new LootPackItem( typeof( BaseArmor ), 81 ),
				new LootPackItem( typeof( BaseShield ), 11 ),
				new LootPackItem( typeof( BaseJewel ), 42 )
			};

		public static readonly LootPackItem[] AosMagicItemsMeagerType2 = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseWeapon ), 28 ),
				new LootPackItem( typeof( BaseRanged ), 7 ),
				new LootPackItem( typeof( BaseArmor ), 40 ),
				new LootPackItem( typeof( BaseShield ), 5 ),
				new LootPackItem( typeof( BaseJewel ), 21 )
			};

		public static readonly LootPackItem[] AosMagicItemsAverageType1 = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseWeapon ), 90 ),
				new LootPackItem( typeof( BaseRanged ), 23 ),
				new LootPackItem( typeof( BaseArmor ), 130 ),
				new LootPackItem( typeof( BaseShield ), 17 ),
				new LootPackItem( typeof( BaseJewel ), 68 )
			};

		public static readonly LootPackItem[] AosMagicItemsAverageType2 = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseWeapon ), 54 ),
				new LootPackItem( typeof( BaseRanged ), 13 ),
				new LootPackItem( typeof( BaseArmor ), 77 ),
				new LootPackItem( typeof( BaseShield ), 10 ),
				new LootPackItem( typeof( BaseJewel ), 40 )
			};

		public static readonly LootPackItem[] AosMagicItemsRichType1 = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseWeapon ), 211 ),
				new LootPackItem( typeof( BaseRanged ), 53 ),
				new LootPackItem( typeof( BaseArmor ), 303 ),
				new LootPackItem( typeof( BaseShield ), 39 ),
				new LootPackItem( typeof( BaseJewel ), 158 )
			};

		public static readonly LootPackItem[] AosMagicItemsRichType2 = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseWeapon ), 170 ),
				new LootPackItem( typeof( BaseRanged ), 43 ),
				new LootPackItem( typeof( BaseArmor ), 245 ),
				new LootPackItem( typeof( BaseShield ), 32 ),
				new LootPackItem( typeof( BaseJewel ), 128 )
			};

		public static readonly LootPackItem[] AosMagicItemsFilthyRichType1 = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseWeapon ), 219 ),
				new LootPackItem( typeof( BaseRanged ), 55 ),
				new LootPackItem( typeof( BaseArmor ), 315 ),
				new LootPackItem( typeof( BaseShield ), 41 ),
				new LootPackItem( typeof( BaseJewel ), 164 )
			};

		public static readonly LootPackItem[] AosMagicItemsFilthyRichType2 = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseWeapon ), 239 ),
				new LootPackItem( typeof( BaseRanged ), 60 ),
				new LootPackItem( typeof( BaseArmor ), 343 ),
				new LootPackItem( typeof( BaseShield ), 90 ),
				new LootPackItem( typeof( BaseJewel ), 45 )
			};

		public static readonly LootPackItem[] AosMagicItemsUltraRich = new LootPackItem[]
			{
				new LootPackItem( typeof( BaseWeapon ), 276 ),
				new LootPackItem( typeof( BaseRanged ), 69 ),
				new LootPackItem( typeof( BaseArmor ), 397 ),
				new LootPackItem( typeof( BaseShield ), 52 ),
				new LootPackItem( typeof( BaseJewel ), 207 )
			};

		/// ML Definitions
		public static readonly LootPack MlRich = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,                     100.00, "4d50+450" ),
				new LootPackEntry( false, AosMagicItemsRichType1,   100.00, 1, 3, 0, 75 ),
				new LootPackEntry( false, AosMagicItemsRichType1,    80.00, 1, 3, 0, 75 ),
				new LootPackEntry( false, AosMagicItemsRichType1,    60.00, 1, 5, 0, 100 ),
				new LootPackEntry( false, Instruments,                1.00, 1 )
			});

		/// SE Definitions
		public static readonly LootPack SePoor = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,                     100.00, "2d10+20" ),
				new LootPackEntry( false, AosMagicItemsPoor,          1.00, 1, 5, 0, 100 ),
				new LootPackEntry( false, Instruments,                0.02, 1 )
			});

		public static readonly LootPack SeMeager = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,                     100.00, "4d10+40" ),
				new LootPackEntry( false, AosMagicItemsMeagerType1,  20.40, 1, 2, 0, 50 ),
				new LootPackEntry( false, AosMagicItemsMeagerType2,  10.20, 1, 5, 0, 100 ),
				new LootPackEntry( false, Instruments,                0.10, 1 )
			});

		public static readonly LootPack SeAverage = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,                     100.00, "8d10+100" ),
				new LootPackEntry( false, AosMagicItemsAverageType1, 32.80, 1, 3, 0, 50 ),
				new LootPackEntry( false, AosMagicItemsAverageType1, 32.80, 1, 4, 0, 75 ),
				new LootPackEntry( false, AosMagicItemsAverageType2, 19.50, 1, 5, 0, 100 ),
				new LootPackEntry( false, Instruments,                0.40, 1 )
			});

		public static readonly LootPack SeRich = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,                     100.00, "15d10+225" ),
				new LootPackEntry( false, AosMagicItemsRichType1,    76.30, 1, 4, 0, 75 ),
				new LootPackEntry( false, AosMagicItemsRichType1,    76.30, 1, 4, 0, 75 ),
				new LootPackEntry( false, AosMagicItemsRichType2,    61.70, 1, 5, 0, 100 ),
				new LootPackEntry( false, Instruments,                1.00, 1 )
			});

		public static readonly LootPack SeFilthyRich = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,                        100.00, "3d100+400" ),
				new LootPackEntry( false, AosMagicItemsFilthyRichType1, 79.50, 1, 5, 0, 100 ),
				new LootPackEntry( false, AosMagicItemsFilthyRichType1, 79.50, 1, 5, 0, 100 ),
				new LootPackEntry( false, AosMagicItemsFilthyRichType2, 77.60, 1, 5, 25, 100 ),
				new LootPackEntry( false, Instruments,                   2.00, 1 )
			});

		public static readonly LootPack SeUltraRich = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,                     100.00, "6d100+600" ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 33, 100 ),
				new LootPackEntry( false, Instruments,                2.00, 1 )
			});

		public static readonly LootPack SeSuperBoss = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,                     100.00, "10d100+800" ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 33, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 33, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 33, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 33, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 50, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 50, 100 ),
				new LootPackEntry( false, Instruments,                2.00, 1 )
			});

		/// AOS Definitions
		public static readonly LootPack AosPoor = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "1d10+10" ),
				new LootPackEntry( false, AosMagicItemsPoor,      0.02, 1, 5, 0, 90 ),
				new LootPackEntry( false, Instruments,    0.02, 1 )
			});

		public static readonly LootPack AosMeager = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "3d10+20" ),
				new LootPackEntry( false, AosMagicItemsMeagerType1,   1.00, 1, 2, 0, 10 ),
				new LootPackEntry( false, AosMagicItemsMeagerType2,   0.20, 1, 5, 0, 90 ),
				new LootPackEntry( false, Instruments,    0.10, 1 )
			});

		public static readonly LootPack AosAverage = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "5d10+50" ),
				new LootPackEntry( false, AosMagicItemsAverageType1,  5.00, 1, 4, 0, 20 ),
				new LootPackEntry( false, AosMagicItemsAverageType1,  2.00, 1, 3, 0, 50 ),
				new LootPackEntry( false, AosMagicItemsAverageType2,  0.50, 1, 5, 0, 90 ),
				new LootPackEntry( false, Instruments,    0.40, 1 )
			});

		public static readonly LootPack AosRich = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "10d10+150" ),
				new LootPackEntry( false, AosMagicItemsRichType1,    20.00, 1, 4, 0, 40 ),
				new LootPackEntry( false, AosMagicItemsRichType1,    10.00, 1, 5, 0, 60 ),
				new LootPackEntry( false, AosMagicItemsRichType2,     1.00, 1, 5, 0, 90 ),
				new LootPackEntry( false, Instruments,    1.00, 1 )
			});

		public static readonly LootPack AosFilthyRich = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "2d100+200" ),
				new LootPackEntry( false, AosMagicItemsFilthyRichType1,  33.00, 1, 4, 0, 50 ),
				new LootPackEntry( false, AosMagicItemsFilthyRichType1,  33.00, 1, 4, 0, 60 ),
				new LootPackEntry( false, AosMagicItemsFilthyRichType2,  20.00, 1, 5, 0, 75 ),
				new LootPackEntry( false, AosMagicItemsFilthyRichType2,   5.00, 1, 5, 0, 100 ),
				new LootPackEntry( false, Instruments,    2.00, 1 )
			});

		public static readonly LootPack AosUltraRich = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "5d100+500" ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 35, 100 ),
				new LootPackEntry( false, Instruments,    2.00, 1 )
			});

		public static readonly LootPack AosSuperBoss = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "5d100+500" ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 25, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 33, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 33, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 33, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 33, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 50, 100 ),
				new LootPackEntry( false, AosMagicItemsUltraRich,   100.00, 1, 5, 50, 100 ),
				new LootPackEntry( false, Instruments,    2.00, 1 )
			});

		/// Pre-AOS Definitions
		public static readonly LootPack OldPoor = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "1d25" ),
				new LootPackEntry( false, Instruments,    0.02, 1 )
			});

		public static readonly LootPack OldMeager = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "5d10+25" ),
				new LootPackEntry( false, Instruments,    0.10, 1 ),
				new LootPackEntry( false, OldMagicItems,  1.00, 1, 1, 0, 60 ),
				new LootPackEntry( false, OldMagicItems,  0.20, 1, 1, 10, 70 )
			});

		public static readonly LootPack OldAverage = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "10d10+50" ),
				new LootPackEntry( false, Instruments,    0.40, 1 ),
				new LootPackEntry( false, OldMagicItems,  5.00, 1, 1, 20, 80 ),
				new LootPackEntry( false, OldMagicItems,  2.00, 1, 1, 30, 90 ),
				new LootPackEntry( false, OldMagicItems,  0.50, 1, 1, 40, 100 )
			});

		public static readonly LootPack OldRich = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "10d10+250" ),
				new LootPackEntry( false, Instruments,    1.00, 1 ),
				new LootPackEntry( false, OldMagicItems, 20.00, 1, 1, 60, 100 ),
				new LootPackEntry( false, OldMagicItems, 10.00, 1, 1, 65, 100 ),
				new LootPackEntry( false, OldMagicItems,  1.00, 1, 1, 70, 100 )
			});

		public static readonly LootPack OldFilthyRich = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "2d125+400" ),
				new LootPackEntry( false, Instruments,    2.00, 1 ),
				new LootPackEntry( false, OldMagicItems, 33.00, 1, 1, 50, 100 ),
				new LootPackEntry( false, OldMagicItems, 33.00, 1, 1, 60, 100 ),
				new LootPackEntry( false, OldMagicItems, 20.00, 1, 1, 70, 100 ),
				new LootPackEntry( false, OldMagicItems,  5.00, 1, 1, 80, 100 )
			});

		public static readonly LootPack OldUltraRich = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "5d100+500" ),
				new LootPackEntry( false, Instruments,    2.00, 1 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 40, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 40, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 50, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 50, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 60, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 60, 100 )
			});

		public static readonly LootPack OldSuperBoss = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry(  true, Gold,         100.00, "5d100+500" ),
				new LootPackEntry( false, Instruments,    2.00, 1 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 40, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 40, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 40, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 50, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 50, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 50, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 60, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 60, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 60, 100 ),
				new LootPackEntry( false, OldMagicItems,    100.00, 1, 1, 70, 100 )
			});

		/// Middle of Script - Not Sure Where These Fit In
		public static readonly LootPack LowScrolls = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry( false, LowScrollItems,   100.00, 1 )
			});

		public static readonly LootPack MedScrolls = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry( false, MedScrollItems,   100.00, 1 )
			});

		public static readonly LootPack HighScrolls = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry( false, HighScrollItems,  100.00, 1 )
			});

		public static readonly LootPack Gems = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry( false, GemItems,         100.00, 1 )
			});

		public static readonly LootPack Potions = new LootPack(new LootPackEntry[]
			{
				new LootPackEntry( false, PotionItems,      100.00, 1 )
			});

		#region Uncomment When These ML Parrot Items Are Added...

		/// public static readonly LootPackItem[] ParrotItem = new LootPackItem[]
		/// 	{
		/// 		new LootPackItem( typeof( ParrotItem ), 1 )
		/// 	};
		/// 
		/// public static readonly LootPack Parrot = new LootPack( new LootPackEntry[]
		/// 	{
		/// 		new LootPackEntry( false, ParrotItem, 10.00, 1 )
		/// 	});

		#endregion
	}

	public partial class LootPackItem
	{
		private static readonly Type[] m_BlankTypes = new Type[] { typeof(BlankScroll) };

		public Item Construct(bool inTokuno, bool isMondain)
		{
			try
			{
				Item item;

				if (m_Type == typeof(BaseRanged))
				{
					item = Loot.RandomRangedWeapon();
				}
				else if (m_Type == typeof(BaseWeapon))
				{
					item = Loot.RandomWeapon();
				}
				else if (m_Type == typeof(BaseArmor))
				{
					item = Loot.RandomArmorOrHat();
				}
				else if (m_Type == typeof(BaseShield))
				{
					item = Loot.RandomShield();
				}
				else if (m_Type == typeof(BaseJewel))
				{
					item = Core.AOS ? Loot.RandomJewelry() : Loot.RandomArmorOrShieldOrWeapon();
				}
				else if (m_Type == typeof(BaseInstrument))
				{
					item = Loot.RandomInstrument();
				}
				else if (m_Type == typeof(Amber)) // gem
				{
					item = Loot.RandomGem();
				}
				else if (m_Type == typeof(ClumsyScroll)) // low scroll
				{
					item = Loot.RandomScroll(SpellCircle.First, SpellCircle.Third);
				}
				else if (m_Type == typeof(ArchCureScroll)) // med scroll
				{
					item = Loot.RandomScroll(SpellCircle.Fourth, SpellCircle.Seventh);
				}
				else if (m_Type == typeof(SummonAirElementalScroll)) // high scroll
				{
					item = Loot.RandomScroll(SpellCircle.Eighth, SpellCircle.Eighth);
				}
				else
				{
					item = Activator.CreateInstance(m_Type) as Item;
				}

				return item;
			}
			catch
			{
			}

			return null;
		}
	}
}