using Server.Engines.Quests.Definitions;
using Server.Mobiles;
using Server.Targeting;

using System;
using System.Collections;

namespace Server.Engines.Quests.Items
{
	public enum ImageType
	{
		Betrayer,
		Bogling,
		BogThing,
		Gazer,
		Beetle,
		GiantBlackWidow,
		Scorpion,
		JukaMage,
		JukaWarrior,
		Lich,
		MeerMage,
		MeerWarrior,
		Mongbat,
		Mummy,
		Pixie,
		PlagueBeast,
		SandVortex,
		StoneGargoyle,
		SwampDragon,
		Wisp,
		Juggernaut
	}

	public class EnchantedPaints : QuestItem
	{
		[Constructable]
		public EnchantedPaints() : base(0xFC1)
		{
			LootType = LootType.Blessed;

			Weight = 1.0;
		}

		public EnchantedPaints(Serial serial) : base(serial)
		{
		}

		public override bool CanDrop(PlayerMobile player)
		{
			var qs = player.Quest as CollectorQuest;

			if (qs == null)
			{
				return true;
			}

			/*return !( qs.IsObjectiveInProgress( typeof( CaptureImagesObjective ) )
				|| qs.IsObjectiveInProgress( typeof( ReturnImagesObjective ) ) );*/
			return false;
		}

		public override void OnDoubleClick(Mobile from)
		{
			var player = from as PlayerMobile;

			if (player != null)
			{
				var qs = player.Quest;

				if (qs is CollectorQuest)
				{
					if (qs.IsObjectiveInProgress(typeof(CaptureImagesObjective_CollectorQuest)))
					{
						player.SendAsciiMessage(0x59, "Target the creature whose image you wish to create.");
						player.Target = new InternalTarget(this);

						return;
					}
				}
			}

			from.SendLocalizedMessage(1010085); // You cannot use this.
		}

		private class InternalTarget : Target
		{
			private readonly EnchantedPaints m_Paints;

			public InternalTarget(EnchantedPaints paints) : base(-1, false, TargetFlags.None)
			{
				CheckLOS = false;
				m_Paints = paints;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (m_Paints.Deleted || !m_Paints.IsChildOf(from.Backpack))
				{
					return;
				}

				var player = from as PlayerMobile;

				if (player != null)
				{
					var qs = player.Quest;

					if (qs is CollectorQuest)
					{
						var obj = qs.FindObjective(typeof(CaptureImagesObjective_CollectorQuest)) as CaptureImagesObjective_CollectorQuest;

						if (obj != null && !obj.Completed)
						{
							if (targeted is Mobile)
							{
								ImageType image;
								var response = obj.CaptureImage((targeted.GetType().Name == "GreaterMongbat" ? new Mongbat().GetType() : targeted.GetType()), out image);

								switch (response)
								{
									case CaptureResponse.Valid:
										{
											player.SendLocalizedMessage(1055125); // The enchanted paints swirl for a moment then an image begins to take shape. *Click*
											player.AddToBackpack(new PaintedImage(image));

											break;
										}
									case CaptureResponse.AlreadyDone:
										{
											player.SendAsciiMessage(0x2C, "You have already captured the image of this creature");

											break;
										}
									case CaptureResponse.Invalid:
										{
											player.SendLocalizedMessage(1055124); // You have no interest in capturing the image of this creature.

											break;
										}
								}
							}
							else
							{
								player.SendAsciiMessage(0x35, "You have no interest in that.");
							}

							return;
						}
					}
				}

				from.SendLocalizedMessage(1010085); // You cannot use this.
			}
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

	public class ImageTypeInfo
	{
		private static readonly ImageTypeInfo[] m_Table = new ImageTypeInfo[]
			{
				new ImageTypeInfo( 9734, typeof( Betrayer ), 75, 45 ),
				new ImageTypeInfo( 9735, typeof( Bogling ), 75, 45 ),
				new ImageTypeInfo( 9736, typeof( BogThing ), 60, 47 ),
				new ImageTypeInfo( 9615, typeof( Gazer ), 75, 45 ),
				new ImageTypeInfo( 9743, typeof( Beetle ), 60, 55 ),
				new ImageTypeInfo( 9667, typeof( GiantBlackWidow ), 55, 52 ),
				new ImageTypeInfo( 9657, typeof( Scorpion ), 65, 47 ),
				new ImageTypeInfo( 9758, typeof( JukaMage ), 75, 45 ),
				new ImageTypeInfo( 9759, typeof( JukaWarrior ), 75, 45 ),
				new ImageTypeInfo( 9636, typeof( Lich ), 75, 45 ),
				new ImageTypeInfo( 9756, typeof( MeerMage ), 75, 45 ),
				new ImageTypeInfo( 9757, typeof( MeerWarrior ), 75, 45 ),
				new ImageTypeInfo( 9638, typeof( Mongbat ), 70, 50 ),
				new ImageTypeInfo( 9639, typeof( Mummy ), 75, 45 ),
				new ImageTypeInfo( 9654, typeof( Pixie ), 75, 45 ),
				new ImageTypeInfo( 9747, typeof( PlagueBeast ), 60, 45 ),
				new ImageTypeInfo( 9750, typeof( SandVortex ), 60, 43 ),
				new ImageTypeInfo( 9614, typeof( StoneGargoyle ), 75, 45 ),
				new ImageTypeInfo( 9753, typeof( SwampDragon ), 50, 55 ),
				new ImageTypeInfo( 8448, typeof( Wisp ), 75, 45 ),
				new ImageTypeInfo( 9746, typeof( Juggernaut ), 55, 38 )
			};

		public static ImageTypeInfo Get(ImageType image)
		{
			var index = (int)image;
			if (index >= 0 && index < m_Table.Length)
			{
				return m_Table[index];
			}
			else
			{
				return m_Table[0];
			}
		}

		public static ImageType[] RandomList(int count)
		{
			var list = new ArrayList(m_Table.Length);
			for (var i = 0; i < m_Table.Length; i++)
			{
				list.Add((ImageType)i);
			}

			var images = new ImageType[count];

			for (var i = 0; i < images.Length; i++)
			{
				var index = Utility.Random(list.Count);
				images[i] = (ImageType)list[index];

				list.RemoveAt(index);
			}

			return images;
		}

		private readonly int m_Figurine;
		private readonly Type m_Type;
		private readonly int m_X;
		private readonly int m_Y;

		public int Figurine => m_Figurine;
		public Type Type => m_Type;
		public int Name => m_Figurine < 0x4000 ? 1020000 + m_Figurine : 1078872 + m_Figurine;
		public int X => m_X;
		public int Y => m_Y;

		public ImageTypeInfo(int figurine, Type type, int x, int y)
		{
			m_Figurine = figurine;
			m_Type = type;
			m_X = x;
			m_Y = y;
		}
	}
}