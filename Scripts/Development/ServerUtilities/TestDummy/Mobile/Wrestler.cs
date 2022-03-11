using Server.Items;

namespace Server.Mobiles
{
	public class DummyStun : Dummy
	{

		[Constructable]
		public DummyStun() : base(AIType.AI_Mage, FightMode.Closest, 15, 1, 0.2, 0.6)
		{

			// A Dummy Stun Mage
			var iHue = 20 + Team * 40;
			var jHue = 25 + Team * 40;

			// Skills and Stats
			InitStats(90, 90, 125);
			Skills[SkillName.Magery].Base = 100;
			Skills[SkillName.EvalInt].Base = 120;
			Skills[SkillName.Anatomy].Base = 80;
			Skills[SkillName.Wrestling].Base = 80;
			Skills[SkillName.Meditation].Base = 100;
			Skills[SkillName.Poisoning].Base = 100;


			// Name
			Name = "Stun Mage";

			// Equip
			var book = new Spellbook {
				Movable = false,
				LootType = LootType.Newbied,
				Content = 0xFFFFFFFFFFFFFFFF
			};
			AddItem(book);

			var lea = new LeatherArms {
				Movable = false,
				LootType = LootType.Newbied,
				Crafter = this,
				Quality = ArmorQuality.Regular
			};
			AddItem(lea);

			var lec = new LeatherChest {
				Movable = false,
				LootType = LootType.Newbied,
				Crafter = this,
				Quality = ArmorQuality.Regular
			};
			AddItem(lec);

			var leg = new LeatherGorget {
				Movable = false,
				LootType = LootType.Newbied,
				Crafter = this,
				Quality = ArmorQuality.Regular
			};
			AddItem(leg);

			var lel = new LeatherLegs {
				Movable = false,
				LootType = LootType.Newbied,
				Crafter = this,
				Quality = ArmorQuality.Regular
			};
			AddItem(lel);

			var bts = new Boots {
				Hue = iHue
			};
			AddItem(bts);

			var cap = new Cap {
				Hue = iHue
			};
			AddItem(cap);

			// Spells
			AddSpellAttack(typeof(Spells.First.MagicArrowSpell));
			AddSpellAttack(typeof(Spells.First.WeakenSpell));
			AddSpellAttack(typeof(Spells.Third.FireballSpell));
			AddSpellDefense(typeof(Spells.Third.WallOfStoneSpell));
			AddSpellDefense(typeof(Spells.First.HealSpell));
		}

		public DummyStun(Serial serial) : base(serial)
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