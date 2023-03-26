using Server.Targeting;

using System;

namespace Server.Items
{
	public class ArachnidaCloak : Cloak
	{
		[Constructable]
		public ArachnidaCloak() : base(4102)
		{
			Name = "Cloak of Arachnida";
			Hue = 1153;
			Weight = 10.0;

			SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
			Attributes.BonusHits = 20;
			Attributes.BonusInt = 15;
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (DateTime.UtcNow >= m_NextAbilityTime)
			{
				from.Target = new webTarget(from, this);
				from.SendMessage("You pull a handful of sticky web from the cloak.");
			}
			else
			{
				from.SendMessage("The cloak does not have enough web to spare!");
			}
		}

		public ArachnidaCloak(Serial serial) : base(serial)
		{
		}
		private DateTime m_NextAbilityTime;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version 
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
			m_NextAbilityTime = DateTime.UtcNow;
		}

		private class webTarget : Target
		{
			private readonly Mobile m_Thrower;
			private readonly ArachnidaCloak m_web;

			public webTarget(Mobile thrower, ArachnidaCloak web) : base(10, false, TargetFlags.None)
			{
				m_Thrower = thrower;
				m_web = web;
			}

			protected override void OnTarget(Mobile from, object target)
			{
				if (target == from)
				{
					from.SendLocalizedMessage(1005576);
				}
				else if (target is Mobile)
				{
					var m = (Mobile)target;
					from.PlaySound(0x1DE);
					//from.Animate( 9, 1, 1, true, false, 0 ); 
					from.SendMessage("You throw the web, temporarily paralyzing your target!");
					m.SendMessage("The web covers you, constricting all limbs!");
					m.Paralyze(TimeSpan.FromSeconds(5));
					Effects.SendMovingEffect(from, m, 0x0EE6, 7, 0, false, true, 1149, 0);
					m_web.m_NextAbilityTime = DateTime.UtcNow + TimeSpan.FromMinutes(30.0);
				}
				else
				{
					from.SendMessage("The cloak has no web to spare!");
				}
			}
		}
	}
}