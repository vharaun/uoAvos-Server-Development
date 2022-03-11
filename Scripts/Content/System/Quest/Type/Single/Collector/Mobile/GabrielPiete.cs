using Server.Engines.Quests.Definitions;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Mobiles
{
	public class GabrielPiete : BaseQuester
	{
		[Constructable]
		public GabrielPiete() : base("the renowned minstrel")
		{
		}

		public GabrielPiete(Serial serial) : base(serial)
		{
		}

		public override void InitBody()
		{
			InitStats(100, 100, 25);

			Hue = 0x83EF;

			Female = false;
			Body = 0x190;
			Name = "Gabriel Piete";
		}

		public override void InitOutfit()
		{
			AddItem(new FancyShirt());
			AddItem(new LongPants(0x5F7));
			AddItem(new Shoes(0x5F7));

			HairItemID = 0x2049; // Pig Tails
			HairHue = 0x460;

			FacialHairItemID = 0x2041; // Mustache
			FacialHairHue = 0x460;
		}

		public override bool CanTalkTo(PlayerMobile to)
		{
			QuestSystem qs = to.Quest as CollectorQuest;

			if (qs == null)
			{
				return false;
			}

			return (qs.IsObjectiveInProgress(typeof(FindGabrielObjective_CollectorQuest))
				|| qs.IsObjectiveInProgress(typeof(FindSheetMusicObjective_CollectorQuest))
				|| qs.IsObjectiveInProgress(typeof(ReturnSheetMusicObjective_CollectorQuest))
				|| qs.IsObjectiveInProgress(typeof(ReturnAutographObjective_CollectorQuest)));
		}

		public override void OnTalk(PlayerMobile player, bool contextMenu)
		{
			var qs = player.Quest;

			if (qs is CollectorQuest)
			{
				Direction = GetDirectionTo(player);

				var obj = qs.FindObjective(typeof(FindGabrielObjective_CollectorQuest));

				if (obj != null && !obj.Completed)
				{
					obj.Complete();
				}
				else if (qs.IsObjectiveInProgress(typeof(FindSheetMusicObjective_CollectorQuest)))
				{
					qs.AddConversation(new GabrielNoSheetMusicConversation_CollectorQuest());
				}
				else
				{
					obj = qs.FindObjective(typeof(ReturnSheetMusicObjective_CollectorQuest));

					if (obj != null && !obj.Completed)
					{
						obj.Complete();
					}
					else if (qs.IsObjectiveInProgress(typeof(ReturnAutographObjective_CollectorQuest)))
					{
						qs.AddConversation(new GabrielIgnoreConversation_CollectorQuest());
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