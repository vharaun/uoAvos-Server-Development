﻿
using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
	public class ProximitySpawner : Spawner
	{
		private int m_TriggerRange;
		private TextDefinition m_SpawnMessage;
		private bool m_InstantFlag;

		[CommandProperty(AccessLevel.GameMaster)]
		public int TriggerRange
		{
			get => m_TriggerRange;
			set => m_TriggerRange = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public TextDefinition SpawnMessage
		{
			get => m_SpawnMessage;
			set => m_SpawnMessage = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool InstantFlag
		{
			get => m_InstantFlag;
			set => m_InstantFlag = value;
		}

		[Constructable]
		public ProximitySpawner()
		{
		}

		[Constructable]
		public ProximitySpawner(string spawnName)
			: base(spawnName)
		{
		}

		[Constructable]
		public ProximitySpawner(int amount, int minDelay, int maxDelay, int team, int homeRange, string spawnName)
			: base(amount, minDelay, maxDelay, team, homeRange, spawnName)
		{
		}

		[Constructable]
		public ProximitySpawner(int amount, int minDelay, int maxDelay, int team, int homeRange, string spawnName, int triggerRange, string spawnMessage, bool instantFlag)
			: base(amount, minDelay, maxDelay, team, homeRange, spawnName)
		{
			m_TriggerRange = triggerRange;
			m_SpawnMessage = TextDefinition.Parse(spawnMessage);
			m_InstantFlag = instantFlag;
		}

		public ProximitySpawner(int amount, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, List<string> spawnNames)
			: base(amount, minDelay, maxDelay, team, homeRange, spawnNames)
		{
		}

		public ProximitySpawner(int amount, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, List<string> spawnNames, int triggerRange, TextDefinition spawnMessage, bool instantFlag)
			: base(amount, minDelay, maxDelay, team, homeRange, spawnNames)
		{
			m_TriggerRange = triggerRange;
			m_SpawnMessage = spawnMessage;
			m_InstantFlag = instantFlag;
		}

		public override string DefaultName => "Proximity Spawner";

		public override void DoTimer(TimeSpan delay)
		{
			if (!Running)
			{
				return;
			}

			End = DateTime.UtcNow + delay;
		}

		public override void Respawn()
		{
			RemoveSpawned();

			End = DateTime.UtcNow;
		}

		public override void Spawn()
		{
			for (var i = 0; i < SpawnNamesCount; ++i)
			{
				for (var j = 0; j < Count; ++j)
				{
					Spawn(i);
				}
			}
		}

		public override bool CheckSpawnerFull()
		{
			return false;
		}

		public override bool HandlesOnMovement => true;

		public virtual bool ValidTrigger(Mobile m)
		{
			if (m is BaseCreature)
			{
				var bc = (BaseCreature)m;

				if (!bc.Controlled && !bc.Summoned)
				{
					return false;
				}
			}
			else if (!m.Player)
			{
				return false;
			}

			return (m.Alive && !m.IsDeadBondedPet && m.CanBeDamaged() && !m.Hidden);
		}

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			if (!Running)
			{
				return;
			}

			if (IsEmpty && End <= DateTime.UtcNow && m.InRange(GetWorldLocation(), m_TriggerRange) && m.Location != oldLocation && ValidTrigger(m))
			{
				TextDefinition.SendMessageTo(m, m_SpawnMessage);

				DoTimer();
				Spawn();

				if (m_InstantFlag)
				{
					foreach (var spawned in Spawned)
					{
						if (spawned is Mobile)
						{
							((Mobile)spawned).Combatant = m;
						}
					}
				}
			}
		}

		public ProximitySpawner(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_TriggerRange);
			TextDefinition.Serialize(writer, m_SpawnMessage);
			writer.Write(m_InstantFlag);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			m_TriggerRange = reader.ReadInt();
			m_SpawnMessage = TextDefinition.Deserialize(reader);
			m_InstantFlag = reader.ReadBool();
		}
	}
}