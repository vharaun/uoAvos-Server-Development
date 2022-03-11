namespace Server.Items
{
	/// EvocaricusSword
	[FlipableAttribute(0x13B9, 0x13Ba)]
	public class EvocaricusSword : BaseSword
	{
		public override int LabelNumber => 1074309;
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;

		public override int AosStrengthReq => 40;
		public override int AosMinDamage => 15;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 28;

		public override int OldStrengthReq => 40;
		public override int OldMinDamage => 6;
		public override int OldMaxDamage => 34;
		public override int OldSpeed => 30;

		public override int DefHitSound => 0x237;
		public override int DefMissSound => 0x23A;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public EvocaricusSword() : base(0x13B9)
		{
			Weight = 6.0;
			Attributes.WeaponDamage = 50;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1073491, "2");

			if (Parent is Mobile)
			{
				if (Hue == 0x388)
				{
					list.Add(1073492);
					list.Add(1072514, "10");
					list.Add(1073493, "10");
					list.Add(1074323, "35");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1060450, "3");
				list.Add(1073493, "10");
				list.Add(1073493, "10");
				list.Add(1074323, "35");
			}
		}

		public override bool OnEquip(Mobile from)
		{
			var item = from.FindItemOnLayer(Layer.TwoHanded);

			if (item != null && item.GetType() == typeof(MalekisHonor))
			{

				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x388;
				WeaponAttributes.SelfRepair = 3;
				Attributes.WeaponSpeed = 35;
				var shield = from.FindItemOnLayer(Layer.TwoHanded) as MalekisHonor;
				shield.Hue = 0x388;
				shield.Attributes.BonusStr = 10;
				shield.Attributes.DefendChance = 10;
				shield.ArmorAttributes.SelfRepair = 3;

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
				Attributes.WeaponSpeed = 0;
				WeaponAttributes.SelfRepair = 0;
				if (m.FindItemOnLayer(Layer.TwoHanded) is MalekisHonor)
				{
					var shield = m.FindItemOnLayer(Layer.TwoHanded) as MalekisHonor;
					shield.Hue = 0x0;
					shield.Attributes.BonusStr = 0;
					shield.Attributes.DefendChance = 0;
					shield.ArmorAttributes.SelfRepair = 0;
				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
		}

		public EvocaricusSword(Serial serial) : base(serial)
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

	/// MalekisHonor
	public class MalekisHonor : BaseShield
	{
		public override int LabelNumber => 1074312;
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 45;
		public override int InitMaxHits => 60;

		public override int AosStrReq => 45;

		public override int ArmorBase => 16;

		[Constructable]
		public MalekisHonor() : base(0x1B74)
		{
			Weight = 7.0;
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add(1073491, "2");

			if (Parent is Mobile)
			{
				if (Hue == 0x388)
				{
					list.Add(1073492);
					list.Add(1072514, "10");
					list.Add(1073493, "10");
					list.Add(1074323, "35");
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Hue == 0x0)
			{
				list.Add(1072378);
				list.Add(1060450, "3");
				list.Add(1073493, "10");
				list.Add(1073493, "10");
				list.Add(1074323, "35");
			}
		}

		public override bool OnEquip(Mobile from)
		{

			var item = from.FindItemOnLayer(Layer.OneHanded);

			if (item != null && item.GetType() == typeof(EvocaricusSword))
			{
				Effects.PlaySound(from.Location, from.Map, 503);
				from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);

				Hue = 0x388;
				Attributes.BonusStr = 10;
				Attributes.DefendChance = 10;
				ArmorAttributes.SelfRepair = 3;
				var sword = from.FindItemOnLayer(Layer.OneHanded) as EvocaricusSword;
				sword.Hue = 0x388;
				sword.Attributes.WeaponSpeed = 35;
				sword.WeaponAttributes.SelfRepair = 3;

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
				Attributes.DefendChance = 0;
				ArmorAttributes.SelfRepair = 0;
				if (m.FindItemOnLayer(Layer.OneHanded) is EvocaricusSword)
				{
					var sword = m.FindItemOnLayer(Layer.OneHanded) as EvocaricusSword;
					sword.Hue = 0x0;
					sword.Attributes.WeaponSpeed = 0;
					sword.WeaponAttributes.SelfRepair = 0;
				}
				InvalidateProperties();
			}
			base.OnRemoved(parent);
		}

		public MalekisHonor(Serial serial) : base(serial)
		{
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (Weight == 5.0)
			{
				Weight = 7.0;
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);//version
		}
	}
}