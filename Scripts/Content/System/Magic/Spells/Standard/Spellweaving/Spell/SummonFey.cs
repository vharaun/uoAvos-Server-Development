using Server.Engines.ChainQuests;
using Server.Mobiles;

using System;

namespace Server.Spells.Spellweaving
{
	public class SummonFeySpell : SpellweavingSummon<ArcaneFey>
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.5);

		public override int Sound => 0x217;

		public SummonFeySpell(Mobile caster, Item scroll)
			: base(caster, scroll, SpellweavingSpellName.SummonFey)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (Caster is PlayerMobile pm)
			{
				var context = ChainQuestSystem.GetContext(pm);

				if (context == null || !context.SummonFey)
				{
					pm.SendLocalizedMessage(1074563); // You haven't forged a friendship with the fey and are unable to summon their aid.
					return false;
				}
			}

			return true;
		}
	}
}