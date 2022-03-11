namespace Server.Items
{
	public class TaintedWool : Wool
	{
		[Constructable]
		public TaintedWool() : this(1)
		{
		}

		[Constructable]
		public TaintedWool(int amount) : base(0x101F)
		{
			Stackable = true;
			Weight = 4.0;
			Amount = amount;
		}

		public TaintedWool(Serial serial) : base(serial)
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

		public static new void OnSpun(ISpinningWheel wheel, Mobile from, int hue)
		{
			Item item = new DarkYarn(1) {
				Hue = hue
			};

			from.AddToBackpack(item);
			from.SendLocalizedMessage(1010574); // You put a ball of yarn in your backpack.
		}
	}
}