using Server.Items;

using System;

namespace Server
{
	public static partial class ValorSpawner
	{
		public static Type[] Artifacts => m_Artifacts;

		private static readonly Type[] m_Artifacts = new Type[]
		{
			typeof( AegisOfGrace ), typeof( BladeDance ), typeof( BloodwoodSpirit ), typeof( Bonesmasher ),
			typeof( Boomstick ), typeof( BrightsightLenses ), typeof( FeyLeggings ), typeof( FleshRipper ),
			typeof( HelmOfSwiftness ), typeof( PadsOfTheCuSidhe ), typeof( QuiverOfRage ), typeof( QuiverOfElements ),
			typeof( RaedsGlory ), typeof( RighteousAnger ), typeof( RobeOfTheEclipse ), typeof( RobeOfTheEquinox ),
			typeof( SoulSeeker ), typeof( TalonBite ), typeof( TotemOfVoid ), typeof( WildfireBow ),
			typeof( Windsong )
		};
	}
}