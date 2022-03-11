using Server.Targeting;

namespace Server.Items
{
	public class WaterPitcher : Item
	{
		[Constructable]
		public WaterPitcher() : base(Utility.Random(0x1f9d, 2))
		{
			Weight = 1.0;
		}

		public WaterPitcher(Serial serial) : base(serial)
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

		public override void OnDoubleClick(Mobile from)
		{
			if (!Movable)
			{
				return;
			}

			from.Target = new InternalTarget(this);
		}

		private class InternalTarget : Target
		{
			private readonly WaterPitcher m_Item;

			public InternalTarget(WaterPitcher item) : base(1, false, TargetFlags.None)
			{
				m_Item = item;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (m_Item.Deleted)
				{
					return;
				}

				if (targeted is BowlFlour)
				{
					m_Item.Delete();
					((BowlFlour)targeted).Delete();

					from.AddToBackpack(new Dough());
					from.AddToBackpack(new WoodenBowl());
				}
			}
		}
	}
}