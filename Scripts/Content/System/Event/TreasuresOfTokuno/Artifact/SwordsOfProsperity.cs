using Server.Items;

namespace Server.Engines.Events
{
	public class SwordsOfProsperity : Daisho
	{
		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		public override int LabelNumber => 1070963;  // Swords of Prosperity

		[Constructable]
		public SwordsOfProsperity() : base()
		{
			WeaponAttributes.MageWeapon = 30;
			Attributes.SpellChanneling = 1;
			Attributes.CastSpeed = 1;
			Attributes.Luck = 200;
		}

		public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
		{
			phys = cold = pois = nrgy = chaos = direct = 0;
			fire = 100;
		}

		public SwordsOfProsperity(Serial serial) : base(serial)
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