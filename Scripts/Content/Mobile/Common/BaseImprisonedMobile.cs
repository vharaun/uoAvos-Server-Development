using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
	public abstract class BaseImprisonedMobile : Item
	{
		public abstract BaseCreature Summon { get; }

		[Constructable]
		public BaseImprisonedMobile(int itemID) : base(itemID)
		{
		}

		public BaseImprisonedMobile(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsChildOf(from.Backpack))
			{
				if (from is PlayerMobile player)
				{
					BaseGump.SendGump(new ConfirmBreakCrystalGump(player, this));
				}
			}
			else
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
			}
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

		public virtual void Release(Mobile from, BaseCreature summon)
		{
		}
	}

	public class ConfirmBreakCrystalGump : BaseConfirmGump
	{
		private readonly BaseImprisonedMobile m_Item;

		// This statuette will be destroyed when its trapped creature is summoned. The creature will be bonded to you but will disappear if released. <br><br>Do you wish to proceed?
		public ConfirmBreakCrystalGump(PlayerMobile user, BaseImprisonedMobile item) : base(user, 1075084)
		{
			m_Item = item;
		}

		public override void Confirm()
		{
			if (m_Item == null || m_Item.Deleted)
			{
				return;
			}

			var summon = m_Item.Summon;

			if (summon != null)
			{
				if (!summon.SetControlMaster(User))
				{
					summon.Delete();
				}
				else
				{
					User.SendLocalizedMessage(1049666); // Your pet has bonded with you!

					summon.MoveToWorld(User.Location, User.Map);
					summon.IsBonded = true;

					summon.Skills.Wrestling.Base = 100;
					summon.Skills.Tactics.Base = 100;
					summon.Skills.MagicResist.Base = 100;
					summon.Skills.Anatomy.Base = 100;

					Effects.PlaySound(summon.Location, summon.Map, summon.BaseSoundID);
					Effects.SendLocationParticles(EffectItem.Create(summon.Location, summon.Map, EffectItem.DefaultDuration), 0x3728, 1, 10, 0x26B6);

					m_Item.Release(User, summon);
					m_Item.Delete();
				}
			}
		}
	}
}