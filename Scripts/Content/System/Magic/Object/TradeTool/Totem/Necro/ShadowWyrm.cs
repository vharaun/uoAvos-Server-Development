namespace Server.Items
{
	public class ShadowWyrmTotem : Item
	{
		private SkillName m_Skill;
		private double m_Required;

		[CommandProperty(AccessLevel.GameMaster)]
		public SkillName Skill
		{
			get => m_Skill;
			set { m_Skill = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public double Required
		{
			get => m_Required;
			set { m_Required = value; InvalidateProperties(); }
		}

		[Constructable]
		public ShadowWyrmTotem() : base(8406) // What Idol Do You Want To Affix To This Creature?
		{
			Movable = true;
			Name = "Shadow Wyrm Idol";
			LootType = LootType.Regular;
		}

		public override void OnDoubleClick(Mobile from)
		{
			var sk = from.Skills[SkillName.Necromancy]; // Choose What Skill This Item Requires
			m_Required = 75; // Choose What Skill Value A Player Needs To Have In The Above Skill To Use This Item

			if (!from.InRange(GetWorldLocation(), 2))
			{
				from.SendLocalizedMessage(500446); // That is too far away. 
			}
			else if (sk.Base >= m_Required)
			{
				if (from.BodyValue == 0x190 || from.BodyValue == 0x191)
				{
					from.BodyValue = 180; // Change Creature Type Here That You Wish Players To Transform Into
					from.HueMod = 0x4001;
					from.PlaySound(0x63F);
					Effects.SendLocationParticles(EffectItem.Create(from.Location, from.Map, EffectItem.DefaultDuration), 0x376A, 1, 29, 0x47D, 2, 9962, 0);
					Effects.SendLocationParticles(EffectItem.Create(new Point3D(from.X, from.Y, from.Z - 7), from.Map, EffectItem.DefaultDuration), 0x37C4, 1, 29, 0x47D, 2, 9502, 0);

				}
				else
				{
					if (from.Female == true)
					{
						from.BodyValue = 0x191;
						from.HueMod = -1;
						from.PlaySound(362);
						Effects.SendLocationParticles(EffectItem.Create(from.Location, from.Map, EffectItem.DefaultDuration), 0x376A, 1, 29, 0x47D, 2, 9962, 0);
						Effects.SendLocationParticles(EffectItem.Create(new Point3D(from.X, from.Y, from.Z - 7), from.Map, EffectItem.DefaultDuration), 0x37C4, 1, 29, 0x47D, 2, 9502, 0);

					}
					else
					{
						from.BodyValue = 0x190;
						from.HueMod = -1;
						from.PlaySound(362);
						Effects.SendLocationParticles(EffectItem.Create(from.Location, from.Map, EffectItem.DefaultDuration), 0x376A, 1, 29, 0x47D, 2, 9962, 0);
						Effects.SendLocationParticles(EffectItem.Create(new Point3D(from.X, from.Y, from.Z - 7), from.Map, EffectItem.DefaultDuration), 0x37C4, 1, 29, 0x47D, 2, 9502, 0);

					}
				}
			}
			else
			{
				if (sk.Base == 0)
				{
					from.SendAsciiMessage("It appears that you aren't a mage!");
				}
				else if (sk.Base >= 1 && sk.Base < m_Required)
				{
					from.SendAsciiMessage("Your magery skill is too low to use this item");
				}
			}
		}

		public ShadowWyrmTotem(Serial serial) : base(serial)
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