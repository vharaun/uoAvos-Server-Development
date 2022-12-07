using Server.Network;
using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Spells.Mysticism
{
	public class SleepSpell : MysticismSpell
	{
		private static readonly Dictionary<Mobile, SleepTimer> m_Table = new();
		private static readonly List<Mobile> m_ImmunityList = new();

		public SleepSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.Sleep)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void OnTarget(Mobile target)
		{
			if (!Caster.CanSee(target))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (target.Paralyzed)
			{
				Caster.SendLocalizedMessage(1080134); // Your target is already immobilized and cannot be slept.
			}
			else if (m_ImmunityList.Contains(target))
			{
				Caster.SendLocalizedMessage(1080135); // Your target cannot be put to sleep.
			}
			else if (CheckHSequence(target))
			{
				_ = SpellHelper.CheckReflect((int)Circle, Caster, ref target);

				var duration = ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 20.0) + 2.0;

				duration -= GetResistSkill(target) / 10.0;

				if (duration <= 0 || StoneFormSpell.UnderTransformation(target))
				{
					Caster.SendLocalizedMessage(1080136); //Your target resists sleep.
					target.SendLocalizedMessage(1080137); //You resist sleep.
				}
				else
				{
					DoSleep(Caster, target, TimeSpan.FromSeconds(duration));
				}
			}

			FinishSequence();
		}

		public static void DoSleep(Mobile caster, Mobile target, TimeSpan duration)
		{
			target.Combatant = null;

			_ = target.SendSpeedControl(SpeedControlType.WalkSpeed);

			if (m_Table.TryGetValue(target, out var t))
			{
				t?.Stop();
			}

			t = new SleepTimer(target, duration);

			m_Table[target] = t;

			t.Start();

			BuffInfo.AddBuff(target, new BuffInfo(BuffIcon.Sleep, 1080139, 1080140, duration, target));

			target.Delta(MobileDelta.WeaponDamage);
		}

		public static bool IsUnderSleepEffects(Mobile from)
		{
			return m_Table.ContainsKey(from);
		}

		public static void OnDamage(Mobile from)
		{
			EndSleep(from);
		}

		public static void EndSleep(Mobile target)
		{
			if (m_Table.TryGetValue(target, out var t))
			{
				t?.Stop();

				_ = m_Table.Remove(target);

				_ = target.SendSpeedControl(SpeedControlType.Disable);

				BuffInfo.RemoveBuff(target, BuffIcon.Sleep);

				var immduration = target.Skills.MagicResist.Value / 10.0;

				m_ImmunityList.Add(target);

				_ = Timer.DelayCall(TimeSpan.FromSeconds(immduration), m => m_ImmunityList.Remove(m), target);

				target.Delta(MobileDelta.WeaponDamage);
			}
		}

		public class SleepTimer : Timer
		{
			private readonly Mobile m_Target;
			private readonly DateTime m_EndTime;

			public SleepTimer(Mobile target, TimeSpan duration)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(0.5))
			{
				m_EndTime = DateTime.UtcNow + duration;
				m_Target = target;
			}

			protected override void OnTick()
			{
				if (m_EndTime < DateTime.UtcNow)
				{
					Stop();

					EndSleep(m_Target);
				}
				else
				{
					Effects.SendTargetParticles(m_Target, 0x3779, 1, 32, 0x13BA, EffectLayer.Head);
				}
			}
		}

		public class InternalTarget : Target
		{
			public SleepSpell Owner { get; set; }

			public InternalTarget(SleepSpell owner)
				: this(owner, false)
			{
			}

			public InternalTarget(SleepSpell owner, bool allowland)
				: base(12, allowland, TargetFlags.Harmful)
			{
				Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile t)
				{
					Owner.OnTarget(t);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				Owner.FinishSequence();
			}
		}
	}
}
