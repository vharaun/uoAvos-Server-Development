using Server.Items;
using Server.Spells.Magery;
using Server.Spells.Ninjitsu;
using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Spells.Mysticism
{
	public enum PurgeMagicType
	{
		None,
		MagicReflect,
		ReactiveArmor,
		Protection,
		Transformation,
		StrBonus,
		DexBonus,
		IntBonus,
		Bless,
	}

	public class PurgeMagicSpell : MysticismSpell
	{
		private static readonly Dictionary<Mobile, ImmuneTimer> m_ImmuneTable = new();
		private static readonly Dictionary<Mobile, CurseTimer> m_CurseTable = new();

		public PurgeMagicSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.PurgeMagic)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void OnTarget(Mobile target)
		{
			if (!Caster.CanSee(target))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (m_CurseTable.ContainsKey(Caster))
			{
				Caster.SendLocalizedMessage(1154212); //You may not use the Purge Magic spell while you are under its curse.
			}
			else if (m_ImmuneTable.ContainsKey(target) || m_CurseTable.ContainsKey(target))
			{
				Caster.SendLocalizedMessage(1080119); // Your Purge Magic has been resisted!
			}
			else if (CheckHSequence(target))
			{
				if (CheckResisted(target))
				{
					target.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
					Caster.SendLocalizedMessage(1080119); //Your Purge Magic has been resisted!
				}
				else
				{
					_ = SpellHelper.CheckReflect((int)Circle, Caster, ref target);

					Caster.PlaySound(0x655);

					Effects.SendLocationParticles(EffectItem.Create(target.Location, target.Map, EffectItem.DefaultDuration), 0x3728, 1, 13, 0x834, 0, 0x13B2, 0);

					var type = GetRandomBuff(target);

					if (type != PurgeMagicType.None)
					{
						var arg = String.Empty;

						switch (type)
						{
							case PurgeMagicType.MagicReflect:
								MagicReflectSpell.EndReflect(target);
								arg = "magic reflect";
								break;
							case PurgeMagicType.ReactiveArmor:
								ReactiveArmorSpell.EndArmor(target);
								arg = "reactive armor";
								break;
							case PurgeMagicType.Protection:
								ProtectionSpell.EndProtection(target);
								arg = "protection";
								break;
							case PurgeMagicType.Transformation:
								TransformationSpellHelper.RemoveContext(target, true);
								arg = "transformation spell";
								break;
							case PurgeMagicType.StrBonus:
								arg = "strength bonus";
								_ = SpellHelper.RemoveStatBonus(target, StatType.Str);
								BuffInfo.RemoveBuff(target, BuffIcon.Strength);
								break;
							case PurgeMagicType.DexBonus:
								arg = "dexterity bonus";
								_ = SpellHelper.RemoveStatBonus(target, StatType.Dex);
								BuffInfo.RemoveBuff(target, BuffIcon.Agility);
								break;
							case PurgeMagicType.IntBonus:
								arg = "intelligence bonus";
								_ = SpellHelper.RemoveStatBonus(target, StatType.Int);
								BuffInfo.RemoveBuff(target, BuffIcon.Cunning);
								break;
							case PurgeMagicType.Bless:
								arg = "bless";
								_ = SpellHelper.RemoveStatBonus(target, StatType.Str);
								_ = SpellHelper.RemoveStatBonus(target, StatType.Dex);
								_ = SpellHelper.RemoveStatBonus(target, StatType.Int);

								BuffInfo.RemoveBuff(target, BuffIcon.Bless);
								break;
						}

						target.SendLocalizedMessage(1080117, arg); //Your ~1_ABILITY_NAME~ has been purged.
						Caster.SendLocalizedMessage(1080118, arg); //Your target's ~1_ABILITY_NAME~ has been purged.

						var duration = (int)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 15);

						if (duration <= 0)
						{
							duration = 1;
						}

						m_ImmuneTable.Add(target, new ImmuneTimer(target, TimeSpan.FromSeconds(duration)));
					}
					else
					{
						Caster.SendLocalizedMessage(1080120); //Your target has no magic that can be purged.

						var duration = (int)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 28);

						if (duration <= 0)
						{
							duration = 1;
						}

						m_CurseTable.Add(target, new CurseTimer(target, Caster, TimeSpan.FromSeconds(duration)));
					}
				}
			}

			FinishSequence();
		}

		public static PurgeMagicType GetRandomBuff(Mobile target)
		{
			var buffs = new List<PurgeMagicType>();

			if (MagicReflectSpell.HasReflect(target))
			{
				buffs.Add(PurgeMagicType.MagicReflect);
			}

			if (ReactiveArmorSpell.HasArmor(target))
			{
				buffs.Add(PurgeMagicType.ReactiveArmor);
			}

			if (ProtectionSpell.HasProtection(target))
			{
				buffs.Add(PurgeMagicType.Protection);
			}

			var context = TransformationSpellHelper.GetContext(target);

			if (context != null && context.Type != typeof(AnimalFormSpell))
			{
				buffs.Add(PurgeMagicType.Transformation);
			}

			var strMod = target.GetStatMod("[Magic] Str Offset");
			var dexMod = target.GetStatMod("[Magic] Dex Offset");
			var intMod = target.GetStatMod("[Magic] Int Offset");

			if (strMod?.Offset > 0 && dexMod?.Offset > 0 && intMod?.Offset > 0)
			{
				buffs.Add(PurgeMagicType.Bless);
			}
			else
			{
				if (strMod?.Offset > 0)
				{
					buffs.Add(PurgeMagicType.StrBonus);
				}

				if (dexMod?.Offset > 0)
				{
					buffs.Add(PurgeMagicType.DexBonus);
				}

				if (intMod?.Offset > 0)
				{
					buffs.Add(PurgeMagicType.IntBonus);
				}
			}

			if (buffs.Count == 0)
			{
				return PurgeMagicType.None;
			}

			var type = Utility.RandomList(buffs);

			buffs.Clear();

			return type;
		}

		public static void RemoveImmunity(Mobile from)
		{
			if (m_ImmuneTable.TryGetValue(from, out var t))
			{
				t?.Stop();

				_ = m_ImmuneTable.Remove(from);
			}
		}

		public static void RemoveCurse(Mobile from, Mobile caster)
		{
			if (m_CurseTable.ContainsKey(from))
			{
				m_CurseTable[from].Stop();

				if (DateTime.UtcNow > m_CurseTable[from].StartTime)
				{
					var inEffect = DateTime.UtcNow - m_CurseTable[from].StartTime;

					var damage = 5 * (int)inEffect.TotalSeconds;

					from.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
					from.PlaySound(0x307);

					_ = m_CurseTable.Remove(from);

					_ = AOS.Damage(from, caster, damage, 20, 20, 20, 20, 20);
				}
			}

			var t = new ImmuneTimer(from, TimeSpan.FromSeconds(16));

			m_ImmuneTable[from] = t;

			t.Start();
		}

		public static void OnMobileDoDamage(Mobile from)
		{
			if (from != null && m_CurseTable.TryGetValue(from, out var t))
			{
				RemoveCurse(from, t.Caster);
			}
		}

		public static bool IsUnderCurseEffects(Mobile from)
		{
			return m_CurseTable.ContainsKey(from);
		}

		private class ImmuneTimer : Timer
		{
			private readonly Mobile m_Mobile;

			public ImmuneTimer(Mobile mob, TimeSpan duration) 
				: base(duration)
			{
				m_Mobile = mob;

				Start();
			}

			protected override void OnTick()
			{
				RemoveImmunity(m_Mobile);
			}
		}

		private class CurseTimer : Timer
		{
			private readonly Mobile m_Mobile;

			public DateTime StartTime { get; }
			public Mobile Caster { get; }

			public CurseTimer(Mobile mob, Mobile caster, TimeSpan duration)
				: base(duration)
			{
				m_Mobile = mob;
				Caster = caster;
				StartTime = DateTime.UtcNow;
			}

			protected override void OnTick()
			{
				RemoveCurse(m_Mobile, Caster);
			}
		}

		public class InternalTarget : Target
		{
			public PurgeMagicSpell Owner { get; set; }

			public InternalTarget(PurgeMagicSpell owner)
				: this(owner, false)
			{
			}

			public InternalTarget(PurgeMagicSpell owner, bool allowland)
				: base(12, allowland, TargetFlags.Harmful)
			{
				Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile m)
				{
					Owner.OnTarget(m);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				Owner.FinishSequence();
			}
		}
	}
}
