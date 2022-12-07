using Server.ContextMenus;

using System.Collections.Generic;

namespace Server.Items
{
	public class SpellScroll : Item, ICommodity
	{
		[CommandProperty(AccessLevel.GameMaster)]
		public SpellName SpellID { get; private set; }

		[Hue, CommandProperty(AccessLevel.GameMaster)]
		public override int Hue
		{
			get => base.Hue;
			set
			{
				if (value <= 0)
				{
					value = Theme.BookHue;
				}

				base.Hue = value;
			}
		}

		private SpellSchool? m_School;

		[CommandProperty(AccessLevel.GameMaster)]
		public SpellSchool School => m_School ??= SpellRegistry.GetSchool(SpellID);

		private SpellbookTheme? m_Theme;

		[CommandProperty(AccessLevel.GameMaster)]
		public SpellbookTheme Theme => m_Theme ??= SpellbookTheme.GetTheme(School);

		int ICommodity.DescriptionNumber => LabelNumber;
		bool ICommodity.IsDeedable => Core.ML;

		[Constructable]
		public SpellScroll(SpellName spellID, int itemID) 
			: this(spellID, itemID, 1)
		{
		}

		[Constructable]
		public SpellScroll(SpellName spellID, int itemID, int amount)
			: base(itemID)
		{
			SpellID = spellID;

			Stackable = true;
			Weight = 1.0;
			Amount = amount;

			Hue = 0;
		}

		public SpellScroll(Serial serial) 
			: base(serial)
		{
		}

		public override bool CanStackWith(Mobile from, Item dropped, bool playSound)
		{
			if (base.CanStackWith(from, dropped, playSound))
			{
				if (dropped is SpellScroll scroll && scroll.SpellID == SpellID)
				{
					return true;
				}
			}

			return false;
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			if (from.Alive && Movable)
			{
				list.Add(new AddToSpellbookEntry());
			}
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!Multis.DesignContext.Check(from))
			{
				return; // They are customizing
			}

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
				return;
			}

			var spell = SpellRegistry.NewSpell(SpellID, from, this);

			if (spell != null)
			{
				spell.Cast();
			}
			else
			{
				from.SendLocalizedMessage(502345); // This spell has been temporarily disabled.
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(SpellID);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadInt();

			SpellID = reader.ReadEnum<SpellName>();
		}
	}
}