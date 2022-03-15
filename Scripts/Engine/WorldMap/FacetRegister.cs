using Server;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

#region Developer Notations

/// When adding, or replacing, a facet you will need to register your new map in two (2) places in this script:
/// MapDefinitions: line(s) 38-43 | MapRegistry: line(s) 124-129

/// You will also need to modify the server application in the 'Server/Engine/Game/' directory:
/// Facet.cs: line(s) 409-419

#endregion

namespace Server.Engines.Facet
{
	public class MapDefinitions
	{
		public static void Configure()
		{
			#region Map/ Facet Definitions

			/// RegisterMap( <index>, <mapID>, <fileIndex>, <width>, <height>, <season>, <name>, <rules> );

			/// - <index>: An unreserved unique index for this map
			/// - <mapID>: An identification number used in client communications. For any visible maps, this value must be from 0-5
			/// - <fileIndex> : A file identification number. For any visible maps, this value must be from 0-5
			/// - <width>, <height>: Size of the map (in tiles)
			/// - <season>: Season of the map. 0 = Spring, 1 = Summer, 2 = Fall, 3 = Winter, 4 = Desolation
			/// - <name>: Reference name for the map, used in props gump, get/set commands, region loading, etc
			/// - <rules>: Rules and restrictions associated with the map. See documentation for details

			#endregion

			RegisterMap(0, 0, 0, 7168, 4096, 4, "Felucca", MapRules.FeluccaRules);
			RegisterMap(1, 1, 1, 7168, 4096, 0, "Trammel", MapRules.TrammelRules);
			RegisterMap(2, 2, 2, 2304, 1600, 1, "Ilshenar", MapRules.TrammelRules);
			RegisterMap(3, 3, 3, 2560, 2048, 1, "Malas", MapRules.TrammelRules);
			RegisterMap(4, 4, 4, 1448, 1448, 1, "Tokuno", MapRules.TrammelRules);
			RegisterMap(5, 5, 5, 1280, 4096, 1, "TerMur", MapRules.TrammelRules);

			RegisterMap(0x7F, 0x7F, 0x7F, Map.SectorSize, Map.SectorSize, 1, "Internal", MapRules.Internal);

			TileMatrixPatch.Enabled = false; // OSI Client Patch 6.0.0.0

			MultiComponentList.PostHSFormat = true; // OSI Client Patch 7.0.9.0
		}

		public static void RegisterMap(int mapIndex, int mapID, int fileIndex, int width, int height, int season, string name, MapRules rules)
		{
			var newMap = new Map(mapID, mapIndex, fileIndex, width, height, season, name, rules);

			Map.Maps[mapIndex] = newMap;
			Map.AllMaps.Add(newMap);
		}
	}

	public class MapRegistry
	{
		public struct MapDefinition
		{
			public int FileIndex;

			public Point2D Dimensions;
			public Point2D WrapAroundDimensions;

			public MapDefinition(int index, Point2D dimension, Point2D wraparound)
			{
				FileIndex = index;
				Dimensions = dimension;
				WrapAroundDimensions = wraparound;
			}
		}

		private static Dictionary<int, MapDefinition> m_Definitions = new Dictionary<int, MapDefinition>();

		public static Dictionary<int, MapDefinition> Definitions
		{
			get { return m_Definitions; }
		}

		private static Dictionary<int, List<int>> m_MapAssociations = new Dictionary<int, List<int>>();

		public static Dictionary<int, List<int>> MapAssociations
		{
			get { return m_MapAssociations; }
		}

		public static void AddMapDefinition(int index, int associated, Point2D dimensions, Point2D wrapDimensions)
		{
			if (!m_Definitions.ContainsKey(index))
			{
				m_Definitions.Add(index, new MapDefinition(associated, dimensions, wrapDimensions));

				if (m_MapAssociations.ContainsKey(associated))
				{
					m_MapAssociations[associated].Add(index);
				}
				else
				{
					m_MapAssociations[associated] = new List<int>();
					m_MapAssociations[associated].Add(index);
				}
			}
		}

		public static void Configure()
		{
			#region Map/ Facet Definitions

			/// AddMapDefinition( <index>, <association>, <point2D_dimensions>, <point2D_wrap_dimensions>);

			/// - <index>: An unreserved unique index for this map
			/// - <association>: An identification number used in client communications. For any visible maps, this value must be from 0-5
			/// - <point2D_dimensions>: The size of your entire map
			/// - <point2D_wrap_dimensions>: The area where your map wraps around (think of your map like a globe)

			#endregion

			AddMapDefinition(0, 0, new Point2D(7168, 4096), new Point2D(5120, 4096)); //felucca
			AddMapDefinition(1, 1, new Point2D(7168, 4096), new Point2D(5120, 4096)); //trammel
			AddMapDefinition(2, 2, new Point2D(2304, 1600), new Point2D(2304, 1600)); //Ilshenar
			AddMapDefinition(3, 3, new Point2D(2560, 2048), new Point2D(2560, 2048)); //Malas
			AddMapDefinition(4, 4, new Point2D(1448, 1448), new Point2D(1448, 1448)); //Tokuno
			AddMapDefinition(5, 5, new Point2D(1280, 4096), new Point2D(1280, 4096)); //TerMur

			EventSink.ServerList += new ServerListEventHandler(EventSink_OnServerList);
			EventSink.Login += new LoginEventHandler(EventSink_Login);
		}

		private static void EventSink_OnServerList(ServerListEventArgs args)
		{
			args.State.Send(new Server.Engine.Facet.LoginComplete());
			args.State.Send(new Server.Engine.Facet.MapDefinitions());
		}

		private static void EventSink_Login(LoginEventArgs args)
		{
			args.Mobile.Send(new Server.Engine.Facet.QueryClientHash(args.Mobile));
		}
	}
}