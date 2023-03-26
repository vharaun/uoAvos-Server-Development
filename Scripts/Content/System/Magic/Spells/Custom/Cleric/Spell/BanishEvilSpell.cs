using Server.Items;
using Server.Mobiles;
using Server.Targeting;

using System;

namespace Server.Spells.Cleric
{
	public class BanishEvilSpell : ClericSpell
	{
		public BanishEvilSpell(Mobile caster, Item scroll)
			: base(caster, scroll, ClericSpellName.BanishEvil)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			var undead = SlayerGroup.GetEntryByName(SlayerName.Silver);
			var demon = SlayerGroup.GetEntryByName(SlayerName.DaemonDismissal);

			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (m is PlayerMobile)
			{
				Caster.SendMessage("You cannot banish another player!");
			}
			else if ((undead != null && !undead.Slays(m)) || (demon != null && !demon.Slays(m)))
			{
				Caster.SendMessage("This spell cannot be used on this type of creature.");
			}
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				m.FixedParticles(0x3709, 10, 30, 5052, 0x480, 0, EffectLayer.LeftFoot);
				m.PlaySound(0x208);

				m.Say("No! I musn't be banished!");
				new InternalTimer(m).Start();
			}

			FinishSequence();
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Owner;

			public InternalTimer(Mobile owner)
				: base(TimeSpan.FromSeconds(1.5))
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if (m_Owner != null && m_Owner.CheckAlive())
				{
					m_Owner.Delete();
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly BanishEvilSpell m_Owner;

			public InternalTarget(BanishEvilSpell owner)
				: base(12, false, TargetFlags.Harmful)
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
