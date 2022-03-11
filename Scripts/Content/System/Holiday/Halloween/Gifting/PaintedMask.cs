
using System;

namespace Server.Items.Holiday
{
	[TypeAlias("Server.Items.ClownMask", "Server.Items.DaemonMask", "Server.Items.PlagueMask")]
	public class BasePaintedMask : Item
	{
		public override string DefaultName
		{
			get
			{
				if (m_Staffer != null)
				{
					return String.Format("{0} hand painted by {1}", MaskName, m_Staffer);
				}

				return MaskName;
			}
		}

		public virtual string MaskName => "A Mask";

		private string m_Staffer;

		private static readonly string[] m_Staffers =
		{
				  "Ryan",
				  "Mark",
				  "Krrios",
				  "Zippy",
				  "Athena",
				  "Eos",
				  "Xavier"
		};

		public BasePaintedMask(int itemid)
			: this(m_Staffers[Utility.Random(m_Staffers.Length)], itemid)
		{

		}

		public BasePaintedMask(string staffer, int itemid)
			: base(itemid + Utility.Random(2))
		{
			m_Staffer = staffer;

			Utility.Intern(m_Staffer);
		}

		public BasePaintedMask(Serial serial) : base(serial)
		{

		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
			writer.Write(m_Staffer);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version == 1)
			{
				m_Staffer = Utility.Intern(reader.ReadString());
			}
		}
	}

	public class PaintedEvilClownMask : BasePaintedMask
	{
		public override string MaskName => "Evil Clown Mask";

		[Constructable]
		public PaintedEvilClownMask()
			: base(0x4a90)
		{
		}

		public PaintedEvilClownMask(Serial serial)
			: base(serial)
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

	public class PaintedDaemonMask : BasePaintedMask
	{
		public override string MaskName => "Daemon Mask";

		[Constructable]
		public PaintedDaemonMask()
			: base(0x4a92)
		{
		}

		public PaintedDaemonMask(Serial serial)
			: base(serial)
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

	public class PaintedPlagueMask : BasePaintedMask
	{
		public override string MaskName => "Plague Mask";

		[Constructable]
		public PaintedPlagueMask()
			: base(0x4A8E)
		{
		}

		public PaintedPlagueMask(Serial serial)
			: base(serial)
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

	public class PaintedEvilJesterMask : BasePaintedMask
	{
		public override string MaskName => "Evil Jester Mask";

		[Constructable]
		public PaintedEvilJesterMask()
			: base(0x4BA5)
		{
		}

		public PaintedEvilJesterMask(Serial serial)
			: base(serial)
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

	public class PaintedPorcelainMask : BasePaintedMask
	{
		public override string MaskName => "Porcelain Mask";

		[Constructable]
		public PaintedPorcelainMask()
			: base(0x4BA7)
		{
		}

		public PaintedPorcelainMask(Serial serial)
			: base(serial)
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
		}
	}
}