using Server.Spells.Avatar;
using Server.Spells.Bushido;
using Server.Spells.Chivalry;
using Server.Spells.Cleric;
using Server.Spells.Druid;
using Server.Spells.Magery;
using Server.Spells.Mysticism;
using Server.Spells.Necromancy;
using Server.Spells.Ninjitsu;
using Server.Spells.Racial;
using Server.Spells.Ranger;
using Server.Spells.Rogue;
using Server.Spells.Spellweaving;

using System;
using System.Collections.Generic;

namespace Server.Spells
{
	public static class SpellInitializer
	{
		[CallPriority(Int32.MinValue)]
		public static void Configure()
		{
			Register(Magery);
			Register(Necromancy);
			Register(Chivalry);
			Register(Ninjitsu);
			Register(Bushido);
			Register(Spellweaving);
			Register(Mysticism);

			// Custom
			Register(Avatar);
			Register(Cleric);
			Register(Druid);
			Register(Ranger);
			Register(Rogue);

			// Racial
			Register(Human);
			Register(Elf);
			Register(Gargoyle);
		}

		private static void Register(IEnumerable<SpellInfo> list)
		{
			foreach (var info in list)
			{
				SpellRegistry.Register(info);
			}
		}

		#region Standard

		#region Magery

		public static readonly SpellInfo[] Magery =
		{
			#region First Circle

			new(typeof(ClumsySpell), SpellName.Clumsy, SpellSchool.Magery, SpellCircle.First)
			{
				Name = "Clumsy",
				Mantra = "Uus Jux",
				Desc = "Temporarily reduces Target's Dexterity.",
				Enabled = true,
				Icon = 2240,
				Back = 9350,
				Action = 212,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 4,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
			new(typeof(CreateFoodSpell), SpellName.CreateFood, SpellSchool.Magery, SpellCircle.First)
			{
				Name = "Create Food",
				Mantra = "In Mani Ylem",
				Desc = "Creates random food item in Caster's backpack.",
				Enabled = true,
				Icon = 2241,
				Back = 9350,
				Action = 224,
				LeftHandEffect = 9011,
				RightHandEffect = 9011,
				Mana = 4,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(FeeblemindSpell), SpellName.Feeblemind, SpellSchool.Magery, SpellCircle.First)
			{
				Name = "Feeblemind",
				Mantra = "Rel Wis",
				Desc = "Temporarily reduces Target's Intelligence.",
				Enabled = true,
				Icon = 2242,
				Back = 9350,
				Action = 212,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 4,
				Reagents =
				{
					[Reagent.Nightshade] = 1,
					[Reagent.Ginseng] = 1,
				},
			},
			new(typeof(HealSpell), SpellName.Heal, SpellSchool.Magery, SpellCircle.First)
			{
				Name = "Heal",
				Mantra = "In Mani",
				Desc = "Heals Target of a small amount of lost Hit Points.",
				Enabled = true,
				Icon = 2243,
				Back = 9350,
				Action = 224,
				LeftHandEffect = 9061,
				RightHandEffect = 9061,
				Mana = 4,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(MagicArrowSpell), SpellName.MagicArrow, SpellSchool.Magery, SpellCircle.First)
			{
				Name = "Magic Arrow",
				Mantra = "In Por Ylem",
				Desc = "Shoots a magical arrow at Target, wich deals Fire damage.",
				Enabled = true,
				Icon = 2244,
				Back = 9350,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 4,
				Reagents =
				{
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(NightSightSpell), SpellName.NightSight, SpellSchool.Magery, SpellCircle.First)
			{
				Name = "Night Sight",
				Mantra = "In Lor",
				Desc = "Temporarily allows Target to see in darkness.",
				Enabled = true,
				Icon = 2245,
				Back = 9350,
				Action = 236,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 4,
				Reagents =
				{
					[Reagent.SpidersSilk] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(ReactiveArmorSpell), SpellName.ReactiveArmor, SpellSchool.Magery, SpellCircle.First)
			{
				Name = "Reactive Armor",
				Mantra = "Flam Sanct",
				Desc = "Increases the Caster's Physical Resistance while reducing their Elemental Resistances.  "
						+ "The Caster's Inscription skill adds a bonus to the amount of Physical Resist applied.  "
						+ "Active until spell is deactivated by re-casting the spell on the same Target.",
				Enabled = true,
				Icon = 2246,
				Back = 9350,
				Action = 236,
				LeftHandEffect = 9011,
				RightHandEffect = 9011,
				Mana = 4,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.SpidersSilk] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(WeakenSpell), SpellName.Weaken, SpellSchool.Magery, SpellCircle.First)
			{
				Name = "Weaken",
				Mantra = "Des Mani",
				Desc = "Temporarily reduces Target's Strength.",
				Enabled = true,
				Icon = 2247,
				Back = 9350,
				Action = 212,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 4,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Nightshade] = 1,
				},
			},

			#endregion

			#region Second Circle

			new(typeof(AgilitySpell), SpellName.Agility, SpellSchool.Magery, SpellCircle.Second)
			{
				Name = "Agility",
				Mantra = "Ex Uus",
				Desc = "Temporarily increases Target's Dexterity.",
				Enabled = true,
				Icon = 2248,
				Back = 9350,
				Action = 212,
				LeftHandEffect = 9061,
				RightHandEffect = 9061,
				Mana = 6,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(CunningSpell), SpellName.Cunning, SpellSchool.Magery, SpellCircle.Second)
			{
				Name = "Cunning",
				Mantra = "Uus Wis",
				Desc = "Temporarily increases Target's Intelligence.",
				Enabled = true,
				Icon = 2249,
				Back = 9350,
				Action = 212,
				LeftHandEffect = 9061,
				RightHandEffect = 9061,
				Mana = 6,
				Reagents =
				{
					[Reagent.Nightshade] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(CureSpell), SpellName.Cure, SpellSchool.Magery, SpellCircle.Second)
			{
				Name = "Cure",
				Mantra = "An Nox",
				Desc = "Attempts to neutralize poisons affecting the Target.",
				Enabled = true,
				Icon = 2250,
				Back = 9350,
				Action = 212,
				LeftHandEffect = 9061,
				RightHandEffect = 9061,
				Mana = 6,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
				},
			},
			new(typeof(HarmSpell), SpellName.Harm, SpellSchool.Magery, SpellCircle.Second)
			{
				Name = "Harm",
				Mantra = "An Mani",
				Desc = "Affects the Target with a chilling effect, dealing Cold damage.  "
						+ "The closer the Target is to the Caster, the more damage is dealt.",
				Enabled = true,
				Icon = 2251,
				Back = 9350,
				Action = 212,
				LeftHandEffect = Core.AOS ? 9001 : 9041,
				RightHandEffect = Core.AOS ? 9001 : 9041,
				Mana = 6,
				Reagents =
				{
					[Reagent.Nightshade] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(MagicTrapSpell), SpellName.MagicTrap, SpellSchool.Magery, SpellCircle.Second)
			{
				Name = "Magic Trap",
				Mantra = "In Jux",
				Desc = "Places an explosive magic ward on a useable object that deals Fire damage to the next person to use the object.",
				Enabled = true,
				Icon = 2252,
				Back = 9350,
				Action = 212,
				LeftHandEffect = 9001,
				RightHandEffect = 9001,
				Mana = 6,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.SpidersSilk] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(RemoveTrapSpell), SpellName.RemoveTrap, SpellSchool.Magery, SpellCircle.Second)
			{
				Name = "Remove Trap",
				Mantra = "An Jux",
				Desc = "Deactivates a magical trap on a single object.",
				Enabled = true,
				Icon = 2253,
				Back = 9350,
				Action = 212,
				LeftHandEffect = 9001,
				RightHandEffect = 9001,
				Mana = 6,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(ProtectionSpell), SpellName.Protection, SpellSchool.Magery, SpellCircle.Second)
			{
				Name = "Protection",
				Mantra = "Uus Sanct",
				Desc = "Prevents the Target from having their spells disrupted, but lowers their Physical Resistances and ability to Resist Spells.  "
						+ "Active until the spell is deactivated by recasting on the same Target.",
				Enabled = true,
				Icon = 2254,
				Back = 9350,
				Action = 236,
				LeftHandEffect = 9011,
				RightHandEffect = 9011,
				Mana = 6,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(StrengthSpell), SpellName.Strength, SpellSchool.Magery, SpellCircle.Second)
			{
				Name = "Strength",
				Mantra = "Uus Mani",
				Desc = "Temporarily increases Target's Strength.",
				Enabled = true,
				Icon = 2255,
				Back = 9350,
				Action = 212,
				LeftHandEffect = 9061,
				RightHandEffect = 9061,
				Mana = 6,
				Reagents =
				{
					[Reagent.MandrakeRoot] = 1,
					[Reagent.Nightshade] = 1,
				},
			},

			#endregion

			#region Third Circle

			new(typeof(BlessSpell), SpellName.Bless, SpellSchool.Magery, SpellCircle.Third)
			{
				Name = "Bless",
				Mantra = "Rel Sanct",
				Desc = "Temporarily increases Target's Strength, Dexterity, and Intelligence.",
				Enabled = true,
				Icon = 2256,
				Back = 9350,
				Action = 203,
				LeftHandEffect = 9061,
				RightHandEffect = 9061,
				Mana = 9,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(FireballSpell), SpellName.Fireball, SpellSchool.Magery, SpellCircle.Third)
			{
				Name = "Fireball",
				Mantra = "Vas Flam",
				Desc = "Shoots a ball of roiling flames at a Target, dealing Fire damage.",
				Enabled = true,
				Icon = 2257,
				Back = 9350,
				Action = 203,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 9,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
				},
			},
			new(typeof(MagicLockSpell), SpellName.MagicLock, SpellSchool.Magery, SpellCircle.Third)
			{
				Name = "Magic Lock",
				Mantra = "An Por",
				Desc = "Magically seals a container, blocking it from use until it is Magically Unlocked.",
				Enabled = true,
				Icon = 2258,
				Back = 9350,
				Action = 215,
				LeftHandEffect = 9001,
				RightHandEffect = 9001,
				Mana = 9,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.Garlic] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(PoisonSpell), SpellName.Poison, SpellSchool.Magery, SpellCircle.Third)
			{
				Name = "Poison",
				Mantra = "In Nox",
				Desc = "The Target is afflicted by poison, of a strength determined by the Caster's Magery and Poison skills, and the distance from the Target.",
				Enabled = true,
				Icon = 2259,
				Back = 9350,
				Action = 203,
				LeftHandEffect = 9051,
				RightHandEffect = 9051,
				Mana = 9,
				Reagents =
				{
					[Reagent.Nightshade] = 1,
				},
			},
			new(typeof(TelekinesisSpell), SpellName.Telekinesis, SpellSchool.Magery, SpellCircle.Third)
			{
				Name = "Telekinesis",
				Mantra = "Ort Por Ylem",
				Desc = "Allows the Caster to Use an item at a distance.",
				Enabled = true,
				Icon = 2260,
				Back = 9350,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 9,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(TeleportSpell), SpellName.Teleport, SpellSchool.Magery, SpellCircle.Third)
			{
				Name = "Teleport",
				Mantra = "Rel Por",
				Desc = "Caster is transported to the Target Location.",
				Enabled = true,
				Icon = 2261,
				Back = 9350,
				Action = 215,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 9,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(UnlockSpell), SpellName.Unlock, SpellSchool.Magery, SpellCircle.Third)
			{
				Name = "Unlock",
				Mantra = "Ex Por",
				Desc = "Unlocks a magical lock or low level normal lock.",
				Enabled = true,
				Icon = 2262,
				Back = 9350,
				Action = 215,
				LeftHandEffect = 9001,
				RightHandEffect = 9001,
				Mana = 9,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(WallOfStoneSpell), SpellName.WallOfStone, SpellSchool.Magery, SpellCircle.Third)
			{
				Name = "Wall of Stone",
				Mantra = "In Sanct Ylem",
				Desc = "Creates a temporary wall of stone that blocks movement.",
				Enabled = true,
				Icon = 2263,
				Back = 9350,
				Action = 227,
				LeftHandEffect = 9011,
				RightHandEffect = 9011,
				AllowTown = false,
				Mana = 9,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.Garlic] = 1,
				},
			},

			#endregion

			#region Fourth Circle

			new(typeof(ArchCureSpell), SpellName.ArchCure, SpellSchool.Magery, SpellCircle.Fourth)
			{
				Name = "Arch Cure",
				Mantra = "Vas An Nox",
				Desc = "Neutralizes poisons on all characters withing a small radius around the caster.",
				Enabled = true,
				Icon = 2264,
				Back = 9350,
				Action = 215,
				LeftHandEffect = 9061,
				RightHandEffect = 9061,
				Mana = 11,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(ArchProtectionSpell), SpellName.ArchProtection, SpellSchool.Magery, SpellCircle.Fourth)
			{
				Name = "Arch Protection",
				Mantra = "Vas Uus Sanct",
				Desc = "Applies the Protection spell to all valid targets within a small radius around the Target Location.",
				Enabled = true,
				Icon = 2265,
				Back = 9350,
				Action = Core.AOS ? 239 : 215,
				LeftHandEffect = 9011,
				RightHandEffect = 9011,
				Mana = 11,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(CurseSpell), SpellName.Curse, SpellSchool.Magery, SpellCircle.Fourth)
			{
				Name = "Curse",
				Mantra = "Des Sanct",
				Desc = "Lowers the Strength, Dexterity, and Intelligence of the Target.  "
						+ "When cast during Player vs. Player combat, the spell also reduces the target's maximum resistance values.",
				Enabled = true,
				Icon = 2266,
				Back = 9350,
				Action = 227,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 11,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Nightshade] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(FireFieldSpell), SpellName.FireField, SpellSchool.Magery, SpellCircle.Fourth)
			{
				Name = "Fire Field",
				Mantra = "In Flam Grav",
				Desc = "Summons a wall of fire that deals Fire damage to all who walk through it.",
				Enabled = true,
				Icon = 2267,
				Back = 9350,
				Action = 215,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				AllowTown = false,
				Mana = 11,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.SpidersSilk] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(GreaterHealSpell), SpellName.GreaterHeal, SpellSchool.Magery, SpellCircle.Fourth)
			{
				Name = "Greater Heal",
				Mantra = "In Vas Mani",
				Desc = "Heals the target of a medium amount of lost Hit Points.",
				Enabled = true,
				Icon = 2268,
				Back = 9350,
				Action = 204,
				LeftHandEffect = 9061,
				RightHandEffect = 9061,
				Mana = 11,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(LightningSpell), SpellName.Lightning, SpellSchool.Magery, SpellCircle.Fourth)
			{
				Name = "Lightning",
				Mantra = "Por Ort Grav",
				Desc = "Strikes the Target with a bolt of lightning, wich deals Energy damage.",
				Enabled = true,
				Icon = 2269,
				Back = 9350,
				Action = 239,
				LeftHandEffect = 9021,
				RightHandEffect = 9021,
				Mana = 11,
				Reagents =
				{
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(ManaDrainSpell), SpellName.ManaDrain, SpellSchool.Magery, SpellCircle.Fourth)
			{
				Name = "Mana Drain",
				Mantra = "Ort Rel",
				Desc = "Temporarily removes an amount of mana from the Target, "
						+ "based on a comparison between the Caster's Evaluate Intelligence sill and the Target's Resist Spells skill.",
				Enabled = true,
				Icon = 2270,
				Back = 9350,
				Action = 215,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 11,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(RecallSpell), SpellName.Recall, SpellSchool.Magery, SpellCircle.Fourth)
			{
				Name = "Recall",
				Mantra = "Kal Ort Por",
				Desc = "Caster is transported to the location marked on the Target rune.  "
						+ "If a ship key is target, Caster is transported to the boat the key opens.",
				Enabled = true,
				Icon = 2271,
				Back = 9350,
				Action = 239,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 11,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},

			#endregion

			#region Fifth Circle

			new(typeof(BladeSpiritsSpell), SpellName.BladeSpirits, SpellSchool.Magery, SpellCircle.Fifth)
			{
				Name = "Blade Spirits",
				Mantra = "In Jux Hur Ylem",
				Desc = "Summons a whirling pillar of blades that selects a Target to attack based off of its combat strength and proximity.  "
						+ "The Blade Spirit disappears after a set amount of time. Requires 1 pet control slot.",
				Enabled = true,
				Icon = 2272,
				Back = 9350,
				Action = 266,
				LeftHandEffect = 9040,
				RightHandEffect = 9040,
				AllowTown = false,
				Mana = 14,
				Tithe = 0,
				Skill = 0.0,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
			new(typeof(DispelFieldSpell), SpellName.DispelField, SpellSchool.Magery, SpellCircle.Fifth)
			{
				Name = "Dispel Field",
				Mantra = "An Grav",
				Desc = "Destroys one of the target Field spell.",
				Enabled = true,
				Icon = 2273,
				Back = 9350,
				Action = 206,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 14,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Garlic] = 1,
					[Reagent.SulfurousAsh] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(IncognitoSpell), SpellName.Incognito, SpellSchool.Magery, SpellCircle.Fifth)
			{
				Name = "Incognito",
				Mantra = "Kal In Ex",
				Desc = "Disuises the Caster with a randomly generated appearance and name.",
				Enabled = true,
				Icon = 2274,
				Back = 9350,
				Action = 206,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 14,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.Garlic] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
			new(typeof(MagicReflectSpell), SpellName.MagicReflect, SpellSchool.Magery, SpellCircle.Fifth)
			{
				Name = "Magic Reflection",
				Mantra = "In Jux Sanct",
				Desc = "Lowers the caster's Physical resistances, while increasing their Elemental resistances.  "
						+ "Active until the spell is deactivated by recasting on the same Target.",
				Enabled = true,
				Icon = 2275,
				Back = 9350,
				Action = 242,
				LeftHandEffect = 9012,
				RightHandEffect = 9012,
				Mana = 14,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(MindBlastSpell), SpellName.MindBlast, SpellSchool.Magery, SpellCircle.Fifth)
			{
				Name = "Mind Blast",
				Mantra = "Por Corp Wis",
				Desc = "Deals Cold damage to the Target based off Caster's Magery and Intelligence.",
				Enabled = true,
				Icon = 2276,
				Back = 9350,
				Action = 218,
				LeftHandEffect = Core.AOS ? 9002 : 9032,
				RightHandEffect = Core.AOS ? 9002 : 9032,
				Mana = 14,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.Nightshade] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(ParalyzeSpell), SpellName.Paralyze, SpellSchool.Magery, SpellCircle.Fifth)
			{
				Name = "Paralyze",
				Mantra = "An Ex Por",
				Desc = "Immobilizes the Target for a brief amount of time.  "
						+ "The Target's Resisting Spells skill affects the Duration of the immobilization.",
				Enabled = true,
				Icon = 2277,
				Back = 9350,
				Action = 218,
				LeftHandEffect = 9012,
				RightHandEffect = 9012,
				Mana = 14,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(PoisonFieldSpell), SpellName.PoisonField, SpellSchool.Magery, SpellCircle.Fifth)
			{
				Name = "Poison Field",
				Mantra = "In Nox Grav",
				Desc = "Conjures a wall of poisonous vapor that poisons anything that walks through it.",
				Enabled = true,
				Icon = 2278,
				Back = 9350,
				Action = 230,
				LeftHandEffect = 9052,
				RightHandEffect = 9052,
				AllowTown = false,
				Mana = 14,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Nightshade] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(SummonCreatureSpell), SpellName.SummonCreature, SpellSchool.Magery, SpellCircle.Fifth)
			{
				Name = "Summon Creature",
				Mantra = "Kal Xen",
				Desc = "Summons a random creature as a pet for a limited duration.  "
						+ "The strength of the summoned creature is based off of the Caster's Magery skill.",
				Enabled = true,
				Icon = 2279,
				Back = 9350,
				Action = 16,
				LeftHandEffect = 0,
				RightHandEffect = 0,
				AllowTown = false,
				Mana = 14,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},

			#endregion

			#region Sixth Circle

			new(typeof(DispelSpell), SpellName.Dispel, SpellSchool.Magery, SpellCircle.Sixth)
			{
				Name = "Dispel",
				Mantra = "An Ort",
				Desc = "Attempts to Dispel a summoned creature, causing it to disapear from the world.  "
						+ "The Dispel difficulty is affected by the Magery skill of the creature's owner.",
				Enabled = true,
				Icon = 2280,
				Back = 9350,
				Action = 218,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 20,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(EnergyBoltSpell), SpellName.EnergyBolt, SpellSchool.Magery, SpellCircle.Sixth)
			{
				Name = "Energy Bolt",
				Mantra = "Corp Por",
				Desc = "Fires a bold of magical force at the Target dealing Energy damage.",
				Enabled = true,
				Icon = 2281,
				Back = 9350,
				Action = 230,
				LeftHandEffect = 9022,
				RightHandEffect = 9022,
				Mana = 20,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
			new(typeof(ExplosionSpell), SpellName.Explosion, SpellSchool.Magery, SpellCircle.Sixth)
			{
				Name = "Explosion",
				Mantra = "Vas Ort Flam",
				Desc = "Strikes the Target with an explosive blast of energy, dealing Fire damage.",
				Enabled = true,
				Icon = 2282,
				Back = 9350,
				Action = 230,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 20,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(InvisibilitySpell), SpellName.Invisibility, SpellSchool.Magery, SpellCircle.Sixth)
			{
				Name = "Invisibility",
				Mantra = "An Lor Xen",
				Desc = "Temporarily causes the Target to become invisible.",
				Enabled = true,
				Icon = 2283,
				Back = 9350,
				Action = 206,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 20,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
			new(typeof(MarkSpell), SpellName.Mark, SpellSchool.Magery, SpellCircle.Sixth)
			{
				Name = "Mark",
				Mantra = "Kal Por Ylem",
				Desc = "Binds a rune to the Caster's current Location.  ",
				Enabled = true,
				Icon = 2284,
				Back = 9350,
				Action = 218,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 20,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(MassCurseSpell), SpellName.MassCurse, SpellSchool.Magery, SpellCircle.Sixth)
			{
				Name = "Mass Curse",
				Mantra = "Vas Des Sanct",
				Desc = "Casts the Curse spell on a target, and any creatures within a two tile radius.",
				Enabled = true,
				Icon = 2285,
				Back = 9350,
				Action = 218,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				AllowTown = false,
				Mana = 20,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.Nightshade] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(ParalyzeFieldSpell), SpellName.ParalyzeField, SpellSchool.Magery, SpellCircle.Sixth)
			{
				Name = "Paralyze Field",
				Mantra = "In Ex Grav",
				Desc = "Conjures a field of paralyzing energy that affects any creature that enters it with the effects of the Paralyze spell.",
				Enabled = true,
				Icon = 2286,
				Back = 9350,
				Action = 230,
				LeftHandEffect = 9012,
				RightHandEffect = 9012,
				AllowTown = false,
				Mana = 20,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(RevealSpell), SpellName.Reveal, SpellSchool.Magery, SpellCircle.Sixth)
			{
				Name = "Reveal",
				Mantra = "Wis Quas",
				Desc = "Reveals the presence of any invisible or hiding creatures or players within a radius around the targeted tile.",
				Enabled = true,
				Icon = 2287,
				Back = 9350,
				Action = 206,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 20,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},

			#endregion

			#region Seventh Circle

			new(typeof(ChainLightningSpell), SpellName.ChainLightning, SpellSchool.Magery, SpellCircle.Seventh)
			{
				Name = "Chain Lightning",
				Mantra = "Vas Ort Grav",
				Desc = "Damages nearby targets with a series of lightning bolts that deal Energy damage.",
				Enabled = true,
				Icon = 2288,
				Back = 9350,
				Action = 209,
				LeftHandEffect = 9022,
				RightHandEffect = 9022,
				AllowTown = false,
				Mana = 40,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(EnergyFieldSpell), SpellName.EnergyField, SpellSchool.Magery, SpellCircle.Seventh)
			{
				Name = "Energy Field",
				Mantra = "In Sanct Grav",
				Desc = "Conjures a temporary field of energy on the ground at the Target Location that blocks all movement.",
				Enabled = true,
				Icon = 2289,
				Back = 9350,
				Action = 221,
				LeftHandEffect = 9022,
				RightHandEffect = 9022,
				AllowTown = false,
				Mana = 40,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(FlameStrikeSpell), SpellName.FlameStrike, SpellSchool.Magery, SpellCircle.Seventh)
			{
				Name = "Flame Strike",
				Mantra = "Kal Vas Flam",
				Desc = "Envelopes the target in a column of magical flame that deals Fire damage.",
				Enabled = true,
				Icon = 2290,
				Back = 9350,
				Action = 245,
				LeftHandEffect = 9042,
				RightHandEffect = 9042,
				Mana = 40,
				Reagents =
				{
					[Reagent.SpidersSilk] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(GateTravelSpell), SpellName.GateTravel, SpellSchool.Magery, SpellCircle.Seventh)
			{
				Name = "Gate Travel",
				Mantra = "Vas Rel Por",
				Desc = "Targeting a rune marked with the Mark spell, opens a temporary portal to the rune's marked location.  "
						+ "The portal can be used by anyone to travel to that location.",
				Enabled = true,
				Icon = 2291,
				Back = 9350,
				Action = 263,
				LeftHandEffect = 9032,
				RightHandEffect = 9032,
				Mana = 40,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(ManaVampireSpell), SpellName.ManaVampire, SpellSchool.Magery, SpellCircle.Seventh)
			{
				Name = "Mana Vampire",
				Mantra = "Ort Sanct",
				Desc = "Drains mana from the Target and transfers it to the Caster.  "
						+ "The amount of mana drained is determined by a comparison between the "
						+ "Caster's Evaluate Intelligence skill and the Target's Resisting Spells skill.",
				Enabled = true,
				Icon = 2292,
				Back = 9350,
				Action = 221,
				LeftHandEffect = 9032,
				RightHandEffect = 9032,
				Mana = 40,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(MassDispelSpell), SpellName.MassDispel, SpellSchool.Magery, SpellCircle.Seventh)
			{
				Name = "Mass Dispel",
				Mantra = "Vas An Ort",
				Desc = "Attempts to dispel any summoned creature within an eight tile radius.",
				Enabled = true,
				Icon = 2293,
				Back = 9350,
				Action = 263,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 40,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Garlic] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(MeteorSwarmSpell), SpellName.MeteorSwarm, SpellSchool.Magery, SpellCircle.Seventh)
			{
				Name = "Meteor Swarm",
				Mantra = "Flam Kal Des Ylem",
				Desc = "Summons a swarm of fiery meteors that strike all targets within a radius around the Target Location.  "
						+ "The total Fire damage dealt is split between all Targets of the spell.",
				Enabled = true,
				Icon = 2294,
				Back = 9350,
				Action = 233,
				LeftHandEffect = 9042,
				RightHandEffect = 9042,
				AllowTown = false,
				Mana = 40,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(PolymorphSpell), SpellName.Polymorph, SpellSchool.Magery, SpellCircle.Seventh)
			{
				Name = "Polymorph",
				Mantra = "Vas Ylem Rel",
				Desc = "Temporarily transforms the Caster into a creature selected from a specified list.  "
						+ "While polymorphed, other players will see the Caster as a criminal.",
				Enabled = true,
				Icon = 2295,
				Back = 9350,
				Action = 221,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 40,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},

			#endregion

			#region Eighth Circle

			new(typeof(EarthquakeSpell), SpellName.Earthquake, SpellSchool.Magery, SpellCircle.Eighth)
			{
				Name = "Earthquake",
				Mantra = "In Vas Por",
				Desc = "Causes a violent shaking of the earth that damages all nearby creatures and characters.",
				Enabled = true,
				Icon = 2296,
				Back = 9350,
				Action = 233,
				LeftHandEffect = 9012,
				RightHandEffect = 9012,
				AllowTown = false,
				Mana = 50,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SulfurousAsh] = 1,
					[Reagent.Ginseng] = 1,
				},
			},
			new(typeof(EnergyVortexSpell), SpellName.EnergyVortex, SpellSchool.Magery, SpellCircle.Eighth)
			{
				Name = "Energy Vortex",
				Mantra = "Vas Corp Por",
				Desc = "Summons a spinning mass of energy that selects a Target to attack based off of its intelligence and proximity.  "
						+ "The Energy Vortex disappears after a set amount of time.  "
						+ "Requires 1 pet control slot.",
				Enabled = true,
				Icon = 2297,
				Back = 9350,
				Action = 260,
				LeftHandEffect = 9032,
				RightHandEffect = 9032,
				AllowTown = false,
				Mana = 50,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
			new(typeof(ResurrectionSpell), SpellName.Resurrection, SpellSchool.Magery, SpellCircle.Eighth)
			{
				Name = "Resurrection",
				Mantra = "An Corp",
				Desc = "Resurrects a player's ghost.  "
						+ "Cannot be used on NPC's or monsters.",
				Enabled = true,
				Icon = 2298,
				Back = 9350,
				Action = 245,
				LeftHandEffect = 9062,
				RightHandEffect = 9062,
				Mana = 50,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
				},
			},
			new(typeof(AirElementalSpell), SpellName.AirElemental, SpellSchool.Magery, SpellCircle.Eighth)
			{
				Name = "Air Elemental",
				Mantra = "Kal Vas Xen Hur",
				Desc = "An air elemental is summoned to serve the Caster.  "
						+ "Requires 2 pet control slots.",
				Enabled = true,
				Icon = 2299,
				Back = 9350,
				Action = 269,
				LeftHandEffect = 9010,
				RightHandEffect = 9010,
				AllowTown = false,
				Mana = 50,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(SummonDaemonSpell), SpellName.SummonDaemon, SpellSchool.Magery, SpellCircle.Eighth)
			{
				Name = "Summon Daemon",
				Mantra = "Kal Vas Xen Corp",
				Desc = "A daemon is summoned to server the Caster.  "
						+ "Results in a large Karma loss for the Caster.  "
						+ "Requires 5 pet control slots.",
				Enabled = true,
				Icon = 2300,
				Back = 9350,
				Action = 269,
				LeftHandEffect = 9050,
				RightHandEffect = 9050,
				AllowTown = false,
				Mana = 50,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(EarthElementalSpell), SpellName.EarthElemental, SpellSchool.Magery, SpellCircle.Eighth)
			{
				Name = "Earth Elemental",
				Mantra = "Kal Vas Xen Ylem",
				Desc = "An earth elemental is summoned to serve the Caster.  "
						+ "Requires 2 pet control slots.",
				Enabled = true,
				Icon = 2301,
				Back = 9350,
				Action = 269,
				LeftHandEffect = 9020,
				RightHandEffect = 9020,
				AllowTown = false,
				Mana = 50,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(FireElementalSpell), SpellName.FireElemental, SpellSchool.Magery, SpellCircle.Eighth)
			{
				Name = "Fire Elemental",
				Mantra = "Kal Vas Xen Flam",
				Desc = "A fire elemental is summoned to serve the Caster.  "
						+ "Requires 4 pet control slots.",
				Enabled = true,
				Icon = 2302,
				Back = 9350,
				Action = 269,
				LeftHandEffect = 9050,
				RightHandEffect = 9050,
				AllowTown = false,
				Mana = 50,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(WaterElementalSpell), SpellName.WaterElemental, SpellSchool.Magery, SpellCircle.Eighth)
			{
				Name = "Water Elemental",
				Mantra = "Kal Vas Xen An Flam",
				Desc = "A water elemental is summoned to serve the Caster.  "
						+ "Requires 3 pet control slots.",
				Enabled = true,
				Icon = 2303,
				Back = 9350,
				Action = 269,
				LeftHandEffect = 9070,
				RightHandEffect = 9070,
				AllowTown = false,
				Mana = 50,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},

			#endregion
		};

		#endregion

		#region Necromancy

		public static readonly SpellInfo[] Necromancy =
		{
			new(typeof(AnimateDeadSpell), SpellName.AnimateDead, SpellSchool.Necromancy)
			{
				Name = "Animate Dead",
				Mantra = "Uus Corp",
				Desc = "Animates the Targeted corpse, creating a mindless, wandering undead.  "
					 + "The strength of the risen undead is greatly modified by the Fame of the original creature.",
				Enabled = Core.AOS,
				Icon = 20480,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 23,
				Skill = 40.0,
				Reagents =
				{
					[Reagent.GraveDust] = 1,
					[Reagent.DaemonBlood] = 1,
				},
			},
			new(typeof(BloodOathSpell), SpellName.BloodOath, SpellSchool.Necromancy)
			{
				Name = "Blood Oath",
				Mantra = "In Jux Mani Xen",
				Desc = "Temporarily creates a dark pact between the Caster and the Target.  "
					 + "Any damage dealt by the Target to the Caster is increased, but the Target receives the same amount of damage.",
				Enabled = Core.AOS,
				Icon = 20481,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 13,
				Skill = 20.0,
				Reagents =
				{
					[Reagent.DaemonBlood] = 1,
				},
			},
			new(typeof(CorpseSkinSpell), SpellName.CorpseSkin, SpellSchool.Necromancy)
			{
				Name = "Corpse Skin",
				Mantra = "In Agle Corp Ylem",
				Desc = "Transmogrifies the flesh of the Target creature or player to resemble rotted corpse flesh, "
					 + "making them more vulnerable to Fire and Poison damage, but increasing their Resistance to Physical and Cold damage.",
				Enabled = Core.AOS,
				Icon = 20482,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9051,
				RightHandEffect = 9051,
				Mana = 11,
				Skill = 20.0,
				Reagents =
				{
					[Reagent.BatWing] = 1,
					[Reagent.GraveDust] = 1,
				},
			},
			new(typeof(CurseWeaponSpell), SpellName.CurseWeapon, SpellSchool.Necromancy)
			{
				Name = "Curse Weapon",
				Mantra = "An Sanct Gra Char",
				Desc = "Temporarily imbues a weapon with a life draining effect.",
				Enabled = Core.AOS,
				Icon = 20483,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 7,
				Skill = 0.0,
				Reagents =
				{
					[Reagent.PigIron] = 1,
				},
			},
			new(typeof(EvilOmenSpell), SpellName.EvilOmen, SpellSchool.Necromancy)
			{
				Name = "Evil Omen",
				Mantra = "Pas Tym An Sanct",
				Desc = "Curses the Target so that the next harmful event that affects them is magnified.",
				Enabled = Core.AOS,
				Icon = 20484,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 11,
				Skill = 20.0,
				Reagents =
				{
					[Reagent.BatWing] = 1,
					[Reagent.NoxCrystal] = 1,
				},
			},
			new(typeof(HorrificBeastSpell), SpellName.HorrificBeast, SpellSchool.Necromancy)
			{
				Name = "Horrific Beast",
				Mantra = "Rel Xen Vas Bal",
				Desc = "Transforms the Caster into a horrific demonic beast, wich deals more damage, and recovers hit points faster, "
					 + "but can no longer cast any spells except for Necromancer Transformation spells.  "
					 + "Caster remains in this form until they recast the Horrific Beast spell.",
				Enabled = Core.AOS,
				Icon = 20485,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 11,
				Skill = 40.0,
				Reagents =
				{
					[Reagent.BatWing] = 1,
					[Reagent.DaemonBlood] = 1,
				},
			},
			new(typeof(LichFormSpell), SpellName.LichForm, SpellSchool.Necromancy)
			{
				Name = "Lich Form",
				Mantra = "Rel Xen Corp Ort",
				Desc = "Transforms the Caster into a lich, increasing their mana regeneration and some Resistances, "
					 + "while lowering their Fire Resist and slowly sapping their life.  "
					 + "Caster remains in this form until they recast the Lich Form spell.",
				Enabled = Core.AOS,
				Icon = 20486,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 23,
				Skill = 70.0,
				Reagents =
				{
					[Reagent.GraveDust] = 1,
					[Reagent.DaemonBlood] = 1,
					[Reagent.NoxCrystal] = 1,
				},
			},
			new(typeof(MindRotSpell), SpellName.MindRot, SpellSchool.Necromancy)
			{
				Name = "Mind Rot",
				Mantra = "Wis An Ben",
				Desc = "Attempts to place a curse on the Target that increases the mana cost of any spells they cast, "
					 + "for a duration bassed off a comparison between the Caster's Spirit Speak skill and the Target's Resisting Spells skill.",
				Enabled = Core.AOS,
				Icon = 20487,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 17,
				Skill = 30.0,
				Reagents =
				{
					[Reagent.BatWing] = 1,
					[Reagent.DaemonBlood] = 1,
					[Reagent.PigIron] = 1,
				},
			},
			new(typeof(PainSpikeSpell), SpellName.PainSpike, SpellSchool.Necromancy)
			{
				Name = "Pain Spike",
				Mantra = "In Sar",
				Desc = "Temporarily causes intense physical pain to the Target, dealing Direct damage.  "
					 + "Once the spell wears off, if the Target is still alive, some of the Hit Points lost through the Pain Spike are restored.",
				Enabled = Core.AOS,
				Icon = 20488,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 5,
				Skill = 20.0,
				Reagents =
				{
					[Reagent.GraveDust] = 1,
					[Reagent.PigIron] = 1,
				},
			},
			new(typeof(PoisonStrikeSpell), SpellName.PoisonStrike, SpellSchool.Necromancy)
			{
				Name = "Poison Strike",
				Mantra = "In Vas Nox",
				Desc = "Creates a blast of poisonous energy centered on the Target.  "
					 + "The main Target is inflicted with a large amount of Poison damage, "
					 + "and all valid Targets in a radius around the main Target are inflicted with a lesser effect.",
				Enabled = Core.AOS,
				Icon = 20489,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 17,
				Skill = 50.0,
				Reagents =
				{
					[Reagent.NoxCrystal] = 1,
				},
			},
			new(typeof(StrangleSpell), SpellName.Strangle, SpellSchool.Necromancy)
			{
				Name = "Strangle",
				Mantra = "In Bal Nox",
				Desc = "Temporarily chokes off the air supply of the Target with poisonous fumes.  "
					 + "The Target is inflicted with Poison damage over time.  "
					 + "The amount of damage dealt each 'hit' is based off of the Caster's Spirit Speak skill and the Target's current Stamina.",
				Enabled = Core.AOS,
				Icon = 20490,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 29,
				Skill = 65.0,
				Reagents =
				{
					[Reagent.DaemonBlood] = 1,
					[Reagent.NoxCrystal] = 1,
				},
			},
			new(typeof(SummonFamiliarSpell), SpellName.SummonFamiliar, SpellSchool.Necromancy)
			{
				Name = "Summon Familiar",
				Mantra = "Kal Xen Bal",
				Desc = "Allows the Caster to summon a Familiar from a selecetd list.  "
					 + "A Familiar will follow and fight with its owner, in addition to granting unique bonuses to the Caster, "
					 + "dependent upon the type of Familiar summoned.",
				Enabled = Core.AOS,
				Icon = 20491,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 17,
				Skill = 30.0,
				Reagents =
				{
					[Reagent.BatWing] = 1,
					[Reagent.GraveDust] = 1,
					[Reagent.DaemonBlood] = 1,
				},
			},
			new(typeof(VampiricEmbraceSpell), SpellName.VampiricEmbrace, SpellSchool.Necromancy)
			{
				Name = "Vampiric Embrace",
				Mantra = "Rel Xen An Sanct",
				Desc = "Transforms the Caster into a powerful Vampire, wich increases his Stamina and Mana regeration while lowering his Fire Resistance.  "
					 + "Vampires also perform Life Drain when striking their enemies.  "
					 + "Caster remains in this form untill they recast the Vampiric Embrace spell.",
				Enabled = Core.AOS,
				Icon = 20492,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 23,
				Skill = 99.0,
				Reagents =
				{
					[Reagent.BatWing] = 1,
					[Reagent.NoxCrystal] = 1,
					[Reagent.PigIron] = 1,
				},
			},
			new(typeof(VengefulSpiritSpell), SpellName.VengefulSpirit, SpellSchool.Necromancy)
			{
				Name = "Vengeful Spirit",
				Mantra = "Kal Xen Bal Beh",
				Desc = "Summons a vile Spirit wich haunts the Target untill either the Target or the Spirit is dead.  "
					 + "Vengeful Spirits have the ability to track down their Target wherever they may travel.  "
					 + "A Spirit's strength is determined by the Necromancy and Spirit Speak skills of the Caster.",
				Enabled = Core.AOS,
				Icon = 20493,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 41,
				Skill = 80.0,
				Reagents =
				{
					[Reagent.BatWing] = 1,
					[Reagent.GraveDust] = 1,
					[Reagent.PigIron] = 1,
				},
			},
			new(typeof(WitherSpell), SpellName.Wither, SpellSchool.Necromancy)
			{
				Name = "Wither",
				Mantra = "Kal Vas An Flam",
				Desc = "Creates a withering frost around the Caster, wich deals Cold Damage to all valid targets in a radius.",
				Enabled = Core.AOS,
				Icon = 20494,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 23,
				Skill = 60.0,
				Reagents =
				{
					[Reagent.GraveDust] = 1,
					[Reagent.NoxCrystal] = 1,
					[Reagent.PigIron] = 1,
				},
			},
			new(typeof(WraithFormSpell), SpellName.WraithForm, SpellSchool.Necromancy)
			{
				Name = "Wraith Form",
				Mantra = "Rel Xen Um",
				Desc = "Transforms the Caster into an etheral Wraith, lowering some Elemental Resists, while increasing their physical resists.  "
					 + "Wraith Form also allows the caster to always succeed when using the Recall spell, "
					 + "and causes a Mana Drain effect when hitting enemies.  "
					 + "Caster remains in this form until they recast the Wraith Form spell.",
				Enabled = Core.AOS,
				Icon = 20495,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 17,
				Skill = 20.0,
				Reagents =
				{
					[Reagent.NoxCrystal] = 1,
					[Reagent.PigIron] = 1,
				},
			},
			new(typeof(ExorcismSpell), SpellName.Exorcism, SpellSchool.Necromancy)
			{
				Name = "Exorcism",
				Mantra = "Ort Corp Grav",
				Desc = "Forcibly relocates player ghosts caught within the spells' area of effect, if the ghost does not have a nearby corpse.  "
					 + "The spell is only effective in Champion Spawn regions and has no effect upon members of the same Party, Guild, Alliance, or Faction.  "
					 + "Affected ghosts are sent to the Chaos Shrine.",
				Enabled = Core.SE,
				Icon = 20496,
				Back = 3600,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 40,
				Skill = 80.0,
				Reagents =
				{
					[Reagent.NoxCrystal] = 1,
					[Reagent.GraveDust] = 1,
				},
			},
		};

		#endregion

		#region Chivalry

		public static readonly SpellInfo[] Chivalry =
		{
			new(typeof(CleanseByFireSpell), SpellName.CleanseByFire, SpellSchool.Chivalry)
			{
				Name = "Cleanse By Fire",
				Mantra = "Expor Flamus",
				Desc = "Cures the target of poisons, but causes the caster to be burned by fire damage.  "
					 + "The amount of fire damage is lessened if the caster has high Karma.",
				Enabled = Core.AOS,
				Icon = 20736,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 10,
				Tithe = 10,
				Skill = 5.0,
			},
			new(typeof(CloseWoundsSpell), SpellName.CloseWounds, SpellSchool.Chivalry)
			{
				Name = "Close Wounds",
				Mantra = "Obsu Vulni",
				Desc = "Heals the target of damage.  "
					 + "The caster's Karma affects the amount of damage healed.",
				Enabled = Core.AOS,
				Icon = 20737,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 10,
				Tithe = 10,
			},
			new(typeof(ConsecrateWeaponSpell), SpellName.ConsecrateWeapon, SpellSchool.Chivalry)
			{
				Name = "Consecrate Weapon",
				Mantra = "Consecrus Arma",
				Desc = "Temporarily enchants the weapon the caster is currently wielding.  "
					 + "The type of damage the weapon inflicts when hitting a target will be converted to the target's worst Resistance type.  "
					 + "Duration of the effect is affected by the caster's Karma.",
				Enabled = Core.AOS,
				Icon = 20738,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 10,
				Tithe = 10,
				Skill = 15.0,
			},
			new(typeof(DispelEvilSpell), SpellName.DispelEvil, SpellSchool.Chivalry)
			{
				Name = "Dispel Evil",
				Mantra = "Dispiro Malas",
				Desc = "Attempts to dispel evil summoned creatures and cause other evil creatures to flee from combat.  "
					 + "Transformed Necromancers may also take Stamina and Mana Damage.  "
					 + "Caster's Karma and Chivalry, and Target's Fame or Necromancy affect Dispel Chance.",
				Enabled = Core.AOS,
				Icon = 20739,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 15,
				Tithe = 10,
				Skill = 35.0,
			},
			new(typeof(DivineFurySpell), SpellName.DivineFury, SpellSchool.Chivalry)
			{
				Name = "Divine Fury",
				Mantra = "Divinum Furis",
				Desc = "Temporarily increases the Paladin's swing speed, chance to hit, and damage dealt, while lowering the Paladin's defenses.  "
					 + "Upon casting, the Paladin's Stamina is also refreshed.  "
					 + "Duration of the spell is affected by the Caster's Karma.",
				Enabled = Core.AOS,
				Icon = 20740,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 15,
				Tithe = 10,
				Skill = 25.0,
			},
			new(typeof(EnemyOfOneSpell), SpellName.EnemyOfOne, SpellSchool.Chivalry)
			{
				Name = "Enemy Of One",
				Mantra = "Forul Solum",
				Desc = "The next target hit becomes the Paladin's Mortal Enemy.  "
					 + "All damage dealt to that creature type is increased, but the Paladin takes extra damage from all other creature types.  "
					 + "Mortal Enemy creature types will highlight Orange to the Paladin.  "
					 + "Duration of the spell is affected by the Caster's Karma.",
				Enabled = Core.AOS,
				Icon = 20741,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 20,
				Tithe = 10,
				Skill = 45.0,
			},
			new(typeof(HolyLightSpell), SpellName.HolyLight, SpellSchool.Chivalry)
			{
				Name = "Holy Light",
				Mantra = "Augus Luminos",
				Desc = "Deals energy damage to all valid targets in a radius around the caster.  "
					 + "Amount of damage dealt is affected by Caster's Karma.",
				Enabled = Core.AOS,
				Icon = 20742,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 15,
				Tithe = 10,
				Skill = 55.0,
			},
			new(typeof(NobleSacrificeSpell), SpellName.NobleSacrifice, SpellSchool.Chivalry)
			{
				Name = "Noble Sacrifice",
				Mantra = "Dium Prostra",
				Desc = "Attempts to Ressurect, Cure, and Heal all targets in a radius around the caster.  "
					 + "If any target is successfully assisted, the Paladin's current Hit points, Mana, and Stamina are greatly reduced.  "
					 + "Amount of damage healed is affected by the Caster's Karma.",
				Enabled = Core.AOS,
				Icon = 20743,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 20,
				Tithe = 30,
				Skill = 65.0,
			},
			new(typeof(RemoveCurseSpell), SpellName.RemoveCurse, SpellSchool.Chivalry)
			{
				Name = "Remove Curse",
				Mantra = "Extermo Vomica",
				Desc = "Attempts to remove all Curse effects from target.  "
					 + "Curses include Mage spells such as Clumsy, Weaken, Feebleming, and Paralyze, as well as all Necromancer curses.  "
					 + "Chance of removing curse is affected by the Caster's Karma.",
				Enabled = Core.AOS,
				Icon = 20744,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 20,
				Tithe = 10,
				Skill = 5.0,
			},
			new(typeof(SacredJourneySpell), SpellName.SacredJourney, SpellSchool.Chivalry)
			{
				Name = "Sacred Journey",
				Mantra = "Sanctum Viatas",
				Desc = "Targeting a rune or ship key allows the caster to teleport to the marked location.  "
					 + "Caster may not flee from combat in this manner.",
				Enabled = Core.AOS,
				Icon = 20745,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 20,
				Tithe = 15,
				Skill = 15.0,
			},
		};

		#endregion

		#region Ninjitsu

		public static readonly SpellInfo[] Ninjitsu =
		{
			new(typeof(FocusAttackAbility), SpellName.FocusAttack, SpellSchool.Ninjitsu)
			{
				Name = "Focus Attack",
				Desc = "Grants a small damage bonus, also increases the effectiveness of any magical properties on the weapon the Ninja uses for the attack.",
				Enabled = Core.SE,
				Action = -1,
				Mana = Core.ML ? 10 : 20,
				Skill = Core.ML ? 30.0 : 60.0,
			},
			new(typeof(DeathStrikeAbility), SpellName.DeathStrike, SpellSchool.Ninjitsu)
			{
				Name = "Death Strike",
				Desc = "Shortly after receiving the strike, the Ninja's opponent will suffer damage determined by the number of steps they have taken.  "
					 + "The average of the Ninja's Hiding and Stealth skills grants a bonus to damage dealt.  "
					 + "Ranged weapons are much less effective for this attack.  "
					 + "The damage dealt is far greater if the Ninja’s opponent chooses to run away.",
				Enabled = Core.SE,
				Action = -1,
				Mana = 30,
				Skill = 85.0,
			},
			new(typeof(AnimalFormSpell), SpellName.AnimalForm, SpellSchool.Ninjitsu)
			{
				Name = "Animal Form",
				Desc = "Grants the Ninja the ability to transform into an animal, gaining special bonuses unique to each type of creature.  "
					 + "There are 12 animal forms available to a skilled Ninja.  "
					 + "The Ninja cannot use special attacks or cast spells while in Animal Form, except for Mirror Image and Shadow Jump.",
				Enabled = Core.SE,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = Core.ML ? 10 : 0,
			},
			new(typeof(KiAttackAbility), SpellName.KiAttack, SpellSchool.Ninjitsu)
			{
				Name = "Ki Attack",
				Desc = "Requires superb timing and quick movement of a well trained Ninja.  "
					 + "The Ninja must initiate the attack and then quickly close the distance to thier opponent to deliver an effective blow.  "
					 + "The further the Ninja travels to deliver the blow, the higher the damage bonus of the attack.",
				Enabled = Core.SE,
				Action = -1,
				Mana = 25,
				Skill = 80.0,
			},
			new(typeof(SurpriseAttackAbility), SpellName.SurpriseAttack, SpellSchool.Ninjitsu)
			{
				Name = "Surprise Attack",
				Desc = "An attack that can only be initiated by a Ninja in Stealth.  "
					 + "Inflicts a defense penalty on the Ninjas' opponent for a short duration.",
				Enabled = Core.SE,
				Action = -1,
				Mana = 20,
				Skill = Core.ML ? 60.0 : 30.0,
			},
			new(typeof(BackstabAbility), SpellName.Backstab, SpellSchool.Ninjitsu)
			{
				Name = "Backstab",
				Desc = "Requires the Ninja to be in Stealth in order to initiate the attack.  "
					 + "Applies a damage bonus to the attack, scaling with the Ninjitsu skill.",
				Enabled = Core.SE,
				Action = -1,
				Mana = 30,
				Skill = Core.ML ? 40.0 : 20.0,
			},
			new(typeof(ShadowJumpSpell), SpellName.ShadowJump, SpellSchool.Ninjitsu)
			{
				Name = "Shadow Jump",
				Desc = "While in Stealth, the Ninja can jump a considerable distance while hidden.  "
					 + "Upon landing, the Ninja’s Stealth ability determines if they remain hidden from view.",
				Enabled = Core.SE,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 15,
				Skill = 50.0,
			},
			new(typeof(MirrorImageSpell), SpellName.MirrorImage, SpellSchool.Ninjitsu)
			{
				Name = "Mirror Image",
				Desc = "Creates a Mirror Image of their self, which can absorb a single attack from an enemy before disappearing.  "
					 + "Ninjas can create up to 4 Mirror Images at a time, making it quite difficult to determine which Ninja is real.",
				Enabled = Core.SE,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 10,
				Skill = Core.ML ? 20.0 : 40.0,
			},
		};

		#endregion

		#region Bushido

		public static readonly SpellInfo[] Bushido =
		{
			new(typeof(HonorableExecutionAbility), SpellName.HonorableExecution, SpellSchool.Bushido)
			{
				Name = "Honorable Execution",
				Desc = "The samurai moves in for the killing blow, granting them enhanced attack speed for a short time after a successful blow is landed.  " 
					 + "An unsuccessful attack will cause great shame for the samurai, temporarily reducing ristance to all forms of damage.",
				Enabled = Core.SE,
				Action = -1,
				Skill = 25.0,
			},
			new(typeof(ConfidenceSpell), SpellName.Confidence, SpellSchool.Bushido)
			{
				Name = "Confidence",
				Desc = "A defensive stance that allows Stamina and Hit Points gain with each successful parry.",
				Enabled = Core.SE,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 10,
				Skill = 25.0,
			},
			new(typeof(EvasionSpell), SpellName.Evasion, SpellSchool.Bushido)
			{
				Name = "Evasion",
				Desc = "Increases the samurais' parry chance and grants the ability to parry direct damage attacks from various sources.",
				Enabled = Core.SE,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 10,
				Skill = 60.0,
			},
			new(typeof(CounterAttackSpell), SpellName.CounterAttack, SpellSchool.Bushido)
			{
				Name = "Counter Attack",
				Desc = "Places the samurai in a defensive stance that allows them to counter attack automatically on the next successfully parry.",
				Enabled = Core.SE,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 5,
				Skill = 40.0,
			},
			new(typeof(LightningStrikeAbility), SpellName.LightningStrike, SpellSchool.Bushido)
			{
				Name = "Lightning Strike",
				Desc = "Attunes the samurais' perception of their opponent, causing critical damage on the next attack.",
				Enabled = Core.SE,
				Action = -1,
				Mana = 5,
				Skill = 50.0,
			},
			new(typeof(MomentumStrikeAbility), SpellName.MomentumStrike, SpellSchool.Bushido)
			{
				Name = "Momentum Strike",
				Desc = "Allows a skilled samurai to initiate an attack on multiple opponents at once.  "
					 + "A successful attack on an opponent results in another attack on an adjacent opponent.",
				Enabled = Core.SE,
				Action = -1,
				Mana = 10,
				Skill = 70.0,
			},
		};

		#endregion

		#region Spellweaving

		public static readonly SpellInfo[] Spellweaving =
		{
			new(typeof(ArcaneCircleSpell), SpellName.ArcaneCircle, SpellSchool.Spellweaving)
			{
				Name = "Arcane Circle",
				Mantra = "Myrshalee",
				Desc = "Creates an Arcane Focus crystal which enhances other spellweaving spells.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 24,
			},
			new(typeof(GiftOfRenewalSpell), SpellName.GiftOfRenewal, SpellSchool.Spellweaving)
			{
				Name = "Gift of Renewal",
				Mantra = "Olorisstra",
				Desc = "Heals a target repeatedly for a short period of time.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 24,
			},
			new(typeof(ImmolatingWeaponSpell), SpellName.ImmolatingWeapon, SpellSchool.Spellweaving)
			{
				Name = "Immolating Weapon",
				Mantra = "Thalshara",
				Desc = "Enchants the caster's melee weapon with extra fire damage for a short duration.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 32,
				Skill = 10.0,
			},
			new(typeof(AttunementSpell), SpellName.Attunement, SpellSchool.Spellweaving)
			{
				Name = "Attunement",
				Mantra = "Haeldril",
				Desc = "Creates magical shield around the caster that absorbs melee damage.  "
					 + "Once the shield runs out of power, the caster recieves damage as normal.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 24,
			},
			new(typeof(ThunderstormSpell), SpellName.Thunderstorm, SpellSchool.Spellweaving)
			{
				Name = "Thunderstorm",
				Mantra = "Erelonia",
				Desc = "Deals mass energy damage around the caster and may cause enemy casters a Faster Casting Recovery penalty.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 32,
				Skill = 10.0,
			},
			new(typeof(NaturesFurySpell), SpellName.NaturesFury, SpellSchool.Spellweaving)
			{
				Name = "Natures' Fury",
				Mantra = "Rauvvrae",
				Desc = "Creates an uncontrollable swarm of insects that attack nearby enemies.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				AllowTown = false,
				Mana = 24,
			},
			new(typeof(SummonFeySpell), SpellName.SummonFey, SpellSchool.Spellweaving)
			{
				Name = "Summon Fey",
				Mantra = "Alalithra",
				Desc = "Summons one or more controllable Pixies.  "
					 + "To cast (and obtain) this spell you must first complete the Friend of the Fey Quest.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 10,
				Skill = 38.0,
			},
			new(typeof(SummonFiendSpell), SpellName.SummonFiend, SpellSchool.Spellweaving)
			{
				Name = "Summon Fiend",
				Mantra = "Nylisstra",
				Desc = "Summons one or more controllable Imps.  " 
					 + "To cast (and obtain) this spell you must first complete the Fiendish Friends Quest.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 10,
				Skill = 38.0,
			},
			new(typeof(ReaperFormSpell), SpellName.ReaperForm, SpellSchool.Spellweaving)
			{
				Name = "Reaper Form",
				Mantra = "Tarisstree",
				Desc = "Enhances the caster's swing speed, spell damage, and resists while penalizing fire resist and movement speed.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 34,
				Skill = 24.0,
			},
			new(/*typeof(WildfireSpell)*/null, SpellName.Wildfire, SpellSchool.Spellweaving)
			{
				Name = "Wildfire",
				Mantra = "Haelyn",
				Desc = "Creates a field of fire that damages enemies within it for a short time.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 50,
				Skill = 66.0,
			},
			new(typeof(EssenceOfWindSpell), SpellName.EssenceOfWind, SpellSchool.Spellweaving)
			{
				Name = "Essence Of Wind",
				Mantra = "Anathrae",
				Desc = "Deals cold damage and gives a swing speed and Faster Casting penalty to nearby enemies.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 40,
				Skill = 52.0,
			},
			new(/*typeof(DryadAllureSpell)*/null, SpellName.DryadAllure, SpellSchool.Spellweaving)
			{
				Name = "Dryad Allure",
				Mantra = "Rathril",
				Desc = "Charms a target (non-player) humanoid into doing the caster's bidding.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 40,
				Skill = 52.0,
			},
			new(typeof(EtherealVoyageSpell), SpellName.EtherealVoyage, SpellSchool.Spellweaving)
			{
				Name = "Ethereal Voyage",
				Mantra = "Orlavdra",
				Desc = "Prevents monsters from being able to see the caster for a short time.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 32,
				Skill = 24.0,
			},
			new(typeof(WordOfDeathSpell), SpellName.WordOfDeath, SpellSchool.Spellweaving)
			{
				Name = "Word Of Death",
				Mantra = "Nyraxle",
				Desc = "Does massive damage to creatures low in health.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 50,
				Skill = 83.0,
			},
			new(typeof(GiftOfLifeSpell), SpellName.GiftOfLife, SpellSchool.Spellweaving)
			{
				Name = "Gift Of Life",
				Mantra = "Illorae",
				Desc = "When in effect on the caster or caster's pet, the beneficiary will be resurrected upon death.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 70,
				Skill = 38.0,
			},
			new(/*typeof(ArcaneEmpowermentSpell)*/null, SpellName.ArcaneEmpowerment, SpellSchool.Spellweaving)
			{
				Name = "Arcane Empowerment",
				Mantra = "Aslavdra",
				Desc = "Enhances the caster's healing/damaging spells and increases the toughness of summons.",
				Enabled = Core.ML,
				Icon = 0,
				Back = 0,
				Action = -1,
				Mana = 50,
				Skill = 24.0,
			},
		};

		#endregion

		#region Mysticism

		public static readonly SpellInfo[] Mysticism =
		{
			new(typeof(NetherBoltSpell), SpellName.NetherBolt, SpellSchool.Mysticism, SpellCircle.First)
			{
				Name = "Nether Bolt",
				Mantra = "In Corp Ylem",
				Desc = "Conjures a bolt of nether energy to assault a target with chaos damage.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 4,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(HealingStoneSpell), SpellName.HealingStone, SpellSchool.Mysticism, SpellCircle.First)
			{
				Name = "Healing Stone",
				Mantra = "Kal In Mani",
				Desc = "Conjures a healing stone, usable only by the Mystic.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 4,
				Reagents =
				{
					[Reagent.Bone] = 1,
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(PurgeMagicSpell), SpellName.PurgeMagic, SpellSchool.Mysticism, SpellCircle.Second)
			{
				Name = "Purge Magic",
				Mantra = "An Ort Sanct",
				Desc = "Attempts to remove a beneficial ward from the Target, chosen randomly.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 6,
				Skill = 8.0,
				Reagents =
				{
					[Reagent.FertileDirt] = 1,
					[Reagent.Garlic] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(EnchantSpell), SpellName.Enchant, SpellSchool.Mysticism, SpellCircle.Second)
			{
				Name = "Enchant",
				Mantra = "In Ort Ylem",
				Desc = "Temporarily enchants a weapon with a hit spell effect chosen by the caster.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 6,
				Skill = 8.0,
				Reagents =
				{
					[Reagent.SpidersSilk] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(SleepSpell), SpellName.Sleep, SpellSchool.Mysticism, SpellCircle.Third)
			{
				Name = "Sleep",
				Mantra = "In Zu",
				Desc = "Puts the target into a temporary sleep state.  "
					 + "In this state, a slept target will attack, cast spells, and move at a much slower speed, "
					 + "in addition to having hit chance and defense chance reduced considerably.  "
					 + "A slept target will awaken if harmed or after a set amount of time.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 9,
				Skill = 20.0,
				Reagents =
				{
					[Reagent.Nightshade] = 1,
					[Reagent.SpidersSilk] = 1,
					[Reagent.BlackPearl] = 1,
				},
			},
			new(typeof(EagleStrikeSpell), SpellName.EagleStrike, SpellSchool.Mysticism, SpellCircle.Third)
			{
				Name = "Eagle Strike",
				Mantra = "Kal Por Xen",
				Desc = "Conjures a magical eagle-like creature as a projectile that assaults the target with its talons, dealing energy damage.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 9,
				Skill = 20.0,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.Bone] = 1,
					[Reagent.SpidersSilk] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(AnimatedWeaponSpell), SpellName.AnimatedWeapon, SpellSchool.Mysticism, SpellCircle.Fourth)
			{
				Name = "Animated Weapon",
				Mantra = "In Jux Por Ylem",
				Desc = "An Animated Weapon is conjured and attacks nearby foes.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 11,
				Skill = 33.0,
				Reagents =
				{
					[Reagent.Bone] = 1,
					[Reagent.BlackPearl] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
			new(typeof(StoneFormSpell), SpellName.StoneForm, SpellSchool.Mysticism, SpellCircle.Fourth)
			{
				Name = "Stone Form",
				Mantra = "In Rel Ylem",
				Desc = "Infuses the caster with the essence of solid stone, making him slow to fight and cast spells, "
					 + "but gives him resistances to curse and damage and a slight bonus to physical damage attacks.  "
					 + "The Stone Form may neutralize poison, strangle, bleed, sleep, and stat reduction effects.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 11,
				Skill = 33.0,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.FertileDirt] = 1,
					[Reagent.Garlic] = 1,
				},
			},
			new(typeof(SpellTriggerSpell), SpellName.SpellTrigger, SpellSchool.Mysticism, SpellCircle.Fifth)
			{
				Name = "Spell Trigger",
				Mantra = "In Vas Ort Ex",
				Desc = "This spell allows the Mystic to store one Mysticism spell in a spell trigger object that can be later triggered when the Mystic uses the item.  "
					 + "The Mystic invokes the Spell Trigger and selects the appropriate magic to trigger.  "
					 + "The Mystic must possess the triggered spell in his spellbook.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 14,
				Skill = 45.0,
				Reagents =
				{
					[Reagent.DragonsBlood] = 1,
					[Reagent.Garlic] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(MassSleepSpell), SpellName.MassSleep, SpellSchool.Mysticism, SpellCircle.Fifth)
			{
				Name = "Mass Sleep",
				Mantra = "Vas Zu",
				Desc = "Puts one or more Targets within a radius around the target's Location into a temporary sleep state.  "
					 + "In this state, slept targets will be unable to attack or cast spells, and will move at a much slower speed.  "
					 + "They will awaken if harmed or after a set amount of time.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 14,
				Skill = 45.0,
				Reagents =
				{
					[Reagent.Ginseng] = 1,
					[Reagent.Nightshade] = 1,
					[Reagent.SpidersSilk] = 1,
				}
			},
			new(typeof(CleansingWindsSpell), SpellName.CleansingWinds, SpellSchool.Mysticism, SpellCircle.Sixth)
			{
				Name = "Cleansing Winds",
				Mantra = "In Vas Mani Hur",
				Desc = "Soothing winds cure poison, lift curses, and heal all characters in a party within a small area of effect.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 20,
				Skill = 58.0,
				Reagents =
				{
					[Reagent.DragonsBlood] = 1,
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(BombardSpell), SpellName.Bombard, SpellSchool.Mysticism, SpellCircle.Sixth)
			{
				Name = "Bombard",
				Mantra = "Corp Por Ylem",
				Desc = "Hurls a magical boulder at the target, dealing physical damage.  "
					 + "This spell also has a chance to knockback and stun a player target.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 20,
				Skill = 58.0,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.DragonsBlood] = 1,
					[Reagent.Garlic] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(SpellPlagueSpell), SpellName.SpellPlague, SpellSchool.Mysticism, SpellCircle.Seventh)
			{
				Name = "Spell Plague",
				Mantra = "Vas Rel Jux Ort",
				Desc = "The target is hit with an explosion of chaos damage and then inflicted with the spell plague curse.  "
					 + "Each time the target is damaged while under the effect of the spell plague, they may suffer an explosion of chaos damage.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 40,
				Skill = 70.0,
				Reagents =
				{
					[Reagent.DaemonBone] = 1,
					[Reagent.DragonsBlood] = 1,
					[Reagent.Nightshade] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(HailStormSpell), SpellName.HailStorm, SpellSchool.Mysticism, SpellCircle.Seventh)
			{
				Name = "Hail Storm",
				Mantra = "Kal Des Ylem",
				Desc = "Summons a storm of hailstones that strikes all Targets within a radius around the target's location, dealing cold damage.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 40,
				Skill = 70.0,
				Reagents =
				{
					[Reagent.DragonsBlood] = 1,
					[Reagent.Bloodmoss] = 1,
					[Reagent.BlackPearl] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(NetherCycloneSpell), SpellName.NetherCyclone, SpellSchool.Mysticism, SpellCircle.Eighth)
			{
				Name = "Nether Cyclone",
				Mantra = "Grav Hur",
				Desc = "Summons a gale of lethal winds that strikes all targets within a radius around the targets' location, dealing chaos damage.  "
					 + "In addition to inflicting damage, each target temporarily loses a percentage of mana and stamina.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 50,
				Skill = 83.0,
				Reagents =
				{
					[Reagent.MandrakeRoot] = 1,
					[Reagent.Nightshade] = 1,
					[Reagent.SulfurousAsh] = 1,
					[Reagent.Bloodmoss] = 1,
				},
			},
			new(typeof(RisingColossusSpell), SpellName.RisingColossus, SpellSchool.Mysticism, SpellCircle.Eighth)
			{
				Name = "Rising Colossus",
				Mantra = "Kal Vas Xen Corp Ylem",
				Desc = "Summons a colossal stone titan that selects a Target to attack based off its intelligence and proximity.  "
					 + "The Rising Colossus disappears after a set amount of time.",
				Enabled = Core.SA,
				Icon = 0,
				Back = 0,
				Action = 230,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 50,
				Skill = 83.0,
				Reagents =
				{
					[Reagent.DaemonBone] = 1,
					[Reagent.DragonsBlood] = 1,
					[Reagent.FertileDirt] = 1,
					[Reagent.BlackPearl] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
		};

		#endregion

		#endregion

		#region Custom

		#region Avatar

		public static readonly SpellInfo[] Avatar =
		{
			new(typeof(DivineLightSpell), SpellName.DivineLight, SpellSchool.Avatar, SpellCircle.First)
			{
				Name = "Divine Light",
				Mantra = "He Ven In Lor",
				Desc = "Divinity lights the Avatars' way.",
				Enabled = true,
				Icon = 2245,
				Back = 9300,
				Action = 236,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 10,
				Tithe = 10,
				Skill = 20.0,
			},
			new(typeof(DivineGatewaySpell), SpellName.DivineGateway, SpellSchool.Avatar, SpellCircle.Fifth)
			{
				Name = "Divine Gateway",
				Mantra = "Hevs Grav Ohm Sepa",
				Desc = "Allows the Avatar to open a heavenly portal to another location.",
				Enabled = true,
				Icon = 2258,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 40,
				Tithe = 30,
				Skill = 80.0,
			},
			new(typeof(MarkOfGodsSpell), SpellName.MarkOfGods, SpellSchool.Avatar, SpellCircle.Fifth)
			{
				Name = "Mark Of Gods",
				Mantra = "Britemus Por Ylemis",
				Desc = "Invokes a powerful bolt of lightning to mark a rune for the Avatar.",
				Enabled = true,
				Icon = 2269,
				Back = 9300,
				Action = -1,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 10,
				Tithe = 10,
				Skill = 20.0,
			},
		};

		#endregion

		#region Cleric

		public static readonly SpellInfo[] Cleric =
		{
			new(typeof(AngelicFaithSpell), SpellName.AngelicFaith, SpellSchool.Cleric, SpellCircle.Eighth)
			{ 
				Name = "Angelic Faith",
				Mantra = "Angelus Terum",
				Desc = "The caster calls upon the divine powers of the heavens to transform himself into a holy angel.  "
					 + "The caster gains better regeneration rates and increased stats and skills.",
				Enabled = true,
				Icon = 2295,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 50, 
				Tithe = 100, 
				Skill = 80.0
			},
			new(typeof(BanishEvilSpell), SpellName.BanishEvil, SpellSchool.Cleric, SpellCircle.Sixth)
			{ 
				Name = "Banish Evil",
				Mantra = "Abigo Malus",
				Desc = "The caster calls forth a divine fire to banish his undead or demonic foe from the earth.",
				Enabled = true,
				Icon = 20739,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 40, 
				Tithe = 30, 
				Skill = 60.0
			},
			new(typeof(DampenSpiritSpell), SpellName.DampenSpirit, SpellSchool.Cleric, SpellCircle.Fourth)
			{ 
				Name = "Dampen Spirit",
				Mantra = "Abicio Spiritus",
				Desc = "The caster's enemy is slowly drained of his stamina, greatly hindering their ability to fight in combat or flee.",
				Enabled = true,
				Icon = 2270,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 11, 
				Tithe = 15, 
				Skill = 35.0
			},
			new(typeof(DivineFocusSpell), SpellName.DivineFocus, SpellSchool.Cleric, SpellCircle.First)
			{ 
				Name = "Divine Focus",
				Mantra = "Divinium Cogitatus",
				Desc = "The caster's mind focuses on his divine faith increasing the effect of his prayers.  "
					 + "However, the caster becomes mentally fatigued much faster.",
				Enabled = true,
				Icon = 2276,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 4, 
				Tithe = 15, 
				Skill = 35.0
			},
			new(typeof(HammerOfFaithSpell), SpellName.HammerOfFaith, SpellSchool.Cleric, SpellCircle.Fifth)
			{ 
				Name = "Hammer Of Faith",
				Mantra = "Malleus Terum",
				Desc = "Summons forth a divine hammer of pure energy blessed with the ability to vanquish undead foes with greater efficiency.",
				Enabled = true,
				Icon = 20741,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 14, 
				Tithe = 20, 
				Skill = 40.0
			},
			new(typeof(PurgeSpell), SpellName.Purge, SpellSchool.Cleric, SpellCircle.Second)
			{ 
				Name = "Purge",
				Mantra = "Repurgo",
				Desc = "The target is cured of all poisons and has all negative stat curses removed.",
				Enabled = true,
				Icon = 20744,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 6, 
				Tithe = 5, 
				Skill = 10.0
			},
			new(typeof(RestorationSpell), SpellName.Restoration, SpellSchool.Cleric, SpellCircle.Eighth)
			{ 
				Name = "Restoration",
				Mantra = "Reductio Aetas",
				Desc = "The caster's target is resurrected and fully healed and refreshed.",
				Enabled = true,
				Icon = 2298,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 50, 
				Tithe = 40, 
				Skill = 50.0
			},
			new(typeof(SacredBoonSpell), SpellName.SacredBoon, SpellSchool.Cleric, SpellCircle.Fourth)
			{ 
				Name = "Sacred Boon",
				Mantra = "Vir Consolatio",
				Desc = "The caster's target is surrounded by a divine wind that heals small amounts of lost life over time.",
				Enabled = true,
				Icon = 20742,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 11, 
				Tithe = 15, 
				Skill = 25.0
			},
			new(typeof(SacrificeSpell), SpellName.Sacrifice, SpellSchool.Cleric, SpellCircle.First)
			{ 
				Name = "Sacrifice",
				Mantra = "Adoleo",
				Desc = "The caster sacrifices himself for his allies.  "
					 + "Whenever damaged, all party members are healed a small percent of the damage dealt.  "
					 + "The caster still takes damage.",
				Enabled = true,
				Icon = 20743,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 4, 
				Tithe = 5, 
				Skill = 5.0
			},
			new(typeof(SmiteSpell), SpellName.Smite, SpellSchool.Cleric, SpellCircle.Eighth)
			{ 
				Name = "Smite",
				Mantra = "Ferio",
				Desc = "The caster calls to the heavens to send a deadly bolt of lightning to strike down his opponent.",
				Enabled = true,
				Icon = 2269,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 50, 
				Tithe = 60, 
				Skill = 80.0
			},
			new(typeof(TouchOfLifeSpell), SpellName.TouchOfLife, SpellSchool.Cleric, SpellCircle.Third)
			{ 
				Name = "Touch Of Life",
				Mantra = "Tactus Vitalis",
				Desc = "The caster's target is healed by the heavens for a significant amount.",
				Enabled = true,
				Icon = 2243,
				Back = 3500,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 9, 
				Tithe = 10, 
				Skill = 30.0
			},
			new(typeof(TrialByFireSpell), SpellName.TrialByFire, SpellSchool.Cleric, SpellCircle.Third)
			{ 
				Name = "Trial By Fire",
				Mantra = "Temptatio Exsuscito",
				Desc = "The caster is surrounded by a divine flame that damages the caster's enemy when hit by a weapon.",
				Enabled = true,
				Icon = 20736, 
				Back = 3500, 
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 9, 
				Tithe = 25, 
				Skill = 45.0
			},
		};

		#endregion

		#region Druid

		public static readonly SpellInfo[] Druid =
		{
            new(typeof(LeafWhirlwindSpell), SpellName.LeafWhirlwind, SpellSchool.Druid, SpellCircle.Sixth)
			{
				Name = "Leaf Whirlwind",
				Mantra = "Ess Lore En Ohm",
				Desc = "A gust of wind blows, picking up magic leaves that memorize where they have come from, marking a rune for the caster.",
				Enabled = true,
				Icon = 2271,
				Back = 5120,
				Action = 218,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				Mana = 25, 
				Skill = 50.0, 
				Reagents =
				{
					[Reagent.SpringWater] = 1,
					[Reagent.PetrifiedWood] = 1,
					[Reagent.DestroyingAngel] = 1,
				},
			},
            new(typeof(HollowReedSpell), SpellName.HollowReed, SpellSchool.Druid, SpellCircle.Second)
			{
				Name = "Hollow Reed",
				Mantra = "En Crur Aeta Sec En Ess",
				Desc = "Increases both the Strength and the Intelligence of the Druid.",
				Enabled = true,
				Icon = 2255,
				Back = 5120,
				Action = 203,
				LeftHandEffect = 9061,
				RightHandEffect = 9061,
				AllowTown = false,
				Mana = 30, 
				Skill = 30.0,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
			new(typeof(BeastPackSpell), SpellName.BeastPack, SpellSchool.Druid, SpellCircle.Third)
			{
				Name = "Pack Of Beasts",
				Mantra = "En Sec Ohm Ess Sepa",
				Desc = "Summons a pack of beasts to fight for the Druid.  " 
					 + "Spell length increases with skill.",
				Enabled = true,
				Icon = 20491,
				Back = 5120,
				Action = 266,
				LeftHandEffect = 9040,
				RightHandEffect = 9040,
				AllowTown = false,
				Mana = 45, 
				Skill = 40.0,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.BlackPearl] = 1,
					[Reagent.PetrifiedWood] = 1,
				},
			},
			new(typeof(SpringOfLifeSpell), SpellName.SpringOfLife, SpellSchool.Druid, SpellCircle.Fourth)
			{
				Name = "Spring of Life",
				Mantra = "En Sepa Aete",
				Desc = "Creates a magical spring that heals the Druid and their party.",
				Enabled = true,
				Icon = 2268,
				Back = 5120,
				Action = 204,
				LeftHandEffect = 9061,
				RightHandEffect = 9061,
				AllowTown = false,
				Mana = 40, 
				Skill = 40.0,
				Reagents =
				{
					[Reagent.SpringWater] = 1,
				},
			},
			new(typeof(GraspingRootsSpell), SpellName.GraspingRoots, SpellSchool.Druid, SpellCircle.Fifth)
			{
				Name = "Grasping Roots",
				Mantra = "En Ohm Sepa Tia Kes",
				Desc = "Summons roots from the ground to entangle a single target.",
				Enabled = true,
				Icon = 2293,
				Back = 5120,
				Action = 218,
				LeftHandEffect = 9012,
				RightHandEffect = 9012,
				AllowTown = false,
				Mana = 40, 
				Skill = 40.0,
				Reagents =
				{
					[Reagent.SpringWater] = 1,
					[Reagent.Bloodmoss] = 1,
					[Reagent.SpidersSilk] = 1,
				},
			},
			new(typeof(BlendWithForestSpell), SpellName.BlendWithForest, SpellSchool.Druid, SpellCircle.Sixth)
			{
				Name = "Blend With Forest",
				Mantra = "Kes Ohm",
				Desc = "The Druid blends seamlessly with the background, becoming invisible to their foes.",
				Enabled = true,
				Icon = 2249,
				Back = 5120,
				Action = 206,
				LeftHandEffect = 9002,
				RightHandEffect = 9002,
				AllowTown = false,
				Mana = 60, 
				Skill = 75.0,
				Reagents =
				{
					[Reagent.Bloodmoss] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
			new(typeof(SwarmOfInsectsSpell), SpellName.SwarmOfInsects, SpellSchool.Druid, SpellCircle.Seventh)
			{
				Name = "Swarm of Insects",
				Mantra = "Ess Ohm En Sec Tia",
				Desc = "Summons a swarm of insects that bite and sting the Druids' enemies.",
				Enabled = true,
				Icon = 2272,
				Back = 5120,
				Action = 263,
				LeftHandEffect = 9032,
				RightHandEffect = 9032,
				AllowTown = false,
				Mana = 70, 
				Skill = 85.0,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Nightshade] = 1,
					[Reagent.DestroyingAngel] = 1,
				},
			},
			new(typeof(VolcanicEruptionSpell), SpellName.VolcanicEruption, SpellSchool.Druid, SpellCircle.Eighth)
			{
				Name = "Volcanic Eruption",
				Mantra = "Vauk Ohm En Tia Crur",
				Desc = "A blast of molten lava bursts from the ground, damaging nearby enemies.",
				Enabled = true,
				Icon = 2296,
				Back = 5120,
				Action = 245,
				LeftHandEffect = 9042,
				RightHandEffect = 9042,
				AllowTown = false,
				Mana = 85, 
				Skill = 98.0,
				Reagents =
				{
					[Reagent.SulfurousAsh] = 1,
					[Reagent.DestroyingAngel] = 1,
				},
			},
			new(typeof(DruidFamiliarSpell), SpellName.DruidFamiliar, SpellSchool.Druid, SpellCircle.Sixth)
			{
				Name = "Summon Familiar",
				Mantra = "Lore Sec En Sepa Ohm",
				Desc = "Summons a familiar that can aid the Druid.",
				Enabled = true,
				Icon = 2295,
				Back = 5120,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 17, 
				Skill = 30.0,
				Reagents =
				{
					[Reagent.MandrakeRoot] = 1,
					[Reagent.SpringWater] = 1,
					[Reagent.PetrifiedWood] = 1,
				},
			},
			new(typeof(StoneCircleSpell), SpellName.StoneCircle, SpellSchool.Druid, SpellCircle.Sixth)
			{
				Name = "Stone Circle",
				Mantra = "En Ess Ohm",
				Desc = "Forms an impassable circle of stones.",
				Enabled = true,
				Icon = 2263,
				Back = 5120,
				Action = 266,
				LeftHandEffect = 9040,
				RightHandEffect = 9040,
				AllowTown = false,
				Mana = 45, 
				Skill = 60.0,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.SpringWater] = 1,
				},
			},
			new(typeof(EnchantedGroveSpell), SpellName.EnchantedGrove, SpellSchool.Druid, SpellCircle.Eighth)
			{
				Name = "Enchanted Grove",
				Mantra = "En Ante Ohm Sepa",
				Desc = "Creates a grove of trees to grow around the Druid, restoring vitality.",
				Enabled = true,
				Icon = 2280,
				Back = 5120,
				Action = 266,
				LeftHandEffect = 9040,
				RightHandEffect = 9040,
				AllowTown = false,
				Mana = 60, 
				Skill = 95.0,
				Reagents =
				{
					[Reagent.MandrakeRoot] = 1,
					[Reagent.PetrifiedWood] = 1,
					[Reagent.SpringWater] = 1,
				},
			},
			new(typeof(LureStoneSpell), SpellName.LureStone, SpellSchool.Druid, SpellCircle.Second)
			{
				Name = "Lure Stone",
				Mantra = "En Kes Ohm Crur",
				Desc = "Creates a magical stone that calls nearby animals to it.",
				Enabled = true,
				Icon = 2294,
				Back = 5120,
				Action = 269,
				LeftHandEffect = 9020,
				RightHandEffect = 9020,
				AllowTown = false,
				Mana = 30, 
				Skill = 15.0,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.SpringWater] = 1,
				},
			},
            new(typeof(NaturesPassageSpell), SpellName.NaturesPassage, SpellSchool.Druid, SpellCircle.Fourth)
			{
				Name = "Nature's Passage",
				Mantra = "Kes Sec Vauk",
				Desc = "The Druid is transformed into flower petals and carried on the wind to their destination.",
				Enabled = true,
				Icon = 2297,
				Back = 5120,
				Action = 239,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 10, 
				Skill = 15.0,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.Bloodmoss] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(MushroomGatewaySpell), SpellName.MushroomGateway, SpellSchool.Druid, SpellCircle.Seventh)
			{
				Name = "Mushroom Gateway",
				Mantra = "Vauk Sepa Ohm",
				Desc = "A magical circle of mushrooms opens, allowing the Druid to step through it to another location.",
				Enabled = true,
				Icon = 2291,
				Back = 5120,
				Action = 263,
				LeftHandEffect = 9032,
				RightHandEffect = 9032,
				Mana = 40, 
				Skill = 70.0,
				Reagents =
				{
					[Reagent.BlackPearl] = 1,
					[Reagent.SpringWater] = 1,
					[Reagent.MandrakeRoot] = 1,
				},
			},
			new(typeof(RestorativeSoilSpell), SpellName.RestorativeSoil, SpellSchool.Druid, SpellCircle.Eighth)
			{
				Name = "Restorative Soil",
				Mantra = "Ohm Sepa Ante",
				Desc = "Saturates a patch of land with power, causing life giving mud to seep through.",
				Enabled = true,
				Icon = 2298,
				Back = 5120,
				Action = 269,
				LeftHandEffect = 9020,
				RightHandEffect = 9020,
				Mana = 55, 
				Skill = 89.0,
				Reagents =
				{
					[Reagent.Garlic] = 1,
					[Reagent.Ginseng] = 1,
					[Reagent.SpringWater] = 1,
				},
			},
			new(typeof(ShieldOfEarthSpell), SpellName.ShieldOfEarth, SpellSchool.Druid, SpellCircle.First)
			{
				Name = "Shield of Earth",
				Mantra = "Kes En Sepa Ohm",
				Desc = "A quick sprouting wall of foliage springs up at the bidding of the Druid.",
				Enabled = true,
				Icon = 2254, 
				Back = 5120, 
				Action = 227,
				LeftHandEffect = 9011,
				RightHandEffect = 9011,
				AllowTown = false,
				Mana = 15, 
				Skill = 20.0,
				Reagents =
				{
					[Reagent.Ginseng] = 1,
					[Reagent.SpringWater] = 1,
				},
			},
		};

		#endregion

		#region Ranger

		public static readonly SpellInfo[] Ranger =
		{
			new(typeof(HuntersAimSpell), SpellName.HuntersAim, SpellSchool.Ranger, SpellCircle.Fourth)
			{
				Name = "Hunters' Aim",
				Mantra = "Cu Ner Sinta",
				Desc = "Increases the Rangers archery, and tactics for a short period of time.",
				Enabled = true,
				Icon = 2244,
				Back = 5054,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 25,
				Skill = 50.0,
				Reagents =
				{
					[Reagent.Nightshade] = 1,
					[Reagent.SpringWater] = 1,
					[Reagent.Bloodmoss] = 1,
				},
			},
			new(typeof(PhoenixFlightSpell), SpellName.PhoenixFlight, SpellSchool.Ranger, SpellCircle.Fourth)
			{
				Name = "Phoenix Flight",
				Mantra = "Kurwa Vilya Thoron",
				Desc = "Calls Forth a Phoenix who will carry you to the location of your choice.",
				Enabled = true,
				Icon = 20736,
				Back = 5054,
				Action = 239,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 10,
				Skill = 15.0,
				Reagents =
				{
					[Reagent.SulfurousAsh] = 1,
					[Reagent.PetrifiedWood] = 1,
				},
			},
			new(typeof(AnimalCompanionSpell), SpellName.AnimalCompanion, SpellSchool.Ranger, SpellCircle.Sixth)
			{
				Name = "Animal Companion",
				Mantra = "Sinta Kurwa Ner Arda Moina",
				Desc = "The Ranger summons an animal companion (based on skill level) to aid him in his quests.",
				Enabled = true,
				Icon = 20491,
				Back = 5054,
				Action = 203,
				LeftHandEffect = 9031,
				RightHandEffect = 9031,
				Mana = 17,
				Skill = 30.0,
				Reagents =
				{
					[Reagent.DestroyingAngel] = 1,
					[Reagent.SpringWater] = 1,
					[Reagent.PetrifiedWood] = 1,
				},
			},
			new(typeof(CallMountSpell), SpellName.CallMount, SpellSchool.Ranger, SpellCircle.Fifth)
			{
				Name = "Call Mount",
				Desc = "The Ranger calls to the Wilds, summoning a speedy mount to his side.",
				Enabled = true,
				Icon = 20745,
				Back = 5054,
				Action = 266,
				LeftHandEffect = 9040,
				RightHandEffect = 9040,
				Mana = 15,
				Skill = 30.0,
				Reagents =
				{
					[Reagent.SpringWater] = 1,
					[Reagent.BlackPearl] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(FireBowSpell), SpellName.FireBow, SpellSchool.Ranger, SpellCircle.Fifth)
			{
				Name = "Fire Bow",
				Mantra = "Kurwa Naur Cu",
				Desc = "The Ranger uses his knowledge of archery and hunting to craft a temporary fire elemental bow, that lasts for a short duration.",
				Enabled = true,
				Icon = 2257,
				Back = 5054,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 30,
				Skill = 85.0,
				Reagents =
				{
					[Reagent.Kindling] = 1,
					[Reagent.SulfurousAsh] = 1,
				},
			},
			new(typeof(IceBowSpell), SpellName.IceBow, SpellSchool.Ranger, SpellCircle.Fifth)
			{
				Name = "Ice Bow",
				Mantra = "Kurwa Khelek Cu",
				Desc = "The Ranger uses his knowledge of archery and hunting to craft a temporary ice elemental bow, that lasts for a short duration.",
				Enabled = true,
				Icon = 21001,
				Back = 5054,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 30,
				Skill = 85.0,
				Reagents =
				{
					[Reagent.Kindling] = 1,
					[Reagent.SpringWater] = 1,
				},
			},
			new(typeof(LightningBowSpell), SpellName.LightningBow, SpellSchool.Ranger, SpellCircle.Fifth)
			{
				Name = "Lightning Bow",
				Mantra = "Kurwa Vilya Cu",
				Desc = "The Ranger uses his knowledge of archery and hunting to craft a temporary lightning elemental bow, that lasts for a short duration.",
				Enabled = true,
				Icon = 2281,
				Back = 5054,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 30,
				Skill = 90.0,
				Reagents =
				{
					[Reagent.Kindling] = 1,
					[Reagent.BlackPearl] = 1,
				},
			},
			new(typeof(NoxBowSpell), SpellName.NoxBow, SpellSchool.Ranger, SpellCircle.Fifth)
			{
				Name = "Nox Bow",
				Mantra = "Kurwa Kshapsa Cu",
				Desc = "The Ranger uses his knowledge of archery and hunting to craft a temporary poison elemental bow, that lasts for a short duration.",
				Enabled = true,
				Icon = 20488,
				Back = 5054,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Mana = 30,
				Skill = 95.0,
				Reagents =
				{
					[Reagent.Kindling] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
		};

		#endregion

		#region Rogue

		public static readonly SpellInfo[] Rogue =
		{
			new(typeof(IntimidationSpell), SpellName.Intimidation, SpellSchool.Rogue, SpellCircle.Fourth)
			{
				Name = "Intimidation",
				Desc = "The Rogue begins to appear enraged, at the loss of their skills.",
				Enabled = true,
				Icon = 20485,
				Back = 5100,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
			},
			new(typeof(ShadowBlendSpell), SpellName.ShadowBlend, SpellSchool.Rogue, SpellCircle.Fourth)
			{
				Name = "Shadow Blend",
				Desc = "The Rogue slips into the shadows.",
				Enabled = true,
				Icon = 21003,
				Back = 5100,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Reagents =
				{
					[Reagent.SpidersSilk] = 1,
					[Reagent.DaemonBlood] = 1,
					[Reagent.BlackPearl] = 1,
				},
			},
			new(typeof(SlyFoxSpell), SpellName.SlyFox, SpellSchool.Rogue, SpellCircle.Fourth)
			{
				Name = "Sly Fox",
				Desc = "The Rogue transforms into a stealthly Sly Fox.",
				Enabled = true,
				Icon = 20491,
				Back = 5100,
				Action = 212,
				LeftHandEffect = 9041,
				RightHandEffect = 9041,
				Reagents =
				{
					[Reagent.PetrifiedWood] = 1,
					[Reagent.NoxCrystal] = 1,
					[Reagent.Nightshade] = 1,
				},
			},
		};

		#endregion

		#endregion

		#region Racial

		#region Human

		public static readonly SpellInfo[] Human =
		{
			new(typeof(StrongBackRacialAbility), SpellName.StrongBack, SpellSchool.Human)
			{
				Name = "Strong Back",
				Desc = "Humans have an increased carrying capacity above what is determined by their strength.",
				Enabled = Core.AOS,
				Icon = 24016,
				Back = 9350,
				Action = -1,
			},
			new(typeof(ToughnessRacialAbility), SpellName.Toughness, SpellSchool.Human)
			{
				Name = "Toughness",
				Desc = "Humans regenerate hit points faster than normal.",
				Enabled = Core.AOS,
				Icon = 24017,
				Back = 9350,
				Action = -1,
			},
			new(typeof(WorkhorseRacialAbility), SpellName.WorkHorse, SpellSchool.Human)
			{
				Name = "Workhorse",
				Desc = "Humans have a better chance at finding more resources while gathering hides, ore, and lumber.",
				Enabled = Core.AOS,
				Icon = 24018,
				Back = 9350,
				Action = -1,
			},
			new(typeof(JackOfAllTradesRacialAbility), SpellName.JackOfAllTrades, SpellSchool.Human)
			{
				Name = "Jack Of All Trades",
				Desc = "Humans have a basic ability in all skills, even untrained ones.",
				Enabled = Core.AOS,
				Icon = 24019,
				Back = 9350,
				Action = -1,
			},
			new(typeof(MasterArtisanRacialAbility), SpellName.MasterArtisan, SpellSchool.Human)
			{
				Name = "Master Artisan",
				Desc = "A strong cultural emphasis on art and craftsmanship grants the humans an increased chance to imbue and unravel magical items.",
				Enabled = Core.SA,
				Icon = 24019,
				Back = 9350,
				Action = -1,
			},
		};

		#endregion

		#region Elf

		public static readonly SpellInfo[] Elf =
		{
			new(typeof(NightVisionRacialAbility), SpellName.NightVision, SpellSchool.Elf)
			{
				Name = "Night Vision",
				Desc = "Elves always have the effect of a full strength Night Sight spell.",
				Enabled = Core.AOS,
				Icon = 24020,
				Back = 9350,
				Action = -1,
			},
			new(typeof(InfusedWithMagicRacialAbility), SpellName.InfusedWithMagic, SpellSchool.Elf)
			{
				Name = "Infused With Magic",
				Desc = "Elves have an increased energy resistance cap.  "
					 + "Elven players must still increase their actual resistances through normal means (i.e. through equipment and magical effects).",
				Enabled = Core.AOS,
				Icon = 24021,
				Back = 9350,
				Action = -1,
			},
			new(typeof(KnowledgeOfNatureRacialAbility), SpellName.KnowledgeOfNature, SpellSchool.Elf)
			{
				Name = "Knowledge Of Nature",
				Desc = "Elves receive an increase to their chance of acquiring special resources such as colored ore when mining or special boards when lumberjacking.",
				Enabled = Core.AOS,
				Icon = 24022,
				Back = 9350,
				Action = -1,
			},
			new(typeof(EvasiveRacialAbility), SpellName.Evasive, SpellSchool.Elf)
			{
				Name = "Evasive",
				Desc = "Elves are more difficult to track than other races.",
				Enabled = Core.AOS,
				Icon = 24023,
				Back = 9350,
				Action = -1,
			},
			new(typeof(PerceptiveRacialAbility), SpellName.Perceptive, SpellSchool.Elf)
			{
				Name = "Perceptive",
				Desc = "Elves gain an increased chance to passively detect hidden monsters and enemies.",
				Enabled = Core.AOS,
				Icon = 24024,
				Back = 9350,
				Action = -1,
			},
			new(typeof(WisdomRacialAbility), SpellName.Wisdom, SpellSchool.Elf)
			{
				Name = "Wisdom",
				Desc = "Elves receive a bonus to their maximum mana.",
				Enabled = Core.AOS,
				Icon = 24025,
				Back = 9350,
				Action = -1,
			},
		};

		#endregion

		#region Gargoyle

		public static readonly SpellInfo[] Gargoyle =
		{
			new(typeof(FlyingRacialAbility), SpellName.Flying, SpellSchool.Gargoyle)
			{
				Name = "Flying",
				Desc = "A Gargoyle's powerful wings carries them over land as fast as a galloping horse and grants them access to special Gargoyle-only areas.",
				Enabled = Core.SA,
				Icon = 24026,
				Back = 9350,
				Action = -1,
			},
			new(typeof(BerserkRacialAbility), SpellName.Berserk, SpellSchool.Gargoyle)
			{
				Name = "Berserk",
				Desc = "In situations of great danger, a Gargoyle's natural ferocity will take over, granting speed and power at the cost of defenses.",
				Enabled = Core.SA,
				Icon = 24027,
				Back = 9350,
				Action = -1,
			},
			new(typeof(DeadlyAimRacialAbility), SpellName.DeadlyAim, SpellSchool.Gargoyle)
			{
				Name = "Deadly Aim",
				Desc = "All Gargoyle's are trained from childhood in the skill of Throwing, giving them a basic competence with missile weapons.",
				Enabled = Core.SA,
				Icon = 24029,
				Back = 9350,
				Action = -1,
			},
			new(typeof(MysticInsightRacialAbility), SpellName.MysticInsight, SpellSchool.Gargoyle)
			{
				Name = "Mystic Insight",
				Desc = "Gargoyle's have an intuitive understanding of Mysticism, allowing them to cast basic Mysticism spells without further training.",
				Enabled = Core.SA,
				Icon = 24030,
				Back = 9350,
				Action = -1,
			},
		};

		#endregion

		#endregion
	}
}