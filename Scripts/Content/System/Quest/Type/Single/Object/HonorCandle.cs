using System;

namespace Server.Items
{
	public class HonorCandle : CandleLong
	{
		private static readonly TimeSpan LitDuration = TimeSpan.FromSeconds(20.0);

		public override int LitSound => 0;
		public override int UnlitSound => 0;

		[Constructable]
		public HonorCandle()
		{
			Movable = false;
			Duration = LitDuration;
		}

		public HonorCandle(Serial serial) : base(serial)
		{
		}

		public override void Burn()
		{
			Douse();
		}

		public override void Douse()
		{
			base.Douse();

			Duration = LitDuration;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}