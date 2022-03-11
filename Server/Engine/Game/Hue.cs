using Server.Network;

using System;

namespace Server
{
	public interface IHued
	{
		int HuedItemID { get; }
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class HueAttribute : Attribute
	{
		public HueAttribute()
		{
		}
	}
}

namespace Server.HuePickers
{
	public class HuePicker
	{
		private static int m_NextSerial = 1;

		private readonly int m_Serial;
		private readonly int m_ItemID;

		public int Serial => m_Serial;

		public int ItemID => m_ItemID;

		public HuePicker(int itemID)
		{
			do
			{
				m_Serial = m_NextSerial++;
			} while (m_Serial == 0);

			m_ItemID = itemID;
		}

		public virtual void OnResponse(int hue)
		{
		}

		public void SendTo(NetState state)
		{
			state.Send(new DisplayHuePicker(this));
			state.AddHuePicker(this);
		}
	}
}