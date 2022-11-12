using Server.Items;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
	public partial class Loot
	{
		private static readonly Dictionary<SpellSchool, Type[]> m_ScrollTypes = new();
		private static readonly Dictionary<SpellName, Type> m_ScrollTypesByID = new();

		// All available scrolls
		public static Type[] SpellScrolls => GetScrollTypes(SpellSchool.Invalid);

		#region Standard

		public static Type[] MageryScrollTypes => GetScrollTypes(SpellSchool.Magery);
		public static Type[] NecromancyScrollTypes => GetScrollTypes(SpellSchool.Magery);
		public static Type[] ChivalryScrolls => GetScrollTypes(SpellSchool.Magery);
		public static Type[] SpellweavingScrolls => GetScrollTypes(SpellSchool.Spellweaving);
		public static Type[] MysticismScrolls => GetScrollTypes(SpellSchool.Mysticism);

		#endregion

		#region Custom

		public static Type[] AvatarScrolls => GetScrollTypes(SpellSchool.Avatar);
		public static Type[] ClericScrolls => GetScrollTypes(SpellSchool.Cleric);
		public static Type[] DruidScrolls => GetScrollTypes(SpellSchool.Druid);
		public static Type[] RangerScrolls => GetScrollTypes(SpellSchool.Ranger);
		public static Type[] RogueScrolls => GetScrollTypes(SpellSchool.Rogue);

		#endregion

		public static Type[] GetScrollTypes(SpellSchool school)
		{
			if (m_ScrollTypes.TryGetValue(school, out var types))
			{
				return types;
			}

			var scrollType = typeof(SpellScroll);

			var list = new HashSet<Type>();

			if (school == SpellSchool.Invalid)
			{
				foreach (var ss in SpellRegistry.Schools)
				{
					foreach (var type in GetScrollTypes(ss))
					{
						list.Add(type);
					}
				}
			}
			else
			{
				foreach (var asm in ScriptCompiler.Assemblies)
				{
					foreach (var type in asm.DefinedTypes)
					{
						if (type.IsSubclassOf(scrollType))
						{
							try
							{
								var scroll = (SpellScroll)Activator.CreateInstance(type);

								if (school == SpellSchool.Invalid || school == SpellRegistry.GetSchool(scroll.SpellID))
								{
									if (list.Add(type))
									{
										m_ScrollTypesByID[scroll.SpellID] = type;
									}
								}

								scroll.Delete();
							}
							catch
							{
							}
						}
					}
				}
			}

			var arr = list.ToArray();

			list.Clear();
			list.TrimExcess();

			return m_ScrollTypes[school] = arr;
		}
	}
}