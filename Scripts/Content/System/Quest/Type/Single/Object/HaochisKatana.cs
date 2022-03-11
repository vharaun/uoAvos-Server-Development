using Server.Engines.Quests.Definitions;
using Server.Mobiles;

namespace Server.Engines.Quests.Items
{
	public class HaochisKatana : QuestItem
	{
		public override int LabelNumber => 1063165;  // Daimyo Haochi's Katana

		[Constructable]
		public HaochisKatana() : base(0x13FF)
		{
			Weight = 1.0;
		}

		public HaochisKatana(Serial serial) : base(serial)
		{
		}

		public override bool CanDrop(PlayerMobile player)
		{
			var qs = player.Quest as HaochisTrialsQuest;

			if (qs == null)
			{
				return true;
			}

			//return !qs.IsObjectiveInProgress( typeof( FifthTrialReturnObjective_HaochisTrialsQuest ) );
			return false;
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

	public class HaochisKatanaGenerator : Item
	{
		[Constructable]
		public HaochisKatanaGenerator() : base(0x1B7B)
		{
			Visible = false;
			Name = "Haochi's katana generator";
			Movable = false;
		}

		public override bool OnMoveOver(Mobile m)
		{
			var player = m as PlayerMobile;

			if (player != null)
			{
				var qs = player.Quest;

				if (qs is HaochisTrialsQuest)
				{
					if (HaochisTrialsQuest.HasLostHaochisKatana(player))
					{
						Item katana = new HaochisKatana();

						if (!player.PlaceInBackpack(katana))
						{
							katana.Delete();
							player.SendLocalizedMessage(1046260); // You need to clear some space in your inventory to continue with the quest.  Come back here when you have more space in your inventory.
						}
					}
					else
					{
						var obj = qs.FindObjective(typeof(FifthTrialIntroObjective_HaochisTrialsQuest));

						if (obj != null && !obj.Completed)
						{
							Item katana = new HaochisKatana();

							if (player.PlaceInBackpack(katana))
							{
								obj.Complete();
							}
							else
							{
								katana.Delete();
								player.SendLocalizedMessage(1046260); // You need to clear some space in your inventory to continue with the quest.  Come back here when you have more space in your inventory.
							}
						}
					}
				}
			}

			return base.OnMoveOver(m);
		}

		public HaochisKatanaGenerator(Serial serial) : base(serial)
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