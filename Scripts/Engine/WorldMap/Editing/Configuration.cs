using Server;
using Server.Commands;
using Server.Commands.Generic;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Server.Engine.Facet
{
	public class FacetEditingSettings
	{
		#region Manually Defined Save Directories

		public const string UNIQUE_SERVER_IDENTIFIER = "uoAvos"; //Must be 28 characters or less

		public const string FILE_EXPORT_ROOT_FOLDER_PATH = "Export/Facet";

		public const string MODIFIED_CLIENT_FILES_SAVE_PATH = "MapFiles";
		public const string LIVE_REALTIME_CHANGES_SAVE_PATH = "Changes";

		/// Module Save Paths
		public const string FACET_MODULE_LUMBERHARVEST_SAVE_PATH = "Modules/LumberHarvest";

		#endregion

		public static string FileExportRootFolderPath
		{
			get
			{
				return Path.Combine(Core.BaseDirectory, FILE_EXPORT_ROOT_FOLDER_PATH);
			}
		}

		public static string ModifiedClientFilesSavePath
		{
			get
			{
				return Path.Combine(FileExportRootFolderPath, MODIFIED_CLIENT_FILES_SAVE_PATH);
			}
		}

		public static string LiveRealTimeChangesSavePath
		{
			get
			{
				return Path.Combine(FileExportRootFolderPath, LIVE_REALTIME_CHANGES_SAVE_PATH);
			}
		}

		#region Server Facet Module: LumberHarvest

		public static string LumberHarvestFallenTreeSaveLocation
		{
			get
			{
				return Path.Combine(FileExportRootFolderPath, FACET_MODULE_LUMBERHARVEST_SAVE_PATH);
			}
		}

		#endregion
	}
}