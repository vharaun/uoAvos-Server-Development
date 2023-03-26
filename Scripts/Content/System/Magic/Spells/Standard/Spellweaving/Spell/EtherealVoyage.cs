using System;

namespace Server.Spells.Spellweaving
{
	public class EtherealVoyageSpell : SpellweavingTransformation
	{
		public static void Initialize()
		{
			EventSink.AggressiveAction += new AggressiveActionEventHandler(delegate (AggressiveActionEventArgs e)
			{
				if (TransformationSpellHelper.UnderTransformation(e.Aggressor, typeof(EtherealVoyageSpell)))
				{
					TransformationSpellHelper.RemoveContext(e.Aggressor, true);
				}
			});
		}

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(3.5);

		public override Body Body => 0x302;
		public override int Hue => 0x48F;

		public EtherealVoyageSpell(Mobile caster, Item scroll)
			: base(caster, scroll, SpellweavingSpellName.EtherealVoyage)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (TransformationSpellHelper.UnderTransformation(Caster, typeof(EtherealVoyageSpell)))
			{
				Caster.SendLocalizedMessage(501775); // This spell is already in effect.
				return false;
			}
			
			if (!Caster.CanBeginAction(typeof(EtherealVoyageSpell)))
			{
				Caster.SendLocalizedMessage(1075124); // You must wait before casting that spell again.
				return false;
			}
			
			if (Caster.Combatant != null)
			{
				Caster.SendLocalizedMessage(1072586); // You cannot cast Ethereal Voyage while you are in combat.
				return false;
			}

			return true;
		}

		public override void DoEffect(Mobile m)
		{
			m.PlaySound(0x5C8);
			m.SendLocalizedMessage(1074770); // You are now under the effects of Ethereal Voyage.

			var skill = Caster.Skills.Spellweaving.Value;

			var duration = TimeSpan.FromSeconds(12.0 + (skill / 24.0) + (FocusLevel * 2.0));

			Timer.DelayCall(duration, RemoveEffect, Caster);

			Caster.BeginAction(typeof(EtherealVoyageSpell)); // Cannot cast this spell for another 5 minutes(300sec) after effect removed.

			BuffInfo.AddBuff(Caster, new BuffInfo(BuffIcon.EtherealVoyage, 1031613, 1075805, duration, Caster));
		}

		public override void RemoveEffect(Mobile m)
		{
			m.SendLocalizedMessage(1074771); // You are no longer under the effects of Ethereal Voyage.

			TransformationSpellHelper.RemoveContext(m, true);

			Timer.DelayCall(TimeSpan.FromMinutes(5.0), m.EndAction, typeof(EtherealVoyageSpell));

			BuffInfo.RemoveBuff(m, BuffIcon.EtherealVoyage);
		}
	}
}