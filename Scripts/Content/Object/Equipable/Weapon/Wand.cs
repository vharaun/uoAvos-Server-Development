
using System;

namespace Server.Items
{
	/// MagicWand
	public class MagicWand : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.Dismount;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Disarm;

		public override int AosStrengthReq => 5;
		public override int AosMinDamage => 9;
		public override int AosMaxDamage => 11;
		public override int AosSpeed => 40;
		public override float MlSpeed => 2.75f;

		public override int OldStrengthReq => 0;
		public override int OldMinDamage => 2;
		public override int OldMaxDamage => 6;
		public override int OldSpeed => 35;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 110;

		[Constructable]
		public MagicWand() : base(0xDF2)
		{
			Weight = 1.0;
		}

		public MagicWand(Serial serial) : base(serial)
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

	/// FireworksWand
	public class FireworksWand : MagicWand
	{
		public override int LabelNumber => 1041424;  // a fireworks wand

		private int m_Charges;

		[CommandProperty(AccessLevel.GameMaster)]
		public int Charges
		{
			get => m_Charges;
			set { m_Charges = value; InvalidateProperties(); }
		}

		[Constructable]
		public FireworksWand() : this(100)
		{
		}

		[Constructable]
		public FireworksWand(int charges)
		{
			m_Charges = charges;
			LootType = LootType.Blessed;
		}

		public FireworksWand(Serial serial) : base(serial)
		{
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1060741, m_Charges.ToString()); // charges: ~1_val~
		}

		public override void OnDoubleClick(Mobile from)
		{
			BeginLaunch(from, true);
		}

		public void BeginLaunch(Mobile from, bool useCharges)
		{
			var map = from.Map;

			if (map == null || map == Map.Internal)
			{
				return;
			}

			if (useCharges)
			{
				if (Charges > 0)
				{
					--Charges;
				}
				else
				{
					from.SendLocalizedMessage(502412); // There are no charges left on that item.
					return;
				}
			}

			from.SendLocalizedMessage(502615); // You launch a firework!

			var ourLoc = GetWorldLocation();

			var startLoc = new Point3D(ourLoc.X, ourLoc.Y, ourLoc.Z + 10);
			var endLoc = new Point3D(startLoc.X + Utility.RandomMinMax(-2, 2), startLoc.Y + Utility.RandomMinMax(-2, 2), startLoc.Z + 32);

			Effects.SendMovingEffect(new Entity(Serial.Zero, startLoc, map), new Entity(Serial.Zero, endLoc, map),
				0x36E4, 5, 0, false, false);

			Timer.DelayCall(TimeSpan.FromSeconds(1.0), FinishLaunch, new object[] { from, endLoc, map });
		}

		private void FinishLaunch(object state)
		{
			var states = (object[])state;

			var from = (Mobile)states[0];
			var endLoc = (Point3D)states[1];
			var map = (Map)states[2];

			var hue = Utility.Random(40);

			if (hue < 8)
			{
				hue = 0x66D;
			}
			else if (hue < 10)
			{
				hue = 0x482;
			}
			else if (hue < 12)
			{
				hue = 0x47E;
			}
			else if (hue < 16)
			{
				hue = 0x480;
			}
			else if (hue < 20)
			{
				hue = 0x47F;
			}
			else
			{
				hue = 0;
			}

			if (Utility.RandomBool())
			{
				hue = Utility.RandomList(0x47E, 0x47F, 0x480, 0x482, 0x66D);
			}

			var renderMode = Utility.RandomList(0, 2, 3, 4, 5, 7);

			Effects.PlaySound(endLoc, map, Utility.Random(0x11B, 4));
			Effects.SendLocationEffect(endLoc, map, 0x373A + (0x10 * Utility.Random(4)), 16, 10, hue, renderMode);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_Charges);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Charges = reader.ReadInt();
						break;
					}
			}
		}
	}
}