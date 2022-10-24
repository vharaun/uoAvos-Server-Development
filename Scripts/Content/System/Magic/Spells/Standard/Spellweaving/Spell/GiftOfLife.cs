using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Spells.Spellweaving
{
	public class GiftOfLifeSpell : SpellweavingSpell
	{
		private static readonly Dictionary<Mobile, (Timer, double)> m_Table = new();

		public static void Initialize()
		{
			EventSink.PlayerDeath += e => HandleDeath(e.Mobile);
			EventSink.CreatureDeath += e => HandleDeath(e.Mobile);
		}

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(4.0);

		public GiftOfLifeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, SpellweavingSpellName.GiftOfLife)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			var bc = m as BaseCreature;

			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (m.IsDeadBondedPet || !m.Alive)
			{
				// As per Osi: Nothing happens.
			}
			else if (m != Caster && (bc == null || !bc.IsBonded || bc.ControlMaster != Caster))
			{
				Caster.SendLocalizedMessage(1072077); // You may only cast this spell on yourself or a bonded pet.
			}
			else if (HasEffect(m))
			{
				Caster.SendLocalizedMessage(501775); // This spell is already in effect.
			}
			else if (CheckBSequence(m))
			{
				if (Caster == m)
				{
					Caster.SendLocalizedMessage(1074774); // You weave powerful magic, protecting yourself from death.
				}
				else
				{
					Caster.SendLocalizedMessage(1074775); // You weave powerful magic, protecting your pet from death.
					
					SpellHelper.Turn(Caster, m);
				}

				StopEffect(m, false);

				m.PlaySound(0x244);
				m.FixedParticles(0x3709, 1, 30, 0x26ED, 5, 2, EffectLayer.Waist);
				m.FixedParticles(0x376A, 1, 30, 0x251E, 5, 3, EffectLayer.Waist);

				var skill = Caster.Skills.Spellweaving.Value;

				var duration = TimeSpan.FromMinutes(skill / 24.0 * FocusLevel + 2.0);
				var scalar = ((skill / 2.4) + FocusLevel) / 100.0;

				m_Table[m] = (Timer.DelayCall(duration, StopEffect, m, true), scalar);

				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.GiftOfLife, 1031615, 1075807, duration, m, null, true));
			}

			FinishSequence();
		}

		private static void HandleDeath(Mobile m)
		{
			if (m_Table.ContainsKey(m))
			{
				Timer.DelayCall(TimeSpan.FromSeconds(Utility.RandomMinMax(2, 4)), HandleDeathCallback, m);
			}
		}

		private static void HandleDeathCallback(Mobile m)
		{
			(Timer Timer, double Scalar) state;

			if (m_Table.TryGetValue(m, out state))
			{
				if (m is not BaseCreature pet)
				{
					m.CloseGump(typeof(ResurrectGump));
					m.SendGump(new ResurrectGump(m, state.Scalar));
				}
				else if (m.IsDeadBondedPet)
				{
					var master = pet.GetMaster();

					if (master != null && master.NetState != null && Utility.InUpdateRange(pet, master))
					{
						master.CloseGump(typeof(PetResurrectGump));
						master.SendGump(new PetResurrectGump(master, pet, state.Scalar));
					}
					else
					{
						var friends = pet.Friends;

						for (var i = 0; friends != null && i < friends.Count; i++)
						{
							var friend = friends[i];

							if (friend.NetState != null && Utility.InUpdateRange(pet, friend))
							{
								friend.CloseGump(typeof(PetResurrectGump));
								friend.SendGump(new PetResurrectGump(friend, pet));
								break;
							}
						}
					}
				}

				// Per OSI, buff is removed when gump sent, regardless of online status or acceptence
				StopEffect(m, false);
			}
		}

		public static bool HasEffect(Mobile m)
		{
			return m != null && m_Table.ContainsKey(m);
		}

		public static void StopEffect(Mobile m, bool message)
		{
			(Timer Timer, double Scalar) state;

			if (m_Table.TryGetValue(m, out state))
			{
				state.Timer.Stop();

				m_Table.Remove(m);

				if (message)
				{
					m.SendLocalizedMessage(1074776); // You are no longer protected with Gift of Life.
				}

				BuffInfo.RemoveBuff(m, BuffIcon.GiftOfLife);
			}
		}

		public class InternalTarget : Target
		{
			private readonly GiftOfLifeSpell m_Owner;

			public InternalTarget(GiftOfLifeSpell owner)
				: base(10, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile m)
				{
					m_Owner.Target(m);
				}
				else
				{
					from.SendLocalizedMessage(1072077); // You may only cast this spell on yourself or a bonded pet.
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}