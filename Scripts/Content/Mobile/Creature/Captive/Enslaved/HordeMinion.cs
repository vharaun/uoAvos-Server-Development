namespace Server.Mobiles
{
	public class EnslavedHordeMinion : HordeMinion
	{
		[Constructable]
		public EnslavedHordeMinion()
		{
			Name = "Horde Minion";
			FightMode = FightMode.None;
		}

		public override bool InitialInnocent => true;

		public override bool CanBeDamaged()
		{
			return false;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1005494); // Enslaved
		}

		public EnslavedHordeMinion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}