using CV = Server.ClientVersion;

using Server;
using Server.Accounting;
using Server.ContextMenus;
using Server.Diagnostics;
using Server.Engines.Facet;
using Server.Gumps;
using Server.HuePickers;
using Server.Items;
using Server.Menus;
using Server.Misc;
using Server.Mobiles;
using Server.Movement;
using Server.Network;
using Server.Prompts;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Server.Engine.Facet
{
	public class FacetEditingPacketHandlers
	{
		public static void Configure()
		{
			EventSink.Disconnected += new DisconnectedEventHandler(EventSink_Disconnected);
		}

		static void EventSink_Disconnected(DisconnectedEventArgs e)
		{
			if (e.Mobile != null && e.Mobile is PlayerMobile)
			{
				PlayerMobile player = (PlayerMobile)e.Mobile;
				Console.WriteLine("Server Facet Settings Configured For " + player.Name);

				/// player.FacetEditingMajorVersion = 0;
				/// player.FacetEditingMinorVersion = 0;
			}
		}

		public static void Initialize()
		{
			PacketHandlers.Register(0x3F, 0, true, new OnPacketReceive(FacetEditingPacketHandlers.ReceiveFacetEditingCommand));
		}

		public static void ReceiveFacetEditingCommand(NetState state, PacketReader pvSrc)
		{
			pvSrc.Seek(13, SeekOrigin.Begin);

			byte facetEditingCommand = pvSrc.ReadByte();

			switch (facetEditingCommand)
			{
				case 0xFF: //block query response
					{
						HandleBlockQueryReply(state, pvSrc);
					}
					break;

				case 0xFE: //read client version of Server Facet
					{
						pvSrc.Seek(15, SeekOrigin.Begin);

						UInt16 majorVersion = pvSrc.ReadUInt16();
						UInt16 minorVersion = pvSrc.ReadUInt16();

						Console.WriteLine(String.Format("Received Server Facet Version Packet: {0}.{1} From {2}", majorVersion, minorVersion, state.Mobile.Name));
						
						if (state != null && state.Mobile is PlayerMobile)
						{
							PlayerMobile player = (PlayerMobile)state.Mobile;

							/// player.FacetEditingMajorVersion = majorVersion;
							/// player.FacetEditingMinorVersion = minorVersion;
						}
					}
					break;

				#region Developer Notations

				/// Need to write in functionality for direct server edit commands
				/// from players with accesslevel that is high enough.
				/// This will be for future enhancements on the client end (Client Overlay Editor,
				/// Pandora's Box Plugin, etc)

				#endregion

				default:
					{
					}
					break;
			}
		}

		#region Developer Notations

		/// Whenever the client moves out of a block, we will ask the client to 
		/// provide us with a list of blocks around it and their corresponding
		/// block versions.  If any of them are different than the server's 
		/// block versions, we'll know the client needs to be updated, and 
		/// we'll send the appropriate blocks.

		#endregion

		public static void HandleBlockQueryReply(NetState state, PacketReader pvSrc)
		{
			Mobile from = state.Mobile;
														// byte 000              -  cmd
														// byte 001 through 002  -  packet size
			pvSrc.Seek(3, SeekOrigin.Begin);            // byte 003 through 006  -  central block number for the query (block that player is standing in)
			UInt32 blocknum = pvSrc.ReadUInt32();		   
			UInt32 count = pvSrc.ReadUInt32();          // byte 007 through 010  -  number of statics in the packet (8 for a query response)
														// byte 011 through 012  -  Server Facet sequence number - we sent one out, did we get it back?
														// byte 013              -  Server Facet command (0xFF is a block Query Response)
			pvSrc.Seek(14, SeekOrigin.Begin);           // byte 014              -  Server Facet mapnumber
			Int32 mapID = (Int32)pvSrc.ReadByte();

			if (mapID != from.Map.MapID)
			{
				Console.WriteLine(string.Format("Received a block query response from {0} for map {1} but that player is on map {2}", from.Name, mapID, from.Map.MapID));

				return;
			}

			UInt16[] receivedCRCs = new UInt16[25];     // byte 015 through 64   -  25 block CRCs

			for (int i = 0; i < 25; i++)
			{
				receivedCRCs[i] = pvSrc.ReadUInt16();
			}

			/// TODO: see if sequence numbers are valid

			PushBlockUpdates((int)blocknum, (int)mapID, receivedCRCs, from);
		}

		public static UInt16 GetBlockCrc(Point2D blockCoords, int mapID, ref byte[] landDataOut, ref byte[] staticsDataOut)
		{
			if (blockCoords.X < 0 || blockCoords.Y < 0 || (blockCoords.X) >= Map.Maps[mapID].Tiles.BlockWidth || (blockCoords.Y) >= Map.Maps[mapID].Tiles.BlockHeight)
			{
				return (UInt16)0;
			}

			landDataOut = BlockUtility.GetLandData(blockCoords, mapID);
			staticsDataOut = BlockUtility.GetRawStaticsData(blockCoords, mapID);

			byte[] blockData = new byte[landDataOut.Length + staticsDataOut.Length];

			Array.Copy(landDataOut, 0, blockData, 0, landDataOut.Length);
			Array.Copy(staticsDataOut, 0, blockData, landDataOut.Length, staticsDataOut.Length);

			return CRC.Fletcher16(blockData);
		}

		public static void PushBlockUpdates(int block, int mapID, UInt16[] recievedCRCs, Mobile from)
		{
			/// Console.WriteLine("------------------------------------------Push Block Updates----------------------------------------");
			/// Console.WriteLine("Map: " + mapID);
			/// Console.WriteLine("Block: " + block);
			/// Console.WriteLine("----------------------------------------------------------------------------------------------------");

			if (!MapRegistry.Definitions.ContainsKey(mapID))
			{
				Console.WriteLine("Received query for an invalid map.");

				return;
			}

			ushort[] Hashes = new ushort[25];

			TileMatrix tm = Map.Maps[mapID].Tiles;

			int blockX = ((block / tm.BlockHeight));
			int blockY = ((block % tm.BlockHeight));

			Int32 wrapWidthInBlocks = MapRegistry.Definitions[mapID].WrapAroundDimensions.X >> 3;
			Int32 wrapHeightInBlocks = MapRegistry.Definitions[mapID].WrapAroundDimensions.Y >> 3;
			Int32 mapWidthInBlocks = MapRegistry.Definitions[mapID].Dimensions.X >> 3;
			Int32 mapHeightInBlocks = MapRegistry.Definitions[mapID].Dimensions.Y >> 3;

			/// Console.WriteLine("BlockX: " + blockX + " BlockY: " + blockY);
			/// Console.WriteLine("Map Height in blocks: " + mapHeightInBlocks);
			/// Console.WriteLine("Map Width in blocks: " + mapWidthInBlocks);
			/// Console.WriteLine("Wrap Height in blocks: " + wrapHeightInBlocks);
			/// Console.WriteLine("Wrap Width in blocks: " + wrapWidthInBlocks);

			if (block < 0 || block >= mapWidthInBlocks * mapHeightInBlocks)
			{
				return;
			}

			byte[] buf = new byte[2];

			for (int x = -2; x <= 2; x++)
			{
				int xBlockItr = 0;

				if (blockX < wrapWidthInBlocks)
				{
					xBlockItr = (blockX + x) % wrapWidthInBlocks;

					if (xBlockItr < 0)
					{
						xBlockItr += wrapWidthInBlocks;
					}
				}
				else
				{
					xBlockItr = (blockX + x) % mapWidthInBlocks;

					if (xBlockItr < 0)
					{
						xBlockItr += mapWidthInBlocks;
					}
				}

				for (int y = -2; y <= 2; y++)
				{
					int yBlockItr = 0;

					if (blockY < wrapHeightInBlocks)
					{
						yBlockItr = (blockY + y) % wrapHeightInBlocks;

						if (yBlockItr < 0)
						{
							yBlockItr += wrapHeightInBlocks;
						}
					}
					else
					{
						yBlockItr = (blockY + y) % mapHeightInBlocks;

						if (yBlockItr < 0)
						{
							yBlockItr += mapHeightInBlocks;
						}
					}

					Int32 blocknum = (xBlockItr * mapHeightInBlocks) + yBlockItr;

					/// CRC Caching
					UInt16 crc = CRC.MapCRCs[mapID][blocknum];

					byte[] landData = new byte[0];
					byte[] staticsData = new byte[0];

					Point2D blockPosition = new Point2D(xBlockItr, yBlockItr);

					if (crc == UInt16.MaxValue)
					{
						crc = GetBlockCrc(blockPosition, mapID, ref landData, ref staticsData);
						CRC.MapCRCs[mapID][blocknum] = crc;
					}

					/// Console.WriteLine(crc.ToString("X4") + " vs " + recievedCRCs[((x + 2) * 5) + y + 2].ToString("X4"));
					/// Console.WriteLine(String.Format("({0},{1})", blockPosition.X, blockPosition.Y));

					if (crc != recievedCRCs[((x + 2) * 5) + (y + 2)])
					{
						if (landData.Length < 1)
						{
							from.Send(new Server.Engine.Facet.UpdateTerrainPacket(blockPosition, from));
							from.Send(new Server.Engine.Facet.UpdateStaticsPacket(blockPosition, from));
						}
						else
						{
							from.Send(new Server.Engine.Facet.UpdateTerrainPacket(landData, blocknum, from.Map.MapID));
							from.Send(new Server.Engine.Facet.UpdateStaticsPacket(staticsData, blocknum, from.Map.MapID));
						}
					}
				}
			}

			///	if (refreshClientView)
			///	{
			///	  from.Send(new RefreshClientView());
			///	}
		}
	}

	#region Update Statics Packet

	#region Developer Notations

	/// Update Statics Packet 
    /// 
    /// 
    /// Original Packet: 
    /// ------------------------------
    /// Source: http://necrotoolz.sourceforge.net/kairpacketguide/packet3f.htm
    /// 
    /// 0x3f      Command 
    /// ushort    Size of packet
    /// uint      Block Number
    /// uint      Number of statics
    /// uint      Extra value for the index file
    /// 
    /// Static[number of statics]    7 bytes
    ///       ushort      ArtID
    ///       byte        X offset in the block
    ///       byte        Y offset in the block
    ///       sbyte       Z axis position of the static
    ///       ushort      Hue Number
    ///       
    /// 
    /// 
    /// New Format:
    /// ------------------------------
    /// byte         0x3f
    /// ushort       size of the packet
    /// int          block_number
    /// uint         number of statics
    /// uint         extra value that we're splitting
    ///              byte  hash
    ///              byte  Server Facet Command
    ///              ushort  mapnumber - if this is 0xFF it means its a query
    /// struct
    /// [number of statics]
    ///              ushort      ItemId      
    ///              byte        X           // Not actually stored in runuo
    ///              byte        Y           // Not actually stored in runuo
    ///              sbyte       Z           
    ///              ushort      Hue         //no longer used
    ///              
    /// 
    /// We're going to use this as a dual purpose packet. The extra field 
    /// will tell us if the packet should actually be used as a hash. The
    /// extra field is split into two padding bytes (0x00), 
    /// and an unsigned short that we're using as our map number.
    /// 
    /// If unsigned short representing the map has a maxvalue for a ushort 
    /// (0xffff), then we'll know its a packet that we're using to request 
    /// a set of 25 CRCs from the client.

	#endregion

	public class UpdateStaticsPacket : Packet
	{
		public UpdateStaticsPacket(Point2D blockCoords, Mobile m) : base(0x3F)
		{
			Map playerMap = m.Map;
			TileMatrix tm = playerMap.Tiles;

			int blockNum = ((blockCoords.X * tm.BlockHeight) + blockCoords.Y);
			byte[] staticsData = BlockUtility.GetRawStaticsData(blockCoords, playerMap.MapID);

			WriteDataToStream(staticsData, blockNum, playerMap.MapID);
		}

		public UpdateStaticsPacket(byte[] staticsData, int blockNumber, int mapID) : base(0x3F)
		{
			WriteDataToStream(staticsData, blockNumber, mapID);
		}

		public void WriteDataToStream(byte[] staticsData, int blockNumber, int mapID)
		{
																  //byte 000         -  cmd

			this.EnsureCapacity(15 + staticsData.Length);         //byte 001 to 002  -  packet size

			m_Stream.Write((uint)blockNumber);                    //byte 003 to 006  -  block number
			m_Stream.Write((int)staticsData.Length / 7);          //byte 007 to 010  -  number of statics in packet
			m_Stream.Write((ushort)0x0000);                       //byte 011 to 012  -  Server Facet sequence number
			m_Stream.Write((byte)0x00);                           //byte 013         -  Server Facet command (0x00 is a statics update)
			m_Stream.Write((byte)mapID);                          //byte 014         -  Server Facet mapnumber
			m_Stream.Write(staticsData, 0, staticsData.Length);   //byte 015 to ???  -  statics data

			/// Console.WriteLine(string.Format("Sending statics data for block: {0}, Map: {1}", blockNum, playerMap.MapID));
			/// BlockUtility.WriteStaticsDataToConsole(staticsData);
		}
	}

	#endregion

	#region Query Client Hash Packet

	/// This Is Now Using A CRC Check Instead Of Versions
	public class QueryClientHash : Packet
	{
		public QueryClientHash(Mobile m) : base(0x3F)
		{
			Map playerMap = m.Map;
			TileMatrix tm = playerMap.Tiles;

			int blocknum = (((m.Location.X >> 3) * tm.BlockHeight) + (m.Location.Y >> 3));

			/// Console.WriteLine(String.Format("Block Query Hash: {0}", blocknum));

														//byte 000         -  cmd

			this.EnsureCapacity(15);                    //byte 001 to 002  -  packet size

			m_Stream.Write((UInt32)blocknum);           //byte 003 to 006  -  central block number for the query (block that player is standing in)
			m_Stream.Write((Int32)0);                   //byte 007 to 010  -  number of statics in the packet (0 for a query)
			m_Stream.Write((UInt16)0x0000);             //byte 011 to 012  -  Server Facet sequence number
			m_Stream.Write((byte)0xFF);                 //byte 013         -  Server Facet command (0xFF is a block Query)
			m_Stream.Write((byte)playerMap.MapID);      //byte 014         -  Server Facet mapnumber
		}
	}

	#endregion

	#region Update Map Definition Packet

	/// This Is Sent To The Client So The Client Knows The Dimension Of Extra Maps
	public class MapDefinitions : Packet
	{
		public MapDefinitions() : base(0x3F)
		{
			Dictionary<int, MapRegistry.MapDefinition>.ValueCollection definitions = MapRegistry.Definitions.Values;

			int length = definitions.Count * 9; // 12 * 9 = 108
			int count = length / 7; // 108 / 7 = 15
			int padding = 0;

			if (length - (count * 7) > 0)
			{
				count++;
				padding = (count * 7) - length;
			}

														// byte 000 to 015  -  The first 15 bytes of this packet are always the same
														// byte 000         -  cmd
														   
			this.EnsureCapacity(15 + length);           // byte 001 to 002  -  packet size
														   
			m_Stream.Write((uint)0x00);                 // byte 003 to 006  -  block number, doesn't really apply in this case
			m_Stream.Write((int)count);                 // byte 007 to 010  -  number of statics in the packet, in this case its calculated to hold enough space for all the map definitions
			m_Stream.Write((ushort)0x00);               // byte 011 to 012  -  Server Facet sequence number, doesn't apply in this case
			m_Stream.Write((byte)0x01);                 // byte 013         -  Server Facet command (0x01 is Update Map Definitions)
			m_Stream.Write((byte)0x00);                 // byte 014         -  Server Facet mapnumber, doesn't apply in this case
														// byte 015 to end  -  Map Definitions

			foreach (MapRegistry.MapDefinition md in definitions)
			{
				m_Stream.Write((byte)md.FileIndex);                 // iteration byte 000         -  map file index number
				m_Stream.Write((ushort)md.Dimensions.X);            // iteration byte 001 to 002  -  map width
				m_Stream.Write((ushort)md.Dimensions.Y);            // iteration byte 003 to 004  -  map height
				m_Stream.Write((ushort)md.WrapAroundDimensions.X);  // iteration byte 005 to 006  -  wrap around dimension X
				m_Stream.Write((ushort)md.WrapAroundDimensions.Y);  // iteration byte 007 to 008  -  wrap around dimension Y
			}

			for (int i = 0; i < padding; i++)
			{
				m_Stream.Write((byte)0x00);
			}
		}
	}

	#endregion

	#region Update Terrain Packet

	#region Developer Notations

	/// Update Terrain Packet 
    /// Source: http://necrotoolz.sourceforge.net/kairpacketguide/packet40.htm
    /// 
    /// Format:
    /// 
    /// byte         0x40
    /// uint         block number
    /// 
    /// struct[64]   maptiles
    ///              ushort      Tile Number 
    ///              sbyte       Z    
    /// uint         map grid header -> we're splitting this into two ushorts
    ///      ushort  padding
    ///      ushort  mapnumber

	#endregion

	public class UpdateTerrainPacket : Packet
	{
		public UpdateTerrainPacket(Point2D blockCoords, Mobile m) : base(0x40, 0xC9)
		{
			Map playerMap = m.Map;
			TileMatrix tm = playerMap.Tiles;

			int blockNumber = ((blockCoords.X * tm.BlockHeight) + blockCoords.Y);
			byte[] landData = BlockUtility.GetLandData(blockCoords, playerMap.MapID);

			WriteDataToStream(landData, blockNumber, playerMap.MapID);
		}

		public UpdateTerrainPacket(byte[] landData, int blockNumber, int mapID) : base(0x40, 0xC9)
		{
			WriteDataToStream(landData, blockNumber, mapID);
		}

		public void WriteDataToStream(byte[] landData, int blockNumber, int mapID)
		{
			/// Console.WriteLine(string.Format("Packet Constructor land block coords ({0},{1})", blockCoords.X, blockCoords.Y));

															   // byte 000              -  cmd
			m_Stream.Write((int)blockNumber);                  // byte 001 through 004  -  blocknum
			m_Stream.Write(landData, 0, landData.Length);      // byte 005 through 196  -  land data
			m_Stream.Write((byte)0x00);                        // byte 197              -  padding
			m_Stream.Write((byte)0x00);                        // byte 198              -  padding
			m_Stream.Write((byte)0x00);                        // byte 199              -  padding
			m_Stream.Write((byte)mapID);                       // byte 200              -  map number
															   // Console.WriteLine(string.Format("Sending land data for block: {0} Map: {1}", blocknum, playerMap.MapID));
															   // BlockUtility.WriteLandDataToConsole(landData);
		}
	}

	#endregion

	#region TargetObjectList Packets

	public struct TargetObject
	{
		public int ItemID;
		public int Hue;
		public int xOffset;
		public int yOffset;
		public int zOffset;
	}

	#region Developer Notations

	///Target Object List Packet
    ///Thank you -hash- from RunUO.com for providing the definition for this

	#endregion

	public sealed class TargetObjectList : Packet
	{
		public TargetObjectList(List<TargetObject> targetObjects, Mobile m, bool allowGround) : base(0xB4)
		{
			byte allowGroundByte = 0;

			if (allowGround == true)
			{
				allowGroundByte = 0x1;
			}

			int packetSize = 16 + (targetObjects.Count * 10);

															//byte 000              -  cmd
			this.EnsureCapacity(packetSize);				//byte 001 through 002  -  packet size

			m_Stream.Write(allowGroundByte);				//byte 003              -  Allow Ground
			m_Stream.Write((int)m.Serial);					//byte 004 through 007  -  target serial
			m_Stream.Write((UInt16)0);						//byte 008 through 009  -  x
			m_Stream.Write((UInt16)0);						//byte 010 through 011  -  y
			m_Stream.Write((UInt16)0);						//byte 012 through 013  -  z
			m_Stream.Write((UInt16)targetObjects.Count);	//byte 014 through 015  -  Number of Entries

			foreach (TargetObject t in targetObjects)		//byte 016 through end     target object entries (10 bytes each)
			{
				m_Stream.Write((UInt16)t.ItemID);			//entry byte 000 through 001  -  Number of Entries
				m_Stream.Write((UInt16)t.Hue);				//entry byte 002 through 003  -  Number of Entries
				m_Stream.Write((UInt16)t.xOffset);			//entry byte 004 through 005  -  Number of Entries
				m_Stream.Write((UInt16)t.yOffset);			//entry byte 006 through 007  -  Number of Entries
				m_Stream.Write((UInt16)t.zOffset);			//entry byte 008 through 009  -  Number of Entries
			}
		}
	}

	#endregion

	#region Login Complete Packet

	public class LoginComplete : Packet
	{
		public LoginComplete() : base(0x3F)
		{
													//1 byte packet number (0x3F)
													//2 bytes size of packet (15)
													//4 byte block num (0x01)
													//4 byte statics count
													//4 byte extra
													//byte 000 to 015  -  The first 15 bytes of this packet are always the same
													//byte 000         -  cmd
			this.EnsureCapacity(43);                //byte 001 to 002  -  packet size

			m_Stream.Write((UInt32)0x01);           //byte 003 to 006  -  block number, doesn't really apply in this case
			m_Stream.Write((UInt32)4);              //byte 007 to 010  -  number of statics in the packet - 0 in this case
			m_Stream.Write((UInt16)0x0000);         //byte 011 to 012  -  Server Facet sequence number, doesn't apply in this case
			m_Stream.Write((byte)0x02);             //byte 013         -  Server Facet command (0x02 is Login Confirmation)
			m_Stream.Write((byte)0x00);             //byte 014         -  Server Facet mapnumber, doesn't apply in this case

			if (FacetEditingSettings.UNIQUE_SERVER_IDENTIFIER.Length < 28)
			{
				m_Stream.WriteAsciiFixed(FacetEditingSettings.UNIQUE_SERVER_IDENTIFIER, FacetEditingSettings.UNIQUE_SERVER_IDENTIFIER.Length);                                       //byte 015 to 042  -  shard identifier
				int remainingLength = 28 - FacetEditingSettings.UNIQUE_SERVER_IDENTIFIER.Length;

				for (int i = 0; i < remainingLength; ++i)
				{
					m_Stream.Write((byte)0x00);
				}
			}
			else
			{
				m_Stream.WriteAsciiFixed(FacetEditingSettings.UNIQUE_SERVER_IDENTIFIER.Substring(0, 28), 28);
			}
		}
	}

	#endregion

	#region Refresh Client View Packet

	///This Is Now Using A CRC Check Instead Of Versions
	public class RefreshClientView : Packet
	{
		public RefreshClientView() : base(0x3F)
		{
												// byte 000         -  cmd
			this.EnsureCapacity(15);            // byte 001 to 002  -  packet size
			m_Stream.Write((UInt32)0);          // byte 003 to 006  -  central block number for the query (block that player is standing in)
			m_Stream.Write((Int32)0);           // byte 007 to 010  -  number of statics in the packet (0 for a query)
			m_Stream.Write((UInt16)0x0000);     // byte 011 to 012  -  Server Facet sequence number
			m_Stream.Write((byte)0x03);         // byte 013         -  Server Facet command (0x03 is a REFRESH_CLIENT)
			m_Stream.Write((byte)0);            // byte 014         -  Server Facet mapnumber
		}
	}

	#endregion
}