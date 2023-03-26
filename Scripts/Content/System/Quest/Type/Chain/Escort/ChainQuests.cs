using Server.Items;

namespace Server.Engines.ChainQuests.Definitions
{
	public class TownEscort : EscortQuest
	{
		// Escort reward
		private static readonly BaseReward m_Reward = new ItemReward("Gold", typeof(Gold), 500);

		public TownEscort(int title, int progress, int destination, string region)
		{
			Activated = true;
			Title = title;
			Description = 1072287; // I seek a worthy escort.  I can offer some small pay to any able bodied adventurer who can assist me.  It is imperative that I reach my destination.
			RefusalMessage = 1072288; // I wish you would reconsider my offer.  I'll be waiting right here for someone brave enough to assist me.
			InProgressMessage = progress;

			Objectives.Add(new EscortObjective(new QuestArea(destination, region)));

			Rewards.Add(m_Reward);
		}
	}

	public class NewHavenEscort : EscortQuest
	{
		// Escort reward
		private static readonly BaseReward m_Reward = new ItemReward("Gold", typeof(Gold), 500);

		public NewHavenEscort(int title, int description, int progress, int destination, string region)
		{
			Activated = true;
			Title = title;
			Description = description;
			RefusalMessage = 1072288; // I wish you would reconsider my offer.  I'll be waiting right here for someone brave enough to assist me.
			InProgressMessage = progress;

			Objectives.Add(new EscortObjective(new QuestArea(destination, region)));

			Rewards.Add(m_Reward);
		}
	}
}