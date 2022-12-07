//#define CUSTOM_TREE_GRAPHICS

using Server;
using Server.Engine.Facet;
using Server.Engines.Harvest;
using Server.Items;
using Server.Network;
using Server.Regions;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#region Developer Notations

///    +---------------------------+              +---------------------------+
///    | GraphicAsset              +-------+      | BaseHarvestablePhase      |
///    |---------------------------|       |      |---------------------------|
///    | ItemId                    |       |      | FinalHarvestPhase         |
///    | xOffset                   |       |      | StartingGrowthPhase       |
///    | yOffset                   |       |      | NextHarvestPhase          |
///    | HarvestResourceBaseAmount |       |      | NextGrowthPhase           |
///    | BonusResourceBaseAmount   |       |      |                           |
///    | BonusResources            |       |      | HarvestResourceBaseAmount |
///    |                           |       |      | BonusResourceBaseAmount   |
///    | +ReapBonusResources       |       |      | HarvestSkill              |
///    +---------------------------+       |      |                           |
///                                        |      | PhaseResources            |
///                                        |      | BonusResources            |
///                                        +-----+| BaseAssetSets             |
///                                               |                           |
///                                               | +Construct                |
///                                               | +TearDown                 |
///                                               | +Harvest                  |
///                                               | +Grow                     |
///                                               |                           |
///                                               | +ReapResource             |
///                                               | +ReapBonusResources       |
///                                               |                           |
///                                               | +LookupOriginLocation     |
///                                               | +LookupAsset              |
///                                               | +LookupPhase              |
///                                               | +LookupStaticHue          |
///                                               | +LookupStaticTile         |
///                                               |                           |
///                                               +---------------------------+
///  
///                              Grow                     Grow                      Grow
///  
///           +----------------+       +----------------+       +-----------------+      +-----------------+
///           | SaplingPhase1  +------>| SaplingPhase2  +------>| GrownTreePhase1 +----->| GrownTreePhase2 |
///           +----------------+       +----------------+       +-----------------+      +-----------------+
///  
///  
///                             Harvest                   Harvest
///  
///           +-----------------+      +------------------+      +------------------+
///           | GrownTreePhase2 +----->| FallenTreePhase1 +----->| FallenTreePhase2 +-------+
///           +-----------------+      +------------------+      +------------------+       |
///                                                                       ^                 |
///                                                                       |     Harvest     |
///                                                                       |                 |
///                                                                       +-----------------+
///      
///                           +----------------------+
///                           | BaseHarvestablePhase |
///                           +----------------------+
///                                       ^ ^
///                                       | |
///                                       | +-----------------------------------------------------------------+
///                                       |                                                                   |
///                             +---------+--------+                                               +---------------------+
///                             | TreeHarvestPhase |                                               | RockMiningBasePhase |
///                             +------------------+                                               +---------------------+
///                                     ^ ^ ^                                                                 ^  ^
///                                     | | |                                                                 |  |
///                                     | | |                                                                 |  +--------------+
///                                     | | |                                                                 |                 |
///            +------------------------+ | +--------------------------+                               +------+------+  +-------+-------+
///            |                          |                            |                               | MoltenPhase |  | HardenedPhase |
///   +--------+---------+      +---------+----------+       +---------+-------+                       +-------------+  +---------------+
///   | SaplingTreePhase |      | FullGrownTreePhase |       | FallenTreePhase |                                              ^ ^
///   +------------------+      +--------------------+       +-----------------+                                              | |
///                                       ^                            ^  ^                                    +--------------+ |
///                                       |                            |  |                                    |                |
///                               +-------+--------+                   |  +--------------+                +----+-----+    +-----+------+
///                               | SmallTreePhase |                   |                 |                | GoldVein |    | CopperVein |
///                               +----------------+         +---------+-------+ +---------------+        +----------+    +------------+
///                                     ^ ^ ^                | SmallFallenTree | | FallenOakTree |
///                                     | | |                +-----------------+ +---------------+
///                                     | | |
///                         +-----------+ | +------------+
///                         |             |              |
///                   +-----+-----+ +-----+-----+ +------+-----+
///                   | OakTree   | | CedarTree | | WalnutTree |
///                   +-----------+ +-----------+ +------------+ 

#endregion

namespace Server.Engine.Facet.Module.LumberHarvest
{
	public class FacetModule_Lumberjacking : HarvestSystem
	{

		//List contains an entry for each map, each entry contains all the locations where trees have been chopped down
		public static Dictionary<int, Dictionary<Point3D, int>> RegrowthMasterLookupTable = new Dictionary<int, Dictionary<Point3D, int>>();
		public static DateTime LastGrowth = DateTime.UtcNow;


		//This is the minimum time between regrowths, but the regrowths will only happen on world saves
		public static TimeSpan TimeBetweenRegrowth = TimeSpan.FromMinutes(1);

		public static void Initialize()
		{

			List<int> tiles = new List<int>(BaseTreeHarvestPhase.MasterHarvestablePhaseLookupByItemIdList.Keys); /// Server.Engine.Facet.Module.LumberHarvest.BaseTreeHarvestPhase.MasterHarvestablePhaseLookupByItemIdList.Keys
			for (int i = 0; i < tiles.Count; ++i)
			{
				tiles[i] += 0x4000;
			}

			int[] tileNums = tiles.ToArray();
			Array.Sort(tileNums);
			HarvestDefinition lumber = new HarvestDefinition();
			lumber.Tiles = tileNums;

			// Players must be within 2 tiles to harvest
			lumber.MaxRange = 2;

			// Skill checking is done on the Lumberjacking skill
			lumber.Skill = SkillName.Lumberjacking;

			// The chopping effect
			lumber.EffectActions = new int[] { 13 };
			lumber.EffectSounds = new int[] { 0x13E };
			lumber.EffectCounts = (Core.AOS ? new int[] { 1 } : new int[] { 1, 2, 2, 2, 3 });
			lumber.EffectDelay = TimeSpan.FromSeconds(1.6);
			lumber.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

			lumber.NoResourcesMessage = 500493; // There's not enough wood here to harvest.
			lumber.FailMessage = 500495; // You hack at the tree for a while, but fail to produce any useable wood.
			lumber.OutOfRangeMessage = 500446; // That is too far away.
			lumber.PackFullMessage = 500497; // You can't place any wood into your backpack!
			lumber.ToolBrokeMessage = 500499; // You broke your axe.

			//not used
			lumber.RaceBonus = Core.ML;
			lumber.RandomizeVeins = Core.ML;
			lumber.BankWidth = 4;
			lumber.BankHeight = 3;
			lumber.MinTotal = 20;
			lumber.MaxTotal = 45;
			lumber.Resources = new HarvestResource[] { new HarvestResource(00.0, 00.0, 100.0, 500498, typeof(Log)) };
			lumber.BonusResources = new BonusHarvestResource[] { new BonusHarvestResource(0, 83.9, null, null) };
			lumber.Veins = new HarvestVein[] { new HarvestVein(49.0, 0.0, lumber.Resources[0], null) };
			System.Definitions.Add(lumber);
		}

		public static void Configure()
		{
			foreach (Map m in Map.AllMaps)
			{
				RegrowthMasterLookupTable.Add(m.MapID, new Dictionary<Point3D, int>());
			}

			EventSink.WorldSave += new WorldSaveEventHandler(OnSave);
			EventSink.WorldLoad += new WorldLoadEventHandler(OnLoad);
		}

		public static void OnLoad()
		{
			for (int mapId = 0; mapId < RegrowthMasterLookupTable.Count; ++mapId)
			{
				string filename = Path.Combine(FacetEditingSettings.LumberHarvestFallenTreeSaveLocation, "TreeLocations." + mapId);
				FileInfo treeFileInfo = new FileInfo(filename);

				if (treeFileInfo.Exists)
				{
					using (FileStream fs = new FileStream(filename, FileMode.Open))
					{
						using (BinaryReader br = new BinaryReader(fs))
						{
							GenericReader reader = new BinaryFileReader(br);

							while (fs.Position < fs.Length)
							{
								Point3D p = reader.ReadPoint3D();
								int itemId = reader.ReadInt();
								if (!RegrowthMasterLookupTable[mapId].ContainsKey(p))
								{
									RegrowthMasterLookupTable[mapId].Add(p, itemId);
								}
							}
						}
					}
				}
			}
		}

		public static void OnSave(WorldSaveEventArgs e)
		{
			if (!Directory.Exists(FacetEditingSettings.LumberHarvestFallenTreeSaveLocation))
			{
				Directory.CreateDirectory(FacetEditingSettings.LumberHarvestFallenTreeSaveLocation);
			}

			bool updateRegrowthTime = false;

			//foreach map in the lookup table
			foreach (Map m in Map.AllMaps)
			{
				if (RegrowthMasterLookupTable.ContainsKey(m.MapID))
				{
					#region Regrowth
					if (DateTime.UtcNow > LastGrowth + TimeBetweenRegrowth)
					{
						updateRegrowthTime = true;
						Dictionary<Point3D, int> mapLookupTable = RegrowthMasterLookupTable[m.MapID];
						MapOperationSeries mapOperations = null;

						List<Point3D> locationsToRemove = new List<Point3D>();

						//for each tree location in the lookup table
						foreach (KeyValuePair<Point3D, int> treeLocationKvp in mapLookupTable)
						{
							if (BaseHarvestablePhase.MasterHarvestablePhaseLookupByItemIdList.ContainsKey(treeLocationKvp.Value))
							{
								//look up the current phase
								bool existingTileFound = false;
								foreach (StaticTile tile in m.Tiles.GetStaticTiles(treeLocationKvp.Key.X, treeLocationKvp.Key.Y))
								{
									if (tile.Z == treeLocationKvp.Key.Z) // if the z altitude matches
									{
										if (BaseHarvestablePhase.MasterHarvestablePhaseLookupByItemIdList.ContainsKey(tile.ID)) //if the item id is linked to a phase
										{

											BaseHarvestablePhase currentPhase = BaseHarvestablePhase.MasterHarvestablePhaseLookupByItemIdList[tile.ID];

											foreach (GraphicAsset[] assetSet in currentPhase.BaseAssetSets)
											{
												if (assetSet.Length > 0 && assetSet[0].ItemID == tile.ID)
												{
													existingTileFound = true;
												}
											}

											if (existingTileFound && !currentPhase.grow(treeLocationKvp.Key, m, ref mapOperations))
											{
												locationsToRemove.Add(treeLocationKvp.Key);
											}

											break;
										}
									}
								}

								//nothing to grow at this location, so construct the starting phase
								if (!existingTileFound)
								{
									//lookup original phase that was saved
									BaseHarvestablePhase grownPhase = BaseHarvestablePhase.MasterHarvestablePhaseLookupByItemIdList[treeLocationKvp.Value];

									//cleanup final harvest graphics
									if (grownPhase.FinalHarvestPhase != null && BaseHarvestablePhase.MasterHarvestablePhaseLookupByTypeList.ContainsKey(grownPhase.FinalHarvestPhase))
									{
										BaseHarvestablePhase.MasterHarvestablePhaseLookupByTypeList[grownPhase.FinalHarvestPhase].Teardown(treeLocationKvp.Key, m, ref mapOperations);
									}

									if (grownPhase.StartingGrowthPhase != null && BaseHarvestablePhase.MasterHarvestablePhaseLookupByTypeList.ContainsKey(grownPhase.StartingGrowthPhase))
									{
										//remove stump
										BaseTreeHarvestPhase maturePhase = grownPhase as BaseTreeHarvestPhase;
										if (maturePhase != null)
										{
											if (mapOperations != null)
											{
												mapOperations.Add(new DeleteStatic(m.MapID, new StaticTarget(treeLocationKvp.Key, maturePhase.StumpGraphic)));
											}
											else
											{
												mapOperations = new MapOperationSeries(new DeleteStatic(m.MapID, new StaticTarget(treeLocationKvp.Key, maturePhase.StumpGraphic)), m.MapID);
											}
										}

										BaseHarvestablePhase.MasterHarvestablePhaseLookupByTypeList[grownPhase.StartingGrowthPhase].Construct(treeLocationKvp.Key, m, ref mapOperations);
									}
								}
							}
						}

						if (mapOperations != null)
						{
							mapOperations.DoOperation();
						}

						foreach (Point3D p in locationsToRemove)
						{
							RegrowthMasterLookupTable[m.MapID].Remove(p);
						}
					}
					#endregion

					GenericWriter writer = new BinaryFileWriter(Path.Combine(FacetEditingSettings.LumberHarvestFallenTreeSaveLocation, "TreeLocations." + m.MapID), true);

					foreach (KeyValuePair<Point3D, int> kvp in RegrowthMasterLookupTable[m.MapID])
					{
						writer.Write(kvp.Key);
						writer.Write(kvp.Value);
					}
					writer.Close();
				}
			}

			if (updateRegrowthTime)
			{
				LastGrowth = DateTime.UtcNow;
			}
		}

		private static FacetModule_Lumberjacking m_System;

		public static FacetModule_Lumberjacking System
		{
			get
			{
				if (m_System == null)
					m_System = new FacetModule_Lumberjacking();

				return m_System;
			}
		}

		public override void FinishHarvesting(Mobile from, Item tool, HarvestDefinition def, object toHarvest, object locked)
		{
			from.EndAction(locked);

			if (!CheckHarvest(from, tool))
				return;

			int tileID;
			Map map;
			Point3D loc;

			if (!GetHarvestDetails(from, tool, toHarvest, out tileID, out map, out loc))
			{
				OnBadHarvestTarget(from, tool, toHarvest);
				return;
			}
			else if (!def.Validate(tileID))
			{
				OnBadHarvestTarget(from, tool, toHarvest);
				return;
			}

			if (!CheckRange(from, tool, def, map, loc, true))
				return;
			else if (!CheckHarvest(from, tool, def, toHarvest))
				return;

			double skillBase = from.Skills[def.Skill].Base;
			double skillValue = from.Skills[def.Skill].Value;

			StaticTarget harvestTarget = toHarvest as StaticTarget;

			if (harvestTarget != null)
			{
				if (from.CheckSkill(def.Skill, 0, 120))
				{
					if (tool is IUsesRemaining)
					{
						IUsesRemaining toolWithUses = (IUsesRemaining)tool;

						toolWithUses.ShowUsesRemaining = true;

						if (toolWithUses.UsesRemaining > 0)
						{
							--toolWithUses.UsesRemaining;
						}
						if (toolWithUses.UsesRemaining < 1)
						{
							tool.Delete();
							def.SendMessageTo(from, def.ToolBrokeMessage);
						}
					}
				}

				BaseHarvestablePhase hTreePhase = BaseHarvestablePhase.LookupPhase(harvestTarget.ItemID);

				if (hTreePhase != null && hTreePhase is BaseTreeHarvestPhase)
				{
					hTreePhase.Harvest(from, harvestTarget.ItemID, harvestTarget.Location, map);
				}
			}
		}
	}

	public class GraphicAsset
	{
		public int ItemID;
		public Int16 XOffset;
		public Int16 YOffset;
		public int HarvestResourceBaseAmount = 0;
		public int BonusResourceBaseAmount = 0;

		//Graphics are linked to bonus resources only. Regular harvest resources should be assigned at the phase level.
		public Dictionary<int, BonusHarvestResource[]> BonusResources = new Dictionary<int, BonusHarvestResource[]>();

		public GraphicAsset(int itemId, Int16 xOff, Int16 yOff)
		{
			ItemID = itemId;
			XOffset = xOff;
			YOffset = yOff;
		}

		public virtual List<Item> ReapBonusResources(int hue, Mobile from)
		{
			return ReapBonusResources(hue, from, BonusResourceBaseAmount, BonusResources);
		}

		//The bonus resource list can be specified at the phase level by using this overloaded method.
		public static List<Item> ReapBonusResources(int hue, Mobile from, int bonusResourceAmount, Dictionary<int, BonusHarvestResource[]> bonusList)
		{
			List<Item> bonusItems = new List<Item>();
			BonusHarvestResource[] bonusResourceList = null;

			if (bonusResourceAmount > 0)
			{
				if (bonusList.ContainsKey(hue))
				{
					bonusResourceList = bonusList[hue];
				}
				else if (bonusList.ContainsKey(0))
				{
					bonusResourceList = bonusList[0];
				}

				if (bonusResourceList != null && bonusResourceList.Length > 0)
				{
					double skillBase = from.Skills[SkillName.Lumberjacking].Base;

					foreach (BonusHarvestResource resource in bonusResourceList)
					{
						if (skillBase >= resource.ReqSkill && Utility.RandomDouble() <= resource.Chance)
						{
							try
							{
								Item item = Activator.CreateInstance(resource.Type) as Item;
								if (item != null)
								{
									item.Amount = bonusResourceAmount;
									bonusItems.Add(item);
								}
							}
							catch
							{
								Console.WriteLine("exception caught when trying to create bonus resource");
							}
						}
					}
				}
			}

			return bonusItems;
		}
	}

	/// Life Cycle Phases
	public class BaseLeafHandlingPhase : BaseTreeHarvestPhase
	{
		public const int FALLING_LEAF_HUE = 1436;

		public BaseLeafHandlingPhase()
		  : base()
		{
		}

		public override bool Harvest(Mobile from, int itemId, Point3D harvestTargetLocation, Map map)
		{
			Point3D trunkLocation = LookupOriginLocation(harvestTargetLocation, itemId);

			//search for leaves
			MapOperationSeries mapActions = null;
			List<KeyValuePair<int, GraphicAsset>> leavesRemoved = RemoveAssets(map, trunkLocation, ref mapActions, LeafSets);

			if (mapActions != null)
			{
				//handle falling leaves

				int numLeaves = Utility.Random(5);
				Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(trunkLocation.X, trunkLocation.Y, trunkLocation.Z + 20), map),
						  new Entity(Serial.Zero, new Point3D(trunkLocation.X, trunkLocation.Y, trunkLocation.Z), map),
						  0x1B1F, 1, 0, false, false, FALLING_LEAF_HUE, 0, 0, 1, 0, EffectLayer.Waist, 0x486);

				for (int i = 0; i < numLeaves + 9; i++)
				{
					new FadingLeaf().MoveToWorld(new Point3D(trunkLocation.X + Utility.Random(4) - 2, trunkLocation.Y + Utility.Random(4) - 2, trunkLocation.Z), map);
					Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(trunkLocation.X + Utility.Random(4) - 2, trunkLocation.Y + Utility.Random(4) - 2, trunkLocation.Z + 20), map),
									  new Entity(Serial.Zero, new Point3D(trunkLocation.X + Utility.Random(4) - 2, trunkLocation.Y + Utility.Random(4) - 2, trunkLocation.Z), map),
									  0x1B1F, 1, 0, false, false, FALLING_LEAF_HUE, 0, 0, 1, 0, EffectLayer.Waist, 0x486);
				}

				//give out leaf bonus asset resources
				foreach (KeyValuePair<int, GraphicAsset> assetPair in leavesRemoved)
				{
					foreach (Item itm in assetPair.Value.ReapBonusResources(assetPair.Key, from))
					{
						from.AddToBackpack(itm);
					}
				}
			}
			else //if there are no leaves left, then remove the trunk pieces and call nextPhase.construct
			{
				base.Harvest(from, itemId, harvestTargetLocation, map, ref mapActions);
			}

			if (mapActions != null)
			{
				mapActions.DoOperation();
			}

			return false;
		}
	}

	public class BaseTreeHarvestPhase : BaseHarvestablePhase
	{
		public const int LEAF_HUE = 0;

		public virtual int StumpGraphic { get { return 0xE57; } }
		public virtual bool AddStump { get { return true; } }

		public List<GraphicAsset[]> LeafSets = new List<GraphicAsset[]>();

		public override void RegisterBasicPhaseTiles()
		{
			base.RegisterBasicPhaseTiles();

			//Add all the leaf graphics for this phase
			foreach (GraphicAsset[] leafSet in LeafSets)
			{
				RegisterAssetSet(leafSet);
			}
		}

		public override Point3D LookupOriginLocation(Point3D harvestTargetLocation, int harvestTargetItemId)
		{
			Point3D originLocation = base.LookupOriginLocation(harvestTargetLocation, harvestTargetItemId);

			if (originLocation == Point3D.Zero)
			{
				bool found = false;
				foreach (GraphicAsset[] leafSet in LeafSets)
				{
					foreach (GraphicAsset asset in leafSet)
					{
						if (asset.ItemID == harvestTargetItemId)
						{
							originLocation = new Point3D(harvestTargetLocation.X + asset.XOffset, harvestTargetLocation.Y + asset.YOffset, harvestTargetLocation.Z - TileData.ItemTable[harvestTargetItemId].CalcHeight);
							found = true;
							break;
						}
					}
					if (found)
					{
						break;
					}
				}
			}

			return originLocation;
		}

		public override int Construct(Point3D location, Map map, ref MapOperationSeries mapOperationSeries)
		{
			int trunkHue = base.Construct(location, map, ref mapOperationSeries);

			GraphicAsset[] leafSet = null;

			if (LeafSets != null && LeafSets.Count > 0)
			{
				//leafSet = LeafSets[Utility.Random(LeafSets.Count)];
				leafSet = LeafSets[0];
			}

			if (leafSet != null)
			{
				foreach (GraphicAsset asset in leafSet)
				{
					//come back and add a usestatic boolean to this class and add it into the constructor too
					AddStatic addStatic = new AddStatic(map.MapID, asset.ItemID, location.Z, location.X + asset.XOffset, location.Y + asset.YOffset, LEAF_HUE);
					if (mapOperationSeries == null)
					{
						mapOperationSeries = new MapOperationSeries(addStatic, map.MapID);
					}
					else
					{
						mapOperationSeries.Add(addStatic);
					}
				}
			}

			return trunkHue;
		}

		public override void Teardown(Point3D originLocation, Map map, ref MapOperationSeries mapActions)
		{
			base.Teardown(originLocation, map, ref mapActions);
			List<KeyValuePair<int, GraphicAsset>> leavesRemoved = RemoveAssets(map, originLocation, ref mapActions, LeafSets);
		}

		public override bool Harvest(Mobile from, int itemId, Point3D harvestTargetLocation, Map map)
		{
			bool successfulHarvest = false;
			MapOperationSeries mapActions = null;

			successfulHarvest = Harvest(from, itemId, harvestTargetLocation, map, ref mapActions);

			if (mapActions != null)
			{
				mapActions.DoOperation();
			}
			return successfulHarvest;
		}


		//This only gets called if the NextHarvestPhase is not null
		public virtual void RecordTreeLocationAndGraphic(int mapId, int itemId, Point3D trunkLocation)
		{
			if (!FacetModule_Lumberjacking.RegrowthMasterLookupTable.ContainsKey(mapId))
			{
				FacetModule_Lumberjacking.RegrowthMasterLookupTable.Add(mapId, new Dictionary<Point3D, int>());
			}

			if (!FacetModule_Lumberjacking.RegrowthMasterLookupTable[mapId].ContainsKey(trunkLocation))
			{
				FacetModule_Lumberjacking.RegrowthMasterLookupTable[mapId].Add(trunkLocation, itemId);
			}
			else
			{
				FacetModule_Lumberjacking.RegrowthMasterLookupTable[mapId][trunkLocation] = itemId;
			}
		}

		public bool Harvest(Mobile from, int itemId, Point3D harvestTargetLocation, Map map, ref MapOperationSeries operationSeries)
		{
			Point3D trunkLocation = LookupOriginLocation(harvestTargetLocation, itemId);

			List<KeyValuePair<int, GraphicAsset>> phasePiecesRemoved = null;

			//If the next phase is not null, tear it all down and construct the next phase
			if (NextHarvestPhase != null)
			{
				phasePiecesRemoved = RemoveAssets(map, trunkLocation, ref operationSeries, BaseAssetSets);
				int constructedTreeHue = 0;

				if (MasterHarvestablePhaseLookupByTypeList.ContainsKey(NextHarvestPhase))
				{
					constructedTreeHue = MasterHarvestablePhaseLookupByTypeList[NextHarvestPhase].Construct(trunkLocation, map, ref operationSeries);
				}

				if (operationSeries != null)
				{
					RecordTreeLocationAndGraphic(map.MapID, BaseAssetSets[0][0].ItemID, trunkLocation);

					if (AddStump)
					{
						operationSeries.Add(new AddStatic(map.MapID, StumpGraphic, trunkLocation.Z, trunkLocation.X, trunkLocation.Y, constructedTreeHue));
					}
				}

			}
			else //the next phase is not null, so destroy one asset at a time
			{
				GraphicAsset asset = LookupAsset(itemId);
				List<GraphicAsset[]> assetsToRemove = new List<GraphicAsset[]>();
				assetsToRemove.Add(new GraphicAsset[] { asset });
				phasePiecesRemoved = RemoveAssets(map, trunkLocation, ref operationSeries, assetsToRemove);
			}

			int hue = 0;

			//give out phase resource for each graphic asset removed
			foreach (KeyValuePair<int, GraphicAsset> assetPair in phasePiecesRemoved)
			{
				hue = assetPair.Key;

				Item itm = this.ReapResource(assetPair.Key, from, assetPair.Value.HarvestResourceBaseAmount);

				if (itm != null)
				{
					from.AddToBackpack(itm);
				}
			}

			//give out asset bonus resources
			foreach (Item itm in this.ReapBonusResources(hue, from))
			{
				from.AddToBackpack(itm);
			}

			bool returnValue = false;

			if (operationSeries != null)
			{
				returnValue = true;
			}

			return returnValue;
		}
	}

	public abstract class BaseHarvestablePhase
	{
		public const int STATIC_TILE_SEARCH_Z_TOLERANCE = 5;
		public virtual Type FinalHarvestPhase { get { return null; } }
		public virtual Type StartingGrowthPhase { get { return null; } }
		public virtual Type NextHarvestPhase { get { return null; } }
		public virtual Type NextGrowthPhase { get { return null; } }
		public virtual bool ConstructUsingHues { get { return false; } }
		public virtual int HarvestResourceBaseAmount { get { return 0; } }
		public virtual int BonusResourceBaseAmount { get { return 0; } }
		public virtual SkillName HarvestSkill { get { return SkillName.Lumberjacking; } }

		public Dictionary<int, HarvestResource> PhaseResources = new Dictionary<int, HarvestResource>();
		public Dictionary<int, BonusHarvestResource[]> BonusResources = new Dictionary<int, BonusHarvestResource[]>();
		public List<GraphicAsset[]> BaseAssetSets = new List<GraphicAsset[]>();

		public BaseHarvestablePhase()
		{
		}

		/// Registration and Asset Lookup
		public static Dictionary<int, GraphicAsset> MasterHarvestableAssetlookup = new Dictionary<int, GraphicAsset>();
		public static Dictionary<int, BaseHarvestablePhase> MasterHarvestablePhaseLookupByItemIdList = new Dictionary<int, BaseHarvestablePhase>();
		public static Dictionary<Type, BaseHarvestablePhase> MasterHarvestablePhaseLookupByTypeList = new Dictionary<Type, BaseHarvestablePhase>();

		public static bool RegisterHarvestablePhase(BaseHarvestablePhase phase)
		{
			bool alreadyRegistered = true;
			if (!MasterHarvestablePhaseLookupByTypeList.ContainsKey(phase.GetType()))
			{
				MasterHarvestablePhaseLookupByTypeList.Add(phase.GetType(), phase);
				alreadyRegistered = false;
				phase.RegisterBasicPhaseTiles();

				//send out update tiles event
				if (UpdatedTilesEvent != null)
				{
					List<int> tiles = new List<int>(BaseTreeHarvestPhase.MasterHarvestablePhaseLookupByItemIdList.Keys); /// Server.Engine.Facet.Module.LumberHarvest.BaseTreeHarvestPhase.MasterHarvestablePhaseLookupByItemIdList.Keys
					UpdatedTilesEvent(tiles.ToArray());
				}
			}
			else
			{
				Console.WriteLine("NOT Registering " + phase.GetType());
			}

			return alreadyRegistered;
		}

		public delegate void UpdateTilesEventHandler(int[] newTiles);
		public static event UpdateTilesEventHandler UpdatedTilesEvent;

		public virtual void RegisterAssetSet(GraphicAsset[] assetSet)
		{
			foreach (GraphicAsset treeAsset in assetSet)
			{
				if (!MasterHarvestablePhaseLookupByItemIdList.ContainsKey(treeAsset.ItemID))
				{
					MasterHarvestablePhaseLookupByItemIdList.Add(treeAsset.ItemID, this);
				}
				else
				{
					Console.WriteLine(this.GetType().ToString() + " tried to add a graphic 0x" + treeAsset.ItemID.ToString("X") + " to the MasterHarvestablePhaseLookupByItemIdList table that is already in use.");
				}

				if (!MasterHarvestableAssetlookup.ContainsKey(treeAsset.ItemID))
				{
					MasterHarvestableAssetlookup.Add(treeAsset.ItemID, treeAsset);
				}
				else
				{
					Console.WriteLine(this.GetType().ToString() + " tried to add a graphic 0x" + treeAsset.ItemID.ToString("X") + " to the MasterHarvestableAssetlookup table that is already in use.");
				}

			}
		}

		public virtual void RegisterBasicPhaseTiles()
		{
			//Add all the trunk graphics for this phase
			foreach (GraphicAsset[] assetSet in BaseAssetSets)
			{
				RegisterAssetSet(assetSet);
			}
		}

		/// Lookups
		public virtual Point3D LookupOriginLocation(Point3D harvestTargetLocation, int harvestTargetItemId)
		{
			Point3D trunkLocation = Point3D.Zero;

			bool found = false;

			foreach (GraphicAsset[] trunkSet in BaseAssetSets)
			{
				foreach (GraphicAsset asset in trunkSet)
				{
					if (asset.ItemID == harvestTargetItemId)
					{
						trunkLocation = new Point3D(harvestTargetLocation.X - asset.XOffset, harvestTargetLocation.Y - asset.YOffset, harvestTargetLocation.Z - TileData.ItemTable[harvestTargetItemId].CalcHeight);
						found = true;
						break;
					}
				}

				if (found)
				{
					break;
				}
			}

			return trunkLocation;
		}

		public static GraphicAsset LookupAsset(int itemId)
		{
			GraphicAsset asset = null;

			if (MasterHarvestableAssetlookup.ContainsKey(itemId))
			{
				asset = MasterHarvestableAssetlookup[itemId];
			}

			return asset;
		}

		public static BaseHarvestablePhase LookupPhase(int itemId)
		{
			BaseHarvestablePhase phase = null;

			if (MasterHarvestablePhaseLookupByItemIdList.ContainsKey(itemId))
			{
				phase = MasterHarvestablePhaseLookupByItemIdList[itemId];
			}

			return phase;
		}

		public static int LookupStaticHue(Map map, Point3D staticLocation, int itemId)
		{
			int hue = 0;
			foreach (StaticTile tile in map.Tiles.GetStaticTiles(staticLocation.X, staticLocation.Y))
			{
				if (tile.Z >= staticLocation.Z - STATIC_TILE_SEARCH_Z_TOLERANCE && tile.Z <= staticLocation.Z + STATIC_TILE_SEARCH_Z_TOLERANCE)
				{
					if (tile.ID == itemId)
					{
						hue = tile.Hue;

						continue;
					}
				}
			}
			return hue;
		}

		public static bool LookupStaticTile(Map map, Point3D staticLocation, int itemId, ref StaticTile tileResult)
		{
			bool found = false;

			foreach (StaticTile tile in map.Tiles.GetStaticTiles(staticLocation.X, staticLocation.Y))
			{
				if (tile.Z >= staticLocation.Z - STATIC_TILE_SEARCH_Z_TOLERANCE && tile.Z <= staticLocation.Z + STATIC_TILE_SEARCH_Z_TOLERANCE)
				{
					if (tile.ID == itemId)
					{
						tileResult = tile;
						found = true;
						continue;
					}
				}
			}
			return found;
		}

		/// Construction / Teardown
		public static List<KeyValuePair<int, GraphicAsset>> RemoveAssets(Map map, Point3D trunkLocation, ref MapOperationSeries deleteTreePartsOperationSeries, List<GraphicAsset[]> assetList)
		{
			List<KeyValuePair<int, GraphicAsset>> treePartsRemoved = new List<KeyValuePair<int, GraphicAsset>>();

			foreach (GraphicAsset[] assetSet in assetList)
			{
				foreach (GraphicAsset treeAsset in assetSet)
				{
					int leafX = trunkLocation.X + treeAsset.XOffset;
					int leafY = trunkLocation.Y + treeAsset.YOffset;

					foreach (StaticTile tile in map.Tiles.GetStaticTiles(leafX, leafY))
					{
						if (tile.Z >= trunkLocation.Z - STATIC_TILE_SEARCH_Z_TOLERANCE && tile.Z <= trunkLocation.Z + STATIC_TILE_SEARCH_Z_TOLERANCE)
						{
							if (tile.ID == treeAsset.ItemID)
							{
								Point3D leafLocation = new Point3D(leafX, leafY, tile.Z);

								if (deleteTreePartsOperationSeries == null)
								{
									deleteTreePartsOperationSeries = new MapOperationSeries(new DeleteStatic(map.MapID, new StaticTarget(leafLocation, treeAsset.ItemID)), map.MapID);
								}
								else
								{
									deleteTreePartsOperationSeries.Add(new DeleteStatic(map.MapID, new StaticTarget(leafLocation, treeAsset.ItemID)));
								}

								treePartsRemoved.Add(new KeyValuePair<int, GraphicAsset>(tile.Hue, treeAsset));

								continue;
							}
						}
					}
				}
			}

			return treePartsRemoved;
		}

		public void Construct(Point3D location, Map map)
		{
			MapOperationSeries series = null;
			Construct(location, map, ref series);
			if (series != null)
			{
				series.DoOperation();
			}
		}

		public virtual void onBeforeConstruct(Point3D location, Map map, ref MapOperationSeries mapOperationSeries)
		{
		}

		/*
		 * Return value is the HUE
		 */
		public virtual int Construct(Point3D location, Map map, ref MapOperationSeries mapOperationSeries)
		{
			onBeforeConstruct(location, map, ref mapOperationSeries);

			GraphicAsset[] trunkSet = null;

			if (BaseAssetSets != null && BaseAssetSets.Count > 0)
			{
				trunkSet = BaseAssetSets[Utility.Random(BaseAssetSets.Count)];
			}

			int hue = 0;

			List<int> possibleHues = new List<int>(PhaseResources.Keys);

			if (ConstructUsingHues && possibleHues.Count > 0)
			{
				hue = possibleHues[Utility.Random(possibleHues.Count)];
			}

			if (trunkSet != null)
			{
				foreach (GraphicAsset asset in trunkSet)
				{
					//come back and add a usestatic boolean to this class and add it into the constructor too
					AddStatic addStatic = new AddStatic(map.MapID, asset.ItemID, location.Z, location.X + asset.XOffset, location.Y + asset.YOffset, hue);
					if (mapOperationSeries == null)
					{
						mapOperationSeries = new MapOperationSeries(addStatic, map.MapID);
					}
					else
					{
						mapOperationSeries.Add(addStatic);
					}
				}
			}

			return hue;
		}

		public void Teardown(Point3D originLocation, Map map)
		{
			MapOperationSeries series = null;
			Teardown(originLocation, map, ref series);
			if (series != null)
			{
				series.DoOperation();
			}
		}

		public virtual void Teardown(Point3D originLocation, Map map, ref MapOperationSeries mapActions)
		{
			List<KeyValuePair<int, GraphicAsset>> basePiecesRemoved = RemoveAssets(map, originLocation, ref mapActions, BaseAssetSets);
		}

		/// Resource Reap Methods
		public virtual Item ReapResource(int hue, Mobile from, int amount)
		{
			Item resourceItem = null;
			HarvestResource resource = null;

			if (amount > 0)
			{
				if (PhaseResources.ContainsKey(hue))
				{
					resource = PhaseResources[hue];
				}
				else if (PhaseResources.ContainsKey(0))
				{
					resource = PhaseResources[0];
				}

				if (resource != null)
				{
					double skillBase = from.Skills[HarvestSkill].Base;

					if (skillBase >= resource.ReqSkill)
					{
						try
						{

							Type type = resource.Types[Utility.Random(resource.Types.Length)];
							Item item = Activator.CreateInstance(type) as Item;
							if (item != null)
							{
								item.Amount = amount;
								resourceItem = item;
							}
						}
						catch
						{
							Console.WriteLine("exception caught when trying to create bonus resource");
						}
					}
					else
					{
						//TODO: Inform player they don't have enough skill using a cliloc to do it
						from.SendMessage("you don't have enough skill to harvest that!");
					}
				}
			}

			return resourceItem;
		}

		public virtual List<Item> ReapBonusResources(int hue, Mobile from)
		{
			return GraphicAsset.ReapBonusResources(hue, from, BonusResourceBaseAmount, BonusResources);
		}

		#region Developer Notations

		///     This is the harvest function for a phase.  If a next harvest phase is defined, this function tears down all the assets associated
		///     with the phase and constructs the next growth phase.  It also optionally gives any phase resources out according to the base 
		///     amount specified. It then optionally gives out any bonus resources according to the amount specified.
		///     
		///     If the next harvest phase has not been defined, it removes the asset that was targetted and gives out an amount of phase 
		///     resources specified in the graphic asset. It then gives out any bonus resources associated with the graphic.
		///     
		///                          Harvest                   Harvest
		///     
		///     +-----------------+      +------------------+      +------------------+
		///     | GrownTreePhase2 +----->| FallenTreePhase1 +----->| FallenTreePhase2 +-------+
		///     +-----------------+      +------------------+      +------------------+       |
		///                                                                 ^                 |
		///                                                                 |     Harvest     |
		///                                                                 |                 |
		///                                                                 +-----------------+
		///     
		///     

		#endregion

		public virtual bool Harvest(Mobile from, int itemId, Point3D location, Map map)
		{
			return false;
		}

		#region Developer Notations

		///		This is the growth function for a phase. If a next growth phase is defined, this function tears down all the assets associated with the
		///     phase and constructs the next growth phase. If the next phase has not been defined, this function assumes that the phase has finished  
		///     growing, and does nothing.
		///     
		///                           Grow                     Grow                      Grow                     Grow
		///     
		///        +----------------+       +----------------+       +-----------------+      +-----------------+
		///        | SaplingPhase1  +------>| SaplingPhase2  +------>| GrownTreePhase1 +----->| GrownTreePhase2 |---------->( Stop )
		///        +----------------+       +----------------+       +-----------------+      +-----------------+
		///        
		///     

		#endregion

		public virtual bool Grow(Point3D originLocation, Map map)
		{
			MapOperationSeries series = null;
			bool grew = grow(originLocation, map, ref series);
			if (series != null)
			{
				series.DoOperation();
			}

			return grew;
		}

		public virtual bool grow(Point3D originLocation, Map map, ref MapOperationSeries series)
		{
			bool grew = false;

			if (NextGrowthPhase != null)
			{
				Teardown(originLocation, map, ref series);
				MasterHarvestablePhaseLookupByTypeList[NextGrowthPhase].Construct(originLocation, map); //this is the transition to the next phase
				grew = true;
			}

			return grew;
		}
	}

	/// Fallen Tree Leaves
	public class FadingLeaf : Item
	{
		[Constructable]
		public FadingLeaf() : this(Utility.RandomList(0x1B1F, 0x1B20, 0x1B21, 0x1B22, 0x1B23, 0x1B24, 0x1B25))
		{
		}

		[Constructable]
		public FadingLeaf(int itemID) : base(itemID)
		{
			Movable = false;
			Hue = 1436;
			new InternalTimer(this).Start();
		}

		public FadingLeaf(Serial serial) : base(serial)
		{
			new InternalTimer(this).Start();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}

		private class InternalTimer : Timer
		{
			private Item m_Leaf;

			public InternalTimer(Item leaf) : base(TimeSpan.FromSeconds(5.0))
			{
				Priority = TimerPriority.OneSecond;

				m_Leaf = leaf;
			}

			protected override void OnTick()
			{
				m_Leaf.Delete();
			}
		}
	}

	/// Chopped Fallen Tree
	public class SmallFallenTreeNorthSouth : BaseTreeHarvestPhase
	{
		public static void Configure() { RegisterHarvestablePhase(new SmallFallenTreeNorthSouth()); }

		public SmallFallenTreeNorthSouth()
		{
			HarvestResource logResource = new HarvestResource(00.0, 00.0, 100.0, 1072540, typeof(Log));
			HarvestResource oakResource = new HarvestResource(65.0, 25.0, 105.0, 1072541, typeof(OakLog));
			HarvestResource ashResource = new HarvestResource(80.0, 40.0, 120.0, 1072542, typeof(AshLog));
			HarvestResource yewResource = new HarvestResource(95.0, 55.0, 135.0, 1072543, typeof(YewLog));
			HarvestResource heartwoodResource = new HarvestResource(100.0, 60.0, 140.0, 1072544, typeof(HeartwoodLog));
			HarvestResource bloodwoodResource = new HarvestResource(100.0, 60.0, 140.0, 1072545, typeof(BloodwoodLog));
			HarvestResource frostwoodResource = new HarvestResource(100.0, 60.0, 140.0, 1072546, typeof(FrostwoodLog));

			PhaseResources.Add(0, logResource);
			PhaseResources.Add(350, oakResource);
			PhaseResources.Add(751, ashResource);
			PhaseResources.Add(545, yewResource);
			PhaseResources.Add(436, heartwoodResource);
			PhaseResources.Add(339, bloodwoodResource);
			PhaseResources.Add(688, frostwoodResource);

			GraphicAsset asset1 = new GraphicAsset(0xCF4, 0, -1);
			asset1.HarvestResourceBaseAmount = 10;

			GraphicAsset asset2 = new GraphicAsset(0xCF3, 0, -2);
			asset2.HarvestResourceBaseAmount = 10;

			BaseAssetSets.Add(new GraphicAsset[] { asset1, asset2 });
		}
	}

	public class SmallFallenTreeEastWest : BaseTreeHarvestPhase
	{
		public static void Configure() { RegisterHarvestablePhase(new SmallFallenTreeEastWest()); }

		public SmallFallenTreeEastWest()
		{
			HarvestResource logResource = new HarvestResource(00.0, 00.0, 100.0, 1072540, typeof(Log));
			HarvestResource oakResource = new HarvestResource(65.0, 25.0, 105.0, 1072541, typeof(OakLog));
			HarvestResource ashResource = new HarvestResource(80.0, 40.0, 120.0, 1072542, typeof(AshLog));
			HarvestResource yewResource = new HarvestResource(95.0, 55.0, 135.0, 1072543, typeof(YewLog));
			HarvestResource heartwoodResource = new HarvestResource(100.0, 60.0, 140.0, 1072544, typeof(HeartwoodLog));
			HarvestResource bloodwoodResource = new HarvestResource(100.0, 60.0, 140.0, 1072545, typeof(BloodwoodLog));
			HarvestResource frostwoodResource = new HarvestResource(100.0, 60.0, 140.0, 1072546, typeof(FrostwoodLog));

			PhaseResources.Add(0, logResource);
			PhaseResources.Add(350, oakResource);
			PhaseResources.Add(751, ashResource);
			PhaseResources.Add(545, yewResource);
			PhaseResources.Add(436, heartwoodResource);
			PhaseResources.Add(339, bloodwoodResource);
			PhaseResources.Add(688, frostwoodResource);

			GraphicAsset asset1 = new GraphicAsset(0xCF5, -3, 0);
			asset1.HarvestResourceBaseAmount = 10;

			GraphicAsset asset2 = new GraphicAsset(0xCF6, -2, 0);
			asset2.HarvestResourceBaseAmount = 10;

			GraphicAsset asset3 = new GraphicAsset(0xCF7, -1, 0);
			asset3.HarvestResourceBaseAmount = 10;

			BaseAssetSets.Add(new GraphicAsset[] { asset1, asset2, asset3 });
		}
	}

	/// Tree ReGrowth Phases
	public class SmallSaplingTreePhase1 : BaseTreeHarvestPhase
	{
		public override bool AddStump { get { return false; } }
		public static void Configure() { RegisterHarvestablePhase(new SmallSaplingTreePhase1()); }
		public override Type NextGrowthPhase { get { return typeof(SmallSaplingTreePhase2); } }
		public override Type StartingGrowthPhase { get { return typeof(SmallSaplingTreePhase1); } }

		public override void RecordTreeLocationAndGraphic(int mapId, int itemId, Point3D trunkLocation)
		{
			//don't record it
		}

		public SmallSaplingTreePhase1()
		  : base()
		{
			BaseAssetSets.Add(new GraphicAsset[] { new GraphicAsset(0xCEA, 0, 0) });
		}
	}

	public class SmallSaplingTreePhase2 : BaseTreeHarvestPhase
	{
		public override bool AddStump { get { return false; } }
		public static void Configure() { RegisterHarvestablePhase(new SmallSaplingTreePhase2()); }
		public override Type StartingGrowthPhase { get { return typeof(SmallSaplingTreePhase1); } }

		public SmallSaplingTreePhase2()
		  : base()
		{
			BaseAssetSets.Add(new GraphicAsset[] { new GraphicAsset(0xCE9, 0, 0) });
		}

		public override void RecordTreeLocationAndGraphic(int mapId, int itemId, Point3D trunkLocation)
		{
			//don't record it, if it gets harvested, we want to leave the original location that was written by the full grown tree
		}

		public override bool grow(Point3D originLocation, Map map, ref MapOperationSeries series)
		{
			bool grew = false;

			if (FacetModule_Lumberjacking.RegrowthMasterLookupTable.ContainsKey(map.MapID))
			{
				Dictionary<Point3D, int> mapRegrowthLookupTable = FacetModule_Lumberjacking.RegrowthMasterLookupTable[map.MapID];

				//if we can't find the original lookup, then we don't grow
				if (mapRegrowthLookupTable.ContainsKey(originLocation))
				{
					Teardown(originLocation, map, ref series);
					int originalItemId = mapRegrowthLookupTable[originLocation];
					MasterHarvestablePhaseLookupByItemIdList[originalItemId].Construct(originLocation, map);
				}
			}

			return grew;
		}
	}
}