using Server.Network;
using Server.Targeting;

using System;

namespace Server.Spells.Mysticism
{
	public class HailStormSpell : MysticismSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.25);

		public HailStormSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.HailStorm)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!SpellHelper.CheckTown(this, p))
			{
			}
			else if (CheckSequence())
			{
				/* Summons a storm of hailstones that strikes all Targets
				 * within a radius around the Target's Location, dealing
				 * cold damage.
				 */

				SpellHelper.Turn(Caster, p);

				if (p is Item item)
				{
					p = item.GetWorldLocation();
				}

				PlayEffect(p, Caster.Map);

				var targets = Caster.Map.GetMobilesInRange(new Point3D(p), 2);

				foreach (var m in targets)
				{
					if (m == Caster)
					{
						continue;
					}

					if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && Caster.CanSee(m))
					{
						if (!Caster.InLOS(m))
						{
							continue;
						}

						var damage = GetNewAosDamage(51, 1, 5, m.Player);

						Caster.DoHarmful(m);

						SpellHelper.Damage(this, m, damage, 0, 0, 100, 0, 0);
					}
				}

				targets.Free();
			}

			FinishSequence();
		}

		private static void PlayEffect(IPoint3D p, Map map)
		{
			Effects.PlaySound(p, map, 0x64F);

			PlaySingleEffect(p, map, -1, 1, -1, 1);
			PlaySingleEffect(p, map, -2, 0, -3, -1);
			PlaySingleEffect(p, map, -3, -1, -1, 1);
			PlaySingleEffect(p, map, 1, 3, -1, 1);
			PlaySingleEffect(p, map, -1, 1, 1, 3);
		}

		private static void PlaySingleEffect(IPoint3D p, Map map, int a, int b, int c, int d)
		{
			int x = p.X, y = p.Y, z = p.Z + 18;

			SendEffectPacket(p, map, new Point3D(x + a, y + c, z), new Point3D(x + a, y + c, z));
			SendEffectPacket(p, map, new Point3D(x + b, y + c, z), new Point3D(x + b, y + c, z));
			SendEffectPacket(p, map, new Point3D(x + b, y + d, z), new Point3D(x + b, y + d, z));
			SendEffectPacket(p, map, new Point3D(x + a, y + d, z), new Point3D(x + a, y + d, z));

			SendEffectPacket(p, map, new Point3D(x + b, y + c, z), new Point3D(x + a, y + c, z));
			SendEffectPacket(p, map, new Point3D(x + b, y + d, z), new Point3D(x + b, y + c, z));
			SendEffectPacket(p, map, new Point3D(x + a, y + d, z), new Point3D(x + b, y + d, z));
			SendEffectPacket(p, map, new Point3D(x + a, y + c, z), new Point3D(x + a, y + d, z));
		}

		private static void SendEffectPacket(IPoint3D p, Map map, Point3D orig, Point3D dest)
		{
			Effects.SendPacket(p, map, new HuedEffect(EffectType.Moving, Serial.Zero, Serial.Zero, 0x36D4, orig, dest, 0, 0, false, false, 0x63, 0x4));
		}

		private class InternalTarget : Target
		{
			private readonly HailStormSpell m_Owner;

			public InternalTarget(HailStormSpell owner)
				: base(12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var p = o as IPoint3D;

				if (p != null)
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