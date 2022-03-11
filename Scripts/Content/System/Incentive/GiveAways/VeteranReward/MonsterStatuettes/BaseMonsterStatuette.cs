using Server.Engines.VeteranRewards;
using Server.Gumps;
using Server.Multis;
using Server.Network;

namespace Server.Items
{
	public partial class MonsterStatuetteInfo
	{
		private readonly int m_LabelNumber;
		private readonly int m_ItemID;
		private readonly int[] m_Sounds;

		public int LabelNumber => m_LabelNumber;
		public int ItemID => m_ItemID;
		public int[] Sounds => m_Sounds;

		public MonsterStatuetteInfo(int labelNumber, int itemID, int baseSoundID)
		{
			m_LabelNumber = labelNumber;
			m_ItemID = itemID;
			m_Sounds = new int[] { baseSoundID, baseSoundID + 1, baseSoundID + 2, baseSoundID + 3, baseSoundID + 4 };
		}

		public MonsterStatuetteInfo(int labelNumber, int itemID, int[] sounds)
		{
			m_LabelNumber = labelNumber;
			m_ItemID = itemID;
			m_Sounds = sounds;
		}

		public static MonsterStatuetteInfo GetInfo(MonsterStatuetteType type)
		{
			var v = (int)type;

			if (v < 0 || v >= m_Table.Length)
			{
				v = 0;
			}

			return m_Table[v];
		}
	}

	public class MonsterStatuette : Item, IRewardItem
	{
		private MonsterStatuetteType m_Type;
		private bool m_TurnedOn;
		private bool m_IsRewardItem;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsRewardItem
		{
			get => m_IsRewardItem;
			set => m_IsRewardItem = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool TurnedOn
		{
			get => m_TurnedOn;
			set { m_TurnedOn = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public MonsterStatuetteType Type
		{
			get => m_Type;
			set
			{
				m_Type = value;
				ItemID = MonsterStatuetteInfo.GetInfo(m_Type).ItemID;

				if (m_Type == MonsterStatuetteType.Slime)
				{
					Hue = Utility.RandomSlimeHue();
				}
				else if (m_Type == MonsterStatuetteType.RedDeath)
				{
					Hue = 0x21;
				}
				else if (m_Type == MonsterStatuetteType.HalloweenGhoul)
				{
					Hue = 0xF4;
				}
				else
				{
					Hue = 0;
				}

				InvalidateProperties();
			}
		}

		public override int LabelNumber => MonsterStatuetteInfo.GetInfo(m_Type).LabelNumber;

		public override double DefaultWeight => 1.0;

		[Constructable]
		public MonsterStatuette() : this(MonsterStatuetteType.Crocodile)
		{
		}

		[Constructable]
		public MonsterStatuette(MonsterStatuetteType type) : base(MonsterStatuetteInfo.GetInfo(type).ItemID)
		{
			LootType = LootType.Blessed;

			m_Type = type;

			if (m_Type == MonsterStatuetteType.Slime)
			{
				Hue = Utility.RandomSlimeHue();
			}
			else if (m_Type == MonsterStatuetteType.RedDeath)
			{
				Hue = 0x21;
			}
			else if (m_Type == MonsterStatuetteType.HalloweenGhoul)
			{
				Hue = 0xF4;
			}
		}

		public override bool HandlesOnMovement => m_TurnedOn && IsLockedDown;

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			if (m_TurnedOn && IsLockedDown && (!m.Hidden || m.AccessLevel == AccessLevel.Player) && Utility.InRange(m.Location, Location, 2) && !Utility.InRange(oldLocation, Location, 2))
			{
				var sounds = MonsterStatuetteInfo.GetInfo(m_Type).Sounds;

				if (sounds.Length > 0)
				{
					Effects.PlaySound(Location, Map, sounds[Utility.Random(sounds.Length)]);
				}
			}

			base.OnMovement(m, oldLocation);
		}

		public MonsterStatuette(Serial serial) : base(serial)
		{
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Core.ML && m_IsRewardItem)
			{
				list.Add(RewardSystem.GetRewardYearLabel(this, new object[] { m_Type })); // X Year Veteran Reward
			}

			if (m_TurnedOn)
			{
				list.Add(502695); // turned on
			}
			else
			{
				list.Add(502696); // turned off
			}
		}

		public bool IsOwner(Mobile mob)
		{
			var house = BaseHouse.FindHouseAt(this);

			return (house != null && house.IsOwner(mob));
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsOwner(from))
			{
				var onOffGump = new OnOffGump(this);
				from.SendGump(onOffGump);
			}
			else
			{
				from.SendLocalizedMessage(502691); // You must be the owner to use this.
			}
		}

		private class OnOffGump : Gump
		{
			private readonly MonsterStatuette m_Statuette;

			public OnOffGump(MonsterStatuette statuette) : base(150, 200)
			{
				m_Statuette = statuette;

				AddBackground(0, 0, 300, 150, 0xA28);

				AddHtmlLocalized(45, 20, 300, 35, statuette.TurnedOn ? 1011035 : 1011034, false, false); // [De]Activate this item

				AddButton(40, 53, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0);
				AddHtmlLocalized(80, 55, 65, 35, 1011036, false, false); // OKAY

				AddButton(150, 53, 0xFA5, 0xFA7, 0, GumpButtonType.Reply, 0);
				AddHtmlLocalized(190, 55, 100, 35, 1011012, false, false); // CANCEL
			}

			public override void OnResponse(NetState sender, RelayInfo info)
			{
				var from = sender.Mobile;

				if (info.ButtonID == 1)
				{
					var newValue = !m_Statuette.TurnedOn;
					m_Statuette.TurnedOn = newValue;

					if (newValue && !m_Statuette.IsLockedDown)
					{
						from.SendLocalizedMessage(502693); // Remember, this only works when locked down.
					}
				}
				else
				{
					from.SendLocalizedMessage(502694); // Cancelled action.
				}
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.WriteEncodedInt((int)m_Type);
			writer.Write(m_TurnedOn);
			writer.Write(m_IsRewardItem);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Type = (MonsterStatuetteType)reader.ReadEncodedInt();
						m_TurnedOn = reader.ReadBool();
						m_IsRewardItem = reader.ReadBool();
						break;
					}
			}
		}
	}
}