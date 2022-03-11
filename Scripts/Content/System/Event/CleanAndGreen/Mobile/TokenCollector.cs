using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.Events
{
	public class TokenCollector : BaseGuildmaster
	{
		public override bool ClickTitle => false;
		public override NpcGuild NpcGuild => NpcGuild.MerchantsGuild;

		private static bool m_Talked;
		private readonly string[] npcSpeech = new string[]
		{
			"Server Cleanup Day!",
		};

		[Constructable]
		public TokenCollector() : base("merchant")
		{
			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("female");
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
			}

			Title = "[CC]";
			NameHue = 11;

			VendorAccessLevel = AccessLevel.Player;
			AccessLevel = AccessLevel.GameMaster;

			SpeechHue = Utility.RandomDyedHue();
			Hue = Utility.RandomSkinHue();

			var hair = new Item(Utility.RandomList(0x203B, 0x2049, 0x2048, 0x204A)) {
				Hue = Utility.RandomNondyedHue(),
				Layer = Layer.Hair,
				Movable = false
			};
			AddItem(hair);

			if (Utility.RandomBool() && !Female)
			{
				var beard = new Item(Utility.RandomList(0x203E, 0x203F, 0x2040, 0x2041, 0x204B, 0x204C, 0x204D)) {
					Hue = hair.Hue,
					Layer = Layer.FacialHair,
					Movable = false
				};

				AddItem(beard);
			}

			switch (Utility.Random(3))
			{
				case 0: AddItem(new BookOfNinjitsu()); break;
				case 1: AddItem(new BookOfBushido()); break;
				case 2: AddItem(new BookOfChivalry()); break;
			}

			AddItem(new ShortPants(Utility.RandomNeutralHue()));
			AddItem(new Shirt(Utility.RandomNeutralHue()));
			AddItem(new Sandals(Utility.RandomNeutralHue()));
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			var m = from;
			var mobile = m as PlayerMobile;

			#region Tier 01: 05-25 Tokens Dropped

			if (dropped is CleanAndGreenToken && dropped.Amount >= 5 && dropped.Amount < 26)
			{
				switch (Utility.Random(3))
				{
					case 3:
						{
							var totem = new SoulSeeker();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;
						}
					case 2:
						{
							var totem = new AegisOfGrace();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;

						}
					case 0:
						{
							var totem = new TotemOfVoid();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;
						}
				}
			}

			#endregion

			#region Tier 02: 26-50 Tokens Dropped

			else if (dropped is CleanAndGreenToken && dropped.Amount >= 26 && dropped.Amount < 51)
			{
				switch (Utility.Random(3))
				{
					case 3:
						{
							var totem = new SoulSeeker();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;
						}
					case 2:
						{
							var totem = new AegisOfGrace();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;

						}
					case 0:
						{
							var totem = new TotemOfVoid();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;
						}
				}
			}

			#endregion

			#region Tier 03: 51-75 Tokens Dropped

			else if (dropped is CleanAndGreenToken && dropped.Amount >= 51 && dropped.Amount < 76)
			{
				switch (Utility.Random(3))
				{
					case 3:
						{
							var totem = new SoulSeeker();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;
						}
					case 2:
						{
							var totem = new AegisOfGrace();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;

						}
					case 0:
						{
							var totem = new TotemOfVoid();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;
						}
				}
			}

			#endregion

			#region Tier 04: 76 - 100 Tokens Dropped

			else if (dropped is CleanAndGreenToken && dropped.Amount >= 76 && dropped.Amount < 101)
			{
				switch (Utility.Random(3))
				{
					case 3:
						{
							var totem = new SoulSeeker();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;
						}
					case 2:
						{
							var totem = new AegisOfGrace();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;

						}
					case 0:
						{
							var totem = new TotemOfVoid();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;
						}
				}
			}

			#endregion

			#region Tier 05: 101+ Tokens Dropped

			else if (dropped is CleanAndGreenToken && dropped.Amount >= 101)
			{
				switch (Utility.Random(3))
				{
					case 3:
						{
							var totem = new SoulSeeker();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;
						}
					case 2:
						{
							var totem = new AegisOfGrace();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;

						}
					case 0:
						{
							var totem = new TotemOfVoid();

							if (totem.Name != null)
							{
								Say("Thank you {0} and here is your {1}", from.Name, totem.Name);
							}
							else
							{
								Say(1060847, String.Format("Thank you {0} and here is your \t#{1}", from.Name, totem.LabelNumber));
							}

							from.AddToBackpack(totem);
							break;
						}
				}
			}

			#endregion

			/// What Happens When We Drop 01-04 Tokens?
			else
			{
				Say("Sorry I cannot accept that in good grace.");
				Say("I suggest you save up your tokens, and return at a later time.");
				return false;
			}

			return true;
		}

		public void Emote()
		{
			switch (Utility.Random(3))
			{
				case 0:
					PlaySound(Female ? 785 : 1056);
					Say("*cough!*");
					break;
				case 1:
					PlaySound(Female ? 818 : 1092);
					Say("*sniff*");
					break;
				default:
					break;
			}
		}

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			if (m_Talked == false)
			{
				if (m.InRange(this, 4))
				{
					m_Talked = true;
					SayRandom(npcSpeech, this);
					Move(GetDirectionTo(m.Location));

					var t = new SpamTimer();
					t.Start();
				}
			}
		}

		private class SpamTimer : Timer
		{
			public SpamTimer() : base(TimeSpan.FromSeconds(20))
			{
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				m_Talked = false;
			}
		}

		private static void SayRandom(string[] say, Mobile m)
		{
			m.Say(say[Utility.Random(say.Length)]);
		}

		public TokenCollector(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version 0
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}