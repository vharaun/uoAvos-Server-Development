using Server.Engines.PartySystem;
using Server.Items;
using Server.Spells.Magery;
using Server.Spells.Necromancy;
using Server.Targeting;

using System.Collections.Generic;
using System.Linq;

namespace Server.Spells.Mysticism
{
	public class CleansingWindsSpell : MysticismSpell
	{
		public CleansingWindsSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.CleansingWinds)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void OnTarget(Mobile targeted)
		{
			if (!Caster.CanSee(targeted))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckBSequence(targeted))
			{
				/* Soothing winds attempt to neutralize poisons, lift curses, and heal a valid
                 * Target. The Caster's Mysticism and either Focus or Imbuing (whichever is
                 * greater) skills determine the effectiveness of the Cleansing Winds.
                 */

				Caster.PlaySound(0x64C);

				var targets = new List<Mobile>
				{
					targeted
				};

				targets.AddRange(FindAdditionalTargets(targeted).Take(3)); // This effect can hit up to 3 additional players beyond the primary target.

				var primarySkill = Caster.Skills[CastSkill].Value;
				var secondarySkill = Caster.Skills[DamageSkill].Value;

				var toHeal = (int)((primarySkill + secondarySkill) / 4.0) + Utility.RandomMinMax(-3, 3);

				toHeal /= targets.Count; // The effectiveness of the spell is reduced by the number of targets affected.

				foreach (var target in targets)
				{
					// WARNING: This spell will flag the caster as a criminal if a criminal or murderer party member is close enough
					// to the target to receive the benefits from the area of effect.
					Caster.DoBeneficial(target);

					PlayEffect(target);

					var toHealMod = toHeal;

					if (target.Poisoned)
					{
						var poisonLevel = target.Poison.Level + 1;
						var chanceToCure = (10000 + (int)((primarySkill + secondarySkill) / 2.0 * 75.0) - (poisonLevel * 1750)) / 100;

						if (chanceToCure > Utility.Random(100) && target.CurePoison(Caster))
						{
							// Poison reduces healing factor by 15% per level of poison.
							toHealMod -= (int)(toHeal * poisonLevel * 0.15);
						}
						else
						{
							// If the cure fails, the target will not be healed.
							toHealMod = 0;
						}
					}

					// Cleansing Winds will not heal the target after removing mortal wound.
					if (MortalStrike.IsWounded(target))
					{
						toHealMod = 0;
					}

					var curseLevel = RemoveCurses(target);

					if (toHealMod > 0 && curseLevel > 0)
					{
						// Each Curse reduces healing by 3 points + 1% per curse level.
						toHealMod -= curseLevel * 3;
						toHealMod -= (int)(toHealMod * (curseLevel / 100.0));
					}

					if (toHealMod > 0)
					{
						SpellHelper.Heal(toHealMod, target, Caster);
					}
				}
			}

			FinishSequence();
		}

		private IEnumerable<Mobile> FindAdditionalTargets(Mobile targeted)
		{
			var casterParty = Party.Get(Caster);

			if (casterParty == null)
			{
				yield break;
			}

			var eable = Caster.Map.GetMobilesInRange(new Point3D(targeted), 2);

			foreach (var m in eable)
			{
				if (m == null || m == targeted)
				{
					continue;
				}

				// Players in the area must be in the casters party in order to receive the beneficial effects of the spell.
				if (Caster.CanBeBeneficial(m, false) && casterParty.Contains(m))
				{
					yield return m;
				}
			}

			eable.Free();
		}

		private static void PlayEffect(Mobile m)
		{
			m.FixedParticles(0x3709, 1, 30, 9963, 13, 3, EffectLayer.Head);

			var from = new Entity(Serial.Zero, new Point3D(m.X, m.Y, m.Z - 10), m.Map);
			var to = new Entity(Serial.Zero, new Point3D(m.X, m.Y, m.Z + 50), m.Map);

			Effects.SendMovingParticles(from, to, 0x2255, 1, 0, false, false, 13, 3, 9501, 1, 0, EffectLayer.Head, 0x100);
		}

		public static int RemoveCurses(Mobile m)
		{
			var curseLevel = 0;

			if (SleepSpell.IsUnderSleepEffects(m))
			{
				SleepSpell.EndSleep(m);
				curseLevel += 2;
			}

			if (EvilOmenSpell.TryEndEffect(m))
			{
				curseLevel += 1;
			}

			if (StrangleSpell.RemoveCurse(m))
			{
				curseLevel += 2;
			}

			if (CorpseSkinSpell.RemoveCurse(m))
			{
				curseLevel += 3;
			}

			if (CurseSpell.UnderEffect(m))
			{
				CurseSpell.RemoveEffect(m);
				curseLevel += 4;
			}

			if (BloodOathSpell.RemoveCurse(m))
			{
				curseLevel += 3;
			}

			if (MindRotSpell.HasMindRotScalar(m))
			{
				MindRotSpell.ClearMindRotScalar(m);
				curseLevel += 2;
			}

			if (SpellPlagueSpell.UnderEffect(m))
			{
				SpellPlagueSpell.RemoveEffect(m);
				curseLevel += 4;
			}

			if (FeeblemindSpell.UnderEffect(m))
			{
				FeeblemindSpell.RemoveEffect(m);
				curseLevel += 1;
			}

			if (ClumsySpell.UnderEffect(m))
			{
				ClumsySpell.RemoveEffect(m);
				curseLevel += 1;
			}

			if (WeakenSpell.UnderEffect(m))
			{
				WeakenSpell.RemoveEffect(m);
				curseLevel += 1;
			}

			if (MortalStrike.IsWounded(m))
			{
				MortalStrike.EndWound(m);
				curseLevel += 2;
			}

			BuffInfo.RemoveBuff(m, BuffIcon.Clumsy);
			BuffInfo.RemoveBuff(m, BuffIcon.FeebleMind);
			BuffInfo.RemoveBuff(m, BuffIcon.Weaken);
			BuffInfo.RemoveBuff(m, BuffIcon.Curse);
			BuffInfo.RemoveBuff(m, BuffIcon.MassCurse);
			BuffInfo.RemoveBuff(m, BuffIcon.MortalStrike);
			BuffInfo.RemoveBuff(m, BuffIcon.Mindrot);
			BuffInfo.RemoveBuff(m, BuffIcon.CorpseSkin);
			BuffInfo.RemoveBuff(m, BuffIcon.Strangle);
			BuffInfo.RemoveBuff(m, BuffIcon.EvilOmen);

			return curseLevel;
		}

		public class InternalTarget : Target
		{
			public CleansingWindsSpell Owner { get; set; }

			public InternalTarget(CleansingWindsSpell owner)
				: this(owner, false)
			{
			}

			public InternalTarget(CleansingWindsSpell owner, bool allowland)
				: base(12, allowland, TargetFlags.Beneficial)
			{
				Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile m)
				{
					Owner.OnTarget(m);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				Owner.FinishSequence();
			}
		}
	}
}
