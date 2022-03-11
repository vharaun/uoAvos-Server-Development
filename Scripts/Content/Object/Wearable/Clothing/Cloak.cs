
using System;

namespace Server.Items
{
	/// Cloak
	[Flipable]
	public class Cloak : BaseCloak, IArcaneEquip
	{
		#region Arcane Impl
		private int m_MaxArcaneCharges, m_CurArcaneCharges;

		[CommandProperty(AccessLevel.GameMaster)]
		public int MaxArcaneCharges
		{
			get => m_MaxArcaneCharges;
			set { m_MaxArcaneCharges = value; InvalidateProperties(); Update(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int CurArcaneCharges
		{
			get => m_CurArcaneCharges;
			set { m_CurArcaneCharges = value; InvalidateProperties(); Update(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsArcane => (m_MaxArcaneCharges > 0 && m_CurArcaneCharges >= 0);

		public void Update()
		{
			if (IsArcane)
			{
				ItemID = 0x26AD;
			}
			else if (ItemID == 0x26AD)
			{
				ItemID = 0x1515;
			}

			if (IsArcane && CurArcaneCharges == 0)
			{
				Hue = 0;
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (IsArcane)
			{
				list.Add(1061837, "{0}\t{1}", m_CurArcaneCharges, m_MaxArcaneCharges); // arcane charges: ~1_val~ / ~2_val~
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			base.OnSingleClick(from);

			if (IsArcane)
			{
				LabelTo(from, 1061837, String.Format("{0}\t{1}", m_CurArcaneCharges, m_MaxArcaneCharges));
			}
		}

		public void Flip()
		{
			if (ItemID == 0x1515)
			{
				ItemID = 0x1530;
			}
			else if (ItemID == 0x1530)
			{
				ItemID = 0x1515;
			}
		}
		#endregion

		[Constructable]
		public Cloak() : this(0)
		{
		}

		[Constructable]
		public Cloak(int hue) : base(0x1515, hue)
		{
			Weight = 5.0;
		}

		public Cloak(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version

			if (IsArcane)
			{
				writer.Write(true);
				writer.Write(m_CurArcaneCharges);
				writer.Write(m_MaxArcaneCharges);
			}
			else
			{
				writer.Write(false);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						if (reader.ReadBool())
						{
							m_CurArcaneCharges = reader.ReadInt();
							m_MaxArcaneCharges = reader.ReadInt();

							if (Hue == 2118)
							{
								Hue = ArcaneGem.DefaultArcaneHue;
							}
						}

						break;
					}
			}

			if (Weight == 4.0)
			{
				Weight = 5.0;
			}
		}
	}
}