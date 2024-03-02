using Server.Engines.VeteranRewards;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

using System;

namespace Server.Items
{
	public interface IEngraved : IEntity
	{
		string EngravedText { get; set; }
	}

	public class EngravingTool : Item, IUsesRemaining, IRewardItem
    {
        public static EngravingTool Find(Mobile from)
        {
            return Find<EngravingTool>(from);
        }
        
		public static T Find<T>(Mobile from) where T : EngravingTool
		{
			return from?.Backpack?.FindItemByType<T>();
		}

		private bool m_IsRewardItem;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsRewardItem
		{
			get => m_IsRewardItem;
			set
			{
				m_IsRewardItem = value;

				InvalidateProperties();
			}
		}

		private int m_UsesRemaining;

		[CommandProperty(AccessLevel.GameMaster)]
		public int UsesRemaining
		{
			get => m_UsesRemaining;
			set
			{
				m_UsesRemaining = value;

				InvalidateProperties();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool ShowUsesRemaining { get; set; } = true;

		public override string DefaultName => "Engraving Tool";

		[Constructable]
		public EngravingTool()
			: this(10)
		{
		}

		[Constructable]
		public EngravingTool(int uses)
			: this(0x32F8, uses)
		{
		}

		[Constructable]
		public EngravingTool(int itemID, int uses)
			: base(itemID)
		{
			m_UsesRemaining = uses;

			Weight = 1.0;

			LootType = LootType.Blessed;
		}

		public EngravingTool(Serial serial)
			: base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
			{
				return;
			}

			if (UsesRemaining > 0)
			{
				from.SendLocalizedMessage(1072357); // Select an object to engrave.
				from.Target = new TargetItem(this);
				return;
			}

			from.SendLocalizedMessage(1076163); // There are no charges left on this engraving tool.

			if (from.Skills.Tinkering.Value == 0)
			{
				from.SendLocalizedMessage(1076179); // Since you have no tinkering skill, you will need to find an NPC tinkerer to repair this for you.
				return;
			}

			if (from.Skills.Tinkering.Value < 75.0)
			{
				from.SendLocalizedMessage(1076178); // Your tinkering skill is too low to fix this yourself.  An NPC tinkerer can help you repair this for a fee.
				return;
			}

			var diamond = from.Backpack.FindItemByType<BlueDiamond>();

			if (diamond == null)
			{
				from.SendLocalizedMessage(1076166); // You do not have a blue diamond needed to recharge the engraving tool.
				return;
			}

			from.SendGump(new RechargeGump(this, null));
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (IsRewardItem)
			{
				list.Add(1076224); // 8th Year Veteran Reward
			}

			if (ShowUsesRemaining)
			{
				list.Add(1060584, UsesRemaining.ToString()); // uses remaining: ~1_val~			
			}
		}

		public virtual void Recharge(Mobile from, Mobile guildmaster)
		{
			if (from.Backpack != null)
			{
				var diamond = from.Backpack.FindItemByType(typeof(BlueDiamond));

				if (guildmaster != null)
				{
					if (UsesRemaining <= 0)
					{
						if (diamond != null && Banker.Withdraw(from, 100000))
						{
							diamond.Consume();

							UsesRemaining += 10;

							guildmaster.Say("Your engraver should be good as new!");
						}
						else
						{
							guildmaster.Say("You need a 100,000 gold and a blue diamond to recharge the engraver.");
						}
					}
					else
					{
						guildmaster.Say(1076164); // I can only help with this if you are carrying an engraving tool that needs repair.
					}
				}
				else
				{
					if (from.Skills.Tinkering.Value == 0)
					{
						from.SendLocalizedMessage(1076179); // Since you have no tinkering skill, you will need to find an NPC tinkerer to repair this for you.					
					}
					else if (from.Skills.Tinkering.Value < 75.0)
					{
						from.SendLocalizedMessage(1076178); // Your tinkering skill is too low to fix this yourself.  An NPC tinkerer can help you repair this for a fee.
					}
					else if (diamond != null)
					{
						diamond.Consume();

						if (Utility.RandomDouble() < from.Skills.Tinkering.Value / 100.0)
						{
							UsesRemaining += 10;

							from.SendMessage("Your engraver should be good as new!");
						}
						else
						{
							from.SendMessage("You cracked the diamond attempting to fix the engraver.");
						}
					}
					else
					{
						from.SendLocalizedMessage(1076166); // You do not have a blue diamond needed to recharge the engraving tool.	
					}
				}
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_UsesRemaining);
			writer.Write(m_IsRewardItem);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadInt();

			m_UsesRemaining = reader.ReadInt();
			m_IsRewardItem = reader.ReadBool();
		}

		public class TargetItem : Target
		{
			private readonly EngravingTool m_Tool;

			public TargetItem(EngravingTool tool) 
				: base(-1, true, TargetFlags.None)
			{
				m_Tool = tool;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (m_Tool == null || m_Tool.Deleted)
				{
					return;
				}

				if (targeted is not IEngraved e)
				{
					from.SendLocalizedMessage(1072309); // The selected item cannot be engraved by this engraving tool.
					return;
				}

				from.CloseGump(typeof(EngraveGump));
				from.SendGump(new EngraveGump(m_Tool, e));
			}
		}

		public class EngraveGump : Gump
		{
			private readonly EngravingTool m_Tool;
			private readonly IEngraved m_Target;

			private enum Buttons
			{
				Cancel,
				Okay,
				Text
			}

			public EngraveGump(EngravingTool tool, IEngraved target)
				: base(0, 0)
			{
				m_Tool = tool;
				m_Target = target;

				Closable = true;
				Disposable = true;
				Dragable = true;
				Resizable = false;

				AddBackground(50, 50, 400, 300, 0xA28);

				AddPage(0);

				AddHtmlLocalized(50, 70, 400, 20, 1072359, 0x0, false, false); // <CENTER>Engraving Tool</CENTER>
				AddHtmlLocalized(75, 95, 350, 145, 1076229, 0x0, true, true); // Please enter the text to add to the selected object. Leave the text area blank to remove any existing text.  Removing text does not use a charge.

				AddButton(125, 300, 0x81A, 0x81B, (int)Buttons.Okay, GumpButtonType.Reply, 0);
				AddButton(320, 300, 0x819, 0x818, (int)Buttons.Cancel, GumpButtonType.Reply, 0);

				AddImageTiled(75, 245, 350, 40, 0xDB0);
				AddImageTiled(76, 245, 350, 2, 0x23C5);
				AddImageTiled(75, 245, 2, 40, 0x23C3);
				AddImageTiled(75, 285, 350, 2, 0x23C5);
				AddImageTiled(425, 245, 2, 42, 0x23C3);

				AddTextEntry(75, 245, 350, 40, 0x0, (int)Buttons.Text, "");
			}

			public override void OnResponse(NetState state, RelayInfo info)
			{
				if (m_Tool == null || m_Tool.Deleted || m_Target == null || m_Target.Deleted)
				{
					return;
				}

				if (info.ButtonID != (int)Buttons.Okay)
				{
					state.Mobile.SendLocalizedMessage(1072363); // The object was not engraved.
					return;
				}

				var relay = info.GetTextEntry((int)Buttons.Text);

				if (relay == null)
				{
					return;
				}

				if (String.IsNullOrEmpty(relay.Text))
				{
					m_Target.EngravedText = null;

					state.Mobile.SendLocalizedMessage(1072362); // You remove the engraving from the object.
					return;
				}

				if (relay.Text.Length > 64)
				{
					m_Target.EngravedText = Utility.FixHtml(relay.Text.Substring(0, 64));
				}
				else
				{
					m_Target.EngravedText = Utility.FixHtml(relay.Text);
				}

				--m_Tool.UsesRemaining;

				state.Mobile.SendLocalizedMessage(1072361); // You engraved the object.

				m_Target.InvalidateProperties();
			}
		}

		public class RechargeGump : Gump
		{
			private readonly EngravingTool m_Engraver;
			private readonly Mobile m_Guildmaster;

			private enum Buttons
			{
				Cancel,
				Confirm
			}

			public RechargeGump(EngravingTool engraver, Mobile guildmaster) 
				: base(200, 200)
			{
				m_Engraver = engraver;
				m_Guildmaster = guildmaster;

				Closable = false;
				Disposable = true;
				Dragable = true;
				Resizable = false;

				AddPage(0);

				AddBackground(0, 0, 291, 133, 0x13BE);
				AddImageTiled(5, 5, 280, 100, 0xA40);

				if (guildmaster != null)
				{
					AddHtml(9, 9, 272, 100, "<basefont color=#FFFFFF>It will cost you 100,000 gold and a blue diamond to recharge your engraver with 10 charges.", false, false);
					AddHtmlLocalized(195, 109, 120, 20, 1076172, 0x7FFF, false, false); // Recharge it
				}
				else
				{
					AddHtmlLocalized(9, 9, 272, 100, 1076176, 0x7FFF, false, false); // You will need a blue diamond to repair the tip of the engraver.  A successful repair will give the engraver 10 charges.
					AddHtmlLocalized(195, 109, 120, 20, 1076177, 0x7FFF, false, false); // Replace the tip.
				}

				AddButton(160, 107, 0xFB7, 0xFB8, (int)Buttons.Confirm, GumpButtonType.Reply, 0);
				AddButton(5, 107, 0xFB1, 0xFB2, (int)Buttons.Cancel, GumpButtonType.Reply, 0);
				AddHtmlLocalized(40, 109, 100, 20, 1060051, 0x7FFF, false, false); // CANCEL
			}

			public override void OnResponse(NetState state, RelayInfo info)
			{
				if (m_Engraver == null || m_Engraver.Deleted)
				{
					return;
				}

				if (info.ButtonID == (int)Buttons.Confirm)
				{
					m_Engraver.Recharge(state.Mobile, m_Guildmaster);
				}
			}
		}
	}
}