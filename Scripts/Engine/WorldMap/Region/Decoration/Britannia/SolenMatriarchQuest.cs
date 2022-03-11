using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] SolenMatriarchQuest { get; } = Register(DecorationTarget.Britannia, "Solen Matriarch Quest", new DecorationList[]
			{
				#region Entries
				
				new("Water Vats", typeof(WaterVatSouth), 0, "", new DecorationEntry[]
				{
					new(5806, 1919, 5, ""),
				}),
				new("", typeof(WaterVatEast), 0, "", new DecorationEntry[]
				{
					new(5797, 1926, 5, ""),
				}),
				
				#endregion
			});
		}
	}
}
