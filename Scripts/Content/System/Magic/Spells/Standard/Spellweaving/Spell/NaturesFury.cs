using Server.Mobiles;
using Server.Regions;
using Server.Targeting;

using System;

namespace Server.Spells.Spellweaving
{
	public class NaturesFurySpell : SpellweavingSummon<NaturesFury>
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.5);

		public override int Sound => 0x5CB;

		public override int Count => 1;

		public override bool Targeted => true;
		public override bool Controlled => false;

		public NaturesFurySpell(Mobile caster, Item scroll)
			: base(caster, scroll, SpellweavingSpellName.NaturesFury)
		{
		}

		public override void Summon(IPoint3D point)
		{
			var p = new Point3D(point);

			if (point is Item item)
			{
				p = item.GetWorldLocation();
			}

			if (!Caster.Map.CanSpawnMobile(p.X, p.Y, p.Z))
			{
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			}
			else if (!SpellHelper.CheckTown(this, p))
			{ 
			}
			else
			{
				var reg = Region.Find(p, Caster.Map);
				var hr = reg.GetRegion<HouseRegion>();

				if (hr?.House?.IsFriend(Caster) != false)
				{
					base.Summon(point);
				}
			}

			FinishSequence();
		}

		public override TimeSpan GetDuration()
		{
			return TimeSpan.FromSeconds(25.0 + (Caster.Skills.Spellweaving.Value / 24.0) + FocusLevel * 2.0);
		}

		protected override void OnSummon(NaturesFury summoned)
		{
			base.OnSummon(summoned);

			var t = new InternalTimer(summoned);

			t.Start();
		}

		private class InternalTimer : Timer
		{
			private readonly NaturesFury m_NatureFury;

			public InternalTimer(NaturesFury nf)
				: base(TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(5.0))
			{
				m_NatureFury = nf;
			}

			protected override void OnTick()
			{
				if (m_NatureFury.Deleted || !m_NatureFury.Alive || m_NatureFury.DamageMin >= 20)
				{
					Stop();
					return;
				}

				++m_NatureFury.DamageMin;
				++m_NatureFury.DamageMax;
			}
		}
	}
}