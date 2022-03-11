namespace Server.Items
{
	[Flipable(0x1721, 0x1722)]
	public class Bananas : Food
	{
		[Constructable]
		public Bananas() : this(1)
		{
		}

		[Constructable]
		public Bananas(int amount) : base(amount, 0x1721)
		{
			Weight = 1.0;
			FillFactor = 1;
			Stackable = false;
		}

		public override void OnDoubleClick(Mobile from) // Override double click of the deed to call our target
		{
			if (!IsChildOf(from.Backpack)) // Make sure its in their pack
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
			}
			else
			{
				switch (Utility.Random(4))
				{
					case 3:
						{
							from.AddToBackpack(new Banana(1));
							from.SendAsciiMessage("*You were only able to extract 1 banana from the bunch*");
							Delete();
							break;
						}
					case 2:
						{
							from.AddToBackpack(new Banana(2));
							from.SendAsciiMessage("*You were only able to extract 2 bananas from the bunch*");
							Delete();
							break;
						}
					case 1:
						{
							from.AddToBackpack(new Banana(4));
							from.SendAsciiMessage("*You were only able to extract 4 bananas from the bunch*");
							Delete();
							break;
						}
					case 0:
						{
							from.AddToBackpack(new Banana(6));
							from.SendAsciiMessage("*You were only able to extract 6 bananas from the bunch*");
							Delete();
							break;
						}
					default:
						{
							return;
						}
				}
			}
		}

		public Bananas(Serial serial) : base(serial)
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

	[FlipableAttribute(0x171f, 0x1720)]
	public class Banana : Food
	{
		[Constructable]
		public Banana() : this(1)
		{
		}

		[Constructable]
		public Banana(int amount) : base(amount, 0x171f)
		{
			Weight = 1.0;
			FillFactor = 1;
		}

		public Banana(Serial serial) : base(serial)
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