using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Trammel
		{
			public static DecorationList[] Magincia { get; } = Register(DecorationTarget.Trammel, "Magincia", new DecorationList[]
			{
				#region Entries
				
				new("Metal Signpost", typeof(Static), 2976, "", new DecorationEntry[]
				{
					new(3778, 2256, 20, ""),
				}),
				new("Lamp Post", typeof(LampPost3), 2852, "", new DecorationEntry[]
				{
					new(3758, 2256, 30, ""),
					new(3773, 2233, 30, ""),
					new(3793, 2232, 20, ""),
				}),
				
				#endregion
			});
		}
	}
}
