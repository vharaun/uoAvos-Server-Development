using Server.Gumps;
using Server.Items;
using Server.Network;

using System;

namespace Server.Spells.Mysticism
{
	public class SpellTriggerSpell : MysticismSpell
	{
		public static readonly SpellTriggerEntry[] Entries =
		{
			new(SpellName.NetherBolt, 1, 1031678, 1095193, 0x2D9E),
			new(SpellName.HealingStone, 1, 1031679, 1095194, 0x2D9F),
			new(SpellName.PurgeMagic, 2, 1031680, 1095195, 0x2DA0),
			new(SpellName.Enchant, 2, 1031681, 1095196, 0x2DA1),
			new(SpellName.Sleep, 3, 1031682, 1095197, 0x2DA2),
			new(SpellName.EagleStrike, 3, 1031683, 1095198, 0x2DA3),
			new(SpellName.AnimatedWeapon, 4, 1031684, 1095199, 0x2DA4),
			new(SpellName.StoneForm, 4, 1031685, 1095200, 0x2DA5),
			new(SpellName.MassSleep, 5, 1031687, 1095202, 0x2DA7),
			new(SpellName.CleansingWinds, 6, 1031688, 1095203, 0x2DA8),
			new(SpellName.Bombard,6, 1031689, 1095204, 0x2DA9),
		};

		public SpellTriggerSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.SpellTrigger)
		{
		}

		public override void OnCast()
		{
			_ = Caster.CloseGump(typeof(SpellTriggerGump));

			var gump = new SpellTriggerGump(this, Caster);
			var serial = gump.Serial;

			_ = Caster.SendGump(gump);

			_ = Timer.DelayCall(TimeSpan.FromSeconds(30), () =>
			{
				var current = Caster.FindGump(typeof(SpellTriggerGump));

				if (current != null && current.Serial == serial)
				{
					_ = Caster.CloseGump(typeof(EnchantSpellGump));

					FinishSequence();
				}
			});
		}
	}

	public class SpellTriggerGump : Gump
	{
		private readonly SpellTriggerSpell m_Spell;
		private readonly int m_Skill;

		public SpellTriggerGump(SpellTriggerSpell spell, Mobile m)
			: base(60, 36)
		{
			m_Spell = spell;

			m_Skill = (int)(MysticismSpell.GetBaseSkill(m) + MysticismSpell.GetBoostSkill(m));

			AddPage(0);

			AddBackground(0, 0, 520, 404, 0x13BE);

			AddImageTiled(10, 10, 500, 20, 0xA40);
			AddImageTiled(10, 40, 500, 324, 0xA40);
			AddImageTiled(10, 374, 500, 20, 0xA40);
			AddAlphaRegion(10, 10, 500, 384);

			AddButton(10, 374, 0xFB1, 0xFB2, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(45, 376, 450, 20, 1060051, 0x7FFF, false, false); // CANCEL

			AddHtmlLocalized(14, 12, 500, 20, 1080151, 0x7FFF, false, false); // <center>Spell Trigger Selection Menu</center>

			AddPage(1);

			var idx = 0;

			for (var i = 0; i < SpellTriggerSpell.Entries.Length; i++)
			{
				var entry = SpellTriggerSpell.Entries[i];

				if (m_Skill >= (entry.Rank * 40))
				{
					idx++;

					if (idx == 11)
					{
						AddButton(400, 374, 0xFA5, 0xFA7, 0, GumpButtonType.Page, 2);
						AddHtmlLocalized(440, 376, 60, 20, 1043353, 0x7FFF, false, false); // Next

						AddPage(2);

						AddButton(300, 374, 0xFAE, 0xFB0, 0, GumpButtonType.Page, 1);
						AddHtmlLocalized(340, 376, 60, 20, 1011393, 0x7FFF, false, false); // Back

						idx = 1;
					}

					if ((idx % 2) != 0)
					{
						AddImageTiledButton(14, 44 + (64 * (idx - 1) / 2), 0x918, 0x919, 100 + i, GumpButtonType.Reply, 0, entry.ItemId, 0, 15, 20);
						AddTooltip(entry.Tooltip);
						AddHtmlLocalized(98, 44 + (64 * (idx - 1) / 2), 170, 60, entry.Cliloc, 0x7FFF, false, false);
					}
					else
					{
						AddImageTiledButton(264, 44 + (64 * (idx - 2) / 2), 0x918, 0x919, 100 + i, GumpButtonType.Reply, 0, entry.ItemId, 0, 15, 20);
						AddTooltip(entry.Tooltip);
						AddHtmlLocalized(348, 44 + (64 * (idx - 2) / 2), 170, 60, entry.Cliloc, 0x7FFF, false, false);
					}
				}
				else
				{
					break;
				}
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			if (from.Backpack != null && info.ButtonID >= 100 && info.ButtonID <= 110 && m_Spell.CheckSequence())
			{
				var stones = from.Backpack.FindItemsByType(typeof(SpellStone));

				for (var i = 0; i < stones.Length; i++)
				{
					stones[i].Delete();
				}

				var entry = SpellTriggerSpell.Entries[info.ButtonID - 100];

				if (m_Skill >= (entry.Rank * 40))
				{
					from.PlaySound(0x659);

					_ = from.PlaceInBackpack(new SpellStone(entry));

					from.SendLocalizedMessage(1080165); // A Spell Stone appears in your backpack
				}
			}

			m_Spell.FinishSequence();
		}
	}

	public class SpellTriggerEntry
	{
		public SpellName Spell { get; }

		public int Rank { get; }
		public int Cliloc { get; }
		public int Tooltip { get; }
		public int ItemId { get; }

		public SpellTriggerEntry(SpellName spell, int rank, int cliloc, int tooltip, int itemId)
		{
			Spell = spell;
			Rank = rank;
			Cliloc = cliloc;
			Tooltip = tooltip;
			ItemId = itemId;
		}
	}
}