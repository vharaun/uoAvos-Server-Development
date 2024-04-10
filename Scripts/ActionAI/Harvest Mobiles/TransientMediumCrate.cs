using System;

using Server.Items;

namespace Server.Multis
{
	[Furniture, Flipable(0xE3F, 0xE3E)]
	public class TransientMediumCrate : MediumCrate
	{
		private DateTime m_Expire;

		[Constructable]
		public TransientMediumCrate()
		{
			Weight = 2.0;
			LiftOverride = true;

			var duration = TimeSpan.FromMinutes(10.0);

			m_Expire = DateTime.UtcNow.Add(duration);

			_ = Timer.DelayCall(duration, Delete);
		}

		public TransientMediumCrate(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.WriteDeltaTime(m_Expire);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadInt();

			m_Expire = reader.ReadDeltaTime();

			var delay = TimeSpan.FromSeconds(Math.Max(0, (m_Expire - DateTime.UtcNow).TotalSeconds));

			Timer.DelayCall(delay, Delete);
		}
	}
}
