using Server.ContextMenus;
using Server.Items;

using System.Collections.Generic;

namespace Server.Mobiles
{
	public abstract class BaseFamiliar : BaseCreature
	{
		public override bool BardImmune => true;
		public override Poison PoisonImmune => Poison.Lethal;
		public override bool Commandable => false;

		public override bool PlayerRangeSensitive => false;

		private bool m_LastHidden;

		public BaseFamiliar()
			: this(AIType.AI_Melee, FightMode.Closest, 10, 1, .1, .1)
		{
		}

		public BaseFamiliar(AIType ai, FightMode mode, int iRangePerception, int iRangeFight, double dActiveSpeed, double dPassiveSpeed)
			: base(ai, mode, iRangePerception, iRangeFight, dActiveSpeed, dPassiveSpeed)
		{
		}

		public BaseFamiliar(Serial serial) : base(serial)
		{
		}

		public virtual void RangeCheck()
		{
			if (!Deleted && ControlMaster != null && !ControlMaster.Deleted)
			{
				var range = (RangeHome - 2);

				if (!InRange(ControlMaster.Location, RangeHome))
				{
					var master = ControlMaster;

					var m_Loc = Point3D.Zero;

					if (Map == master.Map)
					{
						var x = (X > master.X) ? (master.X + range) : (master.X - range);
						var y = (Y > master.Y) ? (master.Y + range) : (master.Y - range);

						for (var i = 0; i < 10; i++)
						{
							m_Loc.X = x + Utility.RandomMinMax(-1, 1);
							m_Loc.Y = y + Utility.RandomMinMax(-1, 1);

							m_Loc.Z = Map.GetAverageZ(m_Loc.X, m_Loc.Y);

							if (Map.CanSpawnMobile(m_Loc))
							{
								break;
							}

							m_Loc = master.Location;
						}

						if (!Deleted)
						{
							SetLocation(m_Loc, true);
						}
					}
				}
			}
		}

		public override void OnThink()
		{
			var master = ControlMaster;

			if (Deleted)
			{
				return;
			}
			if (master == null || master.Deleted)
			{
				DropPackContents();
				EndRelease(null);
				return;
			}

			RangeCheck();

			if (m_LastHidden != master.Hidden)
			{
				Hidden = m_LastHidden = master.Hidden;
			}

			if (AIObject != null && AIObject.WalkMobileRange(master, 5, true, 1, 1))
			{
				Warmode = master.Warmode;
				Combatant = master.Combatant;

				CurrentSpeed = 0.10;
			}
			else
			{
				Warmode = false;
				FocusMob = Combatant = null;

				CurrentSpeed = .01;
			}
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			if (from.Alive && Controlled && from == ControlMaster && from.InRange(this, 14))
			{
				list.Add(new ReleaseEntry(from, this));
			}
		}

		public virtual void BeginRelease(Mobile from)
		{
			if (!Deleted && Controlled && from == ControlMaster && from.CheckAlive())
			{
				EndRelease(from);
			}
		}

		public virtual void EndRelease(Mobile from)
		{
			if (from == null || (!Deleted && Controlled && from == ControlMaster && from.CheckAlive()))
			{
				Effects.SendLocationParticles(EffectItem.Create(Location, Map, EffectItem.DefaultDuration), 0x3728, 1, 13, 2100, 3, 5042, 0);
				PlaySound(0x201);
				Delete();
			}
		}

		public virtual void DropPackContents()
		{
			var map = Map;
			var pack = Backpack;

			if (map != null && map != Map.Internal && pack != null)
			{
				var list = new List<Item>(pack.Items);

				for (var i = 0; i < list.Count; ++i)
				{
					list[i].MoveToWorld(Location, map);
				}
			}
		}

		public void Validate()
		{
			DropPackContents();
			Delete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			ValidationQueue<BaseFamiliar>.Add(this);
		}

		private class ReleaseEntry : ContextMenuEntry
		{
			private readonly Mobile m_From;
			private readonly BaseFamiliar m_Familiar;

			public ReleaseEntry(Mobile from, BaseFamiliar familiar) : base(6118, 14)
			{
				m_From = from;
				m_Familiar = familiar;
			}

			public override void OnClick()
			{
				if (!m_Familiar.Deleted && m_Familiar.Controlled && m_From == m_Familiar.ControlMaster && m_From.CheckAlive())
				{
					m_Familiar.BeginRelease(m_From);
				}
			}
		}
	}
}