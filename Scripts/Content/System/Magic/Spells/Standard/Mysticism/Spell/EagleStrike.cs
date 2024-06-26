﻿using Server.Targeting;

using System;

namespace Server.Spells.Mysticism
{
	public class EagleStrikeSpell : MysticismSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.25);

		public EagleStrikeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.EagleStrike)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (CheckHSequence(m))
			{
				/* Conjures a magical eagle that assaults the Target with
				 * its talons, dealing energy damage.
				 */

				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect(2, Caster, ref m);

				Caster.MovingParticles(m, 0x407A, 7, 0, false, true, 0, 0, 0xBBE, 0xFA6, 0xFFFF, 0);
				Caster.PlaySound(0x2EE);

				Timer.DelayCall(TimeSpan.FromSeconds(1.0), Damage, m);
			}

			FinishSequence();
		}

		private void Damage(Mobile to)
		{
			if (to == null)
			{
				return;
			}

			double damage = GetNewAosDamage(19, 1, 5, to);

			SpellHelper.Damage(this, to, damage, 0, 0, 0, 0, 100);

			to.PlaySound(0x64D);
		}

		private class InternalTarget : Target
		{
			private readonly EagleStrikeSpell m_Owner;

			public InternalTarget(EagleStrikeSpell owner)
				: base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile m)
				{
					m_Owner.Target(m);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}