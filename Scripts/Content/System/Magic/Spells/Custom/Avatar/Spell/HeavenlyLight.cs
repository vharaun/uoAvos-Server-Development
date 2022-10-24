using Server.Targeting;

using System;

namespace Server.Spells.Avatar
{
	public class DivineLightSpell : AvatarSpell
	{
		public DivineLightSpell(Mobile caster, Item scroll)
			: base(caster, scroll, AvatarSpellName.DivineLight)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		private class InternalTarget : Target
		{
			private readonly DivineLightSpell m_Spell;

			public InternalTarget(DivineLightSpell spell)
				: base(10, false, TargetFlags.None)
			{
				m_Spell = spell;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (m_Spell.CheckSequence() && targeted is Mobile targ)
				{
					SpellHelper.Turn(m_Spell.Caster, targ);

					if (targ.BeginAction(typeof(LightCycle)))
					{
						var t = new LightCycle.NightSightTimer(targ);

						t.Start();

						var level = (int)Math.Abs(LightCycle.DungeonLevel * (m_Spell.Caster.Skills[SkillName.Necromancy].Base / 100));

						if (level is > 25 or < 0)
						{
							level = 25;
						}

						targ.LightLevel = level;
					}

					targ.FixedParticles(0x376A, 9, 32, 5007, EffectLayer.Waist);
					targ.PlaySound(0x1E3);
				}

				m_Spell.FinishSequence();
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Spell.FinishSequence();
			}
		}
	}
}
