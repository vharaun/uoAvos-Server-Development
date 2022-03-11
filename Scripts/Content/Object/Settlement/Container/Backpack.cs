using Server.Mobiles;

namespace Server.Items
{
	/// Backpack
	public class Backpack : BaseContainer, IDyable // Used on PlayerMobile
	{
		[Constructable]
		public Backpack() : base(0xE75)
		{
			Layer = Layer.Backpack;
			Weight = 3.0;
		}

		public override int DefaultMaxWeight
		{
			get
			{
				if (Core.ML)
				{
					var m = Parent as Mobile;
					if (m != null && m.Player && m.Backpack == this)
					{
						return 550;
					}
					else
					{
						return base.DefaultMaxWeight;
					}
				}
				else
				{
					return base.DefaultMaxWeight;
				}
			}
		}

		public Backpack(Serial serial) : base(serial)
		{
		}

		public bool Dye(Mobile from, DyeTub sender)
		{
			if (Deleted)
			{
				return false;
			}

			Hue = sender.DyedHue;

			return true;
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

			if (version == 0 && ItemID == 0x9B2)
			{
				ItemID = 0xE75;
			}
		}
	}

	/// CreatureBackpack
	public class CreatureBackpack : Backpack // Used on BaseCreature
	{
		[Constructable]
		public CreatureBackpack(string name)
		{
			Name = name;
			Layer = Layer.Backpack;
			Hue = 5;
			Weight = 3.0;
		}

		public override void AddNameProperty(ObjectPropertyList list)
		{
			if (Name != null)
			{
				list.Add(1075257, Name); // Contents of ~1_PETNAME~'s pack.
			}
			else
			{
				base.AddNameProperty(list);
			}
		}

		public override void OnItemRemoved(Item item)
		{
			if (Items.Count == 0)
			{
				Delete();
			}

			base.OnItemRemoved(item);
		}

		public override bool OnDragLift(Mobile from)
		{
			if (from.AccessLevel > AccessLevel.Player)
			{
				return true;
			}

			from.SendLocalizedMessage(500169); // You cannot pick that up.
			return false;
		}

		public override bool OnDragDropInto(Mobile from, Item item, Point3D p)
		{
			return false;
		}

		public override bool TryDropItem(Mobile from, Item dropped, bool sendFullMessage)
		{
			return false;
		}

		public CreatureBackpack(Serial serial) : base(serial)
		{
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

			if (version == 0)
			{
				Weight = 13.0;
			}
		}
	}

	/// StrongBackpack
	public class StrongBackpack : Backpack // Used on Pack animals
	{
		[Constructable]
		public StrongBackpack()
		{
			Layer = Layer.Backpack;
			Weight = 13.0;
		}

		public override bool CheckHold(Mobile m, Item item, bool message, bool checkItems, int plusItems, int plusWeight)
		{
			return base.CheckHold(m, item, false, checkItems, plusItems, plusWeight);
		}

		public override int DefaultMaxWeight => 1600;

		public override bool CheckContentDisplay(Mobile from)
		{
			object root = RootParent;

			if (root is BaseCreature && ((BaseCreature)root).Controlled && ((BaseCreature)root).ControlMaster == from)
			{
				return true;
			}

			return base.CheckContentDisplay(from);
		}

		public StrongBackpack(Serial serial) : base(serial)
		{
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

			if (version == 0)
			{
				Weight = 13.0;
			}
		}
	}
}