namespace Server.Items
{
	/// MyrmidonHelm
	[FlipableAttribute(0x140C, 0x140D)]
	public class MyrmidonHelm : BaseArmor
	{
		public override int LabelNumber => 1074306;
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 7;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 35;
		public override int OldStrReq => 35;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public MyrmidonHelm() : base(0x140C)
		{
			Weight = 5.0;
			Attributes.BonusStr = 1;
			Attributes.BonusHits = 2;
		}

		public MyrmidonHelm(Serial serial) : base(serial)
		{
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x2CA)
				{
					list.Add(1072377);
					list.Add(1073489, "500");
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
				list.Add(1073489, "500");
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

			if (shirt != null && shirt.GetType() == typeof(MyrmidonChest) && glove != null && glove.GetType() == typeof(MyrmidonGloves) && pants != null && pants.GetType() == typeof(MyrmidonLegs) && neck != null && neck.GetType() == typeof(MyrmidonGorget) && arms != null && arms.GetType() == typeof(MyrmidonArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x2CA;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 3;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 3;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as MyrmidonChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as MyrmidonGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as MyrmidonLegs;
				var gorget = from.FindItemOnLayer(Layer.Neck) as MyrmidonGorget;
				var arm = from.FindItemOnLayer(Layer.Arms) as MyrmidonArms;

				chest.Hue = 0x2CA;
				chest.Attributes.NightSight = 1;
				chest.Attributes.Luck = 500;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 3;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 3;

				gloves.Hue = 0x2CA;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 3;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 3;

				legs.Hue = 0x2CA;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 3;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 3;

				gorget.Hue = 0x2CA;
				gorget.ArmorAttributes.SelfRepair = 3;
				gorget.PhysicalBonus = 3;
				gorget.FireBonus = 3;
				gorget.ColdBonus = 3;
				gorget.PoisonBonus = 3;
				gorget.EnergyBonus = 3;

				arm.Hue = 0x2CA;
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
				if (m.FindItemOnLayer(Layer.InnerTorso) is MyrmidonChest && m.FindItemOnLayer(Layer.Gloves) is MyrmidonGloves && m.FindItemOnLayer(Layer.Arms) is MyrmidonArms && m.FindItemOnLayer(Layer.Pants) is MyrmidonLegs && m.FindItemOnLayer(Layer.Neck) is MyrmidonGorget)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as MyrmidonChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.Luck = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as MyrmidonGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as MyrmidonArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as MyrmidonLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var gorget = m.FindItemOnLayer(Layer.Neck) as MyrmidonGorget;
					gorget.Hue = 0x0;
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

	/// MyrmidonGorget
	public class MyrmidonGorget : BaseArmor
	{
		public override int LabelNumber => 1074306;
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 7;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 35;
		public override int OldStrReq => 35;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public MyrmidonGorget() : base(0x13D6)
		{
			Weight = 2.0;
			Attributes.BonusStr = 1;
			Attributes.BonusHits = 2;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x2CA)
				{
					list.Add(1072377);
					list.Add(1073489, "500");
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
				list.Add(1073489, "500");
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

			if (shirt != null && shirt.GetType() == typeof(MyrmidonChest) && glove != null && glove.GetType() == typeof(MyrmidonGloves) && pants != null && pants.GetType() == typeof(MyrmidonLegs) && helm != null && helm.GetType() == typeof(MyrmidonHelm) && arms != null && arms.GetType() == typeof(MyrmidonArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x2CA;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 3;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 3;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as MyrmidonChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as MyrmidonGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as MyrmidonLegs;
				var helmet = from.FindItemOnLayer(Layer.Helm) as MyrmidonHelm;
				var arm = from.FindItemOnLayer(Layer.Arms) as MyrmidonArms;

				chest.Hue = 0x2CA;
				chest.Attributes.NightSight = 1;
				chest.Attributes.Luck = 500;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 3;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 3;

				gloves.Hue = 0x2CA;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 3;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 3;

				legs.Hue = 0x2CA;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 3;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 3;

				helmet.Hue = 0x2CA;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 3;
				helmet.FireBonus = 3;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 3;

				arm.Hue = 0x2CA;
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
				if (m.FindItemOnLayer(Layer.InnerTorso) is MyrmidonChest && m.FindItemOnLayer(Layer.Gloves) is MyrmidonGloves && m.FindItemOnLayer(Layer.Arms) is MyrmidonArms && m.FindItemOnLayer(Layer.Pants) is MyrmidonLegs && m.FindItemOnLayer(Layer.Helm) is MyrmidonHelm)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as MyrmidonChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.Luck = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as MyrmidonGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as MyrmidonArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as MyrmidonLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as MyrmidonHelm;
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

		public MyrmidonGorget(Serial serial) : base(serial)
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

	/// MyrmidonChest
	[FlipableAttribute(0x13DB, 0x13E2)]
	public class MyrmidonChest : BaseArmor
	{
		public override int LabelNumber => 1074306;
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 7;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 35;
		public override int OldStrReq => 35;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public MyrmidonChest() : base(0x13DB)
		{
			Weight = 10.0;
			Attributes.BonusStr = 1;
			Attributes.BonusHits = 2;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x2CA)
				{
					list.Add(1072377);
					list.Add(1073489, "500");
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
				list.Add(1073489, "500");
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

			if (glove != null && glove.GetType() == typeof(MyrmidonGloves) && pants != null && pants.GetType() == typeof(MyrmidonLegs) && neck != null && neck.GetType() == typeof(MyrmidonGorget) && helm != null && helm.GetType() == typeof(MyrmidonHelm) && arms != null && arms.GetType() == typeof(MyrmidonArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x2CA;
				ArmorAttributes.SelfRepair = 3;
				Attributes.NightSight = 1;
				Attributes.Luck = 500;
				PhysicalBonus = 3;
				FireBonus = 3;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 3;


				var gloves = from.FindItemOnLayer(Layer.Gloves) as MyrmidonGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as MyrmidonLegs;
				var gorget = from.FindItemOnLayer(Layer.Neck) as MyrmidonGorget;
				var helmet = from.FindItemOnLayer(Layer.Helm) as MyrmidonHelm;
				var arm = from.FindItemOnLayer(Layer.Arms) as MyrmidonArms;

				gloves.Hue = 0x2CA;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 3;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 3;

				legs.Hue = 0x2CA;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 3;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 3;

				gorget.Hue = 0x2CA;
				gorget.ArmorAttributes.SelfRepair = 3;
				gorget.PhysicalBonus = 3;
				gorget.FireBonus = 3;
				gorget.ColdBonus = 3;
				gorget.PoisonBonus = 3;
				gorget.EnergyBonus = 3;

				helmet.Hue = 0x2CA;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 3;
				helmet.FireBonus = 3;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 3;

				arm.Hue = 0x2CA;
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
				Attributes.NightSight = 0;
				ArmorAttributes.SelfRepair = 0;
				Attributes.Luck = 0;
				PhysicalBonus = 0;
				FireBonus = 0;
				ColdBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;

				if (m.FindItemOnLayer(Layer.Gloves) is MyrmidonGloves && m.FindItemOnLayer(Layer.Pants) is MyrmidonLegs && m.FindItemOnLayer(Layer.Arms) is MyrmidonArms && m.FindItemOnLayer(Layer.Neck) is MyrmidonGorget && m.FindItemOnLayer(Layer.Helm) is MyrmidonHelm)
				{
					var gloves = m.FindItemOnLayer(Layer.Gloves) as MyrmidonGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as MyrmidonLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as MyrmidonArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var gorget = m.FindItemOnLayer(Layer.Neck) as MyrmidonGorget;
					gorget.Hue = 0x0;
					gorget.ArmorAttributes.SelfRepair = 0;
					gorget.PhysicalBonus = 0;
					gorget.FireBonus = 0;
					gorget.ColdBonus = 0;
					gorget.PoisonBonus = 0;
					gorget.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as MyrmidonHelm;
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

		public MyrmidonChest(Serial serial) : base(serial)
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

	/// MyrmidonArms
	[FlipableAttribute(0x13D4, 0x13DC)]
	public class MyrmidonArms : BaseArmor
	{
		public override int LabelNumber => 1074306;
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 7;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 35;
		public override int OldStrReq => 35;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public MyrmidonArms() : base(0x13D4)
		{
			Weight = 5.0;
			Attributes.BonusStr = 1;
			Attributes.BonusHits = 2;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x2CA)
				{
					list.Add(1072377);
					list.Add(1073489, "500");
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
				list.Add(1073489, "500");
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

			if (shirt != null && shirt.GetType() == typeof(MyrmidonChest) && glove != null && glove.GetType() == typeof(MyrmidonGloves) && pants != null && pants.GetType() == typeof(MyrmidonLegs) && helm != null && helm.GetType() == typeof(MyrmidonHelm) && neck != null && neck.GetType() == typeof(MyrmidonGorget))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x2CA;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 3;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 3;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as MyrmidonChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as MyrmidonGloves;
				var legs = from.FindItemOnLayer(Layer.Pants) as MyrmidonLegs;
				var helmet = from.FindItemOnLayer(Layer.Helm) as MyrmidonHelm;
				var gorget = from.FindItemOnLayer(Layer.Neck) as MyrmidonGorget;

				chest.Hue = 0x2CA;
				chest.Attributes.NightSight = 1;
				chest.Attributes.Luck = 500;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 3;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 3;

				gloves.Hue = 0x2CA;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 3;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 3;

				legs.Hue = 0x2CA;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 3;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 3;

				helmet.Hue = 0x2CA;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 3;
				helmet.FireBonus = 3;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 3;

				gorget.Hue = 0x2CA;
				gorget.ArmorAttributes.SelfRepair = 3;
				gorget.PhysicalBonus = 3;
				gorget.FireBonus = 3;
				gorget.ColdBonus = 3;
				gorget.PoisonBonus = 3;
				gorget.EnergyBonus = 3;

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
				if (m.FindItemOnLayer(Layer.InnerTorso) is MyrmidonChest && m.FindItemOnLayer(Layer.Gloves) is MyrmidonGloves && m.FindItemOnLayer(Layer.Neck) is MyrmidonGorget && m.FindItemOnLayer(Layer.Pants) is MyrmidonLegs && m.FindItemOnLayer(Layer.Helm) is MyrmidonHelm)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as MyrmidonChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.Luck = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as MyrmidonGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var gorget = m.FindItemOnLayer(Layer.Neck) as MyrmidonGorget;
					gorget.Hue = 0x0;
					gorget.ArmorAttributes.SelfRepair = 0;
					gorget.PhysicalBonus = 0;
					gorget.FireBonus = 0;
					gorget.ColdBonus = 0;
					gorget.PoisonBonus = 0;
					gorget.EnergyBonus = 0;

					var legs = m.FindItemOnLayer(Layer.Pants) as MyrmidonLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as MyrmidonHelm;
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


		public MyrmidonArms(Serial serial) : base(serial)
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

	/// MyrmidonGloves
	[FlipableAttribute(0x13D5, 0x13DD)]
	public class MyrmidonGloves : BaseArmor
	{
		public override int LabelNumber => 1074306;
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 7;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 35;
		public override int OldStrReq => 35;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public MyrmidonGloves() : base(0x13D5)
		{
			Weight = 2.0;
			Attributes.BonusStr = 1;
			Attributes.BonusHits = 2;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x2CA)
				{
					list.Add(1072377);
					list.Add(1073489, "500");
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
				list.Add(1073489, "500");
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

			if (shirt != null && shirt.GetType() == typeof(MyrmidonChest) && pants != null && pants.GetType() == typeof(MyrmidonLegs) && neck != null && neck.GetType() == typeof(MyrmidonGorget) && helm != null && helm.GetType() == typeof(MyrmidonHelm) && arms != null && arms.GetType() == typeof(MyrmidonArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x2CA;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 3;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 3;

				var chest = from.FindItemOnLayer(Layer.InnerTorso) as MyrmidonChest;
				var legs = from.FindItemOnLayer(Layer.Pants) as MyrmidonLegs;
				var gorget = from.FindItemOnLayer(Layer.Neck) as MyrmidonGorget;
				var helmet = from.FindItemOnLayer(Layer.Helm) as MyrmidonHelm;
				var arm = from.FindItemOnLayer(Layer.Arms) as MyrmidonArms;

				chest.Hue = 0x2CA;
				chest.Attributes.NightSight = 1;
				chest.Attributes.Luck = 500;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 3;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 3;

				legs.Hue = 0x2CA;
				legs.ArmorAttributes.SelfRepair = 3;
				legs.PhysicalBonus = 3;
				legs.FireBonus = 3;
				legs.ColdBonus = 3;
				legs.PoisonBonus = 3;
				legs.EnergyBonus = 3;

				gorget.Hue = 0x2CA;
				gorget.ArmorAttributes.SelfRepair = 3;
				gorget.PhysicalBonus = 3;
				gorget.FireBonus = 3;
				gorget.ColdBonus = 3;
				gorget.PoisonBonus = 3;
				gorget.EnergyBonus = 3;

				helmet.Hue = 0x2CA;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 3;
				helmet.FireBonus = 3;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 3;

				arm.Hue = 0x2CA;
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
				if (m.FindItemOnLayer(Layer.InnerTorso) is MyrmidonChest && m.FindItemOnLayer(Layer.Pants) is MyrmidonLegs && m.FindItemOnLayer(Layer.Arms) is MyrmidonArms && m.FindItemOnLayer(Layer.Neck) is MyrmidonGorget && m.FindItemOnLayer(Layer.Helm) is MyrmidonHelm)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as MyrmidonChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.Luck = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;


					var legs = m.FindItemOnLayer(Layer.Pants) as MyrmidonLegs;
					legs.Hue = 0x0;
					legs.ArmorAttributes.SelfRepair = 0;
					legs.PhysicalBonus = 0;
					legs.FireBonus = 0;
					legs.ColdBonus = 0;
					legs.PoisonBonus = 0;
					legs.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as MyrmidonArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var gorget = m.FindItemOnLayer(Layer.Neck) as MyrmidonGorget;
					gorget.Hue = 0x0;
					gorget.ArmorAttributes.SelfRepair = 0;
					gorget.PhysicalBonus = 0;
					gorget.FireBonus = 0;
					gorget.ColdBonus = 0;
					gorget.PoisonBonus = 0;
					gorget.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as MyrmidonHelm;
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

		public MyrmidonGloves(Serial serial) : base(serial)
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

	/// MyrmidonLegs
	[FlipableAttribute(0x13DA, 0x13E1)]
	public class MyrmidonLegs : BaseArmor
	{
		public override int LabelNumber => 1074306;
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 7;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 35;
		public override int OldStrReq => 35;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public MyrmidonLegs() : base(0x13DA)
		{
			Weight = 7.0;
			Attributes.BonusStr = 1;
			Attributes.BonusHits = 2;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1072376, "6");

			if (Parent is Mobile)
			{
				if (Hue == 0x2CA)
				{
					list.Add(1072377);
					list.Add(1073489, "500");
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
				list.Add(1073489, "500");
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

			if (shirt != null && shirt.GetType() == typeof(MyrmidonChest) && glove != null && glove.GetType() == typeof(MyrmidonGloves) && neck != null && neck.GetType() == typeof(MyrmidonGorget) && helm != null && helm.GetType() == typeof(MyrmidonHelm) && arms != null && arms.GetType() == typeof(MyrmidonArms))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x2CA;
				ArmorAttributes.SelfRepair = 3;
				PhysicalBonus = 3;
				FireBonus = 3;
				ColdBonus = 3;
				PoisonBonus = 3;
				EnergyBonus = 3;


				var chest = from.FindItemOnLayer(Layer.InnerTorso) as MyrmidonChest;
				var gloves = from.FindItemOnLayer(Layer.Gloves) as MyrmidonGloves;
				var gorget = from.FindItemOnLayer(Layer.Neck) as MyrmidonGorget;
				var helmet = from.FindItemOnLayer(Layer.Helm) as MyrmidonHelm;
				var arm = from.FindItemOnLayer(Layer.Arms) as MyrmidonArms;

				chest.Hue = 0x2CA;
				chest.Attributes.NightSight = 1;
				chest.Attributes.Luck = 500;
				chest.ArmorAttributes.SelfRepair = 3;
				chest.PhysicalBonus = 3;
				chest.FireBonus = 3;
				chest.ColdBonus = 3;
				chest.PoisonBonus = 3;
				chest.EnergyBonus = 3;

				gloves.Hue = 0x2CA;
				gloves.ArmorAttributes.SelfRepair = 3;
				gloves.PhysicalBonus = 3;
				gloves.FireBonus = 3;
				gloves.ColdBonus = 3;
				gloves.PoisonBonus = 3;
				gloves.EnergyBonus = 3;

				gorget.Hue = 0x2CA;
				gorget.ArmorAttributes.SelfRepair = 3;
				gorget.PhysicalBonus = 3;
				gorget.FireBonus = 3;
				gorget.ColdBonus = 3;
				gorget.PoisonBonus = 3;
				gorget.EnergyBonus = 3;

				helmet.Hue = 0x2CA;
				helmet.ArmorAttributes.SelfRepair = 3;
				helmet.PhysicalBonus = 3;
				helmet.FireBonus = 3;
				helmet.ColdBonus = 3;
				helmet.PoisonBonus = 3;
				helmet.EnergyBonus = 3;

				arm.Hue = 0x2CA;
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
				if (m.FindItemOnLayer(Layer.InnerTorso) is MyrmidonChest && m.FindItemOnLayer(Layer.Gloves) is MyrmidonGloves && m.FindItemOnLayer(Layer.Arms) is MyrmidonArms && m.FindItemOnLayer(Layer.Neck) is MyrmidonGorget && m.FindItemOnLayer(Layer.Helm) is MyrmidonHelm)
				{
					var chest = m.FindItemOnLayer(Layer.InnerTorso) as MyrmidonChest;
					chest.Hue = 0x0;
					chest.Attributes.NightSight = 0;
					chest.Attributes.Luck = 0;
					chest.ArmorAttributes.SelfRepair = 0;
					chest.PhysicalBonus = 0;
					chest.FireBonus = 0;
					chest.ColdBonus = 0;
					chest.PoisonBonus = 0;
					chest.EnergyBonus = 0;

					var gloves = m.FindItemOnLayer(Layer.Gloves) as MyrmidonGloves;
					gloves.Hue = 0x0;
					gloves.ArmorAttributes.SelfRepair = 0;
					gloves.PhysicalBonus = 0;
					gloves.FireBonus = 0;
					gloves.ColdBonus = 0;
					gloves.PoisonBonus = 0;
					gloves.EnergyBonus = 0;

					var arm = m.FindItemOnLayer(Layer.Arms) as MyrmidonArms;
					arm.Hue = 0x0;
					arm.ArmorAttributes.SelfRepair = 0;
					arm.PhysicalBonus = 0;
					arm.FireBonus = 0;
					arm.ColdBonus = 0;
					arm.PoisonBonus = 0;
					arm.EnergyBonus = 0;

					var gorget = m.FindItemOnLayer(Layer.Neck) as MyrmidonGorget;
					gorget.Hue = 0x0;
					gorget.ArmorAttributes.SelfRepair = 0;
					gorget.PhysicalBonus = 0;
					gorget.FireBonus = 0;
					gorget.ColdBonus = 0;
					gorget.PoisonBonus = 0;
					gorget.EnergyBonus = 0;

					var helmet = m.FindItemOnLayer(Layer.Helm) as MyrmidonHelm;
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

		public MyrmidonLegs(Serial serial) : base(serial)
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