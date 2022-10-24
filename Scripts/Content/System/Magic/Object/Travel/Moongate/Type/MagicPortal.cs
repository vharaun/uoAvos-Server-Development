using System;

namespace Server.Items
{
	public class MoonglowGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		[Constructable]
		public MoonglowGate() : this(true)
		{
		}

		[Constructable]
		public MoonglowGate(bool decays, Point3D loc, Map map) : this(decays)
		{
			MoveToWorld(loc, map);
			Effects.PlaySound(loc, map, 0x20E);
		}

		[Constructable]
		public MoonglowGate(bool decays) : base(new Point3D(4467, 1283, 5), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
			Name = "Gate To Moonglow";
			Hue = 0x26;  //It's Red.

			if (decays)
			{
				m_Decays = true;
				m_DecayTime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

				m_Timer = new InternalTimer(this, m_DecayTime);
				m_Timer.Start();
			}
		}

		public MoonglowGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_Decays);

			if (m_Decays)
			{
				writer.WriteDeltaTime(m_DecayTime);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Decays = reader.ReadBool();

						if (m_Decays)
						{
							m_DecayTime = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_DecayTime);
							m_Timer.Start();
						}

						break;
					}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item, DateTime end) : base(end - DateTime.UtcNow)
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}

	public class BritainGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		[Constructable]
		public BritainGate() : this(true)
		{
		}

		[Constructable]
		public BritainGate(bool decays, Point3D loc, Map map) : this(decays)
		{
			MoveToWorld(loc, map);
			Effects.PlaySound(loc, map, 0x20E);
		}

		[Constructable]
		public BritainGate(bool decays) : base(new Point3D(1336, 1997, 5), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
			Name = "Gate To Britain";
			Hue = 0x26;  //It's Red.

			if (decays)
			{
				m_Decays = true;
				m_DecayTime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

				m_Timer = new InternalTimer(this, m_DecayTime);
				m_Timer.Start();
			}
		}

		public BritainGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_Decays);

			if (m_Decays)
			{
				writer.WriteDeltaTime(m_DecayTime);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Decays = reader.ReadBool();

						if (m_Decays)
						{
							m_DecayTime = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_DecayTime);
							m_Timer.Start();
						}

						break;
					}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item, DateTime end) : base(end - DateTime.UtcNow)
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}

	public class JhelomGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		[Constructable]
		public JhelomGate() : this(true)
		{
		}

		[Constructable]
		public JhelomGate(bool decays, Point3D loc, Map map) : this(decays)
		{
			MoveToWorld(loc, map);
			Effects.PlaySound(loc, map, 0x20E);
		}

		[Constructable]
		public JhelomGate(bool decays) : base(new Point3D(1499, 3771, 5), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
			Name = "Gate To Jhelom";
			Hue = 0x26;  //It's Red.

			if (decays)
			{
				m_Decays = true;
				m_DecayTime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

				m_Timer = new InternalTimer(this, m_DecayTime);
				m_Timer.Start();
			}
		}

		public JhelomGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_Decays);

			if (m_Decays)
			{
				writer.WriteDeltaTime(m_DecayTime);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Decays = reader.ReadBool();

						if (m_Decays)
						{
							m_DecayTime = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_DecayTime);
							m_Timer.Start();
						}

						break;
					}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item, DateTime end) : base(end - DateTime.UtcNow)
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}

	public class YewGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		[Constructable]
		public YewGate() : this(true)
		{
		}

		[Constructable]
		public YewGate(bool decays, Point3D loc, Map map) : this(decays)
		{
			MoveToWorld(loc, map);
			Effects.PlaySound(loc, map, 0x20E);
		}

		[Constructable]
		public YewGate(bool decays) : base(new Point3D(771, 752, 5), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
			Name = "Gate To Yew";
			Hue = 0x26;  //It's Red.

			if (decays)
			{
				m_Decays = true;
				m_DecayTime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

				m_Timer = new InternalTimer(this, m_DecayTime);
				m_Timer.Start();
			}
		}

		public YewGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_Decays);

			if (m_Decays)
			{
				writer.WriteDeltaTime(m_DecayTime);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Decays = reader.ReadBool();

						if (m_Decays)
						{
							m_DecayTime = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_DecayTime);
							m_Timer.Start();
						}

						break;
					}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item, DateTime end) : base(end - DateTime.UtcNow)
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}

	public class MinocGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		[Constructable]
		public MinocGate() : this(true)
		{
		}

		[Constructable]
		public MinocGate(bool decays, Point3D loc, Map map) : this(decays)
		{
			MoveToWorld(loc, map);
			Effects.PlaySound(loc, map, 0x20E);
		}

		[Constructable]
		public MinocGate(bool decays) : base(new Point3D(2701, 692, 5), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
			Name = "Gate To Minoc";
			Hue = 0x26;  //It's Red.

			if (decays)
			{
				m_Decays = true;
				m_DecayTime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

				m_Timer = new InternalTimer(this, m_DecayTime);
				m_Timer.Start();
			}
		}

		public MinocGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_Decays);

			if (m_Decays)
			{
				writer.WriteDeltaTime(m_DecayTime);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Decays = reader.ReadBool();

						if (m_Decays)
						{
							m_DecayTime = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_DecayTime);
							m_Timer.Start();
						}

						break;
					}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item, DateTime end) : base(end - DateTime.UtcNow)
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}

	public class TrinsicGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		[Constructable]
		public TrinsicGate() : this(true)
		{
		}

		[Constructable]
		public TrinsicGate(bool decays, Point3D loc, Map map) : this(decays)
		{
			MoveToWorld(loc, map);
			Effects.PlaySound(loc, map, 0x20E);
		}

		[Constructable]
		public TrinsicGate(bool decays) : base(new Point3D(1828, 2948, -20), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
			Name = "Gate To Trinsic";
			Hue = 0x26;  //It's Red.

			if (decays)
			{
				m_Decays = true;
				m_DecayTime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

				m_Timer = new InternalTimer(this, m_DecayTime);
				m_Timer.Start();
			}
		}

		public TrinsicGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_Decays);

			if (m_Decays)
			{
				writer.WriteDeltaTime(m_DecayTime);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Decays = reader.ReadBool();

						if (m_Decays)
						{
							m_DecayTime = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_DecayTime);
							m_Timer.Start();
						}

						break;
					}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item, DateTime end) : base(end - DateTime.UtcNow)
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}

	public class SkaraBraeGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		[Constructable]
		public SkaraBraeGate() : this(true)
		{
		}

		[Constructable]
		public SkaraBraeGate(bool decays, Point3D loc, Map map) : this(decays)
		{
			MoveToWorld(loc, map);
			Effects.PlaySound(loc, map, 0x20E);
		}

		[Constructable]
		public SkaraBraeGate(bool decays) : base(new Point3D(643, 2067, 5), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
			Name = "Gate To Skara Brae";
			Hue = 0x26;  //It's Red.

			if (decays)
			{
				m_Decays = true;
				m_DecayTime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

				m_Timer = new InternalTimer(this, m_DecayTime);
				m_Timer.Start();
			}
		}

		public SkaraBraeGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_Decays);

			if (m_Decays)
			{
				writer.WriteDeltaTime(m_DecayTime);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Decays = reader.ReadBool();

						if (m_Decays)
						{
							m_DecayTime = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_DecayTime);
							m_Timer.Start();
						}

						break;
					}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item, DateTime end) : base(end - DateTime.UtcNow)
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}

	public class MaginciaGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		[Constructable]
		public MaginciaGate() : this(true)
		{
		}

		[Constructable]
		public MaginciaGate(bool decays, Point3D loc, Map map) : this(decays)
		{
			MoveToWorld(loc, map);
			Effects.PlaySound(loc, map, 0x20E);
		}

		[Constructable]
		public MaginciaGate(bool decays) : base(new Point3D(3563, 2139, 34), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
			Name = "Gate To Magincia";
			Hue = 0x26;  //It's Red.

			if (decays)
			{
				m_Decays = true;
				m_DecayTime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

				m_Timer = new InternalTimer(this, m_DecayTime);
				m_Timer.Start();
			}
		}

		public MaginciaGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_Decays);

			if (m_Decays)
			{
				writer.WriteDeltaTime(m_DecayTime);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Decays = reader.ReadBool();

						if (m_Decays)
						{
							m_DecayTime = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_DecayTime);
							m_Timer.Start();
						}

						break;
					}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item, DateTime end) : base(end - DateTime.UtcNow)
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}

	public class NewHavenGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		[Constructable]
		public NewHavenGate() : this(true)
		{
		}

		[Constructable]
		public NewHavenGate(bool decays, Point3D loc, Map map) : this(decays)
		{
			MoveToWorld(loc, map);
			Effects.PlaySound(loc, map, 0x20E);
		}

		[Constructable]
		public NewHavenGate(bool decays) : base(new Point3D(3450, 2677, 25), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
			Name = "Gate To New Haven";
			Hue = 0x26;  //It's Red.

			if (decays)
			{
				m_Decays = true;
				m_DecayTime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

				m_Timer = new InternalTimer(this, m_DecayTime);
				m_Timer.Start();
			}
		}

		public NewHavenGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_Decays);

			if (m_Decays)
			{
				writer.WriteDeltaTime(m_DecayTime);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Decays = reader.ReadBool();

						if (m_Decays)
						{
							m_DecayTime = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_DecayTime);
							m_Timer.Start();
						}

						break;
					}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item, DateTime end) : base(end - DateTime.UtcNow)
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}

	public class BucsDenGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		[Constructable]
		public BucsDenGate() : this(true)
		{
		}

		[Constructable]
		public BucsDenGate(bool decays, Point3D loc, Map map) : this(decays)
		{
			MoveToWorld(loc, map);
			Effects.PlaySound(loc, map, 0x20E);
		}

		[Constructable]
		public BucsDenGate(bool decays) : base(new Point3D(2711, 2234, 0), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
			Name = "Gate To Buccaneer's Den";
			Hue = 0x26;  //It's Red.

			if (decays)
			{
				m_Decays = true;
				m_DecayTime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

				m_Timer = new InternalTimer(this, m_DecayTime);
				m_Timer.Start();
			}
		}

		public BucsDenGate(Serial serial) : base(serial)
		{
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(m_Decays);

			if (m_Decays)
			{
				writer.WriteDeltaTime(m_DecayTime);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Decays = reader.ReadBool();

						if (m_Decays)
						{
							m_DecayTime = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_DecayTime);
							m_Timer.Start();
						}

						break;
					}
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item, DateTime end) : base(end - DateTime.UtcNow)
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}
}