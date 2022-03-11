namespace Server.Items
{
	public class Counselor_PR_Robe : BaseAdminUniform
	{
		[Constructable]
		public Counselor_PR_Robe() : base(AccessLevel.Counselor, 0x3, 0x204F)
		{
			Movable = false;
		}

		public Counselor_PR_Robe(Serial serial) : base(serial)
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

	public class GameMaster_GM_Robe : BaseAdminUniform
	{
		[Constructable]
		public GameMaster_GM_Robe() : base(AccessLevel.GameMaster, 0x26, 0x204F)
		{
			Movable = false;
		}

		public GameMaster_GM_Robe(Serial serial) : base(serial)
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
}