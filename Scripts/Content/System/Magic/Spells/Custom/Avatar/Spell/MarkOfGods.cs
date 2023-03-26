using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Avatar
{
	public class MarkOfGodsSpell : AvatarSpell
	{
		public MarkOfGodsSpell(Mobile caster, Item scroll)
			: base(caster, scroll, AvatarSpellName.MarkOfGods)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			return SpellHelper.CheckTravel(Caster, TravelCheckType.Mark);
		}

		public void Target(RecallRune rune)
		{
			if (!Caster.CanSee(rune))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (!SpellHelper.CheckTravel(Caster, TravelCheckType.Mark))
			{
			}
			else if (SpellHelper.CheckMulti(Caster.Location, Caster.Map, !Core.AOS))
			{
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			}
			else if (!rune.IsChildOf(Caster.Backpack))
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1062422); // You must have this rune in your backpack in order to mark it.
			}
			else if (CheckSequence())
			{
				rune.Mark(Caster);
				Caster.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
				Caster.PlaySound(0x1FA);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly MarkOfGodsSpell m_Owner;

			public InternalTarget(MarkOfGodsSpell owner) 
				: base(12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is RecallRune rune)
				{
					m_Owner.Target(rune);
				}
				else
				{
					from.SendLocalizedMessage(501797); // I cannot mark that object.
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
