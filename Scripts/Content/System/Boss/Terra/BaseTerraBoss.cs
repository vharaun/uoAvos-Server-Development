
using System;

#region Developer Notations

/// Based On Killing A Specific Creature In Any Region; Kill Count Does NOT Matter

#endregion

namespace Server.Mobiles
{
	public partial class BaseTerraBossAward : Item
	{
		public static Item CreateRandomArtifact()
		{
			if (!Core.AOS)
			{
				return null;
			}

			var count = (m_ArtifactRarity10.Length * 5) + (m_ArtifactRarity11.Length * 4);
			var random = Utility.Random(count);

			Type type;

			if (random < (m_ArtifactRarity10.Length * 5))
			{
				type = m_ArtifactRarity10[random / 5];
			}
			else
			{
				random -= m_ArtifactRarity10.Length * 5;
				type = m_ArtifactRarity11[random / 4];
			}

			return Loot.Construct(type);
		}

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

		public static void DistributeArtifact(BaseCreature creature)
		{
			DistributeArtifact(creature, CreateRandomArtifact());
		}

		public static void DistributeArtifact(BaseCreature creature, Item artifact)
		{
			DistributeArtifact(FindRandomPlayer(creature), artifact);
		}

		public static void DistributeArtifact(Mobile to)
		{
			DistributeArtifact(to, CreateRandomArtifact());
		}

		public static void DistributeArtifact(Mobile to, Item artifact)
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

		public static int GetArtifactChance(Mobile boss)
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

		public static bool CheckArtifactChance(Mobile boss)
		{
			return GetArtifactChance(boss) > Utility.Random(100000);
		}

		public BaseTerraBossAward(Serial serial) : base(serial)
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