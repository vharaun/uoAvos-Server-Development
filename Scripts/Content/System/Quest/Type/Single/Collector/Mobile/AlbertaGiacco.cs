using Server.Engines.Quests.Definitions;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Mobiles
{
	public class AlbertaGiacco : BaseQuester
	{
		[Constructable]
		public AlbertaGiacco() : base("the respected painter")
		{
		}

		public AlbertaGiacco(Serial serial) : base(serial)
		{
		}

		public override void InitBody()
		{
			InitStats(100, 100, 25);

			Hue = 0x83F2;

			Female = true;
			Body = 0x191;
			Name = "Alberta Giacco";
		}

		public override void InitOutfit()
		{
			AddItem(new FancyShirt());
			AddItem(new Skirt(0x59B));
			AddItem(new Boots());
			AddItem(new FeatheredHat(0x59B));
			AddItem(new FullApron(0x59B));

			HairItemID = 0x203D; // Pony Tail
			HairHue = 0x457;
		}

		public override bool CanTalkTo(PlayerMobile to)
		{
			QuestSystem qs = to.Quest as CollectorQuest;

			if (qs == null)
			{
				return false;
			}

			return (qs.IsObjectiveInProgress(typeof(FindAlbertaObjective_CollectorQuest))
				|| qs.IsObjectiveInProgress(typeof(SitOnTheStoolObjective_CollectorQuest))
				|| qs.IsObjectiveInProgress(typeof(ReturnPaintingObjective_CollectorQuest)));
		}

		public override void OnTalk(PlayerMobile player, bool contextMenu)
		{
			var qs = player.Quest;

			if (qs is CollectorQuest)
			{
				Direction = GetDirectionTo(player);

				var obj = qs.FindObjective(typeof(FindAlbertaObjective_CollectorQuest));

				if (obj != null && !obj.Completed)
				{
					obj.Complete();
				}
				else if (qs.IsObjectiveInProgress(typeof(SitOnTheStoolObjective_CollectorQuest)))
				{
					qs.AddConversation(new AlbertaStoolConversation_CollectorQuest());
				}
				else if (qs.IsObjectiveInProgress(typeof(ReturnPaintingObjective_CollectorQuest)))
				{
					qs.AddConversation(new AlbertaAfterPaintingConversation_CollectorQuest());
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