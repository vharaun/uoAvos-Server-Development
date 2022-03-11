using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Fifth;
using Server.Spells.Seventh;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Gumps
{
	public class PolymorphEntry
	{
		public static readonly PolymorphEntry Chicken = new PolymorphEntry(8401, 0xD0, 1015236, 15, 10);
		public static readonly PolymorphEntry Dog = new PolymorphEntry(8405, 0xD9, 1015237, 17, 10);
		public static readonly PolymorphEntry Wolf = new PolymorphEntry(8426, 0xE1, 1015238, 18, 10);
		public static readonly PolymorphEntry Panther = new PolymorphEntry(8473, 0xD6, 1015239, 20, 14);
		public static readonly PolymorphEntry Gorilla = new PolymorphEntry(8437, 0x1D, 1015240, 23, 10);
		public static readonly PolymorphEntry BlackBear = new PolymorphEntry(8399, 0xD3, 1015241, 22, 10);
		public static readonly PolymorphEntry GrizzlyBear = new PolymorphEntry(8411, 0xD4, 1015242, 22, 12);
		public static readonly PolymorphEntry PolarBear = new PolymorphEntry(8417, 0xD5, 1015243, 26, 10);
		public static readonly PolymorphEntry HumanMale = new PolymorphEntry(8397, 0x190, 1015244, 29, 8);
		public static readonly PolymorphEntry HumanFemale = new PolymorphEntry(8398, 0x191, 1015254, 29, 10);
		public static readonly PolymorphEntry Slime = new PolymorphEntry(8424, 0x33, 1015246, 5, 10);
		public static readonly PolymorphEntry Orc = new PolymorphEntry(8416, 0x11, 1015247, 29, 10);
		public static readonly PolymorphEntry LizardMan = new PolymorphEntry(8414, 0x21, 1015248, 26, 10);
		public static readonly PolymorphEntry Gargoyle = new PolymorphEntry(8409, 0x04, 1015249, 22, 10);
		public static readonly PolymorphEntry Ogre = new PolymorphEntry(8415, 0x01, 1015250, 24, 9);
		public static readonly PolymorphEntry Troll = new PolymorphEntry(8425, 0x36, 1015251, 25, 9);
		public static readonly PolymorphEntry Ettin = new PolymorphEntry(8408, 0x02, 1015252, 25, 8);
		public static readonly PolymorphEntry Daemon = new PolymorphEntry(8403, 0x09, 1015253, 25, 8);


		private readonly int m_Art, m_Body, m_Num, m_X, m_Y;

		private PolymorphEntry(int Art, int Body, int LocNum, int X, int Y)
		{
			m_Art = Art;
			m_Body = Body;
			m_Num = LocNum;
			m_X = X;
			m_Y = Y;
		}

		public int ArtID => m_Art;
		public int BodyID => m_Body;
		public int LocNumber => m_Num;
		public int X => m_X;
		public int Y => m_Y;
	}

	public class PolymorphGump : Gump
	{
		private class PolymorphCategory
		{
			private readonly int m_Num;
			private readonly PolymorphEntry[] m_Entries;

			public PolymorphCategory(int num, params PolymorphEntry[] entries)
			{
				m_Num = num;
				m_Entries = entries;
			}

			public PolymorphEntry[] Entries => m_Entries;
			public int LocNumber => m_Num;
		}

		private static readonly PolymorphCategory[] Categories = new PolymorphCategory[]
			{
				new PolymorphCategory( 1015235, // Animals
					PolymorphEntry.Chicken,
					PolymorphEntry.Dog,
					PolymorphEntry.Wolf,
					PolymorphEntry.Panther,
					PolymorphEntry.Gorilla,
					PolymorphEntry.BlackBear,
					PolymorphEntry.GrizzlyBear,
					PolymorphEntry.PolarBear,
					PolymorphEntry.HumanMale ),

				new PolymorphCategory( 1015245, // Monsters
					PolymorphEntry.Slime,
					PolymorphEntry.Orc,
					PolymorphEntry.LizardMan,
					PolymorphEntry.Gargoyle,
					PolymorphEntry.Ogre,
					PolymorphEntry.Troll,
					PolymorphEntry.Ettin,
					PolymorphEntry.Daemon,
					PolymorphEntry.HumanFemale )
			};


		private readonly Mobile m_Caster;
		private readonly Item m_Scroll;

		public PolymorphGump(Mobile caster, Item scroll) : base(50, 50)
		{
			m_Caster = caster;
			m_Scroll = scroll;

			int x, y;
			AddPage(0);
			AddBackground(0, 0, 585, 393, 5054);
			AddBackground(195, 36, 387, 275, 3000);
			AddHtmlLocalized(0, 0, 510, 18, 1015234, false, false); // <center>Polymorph Selection Menu</center>
			AddHtmlLocalized(60, 355, 150, 18, 1011036, false, false); // OKAY
			AddButton(25, 355, 4005, 4007, 1, GumpButtonType.Reply, 1);
			AddHtmlLocalized(320, 355, 150, 18, 1011012, false, false); // CANCEL
			AddButton(285, 355, 4005, 4007, 0, GumpButtonType.Reply, 2);

			y = 35;
			for (var i = 0; i < Categories.Length; i++)
			{
				var cat = Categories[i];
				AddHtmlLocalized(5, y, 150, 25, cat.LocNumber, true, false);
				AddButton(155, y, 4005, 4007, 0, GumpButtonType.Page, i + 1);
				y += 25;
			}

			for (var i = 0; i < Categories.Length; i++)
			{
				var cat = Categories[i];
				AddPage(i + 1);

				for (var c = 0; c < cat.Entries.Length; c++)
				{
					var entry = cat.Entries[c];
					x = 198 + (c % 3) * 129;
					y = 38 + (c / 3) * 67;

					AddHtmlLocalized(x, y, 100, 18, entry.LocNumber, false, false);
					AddItem(x + 20, y + 25, entry.ArtID);
					AddRadio(x, y + 20, 210, 211, false, (c << 8) + i);
				}
			}
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			if (info.ButtonID == 1 && info.Switches.Length > 0)
			{
				var cnum = info.Switches[0];
				var cat = cnum % 256;
				var ent = cnum >> 8;

				if (cat >= 0 && cat < Categories.Length)
				{
					if (ent >= 0 && ent < Categories[cat].Entries.Length)
					{
						Spell spell = new PolymorphSpell(m_Caster, m_Scroll, Categories[cat].Entries[ent].BodyID);
						spell.Cast();
					}
				}
			}
		}
	}

	public class NewPolymorphGump : Gump
	{
		private static readonly PolymorphEntry[] m_Entries = new PolymorphEntry[]
			{
				PolymorphEntry.Chicken,
				PolymorphEntry.Dog,
				PolymorphEntry.Wolf,
				PolymorphEntry.Panther,
				PolymorphEntry.Gorilla,
				PolymorphEntry.BlackBear,
				PolymorphEntry.GrizzlyBear,
				PolymorphEntry.PolarBear,
				PolymorphEntry.HumanMale,
				PolymorphEntry.HumanFemale,
				PolymorphEntry.Slime,
				PolymorphEntry.Orc,
				PolymorphEntry.LizardMan,
				PolymorphEntry.Gargoyle,
				PolymorphEntry.Ogre,
				PolymorphEntry.Troll,
				PolymorphEntry.Ettin,
				PolymorphEntry.Daemon
			};

		private readonly Mobile m_Caster;
		private readonly Item m_Scroll;

		public NewPolymorphGump(Mobile caster, Item scroll) : base(0, 0)
		{
			m_Caster = caster;
			m_Scroll = scroll;

			AddPage(0);

			AddBackground(0, 0, 520, 404, 0x13BE);
			AddImageTiled(10, 10, 500, 20, 0xA40);
			AddImageTiled(10, 40, 500, 324, 0xA40);
			AddImageTiled(10, 374, 500, 20, 0xA40);
			AddAlphaRegion(10, 10, 500, 384);

			AddHtmlLocalized(14, 12, 500, 20, 1015234, 0x7FFF, false, false); // <center>Polymorph Selection Menu</center>

			AddButton(10, 374, 0xFB1, 0xFB2, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(45, 376, 450, 20, 1060051, 0x7FFF, false, false); // CANCEL

			for (var i = 0; i < m_Entries.Length; i++)
			{
				var entry = m_Entries[i];

				var page = i / 10 + 1;
				var pos = i % 10;

				if (pos == 0)
				{
					if (page > 1)
					{
						AddButton(400, 374, 0xFA5, 0xFA7, 0, GumpButtonType.Page, page);
						AddHtmlLocalized(440, 376, 60, 20, 1043353, 0x7FFF, false, false); // Next
					}

					AddPage(page);

					if (page > 1)
					{
						AddButton(300, 374, 0xFAE, 0xFB0, 0, GumpButtonType.Page, 1);
						AddHtmlLocalized(340, 376, 60, 20, 1011393, 0x7FFF, false, false); // Back
					}
				}

				var x = (pos % 2 == 0) ? 14 : 264;
				var y = (pos / 2) * 64 + 44;

				AddImageTiledButton(x, y, 0x918, 0x919, i + 1, GumpButtonType.Reply, 0, entry.ArtID, 0x0, entry.X, entry.Y);
				AddHtmlLocalized(x + 84, y, 250, 60, entry.LocNumber, 0x7FFF, false, false);
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var idx = info.ButtonID - 1;

			if (idx < 0 || idx >= m_Entries.Length)
			{
				return;
			}

			Spell spell = new PolymorphSpell(m_Caster, m_Scroll, m_Entries[idx].BodyID);
			spell.Cast();
		}
	}
}

namespace Server.Spells.Seventh
{
	/// ChainLightning
	public class ChainLightningSpell : MagerySpell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
				"Chain Lightning", "Vas Ort Grav",
				209,
				9022,
				false,
				Reagent.BlackPearl,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
			);

		public override SpellCircle Circle => SpellCircle.Seventh;

		public ChainLightningSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage => true;

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (SpellHelper.CheckTown(p, Caster) && CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				if (p is Item)
				{
					p = ((Item)p).GetWorldLocation();
				}

				var targets = new List<Mobile>();

				var map = Caster.Map;

				var playerVsPlayer = false;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), 2);

					foreach (Mobile m in eable)
					{
						if (Core.AOS && m == Caster)
						{
							continue;
						}

						if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false))
						{
							if (Core.AOS && !Caster.InLOS(m))
							{
								continue;
							}

							targets.Add(m);

							if (m.Player)
							{
								playerVsPlayer = true;
							}
						}
					}

					eable.Free();
				}

				double damage;

				if (Core.AOS)
				{
					damage = GetNewAosDamage(51, 1, 5, playerVsPlayer);
				}
				else
				{
					damage = Utility.Random(27, 22);
				}

				if (targets.Count > 0)
				{
					if (Core.AOS && targets.Count > 2)
					{
						damage = (damage * 2) / targets.Count;
					}
					else if (!Core.AOS)
					{
						damage /= targets.Count;
					}

					double toDeal;
					for (var i = 0; i < targets.Count; ++i)
					{
						toDeal = damage;
						var m = targets[i];

						if (!Core.AOS && CheckResisted(m))
						{
							toDeal *= 0.5;

							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}
						toDeal *= GetDamageScalar(m);
						Caster.DoHarmful(m);
						SpellHelper.Damage(this, m, toDeal, 0, 0, 0, 0, 100);

						m.BoltEffect(0);
					}
				}
				else
				{
					Caster.PlaySound(0x29);
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly ChainLightningSpell m_Owner;

			public InternalTarget(ChainLightningSpell owner) : base(Core.ML ? 10 : 12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var p = o as IPoint3D;

				if (p != null)
				{
					m_Owner.Target(p);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// EnergyField
	public class EnergyFieldSpell : MagerySpell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
				"Energy Field", "In Sanct Grav",
				221,
				9022,
				false,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
			);

		public override SpellCircle Circle => SpellCircle.Seventh;

		public EnergyFieldSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (SpellHelper.CheckTown(p, Caster) && CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				var dx = Caster.Location.X - p.X;
				var dy = Caster.Location.Y - p.Y;
				var rx = (dx - dy) * 44;
				var ry = (dx + dy) * 44;

				bool eastToWest;

				if (rx >= 0 && ry >= 0)
				{
					eastToWest = false;
				}
				else if (rx >= 0)
				{
					eastToWest = true;
				}
				else if (ry >= 0)
				{
					eastToWest = true;
				}
				else
				{
					eastToWest = false;
				}

				Effects.PlaySound(p, Caster.Map, 0x20B);

				TimeSpan duration;

				if (Core.AOS)
				{
					duration = TimeSpan.FromSeconds((15 + (Caster.Skills.Magery.Fixed / 5)) / 7);
				}
				else
				{
					duration = TimeSpan.FromSeconds(Caster.Skills[SkillName.Magery].Value * 0.28 + 2.0); // (28% of magery) + 2.0 seconds
				}

				var itemID = eastToWest ? 0x3946 : 0x3956;

				for (var i = -2; i <= 2; ++i)
				{
					var loc = new Point3D(eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z);
					var canFit = SpellHelper.AdjustField(ref loc, Caster.Map, 12, false);

					if (!canFit)
					{
						continue;
					}

					Item item = new InternalItem(loc, Caster.Map, duration, itemID, Caster);
					item.ProcessDelta();

					Effects.SendLocationParticles(EffectItem.Create(loc, Caster.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 5051);
				}
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Item
		{
			private readonly Timer m_Timer;
			private readonly Mobile m_Caster;

			public override bool BlocksFit => true;

			public InternalItem(Point3D loc, Map map, TimeSpan duration, int itemID, Mobile caster) : base(itemID)
			{
				Visible = false;
				Movable = false;
				Light = LightType.Circle300;

				MoveToWorld(loc, map);

				m_Caster = caster;

				if (caster.InLOS(this))
				{
					Visible = true;
				}
				else
				{
					Delete();
				}

				if (Deleted)
				{
					return;
				}

				m_Timer = new InternalTimer(this, duration);
				m_Timer.Start();
			}

			public InternalItem(Serial serial) : base(serial)
			{
				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(5.0));
				m_Timer.Start();
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

			public override bool OnMoveOver(Mobile m)
			{
				int noto;

				if (m is PlayerMobile)
				{
					noto = Notoriety.Compute(m_Caster, m);
					if (noto == Notoriety.Enemy || noto == Notoriety.Ally)
					{
						return false;
					}
				}
				return base.OnMoveOver(m);
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if (m_Timer != null)
				{
					m_Timer.Stop();
				}
			}

			private class InternalTimer : Timer
			{
				private readonly InternalItem m_Item;

				public InternalTimer(InternalItem item, TimeSpan duration) : base(duration)
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly EnergyFieldSpell m_Owner;

			public InternalTarget(EnergyFieldSpell owner) : base(Core.ML ? 10 : 12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D)
				{
					m_Owner.Target((IPoint3D)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// FlameStrike
	public class FlameStrikeSpell : MagerySpell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
				"Flame Strike", "Kal Vas Flam",
				245,
				9042,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
			);

		public override SpellCircle Circle => SpellCircle.Seventh;

		public FlameStrikeSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage => true;

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				double damage;

				if (Core.AOS)
				{
					damage = GetNewAosDamage(48, 1, 5, m);
				}
				else
				{
					damage = Utility.Random(27, 22);

					if (CheckResisted(m))
					{
						damage *= 0.6;

						m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar(m);
				}

				m.FixedParticles(0x3709, 10, 30, 5052, EffectLayer.LeftFoot);
				m.PlaySound(0x208);

				SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly FlameStrikeSpell m_Owner;

			public InternalTarget(FlameStrikeSpell owner) : base(Core.ML ? 10 : 12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
				{
					m_Owner.Target((Mobile)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// GateTravel
	public class GateTravelSpell : MagerySpell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
				"Gate Travel", "Vas Rel Por",
				263,
				9032,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
			);

		public override SpellCircle Circle => SpellCircle.Seventh;

		private readonly RunebookEntry m_Entry;

		public GateTravelSpell(Mobile caster, Item scroll) : this(caster, scroll, null)
		{
		}

		public GateTravelSpell(Mobile caster, Item scroll, RunebookEntry entry) : base(caster, scroll, m_Info)
		{
			m_Entry = entry;
		}

		public override void OnCast()
		{
			if (m_Entry == null)
			{
				Caster.Target = new InternalTarget(this);
			}
			else
			{
				Effect(m_Entry.Location, m_Entry.Map, true);
			}
		}

		public override bool CheckCast()
		{
			if (Factions.Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
				return false;
			}
			else if (Caster.Criminal)
			{
				Caster.SendLocalizedMessage(1005561, "", 0x22); // Thou'rt a criminal and cannot escape so easily.
				return false;
			}
			else if (SpellHelper.CheckCombat(Caster))
			{
				Caster.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle??
				return false;
			}

			return SpellHelper.CheckTravel(Caster, TravelCheckType.GateFrom);
		}

		private bool GateExistsAt(Map map, Point3D loc)
		{
			var _gateFound = false;

			IPooledEnumerable eable = map.GetItemsInRange(loc, 0);
			foreach (Item item in eable)
			{
				if (item is Moongate || item is PublicMoongate)
				{
					_gateFound = true;
					break;
				}
			}
			eable.Free();

			return _gateFound;
		}

		public void Effect(Point3D loc, Map map, bool checkMulti)
		{
			if (Factions.Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
			}
			else if (map == null || (!Core.AOS && Caster.Map != map))
			{
				Caster.SendLocalizedMessage(1005570); // You can not gate to another facet.
			}
			else if (!SpellHelper.CheckTravel(Caster, TravelCheckType.GateFrom))
			{
			}
			else if (!SpellHelper.CheckTravel(Caster, map, loc, TravelCheckType.GateTo))
			{
			}
			else if (map == Map.Felucca && Caster is PlayerMobile && ((PlayerMobile)Caster).Young)
			{
				Caster.SendLocalizedMessage(1049543); // You decide against traveling to Felucca while you are still young.
			}
			else if (Caster.Kills >= 5 && map != Map.Felucca)
			{
				Caster.SendLocalizedMessage(1019004); // You are not allowed to travel there.
			}
			else if (Caster.Criminal)
			{
				Caster.SendLocalizedMessage(1005561, "", 0x22); // Thou'rt a criminal and cannot escape so easily.
			}
			else if (SpellHelper.CheckCombat(Caster))
			{
				Caster.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle??
			}
			else if (!map.CanSpawnMobile(loc.X, loc.Y, loc.Z))
			{
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			}
			else if ((checkMulti && SpellHelper.CheckMulti(loc, map)))
			{
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			}
			else if (Core.SE && (GateExistsAt(map, loc) || GateExistsAt(Caster.Map, Caster.Location))) // SE restricted stacking gates
			{
				Caster.SendLocalizedMessage(1071242); // There is already a gate there.
			}
			else if (CheckSequence())
			{
				Caster.SendLocalizedMessage(501024); // You open a magical gate to another location

				Effects.PlaySound(Caster.Location, Caster.Map, 0x20E);

				var firstGate = new InternalItem(loc, map);
				firstGate.MoveToWorld(Caster.Location, Caster.Map);

				Effects.PlaySound(loc, map, 0x20E);

				var secondGate = new InternalItem(Caster.Location, Caster.Map);
				secondGate.MoveToWorld(loc, map);
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Moongate
		{
			public override bool ShowFeluccaWarning => Core.AOS;

			public InternalItem(Point3D target, Map map) : base(target, map)
			{
				Map = map;

				if (ShowFeluccaWarning && map == Map.Felucca)
				{
					ItemID = 0xDDA;
				}

				Dispellable = true;

				var t = new InternalTimer(this);
				t.Start();
			}

			public InternalItem(Serial serial) : base(serial)
			{
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				Delete();
			}

			private class InternalTimer : Timer
			{
				private readonly Item m_Item;

				public InternalTimer(Item item) : base(TimeSpan.FromSeconds(30.0))
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly GateTravelSpell m_Owner;

			public InternalTarget(GateTravelSpell owner) : base(12, false, TargetFlags.None)
			{
				m_Owner = owner;

				owner.Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 501029); // Select Marked item.
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is RecallRune)
				{
					var rune = (RecallRune)o;

					if (rune.Marked)
					{
						m_Owner.Effect(rune.Target, rune.TargetMap, true);
					}
					else
					{
						from.SendLocalizedMessage(501803); // That rune is not yet marked.
					}
				}
				else if (o is Runebook)
				{
					var e = ((Runebook)o).Default;

					if (e != null)
					{
						m_Owner.Effect(e.Location, e.Map, true);
					}
					else
					{
						from.SendLocalizedMessage(502354); // Target is not marked.
					}
				}
				/*else if ( o is Key && ((Key)o).KeyValue != 0 && ((Key)o).Link is BaseBoat )
				{
					BaseBoat boat = ((Key)o).Link as BaseBoat;

					if ( !boat.Deleted && boat.CheckKey( ((Key)o).KeyValue ) )
						m_Owner.Effect( boat.GetMarkedLocation(), boat.Map, false );
					else
						from.Send( new MessageLocalized( from.Serial, from.Body, MessageType.Regular, 0x3B2, 3, 501030, from.Name, "" ) ); // I can not gate travel from that object.
				}*/
				else if (o is HouseRaffleDeed && ((HouseRaffleDeed)o).ValidLocation())
				{
					var deed = (HouseRaffleDeed)o;

					m_Owner.Effect(deed.PlotLocation, deed.PlotFacet, true);
				}
				else
				{
					from.Send(new MessageLocalized(from.Serial, from.Body, MessageType.Regular, 0x3B2, 3, 501030, from.Name, "")); // I can not gate travel from that object.
				}
			}

			protected override void OnNonlocalTarget(Mobile from, object o)
			{
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// ManaVampire
	public class ManaVampireSpell : MagerySpell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
				"Mana Vampire", "Ort Sanct",
				221,
				9032,
				Reagent.BlackPearl,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public override SpellCircle Circle => SpellCircle.Seventh;

		public ManaVampireSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				if (m.Spell != null)
				{
					m.Spell.OnCasterHurt();
				}

				m.Paralyzed = false;

				var toDrain = 0;

				if (Core.AOS)
				{
					toDrain = (int)(GetDamageSkill(Caster) - GetResistSkill(m));

					if (!m.Player)
					{
						toDrain /= 2;
					}

					if (toDrain < 0)
					{
						toDrain = 0;
					}
					else if (toDrain > m.Mana)
					{
						toDrain = m.Mana;
					}
				}
				else
				{
					if (CheckResisted(m))
					{
						m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
					}
					else
					{
						toDrain = m.Mana;
					}
				}

				if (toDrain > (Caster.ManaMax - Caster.Mana))
				{
					toDrain = Caster.ManaMax - Caster.Mana;
				}

				m.Mana -= toDrain;
				Caster.Mana += toDrain;

				if (Core.AOS)
				{
					m.FixedParticles(0x374A, 1, 15, 5054, 23, 7, EffectLayer.Head);
					m.PlaySound(0x1F9);

					Caster.FixedParticles(0x0000, 10, 5, 2054, EffectLayer.Head);
				}
				else
				{
					m.FixedParticles(0x374A, 10, 15, 5054, EffectLayer.Head);
					m.PlaySound(0x1F9);
				}

				HarmfulSpell(m);
			}

			FinishSequence();
		}

		public override double GetResistPercent(Mobile target)
		{
			return 98.0;
		}

		private class InternalTarget : Target
		{
			private readonly ManaVampireSpell m_Owner;

			public InternalTarget(ManaVampireSpell owner) : base(Core.ML ? 10 : 12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
				{
					m_Owner.Target((Mobile)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// MassDispel
	public class MassDispelSpell : MagerySpell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
				"Mass Dispel", "Vas An Ort",
				263,
				9002,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.BlackPearl,
				Reagent.SulfurousAsh
			);

		public override SpellCircle Circle => SpellCircle.Seventh;

		public MassDispelSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				var targets = new List<Mobile>();

				var map = Caster.Map;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), 8);

					foreach (Mobile m in eable)
					{
						if (m is BaseCreature && (m as BaseCreature).IsDispellable && Caster.CanBeHarmful(m, false))
						{
							targets.Add(m);
						}
					}

					eable.Free();
				}

				for (var i = 0; i < targets.Count; ++i)
				{
					var m = targets[i];

					var bc = m as BaseCreature;

					if (bc == null)
					{
						continue;
					}

					var dispelChance = (50.0 + ((100 * (Caster.Skills.Magery.Value - bc.DispelDifficulty)) / (bc.DispelFocus * 2))) / 100;

					if (dispelChance > Utility.RandomDouble())
					{
						Effects.SendLocationParticles(EffectItem.Create(m.Location, m.Map, EffectItem.DefaultDuration), 0x3728, 8, 20, 5042);
						Effects.PlaySound(m, m.Map, 0x201);

						m.Delete();
					}
					else
					{
						Caster.DoHarmful(m);

						m.FixedEffect(0x3779, 10, 20);
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly MassDispelSpell m_Owner;

			public InternalTarget(MassDispelSpell owner) : base(Core.ML ? 10 : 12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var p = o as IPoint3D;

				if (p != null)
				{
					m_Owner.Target(p);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// MeteorSwarm
	public class MeteorSwarmSpell : MagerySpell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
				"Meteor Swarm", "Flam Kal Des Ylem",
				233,
				9042,
				false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh,
				Reagent.SpidersSilk
			);

		public override SpellCircle Circle => SpellCircle.Seventh;

		public MeteorSwarmSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage => true;

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (SpellHelper.CheckTown(p, Caster) && CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				if (p is Item)
				{
					p = ((Item)p).GetWorldLocation();
				}

				var targets = new List<Mobile>();

				var map = Caster.Map;

				var playerVsPlayer = false;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), 2);

					foreach (Mobile m in eable)
					{
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false))
						{
							if (Core.AOS && !Caster.InLOS(m))
							{
								continue;
							}

							targets.Add(m);

							if (m.Player)
							{
								playerVsPlayer = true;
							}
						}
					}

					eable.Free();
				}

				double damage;

				if (Core.AOS)
				{
					damage = GetNewAosDamage(51, 1, 5, playerVsPlayer);
				}
				else
				{
					damage = Utility.Random(27, 22);
				}

				if (targets.Count > 0)
				{
					Effects.PlaySound(p, Caster.Map, 0x160);

					if (Core.AOS && targets.Count > 2)
					{
						damage = (damage * 2) / targets.Count;
					}
					else if (!Core.AOS)
					{
						damage /= targets.Count;
					}

					double toDeal;
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = targets[i];

						toDeal = damage;

						if (!Core.AOS && CheckResisted(m))
						{
							damage *= 0.5;

							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}
						toDeal *= GetDamageScalar(m);
						Caster.DoHarmful(m);
						SpellHelper.Damage(this, m, toDeal, 0, 100, 0, 0, 0);

						Caster.MovingParticles(m, 0x36D4, 7, 0, false, true, 9501, 1, 0, 0x100);
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly MeteorSwarmSpell m_Owner;

			public InternalTarget(MeteorSwarmSpell owner) : base(Core.ML ? 10 : 12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var p = o as IPoint3D;

				if (p != null)
				{
					m_Owner.Target(p);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}

	/// Polymorph
	public class PolymorphSpell : MagerySpell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
				"Polymorph", "Vas Ylem Rel",
				221,
				9002,
				Reagent.Bloodmoss,
				Reagent.SpidersSilk,
				Reagent.MandrakeRoot
			);

		public override SpellCircle Circle => SpellCircle.Seventh;

		private readonly int m_NewBody;

		public PolymorphSpell(Mobile caster, Item scroll, int body) : base(caster, scroll, m_Info)
		{
			m_NewBody = body;
		}

		public PolymorphSpell(Mobile caster, Item scroll) : this(caster, scroll, 0)
		{
		}

		public override bool CheckCast()
		{
			/*if ( Caster.Mounted )
			{
				Caster.SendLocalizedMessage( 1042561 ); //Please dismount first.
				return false;
			}
			else */
			if (Factions.Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1010521); // You cannot polymorph while you have a Town Sigil
				return false;
			}
			else if (TransformationSpellHelper.UnderTransformation(Caster))
			{
				Caster.SendLocalizedMessage(1061633); // You cannot polymorph while in that form.
				return false;
			}
			else if (DisguiseTimers.IsDisguised(Caster))
			{
				Caster.SendLocalizedMessage(502167); // You cannot polymorph while disguised.
				return false;
			}
			else if (Caster.BodyMod == 183 || Caster.BodyMod == 184)
			{
				Caster.SendLocalizedMessage(1042512); // You cannot polymorph while wearing body paint
				return false;
			}
			else if (!Caster.CanBeginAction(typeof(PolymorphSpell)))
			{
				if (Core.ML)
				{
					EndPolymorph(Caster);
				}
				else
				{
					Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
				}

				return false;
			}
			else if (m_NewBody == 0)
			{
				Gump gump;
				if (Core.SE)
				{
					gump = new NewPolymorphGump(Caster, Scroll);
				}
				else
				{
					gump = new PolymorphGump(Caster, Scroll);
				}

				Caster.SendGump(gump);
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			/*if ( Caster.Mounted )
			{
				Caster.SendLocalizedMessage( 1042561 ); //Please dismount first.
			} 
			else */
			if (Factions.Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1010521); // You cannot polymorph while you have a Town Sigil
			}
			else if (!Caster.CanBeginAction(typeof(PolymorphSpell)))
			{
				if (Core.ML)
				{
					EndPolymorph(Caster);
				}
				else
				{
					Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
				}
			}
			else if (TransformationSpellHelper.UnderTransformation(Caster))
			{
				Caster.SendLocalizedMessage(1061633); // You cannot polymorph while in that form.
			}
			else if (DisguiseTimers.IsDisguised(Caster))
			{
				Caster.SendLocalizedMessage(502167); // You cannot polymorph while disguised.
			}
			else if (Caster.BodyMod == 183 || Caster.BodyMod == 184)
			{
				Caster.SendLocalizedMessage(1042512); // You cannot polymorph while wearing body paint
			}
			else if (!Caster.CanBeginAction(typeof(IncognitoSpell)) || Caster.IsBodyMod)
			{
				DoFizzle();
			}
			else if (CheckSequence())
			{
				if (Caster.BeginAction(typeof(PolymorphSpell)))
				{
					if (m_NewBody != 0)
					{
						if (!((Body)m_NewBody).IsHuman)
						{
							var mt = Caster.Mount;

							if (mt != null)
							{
								mt.Rider = null;
							}
						}

						Caster.BodyMod = m_NewBody;

						if (m_NewBody == 400 || m_NewBody == 401)
						{
							Caster.HueMod = Utility.RandomSkinHue();
						}
						else
						{
							Caster.HueMod = 0;
						}

						BaseArmor.ValidateMobile(Caster);
						BaseClothing.ValidateMobile(Caster);

						if (!Core.ML)
						{
							StopTimer(Caster);

							Timer t = new InternalTimer(Caster);

							m_Timers[Caster] = t;

							t.Start();
						}
					}
				}
				else
				{
					Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
				}
			}

			FinishSequence();
		}

		private static readonly Hashtable m_Timers = new Hashtable();

		public static bool StopTimer(Mobile m)
		{
			var t = (Timer)m_Timers[m];

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
			}

			return (t != null);
		}

		private static void EndPolymorph(Mobile m)
		{
			if (!m.CanBeginAction(typeof(PolymorphSpell)))
			{
				m.BodyMod = 0;
				m.HueMod = -1;
				m.EndAction(typeof(PolymorphSpell));

				BaseArmor.ValidateMobile(m);
				BaseClothing.ValidateMobile(m);
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Owner;

			public InternalTimer(Mobile owner) : base(TimeSpan.FromSeconds(0))
			{
				m_Owner = owner;

				var val = (int)owner.Skills[SkillName.Magery].Value;

				if (val > 120)
				{
					val = 120;
				}

				Delay = TimeSpan.FromSeconds(val);
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				EndPolymorph(m_Owner);
			}
		}
	}
}