﻿namespace Server.Items
{
	public class VeriteOre : BaseOre
	{
		[Constructable]
		public VeriteOre() : this(1)
		{
		}

		[Constructable]
		public VeriteOre(int amount) : base(CraftResource.Verite, amount)
		{
		}

		public VeriteOre(Serial serial) : base(serial)
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
			return new VeriteIngot();
		}
	}
}