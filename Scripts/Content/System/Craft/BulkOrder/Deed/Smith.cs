using Server.Engines.Craft;

using System;
using System.Collections.Generic;

namespace Server.Engines.BulkOrders
{
	[TypeAlias("Scripts.Engines.BulkOrders.SmallSmithBOD")]
	public class SmallSmithBOD : SmallBOD
	{
		public static double[] m_BlacksmithMaterialChances = new double[]
			{
				0.501953125, // None
				0.250000000, // Dull Copper
				0.125000000, // Shadow Iron
				0.062500000, // Copper
				0.031250000, // Bronze
				0.015625000, // Gold
				0.007812500, // Agapite
				0.003906250, // Verite
				0.001953125  // Valorite
			};

		public override int ComputeFame()
		{
			return SmithRewardCalculator.Instance.ComputeFame(this);
		}

		public override int ComputeGold()
		{
			return SmithRewardCalculator.Instance.ComputeGold(this);
		}

		public override List<Item> ComputeRewards(bool full)
		{
			var list = new List<Item>();

			var rewardGroup = SmithRewardCalculator.Instance.LookupRewards(SmithRewardCalculator.Instance.ComputePoints(this));

			if (rewardGroup != null)
			{
				if (full)
				{
					for (var i = 0; i < rewardGroup.Items.Length; ++i)
					{
						var item = rewardGroup.Items[i].Construct();

						if (item != null)
						{
							list.Add(item);
						}
					}
				}
				else
				{
					var rewardItem = rewardGroup.AcquireItem();

					if (rewardItem != null)
					{
						var item = rewardItem.Construct();

						if (item != null)
						{
							list.Add(item);
						}
					}
				}
			}

			return list;
		}

		public static SmallSmithBOD CreateRandomFor(Mobile m)
		{
			SmallBulkEntry[] entries;
			bool useMaterials;

			if (useMaterials = Utility.RandomBool())
			{
				entries = SmallBulkEntry.BlacksmithArmor;
			}
			else
			{
				entries = SmallBulkEntry.BlacksmithWeapons;
			}

			if (entries.Length > 0)
			{
				var theirSkill = m.Skills[SkillName.Blacksmith].Base;
				int amountMax;

				if (theirSkill >= 70.1)
				{
					amountMax = Utility.RandomList(10, 15, 20, 20);
				}
				else if (theirSkill >= 50.1)
				{
					amountMax = Utility.RandomList(10, 15, 15, 20);
				}
				else
				{
					amountMax = Utility.RandomList(10, 10, 15, 20);
				}

				var material = BulkMaterialType.None;

				if (useMaterials && theirSkill >= 70.1)
				{
					for (var i = 0; i < 20; ++i)
					{
						var check = GetRandomMaterial(BulkMaterialType.DullCopper, m_BlacksmithMaterialChances);
						var skillReq = 0.0;

						switch (check)
						{
							case BulkMaterialType.DullCopper: skillReq = 65.0; break;
							case BulkMaterialType.ShadowIron: skillReq = 70.0; break;
							case BulkMaterialType.Copper: skillReq = 75.0; break;
							case BulkMaterialType.Bronze: skillReq = 80.0; break;
							case BulkMaterialType.Gold: skillReq = 85.0; break;
							case BulkMaterialType.Agapite: skillReq = 90.0; break;
							case BulkMaterialType.Verite: skillReq = 95.0; break;
							case BulkMaterialType.Valorite: skillReq = 100.0; break;
							case BulkMaterialType.Spined: skillReq = 65.0; break;
							case BulkMaterialType.Horned: skillReq = 80.0; break;
							case BulkMaterialType.Barbed: skillReq = 99.0; break;
						}

						if (theirSkill >= skillReq)
						{
							material = check;
							break;
						}
					}
				}

				var excChance = 0.0;

				if (theirSkill >= 70.1)
				{
					excChance = (theirSkill + 80.0) / 200.0;
				}

				var reqExceptional = (excChance > Utility.RandomDouble());

				var system = DefBlacksmithy.CraftSystem;

				var validEntries = new List<SmallBulkEntry>();

				for (var i = 0; i < entries.Length; ++i)
				{
					var item = system.CraftItems.SearchFor(entries[i].Type);

					if (item != null)
					{
						var allRequiredSkills = true;
						var chance = item.GetSuccessChance(m, null, system, false, ref allRequiredSkills);

						if (allRequiredSkills && chance >= 0.0)
						{
							if (reqExceptional)
							{
								chance = item.GetExceptionalChance(system, chance, m);
							}

							if (chance > 0.0)
							{
								validEntries.Add(entries[i]);
							}
						}
					}
				}

				if (validEntries.Count > 0)
				{
					var entry = validEntries[Utility.Random(validEntries.Count)];
					return new SmallSmithBOD(entry, material, amountMax, reqExceptional);
				}
			}

			return null;
		}

		private SmallSmithBOD(SmallBulkEntry entry, BulkMaterialType material, int amountMax, bool reqExceptional)
		{
			Hue = 0x44E;
			AmountMax = amountMax;
			Type = entry.Type;
			Number = entry.Number;
			Graphic = entry.Graphic;
			RequireExceptional = reqExceptional;
			Material = material;
		}

		[Constructable]
		public SmallSmithBOD()
		{
			SmallBulkEntry[] entries;
			bool useMaterials;

			if (useMaterials = Utility.RandomBool())
			{
				entries = SmallBulkEntry.BlacksmithArmor;
			}
			else
			{
				entries = SmallBulkEntry.BlacksmithWeapons;
			}

			if (entries.Length > 0)
			{
				var hue = 0x44E;
				var amountMax = Utility.RandomList(10, 15, 20);

				BulkMaterialType material;

				if (useMaterials)
				{
					material = GetRandomMaterial(BulkMaterialType.DullCopper, m_BlacksmithMaterialChances);
				}
				else
				{
					material = BulkMaterialType.None;
				}

				var reqExceptional = Utility.RandomBool() || (material == BulkMaterialType.None);

				var entry = entries[Utility.Random(entries.Length)];

				Hue = hue;
				AmountMax = amountMax;
				Type = entry.Type;
				Number = entry.Number;
				Graphic = entry.Graphic;
				RequireExceptional = reqExceptional;
				Material = material;
			}
		}

		public SmallSmithBOD(int amountCur, int amountMax, Type type, int number, int graphic, bool reqExceptional, BulkMaterialType mat)
		{
			Hue = 0x44E;
			AmountMax = amountMax;
			AmountCur = amountCur;
			Type = type;
			Number = number;
			Graphic = graphic;
			RequireExceptional = reqExceptional;
			Material = mat;
		}

		public SmallSmithBOD(Serial serial) : base(serial)
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

	[TypeAlias("Scripts.Engines.BulkOrders.LargeSmithBOD")]
	public class LargeSmithBOD : LargeBOD
	{
		public static double[] m_BlacksmithMaterialChances = new double[]
			{
				0.501953125, // None
				0.250000000, // Dull Copper
				0.125000000, // Shadow Iron
				0.062500000, // Copper
				0.031250000, // Bronze
				0.015625000, // Gold
				0.007812500, // Agapite
				0.003906250, // Verite
				0.001953125  // Valorite
			};

		public override int ComputeFame()
		{
			return SmithRewardCalculator.Instance.ComputeFame(this);
		}

		public override int ComputeGold()
		{
			return SmithRewardCalculator.Instance.ComputeGold(this);
		}

		[Constructable]
		public LargeSmithBOD()
		{
			LargeBulkEntry[] entries;
			var useMaterials = true;

			var rand = Utility.Random(8);

			switch (rand)
			{
				default:
				case 0: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeRing); break;
				case 1: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargePlate); break;
				case 2: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeChain); break;
				case 3: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeAxes); break;
				case 4: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeFencing); break;
				case 5: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeMaces); break;
				case 6: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargePolearms); break;
				case 7: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeSwords); break;
			}

			if (rand > 2 && rand < 8)
			{
				useMaterials = false;
			}

			var hue = 0x44E;
			var amountMax = Utility.RandomList(10, 15, 20, 20);
			var reqExceptional = (0.825 > Utility.RandomDouble());

			BulkMaterialType material;

			if (useMaterials)
			{
				material = GetRandomMaterial(BulkMaterialType.DullCopper, m_BlacksmithMaterialChances);
			}
			else
			{
				material = BulkMaterialType.None;
			}

			Hue = hue;
			AmountMax = amountMax;
			Entries = entries;
			RequireExceptional = reqExceptional;
			Material = material;
		}

		public LargeSmithBOD(int amountMax, bool reqExceptional, BulkMaterialType mat, LargeBulkEntry[] entries)
		{
			Hue = 0x44E;
			AmountMax = amountMax;
			Entries = entries;
			RequireExceptional = reqExceptional;
			Material = mat;
		}

		public override List<Item> ComputeRewards(bool full)
		{
			var list = new List<Item>();

			var rewardGroup = SmithRewardCalculator.Instance.LookupRewards(SmithRewardCalculator.Instance.ComputePoints(this));

			if (rewardGroup != null)
			{
				if (full)
				{
					for (var i = 0; i < rewardGroup.Items.Length; ++i)
					{
						var item = rewardGroup.Items[i].Construct();

						if (item != null)
						{
							list.Add(item);
						}
					}
				}
				else
				{
					var rewardItem = rewardGroup.AcquireItem();

					if (rewardItem != null)
					{
						var item = rewardItem.Construct();

						if (item != null)
						{
							list.Add(item);
						}
					}
				}
			}

			return list;
		}

		public LargeSmithBOD(Serial serial) : base(serial)
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