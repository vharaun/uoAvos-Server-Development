using Server;
using Server.Engines.Facet;
using Server.Misc;

using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Engine.Facet
{
	public class CRC
	{
		public static UInt16[][] MapCRCs; // CRC Caching: [map][block]

		public static void InvalidateBlockCRC(int map, int block)
		{
			MapCRCs[map][block] = UInt16.MaxValue;
		}

		public static void Configure()
		{
			EventSink.WorldLoad += new WorldLoadEventHandler(OnLoad);
		}

		public static void OnLoad()
		{
			MapCRCs = new UInt16[256][];

			/// We Need CRCs For Every Block In Every Map
			foreach (KeyValuePair<int, MapRegistry.MapDefinition> kvp in MapRegistry.Definitions)
			{
				int blocks = Server.Map.Maps[kvp.Key].Tiles.BlockWidth * Server.Map.Maps[kvp.Key].Tiles.BlockHeight;

				MapCRCs[kvp.Key] = new UInt16[blocks];

				for (int j = 0; j < blocks; j++)
				{
					MapCRCs[kvp.Key][j] = UInt16.MaxValue;
				}
			}
		}

		#region Developer Notations

		/// Thank you http://en.wikipedia.org/wiki/Fletcher%27s_checksum
		/// Each sum is computed modulo 255 and thus remains less than 
		/// 0xFF at all times. This implementation will thus never 
		/// produce the checksum results 0x00FF, 0xFF00 or 0xFFFF.

		#endregion

		public static UInt16 Fletcher16(byte[] data)
		{
			UInt16 sum1 = 0;
			UInt16 sum2 = 0;

			int index;

			for (index = 0; index < data.Length; ++index)
			{
				sum1 = (UInt16)((sum1 + data[index]) % 255);
				sum2 = (UInt16)((sum2 + sum1) % 255);
			}

			return (UInt16)((sum2 << 8) | sum1);
		}
	}
}