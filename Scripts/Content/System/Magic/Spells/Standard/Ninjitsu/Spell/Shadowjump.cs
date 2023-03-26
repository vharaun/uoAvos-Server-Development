using Server.Items;
using Server.Mobiles;
using Server.Regions;
using Server.SkillHandlers;
using Server.Targeting;

using System;

namespace Server.Spells.Ninjitsu
{
	public class ShadowJumpSpell : NinjitsuSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.0);

		public override bool BlockedByAnimalForm => false;

		public ShadowJumpSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, NinjitsuSpellName.ShadowJump)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (Caster is PlayerMobile pm) // IsStealthing should be moved to Server.Mobiles
			{
				if (!pm.IsStealthing)
				{
					Caster.SendLocalizedMessage(1063087); // You must be in stealth mode to use this ability.
					return false;
				}
			}
			else if (!Caster.Hidden)
			{
				return false;
			}

			return true;
		}

		public override bool CheckInterrupt(SpellInterrupt type, bool resistable)
		{
			return false;
		}

		public override void OnCast()
		{
			Caster.SendLocalizedMessage(1063088); // You prepare to perform a Shadowjump.
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			var orig = p;
			var map = Caster.Map;

			SpellHelper.GetSurfaceTop(ref p);

			var from = Caster.Location;
			var to = new Point3D(p);

			if (Caster is PlayerMobile pm && !pm.IsStealthing)
			{
				Caster.SendLocalizedMessage(1063087); // You must be in stealth mode to use this ability.
			}
			else if (Factions.Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
			}
			else if (Server.Misc.WeightOverloading.IsOverloaded(Caster))
			{
				Caster.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
			}
			else if (!SpellHelper.CheckTravel(Caster, TravelCheckType.TeleportFrom) || !SpellHelper.CheckTravel(Caster, map, to, TravelCheckType.TeleportTo))
			{
			}
			else if (map == null || !map.CanSpawnMobile(p.X, p.Y, p.Z))
			{
				Caster.SendLocalizedMessage(502831); // Cannot teleport to that spot.
			}
			else if (SpellHelper.CheckMulti(to, map, true, 5))
			{
				Caster.SendLocalizedMessage(502831); // Cannot teleport to that spot.
			}
			else if (Region.Find(to, map).IsPartOf<HouseRegion>())
			{
				Caster.SendLocalizedMessage(502829); // Cannot teleport to that spot.
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, orig);

				var m = Caster;

				m.Location = to;
				m.ProcessDelta();

				Effects.SendLocationParticles(EffectItem.Create(from, m.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);

				m.PlaySound(0x512);

				Stealth.OnUse(m); // stealth check after the a jump
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private readonly ShadowJumpSpell m_Owner;

			public InternalTarget(ShadowJumpSpell owner) 
				: base(11, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D p)
				{
					m_Owner.Target(p);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}