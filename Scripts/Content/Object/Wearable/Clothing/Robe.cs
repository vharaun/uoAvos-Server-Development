
using System;

namespace Server.Items
{
	/// Robe
	[Flipable]
	public class Robe : BaseOuterTorso, IArcaneEquip
	{
		#region Arcane Impl
		private int m_MaxArcaneCharges, m_CurArcaneCharges;

		[CommandProperty(AccessLevel.GameMaster)]
		public int MaxArcaneCharges
		{
			get => m_MaxArcaneCharges;
			set { m_MaxArcaneCharges = value; InvalidateProperties(); Update(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int CurArcaneCharges
		{
			get => m_CurArcaneCharges;
			set { m_CurArcaneCharges = value; InvalidateProperties(); Update(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsArcane => (m_MaxArcaneCharges > 0 && m_CurArcaneCharges >= 0);

		public void Update()
		{
			if (IsArcane)
			{
				ItemID = 0x26AE;
			}
			else if (ItemID == 0x26AE)
			{
				ItemID = 0x1F04;
			}

			if (IsArcane && CurArcaneCharges == 0)
			{
				Hue = 0;
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (IsArcane)
			{
				list.Add(1061837, "{0}\t{1}", m_CurArcaneCharges, m_MaxArcaneCharges); // arcane charges: ~1_val~ / ~2_val~
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			base.OnSingleClick(from);

			if (IsArcane)
			{
				LabelTo(from, 1061837, String.Format("{0}\t{1}", m_CurArcaneCharges, m_MaxArcaneCharges));
			}
		}

		public void Flip()
		{
			if (ItemID == 0x1F03)
			{
				ItemID = 0x1F04;
			}
			else if (ItemID == 0x1F04)
			{
				ItemID = 0x1F03;
			}
		}
		#endregion

		[Constructable]
		public Robe() : this(0)
		{
		}

		[Constructable]
		public Robe(int hue) : base(0x1F03, hue)
		{
			Weight = 3.0;
		}

		public Robe(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version

			if (IsArcane)
			{
				writer.Write(true);
				writer.Write(m_CurArcaneCharges);
				writer.Write(m_MaxArcaneCharges);
			}
			else
			{
				writer.Write(false);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						if (reader.ReadBool())
						{
							m_CurArcaneCharges = reader.ReadInt();
							m_MaxArcaneCharges = reader.ReadInt();

							if (Hue == 2118)
							{
								Hue = ArcaneGem.DefaultArcaneHue;
							}
						}

						break;
					}
			}
		}
	}

	/// MonkRobe
	public class MonkRobe : BaseOuterTorso
	{
		[Constructable]
		public MonkRobe() : this(0x21E)
		{
		}

		[Constructable]
		public MonkRobe(int hue) : base(0x2687, hue)
		{
			Weight = 1.0;
			StrRequirement = 0;
		}
		public override int LabelNumber => 1076584;  // A monk's robe
		public override bool CanBeBlessed => false;
		public override bool Dye(Mobile from, DyeTub sender)
		{
			from.SendLocalizedMessage(sender.FailMessage);
			return false;
		}
		public MonkRobe(Serial serial) : base(serial)
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

	/// MaleElvenRobe
	[Flipable(0x2FB9, 0x3173)]
	public class MaleElvenRobe : BaseOuterTorso
	{
		public override Race RequiredRace => Race.Elf;

		[Constructable]
		public MaleElvenRobe() : this(0)
		{
		}

		[Constructable]
		public MaleElvenRobe(int hue) : base(0x2FB9, hue)
		{
			Weight = 2.0;
		}

		public MaleElvenRobe(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// FemaleElvenRobe
	[Flipable(0x2FBA, 0x3174)]
	public class FemaleElvenRobe : BaseOuterTorso
	{
		public override Race RequiredRace => Race.Elf;
		[Constructable]
		public FemaleElvenRobe() : this(0)
		{
		}

		[Constructable]
		public FemaleElvenRobe(int hue) : base(0x2FBA, hue)
		{
			Weight = 2.0;
		}

		public override bool AllowMaleWearer => false;

		public FemaleElvenRobe(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// MaleKimono
	[Flipable(0x2782, 0x27CD)]
	public class MaleKimono : BaseOuterTorso
	{
		[Constructable]
		public MaleKimono() : this(0)
		{
		}

		[Constructable]
		public MaleKimono(int hue) : base(0x2782, hue)
		{
			Weight = 3.0;
		}

		public override bool AllowFemaleWearer => false;

		public MaleKimono(Serial serial) : base(serial)
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

	/// FemaleKimono
	[Flipable(0x2783, 0x27CE)]
	public class FemaleKimono : BaseOuterTorso
	{
		[Constructable]
		public FemaleKimono() : this(0)
		{
		}

		[Constructable]
		public FemaleKimono(int hue) : base(0x2783, hue)
		{
			Weight = 3.0;
		}

		public override bool AllowMaleWearer => false;

		public FemaleKimono(Serial serial) : base(serial)
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

	/// DeathRobe
	public class DeathRobe : Robe
	{
		private Timer m_DecayTimer;
		private DateTime m_DecayTime;

		private static readonly TimeSpan m_DefaultDecayTime = TimeSpan.FromMinutes(1.0);

		public override bool DisplayLootType => false;

		[Constructable]
		public DeathRobe()
		{
			LootType = LootType.Newbied;
			Hue = 2301;
			BeginDecay(m_DefaultDecayTime);
		}

		public new bool Scissor(Mobile from, Scissors scissors)
		{
			from.SendLocalizedMessage(502440); // Scissors can not be used on that to produce anything.
			return false;
		}

		public void BeginDecay()
		{
			BeginDecay(m_DefaultDecayTime);
		}

		private void BeginDecay(TimeSpan delay)
		{
			if (m_DecayTimer != null)
			{
				m_DecayTimer.Stop();
			}

			m_DecayTime = DateTime.UtcNow + delay;

			m_DecayTimer = new InternalTimer(this, delay);
			m_DecayTimer.Start();
		}

		public override bool OnDroppedToWorld(Mobile from, Point3D p)
		{
			BeginDecay(m_DefaultDecayTime);

			return true;
		}

		public override bool OnDroppedToMobile(Mobile from, Mobile target)
		{
			if (m_DecayTimer != null)
			{
				m_DecayTimer.Stop();
				m_DecayTimer = null;
			}

			return true;
		}

		public override void OnAfterDelete()
		{
			if (m_DecayTimer != null)
			{
				m_DecayTimer.Stop();
			}

			m_DecayTimer = null;
		}

		private class InternalTimer : Timer
		{
			private readonly DeathRobe m_Robe;

			public InternalTimer(DeathRobe c, TimeSpan delay) : base(delay)
			{
				m_Robe = c;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				if (m_Robe.Parent != null || m_Robe.IsLockedDown)
				{
					Stop();
				}
				else
				{
					m_Robe.Delete();
				}
			}
		}

		public DeathRobe(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(2); // version

			writer.Write(m_DecayTimer != null);

			if (m_DecayTimer != null)
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
				case 2:
					{
						if (reader.ReadBool())
						{
							m_DecayTime = reader.ReadDeltaTime();
							BeginDecay(m_DecayTime - DateTime.UtcNow);
						}
						break;
					}
				case 1:
				case 0:
					{
						if (Parent == null)
						{
							BeginDecay(m_DefaultDecayTime);
						}

						break;
					}
			}

			if (version < 1 && Hue == 0)
			{
				Hue = 2301;
			}
		}
	}
}