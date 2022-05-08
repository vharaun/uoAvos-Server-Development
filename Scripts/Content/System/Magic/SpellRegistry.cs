
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Spells
{
	public class SpellRegistry
	{
		private static readonly Type[] m_Types = new Type[700];
		private static int m_Count;

		public static Type[] Types
		{
			get
			{
				m_Count = -1;
				return m_Types;
			}
		}

		//What IS this used for anyways.
		public static int Count
		{
			get
			{
				if (m_Count == -1)
				{
					m_Count = 0;

					for (var i = 0; i < m_Types.Length; ++i)
					{
						if (m_Types[i] != null)
						{
							++m_Count;
						}
					}
				}

				return m_Count;
			}
		}

		private static readonly Dictionary<Type, int> m_IDsFromTypes = new Dictionary<Type, int>(m_Types.Length);

		private static readonly Dictionary<int, SpecialMove> m_SpecialMoves = new Dictionary<int, SpecialMove>();
		public static Dictionary<int, SpecialMove> SpecialMoves => m_SpecialMoves;

		public static int GetRegistryNumber(ISpell s)
		{
			return GetRegistryNumber(s.GetType());
		}

		public static int GetRegistryNumber(SpecialMove s)
		{
			return GetRegistryNumber(s.GetType());
		}

		public static int GetRegistryNumber(Type type)
		{
			if (m_IDsFromTypes.ContainsKey(type))
			{
				return m_IDsFromTypes[type];
			}

			return -1;
		}

		public static void Register(int spellID, Type type)
		{
			if (spellID < 0 || spellID >= m_Types.Length)
			{
				return;
			}

			if (m_Types[spellID] == null)
			{
				++m_Count;
			}

			m_Types[spellID] = type;

			if (!m_IDsFromTypes.ContainsKey(type))
			{
				m_IDsFromTypes.Add(type, spellID);
			}

			if (type.IsSubclassOf(typeof(SpecialMove)))
			{
				SpecialMove spm = null;

				try
				{
					spm = Activator.CreateInstance(type) as SpecialMove;
				}
				catch
				{
				}

				if (spm != null)
				{
					m_SpecialMoves.Add(spellID, spm);
				}
			}
		}

		public static SpecialMove GetSpecialMove(int spellID)
		{
			if (spellID < 0 || spellID >= m_Types.Length)
			{
				return null;
			}

			var t = m_Types[spellID];

			if (t == null || !t.IsSubclassOf(typeof(SpecialMove)) || !m_SpecialMoves.ContainsKey(spellID))
			{
				return null;
			}

			return m_SpecialMoves[spellID];
		}

		private static readonly object[] m_Params = new object[2];

		public static Spell NewSpell(int spellID, Mobile caster, Item scroll)
		{
			if (spellID < 0 || spellID >= m_Types.Length)
			{
				return null;
			}

			var t = m_Types[spellID];

			if (t != null && !t.IsSubclassOf(typeof(SpecialMove)))
			{
				m_Params[0] = caster;
				m_Params[1] = scroll;

				try
				{
					return (Spell)Activator.CreateInstance(t, m_Params);
				}
				catch
				{
				}
			}

			return null;
		}

		private static readonly string[] m_CircleNames = new string[]
			{
				"First",
				"Second",
				"Third",
				"Fourth",
				"Fifth",
				"Sixth",
				"Seventh",
				"Eighth",
				"Necromancy",
				"Chivalry",
				"Bushido",
				"Ninjitsu",
				"Spellweaving"
			};

		public static Spell NewSpell(string name, Mobile caster, Item scroll)
		{
			for (var i = 0; i < m_CircleNames.Length; ++i)
			{
				var t = ScriptCompiler.FindTypeByFullName(String.Format("Server.Spells.{0}.{1}", m_CircleNames[i], name));

				if (t != null && !t.IsSubclassOf(typeof(SpecialMove)))
				{
					m_Params[0] = caster;
					m_Params[1] = scroll;

					try
					{
						return (Spell)Activator.CreateInstance(t, m_Params);
					}
					catch
					{
					}
				}
			}

			return null;
		}
	}

	public class Initializer
	{
		public static void Initialize()
		{
			// First circle
			Register(00, typeof(First.ClumsySpell));
			Register(01, typeof(First.CreateFoodSpell));
			Register(02, typeof(First.FeeblemindSpell));
			Register(03, typeof(First.HealSpell));
			Register(04, typeof(First.MagicArrowSpell));
			Register(05, typeof(First.NightSightSpell));
			Register(06, typeof(First.ReactiveArmorSpell));
			Register(07, typeof(First.WeakenSpell));

			// Second circle
			Register(08, typeof(Second.AgilitySpell));
			Register(09, typeof(Second.CunningSpell));
			Register(10, typeof(Second.CureSpell));
			Register(11, typeof(Second.HarmSpell));
			Register(12, typeof(Second.MagicTrapSpell));
			Register(13, typeof(Second.RemoveTrapSpell));
			Register(14, typeof(Second.ProtectionSpell));
			Register(15, typeof(Second.StrengthSpell));

			// Third circle
			Register(16, typeof(Third.BlessSpell));
			Register(17, typeof(Third.FireballSpell));
			Register(18, typeof(Third.MagicLockSpell));
			Register(19, typeof(Third.PoisonSpell));
			Register(20, typeof(Third.TelekinesisSpell));
			Register(21, typeof(Third.TeleportSpell));
			Register(22, typeof(Third.UnlockSpell));
			Register(23, typeof(Third.WallOfStoneSpell));

			// Fourth circle
			Register(24, typeof(Fourth.ArchCureSpell));
			Register(25, typeof(Fourth.ArchProtectionSpell));
			Register(26, typeof(Fourth.CurseSpell));
			Register(27, typeof(Fourth.FireFieldSpell));
			Register(28, typeof(Fourth.GreaterHealSpell));
			Register(29, typeof(Fourth.LightningSpell));
			Register(30, typeof(Fourth.ManaDrainSpell));
			Register(31, typeof(Fourth.RecallSpell));

			// Fifth circle
			Register(32, typeof(Fifth.BladeSpiritsSpell));
			Register(33, typeof(Fifth.DispelFieldSpell));
			Register(34, typeof(Fifth.IncognitoSpell));
			Register(35, typeof(Fifth.MagicReflectSpell));
			Register(36, typeof(Fifth.MindBlastSpell));
			Register(37, typeof(Fifth.ParalyzeSpell));
			Register(38, typeof(Fifth.PoisonFieldSpell));
			Register(39, typeof(Fifth.SummonCreatureSpell));

			// Sixth circle
			Register(40, typeof(Sixth.DispelSpell));
			Register(41, typeof(Sixth.EnergyBoltSpell));
			Register(42, typeof(Sixth.ExplosionSpell));
			Register(43, typeof(Sixth.InvisibilitySpell));
			Register(44, typeof(Sixth.MarkSpell));
			Register(45, typeof(Sixth.MassCurseSpell));
			Register(46, typeof(Sixth.ParalyzeFieldSpell));
			Register(47, typeof(Sixth.RevealSpell));

			// Seventh circle
			Register(48, typeof(Seventh.ChainLightningSpell));
			Register(49, typeof(Seventh.EnergyFieldSpell));
			Register(50, typeof(Seventh.FlameStrikeSpell));
			Register(51, typeof(Seventh.GateTravelSpell));
			Register(52, typeof(Seventh.ManaVampireSpell));
			Register(53, typeof(Seventh.MassDispelSpell));
			Register(54, typeof(Seventh.MeteorSwarmSpell));
			Register(55, typeof(Seventh.PolymorphSpell));

			// Eighth circle
			Register(56, typeof(Eighth.EarthquakeSpell));
			Register(57, typeof(Eighth.EnergyVortexSpell));
			Register(58, typeof(Eighth.ResurrectionSpell));
			Register(59, typeof(Eighth.AirElementalSpell));
			Register(60, typeof(Eighth.SummonDaemonSpell));
			Register(61, typeof(Eighth.EarthElementalSpell));
			Register(62, typeof(Eighth.FireElementalSpell));
			Register(63, typeof(Eighth.WaterElementalSpell));

			if (Core.AOS)
			{
				// Necromancy spells
				Register(100, typeof(Necromancy.AnimateDeadSpell));
				Register(101, typeof(Necromancy.BloodOathSpell));
				Register(102, typeof(Necromancy.CorpseSkinSpell));
				Register(103, typeof(Necromancy.CurseWeaponSpell));
				Register(104, typeof(Necromancy.EvilOmenSpell));
				Register(105, typeof(Necromancy.HorrificBeastSpell));
				Register(106, typeof(Necromancy.LichFormSpell));
				Register(107, typeof(Necromancy.MindRotSpell));
				Register(108, typeof(Necromancy.PainSpikeSpell));
				Register(109, typeof(Necromancy.PoisonStrikeSpell));
				Register(110, typeof(Necromancy.StrangleSpell));
				Register(111, typeof(Necromancy.SummonFamiliarSpell));
				Register(112, typeof(Necromancy.VampiricEmbraceSpell));
				Register(113, typeof(Necromancy.VengefulSpiritSpell));
				Register(114, typeof(Necromancy.WitherSpell));
				Register(115, typeof(Necromancy.WraithFormSpell));

				if (Core.SE)
				{
					Register(116, typeof(Necromancy.ExorcismSpell));
				}

				// Paladin abilities
				Register(200, typeof(Chivalry.CleanseByFireSpell));
				Register(201, typeof(Chivalry.CloseWoundsSpell));
				Register(202, typeof(Chivalry.ConsecrateWeaponSpell));
				Register(203, typeof(Chivalry.DispelEvilSpell));
				Register(204, typeof(Chivalry.DivineFurySpell));
				Register(205, typeof(Chivalry.EnemyOfOneSpell));
				Register(206, typeof(Chivalry.HolyLightSpell));
				Register(207, typeof(Chivalry.NobleSacrificeSpell));
				Register(208, typeof(Chivalry.RemoveCurseSpell));
				Register(209, typeof(Chivalry.SacredJourneySpell));

				if (Core.SE)
				{
					// Samurai abilities
					Register(400, typeof(Bushido.HonorableExecution));
					Register(401, typeof(Bushido.Confidence));
					Register(402, typeof(Bushido.Evasion));
					Register(403, typeof(Bushido.CounterAttack));
					Register(404, typeof(Bushido.LightningStrike));
					Register(405, typeof(Bushido.MomentumStrike));

					// Ninja abilities
					Register(500, typeof(Ninjitsu.FocusAttack));
					Register(501, typeof(Ninjitsu.DeathStrike));
					Register(502, typeof(Ninjitsu.AnimalForm));
					Register(503, typeof(Ninjitsu.KiAttack));
					Register(504, typeof(Ninjitsu.SurpriseAttack));
					Register(505, typeof(Ninjitsu.Backstab));
					Register(506, typeof(Ninjitsu.Shadowjump));
					Register(507, typeof(Ninjitsu.MirrorImage));
				}

				if (Core.ML)
				{
					Register(600, typeof(Spellweaving.ArcaneCircleSpell));
					Register(601, typeof(Spellweaving.GiftOfRenewalSpell));
					Register(602, typeof(Spellweaving.ImmolatingWeaponSpell));
					Register(603, typeof(Spellweaving.AttuneWeaponSpell));
					Register(604, typeof(Spellweaving.ThunderstormSpell));
					Register(605, typeof(Spellweaving.NatureFurySpell));
					Register(606, typeof(Spellweaving.SummonFeySpell));
					Register(607, typeof(Spellweaving.SummonFiendSpell));
					Register(608, typeof(Spellweaving.ReaperFormSpell));
					//Register( 609, typeof( Spellweaving.WildfireSpell ) );
					Register(610, typeof(Spellweaving.EssenceOfWindSpell));
					//Register( 611, typeof( Spellweaving.DryadAllureSpell ) );
					Register(612, typeof(Spellweaving.EtherealVoyageSpell));
					Register(613, typeof(Spellweaving.WordOfDeathSpell));
					Register(614, typeof(Spellweaving.GiftOfLifeSpell));
					//Register( 615, typeof( Spellweaving.ArcaneEmpowermentSpell ) );
				}

				if (Core.SA)
				{
					// Mysticism spells
					//Register( 677, typeof( Mysticism.NetherBoltSpell ) );
					//Register( 678, typeof( Mysticism.HealingStoneSpell ) );
					//Register( 679, typeof( Mysticism.PurgeMagicSpell ) );
					//Register( 680, typeof( Mysticism.EnchantSpell ) );
					//Register( 681, typeof( Mysticism.SleepSpell ) );
					Register(682, typeof(Mysticism.EagleStrikeSpell));
					Register(683, typeof(Mysticism.AnimatedWeaponSpell));
					Register(684, typeof(Mysticism.StoneFormSpell));
					//Register( 685, typeof( Mysticism.SpellTriggerSpell ) );
					//Register( 686, typeof( Mysticism.MassSleepSpell ) );
					//Register( 687, typeof( Mysticism.CleansingWindsSpell ) );
					//Register( 688, typeof( Mysticism.BombardSpell ) );
					Register(689, typeof(Mysticism.SpellPlagueSpell));
					Register(690, typeof(Mysticism.HailStormSpell));
					Register(691, typeof(Mysticism.NetherCycloneSpell));
					//Register( 692, typeof( Mysticism.RisingColossusSpell ) );
				}
			}
		}

		public static void Register(int spellId, Type type)
		{
			SpellRegistry.Register(spellId, type);
		}
	}
}