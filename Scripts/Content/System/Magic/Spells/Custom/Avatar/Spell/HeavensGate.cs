using Server.Items;
using Server.Network;
using Server.Targeting;

using System;

namespace Server.Spells.Avatar
{
	public class DivineGatewaySpell : AvatarSpell
	{
		private readonly RunebookEntry m_Entry;

		private static readonly (sbyte, sbyte, sbyte, ushort, ushort)[] m_Offsets =
		{
			(-1, -1, 00, 14138, 1174),
			(00, 00, 00, 6899, 1153),
			(-1, +1, 00, 14138, 1174),
			(+1, -1, 00, 14138, 1174),
			(+1, +1, 00, 14170, 1174),
		};

		public DivineGatewaySpell(Mobile caster, Item scroll)
			: this(caster, scroll, null)
		{
		}

		public DivineGatewaySpell(Mobile caster, Item scroll, RunebookEntry entry)
			: base(caster, scroll, AvatarSpellName.DivineGateway)
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
			if (Caster.Criminal)
			{
				Caster.SendLocalizedMessage(1005561, "", 0x22); // Thou'rt a criminal and cannot escape so easily.
				return false;
			}

			if (SpellHelper.CheckCombat(Caster))
			{
				Caster.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle??
				return false;
			}

			return SpellHelper.CheckTravel(Caster, TravelCheckType.GateFrom);
		}

		public void Effect(Point3D loc, Map map, bool checkMulti)
		{
			if (map == null || (!Core.AOS && Caster.Map != map))
			{
				Caster.SendLocalizedMessage(1005570); // You can not gate to another facet.
			}
			else if (!SpellHelper.CheckTravel(Caster, TravelCheckType.GateFrom))
			{
			}
			else if (!SpellHelper.CheckTravel(Caster, map, loc, TravelCheckType.GateTo))
			{
			}
			else if (Caster.Murderer && map != Map.Felucca)
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
			else if (checkMulti && SpellHelper.CheckMulti(loc, map))
			{
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			}
			else if (CheckSequence())
			{
				Caster.SendMessage("The clouds open a divine gate to another place");

				Effects.PlaySound(Caster.Location, Caster.Map, 0x482);

				Caster.PlaySound(0x212);
				Caster.PlaySound(0x206);

				var duration = 30.0; // seconds

				foreach (var (x, y, z, itemID, hue) in m_Offsets)
				{
					var p1 = new Point3D(Caster.X + x, Caster.Y + y, Caster.Z + z);

					if (SpellHelper.AdjustField(ref p1, Caster.Map, 22, false))
					{
						var gate1 = new InternalItem(itemID, hue, loc, map, duration);

						gate1.MoveToWorld(p1, Caster.Map);
					}

					var p2 = new Point3D(loc.X + x, loc.Y + y, loc.Z + z);

					if (SpellHelper.AdjustField(ref p2, map, 22, false))
					{
						var gate2 = new InternalItem(itemID, hue, Caster.Location, Caster.Map, duration);

						gate2.MoveToWorld(p2, map);
					}
				}
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Moongate
		{
			private InternalTimer m_Timer;

			public override bool ShowFeluccaWarning => Core.AOS;

			public InternalItem(int itemID, int hue, Point3D target, Map map, double duration)
				: base(target, map)
			{
				ItemID = itemID;
				Hue = hue;

				Dispellable = true;

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(duration));
				m_Timer.Start();
			}

			public InternalItem(Serial serial)
				: base(serial)
			{
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				m_Timer?.Stop();
				m_Timer = null;
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(0); // version

				if (m_Timer?.Running == true)
				{
					writer.Write(m_Timer.Next - DateTime.UtcNow);
				}
				else
				{
					writer.Write(TimeSpan.Zero);
				}
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				_ = reader.ReadInt();

				var duration = reader.ReadTimeSpan();

				if (duration > TimeSpan.Zero)
				{
					m_Timer = new InternalTimer(this, duration);
				}
				else
				{
					m_Timer = new InternalTimer(this, TimeSpan.Zero);
				}

				m_Timer.Start();
			}

			private class InternalTimer : Timer
			{
				private readonly InternalItem m_Item;

				public InternalTimer(InternalItem item, TimeSpan duration)
					: base(duration)
				{
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
			private readonly DivineGatewaySpell m_Owner;

			public InternalTarget(DivineGatewaySpell owner) : base(12, false, TargetFlags.None)
			{
				m_Owner = owner;

				owner.Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 501029); // Select Marked item.
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is RecallRune rune)
				{
					if (rune.Marked)
					{
						m_Owner.Effect(rune.Target, rune.TargetMap, true);
					}
					else
					{
						from.SendLocalizedMessage(501803); // That rune is not yet marked.
					}
				}
				else if (o is Runebook rb)
				{
					var e = rb.Default;

					if (e != null)
					{
						m_Owner.Effect(e.Location, e.Map, true);
					}
					else
					{
						from.SendLocalizedMessage(502354); // Target is not marked.
					}
				}
				else
				{
					from.SendLocalizedMessage(501030); // I can not gate travel from that object.
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}

