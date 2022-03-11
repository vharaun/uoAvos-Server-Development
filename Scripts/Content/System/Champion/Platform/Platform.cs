using Server.Items;
using Server.Mobiles;

namespace Server.Engines.CannedEvil
{
	public class ChampionPlatform : BaseAddon
	{
		private ChampionSpawn m_Spawn;

		public ChampionPlatform(ChampionSpawn spawn)
		{
			m_Spawn = spawn;

			for (var x = -2; x <= 2; ++x)
			{
				for (var y = -2; y <= 2; ++y)
				{
					AddComponent(0x750, x, y, -5);
				}
			}

			for (var x = -1; x <= 1; ++x)
			{
				for (var y = -1; y <= 1; ++y)
				{
					AddComponent(0x750, x, y, 0);
				}
			}

			for (var i = -1; i <= 1; ++i)
			{
				AddComponent(0x751, i, 2, 0);
				AddComponent(0x752, 2, i, 0);

				AddComponent(0x753, i, -2, 0);
				AddComponent(0x754, -2, i, 0);
			}

			AddComponent(0x759, -2, -2, 0);
			AddComponent(0x75A, 2, 2, 0);
			AddComponent(0x75B, -2, 2, 0);
			AddComponent(0x75C, 2, -2, 0);
		}

		public void AddComponent(int id, int x, int y, int z)
		{
			var ac = new AddonComponent(id) {
				Hue = 0x497
			};

			AddComponent(ac, x, y, z);
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if (m_Spawn != null)
			{
				m_Spawn.Delete();
			}
		}

		public ChampionPlatform(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_Spawn);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Spawn = reader.ReadItem() as ChampionSpawn;

						if (m_Spawn == null)
						{
							Delete();
						}

						break;
					}
			}
		}
	}

	public class ChampionSkullPlatform : BaseAddon
	{
		private ChampionSkullBrazier m_Power, m_Enlightenment, m_Venom, m_Pain, m_Greed, m_Death;

		[Constructable]
		public ChampionSkullPlatform()
		{
			AddComponent(new AddonComponent(0x71A), -1, -1, -1);
			AddComponent(new AddonComponent(0x709), 0, -1, -1);
			AddComponent(new AddonComponent(0x709), 1, -1, -1);
			AddComponent(new AddonComponent(0x709), -1, 0, -1);
			AddComponent(new AddonComponent(0x709), 0, 0, -1);
			AddComponent(new AddonComponent(0x709), 1, 0, -1);
			AddComponent(new AddonComponent(0x709), -1, 1, -1);
			AddComponent(new AddonComponent(0x709), 0, 1, -1);
			AddComponent(new AddonComponent(0x71B), 1, 1, -1);

			AddComponent(new AddonComponent(0x50F), 0, -1, 4);
			AddComponent(m_Power = new ChampionSkullBrazier(this, ChampionSkullType.Power), 0, -1, 5);

			AddComponent(new AddonComponent(0x50F), 1, -1, 4);
			AddComponent(m_Enlightenment = new ChampionSkullBrazier(this, ChampionSkullType.Enlightenment), 1, -1, 5);

			AddComponent(new AddonComponent(0x50F), -1, 0, 4);
			AddComponent(m_Venom = new ChampionSkullBrazier(this, ChampionSkullType.Venom), -1, 0, 5);

			AddComponent(new AddonComponent(0x50F), 1, 0, 4);
			AddComponent(m_Pain = new ChampionSkullBrazier(this, ChampionSkullType.Pain), 1, 0, 5);

			AddComponent(new AddonComponent(0x50F), -1, 1, 4);
			AddComponent(m_Greed = new ChampionSkullBrazier(this, ChampionSkullType.Greed), -1, 1, 5);

			AddComponent(new AddonComponent(0x50F), 0, 1, 4);
			AddComponent(m_Death = new ChampionSkullBrazier(this, ChampionSkullType.Death), 0, 1, 5);

			AddonComponent comp = new LocalizedAddonComponent(0x20D2, 1049495) {
				Hue = 0x482
			};
			AddComponent(comp, 0, 0, 5);

			comp = new LocalizedAddonComponent(0x0BCF, 1049496) {
				Hue = 0x482
			};
			AddComponent(comp, 0, 2, -7);

			comp = new LocalizedAddonComponent(0x0BD0, 1049497) {
				Hue = 0x482
			};
			AddComponent(comp, 2, 0, -7);
		}

		public void Validate()
		{
			if (Validate(m_Power) && Validate(m_Enlightenment) && Validate(m_Venom) && Validate(m_Pain) && Validate(m_Greed) && Validate(m_Death))
			{
				Mobile harrower = Harrower.Spawn(new Point3D(X, Y, Z + 6), Map);

				if (harrower == null)
				{
					return;
				}

				Clear(m_Power);
				Clear(m_Enlightenment);
				Clear(m_Venom);
				Clear(m_Pain);
				Clear(m_Greed);
				Clear(m_Death);
			}
		}

		public void Clear(ChampionSkullBrazier brazier)
		{
			if (brazier != null)
			{
				Effects.SendBoltEffect(brazier);

				if (brazier.Skull != null)
				{
					brazier.Skull.Delete();
				}
			}
		}

		public bool Validate(ChampionSkullBrazier brazier)
		{
			return (brazier != null && brazier.Skull != null && !brazier.Skull.Deleted);
		}

		public ChampionSkullPlatform(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_Power);
			writer.Write(m_Enlightenment);
			writer.Write(m_Venom);
			writer.Write(m_Pain);
			writer.Write(m_Greed);
			writer.Write(m_Death);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Power = reader.ReadItem() as ChampionSkullBrazier;
						m_Enlightenment = reader.ReadItem() as ChampionSkullBrazier;
						m_Venom = reader.ReadItem() as ChampionSkullBrazier;
						m_Pain = reader.ReadItem() as ChampionSkullBrazier;
						m_Greed = reader.ReadItem() as ChampionSkullBrazier;
						m_Death = reader.ReadItem() as ChampionSkullBrazier;

						break;
					}
			}
		}
	}
}