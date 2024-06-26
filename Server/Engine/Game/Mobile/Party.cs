﻿namespace Server
{
	public interface IParty
	{
		void OnStamChanged(Mobile m);
		void OnManaChanged(Mobile m);
		void OnStatsQuery(Mobile beholder, Mobile beheld);
	}

	public abstract class PartyCommands
	{
		private static PartyCommands m_Handler;

		public static PartyCommands Handler { get => m_Handler; set => m_Handler = value; }

		public abstract void OnAdd(Mobile from);
		public abstract void OnRemove(Mobile from, Mobile target);
		public abstract void OnPrivateMessage(Mobile from, Mobile target, string text);
		public abstract void OnPublicMessage(Mobile from, string text);
		public abstract void OnSetCanLoot(Mobile from, bool canLoot);
		public abstract void OnAccept(Mobile from, Mobile leader);
		public abstract void OnDecline(Mobile from, Mobile leader);
	}
}