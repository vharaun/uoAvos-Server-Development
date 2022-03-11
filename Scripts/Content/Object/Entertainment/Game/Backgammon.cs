namespace Server.Items
{
	[Flipable(0xE1C, 0xFAD)]
	public class Backgammon : BaseBoard
	{
		[Constructable]
		public Backgammon() : base(0xE1C)
		{
		}

		public override void CreatePieces()
		{
			for (var i = 0; i < 5; i++)
			{
				CreatePiece(new WhiteBackgammonPiece(this), 42, (17 * i) + 6);
				CreatePiece(new BlackBackgammonPiece(this), 42, (17 * i) + 119);

				CreatePiece(new BlackBackgammonPiece(this), 142, (17 * i) + 6);
				CreatePiece(new WhiteBackgammonPiece(this), 142, (17 * i) + 119);
			}

			for (var i = 0; i < 3; i++)
			{
				CreatePiece(new BlackBackgammonPiece(this), 108, (17 * i) + 6);
				CreatePiece(new WhiteBackgammonPiece(this), 108, (17 * i) + 153);
			}

			for (var i = 0; i < 2; i++)
			{
				CreatePiece(new WhiteBackgammonPiece(this), 223, (17 * i) + 6);
				CreatePiece(new BlackBackgammonPiece(this), 223, (17 * i) + 170);
			}
		}

		public Backgammon(Serial serial) : base(serial)
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
	public class WhiteBackgammonPiece : BasePiece
	{
		public override string DefaultName => "white piece";

		public WhiteBackgammonPiece(BaseBoard board) : base(0x3584, board)
		{
		}

		public WhiteBackgammonPiece(Serial serial) : base(serial)
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

	public class BlackBackgammonPiece : BasePiece
	{
		public override string DefaultName => "black piece";

		public BlackBackgammonPiece(BaseBoard board) : base(0x358B, board)
		{
		}

		public BlackBackgammonPiece(Serial serial) : base(serial)
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