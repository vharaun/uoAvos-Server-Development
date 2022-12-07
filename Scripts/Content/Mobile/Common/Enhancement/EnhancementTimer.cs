// Created by Peoharen

using System;
using System.Collections.Generic;

namespace Server.Items
{
	public class EnhancementTimer : Timer
	{
		private readonly Dictionary<Enum, int> m_List = new();

		private readonly Mobile m_Mobile;
		private readonly string m_Title;

		public EnhancementTimer(Mobile m, int duration, string title, params (Enum, int)[] args)
			: base(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1), duration)
		{
			m_Mobile = m;
			m_Title = title;

			foreach (var (attr, number) in args)
			{
				if (attr is AosAttribute a1)
				{
					Enhancement.SetValue(m, a1, Enhancement.GetValue(m, a1) + number, m_Title);
				}
				else if (attr is AosWeaponAttribute a2)
				{
					Enhancement.SetValue(m, a2, Enhancement.GetValue(m, a2) + number, m_Title);
				}
				else if (attr is AosArmorAttribute a3)
				{
					Enhancement.SetValue(m, a3, Enhancement.GetValue(m, a3) + number, m_Title);
				}
				else
				{
					continue;
				}

				m_List[attr] = number;
			}

			Enhancement.AddMobile(m);
		}

		public void End()
		{
			Stop();

			if (m_Mobile != null && Enhancement.EnhancementList.ContainsKey(m_Mobile))
			{
				foreach (var (attr, number) in m_List)
				{
					if (attr is AosAttribute a1)
					{
						Enhancement.SetValue(m_Mobile, a1, Enhancement.GetValue(m_Mobile, a1) - number, m_Title);
					}
					else if (attr is AosWeaponAttribute a2)
					{
						Enhancement.SetValue(m_Mobile, a2, Enhancement.GetValue(m_Mobile, a2) - number, m_Title);
					}
					else if (attr is AosArmorAttribute a3)
					{
						Enhancement.SetValue(m_Mobile, a3, Enhancement.GetValue(m_Mobile, a3) - number, m_Title);
					}
				}
			}
		}

		protected override void OnTick()
		{
			if (TickIndex >= TickCount)
			{
				End();
			}
		}
	}
}