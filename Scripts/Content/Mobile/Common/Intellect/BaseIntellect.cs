using Server.ContextMenus;
using Server.Engines.Quests.Definitions;
using Server.Engines.Quests.Items;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server.Spells;
using Server.Spells.Spellweaving;
using Server.Targeting;
using Server.Targets;

using System;
using System.Collections.Generic;
using System.IO;

using MoveImpl = Server.Movement.MovementImpl;

namespace Server.Mobiles
{
	public enum AIType
	{
		AI_Use_Default,
		AI_Melee,
		AI_Animal,
		AI_Archer,
		AI_Healer,
		AI_Vendor,
		AI_Mage,
		AI_Berserk,
		AI_Predator,

		#region ActionAI
		AI_ActionAI,
		#endregion

		AI_Thief
	}

	public enum ActionType
	{
		Wander,
		Combat,
		Guard,
		Flee,
		Backoff,
		Interact
	}

	public abstract class BaseAI
	{
		public Timer m_Timer;
		protected ActionType m_Action;
		private long m_NextStopGuard;

		public BaseCreature m_Mobile;

		public BaseAI(BaseCreature m)
		{
			m_Mobile = m;

			m_Timer = new AITimer(this);

			bool activate;

			if (!m.PlayerRangeSensitive)
			{
				activate = true;
			}
			else if (World.Loading)
			{
				activate = false;
			}
			else if (m.Map == null || m.Map == Map.Internal || !m.Map.GetSector(m).Active)
			{
				activate = false;
			}
			else
			{
				activate = true;
			}

			if (activate)
			{
				m_Timer.Start();
			}

			Action = ActionType.Wander;
		}

		public ActionType Action
		{
			get => m_Action;
			set
			{
				m_Action = value;
				OnActionChanged();
			}
		}

		public virtual bool WasNamed(string speech)
		{
			var name = m_Mobile.Name;

			return (name != null && Insensitive.StartsWith(speech, name));
		}

		private class InternalEntry : ContextMenuEntry
		{
			private readonly Mobile m_From;
			private readonly BaseCreature m_Mobile;
			private readonly BaseAI m_AI;
			private readonly OrderType m_Order;

			public InternalEntry(Mobile from, int number, int range, BaseCreature mobile, BaseAI ai, OrderType order)
				: base(number, range)
			{
				m_From = from;
				m_Mobile = mobile;
				m_AI = ai;
				m_Order = order;

				if (mobile.IsDeadPet && (order == OrderType.Guard || order == OrderType.Attack || order == OrderType.Transfer || order == OrderType.Drop))
				{
					Enabled = false;
				}
			}

			public override void OnClick()
			{
				if (!m_Mobile.Deleted && m_Mobile.Controlled && m_From.CheckAlive())
				{
					if (m_Mobile.IsDeadPet && (m_Order == OrderType.Guard || m_Order == OrderType.Attack || m_Order == OrderType.Transfer || m_Order == OrderType.Drop))
					{
						return;
					}

					var isOwner = (m_From == m_Mobile.ControlMaster);
					var isFriend = (!isOwner && m_Mobile.IsPetFriend(m_From));

					if (!isOwner && !isFriend)
					{
						return;
					}
					else if (isFriend && m_Order != OrderType.Follow && m_Order != OrderType.Stay && m_Order != OrderType.Stop)
					{
						return;
					}

					switch (m_Order)
					{
						case OrderType.Follow:
						case OrderType.Attack:
						case OrderType.Transfer:
						case OrderType.Friend:
						case OrderType.Unfriend:
							{
								if (m_Order == OrderType.Transfer && m_From.HasTrade)
								{
									m_From.SendLocalizedMessage(1010507); // You cannot transfer a pet with a trade pending
								}
								else if (m_Order == OrderType.Friend && m_From.HasTrade)
								{
									m_From.SendLocalizedMessage(1070947); // You cannot friend a pet with a trade pending
								}
								else
								{
									m_AI.BeginPickTarget(m_From, m_Order);
								}

								break;
							}
						case OrderType.Release:
							{
								if (m_Mobile.Summoned)
								{
									goto default;
								}
								else
								{
									m_From.SendGump(new Gumps.ConfirmReleaseGump(m_From, m_Mobile));
								}

								break;
							}
						default:
							{
								if (m_Mobile.CheckControlChance(m_From))
								{
									m_Mobile.ControlOrder = m_Order;
								}

								break;
							}
					}
				}
			}
		}

		public virtual void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			if (from.Alive && m_Mobile.Controlled && from.InRange(m_Mobile, 14))
			{
				if (from == m_Mobile.ControlMaster)
				{
					list.Add(new InternalEntry(from, 6107, 14, m_Mobile, this, OrderType.Guard));  // Command: Guard
					list.Add(new InternalEntry(from, 6108, 14, m_Mobile, this, OrderType.Follow)); // Command: Follow

					if (m_Mobile.CanDrop)
					{
						list.Add(new InternalEntry(from, 6109, 14, m_Mobile, this, OrderType.Drop));   // Command: Drop
					}

					list.Add(new InternalEntry(from, 6111, 14, m_Mobile, this, OrderType.Attack)); // Command: Kill

					list.Add(new InternalEntry(from, 6112, 14, m_Mobile, this, OrderType.Stop));   // Command: Stop
					list.Add(new InternalEntry(from, 6114, 14, m_Mobile, this, OrderType.Stay));   // Command: Stay

					if (!m_Mobile.Summoned && !(m_Mobile is GrizzledMare))
					{
						list.Add(new InternalEntry(from, 6110, 14, m_Mobile, this, OrderType.Friend)); // Add Friend
						list.Add(new InternalEntry(from, 6099, 14, m_Mobile, this, OrderType.Unfriend)); // Remove Friend
						list.Add(new InternalEntry(from, 6113, 14, m_Mobile, this, OrderType.Transfer)); // Transfer
					}

					list.Add(new InternalEntry(from, 6118, 14, m_Mobile, this, OrderType.Release)); // Release
				}
				else if (m_Mobile.IsPetFriend(from))
				{
					list.Add(new InternalEntry(from, 6108, 14, m_Mobile, this, OrderType.Follow)); // Command: Follow
					list.Add(new InternalEntry(from, 6112, 14, m_Mobile, this, OrderType.Stop));   // Command: Stop
					list.Add(new InternalEntry(from, 6114, 14, m_Mobile, this, OrderType.Stay));   // Command: Stay
				}
			}
		}

		public virtual void BeginPickTarget(Mobile from, OrderType order)
		{
			if (m_Mobile.Deleted || !m_Mobile.Controlled || !from.InRange(m_Mobile, 14) || from.Map != m_Mobile.Map)
			{
				return;
			}

			var isOwner = (from == m_Mobile.ControlMaster);
			var isFriend = (!isOwner && m_Mobile.IsPetFriend(from));

			if (!isOwner && !isFriend)
			{
				return;
			}
			else if (isFriend && order != OrderType.Follow && order != OrderType.Stay && order != OrderType.Stop)
			{
				return;
			}

			if (from.Target == null)
			{
				if (order == OrderType.Transfer)
				{
					from.SendLocalizedMessage(502038); // Click on the person to transfer ownership to.
				}
				else if (order == OrderType.Friend)
				{
					from.SendLocalizedMessage(502020); // Click on the player whom you wish to make a co-owner.
				}
				else if (order == OrderType.Unfriend)
				{
					from.SendLocalizedMessage(1070948); // Click on the player whom you wish to remove as a co-owner.
				}

				from.Target = new AIControlMobileTarget(this, order);
			}
			else if (from.Target is AIControlMobileTarget)
			{
				var t = (AIControlMobileTarget)from.Target;

				if (t.Order == order)
				{
					t.AddAI(this);
				}
			}
		}

		public virtual void OnAggressiveAction(Mobile aggressor)
		{
			var currentCombat = m_Mobile.Combatant;

			if (currentCombat != null && !aggressor.Hidden && currentCombat != aggressor && m_Mobile.GetDistanceToSqrt(currentCombat) > m_Mobile.GetDistanceToSqrt(aggressor))
			{
				m_Mobile.Combatant = aggressor;
			}
		}

		public virtual void EndPickTarget(Mobile from, Mobile target, OrderType order)
		{
			if (m_Mobile.Deleted || !m_Mobile.Controlled || !from.InRange(m_Mobile, 14) || from.Map != m_Mobile.Map || !from.CheckAlive())
			{
				return;
			}

			var isOwner = (from == m_Mobile.ControlMaster);
			var isFriend = (!isOwner && m_Mobile.IsPetFriend(from));

			if (!isOwner && !isFriend)
			{
				return;
			}
			else if (isFriend && order != OrderType.Follow && order != OrderType.Stay && order != OrderType.Stop)
			{
				return;
			}

			if (order == OrderType.Attack)
			{
				if (target is BaseCreature && ((BaseCreature)target).IsScaryToPets && m_Mobile.IsScaredOfScaryThings)
				{
					m_Mobile.SayTo(from, "Your pet refuses to attack this creature!");
					return;
				}

				if ((SolenHelper.CheckRedFriendship(from) &&
							(target is RedSolenInfiltratorQueen
							|| target is RedSolenInfiltratorWarrior
							|| target is RedSolenQueen
							|| target is RedSolenWarrior
							|| target is RedSolenWorker))
					|| (SolenHelper.CheckBlackFriendship(from) &&
							(target is BlackSolenInfiltratorQueen
							|| target is BlackSolenInfiltratorWarrior
							|| target is BlackSolenQueen
							|| target is BlackSolenWarrior
							|| target is BlackSolenWorker)))
				{
					from.SendAsciiMessage("You can not force your pet to attack a creature you are protected from.");
					return;
				}

				if (target is Factions.BaseFactionGuard)
				{
					m_Mobile.SayTo(from, "Your pet refuses to attack the guard.");
					return;
				}
			}

			if (m_Mobile.CheckControlChance(from))
			{
				m_Mobile.ControlTarget = target;
			
