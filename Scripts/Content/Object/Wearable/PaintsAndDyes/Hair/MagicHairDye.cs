using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
	public class MagicHairDye : Item
	{
		public override int LabelNumber => 1041088;  // Hair Dye

		[Constructable]
		public MagicHairDye() : base(0xEFF)
		{
			Hue = Utility.RandomMinMax(0x47E, 0x499);
		}

		public MagicHairDye(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsChildOf(from.Backpack))
			{
				if (from is PlayerMobile player && ValorSpawner.CheckML(player))
				{
					BaseGump.SendGump(new ConfirmGump(player, this));
				}
			}
			else
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);
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

		private class ConfirmGump : BaseConfirmGump
		{
			private readonly Item m_Item;

			// <div align=right>Use Permanent Hair Dye</div>
			// This special hair dye is made of a unique mixture of leaves, permanently changing one's hair color until another dye is used.
			public ConfirmGump(PlayerMobile user, Item item) : base(user, 1074395, 1074396)
			{
				m_Item = item;
			}

			public override void Confirm()
			{
				if (m_Item != null && !m_Item.Deleted && m_Item.IsChildOf(User.Backpack))
				{
					if (User.HairItemID != 0)
					{
						User.HairHue = m_Item.Hue;
						User.PlaySound(0x240);
						User.SendLocalizedMessage(502622); // You dye your hair.
						m_Item.Delete();
					}
					else
					{
						User.SendLocalizedMessage(502623); // You have no hair to dye and you cannot use this.
					}
				}
				else
				{
					User.SendLocalizedMessage(1073461); // You don't have enough dye.
				}
			}

			public override void Refuse()
			{
				User.SendLocalizedMessage(502620); // You decide not to dye your hair.
			}
		}
	}
}