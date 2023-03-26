using System;

namespace Server.Items
{
	public class TransientFireBow : TransientBow
	{
		[Constructable]
		public TransientFireBow()
			: this(null)
		{ }

		[Constructable]
		public TransientFireBow(TimeSpan duration)
			: this(null, duration)
		{ }

		public TransientFireBow(Mobile owner)
			: this(owner, TimeSpan.Zero)
		{ }

		public TransientFireBow(Mobile owner, TimeSpan duration)
			: base(owner, duration)
		{
			Hue = 1161;
			Name = "Bow of Fire";

			WeaponAttributes.HitFireArea = 100;
			WeaponAttributes.HitFireball = 100;
		}

		public TransientFireBow(Serial serial)
			: base(serial)
		{
		}

		public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
		{
			phys = cold = pois = nrgy = chaos = direct = 0;
			fire = 100;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadInt();
		}
	}
}
