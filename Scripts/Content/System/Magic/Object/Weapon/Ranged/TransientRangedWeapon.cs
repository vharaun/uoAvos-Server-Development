using System;

namespace Server.Items
{
	public abstract class TransientRangedWeapon : BaseRanged
	{
		private Timer m_Timer;

		public TransientRangedWeapon(int itemID, Mobile owner, TimeSpan duration)
			: base(itemID)
		{
			BlessedFor = owner;

			Layer = Layer.TwoHanded;

			if (duration > TimeSpan.Zero)
			{
				m_Timer = Timer.DelayCall(duration, Expire);
			}
		}

		public TransientRangedWeapon(Serial serial)
			: base(serial)
		{
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			if (m_Timer?.Running == true)
			{
				var remaining = m_Timer.Next - DateTime.UtcNow;

				list.Add(1049644, $"Temporary : {Math.Ceiling(remaining.TotalSeconds):N0}s");
			}
		}

		public override bool CanEquip(Mobile m)
		{
			return (BlessedFor == null || BlessedFor == m) && base.CanEquip(m);
		}

		public void Expire()
		{
			if (Deleted)
			{
				return;
			}

			OnExpire();

			Delete();
		}

		protected virtual void OnExpire()
		{
			BlessedFor?.SendMessage($"Your {Utility.FriendlyName(this)} slowly dissipates.");
		}

		public override TimeSpan OnSwing(Mobile attacker, Mobile defender, double damageBonus)
		{
			if (m_Timer?.Running == true)
			{
				InvalidateProperties();
			}

			return base.OnSwing(attacker, defender, damageBonus);
		}

		public override void OnDelete()
		{
			m_Timer?.Stop();
			m_Timer = null;

			base.OnDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			if (m_Timer != null)
			{
				writer.Write(true);

				if (m_Timer.Running)
				{
					writer.Write(m_Timer.Next - DateTime.UtcNow);
				}
				else
				{
					writer.Write(TimeSpan.Zero);
				}
			}
			else
			{
				writer.Write(false);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadInt();

			if (reader.ReadBool())
			{
				m_Timer = Timer.DelayCall(reader.ReadTimeSpan(), Expire);
			}
		}
	}
}
