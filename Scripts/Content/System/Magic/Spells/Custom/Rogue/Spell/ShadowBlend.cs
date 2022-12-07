using System.Collections.Generic;

namespace Server.Spells.Rogue
{
	public class ShadowBlendSpell : ClericTransformation
	{
		private static readonly Dictionary<Mobile, SkillMod> m_Table = new();

		public override Body Body => 0;

		public ShadowBlendSpell(Mobile caster, Item scroll)
			: base(caster, scroll, RogueSpellName.ShadowBlend)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (Caster.Hidden || m_Table.ContainsKey(Caster))
			{
				Caster.SendMessage("You are already in the shadows!");
				return false;
			}

			return true;
		}

		public override void OnTick(Mobile m)
		{
			if (!m.Hidden)
			{
				TransformationSpellHelper.RemoveContext<ShadowBlendSpell>(m, true);
			}
		}

		public override void DoEffect(Mobile m)
		{
			if (!m_Table.ContainsKey(m))
			{
				Caster.Hidden = true;

				var mod = new DefaultSkillMod(SkillName.Stealth, true, 50.0);

				m_Table[Caster] = mod;

				Caster.AddSkillMod(mod);
			}
		}

		public override void RemoveEffect(Mobile m)
		{
			if (m_Table.TryGetValue(m, out var mod))
			{
				_ = m_Table.Remove(m);

				if (mod != null)
				{
					m.RemoveSkillMod(mod);
				}
			}
		}
	}
}
