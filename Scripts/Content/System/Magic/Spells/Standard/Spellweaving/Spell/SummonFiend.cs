using Server.Engines.ChainQuests;
using Server.Mobiles;

using System;

namespace Server.Spells.Spellweaving
{
	public class SummonFiendSpell : SpellweavingSummon<ArcaneFiend>
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		public override int Sound => 0x216;

		public SummonFiendSpell(Mobile caster, Item scroll)
			: base(caster, scroll, SpellweavingSpellName.SummonFiend)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			// This is done after casting completes
			if (Caster is PlayerMobile pm)
			{
				var context = ChainQuestSystem.GetContext(pm);

				if (context == null || !context.SummonFiend)
				{
					pm.SendLocalizedMessage(1074564); // You haven't demonstrated mastery to summon a fiend.
					return false;
				}
			}

			return true;
		}
	}
}