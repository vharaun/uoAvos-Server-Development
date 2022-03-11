namespace Server.Items
{
	public class Chessboard : BaseBoard
	{
		public override int LabelNumber => 1016450;  // a chessboard

		[Constructable]
		public Chessboard() : base(0xFA6)
		{
		}

		public override void CreatePieces()
		{
			for (var i = 0; i < 8; i++)
			{
				CreatePiece(new BlackPawnPiece(this), 67, (25 * i) + 17);
				CreatePiece(new WhitePawnPiece(this), 192, (25 * i) + 17);
			}

			// Rook
			CreatePiece(new BlackRookPiece(this), 42, 5);
			CreatePiece(new BlackRookPiece(this), 42, 180);

			CreatePiece(new WhiteRookPiece(this), 216, 5);
			CreatePiece(new WhiteRookPiece(this), 216, 180);

			// Knight
			CreatePiece(new BlackKnightPiece(this), 42, 30);
			CreatePiece(new BlackKnightPiece(this), 42, 155);

			CreatePiece(new WhiteKnightPiece(this), 216, 30);
			CreatePiece(new WhiteKnightPiece(this), 216, 155);

			// Bishop
			CreatePiece(new BlackBishopPiece(this), 42, 55);
			CreatePiece(new BlackBishopPiece(this), 42, 130);

			CreatePiece(new WhiteBishopPiece(this), 216, 55);
			CreatePiece(new WhiteBishopPiece(this), 216, 130);

			// Queen
			CreatePiece(new BlackQueenPiece(this), 42, 105);
			CreatePiece(new WhiteQueenPiece(this), 216, 105);

			// King
			CreatePiece(new BlackKingPiece(this), 42, 80);
			CreatePiece(new WhiteKingPiece(this), 216, 80);
		}

		public Chessboard(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	/// Board Game Pieces
	public class WhiteKingPiece : BasePiece
	{
		public override string DefaultName => "white king";

		public WhiteKingPiece(BaseBoard board) : base(0x3587, board)
		{
		}

		public WhiteKingPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class BlackKingPiece : BasePiece
	{
		public override string DefaultName => "black king";

		public BlackKingPiece(BaseBoard board) : base(0x358E, board)
		{
		}

		public BlackKingPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class WhiteQueenPiece : BasePiece
	{
		public override string DefaultName => "white queen";

		public WhiteQueenPiece(BaseBoard board) : base(0x358A, board)
		{
		}

		public WhiteQueenPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class BlackQueenPiece : BasePiece
	{
		public override string DefaultName => "black queen";

		public BlackQueenPiece(BaseBoard board) : base(0x3591, board)
		{
		}

		public BlackQueenPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class WhiteRookPiece : BasePiece
	{
		public override string DefaultName => "white rook";

		public WhiteRookPiece(BaseBoard board) : base(0x3586, board)
		{
		}

		public WhiteRookPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class BlackRookPiece : BasePiece
	{
		public override string DefaultName => "black rook";

		public BlackRookPiece(BaseBoard board) : base(0x358D, board)
		{
		}

		public BlackRookPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class WhiteBishopPiece : BasePiece
	{
		public override string DefaultName => "white bishop";

		public WhiteBishopPiece(BaseBoard board) : base(0x3585, board)
		{
		}

		public WhiteBishopPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class BlackBishopPiece : BasePiece
	{
		public override string DefaultName => "black bishop";

		public BlackBishopPiece(BaseBoard board) : base(0x358C, board)
		{
		}

		public BlackBishopPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class WhiteKnightPiece : BasePiece
	{
		public override string DefaultName => "white knight";

		public WhiteKnightPiece(BaseBoard board) : base(0x3588, board)
		{
		}

		public WhiteKnightPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class BlackKnightPiece : BasePiece
	{
		public override string DefaultName => "black knight";

		public BlackKnightPiece(BaseBoard board) : base(0x358F, board)
		{
		}

		public BlackKnightPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class WhitePawnPiece : BasePiece
	{
		public override string DefaultName => "white pawn";

		public WhitePawnPiece(BaseBoard board) : base(0x3589, board)
		{
		}

		public WhitePawnPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class BlackPawnPiece : BasePiece
	{
		public override string DefaultName => "black pawn";

		public BlackPawnPiece(BaseBoard board) : base(0x3590, board)
		{
		}

		public BlackPawnPiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}