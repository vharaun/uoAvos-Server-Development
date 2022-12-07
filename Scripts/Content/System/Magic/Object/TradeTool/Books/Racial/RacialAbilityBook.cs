namespace Server.Items
{
	public abstract class RacialAbilityBook : Spellbook
	{
		public abstract Race Race { get; }

		[Constructable]
		public RacialAbilityBook()
			: this(0UL)
		{
		}

		[Constructable]
		public RacialAbilityBook(ulong content)
			: base(content, 0xEFA)
		{
			LootType = LootType.Blessed;
		}

		public RacialAbilityBook(Serial serial)
			: base(serial)
		{ }

		public override bool CanDisplayTo(Mobile user, bool message)
		{
			if (!base.CanDisplayTo(user, message))
			{
				return false;
			}

			if (user.Race != Race)
			{
				if (message)
				{
					user.SendMessage("You can't comprehend the mantra text within this book...");
				}

				return false;
			}

			return true;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadEncodedInt(); // version
		}
	}
}
