using System;

namespace Server.Items
{
	[Flipable(0x1439, 0x1438)]
	public class TransientHammerOfFaith : TransientMeleeWeapon
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.CrushingBlow;

		public override int AosStrengthReq => 10;
		public override int AosMinDamage => 24;
		public override int AosMaxDamage => 31;
		public override int AosSpeed => 28;

		public override int OldStrengthReq => 40;
		public override int OldMinDamage => 8;
		public override int OldMaxDamage => 36;
		public override int OldSpeed => 31;

		public override float MlSpeed => 3.75f;

		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		[Constructable]
		public TransientHammerOfFaith()
			: this(null)
		{ }

		[Constructable]
		public TransientHammerOfFaith(TimeSpan duration)
			: this(null, duration)
		{ }

		public TransientHammerOfFaith(Mobile owner)
			: this(owner, TimeSpan.Zero)
		{ }

		public TransientHammerOfFaith(Mobile owner, TimeSpan duration)
			: base(0x1439, owner, duration)
		{
			Name = "Hammer of Faith";

			Weight = 10.0;

			Hue = 0x481;

			Layer = Layer.TwoHanded;

			Slayer = SlayerName.Silver;
		}

		public TransientHammerOfFaith(Serial serial)
			: base(serial)
		{
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
