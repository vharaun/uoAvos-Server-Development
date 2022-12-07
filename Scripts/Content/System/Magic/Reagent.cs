using Server.Items;

using System;
using System.Collections.Generic;

namespace Server.Spells
{
	public static class Reagent
	{
		private static readonly Type[] m_Types =
		{
			typeof(BlackPearl),
			typeof(Bloodmoss),
			typeof(Garlic),
			typeof(Ginseng),
			typeof(MandrakeRoot),
			typeof(Nightshade),
			typeof(SulfurousAsh),
			typeof(SpidersSilk),
			typeof(BatWing),
			typeof(GraveDust),
			typeof(DaemonBlood),
			typeof(NoxCrystal),
			typeof(PigIron),
			typeof(Bone),
			typeof(FertileDirt),
			typeof(DragonsBlood),
			typeof(DaemonBone),

			// Custom
			
			typeof(DestroyingAngel),
			typeof(PetrifiedWood),
			typeof(SpringWater),
			typeof(Kindling),
		};

		public static IReadOnlyCollection<Type> Types => m_Types;

		public static Type BlackPearl => m_Types[0];
		public static Type Bloodmoss => m_Types[1];
		public static Type Garlic => m_Types[2];
		public static Type Ginseng => m_Types[3];
		public static Type MandrakeRoot => m_Types[4];
		public static Type Nightshade => m_Types[5];
		public static Type SulfurousAsh => m_Types[6];
		public static Type SpidersSilk => m_Types[7];
		public static Type BatWing => m_Types[8];
		public static Type GraveDust => m_Types[9];
		public static Type DaemonBlood => m_Types[10];
		public static Type NoxCrystal => m_Types[11];
		public static Type PigIron => m_Types[12];
		public static Type Bone => m_Types[13];
		public static Type FertileDirt => m_Types[14];
		public static Type DragonsBlood => m_Types[15];
		public static Type DaemonBone => m_Types[16];

		// Custom

		public static Type DestroyingAngel => m_Types[17];
		public static Type PetrifiedWood => m_Types[18];
		public static Type SpringWater => m_Types[19];
		public static Type Kindling => m_Types[20];
	}
}