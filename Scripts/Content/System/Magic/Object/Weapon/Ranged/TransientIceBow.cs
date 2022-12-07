using System;

namespace Server.Items
{
	public class TransientIceBow : TransientBow
	{
		[Constructable]
		public TransientIceBow()
			: this(null)
		{ }

		[Constructable]
		public TransientIceBow(TimeSpan duration)
			: this(null, duration)
		{ }

		public TransientIceBow(Mobile owner)
			: this(owner, TimeSpan.Zero)
		{ }

		public TransientIceBow(Mobile owner, TimeSpan duration)
			: base(owner, duration)
		{
			Hue = 1266;
			Name = "Bow of Ice";

			WeaponAttributes.HitColdArea = 100;
			WeaponAttributes.HitHarm = 100;
		}

		public TransientIceBow(Serial serial)
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
			phys = fire = pois = nrgy = chaos = direct = 0;
			cold = 100;
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
