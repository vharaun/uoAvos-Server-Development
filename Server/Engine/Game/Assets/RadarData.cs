
using System;
using System.Drawing;
using System.IO;

namespace Server
{
	public static class RadarData
	{
		public static Color[] LandColors { get; } = new Color[TileData.LandTable.Length];
		public static Color[] StaticColors { get; } = new Color[TileData.ItemTable.Length];

		public static bool CheckFile => Core.FindDataFile("radarcol.mul") != null;

		static RadarData()
		{
			var index = 0;

			if (CheckFile)
			{
				var path = Core.FindDataFile("radarcol.mul");

				if (path != null)
				{
					using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						var buffer = new byte[fs.Length];

						fs.Read(buffer, 0, buffer.Length);

						var count = buffer.Length / 2;

						while (index < count)
						{
							var color = HueData.ConvertColor(BitConverter.ToUInt16(buffer, index * 2));

							if (index < LandColors.Length)
							{
								LandColors[index] = color;
							}
							else if (index - LandColors.Length < StaticColors.Length)
							{
								StaticColors[index - LandColors.Length] = color;
							}

							++index;
						}
					}
				}
			}

			while (index < LandColors.Length)
			{
				LandColors[index] = Color.Empty;

				++index;
			}

			index -= LandColors.Length;

			while (index < StaticColors.Length)
			{
				StaticColors[index] = Color.Empty;

				++index;
			}
		}

		public static Color GetLandColor(int index)
		{
			return index < LandColors.Length ? LandColors[index] : Color.Empty;
		}

		public static Color GetStaticColor(int index)
		{
			return index < StaticColors.Length ? StaticColors[index] : Color.Empty;
		}
	}
}
