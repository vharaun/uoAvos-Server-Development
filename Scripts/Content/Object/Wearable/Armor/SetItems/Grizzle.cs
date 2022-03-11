namespace Server.Items
{
	/// GrizzleHelm
	[FlipableAttribute(0x1451, 0x1456)]
	public class GrizzleHelm : BaseArmor
	{
		public override int LabelNumber => 1072120;
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 10;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 10;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 60;
		public override int OldStrReq => 40;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;

		[Constructable]
		public GrizzleHelm() : base(0x1451)
		{
			Weight = 3.0;
			Attributes.BonusHits = 5;
			ArmorAttributes.MageArmor = 1;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "5");

			if (Parent is Mobile)
			{
				if (Hue == 0x279)
				{
					list.Add(1072377);
					list.Add(1073493, "10");
					list.Add(1072514, "12");
					list.Add(1060441);
					list.Add(1060450, "3");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "3");
				list.Add(1072383, "5");
				list.Add(1072384, "3");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");

			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var arms = from.FindItemOnLayer(Layer.Arms);
			var pants = from.FindItemOnLayer(Layer.Pants);

			if (pants != null && pants.GetType() == typeof(GrizzleLegs) && shirt != null && shirt.GetType() == typeof(GrizzleChest) && glove != null && glove.GetType() == typeof(GrizzleGloves) && arms != null && arms.GetType() == typeof(GrizzleArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x279;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 5;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as GrizzleChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as GrizzleGloves;
				var arm = from.FindItemOnLayer(Layer.Arms) as GrizzleArms;
				var legs = from.FindItemOnLayer(Layer.Pants) as GrizzleLegs;

				chest.Hue = 0x279;
				chest.Attributes.BonusStr = 12;
				chest.Attributes.DefendChance = 10;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.Attributes.NightSight = 1;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 5;

				gloves.Hue = 0x279;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 5;

				arm.Hue = 0x279;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 3;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 5;

				legs.Hue = 0x279;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 5;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 5;

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
				if (m.FindItemOnLayer(Layer.Pants) is GrizzleLegs && m.FindItemOnLayer(Layer.InnerTorso) is GrizzleChest && m.FindItemOnLayer(Layer.Gloves) is GrizzleGloves && m.FindItemOnLayer(Layer.Arms) is GrizzleArms)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as GrizzleChest;
					chest.Hue = 0x0;
					chest.Attributes.DefendChance = 0;
					chest.Attributes.BonusStr = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.Attributes.NightSight = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as GrizzleGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as GrizzleArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as GrizzleLegs;
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

		public GrizzleHelm(Serial serial) : base(serial)
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

	/// GrizzleChest
	[FlipableAttribute(0x144F, 0x1454)]
	public class GrizzleChest : BaseArmor
	{
		public override int LabelNumber => 1072118;
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 10;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 10;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 60;
		public override int OldStrReq => 40;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;


		[Constructable]
		public GrizzleChest() : base(0x144F)
		{
			Weight = 10.0;
			Attributes.BonusHits = 5;
			ArmorAttributes.MageArmor = 1;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "5");

			if (Parent is Mobile)
			{
				if (Hue == 0x279)
				{
					list.Add(1072377);
					list.Add(1073493, "10");
					list.Add(1072514, "12");
					list.Add(1060441);
					list.Add(1060450, "3");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "3");
				list.Add(1072383, "5");
				list.Add(1072384, "3");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");

			}
		}

		public override bool OnEquip(Mobile from)
		{

			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var arms = from.FindItemOnLayer(Layer.Arms);
			var helm = from.FindItemOnLayer(Layer.Helm);

			if (helm != null && helm.GetType() == typeof(GrizzleHelm) && glove != null && glove.GetType() == typeof(GrizzleGloves) && pants != null && pants.GetType() == typeof(GrizzleLegs) && arms != null && arms.GetType() == typeof(GrizzleArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x279;
				Attributes.BonusStr = 12;
				Attributes.DefendChance = 10;
				Attributes.NightSight = 1;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 5;

				var gloves = from.FindItemOnLayer(Layer.Gloves) as GrizzleGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as GrizzleLegs;
				var arm = from.FindItemOnLayer(Layer.Arms) as GrizzleArms;
				var helmet = from.FindItemOnLayer(Layer.Helm) as GrizzleHelm;

				gloves.Hue = 0x279;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 5;

				legs.Hue = 0x279;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 5;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 5;

				arm.Hue = 0x279;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 3;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 5;

				helmet.Hue = 0x279;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 3;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 5;

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
				Attributes.BonusStr = 0;
				ArmorAttributes.SelfRepair = 0;
				Attributes.NightSight = 0;
				Attributes.DefendChance = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;

				if (m.FindItemOnLayer(Layer.Helm) is GrizzleHelm && m.FindItemOnLayer(Layer.Gloves) is GrizzleGloves && m.FindItemOnLayer(Layer.Pants) is GrizzleLegs && m.FindItemOnLayer(Layer.Arms) is GrizzleArms)
				{
					var gloves = m.FindItemOnLayer(Layer.Gloves) as GrizzleGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as GrizzleLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as GrizzleArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as GrizzleHelm;
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

		public GrizzleChest(Serial serial) : base(serial)
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

	/// GrizzleArms
	[FlipableAttribute(0x144E, 0x1453)]
	public class GrizzleArms : BaseArmor
	{
		public override int LabelNumber => 1072121;
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 10;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 10;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 60;
		public override int OldStrReq => 40;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;


		[Constructable]
		public GrizzleArms() : base(0x144E)
		{
			Weight = 5.0;
			Attributes.BonusHits = 5;
			ArmorAttributes.MageArmor = 1;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "5");

			if (Parent is Mobile)
			{
				if (Hue == 0x279)
				{
					list.Add(1072377);
					list.Add(1073493, "10");
					list.Add(1072514, "12");
					list.Add(1060441);
					list.Add(1060450, "3");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "3");
				list.Add(1072383, "5");
				list.Add(1072384, "3");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");

			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var helm = from.FindItemOnLayer(Layer.Helm);

			if (helm != null && helm.GetType() == typeof(GrizzleHelm) && shirt != null && shirt.GetType() == typeof(GrizzleChest) && glove != null && glove.GetType() == typeof(GrizzleGloves) && pants != null && pants.GetType() == typeof(GrizzleLegs))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x279;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 5;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as GrizzleChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as GrizzleGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as GrizzleLegs;
				var helmet = from.FindItemOnLayer(Layer.Helm) as GrizzleHelm;

				chest.Hue = 0x279;
				chest.Attributes.BonusStr = 12;
				chest.Attributes.DefendChance = 10;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.Attributes.NightSight = 1;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 5;

				gloves.Hue = 0x279;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 5;

				legs.Hue = 0x279;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 5;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 5;

				helmet.Hue = 0x279;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 3;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 5;

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
				if (m.FindItemOnLayer(Layer.Helm) is GrizzleHelm && m.FindItemOnLayer(Layer.InnerTorso) is GrizzleChest && m.FindItemOnLayer(Layer.Gloves) is GrizzleGloves && m.FindItemOnLayer(Layer.Pants) is GrizzleLegs)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as GrizzleChest;
					chest.Hue = 0x0;
					chest.Attributes.BonusStr = 0;
					chest.Attributes.DefendChance = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.Attributes.NightSight = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as GrizzleGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as GrizzleLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;

					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as GrizzleHelm;
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


		public GrizzleArms(Serial serial) : base(serial)
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

	/// GrizzleGloves
	[FlipableAttribute(0x1450, 0x1455)]
	public class GrizzleGloves : BaseArmor
	{
		public override int LabelNumber => 1072122;
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 10;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 10;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 60;
		public override int OldStrReq => 40;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;


		[Constructable]
		public GrizzleGloves() : base(0x1450)
		{
			Weight = 2.0;
			Attributes.BonusHits = 5;
			ArmorAttributes.MageArmor = 1;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "5");

			if (Parent is Mobile)
			{
				if (Hue == 0x279)
				{
					list.Add(1072377);
					list.Add(1073493, "10");
					list.Add(1072514, "12");
					list.Add(1060441);
					list.Add(1060450, "3");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "3");
				list.Add(1072383, "5");
				list.Add(1072384, "3");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");

			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var arms = from.FindItemOnLayer(Layer.Arms);
			var helm = from.FindItemOnLayer(Layer.Helm);

			if (helm != null && helm.GetType() == typeof(GrizzleHelm) && shirt != null && shirt.GetType() == typeof(GrizzleChest) && pants != null && pants.GetType() == typeof(GrizzleLegs) && arms != null && arms.GetType() == typeof(GrizzleArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x279;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 5;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as GrizzleChest;
				var legs = from.FindItemOnLayer(Layer.Pants) as GrizzleLegs;
				var arm = from.FindItemOnLayer(Layer.Arms) as GrizzleArms;
				var helmet = from.FindItemOnLayer(Layer.Helm) as GrizzleHelm;

				chest.Hue = 0x279;
				chest.Attributes.BonusStr = 12;
				chest.Attributes.DefendChance = 10;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.Attributes.NightSight = 1;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 5;

				legs.Hue = 0x279;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 5;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 5;

				arm.Hue = 0x279;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 3;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 5;

				helmet.Hue = 0x279;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 3;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 5;

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
				if (m.FindItemOnLayer(Layer.Helm) is GrizzleHelm && m.FindItemOnLayer(Layer.InnerTorso) is GrizzleChest && m.FindItemOnLayer(Layer.Pants) is GrizzleLegs && m.FindItemOnLayer(Layer.Arms) is GrizzleArms)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as GrizzleChest;
					chest.Hue = 0x0;
					chest.Attributes.BonusStr = 0;
					chest.Attributes.DefendChance = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.Attributes.NightSight = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;


					var legs = m.FindItemOnLayer(Layer.Pants) as GrizzleLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as GrizzleArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as GrizzleHelm;
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

		public GrizzleGloves(Serial serial) : base(serial)
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

	/// GrizzleLegs
	[FlipableAttribute(0x1452, 0x1457)]
	public class GrizzleLegs : BaseArmor
	{
		public override int LabelNumber => 1072119;
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 10;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 7;
		public override int BaseEnergyResistance => 10;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 60;
		public override int OldStrReq => 40;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;


		[Constructable]
		public GrizzleLegs() : base(0x1452)
		{
			Weight = 7.0;
			Attributes.BonusHits = 5;
			ArmorAttributes.MageArmor = 1;

		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "5");

			if (Parent is Mobile)
			{
				if (Hue == 0x279)
				{
					list.Add(1072377);
					list.Add(1073493, "10");
					list.Add(1072514, "12");
					list.Add(1060441);
					list.Add(1060450, "3");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1072382, "3");
				list.Add(1072383, "5");
				list.Add(1072384, "3");
				list.Add(1072385, "3");
				list.Add(1072386, "5");
				list.Add(1060450, "3");

			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var arms = from.FindItemOnLayer(Layer.Arms);
			var helm = from.FindItemOnLayer(Layer.Helm);

			if (helm != null && helm.GetType() == typeof(GrizzleHelm) && shirt != null && shirt.GetType() == typeof(GrizzleChest) && glove != null && glove.GetType() == typeof(GrizzleGloves) && arms != null && arms.GetType() == typeof(GrizzleArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x279;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 4;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 4;
				EnergyBonus = 4;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as GrizzleChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as GrizzleGloves;
				var arm = from.FindItemOnLayer(Layer.Arms) as GrizzleArms;
				var helmet = from.FindItemOnLayer(Layer.Helm) as GrizzleHelm;

				chest.Hue = 0x279;
				chest.Attributes.BonusStr = 12;
				chest.Attributes.DefendChance = 10;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.Attributes.NightSight = 1;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 5;

				gloves.Hue = 0x279;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 5;

				arm.Hue = 0x279;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 3;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 5;

				helmet.Hue = 0x279;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 3;
				helmet.FireBonus = 5;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 5;

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
				if (m.FindItemOnLayer(Layer.Helm) is GrizzleHelm && m.FindItemOnLayer(Layer.InnerTorso) is GrizzleChest && m.FindItemOnLayer(Layer.Gloves) is GrizzleGloves && m.FindItemOnLayer(Layer.Arms) is GrizzleArms)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as GrizzleChest;
					chest.Hue = 0x0;
					chest.Attributes.BonusStr = 0;
					chest.Attributes.DefendChance = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.Attributes.NightSight = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as GrizzleGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as GrizzleArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as GrizzleHelm;
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

		public GrizzleLegs(Serial serial) : base(serial)
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