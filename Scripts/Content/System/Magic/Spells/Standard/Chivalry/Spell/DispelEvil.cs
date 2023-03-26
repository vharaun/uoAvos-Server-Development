using Server.Items;
using Server.Mobiles;
using Server.Spells.Necromancy;

using System;
using System.Collections.Generic;

namespace Server.Spells.Chivalry
{
	public class DispelEvilSpell : ChivalrySpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(0.25);

		public override bool BlocksMovement => false;

		public DispelEvilSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, ChivalrySpellName.DispelEvil)
		{
		}

		public override bool DelayedDamage => false;

		public override void SendCastEffect()
		{
			Caster.FixedEffect(0x37C4, 10, 7, 4, 3); // At player
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var targets = new List<Mobile>();

				foreach (var m in Caster.GetMobilesInRange(8))
				{
					if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false))
					{
						targets.Add(m);
					}
				}

				Caster.PlaySound(0xF5);
				Caster.PlaySound(0x299);
				Caster.FixedParticles(0x37C4, 1, 25, 9922, 14, 3, EffectLayer.Head);

				var dispelSkill = ComputePowerValue(2);

				var chiv = Caster.Skills.Chivalry.Value;

				for (var i = 0; i < targets.Count; ++i)
				{
					var m = targets[i];
					var bc = m as BaseCreature;

					if (bc != null)
					{
						var dispellable = bc.Summoned && !bc.IsAnimatedDead;

						if (dispellable)
						{
							var dispelChance = (50.0 + ((100 * (chiv - bc.DispelDifficulty)) / (bc.DispelFocus * 2))) / 100;
							dispelChance *= dispelSkill / 100.0;

							if (dispelChance > Utility.RandomDouble())
							{
								Effects.SendLocationParticles(EffectItem.Create(m.Location, m.Map, EffectItem.DefaultDuration), 0x3728, 8, 20, 5042);
								Effects.PlaySound(m, m.Map, 0x201);

								m.Delete();
								continue;
							}
						}

						var evil = !bc.Controlled && bc.Karma < 0;

						if (evil)
						{
							// TODO: Is this right?
							var fleeChance = (100 - Math.Sqrt(m.Fame / 2)) * chiv * dispelSkill;
							fleeChance /= 1000000;

							if (fleeChance > Utility.RandomDouble())
							{
								// guide says 2 seconds, it's longer
								bc.BeginFlee(TimeSpan.FromSeconds(30.0));
							}
						}
					}

					var context = TransformationSpellHelper.GetContext(m);
					if (context != null && context.Spell is NecromancySpell)   //Trees are not evil!	TODO: OSI confirm?
					{
						// transformed ..

						var drainChance = 0.5 * (Caster.Skills.Chivalry.Value / Math.Max(m.Skills.Necromancy.Value, 1));

						if (drainChance > Utility.RandomDouble())
						{
							var drain = (5 * dispelSkill) / 100;

							m.Stam -= drain;
							m.Mana -= drain;
						}
					}
				}
			}

			FinishSequence();
		}
	}
}