using Server.Network;

using System;

namespace Server.Spells.Cleric
{
	public abstract class ClericSpell : Spell
	{
		public new ClericSpellName ID => (ClericSpellName)base.ID;

		public override SkillName CastSkill => SkillName.SpiritSpeak;
		public override SkillName DamageSkill => SkillName.Chivalry;

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(10 * CastDelaySecondsPerTick);

		public override bool ClearHandsOnCast => false;
		public override bool BlocksMovement => false;

		public ClericSpell(Mobile caster, Item scroll, ClericSpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public ClericSpell(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (Caster.Karma <= 0)
			{
				Caster.SendMessage("You must have positive karma to invoke this prayer.");
				return false;
			}

			return true;
		}

		public override bool CheckFizzle()
		{
			if (!base.CheckFizzle())
			{
				return false;
			}

			if (Caster.Karma <= 0)
			{
				Caster.SendMessage("You must have positive karma to invoke this prayer.");
				return false;
			}

			return true;
		}

		public override void SendSkillRequirementMessage(double value, SkillName skill)
		{
			Caster.SendMessage($"You must have at least {value:F1} {Caster.Skills[skill].Name} to invoke this prayer.");
		}

		public override void SendManaRequirementMessage(int mana)
		{
			Caster.SendMessage($"You must have at least {mana} Mana to invoke this prayer.");
		}

		public override void SendTitheRequirementMessage(int tithe)
		{
			Caster.SendMessage($"You must have at least {tithe} Tithing Points to invoke this prayer.");
		}

		public override void SendReagentRequirementMessage()
		{
			Caster.LocalOverheadMessage(MessageType.Regular, 0x22, false, "More reagents are needed for this prayer.");
		}

		public override void SayMantra()
		{
			Caster.PublicOverheadMessage(MessageType.Regular, 0x3B2, false, Info.Mantra);
			Caster.PlaySound(0x24A);
		}

		public override void DoFizzle()
		{
			Caster.PlaySound(0x1D6);
			Caster.NextSpellTime = Core.TickCount;
		}

		public override void DoHurtFizzle()
		{
			Caster.PlaySound(0x1D6);
		}

		public override void OnInterrupt(SpellInterrupt type, bool message)
		{
			base.OnInterrupt(type, message);

			if (message)
			{
				Caster.PlaySound(0x1D6);
			}
		}

		public override void OnBeginCast()
		{
			base.OnBeginCast();

			Caster.FixedEffect(0x37C4, 10, 42, 4, 3);
		}

		public override void GetCastSkills(ref double req, out double min, out double max)
		{
			min = req;
			max = req + 40.0;
		}
	}
}
