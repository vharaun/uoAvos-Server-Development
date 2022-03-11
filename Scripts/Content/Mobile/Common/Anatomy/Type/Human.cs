
using System;

namespace Server.Items
{
	#region Bones

	[FlipableAttribute(0x1B09, 0x1B10)]
	public class BonePile : Item, IScissorable
	{
		[Constructable]
		public BonePile() : base(0x1B09 + Utility.Random(8))
		{
			Stackable = false;
			Weight = 10.0;
		}

		public BonePile(Serial serial) : base(serial)
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

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
			{
				return false;
			}

			base.ScissorHelper(from, new Bone(), Utility.RandomMinMax(10, 15));

			return true;
		}
	}

	[FlipableAttribute(0x1B17, 0x1B18)]
	public class RibCage : Item, IScissorable
	{
		[Constructable]
		public RibCage() : base(0x1B17 + Utility.Random(2))
		{
			Stackable = false;
			Weight = 5.0;
		}

		public RibCage(Serial serial) : base(serial)
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

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
			{
				return false;
			}

			base.ScissorHelper(from, new Bone(), Utility.RandomMinMax(3, 5));

			return true;
		}
	}

	#endregion

	#region Heads

	public enum HeadType
	{
		Regular,
		Duel,
		Tournament
	}

	public class Head : Item
	{
		private string m_PlayerName;
		private HeadType m_HeadType;

		[CommandProperty(AccessLevel.GameMaster)]
		public string PlayerName
		{
			get => m_PlayerName;
			set => m_PlayerName = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public HeadType HeadType
		{
			get => m_HeadType;
			set => m_HeadType = value;
		}

		public override string DefaultName
		{
			get
			{
				if (m_PlayerName == null)
				{
					return base.DefaultName;
				}

				switch (m_HeadType)
				{
					default:
						return String.Format("the head of {0}", m_PlayerName);

					case HeadType.Duel:
						return String.Format("the head of {0}, taken in a duel", m_PlayerName);

					case HeadType.Tournament:
						return String.Format("the head of {0}, taken in a tournament", m_PlayerName);
				}
			}
		}

		[Constructable]
		public Head()
			: this(null)
		{
		}

		[Constructable]
		public Head(string playerName)
			: this(HeadType.Regular, playerName)
		{
		}

		[Constructable]
		public Head(HeadType headType, string playerName)
			: base(0x1DA0)
		{
			m_HeadType = headType;
			m_PlayerName = playerName;
		}

		public Head(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version

			writer.Write(m_PlayerName);
			writer.WriteEncodedInt((int)m_HeadType);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					m_PlayerName = reader.ReadString();
					m_HeadType = (HeadType)reader.ReadEncodedInt();
					break;

				case 0:
					var format = Name;

					if (format != null)
					{
						if (format.StartsWith("the head of "))
						{
							format = format.Substring("the head of ".Length);
						}

						if (format.EndsWith(", taken in a duel"))
						{
							format = format.Substring(0, format.Length - ", taken in a duel".Length);
							m_HeadType = HeadType.Duel;
						}
						else if (format.EndsWith(", taken in a tournament"))
						{
							format = format.Substring(0, format.Length - ", taken in a tournament".Length);
							m_HeadType = HeadType.Tournament;
						}
					}

					m_PlayerName = format;
					Name = null;

					break;
			}
		}
	}

	#endregion

	public abstract class Hair : Item
	{
		/*
		
		public static Hair GetRandomHair( bool female )
		{
			return GetRandomHair( female, Utility.RandomHairHue() );
		}

		public static Hair GetRandomHair( bool female, int hairHue )
		{
			if( female )
			{
				switch ( Utility.Random( 9 ) )
				{
					case 0: return new Afro( hairHue );
					case 1: return new KrisnaHair( hairHue );
					case 2: return new PageboyHair( hairHue );
					case 3: return new PonyTail( hairHue );
					case 4: return new ReceedingHair( hairHue );
					case 5: return new TwoPigTails( hairHue );
					case 6: return new ShortHair( hairHue );
					case 7: return new LongHair( hairHue );
					default: return new BunsHair( hairHue );
				}
			}
			else
			{
				switch ( Utility.Random( 8 ) )
				{
					case 0: return new Afro( hairHue );
					case 1: return new KrisnaHair( hairHue );
					case 2: return new PageboyHair( hairHue );
					case 3: return new PonyTail( hairHue );
					case 4: return new ReceedingHair( hairHue );
					case 5: return new TwoPigTails( hairHue );
					case 6: return new ShortHair( hairHue );
					default: return new LongHair( hairHue );
				}
			}
		}


		public static Hair CreateByID( int id, int hue )
		{
			switch ( id )
			{
				case 0x203B: return new ShortHair( hue );
				case 0x203C: return new LongHair( hue );
				case 0x203D: return new PonyTail( hue );
				case 0x2044: return new Mohawk( hue );
				case 0x2045: return new PageboyHair( hue );
				case 0x2046: return new BunsHair( hue );
				case 0x2047: return new Afro( hue );
				case 0x2048: return new ReceedingHair( hue );
				case 0x2049: return new TwoPigTails( hue );
				case 0x204A: return new KrisnaHair( hue );
				default: return new GenericHair( id, hue );
			}
		}
		 * */

		protected Hair(int itemID)
			: this(itemID, 0)
		{
		}

		protected Hair(int itemID, int hue)
			: base(itemID)
		{
			LootType = LootType.Blessed;
			Layer = Layer.Hair;
			Hue = hue;
		}

		public Hair(Serial serial)
			: base(serial)
		{
		}

		public override bool DisplayLootType => false;

		public override bool VerifyMove(Mobile from)
		{
			return (from.AccessLevel >= AccessLevel.GameMaster);
		}

		public override DeathMoveResult OnParentDeath(Mobile parent)
		{
			//			Dupe( Amount );

			parent.HairItemID = ItemID;
			parent.HairHue = Hue;

			return DeathMoveResult.MoveToCorpse;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			LootType = LootType.Blessed;

			var version = reader.ReadInt();
		}
	}

	#region Style

	public class GenericHair : Hair
	{

		private GenericHair(int itemID)
			: this(itemID, 0)
		{
		}


		private GenericHair(int itemID, int hue)
			: base(itemID, hue)
		{
		}

		public GenericHair(Serial serial)
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

	public class Mohawk : Hair
	{

		private Mohawk()
			: this(0)
		{
		}


		private Mohawk(int hue)
			: base(0x2044, hue)
		{
		}

		public Mohawk(Serial serial)
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

	public class PageboyHair : Hair
	{

		private PageboyHair()
			: this(0)
		{
		}


		private PageboyHair(int hue)
			: base(0x2045, hue)
		{
		}

		public PageboyHair(Serial serial)
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

	public class BunsHair : Hair
	{

		private BunsHair()
			: this(0)
		{
		}


		private BunsHair(int hue)
			: base(0x2046, hue)
		{
		}

		public BunsHair(Serial serial)
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

	public class LongHair : Hair
	{

		private LongHair()
			: this(0)
		{
		}


		private LongHair(int hue)
			: base(0x203C, hue)
		{
		}

		public LongHair(Serial serial)
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

	public class ShortHair : Hair
	{

		private ShortHair()
			: this(0)
		{
		}


		private ShortHair(int hue)
			: base(0x203B, hue)
		{
		}

		public ShortHair(Serial serial)
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

	public class PonyTail : Hair
	{

		private PonyTail()
			: this(0)
		{
		}


		private PonyTail(int hue)
			: base(0x203D, hue)
		{
		}

		public PonyTail(Serial serial)
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

	public class Afro : Hair
	{

		private Afro()
			: this(0)
		{
		}


		private Afro(int hue)
			: base(0x2047, hue)
		{
		}

		public Afro(Serial serial)
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

	public class ReceedingHair : Hair
	{

		private ReceedingHair()
			: this(0)
		{
		}


		private ReceedingHair(int hue)
			: base(0x2048, hue)
		{
		}

		public ReceedingHair(Serial serial)
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

	public class TwoPigTails : Hair
	{

		private TwoPigTails()
			: this(0)
		{
		}


		private TwoPigTails(int hue)
			: base(0x2049, hue)
		{
		}

		public TwoPigTails(Serial serial)
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

	public class KrisnaHair : Hair
	{

		private KrisnaHair()
			: this(0)
		{
		}


		private KrisnaHair(int hue)
			: base(0x204A, hue)
		{
		}

		public KrisnaHair(Serial serial)
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

	#endregion

	public abstract class Beard : Item
	{
		/*public static Beard CreateByID( int id, int hue )
		{
			switch ( id )
			{
				case 0x203E: return new LongBeard( hue );
				case 0x203F: return new ShortBeard( hue );
				case 0x2040: return new Goatee( hue );
				case 0x2041: return new Mustache( hue );
				case 0x204B: return new MediumShortBeard( hue );
				case 0x204C: return new MediumLongBeard( hue );
				case 0x204D: return new Vandyke( hue );
				default: return new GenericBeard( id, hue );
			}
		}*/

		protected Beard(int itemID) : this(itemID, 0)
		{
		}

		protected Beard(int itemID, int hue) : base(itemID)
		{
			LootType = LootType.Blessed;
			Layer = Layer.FacialHair;
			Hue = hue;
		}

		public Beard(Serial serial) : base(serial)
		{
		}

		public override bool DisplayLootType => false;

		public override bool VerifyMove(Mobile from)
		{
			return (from.AccessLevel >= AccessLevel.GameMaster);
		}

		public override DeathMoveResult OnParentDeath(Mobile parent)
		{
			//Dupe( Amount );

			parent.FacialHairItemID = ItemID;
			parent.FacialHairHue = Hue;

			return DeathMoveResult.MoveToCorpse;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			LootType = LootType.Blessed;

			var version = reader.ReadInt();
		}
	}

	#region Style

	public class GenericBeard : Beard
	{

		private GenericBeard(int itemID) : this(itemID, 0)
		{
		}


		private GenericBeard(int itemID, int hue) : base(itemID, hue)
		{
		}

		public GenericBeard(Serial serial) : base(serial)
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

	public class LongBeard : Beard
	{

		private LongBeard()
			: this(0)
		{
		}

		private LongBeard(int hue)
			: base(0x203E, hue)
		{
		}

		public LongBeard(Serial serial) : base(serial)
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

	public class ShortBeard : Beard
	{

		private ShortBeard()
			: this(0)
		{
		}


		private ShortBeard(int hue)
			: base(0x203f, hue)
		{
		}

		public ShortBeard(Serial serial) : base(serial)
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

	public class Goatee : Beard
	{

		private Goatee()
			: this(0)
		{
		}


		private Goatee(int hue)
			: base(0x2040, hue)
		{
		}

		public Goatee(Serial serial) : base(serial)
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

	public class Mustache : Beard
	{

		private Mustache()
			: this(0)
		{
		}


		private Mustache(int hue)
			: base(0x2041, hue)
		{
		}

		public Mustache(Serial serial) : base(serial)
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

	public class MediumShortBeard : Beard
	{

		private MediumShortBeard()
			: this(0)
		{
		}


		private MediumShortBeard(int hue)
			: base(0x204B, hue)
		{
		}

		public MediumShortBeard(Serial serial) : base(serial)
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

	public class MediumLongBeard : Beard
	{

		private MediumLongBeard()
			: this(0)
		{
		}


		private MediumLongBeard(int hue)
			: base(0x204C, hue)
		{
		}

		public MediumLongBeard(Serial serial) : base(serial)
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

	public class Vandyke : Beard
	{

		private Vandyke()
			: this(0)
		{
		}


		private Vandyke(int hue)
			: base(0x204D, hue)
		{
		}

		public Vandyke(Serial serial) : base(serial)
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

	#region Parts

	/// Torso
	public class Torso : Item
	{
		[Constructable]
		public Torso() : base(0x1D9F)
		{
			Weight = 2.0;
		}

		public Torso(Serial serial) : base(serial)
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

	/// Arms
	public class RightArm : Item
	{
		[Constructable]
		public RightArm() : base(0x1DA2)
		{
		}

		public RightArm(Serial serial) : base(serial)
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

	public class LeftArm : Item
	{
		[Constructable]
		public LeftArm() : base(0x1DA1)
		{
		}

		public LeftArm(Serial serial) : base(serial)
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

	/// Legs
	public class RightLeg : Item
	{
		[Constructable]
		public RightLeg() : base(0x1DA4)
		{
		}

		public RightLeg(Serial serial) : base(serial)
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

	public class LeftLeg : Item
	{
		[Constructable]
		public LeftLeg() : base(0x1DA3)
		{
		}

		public LeftLeg(Serial serial) : base(serial)
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