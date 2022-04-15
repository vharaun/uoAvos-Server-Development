using Server.Engines.ChainQuests;
using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Items
{
	public class TransientItem : Item
	{
		private TimeSpan m_LifeSpan;

		[CommandProperty(AccessLevel.GameMaster)]
		public TimeSpan LifeSpan
		{
			get => m_LifeSpan;
			set => m_LifeSpan = value;
		}

		private DateTime m_CreationTime;

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime CreationTime
		{
			get => m_CreationTime;
			set => m_CreationTime = value;
		}

		private Timer m_Timer;

		public override bool Nontransferable => true;
		public override void HandleInvalidTransfer(Mobile from)
		{
			if (InvalidTransferMessage != null)
			{
				TextDefinition.SendMessageTo(from, InvalidTransferMessage);
			}

			Delete();
		}

		public virtual TextDefinition InvalidTransferMessage => null;


		public virtual void Expire(Mobile parent)
		{
			if (parent != null)
			{
				parent.SendLocalizedMessage(1072515, (Name == null ? String.Format("#{0}", LabelNumber) : Name)); // The ~1_name~ expired...
			}

			Effects.PlaySound(GetWorldLocation(), Map, 0x201);

			Delete();
		}

		public virtual void SendTimeRemainingMessage(Mobile to)
		{
			to.SendLocalizedMessage(1072516, String.Format("{0}\t{1}", (Name == null ? String.Format("#{0}", LabelNumber) : Name), (int)m_LifeSpan.TotalSeconds)); // ~1_name~ will expire in ~2_val~ seconds!
		}

		public override void OnDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			base.OnDelete();
		}

		public virtual void CheckExpiry()
		{
			if ((m_CreationTime + m_LifeSpan) < DateTime.UtcNow)
			{
				Expire(RootParent as Mobile);
			}
			else
			{
				InvalidateProperties();
			}
		}

		[Constructable]
		public TransientItem(int itemID, TimeSpan lifeSpan)
			: base(itemID)
		{
			m_CreationTime = DateTime.UtcNow;
			m_LifeSpan = lifeSpan;

			m_Timer = Timer.DelayCall(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5), CheckExpiry);
		}

		public TransientItem(Serial serial)
			: base(serial)
		{
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			var remaining = ((m_CreationTime + m_LifeSpan) - DateTime.UtcNow);

			list.Add(1072517, ((int)remaining.TotalSeconds).ToString()); // Lifespan: ~1_val~ seconds
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);

			writer.Write(m_LifeSpan);
			writer.Write(m_CreationTime);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			m_LifeSpan = reader.ReadTimeSpan();
			m_CreationTime = reader.ReadDateTime();

			m_Timer = Timer.DelayCall(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5), CheckExpiry);
		}
	}
}

namespace Server.Spells.Spellweaving
{
	public abstract class ArcanistSpell : Spell
	{
		public abstract double RequiredSkill { get; }
		public abstract int RequiredMana { get; }

		public override SkillName CastSkill => SkillName.Spellweaving;
		public override SkillName DamageSkill => SkillName.Spellweaving;

		public override bool ClearHandsOnCast => false;

		private int m_CastTimeFocusLevel;

		public ArcanistSpell(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{
		}

		public virtual int FocusLevel => m_CastTimeFocusLevel;

		public static int GetFocusLevel(Mobile from)
		{
			var focus = FindArcaneFocus(from);

			if (focus == null || focus.Deleted)
			{
				return 0;
			}

			return focus.StrengthBonus;
		}

		public static ArcaneFocus FindArcaneFocus(Mobile from)
		{
			if (from == null || from.Backpack == null)
			{
				return null;
			}

			if (from.Holding is ArcaneFocus)
			{
				return (ArcaneFocus)from.Holding;
			}

			return from.Backpack.FindItemByType<ArcaneFocus>();
		}

		public static bool CheckExpansion(Mobile from)
		{
			if (!(from is PlayerMobile))
			{
				return true;
			}

			if (from.NetState == null)
			{
				return false;
			}

			return from.NetState.SupportsExpansion(Expansion.ML);
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			var caster = Caster;

			if (!CheckExpansion(caster))
			{
				caster.SendLocalizedMessage(1072176); // You must upgrade to the Mondain's Legacy Expansion Pack before using that ability
				return false;
			}

			if (caster is PlayerMobile)
			{
				var context = ChainQuestSystem.GetContext((PlayerMobile)caster);

				if (context == null || !context.Spellweaving)
				{
					caster.SendLocalizedMessage(1073220); // You must have completed the epic arcanist quest to use this ability.
					return false;
				}
			}

			var mana = ScaleMana(RequiredMana);

			if (caster.Mana < mana)
			{
				caster.SendLocalizedMessage(1060174, mana.ToString()); // You must have at least ~1_MANA_REQUIREMENT~ Mana to use this ability.
				return false;
			}
			else if (caster.Skills[CastSkill].Value < RequiredSkill)
			{
				caster.SendLocalizedMessage(1063013, String.Format("{0}\t{1}", RequiredSkill.ToString("F1"), "#1044114")); // You need at least ~1_SKILL_REQUIREMENT~ ~2_SKILL_NAME~ skill to use that ability.
				return false;
			}

			return true;
		}

		public override void GetCastSkills(out double min, out double max)
		{
			min = RequiredSkill - 12.5; //per 5 on friday, 2/16/07
			max = RequiredSkill + 37.5;
		}

		public override int GetMana()
		{
			return RequiredMana;
		}

		public override void DoFizzle()
		{
			Caster.PlaySound(0x1D6);
			Caster.NextSpellTime = Core.TickCount;
		}

		public override void DoHurtFizzle()
		{
			Caster.PlaySound(0x1D6);
		}

		public override void OnDisturb(DisturbType type, bool message)
		{
			base.OnDisturb(type, message);

			if (message)
			{
				Caster.PlaySound(0x1D6);
			}
		}

		public override void OnBeginCast()
		{
			base.OnBeginCast();

			SendCastEffect();
			m_CastTimeFocusLevel = GetFocusLevel(Caster);
		}

		public virtual void SendCastEffect()
		{
			Caster.FixedEffect(0x37C4, 10, (int)(GetCastDelay().TotalSeconds * 28), 4, 3);
		}

		public virtual bool CheckResisted(Mobile m)
		{
			var percent = (50 + 2 * (GetResistSkill(m) - GetDamageSkill(Caster))) / 100; //TODO: According to the guide this is it.. but.. is it correct per OSI?

			if (percent <= 0)
			{
				return false;
			}

			if (percent >= 1.0)
			{
				return true;
			}

			return (percent >= Utility.RandomDouble());
		}
	}

	public abstract class ArcaneForm : ArcanistSpell, ITransformationSpell
	{
		public abstract int Body { get; }
		public virtual int Hue => 0;

		public virtual int PhysResistOffset => 0;
		public virtual int FireResistOffset => 0;
		public virtual int ColdResistOffset => 0;
		public virtual int PoisResistOffset => 0;
		public virtual int NrgyResistOffset => 0;

		public ArcaneForm(Mobile caster, Item scroll, SpellInfo info) : base(caster, scroll, info)
		{
		}

		public override bool CheckCast()
		{
			if (!TransformationSpellHelper.CheckCast(Caster, this))
			{
				return false;
			}

			return base.CheckCast();
		}

		public override void OnCast()
		{
			TransformationSpellHelper.OnCast(Caster, this);

			FinishSequence();
		}

		public virtual double TickRate => 1.0;

		public virtual void OnTick(Mobile m)
		{
		}

		public virtual void DoEffect(Mobile m)
		{
		}

		public virtual void RemoveEffect(Mobile m)
		{
		}
	}

	public abstract class ArcaneSummon<T> : ArcanistSpell where T : BaseCreature
	{
		public abstract int Sound { get; }

		public ArcaneSummon(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if ((Caster.Followers + 1) > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1074270); // You have too many followers to summon another one.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var duration = TimeSpan.FromMinutes(Caster.Skills.Spellweaving.Value / 24 + FocusLevel * 2);
				var summons = Math.Min(1 + FocusLevel, Caster.FollowersMax - Caster.Followers);

				for (var i = 0; i < summons; i++)
				{
					BaseCreature bc;

					try { bc = Activator.CreateInstance<T>(); }
					catch { break; }

					SpellHelper.Summon(bc, Caster, Sound, duration, false, false);
				}

				FinishSequence();
			}
		}
	}
}