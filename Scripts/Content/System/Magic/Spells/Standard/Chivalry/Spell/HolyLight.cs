using Server.Items;

using System;
using System.Collections.Generic;

namespace Server.Spells.Chivalry
{
	public class HolyLightSpell : ChivalrySpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.75);

		public override bool BlocksMovement => false;

		public HolyLightSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, ChivalrySpellName.HolyLight)
		{
		}

		public override bool DelayedDamage => false;

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var targets = new List<Mobile>();

				foreach (var m in Caster.GetMobilesInRange(3))
				{
					if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && (!Core.AOS || Caster.InLOS(m)))
					{
						targets.Add(m);
					}
				}

				Caster.PlaySound(0x212);
				Caster.PlaySound(0x206);

				Effects.SendLocationParticles(EffectItem.Create(Caster.Location, Caster.Map, EffectItem.DefaultDuration), 0x376A, 1, 29, 0x47D, 2, 9962, 0);
				Effects.SendLocationParticles(EffectItem.Create(new Point3D(Caster.X, Caster.Y, Caster.Z - 7), Caster.Map, EffectItem.DefaultDuration), 0x37C4, 1, 29, 0x47D, 2, 9502, 0);

				for (var i = 0; i < targets.Count; ++i)
				{
					var m = targets[i];

					var damage = ComputePowerValue(10) + Utility.RandomMinMax(0, 2);

					// TODO: Should caps be applied?
					if (damage < 8)
					{
						damage = 8;
					}
					else if (damage > 24)
					{
						damage = 24;
					}

					Caster.DoHarmful(m);
					SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
				}
			}

			FinishSequence();
		}
	}
}