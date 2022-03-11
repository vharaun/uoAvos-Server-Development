namespace Server.Items
{
	public class CheckerBoard : BaseBoard
	{
		public override int LabelNumber => 1016449;  // a checker board

		[Constructable]
		public CheckerBoard() : base(0xFA6)
		{
		}

		public override void CreatePieces()
		{
			for (var i = 0; i < 4; i++)
			{
				CreatePiece(new WhiteCheckerPiece(this), (50 * i) + 45, 25);
				CreatePiece(new WhiteCheckerPiece(this), (50 * i) + 70, 50);
				CreatePiece(new WhiteCheckerPiece(this), (50 * i) + 45, 75);
				CreatePiece(new BlackCheckerPiece(this), (50 * i) + 70, 150);
				CreatePiece(new BlackCheckerPiece(this), (50 * i) + 45, 175);
				CreatePiece(new BlackCheckerPiece(this), (50 * i) + 70, 200);
			}
		}

		public CheckerBoard(Serial serial) : base(serial)
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
	public class WhiteCheckerPiece : BasePiece
	{
		public override string DefaultName => "white checker";

		public WhiteCheckerPiece(BaseBoard board) : base(0x3584, board)
		{
		}

		public WhiteCheckerPiece(Serial serial) : base(serial)
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

	public class BlackCheckerPiece : BasePiece
	{
		public override string DefaultName => "black checker";

		public BlackCheckerPiece(BaseBoard board) : base(0x358B, board)
		{
		}

		public BlackCheckerPiece(Serial serial) : base(serial)
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