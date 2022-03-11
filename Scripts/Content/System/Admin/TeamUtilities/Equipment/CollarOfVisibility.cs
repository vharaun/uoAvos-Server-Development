using Server.ContextMenus;

using System.Collections.Generic;

namespace Server.Items.Staff
{
	public enum CollarEffect
	{
		FlameStrike1, FlameStrike3, FlameStrikeLightningBolt, Sparkle1, Sparkle3, Explosion, ExplosionLightningBolt, DefaultRunUO
	}

	public class CollarOfVisibility : BaseNecklace
	{
		private Mobile m_Owner;
		public Point3D m_HomeLocation;
		public Map m_HomeMap;

		public CollarEffect mAppearEffect;
		public CollarEffect mHideEffect;

		[CommandProperty(AccessLevel.Counselor)]
		public CollarEffect AppearEffect
		{
			get => mAppearEffect;
			set { if ((value <= CollarEffect.DefaultRunUO) && (value >= CollarEffect.FlameStrike1)) { mAppearEffect = value; } else { return; }; }
		}

		[CommandProperty(AccessLevel.Counselor)]
		public CollarEffect HideEffect
		{
			get => mHideEffect;
			set { if ((value <= CollarEffect.DefaultRunUO) && (value >= CollarEffect.FlameStrike1)) { mHideEffect = value; } else { return; }; }
		}

		[Constructable]
		public CollarOfVisibility() : base(0x1F08)
		{
			LootType = LootType.Blessed;
			Weight = 1.0;
			Hue = 2406;
			Name = "An Unassigned Collar";

			Attributes.BonusHits = 50;
			Attributes.Luck = 1500;

			mAppearEffect = CollarEffect.DefaultRunUO;
			mHideEffect = CollarEffect.DefaultRunUO;
		}

		public override void OnDoubleClick(Mobile m)
		{
			if (m_Owner == null && m.AccessLevel == AccessLevel.Player)
			{
				m.SendMessage("Only the server administration can use this item!");
				//this.Delete();
			}

			else if (m_Owner == null && m.AccessLevel == AccessLevel.Counselor)
			{
				m.SendMessage("Only the server administration can use this item!");
				//this.Delete();
			}

			else if (m_Owner == null)
			{
				m_Owner = m;
				Name = m_Owner.Name.ToString() + "'s Collar of Visibility";
				HomeLocation = m.Location;
				HomeMap = m.Map;
				m.SendMessage("This collar has been assigned to you.");
			}
			else
			{
				if (m_Owner != m)
				{
					m.SendMessage("This item has not been assigned to you!");
					return;
				}
			}

			if (m.AccessLevel > AccessLevel.Player)
			{
				if (m.Hidden)
				{
					m.Hidden = false;
					SendCollarEffects(mAppearEffect, m);
				}
				else
				{
					SendCollarEffects(mHideEffect, m);
					m.Hidden = true;
				}
			}
			else
			{
				m.SendMessage("");
			}
		}

		public void SendCollarEffects(CollarEffect mCollarEffect, Mobile m)
		{
			switch (mCollarEffect)
			{
				case CollarEffect.FlameStrike1:
					Effects.SendLocationEffect(new Point3D(m.X, m.Y, m.Z + 1), m.Map, 0x3709, 15);
					Effects.PlaySound(new Point3D(m.X, m.Y, m.Z), m.Map, 0x208);
					break;
				case CollarEffect.FlameStrike3:
					Effects.SendLocationEffect(new Point3D(m.X, m.Y, m.Z + 1), m.Map, 0x3709, 15);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y, m.Z + 6), m.Map, 0x3709, 15);
					Effects.SendLocationEffect(new Point3D(m.X, m.Y + 1, m.Z + 6), m.Map, 0x3709, 15);
					Effects.PlaySound(new Point3D(m.X, m.Y, m.Z), m.Map, 0x208);
					break;
				case CollarEffect.FlameStrikeLightningBolt:
					Effects.SendLocationEffect(new Point3D(m.X, m.Y, m.Z + 1), m.Map, 0x3709, 15);
					Effects.PlaySound(new Point3D(m.X, m.Y, m.Z), m.Map, 0x208);
					Effects.SendBoltEffect(m, true, 0);
					break;
				case CollarEffect.Sparkle1:
					Effects.SendLocationEffect(new Point3D(m.X, m.Y, m.Z + 1), m.Map, 0x375A, 15);
					Effects.PlaySound(new Point3D(m.X, m.Y, m.Z), m.Map, 0x213);
					break;
				case CollarEffect.Sparkle3:
					Effects.SendLocationEffect(new Point3D(m.X, m.Y + 1, m.Z), m.Map, 0x373A, 15);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y, m.Z), m.Map, 0x373A, 15);
					Effects.SendLocationEffect(new Point3D(m.X, m.Y, m.Z - 1), m.Map, 0x373A, 15);
					Effects.PlaySound(new Point3D(m.X, m.Y, m.Z), m.Map, 0x213);
					break;
				case CollarEffect.Explosion:
					Effects.SendLocationEffect(new Point3D(m.X, m.Y, m.Z + 1), m.Map, 0x36BD, 15);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y, m.Z), m.Map, 0x36BD, 15);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y + 1, m.Z), m.Map, 0x36BD, 15);
					Effects.SendLocationEffect(new Point3D(m.X, m.Y + 1, m.Z), m.Map, 0x36BD, 15);
					Effects.PlaySound(new Point3D(m.X, m.Y, m.Z), m.Map, 0x307);
					break;
				case CollarEffect.ExplosionLightningBolt:
					Effects.SendLocationEffect(new Point3D(m.X, m.Y, m.Z + 1), m.Map, 0x36BD, 15);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y, m.Z), m.Map, 0x36BD, 15);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y + 1, m.Z), m.Map, 0x36BD, 15);
					Effects.SendLocationEffect(new Point3D(m.X, m.Y + 1, m.Z), m.Map, 0x36BD, 15);
					Effects.SendBoltEffect(m, true, 0);
					Effects.PlaySound(new Point3D(m.X, m.Y, m.Z), m.Map, 0x307);
					break;
				case CollarEffect.DefaultRunUO:
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y, m.Z + 4), m.Map, 0x3728, 13);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y, m.Z), m.Map, 0x3728, 13);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y, m.Z - 4), m.Map, 0x3728, 13);
					Effects.SendLocationEffect(new Point3D(m.X, m.Y + 1, m.Z + 4), m.Map, 0x3728, 13);
					Effects.SendLocationEffect(new Point3D(m.X, m.Y + 1, m.Z), m.Map, 0x3728, 13);
					Effects.SendLocationEffect(new Point3D(m.X, m.Y + 1, m.Z - 4), m.Map, 0x3728, 13);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y + 1, m.Z + 11), m.Map, 0x3728, 13);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y + 1, m.Z + 7), m.Map, 0x3728, 13);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y + 1, m.Z + 3), m.Map, 0x3728, 13);
					Effects.SendLocationEffect(new Point3D(m.X + 1, m.Y + 1, m.Z - 1), m.Map, 0x3728, 13);
					Effects.PlaySound(new Point3D(m.X, m.Y, m.Z), m.Map, 0x228);
					break;
			}
		}

		public CollarOfVisibility(Serial serial) : base(serial)
		{
		}


		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D HomeLocation
		{
			get => m_HomeLocation;
			set => m_HomeLocation = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Map HomeMap
		{
			get => m_HomeMap;
			set => m_HomeMap = value;
		}

		private class GoHomeEntry : ContextMenuEntry
		{
			private readonly CollarOfVisibility m_Item;
			private readonly Mobile m_Mobile;

			public GoHomeEntry(Mobile from, Item item) : base(5134) // uses "Goto Loc" entry
			{
				m_Item = (CollarOfVisibility)item;
				m_Mobile = from;
			}

			public override void OnClick()
			{
				m_Mobile.Location = m_Item.HomeLocation;
				if (m_Item.HomeMap != null)
				{
					m_Mobile.Map = m_Item.HomeMap;
				}
			}
		}

		private class SetHomeEntry : ContextMenuEntry
		{
			private readonly CollarOfVisibility m_Item;
			private readonly Mobile m_Mobile;

			public SetHomeEntry(Mobile from, Item item) : base(2055) // uses "Mark" entry
			{
				m_Item = (CollarOfVisibility)item;
				m_Mobile = from;
			}

			public override void OnClick()
			{
				m_Item.HomeLocation = m_Mobile.Location;
				m_Item.HomeMap = m_Mobile.Map;
				m_Mobile.SendMessage("The home location on your collar has been set to your current position.");
			}
		}

		public static void GetContextMenuEntries(Mobile from, Item item, List<ContextMenuEntry> list)
		{
			list.Add(new GoHomeEntry(from, item));
			list.Add(new SetHomeEntry(from, item));
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			if (m_Owner == null)
			{
				return;
			}
			else
			{
				if (m_Owner != from)
				{
					from.SendMessage("This collar is not yours to use.");
					return;
				}
				else
				{
					base.GetContextMenuEntries(from, list);
					CollarOfVisibility.GetContextMenuEntries(from, this, list);
				}
			}
		}

		public override bool OnEquip(Mobile from)
		{
			if (from.AccessLevel < AccessLevel.GameMaster)
			{
				from.SendMessage("This ring can only be used by server administrators!");
				//this.Delete();
			}
			return true;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(1); // version

			writer.Write(m_HomeLocation);
			writer.Write(m_HomeMap);
			writer.Write(m_Owner);

			writer.Write((int)mAppearEffect);
			writer.Write((int)mHideEffect);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
			switch (version)
			{
				case 1:
					{
						m_HomeLocation = reader.ReadPoint3D();
						m_HomeMap = reader.ReadMap();
						m_Owner = reader.ReadMobile();
					}
					goto case 0;
				case 0:
					{
						mAppearEffect = (CollarEffect)reader.ReadInt();
						mHideEffect = (CollarEffect)reader.ReadInt();
						break;
					}
			}
		}
	}
}