using Server.Engines.Publishing;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Server.Commands
{
	public enum DecorationTarget
	{
		None,
		Britannia,
		Felucca,
		Trammel,
		Ilshenar,
		Malas,
		Tokuno,
		TerMur,
		MaginciaFelucca,
		MaginciaTrammel
	}

	public static partial class Decorate
	{
		private static readonly Dictionary<DecorationTarget, Dictionary<string, DecorationList[]>> m_Deco = new();

		public static Dictionary<DecorationTarget, Dictionary<string, DecorationList[]>> DecoRegistry => m_Deco;

		public static DecorationList[] Register(DecorationTarget root, string name, DecorationList[] lists)
		{
			if (!m_Deco.TryGetValue(root, out var registered))
			{
				m_Deco[root] = registered = new Dictionary<string, DecorationList[]>();
			}

			return registered[name] = lists;
		}

		public static void Initialize()
		{
			CommandSystem.Register("Decorate", AccessLevel.Administrator, Decorate_OnCommand);
			CommandSystem.Register("DecorateMag", AccessLevel.Administrator, DecorateMag_OnCommand);
		}

		static Decorate()
		{
			Console.WriteLine("Loading decoration entries...");

			var count = 0;

			var flags = BindingFlags.Public | BindingFlags.Static;

			foreach (var type in typeof(Decorate).GetNestedTypes(flags))
			{
				foreach (var prop in type.GetProperties(flags))
				{
					try
					{
						if (prop.PropertyType != typeof(DecorationList[]))
						{
							continue;
						}

						if (prop.GetValue(null, null) is DecorationList[] list)
						{
							count += list.Length;
						}
					}
					catch 
					{ }
				}
			}

			Console.WriteLine($"Loaded {count:N0} decoration entries.");
		}

		[Usage("Decorate")]
		[Description("Generates world decoration.")]
		private static void Decorate_OnCommand(CommandEventArgs e)
		{
			if (e.Mobile is not PlayerMobile player)
			{
				return;
			}

			var stack = new Queue<DecorationTarget>();

			stack.Enqueue(DecorationTarget.Britannia);

			foreach (var map in Map.AllMaps)
			{
				if (Enum.TryParse<DecorationTarget>(map.Name, out var target) && m_Deco.ContainsKey(target))
				{
					stack.Enqueue(target);
				}
			}

			BaseGump.SendGump(new ConfirmGump(player, stack));
		}

		[Usage("DecorateMag")]
		[Description("Generates world decoration.")]
		private static void DecorateMag_OnCommand(CommandEventArgs e)
		{
			if (e.Mobile is not PlayerMobile player)
			{
				return;
			}

			var stack = new Queue<DecorationTarget>();

			stack.Enqueue(DecorationTarget.MaginciaFelucca);
			stack.Enqueue(DecorationTarget.MaginciaTrammel);

			BaseGump.SendGump(new ConfirmGump(player, stack));
		}

		public static Map[] GetMaps(DecorationTarget root)
		{
			switch (root)
			{
				case DecorationTarget.Britannia: return new[] { Map.Felucca, Map.Trammel };
				case DecorationTarget.MaginciaFelucca: return new[] { Map.Felucca };
				case DecorationTarget.MaginciaTrammel: return new[] { Map.Trammel };
			}

			var map = Map.Parse(root.ToString());

			if (map != null)
			{
				return new[] { map };
			}

			return Array.Empty<Map>();
		}

		public static int Generate(DecorationTarget root) 
		{
			return Generate(null, root);
		}

		public static int Generate(PlayerMobile user, DecorationTarget root)
		{
			if (!m_Deco.TryGetValue(root, out var lists))
			{
				return 0;
			}

			var maps = GetMaps(root);

			if (maps == null || maps.Length == 0)
			{
				return 0;
			}

			var count = 0;

			foreach (var entry in lists.Values)
			{
				foreach (var list in entry)
				{
					var c = list.Generate(maps);

					user?.SendMessage($"Generated {c:N0} items for {list.Name}.");
				}
			}

			return count;
		}

		private class ConfirmGump : BaseConfirmGump
		{
			private readonly Queue<DecorationTarget> m_Stack;

			private int m_Count;

			private DecorationTarget m_Root;

			public ConfirmGump(PlayerMobile user, Queue<DecorationTarget> stack) : base(user)
			{
				Title = "<div align=right>Confirm Decoration</div>";

				m_Stack = stack;

				PopEntry();
			}

			public void PopEntry()
			{
				m_Root = DecorationTarget.None;

				var maps = Array.Empty<Map>();

				if (m_Stack.TryDequeue(out m_Root))
				{
					maps = GetMaps(m_Root);
				}

				if (m_Root != DecorationTarget.None && maps.Length > 0)
				{
					var targets = String.Empty;

					for (var i = 0; i < maps.Length; i++)
					{
						if (targets.Length > 0)
						{
							if (i == maps.Length - 1)
							{
								if (maps.Length > 2)
								{
									targets += ", and";
								}
								else
								{
									targets += " and ";
								}
							}
							else
							{
								targets += ", ";
							}
						}

						targets += maps[i];
					}

					Label = $"Decorate <basefont color=#00FF00>{targets}<basefont color=#FFFFFF> with <basefont color=#0000FF>{m_Root}<basefont color=#FFFFFF> settings?";

					DisplayChoice = true;
				}
				else if (m_Stack.Count > 0)
				{
					PopEntry();
				}
				else
				{
					Label = $"Decoration complete. {m_Count:N0} items were generated in total.";

					DisplayChoice = false;
				}
			}

			public override void Confirm()
			{
				if (m_Root != DecorationTarget.None)
				{
					var count = Generate(User, m_Root);

					User.SendMessage($"Decoration complete. {count:N0} items were generated for {m_Root}.");

					m_Count += count;
				}

				Callback();
			}

			public override void Refuse()
			{
				if (m_Root != DecorationTarget.None)
				{
					User.SendMessage($"Decoration skipped. No items were generated for {m_Root}.");
				}

				Callback();
			}

			private void Callback()
			{
				if (m_Stack.Count > 0)
				{
					PopEntry();
					Refresh();
				}
				else if (m_Root != DecorationTarget.None)
				{
					m_Root = DecorationTarget.None;

					Refresh();
				}
				else
				{
					Close();
				}
			}
		}
	}

	public class DecorationList : List<DecorationEntry>
	{
		private static readonly Type typeofStatic = typeof(Static);
		private static readonly Type typeofLocalizedStatic = typeof(LocalizedStatic);
		private static readonly Type typeofBaseDoor = typeof(BaseDoor);
		private static readonly Type typeofAnkhWest = typeof(AnkhWest);
		private static readonly Type typeofAnkhNorth = typeof(AnkhNorth);
		private static readonly Type typeofBeverage = typeof(BaseBeverage);
		private static readonly Type typeofLocalizedSign = typeof(LocalizedSign);
		private static readonly Type typeofMarkContainer = typeof(MarkContainer);
		private static readonly Type typeofWarningItem = typeof(WarningItem);
		private static readonly Type typeofHintItem = typeof(HintItem);
		private static readonly Type typeofCannon = typeof(Cannon);
		private static readonly Type typeofSerpentPillar = typeof(SerpentPillar);

		private readonly string m_Name;
		private readonly Type m_Type;
		private readonly int m_ItemID;
		private readonly string[] m_Params;

		public string Name => m_Name;
		public Type Type => m_Type;
		public int ItemID => m_ItemID;
		public string[] Params => m_Params;

		public DecorationList(string name)
		{
			m_Name = name;
		}

		public DecorationList(string name, Type type, int itemID, string args, DecorationEntry[] entries)
		{
			m_Name = name;
			m_Type = type;
			m_ItemID = itemID;
			m_Params = args.Split(';');

			AddRange(entries);
		}

		public Item Construct()
		{
			if (m_Type == null)
			{
				return null;
			}

			Item item;

			try
			{
				if (m_Type == typeofStatic)
				{
					item = new Static(m_ItemID);
				}
				else if (m_Type == typeofLocalizedStatic)
				{
					var labelNumber = 0;

					for (var i = 0; i < m_Params.Length; ++i)
					{
						if (m_Params[i].StartsWith("LabelNumber"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								labelNumber = Utility.ToInt32(m_Params[i].Substring(++indexOf));
								break;
							}
						}
					}

					item = new LocalizedStatic(m_ItemID, labelNumber);
				}
				else if (m_Type == typeofLocalizedSign)
				{
					var labelNumber = 0;

					for (var i = 0; i < m_Params.Length; ++i)
					{
						if (m_Params[i].StartsWith("LabelNumber"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								labelNumber = Utility.ToInt32(m_Params[i].Substring(++indexOf));
								break;
							}
						}
					}

					item = new LocalizedSign(m_ItemID, labelNumber);
				}
				else if (m_Type == typeofAnkhWest || m_Type == typeofAnkhNorth)
				{
					var bloodied = false;

					for (var i = 0; !bloodied && i < m_Params.Length; ++i)
					{
						bloodied = (m_Params[i] == "Bloodied");
					}

					if (m_Type == typeofAnkhWest)
					{
						item = new AnkhWest(bloodied);
					}
					else
					{
						item = new AnkhNorth(bloodied);
					}
				}
				else if (m_Type == typeofMarkContainer)
				{
					var bone = false;
					var locked = false;
					var map = Map.Malas;

					for (var i = 0; i < m_Params.Length; ++i)
					{
						if (m_Params[i] == "Bone")
						{
							bone = true;
						}
						else if (m_Params[i] == "Locked")
						{
							locked = true;
						}
						else if (m_Params[i].StartsWith("TargetMap"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								map = Map.Parse(m_Params[i].Substring(++indexOf));
							}
						}
					}

					var mc = new MarkContainer(bone, locked)
					{
						TargetMap = map,
						Description = "strange location"
					};

					item = mc;
				}
				else if (m_Type == typeofHintItem)
				{
					var range = 0;
					var messageNumber = 0;
					string messageString = null;
					var hintNumber = 0;
					string hintString = null;
					var resetDelay = TimeSpan.Zero;

					for (var i = 0; i < m_Params.Length; ++i)
					{
						if (m_Params[i].StartsWith("Range"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								range = Utility.ToInt32(m_Params[i].Substring(++indexOf));
							}
						}
						else if (m_Params[i].StartsWith("WarningString"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								messageString = m_Params[i].Substring(++indexOf);
							}
						}
						else if (m_Params[i].StartsWith("WarningNumber"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								messageNumber = Utility.ToInt32(m_Params[i].Substring(++indexOf));
							}
						}
						else if (m_Params[i].StartsWith("HintString"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								hintString = m_Params[i].Substring(++indexOf);
							}
						}
						else if (m_Params[i].StartsWith("HintNumber"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								hintNumber = Utility.ToInt32(m_Params[i].Substring(++indexOf));
							}
						}
						else if (m_Params[i].StartsWith("ResetDelay"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								resetDelay = TimeSpan.Parse(m_Params[i].Substring(++indexOf));
							}
						}
					}

					var hi = new HintItem(m_ItemID, range, messageNumber, hintNumber)
					{
						WarningString = messageString,
						HintString = hintString,
						ResetDelay = resetDelay
					};

					item = hi;
				}
				else if (m_Type == typeofWarningItem)
				{
					var range = 0;
					var messageNumber = 0;
					string messageString = null;
					var resetDelay = TimeSpan.Zero;

					for (var i = 0; i < m_Params.Length; ++i)
					{
						if (m_Params[i].StartsWith("Range"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								range = Utility.ToInt32(m_Params[i].Substring(++indexOf));
							}
						}
						else if (m_Params[i].StartsWith("WarningString"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								messageString = m_Params[i].Substring(++indexOf);
							}
						}
						else if (m_Params[i].StartsWith("WarningNumber"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								messageNumber = Utility.ToInt32(m_Params[i].Substring(++indexOf));
							}
						}
						else if (m_Params[i].StartsWith("ResetDelay"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								resetDelay = TimeSpan.Parse(m_Params[i].Substring(++indexOf));
							}
						}
					}

					var wi = new WarningItem(m_ItemID, range, messageNumber)
					{
						WarningString = messageString,
						ResetDelay = resetDelay
					};

					item = wi;
				}
				else if (m_Type == typeofCannon)
				{
					var direction = CannonDirection.North;

					for (var i = 0; i < m_Params.Length; ++i)
					{
						if (m_Params[i].StartsWith("CannonDirection"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								direction = (CannonDirection)Enum.Parse(typeof(CannonDirection), m_Params[i].Substring(++indexOf), true);
							}
						}
					}

					item = new Cannon(direction);
				}
				else if (m_Type == typeofSerpentPillar)
				{
					string word = null;
					var destination = new Rectangle2D();

					for (var i = 0; i < m_Params.Length; ++i)
					{
						if (m_Params[i].StartsWith("Word"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								word = m_Params[i].Substring(++indexOf);
							}
						}
						else if (m_Params[i].StartsWith("DestStart"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								destination.Start = Point2D.Parse(m_Params[i].Substring(++indexOf));
							}
						}
						else if (m_Params[i].StartsWith("DestEnd"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								destination.End = Point2D.Parse(m_Params[i].Substring(++indexOf));
							}
						}
					}

					item = new SerpentPillar(word, destination);
				}
				else if (m_Type.IsSubclassOf(typeofBeverage))
				{
					var content = BeverageType.Liquor;
					var fill = false;

					for (var i = 0; !fill && i < m_Params.Length; ++i)
					{
						if (m_Params[i].StartsWith("Content"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								content = (BeverageType)Enum.Parse(typeof(BeverageType), m_Params[i].Substring(++indexOf), true);
								fill = true;
							}
						}
					}

					if (fill)
					{
						item = (Item)Activator.CreateInstance(m_Type, new object[] { content });
					}
					else
					{
						item = (Item)Activator.CreateInstance(m_Type);
					}
				}
				else if (m_Type.IsSubclassOf(typeofBaseDoor))
				{
					var facing = DoorFacing.WestCW;

					for (var i = 0; i < m_Params.Length; ++i)
					{
						if (m_Params[i].StartsWith("Facing"))
						{
							var indexOf = m_Params[i].IndexOf('=');

							if (indexOf >= 0)
							{
								facing = (DoorFacing)Enum.Parse(typeof(DoorFacing), m_Params[i].Substring(++indexOf), true);
								break;
							}
						}
					}

					item = (Item)Activator.CreateInstance(m_Type, new object[] { facing });
				}
				else
				{
					item = (Item)Activator.CreateInstance(m_Type);
				}
			}
			catch (Exception e)
			{
				throw new Exception(String.Format("Bad type: {0}", m_Type), e);
			}

			if (item is BaseAddon)
			{
				if (m_ItemID > 0)
				{
					var comps = ((BaseAddon)item).Components;

					for (var i = 0; i < comps.Count; ++i)
					{
						var comp = comps[i];

						if (comp.Offset == Point3D.Zero)
						{
							comp.ItemID = m_ItemID;
						}
					}
				}
			}
			else if (item is BaseLight)
			{
				bool unlit = false, unprotected = false;

				for (var i = 0; i < m_Params.Length; ++i)
				{
					if (!unlit && m_Params[i] == "Unlit")
					{
						unlit = true;
					}
					else if (!unprotected && m_Params[i] == "Unprotected")
					{
						unprotected = true;
					}

					if (unlit && unprotected)
					{
						break;
					}
				}

				if (!unlit)
				{
					((BaseLight)item).Ignite();
				}

				if (!unprotected)
				{
					((BaseLight)item).Protected = true;
				}

				if (m_ItemID > 0)
				{
					item.ItemID = m_ItemID;
				}
			}
			else if (item is Server.Mobiles.Spawner)
			{
				var sp = (Server.Mobiles.Spawner)item;

				sp.NextSpawn = TimeSpan.Zero;

				for (var i = 0; i < m_Params.Length; ++i)
				{
					if (m_Params[i].StartsWith("Spawn"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							sp.SpawnNames.Add(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("MinDelay"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							sp.MinDelay = TimeSpan.Parse(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("MaxDelay"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							sp.MaxDelay = TimeSpan.Parse(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("NextSpawn"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							sp.NextSpawn = TimeSpan.Parse(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Count"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							sp.Count = Utility.ToInt32(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Team"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							sp.Team = Utility.ToInt32(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("HomeRange"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							sp.HomeRange = Utility.ToInt32(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Running"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							sp.Running = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Group"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							sp.Group = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
				}
			}
			else if (item is RecallRune)
			{
				var rune = (RecallRune)item;

				for (var i = 0; i < m_Params.Length; ++i)
				{
					if (m_Params[i].StartsWith("Description"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							rune.Description = m_Params[i].Substring(++indexOf);
						}
					}
					else if (m_Params[i].StartsWith("Marked"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							rune.Marked = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("TargetMap"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							rune.TargetMap = Map.Parse(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Target"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							rune.Target = Point3D.Parse(m_Params[i].Substring(++indexOf));
						}
					}
				}
			}
			else if (item is SkillTeleporter)
			{
				var tp = (SkillTeleporter)item;

				for (var i = 0; i < m_Params.Length; ++i)
				{
					if (m_Params[i].StartsWith("Skill"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Skill = (SkillName)Enum.Parse(typeof(SkillName), m_Params[i].Substring(++indexOf), true);
						}
					}
					else if (m_Params[i].StartsWith("RequiredFixedPoint"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Required = Utility.ToInt32(m_Params[i].Substring(++indexOf)) * 0.1;
						}
					}
					else if (m_Params[i].StartsWith("Required"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Required = Utility.ToDouble(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("MessageString"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.MessageString = m_Params[i].Substring(++indexOf);
						}
					}
					else if (m_Params[i].StartsWith("MessageNumber"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.MessageNumber = Utility.ToInt32(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("PointDest"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.PointDest = Point3D.Parse(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("MapDest"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.MapDest = Map.Parse(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Creatures"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Creatures = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("SourceEffect"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.SourceEffect = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("DestEffect"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.DestEffect = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("SoundID"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.SoundID = Utility.ToInt32(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Delay"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Delay = TimeSpan.Parse(m_Params[i].Substring(++indexOf));
						}
					}
				}

				if (m_ItemID > 0)
				{
					item.ItemID = m_ItemID;
				}
			}
			else if (item is KeywordTeleporter)
			{
				var tp = (KeywordTeleporter)item;

				for (var i = 0; i < m_Params.Length; ++i)
				{
					if (m_Params[i].StartsWith("Substring"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Substring = m_Params[i].Substring(++indexOf);
						}
					}
					else if (m_Params[i].StartsWith("Keyword"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Keyword = Utility.ToInt32(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Range"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Range = Utility.ToInt32(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("PointDest"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.PointDest = Point3D.Parse(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("MapDest"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.MapDest = Map.Parse(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Creatures"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Creatures = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("SourceEffect"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.SourceEffect = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("DestEffect"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.DestEffect = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("SoundID"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.SoundID = Utility.ToInt32(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Delay"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Delay = TimeSpan.Parse(m_Params[i].Substring(++indexOf));
						}
					}
				}

				if (m_ItemID > 0)
				{
					item.ItemID = m_ItemID;
				}
			}
			else if (item is Teleporter)
			{
				var tp = (Teleporter)item;

				for (var i = 0; i < m_Params.Length; ++i)
				{
					if (m_Params[i].StartsWith("PointDest"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.PointDest = Point3D.Parse(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("MapDest"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.MapDest = Map.Parse(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Creatures"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Creatures = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("SourceEffect"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.SourceEffect = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("DestEffect"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.DestEffect = Utility.ToBoolean(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("SoundID"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.SoundID = Utility.ToInt32(m_Params[i].Substring(++indexOf));
						}
					}
					else if (m_Params[i].StartsWith("Delay"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							tp.Delay = TimeSpan.Parse(m_Params[i].Substring(++indexOf));
						}
					}
				}

				if (m_ItemID > 0)
				{
					item.ItemID = m_ItemID;
				}
			}
			else if (item is FillableContainer)
			{
				var cont = (FillableContainer)item;

				for (var i = 0; i < m_Params.Length; ++i)
				{
					if (m_Params[i].StartsWith("ContentType"))
					{
						var indexOf = m_Params[i].IndexOf('=');

						if (indexOf >= 0)
						{
							cont.ContentType = (FillableContentType)Enum.Parse(typeof(FillableContentType), m_Params[i].Substring(++indexOf), true);
						}
					}
				}

				if (m_ItemID > 0)
				{
					item.ItemID = m_ItemID;
				}
			}
			else if (m_ItemID > 0)
			{
				item.ItemID = m_ItemID;
			}

			item.Movable = false;

			for (var i = 0; i < m_Params.Length; ++i)
			{
				if (m_Params[i].StartsWith("Light"))
				{
					var indexOf = m_Params[i].IndexOf('=');

					if (indexOf >= 0)
					{
						item.Light = (LightType)Enum.Parse(typeof(LightType), m_Params[i].Substring(++indexOf), true);
					}
				}
				else if (m_Params[i].StartsWith("Hue"))
				{
					var indexOf = m_Params[i].IndexOf('=');

					if (indexOf >= 0)
					{
						var hue = Utility.ToInt32(m_Params[i].Substring(++indexOf));

						if (item is DyeTub)
						{
							((DyeTub)item).DyedHue = hue;
						}
						else
						{
							item.Hue = hue;
						}
					}
				}
				else if (m_Params[i].StartsWith("Name"))
				{
					var indexOf = m_Params[i].IndexOf('=');

					if (indexOf >= 0)
					{
						item.Name = m_Params[i].Substring(++indexOf);
					}
				}
				else if (m_Params[i].StartsWith("Amount"))
				{
					var indexOf = m_Params[i].IndexOf('=');

					if (indexOf >= 0)
					{
						// Must supress stackable warnings

						var wasStackable = item.Stackable;

						item.Stackable = true;
						item.Amount = Utility.ToInt32(m_Params[i].Substring(++indexOf));
						item.Stackable = wasStackable;
					}
				}
			}

			return item;
		}

		private static readonly Queue<Item> m_DeleteQueue = new();

		private static bool FindItem(Point3D loc, Map map, Item srcItem)
		{
			var itemID = srcItem.ItemID;

			var res = false;

			IPooledEnumerable<Item> eable;

			if (srcItem is BaseDoor)
			{
				eable = map.GetItemsInRange(loc, 1);

				foreach (var item in eable)
				{
					if (item is not BaseDoor bd)
					{
						continue;
					}

					Point3D p;
					int bdItemID;

					if (bd.Open)
					{
						p = new Point3D(bd.X - bd.Offset.X, bd.Y - bd.Offset.Y, bd.Z - bd.Offset.Z);
						bdItemID = bd.ClosedID;
					}
					else
					{
						p = bd.Location;
						bdItemID = bd.ItemID;
					}

					if (p.X != loc.X || p.Y != loc.Y)
					{
						continue;
					}

					if (item.Z == loc.Z && bdItemID == itemID)
					{
						res = true;
					}
					else if (Math.Abs(item.Z - loc.Z) < 8)
					{
						m_DeleteQueue.Enqueue(item);
					}
				}
			}
			else if ((TileData.ItemTable[itemID & TileData.MaxItemValue].Flags & TileFlag.LightSource) != 0)
			{
				eable = map.GetItemsInRange(loc, 0);

				var lt = srcItem.Light;
				var srcName = srcItem.ItemData.Name;

				foreach (var item in eable)
				{
					if (item.Z == loc.Z)
					{
						if (item.ItemID == itemID)
						{
							if (item.Light != lt)
							{
								m_DeleteQueue.Enqueue(item);
							}
							else
							{
								res = true;
							}
						}
						else if ((item.ItemData.Flags & TileFlag.LightSource) != 0 && item.ItemData.Name == srcName)
						{
							m_DeleteQueue.Enqueue(item);
						}
					}
				}
			}
			else if (srcItem is Teleporter || srcItem is FillableContainer || srcItem is BaseBook)
			{
				eable = map.GetItemsInRange(loc, 0);

				var type = srcItem.GetType();

				foreach (var item in eable)
				{
					if (item.Z == loc.Z && item.ItemID == itemID)
					{
						if (item.GetType() != type)
						{
							m_DeleteQueue.Enqueue(item);
						}
						else
						{
							res = true;
						}
					}
				}
			}
			else
			{
				eable = map.GetItemsInRange(loc, 0);

				foreach (var item in eable)
				{
					if (item.Z == loc.Z && item.ItemID == itemID)
					{
						eable.Free();
						return true;
					}
				}
			}

			eable.Free();

			while (m_DeleteQueue.Count > 0)
			{
				m_DeleteQueue.Dequeue().Delete();
			}

			return res;
		}

		public int Generate(Map[] maps)
		{
			var count = 0;

			Item item = null;

			for (var i = 0; i < Count; ++i)
			{
				var entry = this[i];
				var loc = entry.Location;
				var extra = entry.Extra;

				for (var j = 0; j < maps.Length; ++j)
				{
					if (item == null)
					{
						item = Construct();
					}

					if (item == null)
					{
						continue;
					}

					if (FindItem(loc, maps[j], item))
					{
						continue;
					}

					item.OnBeforeSpawn(loc, maps[j]);
					item.MoveToWorld(loc, maps[j]);
					item.OnAfterSpawn();

					++count;

					if (item is BaseDoor door)
					{
						var eable = maps[j].GetItemsInRange(loc, 1);

						var itemType = door.GetType();

						foreach (var sub in eable)
						{
							if (sub != item && sub.Z == item.Z && sub is BaseDoor link && itemType == link.GetType())
							{
								door.Link = link;
								link.Link = door;
								break;
							}
						}

						eable.Free();
					}
					else if (item is MarkContainer mc)
					{
						try { mc.Target = Point3D.Parse(extra); }
						catch { }
					}

					item = null;
				}
			}

			if (item != null)
			{
				item.Delete();
			}

			return count;
		}
	}

	public class DecorationEntry
	{
		public string Comment { get; }
		public Point3D Location { get; }
		public string Extra { get; }

		public DecorationEntry(int x, int y, int z, string extra)
			: this(x, y, z, extra, String.Empty)
		{ }

		public DecorationEntry(int x, int y, int z, string extra, string comment)
		{
			Location = new Point3D(x, y, z);
			Extra = extra;
			Comment = comment;
		}
	}
}