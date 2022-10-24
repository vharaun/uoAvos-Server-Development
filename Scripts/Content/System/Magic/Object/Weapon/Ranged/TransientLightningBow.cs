using System;

namespace Server.Items
{
	public class TransientLightningBow : TransientBow
	{
		[Constructable]
		public TransientLightningBow()
			: this(null)
		{ }

		[Constructable]
		public TransientLightningBow(TimeSpan duration)
			: this(null, duration)
		{ }

		public TransientLightningBow(Mobile owner)
			: this(owner, TimeSpan.Zero)
		{ }

		public TransientLightningBow(Mobile owner, TimeSpan duration)
			: base(owner, duration)
		{
			Hue = 1278;
			Name = "Bow of Lightning";

			WeaponAttributes.HitEnergyArea = 100;
			WeaponAttributes.HitLightning = 100;
		}

		public TransientLightningBow(Serial serial)
			: base(serial)
		{
		}

		public override void OnHit(Mobile attacker, Mobile defender, double damageBonus)
		{
			if (Utility.RandomDouble() <= 0.1)
			{
				Effects.SendBoltEffect(defender, true);
			}

			base.OnHit(attacker, defender, damageBonus);
		}

		public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
		{
			phys = fire = cold = pois = chaos = direct = 0;
			nrgy = 100;
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
