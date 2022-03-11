
using System;

namespace Server.Items
{
	public class ShipModel : Item
	{
		private static readonly string[] m_ShipModelNames = new string[]
		{
			"HMS Cape",
			"HMS Britannic"
		};

		public override string DefaultName => String.Format("Mysterious Wreck of The {0}", m_ShipModelNames);

		[Constructable]
		public ShipModel() : base(0x14F3)
		{
			Name = DefaultName;
			Hue = 0x37B;
			Weight = 1.0;
			LootType = LootType.Cursed;
		}

		public ShipModel(Serial serial) : base(serial)
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