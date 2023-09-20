using Server.Engines.Harvest;
using Server.Items;
using Server.Multis;
using Server.Spells;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Mobiles
{
	public class ActionAI : BaseAI
	{
		private static readonly Type _ActionLock = typeof(ActionAI);

		private Timer _ActionLockTimer;

		public bool IsActionLocked => !m_Mobile.CanBeginAction(_ActionLock);

		public ActionAI(BaseCreature m)
			: base(m)
		{
		}

		protected void UnlockActions()
		{
			_ActionLockTimer?.Stop();
			_ActionLockTimer = null;

			m_Mobile.CantWalk = false;

			m_Mobile.EndAction(_ActionLock);
		}

		protected void LockActions(TimeSpan duration)
		{
			if (duration <= TimeSpan.Zero)
			{
				return;
			}

			_ActionLockTimer?.Stop();

			if (duration < TimeSpan.MaxValue)
			{
				_ActionLockTimer = Timer.DelayCall(duration, UnlockActions);
			}

			m_Mobile.CantWalk = true;

			_ = m_Mobile.BeginAction(_ActionLock);
		}
		
		public override bool DoActionWander()
		{
			if (IsActionLocked)
			{
				return false;
			}

			if (m_Mobile.Home != Point3D.Zero && m_Mobile.Backpack != null)
			{
				if (Utility.InRange(m_Mobile.Home, m_Mobile.Location, 2))
				{
					if (DoActionOffload())
					{
						return true;
					}
				}
				else if (m_Mobile.Backpack.TotalWeight <= m_Mobile.Backpack.MaxWeight)
				{
					if (DoActionHarvest())
					{
						return true;
					}
				}
			}

			return base.DoActionWander();
		}

		public virtual bool DoActionOffload()
		{
			if (IsActionLocked)
			{
				return false;
			}

			if (m_Mobile.Combatant != null)
			{
				return false;
			}

			var map = m_Mobile.Map;

			if (map == null || map == Map.Internal)
			{
				return false;
			}

			var items = m_Mobile.Backpack?.Items;

			if (items == null || items.Count == 0)
			{
				return false;
			}

			TransientMediumCrate container = null;

			var eable = map.GetItemsInRange(m_Mobile.Location, 5);

			foreach (var item in eable)
			{
				if (item is TransientMediumCrate c && (c.MaxItems <= 0 || c.TotalItems < c.MaxItems) && (c.MaxWeight <= 0 || c.TotalWeight < c.MaxWeight))
				{
					container = c;
					break;
				}
			}

			eable.Free();

			int x = m_Mobile.X, y = m_Mobile.Y, z = m_Mobile.Z;

			Movement.Movement.Offset(m_Mobile.Direction & Direction.Mask, ref x, ref y);

			var loc = new Point3D(x, y, z);

			if (container == null)
			{
				loc = map.GetTopSurface(loc.X, loc.Y);

				if (!SpellHelper.AdjustField(ref loc, map, 10, false))
				{
					return false;
				}

				container = new TransientMediumCrate()
				{
					Movable = false
				};

				container.MoveToWorld(loc, map);

				Effects.SendMovingEffect(m_Mobile, container, container.ItemID, 5, 10, true, false, 0, 0);
			}
			else
			{
				loc = container.Location;
			}

			var dropInterval = TimeSpan.FromMilliseconds(Math.Max(500, Mobile.ActionDelay));

			LockActions(TimeSpan.FromSeconds(1.0 + (items.Count * dropInterval.TotalSeconds)));

			Timer t = null;

			t = Timer.DelayCall(TimeSpan.Zero, dropInterval, items.Count, q =>
			{
				if (m_Mobile?.Deleted != false || m_Mobile.Combatant != null || m_Mobile.Map != map || !m_Mobile.InRange(loc, 2))
				{
					UnlockActions();

					t?.Stop();

					return;
				}

				if (!q.TryDequeue(out var o))
				{
					t?.Stop();

					return;
				}

				if (o.Deleted || !o.Movable)
				{
					return;
				}

				IEntity e;

				if (!container.Deleted && container.TryDropItem(m_Mobile, o, false))
				{
					e = container;
				}
				else if (map.CanFit(loc, o.ItemData.CalcHeight))
				{
					e = EffectItem.Create(loc, map, dropInterval);

					o.MoveToWorld(loc, map);
				}
				else
				{
					UnlockActions();

					t?.Stop();

					return;
				}

				Effects.SendMovingEffect(m_Mobile, e, o.ItemID, 5, 10, true, false, 0, 0);

				if (q.Count % 2 == 0)
				{
					m_Mobile.Animate(32, 5, 0, true, false, 0); // bow
				}
			}, new Queue<Item>(items));

			return true;
		}

		public virtual bool DoActionHarvest()
		{
			if (IsActionLocked)
			{
				return false;
			}

			if (m_Mobile.Combatant != null)
			{
				return false;
			}

			var map = m_Mobile.Map;

			if (map == null || map == Map.Internal)
			{
				return false;
			}

			if (m_Mobile.Harvest is not HarvestSystem harvest)
			{
				return false;
			}

			IHarvestTool tool = null;

			if (m_Mobile.Weapon is IHarvestTool wt && wt.HarvestSystem == harvest)
			{
				tool = wt;
			}

			if (tool == null)
			{
				foreach (var o in m_Mobile.Items)
				{
					if (o is IHarvestTool t)
					{
						if (t.HarvestSystem != harvest)
						{
							continue;
						}

						if (t is IUsesRemaining u)
						{
							if (u.UsesRemaining > 0)
							{
								tool = t;
							}
						}
						else
						{
							tool = t;
						}
					}
				}
			}

			if (tool == null && m_Mobile.Backpack != null)
			{
				foreach (var o in m_Mobile.Backpack.Items)
				{
					if (o is IHarvestTool t)
					{
						if (t.HarvestSystem != harvest)
						{
							continue;
						}

						if (t is IUsesRemaining u)
						{
							if (u.UsesRemaining > 0)
							{
								tool = t;
							}
						}
						else
						{
							tool = t;
						}
					}
				}

				if (tool is Item item && item.Layer != Layer.Invalid && m_Mobile.FindItemOnLayer(item.Layer) == null)
				{
					m_Mobile.EquipItem(item);
				}
			}

			if (tool == null)
			{
				return false;
			}

			const int range = 1;

			for (var xo = -range; xo <= range; xo++)
			{
				for (var yo = -range; yo <= range; yo++)
				{
					if (xo == 0 && yo == 0)
					{
						continue;
					}

					var loc = m_Mobile.Location;

					loc.X += xo;
					loc.Y += yo;

					var multi = false;

					var eable = map.GetMultiTilesAt(loc.X, loc.Y);

					foreach (var mt in eable)
					{
						if (mt.Length > 0)
						{
							multi = true;
							break;
						}
					}

					eable.Free();

					if (multi)
					{
						continue;
					}

					IPoint3D harvesting = null;

					var land = map.Tiles.GetLandTile(loc.X, loc.Y);

					if (Math.Abs(land.Z - m_Mobile.Z) > 20)
					{
						loc.Z = land.Z;

						var landTarget = new LandTarget(loc, map);

						if (harvest.GetHarvestDetails(m_Mobile, tool, landTarget, out _, out _, out _))
						{
							harvesting = landTarget;
						}
					}

					if (harvesting == null)
					{
						var statics = map.Tiles.GetStaticTiles(loc.X, loc.Y, false);

						foreach (var tile in statics)
						{
							if (Math.Abs(tile.Z - m_Mobile.Z) > 20)
							{
								continue;
							}

							loc.Z = tile.Z;

							var staticTarget = new StaticTarget(loc, tile.ID, tile.Hue);

							if (harvest.GetHarvestDetails(m_Mobile, tool, staticTarget, out _, out _, out _))
							{
								harvesting = staticTarget;
								break;
							}
						}
					}

					if (harvesting != null)
					{
						m_Mobile.Direction = m_Mobile.GetDirectionTo(harvesting);

						if (harvest.StartHarvesting(m_Mobile, tool, harvesting))
						{
							var timer = HarvestTimer.Get(m_Mobile);

							var duration = Math.Max(0, timer?.TimeRemaining.TotalSeconds ?? 0);

							LockActions(TimeSpan.FromSeconds(1.0 + duration));

							return true;
						}
					}
				}
			}

			return false;
		}

		public override bool DoActionCombat()
		{
			if (IsActionLocked)
			{
				return false;
			}

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
			else
			{
				m_Mobile.DebugSay("I should be closer to {0}", combatant.Name);
			}

			if (!m_Mobile.Controlled && !m_Mobile.Summoned && m_Mobile.CanFlee)
			{
				var hitPercent = m_Mobile.Hits / (double)m_Mobile.HitsMax;

				if (hitPercent < 0.10)
				{
					m_Mobile.DebugSay("I am low on health!");

					Action = ActionType.Flee;
				}
			}

			return true;
		}

		public override bool DoActionBackoff()
		{
			if (IsActionLocked)
			{
				return false;
			}

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
			if (IsActionLocked)
			{
				return false;
			}

			if (AcquireFocusMob(m_Mobile.RangePerception * 2, m_Mobile.FightMode, true, false, true))
			{
				m_Mobile.FocusMob ??= m_Mobile.Combatant;
			}

			return base.DoActionFlee();
		}

		public override bool DoActionGuard()
		{
			if (IsActionLocked)
			{
				return false;
			}

			return base.DoActionGuard();
		}

		public override bool DoActionInteract()
		{
			if (IsActionLocked)
			{
				return false;
			}

			return base.DoActionInteract();
		}
	}
}