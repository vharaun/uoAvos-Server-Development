using Server.Gumps;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Cleric
{
	public class RestorationSpell : ClericSpell
	{
		public RestorationSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, ClericSpellName.Restoration)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (m == Caster)
			{
				Caster.SendLocalizedMessage(501039); // Thou can not resurrect thyself.
			}
			else if (!Caster.Alive)
			{
				Caster.SendLocalizedMessage(501040); // The resurrecter must be alive.
			}
			else if (m.Alive)
			{
				Caster.SendLocalizedMessage(501041); // Target is not dead.
			}
			else if (!Caster.InRange(m, 1))
			{
				Caster.SendLocalizedMessage(501042); // Target is not close enough.
			}
			else if (!m.Player)
			{
				Caster.SendLocalizedMessage(501043); // Target is not a being.
			}
			else if (m.Map == null || !m.Map.CanFit(m.Location, 16, false, false))
			{
				Caster.SendLocalizedMessage(501042); // Target can not be resurrected at that location.
				m.SendLocalizedMessage(502391); // Thou can not be resurrected there!
			}
			else if (CheckBSequence(m, true))
			{
				SpellHelper.Turn(Caster, m);

				m.PlaySound(0x214);
				m.FixedParticles(0x376A, 1, 62, 0x480, 3, 3, EffectLayer.Waist);
				m.FixedParticles(0x3779, 1, 46, 9502, 5, 3, EffectLayer.Waist);

				_ = m.CloseGump(typeof(ResurrectGump));
				_ = m.CloseGump(typeof(RestoreGump));
				_ = m.SendGump(new RestoreGump());
			}

			FinishSequence();
		}

		private class RestoreGump : Gump
		{
			public RestoreGump() 
				: base(100, 0)
			{
				AddPage(0);

				AddBackground(0, 0, 400, 350, 2600);

				AddHtmlLocalized(0, 20, 400, 35, 1011022, false, false); // <center>Resurrection</center>

				AddHtmlLocalized(50, 55, 300, 140, 1011025, true, true);

				AddButton(200, 227, 4005, 4007, 0, GumpButtonType.Reply, 0);
				AddHtmlLocalized(235, 230, 110, 35, 1011012, false, false); // CANCEL

				AddButton(65, 227, 4005, 4007, 1, GumpButtonType.Reply, 0);
				AddHtmlLocalized(100, 230, 110, 35, 1011011, false, false); // CONTINUE
			}

			public override void OnResponse(NetState state, RelayInfo info)
			{
				var from = state.Mobile;

				_ = from.CloseGump(typeof(RestoreGump));
				_ = from.CloseGump(typeof(ResurrectGump));

				if (info.ButtonID == 1)
				{
					if (from.Map == null || !from.Map.CanFit(from.Location, 16, false, false))
					{
						from.SendLocalizedMessage(502391); // Thou can not be resurrected there!
						return;
					}

					from.PlaySound(0x214);
					from.FixedParticles(0x376A, 1, 62, 0x480, 3, 3, EffectLayer.Waist);
					from.FixedParticles(0x3779, 1, 46, 9502, 5, 3, EffectLayer.Waist);

					from.Resurrect();

					from.Hits = from.HitsMax;
					from.Stam = from.StamMax;
					from.Mana = from.ManaMax;
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly RestorationSpell m_Owner;

			public InternalTarget(RestorationSpell owner) 
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile m)
				{
					m_Owner.Target(m);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
