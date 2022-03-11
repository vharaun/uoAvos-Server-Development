using Server.Items;
using Server.Mobiles;

using System;
using System.Collections.Generic;

namespace Server.Engines.Events
{
	public class IharaSoko : BaseVendor
	{
		public override bool IsActiveVendor => false;
		public override bool IsInvulnerable => true;
		public override bool DisallowAllMoves => true;
		public override bool ClickTitle => true;
		public override bool CanTeach => false;

		protected List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		public override void InitSBInfo()
		{
		}

		public override void InitOutfit()
		{
			AddItem(new Waraji(0x711));
			AddItem(new Backpack());
			AddItem(new Kamishimo(0x483));

			Item item = new LightPlateJingasa {
				Hue = 0x711
			};

			AddItem(item);
		}


		[Constructable]
		public IharaSoko() : base("the Imperial Minister of Trade")
		{
			Name = "Ihara Soko";
			Female = false;
			Body = 0x190;
			Hue = 0x8403;
		}

		public IharaSoko(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			if (m.Alive && m is PlayerMobile)
			{
				var pm = (PlayerMobile)m;

				var range = 3;

				if (m.Alive && Math.Abs(Z - m.Z) < 16 && InRange(m, range) && !InRange(oldLocation, range))
				{
					if (pm.ToTItemsTurnedIn >= TreasuresOfTokuno.ItemsPerReward)
					{
						SayTo(pm, 1070980); // Congratulations! You have turned in enough minor treasures to earn a greater reward.

						pm.CloseGump(typeof(ToTTurnInGump));    //Sanity

						if (!pm.HasGump(typeof(ToTRedeemGump)))
						{
							pm.SendGump(new ToTRedeemGump(this, false));
						}
					}
					else
					{
						if (pm.ToTItemsTurnedIn == 0)
						{
							SayTo(pm, 1071013); // Bring me 10 of the lost treasures of Tokuno and I will reward you with a valuable item.
						}
						else
						{
							SayTo(pm, 1070981, String.Format("{0}\t{1}", pm.ToTItemsTurnedIn, TreasuresOfTokuno.ItemsPerReward)); // You have turned in ~1_COUNT~ minor artifacts. Turn in ~2_NUM~ to receive a reward.
						}

						var buttons = ToTTurnInGump.FindRedeemableItems(pm);

						if (buttons.Count > 0 && !pm.HasGump(typeof(ToTTurnInGump)))
						{
							pm.SendGump(new ToTTurnInGump(this, buttons));
						}
					}
				}

				var leaveRange = 7;

				if (!InRange(m, leaveRange) && InRange(oldLocation, leaveRange))
				{
					pm.CloseGump(typeof(ToTRedeemGump));
					pm.CloseGump(typeof(ToTTurnInGump));
				}
			}
		}

		public override void TurnToTokuno() { }
	}
}