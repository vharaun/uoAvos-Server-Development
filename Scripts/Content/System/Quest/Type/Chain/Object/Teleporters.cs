using Server.Engines.ChainQuests;
using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Items
{
	public class ChainQuestTeleporter : Teleporter
	{
		private Type m_QuestType;
		private TextDefinition m_Message;

		[CommandProperty(AccessLevel.GameMaster)]
		public Type QuestType
		{
			get => m_QuestType;
			set { m_QuestType = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public TextDefinition Message
		{
			get => m_Message;
			set => m_Message = value;
		}

		[Constructable]
		public ChainQuestTeleporter()
			: this(Point3D.Zero, null, null, null)
		{
		}

		[Constructable]
		public ChainQuestTeleporter(Point3D pointDest, Map mapDest)
			: this(pointDest, mapDest, null, null)
		{
		}

		[Constructable]
		public ChainQuestTeleporter(Point3D pointDest, Map mapDest, Type questType, TextDefinition message)
			: base(pointDest, mapDest)
		{
			m_QuestType = questType;
			m_Message = message;
		}

		public override bool CanTeleport(Mobile m)
		{
			if (!base.CanTeleport(m))
			{
				return false;
			}

			if (m_QuestType != null)
			{
				var pm = m as PlayerMobile;

				if (pm == null)
				{
					return false;
				}

				var context = ChainQuestSystem.GetContext(pm);

				if (context == null || (!context.IsDoingQuest(m_QuestType) && !context.HasDoneQuest(m_QuestType)))
				{
					TextDefinition.SendMessageTo(m, m_Message);
					return false;
				}
			}

			return true;
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (m_QuestType != null)
			{
				list.Add(String.Format("Required quest: {0}", m_QuestType.Name));
			}
		}

		public ChainQuestTeleporter(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write((m_QuestType != null) ? m_QuestType.FullName : null);
			TextDefinition.Serialize(writer, m_Message);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			var typeName = reader.ReadString();

			if (typeName != null)
			{
				m_QuestType = ScriptCompiler.FindTypeByFullName(typeName, false);
			}

			m_Message = TextDefinition.Deserialize(reader);
		}
	}

	public interface ITicket
	{
		void OnTicketUsed(Mobile from);
	}

	public class TicketTeleporter : Teleporter
	{
		private Type m_TicketType;
		private TextDefinition m_Message;

		[CommandProperty(AccessLevel.GameMaster)]
		public Type TicketType
		{
			get => m_TicketType;
			set { m_TicketType = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public TextDefinition Message
		{
			get => m_Message;
			set => m_Message = value;
		}

		[Constructable]
		public TicketTeleporter()
			: this(Point3D.Zero, null, null, null)
		{
		}

		[Constructable]
		public TicketTeleporter(Point3D pointDest, Map mapDest)
			: this(pointDest, mapDest, null, null)
		{
		}

		[Constructable]
		public TicketTeleporter(Point3D pointDest, Map mapDest, Type ticketType, TextDefinition message)
			: base(pointDest, mapDest)
		{
			m_TicketType = ticketType;
			m_Message = message;
		}

		public override bool CanTeleport(Mobile m)
		{
			if (!base.CanTeleport(m))
			{
				return false;
			}

			if (m_TicketType != null)
			{
				Item ticket = null;
				var pack = m.Backpack;

				if (pack != null)
				{
					ticket = pack.FindItemByType(m_TicketType, false); // Check (top level) backpack
				}

				if (ticket == null)
				{
					foreach (var item in m.Items) // Check paperdoll
					{
						if (m_TicketType.IsAssignableFrom(item.GetType()))
						{
							ticket = item;
							break;
						}
					}
				}

				if (ticket == null)
				{
					TextDefinition.SendMessageTo(m, m_Message);
					return false;
				}

				if (ticket is ITicket)
				{
					((ITicket)ticket).OnTicketUsed(m);
				}
			}

			return true;
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (m_TicketType != null)
			{
				list.Add(String.Format("Required ticket: {0}", m_TicketType.Name));
			}
		}

		public TicketTeleporter(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write((m_TicketType != null) ? m_TicketType.FullName : null);
			TextDefinition.Serialize(writer, m_Message);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			var typeName = reader.ReadString();

			if (typeName != null)
			{
				m_TicketType = ScriptCompiler.FindTypeByFullName(typeName, false);
			}

			m_Message = TextDefinition.Deserialize(reader);
		}
	}
}