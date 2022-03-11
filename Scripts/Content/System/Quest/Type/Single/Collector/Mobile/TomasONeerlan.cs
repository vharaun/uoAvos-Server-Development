using Server.Engines.Quests.Definitions;
using Server.Engines.Quests.Items;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Mobiles
{
	public class TomasONeerlan : BaseQuester
	{
		[Constructable]
		public TomasONeerlan() : base("the famed toymaker")
		{
		}

		public TomasONeerlan(Serial serial) : base(serial)
		{
		}

		public override void InitBody()
		{
			InitStats(100, 100, 25);

			Hue = 0x83F8;

			Female = false;
			Body = 0x190;
			Name = "Tomas O'Neerlan";
		}

		public override void InitOutfit()
		{
			AddItem(new FancyShirt());
			AddItem(new LongPants(0x546));
			AddItem(new Boots(0x452));
			AddItem(new FullApron(0x455));

			HairItemID = 0x203B;    //ShortHair
			HairHue = 0x455;
		}

		public override bool CanTalkTo(PlayerMobile to)
		{
			QuestSystem qs = to.Quest as CollectorQuest;

			if (qs == null)
			{
				return false;
			}

			return (qs.IsObjectiveInProgress(typeof(FindTomasObjective_CollectorQuest))
				|| qs.IsObjectiveInProgress(typeof(CaptureImagesObjective_CollectorQuest))
				|| qs.IsObjectiveInProgress(typeof(ReturnImagesObjective_CollectorQuest)));
		}

		public override void OnTalk(PlayerMobile player, bool contextMenu)
		{
			var qs = player.Quest;

			if (qs is CollectorQuest)
			{
				Direction = GetDirectionTo(player);

				var obj = qs.FindObjective(typeof(FindTomasObjective_CollectorQuest));

				if (obj != null && !obj.Completed)
				{
					Item paints = new EnchantedPaints();

					if (!player.PlaceInBackpack(paints))
					{
						paints.Delete();
						player.SendLocalizedMessage(1046260); // You need to clear some space in your inventory to continue with the quest.  Come back here when you have more space in your inventory.
					}
					else
					{
						obj.Complete();
					}
				}
				else if (qs.IsObjectiveInProgress(typeof(CaptureImagesObjective_CollectorQuest)))
				{
					qs.AddConversation(new TomasDuringCollectingConversation_CollectorQuest());
				}
				else
				{
					obj = qs.FindObjective(typeof(ReturnImagesObjective_CollectorQuest));

					if (obj != null && !obj.Completed)
					{
						if (player.Backpack != null)
						{
							player.Backpack.ConsumeUpTo(typeof(EnchantedPaints), 1);
						}

						obj.Complete();
					}
				}
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