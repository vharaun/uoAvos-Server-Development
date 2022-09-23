using Server.Factions;
using Server.Guilds;
using Server.Items;
using Server.Regions;
using Server.Targeting;

using System;

namespace Server.Mobiles
{
	/// Castle Guards
	public abstract class BaseGuard : BaseCreature
	{
		public static void Spawn(Mobile caller, Mobile target)
		{
			Spawn(caller, target, 1, false);
		}

		public static void Spawn(Mobile caller, Mobile target, int amount, bool onlyAdditional)
		{
			if (target == null || target.Deleted)
			{
				return;
			}

			foreach (var m in target.GetMobilesInRange(15))
			{
				if (m is BaseGuard g)
				{
					if (g.FocusMob == null) // idling
					{
						g.FocusMob = target;

						--amount;
					}
					else if (g.FocusMob == target && !onlyAdditional)
					{
						--amount;
					}
				}
			}

			if (amount <= 0)
			{
				return;
			}

			var gr = caller.Region.GetRegion<GuardedRegion>();

			while (--amount >= 0)
			{
				var guard = gr.MakeGuard(target.Location);

				if (guard?.Deleted == false)
				{
					guard.Attack(target, true);
				}
			}
		}

		private Town m_Town;

		[CommandProperty(AccessLevel.GameMaster)]
		public virtual Town Town
		{
			get => m_Town;
			set
			{
				if (m_Town != value && OnTownChanging(value))
				{
					var old = m_Town;

					m_Town = value;

					OnTownChanged(old);
				}
			}
		}

		public BaseGuard(AIType ai, FightMode mode, int iRangePerception, int iRangeFight, double dActiveSpeed, double dPassiveSpeed) 
			: base(ai, mode, iRangePerception, iRangeFight, dActiveSpeed, dPassiveSpeed)
		{
			InitStats(100, 100, 100);
		}

		public BaseGuard(Serial serial) 
			: base(serial)
		{
		}

		protected virtual bool OnTownChanging(Town newTown)
		{
			return true;
		}

		protected virtual void OnTownChanged(Town oldTown)
		{ }

		public void Attack(Mobile target, bool teleport)
		{
			if (target == null || target.Deleted)
			{
				return;
			}

			if (teleport)
			{
				var p = target.Location;
				var r = 1;
				var c = (1 + (r * 2)) * (1 + (r * 2));
				var i = 0;

				do
				{
					p.X = target.X + Utility.RandomMinMax(-r, r);
					p.Y = target.Y + Utility.RandomMinMax(-r, r);
					p.Z = target.Map.GetAverageZ(p.X, p.Y);

					if (++i >= c)
					{
						if (++r > RangePerception)
						{
							p = target.Location;
							break;
						}

						c = (1 + (r * 2)) * (1 + (r * 2));
					}
				}
				while (!target.Map.CanFit(p.X, p.Y, p.Z, 18, true, false, true));

				if (Map == null || Map == Map.Internal)
				{
					OnBeforeSpawn(target.Location, target.Map);

					if (Deleted)
					{
						return;
					}

					MoveToWorld(p, target.Map);

					if (Deleted)
					{
						return;
					}

					OnAfterSpawn();
				}
				else
				{
					Effects.SendLocationParticles(this, 0x3728, 10, 10, 5023);

					MoveToWorld(p, target.Map);
				}

				Effects.SendLocationParticles(this, 0x3728, 10, 10, 5023);
			}

			AggressiveAction(target);

			Attack(target);

			if (Combatant == target)
			{
				FocusMob = target;
			}
		}

		public override bool OnBeforeDeath()
		{
			Effects.SendLocationParticles(EffectItem.Create(Location, Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);

			PlaySound(0x1FE);

			Delete();

			return false;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_FocusMob);

			Town.WriteReference(writer, m_Town);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			m_Town = Town.ReadReference(reader);

			m_FocusMob = reader.ReadMobile();
		}
	}

	public abstract class BaseTownGuard : BaseGuard
	{
		protected IdleTimer m_IdleTimer;

		[CommandProperty(AccessLevel.GameMaster)]
		public override Mobile FocusMob
		{
			get => m_FocusMob;
			set
			{
				if (Deleted || value?.Deleted == true)
				{
					return;
				}

				var oldFocus = m_FocusMob;

				if (oldFocus != value)
				{
					m_FocusMob = value;

					if (oldFocus?.Alive == false)
					{
						Say("Thou hast suffered thy punishment, scoundrel.");
					}

					if (value != null)
					{
						Say(500131); // Thou wilt regret thine actions, swine!
					}

					if (m_IdleTimer != null)
					{
						m_IdleTimer.Stop();
						m_IdleTimer = null;
					}

					if (m_FocusMob?.Deleted == false)
					{
						Attack(m_FocusMob, true);
					}
					else
					{
						m_IdleTimer = new IdleTimer(this);
						m_IdleTimer.Start();
					}
				}
				else if (oldFocus?.Deleted != false && m_IdleTimer == null)
				{
					m_IdleTimer = new IdleTimer(this);
					m_IdleTimer.Start();
				}
			}
		}

		public BaseTownGuard(AIType ai, FightMode mode, int iRangePerception, int iRangeFight, double dActiveSpeed, double dPassiveSpeed)
			: base(ai, mode, iRangePerception, iRangeFight, dActiveSpeed, dPassiveSpeed)
		{
			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.MagicResist, 120.0);
			SetSkill(SkillName.DetectHidden, 100.0);

			NextCombatTime = Core.TickCount + 500;

			Title = "the guard";

			SpeechHue = Utility.RandomDyedHue();

			Hue = Utility.RandomSkinHue();

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("female");
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
			}

			Utility.AssignRandomHair(this);

			if (Utility.RandomBool())
			{
				Utility.AssignRandomFacialHair(this, HairHue);
			}

			var pack = Backpack ?? new Backpack
			{
				Movable = false
			};

			pack.DropItem(new Gold(10, 25));

			AddItem(pack);

			if (!Mounted && Utility.RandomBool())
			{
				var horse = new Horse();

				horse.SetControlMaster(this);

				horse.Rider = this;
			}
		}

		public BaseTownGuard(Serial serial) 
			: base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if (m_IdleTimer != null)
			{
				m_IdleTimer.Stop();
				m_IdleTimer = null;
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version >= 0)
			{
				if (m_FocusMob != null)
				{
					Timer.DelayCall(Attack, m_FocusMob, true);
				}
				else
				{
					m_IdleTimer = new IdleTimer(this);
					m_IdleTimer.Start();
				}
			}
		}

		protected class IdleTimer : Timer
		{
			private readonly BaseTownGuard m_Owner;

			private int m_Stage;

			public IdleTimer(BaseTownGuard owner) 
				: base(TimeSpan.FromSeconds(2.0), TimeSpan.FromSeconds(2.5))
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if (m_Owner.Deleted)
				{
					Stop();

					return;
				}

				if ((m_Stage++ % 4) == 0 || !m_Owner.Move(m_Owner.Direction))
				{
					m_Owner.Direction = (Direction)Utility.Random(8);
				}

				if (m_Stage > 16)
				{
					Effects.SendLocationParticles(m_Owner, 0x3728, 10, 10, 2023);

					m_Owner.PlaySound(0x1FE);

					m_Owner.Delete();
				}
			}
		}
	}

	/// Shield Guards
	public abstract class BaseShieldGuard : BaseGuard
	{
		public abstract int Keyword { get; }
		public abstract BaseShield Shield { get; }
		public abstract int SignupNumber { get; }
		public abstract GuildType Type { get; }

		public BaseShieldGuard() 
			: base(AIType.AI_Melee, FightMode.Aggressor, 14, 1, 0.8, 1.6)
		{
			InitStats(1000, 1000, 1000);

			Skills[SkillName.Anatomy].Base = 120.0;
			Skills[SkillName.Tactics].Base = 120.0;
			Skills[SkillName.Swords].Base = 120.0;
			Skills[SkillName.MagicResist].Base = 120.0;
			Skills[SkillName.DetectHidden].Base = 100.0;

			Title = "the guard";

			SpeechHue = Utility.RandomDyedHue();

			Hue = Utility.RandomSkinHue();

			Female = Utility.RandomBool();

			if (Female)
			{
				Body = 0x191;
				Name = NameList.RandomName("female");

				AddItem(new FemalePlateChest());
				AddItem(new PlateArms());
				AddItem(new PlateLegs());

				switch (Utility.Random(2))
				{
					case 0: AddItem(new Doublet(Utility.RandomNondyedHue())); break;
					case 1: AddItem(new BodySash(Utility.RandomNondyedHue())); break;
				}

				switch (Utility.Random(2))
				{
					case 0: AddItem(new Skirt(Utility.RandomNondyedHue())); break;
					case 1: AddItem(new Kilt(Utility.RandomNondyedHue())); break;
				}
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");

				AddItem(new PlateChest());
				AddItem(new PlateArms());
				AddItem(new PlateLegs());

				switch (Utility.Random(3))
				{
					case 0: AddItem(new Doublet(Utility.RandomNondyedHue())); break;
					case 1: AddItem(new Tunic(Utility.RandomNondyedHue())); break;
					case 2: AddItem(new BodySash(Utility.RandomNondyedHue())); break;
				}
			}

			Utility.AssignRandomHair(this);

			if (Utility.RandomBool())
			{
				Utility.AssignRandomFacialHair(this, HairHue);
			}

			AddItem(new VikingSword
			{
				Movable = false
			});

			var shield = Shield;

			if (shield != null)
			{
				shield.Movable = false;

				AddItem(shield);
			}

			PackGold(250, 500);
		}

		public BaseShieldGuard(Serial serial)
			: base(serial)
		{
		}

		public override bool HandlesOnSpeech(Mobile from)
		{
			if (from.InRange(Location, 2))
			{
				return true;
			}

			return base.HandlesOnSpeech(from);
		}

		public override void OnSpeech(SpeechEventArgs e)
		{
			if (!e.Handled && e.HasKeyword(Keyword) && e.Mobile.InRange(Location, 2))
			{
				e.Handled = true;

				var from = e.Mobile;

				if (from.Guild is Guild g && g.Type == Type)
				{
					var pack = from.Backpack;
					var shield = Shield;
					var twoHanded = from.FindItemOnLayer(Layer.TwoHanded);

					if ((pack != null && pack.FindItemByType(shield.GetType()) != null) || (twoHanded != null && shield.GetType().IsAssignableFrom(twoHanded.GetType())))
					{
						Say(1007110); // Why dost thou ask about virtue guards when thou art one?

						shield.Delete();
					}
					else if (from.PlaceInBackpack(shield))
					{
						Say(Utility.Random(1007101, 5));
						Say(1007139); // I see you are in need of our shield, Here you go.

						from.AddToBackpack(shield);
					}
					else
					{
						from.SendLocalizedMessage(502868); // Your backpack is too full.

						shield.Delete();
					}
				}
				else
				{
					Say(SignupNumber);
				}
			}

			base.OnSpeech(e);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}