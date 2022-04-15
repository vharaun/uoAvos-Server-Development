using Server.Accounting;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	[Furniture]
	[Flipable(0x232A, 0x232B)]
	public class GiftBox : BaseContainer
	{
		[Constructable]
		public GiftBox() : this(Utility.RandomDyedHue())
		{
		}

		[Constructable]
		public GiftBox(int hue) : base(Utility.Random(0x232A, 2))
		{
			Weight = 2.0;
			Hue = hue;
		}

		public GiftBox(Serial serial) : base(serial)
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

	public class GiftBoxHues
	{
		public static int RandomGiftBoxHue => m_NormalHues[Utility.Random(m_NormalHues.Length)];
		public static int RandomNeonBoxHue => m_NeonHues[Utility.Random(m_NeonHues.Length)];

		/* there's possibly a couple more, but this is what we could verify on OSI */

		private static readonly int[] m_NormalHues =
		{
			0x672,
			0x454,
			0x507,
			0x4ac,
			0x504,
			0x84b,
			0x495,
			0x97c,
			0x493,
			0x4a8,
			0x494,
			0x4aa,
			0xb8b,
			0x84f,
			0x491,
			0x851,
			0x503,
			0xb8c,
			0x4ab,
			0x84B
		};
		private static readonly int[] m_NeonHues =
		{
			0x438,
			0x424,
			0x433,
			0x445,
			0x42b,
			0x448
		};
	}

	#region Empty Gift Box Items

	/// GiftBoxAngel
	public class GiftBoxAngel : BaseContainer
	{
		public override int DefaultGumpID => 0x11F;

		[Constructable]
		public GiftBoxAngel()
			: base(0x46A7)
		{
			Hue = GiftBoxHues.RandomGiftBoxHue;
		}

		public GiftBoxAngel(Serial serial)
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

	/// GiftBoxCube
	public class GiftBoxCube : BaseContainer
	{
		public override int DefaultGumpID => 0x11B;

		[Constructable]
		public GiftBoxCube()
			: base(0x46A2)
		{
			Hue = GiftBoxHues.RandomGiftBoxHue;
		}

		public GiftBoxCube(Serial serial)
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

	/// GiftBoxCylinder
	public class GiftBoxCylinder : BaseContainer
	{
		public override int DefaultGumpID => 0x11C;

		[Constructable]
		public GiftBoxCylinder()
			: base(0x46A3)
		{
			Hue = GiftBoxHues.RandomGiftBoxHue;
		}

		public GiftBoxCylinder(Serial serial)
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

	/// GiftBoxNeon
	[Flipable(0x232A, 0x232B)]
	public class GiftBoxNeon : BaseContainer
	{
		[Constructable]
		public GiftBoxNeon()
			: base(Utility.RandomBool() ? 0x232A : 0x232B)
		{
			Hue = GiftBoxHues.RandomNeonBoxHue;
		}

		public GiftBoxNeon(Serial serial)
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

	/// GiftBoxOctogon
	public class GiftBoxOctogon : BaseContainer
	{
		public override int DefaultGumpID => 0x11D;

		[Constructable]
		public GiftBoxOctogon()
			: base(0x46A4)
		{
			Hue = GiftBoxHues.RandomGiftBoxHue;
		}

		public GiftBoxOctogon(Serial serial)
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

	/// GiftBoxRectangle
	[FlipableAttribute(0x46A5, 0x46A6)]
	public class GiftBoxRectangle : BaseContainer
	{
		public override int DefaultGumpID => 0x11E;

		[Constructable]
		public GiftBoxRectangle()
			: base(Utility.RandomBool() ? 0x46A5 : 0x46A6)
		{
			Hue = GiftBoxHues.RandomGiftBoxHue;
		}

		public GiftBoxRectangle(Serial serial)
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

	/// VelvetGiftBox
	public class VelvetGiftBox : BaseContainer
	{
		public override int DefaultGumpID => 0x3f;

		[Constructable]
		public VelvetGiftBox()
			: this(false)
		{
		}

		[Constructable]
		public VelvetGiftBox(bool fill)
			: base(0xE7A)
		{
			Name = "Velvet Gift Box";

			Hue = 0x20;

			if (fill)
			{
				for (var i = 0; i < 5; i++)
				{
					AddToBox(new /*youritemhere*/(), new Point3D(60 + (i * 10), 47, 0));
					AddToBox(new /*youritemhere*/(), new Point3D(20 + (i * 10), 72, 0));
				}
				AddToBox(new /*youritemhere*/(), new Point3D(90, 85, 0));
				AddToBox(new /*youritemhere*/(), new Point3D(130, 55, 0));
			}
		}

		public virtual void AddToBox(Item item, Point3D loc)
		{
			DropItem(item);
			item.Location = loc;
		}

		public VelvetGiftBox(Serial serial)
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

	/// HeartShapedBox
	[FlipableAttribute(0x49CA, 0x49CB)]
	public class HeartShapedBox : BaseContainer
	{
		public override int DefaultDropSound => m_DropSound;

		[Constructable]
		public HeartShapedBox()
			: base(0x49CA)
		{
		}

		public override bool OnDragDropInto(Mobile from, Item item, Point3D p)
		{
			PrepareSound(from);
			return base.OnDragDropInto(from, item, p);
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			PrepareSound(from);
			return base.OnDragDrop(from, dropped);
		}

		private static int m_DropSound;

		private static void PrepareSound(Mobile from)
		{
			m_DropSound = from.Female ? 0x430 : 0x320;
		}

		public HeartShapedBox(Serial serial)
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

	/// AnimatedHeartShapedBox
	[FlipableAttribute(0x49CC, 0x49D0)]
	public class AnimatedHeartShapedBox : HeartShapedBox
	{
		[Constructable]
		public AnimatedHeartShapedBox()
		{
			ItemID = 0x49CC;
		}

		public AnimatedHeartShapedBox(Serial serial)
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

	/// GreenStocking
	[Furniture]
	[FlipableAttribute(0x2bd9, 0x2bda)]
	public class GreenStocking : BaseContainer
	{
		public override int DefaultGumpID => 0x103;
		public override int DefaultDropSound => 0x42;

		[Constructable]
		public GreenStocking() : base(Utility.Random(0x2BD9, 2))
		{
		}

		public GreenStocking(Serial serial) : base(serial)
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

	/// RedStocking
	[Furniture]
	[FlipableAttribute(0x2bdb, 0x2bdc)]
	public class RedStocking : BaseContainer
	{
		public override int DefaultGumpID => 0x103;
		public override int DefaultDropSound => 0x42;

		[Constructable]
		public RedStocking() : base(Utility.Random(0x2BDB, 2))
		{
		}

		public RedStocking(Serial serial) : base(serial)
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

	#endregion
}

namespace Server.Misc
{
	public enum GiftResult
	{
		Backpack,
		BankBox
	}

	public class GiftGiving
	{
		private static readonly List<GiftGiver> m_Givers = new List<GiftGiver>();

		public static void Register(GiftGiver giver)
		{
			m_Givers.Add(giver);
		}

		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler(EventSink_Login);
		}

		private static void EventSink_Login(LoginEventArgs e)
		{
			var acct = e.Mobile.Account as Account;

			if (acct == null)
			{
				return;
			}

			var now = DateTime.UtcNow;

			for (var i = 0; i < m_Givers.Count; ++i)
			{
				var giver = m_Givers[i];

				if (now < giver.Start || now >= giver.Finish)
				{
					continue; // not in the correct timefream
				}

				if (acct.Created > (giver.Start - giver.MinimumAge))
				{
					continue; // newly created account
				}

				if (acct.LastLogin >= giver.Start)
				{
					continue; // already got one
				}

				giver.DelayGiveGift(TimeSpan.FromSeconds(5.0), e.Mobile);
			}

			acct.LastLogin = now;
		}
	}

	public abstract class GiftGiver
	{
		public virtual TimeSpan MinimumAge => TimeSpan.FromDays(30.0);

		public abstract DateTime Start { get; }
		public abstract DateTime Finish { get; }
		public abstract void GiveGift(Mobile mob);

		public virtual void DelayGiveGift(TimeSpan delay, Mobile mob)
		{
			Timer.DelayCall(delay, DelayGiveGift_Callback, mob);
		}

		protected virtual void DelayGiveGift_Callback(object state)
		{
			GiveGift((Mobile)state);
		}

		public virtual GiftResult GiveGift(Mobile mob, Item item)
		{
			if (mob.PlaceInBackpack(item))
			{
				if (!WeightOverloading.IsOverloaded(mob))
				{
					return GiftResult.Backpack;
				}
			}

			mob.BankBox.DropItem(item);
			return GiftResult.BankBox;
		}
	}

	#region Sample Holiday Boxes

	/// using Server.Items;
	/// using Server.Network;
	///
	/// using System;
	///
	/// namespace Server.Items
	/// {
	///     [Flipable(0x232A, 0x232B)]
	///     public class WinterGiftPackage2003 : GiftBox
	///     {
	///         [Constructable]
	///         public WinterGiftPackage2003()
	///         {
	///             DropItem(new Snowman());
	///             DropItem(new WreathDeed());
	///             DropItem(new BlueSnowflake());
	///             DropItem(new RedPoinsettia());
	///         }
	///
	///         public WinterGiftPackage2003(Serial serial) : base(serial)
	///         {
	///         }
	///
	///         public override void Serialize(GenericWriter writer)
	///         {
	///             base.Serialize(writer);
	/// 
	///             writer.Write((int)0); // version
	///         }
	///
	///         public override void Deserialize(GenericReader reader)
	///         {
	///             base.Deserialize(reader);
	/// 
	///             int version = reader.ReadInt();
	///         }
	///     }
	/// }

	#endregion

	#region Sample Holiday Timer

	/// using Server;
	/// using Server.Items;
	///
	/// using System;
	///
	/// namespace Server.Misc
	/// {
	///     public class WinterGiftGiver2004 : GiftGiver
	///     {
	///         public static void Initialize()
	///         {
	///             GiftGiving.Register(new WinterGiftGiver2004());
	///         }
	///
	///         public override DateTime Start { get { return new DateTime(2004, 12, 24); } }
	///         public override DateTime Finish { get { return new DateTime(2005, 1, 1); } }
	///
	///         public override void GiveGift(Mobile mob)
	///         {
	///             GiftBox box = new GiftBox();
	///
	///             box.DropItem(new MistletoeDeed());
	///             box.DropItem(new PileOfGlacialSnow());
	///             box.DropItem(new LightOfTheWinterSolstice());
	///
	///             int random = Utility.Random(100);
	///
	///             if (random < 60)
	///                 box.DropItem(new DecorativeTopiary());
	///             else if (random < 84)
	///                 box.DropItem(new FestiveCactus());
	///             else
	///                 box.DropItem(new SnowyTree());
	///
	///             switch (GiveGift(mob, box))
	///             {
	///                 case GiftResult.Backpack:
	///                     mob.SendMessage(0x482, "Happy Holidays from the team!  Gift items have been placed in your backpack.");
	///                     break;
	///                 case GiftResult.BankBox:
	///                     mob.SendMessage(0x482, "Happy Holidays from the team!  Gift items have been placed in your bank box.");
	///                     break;
	///             }
	///         }
	///     }
	/// }

	#endregion
}