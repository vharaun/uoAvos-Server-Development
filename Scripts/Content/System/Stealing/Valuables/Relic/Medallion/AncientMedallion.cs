
using System;

namespace Server.Items
{
	[Flipable(0x1884, 0x1886)]
	public class AncientMedallion : Item
	{
		private static readonly string[] m_AncientMedallionNames = new string[]
		{
			"Ancient Relic of Daventry",
			"Lost Medallion of the Crimson Blood",
			"Ancient Sigil of the Lost Order"
		};

		public override string DefaultName => String.Format("{0}", m_AncientMedallionNames);

		[Constructable]
		public AncientMedallion() : base(0x1884)
		{
			Name = DefaultName;
			Hue = Utility.RandomNeutralHue();
			Weight = 1.0;
			LootType = LootType.Cursed;
		}

		#region Add Effects To This Medallion

		public override void OnDoubleClick(Mobile from)
		{
			switch (Utility.Random(0))
			{
				case 3:
					{

						break;
					}
				case 2:
					{

						break;
					}
				case 1:
					{

						break;
					}
				case 0:
					{

						break;
					}
			}

			base.OnDoubleClick(from);
		}

		#endregion

		public AncientMedallion(Serial serial) : base(serial)
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