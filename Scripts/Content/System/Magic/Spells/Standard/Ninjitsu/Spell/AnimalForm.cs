using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells.Magery;

using System;
using System.Collections;

namespace Server.Spells.Ninjitsu
{
	public class AnimalFormSpell : NinjitsuSpell
	{
		private static readonly Hashtable m_Table = new();
		private static readonly Hashtable m_LastAnimalForms = new();

		public static readonly AnimalFormEntry[] Entries =
		{
			new(typeof(Kirin),        1029632,  9632,    0, 1070811, 100.0,  0x84,     0,     0, false,  true, false),
			new(typeof(Unicorn),      1018214,  9678,    0, 1070812, 100.0,  0x7A,     0,     0, false,  true, false),
			new(typeof(BakeKitsune),  1030083, 10083,    0, 1070810,  82.5,  0xF6,     0,     0, false,  true, false),
			new(typeof(GreyWolf),     1028482,  9681, 2309, 1070810,  82.5,  0x19, 0x8FD, 0x90E, false,  true, false),
			new(typeof(Llama),        1028438,  8438,    0, 1070809,  70.0,  0xDC,     0,     0, false,  true, false),
			new(typeof(ForestOstard), 1018273,  8503, 2212, 1070809,  70.0,  0xDB, 0x899, 0x8B0, false,  true, false),
			new(typeof(BullFrog),     1028496,  8496, 2003, 1070807,  50.0,  0x51, 0x7D1, 0x7D6, false, false, false),
			new(typeof(GiantSerpent), 1018114,  9663, 2009, 1070808,  50.0,  0x15, 0x7D1, 0x7E2, false, false, false),
			new(typeof(Dog),          1018280,  8476, 2309, 1070806,  40.0,  0xD9, 0x8FD, 0x90E, false, false, false),
			new(typeof(Cat),          1018264,  8475, 2309, 1070806,  40.0,  0xC9, 0x8FD, 0x90E, false, false, false),
			new(typeof(Rat),          1018294,  8483, 2309, 1070805,  20.0,  0xEE, 0x8FD, 0x90E,  true, false, false),
			new(typeof(Rabbit),       1028485,  8485, 2309, 1070805,  20.0,  0xCD, 0x8FD, 0x90E,  true, false, false),
			new(typeof(Squirrel),     1031671, 11671,    0,       0,  20.0, 0x116,     0,     0, false, false, false),
			new(typeof(Ferret),       1031672, 11672,    0, 1075220,  40.0, 0x117,     0,     0, false, false,  true),
			new(typeof(CuSidhe),      1031670, 11670,    0, 1075221,  60.0, 0x115,     0,     0, false, false, false),
			new(typeof(Reptalon),     1075202, 11669,    0, 1075222,  90.0, 0x114,     0,     0, false, false, false),
		};

		public static void Initialize()
		{
			EventSink.Login += e =>
			{
				var context = GetContext(e.Mobile);

				if (context != null && context.SpeedBoost)
				{
					e.Mobile.Send(SpeedControl.MountSpeed);
				}
			};
		}

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.0);

		public override int CastRecoveryBase => (Core.ML ? 10 : base.CastRecoveryBase);

		public override bool BlockedByAnimalForm => false;

		private bool m_WasMoving;

		public AnimalFormSpell(Mobile caster, Item scroll)
			: base(caster, scroll, NinjitsuSpellName.AnimalForm)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (PolymorphSpell.IsPolymorphed(Caster))
			{
				Caster.SendLocalizedMessage(1061628); // You can't do that while polymorphed.
				return false;
			}
			
			if (TransformationSpellHelper.UnderTransformation(Caster))
			{
				Caster.SendLocalizedMessage(1063219); // You cannot mimic an animal while in that form.
				return false;
			}
			
			if (DisguiseTimers.IsDisguised(Caster))
			{
				Caster.SendLocalizedMessage(1061631); // You can't do that while disguised.
				return false;
			}

			return true;
		}

		public override bool CheckInterrupt(SpellInterrupt type, bool resistable)
		{
			return false;
		}

		private bool CasterIsMoving()
		{
			return Core.TickCount - Caster.LastMoveTime <= Caster.ComputeMovementSpeed(Caster.Direction);
		}

		public override void OnBeginCast()
		{
			base.OnBeginCast();

			Caster.FixedEffect(0x37C4, 10, 14, 4, 3);

			m_WasMoving = CasterIsMoving();
		}

		public override bool CheckFizzle()
		{
			// Spell is initially always successful, and with no skill gain.
			return true;
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var context = GetContext(Caster);

				if (context != null)
				{
					RemoveContext(Caster, context, true);
				}
				else if (Caster is PlayerMobile)
				{
					var skipGump = m_WasMoving || CasterIsMoving();

					if (GetLastAnimalForm(Caster) == -1 || !skipGump)
					{
						Caster.CloseGump(typeof(AnimalFormGump));
						Caster.SendGump(new AnimalFormGump(Caster, Entries, this));
					}
					else if (Morph(Caster, GetLastAnimalForm(Caster)) == MorphResult.Fail)
					{
						DoFizzle();
					}
					else
					{
						Caster.FixedParticles(0x3728, 10, 13, 2023, EffectLayer.Waist);
					}
				}
				else if (Morph(Caster, GetLastAnimalForm(Caster)) == MorphResult.Fail)
				{
					DoFizzle();
				}
				else
				{
					Caster.FixedParticles(0x3728, 10, 13, 2023, EffectLayer.Waist);
				}
			}

			FinishSequence();
		}

		public static int GetLastAnimalForm(Mobile m)
		{
			if (m_LastAnimalForms.Contains(m))
			{
				return (int)m_LastAnimalForms[m];
			}

			return -1;
		}

		public static MorphResult Morph(Mobile m, int entryID)
		{
			if (entryID < 0 || entryID >= Entries.Length)
			{
				return MorphResult.Fail;
			}

			var entry = Entries[entryID];

			m_LastAnimalForms[m] = entryID; //On OSI, it's the last /attempted/ one not the last succeeded one

			if (m.Skills.Ninjitsu.Value < entry.ReqSkill)
			{
				var args = String.Format("{0}\t{1}\t ", entry.ReqSkill.ToString("F1"), SkillName.Ninjitsu);
				m.SendLocalizedMessage(1063013, args); // You need at least ~1_SKILL_REQUIREMENT~ ~2_SKILL_NAME~ skill to use that ability.
				return MorphResult.NoSkill;
			}

			/*
			if( !m.CheckSkill( SkillName.Ninjitsu, entry.ReqSkill, entry.ReqSkill + 37.5 ) )
				return MorphResult.Fail;
			 *
			 * On OSI,it seems you can only gain starting at '0' using Animal form.
			*/

			var ninjitsu = m.Skills.Ninjitsu.Value;

			if (ninjitsu < entry.ReqSkill + 37.5)
			{
				var chance = (ninjitsu - entry.ReqSkill) / 37.5;

				if (chance < Utility.RandomDouble())
				{
					return MorphResult.Fail;
				}
			}

			m.CheckSkill(SkillName.Ninjitsu, 0.0, 37.5);

			if (!BaseFormTalisman.EntryEnabled(m, entry.Type))
			{
				return MorphResult.Success; // Still consumes mana, just no effect
			}

			BaseMount.Dismount(m);

			var bodyMod = entry.BodyMod;
			var hueMod = entry.HueMod;

			m.BodyMod = bodyMod;
			m.HueMod = hueMod;

			if (entry.SpeedBoost)
			{
				m.Send(SpeedControl.MountSpeed);
			}

			SkillMod mod = null;

			if (entry.StealthBonus)
			{
				mod = new DefaultSkillMod(SkillName.Stealth, true, 20.0) {
					ObeyCap = true
				};
				m.AddSkillMod(mod);
			}

			SkillMod stealingMod = null;

			if (entry.StealingBonus)
			{
				stealingMod = new DefaultSkillMod(SkillName.Stealing, true, 10.0) {
					ObeyCap = true
				};
				m.AddSkillMod(stealingMod);
			}

			Timer timer = new AnimalFormTimer(m, bodyMod, hueMod);
			timer.Start();

			AddContext(m, new AnimalFormContext(timer, mod, entry.SpeedBoost, entry.Type, stealingMod));
			m.CheckStatTimers();
			return MorphResult.Success;
		}

		public static void AddContext(Mobile m, AnimalFormContext context)
		{
			m_Table[m] = context;

			if (context.Type == typeof(BakeKitsune) || context.Type == typeof(GreyWolf))
			{
				m.CheckStatTimers();
			}
		}

		public static void RemoveContext(Mobile m, bool resetGraphics)
		{
			var context = GetContext(m);

			if (context != null)
			{
				RemoveContext(m, context, resetGraphics);
			}
		}

		public static void RemoveContext(Mobile m, AnimalFormContext context, bool resetGraphics)
		{
			m_Table.Remove(m);

			if (context.SpeedBoost)
			{
				m.Send(SpeedControl.Disable);
			}

			var mod = context.Mod;

			if (mod != null)
			{
				m.RemoveSkillMod(mod);
			}

			mod = context.StealingMod;

			if (mod != null)
			{
				m.RemoveSkillMod(mod);
			}

			if (resetGraphics)
			{
				m.HueMod = -1;
				m.BodyMod = 0;
			}

			m.FixedParticles(0x3728, 10, 13, 2023, EffectLayer.Waist);

			context.Timer.Stop();
		}

		public static AnimalFormContext GetContext(Mobile m)
		{
			return (m_Table[m] as AnimalFormContext);
		}

		public static bool UnderTransformation(Mobile m)
		{
			return (GetContext(m) != null);
		}

		public static bool UnderTransformation(Mobile m, Type type)
		{
			var context = GetContext(m);

			return (context != null && context.Type == type);
		}

		public enum MorphResult
		{
			Success,
			Fail,
			NoSkill
		}

		public class AnimalFormEntry
		{
			private readonly Type m_Type;
			private readonly TextDefinition m_Name;
			private readonly int m_ItemID;
			private readonly int m_Hue;
			private readonly int m_Tooltip;
			private readonly double m_ReqSkill;
			private readonly int m_BodyMod;
			private readonly int m_HueModMin;
			private readonly int m_HueModMax;
			private readonly bool m_StealthBonus;
			private readonly bool m_SpeedBoost;
			private readonly bool m_StealingBonus;

			public Type Type => m_Type;
			public TextDefinition Name => m_Name;
			public int ItemID => m_ItemID;
			public int Hue => m_Hue;
			public int Tooltip => m_Tooltip;
			public double ReqSkill => m_ReqSkill;
			public int BodyMod => m_BodyMod;
			public int HueMod => Utility.RandomMinMax(m_HueModMin, m_HueModMax);
			public bool StealthBonus => m_StealthBonus;
			public bool SpeedBoost => m_SpeedBoost;
			public bool StealingBonus => m_StealingBonus;

			public AnimalFormEntry(Type type, TextDefinition name, int itemID, int hue, int tooltip, double reqSkill, int bodyMod, int hueModMin, int hueModMax, bool stealthBonus, bool speedBoost, bool stealingBonus)
			{
				m_Type = type;
				m_Name = name;
				m_ItemID = itemID;
				m_Hue = hue;
				m_Tooltip = tooltip;
				m_ReqSkill = reqSkill;
				m_BodyMod = bodyMod;
				m_HueModMin = hueModMin;
				m_HueModMax = hueModMax;
				m_StealthBonus = stealthBonus;
				m_SpeedBoost = speedBoost;
				m_StealingBonus = stealingBonus;
			}
		}

		public class AnimalFormGump : Gump
		{
			//TODO: Convert this for ML to the BaseImageTileButtonsgump
			private readonly Mobile m_Caster;
			private readonly AnimalFormSpell m_Spell;

			public AnimalFormGump(Mobile caster, AnimalFormEntry[] entries, AnimalFormSpell spell)
				: base(50, 50)
			{
				m_Caster = caster;
				m_Spell = spell;

				AddPage(0);

				AddBackground(0, 0, 520, 404, 0x13BE);
				AddImageTiled(10, 10, 500, 20, 0xA40);
				AddImageTiled(10, 40, 500, 324, 0xA40);
				AddImageTiled(10, 374, 500, 20, 0xA40);
				AddAlphaRegion(10, 10, 500, 384);

				AddHtmlLocalized(14, 12, 500, 20, 1063394, 0x7FFF, false, false); // <center>Polymorph Selection Menu</center>

				AddButton(10, 374, 0xFB1, 0xFB2, 0, GumpButtonType.Reply, 0);
				AddHtmlLocalized(45, 376, 450, 20, 1011012, 0x7FFF, false, false); // CANCEL

				var ninjitsu = caster.Skills.Ninjitsu.Value;

				var current = 0;

				for (var i = 0; i < entries.Length; ++i)
				{
					var enabled = (ninjitsu >= entries[i].ReqSkill && BaseFormTalisman.EntryEnabled(caster, entries[i].Type));

					var page = current / 10 + 1;
					var pos = current % 10;

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

					if (enabled)
					{
						var x = (pos % 2 == 0) ? 14 : 264;
						var y = (pos / 2) * 64 + 44;

						var b = ItemBounds.Table[entries[i].ItemID];

						AddImageTiledButton(x, y, 0x918, 0x919, i + 1, GumpButtonType.Reply, 0, entries[i].ItemID, entries[i].Hue, 40 - b.Width / 2 - b.X, 30 - b.Height / 2 - b.Y, entries[i].Tooltip);
						AddHtmlLocalized(x + 84, y, 250, 60, entries[i].Name, 0x7FFF, false, false);

						current++;
					}
				}
			}

			public override void OnResponse(NetState sender, RelayInfo info)
			{
				var entryID = info.ButtonID - 1;

				if (entryID < 0 || entryID >= AnimalFormSpell.Entries.Length)
				{
					return;
				}

				var mana = m_Spell.GetManaRequirement(m_Spell.Info.Mana);
				var entry = AnimalFormSpell.Entries[entryID];

				if (mana > m_Caster.Mana)
				{
					m_Caster.SendLocalizedMessage(1060174, mana.ToString()); // You must have at least ~1_MANA_REQUIREMENT~ Mana to use this ability.
				}
				else if (m_Caster is PlayerMobile p && p.MountBlockReason != BlockMountType.None)
				{
					m_Caster.SendLocalizedMessage(1063108); // You cannot use this ability right now.
				}
				else if (BaseFormTalisman.EntryEnabled(sender.Mobile, entry.Type))
				{
					#region Dueling
					if (m_Caster is PlayerMobile pm && pm.DuelContext != null && !pm.DuelContext.AllowSpellCast(m_Caster, m_Spell))
					{
					}
					#endregion
					else if (Morph(m_Caster, entryID) == MorphResult.Fail)
					{
						m_Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 502632); // The spell fizzles.
						m_Caster.FixedParticles(0x3735, 1, 30, 9503, EffectLayer.Waist);
						m_Caster.PlaySound(0x5C);
					}
					else
					{
						m_Caster.FixedParticles(0x3728, 10, 13, 2023, EffectLayer.Waist);
						m_Caster.Mana -= mana;
					}
				}
			}
		}
	}

	public class AnimalFormContext
	{
		private readonly Timer m_Timer;
		private readonly SkillMod m_Mod;
		private readonly bool m_SpeedBoost;
		private readonly Type m_Type;
		private readonly SkillMod m_StealingMod;

		public Timer Timer => m_Timer;
		public SkillMod Mod => m_Mod;
		public bool SpeedBoost => m_SpeedBoost;
		public Type Type => m_Type;
		public SkillMod StealingMod => m_StealingMod;

		public AnimalFormContext(Timer timer, SkillMod mod, bool speedBoost, Type type, SkillMod stealingMod)
		{
			m_Timer = timer;
			m_Mod = mod;
			m_SpeedBoost = speedBoost;
			m_Type = type;
			m_StealingMod = stealingMod;
		}
	}

	public class AnimalFormTimer : Timer
	{
		private readonly Mobile m_Mobile;
		private readonly int m_Body;
		private readonly int m_Hue;
		private int m_Counter;
		private Mobile m_LastTarget;

		public AnimalFormTimer(Mobile from, int body, int hue)
			: base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
		{
			m_Mobile = from;
			m_Body = body;
			m_Hue = hue;
			m_Counter = 0;

			Priority = TimerPriority.FiftyMS;
		}

		protected override void OnTick()
		{
			if (m_Mobile.Deleted || !m_Mobile.Alive || m_Mobile.Body != m_Body || m_Mobile.Hue != m_Hue)
			{
				Stop();

				AnimalFormSpell.RemoveContext(m_Mobile, true);

				return;
			}

			if (m_Body == 0x115) // Cu Sidhe
			{
				if (m_Counter++ >= 8)
				{
					if (m_Mobile.Hits < m_Mobile.HitsMax && m_Mobile.Backpack != null)
					{
						var b = m_Mobile.Backpack.FindItemByType<Bandage>();

						if (b != null)
						{
							m_Mobile.Hits += Utility.RandomMinMax(20, 50);
							b.Consume();
						}
					}

					m_Counter = 0;
				}
			}
			else if (m_Body == 0x114) // Reptalon
			{
				if (m_Mobile.Combatant != null && m_Mobile.Combatant != m_LastTarget)
				{
					m_Counter = 1;
					m_LastTarget = m_Mobile.Combatant;
				}

				if (m_Mobile.Warmode && m_LastTarget != null && m_LastTarget.Alive && !m_LastTarget.Deleted && m_Counter-- <= 0)
				{
					if (m_Mobile.CanBeHarmful(m_LastTarget) && m_LastTarget.Map == m_Mobile.Map)
					{
						if (m_LastTarget.InRange(m_Mobile.Location, BaseCreature.DefaultRangePerception) && m_Mobile.InLOS(m_LastTarget))
						{
							m_Mobile.Direction = m_Mobile.GetDirectionTo(m_LastTarget);
							m_Mobile.Freeze(TimeSpan.FromSeconds(1));
							m_Mobile.PlaySound(0x16A);

							DelayCall(TimeSpan.FromSeconds(1.3), BreathEffect_Callback, m_LastTarget);
						}
					}

					m_Counter = Math.Min((int)m_Mobile.GetDistanceToSqrt(m_LastTarget), 10);
				}
			}
		}

		public void BreathEffect_Callback(Mobile target)
		{
			if (m_Mobile.CanBeHarmful(target))
			{
				m_Mobile.RevealingAction();
				m_Mobile.PlaySound(0x227);
				Effects.SendMovingEffect(m_Mobile, target, 0x36D4, 5, 0, false, false, 0, 0);

				DelayCall(TimeSpan.FromSeconds(1), BreathDamage_Callback, target);
			}
		}

		public void BreathDamage_Callback(Mobile target)
		{
			if (m_Mobile.CanBeHarmful(target))
			{
				m_Mobile.RevealingAction();
				m_Mobile.DoHarmful(target);
				AOS.Damage(target, m_Mobile, 20, !target.Player, 0, 100, 0, 0, 0);
			}
		}
	}
}