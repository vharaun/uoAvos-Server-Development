namespace Server.Items
{
	/// PlateOfHonorHelm
	public class PlateOfHonorHelm : BaseArmor
	{
		public override int LabelNumber => 1074303;
		public override int BasePhysicalResistance => 8;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 80;
		public override int OldStrReq => 40;

		public override int OldDexBonus => -1;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateOfHonorHelm() : base(0x1412)
		{
			Weight = 5.0;
			Attributes.RegenHits = 1;
			Attributes.AttackChance = 5;
		}

		public PlateOfHonorHelm(Serial serial) : base(serial)
		{
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x47E)
				{
					list.Add(1072377);
					list.Add(1072513, "25");
					list.Add("Chivalry 10 (total)");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "2");
				list.Add(1072383, "5");
				list.Add(1072384, "5");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");
				list.Add(1072513, "25");
				list.Add("Chivalry 10 (total)");
				list.Add(1060441);
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var neck = from.FindItemOnLayer(Layer.Neck);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (shirt != null && shirt.GetType() == typeof(PlateOfHonorChest) && glove != null && glove.GetType() == typeof(PlateOfHonorGloves) && pants != null && pants.GetType() == typeof(PlateOfHonorLegs) && neck != null && neck.GetType() == typeof(PlateOfHonorGorget) && arms != null && arms.GetType() == typeof(PlateOfHonorArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x47E;
				ArmorAttributes.SelfRepair = 3;
				Attributes.NightSight = 1;
				PhysicalBonus = 2;
				FireBonus = 5;
				ColdBonus = 5;
				PoisonBonus = 3;
				EnergyBonus = 5;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as PlateOfHonorChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as PlateOfHonorGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as PlateOfHonorLegs;
				var gorget = from.FindItemOnLayer(Layer.Neck) as PlateOfHonorGorget;
				var arm = from.FindItemOnLayer(Layer.Arms) as PlateOfHonorArms;

				chest.Hue = 0x47E;
				chest.Attributes.NightSight = 1;
				chest.Attributes.ReflectPhysical = 25;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 10.0);
				chest.PhysicalBonus = 2;
				chest.FireBonus = 5;
				chest.ColdBonus = 5;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 5;

				gloves.Hue = 0x47E;
				gloves.Attributes.NightSight = 1;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 2;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 5;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 5;

				legs.Hue = 0x47E;
				legs.Attributes.NightSight = 1;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 2;
				legs.FireBonus = 5;
				legs.ColdBonus = 5;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 5;

				gorget.Hue = 0x47E;
				gorget.Attributes.NightSight = 1;
				gorget.ArmorAttributes.SelfRepair = 3;
				gorget.PhysicalBonus = 2;
				gorget.FireBonus = 5;
				gorget.ColdBonus = 5;
				gorget.PoisonBonus = 3;
				gorget.EnergyBonus = 5;

				arm.Hue = 0x47E;
				arm.Attributes.NightSight = 1;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 2;
				arm.FireBonus = 5;
				arm.ColdBonus = 5;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 5;

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
				Attributes.NightSight = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
				if (m.FindItemOnLayer(Layer.InnerTorso) is PlateOfHonorChest && m.FindItemOnLayer(Layer.Gloves) is PlateOfHonorGloves && m.FindItemOnLayer(Layer.Arms) is PlateOfHonorArms && m.FindItemOnLayer(Layer.Pants) is PlateOfHonorLegs && m.FindItemOnLayer(Layer.Neck) is PlateOfHonorGorget)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as PlateOfHonorChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.ReflectPhysical = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 0.0);
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as PlateOfHonorGloves;
					gloves.Hue = 0x0;
					gloves.Attributes.NightSight = 0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as PlateOfHonorArms;
					arm.Hue = 0x0;
					arm.Attributes.NightSight = 0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as PlateOfHonorLegs;
					legs.Hue = 0x0;
					legs.Attributes.NightSight = 0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var gorget = m.FindItemOnLayer(Layer.Neck) as PlateOfHonorGorget;
					gorget.Hue = 0x0;
					gorget.Attributes.NightSight = 0;
					gorget.ArmorAttributes.SelfRepair = 0;
					gorget.PhysicalBonus = 0;
					gorget.FireBonus = 0;
					gorget.ColdBonus = 0;
					gorget.PoisonBonus = 0;
					gorget.EnergyBonus = 0;
				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
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

	/// PlateOfHonorGorget
	public class PlateOfHonorGorget : BaseArmor
	{
		public override int LabelNumber => 1074303;
		public override int BasePhysicalResistance => 8;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 45;
		public override int OldStrReq => 30;

		public override int OldDexBonus => -1;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateOfHonorGorget() : base(0x1413)
		{
			Weight = 2.0;
			Attributes.RegenHits = 1;
			Attributes.AttackChance = 5;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x47E)
				{
					list.Add(1072377);
					list.Add(1072513, "25");
					list.Add("Chivalry 10 (total)");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "2");
				list.Add(1072383, "5");
				list.Add(1072384, "5");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");
				list.Add(1072513, "25");
				list.Add("Chivalry 10 (total)");
				list.Add(1060441);
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var helm = from.FindItemOnLayer(Layer.Helm);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (shirt != null && shirt.GetType() == typeof(PlateOfHonorChest) && glove != null && glove.GetType() == typeof(PlateOfHonorGloves) && pants != null && pants.GetType() == typeof(PlateOfHonorLegs) && helm != null && helm.GetType() == typeof(PlateOfHonorHelm) && arms != null && arms.GetType() == typeof(PlateOfHonorArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x47E;
				ArmorAttributes.SelfRepair = 3;
				Attributes.NightSight = 1;
				PhysicalBonus = 2;
				FireBonus = 5;
				ColdBonus = 5;
				PoisonBonus = 3;
				EnergyBonus = 5;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as PlateOfHonorChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as PlateOfHonorGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as PlateOfHonorLegs;
				var helmet = from.FindItemOnLayer(Layer.Helm) as PlateOfHonorHelm;
				var arm = from.FindItemOnLayer(Layer.Arms) as PlateOfHonorArms;

				chest.Hue = 0x47E;
				chest.Attributes.NightSight = 1;
				chest.Attributes.ReflectPhysical = 25;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 10.0);
				chest.PhysicalBonus = 2;
				chest.FireBonus = 5;
				chest.ColdBonus = 5;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 5;

				gloves.Hue = 0x47E;
				gloves.Attributes.NightSight = 1;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 2;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 5;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 5;

				legs.Hue = 0x47E;
				legs.Attributes.NightSight = 1;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 2;
				legs.FireBonus = 5;
				legs.ColdBonus = 5;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 5;

				helmet.Hue = 0x47E;
				helmet.Attributes.NightSight = 1;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 2;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 5;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 5;

				arm.Hue = 0x47E;
				arm.Attributes.NightSight = 1;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 2;
				arm.FireBonus = 5;
				arm.ColdBonus = 5;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 5;

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
				Attributes.NightSight = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
				if (m.FindItemOnLayer(Layer.InnerTorso) is PlateOfHonorChest && m.FindItemOnLayer(Layer.Gloves) is PlateOfHonorGloves && m.FindItemOnLayer(Layer.Arms) is PlateOfHonorArms && m.FindItemOnLayer(Layer.Pants) is PlateOfHonorLegs && m.FindItemOnLayer(Layer.Helm) is PlateOfHonorHelm)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as PlateOfHonorChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.ReflectPhysical = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 0.0);
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as PlateOfHonorGloves;
					gloves.Hue = 0x0;
					gloves.Attributes.NightSight = 0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as PlateOfHonorArms;
					arm.Hue = 0x0;
					arm.Attributes.NightSight = 0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as PlateOfHonorLegs;
					legs.Hue = 0x0;
					legs.Attributes.NightSight = 0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as PlateOfHonorHelm;
					helmet.Hue = 0x0;
					helmet.Attributes.NightSight = 0;
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

		public PlateOfHonorGorget(Serial serial) : base(serial)
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

	/// PlateOfHonorChest
	[FlipableAttribute(0x1415, 0x1416)]
	public class PlateOfHonorChest : BaseArmor
	{
		public override int LabelNumber => 1074303;
		public override int BasePhysicalResistance => 8;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 95;
		public override int OldStrReq => 60;

		public override int OldDexBonus => -8;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateOfHonorChest() : base(0x1415)
		{
			Weight = 10.0;
			Attributes.RegenHits = 1;
			Attributes.AttackChance = 5;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x47E)
				{
					list.Add(1072377);
					list.Add(1072513, "25");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "2");
				list.Add(1072383, "5");
				list.Add(1072384, "5");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");
				list.Add(1072513, "25");
				list.Add("Chivalry 10 (total)");
				list.Add(1060441);
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var neck = from.FindItemOnLayer(Layer.Neck);
			var helm = from.FindItemOnLayer(Layer.Helm);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (glove != null && glove.GetType() == typeof(PlateOfHonorGloves) && pants != null && pants.GetType() == typeof(PlateOfHonorLegs) && neck != null && neck.GetType() == typeof(PlateOfHonorGorget) && helm != null && helm.GetType() == typeof(PlateOfHonorHelm) && arms != null && arms.GetType() == typeof(PlateOfHonorArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x47E;
				ArmorAttributes.SelfRepair = 3;
				Attributes.NightSight = 1;
				Attributes.ReflectPhysical = 25;
				SkillBonuses.SetValues(0, SkillName.Chivalry, 10.0);
				PhysicalBonus = 2;
				FireBonus = 5;
				ColdBonus = 5;
				PoisonBonus = 3;
				EnergyBonus = 5;


				var gloves = from.FindItemOnLayer(Layer.Gloves) as PlateOfHonorGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as PlateOfHonorLegs;
				var gorget = from.FindItemOnLayer(Layer.Neck) as PlateOfHonorGorget;
				var helmet = from.FindItemOnLayer(Layer.Helm) as PlateOfHonorHelm;
				var arm = from.FindItemOnLayer(Layer.Arms) as PlateOfHonorArms;

				gloves.Hue = 0x47E;
				gloves.Attributes.NightSight = 1;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 2;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 5;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 5;

				legs.Hue = 0x47E;
				legs.Attributes.NightSight = 1;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 2;
				legs.FireBonus = 5;
				legs.ColdBonus = 5;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 5;

				gorget.Hue = 0x47E;
				gorget.Attributes.NightSight = 1;
				gorget.ArmorAttributes.SelfRepair = 3;
				gorget.PhysicalBonus = 2;
				gorget.FireBonus = 5;
				gorget.ColdBonus = 5;
				gorget.PoisonBonus = 3;
				gorget.EnergyBonus = 5;

				helmet.Hue = 0x47E;
				helmet.Attributes.NightSight = 1;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 2;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 5;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 5; ;

				arm.Hue = 0x47E;
				arm.Attributes.NightSight = 1;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 2;
				arm.FireBonus = 5;
				arm.ColdBonus = 5;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 5;


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
				Attributes.NightSight = 0;
				ArmorAttributes.SelfRepair = 0;
				Attributes.ReflectPhysical = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
				SkillBonuses.SetValues(0, SkillName.Chivalry, 0.0);

				if (m.FindItemOnLayer(Layer.Gloves) is PlateOfHonorGloves && m.FindItemOnLayer(Layer.Pants) is PlateOfHonorLegs && m.FindItemOnLayer(Layer.Arms) is PlateOfHonorArms && m.FindItemOnLayer(Layer.Neck) is PlateOfHonorGorget && m.FindItemOnLayer(Layer.Helm) is PlateOfHonorHelm)
				{
					var gloves = m.FindItemOnLayer(Layer.Gloves) as PlateOfHonorGloves;
					gloves.Hue = 0x0;
					gloves.Attributes.NightSight = 0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as PlateOfHonorLegs;
					legs.Hue = 0x0;
					legs.Attributes.NightSight = 0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as PlateOfHonorArms;
					arm.Hue = 0x0;
					arm.Attributes.NightSight = 0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var gorget = m.FindItemOnLayer(Layer.Neck) as PlateOfHonorGorget;
					gorget.Hue = 0x0;
					gorget.Attributes.NightSight = 0;
					gorget.ArmorAttributes.SelfRepair = 0;
					gorget.PhysicalBonus = 0;
					gorget.FireBonus = 0;
					gorget.ColdBonus = 0;
					gorget.PoisonBonus = 0;
					gorget.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as PlateOfHonorHelm;
					helmet.Hue = 0x0;
					helmet.Attributes.NightSight = 0;
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

		public PlateOfHonorChest(Serial serial) : base(serial)
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

	/// PlateOfHonorArms
	[FlipableAttribute(0x1410, 0x1417)]
	public class PlateOfHonorArms : BaseArmor
	{
		public override int LabelNumber => 1074303;
		public override int BasePhysicalResistance => 8;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 80;
		public override int OldStrReq => 40;

		public override int OldDexBonus => -2;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateOfHonorArms() : base(0x1410)
		{
			Weight = 5.0;
			Attributes.RegenHits = 1;
			Attributes.AttackChance = 5;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x47E)
				{
					list.Add(1072377);
					list.Add(1072513, "25");
					list.Add("Chivalry 10 (total)");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "2");
				list.Add(1072383, "5");
				list.Add(1072384, "5");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");
				list.Add(1072513, "25");
				list.Add("Chivalry 10 (total)");
				list.Add(1060441);
			}
		}


		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var helm = from.FindItemOnLayer(Layer.Helm);
			var neck = from.FindItemOnLayer(Layer.Neck);

			if (shirt != null && shirt.GetType() == typeof(PlateOfHonorChest) && glove != null && glove.GetType() == typeof(PlateOfHonorGloves) && pants != null && pants.GetType() == typeof(PlateOfHonorLegs) && helm != null && helm.GetType() == typeof(PlateOfHonorHelm) && neck != null && neck.GetType() == typeof(PlateOfHonorGorget))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x47E;
				ArmorAttributes.SelfRepair = 3;
				Attributes.NightSight = 1;
				PhysicalBonus = 2;
				FireBonus = 5;
				ColdBonus = 5;
				PoisonBonus = 3;
				EnergyBonus = 5;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as PlateOfHonorChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as PlateOfHonorGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as PlateOfHonorLegs;
				var helmet = from.FindItemOnLayer(Layer.Helm) as PlateOfHonorHelm;
				var gorget = from.FindItemOnLayer(Layer.Neck) as PlateOfHonorGorget;

				chest.Hue = 0x47E;
				chest.Attributes.NightSight = 1;
				chest.Attributes.ReflectPhysical = 25;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 10.0);
				chest.PhysicalBonus = 2;
				chest.FireBonus = 5;
				chest.ColdBonus = 5;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 5;

				gloves.Hue = 0x47E;
				gloves.Attributes.NightSight = 1;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 2;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 5;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 5;

				legs.Hue = 0x47E;
				legs.Attributes.NightSight = 1;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 2;
				legs.FireBonus = 5;
				legs.ColdBonus = 5;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 5;

				helmet.Hue = 0x47E;
				helmet.Attributes.NightSight = 1;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 2;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 5;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 5;

				gorget.Hue = 0x47E;
				gorget.Attributes.NightSight = 1;
				gorget.ArmorAttributes.SelfRepair = 3;
				gorget.PhysicalBonus = 2;
				gorget.FireBonus = 5;
				gorget.ColdBonus = 5;
				gorget.PoisonBonus = 3;
				gorget.EnergyBonus = 5;

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
				Attributes.NightSight = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
				if (m.FindItemOnLayer(Layer.InnerTorso) is PlateOfHonorChest && m.FindItemOnLayer(Layer.Gloves) is PlateOfHonorGloves && m.FindItemOnLayer(Layer.Neck) is PlateOfHonorGorget && m.FindItemOnLayer(Layer.Pants) is PlateOfHonorLegs && m.FindItemOnLayer(Layer.Helm) is PlateOfHonorHelm)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as PlateOfHonorChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.ReflectPhysical = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 0.0);
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as PlateOfHonorGloves;
					gloves.Hue = 0x0;
					gloves.Attributes.NightSight = 0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var gorget = m.FindItemOnLayer(Layer.Neck) as PlateOfHonorGorget;
					gorget.Hue = 0x0;
					gorget.Attributes.NightSight = 0;
					gorget.ArmorAttributes.SelfRepair = 0;
					gorget.PhysicalBonus = 0;
					gorget.FireBonus = 0;
					gorget.ColdBonus = 0;
					gorget.PoisonBonus = 0;
					gorget.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as PlateOfHonorLegs;
					legs.Hue = 0x0;
					legs.Attributes.NightSight = 0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as PlateOfHonorHelm;
					helmet.Hue = 0x0;
					helmet.Attributes.NightSight = 0;
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


		public PlateOfHonorArms(Serial serial) : base(serial)
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

	/// PlateOfHonorGloves
	[FlipableAttribute(0x1414, 0x1418)]
	public class PlateOfHonorGloves : BaseArmor
	{
		public override int LabelNumber => 1074303;
		public override int BasePhysicalResistance => 8;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 70;
		public override int OldStrReq => 30;

		public override int OldDexBonus => -2;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateOfHonorGloves() : base(0x1414)
		{
			Weight = 2.0;
			Attributes.RegenHits = 1;
			Attributes.AttackChance = 5;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x47E)
				{
					list.Add(1072377);
					list.Add(1072513, "25");
					list.Add("Chivalry 10 (total)");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "2");
				list.Add(1072383, "5");
				list.Add(1072384, "5");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");
				list.Add(1072513, "25");
				list.Add("Chivalry 10 (total)");
				list.Add(1060441);
			}
		}
		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var neck = from.FindItemOnLayer(Layer.Neck);
			var helm = from.FindItemOnLayer(Layer.Helm);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (shirt != null && shirt.GetType() == typeof(PlateOfHonorChest) && pants != null && pants.GetType() == typeof(PlateOfHonorLegs) && neck != null && neck.GetType() == typeof(PlateOfHonorGorget) && helm != null && helm.GetType() == typeof(PlateOfHonorHelm) && arms != null && arms.GetType() == typeof(PlateOfHonorArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x47E;
				ArmorAttributes.SelfRepair = 3;
				Attributes.NightSight = 1;
				PhysicalBonus = 2;
				FireBonus = 5;
				ColdBonus = 5;
				PoisonBonus = 3;
				EnergyBonus = 5;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as PlateOfHonorChest;
				var legs = from.FindItemOnLayer(Layer.Pants) as PlateOfHonorLegs;
				var gorget = from.FindItemOnLayer(Layer.Neck) as PlateOfHonorGorget;
				var helmet = from.FindItemOnLayer(Layer.Helm) as PlateOfHonorHelm;
				var arm = from.FindItemOnLayer(Layer.Arms) as PlateOfHonorArms;

				chest.Hue = 0x47E;
				chest.Attributes.NightSight = 1;
				chest.Attributes.ReflectPhysical = 25;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 10.0);
				chest.PhysicalBonus = 2;
				chest.FireBonus = 5;
				chest.ColdBonus = 5;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 5;

				legs.Hue = 0x47E;
				legs.Attributes.NightSight = 1;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 2;
				legs.FireBonus = 5;
				legs.ColdBonus = 5;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 5;

				gorget.Hue = 0x47E;
				gorget.Attributes.NightSight = 1;
				gorget.ArmorAttributes.SelfRepair = 3;
				gorget.PhysicalBonus = 2;
				gorget.FireBonus = 5;
				gorget.ColdBonus = 5;
				gorget.PoisonBonus = 3;
				gorget.EnergyBonus = 5;

				helmet.Hue = 0x47E;
				helmet.Attributes.NightSight = 1;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 2;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 5;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 5;

				arm.Hue = 0x47E;
				arm.Attributes.NightSight = 1;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 2;
				arm.FireBonus = 5;
				arm.ColdBonus = 5;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 5;


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
				Attributes.NightSight = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
				if (m.FindItemOnLayer(Layer.InnerTorso) is PlateOfHonorChest && m.FindItemOnLayer(Layer.Pants) is PlateOfHonorLegs && m.FindItemOnLayer(Layer.Arms) is PlateOfHonorArms && m.FindItemOnLayer(Layer.Neck) is PlateOfHonorGorget && m.FindItemOnLayer(Layer.Helm) is PlateOfHonorHelm)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as PlateOfHonorChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.ReflectPhysical = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 0.0);
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;


					var legs = m.FindItemOnLayer(Layer.Pants) as PlateOfHonorLegs;
					legs.Hue = 0x0;
					legs.Attributes.NightSight = 0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as PlateOfHonorArms;
					arm.Hue = 0x0;
					arm.Attributes.NightSight = 0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var gorget = m.FindItemOnLayer(Layer.Neck) as PlateOfHonorGorget;
					gorget.Hue = 0x0;
					gorget.Attributes.NightSight = 0;
					gorget.ArmorAttributes.SelfRepair = 0;
					gorget.PhysicalBonus = 0;
					gorget.FireBonus = 0;
					gorget.ColdBonus = 0;
					gorget.PoisonBonus = 0;
					gorget.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as PlateOfHonorHelm;
					helmet.Hue = 0x0;
					helmet.Attributes.NightSight = 0;
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

		public PlateOfHonorGloves(Serial serial) : base(serial)
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

	/// PlateOfHonorLegs
	[FlipableAttribute(0x1411, 0x141a)]
	public class PlateOfHonorLegs : BaseArmor
	{
		public override int LabelNumber => 1074303;
		public override int BasePhysicalResistance => 8;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 90;

		public override int OldStrReq => 60;
		public override int OldDexBonus => -6;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateOfHonorLegs() : base(0x1411)
		{
			Weight = 7.0;
			Attributes.RegenHits = 1;
			Attributes.AttackChance = 5;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x47E)
				{
					list.Add(1072377);
					list.Add(1072513, "25");
					list.Add("Chivalry 10 (total)");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "2");
				list.Add(1072383, "5");
				list.Add(1072384, "5");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");
				list.Add(1072513, "25");
				list.Add("Chivalry 10 (total)");
				list.Add(1060441);
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var neck = from.FindItemOnLayer(Layer.Neck);
			var helm = from.FindItemOnLayer(Layer.Helm);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (shirt != null && shirt.GetType() == typeof(PlateOfHonorChest) && glove != null && glove.GetType() == typeof(PlateOfHonorGloves) && neck != null && neck.GetType() == typeof(PlateOfHonorGorget) && helm != null && helm.GetType() == typeof(PlateOfHonorHelm) && arms != null && arms.GetType() == typeof(PlateOfHonorArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x47E;
				ArmorAttributes.SelfRepair = 3;
				Attributes.NightSight = 1;
				PhysicalBonus = 2;
				FireBonus = 5;
				ColdBonus = 5;
				PoisonBonus = 3;
				EnergyBonus = 5;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as PlateOfHonorChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as PlateOfHonorGloves;
				var gorget = from.FindItemOnLayer(Layer.Neck) as PlateOfHonorGorget;
				var helmet = from.FindItemOnLayer(Layer.Helm) as PlateOfHonorHelm;
				var arm = from.FindItemOnLayer(Layer.Arms) as PlateOfHonorArms;

				chest.Hue = 0x47E;
				chest.Attributes.NightSight = 1;
				chest.Attributes.ReflectPhysical = 25;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 10.0);
				chest.PhysicalBonus = 2;
				chest.FireBonus = 5;
				chest.ColdBonus = 5;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 5;

				gloves.Hue = 0x47E;
				gloves.Attributes.NightSight = 1;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 2;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 5;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 5;

				gorget.Hue = 0x47E;
				gorget.Attributes.NightSight = 1;
				gorget.ArmorAttributes.SelfRepair = 3;
				gorget.PhysicalBonus = 2;
				gorget.FireBonus = 5;
				gorget.ColdBonus = 5;
				gorget.PoisonBonus = 3;
				gorget.EnergyBonus = 5;

				helmet.Hue = 0x47E;
				helmet.Attributes.NightSight = 1;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 2;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 5;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 5;

				arm.Hue = 0x47E;
				arm.Attributes.NightSight = 1;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 2;
				arm.FireBonus = 5;
				arm.ColdBonus = 5;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 5;


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
				Attributes.NightSight = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
				if (m.FindItemOnLayer(Layer.InnerTorso) is PlateOfHonorChest && m.FindItemOnLayer(Layer.Gloves) is PlateOfHonorGloves && m.FindItemOnLayer(Layer.Arms) is PlateOfHonorArms && m.FindItemOnLayer(Layer.Neck) is PlateOfHonorGorget && m.FindItemOnLayer(Layer.Helm) is PlateOfHonorHelm)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as PlateOfHonorChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.ReflectPhysical = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 0.0);
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as PlateOfHonorGloves;
					gloves.Hue = 0x0;
					gloves.Attributes.NightSight = 0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as PlateOfHonorArms;
					arm.Hue = 0x0;
					arm.Attributes.NightSight = 0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var gorget = m.FindItemOnLayer(Layer.Neck) as PlateOfHonorGorget;
					gorget.Hue = 0x0;
					gorget.Attributes.NightSight = 0;
					gorget.ArmorAttributes.SelfRepair = 0;
					gorget.PhysicalBonus = 0;
					gorget.FireBonus = 0;
					gorget.ColdBonus = 0;
					gorget.PoisonBonus = 0;
					gorget.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as PlateOfHonorHelm;
					helmet.Hue = 0x0;
					helmet.Attributes.NightSight = 0;
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

		public PlateOfHonorLegs(Serial serial) : base(serial)
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