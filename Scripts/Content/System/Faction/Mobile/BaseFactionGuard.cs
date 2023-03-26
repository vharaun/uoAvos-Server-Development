using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Magery;
using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Factions
{
	public abstract class BaseFactionGuard : BaseGuard
	{
		private const int ListenRange = 12;

		private static readonly Type[] m_StrongPotions = new Type[]
		{
			typeof( GreaterHealPotion ), typeof( GreaterHealPotion ), typeof( GreaterHealPotion ),
			typeof( GreaterCurePotion ), typeof( GreaterCurePotion ), typeof( GreaterCurePotion ),
			typeof( GreaterStrengthPotion ), typeof( GreaterStrengthPotion ),
			typeof( GreaterAgilityPotion ), typeof( GreaterAgilityPotion ),
			typeof( TotalRefreshPotion ), typeof( TotalRefreshPotion ),
			typeof( GreaterExplosionPotion )
		};

		private static readonly Type[] m_WeakPotions = new Type[]
		{
			typeof( HealPotion ), typeof( HealPotion ), typeof( HealPotion ),
			typeof( CurePotion ), typeof( CurePotion ), typeof( CurePotion ),
			typeof( StrengthPotion ), typeof( StrengthPotion ),
			typeof( AgilityPotion ), typeof( AgilityPotion ),
			typeof( RefreshPotion ), typeof( RefreshPotion ),
			typeof( ExplosionPotion )
		};

		public static Item Immovable(Item item)
		{
			item.Movable = false;

			return item;
		}

		public static Item Newbied(Item item)
		{
			item.LootType = LootType.Newbied;

			return item;
		}

		public static Item Rehued(Item item, int hue)
		{
			item.Hue = hue;

			return item;
		}

		public static Item Layered(Item item, Layer layer)
		{
			item.Layer = layer;

			return item;
		}

		public static Item Resourced(BaseWeapon weapon, CraftResource resource)
		{
			weapon.Resource = resource;

			return weapon;
		}

		public static Item Resourced(BaseArmor armor, CraftResource resource)
		{
			armor.Resource = resource;

			return armor;
		}

		private Faction m_Faction;

		[CommandProperty(AccessLevel.GameMaster)]
		public Faction Faction
		{
			get => m_Faction;
			set
			{
				if (m_Faction != value && OnFactionChanging(value))
				{
					var old = m_Faction;

					m_Faction = value;

					OnFactionChanged(old);
				}
			}
		}

		private DateTime m_OrdersEnd;

		public Orders Orders { get; private set; }

		public abstract FactionGuardAIType GuardAI { get; }

		protected override BaseAI ForcedAI => new FactionGuardAI(this);

		public override TimeSpan ReacquireDelay => TimeSpan.FromSeconds(2.0);

		public override bool ClickTitle => false;

		public override bool BardImmune => true;

		public BaseFactionGuard(string title)
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Orders = new Orders(this);

			Title = title;

			RangeHome = 6;
		}

		public BaseFactionGuard(Serial serial)
			: base(serial)
		{
		}

		protected virtual bool OnFactionChanging(Faction newFaction)
		{
			return true;
		}

		protected virtual void OnFactionChanged(Faction oldFaction)
		{
			if (Town != null)
			{
				Town.UnregisterGuard(this);
			}

			if (Town != null && Faction != null)
			{
				Town.RegisterGuard(this);
			}
		}

		protected override void OnTownChanged(Town oldTown)
		{
			base.OnTownChanged(oldTown);

			if (oldTown != null)
			{
				oldTown.UnregisterGuard(this);
			}

			if (Town != null && Faction != null)
			{
				Town.RegisterGuard(this);
			}
		}

		public void Register()
		{
			if (Town != null && Faction != null)
			{
				Town.RegisterGuard(this);
			}
		}

		public void Unregister()
		{
			if (Town != null)
			{
				Town.UnregisterGuard(this);
			}
		}

		public override bool IsEnemy(Mobile m)
		{
			var ourFaction = Faction;
			var theirFaction = Faction.Find(m);

			if (theirFaction == null && m is BaseFactionGuard fg)
			{
				theirFaction = fg.Faction;
			}

			if (ourFaction != null && theirFaction != null && ourFaction != theirFaction)
			{
				var reactionType = Orders.GetReaction(theirFaction).Type;

				if (reactionType == ReactionType.Attack)
				{
					return true;
				}

				if (theirFaction != null)
				{
					var list = m.Aggressed;

					for (var i = 0; i < list.Count; ++i)
					{
						var ai = list[i];

						if (ai.Defender is BaseFactionGuard bf && bf.Faction == ourFaction)
						{
							return true;
						}
					}
				}
			}

			return base.IsEnemy(m);
		}

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			if (m.Player && m.Alive && InRange(m, 10) && !InRange(oldLocation, 10) && InLOS(m) && Orders.GetReaction(Faction.Find(m)).Type == ReactionType.Warn)
			{
				Direction = GetDirectionTo(m);

				string warning = null;

				switch (Utility.Random(6))
				{
					case 0: warning = "I warn you, {0}, you would do well to leave this area before someone shows you the world of gray."; break;
					case 1: warning = "It would be wise to leave this area, {0}, lest your head become my commanders' trophy."; break;
					case 2: warning = "You are bold, {0}, for one of the meager {1}. Leave now, lest you be taught the taste of dirt."; break;
					case 3: warning = "Your presence here is an insult, {0}. Be gone now, knave."; break;
					case 4: warning = "Dost thou wish to be hung by your toes, {0}? Nay? Then come no closer."; break;
					case 5: warning = "Hey, {0}. Yeah, you. Get out of here before I beat you with a stick."; break;
				}

				var faction = Faction.Find(m);

				Say(warning, m.Name, faction == null ? "civilians" : faction.Definition.FriendlyName);
			}
		}

		public override bool HandlesOnSpeech(Mobile from)
		{
			if (InRange(from, ListenRange))
			{
				return true;
			}

			return base.HandlesOnSpeech(from);
		}

		private void ChangeReaction(Faction faction, ReactionType type)
		{
			if (faction == null)
			{
				switch (type)
				{
					case ReactionType.Ignore: Say(1005179); break; // Civilians will now be ignored.
					case ReactionType.Warn: Say(1005180); break; // Civilians will now be warned of their impending deaths.
					case ReactionType.Attack: return;
				}
			}
			else
			{
				TextDefinition def = null;

				switch (type)
				{
					case ReactionType.Ignore: def = faction.Definition.GuardIgnore; break;
					case ReactionType.Warn: def = faction.Definition.GuardWarn; break;
					case ReactionType.Attack: def = faction.Definition.GuardAttack; break;
				}

				if (def != null && def.Number > 0)
				{
					Say(def.Number);
				}
				else if (def != null && def.String != null)
				{
					Say(def.String);
				}
			}

			Orders.SetReaction(faction, type);
		}

		private bool WasNamed(string speech)
		{
			var name = Name;

			return (name != null && Insensitive.StartsWith(speech, name));
		}

		public override void OnSpeech(SpeechEventArgs e)
		{
			base.OnSpeech(e);

			var from = e.Mobile;

			if (!e.Handled && InRange(from, ListenRange) && from.Alive)
			{
				if (e.HasKeyword(0xE6) && (Insensitive.Equals(e.Speech, "orders") || WasNamed(e.Speech))) // *orders*
				{
					if (Town == null || !Town.IsSheriff(from))
					{
						Say(1042189); // I don't work for you!
					}
					else if (Town.FromRegion(Region) == Town)
					{
						Say(1042180); // Your orders, sire?
						m_OrdersEnd = DateTime.UtcNow + TimeSpan.FromSeconds(10.0);
					}
				}
				else if (DateTime.UtcNow < m_OrdersEnd)
				{
					if (Town != null && Town.IsSheriff(from) && Town.FromRegion(Region) == Town)
					{
						m_OrdersEnd = DateTime.UtcNow + TimeSpan.FromSeconds(10.0);

						var understood = true;
						var newType = ReactionType.Ignore;

						if (Insensitive.Contains(e.Speech, "attack"))
						{
							newType = ReactionType.Attack;
						}
						else if (Insensitive.Contains(e.Speech, "warn"))
						{
							newType = ReactionType.Warn;
						}
						else if (Insensitive.Contains(e.Speech, "ignore"))
						{
							newType = ReactionType.Ignore;
						}
						else
						{
							understood = false;
						}

						if (understood)
						{
							understood = false;

							if (Insensitive.Contains(e.Speech, "civil"))
							{
								ChangeReaction(null, newType);

								understood = true;
							}

							var factions = Faction.Factions;

							for (var i = 0; i < factions.Count; ++i)
							{
								var faction = factions[i];

								if (faction != m_Faction && Insensitive.Contains(e.Speech, faction.Definition.Keyword))
								{
									ChangeReaction(faction, newType);

									understood = true;
								}
							}
						}
						else if (Insensitive.Contains(e.Speech, "patrol"))
						{
							Home = Location;
							RangeHome = 6;
							Combatant = null;

							Orders.Movement = MovementType.Patrol;

							Say(1005146); // This spot looks like it needs protection!  I shall guard it with my life.

							understood = true;
						}
						else if (Insensitive.Contains(e.Speech, "follow"))
						{
							Home = Location;
							RangeHome = 6;
							Combatant = null;

							Orders.Follow = from;
							Orders.Movement = MovementType.Follow;

							Say(1005144); // Yes, Sire.

							understood = true;
						}

						if (!understood)
						{
							Say(1042183); // I'm sorry, I don't understand your orders...
						}
					}
				}
			}
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			if (m_Faction != null && Map == Faction.Facet)
			{
				list.Add(1060846, m_Faction.Definition.PropName); // Guard: ~1_val~
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			if (m_Faction != null && Map == Faction.Facet)
			{
				var text = String.Concat("(Guard, ", m_Faction.Definition.FriendlyName, ")");

				var hue = (Faction.Find(from) == m_Faction ? 98 : 38);

				PrivateOverheadMessage(MessageType.Label, hue, true, text, from.NetState);
			}

			base.OnSingleClick(from);
		}

		public virtual void GenerateRandomHair()
		{
			Utility.AssignRandomHair(this);
			Utility.AssignRandomFacialHair(this, HairHue);
		}

		public void PackStrongPotions(int min, int max)
		{
			PackStrongPotions(Utility.RandomMinMax(min, max));
		}

		public void PackStrongPotions(int count)
		{
			for (var i = 0; i < count; ++i)
			{
				PackStrongPotion();
			}
		}

		public void PackStrongPotion()
		{
			PackItem(Loot.Construct(m_StrongPotions));
		}

		public void PackWeakPotions(int min, int max)
		{
			PackWeakPotions(Utility.RandomMinMax(min, max));
		}

		public void PackWeakPotions(int count)
		{
			for (var i = 0; i < count; ++i)
			{
				PackWeakPotion();
			}
		}

		public void PackWeakPotion()
		{
			PackItem(Loot.Construct(m_WeakPotions));
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			Unregister();
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

			c.Delete();
		}

		public virtual void GenerateBody(bool isFemale, bool randomHair)
		{
			Hue = Utility.RandomSkinHue();

			if (isFemale)
			{
				Female = true;
				Body = 401;
				Name = NameList.RandomName("female");
			}
			else
			{
				Female = false;
				Body = 400;
				Name = NameList.RandomName("male");
			}

			if (randomHair)
			{
				GenerateRandomHair();
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			Faction.WriteReference(writer, m_Faction);

			Orders.Serialize(writer);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			m_Faction = Faction.ReadReference(reader);

			Orders = new Orders(this, reader);

			Timer.DelayCall(Register);
		}
	}

	/// Faction Mounts
	public class VirtualMount : IMount
	{
		private readonly VirtualMountItem m_Item;

		public Mobile Rider
		{
			get => m_Item.Rider;
			set { }
		}

		public VirtualMount(VirtualMountItem item)
		{
			m_Item = item;
		}

		public virtual void OnRiderDamaged(int amount, Mobile from, bool willKill)
		{
		}
	}

	public class VirtualMountItem : Item, IMountItem
	{
		private Mobile m_Rider;

		private readonly VirtualMount m_Mount;

		public Mobile Rider => m_Rider;

		public VirtualMountItem(Mobile mob) : base(0x3EA0)
		{
			Layer = Layer.Mount;

			m_Rider = mob;
			m_Mount = new VirtualMount(this);
		}

		public IMount Mount => m_Mount;

		public VirtualMountItem(Serial serial) 
			: base(serial)
		{
			m_Mount = new VirtualMount(this);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_Rider);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			m_Rider = reader.ReadMobile();

			if (m_Rider == null || m_Rider.Deleted)
			{
				Delete();
			}
		}
	}

	/// Faction Mob AI
	public enum FactionGuardAIType
	{
		Bless = 0x01, // heal, cure, +stats
		Curse = 0x02, // poison, -stats
		Melee = 0x04, // weapons
		Magic = 0x08, // damage spells
		Smart = 0x10  // smart weapons/damage spells
	}

	public class ComboEntry
	{
		private readonly Type m_Spell;
		private readonly TimeSpan m_Hold;
		private readonly int m_Chance;

		public Type Spell => m_Spell;
		public TimeSpan Hold => m_Hold;
		public int Chance => m_Chance;

		public ComboEntry(Type spell) 
			: this(spell, 100, TimeSpan.Zero)
		{
		}

		public ComboEntry(Type spell, int chance) 
			: this(spell, chance, TimeSpan.Zero)
		{
		}

		public ComboEntry(Type spell, int chance, TimeSpan hold)
		{
			m_Spell = spell;
			m_Chance = chance;
			m_Hold = hold;
		}
	}

	public class SpellCombo
	{
		public static readonly SpellCombo Simple = new
		(
			50,
			new(typeof(ParalyzeSpell), 20),
			new(typeof(ExplosionSpell), 100, TimeSpan.FromSeconds(2.8)),
			new(typeof(PoisonSpell), 30),
			new(typeof(EnergyBoltSpell))
		);

		public static readonly SpellCombo Strong = new
		(
			90,
			new(typeof(ParalyzeSpell), 20),
			new(typeof(ExplosionSpell), 50, TimeSpan.FromSeconds(2.8)),
			new(typeof(PoisonSpell), 30),
			new(typeof(ExplosionSpell), 100, TimeSpan.FromSeconds(2.8)),
			new(typeof(EnergyBoltSpell)),
			new(typeof(PoisonSpell), 30),
			new(typeof(EnergyBoltSpell))
		);

		public static Spell Process(Mobile mob, Mobile targ, ref SpellCombo combo, ref int index, ref DateTime releaseTime)
		{
			while (++index < combo.m_Entries.Length)
			{
				var entry = combo.m_Entries[index];

				if (entry.Spell == typeof(PoisonSpell) && targ.Poisoned)
				{
					continue;
				}

				if (entry.Chance > Utility.Random(100))
				{
					releaseTime = DateTime.UtcNow + entry.Hold;

					return (Spell)Activator.CreateInstance(entry.Spell, mob, null);
				}
			}

			combo = null;
			index = -1;

			return null;
		}

		private readonly int m_Mana;
		private readonly ComboEntry[] m_Entries;

		public int Mana => m_Mana;
		public ComboEntry[] Entries => m_Entries;

		public SpellCombo(int mana, params ComboEntry[] entries)
		{
			m_Mana = mana;
			m_Entries = entries;
		}
	}

	public class FactionGuardAI : BaseAI
	{
		private readonly BaseFactionGuard m_Guard;

		private BandageContext m_Bandage;
		private DateTime m_BandageStart;

		private SpellCombo m_Combo;
		private int m_ComboIndex = -1;
		private DateTime m_ReleaseTarget;

		private const int ManaReserve = 30;

		public bool IsAllowed(FactionGuardAIType flag)
		{
			return ((m_Guard.GuardAI & flag) == flag);
		}

		public bool IsDamaged => (m_Guard.Hits < m_Guard.HitsMax);

		public bool IsPoisoned => m_Guard.Poisoned;

		public TimeSpan TimeUntilBandage
		{
			get
			{
				if (m_Bandage != null && m_Bandage.Timer == null)
				{
					m_Bandage = null;
				}

				if (m_Bandage == null)
				{
					return TimeSpan.MaxValue;
				}

				var ts = (m_BandageStart + m_Bandage.Timer.Delay) - DateTime.UtcNow;

				if (ts < TimeSpan.FromSeconds(-1.0))
				{
					m_Bandage = null;
					return TimeSpan.MaxValue;
				}

				if (ts < TimeSpan.Zero)
				{
					ts = TimeSpan.Zero;
				}

				return ts;
			}
		}

		public bool DequipWeapon()
		{
			var pack = m_Guard.Backpack;

			if (pack == null)
			{
				return false;
			}

			var weapon = m_Guard.Weapon as Item;

			if (weapon != null && weapon.Parent == m_Guard && !(weapon is Fists))
			{
				pack.DropItem(weapon);
				return true;
			}

			return false;
		}

		public bool EquipWeapon()
		{
			var pack = m_Guard.Backpack;

			if (pack == null)
			{
				return false;
			}

			var weapon = pack.FindItemByType(typeof(BaseWeapon));

			if (weapon == null)
			{
				return false;
			}

			return m_Guard.EquipItem(weapon);
		}

		public bool StartBandage()
		{
			m_Bandage = null;

			var pack = m_Guard.Backpack;

			if (pack == null)
			{
				return false;
			}

			var bandage = pack.FindItemByType(typeof(Bandage));

			if (bandage == null)
			{
				return false;
			}

			m_Bandage = BandageContext.BeginHeal(m_Guard, m_Guard);
			m_BandageStart = DateTime.UtcNow;
			return (m_Bandage != null);
		}

		public bool UseItemByType(Type type)
		{
			var pack = m_Guard.Backpack;

			if (pack == null)
			{
				return false;
			}

			var item = pack.FindItemByType(type);

			if (item == null)
			{
				return false;
			}

			var requip = DequipWeapon();

			item.OnDoubleClick(m_Guard);

			if (requip)
			{
				EquipWeapon();
			}

			return true;
		}

		public int GetStatMod(Mobile mob, StatType type)
		{
			var mod = mob.GetStatMod(String.Format("[Magic] {0} Offset", type));

			if (mod == null)
			{
				return 0;
			}

			return mod.Offset;
		}

		public Spell RandomOffenseSpell()
		{
			var maxCircle = (int)((m_Guard.Skills.Magery.Value + 20.0) / (100.0 / 7.0));

			if (maxCircle < 1)
			{
				maxCircle = 1;
			}

			switch (Utility.Random(maxCircle * 2))
			{
				case 0: case 1: return new MagicArrowSpell(m_Guard, null);
				case 2: case 3: return new HarmSpell(m_Guard, null);
				case 4: case 5: return new FireballSpell(m_Guard, null);
				case 6: case 7: return new LightningSpell(m_Guard, null);
				case 8: return new MindBlastSpell(m_Guard, null);
				case 9: return new ParalyzeSpell(m_Guard, null);
				case 10: return new EnergyBoltSpell(m_Guard, null);
				case 11: return new ExplosionSpell(m_Guard, null);
				default: return new FlameStrikeSpell(m_Guard, null);
			}
		}

		public Mobile FindDispelTarget(bool activeOnly)
		{
			if (m_Mobile.Deleted || m_Mobile.Int < 95 || CanDispel(m_Mobile) || m_Mobile.AutoDispel)
			{
				return null;
			}

			if (activeOnly)
			{
				var aggressed = m_Mobile.Aggressed;
				var aggressors = m_Mobile.Aggressors;

				Mobile active = null;
				var activePrio = 0.0;

				var comb = m_Mobile.Combatant;

				if (comb != null && !comb.Deleted && comb.Alive && !comb.IsDeadBondedPet && m_Mobile.InRange(comb, 12) && CanDispel(comb))
				{
					active = comb;
					activePrio = m_Mobile.GetDistanceToSqrt(comb);

					if (activePrio <= 2)
					{
						return active;
					}
				}

				for (var i = 0; i < aggressed.Count; ++i)
				{
					var info = aggressed[i];
					var m = info.Defender;

					if (m != comb && m.Combatant == m_Mobile && m_Mobile.InRange(m, 12) && CanDispel(m))
					{
						var prio = m_Mobile.GetDistanceToSqrt(m);

						if (active == null || prio < activePrio)
						{
							active = m;
							activePrio = prio;

							if (activePrio <= 2)
							{
								return active;
							}
						}
					}
				}

				for (var i = 0; i < aggressors.Count; ++i)
				{
					var info = aggressors[i];
					var m = info.Attacker;

					if (m != comb && m.Combatant == m_Mobile && m_Mobile.InRange(m, 12) && CanDispel(m))
					{
						var prio = m_Mobile.GetDistanceToSqrt(m);

						if (active == null || prio < activePrio)
						{
							active = m;
							activePrio = prio;

							if (activePrio <= 2)
							{
								return active;
							}
						}
					}
				}

				return active;
			}
			else
			{
				var map = m_Mobile.Map;

				if (map != null)
				{
					Mobile active = null, inactive = null;
					double actPrio = 0.0, inactPrio = 0.0;

					var comb = m_Mobile.Combatant;

					if (comb != null && !comb.Deleted && comb.Alive && !comb.IsDeadBondedPet && CanDispel(comb))
					{
						active = inactive = comb;
						actPrio = inactPrio = m_Mobile.GetDistanceToSqrt(comb);
					}

					foreach (var m in m_Mobile.GetMobilesInRange(12))
					{
						if (m != m_Mobile && CanDispel(m))
						{
							var prio = m_Mobile.GetDistanceToSqrt(m);

							if (!activeOnly && (inactive == null || prio < inactPrio))
							{
								inactive = m;
								inactPrio = prio;
							}

							if ((m_Mobile.Combatant == m || m.Combatant == m_Mobile) && (active == null || prio < actPrio))
							{
								active = m;
								actPrio = prio;
							}
						}
					}

					return active != null ? active : inactive;
				}
			}

			return null;
		}

		public bool CanDispel(Mobile m)
		{
			return (m is BaseCreature && ((BaseCreature)m).Summoned && m_Mobile.CanBeHarmful(m, false) && !((BaseCreature)m).IsAnimatedDead);
		}

		public void RunTo(Mobile m)
		{
			/*if ( m.Paralyzed || m.Frozen )
			{
				if ( m_Mobile.InRange( m, 1 ) )
					RunFrom( m );
				else if ( !m_Mobile.InRange( m, m_Mobile.RangeFight > 2 ? m_Mobile.RangeFight : 2 ) && !MoveTo( m, true, 1 ) )
					OnFailedMove();
			}
			else
			{*/
			if (!m_Mobile.InRange(m, m_Mobile.RangeFight))
			{
				if (!MoveTo(m, true, 1))
				{
					OnFailedMove();
				}
			}
			else if (m_Mobile.InRange(m, m_Mobile.RangeFight - 1))
			{
				RunFrom(m);
			}
			/*}*/
		}

		public void RunFrom(Mobile m)
		{
			Run((m_Mobile.GetDirectionTo(m) - 4) & Direction.Mask);
		}

		public void OnFailedMove()
		{
			/*if ( !m_Mobile.DisallowAllMoves && 20 > Utility.Random( 100 ) && IsAllowed( GuardAI.Magic ) )
			{
				if ( m_Mobile.Target != null )
					m_Mobile.Target.Cancel( m_Mobile, TargetCancelType.Canceled );

				new TeleportSpell( m_Mobile, null ).Cast();

				m_Mobile.DebugSay( "I am stuck, I'm going to try teleporting away" );
			}
			else*/
			if (AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true))
			{
				if (m_Mobile.Debug)
				{
					m_Mobile.DebugSay("My move is blocked, so I am going to attack {0}", m_Mobile.FocusMob.Name);
				}

				m_Mobile.Combatant = m_Mobile.FocusMob;
				Action = ActionType.Combat;
			}
			else
			{
				m_Mobile.DebugSay("I am stuck");
			}
		}

		public void Run(Direction d)
		{
			if ((m_Mobile.Spell != null && m_Mobile.Spell.IsCasting) || m_Mobile.Paralyzed || m_Mobile.Frozen || m_Mobile.DisallowAllMoves)
			{
				return;
			}

			m_Mobile.Direction = d | Direction.Running;

			if (!DoMove(m_Mobile.Direction, true))
			{
				OnFailedMove();
			}
		}

		public FactionGuardAI(BaseFactionGuard guard) : base(guard)
		{
			m_Guard = guard;
		}

		public override bool Think()
		{
			if (m_Mobile.Deleted)
			{
				return false;
			}

			var combatant = m_Guard.Combatant;

			if (combatant == null || combatant.Deleted || !combatant.Alive || combatant.IsDeadBondedPet || !m_Mobile.CanSee(combatant) || !m_Mobile.CanBeHarmful(combatant, false) || combatant.Map != m_Mobile.Map)
			{
				// Our combatant is deleted, dead, hidden, or we cannot hurt them
				// Try to find another combatant

				if (AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true))
				{
					m_Mobile.Combatant = combatant = m_Mobile.FocusMob;
					m_Mobile.FocusMob = null;
				}
				else
				{
					m_Mobile.Combatant = combatant = null;
				}
			}

			if (combatant != null && (!m_Mobile.InLOS(combatant) || !m_Mobile.InRange(combatant, 12)))
			{
				if (AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true))
				{
					m_Mobile.Combatant = combatant = m_Mobile.FocusMob;
					m_Mobile.FocusMob = null;
				}
				else if (!m_Mobile.InRange(combatant, 36))
				{
					m_Mobile.Combatant = combatant = null;
				}
			}

			var dispelTarget = FindDispelTarget(true);

			if (m_Guard.Target != null && m_ReleaseTarget == DateTime.MinValue)
			{
				m_ReleaseTarget = DateTime.UtcNow + TimeSpan.FromSeconds(10.0);
			}

			if (m_Guard.Target != null && DateTime.UtcNow > m_ReleaseTarget)
			{
				var targ = m_Guard.Target;

				var toHarm = (dispelTarget == null ? combatant : dispelTarget);

				if ((targ.Flags & TargetFlags.Harmful) != 0 && toHarm != null)
				{
					if (m_Guard.Map == toHarm.Map && (targ.Range < 0 || m_Guard.InRange(toHarm, targ.Range)) && m_Guard.CanSee(toHarm) && m_Guard.InLOS(toHarm))
					{
						targ.Invoke(m_Guard, toHarm);
					}
					else if (targ is DispelSpell.InternalTarget)
					{
						targ.Cancel(m_Guard, TargetCancelType.Canceled);
					}
				}
				else if ((targ.Flags & TargetFlags.Beneficial) != 0)
				{
					targ.Invoke(m_Guard, m_Guard);
				}
				else
				{
					targ.Cancel(m_Guard, TargetCancelType.Canceled);
				}

				m_ReleaseTarget = DateTime.MinValue;
			}

			if (dispelTarget != null)
			{
				if (Action != ActionType.Combat)
				{
					Action = ActionType.Combat;
				}

				m_Guard.Warmode = true;

				RunFrom(dispelTarget);
			}
			else if (combatant != null)
			{
				if (Action != ActionType.Combat)
				{
					Action = ActionType.Combat;
				}

				m_Guard.Warmode = true;

				RunTo(combatant);
			}
			else if (m_Guard.Orders.Movement != MovementType.Stand)
			{
				Mobile toFollow = null;

				if (m_Guard.Town != null && m_Guard.Orders.Movement == MovementType.Follow)
				{
					toFollow = m_Guard.Orders.Follow;

					if (toFollow == null)
					{
						toFollow = m_Guard.Town.Sheriff;
					}
				}

				if (toFollow != null && toFollow.Map == m_Guard.Map && toFollow.InRange(m_Guard, m_Guard.RangePerception * 3) && Town.FromRegion(toFollow.Region) == m_Guard.Town)
				{
					if (Action != ActionType.Combat)
					{
						Action = ActionType.Combat;
					}

					if (m_Mobile.CurrentSpeed != m_Mobile.ActiveSpeed)
					{
						m_Mobile.CurrentSpeed = m_Mobile.ActiveSpeed;
					}

					m_Guard.Warmode = true;

					RunTo(toFollow);
				}
				else
				{
					if (Action != ActionType.Wander)
					{
						Action = ActionType.Wander;
					}

					if (m_Mobile.CurrentSpeed != m_Mobile.PassiveSpeed)
					{
						m_Mobile.CurrentSpeed = m_Mobile.PassiveSpeed;
					}

					m_Guard.Warmode = false;

					WalkRandomInHome(2, 2, 1);
				}
			}
			else
			{
				if (Action != ActionType.Wander)
				{
					Action = ActionType.Wander;
				}

				m_Guard.Warmode = false;
			}

			if ((IsDamaged || IsPoisoned) && m_Guard.Skills.Healing.Base > 20.0)
			{
				var ts = TimeUntilBandage;

				if (ts == TimeSpan.MaxValue)
				{
					StartBandage();
				}
			}

			if (m_Mobile.Spell == null && Core.TickCount - m_Mobile.NextSpellTime >= 0)
			{
				Spell spell = null;

				var toRelease = DateTime.MinValue;

				if (IsPoisoned)
				{
					var p = m_Guard.Poison;

					var ts = TimeUntilBandage;

					if (p != Poison.Lesser || ts == TimeSpan.MaxValue || TimeUntilBandage < TimeSpan.FromSeconds(1.5) || (m_Guard.HitsMax - m_Guard.Hits) > Utility.Random(250))
					{
						if (IsAllowed(FactionGuardAIType.Bless))
						{
							spell = new CureSpell(m_Guard, null);
						}
						else
						{
							UseItemByType(typeof(BaseCurePotion));
						}
					}
				}
				else if (IsDamaged && (m_Guard.HitsMax - m_Guard.Hits) > Utility.Random(200))
				{
					if (IsAllowed(FactionGuardAIType.Magic) && ((m_Guard.Hits * 100) / Math.Max(m_Guard.HitsMax, 1)) < 10 && m_Guard.Home != Point3D.Zero && !Utility.InRange(m_Guard.Location, m_Guard.Home, 15) && m_Guard.Mana >= 11)
					{
						spell = new RecallSpell(m_Guard, null, new RunebookEntry(m_Guard.Home, m_Guard.Map, "Guard's Home", null), null);
					}
					else if (IsAllowed(FactionGuardAIType.Bless))
					{
						if (m_Guard.Mana >= 11 && (m_Guard.Hits + 30) < m_Guard.HitsMax)
						{
							spell = new GreaterHealSpell(m_Guard, null);
						}
						else if ((m_Guard.Hits + 10) < m_Guard.HitsMax && (m_Guard.Mana < 11 || (m_Guard.NextCombatTime - Core.TickCount) > 2000))
						{
							spell = new HealSpell(m_Guard, null);
						}
					}
					else if (m_Guard.CanBeginAction(typeof(BaseHealPotion)))
					{
						UseItemByType(typeof(BaseHealPotion));
					}
				}
				else if (dispelTarget != null && (IsAllowed(FactionGuardAIType.Magic) || IsAllowed(FactionGuardAIType.Bless) || IsAllowed(FactionGuardAIType.Curse)))
				{
					if (!dispelTarget.Paralyzed && m_Guard.Mana > (ManaReserve + 20) && 40 > Utility.Random(100))
					{
						spell = new ParalyzeSpell(m_Guard, null);
					}
					else
					{
						spell = new DispelSpell(m_Guard, null);
					}
				}

				if (combatant != null)
				{
					if (m_Combo != null)
					{
						if (spell == null)
						{
							spell = SpellCombo.Process(m_Guard, combatant, ref m_Combo, ref m_ComboIndex, ref toRelease);
						}
						else
						{
							m_Combo = null;
							m_ComboIndex = -1;
						}
					}
					else if (20 > Utility.Random(100) && IsAllowed(FactionGuardAIType.Magic))
					{
						if (80 > Utility.Random(100))
						{
							m_Combo = (IsAllowed(FactionGuardAIType.Smart) ? SpellCombo.Simple : SpellCombo.Strong);
							m_ComboIndex = -1;

							if (m_Guard.Mana >= (ManaReserve + m_Combo.Mana))
							{
								spell = SpellCombo.Process(m_Guard, combatant, ref m_Combo, ref m_ComboIndex, ref toRelease);
							}
							else
							{
								m_Combo = null;

								if (m_Guard.Mana >= (ManaReserve + 40))
								{
									spell = RandomOffenseSpell();
								}
							}
						}
						else if (m_Guard.Mana >= (ManaReserve + 40))
						{
							spell = RandomOffenseSpell();
						}
					}

					if (spell == null && 2 > Utility.Random(100) && m_Guard.Mana >= (ManaReserve + 10))
					{
						var strMod = GetStatMod(m_Guard, StatType.Str);
						var dexMod = GetStatMod(m_Guard, StatType.Dex);
						var intMod = GetStatMod(m_Guard, StatType.Int);

						var types = new List<Type>();

						if (strMod <= 0)
						{
							types.Add(typeof(StrengthSpell));
						}

						if (dexMod <= 0 && IsAllowed(FactionGuardAIType.Melee))
						{
							types.Add(typeof(AgilitySpell));
						}

						if (intMod <= 0 && IsAllowed(FactionGuardAIType.Magic))
						{
							types.Add(typeof(CunningSpell));
						}

						if (IsAllowed(FactionGuardAIType.Bless))
						{
							if (types.Count > 1)
							{
								spell = new BlessSpell(m_Guard, null);
							}
							else if (types.Count == 1)
							{
								spell = (Spell)Activator.CreateInstance(types[0], new object[] { m_Guard, null });
							}
						}
						else if (types.Count > 0)
						{
							if (types[0] == typeof(StrengthSpell))
							{
								UseItemByType(typeof(BaseStrengthPotion));
							}
							else if (types[0] == typeof(AgilitySpell))
							{
								UseItemByType(typeof(BaseAgilityPotion));
							}
						}
					}

					if (spell == null && 2 > Utility.Random(100) && m_Guard.Mana >= (ManaReserve + 10) && IsAllowed(FactionGuardAIType.Curse))
					{
						if (!combatant.Poisoned && 40 > Utility.Random(100))
						{
							spell = new PoisonSpell(m_Guard, null);
						}
						else
						{
							var strMod = GetStatMod(combatant, StatType.Str);
							var dexMod = GetStatMod(combatant, StatType.Dex);
							var intMod = GetStatMod(combatant, StatType.Int);

							var types = new List<Type>();

							if (strMod >= 0)
							{
								types.Add(typeof(WeakenSpell));
							}

							if (dexMod >= 0 && IsAllowed(FactionGuardAIType.Melee))
							{
								types.Add(typeof(ClumsySpell));
							}

							if (intMod >= 0 && IsAllowed(FactionGuardAIType.Magic))
							{
								types.Add(typeof(FeeblemindSpell));
							}

							if (types.Count > 1)
							{
								spell = new CurseSpell(m_Guard, null);
							}
							else if (types.Count == 1)
							{
								spell = (Spell)Activator.CreateInstance(types[0], new object[] { m_Guard, null });
							}
						}
					}
				}

				if (spell != null && (m_Guard.HitsMax - m_Guard.Hits + 10) > Utility.Random(100))
				{
					Type type = null;

					if (spell is GreaterHealSpell)
					{
						type = typeof(BaseHealPotion);
					}
					else if (spell is CureSpell)
					{
						type = typeof(BaseCurePotion);
					}
					else if (spell is StrengthSpell)
					{
						type = typeof(BaseStrengthPotion);
					}
					else if (spell is AgilitySpell)
					{
						type = typeof(BaseAgilityPotion);
					}

					if (type == typeof(BaseHealPotion) && !m_Guard.CanBeginAction(type))
					{
						type = null;
					}

					if (type != null && m_Guard.Target == null && UseItemByType(type))
					{
						if (spell is GreaterHealSpell)
						{
							if ((m_Guard.Hits + 30) > m_Guard.HitsMax && (m_Guard.Hits + 10) < m_Guard.HitsMax)
							{
								spell = new HealSpell(m_Guard, null);
							}
						}
						else
						{
							spell = null;
						}
					}
				}
				else if (spell == null && m_Guard.Stam < (m_Guard.StamMax / 3) && IsAllowed(FactionGuardAIType.Melee))
				{
					UseItemByType(typeof(BaseRefreshPotion));
				}

				if (spell == null || !spell.Cast())
				{
					EquipWeapon();
				}
			}
			else if (m_Mobile.Spell is Spell && ((Spell)m_Mobile.Spell).State == SpellState.Sequencing)
			{
				EquipWeapon();
			}

			return true;
		}
	}

	/// Faction Orders
	public enum ReactionType
	{
		Ignore,
		Warn,
		Attack
	}

	public enum MovementType
	{
		Stand,
		Patrol,
		Follow
	}

	public class Reaction
	{
		private readonly Faction m_Faction;
		private ReactionType m_Type;

		public Faction Faction => m_Faction;
		public ReactionType Type { get => m_Type; set => m_Type = value; }

		public Reaction(Faction faction, ReactionType type)
		{
			m_Faction = faction;
			m_Type = type;
		}

		public Reaction(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			switch (version)
			{
				case 0:
					{
						m_Faction = Faction.ReadReference(reader);
						m_Type = (ReactionType)reader.ReadEncodedInt();

						break;
					}
			}
		}

		public void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			Faction.WriteReference(writer, m_Faction);
			writer.WriteEncodedInt((int)m_Type);
		}
	}

	public class Orders
	{
		private readonly BaseFactionGuard m_Guard;

		private readonly List<Reaction> m_Reactions;
		private MovementType m_Movement;
		private Mobile m_Follow;

		public BaseFactionGuard Guard => m_Guard;

		public MovementType Movement { get => m_Movement; set => m_Movement = value; }
		public Mobile Follow { get => m_Follow; set => m_Follow = value; }

		public Reaction GetReaction(Faction faction)
		{
			Reaction reaction;

			for (var i = 0; i < m_Reactions.Count; ++i)
			{
				reaction = m_Reactions[i];

				if (reaction.Faction == faction)
				{
					return reaction;
				}
			}

			reaction = new Reaction(faction, (faction == null || faction == m_Guard.Faction) ? ReactionType.Ignore : ReactionType.Attack);
			m_Reactions.Add(reaction);

			return reaction;
		}

		public void SetReaction(Faction faction, ReactionType type)
		{
			var reaction = GetReaction(faction);

			reaction.Type = type;
		}

		public Orders(BaseFactionGuard guard)
		{
			m_Guard = guard;
			m_Reactions = new List<Reaction>();
			m_Movement = MovementType.Patrol;
		}

		public Orders(BaseFactionGuard guard, GenericReader reader)
		{
			m_Guard = guard;

			var version = reader.ReadEncodedInt();

			switch (version)
			{
				case 1:
					{
						m_Follow = reader.ReadMobile();
						goto case 0;
					}
				case 0:
					{
						var count = reader.ReadEncodedInt();
						m_Reactions = new List<Reaction>(count);

						for (var i = 0; i < count; ++i)
						{
							m_Reactions.Add(new Reaction(reader));
						}

						m_Movement = (MovementType)reader.ReadEncodedInt();

						break;
					}
			}
		}

		public void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(1); // version

			writer.Write(m_Follow);

			writer.WriteEncodedInt(m_Reactions.Count);

			for (var i = 0; i < m_Reactions.Count; ++i)
			{
				m_Reactions[i].Serialize(writer);
			}

			writer.WriteEncodedInt((int)m_Movement);
		}
	}
}