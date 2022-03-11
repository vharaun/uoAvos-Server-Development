namespace Server.Items
{
	/// MageArmorChest
	[FlipableAttribute(0x316B, 0x2B74)]
	public class MageArmorChest : BaseArmor
	{
		public override int LabelNumber => 1074299;
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
		public MageArmorChest() : base(0x316B)
		{
			Weight = 10.0;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "4");

			if (Parent is Mobile)
			{
				if (Hue == 0x47E)
				{
					list.Add(1072377);
					list.Add(1072380, "15");
					list.Add(1072381, "10");
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
				list.Add(1072380, "15");
				list.Add(1072381, "10");
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (glove != null && glove.GetType() == typeof(MageArmorGloves) && pants != null && pants.GetType() == typeof(MageArmorLegs) && arms != null && arms.GetType() == typeof(MageArmorArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x47E;
				ArmorAttributes.SelfRepair = 3;
				Attributes.BonusInt = 10;
				Attributes.SpellDamage = 15;
				PhysicalBonus = 4;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 4;
				EnergyBonus = 4;


				var gloves = from.FindItemOnLayer(Layer.Gloves) as MageArmorGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as MageArmorLegs;
				var arm = from.FindItemOnLayer(Layer.Arms) as MageArmorArms;

				gloves.Hue = 0x47E;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 4;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 4;
				gloves.EnergyBonus = 4;

				legs.Hue = 0x47E;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 4;
				legs.FireBonus = 5;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 4;
				legs.EnergyBonus = 4;

				arm.Hue = 0x47E;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 4;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 4;
				arm.EnergyBonus = 4;


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
				Attributes.BonusInt = 0;
				ArmorAttributes.SelfRepair = 0;
				Attributes.SpellDamage = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;

				if (m.FindItemOnLayer(Layer.Gloves) is MageArmorGloves && m.FindItemOnLayer(Layer.Pants) is MageArmorLegs && m.FindItemOnLayer(Layer.Arms) is MageArmorArms)
				{
					var gloves = m.FindItemOnLayer(Layer.Gloves) as MageArmorGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as MageArmorLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as MageArmorArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
		}

		public MageArmorChest(Serial serial) : base(serial)
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

	/// MageArmorArms
	[FlipableAttribute(0x2B77, 0x316E)]
	public class MageArmorArms : BaseArmor
	{
		public override int LabelNumber => 1074299;
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
		public MageArmorArms() : base(0x2B77)
		{
			Weight = 5.0;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "4");

			if (Parent is Mobile)
			{
				if (Hue == 0x47E)
				{
					list.Add(1072377);
					list.Add(1072380, "15");
					list.Add(1072381, "10");
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
				list.Add(1072380, "15");
				list.Add(1072381, "10");
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);

			if (shirt != null && shirt.GetType() == typeof(MageArmorChest) && glove != null && glove.GetType() == typeof(MageArmorGloves) && pants != null && pants.GetType() == typeof(MageArmorLegs))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x47E;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 4;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 4;
				EnergyBonus = 4;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as MageArmorChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as MageArmorGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as MageArmorLegs;

				chest.Hue = 0x47E;
				chest.Attributes.BonusInt = 10;
				chest.Attributes.SpellDamage = 15;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 4;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 4;
				chest.EnergyBonus = 4;

				gloves.Hue = 0x47E;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 4;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 4;
				gloves.EnergyBonus = 4;

				legs.Hue = 0x47E;
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
				if (m.FindItemOnLayer(Layer.InnerTorso) is MageArmorChest && m.FindItemOnLayer(Layer.Gloves) is MageArmorGloves && m.FindItemOnLayer(Layer.Pants) is MageArmorLegs)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as MageArmorChest;
					chest.Hue = 0x0;
					chest.Attributes.BonusInt = 0;
					chest.Attributes.SpellDamage = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as MageArmorGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as MageArmorLegs;
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


		public MageArmorArms(Serial serial) : base(serial)
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

	/// MageArmorGloves
	[FlipableAttribute(0x2B75, 0x316C)]
	public class MageArmorGloves : BaseArmor
	{
		public override int LabelNumber => 1074299;
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
		public MageArmorGloves() : base(0x2B75)
		{
			Weight = 2.0;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "4");

			if (Parent is Mobile)
			{
				if (Hue == 0x47E)
				{
					list.Add(1072377);
					list.Add(1072380, "15");
					list.Add(1072381, "10");
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
				list.Add(1072380, "15");
				list.Add(1072381, "10");
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (shirt != null && shirt.GetType() == typeof(MageArmorChest) && pants != null && pants.GetType() == typeof(MageArmorLegs) && arms != null && arms.GetType() == typeof(MageArmorArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x47E;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 4;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 4;
				EnergyBonus = 4;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as MageArmorChest;
				var legs = from.FindItemOnLayer(Layer.Pants) as MageArmorLegs;
				var arm = from.FindItemOnLayer(Layer.Arms) as MageArmorArms;

				chest.Hue = 0x47E;
				chest.Attributes.BonusInt = 10;
				chest.Attributes.SpellDamage = 15;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 4;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 4;
				chest.EnergyBonus = 4;

				legs.Hue = 0x47E;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 4;
				legs.FireBonus = 5;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 4;
				legs.EnergyBonus = 4;

				arm.Hue = 0x47E;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 4;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 4;
				arm.EnergyBonus = 4;


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
				if (m.FindItemOnLayer(Layer.InnerTorso) is MageArmorChest && m.FindItemOnLayer(Layer.Pants) is MageArmorLegs && m.FindItemOnLayer(Layer.Arms) is MageArmorArms)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as MageArmorChest;
					chest.Hue = 0x0;
					chest.Attributes.BonusInt = 0;
					chest.Attributes.SpellDamage = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;


					var legs = m.FindItemOnLayer(Layer.Pants) as MageArmorLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as MageArmorArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
		}

		public MageArmorGloves(Serial serial) : base(serial)
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

	/// MageArmorLegs
	[FlipableAttribute(0x2B78, 0x316F)]
	public class MageArmorLegs : BaseArmor
	{
		public override int LabelNumber => 1074299;
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
		public MageArmorLegs() : base(0x2B78)
		{
			Weight = 7.0;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "4");

			if (Parent is Mobile)
			{
				if (Hue == 0x47E)
				{
					list.Add(1072377);
					list.Add(1072380, "15");
					list.Add(1072381, "10");
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
				list.Add(1072380, "15");
				list.Add(1072381, "10");
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (shirt != null && shirt.GetType() == typeof(MageArmorChest) && glove != null && glove.GetType() == typeof(MageArmorGloves) && arms != null && arms.GetType() == typeof(MageArmorArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x47E;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 4;
				FireBonus = 5;
				ColdBonus = 3;
				PoisonBonus = 4;
				EnergyBonus = 4;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as MageArmorChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as MageArmorGloves;
				var arm = from.FindItemOnLayer(Layer.Arms) as MageArmorArms;

				chest.Hue = 0x47E;
				chest.Attributes.BonusInt = 10;
				chest.Attributes.SpellDamage = 25;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 4;
				chest.FireBonus = 5;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 4;
				chest.EnergyBonus = 4;

				gloves.Hue = 0x47E;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 4;
				gloves.FireBonus = 5;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 4;
				gloves.EnergyBonus = 4;

				arm.Hue = 0x47E;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 4;
				arm.FireBonus = 5;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 4;
				arm.EnergyBonus = 4;


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
				if (m.FindItemOnLayer(Layer.InnerTorso) is MageArmorChest && m.FindItemOnLayer(Layer.Gloves) is MageArmorGloves && m.FindItemOnLayer(Layer.Arms) is MageArmorArms)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as MageArmorChest;
					chest.Hue = 0x0;
					chest.Attributes.BonusInt = 0;
					chest.Attributes.SpellDamage = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as MageArmorGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as MageArmorArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
		}

		public MageArmorLegs(Serial serial) : base(serial)
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