namespace Server.Items
{
	/// DeathEssenceHelm
	[FlipableAttribute(0x1451, 0x1456)]
	public class DeathEssenceHelm : BaseArmor
	{
		public override int LabelNumber => 1074305;
		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 9;
		public override int BaseColdResistance => 6;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 8;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 20;
		public override int OldStrReq => 40;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;


		[Constructable]
		public DeathEssenceHelm() : base(0x1451)
		{
			Weight = 3.0;
			Attributes.RegenMana = 1;
			Attributes.RegenHits = 1;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "5");

			if (Parent is Mobile)
			{
				if (Hue == 0x455)
				{
					list.Add(1072377);
					list.Add(1073488, "10");
					list.Add("Necromancy 10 (total)");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "4");
				list.Add(1072383, "5");
				list.Add(1072384, "3");
				list.Add(1072385, "4");
				list.Add(1072386, "4");
				list.Add(1060450, "3");
				list.Add(1073488, "10");
				list.Add("Necromancy 10 (total)");
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var arms = from.FindItemOnLayer(Layer.Arms);
			var pants = from.FindItemOnLayer(Layer.Pants);

			if (pants != null && pants.GetType() == typeof(DeathEssenceLegs) && shirt != null && shirt.GetType() == typeof(DeathEssenceChest) && glove != null && glove.GetType() == typeof(DeathEssenceGloves) && arms != null && arms.GetType() == typeof(DeathEssenceArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x455;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 4;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 4;
				EnergyBonus = 4;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as DeathEssenceChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as DeathEssenceGloves;
				var arm = from.FindItemOnLayer(Layer.Arms) as DeathEssenceArms;
				var legs = from.FindItemOnLayer(Layer.Pants) as DeathEssenceLegs;

				chest.Hue = 0x455;
				chest.SkillBonuses.SetValues(0, SkillName.Necromancy, 10.0);
				chest.Attributes.LowerManaCost = 10;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 4;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 4;
				chest.EnergyBonus = 4;

				gloves.Hue = 0x455;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 4;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 4;
				gloves.EnergyBonus = 4;

				arm.Hue = 0x455;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 4;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 4;
				arm.EnergyBonus = 4;

				legs.Hue = 0x455;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 4;
				legs.FireBonus = 5;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 4;
				legs.EnergyBonus = 4;

				from.SendLocalizedMessage(1072391);
			}
			InvalidateProperties();
			return base.OnEquip(from);
		}

		public override void OnRemoved(IEntity parent)
		{
			if (parent is Mobile)
			{
				var m = (Mobile)parent;
				Hue = 0x0;
				ArmorAttributes.SelfRepair = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
				if (m.FindItemOnLayer(Layer.Pants) is DeathEssenceLegs && m.FindItemOnLayer(Layer.InnerTorso) is DeathEssenceChest && m.FindItemOnLayer(Layer.Gloves) is DeathEssenceGloves && m.FindItemOnLayer(Layer.Arms) is DeathEssenceArms)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as DeathEssenceChest;
					chest.Hue = 0x0;
					chest.SkillBonuses.SetValues(0, SkillName.Necromancy, 0.0);
					chest.Attributes.LowerManaCost = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as DeathEssenceGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as DeathEssenceArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as DeathEssenceLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
		}

		public DeathEssenceHelm(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);

			if (Weight == 1.0)
			{
				Weight = 3.0;
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	/// DeathEssenceChest
	[FlipableAttribute(0x13CC, 0x13D3)]
	public class DeathEssenceChest : BaseArmor
	{
		public override int LabelNumber => 1074305;
		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 9;
		public override int BaseColdResistance => 6;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 8;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;


		[Constructable]
		public DeathEssenceChest() : base(0x13CC)
		{
			Weight = 10.0;
			Attributes.RegenMana = 1;
			Attributes.RegenHits = 1;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "5");

			if (Parent is Mobile)
			{
				if (Hue == 0x455)
				{
					list.Add(1072377);
					list.Add(1073488, "10");
					list.Add("Necromancy 10 (total)");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "4");
				list.Add(1072383, "5");
				list.Add(1072384, "3");
				list.Add(1072385, "4");
				list.Add(1072386, "4");
				list.Add(1060450, "3");
				list.Add(1073488, "10");
				list.Add("Necromancy 10 (total)");
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var arms = from.FindItemOnLayer(Layer.Arms);
			var helm = from.FindItemOnLayer(Layer.Helm);

			if (helm != null && helm.GetType() == typeof(DeathEssenceHelm) && glove != null && glove.GetType() == typeof(DeathEssenceGloves) && pants != null && pants.GetType() == typeof(DeathEssenceLegs) && arms != null && arms.GetType() == typeof(DeathEssenceArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x455;
				SkillBonuses.SetValues(0, SkillName.Necromancy, 10.0);
				Attributes.LowerManaCost = 10;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 4;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 4;
				EnergyBonus = 4;

				var gloves = from.FindItemOnLayer(Layer.Gloves) as DeathEssenceGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as DeathEssenceLegs;
				var arm = from.FindItemOnLayer(Layer.Arms) as DeathEssenceArms;
				var helmet = from.FindItemOnLayer(Layer.Helm) as DeathEssenceHelm;

				gloves.Hue = 0x455;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 4;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 4;
				gloves.EnergyBonus = 4;

				legs.Hue = 0x455;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 4;
				legs.FireBonus = 5;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 4;
				legs.EnergyBonus = 4;

				arm.Hue = 0x455;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 4;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 4;
				arm.EnergyBonus = 4;

				helmet.Hue = 0x455;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 4;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 4;
				helmet.EnergyBonus = 4;

				from.SendLocalizedMessage(1072391);
			}
			InvalidateProperties();
			return base.OnEquip(from);
		}

		public override void OnRemoved(IEntity parent)
		{
			if (parent is Mobile)
			{
				var m = (Mobile)parent;
				Hue = 0x0;
				SkillBonuses.SetValues(0, SkillName.Necromancy, 0.0);
				Attributes.LowerManaCost = 0;
				ArmorAttributes.SelfRepair = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;

				if (m.FindItemOnLayer(Layer.Helm) is DeathEssenceHelm && m.FindItemOnLayer(Layer.Gloves) is DeathEssenceGloves && m.FindItemOnLayer(Layer.Pants) is DeathEssenceLegs && m.FindItemOnLayer(Layer.Arms) is DeathEssenceArms)
				{
					var gloves = m.FindItemOnLayer(Layer.Gloves) as DeathEssenceGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as DeathEssenceLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as DeathEssenceArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as DeathEssenceHelm;
					helmet.Hue = 0x0;
					helmet.ArmorAttributes.SelfRepair = 0;
					helmet.PhysicalBonus = 0;
					helmet.FireBonus = 0;
					helmet.ColdBonus = 0;
					helmet.PoisonBonus = 0;
					helmet.EnergyBonus = 0;

				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
		}

		public DeathEssenceChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			if (Weight == 1.0)
			{
				Weight = 10.0;
			}
		}
	}

	/// DeathEssenceArms
	[FlipableAttribute(0x13CD, 0x13C5)]
	public class DeathEssenceArms : BaseArmor
	{
		public override int LabelNumber => 1074305;
		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 9;
		public override int BaseColdResistance => 6;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 8;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;


		[Constructable]
		public DeathEssenceArms() : base(0x13CD)
		{
			Weight = 5.0;
			Attributes.RegenMana = 1;
			Attributes.RegenHits = 1;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "5");

			if (Parent is Mobile)
			{
				if (Hue == 0x455)
				{
					list.Add(1072377);
					list.Add(1073488, "10");
					list.Add("Necromancy 10 (total)");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "4");
				list.Add(1072383, "5");
				list.Add(1072384, "3");
				list.Add(1072385, "4");
				list.Add(1072386, "4");
				list.Add(1060450, "3");
				list.Add(1073488, "10");
				list.Add("Necromancy 10 (total)");
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var helm = from.FindItemOnLayer(Layer.Helm);

			if (helm != null && helm.GetType() == typeof(DeathEssenceHelm) && shirt != null && shirt.GetType() == typeof(DeathEssenceChest) && glove != null && glove.GetType() == typeof(DeathEssenceGloves) && pants != null && pants.GetType() == typeof(DeathEssenceLegs))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x455;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 4;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 4;
				EnergyBonus = 4;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as DeathEssenceChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as DeathEssenceGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as DeathEssenceLegs;
				var helmet = from.FindItemOnLayer(Layer.Helm) as DeathEssenceHelm;

				chest.Hue = 0x455;
				chest.SkillBonuses.SetValues(0, SkillName.Necromancy, 10.0);
				chest.Attributes.LowerManaCost = 10;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 4;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 4;
				chest.EnergyBonus = 4;

				gloves.Hue = 0x455;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 4;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 4;
				gloves.EnergyBonus = 4;

				legs.Hue = 0x455;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 4;
				legs.FireBonus = 5;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 4;
				legs.EnergyBonus = 4;

				helmet.Hue = 0x455;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 4;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 4;
				helmet.EnergyBonus = 4;

				from.SendLocalizedMessage(1072391);
			}
			InvalidateProperties();
			return base.OnEquip(from);
		}

		public override void OnRemoved(IEntity parent)
		{
			if (parent is Mobile)
			{
				var m = (Mobile)parent;
				Hue = 0x0;
				ArmorAttributes.SelfRepair = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
				if (m.FindItemOnLayer(Layer.Helm) is DeathEssenceHelm && m.FindItemOnLayer(Layer.InnerTorso) is DeathEssenceChest && m.FindItemOnLayer(Layer.Gloves) is DeathEssenceGloves && m.FindItemOnLayer(Layer.Pants) is DeathEssenceLegs)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as DeathEssenceChest;
					chest.Hue = 0x0;
					chest.SkillBonuses.SetValues(0, SkillName.Necromancy, 0.0);
					chest.Attributes.LowerManaCost = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as DeathEssenceGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as DeathEssenceLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;

					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as DeathEssenceHelm;
					helmet.Hue = 0x0;
					helmet.ArmorAttributes.SelfRepair = 0;

					helmet.PhysicalBonus = 0;
					helmet.FireBonus = 0;
					helmet.ColdBonus = 0;
					helmet.PoisonBonus = 0;
					helmet.EnergyBonus = 0;

				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
		}


		public DeathEssenceArms(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			if (Weight == 1.0)
			{
				Weight = 5.0;
			}
		}
	}

	/// DeathEssenceGloves
	[Flipable]
	public class DeathEssenceGloves : BaseArmor
	{
		public override int LabelNumber => 1074305;
		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 9;
		public override int BaseColdResistance => 6;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 8;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;


		[Constructable]
		public DeathEssenceGloves() : base(0x13C6)
		{
			Weight = 2.0;
			Attributes.RegenMana = 1;
			Attributes.RegenHits = 1;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "5");

			if (Parent is Mobile)
			{
				if (Hue == 0x455)
				{
					list.Add(1072377);
					list.Add(1073488, "10");
					list.Add("Necromancy 10 (total)");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "4");
				list.Add(1072383, "5");
				list.Add(1072384, "3");
				list.Add(1072385, "4");
				list.Add(1072386, "4");
				list.Add(1060450, "3");
				list.Add(1073488, "10");
				list.Add("Necromancy 10 (total)");
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var arms = from.FindItemOnLayer(Layer.Arms);
			var helm = from.FindItemOnLayer(Layer.Helm);

			if (helm != null && helm.GetType() == typeof(DeathEssenceHelm) && shirt != null && shirt.GetType() == typeof(DeathEssenceChest) && pants != null && pants.GetType() == typeof(DeathEssenceLegs) && arms != null && arms.GetType() == typeof(DeathEssenceArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x455;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 4;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 4;
				EnergyBonus = 4;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as DeathEssenceChest;
				var legs = from.FindItemOnLayer(Layer.Pants) as DeathEssenceLegs;
				var arm = from.FindItemOnLayer(Layer.Arms) as DeathEssenceArms;
				var helmet = from.FindItemOnLayer(Layer.Helm) as DeathEssenceHelm;

				chest.Hue = 0x455;
				chest.SkillBonuses.SetValues(0, SkillName.Necromancy, 10.0);
				chest.Attributes.LowerManaCost = 10;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 4;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 4;
				chest.EnergyBonus = 4;

				legs.Hue = 0x455;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 4;
				legs.FireBonus = 5;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 4;
				legs.EnergyBonus = 4;

				arm.Hue = 0x455;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 4;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 4;
				arm.EnergyBonus = 4;

				helmet.Hue = 0x455;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 4;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 4;
				helmet.EnergyBonus = 4;

				from.SendLocalizedMessage(1072391);
			}
			InvalidateProperties();
			return base.OnEquip(from);
		}

		public override void OnRemoved(IEntity parent)
		{
			if (parent is Mobile)
			{
				var m = (Mobile)parent;
				Hue = 0x0;
				ArmorAttributes.SelfRepair = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
				if (m.FindItemOnLayer(Layer.Helm) is DeathEssenceHelm && m.FindItemOnLayer(Layer.InnerTorso) is DeathEssenceChest && m.FindItemOnLayer(Layer.Pants) is DeathEssenceLegs && m.FindItemOnLayer(Layer.Arms) is DeathEssenceArms)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as DeathEssenceChest;
					chest.Hue = 0x0;
					chest.SkillBonuses.SetValues(0, SkillName.Necromancy, 0.0);
					chest.Attributes.LowerManaCost = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;


					var legs = m.FindItemOnLayer(Layer.Pants) as DeathEssenceLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as DeathEssenceArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as DeathEssenceHelm;
					helmet.Hue = 0x0;
					helmet.ArmorAttributes.SelfRepair = 0;
					helmet.PhysicalBonus = 0;
					helmet.FireBonus = 0;
					helmet.ColdBonus = 0;
					helmet.PoisonBonus = 0;
					helmet.EnergyBonus = 0;

				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
		}

		public DeathEssenceGloves(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			if (Weight == 1.0)
			{
				Weight = 2.0;
			}
		}
	}

	/// DeathEssenceLegs
	[FlipableAttribute(0x13CB, 0x13D2)]
	public class DeathEssenceLegs : BaseArmor
	{
		public override int LabelNumber => 1074305;
		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 9;
		public override int BaseColdResistance => 6;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 8;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;


		[Constructable]
		public DeathEssenceLegs() : base(0x13CB)
		{
			Weight = 7.0;
			Attributes.RegenMana = 1;
			Attributes.RegenHits = 1;

		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "5");

			if (Parent is Mobile)
			{
				if (Hue == 0x455)
				{
					list.Add(1072377);
					list.Add(1073488, "10");
					list.Add("Necromancy 10 (total)");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "4");
				list.Add(1072383, "5");
				list.Add(1072384, "3");
				list.Add(1072385, "4");
				list.Add(1072386, "4");
				list.Add(1060450, "3");
				list.Add(1073488, "10");
				list.Add("Necromancy 10 (total)");
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var arms = from.FindItemOnLayer(Layer.Arms);
			var helm = from.FindItemOnLayer(Layer.Helm);

			if (helm != null && helm.GetType() == typeof(DeathEssenceHelm) && shirt != null && shirt.GetType() == typeof(DeathEssenceChest) && glove != null && glove.GetType() == typeof(DeathEssenceGloves) && arms != null && arms.GetType() == typeof(DeathEssenceArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x455;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 4;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 4;
				EnergyBonus = 4;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as DeathEssenceChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as DeathEssenceGloves;
				var arm = from.FindItemOnLayer(Layer.Arms) as DeathEssenceArms;
				var helmet = from.FindItemOnLayer(Layer.Helm) as DeathEssenceHelm;

				chest.Hue = 0x455;
				chest.SkillBonuses.SetValues(0, SkillName.Necromancy, 10.0);
				chest.Attributes.LowerManaCost = 10;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 4;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 4;
				chest.EnergyBonus = 4;

				gloves.Hue = 0x455;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 4;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 4;
				gloves.EnergyBonus = 4;

				arm.Hue = 0x455;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 4;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 4;
				arm.EnergyBonus = 4;

				helmet.Hue = 0x455;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 4;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 4;
				helmet.EnergyBonus = 4;

				from.SendLocalizedMessage(1072391);
			}
			InvalidateProperties();
			return base.OnEquip(from);
		}

		public override void OnRemoved(IEntity parent)
		{
			if (parent is Mobile)
			{
				var m = (Mobile)parent;
				Hue = 0x0;
				ArmorAttributes.SelfRepair = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
				if (m.FindItemOnLayer(Layer.Helm) is DeathEssenceHelm && m.FindItemOnLayer(Layer.InnerTorso) is DeathEssenceChest && m.FindItemOnLayer(Layer.Gloves) is DeathEssenceGloves && m.FindItemOnLayer(Layer.Arms) is DeathEssenceArms)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as DeathEssenceChest;
					chest.Hue = 0x0;
					chest.SkillBonuses.SetValues(0, SkillName.Necromancy, 0.0);
					chest.Attributes.LowerManaCost = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as DeathEssenceGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as DeathEssenceArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as DeathEssenceHelm;
					helmet.Hue = 0x0;
					helmet.ArmorAttributes.SelfRepair = 0;
					helmet.PhysicalBonus = 0;
					helmet.FireBonus = 0;
					helmet.ColdBonus = 0;
					helmet.PoisonBonus = 0;
					helmet.EnergyBonus = 0;

				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
		}

		public DeathEssenceLegs(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}