namespace Server.Items
{
	public class AttuneWeaponScroll : SpellScroll
	{
		[Constructable]
		public AttuneWeaponScroll()
			: this(1)
		{
		}

		[Constructable]
		public AttuneWeaponScroll(int amount)
			: base(603, 0x2D54, amount)
		{
			Hue = 0x8FD;
		}

		public AttuneWeaponScroll(Serial serial)
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

			var version = reader.ReadInt();
		}
	}
}