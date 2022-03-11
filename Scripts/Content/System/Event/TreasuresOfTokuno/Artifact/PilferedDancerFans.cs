using Server.Items;

namespace Server.Engines.Events
{
	public class PilferedDancerFans : Tessen
	{
		public override int LabelNumber => 1070916;  // Pilfered Dancer Fans

		[Constructable]
		public PilferedDancerFans() : base()
		{
			Attributes.WeaponDamage = 20;
			Attributes.WeaponSpeed = 20;
			Attributes.CastRecovery = 2;
			Attributes.DefendChance = 5;
			Attributes.SpellChanneling = 1;
		}

		public PilferedDancerFans(Serial serial) : base(serial)
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

		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;
	}
}