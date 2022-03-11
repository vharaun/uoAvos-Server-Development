using Server.Mobiles;

using System.Collections.Generic;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("ReplaceBankers")]
		[Description("Replaces all of the banker npcs on the server.")]
		public static void ReplaceBankers_OnCommand(CommandEventArgs e)
		{
			var list = new List<Mobile>();

			foreach (var m in World.Mobiles.Values)
			{
				if ((m is Banker) && !(m is BaseCreature))
				{
					list.Add(m);
				}
			}

			foreach (var m in list)
			{
				var map = m.Map;

				if (map != null)
				{
					var hasBankerSpawner = false;

					foreach (var item in m.GetItemsInRange(0))
					{
						if (item is Spawner)
						{
							var spawner = (Spawner)item;

							for (var i = 0; !hasBankerSpawner && i < spawner.SpawnNames.Count; ++i)
							{
								hasBankerSpawner = Insensitive.Equals(spawner.SpawnNames[i], "banker");
							}

							if (hasBankerSpawner)
							{
								break;
							}
						}
					}

					if (!hasBankerSpawner)
					{
						var spawner = new Spawner(1, 1, 5, 0, 4, "banker");

						spawner.MoveToWorld(m.Location, map);
					}
				}
			}
		}
	}
}