using System;

namespace Server.Items
{
	[Flipable(0x13B2, 0x13B1)]
	public abstract class TransientBow : TransientRangedWeapon
	{
		public override int EffectID => 0xF42;

		public override Type AmmoType => typeof(Arrow);
		public override Item Ammo => new Arrow();

		public override WeaponAbility PrimaryAbility => WeaponAbility.ParalyzingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;

		public override int AosStrengthReq => 20;
		public override int AosMinDamage => 10;
		public override int AosMaxDamage => 41;
		public override int AosSpeed => 20;

		public override float MlSpeed => 2.00f;

		public override int OldStrengthReq => 20;
		public override int OldMinDamage => 12;
		public override int OldMaxDamage => 41;
		public override int OldSpeed => 20;

		public override int DefMaxRange => 15;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 60;

		public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;

		public TransientBow(Mobile owner, TimeSpan duration)
			: base(0x13B2, owner, duration)
		{
			Weight = 6.0;
		}

		public TransientBow(Serial serial)
			: base(serial)
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

			_ = reader.ReadInt();
		}
	}
}
