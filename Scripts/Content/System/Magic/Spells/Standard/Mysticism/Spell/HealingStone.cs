using Server.Items;

using System;

namespace Server.Spells.Mysticism
{
	public class HealingStoneSpell : MysticismSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(5);

		public HealingStoneSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.HealingStone)
		{
		}

		public override void OnCast()
		{
			if (Caster.Backpack?.Deleted != false)
			{ 
			}
			else if (CheckSequence())
			{
				var stones = Caster.Backpack.FindItemsByType<HealingStone>();

				foreach (var s in stones)
				{
					s.Delete();
				}

				var factor = Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value;

				var amount = (int)(factor * 1.5);
				var maxHeal = (int)(factor / 5.0);

				Caster.PlaySound(0x650);
				Caster.FixedParticles(0x3779, 1, 15, 0x251E, 0, 0, EffectLayer.Waist);

				Caster.Backpack.DropItem(new HealingStone(Caster, amount, maxHeal));
				Caster.SendLocalizedMessage(1080115); // A Healing Stone appears in your backpack.
			}

			FinishSequence();
		}
	}
}