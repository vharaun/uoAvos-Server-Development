using Server.Engines.PartySystem;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Multis;
using Server.Network;
using Server.Spells.Necromancy;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Spells.Magery
{
	/// ArchCure
	public class ArchCureSpell : MagerySpell
	{
		// Arch cure is now 1/4th of a second faster
		public override TimeSpan CastDelayBase => base.CastDelayBase - TimeSpan.FromSeconds(0.25);

		public ArchCureSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.ArchCure)
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
				var directTarget = p as Mobile;

				if (map != null)
				{
					var feluccaRules = map.Rules == MapRules.FeluccaRules;

					// You can target any living mobile directly, beneficial checks apply
					if (directTarget != null && Caster.CanBeBeneficial(directTarget, false))
					{
						targets.Add(directTarget);
					}

					var eable = map.GetMobilesInRange(new Point3D(p), 2);

					foreach (var m in eable)
					{
						if (m == directTarget)
						{
							continue;
						}

						if (AreaCanTarget(m, feluccaRules))
						{
							targets.Add(m);
						}
					}

					eable.Free();
				}

				Effects.PlaySound(p, Caster.Map, 0x299);

				if (targets.Count > 0)
				{
					var cured = 0;

					for (var i = 0; i < targets.Count; ++i)
					{
						var m = targets[i];

						Caster.DoBeneficial(m);

						var poison = m.Poison;

						if (poison != null)
						{
							var chanceToCure = 10000 + (int)(Caster.Skills[SkillName.Magery].Value * 75) - ((poison.Level + 1) * 1750);
							chanceToCure /= 100;
							chanceToCure -= 1;

							if (chanceToCure > Utility.Random(100) && m.CurePoison(Caster))
							{
								++cured;
							}
						}

						m.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
						m.PlaySound(0x1E0);
					}

					if (cured > 0)
					{
						Caster.SendLocalizedMessage(1010058); // You have cured the target of all poisons!
					}
				}
			}

			FinishSequence();
		}

		private bool AreaCanTarget(Mobile target, bool feluccaRules)
		{
			/* Arch cure area effect won't cure aggressors, victims, murderers, criminals or monsters.
			 * In Felucca, it will also not cure summons and pets.
			 * For red players it will only cure themselves and guild members.
			 */

			if (!Caster.CanBeBeneficial(target, false))
			{
				return false;
			}

			if (Core.AOS && target != Caster)
			{
				if (IsAggressor(target) || IsAggressed(target))
				{
					return false;
				}

				if ((!IsInnocentTo(Caster, target) || !IsInnocentTo(target, Caster)) && !IsAllyTo(Caster, target))
				{
					return false;
				}

				if (feluccaRules && target is not PlayerMobile)
				{
					return false;
				}
			}

			return true;
		}

		private bool IsAggressor(Mobile m)
		{
			foreach (var info in Caster.Aggressors)
			{
				if (m == info.Attacker && !info.Expired)
				{
					return true;
				}
			}

			return false;
		}

		private bool IsAggressed(Mobile m)
		{
			foreach (var info in Caster.Aggressed)
			{
				if (m == info.Defender && !info.Expired)
				{
					return true;
				}
			}

			return false;
		}

		private static bool IsInnocentTo(Mobile from, Mobile to)
		{
			return Notoriety.Compute(from, to) == Notoriety.Innocent;
		}

		private static bool IsAllyTo(Mobile from, Mobile to)
		{
			return Notoriety.Compute(from, to) == Notoriety.Ally;
		}

		private class InternalTarget : Target
		{
			private readonly ArchCureSpell m_Owner;

			public InternalTarget(ArchCureSpell owner)
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

	/// ArchProtection
	public class ArchProtectionSpell : MagerySpell
	{
		private static readonly Dictionary<Mobile, int> m_Table = new();

		public ArchProtectionSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.ArchProtection)
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
					var eable = map.GetMobilesInRange(new Point3D(p), Core.AOS ? 2 : 3);

					foreach (var m in eable)
					{
						if (Caster.CanBeBeneficial(m, false))
						{
							targets.Add(m);
						}
					}

					eable.Free();
				}

				if (Core.AOS)
				{
					var party = Party.Get(Caster);

					for (var i = 0; i < targets.Count; ++i)
					{
						var m = targets[i];

						if (m == Caster || (party != null && party.Contains(m)))
						{
							Caster.DoBeneficial(m);
							ProtectionSpell.Toggle(Caster, m);
						}
					}
				}
				else
				{
					Effects.PlaySound(p, Caster.Map, 0x299);

					var val = (int)((Caster.Skills[SkillName.Magery].Value / 10.0) + 1);

					if (targets.Count > 0)
					{
						for (var i = 0; i < targets.Count; ++i)
						{
							var m = targets[i];

							if (m.BeginAction(typeof(ArchProtectionSpell)))
							{
								Caster.DoBeneficial(m);
								m.VirtualArmorMod += val;

								AddEntry(m, val);
								new InternalTimer(m, Caster).Start();

								m.FixedParticles(0x375A, 9, 20, 5027, EffectLayer.Waist);
								m.PlaySound(0x1F7);
							}
						}
					}
				}
			}

			FinishSequence();
		}

		private static void AddEntry(Mobile m, int v)
		{
			m_Table[m] = v;
		}

		public static void RemoveEntry(Mobile m)
		{
			if (m_Table.TryGetValue(m, out var v))
			{
				_ = m_Table.Remove(m);

				m.EndAction(typeof(ArchProtectionSpell));

				m.VirtualArmorMod = Math.Max(0, m.VirtualArmorMod - v);
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Owner;

			public InternalTimer(Mobile target, Mobile caster)
				: base(TimeSpan.Zero)
			{
				var time = caster.Skills[SkillName.Magery].Value * 1.2;

				if (time > 144)
				{
					time = 144;
				}

				Delay = TimeSpan.FromSeconds(time);
				Priority = TimerPriority.OneSecond;

				m_Owner = target;
			}

			protected override void OnTick()
			{
				RemoveEntry(m_Owner);
			}
		}

		private class InternalTarget : Target
		{
			private readonly ArchProtectionSpell m_Owner;

			public InternalTarget(ArchProtectionSpell owner)
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

	/// Curse
	public class CurseSpell : MagerySpell
	{
		private static readonly Hashtable m_UnderEffect = new();

		public CurseSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Curse)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public static void RemoveEffect(object state)
		{
			var m = (Mobile)state;

			m_UnderEffect.Remove(m);

			m.UpdateResistances();
		}

		public static bool UnderEffect(Mobile m)
		{
			return m_UnderEffect.Contains(m);
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
				SpellHelper.DisableSkillCheck = true;
				_ = SpellHelper.AddStatCurse(Caster, m, StatType.Dex);
				_ = SpellHelper.AddStatCurse(Caster, m, StatType.Int);
				SpellHelper.DisableSkillCheck = false;

				var t = (Timer)m_UnderEffect[m];

				if (Caster.Player && m.Player && t == null) //On OSI you CAN curse yourself and get this effect.
				{
					var duration = SpellHelper.GetDuration(Caster, m);

					m_UnderEffect[m] = t = Timer.DelayCall(duration, RemoveEffect, m);

					m.UpdateResistances();
				}

				if (m.Spell != null)
				{
					m.Spell.OnCasterHurt();
				}

				m.Paralyzed = false;

				m.FixedParticles(0x374A, 10, 15, 5028, EffectLayer.Waist);
				m.PlaySound(0x1E1);

				var percentage = (int)(SpellHelper.GetOffsetScalar(Caster, m, true) * 100);
				var length = SpellHelper.GetDuration(Caster, m);

				var args = String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", percentage, percentage, percentage, 10, 10, 10, 10);

				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Curse, 1075835, 1075836, length, m, args.ToString()));

				HarmfulSpell(m);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly CurseSpell m_Owner;

			public InternalTarget(CurseSpell owner)
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

	/// FireField
	public class FireFieldSpell : MagerySpell
	{
		public FireFieldSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.FireField)
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

				Effects.PlaySound(p, Caster.Map, 0x20C);

				var itemID = eastToWest ? 0x398C : 0x3996;

				TimeSpan duration;

				if (Core.AOS)
				{
					duration = TimeSpan.FromSeconds((15 + (Caster.Skills.Magery.Fixed / 5)) / 4);
				}
				else
				{
					duration = TimeSpan.FromSeconds(4.0 + (Caster.Skills[SkillName.Magery].Value * 0.5));
				}

				for (var i = -2; i <= 2; ++i)
				{
					var loc = new Point3D(eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z);

					_ = new FireFieldItem(itemID, loc, Caster, Caster.Map, duration, i);
				}
			}

			FinishSequence();
		}

		[DispellableField]
		public class FireFieldItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private Mobile m_Caster;
			private int m_Damage;

			public override bool BlocksFit => true;

			public FireFieldItem(int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, int val)
				: this(itemID, loc, caster, map, duration, val, 2)
			{
			}

			public FireFieldItem(int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, int val, int damage)
				: base(itemID)
			{
				var canFit = SpellHelper.AdjustField(ref loc, map, 12, false);

				Visible = false;
				Movable = false;
				Light = LightType.Circle300;

				MoveToWorld(loc, map);

				m_Caster = caster;

				m_Damage = damage;

				m_End = DateTime.UtcNow + duration;

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(Math.Abs(val) * 0.2), caster.InLOS(this), canFit);
				m_Timer.Start();
			}

			public FireFieldItem(Serial serial)
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

					var damage = m_Damage;

					if (!Core.AOS && m.CheckSkill(SkillName.MagicResist, 0.0, 30.0))
					{
						damage = 1;

						m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
					}

					_ = AOS.Damage(m, m_Caster, damage, 0, 100, 0, 0, 0);
					m.PlaySound(0x208);

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

				writer.Write(2); // version

				writer.Write(m_Damage);
				writer.Write(m_Caster);
				writer.WriteDeltaTime(m_End);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				var version = reader.ReadInt();

				switch (version)
				{
					case 2:
						{
							m_Damage = reader.ReadInt();
							goto case 1;
						}
					case 1:
						{
							m_Caster = reader.ReadMobile();

							goto case 0;
						}
					case 0:
						{
							m_End = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, TimeSpan.Zero, true, true);
							m_Timer.Start();

							break;
						}
				}

				if (version < 2)
				{
					m_Damage = 2;
				}
			}

			private class InternalTimer : Timer
			{
				private readonly FireFieldItem m_Item;
				private readonly bool m_InLOS, m_CanFit;

				private static readonly Queue m_Queue = new();

				public InternalTimer(FireFieldItem item, TimeSpan delay, bool inLOS, bool canFit)
					: base(delay, TimeSpan.FromSeconds(1.0))
				{
					m_Item = item;
					m_InLOS = inLOS;
					m_CanFit = canFit;

					Priority = TimerPriority.FiftyMS;
				}

				protected override void OnTick()
				{
					if (m_Item.Deleted)
					{
						return;
					}

					if (!m_Item.Visible)
					{
						if (m_InLOS && m_CanFit)
						{
							m_Item.Visible = true;
						}
						else
						{
							m_Item.Delete();
						}

						if (!m_Item.Deleted)
						{
							m_Item.ProcessDelta();
							Effects.SendLocationParticles(EffectItem.Create(m_Item.Location, m_Item.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 5029);
						}
					}
					else if (DateTime.UtcNow > m_Item.m_End)
					{
						m_Item.Delete();
						Stop();
					}
					else
					{
						var map = m_Item.Map;
						var caster = m_Item.m_Caster;

						if (map != null && caster != null)
						{
							foreach (var m in m_Item.GetMobilesInRange(0))
							{
								if ((m.Z + 16) > m_Item.Z && (m_Item.Z + 12) > m.Z && (!Core.AOS || m != caster) && SpellHelper.ValidIndirectTarget(caster, m) && caster.CanBeHarmful(m, false))
								{
									m_Queue.Enqueue(m);
								}
							}

							while (m_Queue.Count > 0)
							{
								var m = (Mobile)m_Queue.Dequeue();

								if (SpellHelper.CanRevealCaster(m))
								{
									caster.RevealingAction();
								}

								caster.DoHarmful(m);

								var damage = m_Item.m_Damage;

								if (!Core.AOS && m.CheckSkill(SkillName.MagicResist, 0.0, 30.0))
								{
									damage = 1;

									m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
								}

								_ = AOS.Damage(m, caster, damage, 0, 100, 0, 0, 0);
								m.PlaySound(0x208);

								if (m is BaseCreature c)
								{
									c.OnHarmfulSpell(caster);
								}
							}
						}
					}
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly FireFieldSpell m_Owner;

			public InternalTarget(FireFieldSpell owner)
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

	/// GreaterHeal
	public class GreaterHealSpell : MagerySpell
	{
		public GreaterHealSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.GreaterHeal)
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
			else if (m is BaseCreature && ((BaseCreature)m).IsAnimatedDead)
			{
				Caster.SendLocalizedMessage(1061654); // You cannot heal that which is not alive.
			}
			else if (m.IsDeadBondedPet)
			{
				Caster.SendLocalizedMessage(1060177); // You cannot heal a creature that is already dead!
			}
			else if (m is Golem)
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 500951); // You cannot heal that.
			}
			else if (m.Poisoned || Server.Items.MortalStrike.IsWounded(m))
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x22, (Caster == m) ? 1005000 : 1010398);
			}
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				// Algorithm: (40% of magery) + (1-10)

				var toHeal = (int)(Caster.Skills[SkillName.Magery].Value * 0.4);
				toHeal += Utility.Random(1, 10);

				//m.Heal( toHeal, Caster );
				SpellHelper.Heal(toHeal, m, Caster);

				m.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);
				m.PlaySound(0x202);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private readonly GreaterHealSpell m_Owner;

			public InternalTarget(GreaterHealSpell owner)
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

	/// Lightning
	public class LightningSpell : MagerySpell
	{
		public override bool DelayedDamage => false;

		public LightningSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Lightning)
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

				double damage;

				if (Core.AOS)
				{
					damage = GetNewAosDamage(23, 1, 4, m);
				}
				else
				{
					damage = Utility.Random(12, 9);

					if (CheckResisted(m))
					{
						damage *= 0.75;

						m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar(m);
				}

				m.BoltEffect(0);

				SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly LightningSpell m_Owner;

			public InternalTarget(LightningSpell owner)
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

	/// ManaDrain
	public class ManaDrainSpell : MagerySpell
	{
		private static readonly Dictionary<Mobile, Timer> m_Table = new();

		public ManaDrainSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.ManaDrain)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		private void AosDelay_Callback(object state)
		{
			var states = (object[])state;

			var m = (Mobile)states[0];
			var mana = (int)states[1];

			if (m.Alive && !m.IsDeadBondedPet)
			{
				m.Mana += mana;

				m.FixedEffect(0x3779, 10, 25);
				m.PlaySound(0x28E);
			}

			_ = m_Table.Remove(m);
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

				if (m.Spell != null)
				{
					m.Spell.OnCasterHurt();
				}

				m.Paralyzed = false;

				if (Core.AOS)
				{
					var toDrain = 40 + (int)(GetDamageSkill(Caster) - GetResistSkill(m));

					if (toDrain < 0)
					{
						toDrain = 0;
					}
					else if (toDrain > m.Mana)
					{
						toDrain = m.Mana;
					}

					if (m_Table.ContainsKey(m))
					{
						toDrain = 0;
					}

					m.FixedParticles(0x3789, 10, 25, 5032, EffectLayer.Head);
					m.PlaySound(0x1F8);

					if (toDrain > 0)
					{
						m.Mana -= toDrain;

						m_Table[m] = Timer.DelayCall(TimeSpan.FromSeconds(5.0), AosDelay_Callback, new object[] { m, toDrain });
					}
				}
				else
				{
					if (CheckResisted(m))
					{
						m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
					}
					else if (m.Mana >= 100)
					{
						m.Mana -= Utility.Random(1, 100);
					}
					else
					{
						m.Mana -= Utility.Random(1, m.Mana);
					}

					m.FixedParticles(0x374A, 10, 15, 5032, EffectLayer.Head);
					m.PlaySound(0x1F8);
				}

				HarmfulSpell(m);
			}

			FinishSequence();
		}

		public override double GetResistPercent(Mobile target)
		{
			return 99.0;
		}

		private class InternalTarget : Target
		{
			private readonly ManaDrainSpell m_Owner;

			public InternalTarget(ManaDrainSpell owner)
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

	/// Recall
	public class RecallSpell : MagerySpell
	{
		private readonly RunebookEntry m_Entry;
		private readonly Runebook m_Book;

		public RecallSpell(Mobile caster, Item scroll)
			: this(caster, scroll, null, null)
		{
		}

		public RecallSpell(Mobile caster, Point3D loc, Map map)
			: this(caster, null, new RunebookEntry(loc, map, "Unknown", null), null)
		{
		}

		public RecallSpell(Mobile caster, Item scroll, RunebookEntry entry, Runebook book)
			: base(caster, scroll, MagerySpellName.Recall)
		{
			m_Entry = entry;
			m_Book = book;
		}

		public override void GetCastSkills(ref double req, out double min, out double max)
		{
			if (TransformationSpellHelper.UnderTransformation(Caster, typeof(WraithFormSpell)))
			{
				min = max = 0;
			}
			else if (Core.SE && m_Book != null) //recall using Runebook charge
			{
				min = max = 0;
			}
			else
			{
				base.GetCastSkills(ref req, out min, out max);
			}
		}

		public override void OnCast()
		{
			if (m_Entry == null)
			{
				Caster.Target = new InternalTarget(this);
			}
			else
			{
				Effect(m_Entry.Location, m_Entry.Map, true);
			}
		}

		public override bool CheckCast()
		{
			if (Factions.Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
				return false;
			}

			if (Caster.Criminal)
			{
				Caster.SendLocalizedMessage(1005561, "", 0x22); // Thou'rt a criminal and cannot escape so easily.
				return false;
			}

			if (SpellHelper.CheckCombat(Caster))
			{
				Caster.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle??
				return false;
			}

			if (Caster is PlayerMobile player)
			{
				if (WeightOverloading.IsOverloaded(player))
				{
					player.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
					return false;
				}

				return SpellHelper.CheckTravel(player, TravelCheckType.RecallFrom);
			}

			return true;
		}

		public void Effect(Point3D loc, Map map, bool checkMulti)
		{
			try
			{
				if (map == null)
				{
					Caster.SendLocalizedMessage(1005569); // You can not recall to another facet.
					return;
				}

				if (Factions.Sigil.ExistsOn(Caster))
				{
					Caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
					return;
				}

				if (Caster.Criminal)
				{
					Caster.SendLocalizedMessage(1005561, "", 0x22); // Thou'rt a criminal and cannot escape so easily.
					return;
				}

				if (SpellHelper.CheckCombat(Caster))
				{
					Caster.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle??
					return;
				}

				if (Caster is PlayerMobile player)
				{
					if (!Core.AOS && player.Map != map)
					{
						player.SendLocalizedMessage(1005569); // You can not recall to another facet.
						return;
					}

					if (map == Map.Felucca && player.Young)
					{
						player.SendLocalizedMessage(1049543); // You decide against traveling to Felucca while you are still young.
						return;
					}

					if (map != Map.Felucca && player.Murderer)
					{
						player.SendLocalizedMessage(1019004); // You are not allowed to travel there.
						return;
					}

					if (!SpellHelper.CheckTravel(player, TravelCheckType.RecallFrom))
					{
						return;
					}

					if (!SpellHelper.CheckTravel(player, map, loc, TravelCheckType.RecallTo))
					{
						return;
					}

					if (WeightOverloading.IsOverloaded(player))
					{
						player.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
						return;
					}
				}

				if (!map.CanSpawnMobile(loc.X, loc.Y, loc.Z))
				{
					Caster.SendLocalizedMessage(501942); // That location is blocked.
					return;
				}

				if (checkMulti && SpellHelper.CheckMulti(loc, map))
				{
					Caster.SendLocalizedMessage(501942); // That location is blocked.
					return;
				}

				if (m_Book != null && m_Book.CurCharges <= 0)
				{
					Caster.SendLocalizedMessage(502412); // There are no charges left on that item.
					return;
				}

				if (CheckSequence())
				{
					BaseCreature.TeleportPets(Caster, loc, map, true);

					if (m_Book != null)
					{
						--m_Book.CurCharges;
					}

					Caster.PlaySound(0x1FC);
					Caster.MoveToWorld(loc, map);
					Caster.PlaySound(0x1FC);
				}
			}
			finally
			{
				FinishSequence();
			}
		}

		private class InternalTarget : Target
		{
			private readonly RecallSpell m_Owner;

			public InternalTarget(RecallSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.None)
			{
				m_Owner = owner;

				owner.Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 501029); // Select Marked item.
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is RecallRune rune)
				{
					if (rune.Marked)
					{
						m_Owner.Effect(rune.Target, rune.TargetMap, true);
					}
					else
					{
						from.SendLocalizedMessage(501805); // That rune is not yet marked.
					}
				}
				else if (o is Runebook book)
				{
					var e = book.Default;

					if (e != null)
					{
						m_Owner.Effect(e.Location, e.Map, true);
					}
					else
					{
						from.SendLocalizedMessage(502354); // Target is not marked.
					}
				}
				else if (o is Key k && k.KeyValue != 0 && k.Link is BaseBoat boat)
				{
					if (!boat.Deleted && boat.CheckKey(k.KeyValue))
					{
						m_Owner.Effect(boat.GetMarkedLocation(), boat.Map, false);
					}
					else
					{
						from.SendLocalizedMessage(502357); // I can not recall from that object.
					}
				}
				else if (o is HouseRaffleDeed deed && deed.ValidLocation())
				{
					m_Owner.Effect(deed.PlotLocation, deed.PlotFacet, true);
				}
				else
				{
					from.SendLocalizedMessage(502357); // I can not recall from that object.
				}
			}

			protected override void OnNonlocalTarget(Mobile from, object o)
			{
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}