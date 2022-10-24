using System;

namespace Server.Items
{
	public class TransientNoxBow : TransientBow
	{
		[Constructable]
		public TransientNoxBow()
			: this(null)
		{ }

		[Constructable]
		public TransientNoxBow(TimeSpan duration)
			: this(null, duration)
		{ }

		public TransientNoxBow(Mobile owner)
			: this(owner, TimeSpan.Zero)
		{ }

		public TransientNoxBow(Mobile owner, TimeSpan duration)
			: base(owner, duration)
		{
			Hue = 1272;
			Name = "Nox Bow";

			WeaponAttributes.HitPoisonArea = 100;
		}

		public TransientNoxBow(Serial serial)
			: base(serial)
		{
		}

		public override void OnHit(Mobile attacker, Mobile defender, double damageBonus)
		{
			if (Utility.RandomDouble() <= 0.1)
			{
				_ = defender.ApplyPoison(defender, Poison.Lesser);
			}

			base.OnHit(attacker, defender, damageBonus);
		}

		public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
		{
			phys = cold = fire = nrgy = chaos = direct = 0;
			pois = 100;
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
