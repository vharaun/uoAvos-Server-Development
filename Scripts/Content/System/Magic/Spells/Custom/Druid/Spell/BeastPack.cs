using Server.Mobiles;

using System;
using System.Collections.Generic;

namespace Server.Spells.Druid
{
	public class BeastPackSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.0);

		private static readonly List<Type> m_Types = new()
		{
			typeof(BrownBear),
			typeof(TimberWolf),
			typeof(Panther),
			typeof(GreatHart),
			typeof(Hind),
			typeof(Alligator),
			typeof(Boar),
			typeof(GiantRat),
		};

		public BeastPackSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.BeastPack)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Type type = null;

				List<ISpawnable> spawn = null;

				while (type == null && m_Types.Count > 0)
				{
					var t = Utility.RandomList(m_Types);

					try
					{
						var s = (ISpawnable)Activator.CreateInstance(t);

						if (s != null)
						{
							type = t;

							spawn = new()
							{
								s
							};
						}
						else
						{
							_ = m_Types.Remove(t);

							type = null;
						}
					}
					catch
					{
						_ = m_Types.Remove(t);

						type = null;
					}
				}

				if (type != null)
				{
					var count = 2;

					count -= spawn.Count;

					var bonus = Utility.Random(100) + (Caster.Skills[CastSkill].Value * 0.1);

					if (bonus > 11)
					{
						++count;
					}

					if (bonus > 18)
					{
						++count;
					}

					while (--count >= 0)
					{
						spawn.Add((ISpawnable)Activator.CreateInstance(type));
					}
				}

				var duration = TimeSpan.FromSeconds(4.0 * Caster.Skills[CastSkill].Value);

				foreach (var e in spawn)
				{
					if (e is BaseCreature c)
					{
						SpellHelper.Summon(c, Caster, 0x215, duration, false, false);
					}
					else
					{
						var p = Caster.Location;

						if (SpellHelper.FindValidSpawnLocation(Caster.Map, ref p, true))
						{
							e.OnBeforeSpawn(p, Caster.Map);
							e.MoveToWorld(p, Caster.Map);
							e.OnAfterSpawn();
						}
						else
						{
							e.Delete();
						}
					}
				}
			}

			FinishSequence();
		}
	}
}
