using Server.Targeting;

using System;

namespace Server.Spells.Mysticism
{
	public class NetherBoltSpell : MysticismSpell
	{
		public override bool DelayedDamage => true;
		public override bool DelayedDamageStacking => false;

		public NetherBoltSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.NetherBolt)
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
						source.MovingParticles(target, 0x36D4, 7, 0, false, true, 0x49A, 0, 0, 9502, 4019, 0x160);
						source.PlaySound(0x211);
					});
				}

				var damage = GetNewAosDamage(10, 1, 4, target);

				SpellHelper.Damage(this, target, damage, 20, 20, 20, 20, 20);

				Caster.MovingParticles(m, 0x36D4, 7, 0, false, true, 0x49A, 0, 0, 9502, 4019, 0x160);
				Caster.PlaySound(0x211);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			public NetherBoltSpell Owner { get; set; }

			public InternalTarget(NetherBoltSpell owner)
				: this(owner, false)
			{
			}

			public InternalTarget(NetherBoltSpell owner, bool allowland)
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
