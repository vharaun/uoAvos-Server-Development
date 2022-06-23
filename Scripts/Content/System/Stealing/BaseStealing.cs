using Server.Commands;

using System;
using System.Collections;

namespace Server.Items
{
	public partial class StealableSpawner : Item
	{
		public class StealableEntry
		{
			private readonly Map m_Map;
			private Point3D m_Location;
			private readonly int m_MinDelay;
			private readonly int m_MaxDelay;
			private readonly Type m_Type;
			private readonly int m_Hue;

			public Map Map => m_Map;
			public Point3D Location => m_Location;
			public int MinDelay => m_MinDelay;
			public int MaxDelay => m_MaxDelay;
			public Type Type => m_Type;
			public int Hue => m_Hue;

			public StealableEntry(Map map, Point3D location, int minDelay, int maxDelay, Type type) : this(map, location, minDelay, maxDelay, type, 0)
			{
			}

			public StealableEntry(Map map, Point3D location, int minDelay, int maxDelay, Type type, int hue)
			{
				m_Map = map;
				m_Location = location;
				m_MinDelay = minDelay;
				m_MaxDelay = maxDelay;
				m_Type = type;
				m_Hue = hue;
			}

			public Item CreateInstance()
			{
				var item = (Item)Activator.CreateInstance(m_Type);

				if (m_Hue > 0)
				{
					item.Hue = m_Hue;
				}

				item.Movable = false;
				item.MoveToWorld(Location, Map);

				return item;
			}
		}

		public static StealableEntry[] Entries => m_Entries;

		private static Type[] m_TypesOfEntries = null;
		public static Type[] TypesOfEntires
		{
			get
			{
				if (m_TypesOfEntries == null)
				{
					m_TypesOfEntries = new Type[m_Entries.Length];

					for (var i = 0; i < m_Entries.Length; i++)
					{
						m_TypesOfEntries[i] = m_Entries[i].Type;
					}
				}

				return m_TypesOfEntries;
			}
		}

		private static StealableSpawner m_Instance;

		public static StealableSpawner Instance => m_Instance;

		private static int GetLampPostHue()
		{
			if (0.9 > Utility.RandomDouble())
			{
				return 0;
			}

			return Utility.RandomList(0x455, 0x47E, 0x482, 0x486, 0x48F, 0x4F2, 0x58C, 0x66C);
		}

		public static void Initialize()
		{
			CommandSystem.Register("GenStealArties", AccessLevel.Administrator, new CommandEventHandler(GenStealArties_OnCommand));
			CommandSystem.Register("RemoveStealArties", AccessLevel.Administrator, new CommandEventHandler(RemoveStealArties_OnCommand));
		}

		[Usage("GenStealArties")]
		[Description("Generates the stealable artifacts spawner.")]
		private static void GenStealArties_OnCommand(CommandEventArgs args)
		{
			var from = args.Mobile;

			if (Create())
			{
				from.SendMessage("Stealable artifacts spawner generated.");
			}
			else
			{
				from.SendMessage("Stealable artifacts spawner already present.");
			}
		}

		[Usage("RemoveStealArties")]
		[Description("Removes the stealable artifacts spawner and every not yet stolen stealable artifacts.")]
		private static void RemoveStealArties_OnCommand(CommandEventArgs args)
		{
			var from = args.Mobile;

			if (Remove())
			{
				from.SendMessage("Stealable artifacts spawner removed.");
			}
			else
			{
				from.SendMessage("Stealable artifacts spawner not present.");
			}
		}

		public static bool Create()
		{
			if (m_Instance != null && !m_Instance.Deleted)
			{
				return false;
			}

			m_Instance = new StealableSpawner();
			return true;
		}

		public static bool Remove()
		{
			if (m_Instance == null)
			{
				return false;
			}

			m_Instance.Delete();
			m_Instance = null;
			return true;
		}

		public static StealableInstance GetStealableInstance(Item item)
		{
			if (Instance == null)
			{
				return null;
			}

			return (StealableInstance)Instance.m_Table[item];
		}

		public class StealableInstance
		{
			private readonly StealableEntry m_Entry;
			private Item m_Item;
			private DateTime m_NextRespawn;

			public StealableEntry Entry => m_Entry;

			public Item Item
			{
				get => m_Item;
				set
				{
					if (m_Item != null && value == null)
					{
						var delay = Utility.RandomMinMax(Entry.MinDelay, Entry.MaxDelay);
						NextRespawn = DateTime.UtcNow + TimeSpan.FromMinutes(delay);
					}

					if (Instance != null)
					{
						if (m_Item != null)
						{
							Instance.m_Table.Remove(m_Item);
						}

						if (value != null)
						{
							Instance.m_Table[value] = this;
						}
					}

					m_Item = value;
				}
			}

			public DateTime NextRespawn
			{
				get => m_NextRespawn;
				set => m_NextRespawn = value;
			}

			public StealableInstance(StealableEntry entry) : this(entry, null, DateTime.UtcNow)
			{
			}

			public StealableInstance(StealableEntry entry, Item item, DateTime nextRespawn)
			{
				m_Item = item;
				m_NextRespawn = nextRespawn;
				m_Entry = entry;
			}

			public void CheckRespawn()
			{
				if (Item != null && (Item.Deleted || Item.Movable || Item.Parent != null))
				{
					Item = null;
				}

				if (Item == null && DateTime.UtcNow >= NextRespawn)
				{
					Item = Entry.CreateInstance();
				}
			}
		}

		private Timer m_RespawnTimer;
		private StealableInstance[] m_Artifacts;
		private Hashtable m_Table;

		public override string DefaultName => "Stealable Artifacts Spawner - Internal";

		private StealableSpawner() : base(1)
		{
			Movable = false;

			m_Artifacts = new StealableInstance[m_Entries.Length];
			m_Table = new Hashtable(m_Entries.Length);

			for (var i = 0; i < m_Entries.Length; i++)
			{
				m_Artifacts[i] = new StealableInstance(m_Entries[i]);
			}

			m_RespawnTimer = Timer.DelayCall(TimeSpan.Zero, TimeSpan.FromMinutes(15.0), CheckRespawn);
		}

		public override void OnDelete()
		{
			base.OnDelete();

			if (m_RespawnTimer != null)
			{
				m_RespawnTimer.Stop();
				m_RespawnTimer = null;
			}

			foreach (var si in m_Artifacts)
			{
				if (si.Item != null)
				{
					si.Item.Delete();
				}
			}

			m_Instance = null;
		}

		public void CheckRespawn()
		{
			foreach (var si in m_Artifacts)
			{
				si.CheckRespawn();
			}
		}

		public StealableSpawner(Serial serial) : base(serial)
		{
			m_Instance = this;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version

			writer.WriteEncodedInt(m_Artifacts.Length);

			for (var i = 0; i < m_Artifacts.Length; i++)
			{
				var si = m_Artifacts[i];

				writer.Write(si.Item);
				writer.WriteDeltaTime(si.NextRespawn);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();

			m_Artifacts = new StealableInstance[m_Entries.Length];
			m_Table = new Hashtable(m_Entries.Length);

			var length = reader.ReadEncodedInt();

			for (var i = 0; i < length; i++)
			{
				var item = reader.ReadItem();
				var nextRespawn = reader.ReadDeltaTime();

				if (i < m_Artifacts.Length)
				{
					var si = new StealableInstance(m_Entries[i], item, nextRespawn);
					m_Artifacts[i] = si;

					if (si.Item != null)
					{
						m_Table[si.Item] = si;
					}
				}
			}

			for (var i = length; i < m_Entries.Length; i++)
			{
				m_Artifacts[i] = new StealableInstance(m_Entries[i]);
			}

			m_RespawnTimer = Timer.DelayCall(TimeSpan.Zero, TimeSpan.FromMinutes(15.0), CheckRespawn);
		}
	}
}