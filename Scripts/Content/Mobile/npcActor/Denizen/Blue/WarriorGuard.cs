using Server.Items;

using System;

namespace Server.Mobiles
{
	public class WarriorGuard : BaseTownGuard
	{
		[Constructable]
		public WarriorGuard()
			: base(AIType.AI_Melee, FightMode.Weakest, 18, 1, 0.1, 0.2)
		{
			InitStats(1000, 1000, 1000);

			Skills[SkillName.Anatomy].Base = 120.0;
			Skills[SkillName.Tactics].Base = 120.0;
			Skills[SkillName.Swords].Base = 120.0;
			Skills[SkillName.MagicResist].Base = 120.0;
			Skills[SkillName.DetectHidden].Base = 100.0;

			NextCombatTime = Core.TickCount + 500;

			if (Female)
			{
				switch (Utility.Random(2))
				{
					case 0: AddItem(new LeatherSkirt()); break;
					case 1: AddItem(new LeatherShorts()); break;
				}

				switch (Utility.Random(5))
				{
					case 0: AddItem(new FemaleLeatherChest()); break;
					case 1: AddItem(new FemaleStuddedChest()); break;
					case 2: AddItem(new LeatherBustierArms()); break;
					case 3: AddItem(new StuddedBustierArms()); break;
					case 4: AddItem(new FemalePlateChest()); break;
				}
			}
			else
			{
				AddItem(new PlateChest());
				AddItem(new PlateArms());
				AddItem(new PlateLegs());

				switch (Utility.Random(3))
				{
					case 0: AddItem(new Doublet(Utility.RandomNondyedHue())); break;
					case 1: AddItem(new Tunic(Utility.RandomNondyedHue())); break;
					case 2: AddItem(new BodySash(Utility.RandomNondyedHue())); break;
				}
			}

			AddItem(new Halberd
			{
				Movable = false,
				Crafter = this,
				Quality = WeaponQuality.Exceptional
			});

			var pack = new Backpack 
			{
				Movable = false
			};

			pack.DropItem(new Gold(10, 25));

			AddItem(pack);
		}

		public WarriorGuard(Serial serial) 
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