
using System;

#region Developer Notations

/// Original label, doesn't fit the expiration message well
/// public override int LabelNumber { get { return 1073129; } } // A battered bucket.

#endregion

namespace Server.Engines.ChainQuests.Items
{
	public class BatteredBucket : TransientQuestGiverItem
	{
		public override string DefaultName => "battered bucket";

		[Constructable]
		public BatteredBucket()
			: base(0x2004, TimeSpan.FromMinutes(10))
		{
			LootType = LootType.Blessed;
		}

		public BatteredBucket(Serial serial)
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