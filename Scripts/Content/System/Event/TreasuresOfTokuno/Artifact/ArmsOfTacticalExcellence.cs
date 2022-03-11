using Server.Items;

namespace Server.Engines.Events
{
	public class ArmsOfTacticalExcellence : LeatherHiroSode
	{
		public override int LabelNumber => 1070921;  // Arms of Tactical Excellence

		public override int BaseFireResistance => 9;
		public override int BaseColdResistance => 13;
		public override int BasePoisonResistance => 8;

		[Constructable]
		public ArmsOfTacticalExcellence() : base()
		{
			Attributes.BonusDex = 5;
			SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
		}

		public ArmsOfTacticalExcellence(Serial serial) : base(serial)
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