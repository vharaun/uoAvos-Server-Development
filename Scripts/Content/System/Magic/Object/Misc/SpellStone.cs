using Server.ContextMenus;
using Server.Spells.Mysticism;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	public class SpellStone : SpellScroll
	{
		private static readonly Dictionary<Mobile, DateTime> m_CooldownTable = new();

		private SpellTriggerEntry m_SpellDef;

		public override bool Nontransferable => true;

		public SpellStone(SpellTriggerEntry spell)
			: base(spell.Spell, 0x4079, 1)
		{
			m_SpellDef = spell;

			LootType = LootType.Blessed;
		}

		public SpellStone(Serial serial)
			: base(serial)
		{
		}

		public override bool DropToWorld(Mobile from, Point3D p)
		{
			_ = Timer.DelayCall(Delete);

			return true;
		}

		public override bool AllowSecureTrade(Mobile from, Mobile to, Mobile newOwner, bool accepted)
		{
			return false;
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (m_CooldownTable.ContainsKey(from))
			{
				var next = m_CooldownTable[from];
				var seconds = (int)(next - DateTime.UtcNow).TotalSeconds + 1;

				// You must wait ~1_seconds~ seconds before you can use this item.
				from.SendLocalizedMessage(1079263, seconds.ToString());

				return;
			}

			base.OnDoubleClick(from);
		}

		public void Use(Mobile from)
		{
			m_CooldownTable[from] = DateTime.UtcNow.AddSeconds(300.0);

			_ = Timer.DelayCall(TimeSpan.FromSeconds(300.0), m => m_CooldownTable.Remove(m), from);

			Delete();
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add(1080166, SpellRegistry.GetName(m_SpellDef.Spell)); // Use: ~1_spellName~
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			if (m_SpellDef != null)
			{
				writer.Write(true);
				writer.Write(m_SpellDef.Spell);
			}
			else
			{
				writer.Write(false);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version >= 0)
			{
				if (reader.ReadBool())
				{
					var spell = reader.ReadEnum<SpellName>();

					for (var i = 0; i < SpellTriggerSpell.Entries.Length; i++)
					{
						var def = SpellTriggerSpell.Entries[i];

						if (def.Spell == spell)
						{
							m_SpellDef = def;
							break;
						}
					}
				}
			}

			if (m_SpellDef == null)
			{
				_ = Timer.DelayCall(Delete);
			}
		}
	}
}