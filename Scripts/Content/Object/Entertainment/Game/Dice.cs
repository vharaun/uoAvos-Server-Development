using Server.Network;

using System;

namespace Server.Items
{
	public class Dice : Item, ITelekinesisable
	{
		[Constructable]
		public Dice() : base(0xFA7)
		{
			Weight = 1.0;
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!from.InRange(GetWorldLocation(), 2))
			{
				return;
			}

			Roll(from);
		}

		public void OnTelekinesis(Mobile from)
		{
			Effects.SendLocationParticles(EffectItem.Create(Location, Map, EffectItem.DefaultDuration), 0x376A, 9, 32, 5022);
			Effects.PlaySound(Location, Map, 0x1F5);

			Roll(from);
		}

		public void Roll(Mobile from)
		{
			PublicOverheadMessage(MessageType.Regular, 0, false, String.Format("*{0} rolls {1}, {2}*", from.Name, Utility.Random(1, 6), Utility.Random(1, 6)));
		}

		public Dice(Serial serial) : base(serial)
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
	}
}