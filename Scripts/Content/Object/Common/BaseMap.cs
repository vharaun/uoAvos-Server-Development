using System;
using System.Collections.Generic;

using Server.Network;

namespace Server.Items
{
	[Flipable(0x14EB, 0x14EC)]
	public class MapItem : Item, ICraftable
	{
		[CommandProperty(AccessLevel.GameMaster)]
		public bool Editable { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Protected { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Rectangle2D Bounds { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Width { get; set; } = 200;

		[CommandProperty(AccessLevel.GameMaster)]
		public int Height { get; set; } = 200;

		[CommandProperty(AccessLevel.GameMaster)]
		public Map Facet { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public List<Point2D> Pins { get; private set; } = new();

		public virtual int MaxUserPins => 50;

		public override double DefaultWeight => 1.0;

		[Constructable]
		public MapItem() 
			: base(0x14EC)
		{
			SetDisplay(Map.Felucca);
		}

		public MapItem(Serial serial) 
			: base(serial)
		{
		}

		public virtual int OnCraft(int quality, bool makersMark, Mobile from, ICraftSystem craftSystem, Type typeRes, ICraftTool tool, ICraftItem craftItem, int resHue)
		{
			CraftInit(from);

			return 1;
		}

		public virtual void CraftInit(Mobile from)
		{
		}

		public void SetDisplay(Map facet)
		{
			SetDisplay(facet, Width, Height);
		}

		public void SetDisplay(Map facet, int w, int h)
		{
			Facet = facet;

			if (Facet != null)
			{
				Bounds = Facet.Bounds;
			}

			Width = w;
			Height = h;
		}

		public void SetDisplay(Map facet, int x1, int y1, int x2, int y2)
		{
			SetDisplay(facet, x1, y1, x2, y2, Width, Height);
		}

		public void SetDisplay(Map facet, int x1, int y1, int x2, int y2, int w, int h)
		{
			Facet = facet;

			var p1 = new Point2D(x1, y1);
			var p2 = new Point2D(x2, y2);

			Utility.FixPoints(ref p1, ref p2);

			if (Facet != null)
			{
				var bounds = Facet.Bounds;

				p1.X = Math.Clamp(p1.X, bounds.X, bounds.X + bounds.Width);
				p1.Y = Math.Clamp(p1.Y, bounds.Y, bounds.Y + bounds.Height);

				p2.X = Math.Clamp(p2.X, bounds.X, bounds.X + bounds.Width);
				p2.Y = Math.Clamp(p2.Y, bounds.Y, bounds.Y + bounds.Height);
			}

			Bounds = new Rectangle2D(p1, p2);

			Width = w;
			Height = h;
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (from.InRange(GetWorldLocation(), 2))
			{
				DisplayTo(from);
			}
			else
			{
				from.SendLocalizedMessage(500446); // That is too far away.
			}
		}

		public virtual void DisplayTo(Mobile from)
		{
			from.Send(new MapDetails(this));
			from.Send(new MapDisplay(this));

			for (var i = 0; i < Pins.Count; ++i)
			{
				from.Send(new MapAddPin(this, Pins[i]));
			}

			from.Send(new MapSetEditable(this, ValidateEdit(from)));
		}

		public virtual void OnAddPin(Mobile from, int x, int y)
		{
			if (ValidateEdit(from))
			{
				if (MaxUserPins <= 0 || Pins.Count < MaxUserPins)
				{
					Validate(ref x, ref y);
					AddPin(x, y);
				}
			}
		}

		public virtual void OnRemovePin(Mobile from, int number)
		{
			if (ValidateEdit(from))
			{
				RemovePin(number);
			}
		}

		public virtual void OnChangePin(Mobile from, int number, int x, int y)
		{
			if (ValidateEdit(from))
			{
				Validate(ref x, ref y);
				ChangePin(number, x, y);
			}
		}

		public virtual void OnInsertPin(Mobile from, int number, int x, int y)
		{
			if (ValidateEdit(from))
			{
				if (MaxUserPins <= 0 || Pins.Count < MaxUserPins)
				{
					Validate(ref x, ref y);
					InsertPin(number, x, y);
				}
			}
		}

		public virtual void OnClearPins(Mobile from)
		{
			if (ValidateEdit(from))
			{
				ClearPins();
			}
		}

		public virtual void OnToggleEditable(Mobile from)
		{
			if (Validate(from))
			{
				Editable = !Editable;
			}

			from.Send(new MapSetEditable(this, Validate(from) && Editable));
		}

		public virtual void Validate(ref int x, ref int y)
		{
			x = Math.Clamp(x, 0, Width - 1);
			y = Math.Clamp(y, 0, Height - 1);
		}

		public virtual bool ValidateEdit(Mobile from)
		{
			return Editable && Validate(from);
		}

		public virtual bool Validate(Mobile from)
		{
			if (!from.CanSee(this) || from.Map != Map || !from.Alive || InSecureTrade)
			{
				return false;
			}
			
			if (from.AccessLevel >= AccessLevel.GameMaster)
			{
				return true;
			}
			
			if (!Movable || Protected || !from.InRange(GetWorldLocation(), 2))
			{
				return false;
			}

			if (RootParent is Mobile root && root != from)
			{
				return false;
			}

			return true;
		}

		public void ConvertToWorld(int x, int y, out int worldX, out int worldY)
		{
			worldX = (Bounds.Width * x / Width) + Bounds.X;
			worldY = (Bounds.Height * y / Height) + Bounds.Y;
		}

		public void ConvertToMap(int x, int y, out int mapX, out int mapY)
		{
			mapX = (x - Bounds.X) * Width / Bounds.Width;
			mapY = (y - Bounds.Y) * Width / Bounds.Height;
		}

		public virtual void AddWorldPin(int x, int y)
		{
			ConvertToMap(x, y, out var mapX, out var mapY);

			AddPin(mapX, mapY);
		}

		public virtual void AddPin(int x, int y)
		{
			Pins.Add(new Point2D(x, y));
		}

		public virtual void RemovePin(int index)
		{
			if (index > 0 && index < Pins.Count)
			{
				Pins.RemoveAt(index);
			}
		}

		public virtual void InsertPin(int index, int x, int y)
		{
			if (index < 0 || index >= Pins.Count)
			{
				Pins.Add(new Point2D(x, y));
			}
			else
			{
				Pins.Insert(index, new Point2D(x, y));
			}
		}

		public virtual void ChangePin(int index, int x, int y)
		{
			if (index >= 0 && index < Pins.Count)
			{
				Pins[index] = new Point2D(x, y);
			}
		}

		public virtual void ClearPins()
		{
			Pins.Clear();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(Facet);
			writer.Write(Bounds);

			writer.Write(Width);
			writer.Write(Height);

			writer.Write(Protected);

			writer.Write(Pins.Count);

			for (var i = 0; i < Pins.Count; ++i)
			{
				writer.Write(Pins[i]);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						Facet = reader.ReadMap();
						Bounds = reader.ReadRect2D();

						Width = reader.ReadInt();
						Height = reader.ReadInt();

						Protected = reader.ReadBool();

						var count = reader.ReadInt();

						for (var i = 0; i < count; i++)
						{
							Pins.Add(reader.ReadPoint2D());
						}

						break;
					}
			}
		}

		public static void Initialize()
		{
			PacketHandlers.Register(0x56, 11, true, new OnPacketReceive(OnMapCommand));
		}

		private static void OnMapCommand(NetState state, PacketReader pvSrc)
		{
			var from = state.Mobile;
			var map = pvSrc.ReadItem() as MapItem;

			if (map == null)
			{
				return;
			}

			int command = pvSrc.ReadByte();
			int number = pvSrc.ReadByte();

			int x = pvSrc.ReadInt16();
			int y = pvSrc.ReadInt16();

			switch (command)
			{
				case 1: map.OnAddPin(from, x, y); break;
				case 2: map.OnInsertPin(from, number, x, y); break;
				case 3: map.OnChangePin(from, number, x, y); break;
				case 4: map.OnRemovePin(from, number); break;
				case 5: map.OnClearPins(from); break;
				case 6: map.OnToggleEditable(from); break;
			}
		}

		private sealed class MapDetails : Packet
		{
			public MapDetails(MapItem map) : base(0xF5, 21)
			{
				m_Stream.Write(map.Serial);
				m_Stream.Write((short)0x139D);
				m_Stream.Write((short)map.Bounds.Start.X);
				m_Stream.Write((short)map.Bounds.Start.Y);
				m_Stream.Write((short)map.Bounds.End.X);
				m_Stream.Write((short)map.Bounds.End.Y);
				m_Stream.Write((short)map.Width);
				m_Stream.Write((short)map.Height);
				m_Stream.Write((short)map.Facet.MapID);
			}
		}

		private abstract class MapCommand : Packet
		{
			public MapCommand(MapItem map, int command, int number, int x, int y) : base(0x56, 11)
			{
				m_Stream.Write(map.Serial);
				m_Stream.Write((byte)command);
				m_Stream.Write((byte)number);
				m_Stream.Write((short)x);
				m_Stream.Write((short)y);
			}
		}

		private sealed class MapDisplay : MapCommand
		{
			public MapDisplay(MapItem map) : base(map, 5, 0, 0, 0)
			{
			}
		}

		private sealed class MapAddPin : MapCommand
		{
			public MapAddPin(MapItem map, Point2D point) : base(map, 1, 0, point.X, point.Y)
			{
			}
		}

		private sealed class MapSetEditable : MapCommand
		{
			public MapSetEditable(MapItem map, bool editable) : base(map, 7, editable ? 1 : 0, 0, 0)
			{
			}
		}
	}

	public class IndecipherableMap : MapItem
	{
		public override int LabelNumber => 1070799;  // indecipherable map

		[Constructable]
		public IndecipherableMap()
		{
			Editable = false;

			if (Utility.RandomDouble() < 0.2)
			{
				Hue = 0x965;
			}
			else
			{
				Hue = 0x961;
			}
		}

		public IndecipherableMap(Serial serial) 
			: base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			from.SendLocalizedMessage(1070801); // You cannot decipher this ruined map.
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadEncodedInt();
		}
	}

	public class RegionBorderMap : MapItem
	{
		public override string DefaultName => "region border map";

		public override int MaxUserPins => 0;

		[Constructable]
		public RegionBorderMap()
		{
			Editable = false;

			Width = Height = 400;
		}

		public RegionBorderMap(Serial serial)
			: base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			var region = from.Region;

			if (region == null || region.IsDefault)
			{
				return;
			}

			SetDisplay(region.Map);

			ClearPins();

			foreach (var a in region.Area)
			{
				int fx = -1, fy = -1;

				foreach (var p in a.Points)
				{
					if (fx < 0)
					{
						fx = p.X;
					}

					if (fy < 0)
					{
						fy = p.Y;
					}

					AddWorldPin(p.X, p.Y);
				}

				AddWorldPin(fx, fy);
			}

			base.OnDoubleClick(from);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadEncodedInt();
		}
	}
}