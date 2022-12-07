using Server.Mobiles;
using Server.Spells.Necromancy;

using System;
using System.Collections.Generic;

namespace Server.Spells.Ninjitsu
{
	public class MirrorImageSpell : NinjitsuSpell
	{
		private static readonly Dictionary<Mobile, int> m_CloneCount = new Dictionary<Mobile, int>();

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.5);

		public override bool BlockedByAnimalForm => false;

		public MirrorImageSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, NinjitsuSpellName.MirrorImage)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (Caster.Mounted)
			{
				Caster.SendLocalizedMessage(1063132); // You cannot use this ability while mounted.
				return false;
			}
			
			if ((Caster.Followers + 1) > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1063133); // You cannot summon a mirror image because you have too many followers.
				return false;
			}
			
			if (TransformationSpellHelper.UnderTransformation(Caster, typeof(HorrificBeastSpell)))
			{
				Caster.SendLocalizedMessage(1061091); // You cannot cast that spell in this form.
				return false;
			}

			return true;
		}

		public override bool CheckInterrupt(SpellInterrupt type, bool resistable)
		{
			return false;
		}

		public override void OnBeginCast()
		{
			base.OnBeginCast();

			Caster.SendLocalizedMessage(1063134); // You begin to summon a mirror image of yourself.
		}

		public override void OnCast()
		{
			if (Caster.Mounted)
			{
				Caster.SendLocalizedMessage(1063132); // You cannot use this ability while mounted.
			}
			else if (Caster.Followers + 1 > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1063133); // You cannot summon a mirror image because you have too many followers.
			}
			else if (TransformationSpellHelper.UnderTransformation(Caster, typeof(HorrificBeastSpell)))
			{
				Caster.SendLocalizedMessage(1061091); // You cannot cast that spell in this form.
			}
			else if (CheckSequence())
			{
				Caster.FixedParticles(0x376A, 1, 14, 0x13B5, EffectLayer.Waist);
				Caster.PlaySound(0x511);

				var c = new Clone(Caster);

				c.OnBeforeSpawn(Caster.Location, Caster.Map);

				if (!c.Deleted)
				{
					c.MoveToWorld(Caster.Location, Caster.Map);

					if (!c.Deleted)
					{
						c.OnAfterSpawn();
					}
				}
			}

			FinishSequence();
		}

		public static bool HasClone(Mobile m)
		{
			return m_CloneCount.ContainsKey(m);
		}

		public static void AddClone(Mobile m)
		{
			if (m == null)
			{
				return;
			}

			if (m_CloneCount.ContainsKey(m))
			{
				m_CloneCount[m]++;
			}
			else
			{
				m_CloneCount[m] = 1;
			}
		}

		public static void RemoveClone(Mobile m)
		{
			if (m != null && m_CloneCount.ContainsKey(m) && --m_CloneCount[m] <= 0)
			{
				m_CloneCount.Remove(m);
			}
		}
	}
}
