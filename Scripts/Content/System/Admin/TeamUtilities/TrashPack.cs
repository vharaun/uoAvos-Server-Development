
using System;

namespace Server.Items
{
	public class TrashPack : Container
	{
		public override int MaxWeight => 0;  // A value of 0 signals unlimited weight

		public override int DefaultGumpID => 0x3C;
		public override int DefaultDropSound => 0x42;

		public override Rectangle2D Bounds => new Rectangle2D(44, 65, 142, 94);

		public override bool IsDecoContainer => false;

		[Constructable]
		public TrashPack()
			: base(0x9B2)
		{
			Name = "Trash Bag";
			Hue = 1166;
			Movable = true;
		}

		public TrashPack(Serial serial)
			: base(serial)
		{
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

			if (Items.Count > 0)
			{
				m_Timer = new EmptyTimer(this);
				m_Timer.Start();
			}
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			if (!base.OnDragDrop(from, dropped))
			{
				return false;
			}

			if (TotalItems >= 10)
			{
				Empty(501478); // The trash is full!  Emptying!
			}
			else
			{
				from.SendMessage("Items will delete in 30 seconds!"); // The item will be deleted in three minutes

				if (m_Timer != null)
				{
					m_Timer.Stop();
				}
				else
				{
					m_Timer = new EmptyTimer(this);
				}

				m_Timer.Start();
			}

			return true;
		}

		public override bool OnDragDropInto(Mobile from, Item item, Point3D p)
		{
			if (!base.OnDragDropInto(from, item, p))
			{
				return false;
			}

			if (TotalItems >= 10)
			{
				Empty(501478); // The trash is full!  Emptying!
			}
			else
			{
				from.SendMessage("Items will delete in 30 sconds!"); // The item will be deleted in three minutes

				if (m_Timer != null)
				{
					m_Timer.Stop();
				}
				else
				{
					m_Timer = new EmptyTimer(this);
				}

				m_Timer.Start();
			}

			return true;
		}


		public void Empty(int message)
		{
			var items = Items;

			if (items.Count > 0)
			{
				PublicOverheadMessage(Network.MessageType.Regular, 0x3B2, message, "");

				for (var i = items.Count - 1; i >= 0; --i)
				{
					if (i >= items.Count)
					{
						continue;
					}

					items[i].Delete();
				}
			}

			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			m_Timer = null;
		}

		private Timer m_Timer;

		private class EmptyTimer : Timer
		{
			private readonly TrashPack m_Pack;

			public EmptyTimer(TrashPack pack)
				: base(TimeSpan.FromMinutes(.5))
			{
				m_Pack = pack;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Pack.Empty(501479); // Emptying the trashcan!
			}
		}
	}
}