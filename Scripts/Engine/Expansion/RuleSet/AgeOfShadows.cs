using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.Magery;
using Server.Spells.Ninjitsu;

using System;
using System.Collections.Generic;

namespace Server
{
	public class AOS
	{
		public static void DisableStatInfluences()
		{
			for (var i = 0; i < SkillInfo.Table.Length; ++i)
			{
				var info = SkillInfo.Table[i];

				info.StrScale = 0.0;
				info.DexScale = 0.0;
				info.IntScale = 0.0;
				info.StatTotal = 0.0;
			}
		}

		public static int Damage(Mobile m, int damage, bool ignoreArmor, int phys, int fire, int cold, int pois, int nrgy)
		{
			return Damage(m, null, damage, ignoreArmor, phys, fire, cold, pois, nrgy);
		}

		public static int Damage(Mobile m, int damage, int phys, int fire, int cold, int pois, int nrgy)
		{
			return Damage(m, null, damage, phys, fire, cold, pois, nrgy);
		}

		public static int Damage(Mobile m, Mobile from, int damage, int phys, int fire, int cold, int pois, int nrgy)
		{
			return Damage(m, from, damage, false, phys, fire, cold, pois, nrgy, 0, 0, false, false, false);
		}

		public static int Damage(Mobile m, Mobile from, int damage, int phys, int fire, int cold, int pois, int nrgy, int chaos)
		{
			return Damage(m, from, damage, false, phys, fire, cold, pois, nrgy, chaos, 0, false, false, false);
		}

		public static int Damage(Mobile m, Mobile from, int damage, bool ignoreArmor, int phys, int fire, int cold, int pois, int nrgy)
		{
			return Damage(m, from, damage, ignoreArmor, phys, fire, cold, pois, nrgy, 0, 0, false, false, false);
		}

		public static int Damage(Mobile m, Mobile from, int damage, int phys, int fire, int cold, int pois, int nrgy, bool keepAlive)
		{
			return Damage(m, from, damage, false, phys, fire, cold, pois, nrgy, 0, 0, keepAlive, false, false);
		}

		public static int Damage(Mobile m, Mobile from, int damage, bool ignoreArmor, int phys, int fire, int cold, int pois, int nrgy, int chaos, int direct, bool keepAlive, bool archer, bool deathStrike)
		{
			if (m == null || m.Deleted || !m.Alive || damage <= 0)
			{
				return 0;
			}

			if (phys == 0 && fire == 100 && cold == 0 && pois == 0 && nrgy == 0)
			{
				Mobiles.MeerMage.StopEffect(m, true);
			}

			if (!Core.AOS)
			{
				m.Damage(damage, from);
				return damage;
			}

			Fix(ref phys);
			Fix(ref fire);
			Fix(ref cold);
			Fix(ref pois);
			Fix(ref nrgy);
			Fix(ref chaos);
			Fix(ref direct);

			if (Core.ML && chaos > 0)
			{
				switch (Utility.Random(5))
				{
					case 0: phys += chaos; break;
					case 1: fire += chaos; break;
					case 2: cold += chaos; break;
					case 3: pois += chaos; break;
					case 4: nrgy += chaos; break;
				}
			}

			BaseQuiver quiver = null;

			if (archer && from != null)
			{
				quiver = from.FindItemOnLayer(Layer.Cloak) as BaseQuiver;
			}

			int totalDamage;

			if (!ignoreArmor)
			{
				// Armor Ignore on OSI ignores all defenses, not just physical.
				var resPhys = m.PhysicalResistance;
				var resFire = m.FireResistance;
				var resCold = m.ColdResistance;
				var resPois = m.PoisonResistance;
				var resNrgy = m.EnergyResistance;

				totalDamage = damage * phys * (100 - resPhys);
				totalDamage += damage * fire * (100 - resFire);
				totalDamage += damage * cold * (100 - resCold);
				totalDamage += damage * pois * (100 - resPois);
				totalDamage += damage * nrgy * (100 - resNrgy);

				totalDamage /= 10000;

				if (Core.ML)
				{
					totalDamage += damage * direct / 100;

					if (quiver != null)
					{
						totalDamage += totalDamage * quiver.DamageIncrease / 100;
					}
				}

				if (totalDamage < 1)
				{
					totalDamage = 1;
				}
			}
			else if (Core.ML && m is PlayerMobile && from is PlayerMobile)
			{
				if (quiver != null)
				{
					damage += damage * quiver.DamageIncrease / 100;
				}

				if (!deathStrike)
				{
					totalDamage = Math.Min(damage, 35); // Direct Damage cap of 35
				}
				else
				{
					totalDamage = Math.Min(damage, 70); // Direct Damage cap of 70
				}
			}
			else
			{
				totalDamage = damage;

				if (Core.ML && quiver != null)
				{
					totalDamage += totalDamage * quiver.DamageIncrease / 100;
				}
			}

			#region Dragon Barding
			if ((from == null || !from.Player) && m.Player && m.Mount is SwampDragon)
			{
				if (m.Mount is SwampDragon pet && pet.HasBarding)
				{
					var percent = pet.BardingExceptional ? 20 : 10;
					var absorbed = Scale(totalDamage, percent);

					totalDamage -= absorbed;
					pet.BardingHP -= absorbed;

					if (pet.BardingHP < 0)
					{
						pet.HasBarding = false;
						pet.BardingHP = 0;

						m.SendLocalizedMessage(1053031); // Your dragon's barding has been destroyed!
					}
				}
			}
			#endregion

			if (keepAlive && totalDamage > m.Hits)
			{
				totalDamage = m.Hits;
			}

			if (from != null && !from.Deleted && from.Alive)
			{
				var reflectPhys = AosAttributes.GetValue(m, AosAttribute.ReflectPhysical);

				if (reflectPhys != 0)
				{
					if ((from is ExodusMinion em && em.FieldActive) || (from is ExodusOverseer eo && eo.FieldActive))
					{
						from.FixedParticles(0x376A, 20, 10, 0x2530, EffectLayer.Waist);
						from.PlaySound(0x2F4);

						m.SendAsciiMessage("Your weapon cannot penetrate the creature's magical barrier");
					}
					else
					{
						from.Damage(Scale(damage * phys * (100 - (ignoreArmor ? 0 : m.PhysicalResistance)) / 10000, reflectPhys), m);
					}
				}
			}

			m.Damage(totalDamage, from);

			return totalDamage;
		}

		public static void Fix(ref int val)
		{
			if (val < 0)
			{
				val = 0;
			}
		}

		public static int Scale(int input, int percent)
		{
			return input * percent / 100;
		}

		public static int GetStatus(Mobile from, int index)
		{
			return index switch
			{
				// TODO: Account for buffs/debuffs
				0 => from.GetMaxResistance(ResistanceType.Physical),
				1 => from.GetMaxResistance(ResistanceType.Fire),
				2 => from.GetMaxResistance(ResistanceType.Cold),
				3 => from.GetMaxResistance(ResistanceType.Poison),
				4 => from.GetMaxResistance(ResistanceType.Energy),
				5 => AosAttributes.GetValue(from, AosAttribute.DefendChance),
				6 => 45,
				7 => AosAttributes.GetValue(from, AosAttribute.AttackChance),
				8 => AosAttributes.GetValue(from, AosAttribute.WeaponSpeed),
				9 => AosAttributes.GetValue(from, AosAttribute.WeaponDamage),
				10 => AosAttributes.GetValue(from, AosAttribute.LowerRegCost),
				11 => AosAttributes.GetValue(from, AosAttribute.SpellDamage),
				12 => AosAttributes.GetValue(from, AosAttribute.CastRecovery),
				13 => AosAttributes.GetValue(from, AosAttribute.CastSpeed),
				14 => AosAttributes.GetValue(from, AosAttribute.LowerManaCost),
				_ => 0,
			};
		}
	}

	[Flags]
	public enum AosAttribute : ulong
	{
		RegenHits = 0x00000001,
		RegenStam = 0x00000002,
		RegenMana = 0x00000004,
		DefendChance = 0x00000008,
		AttackChance = 0x00000010,
		BonusStr = 0x00000020,
		BonusDex = 0x00000040,
		BonusInt = 0x00000080,
		BonusHits = 0x00000100,
		BonusStam = 0x00000200,
		BonusMana = 0x00000400,
		WeaponDamage = 0x00000800,
		WeaponSpeed = 0x00001000,
		SpellDamage = 0x00002000,
		CastRecovery = 0x00004000,
		CastSpeed = 0x00008000,
		LowerManaCost = 0x00010000,
		LowerRegCost = 0x00020000,
		ReflectPhysical = 0x00040000,
		EnhancePotions = 0x00080000,
		Luck = 0x00100000,
		SpellChanneling = 0x00200000,
		NightSight = 0x00400000,
		IncreasedKarmaLoss = 0x00800000
	}

	public sealed class AosAttributes : BaseAttributes
	{
		[CommandProperty(AccessLevel.GameMaster)]
		public int RegenHits { get => this[AosAttribute.RegenHits]; set => this[AosAttribute.RegenHits] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int RegenStam { get => this[AosAttribute.RegenStam]; set => this[AosAttribute.RegenStam] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int RegenMana { get => this[AosAttribute.RegenMana]; set => this[AosAttribute.RegenMana] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int DefendChance { get => this[AosAttribute.DefendChance]; set => this[AosAttribute.DefendChance] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int AttackChance { get => this[AosAttribute.AttackChance]; set => this[AosAttribute.AttackChance] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BonusStr { get => this[AosAttribute.BonusStr]; set => this[AosAttribute.BonusStr] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BonusDex { get => this[AosAttribute.BonusDex]; set => this[AosAttribute.BonusDex] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BonusInt { get => this[AosAttribute.BonusInt]; set => this[AosAttribute.BonusInt] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BonusHits { get => this[AosAttribute.BonusHits]; set => this[AosAttribute.BonusHits] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BonusStam { get => this[AosAttribute.BonusStam]; set => this[AosAttribute.BonusStam] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BonusMana { get => this[AosAttribute.BonusMana]; set => this[AosAttribute.BonusMana] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int WeaponDamage { get => this[AosAttribute.WeaponDamage]; set => this[AosAttribute.WeaponDamage] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int WeaponSpeed { get => this[AosAttribute.WeaponSpeed]; set => this[AosAttribute.WeaponSpeed] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SpellDamage { get => this[AosAttribute.SpellDamage]; set => this[AosAttribute.SpellDamage] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CastRecovery { get => this[AosAttribute.CastRecovery]; set => this[AosAttribute.CastRecovery] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CastSpeed { get => this[AosAttribute.CastSpeed]; set => this[AosAttribute.CastSpeed] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int LowerManaCost { get => this[AosAttribute.LowerManaCost]; set => this[AosAttribute.LowerManaCost] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int LowerRegCost { get => this[AosAttribute.LowerRegCost]; set => this[AosAttribute.LowerRegCost] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int ReflectPhysical { get => this[AosAttribute.ReflectPhysical]; set => this[AosAttribute.ReflectPhysical] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int EnhancePotions { get => this[AosAttribute.EnhancePotions]; set => this[AosAttribute.EnhancePotions] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Luck { get => this[AosAttribute.Luck]; set => this[AosAttribute.Luck] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SpellChanneling { get => this[AosAttribute.SpellChanneling]; set => this[AosAttribute.SpellChanneling] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int NightSight { get => this[AosAttribute.NightSight]; set => this[AosAttribute.NightSight] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int IncreasedKarmaLoss { get => this[AosAttribute.IncreasedKarmaLoss]; set => this[AosAttribute.IncreasedKarmaLoss] = value; }

		public int this[AosAttribute attribute]
		{
			get => GetValue((ulong)attribute);
			set => SetValue((ulong)attribute, value);
		}

		public AosAttributes(IEntity owner)
			: base(owner)
		{
		}

		public AosAttributes(IEntity owner, AosAttributes other)
			: base(owner, other)
		{
		}

		public AosAttributes(IEntity owner, GenericReader reader)
			: base(owner, reader)
		{
		}

		public override string ToString()
		{
			return "...";
		}

		public void AddStatBonuses(Mobile to)
		{
			var strBonus = BonusStr;
			var dexBonus = BonusDex;
			var intBonus = BonusInt;

			if (strBonus != 0 || dexBonus != 0 || intBonus != 0)
			{
				var modName = Owner.Serial.ToString();

				if (strBonus != 0)
				{
					to.AddStatMod(new StatMod(StatType.Str, modName + "Str", strBonus, TimeSpan.Zero));
				}

				if (dexBonus != 0)
				{
					to.AddStatMod(new StatMod(StatType.Dex, modName + "Dex", dexBonus, TimeSpan.Zero));
				}

				if (intBonus != 0)
				{
					to.AddStatMod(new StatMod(StatType.Int, modName + "Int", intBonus, TimeSpan.Zero));
				}
			}

			to.CheckStatTimers();
		}

		public void RemoveStatBonuses(Mobile from)
		{
			var modName = Owner.Serial.ToString();

			_ = from.RemoveStatMod(modName + "Str");
			_ = from.RemoveStatMod(modName + "Dex");
			_ = from.RemoveStatMod(modName + "Int");

			from.CheckStatTimers();
		}

		public static int GetValue(Mobile m, AosAttribute attribute)
		{
			if (!Core.AOS)
			{
				return 0;
			}

			var items = m.Items;
			var value = 0;

			for (var i = 0; i < items.Count; ++i)
			{
				var obj = items[i];

				if (obj is BaseWeapon w)
				{
					var attrs = w.Attributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}

					if (attribute == AosAttribute.Luck)
					{
						value += w.GetLuckBonus();
					}
				}
				else if (obj is BaseArmor a)
				{
					var attrs = a.Attributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}

					if (attribute == AosAttribute.Luck)
					{
						value += a.GetLuckBonus();
					}
				}
				else if (obj is BaseJewel j)
				{
					var attrs = j.Attributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}
				}
				else if (obj is BaseClothing c)
				{
					var attrs = c.Attributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}
				}
				else if (obj is Spellbook s)
				{
					var attrs = s.Attributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}
				}
				else if (obj is BaseQuiver q)
				{
					var attrs = q.Attributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}
				}
				else if (obj is BaseTalisman t)
				{
					var attrs = t.Attributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}
				}
			}

			#region Enhancement
			value += Enhancement.GetValue(m, attribute);
			#endregion

			return value;
		}
	}

	[Flags]
	public enum AosWeaponAttribute : ulong
	{
		LowerStatReq = 0x00000001,
		SelfRepair = 0x00000002,
		HitLeechHits = 0x00000004,
		HitLeechStam = 0x00000008,
		HitLeechMana = 0x00000010,
		HitLowerAttack = 0x00000020,
		HitLowerDefend = 0x00000040,
		HitMagicArrow = 0x00000080,
		HitHarm = 0x00000100,
		HitFireball = 0x00000200,
		HitLightning = 0x00000400,
		HitDispel = 0x00000800,
		HitColdArea = 0x00001000,
		HitFireArea = 0x00002000,
		HitPoisonArea = 0x00004000,
		HitEnergyArea = 0x00008000,
		HitPhysicalArea = 0x00010000,
		ResistPhysicalBonus = 0x00020000,
		ResistFireBonus = 0x00040000,
		ResistColdBonus = 0x00080000,
		ResistPoisonBonus = 0x00100000,
		ResistEnergyBonus = 0x00200000,
		UseBestSkill = 0x00400000,
		MageWeapon = 0x00800000,
		DurabilityBonus = 0x01000000
	}

	public sealed class AosWeaponAttributes : BaseAttributes
	{
		[CommandProperty(AccessLevel.GameMaster)]
		public int LowerStatReq { get => this[AosWeaponAttribute.LowerStatReq]; set => this[AosWeaponAttribute.LowerStatReq] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SelfRepair { get => this[AosWeaponAttribute.SelfRepair]; set => this[AosWeaponAttribute.SelfRepair] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitLeechHits { get => this[AosWeaponAttribute.HitLeechHits]; set => this[AosWeaponAttribute.HitLeechHits] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitLeechStam { get => this[AosWeaponAttribute.HitLeechStam]; set => this[AosWeaponAttribute.HitLeechStam] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitLeechMana { get => this[AosWeaponAttribute.HitLeechMana]; set => this[AosWeaponAttribute.HitLeechMana] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitLowerAttack { get => this[AosWeaponAttribute.HitLowerAttack]; set => this[AosWeaponAttribute.HitLowerAttack] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitLowerDefend { get => this[AosWeaponAttribute.HitLowerDefend]; set => this[AosWeaponAttribute.HitLowerDefend] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitMagicArrow { get => this[AosWeaponAttribute.HitMagicArrow]; set => this[AosWeaponAttribute.HitMagicArrow] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitHarm { get => this[AosWeaponAttribute.HitHarm]; set => this[AosWeaponAttribute.HitHarm] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitFireball { get => this[AosWeaponAttribute.HitFireball]; set => this[AosWeaponAttribute.HitFireball] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitLightning { get => this[AosWeaponAttribute.HitLightning]; set => this[AosWeaponAttribute.HitLightning] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitDispel { get => this[AosWeaponAttribute.HitDispel]; set => this[AosWeaponAttribute.HitDispel] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitColdArea { get => this[AosWeaponAttribute.HitColdArea]; set => this[AosWeaponAttribute.HitColdArea] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitFireArea { get => this[AosWeaponAttribute.HitFireArea]; set => this[AosWeaponAttribute.HitFireArea] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitPoisonArea { get => this[AosWeaponAttribute.HitPoisonArea]; set => this[AosWeaponAttribute.HitPoisonArea] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitEnergyArea { get => this[AosWeaponAttribute.HitEnergyArea]; set => this[AosWeaponAttribute.HitEnergyArea] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HitPhysicalArea { get => this[AosWeaponAttribute.HitPhysicalArea]; set => this[AosWeaponAttribute.HitPhysicalArea] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int ResistPhysicalBonus { get => this[AosWeaponAttribute.ResistPhysicalBonus]; set => this[AosWeaponAttribute.ResistPhysicalBonus] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int ResistFireBonus { get => this[AosWeaponAttribute.ResistFireBonus]; set => this[AosWeaponAttribute.ResistFireBonus] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int ResistColdBonus { get => this[AosWeaponAttribute.ResistColdBonus]; set => this[AosWeaponAttribute.ResistColdBonus] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int ResistPoisonBonus { get => this[AosWeaponAttribute.ResistPoisonBonus]; set => this[AosWeaponAttribute.ResistPoisonBonus] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int ResistEnergyBonus { get => this[AosWeaponAttribute.ResistEnergyBonus]; set => this[AosWeaponAttribute.ResistEnergyBonus] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int UseBestSkill { get => this[AosWeaponAttribute.UseBestSkill]; set => this[AosWeaponAttribute.UseBestSkill] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int MageWeapon { get => this[AosWeaponAttribute.MageWeapon]; set => this[AosWeaponAttribute.MageWeapon] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int DurabilityBonus { get => this[AosWeaponAttribute.DurabilityBonus]; set => this[AosWeaponAttribute.DurabilityBonus] = value; }

		public int this[AosWeaponAttribute attribute]
		{
			get => GetValue((ulong)attribute);
			set => SetValue((ulong)attribute, value);
		}

		public AosWeaponAttributes(IEntity owner)
			: base(owner)
		{
		}

		public AosWeaponAttributes(IEntity owner, AosWeaponAttributes other)
			: base(owner, other)
		{
		}

		public AosWeaponAttributes(IEntity owner, GenericReader reader)
			: base(owner, reader)
		{
		}

		public override string ToString()
		{
			return "...";
		}

		public static int GetValue(Mobile m, AosWeaponAttribute attribute)
		{
			if (!Core.AOS)
			{
				return 0;
			}

			var items = m.Items;
			var value = 0;

			for (var i = 0; i < items.Count; ++i)
			{
				var obj = items[i];

				if (obj is BaseWeapon w)
				{
					var attrs = w.WeaponAttributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}
				}
				else if (obj is ElvenGlasses g)
				{
					var attrs = g.WeaponAttributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}
				}
			}

			#region Enhancement
			value += Enhancement.GetValue(m, attribute);
			#endregion

			return value;
		}
	}

	[Flags]
	public enum AosArmorAttribute : ulong
	{
		LowerStatReq = 0x00000001,
		SelfRepair = 0x00000002,
		MageArmor = 0x00000004,
		DurabilityBonus = 0x00000008
	}

	public sealed class AosArmorAttributes : BaseAttributes
	{
		[CommandProperty(AccessLevel.GameMaster)]
		public int LowerStatReq { get => this[AosArmorAttribute.LowerStatReq]; set => this[AosArmorAttribute.LowerStatReq] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SelfRepair { get => this[AosArmorAttribute.SelfRepair]; set => this[AosArmorAttribute.SelfRepair] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int MageArmor { get => this[AosArmorAttribute.MageArmor]; set => this[AosArmorAttribute.MageArmor] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int DurabilityBonus { get => this[AosArmorAttribute.DurabilityBonus]; set => this[AosArmorAttribute.DurabilityBonus] = value; }

		public int this[AosArmorAttribute attribute]
		{
			get => GetValue((ulong)attribute);
			set => SetValue((ulong)attribute, value);
		}

		public AosArmorAttributes(IEntity owner)
			: base(owner)
		{
		}

		public AosArmorAttributes(IEntity owner, GenericReader reader)
			: base(owner, reader)
		{
		}

		public AosArmorAttributes(IEntity owner, AosArmorAttributes other)
			: base(owner, other)
		{
		}

		public override string ToString()
		{
			return "...";
		}

		public static int GetValue(Mobile m, AosArmorAttribute attribute)
		{
			if (!Core.AOS)
			{
				return 0;
			}

			var items = m.Items;
			var value = 0;

			for (var i = 0; i < items.Count; ++i)
			{
				var obj = items[i];

				if (obj is BaseArmor a)
				{
					var attrs = a.ArmorAttributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}
				}
				else if (obj is BaseClothing c)
				{
					var attrs = c.ClothingAttributes;

					if (attrs != null)
					{
						value += attrs[attribute];
					}
				}
			}

			return value;
		}
	}

	public sealed class AosSkillBonuses : BaseAttributes
	{
		private List<SkillMod> m_Mods;

		[CommandProperty(AccessLevel.GameMaster)]
		public double Skill_1_Value { get => GetBonus(0); set => SetBonus(0, value); }

		[CommandProperty(AccessLevel.GameMaster)]
		public SkillName Skill_1_Name { get => GetSkill(0); set => SetSkill(0, value); }

		[CommandProperty(AccessLevel.GameMaster)]
		public double Skill_2_Value { get => GetBonus(1); set => SetBonus(1, value); }

		[CommandProperty(AccessLevel.GameMaster)]
		public SkillName Skill_2_Name { get => GetSkill(1); set => SetSkill(1, value); }

		[CommandProperty(AccessLevel.GameMaster)]
		public double Skill_3_Value { get => GetBonus(2); set => SetBonus(2, value); }

		[CommandProperty(AccessLevel.GameMaster)]
		public SkillName Skill_3_Name { get => GetSkill(2); set => SetSkill(2, value); }

		[CommandProperty(AccessLevel.GameMaster)]
		public double Skill_4_Value { get => GetBonus(3); set => SetBonus(3, value); }

		[CommandProperty(AccessLevel.GameMaster)]
		public SkillName Skill_4_Name { get => GetSkill(3); set => SetSkill(3, value); }

		[CommandProperty(AccessLevel.GameMaster)]
		public double Skill_5_Value { get => GetBonus(4); set => SetBonus(4, value); }

		[CommandProperty(AccessLevel.GameMaster)]
		public SkillName Skill_5_Name { get => GetSkill(4); set => SetSkill(4, value); }

		public AosSkillBonuses(IEntity owner)
			: base(owner)
		{
		}

		public AosSkillBonuses(IEntity owner, GenericReader reader)
			: base(owner, reader)
		{
		}

		public AosSkillBonuses(IEntity owner, AosSkillBonuses other)
			: base(owner, other)
		{
		}

		public override string ToString()
		{
			return "...";
		}

		public void GetProperties(ObjectPropertyList list)
		{
			for (var i = 0; i < 5; ++i)
			{
				if (!GetValues(i, out var skill, out var bonus))
				{
					continue;
				}

				list.Add(1060451 + i, "#{0}\t{1}", GetLabel(skill), bonus);
			}
		}

		public void AddTo(Mobile m)
		{
			Remove();

			for (var i = 0; i < 5; ++i)
			{
				if (!GetValues(i, out var skill, out var bonus))
				{
					continue;
				}

				m_Mods ??= new List<SkillMod>();

				var sk = new DefaultSkillMod(skill, true, bonus)
				{
					ObeyCap = true
				};

				m.AddSkillMod(sk);
				m_Mods.Add(sk);
			}
		}

		public void Remove()
		{
			if (m_Mods == null)
			{
				return;
			}

			for (var i = 0; i < m_Mods.Count; ++i)
			{
				var m = m_Mods[i].Owner;

				m_Mods[i].Remove();

				if (Core.ML)
				{
					CheckCancelMorph(m);
				}
			}

			m_Mods = null;
		}

		public bool GetValues(int index, out SkillName skill, out double bonus)
		{
			var v = GetValue(1ul << index);
			var vSkill = 0;
			var vBonus = 0;

			for (var i = 0; i < 32; ++i)
			{
				vSkill <<= 1;
				vSkill |= v & 1;
				v >>= 1;

				vBonus <<= 1;
				vBonus |= v & 1;
				v >>= 1;
			}

			skill = (SkillName)vSkill;
			bonus = vBonus / 10.0;

			return bonus != 0;
		}

		public void SetValues(int index, SkillName skill, double bonus)
		{
			var v = 0;
			var vSkill = (int)skill;
			var vBonus = (int)(bonus * 10);

			for (var i = 0; i < 32; ++i)
			{
				v <<= 1;
				v |= vBonus & 1;
				vBonus >>= 1;

				v <<= 1;
				v |= vSkill & 1;
				vSkill >>= 1;
			}

			SetValue(1ul << index, v);
		}

		public SkillName GetSkill(int index)
		{
			_ = GetValues(index, out var skill, out _);

			return skill;
		}

		public void SetSkill(int index, SkillName skill)
		{
			SetValues(index, skill, GetBonus(index));
		}

		public double GetBonus(int index)
		{
			_ = GetValues(index, out _, out var bonus);

			return bonus;
		}

		public void SetBonus(int index, double bonus)
		{
			SetValues(index, GetSkill(index), bonus);
		}

		public static int GetLabel(SkillName skill)
		{
			return skill switch
			{
				SkillName.EvalInt => 1002070,// Evaluate Intelligence
				SkillName.Forensics => 1002078,// Forensic Evaluation
				SkillName.Lockpicking => 1002097,// Lockpicking
				_ => 1044060 + (int)skill,
			};
		}

		public static void CheckCancelMorph(Mobile m)
		{
			if (m == null)
			{
				return;
			}

			var acontext = AnimalFormSpell.GetContext(m);
			var context = TransformationSpellHelper.GetContext(m);

			if (context != null)
			{
				var spell = context.Spell;

				var reqSkill = spell.GetSkillRequirement();

				spell.GetCastSkills(ref reqSkill, out var minSkill, out _);

				if (m.Skills[spell.CastSkill].Value < minSkill)
				{
					TransformationSpellHelper.RemoveContext(m, context, true);
				}
			}

			if (acontext != null)
			{
				int i;

				for (i = 0; i < AnimalFormSpell.Entries.Length; ++i)
				{
					if (AnimalFormSpell.Entries[i].Type == acontext.Type)
					{
						break;
					}
				}

				if (m.Skills.Ninjitsu.Value < AnimalFormSpell.Entries[i].ReqSkill)
				{
					AnimalFormSpell.RemoveContext(m, true);
				}
			}

			if (PolymorphSpell.IsPolymorphed(m) && m.Skills.Magery.Value < 66.1)
			{
				PolymorphSpell.EndPolymorph(m);
			}

			if (IncognitoSpell.IsIncognito(m) && m.Skills.Magery.Value < 38.1)
			{
				IncognitoSpell.EndIncognito(m);
			}
		}
	}

	[Flags]
	public enum AosElementAttribute : ulong
	{
		Physical = 0x00000001,
		Fire = 0x00000002,
		Cold = 0x00000004,
		Poison = 0x00000008,
		Energy = 0x00000010,
		Chaos = 0x00000020,
		Direct = 0x00000040
	}

	public sealed class AosElementAttributes : BaseAttributes
	{
		[CommandProperty(AccessLevel.GameMaster)]
		public int Physical { get => this[AosElementAttribute.Physical]; set => this[AosElementAttribute.Physical] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Fire { get => this[AosElementAttribute.Fire]; set => this[AosElementAttribute.Fire] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Cold { get => this[AosElementAttribute.Cold]; set => this[AosElementAttribute.Cold] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Poison { get => this[AosElementAttribute.Poison]; set => this[AosElementAttribute.Poison] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Energy { get => this[AosElementAttribute.Energy]; set => this[AosElementAttribute.Energy] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Chaos { get => this[AosElementAttribute.Chaos]; set => this[AosElementAttribute.Chaos] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Direct { get => this[AosElementAttribute.Direct]; set => this[AosElementAttribute.Direct] = value; }

		public int this[AosElementAttribute attribute]
		{
			get => GetValue((ulong)attribute);
			set => SetValue((ulong)attribute, value);
		}

		public AosElementAttributes(IEntity owner)
			: base(owner)
		{
		}

		public AosElementAttributes(IEntity owner, AosElementAttributes other)
			: base(owner, other)
		{
		}

		public AosElementAttributes(IEntity owner, GenericReader reader)
			: base(owner, reader)
		{
		}

		public override string ToString()
		{
			return "...";
		}
	}

	[PropertyObject]
	public abstract class BaseAttributes
	{
		private static readonly int[] m_Empty = Array.Empty<int>();

		private ulong m_Names;
		private int[] m_Values;

		public bool IsEmpty => m_Names == 0;

		public IEntity Owner { get; }

		public BaseAttributes(IEntity owner)
		{
			Owner = owner;
			m_Values = m_Empty;
		}

		public BaseAttributes(IEntity owner, BaseAttributes other)
		{
			Owner = owner;

			m_Values = new int[other.m_Values.Length];

			other.m_Values.CopyTo(m_Values, 0);

			m_Names = other.m_Names;
		}

		public BaseAttributes(IEntity owner, GenericReader reader)
		{
			Owner = owner;

			var version = reader.ReadByte();

			switch (version)
			{
				case 2:
				case 1:
					{
						m_Names = version >= 2 ? reader.ReadEncodedULong() : reader.ReadUInt();
						m_Values = new int[reader.ReadEncodedInt()];

						for (var i = 0; i < m_Values.Length; ++i)
						{
							m_Values[i] = reader.ReadEncodedInt();
						}

						break;
					}
				case 0:
					{
						m_Names = reader.ReadUInt();
						m_Values = new int[reader.ReadInt()];

						for (var i = 0; i < m_Values.Length; ++i)
						{
							m_Values[i] = reader.ReadInt();
						}

						break;
					}
			}
		}

		public void Serialize(GenericWriter writer)
		{
			writer.Write((byte)2); // version;

			writer.WriteEncodedULong(m_Names);
			writer.WriteEncodedInt(m_Values.Length);

			for (var i = 0; i < m_Values.Length; ++i)
			{
				writer.WriteEncodedInt(m_Values[i]);
			}
		}

		public int GetValue(ulong mask)
		{
			if (!Core.AOS)
			{
				return 0;
			}

			if ((m_Names & mask) == 0)
			{
				return 0;
			}

			var index = GetIndex(mask);

			if (index >= 0 && index < m_Values.Length)
			{
				return m_Values[index];
			}

			return 0;
		}

		public void SetValue(ulong mask, int value)
		{
			if ((mask == (int)AosWeaponAttribute.DurabilityBonus) && (this is AosWeaponAttributes))
			{
				if (Owner is BaseWeapon w)
				{
					w.UnscaleDurability();
				}
			}
			else if ((mask == (int)AosArmorAttribute.DurabilityBonus) && (this is AosArmorAttributes))
			{
				if (Owner is BaseArmor a)
				{
					a.UnscaleDurability();
				}
				else if (Owner is BaseClothing c)
				{
					c.UnscaleDurability();
				}
			}

			if (value != 0)
			{
				if ((m_Names & mask) != 0)
				{
					var index = GetIndex(mask);

					if (index >= 0 && index < m_Values.Length)
					{
						m_Values[index] = value;
					}
				}
				else
				{
					var index = GetIndex(mask);

					if (index >= 0 && index <= m_Values.Length)
					{
						var old = m_Values;

						m_Values = new int[old.Length + 1];

						for (var i = 0; i < index; ++i)
						{
							m_Values[i] = old[i];
						}

						m_Values[index] = value;

						for (var i = index; i < old.Length; ++i)
						{
							m_Values[i + 1] = old[i];
						}

						m_Names |= mask;
					}
				}
			}
			else if ((m_Names & mask) != 0)
			{
				var index = GetIndex(mask);

				if (index >= 0 && index < m_Values.Length)
				{
					m_Names &= ~mask;

					if (m_Values.Length == 1)
					{
						m_Values = m_Empty;
					}
					else
					{
						var old = m_Values;

						m_Values = new int[old.Length - 1];

						for (var i = 0; i < index; ++i)
						{
							m_Values[i] = old[i];
						}

						for (var i = index + 1; i < old.Length; ++i)
						{
							m_Values[i - 1] = old[i];
						}
					}
				}
			}

			if ((mask == (int)AosWeaponAttribute.DurabilityBonus) && (this is AosWeaponAttributes))
			{
				if (Owner is BaseWeapon w)
				{
					w.ScaleDurability();
				}
			}
			else if ((mask == (int)AosArmorAttribute.DurabilityBonus) && (this is AosArmorAttributes))
			{
				if (Owner is BaseArmor a)
				{
					a.ScaleDurability();
				}
				else if (Owner is BaseClothing c)
				{
					c.ScaleDurability();
				}
			}

			if (Owner is Item item && item.Parent is Mobile m)
			{
				m.CheckStatTimers();
				m.UpdateResistances();
				m.Delta(MobileDelta.Stat | MobileDelta.WeaponDamage | MobileDelta.Hits | MobileDelta.Stam | MobileDelta.Mana);

				if (this is AosSkillBonuses sb)
				{
					sb.Remove();
					sb.AddTo(m);
				}
			}

			Owner.InvalidateProperties();
		}

		private int GetIndex(ulong mask)
		{
			var index = 0;
			var ourNames = m_Names;
			var currentBit = 1ul;

			while (currentBit != mask)
			{
				if ((ourNames & currentBit) != 0)
				{
					++index;
				}

				if (currentBit == 0x8000000000000000)
				{
					return -1;
				}

				currentBit <<= 1;
			}

			return index;
		}
	}
}