﻿namespace Server.Items
{
	public class Coral : BaseAquaticLife
	{
		public override int LabelNumber => 1074588;  // Coral

		[Constructable]
		public Coral() : base(Utility.RandomList(0x3AF9, 0x3AFA, 0x3AFB))
		{
		}

		public Coral(Serial serial) : base(serial)
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