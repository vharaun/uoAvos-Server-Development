using Server.ContextMenus;
using Server.Mobiles;
using Server.Targeting;

using System.Collections.Generic;

namespace Server.Items.Staff
{
	[FlipableAttribute(0x13F8, 0x13F9)]
	public class StaffOfAnnulment : BaseStaff
	{
		private Mobile m_Owner;
		public Point3D m_HomeLocation;
		public Map m_HomeMap;

		public static bool DeleteCorpse = true;
		public static bool DeleteItems = true;
		public static bool KillInvul = true;
		public static bool RemoveMobile = true;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool CanDeleteCorpse { get => DeleteCorpse; set => DeleteCorpse = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool CanDeleteItem { get => DeleteItems; set => DeleteItems = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool CanKillInvul { get => KillInvul; set => KillInvul = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool RemoveMobileThanKill { get => RemoveMobile; set => RemoveMobile = value; }

		[Constructable]
		public StaffOfAnnulment() : base(0x13F8)
		{
			LootType = LootType.Blessed;
			Weight = 5.0;
			Hue = 2406;
			Name = "An Unassigned Staff";

			Attributes.SpellChanneling = 1;
		}

		public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
		{
			phys = 0; fire = 0; cold = 0; nrgy = 100; chaos = 0; direct = 0;
			pois = 0;
		}

		public override void OnDoubleClick(Mobile m)
		{
			if (m_Owner == null && m.AccessLevel == AccessLevel.Player)
			{
				m.SendMessage("Only the server administration can use this item!");
				//this.Delete();
			}

			else if (m_Owner == null && m.AccessLevel == AccessLevel.Counselor)
			{
				m.SendMessage("Only the server administration can use this item!");
				//this.Delete();
			}

			else if (m_Owner == null && m.AccessLevel >= AccessLevel.Seer)
			{
				m_Owner = m;
				Name = m_Owner.Name.ToString() + "'s Staff of Annulment";
				HomeLocation = m.Location;
				HomeMap = m.Map;
				m.SendMessage("This staff have been assigned to you.");
			}
			else
			{
				if (m_Owner != m)
				{
					m.SendMessage("This item has not been assigned to you!");
					return;
				}
			}

			m.Target = new InternalTarget();
			m.SendMessage("");
		}

		private class InternalTarget : Target
		{
			public InternalTarget() : base(50, false, TargetFlags.None)
			{
			}
			protected override void OnTarget(Mobile mo, object tar)
			{
				if (tar is BaseMount)
				{
					var b = tar as BaseMount;
					if (RemoveMobile == true)
					{
						b.PlaySound(0x228);
						Effects.SendLocationEffect(new Point3D(b.X + 1, b.Y + 1, b.Z), b.Map, 0x3728, 13);
						b.Delete();
						mo.SendMessage("The targeted mount has been deleted!");
					}
					else if (b.Blessed == true && KillInvul == true && b.Hits != 0)
					{
						b.Blessed = false;
						b.BoltEffect(0);
						b.Kill();
						mo.SendMessage("The targeted mount has been killed!");
					}
					else if (b.Hits != 0 && b.Blessed == false)
					{
						b.BoltEffect(0);
						b.Kill();
						mo.SendMessage("The targeted mount has been killed!");
					}
					else if (b.Hits == 0)
					{
						b.PlaySound(0x214);
						b.FixedEffect(0x376A, 10, 16);
						b.ResurrectPet();
						b.Hits = b.HitsMax;
						mo.SendMessage("The targeted mount has been resurrected!");
					}
					else
					{
						mo.SendMessage("The targeted mount is invulnerable! You must set 'CanKillInvul' to 'true' in the '[props' of the Staff");
					}
				}
				else if (tar is PlayerMobile)
				{
					var m = tar as PlayerMobile;
					if (m != mo)
					{
						if (m.Blessed == true && KillInvul == true && m.Alive == true)
						{
							m.Blessed = false;
							m.BoltEffect(0);
							m.Kill();
							mo.SendMessage("The targeted player has been killed!");
						}
						else if (m.Blessed == false && m.Alive == true)
						{
							m.BoltEffect(0);
							m.Kill();
							mo.SendMessage("The targeted player has been killed!");
						}
						else if (m.Alive == false)
						{
							m.PlaySound(0x214);
							m.FixedEffect(0x376A, 10, 16);
							m.Resurrect();
							m.Hits = m.HitsMax;
							mo.SendMessage("The targeted player has been resurrected!");
						}
						else
						{
							mo.SendMessage("The targeted player is invulnerable! You must set 'CanKillInvul' to 'true' in the '[props' of the Staff");
						}
					}
					else
					{
						if (mo.Hidden == false)
						{
							mo.Hidden = false;
							mo.SendMessage("You must use the Collar of Visibility to hide your body!");
						}
						else
						{
							mo.Hidden = true;
							mo.SendMessage("You must use the Collar of Visibility to reveal yourself!");
						}
					}
				}
				else if (tar is Mobile)
				{
					var pm = tar as Mobile;
					if (RemoveMobile == true)
					{
						pm.PlaySound(0x228);
						Effects.SendLocationEffect(new Point3D(pm.X + 1, pm.Y + 1, pm.Z), pm.Map, 0x3728, 13);
						pm.Delete();
						mo.SendMessage("The targeted mobile has been deleted!");
					}
					else if (pm.Blessed == true && KillInvul == true && pm.Alive == true)
					{
						pm.Blessed = false;
						pm.BoltEffect(0);
						pm.Kill();
						mo.SendMessage("The targeted mobile has been removed!");
					}
					else if (pm.Blessed == false && pm.Alive == true)
					{
						pm.BoltEffect(0);
						pm.Kill();
						mo.SendMessage("The targeted mobile has been killed!");
					}
					else
					{
						mo.SendMessage("The targeted mobile is invulnerable! You must set 'CanKillInvul' to 'true' in the '[props' of the Staff");
					}
				}
				else if (tar is Corpse)
				{
					if (DeleteCorpse == true)
					{
						var c = tar as Corpse;
						mo.PlaySound(0x228);
						Effects.SendLocationEffect(new Point3D(c.X + 1, c.Y + 1, c.Z), c.Map, 0x3728, 13);
						c.Delete();
						mo.SendMessage("The targeted corpse has been deleted!");
					}
					else
					{
						mo.SendMessage("The targeted corpse cannot be removed! You must set 'CanDeleteCorpse' to 'true' in the '[props' of the Staff");
					}
				}
				else if (tar is Item)
				{
					if (DeleteItems == true)
					{
						var i = tar as Item;
						if (i is StaffOfAnnulment)
						{
							mo.SendMessage("The Staff Cannot Be Deleted!");
						}
						else
						{
							mo.PlaySound(0x228);
							Effects.SendLocationEffect(new Point3D(i.X + 1, i.Y + 1, i.Z), i.Map, 0x3728, 13);
							i.Delete();
							mo.SendMessage("The targeted item has been deleted!");
						}
					}
					else
					{
						mo.SendMessage("The targeted item cannot be removed! You must set 'CanDeleteItem' to 'true' in the [props of the Staff");
					}
				}
				else
				{
					mo.SendMessage("The staff refuses to delete this item!");
				}
			}
		}

		public StaffOfAnnulment(Serial serial) : base(serial)
		{
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D HomeLocation
		{
			get => m_HomeLocation;
			set => m_HomeLocation = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Map HomeMap
		{
			get => m_HomeMap;
			set => m_HomeMap = value;
		}

		private class GoHomeEntry : ContextMenuEntry
		{
			private readonly StaffOfAnnulment m_Item;
			private readonly Mobile m_Mobile;

			public GoHomeEntry(Mobile from, Item item) : base(5134) // uses "Goto Loc" entry
			{
				m_Item = (StaffOfAnnulment)item;
				m_Mobile = from;
			}

			public override void OnClick()
			{
				m_Mobile.Location = m_Item.HomeLocation;
				if (m_Item.HomeMap != null)
				{
					m_Mobile.Map = m_Item.HomeMap;
				}
			}
		}

		private class SetHomeEntry : ContextMenuEntry
		{
			private readonly StaffOfAnnulment m_Item;
			private readonly Mobile m_Mobile;

			public SetHomeEntry(Mobile from, Item item) : base(2055) // uses "Mark" entry
			{
				m_Item = (StaffOfAnnulment)item;
				m_Mobile = from;
			}

			public override void OnClick()
			{
				m_Item.HomeLocation = m_Mobile.Location;
				m_Item.HomeMap = m_Mobile.Map;
				m_Mobile.SendMessage("The home location on your staff has been set to your current position!");
			}
		}

		public static void GetContextMenuEntries(Mobile from, Item item, List<ContextMenuEntry> list)
		{
			list.Add(new GoHomeEntry(from, item));
			list.Add(new SetHomeEntry(from, item));
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			if (m_Owner == null)
			{
				return;
			}
			else
			{
				if (m_Owner != from)
				{
					from.SendMessage("This staff is not yours to use!");
					return;
				}
				else
				{
					base.GetContextMenuEntries(from, list);
					StaffOfAnnulment.GetContextMenuEntries(from, this, list);
				}
			}
		}

		public override bool OnEquip(Mobile from)
		{
			if (from.AccessLevel < AccessLevel.GameMaster)
			{
				from.SendMessage("This staff can only be used by server administrators!");
				Delete();
			}
			return true;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version

			writer.Write(m_HomeLocation);
			writer.Write(m_HomeMap);
			writer.Write(m_Owner);

			writer.Write(DeleteCorpse);
			writer.Write(DeleteItems);
			writer.Write(KillInvul);
			writer.Write(RemoveMobile);

		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_HomeLocation = reader.ReadPoint3D();
						m_HomeMap = reader.ReadMap();
						m_Owner = reader.ReadMobile();
					}
					goto case 0;
				case 0:
					{
						if (ItemID == 0x13F8)
						{
							ItemID = 0x13F9;
						}

						DeleteCorpse = reader.ReadBool();
						DeleteItems = reader.ReadBool();
						KillInvul = reader.ReadBool();
						RemoveMobile = reader.ReadBool();
					}
					break;
			}
		}
	}
}