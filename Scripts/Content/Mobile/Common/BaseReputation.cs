using Server.Engines.ConPVP;
using Server.Engines.PartySystem;
using Server.Ethics;
using Server.Factions;
using Server.Guilds;
using Server.Items;
using Server.Mobiles;
using Server.Multis;
using Server.SkillHandlers;
using Server.Spells.Seventh;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Server.Misc
{
	public class NotorietyHandlers
	{
		public static void Initialize()
		{
			Notoriety.Hues[Notoriety.Innocent] = 0x59;
			Notoriety.Hues[Notoriety.Ally] = 0x3F;
			Notoriety.Hues[Notoriety.CanBeAttacked] = 0x3B2;
			Notoriety.Hues[Notoriety.Criminal] = 0x3B2;
			Notoriety.Hues[Notoriety.Enemy] = 0x90;
			Notoriety.Hues[Notoriety.Murderer] = 0x22;
			Notoriety.Hues[Notoriety.Invulnerable] = 0x35;

			Notoriety.Handler = new NotorietyHandler(MobileNotoriety);

			Mobile.AllowBeneficialHandler = new AllowBeneficialHandler(Mobile_AllowBeneficial);
			Mobile.AllowHarmfulHandler = new AllowHarmfulHandler(Mobile_AllowHarmful);
		}

		public static bool IsPeaceful(Guild guild)
		{
			if (guild == null)
			{
				return true;
			}

			if (guild.Enemies.Count == 0 && guild.Type == GuildType.Regular)
			{
				return true;
			}

			return false;
		}

		public static Guild GetGuildFor(Guild def, Mobile m)
		{
			if (m.Guild is Guild guild)
			{
				return guild;
			}

			if (m is BaseCreature c && c.Controlled && c.ControlMaster != null)
			{
				if (c.Map != Map.Internal && (Core.AOS || Guild.NewGuildSystem || c.ControlOrder == OrderType.Attack || c.ControlOrder == OrderType.Guard))
				{
					if (c.ControlMaster.Guild is Guild masterGuild)
					{
						return masterGuild;
					}
				}

				if (c.Map == Map.Internal || c.ControlMaster.Guild == null)
				{
					return null;
				}
			}

			return def;
		}

		public static bool Mobile_AllowBeneficial(Mobile from, Mobile target)
		{
			if (from == null || target == null)
			{
				return true;
			}

			if (from.AccessLevel > AccessLevel.Player || target.AccessLevel > AccessLevel.Player)
			{
				return true;
			}

			var map = from.Map;

			var srcPlayer = from as PlayerMobile;
			var trgPlayer = target as PlayerMobile;

			var srcCreature = from as BaseCreature;
			var trgCreature = target as BaseCreature;

			#region Dueling

			var pmFrom = srcPlayer ?? srcCreature?.GetRootMaster<PlayerMobile>();
			var pmTarg = trgPlayer ?? trgCreature?.GetRootMaster<PlayerMobile>();

			if (pmFrom != null && pmTarg != null)
			{
				if (pmFrom.DuelContext != pmTarg.DuelContext)
				{
					if (pmFrom.DuelContext != null && pmFrom.DuelContext.Started)
					{
						return false;
					}

					if (pmTarg.DuelContext != null && pmTarg.DuelContext.Started)
					{
						return false;
					}
				}

				if (pmFrom.DuelContext != null)
				{
					if (pmFrom.DuelContext == pmTarg.DuelContext)
					{
						if (pmFrom.DuelContext.StartedReadyCountdown && !pmFrom.DuelContext.Started)
						{
							return false;
						}

						if (pmFrom.DuelContext.Tied || pmFrom.DuelPlayer.Eliminated || pmTarg.DuelPlayer.Eliminated)
						{
							return false;
						}
					}

					if (pmFrom.DuelPlayer != null && !pmFrom.DuelPlayer.Eliminated && pmFrom.DuelContext.IsSuddenDeath)
					{
						return false;
					}

					if (pmFrom.DuelContext == pmTarg.DuelContext)
					{
						if (pmFrom.DuelContext.m_Tournament != null && pmFrom.DuelContext.m_Tournament.IsNotoRestricted && pmFrom.DuelPlayer != null && pmTarg.DuelPlayer != null && pmFrom.DuelPlayer.Participant != pmTarg.DuelPlayer.Participant)
						{
							return false;
						}

						if (pmFrom.DuelContext.Started)
						{
							return true;
						}
					}
				}
			}

			if (pmFrom != null && pmFrom.DuelContext != null && pmFrom.DuelContext.Started)
			{
				return false;
			}

			if (pmTarg != null && pmTarg.DuelContext != null && pmTarg.DuelContext.Started)
			{
				return false;
			}

			if (from.Region.IsPartOf<SafeZone>() || target.Region.IsPartOf<SafeZone>())
			{
				return false;
			}

			#endregion

			#region Factions

			var targetFaction = Faction.Find(target, true);

			if (targetFaction != null)
			{
				if (!Core.ML || map == Faction.Facet)
				{
					if (Faction.Find(from, true) != targetFaction)
					{
						return false;
					}
				}
			}

			#endregion

			if (map != null && !map.Rules.HasFlag(MapRules.BeneficialRestrictions))
			{
				return true; // In felucca, anything goes
			}

			if (srcPlayer == null)
			{
				return true; // NPCs have no restrictions
			}

			if (Reputation.IsAlly(from, target))
			{
				return true;
			}

			if (trgCreature != null && !trgCreature.Controlled)
			{
				return false; // Players cannot heal uncontrolled mobiles
			}

			if (srcPlayer.Young && (trgPlayer == null || !trgPlayer.Young))
			{
				return false; // Young players cannot perform beneficial actions towards older players
			}

			var fromGuild = GetGuildFor(from.Guild as Guild, from);
			var targetGuild = GetGuildFor(target.Guild as Guild, target);

			if (fromGuild != null && targetGuild != null)
			{
				if (targetGuild == fromGuild || fromGuild.IsAlly(targetGuild))
				{
					return true; // Guild members can be beneficial
				}

				return IsPeaceful(fromGuild) && IsPeaceful(targetGuild);
			}

			return true;
		}

		public static bool Mobile_AllowHarmful(Mobile from, Mobile target)
		{
			if (from == null || target == null)
			{
				return true;
			}

			if (from.AccessLevel > AccessLevel.Player || target.AccessLevel > AccessLevel.Player)
			{
				return true;
			}

			var map = from.Map;

			var srcPlayer = from as PlayerMobile;
			var trgPlayer = target as PlayerMobile;

			var srcCreature = from as BaseCreature;
			var trgCreature = target as BaseCreature;

			#region Dueling

			var pmFrom = srcPlayer ?? srcCreature?.GetRootMaster<PlayerMobile>();
			var pmTarg = trgPlayer ?? trgCreature?.GetRootMaster<PlayerMobile>();

			if (pmFrom != null && pmTarg != null)
			{
				if (pmFrom.DuelContext != pmTarg.DuelContext)
				{
					if (pmFrom.DuelContext != null && pmFrom.DuelContext.Started)
					{
						return false;
					}

					if (pmTarg.DuelContext != null && pmTarg.DuelContext.Started)
					{
						return false;
					}
				}

				if (pmFrom.DuelContext != null && pmFrom.DuelContext == pmTarg.DuelContext)
				{
					if (pmFrom.DuelContext.StartedReadyCountdown && !pmFrom.DuelContext.Started)
					{
						return false;
					}

					if (pmFrom.DuelContext.Tied || pmFrom.DuelPlayer.Eliminated || pmTarg.DuelPlayer.Eliminated)
					{
						return false;
					}

					if (pmFrom.DuelContext.m_Tournament != null && pmFrom.DuelContext.m_Tournament.IsNotoRestricted && pmFrom.DuelPlayer != null && pmTarg.DuelPlayer != null && pmFrom.DuelPlayer.Participant == pmTarg.DuelPlayer.Participant)
					{
						return false;
					}

					if (pmFrom.DuelContext.Started)
					{
						return true;
					}
				}
			}

			if (pmFrom != null && pmFrom.DuelContext != null && pmFrom.DuelContext.Started)
			{
				return false;
			}

			if (pmTarg != null && pmTarg.DuelContext != null && pmTarg.DuelContext.Started)
			{
				return false;
			}

			if (from.Region.IsPartOf<SafeZone>() || target.Region.IsPartOf<SafeZone>())
			{
				return false;
			}

			#endregion

			if (map != null && !map.Rules.HasFlag(MapRules.HarmfulRestrictions))
			{
				return true; // In felucca, anything goes
			}

			if (srcPlayer == null)
			{
				var master = srcCreature?.GetMaster();

				if (master == null || master.AccessLevel > AccessLevel.Player)
				{
					if (trgPlayer == null || !trgPlayer.CheckYoungProtection(from))
					{
						return true; // Uncontrolled NPCs are only restricted by the young system
					}

					if (CheckAggressor(from.Aggressors, target) || CheckAggressed(from.Aggressed, target))
					{
						return true;
					}

					return false;
				}
			}

			if (Reputation.IsEnemy(from, target))
			{
				return true;
			}

			var fromGuild = GetGuildFor(from.Guild as Guild, from);
			var targetGuild = GetGuildFor(target.Guild as Guild, target);

			if (fromGuild != null && targetGuild != null && (fromGuild == targetGuild || fromGuild.IsAlly(targetGuild) || fromGuild.IsEnemy(targetGuild)))
			{
				return true; // Guild allies or enemies can be harmful
			}

			if (trgCreature != null && (trgCreature.Controlled || (trgCreature.Summoned && from != trgCreature.SummonMaster)))
			{
				return false; // Cannot harm other controlled mobiles
			}

			if (trgPlayer != null)
			{
				return false; // Cannot harm other players
			}

			if (trgCreature == null || !trgCreature.InitialInnocent)
			{
				if (Notoriety.Compute(from, target) == Notoriety.Innocent)
				{
					return false; // Cannot harm innocent mobiles
				}
			}

			return true;
		}

		public static int CorpseNotoriety(Mobile source, Corpse target)
		{
			if (target.AccessLevel > AccessLevel.Player)
			{
				return Notoriety.CanBeAttacked;
			}

			var srcPlayer = source as PlayerMobile;
			var trgPlayer = target.Owner as PlayerMobile;

			var srcCreature = source as BaseCreature;
			var trgCreature = target.Owner as BaseCreature;

			var body = (Body)target.Amount;

			if (trgCreature != null)
			{
				var sourceGuild = GetGuildFor(source.Guild as Guild, source);
				var targetGuild = GetGuildFor(target.Guild, trgCreature);

				if (sourceGuild != null && targetGuild != null)
				{
					if (sourceGuild == targetGuild || sourceGuild.IsAlly(targetGuild))
					{
						return Notoriety.Ally;
					}
					
					if (sourceGuild.IsEnemy(targetGuild))
					{
						return Notoriety.Enemy;
					}
				}

				var srcFaction = Faction.Find(source, true, true);
				var trgFaction = Faction.Find(trgCreature, true, true);

				if (srcFaction != null && trgFaction != null && srcFaction != trgFaction && source.Map == Faction.Facet)
				{
					return Notoriety.Enemy;
				}

				var srcRepPlayer = srcPlayer ?? srcCreature?.GetRootMaster<PlayerMobile>();

				if (srcRepPlayer != null)
				{
					var repNoto = Reputation.ComputeNotoriety(srcRepPlayer, trgCreature);

					if (repNoto >= 0)
					{
						return repNoto;
					}
				}

				if (CheckHouseFlag(source, trgCreature, trgCreature.Location, trgCreature.Map))
				{
					return Notoriety.CanBeAttacked;
				}

				var actual = Notoriety.CanBeAttacked;

				if (trgCreature.Kills >= 5)
				{
					actual = Notoriety.Murderer;
				}
				else if (body.IsMonster && IsSummoned(trgCreature))
				{
					actual = Notoriety.Murderer;
				}
				else if (trgCreature.AlwaysMurderer || trgCreature.IsAnimatedDead)
				{
					actual = Notoriety.Murderer;
				}

				if (DateTime.UtcNow >= target.TimeOfDeath + Corpse.MonsterLootRightSacrifice)
				{
					return actual;
				}

				var sourceParty = Party.Get(source);

				var list = target.Aggressors;

				for (var i = 0; i < list.Count; ++i)
				{
					if (list[i] == source)
					{
						return actual;
					}

					if (sourceParty != null && Party.Get(list[i]) == sourceParty)
					{
						return actual;
					}
				}
			}
			else
			{
				if (target.Kills >= 5)
				{
					return Notoriety.Murderer;
				}

				if (target.Criminal && target.Map != null && !target.Map.Rules.HasFlag(MapRules.HarmfulRestrictions))
				{
					return Notoriety.Criminal;
				}

				var sourceGuild = GetGuildFor(source.Guild as Guild, source);
				var targetGuild = GetGuildFor(target.Guild, target.Owner);

				if (sourceGuild != null && targetGuild != null)
				{
					if (sourceGuild == targetGuild || sourceGuild.IsAlly(targetGuild))
					{
						return Notoriety.Ally;
					}
					
					if (sourceGuild.IsEnemy(targetGuild))
					{
						return Notoriety.Enemy;
					}
				}

				var srcFaction = Faction.Find(source, true, true);
				var trgFaction = Faction.Find(target.Owner, true, true);

				if (srcFaction != null && trgFaction != null && srcFaction != trgFaction && source.Map == Faction.Facet)
				{
					var secondList = target.Aggressors;

					for (var i = 0; i < secondList.Count; ++i)
					{
						if (secondList[i] == source || secondList[i] is BaseFactionGuard)
						{
							return Notoriety.Enemy;
						}
					}
				}

				var srcRepPlayer = srcPlayer ?? srcCreature?.GetRootMaster<PlayerMobile>();

				if (srcRepPlayer != null)
				{
					var repNoto = Reputation.ComputeNotoriety(srcRepPlayer, target.Owner);

					if (repNoto >= 0)
					{
						return repNoto;
					}
				}

				if (CheckHouseFlag(source, target.Owner, target.Location, target.Map))
				{
					return Notoriety.CanBeAttacked;
				}

				if (trgPlayer == null)
				{
					return Notoriety.CanBeAttacked;
				}

				var list = target.Aggressors;

				for (var i = 0; i < list.Count; ++i)
				{
					if (list[i] == source)
					{
						return Notoriety.CanBeAttacked;
					}
				}
			}
			
			return Notoriety.Innocent;
		}

		public static int MobileNotoriety(Mobile source, Mobile target)
		{
			var srcPlayer = source as PlayerMobile;
			var trgPlayer = target as PlayerMobile;

			var srcCreature = source as BaseCreature;
			var trgCreature = target as BaseCreature;

			if (Core.AOS)
			{
				if (target.Blessed)
				{
					return Notoriety.Invulnerable;
				}

				if (trgCreature != null && trgCreature.IsInvulnerable)
				{
					return Notoriety.Invulnerable;
				}

				if (target is PlayerVendor || target is TownCrier)
				{
					return Notoriety.Invulnerable;
				}
			}

			#region Dueling

			var pmFrom = srcPlayer ?? srcCreature?.GetRootMaster<PlayerMobile>();
			var pmTarg = trgPlayer ?? trgCreature?.GetRootMaster<PlayerMobile>();

			if (pmFrom != null && pmTarg != null)
			{
				if (pmFrom.DuelContext != null && pmFrom.DuelContext.StartedBeginCountdown && !pmFrom.DuelContext.Finished && pmFrom.DuelContext == pmTarg.DuelContext)
				{
					if (pmFrom.DuelContext.IsAlly(pmFrom, pmTarg))
					{
						return Notoriety.Ally;
					}
					
					return Notoriety.Enemy;
				}
			}

			#endregion

			if (target.AccessLevel > AccessLevel.Player)
			{
				return Notoriety.CanBeAttacked;
			}

			if (srcPlayer != null && trgCreature != null)
			{
				var master = trgCreature.GetMaster();

				if (master != null && master.AccessLevel > AccessLevel.Player)
				{
					return Notoriety.CanBeAttacked;
				}

				master = trgCreature.ControlMaster;

				if (Core.ML && master != null)
				{
					if (source == master && CheckAggressor(target.Aggressors, source))
					{
						return Notoriety.CanBeAttacked;
					}

					if (CheckAggressor(source.Aggressors, trgCreature))
					{
						return Notoriety.CanBeAttacked;
					}

					return MobileNotoriety(source, master);
				}

				if (!trgCreature.Summoned && !trgCreature.Controlled && srcPlayer.EnemyOfOneType == target.GetType())
				{
					return Notoriety.Enemy;
				}
			}

			if (target.Kills >= 5)
			{
				return Notoriety.Murderer;
			}

			if (target.Body.IsMonster && IsSummoned(trgCreature))
			{
				if (target is not BaseFamiliar && target is not ArcaneFey && target is not Golem)
				{
					return Notoriety.Murderer;
				}
			}

			if (trgCreature != null && (trgCreature.AlwaysMurderer || trgCreature.IsAnimatedDead))
			{
				return Notoriety.Murderer;
			}

			if (target.Criminal)
			{
				return Notoriety.Criminal;
			}

			var sourceGuild = GetGuildFor(source.Guild as Guild, source);
			var targetGuild = GetGuildFor(target.Guild as Guild, target);

			if (sourceGuild != null && targetGuild != null)
			{
				if (sourceGuild == targetGuild || sourceGuild.IsAlly(targetGuild))
				{
					return Notoriety.Ally;
				}
				
				if (sourceGuild.IsEnemy(targetGuild))
				{
					return Notoriety.Enemy;
				}
			}

			var srcFaction = Faction.Find(source, true, true);
			var trgFaction = Faction.Find(target, true, true);

			if (srcFaction != null && trgFaction != null && srcFaction != trgFaction && source.Map == Faction.Facet)
			{
				return Notoriety.Enemy;
			}

			if (Stealing.ClassicMode && trgPlayer != null && trgPlayer.PermaFlags.Contains(source))
			{
				return Notoriety.CanBeAttacked;
			}

			if (target is BaseCreature trgCreature1 && trgCreature1.AlwaysAttackable)
			{
				return Notoriety.CanBeAttacked;
			}

			var srcRepPlayer = srcPlayer ?? srcCreature?.GetRootMaster<PlayerMobile>();

			if (srcRepPlayer != null)
			{
				var repNoto = Reputation.ComputeNotoriety(srcRepPlayer, target);

				if (repNoto >= 0)
				{
					return repNoto;
				}
			}

			if (CheckHouseFlag(source, target, target.Location, target.Map))
			{
				return Notoriety.CanBeAttacked;
			}

			if (trgCreature == null || trgCreature.InitialInnocent)
			{
				if (trgPlayer == null && !target.Body.IsHuman && !target.Body.IsGhost && !IsPet(trgCreature))
				{
					return Notoriety.CanBeAttacked;
				}

				if (!Core.ML && !target.CanBeginAction(typeof(PolymorphSpell)))
				{
					return Notoriety.CanBeAttacked;
				}
			}

			if (CheckAggressor(source.Aggressors, target))
			{
				return Notoriety.CanBeAttacked;
			}

			if (CheckAggressed(source.Aggressed, target))
			{
				return Notoriety.CanBeAttacked;
			}

			if (trgCreature != null && trgCreature.Controlled && trgCreature.ControlOrder == OrderType.Guard && trgCreature.ControlTarget == source)
			{
				return Notoriety.CanBeAttacked;
			}

			if (srcCreature != null)
			{
				var master = srcCreature.GetMaster();

				if (master != null)
				{
					if (trgCreature != null)
					{
						return Notoriety.CanBeAttacked;
					}

					if (CheckAggressor(master.Aggressors, target))
					{
						return Notoriety.CanBeAttacked;
					}

					if (MobileNotoriety(master, target) == Notoriety.CanBeAttacked)
					{
						return Notoriety.CanBeAttacked;
					}
				}
			}

			return Notoriety.Innocent;
		}

		public static bool CheckHouseFlag(Mobile from, Mobile m, Point3D p, Map map)
		{
			var house = BaseHouse.FindHouseAt(p, map, 16);

			if (house == null || house.Public || !house.IsFriend(from))
			{
				return false;
			}

			if (m != null && house.IsFriend(m))
			{
				return false;
			}

			if (m is BaseCreature c && !c.Deleted && c.Controlled && c.ControlMaster != null)
			{
				return !house.IsFriend(c.ControlMaster);
			}

			return true;
		}

		public static bool IsPet(BaseCreature c)
		{
			return c != null && c.Controlled;
		}

		public static bool IsSummoned(BaseCreature c)
		{
			return c != null && c.Summoned;
		}

		public static bool CheckAggressor(List<AggressorInfo> list, Mobile target)
		{
			for (var i = 0; i < list.Count; ++i)
			{
				if (list[i].Attacker == target)
				{
					return true;
				}
			}

			return false;
		}

		public static bool CheckAggressed(List<AggressorInfo> list, Mobile target)
		{
			for (var i = 0; i < list.Count; ++i)
			{
				var info = list[i];

				if (!info.CriminalAggression && info.Defender == target)
				{
					return true;
				}
			}

			return false;
		}
	}

	#region Reputation

	public enum ReputationLevel
	{
		Hated,
		Hostile,
		Unfriendly,
		Neutral,
		Friendly,
		Honored,
		Revered,
		Exalted,
	}

	public enum ReputationCategory
	{
		None,
		Townships,
		Vendors,
	}

	public static class Reputation
	{
		public static string FilePath => Path.Combine(Core.CurrentSavesDirectory, "Reputation", "Reputation.bin");

		public static ReputationLevel[] Levels { get; } = Enum.GetValues<ReputationLevel>();

		public static Dictionary<ReputationCategory, HashSet<ReputationDefinition>> Definitions { get; } = new();

		public static Dictionary<PlayerMobile, ReputationState> PlayerStates { get; } = new();

		static Reputation()
		{
			Definitions[ReputationCategory.Townships] = new(Town.Towns.Select(t => t.Definition.Reputation));
			Definitions[ReputationCategory.Vendors] = new(NpcGuildInfo.Guilds.Select(g => g.Reputation));
		}

		[CallPriority(Int32.MinValue + 20)]
		public static void Configure()
		{
			EventSink.WorldSave += OnSave;
			EventSink.WorldLoad += OnLoad;
		}

		public static void HandleDeletion(Mobile mob)
		{
			if (mob is PlayerMobile p)
			{
				PlayerStates.Remove(p);
			}
		}

		public static void HandleDeath(Mobile victim, PlayerMobile killer)
		{
			foreach (var victimRep in GetDefinitions(victim))
			{
				victimRep.HandleDeath(killer, victim);
			}
		}

		public static int DeltaPoints(PlayerMobile player, ReputationDefinition definition, int delta, bool message)
		{
			return definition?.DeltaPoints(player, delta, message) ?? 0;
		}

		public static ReputationState GetState(PlayerMobile player)
		{
			if (!PlayerStates.TryGetValue(player, out var state) || state == null)
			{
				if (!player.Deleted)
				{
					PlayerStates[player] = state = new ReputationState(player);
				}
			}
			else if (player.Deleted)
			{
				PlayerStates.Remove(player);

				state = null;
			}

			return state;
		}

		public static ReputationEntry GetEntry(PlayerMobile player, ReputationDefinition definition)
		{
			var state = GetState(player);

			if (state != null)
			{
				return state.GetEntry(definition);
			}

			return null;
		}

		public static ReputationLevel GetLevel(PlayerMobile player, ReputationDefinition definition)
		{
			var entry = GetEntry(player, definition);

			if (entry != null)
			{
				return definition.ComputeLevel(entry.Points);
			}

			return ReputationLevel.Neutral;
		}

		public static int GetPoints(PlayerMobile player, ReputationDefinition definition)
		{
			var entry = GetEntry(player, definition);

			if (entry != null)
			{
				return entry.Points;
			}

			return definition[ReputationLevel.Neutral];
		}

		public static bool HasDefinition<T>(Mobile mobile, T definition) where T : ReputationDefinition
		{
			foreach (var def in InternalGetDefinitions<T>(mobile))
			{
				if (def == definition)
				{
					return true;
				}
			}

			return false;
		}

		public static IEnumerable<ReputationDefinition> GetDefinitions(Mobile mobile)
		{
			return GetDefinitions<ReputationDefinition>(mobile);
		}

		public static IEnumerable<T> GetDefinitions<T>(Mobile mobile) where T : ReputationDefinition
		{
			return InternalGetDefinitions<T>(mobile).Distinct();
		}

		private static IEnumerable<T> InternalGetDefinitions<T>(Mobile mobile) where T : ReputationDefinition
		{
			if (mobile?.Deleted != false)
			{
				yield break;
			}

			if (mobile is PlayerMobile player)
			{
				if (player.HomeTown?.Definition.Reputation is T tdef)
				{
					yield return tdef;
				}
			}
			else if (mobile is BaseCreature creature)
			{
				if (creature.ControlMaster != null)
				{
					foreach (var def in GetDefinitions<T>(creature.ControlMaster))
					{
						yield return def;
					}
				}
				else if (creature.SummonMaster != null)
				{
					foreach (var def in GetDefinitions<T>(creature.SummonMaster))
					{
						yield return def;
					}
				}

				if (creature is BaseFactionGuard fg)
				{
					var town = fg.Town;

					if (town?.Definition.Reputation is T tdef)
					{
						yield return tdef;
					}
				}

				if (creature is BaseVendor vendor)
				{
					if (vendor.NpcGuild != NpcGuild.None)
					{
						var npcGuild = vendor.NpcGuildInfo;

						if (npcGuild?.Reputation is T gdef)
						{
							yield return gdef;
						}
					}

					var town = vendor.HomeTown;

					if (town?.Definition.Reputation is T tdef)
					{
						yield return tdef;
					}
				}

				if (creature.Home != Point3D.Zero)
				{
					var region = Region.Find(creature.Home, creature.Map);

					if (region != null)
					{
						var town = Town.FromRegion(region);

						if (town?.Definition.Reputation is T tdef)
						{
							yield return tdef;
						}
					}
				}

				if (creature.Spawner != null && creature.Spawner.HomeLocation != Point3D.Zero)
				{
					var region = Region.Find(creature.Spawner.HomeLocation, creature.Map);

					if (region != null)
					{
						var town = Town.FromRegion(region);

						if (town?.Definition.Reputation is T tdef)
						{
							yield return tdef;
						}
					}
				}

				if (creature.Spawner is Item s && s.RootParent is not Mobile)
				{
					var region = Region.Find(s.GetWorldLocation(), s.Map);

					if (region != null)
					{
						var town = Town.FromRegion(region);

						if (town?.Definition.Reputation is T tdef)
						{
							yield return tdef;
						}
					}
				}
			}
		}

		public static bool IsEnemy(Mobile source, Mobile target)
		{
			return ComputeNotoriety(source, target) == Notoriety.Enemy;
		}

		public static bool IsAlly(Mobile source, Mobile target)
		{
			return ComputeNotoriety(source, target) == Notoriety.Ally;
		}

		public static int ComputeNotoriety(Mobile source, Mobile target)
		{
			var enemies = 0;
			var allies = 0;

			foreach (var rep in Reputation.GetDefinitions(source))
			{
				if (rep.IsEnemy(target))
				{
					++enemies;
				}
				else if (rep.IsAlly(target))
				{
					++allies;
				}
			}

			if (enemies > allies)
			{
				return Notoriety.Enemy;
			}

			if (allies > enemies)
			{
				return Notoriety.Ally;
			}

			return -1;
		}

		public static void WriteReference(GenericWriter writer, ReputationDefinition definition)
		{
			if (definition is TownReputationDefinition townDef)
			{
				writer.WriteEncodedInt(1);

				Town.WriteReference(writer, townDef.Owner);
			}
			else if (definition is NpcGuildReputationDefinition npcGuildDef)
			{
				writer.WriteEncodedInt(2);

				NpcGuildInfo.WriteReference(writer, npcGuildDef.Owner);
			}
			else
			{
				writer.WriteEncodedInt(-1);
			}
		}

		public static ReputationDefinition ReadReference(GenericReader reader)
		{
			var sub = reader.ReadEncodedInt();

			switch (sub)
			{
				case 0:
					{
						var town = Town.ReadReference(reader);

						return town?.Definition.Reputation;
					}
				case 1:
					{
						var npcGuild = NpcGuildInfo.ReadReference(reader);

						return npcGuild?.Reputation;
					}
			}

			return null;
		}

		private static void OnSave(WorldSaveEventArgs e)
		{
			Persistence.Serialize(FilePath, OnSerialize);
		}

		private static void OnSerialize(GenericWriter writer)
		{
			writer.Write(0);

			writer.Write(PlayerStates.Count);

			foreach (var state in PlayerStates.Values)
			{
				state.Serialize(writer);
			}
		}

		private static void OnLoad()
		{
			Persistence.Deserialize(FilePath, OnDeserialize);
		}

		private static void OnDeserialize(GenericReader reader)
		{
			reader.ReadInt();

			var count = reader.ReadInt();

			while (--count >= 0)
			{
				var state = new ReputationState(reader);

				if (state.Owner?.Deleted == false)
				{
					PlayerStates[state.Owner] = state;
				}
			}
		}
	}

	public abstract class ReputationDefinition<T> : ReputationDefinition
	{
		public T Owner { get; }

		public ReputationDefinition(T owner, ReputationCategory category, string name, params int[] levels) 
			: base(category, name, levels)
		{
			Owner = owner;
		}
	}

	[Parsable]
	public abstract class ReputationDefinition
	{
		public static readonly ReputationDefinition Default = Empty.Instance;

		private sealed class Empty : ReputationDefinition
		{
			public static readonly Empty Instance;

			static Empty()
			{
				var count = Reputation.Levels.Length;

				var values = new int[count];

				for (var i = 1; i < count; i++)
				{
					values[i] = (int)Math.Pow(2, i);
				}

				Instance = new(values);
			}

			private Empty(int[] levels)
				: base(ReputationCategory.None, String.Empty, levels)
			{ }
		}

		public static bool TryParse(string input, out ReputationDefinition value)
		{
			try
			{
				value = Parse(input);
				return true;
			}
			catch
			{
				value = Default;
				return false;
			}
		}

		public static ReputationDefinition Parse(string input)
		{
			var index = input.IndexOf('|');

			var cats = input.Substring(0, index);
			var name = input.Substring(index + 1);

			var cat = Enum.Parse<ReputationCategory>(cats);
			var defs = Reputation.Definitions[cat];

			foreach (var def in defs)
			{
				if (Insensitive.Equals(def.Name, name))
				{
					return def;
				}
			}

			return null;
		}

		private readonly int[] m_Levels;

		public int this[ReputationLevel level] => m_Levels[(int)level];

		public int PointsMin => this[ReputationLevel.Hated];
		public int PointsMax => this[ReputationLevel.Exalted];
		public int PointsDef => this[ReputationLevel.Neutral];

		public ReputationCategory Category { get; }

		public string Name { get; }

		public ReputationDefinition(ReputationCategory cat, string name, params int[] levels)
		{
			Category = cat;
			Name = name;

			m_Levels = Default.m_Levels.ToArray();

			if (levels?.Length > 0)
			{
				Array.Copy(levels, m_Levels, Math.Min(levels.Length, m_Levels.Length));
			}
		}

		public override string ToString()
		{
			return $"{Category}|{Name}";
		}

		public ReputationLevel ComputeLevel(int points)
		{
			var index = -1;

			while (++index < m_Levels.Length)
			{
				if (points <= m_Levels[index])
				{
					break;
				}
			}

			return (ReputationLevel)index;
		}

		public virtual bool IsEnemy(Mobile mobile)
		{
			if (mobile is PlayerMobile p)
			{
				return Reputation.GetLevel(p, this) <= ReputationLevel.Hostile;
			}

			if (mobile is BaseCreature c)
			{
				var master = c.GetMaster();

				if (master != null)
				{
					return IsEnemy(master);
				}
			}

			return false;
		}

		public virtual bool IsAlly(Mobile mobile)
		{
			if (mobile is PlayerMobile p)
			{
				return Reputation.GetLevel(p, this) >= ReputationLevel.Revered;
			}

			if (mobile is BaseCreature c)
			{
				var master = c.GetMaster();

				if (master != null)
				{
					return IsAlly(master);
				}
			}

			if (Reputation.HasDefinition(mobile, this))
			{
				return true;
			}

			return false;
		}

		public virtual void HandleDeath(PlayerMobile killer, Mobile victim)
		{
			if (killer == null || victim == null)
			{
				return;
			}

			var points = -10;

			if (victim is PlayerMobile playerVictim)
			{
				var victimLevel = Reputation.GetLevel(playerVictim, this);

				if (victimLevel < ReputationLevel.Neutral)
				{
					points *= -1;
				}
				else if (victimLevel >= ReputationLevel.Honored)
				{
					points *= 1 + (int)(ReputationLevel.Exalted - victimLevel);
				}
			}

			DeltaPoints(killer, points, true);
		}

		public virtual int DeltaPoints(PlayerMobile player, int delta, bool message)
		{
			if (player == null || delta == 0)
			{
				return 0;
			}

			var entry = Reputation.GetEntry(player, this);

			if (entry == null)
			{
				return 0;
			}

			var oldLevel = entry.Level;
			var oldPoints = entry.Points;

			if (delta > 0)
			{
				entry.Points += delta;

				if (message && entry.Points > oldPoints)
				{
					player.SendMessage(0x55, $"You earned {entry.Points - oldPoints:N0} reputation with {entry.Definition.Name}");
				}
			}
			else if (delta < 0)
			{
				entry.Points -= delta;

				if (message && entry.Points < oldPoints)
				{
					player.SendMessage(0x22, $"You lost {oldPoints - entry.Points:N0} reputation with {entry.Definition.Name}");
				}
			}

			if (message)
			{
				var level = entry.Level;

				if (level > oldLevel)
				{
					player.SendMessage(0x55, $"You are now {level} with {entry.Definition.Name}");
				}
				else if (level < oldLevel)
				{
					player.SendMessage(0x22, $"You are now {level} with {entry.Definition.Name}");
				}
			}

			player.Delta(MobileDelta.Noto | MobileDelta.Properties);

			return delta;
		}
	}

	[PropertyObject]
	public class ReputationState : ICollection<ReputationEntry>, INotifyPropertyUpdate
	{
		[CommandProperty(AccessLevel.Counselor, true)]
		public PlayerMobile Owner { get; private set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public HashSet<ReputationEntry> Entries { get; private set; } = new();

		[CommandProperty(AccessLevel.Counselor, true)]
		public int Count => Entries.Count;

		public ReputationEntry this[ReputationDefinition definition] => GetEntry(definition);

		bool ICollection<ReputationEntry>.IsReadOnly => ((ICollection<ReputationEntry>)Entries).IsReadOnly;

		public ReputationState(PlayerMobile owner)
		{
			Owner = owner;
		}

		public ReputationState(GenericReader reader)
		{
			Deserialize(reader);
		}

		public ReputationEntry GetEntry(ReputationDefinition definition)
		{
			if (definition == null)
			{
				return null;
			}

			foreach (var entry in Entries)
			{
				if (entry.Definition == definition)
				{
					return entry;
				}
			}

			var add = new ReputationEntry(definition);

			Entries.Add(add);

			PropertyNotifier.Notify(this, Entries);

			return add;
		}

		void ICollection<ReputationEntry>.Add(ReputationEntry item)
		{
			if (Entries.Add(item))
			{
				PropertyNotifier.Notify(this, Entries);
			}
		}

		public void Clear()
		{
			Entries.Clear();

			PropertyNotifier.Notify(this, Entries);
		}

		public bool Contains(ReputationEntry entry)
		{
			return Entries.Contains(entry);
		}

		public void CopyTo(ReputationEntry[] array, int arrayIndex)
		{
			Entries.CopyTo(array, arrayIndex);
		}

		public bool Remove(ReputationEntry item)
		{
			if (Entries.Remove(item))
			{
				PropertyNotifier.Notify(this, Entries);

				return true;
			}

			return false;
		}

		public IEnumerator<ReputationEntry> GetEnumerator()
		{
			return Entries.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0);

			writer.Write(Owner);

			writer.WriteEncodedInt(Entries.Count);

			foreach (var entry in Entries)
			{
				entry.Serialize(writer);
			}
		}

		public void Deserialize(GenericReader reader)
		{
			reader.ReadEncodedInt();

			Owner = reader.ReadMobile<PlayerMobile>();

			var count = reader.ReadEncodedInt();

			while (--count >= 0)
			{
				var entry = new ReputationEntry(reader);

				if (entry.Definition != null)
				{
					Entries.Add(entry);
				}
			}
		}
	}

	[PropertyObject]
	public class ReputationEntry
	{
		private ReputationDefinition m_Definition;
		private int m_Points;

		[CommandProperty(AccessLevel.Counselor, true)]
		public ReputationDefinition Definition => m_Definition;

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public int Points { get => m_Points; set => m_Points = Math.Clamp(value, Definition.PointsMin, Definition.PointsMax); }

		[CommandProperty(AccessLevel.Counselor, true)]
		public ReputationLevel Level => Definition.ComputeLevel(Points);

		public ReputationEntry(ReputationDefinition definition)
		{
			m_Definition = definition;
		}

		public ReputationEntry(GenericReader reader)
		{
			Deserialize(reader);
		}

		public void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0);

			Reputation.WriteReference(writer, m_Definition);

			writer.WriteEncodedInt(m_Points);
		}

		public void Deserialize(GenericReader reader)
		{
			reader.ReadEncodedInt();

			m_Definition = Reputation.ReadReference(reader);

			m_Points = reader.ReadEncodedInt();
		}
	}

	#endregion
}