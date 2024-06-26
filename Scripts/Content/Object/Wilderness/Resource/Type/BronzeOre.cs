﻿namespace Server.Items
{
	public class BronzeOre : BaseOre
	{
		[Constructable]
		public BronzeOre() : this(1)
		{
		}

		[Constructable]
		public BronzeOre(int amount) : base(CraftResource.Bronze, amount)
		{
		}

		public BronzeOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new BronzeIngot();
		}
	}
}