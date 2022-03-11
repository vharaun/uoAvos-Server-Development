using Server.Items;

namespace Server.Engines.Stealables
{
	internal class Bucket : BaseWaterContainer
	{
		public override int voidItem_ID => vItemID;
		public override int fullItem_ID => fItemID;
		public override int MaxQuantity => 25;

		private static readonly int vItemID = 0x14e0;
		private static readonly int fItemID = 0x2004;

		[Constructable]
		public Bucket()
			: this(false)
		{
		}

		[Constructable]
		public Bucket(bool filled)
			: base((filled) ? Bucket.fItemID : Bucket.vItemID, filled)
		{
		}

		public Bucket(Serial serial)
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