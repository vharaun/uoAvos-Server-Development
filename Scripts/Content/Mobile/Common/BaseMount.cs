using Server.Engines.VeteranRewards;
using Server.Items;
using Server.Multis;
using Server.Spells;
using Server.Targeting;

using System;

namespace Server.Mobiles
{
	/// General Mounts
	public abstract class BaseMount : BaseCreature, IMount
	{
		private Mobile m_Rider;
		private Item m_InternalItem;
		private DateTime m_NextMountAbility;

		public virtual TimeSpan MountAbilityDelay => TimeSpan.Zero;

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime NextMountAbility
		{
			get => m_NextMountAbility;
			set => m_NextMountAbility = value;
		}

		protected Item InternalItem => m_InternalItem;

		public virtual bool AllowMaleRider => true;
		public virtual bool AllowFemaleRider => true;

		public BaseMount(string name, int bodyID, int itemID, AIType aiType, FightMode fightMode, int rangePerception, int rangeFight, double activeSpeed, double passiveSpeed) : base(aiType, fightMode, rangePerception, rangeFight, activeSpeed, passiveSpeed)
		{
			Name = name;
			Body = bodyID;

			m_InternalItem = new MountItem(this, itemID);
		}

		[Hue, CommandProperty(AccessLevel.GameMaster)]
		public override int Hue
		{
			get => base.Hue;
			set
			{
				base.Hue = value;

				if (m_InternalItem != null)
				{
					m_InternalItem.Hue = value;
				}
			}
		}

		public override bool OnBeforeDeath()
		{
			Rider = null;

			return base.OnBeforeDeath();
		}

		public override void OnAfterDelete()
		{
			if (m_InternalItem != null)
			{
				m_InternalItem.Delete();
			}

			m_InternalItem = null;

			base.OnAfterDelete();
		}

		public override void OnDelete()
		{
			Rider = null;

			base.OnDelete();
		}

		public BaseMount(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version

			writer.Write(m_NextMountAbility);

			writer.Write(m_Rider);
			writer.Write(m_InternalItem);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_NextMountAbility = reader.ReadDateTime();
						goto case 0;
					}
				case 0:
					{
						m_Rider = reader.ReadMobile();
						m_InternalItem = reader.ReadItem();

						if (m_InternalItem == null)
						{
							Delete();
						}

						break;
					}
			}
		}

		public virtual void OnDisallowedRider(Mobile m)
		{
			m.SendMessage("You may not ride this creature.");
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsDeadPet)
			{
				return;
			}

			if (from.IsBodyMod && !from.Body.IsHuman)
			{
				if (Core.AOS) // You cannot ride a mount in your current form.
				{
					PrivateOverheadMessage(Network.MessageType.Regular, 0x3B2, 1062061, from.NetState);
				}
				else
				{
					from.SendLocalizedMessage(1061628); // You can't do that while polymorphed.
				}

				return;
			}

			if (!CheckMountAllowed(from))
			{
				return;
			}

			if (from.Mounted)
			{
				from.SendLocalizedMessage(1005583); // Please dismount first.
				return;
			}

			if (from.Female ? !AllowFemaleRider : !AllowMaleRider)
			{
				OnDisallowedRider(from);
				return;
			}

			if (!Multis.DesignContext.Check(from))
			{
				return;
			}

			if (from.HasTrade)
			{
				from.SendLocalizedMessage(1042317, "", 0x41); // You may not ride at this time
				return;
			}

			if (from.InRange(this, 1))
			{
				var canAccess = (from.AccessLevel >= AccessLevel.GameMaster)
					|| (Controlled && ControlMaster == from)
					|| (Summoned && SummonMaster == from);

				if (canAccess)
				{
					if (Poisoned)
					{
						PrivateOverheadMessage(Network.MessageType.Regular, 0x3B2, 1049692, from.NetState); // This mount is too ill to ride.
					}
					else
					{
						Rider = from;
					}
				}
				else if (!Controlled && !Summoned)
				{
					// That mount does not look broken! You would have to tame it to ride it.
					PrivateOverheadMessage(Network.MessageType.Regular, 0x3B2, 501263, from.NetState);
				}
				else
				{
					// This isn't your mount; it refuses to let you ride.
					PrivateOverheadMessage(Network.MessageType.Regular, 0x3B2, 501264, from.NetState);
				}
			}
			else
			{
				from.SendLocalizedMessage(500206); // That is too far away to ride.
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int ItemID
		{
			get
			{
				if (m_InternalItem != null)
				{
					return m_InternalItem.ItemID;
				}
				else
				{
					return 0;
				}
			}
			set
			{
				if (m_InternalItem != null)
				{
					m_InternalItem.ItemID = value;
				}
			}
		}

		public static void Dismount(Mobile m)
		{
			var mount = m.Mount;

			if (mount != null)
			{
				mount.Rider = null;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Rider
		{
			get => m_Rider;
			set
			{
				if (m_Rider != value)
				{
					if (value == null)
					{
						var loc = m_Rider.Location;
						var map = m_Rider.Map;

						if (map == null || map == Map.Internal)
						{
							loc = m_Rider.LogoutLocation;
							map = m_Rider.LogoutMap;
						}

						Direction = m_Rider.Direction;
						Location = loc;
						Map = map;

						if (m_InternalItem != null)
						{
							m_InternalItem.Internalize();
						}
					}
					else
					{
						if (m_Rider != null)
						{
							Dismount(m_Rider);
						}

						Dismount(value);

						if (m_InternalItem != null)
						{
							value.AddItem(m_InternalItem);
						}

						value.Direction = Direction;

						Internalize();

						if (value.Target is Bola.BolaTarget)
						{
							Target.Cancel(value);
						}
					}

					m_Rider = value;
				}
			}
		}

		// 1040024 You are still too dazed from being knocked off your mount to ride!
		// 1062910 You cannot mount while recovering from a bola throw.
		// 1070859 You cannot mount while recovering from a dismount special maneuver.

		public static bool CheckMountAllowed(Mobile mob)
		{
			var result = true;

			if ((mob is PlayerMobile) && (mob as PlayerMobile).MountBlockReason != BlockMountType.None)
			{
				mob.SendLocalizedMessage((int)(mob as PlayerMobile).MountBlockReason);

				result = false;
			}

			return result;
		}

		public virtual void OnRiderDamaged(int amount, Mobile from, bool willKill)
		{
			if (m_Rider == null)
			{
				return;
			}

			var attacker = from;
			if (attacker == null)
			{
				attacker = m_Rider.FindMostRecentDamager(true);
			}

			if (!(attacker == this || attacker == m_Rider || willKill || DateTime.UtcNow < m_NextMountAbility))
			{
				if (DoMountAbility(amount, from))
				{
					m_NextMountAbility = DateTime.UtcNow + MountAbilityDelay;
				}
			}
		}

		public virtual bool DoMountAbility(int damage, Mobile attacker)
		{
			return false;
		}
	}

	public class MountItem : Item, IMountItem
	{
		private BaseMount m_Mount;

		public override double DefaultWeight => 0;

		public MountItem(BaseMount mount, int itemID) : base(itemID)
		{
			Layer = Layer.Mount;
			Movable = false;

			m_Mount = mount;
		}

		public MountItem(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Mount != null)
			{
				m_Mount.Delete();
			}

			m_Mount = null;

			base.OnAfterDelete();
		}

		public override DeathMoveResult OnParentDeath(Mobile parent)
		{
			if (m_Mount != null)
			{
				m_Mount.Rider = null;
			}

			return DeathMoveResult.RemainEquiped;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_Mount);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Mount = reader.ReadMobile() as BaseMount;

						if (m_Mount == null)
						{
							Delete();
						}

						break;
					}
			}
		}

		public IMount Mount => m_Mount;
	}


	/// Ethereal Mounts
	public class EtherealMount : Item, IMount, IMountItem, Engines.VeteranRewards.IRewardItem
	{
		public static void StopMounting(Mobile mob)
		{
			if (mob.Spell is EtherealSpell s)
			{
				s.Stop();
			}
		}


		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsRewardItem { get; set; }

		private bool m_IsDonationItem;

		[CommandProperty(AccessLevel.GameMaster, AccessLevel.Administrator)]
		public bool IsDonationItem
		{
			get => m_IsDonationItem;
			set
			{
				m_IsDonationItem = value;

				InvalidateProperties();
			}
		}

		private int m_MountedID;

		[CommandProperty(AccessLevel.GameMaster)]
		public int MountedID
		{
			get => m_MountedID;
			set
			{
				if (m_MountedID != value)
				{
					m_MountedID = value;

					if (m_Rider != null)
					{
						ItemID = value;
					}
				}
			}
		}

		private int m_RegularID;

		[CommandProperty(AccessLevel.GameMaster)]
		public int RegularID
		{
			get => m_RegularID;
			set
			{
				if (m_RegularID != value)
				{
					m_RegularID = value;

					if (m_Rider == null)
					{
						ItemID = value;
					}
				}
			}
		}

		private Mobile m_Rider;

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Rider
		{
			get => m_Rider;
			set
			{
				if (value != m_Rider)
				{
					if (value == null)
					{
						Internalize();
						UnmountMe();
						RemoveFollowers();

						m_Rider = value;
					}
					else
					{
						if (m_Rider != null)
						{
							Dismount(m_Rider);
						}

						Dismount(value);
						RemoveFollowers();

						m_Rider = value;

						AddFollowers();
						MountMe();
					}
				}
			}
		}

		public virtual int EtherealHue => 0x4001;

		public virtual int FollowerSlots => 1;

		public override bool DisplayLootType => false;

		public override double DefaultWeight => 1.0;

		IMount IMountItem.Mount => this;

		[Constructable]
		public EtherealMount(int itemID, int mountID)
			: base(itemID)
		{
			m_MountedID = mountID;
			m_RegularID = itemID;
			m_Rider = null;

			Layer = Layer.Invalid;

			LootType = LootType.Blessed;
		}

		public EtherealMount(Serial serial)
			: base(serial)
		{
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (m_IsDonationItem)
			{
				list.Add("Donation Ethereal");
				list.Add("7.5 sec slower cast time if not a 9mo. Veteran");
			}

			if (Core.ML && IsRewardItem)
			{
				list.Add(RewardSystem.GetRewardYearLabel(this, Array.Empty<object>())); // X Year Veteran Reward
			}
		}

		public void RemoveFollowers()
		{
			if (m_Rider != null)
			{
				m_Rider.Followers -= FollowerSlots;

				if (m_Rider.Followers < 0)
				{
					m_Rider.Followers = 0;
				}
			}
		}

		public void AddFollowers()
		{
			if (m_Rider != null)
			{
				m_Rider.Followers += FollowerSlots;
			}
		}

		public virtual bool Validate(Mobile from)
		{
			if (Parent == null)
			{
				from.SayTo(from, 1010095); // This must be on your person to use.
				return false;
			}
			
			if (IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
			{
				// CheckIsUsableBy sends the message
				return false;
			}
			
			if (!BaseMount.CheckMountAllowed(from))
			{
				// CheckMountAllowed sends the message
				return false;
			}
			
			if (from.Mounted)
			{
				from.SendLocalizedMessage(1005583); // Please dismount first.
				return false;
			}
			
			if (from.IsBodyMod && !from.Body.IsHuman)
			{
				from.SendLocalizedMessage(1061628); // You can't do that while polymorphed.
				return false;
			}
			
			if (from.HasTrade)
			{
				from.SendLocalizedMessage(1042317, "", 0x41); // You may not ride at this time
				return false;
			}
			
			if ((from.Followers + FollowerSlots) > from.FollowersMax)
			{
				from.SendLocalizedMessage(1049679); // You have too many followers to summon your mount.
				return false;
			}
			
			if (!DesignContext.Check(from))
			{
				// Check sends the message
				return false;
			}

			return true;
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (Validate(from))
			{
				var s = new EtherealSpell(this, from);
				
				s.Cast();
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			base.OnSingleClick(from);

			if (m_IsDonationItem)
			{
				LabelTo(from, "Donation Ethereal");
			}
			else
			{
				LabelTo(from, "Veteran Reward");
			}
		}

		public override DeathMoveResult OnParentDeath(Mobile parent)
		{
			Rider = null; // get off, move to pack

			return DeathMoveResult.RemainEquiped;
		}

		public static void Dismount(Mobile m)
		{
			var mount = m.Mount;

			if (mount != null)
			{
				mount.Rider = null;
			}
		}

		public void UnmountMe()
		{
			var bp = m_Rider.Backpack;

			ItemID = m_RegularID;
			Layer = Layer.Invalid;
			Movable = true;

			if (Hue == EtherealHue)
			{
				Hue = 0;
			}

			if (bp != null)
			{
				bp.DropItem(this);
			}
			else
			{
				var loc = m_Rider.Location;
				var map = m_Rider.Map;

				if (map == null || map == Map.Internal)
				{
					loc = m_Rider.LogoutLocation;
					map = m_Rider.LogoutMap;
				}

				MoveToWorld(loc, map);
			}
		}

		public void MountMe()
		{
			ItemID = m_MountedID;
			Layer = Layer.Mount;
			Movable = false;

			if (Hue == 0)
			{
				Hue = EtherealHue;
			}

			ProcessDelta();

			m_Rider.ProcessDelta();
			m_Rider.EquipItem(this);
			m_Rider.ProcessDelta();

			ProcessDelta();
		}

		void IMount.OnRiderDamaged(int amount, Mobile from, bool willKill)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(3); // version

			writer.Write(m_IsDonationItem);
			writer.Write(IsRewardItem);

			writer.Write(m_MountedID);
			writer.Write(m_RegularID);
			writer.Write(m_Rider);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 3:
					{
						m_IsDonationItem = reader.ReadBool();
						goto case 2;
					}
				case 2:
					{
						IsRewardItem = reader.ReadBool();
						goto case 0;
					}
				case 1:
					{
						_ = reader.ReadInt();
						goto case 0;
					}
				case 0:
					{
						m_MountedID = reader.ReadInt();
						m_RegularID = reader.ReadInt();
						m_Rider = reader.ReadMobile();
						break;
					}
			}

			if (m_MountedID == 0x3EA2)
			{
				m_MountedID = 0x3EAA;
			}

			LootType = LootType.Blessed;

			AddFollowers();

			if (version < 3 && Weight == 0)
			{
				Weight = -1;
			}
		}

		private class EtherealSpell : Spell
		{
			private static SpellInfo ResolveInfo(EtherealMount mount)
			{
				return new(mount.GetType())
				{
					Name = Utility.FriendlyName(mount),
					Action = 230,
				};
			}

			private readonly EtherealMount m_Mount;
			private readonly Mobile m_Rider;

			private bool m_Stop;

			public override double CastDelayFastScalar => 0;

			public override TimeSpan CastDelayBase => ComputeCastDelay();

			public override bool ClearHandsOnCast => false;

			public override bool RevealOnCast => false;

			public override SkillName CastSkill => SkillName.Focus;
			public override SkillName DamageSkill => SkillName.Focus;

			public EtherealSpell(EtherealMount mount, Mobile rider)
				: base(rider, null, ResolveInfo(mount))
			{
				m_Rider = rider;
				m_Mount = mount;
			}

			private TimeSpan ComputeCastDelay()
			{
				var delay = Core.AOS ? 3.0 : 2.0;

				if (m_Mount.IsDonationItem && RewardSystem.GetRewardLevel(m_Rider) < 3)
				{
					delay += 7.5;
				}

				return TimeSpan.FromSeconds(delay);
			}

			public override TimeSpan GetCastRecovery()
			{
				return TimeSpan.Zero;
			}

			public override void GetCastSkills(ref double req, out double min, out double max)
			{
				req = min = max = 0.0;
			}

			public override bool ConsumeReagents()
			{
				return true;
			}

			public override bool CheckFizzle()
			{
				return true;
			}

			public void Stop()
			{
				m_Stop = true;

				Interrupt(SpellInterrupt.Hurt);
			}

			public override bool CheckInterrupt(SpellInterrupt type, bool resistable)
			{
				return type != SpellInterrupt.EquipRequest && type != SpellInterrupt.UseRequest;
			}

			public override void DoHurtFizzle()
			{
				if (!m_Stop)
				{
					base.DoHurtFizzle();
				}
			}

			public override void DoFizzle()
			{
				if (!m_Stop)
				{
					base.DoFizzle();
				}
			}

			public override void OnInterrupt(SpellInterrupt type, bool message)
			{
				if (message && !m_Stop)
				{
					Caster.SendLocalizedMessage(1049455); // You have been disrupted while attempting to summon your ethereal mount!
				}
			}

			public override void OnCast()
			{
				if (!m_Mount.Deleted && m_Mount.Rider == null && m_Mount.Validate(m_Rider))
				{
					m_Mount.Rider = m_Rider;
				}

				FinishSequence();
			}
		}
	}
}