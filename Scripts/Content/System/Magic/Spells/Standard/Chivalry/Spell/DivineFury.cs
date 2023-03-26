
using System;
using System.Collections;

namespace Server.Spells.Chivalry
{
	public class DivineFurySpell : ChivalrySpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.0);

		public override bool BlocksMovement => false;

		public DivineFurySpell(Mobile caster, Item scroll) 
			: base(caster, scroll, ChivalrySpellName.DivineFury)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Caster.PlaySound(0x20F);
				Caster.PlaySound(Caster.Female ? 0x338 : 0x44A);
				Caster.FixedParticles(0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Waist);
				Caster.FixedParticles(0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist);

				Caster.Stam = Caster.StamMax;

				var t = (Timer)m_Table[Caster];

				if (t != null)
				{
					t.Stop();
				}

				var delay = ComputePowerValue(10);

				// TODO: Should caps be applied?
				if (delay < 7)
				{
					delay = 7;
				}
				else if (delay > 24)
				{
					delay = 24;
				}

				m_Table[Caster] = t = Timer.DelayCall(TimeSpan.FromSeconds(delay), Expire_Callback, Caster);
				Caster.Delta(MobileDelta.WeaponDamage);

				BuffInfo.AddBuff(Caster, new BuffInfo(BuffIcon.DivineFury, 1060589, 1075634, TimeSpan.FromSeconds(delay), Caster));
			}

			FinishSequence();
		}

		private static readonly Hashtable m_Table = new Hashtable();

		public static bool UnderEffect(Mobile m)
		{
			return m_Table.Contains(m);
		}

		private static void Expire_Callback(object state)
		{
			var m = (Mobile)state;

			m_Table.Remove(m);

			m.Delta(MobileDelta.WeaponDamage);
			m.PlaySound(0xF8);
		}
	}
}