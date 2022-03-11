using Server.Mobiles;

using System;

#region Developer Notations

/// Based On How Many Creature Types Are Killed In A Defined Region

#endregion

namespace Server
{
	public static partial class ValorSpawner
	{
		public static bool CheckArtifactChance(Mobile m, BaseCreature bc)
		{
			if (!Core.ML)
			{
				return false;
			}

			return Paragon.CheckArtifactChance(m, bc);
		}

		public static void GiveArtifactTo(Mobile m)
		{
			var item = Activator.CreateInstance(m_Artifacts[Utility.Random(m_Artifacts.Length)]) as Item;

			if (item == null)
			{
				return;
			}

			if (m.AddToBackpack(item))
			{
				m.SendLocalizedMessage(1072223); // An item has been placed in your backpack.
				m.SendLocalizedMessage(1062317); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.
			}
			else if (m.BankBox.TryDropItem(m, item, false))
			{
				m.SendLocalizedMessage(1072224); // An item has been placed in your bank box.
				m.SendLocalizedMessage(1062317); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.
			}
			else
			{
				// Item was placed at feet by m.AddToBackpack
				m.SendLocalizedMessage(1072523); // You find an artifact, but your backpack and bank are too full to hold it.
			}
		}

		public static bool CheckML(Mobile from)
		{
			return CheckML(from, true);
		}

		public static bool CheckML(Mobile from, bool message)
		{
			if (from == null || from.NetState == null)
			{
				return false;
			}

			if (from.NetState.SupportsExpansion(Expansion.ML))
			{
				return true;
			}

			if (message)
			{
				from.SendLocalizedMessage(1072791); // You must upgrade to Mondain's Legacy in order to use that item.
			}

			return false;
		}

		public static bool IsValorRegion(Region region)
		{
			return region.IsPartOf("Twisted Weald")
				|| region.IsPartOf("Sanctuary")
				|| region.IsPartOf("The Prism of Light")
				|| region.IsPartOf("The Citadel")
				|| region.IsPartOf("Bedlam")
				|| region.IsPartOf("Blighted Grove")
				|| region.IsPartOf("The Painted Caves")
				|| region.IsPartOf("The Palace of Paroxysmus")
				|| region.IsPartOf("Labyrinth");
		}
	}
}