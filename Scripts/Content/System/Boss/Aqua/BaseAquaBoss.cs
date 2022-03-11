
using System;

#region Developer Notations

/// Based On Killing A Specific Creature In Any Region; Kill Count Does NOT Matter

#endregion

namespace Server.Mobiles
{
	public partial class BaseAquaBossAward : Item
	{
		public static Mobile FindRandomPlayer(BaseCreature creature)
		{
			var rights = BaseCreature.GetLootingRights(creature.DamageEntries, creature.HitsMax);

			for (var i = rights.Count - 1; i >= 0; --i)
			{
				var ds = rights[i];

				if (!ds.m_HasRight)
				{
					rights.RemoveAt(i);
				}
			}

			if (rights.Count > 0)
			{
				return rights[Utility.Random(rights.Count)].m_Mobile;
			}

			return null;
		}

		#region Fresh Water Boss Artifact Distribution

		public static Item CreateRandomFreshWaterArtifact()
		{
			if (!Core.AOS)
			{
				return null;
			}

			var count = (m_FreshWaterArtifact.Length * 5) + (m_AncientFWaterTreasureChest.Length * 4);
			var random = Utility.Random(count);

			Type typeFreshWaterTreasure;

			if (random < (m_FreshWaterArtifact.Length * 5))
			{
				typeFreshWaterTreasure = m_FreshWaterArtifact[random / 5];
			}
			else
			{
				random -= m_FreshWaterArtifact.Length * 5;
				typeFreshWaterTreasure = m_AncientFWaterTreasureChest[random / 4];
			}

			return Loot.Construct(typeFreshWaterTreasure);
		}

		public static void DistributeFreshWaterArtifact(BaseCreature creature)
		{
			DistributeFreshWaterArtifact(creature, CreateRandomFreshWaterArtifact());
		}

		public static void DistributeFreshWaterArtifact(BaseCreature creature, Item artifact)
		{
			DistributeFreshWaterArtifact(FindRandomPlayer(creature), artifact);
		}

		public static void DistributeFreshWaterArtifact(Mobile to)
		{
			DistributeFreshWaterArtifact(to, CreateRandomFreshWaterArtifact());
		}

		public static void DistributeFreshWaterArtifact(Mobile to, Item artifact)
		{
			if (to == null || artifact == null)
			{
				return;
			}

			var pack = to.Backpack;

			if (pack == null || !pack.TryDropItem(to, artifact, false))
			{
				to.BankBox.DropItem(artifact);
			}

			to.SendLocalizedMessage(1062317); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.
		}

		public static int GetFreshWaterArtifactChance(Mobile boss)
		{
			var luck = LootPack.GetLuckChanceForKiller(boss);
			int chance;

			if (!Core.AOS)
			{
				return 0;
			}

			if (boss is DemonKnight)
			{
				chance = 1500 + (luck / 5);
			}
			else
			{
				chance = 750 + (luck / 10);
			}

			return chance;
		}

		public static bool CheckFreshWaterArtifactChance(Mobile boss)
		{
			return GetFreshWaterArtifactChance(boss) > Utility.Random(100000);
		}

		#endregion

		#region Salty Water Boss Artifact Distribution

		public static Item CreateRandomSaltWaterArtifact()
		{
			if (!Core.AOS)
			{
				return null;
			}

			var count = (m_SaltWaterArtifact.Length * 5) + (m_AncientSWaterTreasureChest.Length * 4);
			var random = Utility.Random(count);

			Type typeSaltWaterTreasure;

			if (random < (m_SaltWaterArtifact.Length * 5))
			{
				typeSaltWaterTreasure = m_SaltWaterArtifact[random / 5];
			}
			else
			{
				random -= m_SaltWaterArtifact.Length * 5;
				typeSaltWaterTreasure = m_AncientSWaterTreasureChest[random / 4];
			}



			return Loot.Construct(typeSaltWaterTreasure);
		}

		public static void DistributeSaltWaterArtifact(BaseCreature creature)
		{
			DistributeSaltWaterArtifact(creature, CreateRandomSaltWaterArtifact());
		}

		public static void DistributeSaltWaterArtifact(BaseCreature creature, Item artifact)
		{
			DistributeSaltWaterArtifact(FindRandomPlayer(creature), artifact);
		}

		public static void DistributeSaltWaterArtifact(Mobile to)
		{
			DistributeSaltWaterArtifact(to, CreateRandomSaltWaterArtifact());
		}

		public static void DistributeSaltWaterArtifact(Mobile to, Item artifact)
		{
			if (to == null || artifact == null)
			{
				return;
			}

			var pack = to.Backpack;

			if (pack == null || !pack.TryDropItem(to, artifact, false))
			{
				to.BankBox.DropItem(artifact);
			}

			to.SendLocalizedMessage(1062317); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.
		}

		public static int GetSaltWaterArtifactChance(Mobile boss)
		{
			var luck = LootPack.GetLuckChanceForKiller(boss);
			int chance;

			if (!Core.AOS)
			{
				return 0;
			}

			if (boss is DemonKnight)
			{
				chance = 1500 + (luck / 5);
			}
			else
			{
				chance = 750 + (luck / 10);
			}

			return chance;
		}

		public static bool CheckSaltWaterArtifactChance(Mobile boss)
		{
			return GetSaltWaterArtifactChance(boss) > Utility.Random(100000);
		}

		#endregion

		public BaseAquaBossAward(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}