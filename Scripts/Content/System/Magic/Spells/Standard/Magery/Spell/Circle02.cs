using Server.Items;
using Server.Targeting;

using System;
using System.Collections;

namespace Server.Spells.Magery
{
	/// Agility
	public class AgilitySpell : MagerySpell
	{
		public AgilitySpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Agility)
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
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				_ = SpellHelper.AddStatBonus(Caster, m, StatType.Dex);

				m.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
				m.PlaySound(0x1e7);

				var percentage = (int)(SpellHelper.GetOffsetScalar(Caster, m, false) * 100);
				var length = SpellHelper.GetDuration(Caster, m);

				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Agility, 1075841, length, m, percentage.ToString()));
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly AgilitySpell m_Owner;

			public InternalTarget(AgilitySpell owner)
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

	/// Cunning
	public class CunningSpell : MagerySpell
	{
		public CunningSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Cunning)
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
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				_ = SpellHelper.AddStatBonus(Caster, m, StatType.Int);

				m.FixedParticles(0x375A, 10, 15, 5011, EffectLayer.Head);
				m.PlaySound(0x1EB);

				var percentage = (int)(SpellHelper.GetOffsetScalar(Caster, m, false) * 100);
				var length = SpellHelper.GetDuration(Caster, m);

				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Cunning, 1075843, length, m, percentage.ToString()));
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly CunningSpell m_Owner;

			public InternalTarget(CunningSpell owner)
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

	/// Cure
	public class CureSpell : MagerySpell
	{
		public CureSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Cure)
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
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				var p = m.Poison;

				if (p != null)
				{
					var chanceToCure = 10000 + (int)(Caster.Skills[SkillName.Magery].Value * 75) - ((p.Level + 1) * (Core.AOS ? (p.Level < 4 ? 3300 : 3100) : 1750));
					chanceToCure /= 100;

					if (chanceToCure > Utility.Random(100))
					{
						if (m.CurePoison(Caster))
						{
							if (Caster != m)
							{
								Caster.SendLocalizedMessage(1010058); // You have cured the target of all poisons!
							}

							m.SendLocalizedMessage(1010059); // You have been cured of all poisons.
						}
					}
					else
					{
						m.SendLocalizedMessage(1010060); // You have failed to cure your target!
					}
				}

				m.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
				m.PlaySound(0x1E0);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private readonly CureSpell m_Owner;

			public InternalTarget(CureSpell owner)
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

	/// Harm
	public class HarmSpell : MagerySpell
	{
		public override bool DelayedDamage => false;

		public HarmSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Harm)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override double GetSlayerDamageScalar(Mobile target)
		{
			return 1.0; //This spell isn't affected by slayer spellbooks
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

				double damage;

				if (Core.AOS)
				{
					damage = GetNewAosDamage(17, 1, 5, m);
				}
				else
				{
					damage = Utility.Random(1, 15);

					if (CheckResisted(m))
					{
						damage *= 0.75;

						m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar(m);
				}

				if (!m.InRange(Caster, 2))
				{
					damage *= 0.25; // 1/4 damage at > 2 tile range
				}
				else if (!m.InRange(Caster, 1))
				{
					damage *= 0.50; // 1/2 damage at 2 tile range
				}

				if (Core.AOS)
				{
					m.FixedParticles(0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist);
					m.PlaySound(0x0FC);
				}
				else
				{
					m.FixedParticles(0x374A, 10, 15, 5013, EffectLayer.Waist);
					m.PlaySound(0x1F1);
				}

				SpellHelper.Damage(this, m, damage, 0, 0, 100, 0, 0);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly HarmSpell m_Owner;

			public InternalTarget(HarmSpell owner)
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

	/// MagicTrap
	public class MagicTrapSpell : MagerySpell
	{
		public MagicTrapSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.MagicTrap)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(TrapableContainer item)
		{
			if (!Caster.CanSee(item))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (item.TrapType is not TrapType.None and not TrapType.MagicTrap)
			{
				base.DoFizzle();
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, item);

				item.TrapType = TrapType.MagicTrap;
				item.TrapPower = Core.AOS ? Utility.RandomMinMax(10, 50) : 1;
				item.TrapLevel = 0;

				var loc = item.GetWorldLocation();

				Effects.SendLocationParticles(EffectItem.Create(new Point3D(loc.X + 1, loc.Y, loc.Z), item.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 9502);
				Effects.SendLocationParticles(EffectItem.Create(new Point3D(loc.X, loc.Y - 1, loc.Z), item.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 9502);
				Effects.SendLocationParticles(EffectItem.Create(new Point3D(loc.X - 1, loc.Y, loc.Z), item.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 9502);
				Effects.SendLocationParticles(EffectItem.Create(new Point3D(loc.X, loc.Y + 1, loc.Z), item.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 9502);
				Effects.SendLocationParticles(EffectItem.Create(new Point3D(loc.X, loc.Y, loc.Z), item.Map, EffectItem.DefaultDuration), 0, 0, 0, 5014);

				Effects.PlaySound(loc, item.Map, 0x1EF);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly MagicTrapSpell m_Owner;

			public InternalTarget(MagicTrapSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is TrapableContainer)
				{
					m_Owner.Target((TrapableContainer)o);
				}
				else
				{
					from.SendMessage("You can't trap that");
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// Protection
	public class ProtectionSpell : MagerySpell
	{
		private static readonly Hashtable m_Table = new();

		public static Hashtable Registry { get; } = new Hashtable();

		public ProtectionSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Protection)
		{
		}

		public override bool CheckCast()
		{
			if (Core.AOS)
			{
				return true;
			}

			if (Registry.ContainsKey(Caster))
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

		public static void Toggle(Mobile caster, Mobile target)
		{
			/* Players under the protection spell effect can no longer have their spells "disrupted" when hit.
			 * Players under the protection spell have decreased physical resistance stat value (-15 + (Inscription/20),
			 * a decreased "resisting spells" skill value by -35 + (Inscription/20),
			 * and a slower casting speed modifier (technically, a negative "faster cast speed") of 2 points.
			 * The protection spell has an indefinite duration, becoming active when cast, and deactivated when re-cast.
			 * Reactive Armor, Protection, and Magic Reflection will stay on—even after logging out,
			 * even after dying—until you “turn them off” by casting them again.
			 */

			var mods = (object[])m_Table[target];

			if (mods == null)
			{
				target.PlaySound(0x1E9);
				target.FixedParticles(0x375A, 9, 20, 5016, EffectLayer.Waist);

				mods = new object[2]
				{
					new ResistanceMod(ResistanceType.Physical, -15 + Math.Min((int)(caster.Skills[SkillName.Inscribe].Value / 20), 15)),
					new DefaultSkillMod(SkillName.MagicResist, true, -35 + Math.Min((int)(caster.Skills[SkillName.Inscribe].Value / 20), 35))
				};

				m_Table[target] = mods;
				Registry[target] = 100.0;

				target.AddResistanceMod((ResistanceMod)mods[0]);
				target.AddSkillMod((SkillMod)mods[1]);

				var physloss = -15 + (int)(caster.Skills[SkillName.Inscribe].Value / 20);
				var resistloss = -35 + (int)(caster.Skills[SkillName.Inscribe].Value / 20);
				var args = String.Format("{0}\t{1}", physloss, resistloss);
				BuffInfo.AddBuff(target, new BuffInfo(BuffIcon.Protection, 1075814, 1075815, args.ToString()));
			}
			else
			{
				target.PlaySound(0x1ED);
				target.FixedParticles(0x375A, 9, 20, 5016, EffectLayer.Waist);

				m_Table.Remove(target);
				Registry.Remove(target);

				target.RemoveResistanceMod((ResistanceMod)mods[0]);
				target.RemoveSkillMod((SkillMod)mods[1]);

				BuffInfo.RemoveBuff(target, BuffIcon.Protection);
			}
		}

		public static bool HasProtection(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void EndProtection(Mobile m)
		{
			if (m_Table.Contains(m))
			{
				var mods = (object[])m_Table[m];

				m_Table.Remove(m);
				Registry.Remove(m);

				m.RemoveResistanceMod((ResistanceMod)mods[0]);
				m.RemoveSkillMod((SkillMod)mods[1]);

				BuffInfo.RemoveBuff(m, BuffIcon.Protection);
			}
		}

		public override void OnCast()
		{
			if (Core.AOS)
			{
				if (CheckSequence())
				{
					Toggle(Caster, Caster);
				}
			}
			else if (Registry.ContainsKey(Caster))
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
					double value = (int)(Caster.Skills[SkillName.EvalInt].Value + Caster.Skills[SkillName.Meditation].Value + Caster.Skills[SkillName.Inscribe].Value);
					value /= 4;

					if (value < 0)
					{
						value = 0;
					}
					else if (value > 75)
					{
						value = 75.0;
					}

					Registry.Add(Caster, value);

					var t = new InternalTimer(Caster);

					t.Start();

					Caster.FixedParticles(0x375A, 9, 20, 5016, EffectLayer.Waist);
					Caster.PlaySound(0x1ED);
				}
				else
				{
					Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
				}
			}

			FinishSequence();
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Caster;

			public InternalTimer(Mobile caster)
				: base(TimeSpan.FromSeconds(0))
			{
				m_Caster = caster;

				var val = caster.Skills[SkillName.Magery].Value * 2.0;

				if (val < 15)
				{
					val = 15;
				}
				else if (val > 240)
				{
					val = 240;
				}

				Delay = TimeSpan.FromSeconds(val);
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				Registry.Remove(m_Caster);

				DefensiveState.Nullify(m_Caster);
			}
		}
	}

	/// RemoveTrap
	public class RemoveTrapSpell : MagerySpell
	{
		public RemoveTrapSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.RemoveTrap)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
			Caster.SendMessage("What do you wish to untrap?");
		}

		public void Target(TrapableContainer item)
		{
			if (!Caster.CanSee(item))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (item.TrapType is not TrapType.None and not TrapType.MagicTrap)
			{
				base.DoFizzle();
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, item);

				var loc = item.GetWorldLocation();

				Effects.SendLocationParticles(EffectItem.Create(loc, item.Map, EffectItem.DefaultDuration), 0x376A, 9, 32, 5015);
				Effects.PlaySound(loc, item.Map, 0x1F0);

				item.TrapType = TrapType.None;
				item.TrapPower = 0;
				item.TrapLevel = 0;
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly RemoveTrapSpell m_Owner;

			public InternalTarget(RemoveTrapSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is TrapableContainer)
				{
					m_Owner.Target((TrapableContainer)o);
				}
				else
				{
					from.SendMessage("You can't disarm that");
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// Strength
	public class StrengthSpell : MagerySpell
	{
		public StrengthSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Strength)
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
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				_ = SpellHelper.AddStatBonus(Caster, m, StatType.Str);

				m.FixedParticles(0x375A, 10, 15, 5017, EffectLayer.Waist);
				m.PlaySound(0x1EE);

				var percentage = (int)(SpellHelper.GetOffsetScalar(Caster, m, false) * 100);
				var length = SpellHelper.GetDuration(Caster, m);

				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Strength, 1075845, length, m, percentage.ToString()));
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly StrengthSpell m_Owner;

			public InternalTarget(StrengthSpell owner)
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
}