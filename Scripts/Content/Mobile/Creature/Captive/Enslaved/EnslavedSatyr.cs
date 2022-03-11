namespace Server.Mobiles
{
	[CorpseName("an enslaved satyr corpse")]
	public class EnslavedSatyr : Satyr
	{
		[Constructable]
		public EnslavedSatyr()
		{
			Name = "a satyr";
		}

		/*
		// TODO: uncomment once added
		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			if ( Utility.RandomDouble() < 0.1 )
				c.DropItem( new ParrotItem() );
		}
		*/

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1005494); // Enslaved
		}

		public EnslavedSatyr(Serial serial)
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