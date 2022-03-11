using Server.ContextMenus;
using Server.Engines.Craft;
using Server.Network;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	public class SalvageBag : Bag
	{
		private bool m_Failure;

		public override int LabelNumber => 1079931;  // Salvage Bag

		[Constructable]
		public SalvageBag()
			: this(Utility.RandomBlueHue())
		{
		}

		[Constructable]
		public SalvageBag(int hue)
		{
			Weight = 2.0;
			Hue = hue;
			m_Failure = false;
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			if (from.Alive)
			{
				list.Add(new SalvageIngotsEntry(this, IsChildOf(from.Backpack) && Resmeltables()));
				list.Add(new SalvageClothEntry(this, IsChildOf(from.Backpack) && Scissorables()));
				list.Add(new SalvageAllEntry(this, IsChildOf(from.Backpack) && Resmeltables() && Scissorables()));
			}
		}

		#region Checks
		private bool Resmeltables() //Where context menu checks for metal items and dragon barding deeds
		{
			foreach (var i in Items)
			{
				if (i != null && !i.Deleted)
				{
					if (i is BaseWeapon)
					{
						if (CraftResources.GetType(((BaseWeapon)i).Resource) == CraftResourceType.Metal)
						{
							return true;
						}
					}
					if (i is BaseArmor)
					{
						if (CraftResources.GetType(((BaseArmor)i).Resource) == CraftResourceType.Metal)
						{
							return true;
						}
					}
					if (i is DragonBardingDeed)
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool Scissorables() //Where context menu checks for Leather items and cloth items
		{
			foreach (var i in Items)
			{
				if (i != null && !i.Deleted)
				{
					if (i is IScissorable)
					{
						if (i is BaseClothing)
						{
							return true;
						}

						if (i is BaseArmor)
						{
							if (CraftResources.GetType(((BaseArmor)i).Resource) == CraftResourceType.Leather)
							{
								return true;
							}
						}
						if ((i is Cloth) || (i is BoltOfCloth) || (i is Hides) || (i is BonePile))
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		#endregion

		#region Resmelt.cs
		private bool Resmelt(Mobile from, Item item, CraftResource resource)
		{
			try
			{
				if (CraftResources.GetType(resource) != CraftResourceType.Metal)
				{
					return false;
				}

				var info = CraftResources.GetInfo(resource);

				if (info == null || info.ResourceTypes.Length == 0)
				{
					return false;
				}

				var craftItem = DefBlacksmithy.CraftSystem.CraftItems.SearchFor(item.GetType());

				if (craftItem == null || craftItem.Resources.Count == 0)
				{
					return false;
				}

				var craftResource = craftItem.Resources.GetAt(0);

				if (craftResource.Amount < 2)
				{
					return false; // Not enough metal to resmelt
				}

				var difficulty = 0.0;

				switch (resource)
				{
					case CraftResource.DullCopper: difficulty = 65.0; break;
					case CraftResource.ShadowIron: difficulty = 70.0; break;
					case CraftResource.Copper: difficulty = 75.0; break;
					case CraftResource.Bronze: difficulty = 80.0; break;
					case CraftResource.Gold: difficulty = 85.0; break;
					case CraftResource.Agapite: difficulty = 90.0; break;
					case CraftResource.Verite: difficulty = 95.0; break;
					case CraftResource.Valorite: difficulty = 99.0; break;
				}

				var resourceType = info.ResourceTypes[0];
				var ingot = (Item)Activator.CreateInstance(resourceType);

				if (item is DragonBardingDeed || (item is BaseArmor && ((BaseArmor)item).PlayerConstructed) || (item is BaseWeapon && ((BaseWeapon)item).PlayerConstructed) || (item is BaseClothing && ((BaseClothing)item).PlayerConstructed))
				{
					var mining = from.Skills[SkillName.Mining].Value;
					if (mining > 100.0)
					{
						mining = 100.0;
					}

					var amount = (((4 + mining) * craftResource.Amount - 4) * 0.0068);
					if (amount < 2)
					{
						ingot.Amount = 2;
					}
					else
					{
						ingot.Amount = (int)amount;
					}
				}
				else
				{
					ingot.Amount = 2;
				}

				if (difficulty > from.Skills[SkillName.Mining].Value)
				{
					m_Failure = true;
					ingot.Delete();
				}
				else
				{
					item.Delete();
				}

				from.AddToBackpack(ingot);

				from.PlaySound(0x2A);
				from.PlaySound(0x240);

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			return false;
		}
		#endregion

		#region Salvaging
		private void SalvageIngots(Mobile from)
		{
			var tools = from.Backpack.FindItemsByType(typeof(BaseTool));

			var ToolFound = false;
			foreach (var tool in tools)
			{
				if (tool is BaseTool && ((BaseTool)tool).CraftSystem == DefBlacksmithy.CraftSystem)
				{
					ToolFound = true;
				}
			}

			if (!ToolFound)
			{
				from.SendLocalizedMessage(1079822); // You need a blacksmithing tool in order to salvage ingots.
				return;
			}

			bool anvil, forge;
			DefBlacksmithy.CheckAnvilAndForge(from, 2, out anvil, out forge);

			if (!forge)
			{
				from.SendLocalizedMessage(1044265); // You must be near a forge.
				return;
			}

			var salvaged = 0;
			var notSalvaged = 0;

			Container sBag = this;

			var Smeltables = sBag.FindItemsByType<Item>();

			for (var i = Smeltables.Count - 1; i >= 0; i--)
			{
				var item = Smeltables[i];

				if (item is BaseArmor)
				{
					if (Resmelt(from, item, ((BaseArmor)item).Resource))
					{
						salvaged++;
					}
					else
					{
						notSalvaged++;
					}
				}
				else if (item is BaseWeapon)
				{
					if (Resmelt(from, item, ((BaseWeapon)item).Resource))
					{
						salvaged++;
					}
					else
					{
						notSalvaged++;
					}
				}
				else if (item is DragonBardingDeed)
				{
					if (Resmelt(from, item, ((DragonBardingDeed)item).Resource))
					{
						salvaged++;
					}
					else
					{
						notSalvaged++;
					}
				}
			}
			if (m_Failure)
			{
				from.SendLocalizedMessage(1079975); // You failed to smelt some metal for lack of skill.
				m_Failure = false;
			}
			else
			{
				from.SendLocalizedMessage(1079973, String.Format("{0}\t{1}", salvaged, salvaged + notSalvaged)); // Salvaged: ~1_COUNT~/~2_NUM~ blacksmithed items
			}
		}

		private void SalvageCloth(Mobile from)
		{
			var scissors = from.Backpack.FindItemByType(typeof(Scissors)) as Scissors;
			if (scissors == null)
			{
				from.SendLocalizedMessage(1079823); // You need scissors in order to salvage cloth.
				return;
			}

			var salvaged = 0;
			var notSalvaged = 0;

			Container sBag = this;

			var scissorables = sBag.FindItemsByType<Item>();

			for (var i = scissorables.Count - 1; i >= 0; --i)
			{
				var item = scissorables[i];

				if (item is IScissorable)
				{
					var scissorable = (IScissorable)item;

					if (Scissors.CanScissor(from, scissorable) && scissorable.Scissor(from, scissors))
					{
						++salvaged;
					}
					else
					{
						++notSalvaged;
					}
				}
			}

			from.SendLocalizedMessage(1079974, String.Format("{0}\t{1}", salvaged, salvaged + notSalvaged)); // Salvaged: ~1_COUNT~/~2_NUM~ tailored items

			var pack = from.Backpack;

			foreach (var i in FindItemsByType(typeof(Item), true))
			{
				if ((i is Leather) || (i is Cloth) || (i is SpinedLeather) || (i is HornedLeather) || (i is BarbedLeather) || (i is Bandage) || (i is Bone))
				{
					from.AddToBackpack(i);
				}
			}
		}

		private void SalvageAll(Mobile from)
		{
			SalvageIngots(from);

			SalvageCloth(from);
		}
		#endregion

		#region ContextMenuEntries
		private class SalvageAllEntry : ContextMenuEntry
		{
			private readonly SalvageBag m_Bag;

			public SalvageAllEntry(SalvageBag bag, bool enabled)
				: base(6276)
			{
				m_Bag = bag;

				if (!enabled)
				{
					Flags |= CMEFlags.Disabled;
				}
			}

			public override void OnClick()
			{
				if (m_Bag.Deleted)
				{
					return;
				}

				var from = Owner.From;

				if (from.CheckAlive())
				{
					m_Bag.SalvageAll(from);
				}
			}
		}

		private class SalvageIngotsEntry : ContextMenuEntry
		{
			private readonly SalvageBag m_Bag;

			public SalvageIngotsEntry(SalvageBag bag, bool enabled)
				: base(6277)
			{
				m_Bag = bag;

				if (!enabled)
				{
					Flags |= CMEFlags.Disabled;
				}
			}

			public override void OnClick()
			{
				if (m_Bag.Deleted)
				{
					return;
				}

				var from = Owner.From;

				if (from.CheckAlive())
				{
					m_Bag.SalvageIngots(from);
				}
			}
		}

		private class SalvageClothEntry : ContextMenuEntry
		{
			private readonly SalvageBag m_Bag;

			public SalvageClothEntry(SalvageBag bag, bool enabled)
				: base(6278)
			{
				m_Bag = bag;

				if (!enabled)
				{
					Flags |= CMEFlags.Disabled;
				}
			}

			public override void OnClick()
			{
				if (m_Bag.Deleted)
				{
					return;
				}

				var from = Owner.From;

				if (from.CheckAlive())
				{
					m_Bag.SalvageCloth(from);
				}
			}
		}
		#endregion

		#region Serialization
		public SalvageBag(Serial serial)
			: base(serial)
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
		#endregion
	}
}