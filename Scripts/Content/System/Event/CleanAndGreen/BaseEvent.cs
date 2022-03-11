using Server.Items;

using System;

#region Developer Notations

/// ToDo: Create A Reward Gump For This System With Choices For Each Tier

#endregion

namespace Server.Engines.Events
{
	public class CleanAndGreenTrashBarrel : Item
	{
		public static int i_Reward = 0;

		[Constructable]
		public CleanAndGreenTrashBarrel() : base(0xE77)
		{
			Name = "Cleaning Up Britannia";

			Movable = false;
			Hue = 1285;
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			if (dropped.LootType == LootType.Blessed || dropped.LootType == LootType.Newbied || dropped.Insured)
			{
				from.SendMessage("You can not trash blessed, newbied, or insured items");
				return false;
			}

			from.PlaySound(0x76); // Change Drop Sound Here

			i_Reward = 0;
			if (dropped.LootType != LootType.Blessed || dropped.LootType != LootType.Newbied || dropped.Insured)
			{
				if (dropped is Container)
				{
					var props = 0;
					var list = ((Container)dropped).Items;
					if (list.Count > 0)
					{
						for (var i = list.Count - 1; i >= 0; --i)
						{

							if (list[i] is BaseOre || list[i] is BaseIngot || list[i] is BaseScales || list[i] is BaseHides || list[i] is BaseGranite ||
							list[i] is BaseReagent || list[i] is Cloth || list[i] is Board || list[i] is Log || list[i] is UncutCloth || list[i] is Bandage || list[i] is BaseLeather ||
							(list[i].ItemID >= 2508 && list[i].ItemID <= 2511) || (list[i].ItemID >= 13321 && list[i].ItemID <= 13344) || (list[i].ItemID >= 15097 && list[i].ItemID <= 15125))
							{
								i_Reward = 1;
							}
							else if (list[i] is Gold || list[i] is CookableFood || list[i] is Food || list[i] is Arrow || list[i] is Bolt)
							{
								i_Reward = 0;
							}

							if (list[i] is BaseArmor)
							{
								foreach (int j in Enum.GetValues(typeof(AosAttribute)))
								{
									if (((BaseArmor)list[i]).Attributes[(AosAttribute)j] > 0)
									{
										++props;
									}
								}

								foreach (int j in Enum.GetValues(typeof(AosArmorAttribute)))
								{
									if (((BaseArmor)list[i]).ArmorAttributes[(AosArmorAttribute)j] > 0)
									{
										++props;
									}
								}

								i_Reward += (Utility.RandomMinMax(5 + (5 * props), 9 + (9 * props)));
							}
							else if (list[i] is BaseWeapon)
							{
								foreach (int j in Enum.GetValues(typeof(AosAttribute)))
								{
									if (((BaseWeapon)list[i]).Attributes[(AosAttribute)j] > 0)
									{
										++props;
									}
								}

								foreach (int j in Enum.GetValues(typeof(AosArmorAttribute)))
								{
									if (((BaseWeapon)list[i]).WeaponAttributes[(AosWeaponAttribute)j] > 0)
									{
										++props;
									}
								}

								i_Reward += (Utility.RandomMinMax(5 + (5 * props), 9 + (9 * props)));
							}
							else if (list[i] is BaseJewel)
							{
								foreach (int j in Enum.GetValues(typeof(AosAttribute)))
								{
									if (((BaseJewel)list[i]).Attributes[(AosAttribute)j] > 0)
									{
										++props;
									}
								}

								foreach (int j in Enum.GetValues(typeof(AosElementAttribute)))
								{
									if (((BaseJewel)list[i]).Resistances[(AosElementAttribute)j] > 0)
									{
										++props;
									}
								}

								i_Reward += (Utility.RandomMinMax(5 + (5 * props), 9 + (9 * props)));
							}
							else if (list[i] is BaseClothing)
							{
								foreach (int j in Enum.GetValues(typeof(AosAttribute)))
								{
									if (((BaseClothing)list[i]).Attributes[(AosAttribute)j] > 0)
									{
										++props;
									}
								}

								foreach (int j in Enum.GetValues(typeof(AosElementAttribute)))
								{
									if (((BaseClothing)list[i]).Resistances[(AosElementAttribute)j] > 0)
									{
										++props;
									}
								}

								i_Reward += (Utility.RandomMinMax(5 + (5 * props), 9 + (9 * props)));
							}

							props = 0;
						}
						i_Reward += Utility.RandomMinMax(2, 5);
					}
					else
					{
						i_Reward = 1;
					}
				}
				else if (dropped is BaseOre || dropped is BaseIngot || dropped is BaseScales || dropped is BaseHides || dropped is BaseGranite ||
				dropped is BaseReagent || dropped is Cloth || dropped is Board || dropped is Log || dropped is UncutCloth || dropped is Bandage || dropped is BaseLeather ||
				(dropped.ItemID >= 2508 && dropped.ItemID <= 2511) || (dropped.ItemID >= 13321 && dropped.ItemID <= 13344) || (dropped.ItemID >= 15097 && dropped.ItemID <= 15125))
				{
					i_Reward = 1;
				}
				else if (dropped is CookableFood || dropped is Food || dropped is Arrow || dropped is Bolt)
				{
					i_Reward = 0;
				}
				else if (dropped is Gold)
				{
					i_Reward = 0;
				}

				else if (dropped is BaseJewel || dropped is BaseArmor || dropped is BaseWeapon || dropped is BaseClothing)
				{
					var props = 0;
					if (dropped is BaseArmor)
					{
						foreach (int i in Enum.GetValues(typeof(AosAttribute)))
						{
							if (((BaseArmor)dropped).Attributes[(AosAttribute)i] > 0)
							{
								++props;
							}
						}

						foreach (int i in Enum.GetValues(typeof(AosArmorAttribute)))
						{
							if (((BaseArmor)dropped).ArmorAttributes[(AosArmorAttribute)i] > 0)
							{
								++props;
							}
						}

						i_Reward += (Utility.RandomMinMax(5 + (5 * props), 9 + (9 * props)));
					}
					else if (dropped is BaseWeapon)
					{
						foreach (int i in Enum.GetValues(typeof(AosAttribute)))
						{
							if (((BaseWeapon)dropped).Attributes[(AosAttribute)i] > 0)
							{
								++props;
							}
						}

						foreach (int i in Enum.GetValues(typeof(AosArmorAttribute)))
						{
							if (((BaseWeapon)dropped).WeaponAttributes[(AosWeaponAttribute)i] > 0)
							{
								++props;
							}
						}

						i_Reward += (Utility.RandomMinMax(5 + (5 * props), 9 + (9 * props)));
					}
					else if (dropped is BaseJewel)
					{
						foreach (int i in Enum.GetValues(typeof(AosAttribute)))
						{
							if (((BaseJewel)dropped).Attributes[(AosAttribute)i] > 0)
							{
								++props;
							}
						}

						foreach (int i in Enum.GetValues(typeof(AosElementAttribute)))
						{
							if (((BaseJewel)dropped).Resistances[(AosElementAttribute)i] > 0)
							{
								++props;
							}
						}

						i_Reward += (Utility.RandomMinMax(5 + (5 * props), 9 + (9 * props)));
					}
					else if (dropped is BaseClothing)
					{
						foreach (int i in Enum.GetValues(typeof(AosAttribute)))
						{
							if (((BaseClothing)dropped).Attributes[(AosAttribute)i] > 0)
							{
								++props;
							}
						}

						foreach (int i in Enum.GetValues(typeof(AosElementAttribute)))
						{
							if (((BaseClothing)dropped).Resistances[(AosElementAttribute)i] > 0)
							{
								++props;
							}
						}

						i_Reward += (Utility.RandomMinMax(5 + (5 * props), 9 + (9 * props)));
					}
				}

				dropped.Delete();

				if (i_Reward > 60000)
				{
					i_Reward = 60000;
				}

				if (i_Reward > 0)
				{
					from.AddToBackpack(new CleanAndGreenToken(i_Reward));
					from.SendMessage(1173, "You were rewarded {0} Trade Tokens for your trash, thank you for cleaning up Britannia!.", i_Reward);
				}
				else if (i_Reward == 0)
				{
					from.SendMessage(1173, "We appreciate the effort to keep Britannia clean, but you were rewarded 0 Trade Tokens for your trash, as it was not very much.");
				}
				else if (i_Reward < 0)
				{
					from.SendMessage(1173, "You were rewarded {0} Trade Tokens for trying to exploit the system.", i_Reward);
				}
			}

			return true;
		}

		public override void OnDoubleClick(Mobile from) { }
		public CleanAndGreenTrashBarrel(Serial serial) : base(serial) { }
		public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
		public override void Deserialize(GenericReader reader) { base.Deserialize(reader); var version = reader.ReadInt(); }
	}

	public class CleanAndGreenToken : Item
	{
		[Constructable]
		public CleanAndGreenToken() : this(1)
		{
		}

		[Constructable]
		public CleanAndGreenToken(int amountFrom, int amountTo) : this(Utility.RandomMinMax(amountFrom, amountTo))
		{
		}

		[Constructable]
		public CleanAndGreenToken(int amount) : base(0xF8E)
		{
			Stackable = true;
			Name = "Trade Token";
			Hue = 1285;
			LootType = LootType.Blessed;
			Weight = 0;
			Amount = amount;
		}

		public CleanAndGreenToken(Serial serial) : base(serial)
		{
		}

		public override int GetDropSound()
		{
			if (Amount <= 1)
			{
				return 0x2E4;
			}
			else if (Amount <= 5)
			{
				return 0x2E5;
			}
			else
			{
				return 0x2E6;
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