using Server.Items;

using System;

namespace Server.Mobiles
{
	public class ArcherGuard : BaseTownGuard
	{
		[Constructable]
		public ArcherGuard() 
			: base(AIType.AI_Archer, FightMode.Weakest, 18, 1, 0.1, 0.2)
		{
			InitStats(100, 125, 25);

			Skills[SkillName.Anatomy].Base = 120.0;
			Skills[SkillName.Tactics].Base = 120.0;
			Skills[SkillName.Archery].Base = 120.0;
			Skills[SkillName.MagicResist].Base = 120.0;
			Skills[SkillName.DetectHidden].Base = 100.0;

			NextCombatTime = Core.TickCount + 500;

			new Horse().Rider = this;

			AddItem(new StuddedChest());
			AddItem(new StuddedArms());
			AddItem(new StuddedGloves());
			AddItem(new StuddedGorget());
			AddItem(new StuddedLegs());
			AddItem(new Boots());
			AddItem(new SkullCap());

			AddItem(new Bow 
			{
				Movable = false,
				Crafter = this,
				Quality = WeaponQuality.Exceptional
			});

			var pack = new Backpack 
			{
				Movable = false
			};

			pack.DropItem(new Arrow(250) 
			{
				LootType = LootType.Newbied
			});

			pack.DropItem(new Gold(10, 25));

			AddItem(pack);
		}

		public ArcherGuard(Serial serial) 
			: base(serial)
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