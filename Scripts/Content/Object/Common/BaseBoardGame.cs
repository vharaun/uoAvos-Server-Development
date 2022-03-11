using Server.ContextMenus;
using Server.Multis;
using Server.Network;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	public abstract class BaseBoard : Container, ISecurable
	{
		private SecureLevel m_Level;

		[CommandProperty(AccessLevel.GameMaster)]
		public SecureLevel Level
		{
			get => m_Level;
			set => m_Level = value;
		}

		public BaseBoard(int itemID) : base(itemID)
		{
			CreatePieces();

			Weight = 5.0;
		}

		public abstract void CreatePieces();

		public void Reset()
		{
			for (var i = Items.Count - 1; i >= 0; --i)
			{
				if (i < Items.Count)
				{
					Items[i].Delete();
				}
			}

			CreatePieces();
		}

		public void CreatePiece(BasePiece piece, int x, int y)
		{
			AddItem(piece);
			piece.Location = new Point3D(x, y, 0);
		}

		public override bool DisplaysContent => false;  // Do not display (x items, y stones)

		public override bool IsDecoContainer => false;

		public BaseBoard(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(1); // version

			writer.Write((int)m_Level);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			if (version == 1)
			{
				m_Level = (SecureLevel)reader.ReadInt();
			}

			if (Weight == 1.0)
			{
				Weight = 5.0;
			}
		}

		public override TimeSpan DecayTime => TimeSpan.FromDays(1.0);

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			var piece = dropped as BasePiece;

			return (piece != null && piece.Board == this && base.OnDragDrop(from, dropped));
		}

		public override bool OnDragDropInto(Mobile from, Item dropped, Point3D point)
		{
			var piece = dropped as BasePiece;

			if (piece != null && piece.Board == this && base.OnDragDropInto(from, dropped, point))
			{
				Packet p = new PlaySound(0x127, GetWorldLocation());

				p.Acquire();

				if (RootParent == from)
				{
					from.Send(p);
				}
				else
				{
					foreach (var state in GetClientsInRange(2))
					{
						state.Send(p);
					}
				}

				p.Release();

				return true;
			}
			else
			{
				return false;
			}
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			if (ValidateDefault(from, this))
			{
				list.Add(new DefaultEntry(from, this));
			}

			SetSecureLevelEntry.AddTo(from, this, list);
		}

		public static bool ValidateDefault(Mobile from, BaseBoard board)
		{
			if (from.AccessLevel >= AccessLevel.GameMaster)
			{
				return true;
			}

			if (!from.Alive)
			{
				return false;
			}

			if (board.IsChildOf(from.Backpack))
			{
				return true;
			}

			object root = board.RootParent;

			if (root is Mobile && root != from)
			{
				return false;
			}

			if (board.Deleted || board.Map != from.Map || !from.InRange(board.GetWorldLocation(), 1))
			{
				return false;
			}

			var house = BaseHouse.FindHouseAt(board);

			return (house != null && house.IsOwner(from));
		}

		public class DefaultEntry : ContextMenuEntry
		{
			private readonly Mobile m_From;
			private readonly BaseBoard m_Board;

			public DefaultEntry(Mobile from, BaseBoard board) : base(6162, from.AccessLevel >= AccessLevel.GameMaster ? -1 : 1)
			{
				m_From = from;
				m_Board = board;
			}

			public override void OnClick()
			{
				if (BaseBoard.ValidateDefault(m_From, m_Board))
				{
					m_Board.Reset();
				}
			}
		}
	}

	/// Board Game Pieces
	public class BasePiece : Item
	{
		private BaseBoard m_Board;

		public BaseBoard Board
		{
			get => m_Board;
			set => m_Board = value;
		}

		public override bool IsVirtualItem => true;

		public BasePiece(int itemID, BaseBoard board) : base(itemID)
		{
			m_Board = board;
		}

		public BasePiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
			writer.Write(m_Board);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Board = (BaseBoard)reader.ReadItem();

						if (m_Board == null || Parent == null)
						{
							Delete();
						}

						break;
					}
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			if (m_Board == null || m_Board.Deleted)
			{
				Delete();
			}
			else if (!IsChildOf(m_Board))
			{
				m_Board.DropItem(this);
			}
			else
			{
				base.OnSingleClick(from);
			}
		}

		public override bool OnDragLift(Mobile from)
		{
			if (m_Board == null || m_Board.Deleted)
			{
				Delete();
				return false;
			}
			else if (!IsChildOf(m_Board))
			{
				m_Board.DropItem(this);
				return false;
			}
			else
			{
				return true;
			}
		}

		public override bool CanTarget => false;

		public override bool DropToMobile(Mobile from, Mobile target, Point3D p)
		{
			return false;
		}

		public override bool DropToItem(Mobile from, Item target, Point3D p)
		{
			return (target == m_Board && p.X != -1 && p.Y != -1 && base.DropToItem(from, target, p));
		}

		public override bool DropToWorld(Mobile from, Point3D p)
		{
			return false;
		}

		public override int GetLiftSound(Mobile from)
		{
			return -1;
		}
	}
}