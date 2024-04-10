using Server.ContextMenus;
using Server.Engines.Harvest;
using Server.Network;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	public class FishingPole : Item, IHarvestTool, IEngraved
	{
		public virtual HarvestSystem HarvestSystem => Fishing.System;

		IHarvestSystem IHarvestTool.HarvestSystem => HarvestSystem;

		private string m_EngravedText;

		[CommandProperty(AccessLevel.GameMaster)]
		public string EngravedText
		{
			get => m_EngravedText;
			set
			{
				m_EngravedText = value;

				InvalidateProperties();
			}
		}

		[Constructable]
		public FishingPole() 
			: base(0x0DC0)
		{
			Layer = Layer.TwoHanded;
			Weight = 8.0;
		}

		public FishingPole(Serial serial)
			: base(serial)
		{
		}

		public override void AddNameProperty(ObjectPropertyList list)
		{
			base.AddNameProperty(list);

			if (!String.IsNullOrEmpty(EngravedText))
			{
				list.Add(1062613, EngravedText);
			}
		}

		public override void OnDoubleClick(Mobile from)
		{
			var loc = GetWorldLocation();

			if (!from.InLOS(loc) || !from.InRange(loc, 2))
			{
				from.LocalOverheadMessage(MessageType.Regular, 0x3E9, 1019045); // I can't reach that
			}
			else
			{
				HarvestSystem?.BeginHarvesting(from, this);
			}
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			BaseHarvestTool.AddContextMenuEntries(from, this, list, Fishing.System);
		}

		public override bool CheckConflictingLayer(Mobile m, Item item, Layer layer)
		{
			if (base.CheckConflictingLayer(m, item, layer))
			{
				return true;
			}

			if (layer == Layer.OneHanded)
			{
				m.SendLocalizedMessage(500214); // You already have something in both hands.
				return true;
			}

			return false;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version

			writer.Write(m_EngravedText);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			m_EngravedText = reader.ReadString();

			if (version < 1 && Layer == Layer.OneHanded)
			{
				Layer = Layer.TwoHanded;
			}
		}
	}
}