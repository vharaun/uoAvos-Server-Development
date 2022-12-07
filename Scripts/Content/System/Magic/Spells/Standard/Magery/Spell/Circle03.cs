using Server.Factions;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Multis;
using Server.Network;
using Server.Regions;
using Server.Spells.Magery;
using Server.Targeting;

using System;

namespace Server
{
	public interface ITelekinesisable : IPoint3D
	{
		void OnTelekinesis(Mobile from);
	}
}

namespace Server.Spells.Magery
{
	/// Bless
	public class BlessSpell : MagerySpell
	{
		public BlessSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Bless)
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
				SpellHelper.DisableSkillCheck = true;
				_ = SpellHelper.AddStatBonus(Caster, m, StatType.Dex);
				_ = SpellHelper.AddStatBonus(Caster, m, StatType.Int);
				SpellHelper.DisableSkillCheck = false;

				m.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist);
				m.PlaySound(0x1EA);

				var percentage = (int)(SpellHelper.GetOffsetScalar(Caster, m, false) * 100);
				var length = SpellHelper.GetDuration(Caster, m);

				var args = String.Format("{0}\t{1}\t{2}", percentage, percentage, percentage);

				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Bless, 1075847, 1075848, length, m, args.ToString()));
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly BlessSpell m_Owner;

			public InternalTarget(BlessSpell owner)
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

	/// Fireball
	public class FireballSpell : MagerySpell
	{
		public FireballSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Fireball)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage => true;

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
					damage = GetNewAosDamage(19, 1, 5, m);
				}
				else
				{
					damage = Utility.Random(10, 7);

					if (CheckResisted(m))
					{
						damage *= 0.75;

						m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar(m);
				}

				source.MovingParticles(m, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160);
				source.PlaySound(Core.AOS ? 0x15E : 0x44B);

				SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly FireballSpell m_Owner;

			public InternalTarget(FireballSpell owner)
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

	/// MagicLock
	public class MagicLockSpell : MagerySpell
	{
		public MagicLockSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.MagicLock)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(LockableContainer targ)
		{
			if (Multis.BaseHouse.CheckLockedDownOrSecured(targ))
			{
				// You cannot cast this on a locked down item.
				Caster.LocalOverheadMessage(MessageType.Regular, 0x22, 501761);
			}
			else if (targ.Locked || targ.LockLevel == 0 || targ is ParagonChest)
			{
				// Target must be an unlocked chest.
				Caster.SendLocalizedMessage(501762);
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, targ);

				var loc = targ.GetWorldLocation();

				Effects.SendLocationParticles(
					EffectItem.Create(loc, targ.Map, EffectItem.DefaultDuration),
					0x376A, 9, 32, 5020);

				Effects.PlaySound(loc, targ.Map, 0x1FA);

				// The chest is now locked!
				Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 501763);

				targ.LockLevel = -255; // signal magic lock
				targ.Locked = true;
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly MagicLockSpell m_Owner;

			public InternalTarget(MagicLockSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is LockableContainer)
				{
					m_Owner.Target((LockableContainer)o);
				}
				else
				{
					from.SendLocalizedMessage(501762); // Target must be an unlocked chest.
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// Poison
	public class PoisonSpell : MagerySpell
	{
		public PoisonSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Poison)
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

				if (m.Spell != null)
				{
					m.Spell.OnCasterHurt();
				}

				m.Paralyzed = false;

				if (CheckResisted(m))
				{
					m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}
				else
				{
					int level;

					if (Core.AOS)
					{
						if (Caster.InRange(m, 2))
						{
							var total = (Caster.Skills.Magery.Fixed + Caster.Skills.Poisoning.Fixed) / 2;

							if (total >= 1000)
							{
								level = 3;
							}
							else if (total > 850)
							{
								level = 2;
							}
							else if (total > 650)
							{
								level = 1;
							}
							else
							{
								level = 0;
							}
						}
						else
						{
							level = 0;
						}
					}
					else
					{
						//double total = Caster.Skills[SkillName.Magery].Value + Caster.Skills[SkillName.Poisoning].Value;

						#region Dueling
						var total = Caster.Skills[SkillName.Magery].Value;

						if (Caster is PlayerMobile pm)
						{
							if (pm.DuelContext == null || !pm.DuelContext.Started || pm.DuelContext.Finished || pm.DuelContext.Ruleset.GetOption("Skills", "Poisoning"))
							{
								total += Caster.Skills[SkillName.Poisoning].Value;
							}
						}
						else
						{
							total += Caster.Skills[SkillName.Poisoning].Value;
						}
						#endregion

						var dist = Caster.GetDistanceToSqrt(m);

						if (dist >= 3.0)
						{
							total -= (dist - 3.0) * 10.0;
						}

						if (total >= 200.0 && 1 > Utility.Random(10))
						{
							level = 3;
						}
						else if (total > (Core.AOS ? 170.1 : 170.0))
						{
							level = 2;
						}
						else if (total > (Core.AOS ? 130.1 : 130.0))
						{
							level = 1;
						}
						else
						{
							level = 0;
						}
					}

					_ = m.ApplyPoison(Caster, Poison.GetPoison(level));
				}

				m.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist);
				m.PlaySound(0x205);

				HarmfulSpell(m);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly PoisonSpell m_Owner;

			public InternalTarget(PoisonSpell owner)
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

	/// Telekinesis
	public class TelekinesisSpell : MagerySpell
	{
		public TelekinesisSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Telekinesis)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(ITelekinesisable obj)
		{
			if (CheckSequence())
			{
				SpellHelper.Turn(Caster, obj);

				obj.OnTelekinesis(Caster);
			}

			FinishSequence();
		}

		public void Target(Container item)
		{
			if (CheckSequence())
			{
				SpellHelper.Turn(Caster, item);

				var root = item.RootParent;

				if (!item.IsAccessibleTo(Caster))
				{
					item.OnDoubleClickNotAccessible(Caster);
				}
				else if (!item.CheckItemUse(Caster, item))
				{
				}
				else if (root != null && root is Mobile && root != Caster)
				{
					item.OnSnoop(Caster);
				}
				else if (item is Corpse c && !c.CheckLoot(Caster, null))
				{
				}
				else if (Caster.Region.OnDoubleClick(Caster, item))
				{
					Effects.SendLocationParticles(EffectItem.Create(item.Location, item.Map, EffectItem.DefaultDuration), 0x376A, 9, 32, 5022);
					Effects.PlaySound(item.Location, item.Map, 0x1F5);

					item.OnItemUsed(Caster, item);
				}
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private readonly TelekinesisSpell m_Owner;

			public InternalTarget(TelekinesisSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is ITelekinesisable t)
				{
					m_Owner.Target(t);
				}
				else if (o is Container c)
				{
					m_Owner.Target(c);
				}
				else
				{
					from.SendLocalizedMessage(501857); // This spell won't work on that!
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// Teleport
	public class TeleportSpell : MagerySpell
	{
		public TeleportSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Teleport)
		{
		}

		public override bool CheckCast()
		{
			if (Factions.Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
				return false;
			}

			if (WeightOverloading.IsOverloaded(Caster))
			{
				Caster.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
				return false;
			}

			return SpellHelper.CheckTravel(Caster, TravelCheckType.TeleportFrom);
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			var orig = p;
			var map = Caster.Map;

			SpellHelper.GetSurfaceTop(ref p);

			var from = Caster.Location;
			var to = new Point3D(p);

			if (Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
			}
			else if (WeightOverloading.IsOverloaded(Caster))
			{
				Caster.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
			}
			else if (!SpellHelper.CheckTravel(Caster, TravelCheckType.TeleportFrom))
			{
			}
			else if (!SpellHelper.CheckTravel(Caster, map, to, TravelCheckType.TeleportTo))
			{
			}
			else if (map == null || !map.CanSpawnMobile(p.X, p.Y, p.Z))
			{
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			}
			else if (SpellHelper.CheckMulti(to, map))
			{
				Caster.SendLocalizedMessage(502831); // Cannot teleport to that spot.
			}
			else if (Region.Find(to, map).IsPartOf<HouseRegion>())
			{
				Caster.SendLocalizedMessage(502829); // Cannot teleport to that spot.
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, orig);

				var m = Caster;

				m.Location = to;
				m.ProcessDelta();

				if (m.Player)
				{
					Effects.SendLocationParticles(EffectItem.Create(from, m.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
					Effects.SendLocationParticles(EffectItem.Create(to, m.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 5023);
				}
				else
				{
					m.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
				}

				m.PlaySound(0x1FE);

				var eable = m.GetItemsInRange(0);

				foreach (var item in eable)
				{
					if (item is ParalyzeFieldSpell.InternalItem or PoisonFieldSpell.InternalItem or FireFieldSpell.FireFieldItem)
					{
						_ = item.OnMoveOver(m);
					}
				}

				eable.Free();
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private readonly TeleportSpell m_Owner;

			public InternalTarget(TeleportSpell owner)
				: base(Core.ML ? 11 : 12, true, TargetFlags.None)
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

	/// Unlock
	public class UnlockSpell : MagerySpell
	{
		public UnlockSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.Unlock)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		private class InternalTarget : Target
		{
			private readonly UnlockSpell m_Owner;

			public InternalTarget(UnlockSpell owner)
				: base(Core.ML ? 10 : 12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is not IPoint3D loc)
				{
					return;
				}

				if (m_Owner.CheckSequence())
				{
					SpellHelper.Turn(from, o);

					Effects.SendLocationParticles(EffectItem.Create(new Point3D(loc), from.Map, EffectItem.DefaultDuration), 0x376A, 9, 32, 5024);

					Effects.PlaySound(loc, from.Map, 0x1FF);

					if (o is Mobile)
					{
						from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 503101); // That did not need to be unlocked.
					}
					else if (o is LockableContainer cont)
					{
						if (BaseHouse.CheckSecured(cont))
						{
							from.SendLocalizedMessage(503098); // You cannot cast this on a secure item.
						}
						else if (!cont.Locked)
						{
							from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 503101); // That did not need to be unlocked.
						}
						else if (cont.LockLevel == 0)
						{
							from.SendLocalizedMessage(501666); // You can't unlock that!
						}
						else
						{
							var level = (int)(from.Skills[SkillName.Magery].Value * 0.8) - 4;

							if (level >= cont.RequiredSkill && (cont is not TreasureMapChest c || c.Level <= 2))
							{
								cont.Locked = false;

								if (cont.LockLevel == -255)
								{
									cont.LockLevel = cont.RequiredSkill - 10;
								}
							}
							else
							{
								from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 503099); // My spell does not seem to have an effect on that lock.
							}
						}
					}
					else
					{
						from.SendLocalizedMessage(501666); // You can't unlock that!
					}
				}

				m_Owner.FinishSequence();
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// WallofStone
	public class WallOfStoneSpell : MagerySpell
	{
		public WallOfStoneSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MagerySpellName.WallOfStone)
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

				Effects.PlaySound(p, Caster.Map, 0x1F6);

				for (var i = -1; i <= 1; ++i)
				{
					var loc = new Point3D(eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z);
					var canFit = SpellHelper.AdjustField(ref loc, Caster.Map, 22, true);

					if (!canFit)
					{
						continue;
					}

					Item item = new InternalItem(loc, Caster.Map, Caster);

					Effects.SendLocationParticles(item, 0x376A, 9, 10, 5025);
				}
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private readonly Mobile m_Caster;

			public override bool BlocksFit => true;

			public InternalItem(Point3D loc, Map map, Mobile caster)
				: base(0x82)
			{
				Visible = false;
				Movable = false;

				MoveToWorld(loc, map);

				m_Caster = caster;

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

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(10.0));
				m_Timer.Start();

				m_End = DateTime.UtcNow + TimeSpan.FromSeconds(10.0);
			}

			public InternalItem(Serial serial)
				: base(serial)
			{
			}

			public override bool OnMoveOver(Mobile m)
			{
				int noto;

				if (m is PlayerMobile)
				{
					noto = Notoriety.Compute(m_Caster, m);
					if (noto is Notoriety.Enemy or Notoriety.Ally)
					{
						return false;
					}
				}

				return base.OnMoveOver(m);
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if (m_Timer != null)
				{
					m_Timer.Stop();
				}
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(1); // version

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
							m_End = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_End - DateTime.UtcNow);
							m_Timer.Start();

							break;
						}
					case 0:
						{
							var duration = TimeSpan.FromSeconds(10.0);

							m_Timer = new InternalTimer(this, duration);
							m_Timer.Start();

							m_End = DateTime.UtcNow + duration;

							break;
						}
				}
			}

			private class InternalTimer : Timer
			{
				private readonly InternalItem m_Item;

				public InternalTimer(InternalItem item, TimeSpan duration)
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
			private readonly WallOfStoneSpell m_Owner;

			public InternalTarget(WallOfStoneSpell owner)
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
}