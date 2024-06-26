﻿using Server.Items;

namespace Server.Engines.Stealables
{
	internal class ClosedBarrel : TrapableContainer
	{
		public override int DefaultGumpID => 0x3e;

		[Constructable]
		public ClosedBarrel()
			: base(0x0FAE)
		{
		}

		public ClosedBarrel(Serial serial)
			: base(serial)
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