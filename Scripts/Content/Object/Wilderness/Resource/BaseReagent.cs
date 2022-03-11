using Server.Items;

using System;

namespace Server.Items
{
	public abstract class BaseReagent : Item
	{
		public override double DefaultWeight => 0.1;

		public BaseReagent(int itemID) : this(itemID, 1)
		{
		}

		public BaseReagent(int itemID, int amount) : base(itemID)
		{
			Stackable = true;
			Amount = amount;
		}

		public BaseReagent(Serial serial) : base(serial)
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

namespace Server.Spells
{
	public class Reagent
	{
		private static readonly Type[] m_Types = {
				typeof( BlackPearl ),
				typeof( Bloodmoss ),
				typeof( Garlic ),
				typeof( Ginseng ),
				typeof( MandrakeRoot ),
				typeof( Nightshade ),
				typeof( SulfurousAsh ),
				typeof( SpidersSilk ),
				typeof( BatWing ),
				typeof( GraveDust ),
				typeof( DaemonBlood ),
				typeof( NoxCrystal ),
				typeof( PigIron ),
				typeof( Bone ),
				typeof( FertileDirt ),
				typeof( DragonsBlood ),
				typeof( DaemonBone )
			};

		public Type[] Types => m_Types;

		public static Type BlackPearl
		{
			get => m_Types[0];
			set => m_Types[0] = value;
		}

		public static Type Bloodmoss
		{
			get => m_Types[1];
			set => m_Types[1] = value;
		}

		public static Type Garlic
		{
			get => m_Types[2];
			set => m_Types[2] = value;
		}

		public static Type Ginseng
		{
			get => m_Types[3];
			set => m_Types[3] = value;
		}

		public static Type MandrakeRoot
		{
			get => m_Types[4];
			set => m_Types[4] = value;
		}

		public static Type Nightshade
		{
			get => m_Types[5];
			set => m_Types[5] = value;
		}

		public static Type SulfurousAsh
		{
			get => m_Types[6];
			set => m_Types[6] = value;
		}

		public static Type SpidersSilk
		{
			get => m_Types[7];
			set => m_Types[7] = value;
		}

		public static Type BatWing
		{
			get => m_Types[8];
			set => m_Types[8] = value;
		}

		public static Type GraveDust
		{
			get => m_Types[9];
			set => m_Types[9] = value;
		}

		public static Type DaemonBlood
		{
			get => m_Types[10];
			set => m_Types[10] = value;
		}

		public static Type NoxCrystal
		{
			get => m_Types[11];
			set => m_Types[11] = value;
		}

		public static Type PigIron
		{
			get => m_Types[12];
			set => m_Types[12] = value;
		}

		public static Type Bone
		{
			get => m_Types[13];
			set => m_Types[13] = value;
		}

		public static Type FertileDirt
		{
			get => m_Types[14];
			set => m_Types[14] = value;
		}

		public static Type DragonsBlood
		{
			get => m_Types[15];
			set => m_Types[15] = value;
		}

		public static Type DaemonBone
		{
			get => m_Types[16];
			set => m_Types[16] = value;
		}
	}
}