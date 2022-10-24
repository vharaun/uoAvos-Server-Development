using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	/// Bola
	public class Bola : Item
	{
		[Constructable]
		public Bola() : this(1)
		{
		}

		[Constructable]
		public Bola(int amount) : base(0x26AC)
		{
			Weight = 4.0;
			Stackable = true;
			Amount = amount;
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1040019); // The bola must be in your pack to use it.
			}
			else if (!from.CanBeginAction(typeof(Bola)))
			{
				from.SendLocalizedMessage(1049624); // You have to wait a few moments before you can use another bola!
			}
			else if (from.Target is BolaTarget)
			{
				from.SendLocalizedMessage(1049631); // This bola is already being used.
			}
			else if (!HasFreeHands(from))
			{
				from.SendLocalizedMessage(1040015); // Your hands must be free to use this
			}
			else if (from.Mounted)
			{
				from.SendLocalizedMessage(1040016); // You cannot use this while riding a mount
			}
			else if (Server.Spells.Ninjitsu.AnimalFormSpell.UnderTransformation(from))
			{
				from.SendLocalizedMessage(1070902); // You can't use this while in an animal form!
			}
			else
			{
				EtherealMount.StopMounting(from);

				from.Target = new BolaTarget(this);
				from.LocalOverheadMessage(MessageType.Emote, 0x3B2, 1049632); // * You begin to swing the bola...*
				from.NonlocalOverheadMessage(MessageType.Emote, 0x3B2, 1049633, from.Name); // ~1_NAME~ begins to menacingly swing a bola...
			}
		}

		private static void ReleaseBolaLock(object state)
		{
			((Mobile)state).EndAction(typeof(Bola));
		}

		private static void FinishThrow(object state)
		{
			var states = (object[])state;

			var from = (Mobile)states[0];
			var to = (Mobile)states[1];

			if (Core.AOS)
			{
				new Bola().MoveToWorld(to.Location, to.Map);
			}

			if (to is ChaosDragoon || to is ChaosDragoonElite)
			{
				from.SendLocalizedMessage(1042047); // You fail to knock the rider from its mount.
			}

			var mt = to.Mount;
			if (mt != null && !(to is ChaosDragoon || to is ChaosDragoonElite))
			{
				mt.Rider = null;
			}

			if (to is PlayerMobile)
			{
				if (Server.Spells.Ninjitsu.AnimalFormSpell.UnderTransformation(to))
				{
					to.SendLocalizedMessage(1114066, from.Name); // ~1_NAME~ knocked you out of animal form!
				}
				else if (to.Mounted)
				{
					to.SendLocalizedMessage(1040023); // You have been knocked off of your mount!
				}

				(to as PlayerMobile).SetMountBlock(BlockMountType.Dazed, TimeSpan.FromSeconds(Core.ML ? 10 : 3), true);
			}

			if (Core.AOS && from is PlayerMobile) /* only failsafe, attacker should already be dismounted */
			{
				(from as PlayerMobile).SetMountBlock(BlockMountType.BolaRecovery, TimeSpan.FromSeconds(Core.ML ? 10 : 3), true);
			}

			to.Damage(1);

			Timer.DelayCall(TimeSpan.FromSeconds(2.0), ReleaseBolaLock, from);
		}

		private static bool HasFreeHands(Mobile from)
		{
			var one = from.FindItemOnLayer(Layer.OneHanded);
			var two = from.FindItemOnLayer(Layer.TwoHanded);

			if (Core.SE)
			{
				var pack = from.Backpack;

				if (pack != null)
				{
					if (one != null && one.Movable)
					{
						pack.DropItem(one);
						one = null;
					}

					if (two != null && two.Movable)
					{
						pack.DropItem(two);
						two = null;
					}
				}
			}
			else if (Core.AOS)
			{
				if (one != null && one.Movable)
				{
					from.AddToBackpack(one);
					one = null;
				}

				if (two != null && two.Movable)
				{
					from.AddToBackpack(two);
					two = null;
				}
			}

			return (one == null && two == null);
		}

		public class BolaTarget : Target
		{
			private readonly Bola m_Bola;

			public BolaTarget(Bola bola) : base(8, false, TargetFlags.Harmful)
			{
				m_Bola = bola;
			}

			protected override void OnTarget(Mobile from, object obj)
			{
				if (m_Bola.Deleted)
				{
					return;
				}

				if (obj is Mobile)
				{
					var to = (Mobile)obj;

					if (!m_Bola.IsChildOf(from.Backpack))
					{
						from.SendLocalizedMessage(1040019); // The bola must be in your pack to use it.
					}
					else if (!HasFreeHands(from))
					{
						from.SendLocalizedMessage(1040015); // Your hands must be free to use this
					}
					else if (from.Mounted)
					{
						from.SendLocalizedMessage(1040016); // You cannot use this while riding a mount
					}
					else if (Server.Spells.Ninjitsu.AnimalFormSpell.UnderTransformation(from))
					{
						from.SendLocalizedMessage(1070902); // You can't use this while in an animal form!
					}
					else if (!to.Mounted && !Server.Spells.Ninjitsu.AnimalFormSpell.UnderTransformation(to))
					{
						from.SendLocalizedMessage(1049628); // You have no reason to throw a bola at that.
					}
					else if (!from.CanBeHarmful(to))
					{
					}
					else if (from.BeginAction(typeof(Bola)))
					{
						EtherealMount.StopMounting(from);

						from.DoHarmful(to);

						m_Bola.Consume();

						from.Direction = from.GetDirectionTo(to);
						from.Animate(11, 5, 1, true, false, 0);
						from.MovingEffect(to, 0x26AC, 10, 0, false, false);

						Timer.DelayCall(TimeSpan.FromSeconds(0.5), FinishThrow, new object[] { from, to });
					}
					else
					{
						from.SendLocalizedMessage(1049624); // You have to wait a few moments before you can use another bola!
					}
				}
				else
				{
					from.SendLocalizedMessage(1049629); // You cannot throw a bola at that.
				}
			}
		}

		public Bola(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	/// EggBomb: Is A SmokeBomb
	public class EggBomb : Item
	{
		public override int LabelNumber => 1030249;

		[Constructable]
		public EggBomb() : base(0x2808)
		{
			// Item ID should be 0x2809 - Temporary solution for clients 7.0.0.0 and up
			Stackable = Core.ML;
			Weight = 1.0;
		}

		public EggBomb(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!IsChildOf(from.Backpack))
			{
				// The item must be in your backpack to use it.
				from.SendLocalizedMessage(1060640);
			}
			else if (from.Skills.Ninjitsu.Value < 50.0)
			{
				// You need at least ~1_SKILL_REQUIREMENT~ ~2_SKILL_NAME~ skill to use that ability.
				from.SendLocalizedMessage(1063013, "50\tNinjitsu");
			}
			else if (Core.TickCount - from.NextSkillTime < 0)
			{
				// You must wait a few seconds before you can use that item.
				from.SendLocalizedMessage(1070772);
			}
			else if (from.Mana < 10)
			{
				// You don't have enough mana to do that.
				from.SendLocalizedMessage(1049456);
			}
			else
			{
				SkillHandlers.Hiding.CombatOverride = true;

				if (from.UseSkill(SkillName.Hiding))
				{
					from.Mana -= 10;

					from.FixedParticles(0x3709, 1, 30, 9904, 1108, 6, EffectLayer.RightFoot);
					from.PlaySound(0x22F);

					Consume();
				}

				SkillHandlers.Hiding.CombatOverride = false;
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (ItemID == 0x2809) // Temporary solution for clients 7.0.0.0 and up
			{
				ItemID = 0x2808;
			}
		}
	}

	/// Firebomb
	public class Firebomb : Item
	{
		private Timer m_Timer;
		private int m_Ticks = 0;
		private Mobile m_LitBy;
		private List<Mobile> m_Users;

		[Constructable]
		public Firebomb() : this(0x99B)
		{
		}

		[Constructable]
		public Firebomb(int itemID) : base(itemID)
		{
			//Name = "a firebomb";
			Weight = 2.0;
			Hue = 1260;
		}

		public Firebomb(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
				return;
			}

			if (Core.AOS && (from.Paralyzed || from.Frozen || (from.Spell != null && from.Spell.IsCasting)))
			{
				// to prevent exploiting for pvp
				from.SendLocalizedMessage(1075857); // You cannot use that while paralyzed.
				return;
			}

			if (m_Timer == null)
			{
				m_Timer = Timer.DelayCall(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1), OnFirebombTimerTick);
				m_LitBy = from;
				from.SendLocalizedMessage(1060582); // You light the firebomb.  Throw it now!
			}
			else
			{
				from.SendLocalizedMessage(1060581); // You've already lit it!  Better throw it now!
			}

			if (m_Users == null)
			{
				m_Users = new List<Mobile>();
			}

			if (!m_Users.Contains(from))
			{
				m_Users.Add(from);
			}

			from.Target = new ThrowTarget(this);
		}

		private void OnFirebombTimerTick()
		{
			if (Deleted)
			{
				m_Timer.Stop();
				return;
			}

			if (Map == Map.Internal && HeldBy == null)
			{
				return;
			}

			switch (m_Ticks)
			{
				case 0:
				case 1:
				case 2:
					{
						++m_Ticks;

						if (HeldBy != null)
						{
							HeldBy.PublicOverheadMessage(MessageType.Regular, 957, false, m_Ticks.ToString());
						}
						else if (RootParent == null)
						{
							PublicOverheadMessage(MessageType.Regular, 957, false, m_Ticks.ToString());
						}
						else if (RootParent is Mobile)
						{
							((Mobile)RootParent).PublicOverheadMessage(MessageType.Regular, 957, false, m_Ticks.ToString());
						}

						break;
					}
				default:
					{
						if (HeldBy != null)
						{
							HeldBy.DropHolding();
						}

						if (m_Users != null)
						{
							foreach (var m in m_Users)
							{
								var targ = m.Target as ThrowTarget;

								if (targ != null && targ.Bomb == this)
								{
									Target.Cancel(m);
								}
							}

							m_Users.Clear();
							m_Users = null;
						}

						if (RootParent is Mobile)
						{
							var parent = (Mobile)RootParent;
							parent.SendLocalizedMessage(1060583); // The firebomb explodes in your hand!
							AOS.Damage(parent, Utility.Random(3) + 4, 0, 100, 0, 0, 0);
						}
						else if (RootParent == null)
						{
							var toDamage = new List<Mobile>();
							IPooledEnumerable eable = Map.GetMobilesInRange(Location, 1);

							foreach (Mobile m in eable)
							{
								toDamage.Add(m);
							}
							eable.Free();

							Mobile victim;
							for (var i = 0; i < toDamage.Count; ++i)
							{
								victim = toDamage[i];

								if (m_LitBy == null || (SpellHelper.ValidIndirectTarget(m_LitBy, victim) && m_LitBy.CanBeHarmful(victim, false)))
								{
									if (m_LitBy != null)
									{
										m_LitBy.DoHarmful(victim);
									}

									AOS.Damage(victim, m_LitBy, Utility.Random(3) + 4, 0, 100, 0, 0, 0);
								}
							}
							(new FirebombField(m_LitBy, toDamage)).MoveToWorld(Location, Map);
						}

						m_Timer.Stop();
						Delete();
						break;
					}
			}
		}

		private void OnFirebombTarget(Mobile from, object obj)
		{
			if (Deleted || Map == Map.Internal || !IsChildOf(from.Backpack))
			{
				return;
			}

			var p = obj as IPoint3D;

			if (p == null)
			{
				return;
			}

			SpellHelper.GetSurfaceTop(ref p);

			from.RevealingAction();

			IEntity to;

			if (p is Mobile)
			{
				to = (Mobile)p;
			}
			else
			{
				to = new Entity(Serial.Zero, new Point3D(p), Map);
			}

			Effects.SendMovingEffect(from, to, ItemID, 7, 0, false, false, Hue, 0);

			Timer.DelayCall(TimeSpan.FromSeconds(1.0), FirebombReposition_OnTick, new object[] { p, Map });
			Internalize();
		}

		private void FirebombReposition_OnTick(object state)
		{
			if (Deleted)
			{
				return;
			}

			var states = (object[])state;
			var p = (IPoint3D)states[0];
			var map = (Map)states[1];

			MoveToWorld(new Point3D(p), map);
		}

		private class ThrowTarget : Target
		{
			private readonly Firebomb m_Bomb;

			public Firebomb Bomb => m_Bomb;

			public ThrowTarget(Firebomb bomb)
				: base(12, true, TargetFlags.None)
			{
				m_Bomb = bomb;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				m_Bomb.OnFirebombTarget(from, targeted);
			}
		}
	}

	public class FirebombField : Item
	{
		private readonly List<Mobile> m_Burning;
		private readonly Timer m_Timer;
		private readonly Mobile m_LitBy;
		private readonly DateTime m_Expire;

		public FirebombField(Mobile litBy, List<Mobile> toDamage) : base(0x376A)
		{
			Movable = false;
			m_LitBy = litBy;
			m_Expire = DateTime.UtcNow + TimeSpan.FromSeconds(10);
			m_Burning = toDamage;
			m_Timer = Timer.DelayCall(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0), OnFirebombFieldTimerTick);
		}

		public FirebombField(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			// Don't serialize these...
		}

		public override void Deserialize(GenericReader reader)
		{
		}

		public override bool OnMoveOver(Mobile m)
		{
			if (ItemID == 0x398C && m_LitBy == null || (SpellHelper.ValidIndirectTarget(m_LitBy, m) && m_LitBy.CanBeHarmful(m, false)))
			{
				if (m_LitBy != null)
				{
					m_LitBy.DoHarmful(m);
				}

				AOS.Damage(m, m_LitBy, 2, 0, 100, 0, 0, 0);
				m.PlaySound(0x208);

				if (!m_Burning.Contains(m))
				{
					m_Burning.Add(m);
				}
			}

			return true;
		}

		private void OnFirebombFieldTimerTick()
		{
			if (Deleted)
			{
				m_Timer.Stop();
				return;
			}

			if (ItemID == 0x376A)
			{
				ItemID = 0x398C;
				return;
			}

			Mobile victim;
			for (var i = 0; i < m_Burning.Count;)
			{
				victim = m_Burning[i];

				if (victim.Location == Location && victim.Map == Map && (m_LitBy == null || (SpellHelper.ValidIndirectTarget(m_LitBy, victim) && m_LitBy.CanBeHarmful(victim, false))))
				{
					if (m_LitBy != null)
					{
						m_LitBy.DoHarmful(victim);
					}

					AOS.Damage(victim, m_LitBy, Utility.Random(3) + 4, 0, 100, 0, 0, 0);
					++i;
				}
				else
				{
					m_Burning.RemoveAt(i);
				}
			}

			if (DateTime.UtcNow >= m_Expire)
			{
				m_Timer.Stop();
				Delete();
			}
		}
	}

	/// MolotovCocktail
	public class MolotovCocktail : GreaterExplosionPotion
	{
		// ToDo: Make This Item Throwable
		[Constructable]
		public MolotovCocktail()
		{
			Stackable = false;
			ItemID = 0x99B;
			Hue = Utility.RandomList(0xB, 0xF, 0x48D); // TODO update
		}

		public MolotovCocktail(Serial serial) : base(serial)
		{
		}

		public override void Drink(Mobile from)
		{
			if (ValorSpawner.CheckML(from))
			{
				base.Drink(from);
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add(1074502); // It looks explosive.
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	/// SmokeBomb: Is A EggBomb
	public class SmokeBomb : Item
	{
		[Constructable]
		public SmokeBomb() : base(0x2808)
		{
			Stackable = Core.ML;
			Weight = 1.0;
		}

		public SmokeBomb(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!IsChildOf(from.Backpack))
			{
				// The item must be in your backpack to use it.
				from.SendLocalizedMessage(1060640);
			}
			else if (from.Skills.Ninjitsu.Value < 50.0)
			{
				// You need at least ~1_SKILL_REQUIREMENT~ ~2_SKILL_NAME~ skill to use that ability.
				from.SendLocalizedMessage(1063013, "50\tNinjitsu");
			}
			else if (Core.TickCount - from.NextSkillTime < 0)
			{
				// You must wait a few seconds before you can use that item.
				from.SendLocalizedMessage(1070772);
			}
			else if (from.Mana < 10)
			{
				// You don't have enough mana to do that.
				from.SendLocalizedMessage(1049456);
			}
			else
			{
				SkillHandlers.Hiding.CombatOverride = true;

				if (from.UseSkill(SkillName.Hiding))
				{
					from.Mana -= 10;

					from.FixedParticles(0x3709, 1, 30, 9904, 1108, 6, EffectLayer.RightFoot);
					from.PlaySound(0x22F);

					Consume();
				}

				SkillHandlers.Hiding.CombatOverride = false;
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}