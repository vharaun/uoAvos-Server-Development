
using System;

namespace Server
{
	public partial class OppositionGroup
	{
		public static readonly OppositionGroup[] EmptyArray = Array.Empty<OppositionGroup>();

		public static readonly OppositionGroup None = new(Array.Empty<Type[]>());

		private readonly Type[][] m_Types;

		public OppositionGroup(Type[][] types)
		{
			m_Types = types;
		}

		public bool IsEnemy(object from, object target)
		{
			var fromGroup = IndexOf(from);
			var targGroup = IndexOf(target);

			return (fromGroup != -1 && targGroup != -1 && fromGroup != targGroup);
		}

		public int IndexOf(object obj)
		{
			if (obj == null)
			{
				return -1;
			}

			var type = obj.GetType();

			for (var i = 0; i < m_Types.Length; ++i)
			{
				var group = m_Types[i];

				var contains = false;

				for (var j = 0; !contains && j < group.Length; ++j)
				{
					contains = group[j].IsAssignableFrom(type);
				}

				if (contains)
				{
					return i;
				}
			}

			return -1;
		}
	}
}