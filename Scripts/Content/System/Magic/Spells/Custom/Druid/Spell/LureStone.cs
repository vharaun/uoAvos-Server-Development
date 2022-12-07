using Server.Items;
using Server.Mobiles;
using Server.Targeting;

using System;

namespace Server.Spells.Druid
{
	public class LureStoneSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1);

		public LureStoneSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.LureStone)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p) || !Caster.InLOS(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (!SpellHelper.CheckTown(this, p))
			{ }
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				Effects.PlaySound(p, Caster.Map, 0x243);

				var loc = new Point3D(p);

				if (SpellHelper.AdjustField(ref loc, Caster.Map, 22, true))
				{
					var item1 = new InternalItem(Caster);

					item1.MoveToWorld(loc, Caster.Map);

					--loc.Y;

					if (SpellHelper.AdjustField(ref loc, Caster.Map, 22, true))
					{
						var item2 = new InternalItem(null);

						item2.MoveToWorld(loc, Caster.Map);
					}
				}
			}

			FinishSequence();
		}

		private class InternalItem : Item
		{
			private InternalTimer m_Timer;

			private Mobile m_Owner;

			public override bool BlocksFit => true;

			public override bool HandlesOnMovement => true;

			public InternalItem(Mobile caster)
				: base(caster != null ? 0x1355 : 0x1356)
			{
				m_Owner = caster;

				Movable = false;

				Name = "lure stone";

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(30.0));
				m_Timer.Start();
			}

			public InternalItem(Serial serial)
				: base(serial)
			{
			}

			public override void OnMovement(Mobile m, Point3D oldLocation)
			{
				if (m_Owner != null && m is BaseCreature cret)
				{
					LureStone.Lure(m_Owner, cret, X, Y, true);
				}
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				m_Timer?.Stop();
				m_Timer = null;
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(0); // version

				writer.Write(m_Owner);

				if (m_Timer?.Running == true)
				{
					writer.Write(m_Timer.Next - DateTime.UtcNow);
				}
				else
				{
					writer.Write(TimeSpan.Zero);
				}
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				_ = reader.ReadInt();

				m_Owner = reader.ReadMobile();

				var duration = reader.ReadTimeSpan();

				if (duration > TimeSpan.Zero)
				{
					m_Timer = new InternalTimer(this, duration);
				}
				else
				{
					m_Timer = new InternalTimer(this, TimeSpan.Zero);
				}

				m_Timer.Start();
			}

			private class InternalTimer : Timer
			{
				private readonly InternalItem m_Item;

				public InternalTimer(InternalItem item, TimeSpan duration)
					: base(duration)
				{
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly LureStoneSpell m_Owner;

			public InternalTarget(LureStoneSpell owner)
				: base(12, true, TargetFlags.None)
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
