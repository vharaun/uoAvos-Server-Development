using Server.Multis;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	/// WoodenBox
	[Furniture]
	[Flipable(0x9AA, 0xE7D)]
	public class WoodenBox : LockableContainer
	{
		[Constructable]
		public WoodenBox() : base(0x9AA)
		{
			Weight = 4.0;
		}

		public WoodenBox(Serial serial) : base(serial)
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

	/// MetalBox
	[DynamicFliping]
	[Flipable(0x9A8, 0xE80)]
	public class MetalBox : LockableContainer
	{
		[Constructable]
		public MetalBox() : base(0x9A8)
		{
		}

		public MetalBox(Serial serial) : base(serial)
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

			if (version == 0 && Weight == 3)
			{
				Weight = -1;
			}
		}
	}

	/// StrongBox
	[FlipableAttribute(0xE80, 0x9A8)]
	public class StrongBox : BaseContainer, IChopable
	{
		private Mobile m_Owner;
		private BaseHouse m_House;

		public override double DefaultWeight => 100;
		public override int LabelNumber => 1023712;

		public StrongBox(Mobile owner, BaseHouse house) : base(0xE80)
		{
			m_Owner = owner;
			m_House = house;

			MaxItems = 25;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Owner
		{
			get => m_Owner;
			set
			{
				m_Owner = value;
				InvalidateProperties();
			}
		}

		public override int DefaultMaxWeight => 0;

		public StrongBox(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_Owner);
			writer.Write(m_House);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Owner = reader.ReadMobile();
						m_House = reader.ReadItem() as BaseHouse;

						break;
					}
			}

			Timer.DelayCall(TimeSpan.FromSeconds(1.0), Validate);
		}

		private void Validate()
		{
			if (m_Owner != null && m_House != null && !m_House.IsCoOwner(m_Owner))
			{
				Console.WriteLine("Warning: Destroying strongbox of {0}", m_Owner.Name);
				Destroy();
			}
		}

		public override bool Decays
		{
			get
			{
				if (m_House != null && m_Owner != null && !m_Owner.Deleted)
				{
					return !m_House.IsCoOwner(m_Owner);
				}
				else
				{
					return true;
				}
			}
		}

		public override TimeSpan DecayTime => TimeSpan.FromMinutes(30.0);

		public override void AddNameProperty(ObjectPropertyList list)
		{
			if (m_Owner != null)
			{
				list.Add(1042887, m_Owner.Name); // a strong box owned by ~1_OWNER_NAME~
			}
			else
			{
				base.AddNameProperty(list);
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			if (m_Owner != null)
			{
				LabelTo(from, 1042887, m_Owner.Name); // a strong box owned by ~1_OWNER_NAME~

				if (CheckContentDisplay(from))
				{
					LabelTo(from, "({0} items, {1} stones)", TotalItems, TotalWeight);
				}
			}
			else
			{
				base.OnSingleClick(from);
			}
		}

		public override bool IsAccessibleTo(Mobile m)
		{
			if (m_Owner == null || m_Owner.Deleted || m_House == null || m_House.Deleted || m.AccessLevel >= AccessLevel.GameMaster)
			{
				return true;
			}

			return m == m_Owner && m_House.IsCoOwner(m) && base.IsAccessibleTo(m);
		}

		private void Chop(Mobile from)
		{
			Effects.PlaySound(Location, Map, 0x3B3);
			from.SendLocalizedMessage(500461); // You destroy the item.
			Destroy();
		}

		public void OnChop(Mobile from)
		{
			if (m_House != null && !m_House.Deleted && m_Owner != null && !m_Owner.Deleted)
			{
				if (from == m_Owner || m_House.IsOwner(from))
				{
					Chop(from);
				}
			}
			else
			{
				Chop(from);
			}
		}

		public Container ConvertToStandardContainer()
		{
			Container metalBox = new MetalBox();
			var subItems = new List<Item>(Items);

			foreach (var subItem in subItems)
			{
				metalBox.AddItem(subItem);
			}

			Delete();

			return metalBox;
		}
	}
}