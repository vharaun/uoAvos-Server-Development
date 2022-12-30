using Server.Ethics;
using Server.Factions;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

using System;
using System.Text;

namespace Server.Ethics
{
	public abstract class Ethic
	{
		public static readonly bool Enabled = false;

		public static Ethic Find(Item item)
		{
			if ((item.SavedFlags & 0x100) != 0)
			{
				if (item.Hue == Hero.Definition.PrimaryHue)
				{
					return Hero;
				}

				item.SavedFlags &= ~0x100;
			}

			if ((item.SavedFlags & 0x200) != 0)
			{
				if (item.Hue == Evil.Definition.PrimaryHue)
				{
					return Evil;
				}

				item.SavedFlags &= ~0x200;
			}

			return null;
		}

		public static bool CheckTrade(Mobile from, Mobile to, Mobile newOwner, Item item)
		{
			var itemEthic = Find(item);

			if (itemEthic == null || Find(newOwner) == itemEthic)
			{
				return true;
			}

			if (itemEthic == Hero)
			{
				(from == newOwner ? to : from).SendMessage("Only heros may receive this item.");
			}
			else if (itemEthic == Evil)
			{
				(from == newOwner ? to : from).SendMessage("Only the evil may receive this item.");
			}

			return false;
		}

		public static bool CheckEquip(Mobile from, Item item)
		{
			var itemEthic = Find(item);

			if (itemEthic == null || Find(from) == itemEthic)
			{
				return true;
			}

			if (itemEthic == Hero)
			{
				from.SendMessage("Only heros may wear this item.");
			}
			else if (itemEthic == Evil)
			{
				from.SendMessage("Only the evil may wear this item.");
			}

			return false;
		}

		public static bool IsImbued(Item item)
		{
			return IsImbued(item, false);
		}

		public static bool IsImbued(Item item, bool recurse)
		{
			if (Find(item) != null)
			{
				return true;
			}

			if (recurse)
			{
				foreach (var child in item.Items)
				{
					if (IsImbued(child, true))
					{
						return true;
					}
				}
			}

			return false;
		}

		public static void Initialize()
		{
			if (Enabled)
			{
				EventSink.Speech += new SpeechEventHandler(EventSink_Speech);
			}
		}

		public static void EventSink_Speech(SpeechEventArgs e)
		{
			if (e.Blocked || e.Handled)
			{
				return;
			}

			var pl = Player.Find(e.Mobile);

			if (pl == null)
			{
				for (var i = 0; i < Ethics.Length; ++i)
				{
					var ethic = Ethics[i];

					if (!ethic.IsEligible(e.Mobile))
					{
						continue;
					}

					if (!Insensitive.Equals(ethic.Definition.JoinPhrase.String, e.Speech))
					{
						continue;
					}

					var isNearAnkh = false;

					foreach (var item in e.Mobile.GetItemsInRange(2))
					{
						if (item is Items.AnkhNorth || item is Items.AnkhWest)
						{
							isNearAnkh = true;
							break;
						}
					}

					if (!isNearAnkh)
					{
						continue;
					}

					pl = new Player(ethic, e.Mobile);

					pl.Attach();

					e.Mobile.FixedEffect(0x373A, 10, 30);
					e.Mobile.PlaySound(0x209);

					e.Handled = true;
					break;
				}
			}
			else
			{
				if (e.Mobile is PlayerMobile && (e.Mobile as PlayerMobile).DuelContext != null)
				{
					return;
				}

				var ethic = pl.Ethic;

				for (var i = 0; i < ethic.Definition.Powers.Length; ++i)
				{
					var power = ethic.Definition.Powers[i];

					if (!Insensitive.Equals(power.Definition.Phrase.String, e.Speech))
					{
						continue;
					}

					if (!power.CheckInvoke(pl))
					{
						continue;
					}

					power.BeginInvoke(pl);
					e.Handled = true;

					break;
				}
			}
		}

		protected EthicDefinition m_Definition;

		protected PlayerCollection m_Players;

		public EthicDefinition Definition => m_Definition;

		public PlayerCollection Players => m_Players;

		public static Ethic Find(Mobile mob)
		{
			return Find(mob, false, false);
		}

		public static Ethic Find(Mobile mob, bool inherit)
		{
			return Find(mob, inherit, false);
		}

		public static Ethic Find(Mobile mob, bool inherit, bool allegiance)
		{
			var pl = Player.Find(mob);

			if (pl != null)
			{
				return pl.Ethic;
			}

			if (inherit && mob is BaseCreature)
			{
				var bc = (BaseCreature)mob;

				if (bc.Controlled)
				{
					return Find(bc.ControlMaster, false);
				}
				else if (bc.Summoned)
				{
					return Find(bc.SummonMaster, false);
				}
				else if (allegiance)
				{
					return bc.EthicAllegiance;
				}
			}

			return null;
		}

		public Ethic()
		{
			m_Players = new PlayerCollection();
		}

		public abstract bool IsEligible(Mobile mob);

		public virtual void Deserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			switch (version)
			{
				case 0:
					{
						var playerCount = reader.ReadEncodedInt();

						for (var i = 0; i < playerCount; ++i)
						{
							var pl = new Player(this, reader);

							if (pl.Mobile != null)
							{
								Timer.DelayCall(TimeSpan.Zero, pl.CheckAttach);
							}
						}

						break;
					}
			}
		}

		public virtual void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.WriteEncodedInt(m_Players.Count);

			for (var i = 0; i < m_Players.Count; ++i)
			{
				m_Players[i].Serialize(writer);
			}
		}

		public static readonly Ethic Hero = new Hero.HeroEthic();
		public static readonly Ethic Evil = new Evil.EvilEthic();

		public static readonly Ethic[] Ethics = new Ethic[]
			{
				Hero,
				Evil
			};
	}

	public class EthicDefinition
	{
		private readonly int m_PrimaryHue;

		private readonly TextDefinition m_Title;
		private readonly TextDefinition m_Adjunct;

		private readonly TextDefinition m_JoinPhrase;

		private readonly Power[] m_Powers;

		public int PrimaryHue => m_PrimaryHue;

		public TextDefinition Title => m_Title;
		public TextDefinition Adjunct => m_Adjunct;

		public TextDefinition JoinPhrase => m_JoinPhrase;

		public Power[] Powers => m_Powers;

		public EthicDefinition(int primaryHue, TextDefinition title, TextDefinition adjunct, TextDefinition joinPhrase, Power[] powers)
		{
			m_PrimaryHue = primaryHue;

			m_Title = title;
			m_Adjunct = adjunct;

			m_JoinPhrase = joinPhrase;

			m_Powers = powers;
		}
	}

	public class EthicsPersistance : Item
	{
		private static EthicsPersistance m_Instance;

		public static EthicsPersistance Instance => m_Instance;

		public override string DefaultName => "Ethics Persistance - Internal";

		[Constructable]
		public EthicsPersistance()
			: base(1)
		{
			Movable = false;

			if (m_Instance == null || m_Instance.Deleted)
			{
				m_Instance = this;
			}
			else
			{
				base.Delete();
			}
		}

		public EthicsPersistance(Serial serial)
			: base(serial)
		{
			m_Instance = this;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			for (var i = 0; i < Ethics.Ethic.Ethics.Length; ++i)
			{
				Ethics.Ethic.Ethics[i].Serialize(writer);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						for (var i = 0; i < Ethics.Ethic.Ethics.Length; ++i)
						{
							Ethics.Ethic.Ethics[i].Deserialize(reader);
						}

						break;
					}
			}
		}

		public override void Delete()
		{
		}
	}

	[PropertyObject]
	public class Player
	{
		public static Player Find(Mobile mob)
		{
			return Find(mob, false);
		}

		public static Player Find(Mobile mob, bool inherit)
		{
			var pm = mob as PlayerMobile;

			if (pm == null)
			{
				if (inherit && mob is BaseCreature)
				{
					var bc = mob as BaseCreature;

					if (bc != null && bc.Controlled)
					{
						pm = bc.ControlMaster as PlayerMobile;
					}
					else if (bc != null && bc.Summoned)
					{
						pm = bc.SummonMaster as PlayerMobile;
					}
				}

				if (pm == null)
				{
					return null;
				}
			}

			var pl = pm.EthicPlayer;

			if (pl != null && !pl.Ethic.IsEligible(pl.Mobile))
			{
				pm.EthicPlayer = pl = null;
			}

			return pl;
		}

		private readonly Ethic m_Ethic;
		private readonly Mobile m_Mobile;

		private int m_Power;
		private int m_History;

		private Mobile m_Steed;
		private Mobile m_Familiar;

		private DateTime m_Shield;

		public Ethic Ethic => m_Ethic;
		public Mobile Mobile => m_Mobile;

		[CommandProperty(AccessLevel.GameMaster, AccessLevel.Administrator)]
		public int Power { get => m_Power; set => m_Power = value; }

		[CommandProperty(AccessLevel.GameMaster, AccessLevel.Administrator)]
		public int History { get => m_History; set => m_History = value; }

		[CommandProperty(AccessLevel.GameMaster, AccessLevel.Administrator)]
		public Mobile Steed { get => m_Steed; set => m_Steed = value; }

		[CommandProperty(AccessLevel.GameMaster, AccessLevel.Administrator)]
		public Mobile Familiar { get => m_Familiar; set => m_Familiar = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsShielded
		{
			get
			{
				if (m_Shield == DateTime.MinValue)
				{
					return false;
				}

				if (DateTime.UtcNow < (m_Shield + TimeSpan.FromHours(1.0)))
				{
					return true;
				}

				FinishShield();
				return false;
			}
		}

		public void BeginShield()
		{
			m_Shield = DateTime.UtcNow;
		}

		public void FinishShield()
		{
			m_Shield = DateTime.MinValue;
		}

		public Player(Ethic ethic, Mobile mobile)
		{
			m_Ethic = ethic;
			m_Mobile = mobile;

			m_Power = 5;
			m_History = 5;
		}

		public void CheckAttach()
		{
			if (m_Ethic.IsEligible(m_Mobile))
			{
				Attach();
			}
		}

		public void Attach()
		{
			if (m_Mobile is PlayerMobile)
			{
				(m_Mobile as PlayerMobile).EthicPlayer = this;
			}

			m_Ethic.Players.Add(this);
		}

		public void Detach()
		{
			if (m_Mobile is PlayerMobile)
			{
				(m_Mobile as PlayerMobile).EthicPlayer = null;
			}

			m_Ethic.Players.Remove(this);
		}

		public Player(Ethic ethic, GenericReader reader)
		{
			m_Ethic = ethic;

			var version = reader.ReadEncodedInt();

			switch (version)
			{
				case 0:
					{
						m_Mobile = reader.ReadMobile();

						m_Power = reader.ReadEncodedInt();
						m_History = reader.ReadEncodedInt();

						m_Steed = reader.ReadMobile();
						m_Familiar = reader.ReadMobile();

						m_Shield = reader.ReadDeltaTime();

						break;
					}
			}
		}

		public void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_Mobile);

			writer.WriteEncodedInt(m_Power);
			writer.WriteEncodedInt(m_History);

			writer.Write(m_Steed);
			writer.Write(m_Familiar);

			writer.WriteDeltaTime(m_Shield);
		}
	}

	public class PlayerCollection : System.Collections.ObjectModel.Collection<Player>
	{
	}

	public abstract class Power
	{
		protected PowerDefinition m_Definition;

		public PowerDefinition Definition => m_Definition;

		public virtual bool CheckInvoke(Player from)
		{
			if (!from.Mobile.CheckAlive())
			{
				return false;
			}

			if (from.Power < m_Definition.Power)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You lack the power to invoke this ability.");
				return false;
			}

			return true;
		}

		public abstract void BeginInvoke(Player from);

		public virtual void FinishInvoke(Player from)
		{
			from.Power -= m_Definition.Power;
		}
	}

	public class PowerDefinition
	{
		private readonly int m_Power;

		private readonly TextDefinition m_Name;
		private readonly TextDefinition m_Phrase;
		private readonly TextDefinition m_Description;

		public int Power => m_Power;

		public TextDefinition Name => m_Name;
		public TextDefinition Phrase => m_Phrase;
		public TextDefinition Description => m_Description;

		public PowerDefinition(int power, TextDefinition name, TextDefinition phrase, TextDefinition description)
		{
			m_Power = power;

			m_Name = name;
			m_Phrase = phrase;
			m_Description = description;
		}
	}
}

namespace Server.Ethics.Evil
{
	public sealed class EvilEthic : Ethic
	{
		public EvilEthic()
		{
			m_Definition = new EthicDefinition(
					0x455,
					"Evil", "(Evil)",
					"I am evil incarnate",
					new Power[]
					{
						new UnholySense(),
						new UnholyItem(),
						new SummonFamiliar(),
						new VileBlade(),
						new Blight(),
						new UnholyShield(),
						new UnholySteed(),
						new UnholyWord()
					}
				);
		}

		public override bool IsEligible(Mobile mob)
		{
			var fac = Faction.Find(mob);

			return fac?.Definition.Ethic == FactionEthic.Evil;
		}
	}

	#region Evil Ethics Powers

	public sealed class Blight : Power
	{
		public Blight()
		{
			m_Definition = new PowerDefinition(
					15,
					"Blight",
					"Velgo Ontawl",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			from.Mobile.BeginTarget(12, true, Targeting.TargetFlags.None, new TargetStateCallback(Power_OnTarget), from);
			from.Mobile.SendMessage("Where do you wish to blight?");
		}

		private void Power_OnTarget(Mobile fromMobile, object obj, object state)
		{
			var from = state as Player;

			var p = obj as IPoint3D;

			if (p == null)
			{
				return;
			}

			if (!CheckInvoke(from))
			{
				return;
			}

			var powerFunctioned = false;

			SpellHelper.GetSurfaceTop(ref p);

			foreach (var mob in from.Mobile.GetMobilesInRange(6))
			{
				if (mob == from.Mobile || !SpellHelper.ValidIndirectTarget(from.Mobile, mob))
				{
					continue;
				}

				if (mob.GetStatMod("Holy Curse") != null)
				{
					continue;
				}

				if (!from.Mobile.CanBeHarmful(mob, false))
				{
					continue;
				}

				from.Mobile.DoHarmful(mob, true);

				mob.AddStatMod(new StatMod(StatType.All, "Holy Curse", -10, TimeSpan.FromMinutes(30.0)));

				mob.FixedParticles(0x374A, 10, 15, 5028, EffectLayer.Waist);
				mob.PlaySound(0x1FB);

				powerFunctioned = true;
			}

			if (powerFunctioned)
			{
				SpellHelper.Turn(from.Mobile, p);

				Effects.PlaySound(p, from.Mobile.Map, 0x1FB);

				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You curse the area.");

				FinishInvoke(from);
			}
			else
			{
				from.Mobile.FixedEffect(0x3735, 6, 30);
				from.Mobile.PlaySound(0x5C);
			}
		}
	}

	public sealed class SummonFamiliar : Power
	{
		public SummonFamiliar()
		{
			m_Definition = new PowerDefinition(
					5,
					"Summon Familiar",
					"Trubechs Vingir",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			if (from.Familiar != null && from.Familiar.Deleted)
			{
				from.Familiar = null;
			}

			if (from.Familiar != null)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You already have an unholy familiar.");
				return;
			}

			if ((from.Mobile.Followers + 1) > from.Mobile.FollowersMax)
			{
				from.Mobile.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return;
			}

			var familiar = new UnholyFamiliar();

			if (Mobiles.BaseCreature.Summon(familiar, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours(1.0)))
			{
				from.Familiar = familiar;

				FinishInvoke(from);
			}
		}
	}

	public sealed class UnholyItem : Power
	{
		public UnholyItem()
		{
			m_Definition = new PowerDefinition(
					5,
					"Unholy Item",
					"Vidda K'balc",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			from.Mobile.BeginTarget(12, false, Targeting.TargetFlags.None, new TargetStateCallback(Power_OnTarget), from);
			from.Mobile.SendMessage("Which item do you wish to imbue?");
		}

		private void Power_OnTarget(Mobile fromMobile, object obj, object state)
		{
			var from = state as Player;

			var item = obj as Item;

			if (item == null)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that.");
				return;
			}

			if (item.Parent != from.Mobile)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You may only imbue items you are wearing.");
				return;
			}

			if ((item.SavedFlags & 0x300) != 0)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "That has already beem imbued.");
				return;
			}

			var canImbue = (item is Spellbook || item is BaseClothing || item is BaseArmor || item is BaseWeapon) && (item.Name == null);

			if (canImbue)
			{
				if (!CheckInvoke(from))
				{
					return;
				}

				item.Hue = Ethic.Evil.Definition.PrimaryHue;
				item.SavedFlags |= 0x200;

				from.Mobile.FixedEffect(0x375A, 10, 20);
				from.Mobile.PlaySound(0x209);

				FinishInvoke(from);
			}
			else
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that.");
			}
		}
	}

	public sealed class UnholySense : Power
	{
		public UnholySense()
		{
			m_Definition = new PowerDefinition(
					0,
					"Unholy Sense",
					"Drewrok Velgo",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			var opposition = Ethic.Hero;

			var enemyCount = 0;

			var maxRange = 18 + from.Power;

			Player primary = null;

			foreach (var pl in opposition.Players)
			{
				var mob = pl.Mobile;

				if (mob == null || mob.Map != from.Mobile.Map || !mob.Alive)
				{
					continue;
				}

				if (!mob.InRange(from.Mobile, Math.Max(18, maxRange - pl.Power)))
				{
					continue;
				}

				if (primary == null || pl.Power > primary.Power)
				{
					primary = pl;
				}

				++enemyCount;
			}

			var sb = new StringBuilder();

			sb.Append("You sense ");
			sb.Append(enemyCount == 0 ? "no" : enemyCount.ToString());
			sb.Append(enemyCount == 1 ? " enemy" : " enemies");

			if (primary != null)
			{
				sb.Append(", and a strong presense");

				switch (from.Mobile.GetDirectionTo(primary.Mobile))
				{
					case Direction.West:
						sb.Append(" to the west.");
						break;
					case Direction.East:
						sb.Append(" to the east.");
						break;
					case Direction.North:
						sb.Append(" to the north.");
						break;
					case Direction.South:
						sb.Append(" to the south.");
						break;

					case Direction.Up:
						sb.Append(" to the north-west.");
						break;
					case Direction.Down:
						sb.Append(" to the south-east.");
						break;
					case Direction.Left:
						sb.Append(" to the south-west.");
						break;
					case Direction.Right:
						sb.Append(" to the north-east.");
						break;
				}
			}
			else
			{
				sb.Append('.');
			}

			from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x59, false, sb.ToString());

			FinishInvoke(from);
		}
	}

	public sealed class UnholyShield : Power
	{
		public UnholyShield()
		{
			m_Definition = new PowerDefinition(
					20,
					"Unholy Shield",
					"Velgo K'blac",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			if (from.IsShielded)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You are already under the protection of an unholy shield.");
				return;
			}

			from.BeginShield();

			from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You are now under the protection of an unholy shield.");

			FinishInvoke(from);
		}
	}

	public sealed class UnholySteed : Power
	{
		public UnholySteed()
		{
			m_Definition = new PowerDefinition(
					30,
					"Unholy Steed",
					"Trubechs Yeliab",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			if (from.Steed != null && from.Steed.Deleted)
			{
				from.Steed = null;
			}

			if (from.Steed != null)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You already have an unholy steed.");
				return;
			}

			if ((from.Mobile.Followers + 1) > from.Mobile.FollowersMax)
			{
				from.Mobile.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return;
			}

			var steed = new Mobiles.UnholySteed();

			if (Mobiles.BaseCreature.Summon(steed, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours(1.0)))
			{
				from.Steed = steed;

				FinishInvoke(from);
			}
		}
	}

	public sealed class UnholyWord : Power
	{
		public UnholyWord()
		{
			m_Definition = new PowerDefinition(
					100,
					"Unholy Word",
					"Velgo Oostrac",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
		}
	}

	public sealed class VileBlade : Power
	{
		public VileBlade()
		{
			m_Definition = new PowerDefinition(
					10,
					"Vile Blade",
					"Velgo Reyam",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
		}
	}

	#endregion
}

namespace Server.Ethics.Hero
{
	public sealed class HeroEthic : Ethic
	{
		public HeroEthic()
		{
			m_Definition = new EthicDefinition(
					0x482,
					"Hero", "(Hero)",
					"I will defend the virtues",
					new Power[]
					{
						new HolySense(),
						new HolyItem(),
						new SummonFamiliar(),
						new HolyBlade(),
						new Bless(),
						new HolyShield(),
						new HolySteed(),
						new HolyWord()
					}
				);
		}

		public override bool IsEligible(Mobile mob)
		{
			if (mob.Murderer)
			{
				return false;
			}

			var fac = Faction.Find(mob);

			return fac?.Definition.Ethic == FactionEthic.Good;
		}
	}

	#region Hero Ethics Powers

	public sealed class Bless : Power
	{
		public Bless()
		{
			m_Definition = new PowerDefinition(
					15,
					"Bless",
					"Erstok Ontawl",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			from.Mobile.BeginTarget(12, true, Targeting.TargetFlags.None, new TargetStateCallback(Power_OnTarget), from);
			from.Mobile.SendMessage("Where do you wish to bless?");
		}

		private void Power_OnTarget(Mobile fromMobile, object obj, object state)
		{
			var from = state as Player;

			var p = obj as IPoint3D;

			if (p == null)
			{
				return;
			}

			if (!CheckInvoke(from))
			{
				return;
			}

			var powerFunctioned = false;

			SpellHelper.GetSurfaceTop(ref p);

			foreach (var mob in from.Mobile.GetMobilesInRange(6))
			{
				if (mob != from.Mobile && SpellHelper.ValidIndirectTarget(from.Mobile, mob))
				{
					continue;
				}

				if (mob.GetStatMod("Holy Bless") != null)
				{
					continue;
				}

				if (!from.Mobile.CanBeBeneficial(mob, false))
				{
					continue;
				}

				from.Mobile.DoBeneficial(mob);

				mob.AddStatMod(new StatMod(StatType.All, "Holy Bless", 10, TimeSpan.FromMinutes(30.0)));

				mob.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist);
				mob.PlaySound(0x1EA);

				powerFunctioned = true;
			}

			if (powerFunctioned)
			{
				SpellHelper.Turn(from.Mobile, p);

				Effects.PlaySound(p, from.Mobile.Map, 0x299);

				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You consecrate the area.");

				FinishInvoke(from);
			}
			else
			{
				from.Mobile.FixedEffect(0x3735, 6, 30);
				from.Mobile.PlaySound(0x5C);
			}
		}
	}

	public sealed class SummonFamiliar : Power
	{
		public SummonFamiliar()
		{
			m_Definition = new PowerDefinition(
					5,
					"Summon Familiar",
					"Trubechs Vingir",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			if (from.Familiar != null && from.Familiar.Deleted)
			{
				from.Familiar = null;
			}

			if (from.Familiar != null)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You already have a holy familiar.");
				return;
			}

			if ((from.Mobile.Followers + 1) > from.Mobile.FollowersMax)
			{
				from.Mobile.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return;
			}

			var familiar = new HolyFamiliar();

			if (Mobiles.BaseCreature.Summon(familiar, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours(1.0)))
			{
				from.Familiar = familiar;

				FinishInvoke(from);
			}
		}
	}

	public sealed class HolyItem : Power
	{
		public HolyItem()
		{
			m_Definition = new PowerDefinition(
					5,
					"Holy Item",
					"Vidda K'balc",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			from.Mobile.BeginTarget(12, false, Targeting.TargetFlags.None, new TargetStateCallback(Power_OnTarget), from);
			from.Mobile.SendMessage("Which item do you wish to imbue?");
		}

		private void Power_OnTarget(Mobile fromMobile, object obj, object state)
		{
			var from = state as Player;

			var item = obj as Item;

			if (item == null)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that.");
				return;
			}

			if (item.Parent != from.Mobile)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You may only imbue items you are wearing.");
				return;
			}

			if ((item.SavedFlags & 0x300) != 0)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "That has already beem imbued.");
				return;
			}

			var canImbue = (item is Spellbook || item is BaseClothing || item is BaseArmor || item is BaseWeapon) && (item.Name == null);

			if (canImbue)
			{
				if (!CheckInvoke(from))
				{
					return;
				}

				item.Hue = Ethic.Hero.Definition.PrimaryHue;
				item.SavedFlags |= 0x100;

				from.Mobile.FixedEffect(0x375A, 10, 20);
				from.Mobile.PlaySound(0x209);

				FinishInvoke(from);
			}
			else
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that.");
			}
		}
	}

	public sealed class HolySense : Power
	{
		public HolySense()
		{
			m_Definition = new PowerDefinition(
					0,
					"Holy Sense",
					"Drewrok Erstok",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			var opposition = Ethic.Evil;

			var enemyCount = 0;

			var maxRange = 18 + from.Power;

			Player primary = null;

			foreach (var pl in opposition.Players)
			{
				var mob = pl.Mobile;

				if (mob == null || mob.Map != from.Mobile.Map || !mob.Alive)
				{
					continue;
				}

				if (!mob.InRange(from.Mobile, Math.Max(18, maxRange - pl.Power)))
				{
					continue;
				}

				if (primary == null || pl.Power > primary.Power)
				{
					primary = pl;
				}

				++enemyCount;
			}

			var sb = new StringBuilder();

			sb.Append("You sense ");
			sb.Append(enemyCount == 0 ? "no" : enemyCount.ToString());
			sb.Append(enemyCount == 1 ? " enemy" : " enemies");

			if (primary != null)
			{
				sb.Append(", and a strong presense");

				switch (from.Mobile.GetDirectionTo(primary.Mobile))
				{
					case Direction.West:
						sb.Append(" to the west.");
						break;
					case Direction.East:
						sb.Append(" to the east.");
						break;
					case Direction.North:
						sb.Append(" to the north.");
						break;
					case Direction.South:
						sb.Append(" to the south.");
						break;

					case Direction.Up:
						sb.Append(" to the north-west.");
						break;
					case Direction.Down:
						sb.Append(" to the south-east.");
						break;
					case Direction.Left:
						sb.Append(" to the south-west.");
						break;
					case Direction.Right:
						sb.Append(" to the north-east.");
						break;
				}
			}
			else
			{
				sb.Append('.');
			}

			from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x59, false, sb.ToString());

			FinishInvoke(from);
		}
	}

	public sealed class HolyShield : Power
	{
		public HolyShield()
		{
			m_Definition = new PowerDefinition(
					20,
					"Holy Shield",
					"Erstok K'blac",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			if (from.IsShielded)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You are already under the protection of a holy shield.");
				return;
			}

			from.BeginShield();

			from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You are now under the protection of a holy shield.");

			FinishInvoke(from);
		}
	}

	public sealed class HolySteed : Power
	{
		public HolySteed()
		{
			m_Definition = new PowerDefinition(
					30,
					"Holy Steed",
					"Trubechs Yeliab",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
			if (from.Steed != null && from.Steed.Deleted)
			{
				from.Steed = null;
			}

			if (from.Steed != null)
			{
				from.Mobile.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, false, "You already have a holy steed.");
				return;
			}

			if ((from.Mobile.Followers + 1) > from.Mobile.FollowersMax)
			{
				from.Mobile.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return;
			}

			var steed = new Mobiles.HolySteed();

			if (Mobiles.BaseCreature.Summon(steed, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours(1.0)))
			{
				from.Steed = steed;

				FinishInvoke(from);
			}
		}
	}

	public sealed class HolyWord : Power
	{
		public HolyWord()
		{
			m_Definition = new PowerDefinition(
					100,
					"Holy Word",
					"Erstok Oostrac",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
		}
	}

	public sealed class HolyBlade : Power
	{
		public HolyBlade()
		{
			m_Definition = new PowerDefinition(
					10,
					"Holy Blade",
					"Erstok Reyam",
					""
				);
		}

		public override void BeginInvoke(Player from)
		{
		}
	}

	#endregion
}

namespace Server.Mobiles
{
	#region Evil Ethic Mobiles

	[CorpseName("an unholy corpse")]
	public class UnholySteed : BaseMount
	{
		public override bool IsDispellable => false;
		public override bool IsBondable => false;

		public override bool HasBreath => true;
		public override bool CanBreath => true;

		[Constructable]
		public UnholySteed()
			: base("a dark steed", 0x74, 0x3EA7, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
		{
			SetStr(496, 525);
			SetDex(86, 105);
			SetInt(86, 125);

			SetHits(298, 315);

			SetDamage(16, 22);

			SetDamageType(ResistanceType.Physical, 40);
			SetDamageType(ResistanceType.Fire, 40);
			SetDamageType(ResistanceType.Energy, 20);

			SetResistance(ResistanceType.Physical, 55, 65);
			SetResistance(ResistanceType.Fire, 30, 40);
			SetResistance(ResistanceType.Cold, 30, 40);
			SetResistance(ResistanceType.Poison, 30, 40);
			SetResistance(ResistanceType.Energy, 20, 30);

			SetSkill(SkillName.MagicResist, 25.1, 30.0);
			SetSkill(SkillName.Tactics, 97.6, 100.0);
			SetSkill(SkillName.Wrestling, 80.5, 92.5);

			Fame = 14000;
			Karma = -14000;

			VirtualArmor = 60;

			Tamable = false;
			ControlSlots = 1;
		}

		public override FoodType FavoriteFood => FoodType.FruitsAndVegies | FoodType.GrainsAndHay;

		public UnholySteed(Serial serial)
			: base(serial)
		{
		}

		public override string ApplyNameSuffix(string suffix)
		{
			if (suffix.Length == 0)
			{
				suffix = Ethic.Evil.Definition.Adjunct.String;
			}
			else
			{
				suffix = String.Concat(suffix, " ", Ethic.Evil.Definition.Adjunct.String);
			}

			return base.ApplyNameSuffix(suffix);
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (Ethic.Find(from) != Ethic.Evil)
			{
				from.SendMessage("You may not ride this steed.");
			}
			else
			{
				base.OnDoubleClick(from);
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
		}
	}

	[CorpseName("an evil corpse")]
	public class UnholyFamiliar : BaseCreature
	{
		public override bool IsDispellable => false;
		public override bool IsBondable => false;

		[Constructable]
		public UnholyFamiliar()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "a dark wolf";
			Body = 99;
			BaseSoundID = 0xE5;

			SetStr(96, 120);
			SetDex(81, 105);
			SetInt(36, 60);

			SetHits(58, 72);
			SetMana(0);

			SetDamage(11, 17);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 20, 25);
			SetResistance(ResistanceType.Fire, 10, 20);
			SetResistance(ResistanceType.Cold, 5, 10);
			SetResistance(ResistanceType.Poison, 5, 10);
			SetResistance(ResistanceType.Energy, 10, 15);

			SetSkill(SkillName.MagicResist, 57.6, 75.0);
			SetSkill(SkillName.Tactics, 50.1, 70.0);
			SetSkill(SkillName.Wrestling, 60.1, 80.0);

			Fame = 2500;
			Karma = 2500;

			VirtualArmor = 22;

			Tamable = false;
			ControlSlots = 1;
		}

		public override int Meat => 1;
		public override int Hides => 7;
		public override FoodType FavoriteFood => FoodType.Meat;
		public override PackInstinct PackInstinct => PackInstinct.Canine;

		public UnholyFamiliar(Serial serial)
			: base(serial)
		{
		}

		public override string ApplyNameSuffix(string suffix)
		{
			if (suffix.Length == 0)
			{
				suffix = Ethic.Evil.Definition.Adjunct.String;
			}
			else
			{
				suffix = String.Concat(suffix, " ", Ethic.Evil.Definition.Adjunct.String);
			}

			return base.ApplyNameSuffix(suffix);
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

	#endregion

	#region Hero Ethic Mobiles

	[CorpseName("a holy corpse")]
	public class HolySteed : BaseMount
	{
		public override bool IsDispellable => false;
		public override bool IsBondable => false;

		public override bool HasBreath => true;
		public override bool CanBreath => true;

		[Constructable]
		public HolySteed()
			: base("a silver steed", 0x75, 0x3EA8, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
		{
			SetStr(496, 525);
			SetDex(86, 105);
			SetInt(86, 125);

			SetHits(298, 315);

			SetDamage(16, 22);

			SetDamageType(ResistanceType.Physical, 40);
			SetDamageType(ResistanceType.Fire, 40);
			SetDamageType(ResistanceType.Energy, 20);

			SetResistance(ResistanceType.Physical, 55, 65);
			SetResistance(ResistanceType.Fire, 30, 40);
			SetResistance(ResistanceType.Cold, 30, 40);
			SetResistance(ResistanceType.Poison, 30, 40);
			SetResistance(ResistanceType.Energy, 20, 30);

			SetSkill(SkillName.MagicResist, 25.1, 30.0);
			SetSkill(SkillName.Tactics, 97.6, 100.0);
			SetSkill(SkillName.Wrestling, 80.5, 92.5);

			Fame = 14000;
			Karma = 14000;

			VirtualArmor = 60;

			Tamable = false;
			ControlSlots = 1;
		}

		public override FoodType FavoriteFood => FoodType.FruitsAndVegies | FoodType.GrainsAndHay;

		public HolySteed(Serial serial)
			: base(serial)
		{
		}

		public override string ApplyNameSuffix(string suffix)
		{
			if (suffix.Length == 0)
			{
				suffix = Ethic.Hero.Definition.Adjunct.String;
			}
			else
			{
				suffix = String.Concat(suffix, " ", Ethic.Hero.Definition.Adjunct.String);
			}

			return base.ApplyNameSuffix(suffix);
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (Ethic.Find(from) != Ethic.Hero)
			{
				from.SendMessage("You may not ride this steed.");
			}
			else
			{
				base.OnDoubleClick(from);
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
		}
	}

	[CorpseName("a holy corpse")]
	public class HolyFamiliar : BaseCreature
	{
		public override bool IsDispellable => false;
		public override bool IsBondable => false;

		[Constructable]
		public HolyFamiliar()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "a silver wolf";
			Body = 100;
			BaseSoundID = 0xE5;

			SetStr(96, 120);
			SetDex(81, 105);
			SetInt(36, 60);

			SetHits(58, 72);
			SetMana(0);

			SetDamage(11, 17);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 20, 25);
			SetResistance(ResistanceType.Fire, 10, 20);
			SetResistance(ResistanceType.Cold, 5, 10);
			SetResistance(ResistanceType.Poison, 5, 10);
			SetResistance(ResistanceType.Energy, 10, 15);

			SetSkill(SkillName.MagicResist, 57.6, 75.0);
			SetSkill(SkillName.Tactics, 50.1, 70.0);
			SetSkill(SkillName.Wrestling, 60.1, 80.0);

			Fame = 2500;
			Karma = 2500;

			VirtualArmor = 22;

			Tamable = false;
			ControlSlots = 1;
		}

		public override int Meat => 1;
		public override int Hides => 7;
		public override FoodType FavoriteFood => FoodType.Meat;
		public override PackInstinct PackInstinct => PackInstinct.Canine;

		public HolyFamiliar(Serial serial)
			: base(serial)
		{
		}

		public override string ApplyNameSuffix(string suffix)
		{
			if (suffix.Length == 0)
			{
				suffix = Ethic.Hero.Definition.Adjunct.String;
			}
			else
			{
				suffix = String.Concat(suffix, " ", Ethic.Hero.Definition.Adjunct.String);
			}

			return base.ApplyNameSuffix(suffix);
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

	#endregion
}