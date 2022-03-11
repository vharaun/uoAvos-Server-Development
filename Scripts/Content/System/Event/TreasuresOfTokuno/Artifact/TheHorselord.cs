using Server.Items;

namespace Server.Engines.Events
{
	public class TheHorselord : Yumi
	{
		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		public override int LabelNumber => 1070967;  // The Horselord

		[Constructable]
		public TheHorselord() : base()
		{
			Attributes.BonusDex = 5;
			Attributes.RegenMana = 1;
			Attributes.Luck = 125;
			Attributes.WeaponDamage = 50;

			Slayer = SlayerName.ElementalBan;
			Slayer2 = SlayerName.ReptilianDeath;
		}

		public TheHorselord(Serial serial) : base(serial)
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