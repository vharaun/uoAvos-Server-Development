
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Server
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class NoSortAttribute : Attribute
	{
		public NoSortAttribute()
		{
		}
	}

	[AttributeUsage(AttributeTargets.Method)]
	public class CallPriorityAttribute : Attribute
	{
		public static int GetValue(MethodInfo m)
		{
			if (m == null)
			{
				return 0;
			}

			var a = m.GetCustomAttribute<CallPriorityAttribute>(false);

			if (a != null)
			{
				return a.Priority;
			}

			return 0;
		}

		private int m_Priority;

		public int Priority
		{
			get => m_Priority;
			set => m_Priority = value;
		}

		public CallPriorityAttribute(int priority)
		{
			m_Priority = priority;
		}
	}

	public class CallPriorityComparer : IComparer<MethodInfo>
	{
		public int Compare(MethodInfo x, MethodInfo y)
		{
			if (x == null && y == null)
			{
				return 0;
			}

			if (x == null)
			{
				return 1;
			}

			if (y == null)
			{
				return -1;
			}

			var xPriority = GetPriority(x);
			var yPriority = GetPriority(y);

			if (xPriority > yPriority)
			{
				return 1;
			}

			if (xPriority < yPriority)
			{
				return -1;
			}

			return 0;
		}

		private int GetPriority(MethodInfo mi)
		{
			var objs = mi.GetCustomAttributes(typeof(CallPriorityAttribute), true);

			if (objs == null)
			{
				return 0;
			}

			if (objs.Length == 0)
			{
				return 0;
			}

			var attr = objs[0] as CallPriorityAttribute;

			if (attr == null)
			{
				return 0;
			}

			return attr.Priority;
		}
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class TypeAliasAttribute : Attribute
	{
		private readonly string[] m_Aliases;

		public string[] Aliases => m_Aliases;

		public TypeAliasAttribute(params string[] aliases)
		{
			m_Aliases = aliases;
		}
	}

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class ParsableAttribute : Attribute
	{
		public ParsableAttribute()
		{
		}
	}

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
	public class CustomEnumAttribute : Attribute
	{
		private readonly string[] m_Names;

		public string[] Names => m_Names;

		public CustomEnumAttribute(string[] names)
		{
			m_Names = names;
		}
	}

	[AttributeUsage(AttributeTargets.Constructor)]
	public class ConstructableAttribute : Attribute
	{
		private AccessLevel m_AccessLevel;

		public AccessLevel AccessLevel
		{
			get => m_AccessLevel;
			set => m_AccessLevel = value;
		}

		public ConstructableAttribute() : this(AccessLevel.Player)  //Lowest accesslevel for current functionality (Level determined by access to [add)
		{
		}

		public ConstructableAttribute(AccessLevel accessLevel)
		{
			m_AccessLevel = accessLevel;
		}
	}

	public enum TypeFilterResult
	{
		NoFilter,
		NotFound,
		Allowed,
		Disallowed,
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class TypeFilterAttribute : Attribute
	{
		public bool CheckChildren { get; }

		public Type[] AllowedTypes { get; }
		public Type[] DisallowedTypes { get; }

		public TypeFilterAttribute(bool checkChildren, bool allowed, params Type[] types)
			: this(checkChildren, allowed ? types : null, !allowed ? types : null)
		{ }

		public TypeFilterAttribute(bool checkChildren, Type[] allowedTypes, Type[] disallowedTypes)
		{
			CheckChildren = checkChildren;

			AllowedTypes = allowedTypes ?? Type.EmptyTypes;
			DisallowedTypes = disallowedTypes ?? Type.EmptyTypes;
		}

		public static TypeFilterResult CheckState(PropertyInfo prop, Type type)
		{
			int index, count = 0;

			foreach (var attr in prop.GetCustomAttributes<TypeFilterAttribute>())
			{
				++count;

				index = attr.AllowedTypes.Length;

				while (--index >= 0)
				{
					if (attr.AllowedTypes[index] == type || (attr.CheckChildren && type.IsSubclassOf(attr.AllowedTypes[index])))
					{
						return TypeFilterResult.Allowed;
					}
				}

				index = attr.DisallowedTypes.Length;

				while (--index >= 0)
				{
					if (attr.DisallowedTypes[index] == type || (attr.CheckChildren && type.IsSubclassOf(attr.DisallowedTypes[index])))
					{
						return TypeFilterResult.Disallowed;
					}
				}
			}

			if (count > 0)
			{
				return TypeFilterResult.NotFound;
			}

			return TypeFilterResult.NoFilter;
		}
	}
}