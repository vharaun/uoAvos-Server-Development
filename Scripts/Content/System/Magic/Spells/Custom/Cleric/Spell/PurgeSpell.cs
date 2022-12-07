using Server.Spells.Magery;
using Server.Spells.Necromancy;
using Server.Targeting;

namespace Server.Spells.Cleric
{
	public class PurgeSpell : ClericSpell
	{
		public PurgeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, ClericSpellName.Purge)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckBSequence(m, false))
			{
				SpellHelper.Turn(Caster, m);

				m.PlaySound(0xF6);
				m.PlaySound(0x1F7);
				m.FixedParticles(0x3709, 1, 30, 9963, 13, 3, EffectLayer.Head);

				var from = new Entity(Serial.Zero, new Point3D(m.X, m.Y, m.Z - 10), Caster.Map);
				var to = new Entity(Serial.Zero, new Point3D(m.X, m.Y, m.Z + 50), Caster.Map);

				Effects.SendMovingParticles(from, to, 0x2255, 1, 0, false, false, 13, 3, 9501, 1, 0, EffectLayer.Head, 0x100);

				CurseSpell.RemoveEffect(m);

				_ = StrangleSpell.RemoveCurse(m);
				_ = CorpseSkinSpell.RemoveCurse(m);

				_ = m.CurePoison(Caster);

				m.Paralyzed = false;
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly PurgeSpell m_Owner;

			public InternalTarget(PurgeSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile m)
				{
					m_Owner.Target(m);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
