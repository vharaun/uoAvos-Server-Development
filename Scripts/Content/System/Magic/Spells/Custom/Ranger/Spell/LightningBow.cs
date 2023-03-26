using Server.Items;

using System;

namespace Server.Spells.Ranger
{
	public class LightningBowSpell : RangerSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(7.0);

		public LightningBowSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, RangerSpellName.LightningBow)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var skill = Caster.Skills[SkillName.Archery];
				var scalar = HuntersAimSpell.GetScalar(Caster);
				var duration = TimeSpan.FromMinutes(skill.Value / 20.0 * scalar);

				var weap = new TransientLightningBow(Caster, duration);

				if (Caster.AddToBackpack(weap))
				{
					Caster.SendMessage("You create a magical bow and place it in your backpack.");
				}
				else
				{
					Caster.SendMessage("You create a magical bow and place it at your feet.");
				}


				Caster.PlaySound(518);

				Effects.SendLocationParticles(EffectItem.Create(Caster.Location, Caster.Map, EffectItem.DefaultDuration), 0x376A, 1, 29, 1278, 2, 9962, 0);
				Effects.SendLocationParticles(EffectItem.Create(new Point3D(Caster.X, Caster.Y, Caster.Z - 7), Caster.Map, EffectItem.DefaultDuration), 0x37C4, 1, 29, 1278, 2, 9502, 0);
			}

			FinishSequence();
		}
	}
}
