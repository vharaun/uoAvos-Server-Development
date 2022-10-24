using Server.ContextMenus;
using Server.Gumps;
using Server.Items;

using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName("a pack rat corpse")]
	public class PackRatFamiliar : BaseFamiliar
	{
		private DateTime m_NextPickup;

		public PackRatFamiliar()
		{
			Name = "a pack rat";
			Body = 0xD7;
			BaseSoundID = 0x188;

			SetStr(32, 74);
			SetDex(46, 65);
			SetInt(16, 30);

			SetHits(26, 39);
			SetMana(0);

			SetDamage(4, 8);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 15, 20);
			SetResistance(ResistanceType.Fire, 5, 10);
			SetResistance(ResistanceType.Poison, 25, 35);

			SetSkill(SkillName.MagicResist, 25.1, 30.0);
			SetSkill(SkillName.Tactics, 29.3, 44.0);
			SetSkill(SkillName.Wrestling, 29.3, 44.0);

			Fame = 300;
			Karma = -300;

			VirtualArmor = 18;

			ControlSlots = 1;

			Backpack?.Delete();

			AddItem(new StrongBackpack
			{
				Movable = false
			});
		}

		public PackRatFamiliar(Serial serial)
			: base(serial)
		{
		}

		public override void OnThink()
		{
			base.OnThink();

			if (DateTime.UtcNow < m_NextPickup)
			{
				return;
			}

			m_NextPickup = DateTime.UtcNow.AddSeconds(Utility.RandomMinMax(5, 10));

			var pack = Backpack;

			if (pack == null)
			{
				return;
			}

			var pickedUp = 0;

			var eable = GetItemsInRange(2);

			foreach (var item in eable)
			{
				if (!item.Movable || !item.Stackable)
				{
					continue;
				}

				if (!pack.CheckHold(this, item, false, true))
				{
					return;
				}

				NextActionTime = Core.TickCount;

				if (!Lift(item, item.Amount))
				{
					continue;
				}

				_ = Drop(this, Point3D.Zero);

				if (++pickedUp == 3)
				{
					break;
				}
			}

			eable.Free();
		}

		private void ConfirmRelease(Mobile from, bool okay, object state)
		{
			if (okay)
			{
				EndRelease(from);
			}
		}

		public override void BeginRelease(Mobile from)
		{
			var pack = Backpack;

			if (pack != null && pack.Items.Count > 0)
			{
				_ = from.SendGump(new WarningGump(1060635, 30720, 1061672, 32512, 420, 280, ConfirmRelease, null));
			}
			else
			{
				EndRelease(from);
			}
		}

		#region Pack Animal Methods

		public override bool OnBeforeDeath()
		{
			if (!base.OnBeforeDeath())
			{
				return false;
			}

			PackAnimal.CombineBackpacks(this);

			return true;
		}

		public override DeathMoveResult GetInventoryMoveResultFor(Item item)
		{
			return DeathMoveResult.MoveToCorpse;
		}

		public override bool IsSnoop(Mobile from)
		{
			if (PackAnimal.CheckAccess(this, from))
			{
				return false;
			}

			return base.IsSnoop(from);
		}

		public override bool OnDragDrop(Mobile from, Item item)
		{
			if (CheckFeed(from, item))
			{
				return true;
			}

			if (PackAnimal.CheckAccess(this, from))
			{
				_ = AddToBackpack(item);
				return true;
			}

			return base.OnDragDrop(from, item);
		}

		public override bool CheckNonlocalDrop(Mobile from, Item item, Item target)
		{
			return PackAnimal.CheckAccess(this, from);
		}

		public override bool CheckNonlocalLift(Mobile from, Item item)
		{
			return PackAnimal.CheckAccess(this, from);
		}

		public override void OnDoubleClick(Mobile from)
		{
			PackAnimal.TryPackOpen(this, from);
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			PackAnimal.GetContextMenuEntries(this, from, list);
		}

		#endregion

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadInt();
		}
	}
}
