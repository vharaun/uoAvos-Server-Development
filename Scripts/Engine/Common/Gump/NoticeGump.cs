using Server.Network;

using System;

namespace Server.Gumps
{
	public delegate void NoticeGumpCallback(Mobile from, object state);

	public delegate void NoticeGumpCallback<T>(Mobile from, T state);

	public class NoticeGump : NoticeGump<object>
	{
		public NoticeGump(int header, int headerColor, object content, int contentColor, int width, int height, NoticeGumpCallback callback, object state)
			: base(header, headerColor, content, contentColor, width, height, (m, s) => callback?.Invoke(m, s), state)
		{
		}
	}

	public class NoticeGump<T> : Gump
	{
		private readonly NoticeGumpCallback<T> m_Callback;
		private readonly T m_State;

		public NoticeGump(int header, int headerColor, object content, int contentColor, int width, int height, NoticeGumpCallback<T> callback, T state) 
			: base((640 - width) / 2, (480 - height) / 2)
		{
			m_Callback = callback;
			m_State = state;

			Closable = false;

			AddPage(0);

			AddBackground(0, 0, width, height, 5054);

			AddImageTiled(10, 10, width - 20, 20, 2624);
			AddAlphaRegion(10, 10, width - 20, 20);
			AddHtmlLocalized(10, 10, width - 20, 20, header, headerColor, false, false);

			AddImageTiled(10, 40, width - 20, height - 80, 2624);
			AddAlphaRegion(10, 40, width - 20, height - 80);

			if (content is int)
			{
				AddHtmlLocalized(10, 40, width - 20, height - 80, (int)content, contentColor, false, true);
			}
			else if (content is string)
			{
				AddHtml(10, 40, width - 20, height - 80, String.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", contentColor, content), false, true);
			}

			AddImageTiled(10, height - 30, width - 20, 20, 2624);
			AddAlphaRegion(10, height - 30, width - 20, 20);
			AddButton(10, height - 30, 4005, 4007, 1, GumpButtonType.Reply, 0);
			AddHtmlLocalized(40, height - 30, 120, 20, 1011036, 32767, false, false); // OKAY
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 1 && m_Callback != null)
			{
				m_Callback(sender.Mobile, m_State);
			}
		}
	}
}