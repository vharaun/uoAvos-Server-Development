using Server.Items;

namespace Server.Engines.Events
{
	public class SwordOfTheStampede : NoDachi
	{
		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		public override int LabelNumber => 1070964;  // Sword of the Stampede

		[Constructable]
		public SwordOfTheStampede() : base()
		{
			WeaponAttributes.HitHarm = 100;
			Attributes.AttackChance = 10;
			Attributes.WeaponDamage = 60;
		}

		public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
		{
			phys = fire = pois = nrgy = chaos = direct = 0;
			cold = 100;
		}

		public SwordOfTheStampede(Serial serial) : base(serial)
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