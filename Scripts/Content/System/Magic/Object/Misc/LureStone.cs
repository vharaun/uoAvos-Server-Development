using Server.Mobiles;

using System;

namespace Server.Items
{
	public class LureStone : Item
	{
		public static void Lure(Mobile owner, BaseCreature cret, int toX, int toY, bool spell)
		{
			if (owner != null && cret != null && cret.BeginAction(typeof(LureStone))) // prevent being handled by multiple stones at once
			{
				if (cret.Combatant == null || !cret.Combatant.Alive || cret.Combatant.Deleted)
				{
					var bonus = owner.Skills[SkillName.AnimalLore].Value / 100;
					var tamer = owner.Skills[SkillName.AnimalTaming].Value;

					if (spell && tamer >= 99.9)
					{
						cret.TargetLocation = new Point2D(toX, toY);
					}
					else if (cret.Tamable && cret.MinTameSkill <= tamer + bonus + 0.1)
					{
						cret.TargetLocation = new Point2D(toX, toY);
					}
				}

				_ = Timer.DelayCall(cret.EndAction, typeof(LureStone));
			}
		}

		private InternalTimer m_Timer;

		private Mobile m_Owner;

		public override bool HandlesOnMovement => true;

		[Constructable]
		public LureStone(Mobile owner)
			: base(0x1355)
		{
			m_Owner = owner;

			Name = "lure stone";
			Movable = false;

			m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(30.0));
			m_Timer.Start();
		}

		public LureStone(Serial serial)
			: base(serial)
		{
		}

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			Lure(m_Owner, m as BaseCreature, X, Y, false);
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
			private readonly LureStone m_Item;

			public InternalTimer(LureStone item, TimeSpan duration)
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
}
