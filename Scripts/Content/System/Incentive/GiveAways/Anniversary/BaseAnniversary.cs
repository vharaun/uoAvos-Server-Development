using Server.Items;
using Server.Misc;

using System;

#region Developer Notations

/// This Incentive Celebrates Each FULL Year The Server Is Running!
/// The Dates Below Need To Change After Each Anniversary. 
/// This Script Is Merely A Template To Get Everyone Started...

#endregion

namespace Server.Events.Anniversary
{
	public class AnniversaryGiftGiver : GiftGiver
	{
		public static void Initialize()
		{
			GiftGiving.Register(new AnniversaryGiftGiver());
		}

		public override DateTime Start => new DateTime(2023, 01, 01);

		public override DateTime Finish => new DateTime(2023, 01, 31);

		public override void GiveGift(Mobile mob)
		{
			var box = new GiftBox();

			#region Anniversary Gift Rewards

			box.DropItem(new AnniversaryGiftBox001());

			#endregion

			switch (GiveGift(mob, box))
			{
				case GiftResult.Backpack:
					{
						mob.SendMessage(0x482, "Happy Anniversary from the team! A gift has been placed in your backpack.");
						break;
					}
				case GiftResult.BankBox:
					{
						mob.SendMessage(0x482, "Happy Anniversary from the team! A gift has been placed in your bankbox.");
						break;
					}
			}
		}
	}
}