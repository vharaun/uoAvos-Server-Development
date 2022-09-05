using Server.Factions;
using Server.Guilds;
using Server.Items;

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
					if (g.Focus == null) // idling
					{
						g.Focus = target;

						--amount;
					}
					else if (g.Focus == target && !onlyAdditional)
					{
						--amount;
					}
				}
			}

			while (--amount >= 0)
			{
				caller.Region.MakeGuard(target);
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

		protected Mobile m_Focus;

		public virtual Mobile Focus { get => m_Focus; set => m_Focus = value; }

		public BaseGuard(AIType ai, FightMode mode, int iRangePerception, int iRangeFight, double dActiveSpeed, double dPassiveSpeed) 
			: base(ai, mode, iRangePerception, iRangeFight, dActiveSpeed, dPassiveSpeed)
		{
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
					MoveToWorld(p, target.Map);
				}

				Effects.SendLocationParticles(this, 0x3728, 10, 10, 5023);
			}

			Attack(target);

			if (Combatant == target)
			{
				Focus = target;
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

			writer.Write(m_Focus);

			Town.WriteReference(writer, m_Town);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			m_Town = Town.ReadReference(reader);

			m_Focus = reader.ReadMobile();
		}
	}

	public abstract class BaseTownGuard : BaseGuard
	{
		protected AttackTimer m_AttackTimer;
		protected IdleTimer m_IdleTimer;

		public BaseTownGuard(AIType ai, FightMode mode, int iRangePerception, int iRangeFight, double dActiveSpeed, double dPassiveSpeed)
			: base(ai, mode, iRangePerception, iRangeFight, dActiveSpeed, dPassiveSpeed)
		{
			InitStats(1000, 1000, 1000);

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

			var weapon = new Halberd
			{
				Movable = false,
				Crafter = this,
				Quality = WeaponQuality.Exceptional
			};

			AddItem(weapon);

			Container pack = new Backpack
			{
				Movable = false
			};

			pack.DropItem(new Gold(10, 25));

			AddItem(pack);

			Skills[SkillName.Anatomy].Base = 120.0;
			Skills[SkillName.Tactics].Base = 120.0;
			Skills[SkillName.Swords].Base = 120.0;
			Skills[SkillName.MagicResist].Base = 120.0;
			Skills[SkillName.DetectHidden].Base = 100.0;

			NextCombatTime = Core.TickCount + 500;
		}

		public BaseTownGuard(Serial serial) : base(serial)
		{
		}

		public override bool OnBeforeDeath()
		{
			if (m_Focus != null && m_Focus.Alive)
			{
				new AvengeTimer(m_Focus).Start(); // If a guard dies, three more guards will spawn
			}

			return base.OnBeforeDeath();
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public override Mobile Focus
		{
			get => m_Focus;
			set
			{
				if (Deleted)
				{
					return;
				}

				var oldFocus = m_Focus;

				if (oldFocus != value)
				{
					m_Focus = value;

					if (value != null)
					{
						AggressiveAction(value);
					}

					Combatant = value;

					if (oldFocus != null && !oldFocus.Alive)
					{
						Say("Thou hast suffered thy punishment, scoundrel.");
					}

					if (value != null)
					{
						Say(500131); // Thou wilt regret thine actions, swine!
					}

					if (m_AttackTimer != null)
					{
						m_AttackTimer.Stop();
						m_AttackTimer = null;
					}

					if (m_IdleTimer != null)
					{
						m_IdleTimer.Stop();
						m_IdleTimer = null;
					}

					if (m_Focus != null)
					{
						m_AttackTimer = new AttackTimer(this);
						m_AttackTimer.Start();
						m_AttackTimer.DoOnTick();
					}
					else
					{
						m_IdleTimer = new IdleTimer(this);
						m_IdleTimer.Start();
					}
				}
				else if (m_Focus == null && m_IdleTimer == null)
				{
					m_IdleTimer = new IdleTimer(this);
					m_IdleTimer.Start();
				}
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
				if (m_Focus != null)
				{
					m_AttackTimer = new AttackTimer(this);
					m_AttackTimer.Start();
				}
				else
				{
					m_IdleTimer = new IdleTimer(this);
					m_IdleTimer.Start();
				}
			}
		}

		public override void OnAfterDelete()
		{
			if (m_AttackTimer != null)
			{
				m_AttackTimer.Stop();
				m_AttackTimer = null;
			}

			if (m_IdleTimer != null)
			{
				m_IdleTimer.Stop();
				m_IdleTimer = null;
			}

			base.OnAfterDelete();
		}

		protected class AvengeTimer : Timer
		{
			private readonly Mobile m_Focus;

			public AvengeTimer(Mobile focus) : base(TimeSpan.FromSeconds(2.5), TimeSpan.FromSeconds(1.0), 3)
			{
				m_Focus = focus;
			}

			protected override void OnTick()
			{
				BaseGuard.Spawn(m_Focus, m_Focus, 1, true);
			}
		}

		protected class AttackTimer : Timer
		{
			private readonly BaseTownGuard m_Owner;

			public AttackTimer(BaseTownGuard owner) : base(TimeSpan.FromSeconds(0.25), TimeSpan.FromSeconds(0.1))
			{
				m_Owner = owner;
			}

			public void DoOnTick()
			{
				OnTick();
			}

			protected override void OnTick()
			{
				if (m_Owner.Deleted)
				{
					Stop();

					return;
				}

				m_Owner.Criminal = false;
				m_Owner.Kills = 0;
				m_Owner.Stam = m_Owner.StamMax;

				var target = m_Owner.Focus;

				if (target != null && (target.Deleted || !target.Alive || !m_Owner.CanBeHarmful(target)))
				{
					m_Owner.Focus = null;

					Stop();

					return;
				}
				
				if (m_Owner.Weapon is Fists)
				{
					m_Owner.Kill();

					Stop();

					return;
				}

				if (target != null && m_Owner.Combatant != target)
				{
					m_Owner.Combatant = target;
				}

				if (target == null)
				{
					Stop();
				}
				else
				{// <instakill>
					TeleportTo(target);

					target.BoltEffect(0);

					if (target is BaseCreature bc)
					{
						bc.NoKillAwards = true;
					}

					target.Damage(target.HitsMax, m_Owner);
					target.Kill(); // just in case, maybe Damage is overriden on some shard

					if (target.Corpse != null && !target.Player)
					{
						target.Corpse.Delete();
					}

					m_Owner.Focus = null;

					Stop();
				}// </instakill>
				/*else if (!m_Owner.InRange(target, 20))
				{
					m_Owner.Focus = null;
				}
				else if (!m_Owner.InRange(target, 10) || !m_Owner.InLOS(target))
				{
					TeleportTo(target);
				}
				else if (!m_Owner.InRange(target, 1))
				{
					if (!m_Owner.Move(m_Owner.GetDirectionTo(target) | Direction.Running))
						TeleportTo(target);
				}
				else if (!m_Owner.CanSee(target))
				{
					if (!m_Owner.UseSkill(SkillName.DetectHidden) && Utility.Random(50) == 0)
						m_Owner.Say("Reveal!");
				}*/
			}

			private void TeleportTo(Mobile target)
			{
				var from = m_Owner.Location;
				var to = target.Location;

				m_Owner.Location = to;

				Effects.SendLocationParticles(EffectItem.Create(from, m_Owner.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
				Effects.SendLocationParticles(EffectItem.Create(to, m_Owner.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 5023);

				m_Owner.PlaySound(0x1FE);
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
					Effects.SendLocationParticles(EffectItem.Create(m_Owner.Location, m_Owner.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
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