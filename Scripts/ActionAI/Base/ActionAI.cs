﻿using Server.Items;
using Server.Multis;

namespace Server.Mobiles
{
	public class ActionAI : BaseAI
	{
		public ActionAI(BaseCreature m) 
			: base(m)
		{
		}

		public override bool DoActionWander()
		{
			var blank = new Point3D(0, 0, 0);

			if (m_Mobile.Home != blank && Utility.InRange(m_Mobile.Home, m_Mobile.Location, 2) /* m_Mobile.Location == m_Mobile.Home */)
			{
				m_Mobile.CurrentSpeed = 2.0;
				m_Mobile.CantWalk = true;
				_ = EmptyPack();
			}

			//add backpack?

			if (m_Mobile.Backpack != null && m_Mobile.Backpack.TotalWeight <= m_Mobile.Backpack.MaxWeight)
			{
				if (m_Mobile.Home != blank && m_Mobile.Location != m_Mobile.Home)
				{
					if (Core.TickCount - 21600000 /* m_Mobile.NextSkillTime */ >= 0 /* && m_TreeTiles.Contains( staticTile.ID ) */ )
					{
						_ = DoHarvest();
						return base.DoActionWander();
					}
				}

				return base.DoActionWander();
			}

			return base.DoActionWander();
		}

		private bool EmptyPack()
		{
			TransientMediumCrate container = null;
			var items = m_Mobile.Backpack.Items;
			var p = new Point3D(m_Mobile.X, m_Mobile.Y, m_Mobile.Z);

			if (items.Count > 0)
			{
				foreach (var item in m_Mobile.Map.GetItemsInRange(p, 5))
				{
					if (item is TransientMediumCrate)
					{
						container = (TransientMediumCrate)item;
						if (container.Weight > 300)
						{
							continue;
						}
						else
						{
							container = (TransientMediumCrate)item;
							break;
						}
					}
				}

				var randomX = Utility.RandomMinMax(-2, 1);
				var randomY = Utility.RandomMinMax(-2, 1);

				if (container == null || container.Weight > 300)
				{
					/* m_Mobile.PlaySound( 0x23D );
					m_Mobile.Animate( 9, 5, 1, true, false, 0 ); */

					container = new TransientMediumCrate();
					var newPoint = new Point3D(p.X + randomX, p.Y + randomY, p.Z);
					container.MoveToWorld(newPoint, m_Mobile.Map);
				}

				for (var i = 0; i < items.Count; i++)
				{
					//randomize placement of items in container so they're not all stacked on stop of eachother
					var randX = Utility.RandomMinMax(0, 100);
					var randY = Utility.RandomMinMax(0, 100);

					//items in Containers do not have a Z coordinate
					if (container != null || !container.Deleted)
					{
						_ = container.OnDragDropInto(m_Mobile, items[i], new Point3D(randX, randY, 0));
					}
				}

				items = m_Mobile.Backpack.Items;

				if (items.Count >= 1)
				{
					for (var i = 0; i < items.Count; i++)
					{
						items[i].Delete();
						/* //randomize placement of items in container so they're not all stacked on stop of eachother
                        randX = Utility.RandomMinMax(0, 100);
                        randY = Utility.RandomMinMax(0, 100);

                        //items in Containers do not have a Z coordinate
                        if (container != null || !container.Deleted)
                            container.OnDragDropInto(m_Mobile, items[i], new Point3D(randX, randY, 0)); */
					}
				}
			}

			m_Mobile.CantWalk = false;

			return true;
		}

		//Modified version of what's in Server/Mobile so we don't drop items to ground if it can't be placed in backpack while harvesting
		public bool TryAddToBackpack(Item item)
		{
			if (item.Deleted)
			{
				return false;
			}

			if (!m_Mobile.PlaceInBackpack(item))
			{
				item.Delete();
				return false;
			}

			return true;
		}

		public bool DoHarvest()
		{
			if (m_Mobile.Map == null || m_Mobile.Deleted)
			{
				return base.DoActionWander();
			}

			if (m_Mobile.harvestDefinition == null)
			{
				return base.DoActionWander();
			}

			if (m_Mobile.Map == Map.Internal)
			{
				return false;
			}

			if (m_Mobile.Backpack == null)
			{
				m_Mobile.AddItem(new Backpack());
			}

			var map = m_Mobile.Map;
			var loc = m_Mobile.Location;

			var bank = m_Mobile.harvestDefinition.GetBank(map, loc.X, loc.Y);

			var available = bank != null && bank.Current >= m_Mobile.harvestDefinition.ConsumedPerHarvest;

			if (!available)
			{
				//m_Mobile.Emote( String.Format("There is no wood here to harvest") );
				return base.DoActionWander();
			}

			if (bank == null || bank.Current < m_Mobile.harvestDefinition.ConsumedPerHarvest)
			{
				return base.DoActionWander();
			}

			var vein = bank.Vein;

			if (vein == null)
			{
				return base.DoActionWander();
			}

			var primary = vein.PrimaryResource;
			var fallback = m_Mobile.harvestDefinition.Resources[0];

			var resource = m_Mobile.harvestSystem.MutateResource(m_Mobile, null, m_Mobile.harvestDefinition, map, loc, vein, primary, fallback);

			var skillBase = m_Mobile.Skills[m_Mobile.harvestDefinition.Skill].Base;

			if (skillBase >= resource.ReqSkill && m_Mobile.CheckSkill(m_Mobile.harvestDefinition.Skill, resource.MinSkill, resource.MaxSkill))
			{
				var type = m_Mobile.harvestSystem.GetResourceType(m_Mobile, null, m_Mobile.harvestDefinition, map, loc, resource);

				if (type != null)
				{
					type = m_Mobile.harvestSystem.MutateType(type, m_Mobile, null, m_Mobile.harvestDefinition, map, loc, resource);
				}

				if (type != null)
				{
					var itemHarvested = m_Mobile.harvestSystem.Construct(type, m_Mobile);

					if (itemHarvested != null)
					{
						if (itemHarvested.Stackable)
						{
							var amount = m_Mobile.harvestDefinition.ConsumedPerHarvest;
							var feluccaAmount = m_Mobile.harvestDefinition.ConsumedPerFeluccaHarvest;

							var inFelucca = map == Map.Felucca;

							if (inFelucca)
							{
								itemHarvested.Amount = feluccaAmount;
							}
							else
							{
								itemHarvested.Amount = amount;
							}
						}

						bank.Consume(itemHarvested.Amount, m_Mobile);

						var pack = m_Mobile.Backpack;

						if (pack == null)
						{
							return base.DoActionWander();
						}

						_ = pack.TryDropItem(m_Mobile, itemHarvested, false);

						// Harvest bark fragment, amber, etc
						var bonus = m_Mobile.harvestDefinition.GetBonusResource();

						if (bonus != null && bonus.Type != null && skillBase >= bonus.ReqSkill)
						{
							var bonusItem = m_Mobile.harvestSystem.Construct(bonus.Type, m_Mobile);

							_ = pack.TryDropItem(m_Mobile, bonusItem, false);
						}
					}
				}
			}

			return base.DoActionWander();
		}

		/* 
		public virtual bool WalkMobileRange(Point3D m, int iSteps, bool bRun, int iWantDistMin, int iWantDistMax)
		{
			if (m_Mobile.Deleted || m_Mobile.DisallowAllMoves)
				return false;

			if (m_Mobile.Location != m)
			{
				for (int i = 0; i < iSteps; i++)
				{
					// Get the curent distance
					int iCurrDist = (int)m_Mobile.GetDistanceToSqrt(m);

					if (iCurrDist < iWantDistMin || iCurrDist > iWantDistMax)
					{
						bool needCloser = (iCurrDist > iWantDistMax);
						bool needFurther = !needCloser;

						if (needCloser && m_Path != null && m_Mobile.Location == m )
						{
							if (m_Path.Follow(bRun, 1))
								m_Path = null;
						}
						else
						{
							Direction dirTo = (Direction)m_Mobile.GetDirectionTo( m );

						

							// Add the run flag
							if (bRun)
								dirTo = dirTo | Direction.Running;

							if (!DoMove(dirTo, true) && needCloser)
							{
								m_Path = new PathFollower(m_Mobile, m);
								m_Path.Mover = new MoveMethod(DoMoveImpl);

								if (m_Path.Follow(bRun, 1))
									m_Path = null;
							}
							else
							{
								m_Path = null;
							}
						}
					}
					else
					{
						return true;
					}
				}

				// Get the curent distance
				int iNewDist = (int)m_Mobile.GetDistanceToSqrt(m);

				if (iNewDist >= iWantDistMin && iNewDist <= iWantDistMax)
					return true;
				else
					return false;
			}
            else
            {
                return true;
            }

			return false;
		} 
		*/

		public override bool DoActionCombat()
		{
			var combatant = m_Mobile.Combatant;

			if (combatant == null || combatant.Deleted || combatant.Map != m_Mobile.Map)
			{
				m_Mobile.DebugSay("My combatant is gone..");

				Action = ActionType.Wander;

				return true;
			}

			if (WalkMobileRange(combatant, 1, true, m_Mobile.RangeFight, m_Mobile.RangeFight))
			{
				m_Mobile.Direction = m_Mobile.GetDirectionTo(combatant);
			}
			else if (m_Mobile.GetDistanceToSqrt(combatant) > m_Mobile.RangePerception + 1)
			{
				m_Mobile.DebugSay("I cannot find {0}", combatant.Name);

				Action = ActionType.Wander;

				return true;
			}
			else if (m_Mobile.Debug)
			{
				m_Mobile.DebugSay("I should be closer to {0}", combatant.Name);
			}

			if (!m_Mobile.Controlled && !m_Mobile.Summoned && m_Mobile.CanFlee)
			{
				var hitPercent = m_Mobile.Hits / (double)m_Mobile.HitsMax;

				if (hitPercent < 0.1)
				{
					m_Mobile.DebugSay("I am low on health!");

					Action = ActionType.Flee;
				}
			}

			return true;
		}

		public override bool DoActionBackoff()
		{
			var hitPercent = m_Mobile.Hits / (double)m_Mobile.HitsMax;

			if (!m_Mobile.Summoned && !m_Mobile.Controlled && hitPercent < 0.1 && m_Mobile.CanFlee) // Less than 10% health
			{
				Action = ActionType.Flee;
			}
			else if (AcquireFocusMob(m_Mobile.RangePerception * 2, FightMode.Closest, true, false, true))
			{
				if (WalkMobileRange(m_Mobile.FocusMob, 1, false, m_Mobile.RangePerception, m_Mobile.RangePerception * 2))
				{
					m_Mobile.DebugSay("Well, here I am safe");

					Action = ActionType.Wander;
				}
			}
			else
			{
				m_Mobile.DebugSay("I have lost my focus, lets relax");
				Action = ActionType.Wander;
			}

			return true;
		}

		public override bool DoActionFlee()
		{
			_ = AcquireFocusMob(m_Mobile.RangePerception * 2, m_Mobile.FightMode, true, false, true);

			m_Mobile.FocusMob ??= m_Mobile.Combatant;

			return base.DoActionFlee();
		}
	}
}