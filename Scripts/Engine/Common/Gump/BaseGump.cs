using Server.Mobiles;
using Server.Network;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Server.Gumps
{
	public abstract class BaseGump : Gump, IDisposable
	{
		public const int CenterLoc = 1114513;     // <center>~1_val~</center>
		public const int AlignRightLoc = 1114514; // <DIV ALIGN=RIGHT>~1_TOKEN~</DIV>

		private Gump _Parent;

		private int _ButtonID;

		private Dictionary<int, Action<int>> _Buttons;

		public PlayerMobile User { get; private set; }

		public bool Open { get; protected set; }

		public bool CloseOnMapChange { get; set; }

		public Gump Parent
		{
			get => _Parent;
			set
			{
				if (_Parent == value)
				{
					return;
				}

				if (_Parent is BaseGump opg)
				{
					_ = opg.Children.Remove(this);
				}

				_Parent = value;

				if (_Parent is BaseGump npg)
				{
					_ = npg.Children.Add(this);
				}
			}
		}

		public HashSet<BaseGump> Children { get; private set; } = new();

		public BaseGump(PlayerMobile user, int x = 50, int y = 50, BaseGump parent = null)
			: base(x, y)
		{
			User = user;
			Parent = parent;
		}

		~BaseGump()
		{
			Dispose();
		}

		public static BaseGump SendGump(BaseGump gump)
		{
			if (gump == null)
			{
				return null;
			}

			var g = gump.User.FindGump(gump.GetType()) as BaseGump;

			if (g == gump)
			{
				gump.Refresh();
			}
			else
			{
				gump.SendGump();
			}

			return gump;
		}

		public virtual void SendGump()
		{
			AddGumpLayout();
			Open = true;
			_ = User.SendGump(this);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);

			Children.Clear();
			Children = null;

			User = null;
			Parent = null;

			foreach (var kvp in _TextTooltips)
			{
				kvp.Value.Free();
			}

			foreach (var kvp in _ClilocTooltips)
			{
				kvp.Value.Free();
			}

			_ClilocTooltips.Clear();
			_TextTooltips.Clear();

			OnDispose();
		}

		public virtual void OnDispose()
		{
		}

		public abstract void AddGumpLayout();

		public virtual void Refresh(bool recompile = true, bool close = true)
		{
			OnBeforeRefresh();

			if (User == null || User.NetState == null)
			{
				return;
			}

			if (close)
			{
				User.NetState.Send(new CloseGump(TypeID, 0));
				User.NetState.RemoveGump(this);
			}
			else
			{
				User.NetState.RemoveGump(this);
			}

			if (recompile)
			{
				Entries.Clear();
				AddGumpLayout();
			}

			_ = User.SendGump(this);
			OnAfterRefresh();
		}

		public void RefreshParent(bool resend = false)
		{
			if (Parent is BaseGump pg)
			{
				pg.Refresh();
			}

			if (resend)
			{
				Refresh();
			}
		}

		public virtual void OnBeforeRefresh()
		{
		}

		public virtual void OnAfterRefresh()
		{
		}

		public virtual void OnClosed()
		{
			foreach (var child in Children)
			{
				child.Close();
			}

			Children.Clear();

			Open = false;

			if (Parent is BaseGump pg)
			{
				pg.OnChildClosed(this);
			}

			Parent = null;
		}

		public virtual void OnChildClosed(BaseGump gump)
		{
		}

		public override sealed void OnResponse(NetState state, RelayInfo info)
		{
			OnResponse(info);

			if (info.ButtonID == 0)
			{
				OnClosed();
			}
		}

		public virtual void OnResponse(RelayInfo info)
		{
			if (_Buttons != null && _Buttons.TryGetValue(info.ButtonID, out var callback) && callback != null)
			{
				callback(info.ButtonID);
			}
			else if (info.ButtonID != 0)
			{
				Refresh();
			}
			else
			{
				Close();
			}
		}

		public virtual void OnServerClosed(NetState state)
		{
			OnClosed();
		}

		public virtual void Close()
		{
			if (User == null || User.NetState == null)
			{
				return;
			}

			OnServerClose(User.NetState);

			_ = User.Send(new CloseGump(TypeID, 0));
			User.NetState.RemoveGump(this);

			OnClosed();

			_Buttons?.Clear();
		}

		public static T GetGump<T>(PlayerMobile pm, Func<T, bool> predicate) where T : Gump
		{
			return EnumerateGumps<T>(pm).FirstOrDefault(x => predicate == null || predicate(x));
		}

		public static IEnumerable<T> EnumerateGumps<T>(PlayerMobile pm, Func<T, bool> predicate = null) where T : Gump
		{
			return pm?.NetState?.Gumps?.OfType<T>().Where(g => predicate == null || predicate(g)) ?? Enumerable.Empty<T>();
		}

		public static List<Gump> GetGumps(PlayerMobile pm)
		{
			return new(EnumerateGumps<Gump>(pm));
		}

		public static List<T> GetGumps<T>(PlayerMobile pm) where T : Gump
		{
			return new(EnumerateGumps<T>(pm));
		}

		public static List<BaseGump> GetGumps(PlayerMobile pm, bool checkOpen)
		{
			return new(EnumerateGumps<BaseGump>(pm, g => !checkOpen || g.Open));
		}

		public static List<T> GetGumps<T>(PlayerMobile pm, bool checkOpen) where T : BaseGump
		{
			return new(EnumerateGumps<T>(pm, g => !checkOpen || g.Open));
		}

		public static void CheckCloseGumps(PlayerMobile pm, bool checkOpen = false)
		{
			var ns = pm.NetState;

			if (ns != null)
			{
				var gumps = GetGumps(pm, checkOpen);

				foreach (var gump in gumps)
				{
					if (gump.CloseOnMapChange)
					{
						_ = pm.CloseGump(gump.GetType());
					}
				}

				gumps.Clear();
				gumps.TrimExcess();
			}
		}

		public void AddButton(int x, int y, int normalID, int pressedID, Action callback)
		{
			AddButton(x, y, normalID, pressedID, _ => callback());
		}

		public void AddButton(int x, int y, int normalID, int pressedID, Action<int> callback)
		{
			var buttonID = ++_ButtonID;

			AddButton(x, y, normalID, pressedID, buttonID, GumpButtonType.Reply, buttonID);

			_Buttons ??= new Dictionary<int, Action<int>>();

			_Buttons[buttonID] = callback;
		}

		public void AddHtml(int x, int y, int width, int height, string text, bool background, bool scrollbar, Color color)
		{
			text = SetColor(color, text);

			AddHtml(x, y, width, height, text, background, scrollbar);
		}

		public void AddItemProperty(Item item)
		{
			item.SendPropertiesTo(User);

			AddItemProperty(item.Serial);
		}

		public void AddMobileProperty(Mobile mob)
		{
			mob.SendPropertiesTo(User);

			AddItemProperty(mob.Serial.Value);
		}

		public void AddProperties(Spoof spoof)
		{
			_ = User.Send(spoof.PropertyList);

			AddItemProperty(spoof.Serial.Value);
		}

		#region Images

		public static Size GetImageSize(int gumpID)
		{
			var asset = GumpData.GetGump(gumpID);

			return asset?.Size ?? Size.Empty;
		}

		#endregion

		#region Formatting

		public static int C16232(int c16)
		{
			c16 &= 0x7FFF;

			var r = ((c16 >> 10) & 0x1F) << 3;
			var g = ((c16 >> 05) & 0x1F) << 3;
			var b = ((c16 >> 00) & 0x1F) << 3;

			return (r << 16) | (g << 8) | (b << 0);
		}

		public static int C16216(int c16)
		{
			return c16 & 0x7FFF;
		}

		public static int C32216(int c32)
		{
			c32 &= 0xFFFFFF;

			var r = ((c32 >> 16) & 0xFF) >> 3;
			var g = ((c32 >> 08) & 0xFF) >> 3;
			var b = ((c32 >> 00) & 0xFF) >> 3;

			return (r << 10) | (g << 5) | (b << 0);
		}

		public static string SetColor(Color color, string str)
		{
			return SetColor(color.ToArgb(), str);
		}

		public static string SetColor(int color, string str)
		{
			var r = Math.Max(0x08, (color >> 16) & 0xFF);
			var g = Math.Max(0x08, (color >> 08) & 0xFF);
			var b = Math.Max(0x08, (color >> 00) & 0xFF);

			color = (r << 16) | (g << 08) | (b << 00);

			return $"<BASEFONT COLOR=#{color:X6}>{str}";
		}

		public static string ColorAndCenter(Color color, string str)
		{
			return ColorAndCenter(color.ToArgb(), str);
		}

		public static string ColorAndCenter(int color, string str)
		{
			color &= 0x00FFFFFF;

			return $"<BASEFONT COLOR=#{color:X6}><CENTER>{str}</CENTER>";
		}

		public static string Center(string str)
		{
			return $"<CENTER>{str}</CENTER>";
		}

		public static string ColorAndAlignRight(Color color, string str)
		{
			return ColorAndAlignRight(color.ToArgb(), str);
		}

		public static string ColorAndAlignRight(int color, string str)
		{
			color &= 0x00FFFFFF;

			return $"<DIV ALIGN=RIGHT><BASEFONT COLOR=#{color:X6}>{str}</DIV>";
		}

		public static string AlignRight(string str)
		{
			return $"<DIV ALIGN=RIGHT>{str}</DIV>";
		}

		public void AddHtmlTextDefinition(int x, int y, int length, int height, TextDefinition text, bool background, bool scrollbar)
		{
			if (text.Number > 0)
			{
				AddHtmlLocalized(x, y, length, height, text.Number, false, false);
			}
			else if (!String.IsNullOrEmpty(text.String))
			{
				AddHtml(x, y, length, height, text.String, background, scrollbar);
			}
		}

		public void AddHtmlTextDefinition(int x, int y, int length, int height, TextDefinition text, int color, bool background, bool scrollbar)
		{
			if (text.Number > 0)
			{
				AddHtmlLocalized(x, y, length, height, text.Number, color, false, false);
			}
			else if (!String.IsNullOrEmpty(text.String))
			{
				AddHtml(x, y, length, height, SetColor(color, text.String), background, scrollbar);
			}
		}

		public void AddHtmlLocalizedCentered(int x, int y, int length, int height, int localization, bool background, bool scrollbar)
		{
			AddHtmlLocalized(x, y, length, height, 1113302, $"#{localization}", 0, background, scrollbar);
		}

		public void AddHtmlLocalizedCentered(int x, int y, int length, int height, int localization, int hue, bool background, bool scrollbar)
		{
			AddHtmlLocalized(x, y, length, height, 1113302, $"#{localization}", hue, background, scrollbar);
		}

		public void AddHtmlLocalizedAlignRight(int x, int y, int length, int height, int localization, bool background, bool scrollbar)
		{
			AddHtmlLocalized(x, y, length, height, 1114514, $"#{localization}", 0, background, scrollbar);
		}

		public void AddHtmlLocalizedAlignRight(int x, int y, int length, int height, int localization, int hue, bool background, bool scrollbar)
		{
			AddHtmlLocalized(x, y, length, height, 1114514, $"#{localization}", hue, background, scrollbar);
		}

		#endregion

		#region Tooltips

		private readonly Dictionary<string, Spoof> _TextTooltips = new();
		private readonly Dictionary<Dictionary<int, string>, Spoof> _ClilocTooltips = new();

		public void AddTooltipTextDefinition(TextDefinition text)
		{
			if (text.Number > 0)
			{
				AddTooltip(text.Number);
			}
			else if (!String.IsNullOrEmpty(text.String))
			{
				AddTooltip(text.String);
			}
		}

		public void AddTooltip(string text, Color color)
		{
			AddTooltip(String.Empty, text, Color.Empty, color);
		}

		public void AddTooltip(string title, string text)
		{
			AddTooltip(title, text, Color.Empty, Color.Empty);
		}

		public void AddTooltip(int cliloc, string format, params string[] args)
		{
			base.AddTooltip(cliloc, String.Format(format, args));
		}

		public void AddTooltip(int[] clilocs)
		{
			AddTooltip(clilocs, new string[clilocs.Length]);
		}

		public void AddTooltip(string[] args)
		{
			var clilocs = new int[Math.Min(Spoof.EmptyClilocs.Length, args.Length)];

			for (var i = 0; i < args.Length; i++)
			{
				if (i >= Spoof.EmptyClilocs.Length)
				{
					break;
				}

				clilocs[i] = Spoof.EmptyClilocs[i];
			}

			AddTooltip(clilocs, args);
		}

		public void AddTooltip(int[] clilocs, string[] args)
		{
			var dictionary = new Dictionary<int, string>();
			var emptyIndex = 0;

			for (var i = 0; i < clilocs.Length; i++)
			{
				var str = String.Empty;

				if (i < args.Length)
				{
					str = args[i] ?? String.Empty;
				}

				var cliloc = clilocs[i];

				if (cliloc <= 0)
				{
					if (emptyIndex <= Spoof.EmptyClilocs.Length)
					{
						cliloc = Spoof.EmptyClilocs[emptyIndex];
						emptyIndex++;
					}
				}

				if (cliloc > 0)
				{
					dictionary[cliloc] = str;
				}
			}

			Spoof spoof;

			if (!_ClilocTooltips.TryGetValue(dictionary, out spoof) || spoof == null || spoof.Deleted)
			{
				spoof = Spoof.Acquire();
			}

			spoof.ClilocTable = dictionary;

			_ClilocTooltips[dictionary] = spoof;
			AddProperties(spoof);
		}

		public void AddTooltip(string title, string text, Color titleColor, Color textColor)
		{
			title ??= String.Empty;
			text ??= String.Empty;

			if (titleColor.IsEmpty || titleColor == Color.Transparent)
			{
				titleColor = Color.White;
			}

			if (textColor.IsEmpty || textColor == Color.Transparent)
			{
				textColor = Color.White;
			}

			Spoof spoof;

			if (!_TextTooltips.TryGetValue(text, out spoof) || spoof == null || spoof.Deleted)
			{
				spoof = Spoof.Acquire();
			}

			if (!String.IsNullOrWhiteSpace(title))
			{
				spoof.Text = String.Concat(String.Format("<basefont color=#{0:X}>{1}", titleColor.ToArgb(), title),
							'\n',
							String.Format("<basefont color=#{0:X}>{1}", textColor.ToArgb(), text));
			}
			else
			{
				spoof.Text = String.Format("<basefont color=#{0:X}>{1}", textColor.ToArgb(), text); //  text.WrapUOHtmlColor(textColor, false);
			}

			_TextTooltips[text] = spoof;
			AddProperties(spoof);
		}

		public sealed class Spoof : Entity
		{
			private static readonly char[] _Split = { '\n' };
			private static int _UID = -1;

			private static int NewUID
			{
				get
				{
					if (_UID == Int32.MinValue)
					{
						_UID = -1;
					}

					return --_UID;
				}
			}

			public static int[] EmptyClilocs =
			{
				1042971, 1070722, // ~1_NOTHING~
			    1114057, 1114778, 1114779, // ~1_val~
			    1150541, // ~1_TOKEN~
			    1153153, // ~1_year~
            };

			private static readonly List<Spoof> _SpoofPool = new();

			public static Spoof Acquire()
			{
				if (_SpoofPool.Count == 0)
				{
					return new Spoof();
				}

				var spoof = _SpoofPool[0];

				_ = _SpoofPool.Remove(spoof);

				return spoof;
			}

			public void Free()
			{
				Packet.Release(ref _PropertyList);

				_Text = String.Empty;
				_ClilocTable = null;

				_SpoofPool.Add(this);
			}

			private ObjectPropertyList _PropertyList;

			public ObjectPropertyList PropertyList
			{
				get
				{
					if (_PropertyList == null)
					{
						_PropertyList = new ObjectPropertyList(this);

						if (!String.IsNullOrEmpty(Text))
						{
							var text = StripHtmlBreaks(Text, true);

							if (text.IndexOf('\n') >= 0)
							{
								var lines = text.Split(_Split);

								foreach (var str in lines)
								{
									_PropertyList.Add(str);
								}
							}
							else
							{
								_PropertyList.Add(text);
							}
						}
						else if (_ClilocTable != null)
						{
							foreach (var kvp in _ClilocTable)
							{
								var cliloc = kvp.Key;
								var args = kvp.Value;

								if (cliloc <= 0 && !String.IsNullOrEmpty(args))
								{
									_PropertyList.Add(args);
								}
								else if (String.IsNullOrEmpty(args))
								{
									_PropertyList.Add(cliloc);
								}
								else
								{
									_PropertyList.Add(cliloc, args);
								}
							}
						}

						_PropertyList.Terminate();
						_PropertyList.SetStatic();
					}

					return _PropertyList;
				}
			}

			private string _Text = String.Empty;

			public string Text
			{
				get => _Text ?? String.Empty;
				set
				{
					if (_Text != value)
					{
						_Text = value;

						Packet.Release(ref _PropertyList);
					}
				}
			}

			private Dictionary<int, string> _ClilocTable;

			public Dictionary<int, string> ClilocTable
			{
				get => _ClilocTable;
				set
				{
					if (_ClilocTable != value)
					{
						_ClilocTable = value;

						Packet.Release(ref _PropertyList);
					}
				}
			}

			public Spoof()
				: base(NewUID, Point3D.Zero, Map.Internal)
			{ }
		}

		public static string StripHtmlBreaks(string str, bool preserve)
		{
			return Regex.Replace(str, @"<br[^>]?>", preserve ? "\n" : " ", RegexOptions.IgnoreCase);
		}

		#endregion
	}
}