using Server.Network;

namespace Server.Spells.Bushido
{
	public abstract class BushidoSpell : Spell
	{
		public new BushidoSpellName ID => (BushidoSpellName)base.ID;

		public override SkillName CastSkill => SkillName.Bushido;
		public override SkillName DamageSkill => SkillName.Bushido;

		public override bool ClearHandsOnCast => false;
		public override bool BlocksMovement => false;
		public override bool ShowHandMovement => false;

		public override double CastDelayFastScalar => 0;

		public override int CastRecoveryBase => 7;

		public BushidoSpell(Mobile caster, Item scroll, BushidoSpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public BushidoSpell(Mobile caster, Item scroll, SpellInfo info) 
			: base(caster, scroll, info)
		{
		}

		public override void SendSkillRequirementMessage(double value, SkillName skill)
		{
			Caster.SendMessage($"You need {value:F1} {Caster.Skills[skill].Name} to perform that attack!");
		}

		public override void GetCastSkills(ref double req, out double min, out double max)
		{
			min = req - 12.5; //per 5 on friday, 2/16/07
			max = req + 37.5;
		}

		public virtual void OnCastSuccessful(Mobile caster)
		{
			if (EvasionSpell.IsEvading(caster))
			{
				EvasionSpell.EndEvasion(caster);
			}

			if (ConfidenceSpell.IsConfident(caster))
			{
				ConfidenceSpell.EndConfidence(caster);
			}

			if (CounterAttackSpell.IsCountering(caster))
			{
				CounterAttackSpell.StopCountering(caster);
			}

			OnEffectStart(Caster, ID);
		}

		public static void OnEffectStart(Mobile caster, BushidoSpellName id)
		{
			var spellID = (int)id;

			if (spellID >= 0)
			{
				caster.Send(new ToggleSpecialAbility(spellID + 1, false));
			}
		}

		public static void OnEffectEnd(Mobile caster, BushidoSpellName id)
		{
			var spellID = (int)id;

			if (spellID >= 0)
			{
				caster.Send(new ToggleSpecialAbility(spellID + 1, false));
			}
		}
	}
}