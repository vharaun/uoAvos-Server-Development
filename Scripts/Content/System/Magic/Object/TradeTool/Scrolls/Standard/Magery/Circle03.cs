namespace Server.Items
{
	public class BlessScroll : SpellScroll
	{
		[Constructable]
		public BlessScroll() : this(1)
		{
		}

		[Constructable]
		public BlessScroll(int amount) : base(SpellName.Bless, 0x1F3D, amount)
		{
		}

		public BlessScroll(Serial serial) : base(serial)
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

	public class FireballScroll : SpellScroll
	{
		[Constructable]
		public FireballScroll() : this(1)
		{
		}

		[Constructable]
		public FireballScroll(int amount) : base(SpellName.Fireball, 0x1F3E, amount)
		{
		}

		public FireballScroll(Serial serial) : base(serial)
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

	public class MagicLockScroll : SpellScroll
	{
		[Constructable]
		public MagicLockScroll() : this(1)
		{
		}

		[Constructable]
		public MagicLockScroll(int amount) : base(SpellName.MagicLock, 0x1F3F, amount)
		{
		}

		public MagicLockScroll(Serial serial) : base(serial)
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

	public class PoisonScroll : SpellScroll
	{
		[Constructable]
		public PoisonScroll() : this(1)
		{
		}

		[Constructable]
		public PoisonScroll(int amount) : base(SpellName.Poison, 0x1F40, amount)
		{
		}

		public PoisonScroll(Serial serial) : base(serial)
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

	public class TelekinesisScroll : SpellScroll
	{
		[Constructable]
		public TelekinesisScroll() : this(1)
		{
		}

		[Constructable]
		public TelekinesisScroll(int amount) : base(SpellName.Telekinesis, 0x1F41, amount)
		{
		}

		public TelekinesisScroll(Serial serial) : base(serial)
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

	public class TeleportScroll : SpellScroll
	{
		[Constructable]
		public TeleportScroll() : this(1)
		{
		}

		[Constructable]
		public TeleportScroll(int amount) : base(SpellName.Teleport, 0x1F42, amount)
		{
		}

		public TeleportScroll(Serial serial) : base(serial)
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

	public class UnlockScroll : SpellScroll
	{
		[Constructable]
		public UnlockScroll() : this(1)
		{
		}

		[Constructable]
		public UnlockScroll(int amount) : base(SpellName.Unlock, 0x1F43, amount)
		{
		}

		public UnlockScroll(Serial serial) : base(serial)
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

	public class WallOfStoneScroll : SpellScroll
	{
		[Constructable]
		public WallOfStoneScroll() : this(1)
		{
		}

		[Constructable]
		public WallOfStoneScroll(int amount) : base(SpellName.WallOfStone, 0x1F44, amount)
		{
		}

		public WallOfStoneScroll(Serial serial) : base(serial)
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