
using System;

namespace Server.Items
{
	/// CandleLong
	public class CandleLong : BaseLight
	{
		public override int LitItemID => 0x1430;
		public override int UnlitItemID => 0x1433;

		[Constructable]
		public CandleLong() : base(0x1433)
		{
			if (Burnout)
			{
				Duration = TimeSpan.FromMinutes(30);
			}
			else
			{
				Duration = TimeSpan.Zero;
			}

			Burning = false;
			Light = LightType.Circle150;
			Weight = 1.0;
		}

		public CandleLong(Serial serial) : base(serial)
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

	/// CandleShort
	public class CandleShort : BaseLight
	{
		public override int LitItemID => 0x142C;
		public override int UnlitItemID => 0x142F;

		[Constructable]
		public CandleShort() : base(0x142F)
		{
			if (Burnout)
			{
				Duration = TimeSpan.FromMinutes(25);
			}
			else
			{
				Duration = TimeSpan.Zero;
			}

			Burning = false;
			Light = LightType.Circle150;
			Weight = 1.0;
		}

		public CandleShort(Serial serial) : base(serial)
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

	/// CandleLarge
	public class CandleLarge : BaseLight
	{
		public override int LitItemID => 0xB1A;
		public override int UnlitItemID => 0xA26;

		[Constructable]
		public CandleLarge() : base(0xA26)
		{
			if (Burnout)
			{
				Duration = TimeSpan.FromMinutes(25);
			}
			else
			{
				Duration = TimeSpan.Zero;
			}

			Burning = false;
			Light = LightType.Circle150;
			Weight = 2.0;
		}

		public CandleLarge(Serial serial) : base(serial)
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

	/// CandleSkull
	public class CandleSkull : BaseLight
	{
		public override int LitItemID
		{
			get
			{
				if (ItemID == 0x1583 || ItemID == 0x1854)
				{
					return 0x1854;
				}

				return 0x1858;
			}
		}

		public override int UnlitItemID
		{
			get
			{
				if (ItemID == 0x1853 || ItemID == 0x1584)
				{
					return 0x1853;
				}

				return 0x1857;
			}
		}

		[Constructable]
		public CandleSkull() : base(0x1853)
		{
			if (Burnout)
			{
				Duration = TimeSpan.FromMinutes(25);
			}
			else
			{
				Duration = TimeSpan.Zero;
			}

			Burning = false;
			Light = LightType.Circle150;
			Weight = 5.0;
		}

		public CandleSkull(Serial serial) : base(serial)
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
}