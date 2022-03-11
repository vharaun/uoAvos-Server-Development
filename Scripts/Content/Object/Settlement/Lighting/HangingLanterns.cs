
using System;

namespace Server.Items
{
	/// HangingLantern
	public class HangingLantern : BaseLight
	{
		public override int LitItemID => 0xA1A;
		public override int UnlitItemID => 0xA1D;

		[Constructable]
		public HangingLantern() : base(0xA1D)
		{
			Movable = false;
			Duration = TimeSpan.Zero; // Never burnt out
			Burning = false;
			Light = LightType.Circle300;
			Weight = 40.0;
		}

		public HangingLantern(Serial serial) : base(serial)
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
	}

	/// RedHangingLantern
	[Flipable]
	public class RedHangingLantern : BaseLight
	{
		public override int LitItemID
		{
			get
			{
				if (ItemID == 0x24C2)
				{
					return 0x24C1;
				}
				else
				{
					return 0x24C3;
				}
			}
		}

		public override int UnlitItemID
		{
			get
			{
				if (ItemID == 0x24C1)
				{
					return 0x24C2;
				}
				else
				{
					return 0x24C4;
				}
			}
		}

		[Constructable]
		public RedHangingLantern() : base(0x24C2)
		{
			Movable = true;
			Duration = TimeSpan.Zero; // Never burnt out
			Burning = false;
			Light = LightType.Circle300;
			Weight = 3.0;
		}

		public RedHangingLantern(Serial serial) : base(serial)
		{
		}

		public void Flip()
		{
			Light = LightType.Circle300;

			switch (ItemID)
			{
				case 0x24C2: ItemID = 0x24C4; break;
				case 0x24C1: ItemID = 0x24C3; break;

				case 0x24C4: ItemID = 0x24C2; break;
				case 0x24C3: ItemID = 0x24C1; break;
			}
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
	}

	/// WhiteHangingLantern
	[Flipable]
	public class WhiteHangingLantern : BaseLight
	{
		public override int LitItemID
		{
			get
			{
				if (ItemID == 0x24C6)
				{
					return 0x24C5;
				}
				else
				{
					return 0x24C7;
				}
			}
		}

		public override int UnlitItemID
		{
			get
			{
				if (ItemID == 0x24C5)
				{
					return 0x24C6;
				}
				else
				{
					return 0x24C8;
				}
			}
		}

		[Constructable]
		public WhiteHangingLantern() : base(0x24C6)
		{
			Movable = true;
			Duration = TimeSpan.Zero; // Never burnt out
			Burning = false;
			Light = LightType.Circle300;
			Weight = 3.0;
		}

		public WhiteHangingLantern(Serial serial) : base(serial)
		{
		}

		public void Flip()
		{
			Light = LightType.Circle300;

			switch (ItemID)
			{
				case 0x24C6: ItemID = 0x24C8; break;
				case 0x24C5: ItemID = 0x24C7; break;

				case 0x24C8: ItemID = 0x24C6; break;
				case 0x24C7: ItemID = 0x24C5; break;
			}
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
	}
}