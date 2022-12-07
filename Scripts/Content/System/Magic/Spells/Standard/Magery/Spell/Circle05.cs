using Server.Factions;
using Server.Items;
using Server.Mobiles;
using Server.Spells.Chivalry;
using Server.Spells.Magery;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Spells.Magery
{
	/// BladeSpirit
	public class BladeSpiritsSpell : MagerySpell
	{
		public BladeSpiritsSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.BladeSpirits)
		{
		}

		public override TimeSpan GetCastDelay()
		{
			if (Core.AOS)
			{
				return TimeSpan.FromTicks(base.GetCastDelay().Ticks * (Core.SE ? 3 : 5));
			}

			return base.GetCastDelay() + TimeSpan.FromSeconds(6.0);
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if ((Caster.Followers + (Core.SE ? 2 : 1)) > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			var map = Caster.Map;

			SpellHelper.GetSurfaceTop(ref p);

			if (map == null || !map.CanSpawnMobile(p.X, p.Y, p.Z))
			{
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			}
			else if (!SpellHelper.CheckTown(this, p))
			{ }
			else if (CheckSequence())
			{
				TimeSpan duration;

				if (Core.AOS)
				{
					duration = TimeSpan.FromSeconds(120);
				}
				else
				{
					duration = TimeSpan.FromSeconds(Utility.Random(80, 40));
				}

				_ = BaseCreature.Summon(new BladeSpirits(), false, Caster, new Point3D(p), 0x212, duration);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private BladeSpiritsSpell m_Owner;

			public InternalTarget(BladeSpiritsSpell owner)
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

			protected override void OnTargetOutOfLOS(Mobile from, object o)
			{
				from.SendLocalizedMessage(501943); // Target cannot be seen. Try again.
				from.Target = new InternalTarget(m_Owner);
				from.Target.BeginTimeout(from, TimeoutTime - DateTime.UtcNow);
				m_Owner = null;
			}

			protected override void OnTargetFinish(Mobile from)
			{
				if (m_Owner != null)
				{
					m_Owner.FinishSequence();
				}
			}
		}
	}

	/// DispelField
	public class DispelFieldSpell : MagerySpell
	{
		public DispelFieldSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.DispelField)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Item item)
		{
			var t = item.GetType();

			if (!Caster.CanSee(item))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (!t.IsDefined(typeof(DispellableFieldAttribute), false))
			{
				Caster.SendLocalizedMessage(1005049); // That cannot be dispelled.
			}
			else if (item is Moongate && !((Moongate)item).Dispellable)
			{
				Caster.SendLocalizedMessage(1005047); // That magic is too chaotic
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, item);

				Effects.SendLocationParticles(EffectItem.Create(item.Location, item.Map, EffectItem.DefaultDuration), 0x376A, 9, 20, 5042);
				Effects.PlaySound(item.GetWorldLocation(), item.Map, 0x201);

				item.Delete();
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly DispelFieldSpell m_Owner;

			public InternalTarget(DispelFieldSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Item)
				{
					m_Owner.Target((Item)o);
				}
				else
				{
					m_Owner.Caster.SendLocalizedMessage(1005049); // That cannot be dispelled.
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// Incognito
	public class IncognitoSpell : MagerySpell
	{
		private static readonly Dictionary<Mobile, Timer> m_Timers = new();

		public IncognitoSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Incognito)
		{
		}

		public override bool CheckCast()
		{
			if (Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1010445); // You cannot incognito if you have a sigil
				return false;
			}
			
			if (IsIncognito(Caster))
			{
				Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
				return false;
			}
			
			if (Caster.BodyMod.BodyID is 183 or 184)
			{
				Caster.SendLocalizedMessage(1042402); // You cannot use incognito while wearing body paint
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if (Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1010445); // You cannot incognito if you have a sigil
			}
			else if (IsIncognito(Caster))
			{
				Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
			}
			else if (Caster.BodyMod.BodyID is 183 or 184)
			{
				Caster.SendLocalizedMessage(1042402); // You cannot use incognito while wearing body paint
			}
			else if (DisguiseTimers.IsDisguised(Caster))
			{
				Caster.SendLocalizedMessage(1061631); // You can't do that while disguised.
			}
			else if (PolymorphSpell.IsPolymorphed(Caster) || Caster.IsBodyMod)
			{
				DoFizzle();
			}
			else if (CheckSequence())
			{
				if (Caster.BeginAction(typeof(IncognitoSpell)))
				{
					_ = DisguiseTimers.StopTimer(Caster);

					Caster.HueMod = Caster.Race.RandomSkinHue();
					Caster.NameMod = Caster.Female ? NameList.RandomName("female") : NameList.RandomName("male");

					if (Caster is PlayerMobile pm && pm.Race != null)
					{
						pm.SetHairMods(pm.Race.RandomHair(pm.Female), pm.Race.RandomFacialHair(pm.Female));
						pm.HairHue = pm.Race.RandomHairHue();
						pm.FacialHairHue = pm.Race.RandomHairHue();
					}

					Caster.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
					Caster.PlaySound(0x3BD);

					BaseArmor.ValidateMobile(Caster);
					BaseClothing.ValidateMobile(Caster);

					StopTimer(Caster);

					var duration = TimeSpan.FromSeconds(Math.Min(144.0, (6 * Caster.Skills.Magery.Fixed / 50) + 1));

					m_Timers[Caster] = Timer.DelayCall(duration, EndIncognito, Caster);

					BuffInfo.AddBuff(Caster, new BuffInfo(BuffIcon.Incognito, 1075819));
				}
				else
				{
					Caster.SendLocalizedMessage(1079022); // You're already incognitoed!
				}
			}

			FinishSequence();
		}

		private static void StopTimer(Mobile m)
		{
			BuffInfo.RemoveBuff(m, BuffIcon.Incognito);

			if (m != null && m_Timers.TryGetValue(m, out var t))
			{
				t?.Stop();

				m_Timers.Remove(m);
			}
		}

		public static void EndIncognito(Mobile m)
		{
			StopTimer(m);

			if (m != null && IsIncognito(m))
			{
				if (m is PlayerMobile pm)
				{
					pm.SetHairMods(-1, -1);
				}

				m.BodyMod = 0;
				m.HueMod = -1;
				m.NameMod = null;

				m.EndAction(typeof(IncognitoSpell));

				BaseArmor.ValidateMobile(m);
				BaseClothing.ValidateMobile(m);
			}
		}

		public static bool IsIncognito(Mobile m)
		{
			return m?.CanBeginAction(typeof(IncognitoSpell)) == false;
		}
	}

	/// MagicReflect
	public class MagicReflectSpell : MagerySpell
	{
		private static readonly Hashtable m_Table = new();

		public MagicReflectSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.MagicReflect)
		{
		}

		public override bool CheckCast()
		{
			if (Core.AOS)
			{
				return true;
			}

			if (Caster.MagicDamageAbsorb > 0)
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
				/* The magic reflection spell decreases the caster's physical resistance, while increasing the caster's elemental resistances.
				 * Physical decrease = 25 - (Inscription/20).
				 * Elemental resistance = +10 (-20 physical, +10 elemental at GM Inscription)
				 * The magic reflection spell has an indefinite duration, becoming active when cast, and deactivated when re-cast.
				 * Reactive Armor, Protection, and Magic Reflection will stay on—even after logging out, even after dying—until you “turn them off” by casting them again. 
				 */

				if (CheckSequence())
				{
					var targ = Caster;

					var mods = (ResistanceMod[])m_Table[targ];

					if (mods == null)
					{
						targ.PlaySound(0x1E9);
						targ.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);

						var physiMod = -25 + (int)(targ.Skills[SkillName.Inscribe].Value / 20);
						var otherMod = 10;

						mods = new ResistanceMod[5]
						{
							new ResistanceMod(ResistanceType.Physical, physiMod),
							new ResistanceMod(ResistanceType.Fire, otherMod),
							new ResistanceMod(ResistanceType.Cold, otherMod),
							new ResistanceMod(ResistanceType.Poison, otherMod),
							new ResistanceMod(ResistanceType.Energy, otherMod),
						};

						m_Table[targ] = mods;

						for (var i = 0; i < mods.Length; ++i)
						{
							targ.AddResistanceMod(mods[i]);
						}

						var buffFormat = String.Format("{0}\t+{1}\t+{1}\t+{1}\t+{1}", physiMod, otherMod);

						BuffInfo.AddBuff(targ, new BuffInfo(BuffIcon.MagicReflection, 1075817, buffFormat, true));
					}
					else
					{
						targ.PlaySound(0x1ED);
						targ.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);

						m_Table.Remove(targ);

						for (var i = 0; i < mods.Length; ++i)
						{
							targ.RemoveResistanceMod(mods[i]);
						}

						BuffInfo.RemoveBuff(targ, BuffIcon.MagicReflection);
					}
				}

				FinishSequence();
			}
			else
			{
				if (Caster.MagicDamageAbsorb > 0)
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
						var value = (int)(Caster.Skills[SkillName.Magery].Value + Caster.Skills[SkillName.Inscribe].Value);
						value = (int)(8 + (value / 200 * 7.0));//absorb from 8 to 15 "circles"

						Caster.MagicDamageAbsorb = value;

						Caster.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);
						Caster.PlaySound(0x1E9);
					}
					else
					{
						Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
					}
				}

				FinishSequence();
			}
		}

		public static bool HasReflect(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void EndReflect(Mobile m)
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
				BuffInfo.RemoveBuff(m, BuffIcon.MagicReflection);
			}
		}
	}

	/// MindBlast
	public class MindBlastSpell : MagerySpell
	{
		public override bool DelayedDamage => !Core.AOS;

		public MindBlastSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.MindBlast)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		private void AosDelay_Callback(object state)
		{
			var states = (object[])state;
			var caster = (Mobile)states[0];
			var target = (Mobile)states[1];
			var defender = (Mobile)states[2];
			var damage = (int)states[3];

			if (caster.HarmfulCheck(defender))
			{
				SpellHelper.Damage(this, target, Utility.RandomMinMax(damage, damage + 4), 0, 0, 100, 0, 0);

				target.FixedParticles(0x374A, 10, 15, 5038, 1181, 2, EffectLayer.Head);
				target.PlaySound(0x213);
			}
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (Core.AOS)
			{
				if (Caster.CanBeHarmful(m) && CheckSequence())
				{
					Mobile from = Caster, target = m;

					SpellHelper.Turn(from, target);

					SpellHelper.CheckReflect((int)Circle, ref from, ref target);

					var damage = (int)((Caster.Skills[SkillName.Magery].Value + Caster.Int) / 5);

					if (damage > 60)
					{
						damage = 60;
					}

					_ = Timer.DelayCall(TimeSpan.FromSeconds(1.0),
						AosDelay_Callback,
						new object[] { Caster, target, m, damage });
				}
			}
			else if (CheckHSequence(m))
			{
				Mobile from = Caster, target = m;

				SpellHelper.Turn(from, target);

				SpellHelper.CheckReflect((int)Circle, ref from, ref target);

				// Algorithm: (highestStat - lowestStat) / 2 [- 50% if resisted]

				int highestStat = target.Str, lowestStat = target.Str;

				if (target.Dex > highestStat)
				{
					highestStat = target.Dex;
				}

				if (target.Dex < lowestStat)
				{
					lowestStat = target.Dex;
				}

				if (target.Int > highestStat)
				{
					highestStat = target.Int;
				}

				if (target.Int < lowestStat)
				{
					lowestStat = target.Int;
				}

				if (highestStat > 150)
				{
					highestStat = 150;
				}

				if (lowestStat > 150)
				{
					lowestStat = 150;
				}

				var damage = GetDamageScalar(m) * (highestStat - lowestStat) / 2; // Many users prefer 3 or 4

				if (damage > 45)
				{
					damage = 45;
				}

				if (CheckResisted(target))
				{
					damage /= 2;
					target.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

				from.FixedParticles(0x374A, 10, 15, 2038, EffectLayer.Head);

				target.FixedParticles(0x374A, 10, 15, 5038, EffectLayer.Head);
				target.PlaySound(0x213);

				SpellHelper.Damage(this, target, damage, 0, 0, 100, 0, 0);
			}

			FinishSequence();
		}

		public override double GetSlayerDamageScalar(Mobile target)
		{
			return 1.0; //This spell isn't affected by slayer spellbooks
		}

		private class InternalTarget : Target
		{
			private readonly MindBlastSpell m_Owner;

			public InternalTarget(MindBlastSpell owner)
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

	/// Paralyze
	public class ParalyzeSpell : MagerySpell
	{
		public ParalyzeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Paralyze)
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
			else if (Core.AOS && (m.Frozen || m.Paralyzed || (m.Spell != null && m.Spell.IsCasting && m.Spell is not ChivalrySpell)))
			{
				Caster.SendLocalizedMessage(1061923); // The target is already frozen.
			}
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				double duration;

				if (Core.AOS)
				{
					var secs = (int)((GetDamageSkill(Caster) / 10) - (GetResistSkill(m) / 10));

					if (!Core.SE)
					{
						secs += 2;
					}

					if (!m.Player)
					{
						secs *= 3;
					}

					if (secs < 0)
					{
						secs = 0;
					}

					duration = secs;
				}
				else
				{
					// Algorithm: ((20% of magery) + 7) seconds [- 50% if resisted]

					duration = 7.0 + (Caster.Skills[SkillName.Magery].Value * 0.2);

					if (CheckResisted(m))
					{
						duration *= 0.75;
					}
				}

				if (m is PlagueBeastLord pbl)
				{
					pbl.OnParalyzed(Caster);
					duration = 120;
				}

				m.Paralyze(TimeSpan.FromSeconds(duration));

				m.PlaySound(0x204);
				m.FixedEffect(0x376A, 6, 1);

				HarmfulSpell(m);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private readonly ParalyzeSpell m_Owner;

			public InternalTarget(ParalyzeSpell owner)
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

	/// PoisonField
	public class PoisonFieldSpell : MagerySpell
	{
		public PoisonFieldSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.PoisonField)
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

				var itemID = eastToWest ? 0x3915 : 0x3922;

				var duration = TimeSpan.FromSeconds(3 + (Caster.Skills.Magery.Fixed / 25));

				for (var i = -2; i <= 2; ++i)
				{
					var loc = new Point3D(eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z);

					_ = new InternalItem(itemID, loc, Caster, Caster.Map, duration, i);
				}
			}

			FinishSequence();
		}

		[DispellableField]
		public class InternalItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private Mobile m_Caster;

			public override bool BlocksFit => true;

			public InternalItem(int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, int val)
				: base(itemID)
			{
				var canFit = SpellHelper.AdjustField(ref loc, map, 12, false);

				Visible = false;
				Movable = false;
				Light = LightType.Circle300;

				MoveToWorld(loc, map);

				m_Caster = caster;

				m_End = DateTime.UtcNow + duration;

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(Math.Abs(val) * 0.2), caster.InLOS(this), canFit);
				m_Timer.Start();
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

			public void ApplyPoisonTo(Mobile m)
			{
				if (m_Caster == null)
				{
					return;
				}

				Poison p;

				if (Core.AOS)
				{
					var total = (m_Caster.Skills.Magery.Fixed + m_Caster.Skills.Poisoning.Fixed) / 2;

					if (total >= 1000)
					{
						p = Poison.Deadly;
					}
					else if (total > 850)
					{
						p = Poison.Greater;
					}
					else if (total > 650)
					{
						p = Poison.Regular;
					}
					else
					{
						p = Poison.Lesser;
					}
				}
				else
				{
					p = Poison.Regular;
				}

				if (m.ApplyPoison(m_Caster, p) == ApplyPoisonResult.Poisoned)
				{
					if (SpellHelper.CanRevealCaster(m))
					{
						m_Caster.RevealingAction();
					}
				}

				if (m is BaseCreature c)
				{
					c.OnHarmfulSpell(m_Caster);
				}
			}

			public override bool OnMoveOver(Mobile m)
			{
				if (Visible && m_Caster != null && (!Core.AOS || m != m_Caster) && SpellHelper.ValidIndirectTarget(m_Caster, m) && m_Caster.CanBeHarmful(m, false))
				{
					m_Caster.DoHarmful(m);

					ApplyPoisonTo(m);
					m.PlaySound(0x474);
				}

				return true;
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(1); // version

				writer.Write(m_Caster);
				writer.WriteDeltaTime(m_End);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				var version = reader.ReadInt();

				switch (version)
				{
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
			}

			private class InternalTimer : Timer
			{
				private readonly InternalItem m_Item;
				private readonly bool m_InLOS, m_CanFit;

				private static readonly Queue<Mobile> m_Queue = new();

				public InternalTimer(InternalItem item, TimeSpan delay, bool inLOS, bool canFit)
					: base(delay, TimeSpan.FromSeconds(1.5))
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
							Effects.SendLocationParticles(EffectItem.Create(m_Item.Location, m_Item.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 5040);
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
							var eastToWest = m_Item.ItemID == 0x3915;
							var eable = map.GetMobilesInBounds(new Rectangle2D(m_Item.X - (eastToWest ? 0 : 1), m_Item.Y - (eastToWest ? 1 : 0), eastToWest ? 1 : 2, eastToWest ? 2 : 1));

							foreach (var m in eable)
							{
								if ((m.Z + 16) > m_Item.Z && (m_Item.Z + 12) > m.Z && (!Core.AOS || m != caster) && SpellHelper.ValidIndirectTarget(caster, m) && caster.CanBeHarmful(m, false))
								{
									m_Queue.Enqueue(m);
								}
							}

							eable.Free();

							while (m_Queue.Count > 0)
							{
								var m = m_Queue.Dequeue();

								caster.DoHarmful(m);

								m_Item.ApplyPoisonTo(m);
								m.PlaySound(0x474);
							}
						}
					}
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly PoisonFieldSpell m_Owner;

			public InternalTarget(PoisonFieldSpell owner)
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

	/// SummonCreature
	public class SummonCreatureSpell : MagerySpell
	{
		// NOTE: Creature list based on 1hr of summon/release on OSI.

		private static readonly Type[] m_Types =
		{
			typeof(PolarBear),
			typeof(GrizzlyBear),
			typeof(BlackBear),
			typeof(Horse),
			typeof(Walrus),
			typeof(Chicken),
			typeof(Scorpion),
			typeof(GiantSerpent),
			typeof(Llama),
			typeof(Alligator),
			typeof(GreyWolf),
			typeof(Slime),
			typeof(Eagle),
			typeof(Gorilla),
			typeof(SnowLeopard),
			typeof(Pig),
			typeof(Hind),
			typeof(Rabbit)
		};

		public SummonCreatureSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.SummonCreature)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if ((Caster.Followers + 2) > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				try
				{
					var creature = (BaseCreature)Activator.CreateInstance(m_Types[Utility.Random(m_Types.Length)]);

					//creature.ControlSlots = 2;

					TimeSpan duration;

					if (Core.AOS)
					{
						duration = TimeSpan.FromSeconds(2 * Caster.Skills.Magery.Fixed / 5);
					}
					else
					{
						duration = TimeSpan.FromSeconds(4.0 * Caster.Skills[SkillName.Magery].Value);
					}

					SpellHelper.Summon(creature, Caster, 0x215, duration, false, false);
				}
				catch
				{
				}
			}

			FinishSequence();
		}

		public override TimeSpan GetCastDelay()
		{
			if (Core.AOS)
			{
				return TimeSpan.FromTicks(base.GetCastDelay().Ticks * 5);
			}

			return base.GetCastDelay() + TimeSpan.FromSeconds(6.0);
		}
	}
}