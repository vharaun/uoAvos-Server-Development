using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.Quests.Mobiles
{
	public class Prisoner : BaseEscortable
	{
		private static bool m_Talked;
		private readonly string[] npcSpeech = new string[]
		{
			"HELP!",
			"Help Me!",
			"Canst thou aid me?!",
			"Help a poor prisoner!",
			"Help! Please!",
			"aaah! Help me!",
			"Go and get some help!"
		};

		[Constructable]
		public Prisoner()
		{
			Title = Female ? "the noblewoman" : "the nobleman";

			CantWalk = true;
			IsPrisoner = true;
		}

		public override bool CanTeach => true;
		public override bool ClickTitle => false;

		public override void InitOutfit()
		{
			if (Female)
			{
				AddItem(new FancyDress(Utility.RandomNondyedHue()));
			}
			else
			{
				AddItem(new FancyShirt(Utility.RandomNondyedHue()));
				AddItem(new LongPants(Utility.RandomNondyedHue()));
			}

			if (Utility.RandomBool())
			{
				AddItem(new Boots());
			}
			else
			{
				AddItem(new ThighBoots());
			}

			Utility.AssignRandomHair(this);
			Utility.AssignRandomFacialHair(this, HairHue);
		}

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			base.OnMovement(m, oldLocation);

			if (CantWalk && InRange(m, 1) && !InRange(oldLocation, 1) && (!m.Hidden || m.AccessLevel == AccessLevel.Player))
			{
				Say(502268); // Quickly, I beg thee! Unlock my chains! If thou dost look at me close thou canst see them.
			}

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

		public Prisoner(Serial serial)
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
}