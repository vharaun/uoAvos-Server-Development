using System;
using System.Collections.Generic;

#region Developer Notations

/// When adding, or replacing, a facet you will need to register your new map in this script:
/// MapRegistry: line(s) 38+

/// You will also need to modify the server application in the 'Server/Engine/Game/' directory:
/// Facet.cs: line(s) 412+

#endregion

namespace Server.Engines.Facet
{
	public static class MapRegistry
	{
		public static Dictionary<int, MapDefinition> Definitions { get; } = new();
		public static Dictionary<int, HashSet<int>> MapAssociations { get; } = new();

		static MapRegistry()
		{
			#region Map/Facet Definitions

			/// RegisterMap( <index>, <mapID>, <fileIndex>, <width>, <height>[, <wrapWidth>, <wrapHeight>], <season>, <name>, <rules> );

			/// - <index>: An unreserved unique index for this map
			/// - <mapID>: An identification number used in client communications. For any visible maps, this value must be from 0-5
			/// - <fileIndex> : A file identification number. For any visible maps, this value must be from 0-5
			/// - <width>, <height>: Size of the map bounds (in tiles)
			/// - <wrapWidth>, <wrapHeight>: Size of the map wrap (in tiles)
			/// - <season>: Season of the map. 0 = Spring, 1 = Summer, 2 = Fall, 3 = Winter, 4 = Desolation
			/// - <name>: Reference name for the map, used in props gump, get/set commands, region loading, etc
			/// - <rules>: Rules and restrictions associated with the map. See documentation for details

			#endregion

			RegisterMap(0, 0, 0, 7168, 4096, 5120, 4096, 4, "Felucca", MapRules.FeluccaRules);
			RegisterMap(1, 1, 1, 7168, 4096, 5120, 4096, 0, "Trammel", MapRules.TrammelRules);
			RegisterMap(2, 2, 2, 2304, 1600, 1, "Ilshenar", MapRules.TrammelRules);
			RegisterMap(3, 3, 3, 2560, 2048, 1, "Malas", MapRules.TrammelRules);
			RegisterMap(4, 4, 4, 1448, 1448, 1, "Tokuno", MapRules.TrammelRules);
			RegisterMap(5, 5, 5, 1280, 4096, 1, "TerMur", MapRules.TrammelRules);

			RegisterMap(0x7F, 0x7F, 0x7F, Map.SectorSize, Map.SectorSize, 1, "Internal", MapRules.Internal);
		}

		public static void Configure()
		{
			TileMatrixPatch.Enabled = false; // OSI Client Patch 6.0.0.0
			MultiComponentList.PostHSFormat = true; // OSI Client Patch 7.0.9.0

			EventSink.ServerList += EventSink_OnServerList;
			EventSink.Login += EventSink_Login;
		}

		private static void EventSink_OnServerList(ServerListEventArgs args)
		{
			args.State.Send(new Engine.Facet.LoginComplete());
			args.State.Send(new Engine.Facet.MapDefinitions());
		}

		private static void EventSink_Login(LoginEventArgs args)
		{
			_ = args.Mobile.Send(new Engine.Facet.QueryClientHash(args.Mobile));
		}

		public static void RegisterMap(int mapIndex, int mapID, int fileIndex, ushort width, ushort height, int season, string name, MapRules rules)
		{
			var wrapWidth = width;
			var wrapHeight = height;

			if (wrapWidth == 7168 && (fileIndex == 0 || fileIndex == 1))
			{
				wrapWidth = 5120;
			}

			RegisterMap(mapIndex, mapID, fileIndex, width, height, wrapWidth, wrapHeight, season, name, rules);
		}

		public static void RegisterMap(int mapIndex, int mapID, int fileIndex, ushort width, ushort height, ushort wrapWidth, ushort wrapHeight, int season, string name, MapRules rules)
		{
			RegisterMap(mapIndex, mapID, fileIndex, new MapBounds(width, height), new MapBounds(wrapWidth, wrapHeight), season, name, rules);
		}

		public static void RegisterMap(int mapIndex, int mapID, int fileIndex, MapBounds bounds, MapBounds wrap, int season, string name, MapRules rules)
		{
			var newMap = new Map(mapID, mapIndex, fileIndex, bounds.Width, bounds.Height, season, name, rules);

			Map.Maps[mapIndex] = newMap;

			Map.AllMaps.Add(newMap);
			Map.AllMaps.Sort((l, r) => l.MapIndex.CompareTo(r.MapIndex));

			if (mapIndex == 0x7F)
			{
				return;
			}

			Definitions[mapIndex] = new MapDefinition(fileIndex, bounds, wrap);

			if (!MapAssociations.TryGetValue(fileIndex, out var value))
			{
				MapAssociations[fileIndex] = value = new();
			}

			value.Add(mapIndex);
		}

		public readonly struct MapBounds
		{
			public readonly ushort Width, Height;

			public MapBounds(ushort width, ushort height)
			{
				Width = width;
				Height = height;
			}
		}

		public readonly struct MapDefinition
		{
			public readonly int FileIndex;

			public readonly MapBounds Bounds, Wrap;

			public MapDefinition(int index, MapBounds bounds, MapBounds wrap)
			{
				FileIndex = index;
				Bounds = bounds;
				Wrap = wrap;
			}
		}
	}
}