using Server.Engines.Quests.Definitions;
using Server.Mobiles;

namespace Server.Engines.Quests.Items
{
	public class CrystalCaveBarrier : Item
	{
		[Constructable]
		public CrystalCaveBarrier() : base(0x3967)
		{
			Movable = false;
		}

		public override bool OnMoveOver(Mobile m)
		{
			if (m.AccessLevel > AccessLevel.Player)
			{
				return true;
			}

			var sendMessage = m.Player;

			if (m is BaseCreature)
			{
				m = ((BaseCreature)m).ControlMaster;
			}

			var pm = m as PlayerMobile;

			if (pm != null)
			{
				var qs = pm.Quest;

				if (qs is DarkTidesQuest)
				{
					var obj = qs.FindObjective(typeof(SpeakCavePasswordObjective_DarkTidesQuest));

					if (obj != null && obj.Completed)
					{
						if (sendMessage)
						{
							m.SendLocalizedMessage(1060648); // With Horus' permission, you are able to pass through the barrier.
						}

						return true;
					}
				}
			}

			if (sendMessage)
			{
				m.SendLocalizedMessage(1060649, "", 0x66D); // Without the permission of the guardian Horus, the magic of the barrier prevents your passage.
			}

			return false;
		}

		public CrystalCaveBarrier(Serial serial) : base(serial)
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

	public class VaultOfSecretsBarrier : Item
	{
		[Constructable]
		public VaultOfSecretsBarrier() : base(0x49E)
		{
			Movable = false;
			Visible = false;
		}

		public override bool OnMoveOver(Mobile m)
		{
			if (m.AccessLevel > AccessLevel.Player)
			{
				return true;
			}

			var pm = m as PlayerMobile;

			if (pm != null && pm.Profession == 4)
			{
				m.SendLocalizedMessage(1060188, "", 0x24); // The wicked may not enter!
				return false;
			}

			return base.OnMoveOver(m);
		}

		public VaultOfSecretsBarrier(Serial serial) : base(serial)
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

	public class GuardianBarrier : Item
	{
		[Constructable]
		public GuardianBarrier() : base(0x3967)
		{
			Movable = false;
			Visible = false;
		}

		public override bool OnMoveOver(Mobile m)
		{
			if (m.AccessLevel > AccessLevel.Player)
			{
				return true;
			}

			// If the mobile is to the north of the barrier, allow him to pass
			if (Y >= m.Y)
			{
				return true;
			}

			if (m is BaseCreature)
			{
				var master = ((BaseCreature)m).GetMaster();

				// Allow creatures to cross from the south to the north only if their master is near to the north
				if (master != null && Y >= master.Y && master.InRange(this, 4))
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			var pm = m as PlayerMobile;

			if (pm != null)
			{
				var qs = pm.Quest as EminosUndertakingQuest;

				if (qs != null)
				{
					var obj = qs.FindObjective(typeof(SneakPastGuardiansObjective_EminosUndertakingQuest)) as SneakPastGuardiansObjective_EminosUndertakingQuest;

					if (obj != null)
					{
						if (m.Hidden)
						{
							return true; // Hidden ninjas can pass
						}

						if (!obj.TaughtHowToUseSkills)
						{
							obj.TaughtHowToUseSkills = true;
							qs.AddConversation(new NeedToHideConversation_EminosUndertakingQuest());
						}
					}
				}
			}

			return false;
		}

		public GuardianBarrier(Serial serial) : base(serial)
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