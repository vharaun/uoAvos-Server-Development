using Server.ContextMenus;
using Server.Gumps;
using Server.Items;

using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName("a skittering hopper corpse")]
	public class SkitteringHopperFamiliar : BaseFamiliar
	{
		private DateTime m_NextPickup;

		[Constructable]
		public SkitteringHopperFamiliar()
		{
			Name = "a skittering hopper";
			Body = 302;
			BaseSoundID = 959;

			SetStr(41, 65);
			SetDex(91, 115);
			SetInt(26, 50);

			SetHits(31, 45);

			SetDamage(3, 5);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 5, 10);
			SetResistance(ResistanceType.Cold, 10, 20);
			SetResistance(ResistanceType.Energy, 5, 10);

			SetSkill(SkillName.MagicResist, 30.1, 45.0);
			SetSkill(SkillName.Tactics, 45.1, 70.0);
			SetSkill(SkillName.Wrestling, 40.1, 60.0);

			Fame = 300;
			Karma = 0;

			ControlSlots = 1;

			var pack = Backpack;

			if (pack != null)
			{
				pack.Delete();
			}

			pack = new StrongBackpack
			{
				Movable = false
			};

			AddItem(pack);
		}

		public SkitteringHopperFamiliar(Serial serial)
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

			m_NextPickup = DateTime.UtcNow.AddSeconds(Utility.RandomMinMax(5.0, 10.0));

			var pack = Backpack;

			if (pack == null)
			{
				return;
			}

			var pickedUp = 0;

			foreach (var item in GetItemsInRange(2))
			{
				if (item.Movable && item.Stackable)
				{
					if (!pack.CheckHold(this, item, false, true))
					{
						continue;
					}

					NextActionTime = Core.TickCount;

					if (!Lift(item, item.Amount))
					{
						continue;
					}

					_ = Drop(this, Point3D.Zero);

					if (++pickedUp >= 3)
					{
						break;
					}
				}
			}
		}

		private void ConfirmRelease_Callback(Mobile from, bool okay, object state)
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
				_ = from.SendGump(new WarningGump(1060635, 30720, 1061672, 32512, 420, 280, ConfirmRelease_Callback, null));
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
