namespace Server.Misc
{
	public class DataPath
	{
		#region Game Installation Configuration

		/// If you wish the server to use a  seperate set of datafiles, 
		/// change the 'CustomPath' value below. 
		/// 
		/// A value of null will prompt for manual path input in the console.
		/// 
		/// Example: @"C:\Program Files\Ultima Online";

		#endregion

		private static readonly string CustomPath = @"X:\ULTIMA\Ultima Online Classic"; //This default value will try to find your game data in your '<shard root>/Client' directory

		#region Files Required To Run Emulation

		/// Map*.mul
		/// Map*LegacyMUL.uop
		/// MapDif*.mul
		/// MapDifL*.mul
		/// Multi.idx
		/// Multi.mul
		/// StaDif*.mul
		/// StaDifI*.mul
		/// StaDifL*.mul
		/// StaIdx*.mul
		/// Statics*.mul
		/// TileData.mul
		/// VerData.mul

		#endregion

		public static void Prepare()
		{
			if (CustomPath != null)
			{
				Core.DataDirectory = CustomPath;
			}
		}
	}
}