using Server.Gumps;

namespace Server.Items
{
	public class RessurectionGate : Item
	{
		public override string DefaultName => "a resurrection gate";

		[Constructable]
		public RessurectionGate() : base(0xF6C)
		{
			Movable = false;
			Hue = 0x2D1;
			Light = LightType.Circle300;
		}

		public RessurectionGate(Serial serial) : base(serial)
		{
		}

		public override bool OnMoveOver(Mobile m)
		{
			if (!m.Alive && m.Map != null && m.Map.CanFit(m.Location, 16, false, false))
			{
				m.PlaySound(0x214);
				m.FixedEffect(0x376A, 10, 16);

				m.CloseGump(typeof(ResurrectGump));
				m.SendGump(new ResurrectGump(m));
			}
			else
			{
				m.SendLocalizedMessage(502391); // Thou can not be resurrected there!
			}

			return false;
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