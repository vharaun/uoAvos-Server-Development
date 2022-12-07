using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Spells.Magery
{
	/// AirElemental
	public class AirElementalSpell : MagerySpell
	{
		public AirElementalSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, MagerySpellName.AirElemental)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if ((Caster.Followers + 2) > Caster.FollowersMax)
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
				var duration = TimeSpan.FromSeconds(2 * Caster.Skills.Magery.Fixed / 5);

				if (Core.AOS)
				{
					SpellHelper.Summon(new SummonedAirElemental(), Caster, 0x217, duration, false, false);
				}
				else
				{
					SpellHelper.Summon(new AirElemental(), Caster, 0x217, duration, false, false);
				}
			}

			FinishSequence();
		}
	}

	/// EarthElemental
	public class EarthElementalSpell : MagerySpell
	{
		public EarthElementalSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, MagerySpellName.EarthElemental)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if ((Caster.Followers + 2) > Caster.FollowersMax)
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
				var duration = TimeSpan.FromSeconds(2 * Caster.Skills.Magery.Fixed / 5);

				if (Core.AOS)
				{
					SpellHelper.Summon(new SummonedEarthElemental(), Caster, 0x217, duration, false, false);
				}
				else
				{
					SpellHelper.Summon(new EarthElemental(), Caster, 0x217, duration, false, false);
				}
			}

			FinishSequence();
		}
	}

	///  Earthquake
	public class EarthquakeSpell : MagerySpell
	{
		public EarthquakeSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, MagerySpellName.Earthquake)
		{
		}

		public override bool DelayedDamage => !Core.AOS;

		public override void OnCast()
		{
			if (!SpellHelper.CheckTown(this, Caster))
			{ }
			else if (CheckSequence())
			{
				var targets = new List<Mobile>();

				var map = Caster.Map;

				if (map != null)
				{
					foreach (var m in Caster.GetMobilesInRange(1 + (int)(Caster.Skills[SkillName.Magery].Value / 15.0)))
					{
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && (!Core.AOS || Caster.InLOS(m)))
						{
							targets.Add(m);
						}
					}
				}

				Caster.PlaySound(0x220);

				for (var i = 0; i < targets.Count; ++i)
				{
					var m = targets[i];

					int damage;

					if (Core.AOS)
					{
						damage = m.Hits / 2;

						if (!m.Player)
						{
							damage = Math.Max(Math.Min(damage, 100), 15);
						}

						damage += Utility.RandomMinMax(0, 15);

					}
					else
					{
						damage = m.Hits * 6 / 10;

						if (!m.Player && damage < 10)
						{
							damage = 10;
						}
						else if (damage > 75)
						{
							damage = 75;
						}
					}

					Caster.DoHarmful(m);
					SpellHelper.Damage(TimeSpan.Zero, m, Caster, damage, 100, 0, 0, 0, 0);
				}
			}

			FinishSequence();
		}
	}

	/// EnergyVortex
	public class EnergyVortexSpell : MagerySpell
	{
		public EnergyVortexSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, MagerySpellName.EnergyVortex)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if ((Caster.Followers + (Core.SE ? 2 : 1)) > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			var map = Caster.Map;

			SpellHelper.GetSurfaceTop(ref p);

			if (map == null || !map.CanSpawnMobile(p.X, p.Y, p.Z))
			{
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			}
			else if (!SpellHelper.CheckTown(this, p))
			{ }
			else if (CheckSequence())
			{
				TimeSpan duration;

				if (Core.AOS)
				{
					duration = TimeSpan.FromSeconds(90.0);
				}
				else
				{
					duration = TimeSpan.FromSeconds(Utility.Random(80, 40));
				}

				_ = BaseCreature.Summon(new EnergyVortex(), false, Caster, new Point3D(p), 0x212, duration);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private EnergyVortexSpell m_Owner;

			public InternalTarget(EnergyVortexSpell owner) : base(Core.ML ? 10 : 12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D)
				{
					m_Owner.Target((IPoint3D)o);
				}
			}

			protected override void OnTargetOutOfLOS(Mobile from, object o)
			{
				from.SendLocalizedMessage(501943); // Target cannot be seen. Try again.
				from.Target = new InternalTarget(m_Owner);
				from.Target.BeginTimeout(from, TimeoutTime - DateTime.UtcNow);
				m_Owner = null;
			}

			protected override void OnTargetFinish(Mobile from)
			{
				if (m_Owner != null)
				{
					m_Owner.FinishSequence();
				}
			}
		}
	}

	/// FireElemental
	public class FireElementalSpell : MagerySpell
	{
		public FireElementalSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, MagerySpellName.FireElemental)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if ((Caster.Followers + 4) > Caster.FollowersMax)
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
				var duration = TimeSpan.FromSeconds(2 * Caster.Skills.Magery.Fixed / 5);

				if (Core.AOS)
				{
					SpellHelper.Summon(new SummonedFireElemental(), Caster, 0x217, duration, false, false);
				}
				else
				{
					SpellHelper.Summon(new FireElemental(), Caster, 0x217, duration, false, false);
				}
			}

			FinishSequence();
		}
	}

	/// Resurrection
	public class ResurrectionSpell : MagerySpell
	{
		public ResurrectionSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, MagerySpellName.Resurrection)
		{
		}

		public override bool CheckCast()
		{
			if (Engines.ConPVP.DuelContext.CheckSuddenDeath(Caster))
			{
				Caster.SendMessage(0x22, "You cannot cast this spell when in sudden death.");
				return false;
			}

			return base.CheckCast();
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
			else if (m == Caster)
			{
				Caster.SendLocalizedMessage(501039); // Thou can not resurrect thyself.
			}
			else if (!Caster.Alive)
			{
				Caster.SendLocalizedMessage(501040); // The resurrecter must be alive.
			}
			else if (m.Alive)
			{
				Caster.SendLocalizedMessage(501041); // Target is not dead.
			}
			else if (!Caster.InRange(m, 1))
			{
				Caster.SendLocalizedMessage(501042); // Target is not close enough.
			}
			else if (!m.Player)
			{
				Caster.SendLocalizedMessage(501043); // Target is not a being.
			}
			else if (m.Map == null || !m.Map.CanFit(m.Location, 16, false, false))
			{
				Caster.SendLocalizedMessage(501042); // Target can not be resurrected at that location.
				m.SendLocalizedMessage(502391); // Thou can not be resurrected there!
			}
			else if (m.Region != null && m.Region.IsPartOf("Khaldun"))
			{
				Caster.SendLocalizedMessage(1010395); // The veil of death in this area is too strong and resists thy efforts to restore life.
			}
			else if (CheckBSequence(m, true))
			{
				SpellHelper.Turn(Caster, m);

				m.PlaySound(0x214);
				m.FixedEffect(0x376A, 10, 16);

				_ = m.CloseGump(typeof(ResurrectGump));
				_ = m.SendGump(new ResurrectGump(m, Caster));
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly ResurrectionSpell m_Owner;

			public InternalTarget(ResurrectionSpell owner) : base(1, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
				{
					m_Owner.Target((Mobile)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// SummonDaemon
	public class SummonDaemonSpell : MagerySpell
	{
		public SummonDaemonSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, MagerySpellName.SummonDaemon)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if ((Caster.Followers + (Core.SE ? 4 : 5)) > Caster.FollowersMax)
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
				var duration = TimeSpan.FromSeconds(2 * Caster.Skills.Magery.Fixed / 5);

				if (Core.AOS)  /* Why two diff daemons? TODO: solve this */
				{
					BaseCreature m_Daemon = new SummonedDaemon();
					SpellHelper.Summon(m_Daemon, Caster, 0x216, duration, false, false);
					m_Daemon.FixedParticles(0x3728, 8, 20, 5042, EffectLayer.Head);
				}
				else
				{
					SpellHelper.Summon(new Daemon(), Caster, 0x216, duration, false, false);
				}
			}

			FinishSequence();
		}
	}

	/// WaterElemental
	public class WaterElementalSpell : MagerySpell
	{
		public WaterElementalSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, MagerySpellName.WaterElemental)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if ((Caster.Followers + 3) > Caster.FollowersMax)
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
				var duration = TimeSpan.FromSeconds(2 * Caster.Skills.Magery.Fixed / 5);

				if (Core.AOS)
				{
					SpellHelper.Summon(new SummonedWaterElemental(), Caster, 0x217, duration, false, false);
				}
				else
				{
					SpellHelper.Summon(new WaterElemental(), Caster, 0x217, duration, false, false);
				}
			}

			FinishSequence();
		}
	}
}