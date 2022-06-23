using Server.Network;

using System;

namespace Server.Items
{
	public class BaseAquaticLife : Item
	{
		private static readonly TimeSpan DeathDelay = TimeSpan.FromMinutes(5);

		private Timer m_Timer;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Dead => (ItemID == 0x3B0C);

		[Constructable]
		public BaseAquaticLife(int itemID) : base(itemID)
		{
			StartTimer();
		}

		public BaseAquaticLife(Serial serial) : base(serial)
		{
		}

		public virtual void StartTimer()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			m_Timer = Timer.DelayCall(DeathDelay, Kill);

			InvalidateProperties();
		}

		public virtual void StopTimer()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			m_Timer = null;

			InvalidateProperties();
		}

		public override void OnDelete()
		{
			StopTimer();
		}

		public virtual void Kill()
		{
			ItemID = 0x3B0C;
			StopTimer();

			InvalidateProperties();
		}

		public int GetDescription()
		{
			// TODO: This will never return "very unusual dead aquarium creature" due to the way it is killed
			if (ItemID > 0x3B0F)
			{
				return Dead ? 1074424 : 1074422; // A very unusual [dead/live] aquarium creature
			}
			else if (Hue != 0)
			{
				return Dead ? 1074425 : 1074423; // A [dead/live] aquarium creature of unusual color
			}

			return Dead ? 1073623 : 1073622; // A [dead/live] aquarium creature
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add(GetDescription());

			if (!Dead && m_Timer != null)
			{
				list.Add(1074507); // Gasping for air
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (!(Parent is Aquarium) && !(Parent is FishBowl))
			{
				StartTimer();
			}
		}
	}

	public abstract class BaseMagicFish : Item
	{
		public virtual int Bonus => 0;
		public virtual StatType Type => StatType.Str;

		public override double DefaultWeight => 1.0;

		public BaseMagicFish(int hue) : base(0xDD6)
		{
			Hue = hue;
		}

		public BaseMagicFish(Serial serial) : base(serial)
		{
		}

		public virtual bool Apply(Mobile from)
		{
			var applied = Spells.SpellHelper.AddStatOffset(from, Type, Bonus, TimeSpan.FromMinutes(1.0));

			if (!applied)
			{
				from.SendLocalizedMessage(502173); // You are already under a similar effect.
			}

			return applied;
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
			}
			else if (Apply(from))
			{
				from.FixedEffect(0x375A, 10, 15);
				from.PlaySound(0x1E7);
				from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 501774); // You swallow the fish whole!
				Delete();
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}