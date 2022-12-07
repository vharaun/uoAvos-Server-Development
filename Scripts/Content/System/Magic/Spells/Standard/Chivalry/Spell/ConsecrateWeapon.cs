using Server.Items;

using System;
using System.Collections;

namespace Server.Spells.Chivalry
{
	public class ConsecrateWeaponSpell : ChivalrySpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(0.5);

		public override bool BlocksMovement => false;

		public ConsecrateWeaponSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, ChivalrySpellName.ConsecrateWeapon)
		{
		}

		public override void OnCast()
		{
			var weapon = Caster.Weapon as BaseWeapon;

			if (weapon == null || weapon is Fists)
			{
				Caster.SendLocalizedMessage(501078); // You must be holding a weapon.
			}
			else if (CheckSequence())
			{
				/* Temporarily enchants the weapon the caster is currently wielding.
				 * The type of damage the weapon inflicts when hitting a target will
				 * be converted to the target's worst Resistance type.
				 * Duration of the effect is affected by the caster's Karma and lasts for 3 to 11 seconds.
				 */

				int itemID, soundID;

				switch (weapon.Skill)
				{
					case SkillName.Macing: itemID = 0xFB4; soundID = 0x232; break;
					case SkillName.Archery: itemID = 0x13B1; soundID = 0x145; break;
					default: itemID = 0xF5F; soundID = 0x56; break;
				}

				Caster.PlaySound(0x20C);
				Caster.PlaySound(soundID);
				Caster.FixedParticles(0x3779, 1, 30, 9964, 3, 3, EffectLayer.Waist);

				IEntity from = new Entity(Serial.Zero, new Point3D(Caster.X, Caster.Y, Caster.Z), Caster.Map);
				IEntity to = new Entity(Serial.Zero, new Point3D(Caster.X, Caster.Y, Caster.Z + 50), Caster.Map);
				Effects.SendMovingParticles(from, to, itemID, 1, 0, false, false, 33, 3, 9501, 1, 0, EffectLayer.Head, 0x100);

				double seconds = ComputePowerValue(20);

				// TODO: Should caps be applied?
				if (seconds < 3.0)
				{
					seconds = 3.0;
				}
				else if (seconds > 11.0)
				{
					seconds = 11.0;
				}

				var duration = TimeSpan.FromSeconds(seconds);

				var t = (Timer)m_Table[weapon];

				if (t != null)
				{
					t.Stop();
				}

				weapon.Consecrated = true;

				m_Table[weapon] = t = new ExpireTimer(weapon, duration);

				t.Start();
			}

			FinishSequence();
		}

		private static readonly Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private readonly BaseWeapon m_Weapon;

			public ExpireTimer(BaseWeapon weapon, TimeSpan delay) : base(delay)
			{
				m_Weapon = weapon;
				Priority = TimerPriority.FiftyMS;
			}

			protected override void OnTick()
			{
				m_Weapon.Consecrated = false;
				Effects.PlaySound(m_Weapon.GetWorldLocation(), m_Weapon.Map, 0x1F8);
				m_Table.Remove(this);
			}
		}
	}
}