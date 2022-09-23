
using System;

namespace Server
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	public class UsageAttribute : Attribute
	{
		private readonly string m_Usage;

		public string Usage => m_Usage;

		public UsageAttribute(string usage)
		{
			m_Usage = usage;
		}
	}

	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	public class NameAttribute : Attribute
	{
		private readonly string m_Name;

		public string Name => m_Name;

		public NameAttribute(string name)
		{
			m_Name = name;
		}
	}

	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	public class DescriptionAttribute : Attribute
	{
		private readonly string m_Description;

		public string Description => m_Description;

		public DescriptionAttribute(string description)
		{
			m_Description = description;
		}
	}

	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	public class AliasesAttribute : Attribute
	{
		private readonly string[] m_Aliases;

		public string[] Aliases => m_Aliases;

		public AliasesAttribute(params string[] aliases)
		{
			m_Aliases = aliases;
		}
	}
}