namespace Server.Items
{
	public class GiantWeb1 : BaseAddon
	{
		[Constructable]
		public GiantWeb1()
		{
			var itemID = 4280;
			var count = 5;
			var leftToRight = false;

			for (var i = 0; i < count; ++i)
			{
				AddComponent(new AddonComponent(itemID++), leftToRight ? i : count - 1 - i, -(leftToRight ? i : count - 1 - i), 0);
			}
		}

		public GiantWeb1(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((byte)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadByte();
		}
	}

	public class GiantWeb2 : BaseAddon
	{
		[Constructable]
		public GiantWeb2()
		{
			var itemID = 4285;
			var count = 5;
			var leftToRight = true;

			for (var i = 0; i < count; ++i)
			{
				AddComponent(new AddonComponent(itemID++), leftToRight ? i : count - 1 - i, -(leftToRight ? i : count - 1 - i), 0);
			}
		}

		public GiantWeb2(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((byte)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadByte();
		}
	}

	public class GiantWeb3 : BaseAddon
	{
		[Constructable]
		public GiantWeb3()
		{
			var itemID = 4290;
			var count = 4;
			var leftToRight = true;

			for (var i = 0; i < count; ++i)
			{
				AddComponent(new AddonComponent(itemID++), leftToRight ? i : count - 1 - i, -(leftToRight ? i : count - 1 - i), 0);
			}
		}

		public GiantWeb3(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((byte)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadByte();
		}
	}

	public class GiantWeb4 : BaseAddon
	{
		[Constructable]
		public GiantWeb4()
		{
			var itemID = 4294;
			var count = 4;
			var leftToRight = false;

			for (var i = 0; i < count; ++i)
			{
				AddComponent(new AddonComponent(itemID++), leftToRight ? i : count - 1 - i, -(leftToRight ? i : count - 1 - i), 0);
			}
		}

		public GiantWeb4(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((byte)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadByte();
		}
	}

	public class GiantWeb5 : BaseAddon
	{
		[Constructable]
		public GiantWeb5()
		{
			var itemID = 4298;
			var count = 4;
			var leftToRight = true;

			for (var i = 0; i < count; ++i)
			{
				AddComponent(new AddonComponent(itemID++), leftToRight ? i : count - 1 - i, -(leftToRight ? i : count - 1 - i), 0);
			}
		}

		public GiantWeb5(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((byte)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadByte();
		}
	}

	public class GiantWeb6 : BaseAddon
	{
		[Constructable]
		public GiantWeb6()
		{
			var itemID = 4302;
			var count = 4;
			var leftToRight = false;

			for (var i = 0; i < count; ++i)
			{
				AddComponent(new AddonComponent(itemID++), leftToRight ? i : count - 1 - i, -(leftToRight ? i : count - 1 - i), 0);
			}
		}

		public GiantWeb6(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((byte)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadByte();
		}
	}
}