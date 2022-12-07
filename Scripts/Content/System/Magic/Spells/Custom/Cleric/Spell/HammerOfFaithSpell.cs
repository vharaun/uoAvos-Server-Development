using Server.Items;

using System;

namespace Server.Spells.Cleric
{
	public class HammerOfFaithSpell : ClericSpell
	{
		public HammerOfFaithSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, ClericSpellName.HammerOfFaith)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var skill = Caster.Skills[SkillName.SpiritSpeak];
				var scalar = DivineFocusSpell.GetScalar(Caster);
				var duration = TimeSpan.FromMinutes(skill.Value / 20.0 * scalar);

				if (Caster.AddToBackpack(new TransientHammerOfFaith(Caster, duration)))
				{
					Caster.SendMessage("You create a magical hammer and place it in your backpack.");
				}
				else
				{
					Caster.SendMessage("You create a magical hammer and drop it at your feet.");
				}

				Caster.PlaySound(0x212);
				Caster.PlaySound(0x206);

				Effects.SendLocationParticles(EffectItem.Create(Caster.Location, Caster.Map, EffectItem.DefaultDuration), 0x376A, 1, 29, 0x47D, 2, 9962, 0);
				Effects.SendLocationParticles(EffectItem.Create(new Point3D(Caster.X, Caster.Y, Caster.Z - 7), Caster.Map, EffectItem.DefaultDuration), 0x37C4, 1, 29, 0x47D, 2, 9502, 0);
			}

			FinishSequence();
		}
	}
}

namespace Server.Items
{
}
