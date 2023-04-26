using System;
using System.Collections.Generic;

namespace Server
{
	public interface IUsesRemaining
	{
		int UsesRemaining { get; set; }
		bool ShowUsesRemaining { get; set; }
	}

	public interface IChopable
	{
		void OnChop(Mobile from);
	}

	public interface ICarvable : IEntity
	{
		void Carve(Mobile from, Item item);
	}

	public interface IHarvestTool : IEntity
	{
		IHarvestSystem HarvestSystem { get; }
	}

	public interface IHarvestSystem
	{
	}

	public interface ICraftTool : IEntity
	{
		ICraftSystem CraftSystem { get; }
	}

	public interface ICraftSystem
	{
		TextDefinition Title { get; }

		SkillName MainSkill { get; }
	}

	public interface ICraftItem
	{
		TextDefinition GroupName { get; }
		TextDefinition Name { get; }

		Type ItemType { get; }
	}

	public interface ICraftable : IEntity
	{
		int OnCraft(int quality, bool makersMark, Mobile from, ICraftSystem craftSystem, Type typeRes, ICraftTool tool, ICraftItem craftItem, int resHue);
	}

	public enum ItemQuality
	{
		Low,
		Regular,
		Exceptional
	}
}