#region Developer Notations

/// ToDo: After Comsuming Green Tea, Maybe Empty Cups Get Added To Pack

#endregion

namespace Server.Items
{
	public class GreenTeaCup : Item
	{
		[Constructable]
		public GreenTeaCup() : base(0x284C)
		{
			Name = "A Cup of Green Tea";
			Weight = 2.0;
		}

		public override void OnDoubleClick(Mobile from)
		{
			switch (Utility.Random(4))
			{
				case 4:
					{
						Effects.PlaySound(from.Location, from.Map, 0x30); // Sipping Tea
						Effects.PlaySound(from.Location, from.Map, 0x30); // Sipping Tea
						break;
					}
				case 3:
					{
						Effects.PlaySound(from.Location, from.Map, 0x30); // Sipping Tea
						break;
					}
				case 2:
					{
						Effects.PlaySound(from.Location, from.Map, 0x30); // Sipping Tea
						Consume(); // Chance The Cups Empties On Drinking			
						break;
					}
				case 1:
					{
						from.Say("*Ouch!*" + "You've burned your lip while drinking your tea!");
						from.Hits = -2;
						Effects.PlaySound(from.Location, from.Map, 0x30); // Sipping Tea
						Effects.PlaySound(from.Location, from.Map, 0x540); // Ouch!
						Consume(); // Chance The Cups Empties On Drinking			
						break;
					}
				case 0:
					{
						from.Say("*Mmmm*" + "You feel more situated with warm tea in your belly!");
						Effects.PlaySound(from.Location, from.Map, 0x30); // Sipping Tea
						Consume();
						break;
					}
			}

			Delete();
			base.OnDoubleClick(from);
		}

		public GreenTeaCup(Serial serial) : base(serial)
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

	public class GreenTeaPot : Item
	{
		[Constructable]
		public GreenTeaPot() : base(0x284B)
		{
			Name = "A Fresh Pot of Green Tea";
			Weight = 10.0;
		}

		public override void OnDoubleClick(Mobile from)
		{
			switch (Utility.Random(2))
			{
				case 2:
					{
						Effects.PlaySound(from.Location, from.Map, 0x4E); // Pouring
						from.AddToBackpack(new GreenTeaCup());
						break;
					}
				case 1:
					{
						Effects.PlaySound(from.Location, from.Map, 0x4E); // Pouring
						from.AddToBackpack(new GreenTeaCup());
						Delete(); // Chance The Pot Empties
						break;
					}
				case 0:
					{
						from.Say("Ouch! You've burned your hand on the tea pot!");
						from.Hits = -2;
						Effects.PlaySound(from.Location, from.Map, 0x540); // Ouch!
						break;
					}
			}

			base.OnDoubleClick(from);
		}

		public GreenTeaPot(Serial serial) : base(serial)
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

	public class GreenTeaLeafBasket : Item
	{
		[Constructable]
		public GreenTeaLeafBasket() : base(0x284B)
		{
			Name = "Fresh Green Tea Leaves";
			Weight = 10.0;
		}

		public override void OnDoubleClick(Mobile from)
		{
			switch (Utility.Random(3))
			{
				case 2:
					{
						from.SendAsciiMessage("You've used up all the tea leaves in this basket!");
						Delete();
						break;
					}
				case 1:
					{
						from.SendAsciiMessage("You fail to brew any tea...");
						break;
					}
				case 0:
					{
						from.AddToBackpack(new GreenTeaPot());
						Delete();
						break;
					}
			}

			base.OnDoubleClick(from);
		}

		public GreenTeaLeafBasket(Serial serial) : base(serial)
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