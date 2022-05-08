using System;
using System.Collections.Generic;

namespace Server
{
	public interface ISpell
	{
		int ID { get; }

		bool IsCasting { get; }

		void OnCasterHurt();
		void OnCasterKilled();
		void OnConnectionChanged();
		bool OnCasterMoving(Direction d);
		bool OnCasterEquiping(Item item);
		bool OnCasterUsingObject(object o);
		bool OnCastInTown(Region r);
	}

	public enum SpellName
	{
		#region First

		Clumsy = 0,
		CreateFood = 1,
		Feeblemind = 2,
		Heal = 3,
		MagicArrow = 4,
		NightSight = 5,
		ReactiveArmor = 6,
		Weaken = 7,

		#endregion

		#region Second

		Agility = 8,
		Cunning = 9,
		Cure = 10,
		Harm = 11,
		MagicTrap = 12,
		RemoveTrap = 13,
		Protection = 14,
		Strength = 15,

		#endregion

		#region Third

		Bless = 16,
		Fireball = 17,
		MagicLock = 18,
		Poison = 19,
		Telekinesis = 20,
		Teleport = 21,
		Unlock = 22,
		WallOfStone = 23,

		#endregion

		#region Fourth

		ArchCure = 24,
		ArchProtection = 25,
		Curse = 26,
		FireField = 27,
		GreaterHeal = 28,
		Lightning = 29,
		ManaDrain = 30,
		Recall = 31,

		#endregion

		#region Fifth

		BladeSpirits = 32,
		DispelField = 33,
		Incognito = 34,
		MagicReflect = 35,
		MindBlast = 36,
		Paralyze = 37,
		PoisonField = 38,
		SummonCreature = 39,

		#endregion

		#region Sixth

		Dispel = 40,
		EnergyBolt = 41,
		Explosion = 42,
		Invisibility = 43,
		Mark = 44,
		MassCurse = 45,
		ParalyzeField = 46,
		Reveal = 47,

		#endregion

		#region Seventh

		ChainLightning = 48,
		EnergyField = 49,
		FlameStrike = 50,
		GateTravel = 51,
		ManaVampire = 52,
		MassDispel = 53,
		MeteorSwarm = 54,
		Polymorph = 55,

		#endregion

		#region Eighth

		Earthquake = 56,
		EnergyVortex = 57,
		Resurrection = 58,
		AirElemental = 59,
		SummonDaemon = 60,
		EarthElemental = 61,
		FireElemental = 62,
		WaterElemental = 63,

		#endregion

		#region Necromancy

		AnimateDead = 100,
		BloodOath = 101,
		CorpseSkin = 102,
		CurseWeapon = 103,
		EvilOmen = 104,
		HorrificBeast = 105,
		LichForm = 106,
		MindRot = 107,
		PainSpike = 108,
		PoisonStrike = 109,
		Strangle = 110,
		SummonFamiliar = 111,
		VampiricEmbrace = 112,
		VengefulSpirit = 113,
		Wither = 114,
		WraithForm = 115,
		Exorcism = 116,

		#endregion

		#region Chivalry

		CleanseByFire = 200,
		CloseWounds = 201,
		ConsecrateWeapon = 202,
		DispelEvil = 203,
		DivineFury = 204,
		EnemyOfOne = 205,
		HolyLight = 206,
		NobleSacrifice = 207,
		RemoveCurse = 208,
		SacredJourney = 209,

		#endregion

		#region Bushido

		HonorableExecution = 400,
		Confidence = 401,
		Evasion = 402,
		CounterAttack = 403,
		LightningStrike = 404,
		MomentumStrike = 405,

		#endregion

		#region Ninjitsu

		FocusAttack = 500,
		DeathStrike = 501,
		AnimalForm = 502,
		KiAttack = 503,
		SurpriseAttack = 504,
		Backstab = 505,
		Shadowjump = 506,
		MirrorImage = 507,

		#endregion

		#region Spellweaving

		ArcaneCircle = 600,
		GiftOfRenewal = 601,
		ImmolatingWeapon = 602,
		AttuneWeapon = 603,
		Thunderstorm = 604,
		NatureFury = 605,
		SummonFey = 606,
		SummonFiend = 607,
		ReaperForm = 608,
		Wildfire = 609,
		EssenceOfWind = 610,
		DryadAllure = 611,
		EtherealVoyage = 612,
		WordOfDeath = 613,
		GiftOfLife = 614,
		ArcaneEmpowerment = 615,

		#endregion

		#region Mysticism

		NetherBolt = 677,
		HealingStone = 678,
		PurgeMagic = 679,
		Enchant = 680,
		Sleep = 681,
		EagleStrike = 682,
		AnimatedWeapon = 683,
		StoneForm = 684,
		SpellTrigger = 685,
		MassSleep = 686,
		CleansingWinds = 687,
		Bombard = 688,
		SpellPlague = 689,
		HailStorm = 690,
		NetherCyclone = 691,
		RisingColossus = 692,

		#endregion
	}

	public enum Circle1SpellName
	{
		Clumsy = SpellName.Clumsy,
		CreateFood = SpellName.CreateFood,
		Feeblemind = SpellName.Feeblemind,
		Heal = SpellName.Heal,
		MagicArrow = SpellName.MagicArrow,
		NightSight = SpellName.NightSight,
		ReactiveArmor = SpellName.ReactiveArmor,
		Weaken = SpellName.Weaken,
	}

	public enum Circle2SpellName
	{
		Agility = SpellName.Agility,
		Cunning = SpellName.Cunning,
		Cure = SpellName.Cure,
		Harm = SpellName.Harm,
		MagicTrap = SpellName.MagicTrap,
		RemoveTrap = SpellName.RemoveTrap,
		Protection = SpellName.Protection,
		Strength = SpellName.Strength,
	}

	public enum Circle3SpellName
	{
		Bless = SpellName.Bless,
		Fireball = SpellName.Fireball,
		MagicLock = SpellName.MagicLock,
		Poison = SpellName.Poison,
		Telekinesis = SpellName.Telekinesis,
		Teleport = SpellName.Teleport,
		Unlock = SpellName.Unlock,
		WallOfStone = SpellName.WallOfStone,
	}

	public enum Circle4SpellName
	{
		ArchCure = SpellName.ArchCure,
		ArchProtection = SpellName.ArchProtection,
		Curse = SpellName.Curse,
		FireField = SpellName.FireField,
		GreaterHeal = SpellName.GreaterHeal,
		Lightning = SpellName.Lightning,
		ManaDrain = SpellName.ManaDrain,
		Recall = SpellName.Recall,
	}

	public enum Circle5SpellName
	{
		BladeSpirits = SpellName.BladeSpirits,
		DispelField = SpellName.DispelField,
		Incognito = SpellName.Incognito,
		MagicReflect = SpellName.MagicReflect,
		MindBlast = SpellName.MindBlast,
		Paralyze = SpellName.Paralyze,
		PoisonField = SpellName.PoisonField,
		SummonCreature = SpellName.SummonCreature,
	}

	public enum Circle6SpellName
	{
		Dispel = SpellName.Dispel,
		EnergyBolt = SpellName.EnergyBolt,
		Explosion = SpellName.Explosion,
		Invisibility = SpellName.Invisibility,
		Mark = SpellName.Mark,
		MassCurse = SpellName.MassCurse,
		ParalyzeField = SpellName.ParalyzeField,
		Reveal = SpellName.Reveal,
	}

	public enum Circle7SpellName
	{
		ChainLightning = SpellName.ChainLightning,
		EnergyField = SpellName.EnergyField,
		FlameStrike = SpellName.FlameStrike,
		GateTravel = SpellName.GateTravel,
		ManaVampire = SpellName.ManaVampire,
		MassDispel = SpellName.MassDispel,
		MeteorSwarm = SpellName.MeteorSwarm,
		Polymorph = SpellName.Polymorph,
	}

	public enum Circle8SpellName
	{
		Earthquake = SpellName.Earthquake,
		EnergyVortex = SpellName.EnergyVortex,
		Resurrection = SpellName.Resurrection,
		AirElemental = SpellName.AirElemental,
		SummonDaemon = SpellName.SummonDaemon,
		EarthElemental = SpellName.EarthElemental,
		FireElemental = SpellName.FireElemental,
		WaterElemental = SpellName.WaterElemental,
	}

	public enum NecromancySpellName
	{
		AnimateDead = SpellName.AnimateDead,
		BloodOath = SpellName.BloodOath,
		CorpseSkin = SpellName.CorpseSkin,
		CurseWeapon = SpellName.CurseWeapon,
		EvilOmen = SpellName.EvilOmen,
		HorrificBeast = SpellName.HorrificBeast,
		LichForm = SpellName.LichForm,
		MindRot = SpellName.MindRot,
		PainSpike = SpellName.PainSpike,
		PoisonStrike = SpellName.PoisonStrike,
		Strangle = SpellName.Strangle,
		SummonFamiliar = SpellName.SummonFamiliar,
		VampiricEmbrace = SpellName.VampiricEmbrace,
		VengefulSpirit = SpellName.VengefulSpirit,
		Wither = SpellName.Wither,
		WraithForm = SpellName.WraithForm,
		Exorcism = SpellName.Exorcism,
	}

	public enum ChivalrySpellName
	{
		CleanseByFire = SpellName.CleanseByFire,
		CloseWounds = SpellName.CloseWounds,
		ConsecrateWeapon = SpellName.ConsecrateWeapon,
		DispelEvil = SpellName.DispelEvil,
		DivineFury = SpellName.DivineFury,
		EnemyOfOne = SpellName.EnemyOfOne,
		HolyLight = SpellName.HolyLight,
		NobleSacrifice = SpellName.NobleSacrifice,
		RemoveCurse = SpellName.RemoveCurse,
		SacredJourney = SpellName.SacredJourney,
	}

	public enum BushidoSpellName
	{
		HonorableExecution = SpellName.HonorableExecution,
		Confidence = SpellName.Confidence,
		Evasion = SpellName.Evasion,
		CounterAttack = SpellName.CounterAttack,
		LightningStrike = SpellName.LightningStrike,
		MomentumStrike = SpellName.MomentumStrike,
	}

	public enum NinjitsuSpellName
	{
		FocusAttack = SpellName.FocusAttack,
		DeathStrike = SpellName.DeathStrike,
		AnimalForm = SpellName.AnimalForm,
		KiAttack = SpellName.KiAttack,
		SurpriseAttack = SpellName.SurpriseAttack,
		Backstab = SpellName.Backstab,
		Shadowjump = SpellName.Shadowjump,
		MirrorImage = SpellName.MirrorImage,
	}

	public enum SpellweavingSpellName
	{
		ArcaneCircle = SpellName.ArcaneCircle,
		GiftOfRenewal = SpellName.GiftOfRenewal,
		ImmolatingWeapon = SpellName.ImmolatingWeapon,
		AttuneWeapon = SpellName.AttuneWeapon,
		Thunderstorm = SpellName.Thunderstorm,
		NatureFury = SpellName.NatureFury,
		SummonFey = SpellName.SummonFey,
		SummonFiend = SpellName.SummonFiend,
		ReaperForm = SpellName.ReaperForm,
		Wildfire = SpellName.Wildfire,
		EssenceOfWind = SpellName.EssenceOfWind,
		DryadAllure = SpellName.DryadAllure,
		EtherealVoyage = SpellName.EtherealVoyage,
		WordOfDeath = SpellName.WordOfDeath,
		GiftOfLife = SpellName.GiftOfLife,
		ArcaneEmpowerment = SpellName.ArcaneEmpowerment,
	}

	public enum MysticismSpellName
	{
		NetherBolt = SpellName.NetherBolt,
		HealingStone = SpellName.HealingStone,
		PurgeMagic = SpellName.PurgeMagic,
		Enchant = SpellName.Enchant,
		Sleep = SpellName.Sleep,
		EagleStrike = SpellName.EagleStrike,
		AnimatedWeapon = SpellName.AnimatedWeapon,
		StoneForm = SpellName.StoneForm,
		SpellTrigger = SpellName.SpellTrigger,
		MassSleep = SpellName.MassSleep,
		CleansingWinds = SpellName.CleansingWinds,
		Bombard = SpellName.Bombard,
		SpellPlague = SpellName.SpellPlague,
		HailStorm = SpellName.HailStorm,
		NetherCyclone = SpellName.NetherCyclone,
		RisingColossus = SpellName.RisingColossus,
	}

	public class SpellInfo
	{
		private string m_Name;
		private string m_Mantra;
		private Type[] m_Reagents;
		private int[] m_Amounts;
		private int m_Action;
		private bool m_AllowTown;
		private int m_LeftHandEffect, m_RightHandEffect;

		public SpellInfo(string name, string mantra, params Type[] regs) : this(name, mantra, 16, 0, 0, true, regs)
		{
		}

		public SpellInfo(string name, string mantra, bool allowTown, params Type[] regs) : this(name, mantra, 16, 0, 0, allowTown, regs)
		{
		}

		public SpellInfo(string name, string mantra, int action, params Type[] regs) : this(name, mantra, action, 0, 0, true, regs)
		{
		}

		public SpellInfo(string name, string mantra, int action, bool allowTown, params Type[] regs) : this(name, mantra, action, 0, 0, allowTown, regs)
		{
		}

		public SpellInfo(string name, string mantra, int action, int handEffect, params Type[] regs) : this(name, mantra, action, handEffect, handEffect, true, regs)
		{
		}

		public SpellInfo(string name, string mantra, int action, int handEffect, bool allowTown, params Type[] regs) : this(name, mantra, action, handEffect, handEffect, allowTown, regs)
		{
		}

		public SpellInfo(string name, string mantra, int action, int leftHandEffect, int rightHandEffect, bool allowTown, params Type[] regs)
		{
			m_Name = name;
			m_Mantra = mantra;
			m_Action = action;
			m_Reagents = regs;
			m_AllowTown = allowTown;

			m_LeftHandEffect = leftHandEffect;
			m_RightHandEffect = rightHandEffect;

			m_Amounts = new int[regs.Length];

			for (var i = 0; i < regs.Length; ++i)
			{
				m_Amounts[i] = 1;
			}
		}

		public int Action { get => m_Action; set => m_Action = value; }
		public bool AllowTown { get => m_AllowTown; set => m_AllowTown = value; }
		public int[] Amounts { get => m_Amounts; set => m_Amounts = value; }
		public string Mantra { get => m_Mantra; set => m_Mantra = value; }
		public string Name { get => m_Name; set => m_Name = value; }
		public Type[] Reagents { get => m_Reagents; set => m_Reagents = value; }
		public int LeftHandEffect { get => m_LeftHandEffect; set => m_LeftHandEffect = value; }
		public int RightHandEffect { get => m_RightHandEffect; set => m_RightHandEffect = value; }
	}

	[PropertyObject]
	public class SpellStates<T> : BaseStates<SpellName, T>
	{
		#region Circles

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Circle1SpellStates<T> Circle1 { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Circle2SpellStates<T> Circle2 { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Circle3SpellStates<T> Circle3 { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Circle4SpellStates<T> Circle4 { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Circle5SpellStates<T> Circle5 { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Circle6SpellStates<T> Circle6 { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Circle7SpellStates<T> Circle7 { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public Circle8SpellStates<T> Circle8 { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public NecromancySpellStates<T> Necromancy { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public ChivalrySpellStates<T> Chivalry { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public BushidoSpellStates<T> Bushido { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public NinjitsuSpellStates<T> Ninjitsu { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public SpellweavingSpellStates<T> Spellweaving { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public MysticismSpellStates<T> Mysticism { get; private set; } = new();

		#endregion

		protected IEnumerable<IStates<T>> SubStates
		{
			get
			{
				yield return Circle1;
				yield return Circle2;
				yield return Circle3;
				yield return Circle4;
				yield return Circle5;
				yield return Circle6;
				yield return Circle7;
				yield return Circle8;

				yield return Necromancy;
				yield return Chivalry;
				yield return Bushido;
				yield return Ninjitsu;
				yield return Spellweaving;
				yield return Mysticism;
			}
		}

		public T this[Circle1SpellName spell] { get => Circle1[spell]; set => Circle1[spell] = value; }
		public T this[Circle2SpellName spell] { get => Circle2[spell]; set => Circle2[spell] = value; }
		public T this[Circle3SpellName spell] { get => Circle3[spell]; set => Circle3[spell] = value; }
		public T this[Circle4SpellName spell] { get => Circle4[spell]; set => Circle4[spell] = value; }
		public T this[Circle5SpellName spell] { get => Circle5[spell]; set => Circle5[spell] = value; }
		public T this[Circle6SpellName spell] { get => Circle6[spell]; set => Circle6[spell] = value; }
		public T this[Circle7SpellName spell] { get => Circle7[spell]; set => Circle7[spell] = value; }
		public T this[Circle8SpellName spell] { get => Circle8[spell]; set => Circle8[spell] = value; }

		public T this[NecromancySpellName spell] { get => Necromancy[spell]; set => Necromancy[spell] = value; }
		public T this[ChivalrySpellName spell] { get => Chivalry[spell]; set => Chivalry[spell] = value; }
		public T this[BushidoSpellName spell] { get => Bushido[spell]; set => Bushido[spell] = value; }
		public T this[NinjitsuSpellName spell] { get => Ninjitsu[spell]; set => Ninjitsu[spell] = value; }
		public T this[SpellweavingSpellName spell] { get => Spellweaving[spell]; set => Spellweaving[spell] = value; }
		public T this[MysticismSpellName spell] { get => Mysticism[spell]; set => Mysticism[spell] = value; }

		public T this[int spell] { get => this[(SpellName)spell]; set => this[(SpellName)spell] = value; }

		public override sealed int Length { get; } = EnumValues.Length;

		public SpellStates()
			: base(0)
		{
		}

		public SpellStates(GenericReader reader)
			: base(0, reader)
		{
		}

		public override void Clear()
		{
			base.Clear();

			foreach (var states in SubStates)
			{
				states.Clear();
			}
		}

		protected override T Get(SpellName spell)
		{
			var index = Array.IndexOf(EnumValues, spell);

			if (index < 0)
			{
				return default;
			}

			var skipped = 0;

			foreach (var states in SubStates)
			{
				if (index >= skipped + states.Length)
				{
					skipped += states.Length;
					continue;
				}

				return states.Data[skipped - index];
			}

			return default;
		}

		protected override void Set(SpellName spell, T value)
		{
			var index = Array.IndexOf(EnumValues, spell);

			if (index < 0)
			{
				return;
			}

			var skipped = 0;

			foreach (var states in SubStates)
			{
				if (index >= skipped + states.Length)
				{
					skipped += states.Length;
					continue;
				}

				states.Data[skipped - index] = value;
				return;
			}
		}

		public override IEnumerator<T> GetEnumerator()
		{
			foreach (var states in SubStates)
			{
				foreach (var value in states)
				{
					yield return value;
				}
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			Circle1.Serialize(writer);
			Circle2.Serialize(writer);
			Circle3.Serialize(writer);
			Circle4.Serialize(writer);
			Circle5.Serialize(writer);
			Circle6.Serialize(writer);
			Circle7.Serialize(writer);
			Circle8.Serialize(writer);

			Necromancy.Serialize(writer);
			Chivalry.Serialize(writer);
			Bushido.Serialize(writer);
			Ninjitsu.Serialize(writer);
			Spellweaving.Serialize(writer);
			Mysticism.Serialize(writer);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();

			Circle1.Deserialize(reader);
			Circle2.Deserialize(reader);
			Circle3.Deserialize(reader);
			Circle4.Deserialize(reader);
			Circle5.Deserialize(reader);
			Circle6.Deserialize(reader);
			Circle7.Deserialize(reader);
			Circle8.Deserialize(reader);

			Necromancy.Deserialize(reader);
			Chivalry.Deserialize(reader);
			Bushido.Deserialize(reader);
			Ninjitsu.Deserialize(reader);
			Spellweaving.Deserialize(reader);
			Mysticism.Deserialize(reader);
		}
	}

	[PropertyObject]
	public class Circle1SpellStates<T> : BaseStates<Circle1SpellName, T>
	{
		#region First

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Clumsy { get => this[Circle1SpellName.Clumsy]; set => this[Circle1SpellName.Clumsy] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T CreateFood { get => this[Circle1SpellName.CreateFood]; set => this[Circle1SpellName.CreateFood] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Feeblemind { get => this[Circle1SpellName.Feeblemind]; set => this[Circle1SpellName.Feeblemind] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Heal { get => this[Circle1SpellName.Heal]; set => this[Circle1SpellName.Heal] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MagicArrow { get => this[Circle1SpellName.MagicArrow]; set => this[Circle1SpellName.MagicArrow] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T NightSight { get => this[Circle1SpellName.NightSight]; set => this[Circle1SpellName.NightSight] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ReactiveArmor { get => this[Circle1SpellName.ReactiveArmor]; set => this[Circle1SpellName.ReactiveArmor] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Weaken { get => this[Circle1SpellName.Weaken]; set => this[Circle1SpellName.Weaken] = value; }

		#endregion

		public T this[int spell] { get => this[(Circle1SpellName)spell]; set => this[(Circle1SpellName)spell] = value; }

		public Circle1SpellStates()
		{
		}

		public Circle1SpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class Circle2SpellStates<T> : BaseStates<Circle2SpellName, T>
	{
		#region Second

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Agility { get => this[Circle2SpellName.Agility]; set => this[Circle2SpellName.Agility] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Cunning { get => this[Circle2SpellName.Cunning]; set => this[Circle2SpellName.Cunning] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Cure { get => this[Circle2SpellName.Cure]; set => this[Circle2SpellName.Cure] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Harm { get => this[Circle2SpellName.Harm]; set => this[Circle2SpellName.Harm] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MagicTrap { get => this[Circle2SpellName.MagicTrap]; set => this[Circle2SpellName.MagicTrap] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T RemoveTrap { get => this[Circle2SpellName.RemoveTrap]; set => this[Circle2SpellName.RemoveTrap] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Protection { get => this[Circle2SpellName.Protection]; set => this[Circle2SpellName.Protection] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Strength { get => this[Circle2SpellName.Strength]; set => this[Circle2SpellName.Strength] = value; }


		#endregion

		public T this[int spell] { get => this[(Circle2SpellName)spell]; set => this[(Circle2SpellName)spell] = value; }

		public Circle2SpellStates()
		{
		}

		public Circle2SpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class Circle3SpellStates<T> : BaseStates<Circle3SpellName, T>
	{
		#region Third

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Bless { get => this[Circle3SpellName.Bless]; set => this[Circle3SpellName.Bless] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Fireball { get => this[Circle3SpellName.Fireball]; set => this[Circle3SpellName.Fireball] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MagicLock { get => this[Circle3SpellName.MagicLock]; set => this[Circle3SpellName.MagicLock] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Poison { get => this[Circle3SpellName.Poison]; set => this[Circle3SpellName.Poison] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Telekinesis { get => this[Circle3SpellName.Telekinesis]; set => this[Circle3SpellName.Telekinesis] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Teleport { get => this[Circle3SpellName.Teleport]; set => this[Circle3SpellName.Teleport] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Unlock { get => this[Circle3SpellName.Unlock]; set => this[Circle3SpellName.Unlock] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T WallOfStone { get => this[Circle3SpellName.WallOfStone]; set => this[Circle3SpellName.WallOfStone] = value; }


		#endregion

		public T this[int spell] { get => this[(Circle3SpellName)spell]; set => this[(Circle3SpellName)spell] = value; }

		public Circle3SpellStates()
		{
		}

		public Circle3SpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class Circle4SpellStates<T> : BaseStates<Circle4SpellName, T>
	{
		#region Fourth

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ArchCure { get => this[Circle4SpellName.ArchCure]; set => this[Circle4SpellName.ArchCure] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ArchProtection { get => this[Circle4SpellName.ArchProtection]; set => this[Circle4SpellName.ArchProtection] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Curse { get => this[Circle4SpellName.Curse]; set => this[Circle4SpellName.Curse] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T FireField { get => this[Circle4SpellName.FireField]; set => this[Circle4SpellName.FireField] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T GreaterHeal { get => this[Circle4SpellName.GreaterHeal]; set => this[Circle4SpellName.GreaterHeal] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Lightning { get => this[Circle4SpellName.Lightning]; set => this[Circle4SpellName.Lightning] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ManaDrain { get => this[Circle4SpellName.ManaDrain]; set => this[Circle4SpellName.ManaDrain] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Recall { get => this[Circle4SpellName.Recall]; set => this[Circle4SpellName.Recall] = value; }

		#endregion

		public T this[int spell] { get => this[(Circle4SpellName)spell]; set => this[(Circle4SpellName)spell] = value; }

		public Circle4SpellStates()
		{
		}

		public Circle4SpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class Circle5SpellStates<T> : BaseStates<Circle5SpellName, T>
	{
		#region Fifth

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T BladeSpirits { get => this[Circle5SpellName.BladeSpirits]; set => this[Circle5SpellName.BladeSpirits] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T DispelField { get => this[Circle5SpellName.DispelField]; set => this[Circle5SpellName.DispelField] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Incognito { get => this[Circle5SpellName.Incognito]; set => this[Circle5SpellName.Incognito] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MagicReflect { get => this[Circle5SpellName.MagicReflect]; set => this[Circle5SpellName.MagicReflect] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MindBlast { get => this[Circle5SpellName.MindBlast]; set => this[Circle5SpellName.MindBlast] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Paralyze { get => this[Circle5SpellName.Paralyze]; set => this[Circle5SpellName.Paralyze] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T PoisonField { get => this[Circle5SpellName.PoisonField]; set => this[Circle5SpellName.PoisonField] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T SummonCreature { get => this[Circle5SpellName.SummonCreature]; set => this[Circle5SpellName.SummonCreature] = value; }

		#endregion

		public T this[int spell] { get => this[(Circle5SpellName)spell]; set => this[(Circle5SpellName)spell] = value; }

		public Circle5SpellStates()
		{
		}

		public Circle5SpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class Circle6SpellStates<T> : BaseStates<Circle6SpellName, T>
	{
		#region Sixth

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Dispel { get => this[Circle6SpellName.Dispel]; set => this[Circle6SpellName.Dispel] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T EnergyBolt { get => this[Circle6SpellName.EnergyBolt]; set => this[Circle6SpellName.EnergyBolt] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Explosion { get => this[Circle6SpellName.Explosion]; set => this[Circle6SpellName.Explosion] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Invisibility { get => this[Circle6SpellName.Invisibility]; set => this[Circle6SpellName.Invisibility] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Mark { get => this[Circle6SpellName.Mark]; set => this[Circle6SpellName.Mark] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MassCurse { get => this[Circle6SpellName.MassCurse]; set => this[Circle6SpellName.MassCurse] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ParalyzeField { get => this[Circle6SpellName.ParalyzeField]; set => this[Circle6SpellName.ParalyzeField] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Reveal { get => this[Circle6SpellName.Reveal]; set => this[Circle6SpellName.Reveal] = value; }

		#endregion

		public T this[int spell] { get => this[(Circle6SpellName)spell]; set => this[(Circle6SpellName)spell] = value; }

		public Circle6SpellStates()
		{
		}

		public Circle6SpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class Circle7SpellStates<T> : BaseStates<Circle7SpellName, T>
	{
		#region Seventh

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ChainLightning { get => this[Circle7SpellName.ChainLightning]; set => this[Circle7SpellName.ChainLightning] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T EnergyField { get => this[Circle7SpellName.EnergyField]; set => this[Circle7SpellName.EnergyField] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T FlameStrike { get => this[Circle7SpellName.FlameStrike]; set => this[Circle7SpellName.FlameStrike] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T GateTravel { get => this[Circle7SpellName.GateTravel]; set => this[Circle7SpellName.GateTravel] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ManaVampire { get => this[Circle7SpellName.ManaVampire]; set => this[Circle7SpellName.ManaVampire] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MassDispel { get => this[Circle7SpellName.MassDispel]; set => this[Circle7SpellName.MassDispel] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MeteorSwarm { get => this[Circle7SpellName.MeteorSwarm]; set => this[Circle7SpellName.MeteorSwarm] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Polymorph { get => this[Circle7SpellName.Polymorph]; set => this[Circle7SpellName.Polymorph] = value; }

		#endregion

		public T this[int spell] { get => this[(Circle7SpellName)spell]; set => this[(Circle7SpellName)spell] = value; }

		public Circle7SpellStates()
		{
		}

		public Circle7SpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class Circle8SpellStates<T> : BaseStates<Circle8SpellName, T>
	{
		#region Eighth

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Earthquake { get => this[Circle8SpellName.Earthquake]; set => this[Circle8SpellName.Earthquake] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T EnergyVortex { get => this[Circle8SpellName.EnergyVortex]; set => this[Circle8SpellName.EnergyVortex] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Resurrection { get => this[Circle8SpellName.Resurrection]; set => this[Circle8SpellName.Resurrection] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T AirElemental { get => this[Circle8SpellName.AirElemental]; set => this[Circle8SpellName.AirElemental] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T SummonDaemon { get => this[Circle8SpellName.SummonDaemon]; set => this[Circle8SpellName.SummonDaemon] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T EarthElemental { get => this[Circle8SpellName.EarthElemental]; set => this[Circle8SpellName.EarthElemental] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T FireElemental { get => this[Circle8SpellName.FireElemental]; set => this[Circle8SpellName.FireElemental] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T WaterElemental { get => this[Circle8SpellName.WaterElemental]; set => this[Circle8SpellName.WaterElemental] = value; }

		#endregion

		public T this[int spell] { get => this[(Circle8SpellName)spell]; set => this[(Circle8SpellName)spell] = value; }

		public Circle8SpellStates()
		{
		}

		public Circle8SpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class NecromancySpellStates<T> : BaseStates<NecromancySpellName, T>
	{
		#region Necromancy

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T AnimateDead { get => this[NecromancySpellName.AnimateDead]; set => this[NecromancySpellName.AnimateDead] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T BloodOath { get => this[NecromancySpellName.BloodOath]; set => this[NecromancySpellName.BloodOath] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T CorpseSkin { get => this[NecromancySpellName.CorpseSkin]; set => this[NecromancySpellName.CorpseSkin] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T CurseWeapon { get => this[NecromancySpellName.CurseWeapon]; set => this[NecromancySpellName.CurseWeapon] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T EvilOmen { get => this[NecromancySpellName.EvilOmen]; set => this[NecromancySpellName.EvilOmen] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T HorrificBeast { get => this[NecromancySpellName.HorrificBeast]; set => this[NecromancySpellName.HorrificBeast] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T LichForm { get => this[NecromancySpellName.LichForm]; set => this[NecromancySpellName.LichForm] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MindRot { get => this[NecromancySpellName.MindRot]; set => this[NecromancySpellName.MindRot] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T PainSpike { get => this[NecromancySpellName.PainSpike]; set => this[NecromancySpellName.PainSpike] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T PoisonStrike { get => this[NecromancySpellName.PoisonStrike]; set => this[NecromancySpellName.PoisonStrike] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Strangle { get => this[NecromancySpellName.Strangle]; set => this[NecromancySpellName.Strangle] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T SummonFamiliar { get => this[NecromancySpellName.SummonFamiliar]; set => this[NecromancySpellName.SummonFamiliar] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T VampiricEmbrace { get => this[NecromancySpellName.VampiricEmbrace]; set => this[NecromancySpellName.VampiricEmbrace] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T VengefulSpirit { get => this[NecromancySpellName.VengefulSpirit]; set => this[NecromancySpellName.VengefulSpirit] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Wither { get => this[NecromancySpellName.Wither]; set => this[NecromancySpellName.Wither] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T WraithForm { get => this[NecromancySpellName.WraithForm]; set => this[NecromancySpellName.WraithForm] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Exorcism { get => this[NecromancySpellName.Exorcism]; set => this[NecromancySpellName.Exorcism] = value; }

		#endregion

		public T this[int spell] { get => this[(NecromancySpellName)spell]; set => this[(NecromancySpellName)spell] = value; }

		public NecromancySpellStates()
		{
		}

		public NecromancySpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class ChivalrySpellStates<T> : BaseStates<ChivalrySpellName, T>
	{
		#region Chivalry

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T CleanseByFire { get => this[ChivalrySpellName.CleanseByFire]; set => this[ChivalrySpellName.CleanseByFire] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T CloseWounds { get => this[ChivalrySpellName.CloseWounds]; set => this[ChivalrySpellName.CloseWounds] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ConsecrateWeapon { get => this[ChivalrySpellName.ConsecrateWeapon]; set => this[ChivalrySpellName.ConsecrateWeapon] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T DispelEvil { get => this[ChivalrySpellName.DispelEvil]; set => this[ChivalrySpellName.DispelEvil] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T DivineFury { get => this[ChivalrySpellName.DivineFury]; set => this[ChivalrySpellName.DivineFury] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T EnemyOfOne { get => this[ChivalrySpellName.EnemyOfOne]; set => this[ChivalrySpellName.EnemyOfOne] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T HolyLight { get => this[ChivalrySpellName.HolyLight]; set => this[ChivalrySpellName.HolyLight] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T NobleSacrifice { get => this[ChivalrySpellName.NobleSacrifice]; set => this[ChivalrySpellName.NobleSacrifice] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T RemoveCurse { get => this[ChivalrySpellName.RemoveCurse]; set => this[ChivalrySpellName.RemoveCurse] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T SacredJourney { get => this[ChivalrySpellName.SacredJourney]; set => this[ChivalrySpellName.SacredJourney] = value; }

		#endregion

		public T this[int spell] { get => this[(ChivalrySpellName)spell]; set => this[(ChivalrySpellName)spell] = value; }

		public ChivalrySpellStates()
		{
		}

		public ChivalrySpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class BushidoSpellStates<T> : BaseStates<BushidoSpellName, T>
	{
		#region Bushido

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T HonorableExecution { get => this[BushidoSpellName.HonorableExecution]; set => this[BushidoSpellName.HonorableExecution] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Confidence { get => this[BushidoSpellName.Confidence]; set => this[BushidoSpellName.Confidence] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Evasion { get => this[BushidoSpellName.Evasion]; set => this[BushidoSpellName.Evasion] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T CounterAttack { get => this[BushidoSpellName.CounterAttack]; set => this[BushidoSpellName.CounterAttack] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T LightningStrike { get => this[BushidoSpellName.LightningStrike]; set => this[BushidoSpellName.LightningStrike] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MomentumStrike { get => this[BushidoSpellName.MomentumStrike]; set => this[BushidoSpellName.MomentumStrike] = value; }

		#endregion

		public T this[int spell] { get => this[(BushidoSpellName)spell]; set => this[(BushidoSpellName)spell] = value; }

		public BushidoSpellStates()
		{
		}

		public BushidoSpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class NinjitsuSpellStates<T> : BaseStates<NinjitsuSpellName, T>
	{
		#region Ninjitsu

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T FocusAttack { get => this[NinjitsuSpellName.FocusAttack]; set => this[NinjitsuSpellName.FocusAttack] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T DeathStrike { get => this[NinjitsuSpellName.DeathStrike]; set => this[NinjitsuSpellName.DeathStrike] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T AnimalForm { get => this[NinjitsuSpellName.AnimalForm]; set => this[NinjitsuSpellName.AnimalForm] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T KiAttack { get => this[NinjitsuSpellName.KiAttack]; set => this[NinjitsuSpellName.KiAttack] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T SurpriseAttack { get => this[NinjitsuSpellName.SurpriseAttack]; set => this[NinjitsuSpellName.SurpriseAttack] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Backstab { get => this[NinjitsuSpellName.Backstab]; set => this[NinjitsuSpellName.Backstab] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Shadowjump { get => this[NinjitsuSpellName.Shadowjump]; set => this[NinjitsuSpellName.Shadowjump] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MirrorImage { get => this[NinjitsuSpellName.MirrorImage]; set => this[NinjitsuSpellName.MirrorImage] = value; }

		#endregion

		public T this[int spell] { get => this[(NinjitsuSpellName)spell]; set => this[(NinjitsuSpellName)spell] = value; }

		public NinjitsuSpellStates()
		{
		}

		public NinjitsuSpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class SpellweavingSpellStates<T> : BaseStates<SpellweavingSpellName, T>
	{
		#region Spellweaving

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ArcaneCircle { get => this[SpellweavingSpellName.ArcaneCircle]; set => this[SpellweavingSpellName.ArcaneCircle] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T GiftOfRenewal { get => this[SpellweavingSpellName.GiftOfRenewal]; set => this[SpellweavingSpellName.GiftOfRenewal] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ImmolatingWeapon { get => this[SpellweavingSpellName.ImmolatingWeapon]; set => this[SpellweavingSpellName.ImmolatingWeapon] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T AttuneWeapon { get => this[SpellweavingSpellName.AttuneWeapon]; set => this[SpellweavingSpellName.AttuneWeapon] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Thunderstorm { get => this[SpellweavingSpellName.Thunderstorm]; set => this[SpellweavingSpellName.Thunderstorm] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T NatureFury { get => this[SpellweavingSpellName.NatureFury]; set => this[SpellweavingSpellName.NatureFury] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T SummonFey { get => this[SpellweavingSpellName.SummonFey]; set => this[SpellweavingSpellName.SummonFey] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T SummonFiend { get => this[SpellweavingSpellName.SummonFiend]; set => this[SpellweavingSpellName.SummonFiend] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ReaperForm { get => this[SpellweavingSpellName.ReaperForm]; set => this[SpellweavingSpellName.ReaperForm] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Wildfire { get => this[SpellweavingSpellName.Wildfire]; set => this[SpellweavingSpellName.Wildfire] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T EssenceOfWind { get => this[SpellweavingSpellName.EssenceOfWind]; set => this[SpellweavingSpellName.EssenceOfWind] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T DryadAllure { get => this[SpellweavingSpellName.DryadAllure]; set => this[SpellweavingSpellName.DryadAllure] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T EtherealVoyage { get => this[SpellweavingSpellName.EtherealVoyage]; set => this[SpellweavingSpellName.EtherealVoyage] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T WordOfDeath { get => this[SpellweavingSpellName.WordOfDeath]; set => this[SpellweavingSpellName.WordOfDeath] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T GiftOfLife { get => this[SpellweavingSpellName.GiftOfLife]; set => this[SpellweavingSpellName.GiftOfLife] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T ArcaneEmpowerment { get => this[SpellweavingSpellName.ArcaneEmpowerment]; set => this[SpellweavingSpellName.ArcaneEmpowerment] = value; }

		#endregion

		public T this[int spell] { get => this[(SpellweavingSpellName)spell]; set => this[(SpellweavingSpellName)spell] = value; }

		public SpellweavingSpellStates()
		{
		}

		public SpellweavingSpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	[PropertyObject]
	public class MysticismSpellStates<T> : BaseStates<MysticismSpellName, T>
	{
		#region Mysticism

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T NetherBolt { get => this[MysticismSpellName.NetherBolt]; set => this[MysticismSpellName.NetherBolt] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T HealingStone { get => this[MysticismSpellName.HealingStone]; set => this[MysticismSpellName.HealingStone] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T PurgeMagic { get => this[MysticismSpellName.PurgeMagic]; set => this[MysticismSpellName.PurgeMagic] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Enchant { get => this[MysticismSpellName.Enchant]; set => this[MysticismSpellName.Enchant] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Sleep { get => this[MysticismSpellName.Sleep]; set => this[MysticismSpellName.Sleep] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T EagleStrike { get => this[MysticismSpellName.EagleStrike]; set => this[MysticismSpellName.EagleStrike] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T AnimatedWeapon { get => this[MysticismSpellName.AnimatedWeapon]; set => this[MysticismSpellName.AnimatedWeapon] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T StoneForm { get => this[MysticismSpellName.StoneForm]; set => this[MysticismSpellName.StoneForm] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T SpellTrigger { get => this[MysticismSpellName.SpellTrigger]; set => this[MysticismSpellName.SpellTrigger] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T MassSleep { get => this[MysticismSpellName.MassSleep]; set => this[MysticismSpellName.MassSleep] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T CleansingWinds { get => this[MysticismSpellName.CleansingWinds]; set => this[MysticismSpellName.CleansingWinds] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T Bombard { get => this[MysticismSpellName.Bombard]; set => this[MysticismSpellName.Bombard] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T SpellPlague { get => this[MysticismSpellName.SpellPlague]; set => this[MysticismSpellName.SpellPlague] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T HailStorm { get => this[MysticismSpellName.HailStorm]; set => this[MysticismSpellName.HailStorm] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T NetherCyclone { get => this[MysticismSpellName.NetherCyclone]; set => this[MysticismSpellName.NetherCyclone] = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public T RisingColossus { get => this[MysticismSpellName.RisingColossus]; set => this[MysticismSpellName.RisingColossus] = value; }

		#endregion

		public T this[int spell] { get => this[(MysticismSpellName)spell]; set => this[(MysticismSpellName)spell] = value; }

		public MysticismSpellStates()
		{
		}

		public MysticismSpellStates(GenericReader reader)
			: base(reader)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}

	public class SpellPermissions : SpellStates<bool>
	{
		public SpellPermissions()
		{
		}

		public SpellPermissions(GenericReader reader)
			: base(reader)
		{
		}

		public virtual void SetAll(bool value)
		{
			Array.Fill(m_Data, value);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}
}