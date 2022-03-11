using Server.Engines.Quests.Definitions;
using Server.Engines.Quests.Items;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Mobiles
{
	public class Haochi : BaseQuester
	{
		[Constructable]
		public Haochi() : base("the Honorable Samurai Legend")
		{
		}

		public override void InitBody()
		{
			InitStats(100, 100, 25);

			Hue = 0x8403;

			Female = false;
			Body = 0x190;
			Name = "Daimyo Haochi";
		}

		public override void InitOutfit()
		{
			HairItemID = 0x204A;
			HairHue = 0x901;

			AddItem(new SamuraiTabi());
			AddItem(new JinBaori());

			AddItem(new PlateHaidate());
			AddItem(new StandardPlateKabuto());
			AddItem(new PlateMempo());
			AddItem(new PlateDo());
			AddItem(new PlateHiroSode());
		}

		public override int GetAutoTalkRange(PlayerMobile pm)
		{
			return 2;
		}

		public override int TalkNumber => -1;

		public override void OnTalk(PlayerMobile player, bool contextMenu)
		{
			var qs = player.Quest;

			if (qs is HaochisTrialsQuest)
			{
				if (HaochisTrialsQuest.HasLostHaochisKatana(player))
				{
					qs.AddConversation(new LostSwordConversation_HaochisTrialsQuest());
					return;
				}

				var obj = qs.FindObjective(typeof(FindHaochiObjective_HaochisTrialsQuest));

				if (obj != null && !obj.Completed)
				{
					obj.Complete();
					return;
				}

				obj = qs.FindObjective(typeof(FirstTrialReturnObjective_HaochisTrialsQuest));

				if (obj != null && !obj.Completed)
				{
					player.AddToBackpack(new LeatherDo());
					obj.Complete();
					return;
				}

				obj = qs.FindObjective(typeof(SecondTrialReturnObjective_HaochisTrialsQuest));

				if (obj != null && !obj.Completed)
				{
					if (((SecondTrialReturnObjective_HaochisTrialsQuest)obj).Dragon)
					{
						player.AddToBackpack(new LeatherSuneate());
					}

					obj.Complete();
					return;
				}

				obj = qs.FindObjective(typeof(ThirdTrialReturnObjective_HaochisTrialsQuest));

				if (obj != null && !obj.Completed)
				{
					player.AddToBackpack(new LeatherHiroSode());
					obj.Complete();
					return;
				}

				obj = qs.FindObjective(typeof(FourthTrialReturnObjective_HaochisTrialsQuest));

				if (obj != null && !obj.Completed)
				{
					if (!((FourthTrialReturnObjective_HaochisTrialsQuest)obj).KilledCat)
					{
						var cont = GetNewContainer();
						cont.DropItem(new LeatherHiroSode());
						cont.DropItem(new JinBaori());
						player.AddToBackpack(cont);
					}

					obj.Complete();
					return;
				}

				obj = qs.FindObjective(typeof(FifthTrialReturnObjective_HaochisTrialsQuest));

				if (obj != null && !obj.Completed)
				{
					var pack = player.Backpack;
					if (pack != null)
					{
						var katana = pack.FindItemByType(typeof(HaochisKatana));
						if (katana != null)
						{
							katana.Delete();
							obj.Complete();

							obj = qs.FindObjective(typeof(FifthTrialIntroObjective_HaochisTrialsQuest));
							if (obj != null && ((FifthTrialIntroObjective_HaochisTrialsQuest)obj).StolenTreasure)
							{
								qs.AddConversation(new SixthTrialIntroConversation_HaochisTrialsQuest(true));
							}
							else
							{
								qs.AddConversation(new SixthTrialIntroConversation_HaochisTrialsQuest(false));
							}
						}
					}

					return;
				}

				obj = qs.FindObjective(typeof(SixthTrialReturnObjective_HaochisTrialsQuest));

				if (obj != null && !obj.Completed)
				{
					obj.Complete();
					return;
				}

				obj = qs.FindObjective(typeof(SeventhTrialReturnObjective_HaochisTrialsQuest));

				if (obj != null && !obj.Completed)
				{
					BaseWeapon weapon = new Daisho();
					BaseRunicTool.ApplyAttributesTo(weapon, Utility.Random(1, 3), 10, 30);
					player.AddToBackpack(weapon);

					BaseArmor armor = new LeatherDo();
					BaseRunicTool.ApplyAttributesTo(armor, Utility.Random(1, 3), 10, 20);
					player.AddToBackpack(armor);

					obj.Complete();
					return;
				}
			}
		}

		public Haochi(Serial serial) : base(serial)
		{
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