namespace Server.Items
{
	/// AcolyteChest
	[FlipableAttribute(0x13CC, 0x13D3)]
	public class AcolyteChest : BaseArmor
	{
		public override int LabelNumber => 1074307;
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 7;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;


		[Constructable]
		public AcolyteChest() : base(0x13CC)
		{
			Weight = 10.0;
			Attributes.BonusMana = 2;
			Attributes.SpellDamage = 2;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "4");

			if (Parent is Mobile)
			{
				if (Hue == 0x2)
				{
					list.Add(1072377);
					list.Add(1073489, "100");
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
				list.Add(1072383, "3");
				list.Add(1072384, "3");
				list.Add(1072385, "3");
				list.Add(1072386, "3");
				list.Add(1060450, "3");
				list.Add(1073489, "100");
				list.Add(1060441);
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (glove != null && glove.GetType() == typeof(AcolyteGloves) && pants != null && pants.GetType() == typeof(AcolyteLegs) && arms != null && arms.GetType() == typeof(AcolyteArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x2;
				ArmorAttributes.SelfRepair = 3;
				Attributes.Luck = 100;
				Attributes.NightSight = 1;
				PhysicalBonus = 3;
				FireBonus = 3;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 3;


				var gloves = from.FindItemOnLayer(Layer.Gloves) as AcolyteGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as AcolyteLegs;
				var arm = from.FindItemOnLayer(Layer.Arms) as AcolyteArms;

				gloves.Hue = 0x2;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 3;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 3;

				legs.Hue = 0x2;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 3;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 3;

				arm.Hue = 0x2;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 3;
				arm.FireBonus = 3;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 3;


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
				Attributes.Luck = 0;
				ArmorAttributes.SelfRepair = 0;
				Attributes.NightSight = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;

				if (m.FindItemOnLayer(Layer.Gloves) is AcolyteGloves && m.FindItemOnLayer(Layer.Pants) is AcolyteLegs && m.FindItemOnLayer(Layer.Arms) is AcolyteArms)
				{
					var gloves = m.FindItemOnLayer(Layer.Gloves) as AcolyteGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as AcolyteLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as AcolyteArms;
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

		public AcolyteChest(Serial serial) : base(serial)
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

	/// AcolyteArms
	[FlipableAttribute(0x13CD, 0x13C5)]
	public class AcolyteArms : BaseArmor
	{
		public override int LabelNumber => 1074307;
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 7;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;


		[Constructable]
		public AcolyteArms() : base(0x13CD)
		{
			Weight = 5.0;
			Attributes.BonusMana = 2;
			Attributes.SpellDamage = 2;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "4");

			if (Parent is Mobile)
			{
				if (Hue == 0x2)
				{
					list.Add(1072377);
					list.Add(1073489, "100");
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
				list.Add(1072383, "3");
				list.Add(1072384, "3");
				list.Add(1072385, "3");
				list.Add(1072386, "3");
				list.Add(1060450, "3");
				list.Add(1073489, "100");
				list.Add(1060441);
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var pants = from.FindItemOnLayer(Layer.Pants);

			if (shirt != null && shirt.GetType() == typeof(AcolyteChest) && glove != null && glove.GetType() == typeof(AcolyteGloves) && pants != null && pants.GetType() == typeof(AcolyteLegs))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x2;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 3;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 3;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as AcolyteChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as AcolyteGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as AcolyteLegs;

				chest.Hue = 0x2;
				chest.Attributes.NightSight = 1;
				chest.Attributes.Luck = 100;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 3;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 3;

				gloves.Hue = 0x2;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 3;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 3;

				legs.Hue = 0x2;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 3;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 3;

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
				if (m.FindItemOnLayer(Layer.InnerTorso) is AcolyteChest && m.FindItemOnLayer(Layer.Gloves) is AcolyteGloves && m.FindItemOnLayer(Layer.Pants) is AcolyteLegs)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as AcolyteChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.Luck = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as AcolyteGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as AcolyteLegs;
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


		public AcolyteArms(Serial serial) : base(serial)
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

	/// AcolyteGloves
	[FlipableAttribute(0x13C6, 0x13CE)]
	public class AcolyteGloves : BaseArmor
	{
		public override int LabelNumber => 1074307;
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 7;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;


		[Constructable]
		public AcolyteGloves() : base(0x13C6)
		{
			Weight = 2.0;
			Attributes.BonusMana = 2;
			Attributes.SpellDamage = 2;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "4");

			if (Parent is Mobile)
			{
				if (Hue == 0x2)
				{
					list.Add(1072377);
					list.Add(1073489, "100");
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
				list.Add(1072383, "3");
				list.Add(1072384, "3");
				list.Add(1072385, "3");
				list.Add(1072386, "3");
				list.Add(1060450, "3");
				list.Add(1073489, "100");
				list.Add(1060441);
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var pants = from.FindItemOnLayer(Layer.Pants);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (shirt != null && shirt.GetType() == typeof(AcolyteChest) && pants != null && pants.GetType() == typeof(AcolyteLegs) && arms != null && arms.GetType() == typeof(AcolyteArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x2;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 3;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 3;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as AcolyteChest;
				var legs = from.FindItemOnLayer(Layer.Pants) as AcolyteLegs;
				var arm = from.FindItemOnLayer(Layer.Arms) as AcolyteArms;

				chest.Hue = 0x2;
				chest.Attributes.Luck = 100;
				chest.Attributes.NightSight = 1;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 3;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 3;

				legs.Hue = 0x2;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 3;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 3;

				arm.Hue = 0x2;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 3;
				arm.FireBonus = 3;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 3;


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
				if (m.FindItemOnLayer(Layer.InnerTorso) is AcolyteChest && m.FindItemOnLayer(Layer.Pants) is AcolyteLegs && m.FindItemOnLayer(Layer.Arms) is AcolyteArms)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as AcolyteChest;
					chest.Hue = 0x0;
					chest.Attributes.Luck = 0;
					chest.Attributes.NightSight = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;


					var legs = m.FindItemOnLayer(Layer.Pants) as AcolyteLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as AcolyteArms;
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

		public AcolyteGloves(Serial serial) : base(serial)
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

	/// AcolyteLegs
	[FlipableAttribute(0x13CB, 0x13D2)]
	public class AcolyteLegs : BaseArmor
	{
		public override int LabelNumber => 1074307;
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 7;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;


		[Constructable]
		public AcolyteLegs() : base(0x13CB)
		{
			Weight = 7.0;
			Attributes.BonusMana = 2;
			Attributes.SpellDamage = 2;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "4");

			if (Parent is Mobile)
			{
				if (Hue == 0x2)
				{
					list.Add(1072377);
					list.Add(1073489, "100");
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
				list.Add(1072383, "3");
				list.Add(1072384, "3");
				list.Add(1072385, "3");
				list.Add(1072386, "3");
				list.Add(1060450, "3");
				list.Add(1073489, "100");
				list.Add(1060441);
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var shirt = from.FindItemOnLayer(Layer.InnerTorso);
			var glove = from.FindItemOnLayer(Layer.Gloves);
			var arms = from.FindItemOnLayer(Layer.Arms);

			if (shirt != null && shirt.GetType() == typeof(AcolyteChest) && glove != null && glove.GetType() == typeof(AcolyteGloves) && arms != null && arms.GetType() == typeof(AcolyteArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x2;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 3;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 3;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as AcolyteChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as AcolyteGloves;
				var arm = from.FindItemOnLayer(Layer.Arms) as AcolyteArms;

				chest.Hue = 0x2;
				chest.Attributes.Luck = 100; ;
				chest.Attributes.NightSight = 1; ;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 3;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 3;

				gloves.Hue = 0x2;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 3;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 3;

				arm.Hue = 0x2;
				arm.ArmorAttributes.SelfRepair = 3;
				arm.PhysicalBonus = 3;
				arm.FireBonus = 3;
				arm.ColdBonus = 3;
				arm.PoisonBonus = 3;
				arm.EnergyBonus = 3;


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
				if (m.FindItemOnLayer(Layer.InnerTorso) is AcolyteChest && m.FindItemOnLayer(Layer.Gloves) is AcolyteGloves && m.FindItemOnLayer(Layer.Arms) is AcolyteArms)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as AcolyteChest;
					chest.Hue = 0x0;
					chest.Attributes.Luck = 0;
					chest.Attributes.NightSight = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as AcolyteGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as AcolyteArms;
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

		public AcolyteLegs(Serial serial) : base(serial)
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