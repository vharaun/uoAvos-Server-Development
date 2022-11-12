using Server.Targeting;

using System;

namespace Server.Spells.Mysticism
{
	public class BombardSpell : MysticismSpell
	{
		public override bool DelayedDamage => true;
		public override bool DelayedDamageStacking => false;

		public BombardSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.Bombard)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void OnTarget(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckHSequence(m))
			{
				var target = m;
				var source = Caster;

				SpellHelper.Turn(Caster, target);

				if (SpellHelper.CheckReflect((int)Circle, ref source, ref target))
				{
					_ = Timer.DelayCall(TimeSpan.FromSeconds(0.5), () =>
					{
						source.MovingEffect(target, 0x1363, 12, 1, false, true, 0, 0);
						source.PlaySound(0x64B);
					});
				}

				Caster.MovingEffect(m, 0x1363, 12, 1, false, true, 0, 0);
				Caster.PlaySound(0x64B);

				SpellHelper.Damage(this, target, GetNewAosDamage(40, 1, 5, target), 100, 0, 0, 0, 0);

				_ = Timer.DelayCall(TimeSpan.FromSeconds(1.2), () =>
				{
					if (!CheckResisted(target))
					{
						var secs = Math.Max(0, (GetDamageSkill(Caster) / 10.0) - (GetResistSkill(target) / 10.0));

						target.Paralyze(TimeSpan.FromSeconds(secs));
					}
				});
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			public BombardSpell Owner { get; set; }

			public InternalTarget(BombardSpell owner)
				: this(owner, false)
			{
			}

			public InternalTarget(BombardSpell owner, bool allowland)
				: base(12, allowland, TargetFlags.Harmful)
			{
				Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile m)
				{
					Owner.OnTarget(m);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				Owner.FinishSequence();
			}
		}
	}
}
