using Server.Mobiles;
using Server.Network;

using System;

namespace Server.Spells.Ranger
{
	public class CallMountSpell : RangerSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		private static readonly Type[] m_Types =
		{
			typeof(Horse),
			typeof(SwampDragon),
			typeof(RidableLlama),
			typeof(ForestOstard),
			typeof(DesertOstard),
		};

		public CallMountSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, RangerSpellName.CallMount)
		{
		}

		public override void SayMantra()
		{
			base.SayMantra();

			Caster.PlaySound(0x3D);
			Caster.PublicOverheadMessage(MessageType.Emote, 0x55, true, "*Blows Flute*", false);
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (Caster.Followers + 1 > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				try
				{
					var creature = (BaseCreature)Activator.CreateInstance(Utility.RandomList(m_Types));

					creature.ControlSlots = 1;

					TimeSpan duration;

					if (Core.AOS)
					{
						duration = TimeSpan.FromSeconds(2.0 * Caster.Skills[SkillName.AnimalTaming].Fixed / 5.0);
					}
					else
					{
						duration = TimeSpan.FromSeconds(4.0 * Caster.Skills[SkillName.AnimalLore].Value);
					}

					SpellHelper.Summon(creature, Caster, 0x215, duration, false, false);
				}
				catch
				{
				}
			}

			FinishSequence();
		}
	}
}
