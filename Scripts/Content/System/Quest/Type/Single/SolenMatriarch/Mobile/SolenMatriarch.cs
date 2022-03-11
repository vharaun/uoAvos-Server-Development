using Server.ContextMenus;
using Server.Engines.Plants;
using Server.Engines.Quests.Definitions;
using Server.Engines.Quests.Items;
using Server.Mobiles;
using Server.Targeting;

using System.Collections.Generic;

namespace Server.Engines.Quests.Mobiles
{
	public abstract class BaseSolenMatriarch : BaseQuester
	{
		public abstract bool RedSolen { get; }

		public override bool DisallowAllMoves => false;

		public BaseSolenMatriarch()
		{
			Name = "the solen matriarch";

			Body = 0x328;

			if (!RedSolen)
			{
				Hue = 0x44E;
			}

			SpeechHue = 0;
		}

		public override int GetIdleSound()
		{
			return 0x10D;
		}

		public override bool CanTalkTo(PlayerMobile to)
		{
			if (SolenMatriarchQuest.IsFriend(to, RedSolen))
			{
				return true;
			}

			var qs = to.Quest as SolenMatriarchQuest;

			return qs != null && qs.RedSolen == RedSolen;
		}

		public override void OnTalk(PlayerMobile player, bool contextMenu)
		{
			Direction = GetDirectionTo(player);

			var qs = player.Quest as SolenMatriarchQuest;

			if (qs != null && qs.RedSolen == RedSolen)
			{
				if (qs.IsObjectiveInProgress(typeof(KillInfiltratorsObjective_SolenMatriarchQuest)))
				{
					qs.AddConversation(new DuringKillInfiltratorsConversation_SolenMatriarchQuest());
				}
				else
				{
					var obj = qs.FindObjective(typeof(ReturnAfterKillsObjective_SolenMatriarchQuest));

					if (obj != null && !obj.Completed)
					{
						obj.Complete();
					}
					else if (qs.IsObjectiveInProgress(typeof(GatherWaterObjective_SolenMatriarchQuest)))
					{
						qs.AddConversation(new DuringWaterGatheringConversation_SolenMatriarchQuest());
					}
					else
					{
						obj = qs.FindObjective(typeof(ReturnAfterWaterObjective_SolenMatriarchQuest));

						if (obj != null && !obj.Completed)
						{
							obj.Complete();
						}
						else if (qs.IsObjectiveInProgress(typeof(ProcessFungiObjective_SolenMatriarchQuest)))
						{
							qs.AddConversation(new DuringFungiProcessConversation_SolenMatriarchQuest());
						}
						else
						{
							obj = qs.FindObjective(typeof(GetRewardObjective_SolenMatriarchQuest));

							if (obj != null && !obj.Completed)
							{
								if (SolenMatriarchQuest.GiveRewardTo(player))
								{
									obj.Complete();
								}
								else
								{
									qs.AddConversation(new FullBackpackConversation_SolenMatriarchQuest(false));
								}
							}
						}
					}
				}
			}
			else if (SolenMatriarchQuest.IsFriend(player, RedSolen))
			{
				QuestSystem newQuest = new SolenMatriarchQuest(player, RedSolen);

				if (player.Quest == null && QuestSystem.CanOfferQuest(player, typeof(SolenMatriarchQuest)))
				{
					newQuest.SendOffer();
				}
				else
				{
					newQuest.AddConversation(new DontOfferConversation_SolenMatriarchQuest(true));
				}
			}
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			var player = from as PlayerMobile;

			if (player != null)
			{
				if (dropped is Seed)
				{
					var qs = player.Quest as SolenMatriarchQuest;

					if (qs != null && qs.RedSolen == RedSolen)
					{
						SayTo(player, 1054080); // Thank you for that plant seed. Those have such wonderful flavor.
					}
					else
					{
						QuestSystem newQuest = new SolenMatriarchQuest(player, RedSolen);

						if (player.Quest == null && QuestSystem.CanOfferQuest(player, typeof(SolenMatriarchQuest)))
						{
							newQuest.SendOffer();
						}
						else
						{
							newQuest.AddConversation(new DontOfferConversation_SolenMatriarchQuest(SolenMatriarchQuest.IsFriend(player, RedSolen)));
						}
					}

					dropped.Delete();
					return true;
				}
				else if (dropped is ZoogiFungus)
				{
					OnGivenFungi(player, (ZoogiFungus)dropped);

					return dropped.Deleted;
				}
			}

			return base.OnDragDrop(from, dropped);
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			if (from.Alive)
			{
				var pm = from as PlayerMobile;

				if (pm != null)
				{
					var qs = pm.Quest as SolenMatriarchQuest;

					if (qs != null && qs.RedSolen == RedSolen)
					{
						if (qs.IsObjectiveInProgress(typeof(ProcessFungiObjective_SolenMatriarchQuest)))
						{
							list.Add(new ProcessZoogiFungusEntry(this, pm));
						}
					}
				}
			}
		}

		private class ProcessZoogiFungusEntry : ContextMenuEntry
		{
			private readonly BaseSolenMatriarch m_Matriarch;
			private readonly PlayerMobile m_From;

			public ProcessZoogiFungusEntry(BaseSolenMatriarch matriarch, PlayerMobile from) : base(6184)
			{
				m_Matriarch = matriarch;
				m_From = from;
			}

			public override void OnClick()
			{
				if (m_From.Alive)
				{
					m_From.Target = new ProcessFungiTarget(m_Matriarch, m_From);
				}
			}
		}

		private class ProcessFungiTarget : Target
		{
			private readonly BaseSolenMatriarch m_Matriarch;
			private readonly PlayerMobile m_From;

			public ProcessFungiTarget(BaseSolenMatriarch matriarch, PlayerMobile from) : base(-1, false, TargetFlags.None)
			{
				m_Matriarch = matriarch;
				m_From = from;
			}

			protected override void OnTargetCancel(Mobile from, TargetCancelType cancelType)
			{
				from.SendLocalizedMessage(1042021, "", 0x59); // Cancelled.
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (targeted is ZoogiFungus)
				{
					var fungus = (ZoogiFungus)targeted;

					if (fungus.IsChildOf(m_From.Backpack))
					{
						m_Matriarch.OnGivenFungi(m_From, (ZoogiFungus)targeted);
					}
					else
					{
						m_From.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
					}
				}
			}
		}

		public void OnGivenFungi(PlayerMobile player, ZoogiFungus fungi)
		{
			Direction = GetDirectionTo(player);

			var qs = player.Quest as SolenMatriarchQuest;

			if (qs != null && qs.RedSolen == RedSolen)
			{
				var obj = qs.FindObjective(typeof(ProcessFungiObjective_SolenMatriarchQuest));

				if (obj != null && !obj.Completed)
				{
					var amount = fungi.Amount / 2;

					if (amount > 100)
					{
						amount = 100;
					}

					if (amount > 0)
					{
						if (amount * 2 >= fungi.Amount)
						{
							fungi.Delete();
						}
						else
						{
							fungi.Amount -= amount * 2;
						}

						var powder = new PowderOfTranslocation(amount);
						player.AddToBackpack(powder);

						player.SendLocalizedMessage(1054100); // You receive some powder of translocation.

						obj.Complete();
					}
				}
			}
		}

		public BaseSolenMatriarch(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	public class RedSolenMatriarch : BaseSolenMatriarch
	{
		public override bool RedSolen => true;

		[Constructable]
		public RedSolenMatriarch()
		{
		}

		public RedSolenMatriarch(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	public class BlackSolenMatriarch : BaseSolenMatriarch
	{
		public override bool RedSolen => false;

		[Constructable]
		public BlackSolenMatriarch()
		{
		}

		public BlackSolenMatriarch(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}