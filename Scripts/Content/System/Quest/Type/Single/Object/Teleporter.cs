using Server.Engines.Quests.Definitions;
using Server.Mobiles;

namespace Server.Engines.Quests.Items
{
	public abstract class DynamicTeleporter : Item
	{
		public override int LabelNumber => 1049382;  // a magical teleporter

		public DynamicTeleporter() : this(0x1822, 0x482)
		{
		}

		public DynamicTeleporter(int itemID, int hue) : base(itemID)
		{
			Movable = false;
			Hue = hue;
		}

		public abstract bool GetDestination(PlayerMobile player, ref Point3D loc, ref Map map);

		public virtual int NotWorkingMessage => 500309;  // Nothing Happens.

		public override bool OnMoveOver(Mobile m)
		{
			var pm = m as PlayerMobile;

			if (pm != null)
			{
				var loc = Point3D.Zero;
				Map map = null;

				if (GetDestination(pm, ref loc, ref map))
				{
					BaseCreature.TeleportPets(pm, loc, map);

					pm.PlaySound(0x1FE);
					pm.MoveToWorld(loc, map);

					return false;
				}
				else
				{
					pm.SendLocalizedMessage(NotWorkingMessage);
				}
			}

			return base.OnMoveOver(m);
		}

		public DynamicTeleporter(Serial serial) : base(serial)
		{
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
	}

	public class DarkTidesTeleporter : DynamicTeleporter
	{
		[Constructable]
		public DarkTidesTeleporter()
		{
		}

		public override bool GetDestination(PlayerMobile player, ref Point3D loc, ref Map map)
		{
			var qs = player.Quest;

			if (qs is DarkTidesQuest)
			{
				if (qs.IsObjectiveInProgress(typeof(FindMaabusTombObjective_DarkTidesQuest)))
				{
					loc = new Point3D(2038, 1263, -90);
					map = Map.Malas;
					qs.AddConversation(new NecroRadarConversation_DarkTidesQuest());
					return true;
				}
				else if (qs.IsObjectiveInProgress(typeof(FindCrystalCaveObjective_DarkTidesQuest)))
				{
					loc = new Point3D(1194, 521, -90);
					map = Map.Malas;
					return true;
				}
				else if (qs.IsObjectiveInProgress(typeof(FindCityOfLightObjective_DarkTidesQuest)))
				{
					loc = new Point3D(1091, 519, -90);
					map = Map.Malas;
					return true;
				}
				else if (qs.IsObjectiveInProgress(typeof(ReturnToCrystalCaveObjective_DarkTidesQuest)))
				{
					loc = new Point3D(1194, 521, -90);
					map = Map.Malas;
					return true;
				}
				else if (DarkTidesQuest.HasLostCallingScroll(player))
				{
					loc = new Point3D(1194, 521, -90);
					map = Map.Malas;
					return true;
				}
			}

			return false;
		}

		public DarkTidesTeleporter(Serial serial) : base(serial)
		{
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
	}

	public class BlueNinjaQuestTeleporter : DynamicTeleporter
	{
		public override int LabelNumber => 1026157;  // teleporter

		[Constructable]
		public BlueNinjaQuestTeleporter() : base(0x51C, 0x2)
		{
		}

		public override int NotWorkingMessage => 1063198;  // You stand on the strange floor tile but nothing happens.

		public override bool GetDestination(PlayerMobile player, ref Point3D loc, ref Map map)
		{
			var qs = player.Quest;

			if (qs is EminosUndertakingQuest && qs.FindObjective(typeof(GainInnInformationObjective_EminosUndertakingQuest)) != null)
			{
				loc = new Point3D(411, 1116, 0);
				map = Map.Malas;

				return true;
			}

			return false;
		}

		public BlueNinjaQuestTeleporter(Serial serial) : base(serial)
		{
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
	}

	public class GreenNinjaQuestTeleporter : DynamicTeleporter
	{
		public override int LabelNumber => 1026157;  // teleporter

		[Constructable]
		public GreenNinjaQuestTeleporter() : base(0x51C, 0x17E)
		{
		}

		public override int NotWorkingMessage => 1063198;  // You stand on the strange floor tile but nothing happens.

		public override bool GetDestination(PlayerMobile player, ref Point3D loc, ref Map map)
		{
			var qs = player.Quest;

			if (qs is EminosUndertakingQuest && qs.FindObjective(typeof(UseTeleporterObjective_EminosUndertakingQuest)) != null)
			{
				loc = new Point3D(410, 1125, 0);
				map = Map.Malas;

				return true;
			}

			return false;
		}

		public GreenNinjaQuestTeleporter(Serial serial) : base(serial)
		{
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
	}

	public class WhiteNinjaQuestTeleporter : DynamicTeleporter
	{
		public override int LabelNumber => 1026157;  // teleporter

		[Constructable]
		public WhiteNinjaQuestTeleporter() : base(0x51C, 0x47E)
		{
		}

		public override int NotWorkingMessage => 1063198;  // You stand on the strange floor tile but nothing happens.

		public override bool GetDestination(PlayerMobile player, ref Point3D loc, ref Map map)
		{
			var qs = player.Quest;

			if (qs is EminosUndertakingQuest)
			{
				var obj = qs.FindObjective(typeof(SearchForSwordObjective_EminosUndertakingQuest));

				if (obj != null)
				{
					if (!obj.Completed)
					{
						obj.Complete();
					}

					loc = new Point3D(411, 1085, 0);
					map = Map.Malas;

					return true;
				}
			}

			return false;
		}

		public WhiteNinjaQuestTeleporter(Serial serial) : base(serial)
		{
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
	}

	public class UzeraanTurmoilTeleporter : DynamicTeleporter
	{
		[Constructable]
		public UzeraanTurmoilTeleporter()
		{
		}

		public override bool GetDestination(PlayerMobile player, ref Point3D loc, ref Map map)
		{
			var qs = player.Quest;

			if (qs is UzeraanTurmoilQuest)
			{
				if (qs.IsObjectiveInProgress(typeof(FindSchmendrickObjective_UzeraanTurmoilQuest))
					|| qs.IsObjectiveInProgress(typeof(FindApprenticeObjective_UzeraanTurmoilQuest))
					|| UzeraanTurmoilQuest.HasLostScrollOfPower(player))
				{
					loc = new Point3D(5222, 1858, 0);
					map = Map.Trammel;
					return true;
				}
				else if (qs.IsObjectiveInProgress(typeof(FindDryadObjective_UzeraanTurmoilQuest))
					|| UzeraanTurmoilQuest.HasLostFertileDirt(player))
				{
					loc = new Point3D(3557, 2690, 2);
					map = Map.Trammel;
					return true;
				}
				else if (player.Profession != 5 // paladin
					&& (qs.IsObjectiveInProgress(typeof(GetDaemonBoneObjective_UzeraanTurmoilQuest))
					|| UzeraanTurmoilQuest.HasLostDaemonBone(player)))
				{
					loc = new Point3D(3422, 2653, 48);
					map = Map.Trammel;
					return true;
				}
				else if (qs.IsObjectiveInProgress(typeof(CashBankCheckObjective_UzeraanTurmoilQuest)))
				{
					loc = new Point3D(3624, 2610, 0);
					map = Map.Trammel;
					return true;
				}
			}

			return false;
		}

		public UzeraanTurmoilTeleporter(Serial serial) : base(serial)
		{
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
	}
}