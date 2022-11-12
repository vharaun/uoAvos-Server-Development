using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections;

namespace Server.Spells.Magery
{
	/// Clumsy
	public class ClumsySpell : MagerySpell
	{
		public ClumsySpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Clumsy)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				_ = SpellHelper.AddStatCurse(Caster, m, StatType.Dex);

				if (m.Spell != null)
				{
					m.Spell.OnCasterHurt();
				}

				m.Paralyzed = false;

				m.FixedParticles(0x3779, 10, 15, 5002, EffectLayer.Head);
				m.PlaySound(0x1DF);

				var percentage = (int)(SpellHelper.GetOffsetScalar(Caster, m, true) * 100);
				var length = SpellHelper.GetDuration(Caster, m);

				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Clumsy, 1075831, length, m, percentage.ToString()));

				HarmfulSpell(m);
			}

			FinishSequence();
		}

		public static bool UnderEffect(Mobile m)
		{
			return SpellHelper.HasStatCurse(m, StatType.Dex);
		}

		public static void RemoveEffect(Mobile m)
		{
			SpellHelper.RemoveStatCurse(m, StatType.Dex);

			BuffInfo.RemoveBuff(m, BuffIcon.Clumsy);
		}

		private class InternalTarget : Target
		{
			private readonly ClumsySpell m_Owner;

			public InternalTarget(ClumsySpell owner) : base(Core.ML ? 10 : 12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
				{
					m_Owner.Target((Mobile)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// CreateFood
	public class FoodInfo
	{
		public Type Type { get; set; }
		public string Name { get; set; }

		public FoodInfo(Type type, string name)
		{
			Type = type;
			Name = name;
		}

		public Item Create()
		{
			Item item;

			try
			{
				item = (Item)Activator.CreateInstance(Type);
			}
			catch
			{
				item = null;
			}

			return item;
		}
	}

	public class CreateFoodSpell : MagerySpell
	{
		private static readonly FoodInfo[] m_Food = new FoodInfo[]
		{
			new FoodInfo( typeof( Grapes ), "a grape bunch" ),
			new FoodInfo( typeof( Ham ), "a ham" ),
			new FoodInfo( typeof( CheeseWedge ), "a wedge of cheese" ),
			new FoodInfo( typeof( Muffins ), "muffins" ),
			new FoodInfo( typeof( SaltwaterFishSteak ), "a saltwater fish steak" ),
			new FoodInfo( typeof( Ribs ), "cut of ribs" ),
			new FoodInfo( typeof( CookedBird ), "a cooked bird" ),
			new FoodInfo( typeof( Sausage ), "sausage" ),
			new FoodInfo( typeof( Apple ), "an apple" ),
			new FoodInfo( typeof( Peach ), "a peach" )
		};

		public CreateFoodSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.CreateFood)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var foodInfo = m_Food[Utility.Random(m_Food.Length)];
				var food = foodInfo.Create();

				if (food != null)
				{
					_ = Caster.AddToBackpack(food);

					// You magically create food in your backpack:
					Caster.SendLocalizedMessage(1042695, true, " " + foodInfo.Name);

					Caster.FixedParticles(0, 10, 5, 2003, EffectLayer.RightHand);
					Caster.PlaySound(0x1E2);
				}
			}

			FinishSequence();
		}
	}

	/// Feeblemind
	public class FeeblemindSpell : MagerySpell
	{
		public FeeblemindSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Feeblemind)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				_ = SpellHelper.AddStatCurse(Caster, m, StatType.Int);

				if (m.Spell != null)
				{
					m.Spell.OnCasterHurt();
				}

				m.Paralyzed = false;

				m.FixedParticles(0x3779, 10, 15, 5004, EffectLayer.Head);
				m.PlaySound(0x1E4);

				var percentage = (int)(SpellHelper.GetOffsetScalar(Caster, m, true) * 100);
				var length = SpellHelper.GetDuration(Caster, m);

				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.FeebleMind, 1075833, length, m, percentage.ToString()));

				HarmfulSpell(m);
			}

			FinishSequence();
		}

		public static bool UnderEffect(Mobile m)
		{
			return SpellHelper.HasStatCurse(m, StatType.Int);
		}

		public static void RemoveEffect(Mobile m)
		{
			SpellHelper.RemoveStatCurse(m, StatType.Int);

			BuffInfo.RemoveBuff(m, BuffIcon.FeebleMind);
		}

		private class InternalTarget : Target
		{
			private readonly FeeblemindSpell m_Owner;

			public InternalTarget(FeeblemindSpell owner) : base(Core.ML ? 10 : 12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
				{
					m_Owner.Target((Mobile)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// Heal
	public class HealSpell : MagerySpell
	{
		public HealSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Heal)
		{
		}

		public override bool CheckCast()
		{
			if (Engines.ConPVP.DuelContext.CheckSuddenDeath(Caster))
			{
				Caster.SendMessage(0x22, "You cannot cast this spell when in sudden death.");
				return false;
			}

			return base.CheckCast();
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (m.IsDeadBondedPet)
			{
				Caster.SendLocalizedMessage(1060177); // You cannot heal a creature that is already dead!
			}
			else if (m is BaseCreature && ((BaseCreature)m).IsAnimatedDead)
			{
				Caster.SendLocalizedMessage(1061654); // You cannot heal that which is not alive.
			}
			else if (m is Golem)
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 500951); // You cannot heal that.
			}
			else if (m.Poisoned || MortalStrike.IsWounded(m))
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x22, (Caster == m) ? 1005000 : 1010398);
			}
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				int toHeal;

				if (Core.AOS)
				{
					toHeal = Caster.Skills.Magery.Fixed / 120;
					toHeal += Utility.RandomMinMax(1, 4);

					if (Core.SE && Caster != m)
					{
						toHeal = (int)(toHeal * 1.5);
					}
				}
				else
				{
					toHeal = (int)(Caster.Skills[SkillName.Magery].Value * 0.1);
					toHeal += Utility.Random(1, 5);
				}

				//m.Heal( toHeal, Caster );
				SpellHelper.Heal(toHeal, m, Caster);

				m.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
				m.PlaySound(0x1F2);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private readonly HealSpell m_Owner;

			public InternalTarget(HealSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
				{
					m_Owner.Target((Mobile)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// Magic Arrow
	public class MagicArrowSpell : MagerySpell
	{
		public override bool DelayedDamage => true;
		public override bool DelayedDamageStacking => !Core.AOS;

		public MagicArrowSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.MagicArrow)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckHSequence(m))
			{
				var source = Caster;

				SpellHelper.Turn(source, m);

				SpellHelper.CheckReflect((int)Circle, ref source, ref m);

				double damage;

				if (Core.AOS)
				{
					damage = GetNewAosDamage(10, 1, 4, m);
				}
				else
				{
					damage = Utility.Random(4, 4);

					if (CheckResisted(m))
					{
						damage *= 0.75;

						m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar(m);
				}

				source.MovingParticles(m, 0x36E4, 5, 0, false, false, 3006, 0, 0);
				source.PlaySound(0x1E5);

				SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly MagicArrowSpell m_Owner;

			public InternalTarget(MagicArrowSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
				{
					m_Owner.Target((Mobile)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// NightSight
	public class NightSightSpell : MagerySpell
	{
		public NightSightSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.NightSight)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new NightSightTarget(this);
		}

		private class NightSightTarget : Target
		{
			private readonly Spell m_Spell;

			public NightSightTarget(Spell spell)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Spell = spell;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (targeted is Mobile && m_Spell.CheckBSequence((Mobile)targeted))
				{
					var targ = (Mobile)targeted;

					SpellHelper.Turn(m_Spell.Caster, targ);

					if (targ.BeginAction(typeof(LightCycle)))
					{
						new LightCycle.NightSightTimer(targ).Start();
						var level = (int)(LightCycle.DungeonLevel * ((Core.AOS ? targ.Skills[SkillName.Magery].Value : from.Skills[SkillName.Magery].Value) / 100));

						if (level < 0)
						{
							level = 0;
						}

						targ.LightLevel = level;

						targ.FixedParticles(0x376A, 9, 32, 5007, EffectLayer.Waist);
						targ.PlaySound(0x1E3);

						BuffInfo.AddBuff(targ, new BuffInfo(BuffIcon.NightSight, 1075643)); //Night Sight/You ignore lighting effects
					}
					else
					{
						from.SendMessage("{0} already have nightsight.", from == targ ? "You" : "They");
					}
				}

				m_Spell.FinishSequence();
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Spell.FinishSequence();
			}
		}
	}

	/// ReactiveArmor
	public class ReactiveArmorSpell : MagerySpell
	{
		private static readonly Hashtable m_Table = new();

		public ReactiveArmorSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.ReactiveArmor)
		{
		}

		public override bool CheckCast()
		{
			if (Core.AOS)
			{
				return true;
			}

			if (Caster.MeleeDamageAbsorb > 0)
			{
				Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
				return false;
			}
			
			if (DefensiveState.IsActive(Caster))
			{
				Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if (Core.AOS)
			{
				/* The reactive armor spell increases the caster's physical resistance, while lowering the caster's elemental resistances.
				 * 15 + (Inscription/20) Physcial bonus
				 * -5 Elemental
				 * The reactive armor spell has an indefinite duration, becoming active when cast, and deactivated when re-cast. 
				 * Reactive Armor, Protection, and Magic Reflection will stay on—even after logging out, even after dying—until you “turn them off” by casting them again. 
				 * (+20 physical -5 elemental at 100 Inscription)
				 */

				if (CheckSequence())
				{
					var targ = Caster;

					var mods = (ResistanceMod[])m_Table[targ];

					if (mods == null)
					{
						targ.PlaySound(0x1E9);
						targ.FixedParticles(0x376A, 9, 32, 5008, EffectLayer.Waist);

						mods = new ResistanceMod[5]
						{
							new ResistanceMod(ResistanceType.Physical, 15 + (int)(targ.Skills[SkillName.Inscribe].Value / 20)),
							new ResistanceMod(ResistanceType.Fire, -5),
							new ResistanceMod(ResistanceType.Cold, -5),
							new ResistanceMod(ResistanceType.Poison, -5),
							new ResistanceMod(ResistanceType.Energy, -5)
						};

						m_Table[targ] = mods;

						for (var i = 0; i < mods.Length; ++i)
						{
							targ.AddResistanceMod(mods[i]);
						}

						var physresist = 15 + (int)(targ.Skills[SkillName.Inscribe].Value / 20);
						var args = String.Format("{0}\t{1}\t{2}\t{3}\t{4}", physresist, 5, 5, 5, 5);

						BuffInfo.AddBuff(Caster, new BuffInfo(BuffIcon.ReactiveArmor, 1075812, 1075813, args.ToString()));
					}
					else
					{
						targ.PlaySound(0x1ED);
						targ.FixedParticles(0x376A, 9, 32, 5008, EffectLayer.Waist);

						m_Table.Remove(targ);

						for (var i = 0; i < mods.Length; ++i)
						{
							targ.RemoveResistanceMod(mods[i]);
						}

						BuffInfo.RemoveBuff(Caster, BuffIcon.ReactiveArmor);
					}
				}

				FinishSequence();
			}
			else
			{
				if (Caster.MeleeDamageAbsorb > 0)
				{
					Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
				}
				else if (DefensiveState.IsActive(Caster))
				{
					Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
				}
				else if (CheckSequence())
				{
					if (DefensiveState.Activate(Caster))
					{
						var value = (int)(Caster.Skills[SkillName.Magery].Value + Caster.Skills[SkillName.Meditation].Value + Caster.Skills[SkillName.Inscribe].Value);
						value /= 3;

						if (value < 0)
						{
							value = 1;
						}
						else if (value > 75)
						{
							value = 75;
						}

						Caster.MeleeDamageAbsorb = value;

						Caster.FixedParticles(0x376A, 9, 32, 5008, EffectLayer.Waist);
						Caster.PlaySound(0x1F2);
					}
					else
					{
						Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
					}
				}

				FinishSequence();
			}
		}

		public static bool HasArmor(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void EndArmor(Mobile m)
		{
			if (m_Table.Contains(m))
			{
				var mods = (ResistanceMod[])m_Table[m];

				if (mods != null)
				{
					for (var i = 0; i < mods.Length; ++i)
					{
						m.RemoveResistanceMod(mods[i]);
					}
				}

				m_Table.Remove(m);
				BuffInfo.RemoveBuff(m, BuffIcon.ReactiveArmor);
			}
		}
	}

	/// Weaken
	public class WeakenSpell : MagerySpell
	{
		public WeakenSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Weaken)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				_ = SpellHelper.AddStatCurse(Caster, m, StatType.Str);

				if (m.Spell != null)
				{
					m.Spell.OnCasterHurt();
				}

				m.Paralyzed = false;

				m.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
				m.PlaySound(0x1E6);

				var percentage = (int)(SpellHelper.GetOffsetScalar(Caster, m, true) * 100);
				var length = SpellHelper.GetDuration(Caster, m);

				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Weaken, 1075837, length, m, percentage.ToString()));

				HarmfulSpell(m);
			}

			FinishSequence();
		}

		public static bool UnderEffect(Mobile m)
		{
			return SpellHelper.HasStatCurse(m, StatType.Str);
		}

		public static void RemoveEffect(Mobile m)
		{
			SpellHelper.RemoveStatCurse(m, StatType.Str);

			BuffInfo.RemoveBuff(m, BuffIcon.Weaken);
		}

		public class InternalTarget : Target
		{
			private readonly WeakenSpell m_Owner;

			public InternalTarget(WeakenSpell owner) : base(Core.ML ? 10 : 12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
				{
					m_Owner.Target((Mobile)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}