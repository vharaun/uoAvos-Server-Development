using System;

using Server.Items;

namespace Server.Multis
{
	[Furniture, Flipable(0xE3F, 0xE3E)]
	public class TransientMediumCrate : MediumCrate
	{
		[Constructable]
		public TransientMediumCrate() : base()
		{
			Weight = 2.0;
			LiftOverride = true;

			Timer.DelayCall(TimeSpan.FromMinutes(10.0), Delete);
		}

		public TransientMediumCrate(Serial serial)
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

			_ = reader.ReadInt();
		}
	}
}
