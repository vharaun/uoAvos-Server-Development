﻿namespace Server.Items
{
	public class StrippedSosarianSwill : BaseAquaticLife
	{
		public override int LabelNumber => 1074594;  // Stripped Sosarian Swill

		[Constructable]
		public StrippedSosarianSwill() : base(0x3B0A)
		{
		}

		public StrippedSosarianSwill(Serial serial) : base(serial)
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