using Server.Items;
using Server.Network;
using Server.Spells;

using System;

namespace Server.SkillHandlers
{
	public static class SpiritSpeak
	{
		public static void Initialize()
		{
			SkillInfo.Table[32].Callback = new SkillUseCallback(OnUse);
		}

		public static TimeSpan OnUse(Mobile m)
		{
			if (Core.AOS)
			{
				Spell spell = new SpiritSpeakSpell(m);

				spell.Cast();

				if (spell.IsCasting)
				{
					return TimeSpan.FromSeconds(5.0);
				}

				return TimeSpan.Zero;
			}

			m.RevealingAction();

			if (m.CheckSkill(SkillName.SpiritSpeak, 0, 100))
			{
				if (!m.CanHearGhosts)
				{
					m.CanHearGhosts = true;

					var secs = Math.Max(15.0, m.Skills[SkillName.SpiritSpeak].Base / 50.0 * 90.0);

					var t = new SpiritSpeakTimer(m, TimeSpan.FromSeconds(secs));

					t.Start();
				}

				m.PlaySound(0x24A);
				m.SendLocalizedMessage(502444);//You contact the neitherworld.
			}
			else
			{
				m.SendLocalizedMessage(502443);//You fail to contact the neitherworld.
				m.CanHearGhosts = false;
			}

			return TimeSpan.FromSeconds(1.0);
		}

		private class SpiritSpeakTimer : Timer
		{
			private readonly Mobile m_Owner;

			public SpiritSpeakTimer(Mobile m, TimeSpan delay) 
				: base(delay)
			{
				m_Owner = m;

				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Owner.CanHearGhosts = false;

				m_Owner.SendLocalizedMessage(502445);//You feel your contact with the neitherworld fading.
			}
		}

		private class SpiritSpeakSpell : Spell
		{
			private static readonly SpellInfo m_Info = new(typeof(SpiritSpeakSpell))
			{
				Name = "Spirit Speak",
				Action = 269,
			};

			public override bool BlockedByHorrificBeast => false;

			public override bool ClearHandsOnCast => false;

			public override double CastDelayFastScalar => 0;

			public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.0);

			public override bool CheckNextSpellTime => false;

			public override SkillName CastSkill => SkillName.SpiritSpeak;
			public override SkillName DamageSkill => SkillName.SpiritSpeak;

			public SpiritSpeakSpell(Mobile caster) 
				: base(caster, null, m_Info)
			{
			}

			public override void OnCasterHurt()
			{
				if (IsCasting)
				{
					Interrupt(SpellInterrupt.Hurt, true);
				}
			}

			public override bool ConsumeReagents()
			{
				return true;
			}

			public override bool CheckFizzle()
			{
				return true;
			}

			public override void OnInterrupt(SpellInterrupt type, bool message)
			{
				Caster.NextSkillTime = Core.TickCount;

				base.OnInterrupt(type, message);
			}

			public override bool CheckInterrupt(SpellInterrupt type, bool resistable)
			{
				return type != SpellInterrupt.EquipRequest && type != SpellInterrupt.UseRequest;
			}

			public override void SayMantra()
			{
				// Anh Mi Sah Ko
				Caster.PublicOverheadMessage(MessageType.Regular, 0x3B2, 1062074, "", false);
				Caster.PlaySound(0x24A);
			}

			public override void OnCast()
			{
				Corpse toChannel = null;

				var items = Caster.GetItemsInRange(3);

				foreach (var item in items)
				{
					if (item is Corpse c && !c.Channeled)
					{
						toChannel = c;
						break;
					}
				}
				
				items.Free();

				int max, min, mana, number;

				if (toChannel != null)
				{
					min = 1 + (int)(Caster.Skills[SkillName.SpiritSpeak].Value * 0.25);
					max = min + 4;
					mana = 0;
					number = 1061287; // You channel energy from a nearby corpse to heal your wounds.
				}
				else
				{
					min = 1 + (int)(Caster.Skills[SkillName.SpiritSpeak].Value * 0.25);
					max = min + 4;
					mana = 10;
					number = 1061286; // You channel your own spiritual energy to heal your wounds.
				}

				if (Caster.Mana < mana)
				{
					Caster.SendLocalizedMessage(1061285); // You lack the mana required to use this skill.
				}
				else
				{
					Caster.CheckSkill(SkillName.SpiritSpeak, 0.0, 120.0);

					if (Utility.RandomDouble() > (Caster.Skills[SkillName.SpiritSpeak].Value / 100.0))
					{
						Caster.SendLocalizedMessage(502443); // You fail your attempt at contacting the netherworld.
					}
					else
					{
						if (toChannel != null)
						{
							toChannel.Channeled = true;
							toChannel.Hue = 0x835;
						}

						Caster.Mana -= mana;
						Caster.SendLocalizedMessage(number);

						if (min > max)
						{
							min = max;
						}

						Caster.Hits += Utility.RandomMinMax(min, max);

						Caster.FixedParticles(0x375A, 1, 15, 9501, 2100, 4, EffectLayer.Waist);
					}
				}

				FinishSequence();
			}
		}
	}
}