using Server.Gumps;
using Server.Mobiles;
using Server.Network;

using System;
using System.Collections.Generic;

#region Developer Notations

/// If you create a new reward category or rarity then you need to input below: 
/// see commented-out examples for "Junk" and "Currency"   
///
/// For most items you only need to input the Type and description and just leave the "null, 0, 0" alone
///
/// If there's an item that need a constructor parameter, like gold, 
/// then you can do (typeof(Gold), null, 100, 0 "100 Gold Coins") ... 
/// 100 being the amount of gold that would normally be entered like Gold gold = new Gold(100);
///
/// The reason for using typeof is so 
/// 1) new items aren't generated when a card is flipped and potentially left in limbo if never redeemed
/// 2) a new item is actually generated if two of the same item happen to be rewarded
/// 3) the more reward options you add to the lists the less the same reward is redeemed

#endregion

namespace Server.Items
{
	public class SovereignCrate : Item
	{
		private int m_NumberOfCards;

		[CommandProperty(AccessLevel.GameMaster)]
		public int NumberOfCards
		{
			get => m_NumberOfCards;
			set { m_NumberOfCards = value; InvalidateProperties(); }
		}

		/// List that keeps track of what cards have been flipped and their respective reward
		public List<Tuple<int, Item, RewardType, RewardRarity, string>> CardList = new List<Tuple<int, Item, RewardType, RewardRarity, string>>();

		[Constructable]
		public SovereignCrate() : base(11764)
		{
			Name = "Crown Crate";
			LootType = LootType.Blessed;

			if (0.3 > Utility.RandomDouble()) // 30% chance to give 5 cards instead of 4
			{
				NumberOfCards = 5;
			}
			else
			{
				NumberOfCards = 4;
			}
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1042001);
			}
			else
			{
				from.SendGump(new SovereignCrateGump(from, this));
			}
		}

		public SovereignCrate(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_NumberOfCards);

			writer.Write(CardList.Count);
			for (var i = 0; i < CardList.Count; i++)
			{
				writer.Write(CardList[i].Item1);    // Card Number
				writer.Write(CardList[i].Item2);         // Item
				writer.Write((int)CardList[i].Item3);    // RewardType
				writer.Write((int)CardList[i].Item4);    // RewardRarity
				writer.Write(CardList[i].Item5); // Description
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			m_NumberOfCards = reader.ReadInt();

			var count = reader.ReadInt();

			CardList = new List<Tuple<int, Item, RewardType, RewardRarity, string>>();

			for (var i = 0; i < count; i++)
			{
				CardList.Add(new Tuple<int, Item, RewardType, RewardRarity, string>(reader.ReadInt(), reader.ReadItem(), (RewardType)reader.ReadInt(), (RewardRarity)reader.ReadInt(), reader.ReadString()));
			}
		}
	}

	public class SovereignCrateGump : Gump
	{
		/// If you create a new reward category or rarity then you need to input below: 
		/// see commented-out examples for "Junk" and "Currency"   

		private readonly Mobile caller;
		private readonly SovereignCrate m_Crate;

		private const int ContinueButton = 99999;

		public SovereignCrateGump(Mobile from, SovereignCrate crate) : base(0, 0)
		{
			m_Crate = crate;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);

			AddImageTiled(0, 0, m_Crate.NumberOfCards == 4 ? 895 : 1120, 550, 1759); // 0x6df
			AddAlphaRegion(0, 0, m_Crate.NumberOfCards == 4 ? 895 : 1120, 550);
			AddButton(20, 20, 3, 3, 0, GumpButtonType.Reply, 0); // Close button

			/// Unchosen Cards
			for (var i = 0; i < m_Crate.NumberOfCards; i++)
			{
				AddBackground(10 + (i * 220), 100, 215, 280, 1579); // Card background

				// Prevent buttons from appearing behind cards that have been selected
				if (!m_Crate.CardList.Exists(x => x.Item1 == i))
				{
					AddButton(60 + (i * 220), 150, 30502, 30502, i + 1, GumpButtonType.Reply, 0); // Card back design pattern
				}
			}

			/// Selected Cards
			if (m_Crate.CardList.Count > 0)
			{
				for (var j = 0; j < m_Crate.CardList.Count; j++)
				{
					var hue = 0;

					switch (m_Crate.CardList[j].Item4)
					{
						#region Adding New Rarities And Circle Hues

						/// case RewardRarity.Junk: 
						/// hue = 5; // Sets hue of the circle on the card face
						/// break;

						#endregion

						case RewardRarity.Normal:
							hue = 1165; // Sets hue of the circle on the card face
							break;
						case RewardRarity.Rare:
							hue = 1167; // Sets hue of the circle on the card face
							break;
						case RewardRarity.Legendary:
							hue = 1161; // Sets hue of the circle on the card face
							break;
					}

					var icon = 0;
					var category = "";
					var cardface = 0;

					// Sets the icon inside the circle, the card face gump id, and the category name that appears above each flipped card
					switch (m_Crate.CardList[j].Item3)
					{
						#region Adding New Reward Type Category

						/// case RewardType.Currency:
						///     icon = 110; 
						///     category = "Currency";
						///     cardface = 30511;
						///     break;

						#endregion

						case RewardType.Armor:
							icon = 111; // Anhk
							category = "Armor";
							cardface = 30504;
							break;
						case RewardType.Weapon:
							icon = 112; // Sword
							category = "Weapon";
							cardface = 30503;
							break;
						case RewardType.Pet:
							icon = 108; // Shepherd's Crook
							category = "Pet";
							cardface = 30506;
							break;
						case RewardType.Cosmetic:
							icon = 109; //Scales
							category = "Cosmetic";
							cardface = 30510;
							break;
					}

					AddHtml(30 + (m_Crate.CardList[j].Item1 * 220), 58, 175, 24, "<center><big>" + category + "</big></center>", true, false); // Reward category
					AddBackground(30 + (m_Crate.CardList[j].Item1 * 220), 120, 175, 240, 83); // card background
					AddHtml(30 + (m_Crate.CardList[j].Item1 * 220), 390, 175, 45, "<center>" + m_Crate.CardList[j].Item5 + "</center>", true, false); // Reward description            
					AddImage(60 + (m_Crate.CardList[j].Item1 * 220), 150, cardface);   // Card "face"
					AddImage(12 + (m_Crate.CardList[j].Item1 * 220), 102, 1417, hue);  // Circle in upper left of card
					AddImage(19 + (m_Crate.CardList[j].Item1 * 220), 111, icon, 2056); // Icon in the circle

				}
			}

			//all cards have been flipped
			if (m_Crate.CardList.Count == m_Crate.NumberOfCards)
			{
				AddBackground(m_Crate.NumberOfCards == 4 ? 365 : 585, 450, 500, 75, 5100); // Background for continue button
				AddButton(m_Crate.NumberOfCards == 4 ? 390 : 610, 475, 5042, 5042, ContinueButton, GumpButtonType.Reply, 0); // Continue button to drop all items to backpack
				AddHtml(m_Crate.NumberOfCards == 4 ? 517 : 737, 473, 308, 27, "<big>  Redeem All Rewards", true, false); // Reward description
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			if (info.ButtonID == ContinueButton)
			{
				if (m_Crate.CardList.Count != m_Crate.NumberOfCards)
				{
					/// Should not be seen unless there is an exploit found
					from.SendMessage("You have not flipped all the cards!");
					return;
				}

				else
				{
					for (var k = 0; k < m_Crate.CardList.Count; k++)
					{
						var item = m_Crate.CardList[k].Item2;

						if (item != null)
						{
							var pack = from.Backpack;
							pack.DropItem(item);
						}
					}
				}

				from.CloseGump(typeof(SovereignCrateGump)); // Ensure that the gump is closed
				m_Crate.Delete(); // Delete the crown crate now that the items have been redeemed
			}

			else if (info.ButtonID > 0)
			{
				#region Randomize Reward Type and Rarity

				var randomRewardType = Utility.RandomMinMax(0, 4); // Change 4 (max number) if you add new types or rarities
				var randomRarity = Utility.RandomMinMax(0, 3);

				var randomType = RewardType.Cosmetic;
				var rarity = RewardRarity.Normal;

				switch (randomRewardType)
				{
					#region Randomize New Reward Type Category

					/// case 4: randomType = RewardType.Currency;
					///         break;

					#endregion

					case 0:
						randomType = RewardType.Armor;
						break;
					case 1:
						randomType = RewardType.Weapon;
						break;
					case 2:
						randomType = RewardType.Pet;
						break;
					case 3:
						randomType = RewardType.Cosmetic;
						break;
				}

				switch (randomRarity)
				{
					#region Randomize New Reward Type Rarities

					/// case 3: rarity = RewardType.Junk;
					///         break;

					#endregion

					case 0:
						rarity = RewardRarity.Normal;
						break;
					case 1:
						rarity = RewardRarity.Rare;
						break;
					case 2:
						rarity = RewardRarity.Legendary;
						break;
				}

				#endregion

				#region Take Reward Type and Rarity and Pull A Random Reward From The Lists

				var list = SovereignCrateRewardLists.Armor_Normal;

				#region Assigning New Reward Categories

				/// else if(randomType == RewardType.Currency) // New Reward Category: "Currency"
				/// {
				///     switch(rarity)
				///     {
				///         case RewardRarity.Junk: // New Rarity Type: "Junk"
				///             list = SovereignCrateRewardLists.Currency_Junk;
				///             break;
				///         case RewardRarity.Normal: 
				///             list = SovereignCrateRewardLists.Currency_Normal;
				///             break;
				///         case RewardRarity.Rare:
				///             list = SovereignCrateRewardLists.Currency_Rare;
				///             break;
				///         case RewardRarity.Legendary:
				///             list = SovereignCrateRewardLists.Currency_Legendary;
				///             break;
				///     }
				/// } 

				#endregion

				// Select a random item off the Reward List
				if (randomType == RewardType.Armor)
				{
					switch (rarity)
					{
						case RewardRarity.Normal:
							list = SovereignCrateRewardLists.Armor_Normal;
							break;
						case RewardRarity.Rare:
							list = SovereignCrateRewardLists.Armor_Rare;
							break;
						case RewardRarity.Legendary:
							list = SovereignCrateRewardLists.Armor_Legendary;
							break;
					}
				}
				else if (randomType == RewardType.Weapon)
				{
					switch (rarity)
					{
						case RewardRarity.Normal:
							list = SovereignCrateRewardLists.Weapon_Normal;
							break;
						case RewardRarity.Rare:
							list = SovereignCrateRewardLists.Weapon_Rare;
							break;
						case RewardRarity.Legendary:
							list = SovereignCrateRewardLists.Weapon_Legendary;
							break;
					}
				}
				else if (randomType == RewardType.Pet)
				{
					switch (rarity)
					{
						case RewardRarity.Normal:
							list = SovereignCrateRewardLists.Pet_Normal;
							break;
						case RewardRarity.Rare:
							list = SovereignCrateRewardLists.Pet_Rare;
							break;
						case RewardRarity.Legendary:
							list = SovereignCrateRewardLists.Pet_Legendary;
							break;
					}
				}
				else if (randomType == RewardType.Cosmetic)
				{
					switch (rarity)
					{
						case RewardRarity.Normal:
							list = SovereignCrateRewardLists.Cosmetic_Normal;
							break;
						case RewardRarity.Rare:
							list = SovereignCrateRewardLists.Cosmetic_Rare;
							break;
						case RewardRarity.Legendary:
							list = SovereignCrateRewardLists.Cosmetic_Legendary;
							break;
					}
				}

				Item rewardItem;

				var randomListEntry = new Random();
				var index = randomListEntry.Next(list.Count);

				// Input parameters as part of a pet deed creation
				if (list == SovereignCrateRewardLists.Pet_Normal || list == SovereignCrateRewardLists.Pet_Rare || list == SovereignCrateRewardLists.Pet_Legendary)
				{
					rewardItem = Activator.CreateInstance(list[index].Item1, new object[] { list[index].Item2, list[index].Item3, list[index].Item4 }) as Item;
				}
				// Parameters aren't needed to create the item
				else
				{
					rewardItem = Activator.CreateInstance(list[index].Item1) as Item;
				}

				#endregion

				var description = list[index].Item5;

				if (rewardItem is PetDeed)
				{
					var deed = (PetDeed)rewardItem;
				}

				m_Crate.CardList.Add(new Tuple<int, Item, RewardType, RewardRarity, string>(info.ButtonID - 1, rewardItem, randomType, rarity, description));
				from.SendGump(new SovereignCrateGump(from, m_Crate));
			}

		}
	}

	#region SovereignCrate Reward Registry

	public enum RewardType
	{
		Armor,
		Weapon,
		Pet,
		Cosmetic
	}

	public enum RewardRarity
	{
		Normal,
		Rare,
		Legendary
	}

	public class SovereignCrateRewardLists
	{
		#region Adding A New Reward List

		/// public static List<Tuple<Type,Type,int,int,string>> Currency_Normal = new List<Tuple<Type, Type, int, int, string>>
		/// {
		///     (new Tuple<Type,Type,int,int,string>( typeof(Gold), null, 10, 0, "10 Gold Coins" ) ),
		///     (new Tuple<Type,Type,int,int,string>( typeof(Gold), null, 100, 0, "100 Gold Coins" ) )
		/// };
		/// 
		/// public static List<Tuple<Type, Type, int, int, string>> Currency_Rare = new List<Tuple<Type, Type, int, int, string>>
		/// {
		///     (new Tuple<Type,Type,int,int,string>( typeof(Gold), null, 10000, 0, "10,000 Gold Coins" ) ),
		///     (new Tuple<Type,Type,int,int,string>( typeof(Gold), null, 100000, 0, "100,000 Gold Coins" ) )
		/// };
		/// 
		/// public static List<Tuple<Type, Type, int, int, string>> Currency_Legendary = new List<Tuple<Type, Type, int, int, string>>
		/// {
		///     (new Tuple<Type,Type,int,int,string>( typeof(Gold), null, 1000000, 0, "1,000,000 Gold Coins" ) ),
		///     (new Tuple<Type,Type,int,int,string>( typeof(Gold), null, 10000000, 0, "10,000,000 Gold Coins" ) )
		/// };
		/// public static List<Tuple<Type, Type, int, int, string>> Currency_Junk = new List<Tuple<Type, Type, int, int, string>>
		/// {
		///     (new Tuple<Type,Type,int,int,string>( typeof(Gold), null, 1, 0, "1 Gold Coin" ) ),
		///     (new Tuple<Type,Type,int,int,string>( typeof(Gold), null, 3, 0, "3 Gold Coins" ) )
		/// };

		#endregion

		/// Reward Type: Armor List
		public static List<Tuple<Type, Type, int, int, string>> Armor_Normal = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type,Type,int,int,string>( typeof(LeatherChest), null, 0, 0, "Leather Chest" ) ),
			(new Tuple<Type,Type,int,int,string>( typeof(LeatherNinjaJacket), null, 0, 0, "Leather Ninja Jacket" ) )
		};

		public static List<Tuple<Type, Type, int, int, string>> Armor_Rare = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type,Type,int,int,string>( typeof(ArmorOfFortune), null, 0, 0, "Armor Of Fortune" ) ),
			(new Tuple<Type,Type,int,int,string>( typeof(GauntletsOfNobility), null, 0, 0, "Gauntlets Of Nobility" ) )
		};

		public static List<Tuple<Type, Type, int, int, string>> Armor_Legendary = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type,Type,int,int,string>( typeof(LeggingsOfBane), null, 0, 0, "Leggings Of Bane" ) ),
			(new Tuple<Type,Type,int,int,string>( typeof(MidnightBracers), null, 0, 0, "Midnight Bracers" ) )
		};


		/// Reward Type: Weapon List
		public static List<Tuple<Type, Type, int, int, string>> Weapon_Normal = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type,Type,int,int,string>( typeof(Katana), null, 0, 0, "Katana" ) ),
			(new Tuple<Type,Type,int,int,string>( typeof(Dagger), null, 0, 0, "Dagger" ) )
		};

		public static List<Tuple<Type, Type, int, int, string>> Weapon_Rare = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type,Type,int,int,string>( typeof(BladeOfInsanity), null, 0, 0, "Blade Of Insanity" ) ),
			(new Tuple<Type,Type,int,int,string>( typeof(NightsKiss), null, 0, 0, "NightsKiss" ) )
		};

		public static List<Tuple<Type, Type, int, int, string>> Weapon_Legendary = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type,Type,int,int,string>( typeof(AxeOfTheHeavens), null, 0, 0, "Axe of the Heavens" ) ),
			(new Tuple<Type,Type,int,int,string>( typeof(TheTaskmaster), null, 0, 0, "The Taskmaster" ) )
		};


		/// Reward Type: Animal List
		/// Format: PetDeed, typeof Mobile, Stat Bonus, Skill Bonus, String Description
		public static List<Tuple<Type, Type, int, int, string>> Pet_Normal = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type, Type, int, int, string>( typeof(PetDeed), typeof(Cow), 0,0, "An Ordinary Cow" ) ),
			(new Tuple<Type, Type, int, int, string>( typeof(PetDeed), typeof(Chicken), 0,0, "An Ordinary Chicken" ) )
		};

		public static List<Tuple<Type, Type, int, int, string>> Pet_Rare = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type, Type, int, int, string>( typeof(PetDeed), typeof(Cow), 10,10, "Rare Cow" ) ),
			(new Tuple<Type, Type, int, int, string>( typeof(PetDeed), typeof(Chicken), 10,10, "Rare Chicken" ) )
		};

		public static List<Tuple<Type, Type, int, int, string>> Pet_Legendary = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type, Type, int, int, string>( typeof(PetDeed), typeof(Cow), 100,100, "Legendary Cow" ) ),
			(new Tuple<Type, Type, int, int, string>( typeof(PetDeed), typeof(Chicken), 100,100, "Legendary Chicken" ) )
		};


		/// Reward Type: Cosmetic List
		public static List<Tuple<Type, Type, int, int, string>> Cosmetic_Normal = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type,Type,int,int,string>( typeof(RockArtifact), null, 0, 0, "A decorative rock" ) ),
			(new Tuple<Type,Type,int,int,string>( typeof(SkullCandleArtifact), null, 0, 0, "Skull Candle" ) )
		};

		public static List<Tuple<Type, Type, int, int, string>> Cosmetic_Rare = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type,Type,int,int,string>( typeof(StuddedLeggingsArtifact), null, 0, 0, "Unwearable Leggings" ) ),
			(new Tuple<Type,Type,int,int,string>( typeof(TarotCardsArtifact), null, 0, 0, "Tarot Cards" ) )
		};

		public static List<Tuple<Type, Type, int, int, string>> Cosmetic_Legendary = new List<Tuple<Type, Type, int, int, string>>
		{
			(new Tuple<Type,Type,int,int,string>( typeof(SaddleArtifact), null, 0, 0, "A decorative saddle" ) ),
			(new Tuple<Type,Type,int,int,string>( typeof(RuinedPaintingArtifact), null, 0, 0, "A ruined painting" ) )
		};
	}

	public class PetDeed : Item
	{
		private Type m_BaseCreatureType;
		private double m_StatsScalar;
		private double m_SkillsScalar;

		[CommandProperty(AccessLevel.GameMaster)]
		public Type BaseCreatureType
		{
			get => m_BaseCreatureType;
			set { m_BaseCreatureType = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public double StatsScalar
		{
			get => m_StatsScalar;
			set { m_StatsScalar = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public double SkillsScalar
		{
			get => m_SkillsScalar;
			set { m_SkillsScalar = value; InvalidateProperties(); }
		}

		[Constructable]
		public PetDeed(Type basecreature, double statsscalar, double skillsscalar) : base(0x2258)
		{
			m_BaseCreatureType = basecreature;
			m_StatsScalar = statsscalar;
			m_SkillsScalar = skillsscalar;

			Weight = 1.0;
			Name = "Crown Crate Pet Deed";
			LootType = LootType.Blessed;
			Hue = 0;
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add("<basefont color=#6ff722>Pet Type: " + m_BaseCreatureType.Name + "<br><basefont color=#f7a23b>Stats Bonus: " + m_StatsScalar + "<br>Skills Bonus: " + m_SkillsScalar + "<br><basefont color=#429ff1>Double click to redeem the pet");
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1042001);
			}
			else
			{
				BaseCreature bc;
				bc = Activator.CreateInstance(m_BaseCreatureType) as BaseCreature;


				if (m_SkillsScalar > 0.0) // Do not process skill bonus unless the skill scalar is greater than 0.0
				{
					for (var i = 0; i < bc.Skills.Length; i++)
					{
						var skill = bc.Skills[i];

						if (skill.Base > 0.0)
						{
							skill.Base += (skill.Base * m_SkillsScalar);
						}
					}
				}

				if (m_StatsScalar > 0.0)
				{

					/// since we're dealing with doubles a 5% increase is 0.5 : 100 * 0.5 = 50 
					/// to increase stats we're doing 100 + ( 100 * 0.5 ) = 150

					bc.HitsMaxSeed += (int)(bc.HitsMaxSeed * m_StatsScalar);
					bc.RawStr += (int)(bc.RawStr * m_StatsScalar);
					bc.RawDex += (int)(bc.RawDex * m_StatsScalar);
					bc.RawInt += (int)(bc.RawInt * m_StatsScalar);

					/// Makes sure creature stats are fully refreshed when deed is redeemed
					bc.Hits = bc.HitsMax;
					bc.Mana = bc.ManaMax;
					bc.Stam = bc.StamMax;
				}

				bc.MoveToWorld(new Point3D(from.X + 1, from.Y + 1, from.Z), from.Map);

				/// Set pet to "tamed"
				bc.Controlled = true;
				bc.ControlMaster = from;

				// Set pet to auto-follow owner
				bc.ControlOrder = OrderType.Follow;
				bc.ControlTarget = from;

				Delete();
			}
		}

		public PetDeed(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_BaseCreatureType.FullName);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			var bc = reader.ReadString();

			m_BaseCreatureType = Type.GetType(bc, false) ?? ScriptCompiler.FindTypeByFullName(bc);
		}
	}

	#endregion
}