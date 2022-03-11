using Server.Engines.VeteranRewards;

namespace Server.Items
{
	public class RedSoulstone : SoulStone, IRewardItem
	{
		[Constructable]
		public RedSoulstone()
			: this(null)
		{
		}

		[Constructable]
		public RedSoulstone(string account)
			: base(account, 0x32F3, 0x32F4)
		{

		}

		public RedSoulstone(Serial serial)
			: base(serial)
		{
		}

		private bool m_IsRewardItem;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsRewardItem
		{
			get => m_IsRewardItem;
			set { m_IsRewardItem = value; InvalidateProperties(); }
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (m_IsRewardItem)
			{
				list.Add(1076217); // 1st Year Veteran Reward
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version

			writer.Write(m_IsRewardItem);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_IsRewardItem = reader.ReadBool();
						break;
					}
			}
		}
	}
}