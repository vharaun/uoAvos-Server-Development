using Server.Targeting;

#region Developer Notations

/// To Recharge A Talisman You Need The Following
/// 1 Runed Switch

/// To Create The Runed Switch You Need The Following:
/// 2 Boards
/// 1 Enchanted Switch > Included In This File
/// 1 Jeweled Filigree > Included In This File
/// 1 Runed Prism	   > Included In This File

/// To Create The Runed Prism You Need The Following:
/// 1 Blank Scroll
/// 1 Black Pearl
/// 1 Spider Silk
/// 1 Hollow Prism	   > Included In This File

#endregion

namespace Server.Items
{
	public class EnchantedSwitch : Item
	{
		public override int LabelNumber => 1072893;  // enchanted switch

		[Constructable]
		public EnchantedSwitch() : base(0x2F5C)
		{
			Weight = 1.0;
		}

		public EnchantedSwitch(Serial serial) : base(serial)
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

	public class HollowPrism : Item
	{
		public override int LabelNumber => 1072895;  // hollow prism

		[Constructable]
		public HollowPrism() : base(0x2F5D)
		{
			Weight = 1.0;
		}

		public HollowPrism(Serial serial) : base(serial)
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

	public class JeweledFiligree : Item
	{
		public override int LabelNumber => 1072894;  // jeweled filigree

		[Constructable]
		public JeweledFiligree() : base(0x2F5E)
		{
			Weight = 1.0;
		}

		public JeweledFiligree(Serial serial) : base(serial)
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

	public class RunedPrism : Item
	{
		public override int LabelNumber => 1073465;  // runed prism

		[Constructable]
		public RunedPrism() : base(0x2F57)
		{
			Weight = 1.0;
		}

		public RunedPrism(Serial serial) : base(serial)
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

	public class RunedSwitch : Item
	{
		public override int LabelNumber => 1072896;  // runed switch

		[Constructable]
		public RunedSwitch() : base(0x2F61)
		{
			Weight = 1.0;
		}

		public RunedSwitch(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1075101); // Please select an item to recharge.
				from.Target = new InternalTarget(this);
			}
			else
			{
				from.SendLocalizedMessage(1060640); // The item must be in your backpack to use it.
			}
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

		private class InternalTarget : Target
		{
			private readonly RunedSwitch m_Item;

			public InternalTarget(RunedSwitch item) : base(0, false, TargetFlags.None)
			{
				m_Item = item;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (m_Item == null || m_Item.Deleted)
				{
					return;
				}

				if (o is BaseTalisman)
				{
					var talisman = (BaseTalisman)o;

					if (talisman.Charges == 0)
					{
						talisman.Charges = talisman.MaxCharges;
						m_Item.Delete();
						from.SendLocalizedMessage(1075100); // The item has been recharged.
					}
					else
					{
						from.SendLocalizedMessage(1075099); // You cannot recharge that item until all of its current charges have been used.
					}
				}
				else
				{
					from.SendLocalizedMessage(1046439); // That is not a valid target.
				}
			}
		}
	}
}