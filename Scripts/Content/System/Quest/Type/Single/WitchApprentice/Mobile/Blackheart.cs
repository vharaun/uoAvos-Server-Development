using Server.Engines.Quests.Definitions;
using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.Quests.Mobiles
{
	public class Blackheart : BaseQuester
	{
		[Constructable]
		public Blackheart() : base("the Drunken Pirate")
		{
		}

		public Blackheart(Serial serial) : base(serial)
		{
		}

		public override void InitBody()
		{
			InitStats(100, 100, 25);

			Hue = 0x83EF;

			Female = false;
			Body = 0x190;
			Name = "Captain Blackheart";
		}

		public override void InitOutfit()
		{
			AddItem(new FancyShirt());
			AddItem(new LongPants(0x66D));
			AddItem(new ThighBoots());
			AddItem(new TricorneHat(0x1));
			AddItem(new BodySash(0x66D));

			var gloves = new LeatherGloves {
				Hue = 0x66D
			};
			AddItem(gloves);

			FacialHairItemID = 0x203E; // Long Beard
			FacialHairHue = 0x455;

			Item sword = new Cutlass {
				Movable = false
			};
			AddItem(sword);
		}

		public override void OnTalk(PlayerMobile player, bool contextMenu)
		{
			Direction = GetDirectionTo(player);
			Animate(33, 20, 1, true, false, 0);

			var qs = player.Quest;

			if (qs is WitchApprenticeQuest)
			{
				var obj = qs.FindObjective(typeof(FindIngredientObjective_WitchApprenticeQuest)) as FindIngredientObjective_WitchApprenticeQuest;

				if (obj != null && !obj.Completed && obj.Ingredient == Ingredient.Whiskey)
				{
					PlaySound(Utility.RandomBool() ? 0x42E : 0x43F);

					var hat = player.FindItemOnLayer(Layer.Helm);
					var tricorne = hat is TricorneHat;

					if (tricorne && player.BAC >= 20)
					{
						obj.Complete();

						if (obj.BlackheartMet)
						{
							qs.AddConversation(new BlackheartPirateConversation_WitchApprenticeQuest(false));
						}
						else
						{
							qs.AddConversation(new BlackheartPirateConversation_WitchApprenticeQuest(true));
						}
					}
					else if (!obj.BlackheartMet)
					{
						obj.Complete();

						qs.AddConversation(new BlackheartFirstConversation_WitchApprenticeQuest());
					}
					else
					{
						qs.AddConversation(new BlackheartNoPirateConversation_WitchApprenticeQuest(tricorne, player.BAC > 0));
					}

					return;
				}
			}

			PlaySound(0x42C);
			SayTo(player, 1055041); // The drunken pirate shakes his fist at you and goes back to drinking.
		}

		private void Heave()
		{
			PublicOverheadMessage(Network.MessageType.Regular, 0x3B2, 500849); // *hic*

			Timer.DelayCall(TimeSpan.FromSeconds(Utility.RandomMinMax(60, 180)), new TimerCallback(Heave));
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

			Heave();
		}
	}
}