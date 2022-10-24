using System;

namespace Server.Spells.Mysticism
{
	public class StoneFormSpell : MysticismTransformation
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.5);

		public override Body Body => 0x2C1;

		public override int PhysResistOffset => GetResistOffset(Caster);
		public override int FireResistOffset => GetResistOffset(Caster);
		public override int ColdResistOffset => GetResistOffset(Caster);
		public override int PoisResistOffset => GetResistOffset(Caster);
		public override int NrgyResistOffset => GetResistOffset(Caster);

		public StoneFormSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.StoneForm)
		{
		}

		public override void DoEffect(Mobile m)
		{
			var offset = GetResistOffset(m);
			var cap = GetResistCapBonus(m);
			var bonus = GetDIBonus(Caster);

			Caster.PlaySound(0x65A);
			Caster.Delta(MobileDelta.Resistances);

			BuffInfo.AddBuff(Caster, new BuffInfo(BuffIcon.StoneForm, 1080145, 1080146, $"-10\t-2\t{offset}\t{cap}\t{bonus}", false));
		}

		public override void RemoveEffect(Mobile m)
		{
			m.PlaySound(0xFA);

			m.Delta(MobileDelta.Resistances);

			BuffInfo.RemoveBuff(m, BuffIcon.StoneForm);
		}

		public static bool UnderTransformation(Mobile m)
		{
			return TransformationSpellHelper.UnderTransformation(m, typeof(StoneFormSpell));
		}

		public static int GetResistOffset(Mobile m)
		{
			return (int)((GetBaseSkill(m) + GetBoostSkill(m)) / 24.0);
		}

		public static int GetDIBonus(Mobile m)
		{
			return (int)((GetBaseSkill(m) + GetBoostSkill(m)) / 12.0);
		}

		public static int GetResistCapBonus(Mobile m)
		{
			return (int)((GetBaseSkill(m) + GetBoostSkill(m)) / 48.0);
		}
	}
}