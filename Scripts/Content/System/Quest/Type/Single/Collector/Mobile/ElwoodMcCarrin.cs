using Server.Engines.Quests.Definitions;
using Server.Engines.Quests.Items;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Mobiles
{
	public class ElwoodMcCarrin : BaseQuester
	{
		[Constructable]
		public ElwoodMcCarrin() : base("the well-known collector")
		{
		}

		public ElwoodMcCarrin(Serial serial) : base(serial)
		{
		}

		public override void InitBody()
		{
			InitStats(100, 100, 25);

			Hue = 0x83ED;

			Female = false;
			Body = 0x190;
			Name = "Elwood McCarrin";
		}

		public override void InitOutfit()
		{
			AddItem(new FancyShirt());
			AddItem(new LongPants(0x544));
			AddItem(new Shoes(0x454));
			AddItem(new JesterHat(0x4D2));
			AddItem(new FullApron(0x4D2));

			HairItemID = 0x203D; // Pony Tail
			HairHue = 0x47D;

			FacialHairItemID = 0x2040; // Goatee
			FacialHairHue = 0x47D;
		}

		public override void OnTalk(PlayerMobile player, bool contextMenu)
		{
			Direction = GetDirectionTo(player);

			var qs = player.Quest;

			if (qs is CollectorQuest)
			{
				if (qs.IsObjectiveInProgress(typeof(FishPearlsObjective_CollectorQuest)))
				{
					qs.AddConversation(new ElwoodDuringFishConversation_CollectorQuest());
				}
				else
				{
					var obj = qs.FindObjective(typeof(ReturnPearlsObjective_CollectorQuest));

					if (obj != null && !obj.Completed)
					{
						obj.Complete();
					}
					else if (qs.IsObjectiveInProgress(typeof(FindAlbertaObjective_CollectorQuest)))
					{
						qs.AddConversation(new ElwoodDuringPainting1Conversation_CollectorQuest());
					}
					else if (qs.IsObjectiveInProgress(typeof(SitOnTheStoolObjective_CollectorQuest)))
					{
						qs.AddConversation(new ElwoodDuringPainting2Conversation_CollectorQuest());
					}
					else
					{
						obj = qs.FindObjective(typeof(ReturnPaintingObjective_CollectorQuest));

						if (obj != null && !obj.Completed)
						{
							obj.Complete();
						}
						else if (qs.IsObjectiveInProgress(typeof(FindGabrielObjective_CollectorQuest)))
						{
							qs.AddConversation(new ElwoodDuringAutograph1Conversation_CollectorQuest());
						}
						else if (qs.IsObjectiveInProgress(typeof(FindSheetMusicObjective_CollectorQuest)))
						{
							qs.AddConversation(new ElwoodDuringAutograph2Conversation_CollectorQuest());
						}
						else if (qs.IsObjectiveInProgress(typeof(ReturnSheetMusicObjective_CollectorQuest)))
						{
							qs.AddConversation(new ElwoodDuringAutograph3Conversation_CollectorQuest());
						}
						else
						{
							obj = qs.FindObjective(typeof(ReturnAutographObjective_CollectorQuest));

							if (obj != null && !obj.Completed)
							{
								obj.Complete();
							}
							else if (qs.IsObjectiveInProgress(typeof(FindTomasObjective_CollectorQuest)))
							{
								qs.AddConversation(new ElwoodDuringToys1Conversation_CollectorQuest());
							}
							else if (qs.IsObjectiveInProgress(typeof(CaptureImagesObjective_CollectorQuest)))
							{
								qs.AddConversation(new ElwoodDuringToys2Conversation_CollectorQuest());
							}
							else if (qs.IsObjectiveInProgress(typeof(ReturnImagesObjective_CollectorQuest)))
							{
								qs.AddConversation(new ElwoodDuringToys3Conversation_CollectorQuest());
							}
							else
							{
								obj = qs.FindObjective(typeof(ReturnToysObjective_CollectorQuest));

								if (obj != null && !obj.Completed)
								{
									obj.Complete();

									if (GiveReward(player))
									{
										qs.AddConversation(new CollectorEndConversation_CollectorQuest());
									}
									else
									{
										qs.AddConversation(new FullEndConversation_CollectorQuest(true));
									}
								}
								else
								{
									obj = qs.FindObjective(typeof(MakeRoomObjective_CollectorQuest));

									if (obj != null && !obj.Completed)
									{
										if (GiveReward(player))
										{
											obj.Complete();
											qs.AddConversation(new CollectorEndConversation_CollectorQuest());
										}
										else
										{
											qs.AddConversation(new FullEndConversation_CollectorQuest(false));
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				QuestSystem newQuest = new CollectorQuest(player);

				if (qs == null && QuestSystem.CanOfferQuest(player, typeof(CollectorQuest)))
				{
					newQuest.SendOffer();
				}
				else
				{
					newQuest.AddConversation(new DontOfferConversation_CollectorQuest());
				}
			}
		}

		public bool GiveReward(Mobile to)
		{
			var bag = new Bag();

			bag.DropItem(new Gold(Utility.RandomMinMax(500, 1000)));

			if (Utility.RandomBool())
			{
				var weapon = Loot.RandomWeapon();

				if (Core.AOS)
				{
					BaseRunicTool.ApplyAttributesTo(weapon, 2, 20, 30);
				}
				else
				{
					weapon.DamageLevel = (WeaponDamageLevel)BaseCreature.RandomMinMaxScaled(2, 3);
					weapon.AccuracyLevel = (WeaponAccuracyLevel)BaseCreature.RandomMinMaxScaled(2, 3);
					weapon.DurabilityLevel = (WeaponDurabilityLevel)BaseCreature.RandomMinMaxScaled(2, 3);
				}

				bag.DropItem(weapon);
			}
			else
			{
				Item item;

				if (Core.AOS)
				{
					item = Loot.RandomArmorOrShieldOrJewelry();

					if (item is BaseArmor)
					{
						BaseRunicTool.ApplyAttributesTo((BaseArmor)item, 2, 20, 30);
					}
					else if (item is BaseJewel)
					{
						BaseRunicTool.ApplyAttributesTo((BaseJewel)item, 2, 20, 30);
					}
				}
				else
				{
					var armor = Loot.RandomArmorOrShield();
					item = armor;

					armor.ProtectionLevel = (ArmorProtectionLevel)BaseCreature.RandomMinMaxScaled(2, 3);
					armor.Durability = (ArmorDurabilityLevel)BaseCreature.RandomMinMaxScaled(2, 3);
				}

				bag.DropItem(item);
			}

			bag.DropItem(new Obsidian());

			if (to.PlaceInBackpack(bag))
			{
				return true;
			}
			else
			{
				bag.Delete();
				return false;
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