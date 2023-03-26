using Server.Mobiles;
using Server.Targeting;

using System;

namespace Server.Spells.Spellweaving
{
	public abstract class SpellweavingSummon<T> : SpellweavingSpell where T : BaseCreature
	{
		public abstract int Sound { get; }

		public virtual int Count => 0;
		public virtual int Slots => 1;

		public virtual bool Targeted => false;
		public virtual bool Controlled => true;

		public SpellweavingSummon(Mobile caster, Item scroll, SpellweavingSpellName id)
			: base(caster, scroll, id)
		{
		}

		public SpellweavingSummon(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (Caster.Followers + (Slots * GetCount()) > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1074270); // You have too many followers to summon another one.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if (Targeted)
			{
				Caster.Target = new InternalTarget(this);
			}
			else
			{
				Summon(Caster);
			}
		}

		public virtual void Summon(IPoint3D point)
		{
			if (CheckSequence())
			{
				var loc = new Point3D(point);

				if (point is Item item)
				{
					loc = item.GetWorldLocation();
				}

				var summons = GetCount();
				var duration = GetDuration();

				while (--summons >= 0)
				{
					var p = loc;

					if (!Targeted && !SpellHelper.FindValidSpawnLocation(Caster.Map, ref p, true))
					{
						p = Caster.Location;
					}

					var summoned = Construct();

					if (summoned == null)
					{
						break;
					}

					if (BaseCreature.Summon(summoned, Controlled, Caster, p, Sound, duration))
					{
						OnSummon(summoned);
					}
				}
			}

			FinishSequence();
		}

		public virtual T Construct()
		{
			try
			{
				return Activator.CreateInstance<T>();
			}
			catch
			{
				return null;
			}
		}

		public virtual int GetCount()
		{
			if (Count <= 0)
			{
				return Math.Min(1 + FocusLevel, Caster.FollowersMax - Caster.Followers);
			}

			return Count;
		}

		public virtual TimeSpan GetDuration()
		{
			return TimeSpan.FromMinutes(Caster.Skills.Spellweaving.Value / 24.0 + FocusLevel * 2.0);
		}

		protected virtual void OnSummon(T summoned)
		{
		}

		private class InternalTarget : Target
		{
			private readonly SpellweavingSummon<T> m_Owner;

			public InternalTarget(SpellweavingSummon<T> owner)
				: base(10, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D p)
				{
					m_Owner.Summon(p);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}