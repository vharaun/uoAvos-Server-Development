﻿namespace Server.Items
{
	public class ValoriteOre : BaseOre
	{
		[Constructable]
		public ValoriteOre() : this(1)
		{
		}

		[Constructable]
		public ValoriteOre(int amount) : base(CraftResource.Valorite, amount)
		{
		}

		public ValoriteOre(Serial serial) : base(serial)
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
			return new ValoriteIngot();
		}
	}
}