using Server.Mobiles;

namespace Server.ContextMenus
{
	public class OpenBankEntry : ContextMenuEntry
	{
		private readonly Mobile m_Banker;

		public OpenBankEntry(Mobile from, Mobile banker) : base(6105, 12)
		{
			m_Banker = banker;
		}

		public override void OnClick()
		{
			if (!Owner.From.CheckAlive())
			{
				return;
			}

			if (Owner.From.Criminal)
			{
				m_Banker.Say(500378); // Thou art a criminal and cannot access thy bank box.
			}
			else
			{
				Owner.From.BankBox.Open();
			}
		}
	}

	public class TeachEntry : ContextMenuEntry
	{
		private readonly SkillName m_Skill;
		private readonly BaseCreature m_Mobile;
		private readonly Mobile m_From;

		public TeachEntry(SkillName skill, BaseCreature m, Mobile from, bool enabled) : base(6000 + (int)skill)
		{
			m_Skill = skill;
			m_Mobile = m;
			m_From = from;

			if (!enabled)
			{
				Flags |= Network.CMEFlags.Disabled;
			}
		}

		public override void OnClick()
		{
			if (!m_From.CheckAlive())
			{
				return;
			}

			m_Mobile.Teach(m_Skill, m_From, 0, false);
		}
	}
}