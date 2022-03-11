using Server.Items;

using System;

#region Developer Notations

/// This is a test dummy that you can configure in game!
/// It will die after 5 minutes, so the test server stays clean!

/// Create Macros to help your dummy succeed: '[add Dummy 1 15 7 -1 0.5 2'
/// Please Note: An iTeam of negative will set a faction at random

#endregion

namespace Server.Mobiles
{
	public class Dummy : BaseCreature
	{
		public Timer m_Timer;

		[Constructable]
		public Dummy(AIType iAI, FightMode iFightMode, int iRangePerception, int iRangeFight, double dActiveSpeed, double dPassiveSpeed) : base(iAI, iFightMode, iRangePerception, iRangeFight, dActiveSpeed, dPassiveSpeed)
		{
			Body = 400 + Utility.Random(2);
			Hue = Utility.RandomSkinHue();

			Skills[SkillName.DetectHidden].Base = 100;
			Skills[SkillName.MagicResist].Base = 120;

			Team = Utility.Random(3);

			var iHue = 20 + Team * 40;
			var jHue = 25 + Team * 40;

			Utility.AssignRandomHair(this, iHue);

			var glv = new LeatherGloves {
				Hue = iHue,
				LootType = LootType.Newbied
			};
			AddItem(glv);

			Container pack = new Backpack {
				Movable = false
			};

			AddItem(pack);

			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
		}

		public Dummy(Serial serial) : base(serial)
		{
			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
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

		public override bool HandlesOnSpeech(Mobile from)
		{
			if (from.AccessLevel >= AccessLevel.GameMaster)
			{
				return true;
			}

			return base.HandlesOnSpeech(from);
		}

		public override void OnSpeech(SpeechEventArgs e)
		{
			base.OnSpeech(e);

			if (e.Mobile.AccessLevel >= AccessLevel.GameMaster)
			{
				if (e.Speech == "kill")
				{
					m_Timer.Stop();
					m_Timer.Delay = TimeSpan.FromSeconds(Utility.Random(1, 5));
					m_Timer.Start();
				}
			}
		}

		public override void OnTeamChange()
		{
			var iHue = 20 + Team * 40;
			var jHue = 25 + Team * 40;

			var item = FindItemOnLayer(Layer.OuterTorso);

			if (item != null)
			{
				item.Hue = jHue;
			}

			item = FindItemOnLayer(Layer.Helm);

			if (item != null)
			{
				item.Hue = iHue;
			}

			item = FindItemOnLayer(Layer.Gloves);

			if (item != null)
			{
				item.Hue = iHue;
			}

			item = FindItemOnLayer(Layer.Shoes);

			if (item != null)
			{
				item.Hue = iHue;
			}

			HairHue = iHue;

			item = FindItemOnLayer(Layer.MiddleTorso);

			if (item != null)
			{
				item.Hue = iHue;
			}

			item = FindItemOnLayer(Layer.OuterLegs);

			if (item != null)
			{
				item.Hue = iHue;
			}
		}

		private class AutokillTimer : Timer
		{
			private readonly Dummy m_Owner;

			public AutokillTimer(Dummy owner) : base(TimeSpan.FromMinutes(5.0))
			{
				m_Owner = owner;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Owner.Kill();
				Stop();
			}
		}
	}
}