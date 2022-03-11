using Server.Engines.Quests.Definitions;
using Server.Engines.Quests.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Mobiles
{
	public abstract class BaseAmbitiousSolenQueen : BaseQuester
	{
		public abstract bool RedSolen { get; }

		public override bool DisallowAllMoves => false;

		public BaseAmbitiousSolenQueen()
		{
		}

		public override void InitBody()
		{
			Name = "an ambitious solen queen";

			Body = 0x30F;

			if (!RedSolen)
			{
				Hue = 0x453;
			}

			SpeechHue = 0;
		}

		public override int GetIdleSound()
		{
			return 0x10D;
		}

		public override void OnTalk(PlayerMobile player, bool contextMenu)
		{
			Direction = GetDirectionTo(player);

			var qs = player.Quest as AmbitiousQueenQuest;

			if (qs != null && qs.RedSolen == RedSolen)
			{
				if (qs.IsObjectiveInProgress(typeof(KillQueensObjective_AmbitiousQueenQuest)))
				{
					qs.AddConversation(new DuringKillQueensConversation_AmbitiousQueenQuest());
				}
				else
				{
					var obj = qs.FindObjective(typeof(ReturnAfterKillsObjective_AmbitiousQueenQuest));

					if (obj != null && !obj.Completed)
					{
						obj.Complete();
					}
					else if (qs.IsObjectiveInProgress(typeof(GatherFungiObjective_AmbitiousQueenQuest)))
					{
						qs.AddConversation(new DuringFungiGatheringConversation_AmbitiousQueenQuest());
					}
					else
					{
						var lastObj = qs.FindObjective(typeof(GetRewardObjective_AmbitiousQueenQuest)) as GetRewardObjective_AmbitiousQueenQuest;

						if (lastObj != null && !lastObj.Completed)
						{
							var bagOfSending = lastObj.BagOfSending;
							var powderOfTranslocation = lastObj.PowderOfTranslocation;
							var gold = lastObj.Gold;

							AmbitiousQueenQuest.GiveRewardTo(player, ref bagOfSending, ref powderOfTranslocation, ref gold);

							lastObj.BagOfSending = bagOfSending;
							lastObj.PowderOfTranslocation = powderOfTranslocation;
							lastObj.Gold = gold;

							if (!bagOfSending && !powderOfTranslocation && !gold)
							{
								lastObj.Complete();
							}
							else
							{
								qs.AddConversation(new FullBackpackConversation_AmbitiousQueenQuest(false, lastObj.BagOfSending, lastObj.PowderOfTranslocation, lastObj.Gold));
							}
						}
					}
				}
			}
			else
			{
				QuestSystem newQuest = new AmbitiousQueenQuest(player, RedSolen);

				if (player.Quest == null && QuestSystem.CanOfferQuest(player, typeof(AmbitiousQueenQuest)))
				{
					newQuest.SendOffer();
				}
				else
				{
					newQuest.AddConversation(new DontOfferConversation_AmbitiousQueenQuest());
				}
			}
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			Direction = GetDirectionTo(from);

			var player = from as PlayerMobile;

			if (player != null)
			{
				var qs = player.Quest as AmbitiousQueenQuest;

				if (qs != null && qs.RedSolen == RedSolen)
				{
					var obj = qs.FindObjective(typeof(GatherFungiObjective_AmbitiousQueenQuest));

					if (obj != null && !obj.Completed)
					{
						if (dropped is ZoogiFungus)
						{
							var fungi = (ZoogiFungus)dropped;

							if (fungi.Amount >= 50)
							{
								obj.Complete();

								fungi.Amount -= 50;

								if (fungi.Amount == 0)
								{
									fungi.Delete();
									return true;
								}
								else
								{
									return false;
								}
							}
							else
							{
								SayTo(player, 1054072); // Our arrangement was for 50 of the zoogi fungus. Please return to me when you have that amount.
								return false;
							}
						}
					}
				}
			}

			return base.OnDragDrop(from, dropped);
		}

		public BaseAmbitiousSolenQueen(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	public class RedAmbitiousSolenQueen : BaseAmbitiousSolenQueen
	{
		public override bool RedSolen => true;

		[Constructable]
		public RedAmbitiousSolenQueen()
		{
		}

		public RedAmbitiousSolenQueen(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	public class BlackAmbitiousSolenQueen : BaseAmbitiousSolenQueen
	{
		public override bool RedSolen => false;

		[Constructable]
		public BlackAmbitiousSolenQueen()
		{
		}

		public BlackAmbitiousSolenQueen(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}