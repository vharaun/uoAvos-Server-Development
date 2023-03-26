using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Spells.Magery
{
	/// Dispel
	public class DispelSpell : MagerySpell
	{
		public DispelSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Dispel)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public class InternalTarget : Target
		{
			private readonly DispelSpell m_Owner;

			public InternalTarget(DispelSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile m)
				{
					if (!from.CanSee(m))
					{
						from.SendLocalizedMessage(500237); // Target can not be seen.
					}
					else if (m is not BaseCreature bc || !bc.IsDispellable)
					{
						from.SendLocalizedMessage(1005049); // That cannot be dispelled.
					}
					else if (m_Owner.CheckHSequence(m))
					{
						SpellHelper.Turn(from, m);

						var dispelChance = (50.0 + (100 * (from.Skills.Magery.Value - bc.DispelDifficulty) / (bc.DispelFocus * 2))) / 100;

						if (dispelChance > Utility.RandomDouble())
						{
							Effects.SendLocationParticles(EffectItem.Create(m.Location, m.Map, EffectItem.DefaultDuration), 0x3728, 8, 20, 5042);
							Effects.PlaySound(m, m.Map, 0x201);

							m.Delete();
						}
						else
						{
							m.FixedEffect(0x3779, 10, 20);
							from.SendLocalizedMessage(1010084); // The creature resisted the attempt to dispel it!
						}
					}
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// EnergyBolt
	public class EnergyBoltSpell : MagerySpell
	{
		public override bool DelayedDamage => true;

		public EnergyBoltSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.EnergyBolt)
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

				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect((int)Circle, ref source, ref m);

				double damage;

				if (Core.AOS)
				{
					damage = GetNewAosDamage(40, 1, 5, m);
				}
				else
				{
					damage = Utility.Random(24, 18);

					if (CheckResisted(m))
					{
						damage *= 0.75;

						m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
					}

					// Scale damage based on evalint and resist
					damage *= GetDamageScalar(m);
				}

				// Do the effects
				source.MovingParticles(m, 0x379F, 7, 0, false, true, 3043, 4043, 0x211);
				source.PlaySound(0x20A);

				// Deal the damage
				SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly EnergyBoltSpell m_Owner;

			public InternalTarget(EnergyBoltSpell owner)
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

	/// Explosion
	public class ExplosionSpell : MagerySpell
	{
		public override bool DelayedDamage => false;
		public override bool DelayedDamageStacking => !Core.AOS;

		public ExplosionSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Explosion)
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
			else if (Caster.CanBeHarmful(m) && CheckSequence())
			{
				Mobile attacker = Caster, defender = m;

				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				var t = new InternalTimer(this, attacker, defender, m);

				t.Start();
			}

			FinishSequence();
		}

		private class InternalTimer : Timer
		{
			private readonly MagerySpell m_Spell;
			private readonly Mobile m_Target;
			private readonly Mobile m_Attacker, m_Defender;

			public InternalTimer(MagerySpell spell, Mobile attacker, Mobile defender, Mobile target)
				: base(TimeSpan.FromSeconds(Core.AOS ? 3.0 : 2.5))
			{
				m_Spell = spell;
				m_Attacker = attacker;
				m_Defender = defender;
				m_Target = target;

				if (m_Spell != null)
				{
					m_Spell.StartDelayedDamageContext(attacker, this);
				}

				Priority = TimerPriority.FiftyMS;
			}

			protected override void OnTick()
			{
				if (m_Attacker.HarmfulCheck(m_Defender))
				{
					double damage;

					if (Core.AOS)
					{
						damage = m_Spell.GetNewAosDamage(40, 1, 5, m_Defender);
					}
					else
					{
						damage = Utility.Random(23, 22);

						if (m_Spell.CheckResisted(m_Target))
						{
							damage *= 0.75;

							m_Target.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}

						damage *= m_Spell.GetDamageScalar(m_Target);
					}

					m_Target.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
					m_Target.PlaySound(0x307);

					SpellHelper.Damage(m_Spell, m_Target, damage, 0, 100, 0, 0, 0);

					if (m_Spell != null)
					{
						m_Spell.RemoveDelayedDamageContext(m_Attacker);
					}
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly ExplosionSpell m_Owner;

			public InternalTarget(ExplosionSpell owner)
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

	/// Invisibility
	public class InvisibilitySpell : MagerySpell
	{
		private static readonly Dictionary<Mobile, Timer> m_Table = new();

		public InvisibilitySpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Invisibility)
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
			else if (m is BaseVendor or PlayerVendor || m.AccessLevel > Caster.AccessLevel)
			{
				Caster.SendLocalizedMessage(501857); // This spell won't work on that!
			}
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				Effects.SendLocationParticles(EffectItem.Create(new Point3D(m.X, m.Y, m.Z + 16), Caster.Map, EffectItem.DefaultDuration), 0x376A, 10, 15, 5045);
				m.PlaySound(0x3C4);

				m.Hidden = true;
				m.Combatant = null;
				m.Warmode = false;

				RemoveTimer(m);

				var duration = TimeSpan.FromSeconds(1.2 * Caster.Skills.Magery.Fixed / 10);

				Timer t = new InternalTimer(m, duration);

				BuffInfo.RemoveBuff(m, BuffIcon.HidingAndOrStealth);
				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Invisibility, 1075825, duration, m)); //Invisibility/Invisible

				m_Table[m] = t;

				t.Start();
			}

			FinishSequence();
		}

		public static bool HasTimer(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void RemoveTimer(Mobile m)
		{
			Timer t;
			_ = m_Table.TryGetValue(m, out t);

			if (t != null)
			{
				t.Stop();
				_ = m_Table.Remove(m);
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Mobile;

			public InternalTimer(Mobile m, TimeSpan duration)
				: base(duration)
			{
				Priority = TimerPriority.OneSecond;
				m_Mobile = m;
			}

			protected override void OnTick()
			{
				m_Mobile.RevealingAction();
				RemoveTimer(m_Mobile);
			}
		}

		public class InternalTarget : Target
		{
			private readonly InvisibilitySpell m_Owner;

			public InternalTarget(InvisibilitySpell owner)
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

	/// Mark
	public class MarkSpell : MagerySpell
	{
		public MarkSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Mark)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			return SpellHelper.CheckTravel(Caster, TravelCheckType.Mark);
		}

		public void Target(RecallRune rune)
		{
			if (!Caster.CanSee(rune))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (!SpellHelper.CheckTravel(Caster, TravelCheckType.Mark))
			{
			}
			else if (SpellHelper.CheckMulti(Caster.Location, Caster.Map, !Core.AOS))
			{
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			}
			else if (!rune.IsChildOf(Caster.Backpack))
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1062422); // You must have this rune in your backpack in order to mark it.
			}
			else if (CheckSequence())
			{
				rune.Mark(Caster);

				Caster.PlaySound(0x1FA);
				Effects.SendLocationEffect(Caster, Caster.Map, 14201, 16);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly MarkSpell m_Owner;

			public InternalTarget(MarkSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is RecallRune)
				{
					m_Owner.Target((RecallRune)o);
				}
				else
				{
					from.SendLocalizedMessage(501797); // I cannot mark that object.
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// MassCurse
	public class MassCurseSpell : MagerySpell
	{
		public MassCurseSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.MassCurse)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (!SpellHelper.CheckTown(this, p))
			{ }
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				var targets = new List<Mobile>();

				var map = Caster.Map;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), 2);

					foreach (Mobile m in eable)
					{
						if (Core.AOS && m == Caster)
						{
							continue;
						}

						if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanSee(m) && Caster.CanBeHarmful(m, false))
						{
							targets.Add(m);
						}
					}

					eable.Free();
				}

				for (var i = 0; i < targets.Count; ++i)
				{
					var m = targets[i];

					Caster.DoHarmful(m);

					_ = SpellHelper.AddStatCurse(Caster, m, StatType.Str);
					SpellHelper.DisableSkillCheck = true;
					_ = SpellHelper.AddStatCurse(Caster, m, StatType.Dex);
					_ = SpellHelper.AddStatCurse(Caster, m, StatType.Int);
					SpellHelper.DisableSkillCheck = false;

					m.FixedParticles(0x374A, 10, 15, 5028, EffectLayer.Waist);
					m.PlaySound(0x1FB);

					HarmfulSpell(m);
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly MassCurseSpell m_Owner;

			public InternalTarget(MassCurseSpell owner)
				: base(Core.ML ? 10 : 12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D p)
				{
					m_Owner.Target(p);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// ParalyzeField
	public class ParalyzeFieldSpell : MagerySpell
	{
		public ParalyzeFieldSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.ParalyzeField)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (!SpellHelper.CheckTown(this, p))
			{ }
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				var dx = Caster.Location.X - p.X;
				var dy = Caster.Location.Y - p.Y;
				var rx = (dx - dy) * 44;
				var ry = (dx + dy) * 44;

				bool eastToWest;

				if (rx >= 0 && ry >= 0)
				{
					eastToWest = false;
				}
				else if (rx >= 0)
				{
					eastToWest = true;
				}
				else if (ry >= 0)
				{
					eastToWest = true;
				}
				else
				{
					eastToWest = false;
				}

				Effects.PlaySound(p, Caster.Map, 0x20B);

				var itemID = eastToWest ? 0x3967 : 0x3979;

				var duration = TimeSpan.FromSeconds(3.0 + (Caster.Skills[SkillName.Magery].Value / 3.0));

				for (var i = -2; i <= 2; ++i)
				{
					var loc = new Point3D(eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z);
					var canFit = SpellHelper.AdjustField(ref loc, Caster.Map, 12, false);

					if (!canFit)
					{
						continue;
					}

					Item item = new InternalItem(Caster, itemID, loc, Caster.Map, duration);
					item.ProcessDelta();

					Effects.SendLocationParticles(EffectItem.Create(loc, Caster.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 5048);
				}
			}

			FinishSequence();
		}

		[DispellableField]
		public class InternalItem : Item
		{
			private Timer m_Timer;
			private Mobile m_Caster;
			private DateTime m_End;

			public override bool BlocksFit => true;

			public InternalItem(Mobile caster, int itemID, Point3D loc, Map map, TimeSpan duration)
				: base(itemID)
			{
				Visible = false;
				Movable = false;
				Light = LightType.Circle300;

				MoveToWorld(loc, map);

				if (caster.InLOS(this))
				{
					Visible = true;
				}
				else
				{
					Delete();
				}

				if (Deleted)
				{
					return;
				}

				m_Caster = caster;

				m_Timer = new InternalTimer(this, duration);
				m_Timer.Start();

				m_End = DateTime.UtcNow + duration;
			}

			public InternalItem(Serial serial)
				: base(serial)
			{
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if (m_Timer != null)
				{
					m_Timer.Stop();
				}
			}

			public override bool OnMoveOver(Mobile m)
			{
				if (Visible && m_Caster != null && (!Core.AOS || m != m_Caster) && SpellHelper.ValidIndirectTarget(m_Caster, m) && m_Caster.CanBeHarmful(m, false))
				{
					if (SpellHelper.CanRevealCaster(m))
					{
						m_Caster.RevealingAction();
					}

					m_Caster.DoHarmful(m);

					double duration;

					if (Core.AOS)
					{
						duration = 2.0 + ((int)(m_Caster.Skills[SkillName.EvalInt].Value / 10) - (int)(m.Skills[SkillName.MagicResist].Value / 10));

						if (!m.Player)
						{
							duration *= 3.0;
						}

						if (duration < 0.0)
						{
							duration = 0.0;
						}
					}
					else
					{
						duration = 7.0 + (m_Caster.Skills[SkillName.Magery].Value * 0.2);
					}

					m.Paralyze(TimeSpan.FromSeconds(duration));

					m.PlaySound(0x204);
					m.FixedEffect(0x376A, 10, 16);

					if (m is BaseCreature)
					{
						((BaseCreature)m).OnHarmfulSpell(m_Caster);
					}
				}

				return true;
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(0); // version

				writer.Write(m_Caster);
				writer.WriteDeltaTime(m_End);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				var version = reader.ReadInt();

				switch (version)
				{
					case 0:
						{
							m_Caster = reader.ReadMobile();
							m_End = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_End - DateTime.UtcNow);
							m_Timer.Start();

							break;
						}
				}
			}

			private class InternalTimer : Timer
			{
				private readonly Item m_Item;

				public InternalTimer(Item item, TimeSpan duration)
					: base(duration)
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly ParalyzeFieldSpell m_Owner;

			public InternalTarget(ParalyzeFieldSpell owner)
				: base(Core.ML ? 10 : 12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D)
				{
					m_Owner.Target((IPoint3D)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// Reveal
	public class RevealSpell : MagerySpell
	{
		public RevealSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Reveal)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				var targets = new List<Mobile>();

				var map = Caster.Map;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), 1 + (int)(Caster.Skills[SkillName.Magery].Value / 20.0));

					foreach (Mobile m in eable)
					{
						if (m is Mobiles.ShadowKnight && (m.X != p.X || m.Y != p.Y))
						{
							continue;
						}

						if (m.Hidden && (m.AccessLevel == AccessLevel.Player || Caster.AccessLevel > m.AccessLevel) && CheckDifficulty(Caster, m))
						{
							targets.Add(m);
						}
					}

					eable.Free();
				}

				for (var i = 0; i < targets.Count; ++i)
				{
					var m = targets[i];

					m.RevealingAction();

					m.FixedParticles(0x375A, 9, 20, 5049, EffectLayer.Head);
					m.PlaySound(0x1FD);
				}
			}

			FinishSequence();
		}

		// Reveal uses magery and detect hidden vs. hide and stealth 
		private static bool CheckDifficulty(Mobile from, Mobile m)
		{
			// Reveal always reveals vs. invisibility spell 
			if (!Core.AOS || InvisibilitySpell.HasTimer(m))
			{
				return true;
			}

			var magery = from.Skills[SkillName.Magery].Fixed;
			var detectHidden = from.Skills[SkillName.DetectHidden].Fixed;

			var hiding = m.Skills[SkillName.Hiding].Fixed;
			var stealth = m.Skills[SkillName.Stealth].Fixed;
			var divisor = hiding + stealth;

			int chance;
			if (divisor > 0)
			{
				chance = 50 * (magery + detectHidden) / divisor;
			}
			else
			{
				chance = 100;
			}

			return chance > Utility.Random(100);
		}

		public class InternalTarget : Target
		{
			private readonly RevealSpell m_Owner;

			public InternalTarget(RevealSpell owner)
				: base(Core.ML ? 10 : 12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D p)
				{
					m_Owner.Target(p);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}