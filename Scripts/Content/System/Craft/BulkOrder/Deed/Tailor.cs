using Server.Engines.Craft;

using System;
using System.Collections.Generic;

namespace Server.Engines.BulkOrders
{
	public class SmallTailorBOD : SmallBOD
	{
		public static double[] m_TailoringMaterialChances = new double[]
			{
				0.857421875, // None
				0.125000000, // Spined
				0.015625000, // Horned
				0.001953125  // Barbed
			};

		public override int ComputeFame()
		{
			return TailorRewardCalculator.Instance.ComputeFame(this);
		}

		public override int ComputeGold()
		{
			return TailorRewardCalculator.Instance.ComputeGold(this);
		}

		public override List<Item> ComputeRewards(bool full)
		{
			var list = new List<Item>();

			var rewardGroup = TailorRewardCalculator.Instance.LookupRewards(TailorRewardCalculator.Instance.ComputePoints(this));

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

		public static SmallTailorBOD CreateRandomFor(Mobile m)
		{
			SmallBulkEntry[] entries;
			var useMaterials = Utility.RandomBool();

			var theirSkill = m.Skills[SkillName.Tailoring].Base;
			if (useMaterials && theirSkill >= 6.2) // Ugly, but the easiest leather BOD is Leather Cap which requires at least 6.2 skill.
			{
				entries = SmallBulkEntry.TailorLeather;
			}
			else
			{
				entries = SmallBulkEntry.TailorCloth;
			}

			if (entries.Length > 0)
			{
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
						var check = GetRandomMaterial(BulkMaterialType.Spined, m_TailoringMaterialChances);
						var skillReq = 0.0;

						switch (check)
						{
							case BulkMaterialType.DullCopper: skillReq = 65.0; break;
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


				var system = DefTailoring.CraftSystem;

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
					return new SmallTailorBOD(entry, material, amountMax, reqExceptional);
				}
			}

			return null;
		}

		private SmallTailorBOD(SmallBulkEntry entry, BulkMaterialType material, int amountMax, bool reqExceptional)
		{
			Hue = 0x483;
			AmountMax = amountMax;
			Type = entry.Type;
			Number = entry.Number;
			Graphic = entry.Graphic;
			RequireExceptional = reqExceptional;
			Material = material;
		}

		[Constructable]
		public SmallTailorBOD()
		{
			SmallBulkEntry[] entries;
			bool useMaterials;

			if (useMaterials = Utility.RandomBool())
			{
				entries = SmallBulkEntry.TailorLeather;
			}
			else
			{
				entries = SmallBulkEntry.TailorCloth;
			}

			if (entries.Length > 0)
			{
				var hue = 0x483;
				var amountMax = Utility.RandomList(10, 15, 20);

				BulkMaterialType material;

				if (useMaterials)
				{
					material = GetRandomMaterial(BulkMaterialType.Spined, m_TailoringMaterialChances);
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

		public SmallTailorBOD(int amountCur, int amountMax, Type type, int number, int graphic, bool reqExceptional, BulkMaterialType mat)
		{
			Hue = 0x483;
			AmountMax = amountMax;
			AmountCur = amountCur;
			Type = type;
			Number = number;
			Graphic = graphic;
			RequireExceptional = reqExceptional;
			Material = mat;
		}

		public SmallTailorBOD(Serial serial) : base(serial)
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

	public class LargeTailorBOD : LargeBOD
	{
		public static double[] m_TailoringMaterialChances = new double[]
			{
				0.857421875, // None
				0.125000000, // Spined
				0.015625000, // Horned
				0.001953125  // Barbed
			};

		public override int ComputeFame()
		{
			return TailorRewardCalculator.Instance.ComputeFame(this);
		}

		public override int ComputeGold()
		{
			return TailorRewardCalculator.Instance.ComputeGold(this);
		}

		[Constructable]
		public LargeTailorBOD()
		{
			LargeBulkEntry[] entries;
			var useMaterials = false;

			switch (Utility.Random(14))
			{
				default:
				case 0: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.Farmer); break;
				case 1: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.FemaleLeatherSet); useMaterials = true; break;
				case 2: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.FisherGirl); break;
				case 3: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.Gypsy); break;
				case 4: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.HatSet); break;
				case 5: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.Jester); break;
				case 6: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.Lady); break;
				case 7: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.MaleLeatherSet); useMaterials = true; break;
				case 8: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.Pirate); break;
				case 9: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.ShoeSet); useMaterials = Core.ML; break;
				case 10: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.StuddedSet); useMaterials = true; break;
				case 11: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.TownCrier); break;
				case 12: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.Wizard); break;
				case 13: entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.BoneSet); useMaterials = true; break;
			}

			var hue = 0x483;
			var amountMax = Utility.RandomList(10, 15, 20, 20);
			var reqExceptional = (0.825 > Utility.RandomDouble());

			BulkMaterialType material;

			if (useMaterials)
			{
				material = GetRandomMaterial(BulkMaterialType.Spined, m_TailoringMaterialChances);
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

		public LargeTailorBOD(int amountMax, bool reqExceptional, BulkMaterialType mat, LargeBulkEntry[] entries)
		{
			Hue = 0x483;
			AmountMax = amountMax;
			Entries = entries;
			RequireExceptional = reqExceptional;
			Material = mat;
		}

		public override List<Item> ComputeRewards(bool full)
		{
			var list = new List<Item>();

			var rewardGroup = TailorRewardCalculator.Instance.LookupRewards(TailorRewardCalculator.Instance.ComputePoints(this));

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

		public LargeTailorBOD(Serial serial) : base(serial)
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