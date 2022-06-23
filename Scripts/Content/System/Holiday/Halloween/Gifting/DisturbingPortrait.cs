using Server.Network;

using System;

namespace Server.Items
{
	/// DisturbingPortrait1
	[Flipable(0x2A5D, 0x2A61)]
	public class DisturbingPortrait1Component : AddonComponent
	{
		public override int LabelNumber => 1074479;  // Disturbing portrait
		public bool FacingSouth => ItemID < 0x2A61;

		private InternalTimer m_Timer;

		public DisturbingPortrait1Component() : base(0x2A5D)
		{
			m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(1));
			m_Timer.Start();
		}

		public DisturbingPortrait1Component(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (Utility.InRange(Location, from.Location, 2))
			{
				int hours;
				int minutes;

				Clock.GetTime(Map, X, Y, out hours, out minutes);

				if (hours < 4 || hours > 20)
				{
					Effects.PlaySound(Location, Map, 0x569);
				}

				UpdateImage();
			}
			else
			{
				from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
			}
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if (m_Timer != null && m_Timer.Running)
			{
				m_Timer.Stop();
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();

			m_Timer = new InternalTimer(this, TimeSpan.Zero);
			m_Timer.Start();
		}

		private void UpdateImage()
		{
			int hours;
			int minutes;

			Clock.GetTime(Map, X, Y, out hours, out minutes);

			if (FacingSouth)
			{
				if (hours < 4)
				{
					ItemID = 0x2A60;
				}
				else if (hours < 6)
				{
					ItemID = 0x2A5F;
				}
				else if (hours < 8)
				{
					ItemID = 0x2A5E;
				}
				else if (hours < 16)
				{
					ItemID = 0x2A5D;
				}
				else if (hours < 18)
				{
					ItemID = 0x2A5E;
				}
				else if (hours < 20)
				{
					ItemID = 0x2A5F;
				}
				else
				{
					ItemID = 0x2A60;
				}
			}
			else
			{
				if (hours < 4)
				{
					ItemID = 0x2A64;
				}
				else if (hours < 6)
				{
					ItemID = 0x2A63;
				}
				else if (hours < 8)
				{
					ItemID = 0x2A62;
				}
				else if (hours < 16)
				{
					ItemID = 0x2A61;
				}
				else if (hours < 18)
				{
					ItemID = 0x2A62;
				}
				else if (hours < 20)
				{
					ItemID = 0x2A63;
				}
				else
				{
					ItemID = 0x2A64;
				}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly DisturbingPortrait1Component m_Component;

			public InternalTimer(DisturbingPortrait1Component c, TimeSpan delay) : base(delay, TimeSpan.FromMinutes(10))
			{
				m_Component = c;

				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				if (m_Component != null && !m_Component.Deleted)
				{
					m_Component.UpdateImage();
				}
			}
		}
	}

	public class DisturbingPortrait1Addon : BaseAddon
	{
		public override BaseAddonDeed Deed => new DisturbingPortrait1Deed();

		[Constructable]
		public DisturbingPortrait1Addon() : base()
		{
			AddComponent(new DisturbingPortrait1Component(), 0, 0, 0);
		}

		public DisturbingPortrait1Addon(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	public class DisturbingPortrait1Deed : BaseAddonDeed
	{
		public override BaseAddon Addon => new DisturbingPortrait1Addon();
		public override int LabelNumber => 1074479;  // Disturbing portrait

		[Constructable]
		public DisturbingPortrait1Deed() : base()
		{
			LootType = LootType.Blessed;
		}

		public DisturbingPortrait1Deed(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// DisturbingPortrait2
	[Flipable(0x2A5D, 0x2A61)]
	public class DisturbingPortrait2Component : AddonComponent
	{
		public override int LabelNumber => 1074479;  // Disturbing portrait

		private Timer m_Timer;

		public DisturbingPortrait2Component() : base(0x2A5D)
		{
			m_Timer = Timer.DelayCall(TimeSpan.FromMinutes(3), TimeSpan.FromMinutes(3), Change);
		}

		public DisturbingPortrait2Component(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (Utility.InRange(Location, from.Location, 2))
			{
				Effects.PlaySound(Location, Map, Utility.RandomMinMax(0x567, 0x568));
			}
			else
			{
				from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
			}
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if (m_Timer != null && m_Timer.Running)
			{
				m_Timer.Stop();
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();

			m_Timer = Timer.DelayCall(TimeSpan.FromMinutes(3), TimeSpan.FromMinutes(3), Change);
		}

		private void Change()
		{
			if (ItemID < 0x2A61)
			{
				ItemID = Utility.RandomMinMax(0x2A5D, 0x2A60);
			}
			else
			{
				ItemID = Utility.RandomMinMax(0x2A61, 0x2A64);
			}
		}
	}

	public class DisturbingPortrait2Addon : BaseAddon
	{
		public override BaseAddonDeed Deed => new DisturbingPortrait2Deed();

		[Constructable]
		public DisturbingPortrait2Addon() : base()
		{
			AddComponent(new DisturbingPortrait2Component(), 0, 0, 0);
		}

		public DisturbingPortrait2Addon(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	public class DisturbingPortrait2Deed : BaseAddonDeed
	{
		public override BaseAddon Addon => new DisturbingPortrait2Addon();
		public override int LabelNumber => 1074479;  // Disturbing portrait

		[Constructable]
		public DisturbingPortrait2Deed() : base()
		{
			LootType = LootType.Blessed;
		}

		public DisturbingPortrait2Deed(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}