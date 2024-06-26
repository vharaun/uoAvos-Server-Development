﻿namespace Server.Engines.Stealables
{
	public class Chessmen2 : Item
	{

		[Constructable]
		public Chessmen2() : base(0xE12)
		{
			Movable = true;
			Stackable = false;
		}

		public Chessmen2(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}