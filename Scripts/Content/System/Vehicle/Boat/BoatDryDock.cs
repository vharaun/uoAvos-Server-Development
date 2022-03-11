using Server.Engines.CannedEvil;
using Server.Gumps;
using Server.Network;
using Server.Regions;
using Server.Targeting;

namespace Server.Multis
{
	public abstract class BaseDockedBoat : Item
	{
		private int m_MultiID;
		private Point3D m_Offset;
		private string m_ShipName;

		[CommandProperty(AccessLevel.GameMaster)]
		public int MultiID { get => m_MultiID; set => m_MultiID = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D Offset { get => m_Offset; set => m_Offset = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public string ShipName { get => m_ShipName; set { m_ShipName = value; InvalidateProperties(); } }

		public BaseDockedBoat(int id, Point3D offset, BaseBoat boat) : base(0x14F4)
		{
			Weight = 1.0;
			LootType = LootType.Blessed;

			m_MultiID = id;
			m_Offset = offset;

			m_ShipName = boat.ShipName;
		}

		public BaseDockedBoat(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version

			writer.Write(m_MultiID);
			writer.Write(m_Offset);
			writer.Write(m_ShipName);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
				case 0:
					{
						m_MultiID = reader.ReadInt();
						m_Offset = reader.ReadPoint3D();
						m_ShipName = reader.ReadString();

						if (version == 0)
						{
							reader.ReadUInt();
						}

						break;
					}
			}

			if (LootType == LootType.Newbied)
			{
				LootType = LootType.Blessed;
			}

			if (Weight == 0.0)
			{
				Weight = 1.0;
			}
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
			}
			else
			{
				from.SendLocalizedMessage(502482); // Where do you wish to place the ship?

				from.Target = new InternalTarget(this);
			}
		}

		public abstract BaseBoat Boat { get; }

		public override void AddNameProperty(ObjectPropertyList list)
		{
			if (m_ShipName != null)
			{
				list.Add(m_ShipName);
			}
			else
			{
				base.AddNameProperty(list);
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			if (m_ShipName != null)
			{
				LabelTo(from, m_ShipName);
			}
			else
			{
				base.OnSingleClick(from);
			}
		}

		public void OnPlacement(Mobile from, Point3D p)
		{
			if (Deleted)
			{
				return;
			}
			else if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
			}
			else
			{
				var map = from.Map;

				if (map == null)
				{
					return;
				}

				var boat = Boat;

				if (boat == null)
				{
					return;
				}

				p = new Point3D(p.X - m_Offset.X, p.Y - m_Offset.Y, p.Z - m_Offset.Z);

				if (BaseBoat.IsValidLocation(p, map) && boat.CanFit(p, map, boat.ItemID) && map != Map.Ilshenar && map != Map.Malas)
				{
					Delete();

					boat.Owner = from;
					boat.Anchored = true;
					boat.ShipName = m_ShipName;

					var keyValue = boat.CreateKeys(from);

					if (boat.PPlank != null)
					{
						boat.PPlank.KeyValue = keyValue;
					}

					if (boat.SPlank != null)
					{
						boat.SPlank.KeyValue = keyValue;
					}

					boat.MoveToWorld(p, map);
				}
				else
				{
					boat.Delete();
					from.SendLocalizedMessage(1043284); // A ship can not be created here.
				}
			}
		}

		private class InternalTarget : MultiTarget
		{
			private readonly BaseDockedBoat m_Model;

			public InternalTarget(BaseDockedBoat model) : base(model.MultiID, model.Offset)
			{
				m_Model = model;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var ip = o as IPoint3D;

				if (ip != null)
				{
					if (ip is Item)
					{
						ip = ((Item)ip).GetWorldTop();
					}

					var p = new Point3D(ip);

					var region = Region.Find(p, from.Map);

					if (region.IsPartOf(typeof(DungeonRegion)))
					{
						from.SendLocalizedMessage(502488); // You can not place a ship inside a dungeon.
					}
					else if (region.IsPartOf(typeof(HouseRegion)) || region.IsPartOf(typeof(ChampionSpawnRegion)))
					{
						from.SendLocalizedMessage(1042549); // A boat may not be placed in this area.
					}
					else
					{
						m_Model.OnPlacement(from, p);
					}
				}
			}
		}
	}

	public class ConfirmDryDockGump : Gump
	{
		private readonly Mobile m_From;
		private readonly BaseBoat m_Boat;

		public ConfirmDryDockGump(Mobile from, BaseBoat boat) : base(150, 200)
		{
			m_From = from;
			m_Boat = boat;

			m_From.CloseGump(typeof(ConfirmDryDockGump));

			AddPage(0);

			AddBackground(0, 0, 220, 170, 5054);
			AddBackground(10, 10, 200, 150, 3000);

			AddHtmlLocalized(20, 20, 180, 80, 1018319, true, false); // Do you wish to dry dock this boat?

			AddHtmlLocalized(55, 100, 140, 25, 1011011, false, false); // CONTINUE
			AddButton(20, 100, 4005, 4007, 2, GumpButtonType.Reply, 0);

			AddHtmlLocalized(55, 125, 140, 25, 1011012, false, false); // CANCEL
			AddButton(20, 125, 4005, 4007, 1, GumpButtonType.Reply, 0);
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			if (info.ButtonID == 2)
			{
				m_Boat.EndDryDock(m_From);
			}
		}
	}
}