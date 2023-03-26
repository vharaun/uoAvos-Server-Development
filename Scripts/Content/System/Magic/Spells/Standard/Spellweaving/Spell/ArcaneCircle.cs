using Server.Items;

using System;
using System.Collections.Generic;

namespace Server.Spells.Spellweaving
{
	public class ArcaneCircleSpell : SpellweavingSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(0.5);

		public ArcaneCircleSpell(Mobile caster, Item scroll)
			: base(caster, scroll, SpellweavingSpellName.ArcaneCircle)
		{
		}

		public override bool CheckCast()
		{
			if (!IsValidLocation(Caster.Location, Caster.Map))
			{
				Caster.SendLocalizedMessage(1072705); // You must be standing on an arcane circle, pentagram or abbatoir to use this spell.
				return false;
			}

			var count = 0;

			foreach (var m in GetArcanists())
			{
				if (++count >= 2)
				{
					break;
				}
			}

			if (count < 2)
			{
				Caster.SendLocalizedMessage(1080452); // There are not enough spellweavers present to create an Arcane Focus.
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

				var arcanists = new Queue<Mobile>(GetArcanists());

				var duration = TimeSpan.FromHours(Math.Max(1, (int)(Caster.Skills.Spellweaving.Value / 24)));

				var strengthBonus = Math.Min(arcanists.Count, IsSanctuary(Caster.Location, Caster.Map) ? 6 : 5); // The Sanctuary is a special, single location place

				while (arcanists.TryDequeue(out var m))
				{
					GiveArcaneFocus(m, duration, strengthBonus);
				}
			}

			FinishSequence();
		}

		private IEnumerable<Mobile> GetArcanists()
		{
			yield return Caster;

			var mobiles = Caster.GetMobilesInRange(1); // Range verified as 1

			// OSI Verified: Even enemies/combatants count
			foreach (var m in mobiles)
			{
				// Everyone gets the Arcane Focus, power capped elsewhere
				if (m != Caster && m.Player && Caster.CanBeBeneficial(m, false) && Math.Abs(Caster.Skills.Spellweaving.Value - m.Skills.Spellweaving.Value) <= 20)
				{
					yield return m;
				}
			}

			mobiles.Free();
		}

		public static bool IsValidTile(int itemID)
		{
			// Per OSI, Center tile only
			// Pentagram center, Abbatoir center, Arcane Circle Center, Bloody Pentagram has 4 tiles at center
			return itemID is 0xFEA or 0x1216 or 0x307F or 0x1D10 or 0x1D0F or 0x1D1F or 0x1D12; 
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
				
				if (IsValidTile(tand))
				{
					return true;
				}
			}

			var eable = map.GetItemsInRange(location, 0); // Added Tiles

			var result = false;

			foreach (var item in eable)
			{
				var id = item.ItemData;

				if (item == null || item.Z + id.CalcHeight != location.Z)
				{
					continue;
				}
				
				if (IsValidTile(item.ItemID))
				{
					result = true;
					break;
				}
			}

			eable.Free();

			return result;
		}

		private static void GiveArcaneFocus(Mobile to, TimeSpan duration, int strengthBonus)
		{
			if (to == null)
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
			else // OSI renewal rules: the new one will override the old one, always.
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