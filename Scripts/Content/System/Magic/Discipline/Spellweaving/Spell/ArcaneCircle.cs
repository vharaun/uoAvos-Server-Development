using Server.Items;
using Server.Mobiles;

using System;
using System.Collections.Generic;

namespace Server.Items
{
	public class ArcaneFocus : TransientItem
	{
		public override int LabelNumber => 1032629;  // Arcane Focus

		private int m_StrengthBonus;

		[CommandProperty(AccessLevel.GameMaster)]
		public int StrengthBonus
		{
			get => m_StrengthBonus;
			set => m_StrengthBonus = value;
		}

		[Constructable]
		public ArcaneFocus()
			: this(TimeSpan.FromHours(1), 1)
		{
		}

		[Constructable]
		public ArcaneFocus(int lifeSpan, int strengthBonus)
			: this(TimeSpan.FromSeconds(lifeSpan), strengthBonus)
		{
		}

		public ArcaneFocus(TimeSpan lifeSpan, int strengthBonus) : base(0x3155, lifeSpan)
		{
			LootType = LootType.Blessed;
			m_StrengthBonus = strengthBonus;
		}

		public ArcaneFocus(Serial serial) : base(serial)
		{
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add(1060485, m_StrengthBonus.ToString()); // strength bonus ~1_val~
		}

		public override TextDefinition InvalidTransferMessage => 1073480;  // Your arcane focus disappears.
		public override bool Nontransferable => true;

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);

			writer.Write(m_StrengthBonus);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			m_StrengthBonus = reader.ReadInt();
		}
	}
}

namespace Server.Spells.Spellweaving
{
	public class ArcaneCircleSpell : ArcanistSpell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
				"Arcane Circle", "Myrshalee",
				-1
			);

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(0.5);

		public override double RequiredSkill => 0.0;
		public override int RequiredMana => 24;

		public ArcaneCircleSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if (!IsValidLocation(Caster.Location, Caster.Map))
			{
				Caster.SendLocalizedMessage(1072705); // You must be standing on an arcane circle, pentagram or abbatoir to use this spell.
				return false;
			}

			if (GetArcanists().Count < 2)
			{
				Caster.SendLocalizedMessage(1080452); //There are not enough spellweavers present to create an Arcane Focus.
				return false;
			}

			return base.CheckCast();
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Caster.FixedParticles(0x3779, 10, 20, 0x0, EffectLayer.Waist);
				Caster.PlaySound(0x5C0);

				var Arcanists = GetArcanists();

				var duration = TimeSpan.FromHours(Math.Max(1, (int)(Caster.Skills.Spellweaving.Value / 24)));

				var strengthBonus = Math.Min(Arcanists.Count, IsSanctuary(Caster.Location, Caster.Map) ? 6 : 5);    //The Sanctuary is a special, single location place

				for (var i = 0; i < Arcanists.Count; i++)
				{
					GiveArcaneFocus(Arcanists[i], duration, strengthBonus);
				}
			}

			FinishSequence();
		}

		private static bool IsSanctuary(Point3D p, Map m)
		{
			return (m == Map.Trammel || m == Map.Felucca) && p.X == 6267 && p.Y == 131;
		}

		private static bool IsValidLocation(Point3D location, Map map)
		{
			var lt = map.Tiles.GetLandTile(location.X, location.Y);         // Land   Tiles            

			if (IsValidTile(lt.ID) && lt.Z == location.Z)
			{
				return true;
			}

			var tiles = map.Tiles.GetStaticTiles(location.X, location.Y); // Static Tiles

			for (var i = 0; i < tiles.Length; ++i)
			{
				var t = tiles[i];
				var id = TileData.ItemTable[t.ID & TileData.MaxItemValue];

				var tand = t.ID;

				if (t.Z + id.CalcHeight != location.Z)
				{
					continue;
				}
				else if (IsValidTile(tand))
				{
					return true;
				}
			}

			IPooledEnumerable eable = map.GetItemsInRange(location, 0);      // Added  Tiles

			foreach (Item item in eable)
			{
				var id = item.ItemData;

				if (item == null || item.Z + id.CalcHeight != location.Z)
				{
					continue;
				}
				else if (IsValidTile(item.ItemID))
				{
					eable.Free();
					return true;
				}
			}

			eable.Free();
			return false;
		}

		public static bool IsValidTile(int itemID)
		{
			//Per OSI, Center tile only
			return (itemID == 0xFEA || itemID == 0x1216 || itemID == 0x307F || itemID == 0x1D10 || itemID == 0x1D0F || itemID == 0x1D1F || itemID == 0x1D12);   // Pentagram center, Abbatoir center, Arcane Circle Center, Bloody Pentagram has 4 tiles at center
		}

		private List<Mobile> GetArcanists()
		{
			var weavers = new List<Mobile> {
				Caster
			};

			//OSI Verified: Even enemies/combatants count
			foreach (var m in Caster.GetMobilesInRange(1))   //Range verified as 1
			{
				if (m != Caster && m is PlayerMobile && Caster.CanBeBeneficial(m, false) && Math.Abs(Caster.Skills.Spellweaving.Value - m.Skills.Spellweaving.Value) <= 20 && !(m is Clone))
				{
					weavers.Add(m);
				}
				// Everyone gets the Arcane Focus, power capped elsewhere
			}

			return weavers;
		}

		private void GiveArcaneFocus(Mobile to, TimeSpan duration, int strengthBonus)
		{
			if (to == null) //Sanity
			{
				return;
			}

			var focus = FindArcaneFocus(to);

			if (focus == null)
			{
				var f = new ArcaneFocus(duration, strengthBonus);
				if (to.PlaceInBackpack(f))
				{
					f.SendTimeRemainingMessage(to);
					to.SendLocalizedMessage(1072740); // An arcane focus appears in your backpack.
				}
				else
				{
					f.Delete();
				}

			}
			else        //OSI renewal rules: the new one will override the old one, always.
			{
				to.SendLocalizedMessage(1072828); // Your arcane focus is renewed.
				focus.LifeSpan = duration;
				focus.CreationTime = DateTime.UtcNow;
				focus.StrengthBonus = strengthBonus;
				focus.InvalidateProperties();
				focus.SendTimeRemainingMessage(to);
			}
		}
	}
}