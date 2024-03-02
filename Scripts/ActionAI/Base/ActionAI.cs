using Server.Engines.Harvest;
using Server.Items;
using Server.Multis;
using Server.Spells;
using Server.Spells.Magery;

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

		public bool TryCastRecall(Point3D loc, Map map)
		{
			if (loc == Point3D.Zero || map == null || map == Map.Internal)
			{
				return false;
			}

			var info = SpellRegistry.GetInfo(SpellName.Recall);

			if (info != null && m_Mobile.Skills.Magery.Value >= info.Skill)
			{
				var recall = new RecallSpell(m_Mobile, loc, map);

				if (recall.Cast())
				{
					LockActions(recall.GetCastDelay());

					return true;
				}
			}

			return false;
		}

		protected virtual IHarvestTool FindTool(IHarvestSystem harvest)
		{
			if (m_Mobile.Weapon is IHarvestTool wt && wt.HarvestSystem == harvest)
			{
				return wt;
			}

			IHarvestTool tool;

			if ((tool = FindTool(m_Mobile.Items, false, harvest)) != null)
			{
				return tool;
			}

			if ((tool = FindTool(m_Mobile.Backpack?.Items, false, harvest)) != null)
			{
				return tool;
			}

			if (m_Mobile.Map != null && m_Mobile.Map != Map.Internal)
			{
				var eable = m_Mobile.Map.GetMobilesInRange(m_Mobile.Location, m_Mobile.RangePerception);

				try
				{
					foreach (var m in eable)
					{
						if (m is BaseCreature c && c.ControlMaster == m_Mobile && c is IPackAnimal)
						{
							if ((tool = FindTool(m.Backpack?.Items, true, harvest)) != null)
							{
								return tool;
							}
						}
					}
				}
				finally
				{
					eable.Free();
				}
			}

			return null;
		}

		protected virtual IHarvestTool FindTool(List<Item> items, bool recursive, IHarvestSystem harvest)
		{
			if (items != null)
			{
				foreach (var o in items)
				{
					if (o is IHarvestTool t)
					{
						if (t.HarvestSystem == harvest)
						{
							return t;
						}
					}
					else if (recursive)
					{
						return FindTool(o.Items, recursive, harvest);
					}
				}
			}

			return null;
		}

		protected virtual bool CheckHarvest()
		{
			var pack = m_Mobile.Backpack;

			if (pack != null && (pack.MaxItems <= 0 || pack.TotalItems < pack.MaxItems) && (pack.MaxWeight <= 0 || pack.TotalWeight <= pack.MaxWeight))
			{
				if (Utility.RandomDouble() <= 0.10)
				{
					return true;
				}
			}

			return false;
		}

		protected virtual bool CheckOffload()
		{
			var pack = m_Mobile.Backpack;

			if (pack != null && ((pack.MaxItems > 0 && pack.TotalItems >= pack.MaxItems) || (pack.MaxWeight > 0 && pack.TotalWeight > pack.MaxWeight)))
			{
				if (m_Mobile.Home != Point3D.Zero)
				{
					if (Utility.InRange(m_Mobile.Home, m_Mobile.Location, 2))
					{
						return true;
					}

					_ = MoveTo(m_Mobile.Home, false, 2);
				}
			}

			return false;
		}

		protected virtual bool CheckReturnHome()
		{
			if (m_Mobile.Formation == null && m_Mobile.ReturnsToHome && m_Mobile.Home != Point3D.Zero)
			{
				var dist = m_Mobile.GetHomeDistance();

				if (dist > m_Mobile.RangePerception && dist > m_Mobile.RangeHome)
				{
					return true;
				}

				_ = MoveTo(m_Mobile.Home, false, 2);
			}

			return false;
		}

		protected override bool OnThink()
		{
			if (base.OnThink())
			{
				return true;
			}

			if (CheckHarvest())
			{
				Action = ActionType.Harvest;
			}
			else if (CheckOffload())
			{
				Action = ActionType.Offload;
			}

			return false;
		}

		public override bool DoActionWander()
		{
			if (IsActionLocked)
			{
				return true;
			}
			
			if (CheckReturnHome())
			{
				if (TryCastRecall(m_Mobile.Home, m_Mobile.Map))
				{
					return true;
				}
			}

			return base.DoActionWander();
		}

		public override bool DoActionOffload()
		{
			if (IsActionLocked)
			{
				return true;
			}

			if (m_Mobile.Combatant != null)
			{
				Action = ActionType.Combat;

				return true;
			}

			var map = m_Mobile.Map;

			if (map == null || map == Map.Internal)
			{
				Action = ActionType.Wander;

				return true;
			}

			var items = m_Mobile.Backpack?.Items;

			if (items == null || items.Count == 0)
			{
				Action = ActionType.Wander;

				return true;
			}

			TransientMediumCrate container = null;

			var eable = map.GetItemsInRange(m_Mobile.Location, 5);

			try
			{
				foreach (var item in eable)
				{
					if (item is TransientMediumCrate c && (c.MaxItems <= 0 || c.TotalItems < c.MaxItems) && (c.MaxWeight <= 0 || c.TotalWeight < c.MaxWeight))
					{
						container = c;
						break;
					}
				}
			}
			finally
			{
				eable.Free();
			}

			int x = m_Mobile.X, y = m_Mobile.Y, z = m_Mobile.Z;

			Movement.Movement.Offset(m_Mobile.Direction & Direction.Mask, ref x, ref y);

			var loc = new Point3D(x, y, z);

			if (container == null)
			{
				loc = map.GetTopSurface(loc.X, loc.Y);

				if (!SpellHelper.AdjustField(ref loc, map, 10, false))
				{
					Action = ActionType.Wander;

					return true;
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
					SpellHelper.Turn(m_Mobile, e);

					m_Mobile.Animate(32, 5, 0, true, false, 0); // bow
				}
			}, new Queue<Item>(items));

			Action = ActionType.Wander;

			return true;
		}

		public override bool DoActionHarvest()
		{
			if (IsActionLocked)
			{
				return true;
			}

			if (m_Mobile.Combatant != null)
			{
				Action = ActionType.Combat;

				return true;
			}

			var map = m_Mobile.Map;

			if (map == null || map == Map.Internal)
			{
				Action = ActionType.Wander;

				return true;
			}

			if (m_Mobile.Harvest is not HarvestSystem harvest)
			{
				Action = ActionType.Wander;

				return true;
			}

			var tool = FindTool(harvest);

			if (tool == null)
			{
				var eable = m_Mobile.Map.GetMobilesInRange(m_Mobile.Location, m_Mobile.RangePerception);

				try
				{
					foreach (var v in eable.OfType<BaseVendor>().OrderBy(m_Mobile.GetDistanceToSqrt))
					{
						foreach (var info in v.BuyInfo)
						{
							if (info.Amount <= 0)
							{
								continue;
							}

							var disp = info.GetDisplayEntity();

							if (disp is not Item i || i is not IHarvestTool t || t.HarvestSystem != harvest)
							{
								continue;
							}

							if (!m_Mobile.InRange(v, 2))
							{
								MoveTo(v, false, 2);

								return true;
							}

							LockActions(TimeSpan.FromSeconds(3.0));

							SpellHelper.Turn(v, m_Mobile);
							SpellHelper.Turn(m_Mobile, v);

							var e = info.GetEntity();

							if (e is Item o)
							{
								if (m_Mobile.PlaceInBackpack(o))
								{
									--info.Amount;

									EventSink.InvokeBuyFromVendor(new BuyFromVendorEventArgs(m_Mobile, v, o, 1));

									return true;
								}

								Action = ActionType.Offload;
							}

							e?.Delete();

							return true;
						}
					}
				}
				finally
				{
					eable.Free();
				}
			}

			if (tool == null)
			{
				Action = ActionType.Wander;

				return true;
			}

			if (tool is Item item && item.Parent != m_Mobile && item.Layer != Layer.Invalid)
			{
				var conflict = item.Layer switch
				{
					Layer.OneHanded => m_Mobile.FindItemOnLayer(Layer.TwoHanded),
					Layer.TwoHanded => m_Mobile.FindItemOnLayer(Layer.OneHanded),

					_ => m_Mobile.FindItemOnLayer(item.Layer),
				};

				if (conflict == null)
				{
					m_Mobile.EquipItem(item);
				}
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

					try
					{
						foreach (var mt in eable)
						{
							if (mt.Length > 0)
							{
								multi = true;
								break;
							}
						}
					}
					finally
					{
						eable.Free();
					}

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

							Action = ActionType.Wander;

							return true;
						}
					}
				}
			}

			Action = ActionType.Wander;

			return base.DoActionHarvest();
		}

		public override bool DoActionCombat()
		{
			if (IsActionLocked)
			{
				return true;
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
			else if (m_Mobile.GetDistanceToSqrt(combatant) <= m_Mobile.RangePerception + 1)
			{
				m_Mobile.DebugSay("I should be closer to {0}", combatant.Name);
			}
			else
			{
				m_Mobile.DebugSay("I cannot find {0}", combatant.Name);

				Action = ActionType.Wander;

				return true;
			}

			if (!m_Mobile.Controlled && !m_Mobile.Summoned && m_Mobile.CanFlee)
			{
				var hitPercent = m_Mobile.Hits / (double)m_Mobile.HitsMax;

				if (hitPercent < 0.10)
				{
					m_Mobile.DebugSay("I am low on health!");

					Action = ActionType.Flee;

					return true;
				}
			}

			return base.DoActionCombat();
		}

		public override bool DoActionBackoff()
		{
			if (IsActionLocked)
			{
				return true;
			}

			var hitPercent = m_Mobile.Hits / (double)m_Mobile.HitsMax;

			if (!m_Mobile.Summoned && !m_Mobile.Controlled && hitPercent < 0.1 && m_Mobile.CanFlee) // Less than 10% health
			{
				Action = ActionType.Flee;

				return true;
			}

			if (!AcquireFocusMob(m_Mobile.RangePerception * 2, FightMode.Closest, true, false, true))
			{
				m_Mobile.DebugSay("I have lost my focus, lets relax");

				Action = ActionType.Wander;

				return true;
			}
			
			if (WalkMobileRange(m_Mobile.FocusMob, 1, false, m_Mobile.RangePerception, m_Mobile.RangePerception * 2))
			{
				m_Mobile.DebugSay("Well, here I am safe");

				Action = ActionType.Wander;

				return true;
			}

			return base.DoActionBackoff();
		}

		public override bool DoActionFlee()
		{
			if (IsActionLocked)
			{
				return true;
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
				return true;
			}

			return base.DoActionGuard();
		}

		public override bool DoActionInteract()
		{
			if (IsActionLocked)
			{
				return true;
			}

			return base.DoActionInteract();
		}
	}
}