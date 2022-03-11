namespace Server.Items
{
	public class AquariumFood : Item
	{
		public override int LabelNumber => 1074819;  // Aquarium food

		[Constructable]
		public AquariumFood() : base(0xEFC)
		{
		}

		public AquariumFood(Serial serial) : base(serial)
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

	public class VacationWafer : Item
	{
		public const int VacationDays = 7;

		public override int LabelNumber => 1074431;  // An aquarium flake sphere

		[Constructable]
		public VacationWafer() : base(0x973)
		{
		}

		public VacationWafer(Serial serial) : base(serial)
		{
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1074432, VacationDays.ToString()); // Vacation days: ~1_DAYS~
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version < 1 && ItemID == 0x971)
			{
				ItemID = 0x973;
			}
		}
	}
}