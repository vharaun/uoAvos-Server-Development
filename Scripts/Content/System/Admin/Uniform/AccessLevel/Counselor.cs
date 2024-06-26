﻿namespace Server.Items
{
	public class CounselorRobe : BaseAdminUniform
	{
		[Constructable]
		public CounselorRobe() : base(AccessLevel.Counselor, 0x3, 0x204F)
		{
		}

		public CounselorRobe(Serial serial) : base(serial)
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