using Server.ContextMenus;
using Server.Items;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	public abstract class Food : Item
	{
		private Mobile m_Poisoner;
		private Poison m_Poison;
		private int m_FillFactor;

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Poisoner
		{
			get => m_Poisoner;
			set => m_Poisoner = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Poison Poison
		{
			get => m_Poison;
			set => m_Poison = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int FillFactor
		{
			get => m_FillFactor;
			set => m_FillFactor = value;
		}

		public Food(int itemID) : this(1, itemID)
		{
		}

		public Food(int amount, int itemID) : base(itemID)
		{
			Stackable = true;
			Amount = amount;
			m_FillFactor = 1;
		}

		public Food(Serial serial) : base(serial)
		{
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			if (from.Alive)
			{
				list.Add(new ContextMenus.EatEntry(from, this));
			}
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!Movable)
			{
				return;
			}

			if (from.InRange(GetWorldLocation(), 1))
			{
				Eat(from);
			}
		}

		public virtual bool Eat(Mobile from)
		{
			// Fill the Mobile with FillFactor
			if (CheckHunger(from))
			{
				// Play a random "eat" sound
				from.PlaySound(Utility.Random(0x3A, 3));

				if (from.Body.IsHuman && !from.Mounted)
				{
					from.Animate(34, 5, 1, true, false, 0);
				}

				if (m_Poison != null)
				{
					from.ApplyPoison(m_Poisoner, m_Poison);
				}

				Consume();

				return true;
			}

			return false;
		}

		public virtual bool CheckHunger(Mobile from)
		{
			return FillHunger(from, m_FillFactor);
		}

		public static bool FillHunger(Mobile from, int fillFactor)
		{
			if (from.Hunger >= 20)
			{
				from.SendLocalizedMessage(500867); // You are simply too full to eat any more!
				return false;
			}

			var iHunger = from.Hunger + fillFactor;

			if (from.Stam < from.StamMax)
			{
				from.Stam += Utility.Random(6, 3) + fillFactor / 5;
			}

			if (iHunger >= 20)
			{
				from.Hunger = 20;
				from.SendLocalizedMessage(500872); // You manage to eat the food, but you are stuffed!
			}
			else
			{
				from.Hunger = iHunger;

				if (iHunger < 5)
				{
					from.SendLocalizedMessage(500868); // You eat the food, but are still extremely hungry.
				}
				else if (iHunger < 10)
				{
					from.SendLocalizedMessage(500869); // You eat the food, and begin to feel more satiated.
				}
				else if (iHunger < 15)
				{
					from.SendLocalizedMessage(500870); // After eating the food, you feel much less hungry.
				}
				else
				{
					from.SendLocalizedMessage(500871); // You feel quite full after consuming the food.
				}
			}

			return true;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(4); // version

			writer.Write(m_Poisoner);

			Poison.Serialize(m_Poison, writer);
			writer.Write(m_FillFactor);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						switch (reader.ReadInt())
						{
							case 0: m_Poison = null; break;
							case 1: m_Poison = Poison.Lesser; break;
							case 2: m_Poison = Poison.Regular; break;
							case 3: m_Poison = Poison.Greater; break;
							case 4: m_Poison = Poison.Deadly; break;
						}

						break;
					}
				case 2:
					{
						m_Poison = Poison.Deserialize(reader);
						break;
					}
				case 3:
					{
						m_Poison = Poison.Deserialize(reader);
						m_FillFactor = reader.ReadInt();
						break;
					}
				case 4:
					{
						m_Poisoner = reader.ReadMobile();
						goto case 3;
					}
			}
		}
	}

	public abstract class CookableFood : Item
	{
		private int m_CookingLevel;

		[CommandProperty(AccessLevel.GameMaster)]
		public int CookingLevel
		{
			get => m_CookingLevel;
			set => m_CookingLevel = value;
		}

		public CookableFood(int itemID, int cookingLevel) : base(itemID)
		{
			m_CookingLevel = cookingLevel;
		}

		public CookableFood(Serial serial) : base(serial)
		{
		}

		public abstract Food Cook();

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
							 // Version 1
			writer.Write(m_CookingLevel);

		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_CookingLevel = reader.ReadInt();

						break;
					}
			}
		}

#if false
		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
				return;

			from.Target = new InternalTarget( this );
		}
#endif

		public static bool IsHeatSource(object targeted)
		{
			int itemID;

			if (targeted is Item)
			{
				itemID = ((Item)targeted).ItemID;
			}
			else if (targeted is StaticTarget)
			{
				itemID = ((StaticTarget)targeted).ItemID;
			}
			else
			{
				return false;
			}

			if (itemID >= 0xDE3 && itemID <= 0xDE9)
			{
				return true; // Campfire
			}
			else if (itemID >= 0x461 && itemID <= 0x48E)
			{
				return true; // Sandstone oven/fireplace
			}
			else if (itemID >= 0x92B && itemID <= 0x96C)
			{
				return true; // Stone oven/fireplace
			}
			else if (itemID == 0xFAC)
			{
				return true; // Firepit
			}
			else if (itemID >= 0x184A && itemID <= 0x184C)
			{
				return true; // Heating stand (left)
			}
			else if (itemID >= 0x184E && itemID <= 0x1850)
			{
				return true; // Heating stand (right)
			}
			else if (itemID >= 0x398C && itemID <= 0x399F)
			{
				return true; // Fire field
			}

			return false;
		}

		private class InternalTarget : Target
		{
			private readonly CookableFood m_Item;

			public InternalTarget(CookableFood item) : base(1, false, TargetFlags.None)
			{
				m_Item = item;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (m_Item.Deleted)
				{
					return;
				}

				if (CookableFood.IsHeatSource(targeted))
				{
					if (from.BeginAction(typeof(CookableFood)))
					{
						from.PlaySound(0x225);

						m_Item.Consume();

						var t = new InternalTimer(from, targeted as IPoint3D, from.Map, m_Item);
						t.Start();
					}
					else
					{
						from.SendLocalizedMessage(500119); // You must wait to perform another action
					}
				}
			}

			private class InternalTimer : Timer
			{
				private readonly Mobile m_From;
				private readonly IPoint3D m_Point;
				private readonly Map m_Map;
				private readonly CookableFood m_CookableFood;

				public InternalTimer(Mobile from, IPoint3D p, Map map, CookableFood cookableFood) : base(TimeSpan.FromSeconds(5.0))
				{
					m_From = from;
					m_Point = p;
					m_Map = map;
					m_CookableFood = cookableFood;
				}

				protected override void OnTick()
				{
					m_From.EndAction(typeof(CookableFood));

					if (m_From.Map != m_Map || (m_Point != null && m_From.GetDistanceToSqrt(m_Point) > 3))
					{
						m_From.SendLocalizedMessage(500686); // You burn the food to a crisp! It's ruined.
						return;
					}

					if (m_From.CheckSkill(SkillName.Cooking, m_CookableFood.CookingLevel, 100))
					{
						var cookedFood = m_CookableFood.Cook();

						if (m_From.AddToBackpack(cookedFood))
						{
							m_From.PlaySound(0x57);
						}
					}
					else
					{
						m_From.SendLocalizedMessage(500686); // You burn the food to a crisp! It's ruined.
					}
				}
			}
		}
	}

	public class UtilityItem
	{
		public static int RandomChoice(int itemID1, int itemID2)
		{
			var iRet = 0;
			switch (Utility.Random(2))
			{
				default:
				case 0: iRet = itemID1; break;
				case 1: iRet = itemID2; break;
			}
			return iRet;
		}
	}
}

namespace Server.ContextMenus
{
	public class EatEntry : ContextMenuEntry
	{
		private readonly Mobile m_From;
		private readonly Food m_Food;

		public EatEntry(Mobile from, Food food) : base(6135, 1)
		{
			m_From = from;
			m_Food = food;
		}

		public override void OnClick()
		{
			if (m_Food.Deleted || !m_Food.Movable || !m_From.CheckAlive() || !m_Food.CheckItemUse(m_From))
			{
				return;
			}

			m_Food.Eat(m_From);
		}
	}
}

namespace Server.Misc
{
	public class FoodDecayTimer : Timer
	{
		public static void Initialize()
		{
			new FoodDecayTimer().Start();
		}

		public FoodDecayTimer() : base(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5))
		{
			Priority = TimerPriority.OneMinute;
		}

		protected override void OnTick()
		{
			FoodDecay();
		}

		public static void FoodDecay()
		{
			foreach (var state in NetState.Instances)
			{
				HungerDecay(state.Mobile);
				ThirstDecay(state.Mobile);
			}
		}

		public static void HungerDecay(Mobile m)
		{
			if (m != null && m.Hunger >= 1)
			{
				m.Hunger -= 1;
			}
		}

		public static void ThirstDecay(Mobile m)
		{
			if (m != null && m.Thirst >= 1)
			{
				m.Thirst -= 1;
			}
		}
	}
}