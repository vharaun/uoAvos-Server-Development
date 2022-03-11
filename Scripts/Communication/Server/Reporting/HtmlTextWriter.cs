
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

#region Developer Notations

/// Copyright © 2019 Max Feingold | License: MIT License (https://www.mit.edu/~amini/LICENSE.md)
/// 
/// What Is This For:
///  
/// HtmlTextWriter is a simple, drop-in replacement for the .NET Framework's: 
/// [System.Web.UI.HtmlWriter](https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.htmltextwriter?view=netframework-4.8) class, 
/// which is not yet included in .NET Standard.
/// 
/// Target Uses:
/// 
/// This library is intended for apps ported from .NET Framework to Xamarin, UWP, or .NET Core in general, and which use 
/// System.Web.UI.HtmlWriter to generate simple HTML content. 
/// If you're writing new code in .NET Core, presumably there's an ASP.NET Core thing you can use instead.
/// 
/// Gaps:
/// 
/// This library is a reimplementation, and may not be character-for-character compatible with the original. E.g. linebreak handling 
/// may be subtly different. That's probably okay.
///
/// The original HtmlTextWriter has a number of features that this one doesn't support yet:
/// 
/// - Styles
/// - Non-closing tags, such as `<hr>` or `<meta>`
/// - Most of the protected members used by derived classes.
/// 
/// If your scenarios require these things, or if you find a bug, feel free to submit a PR.

#endregion

namespace System.Web.UI
{
	public class HtmlTextWriter : TextWriter
	{
		//
		// Constants
		//

		public const string DefaultTabString = "\t";
		public const char DoubleQuoteChar = '"';
		public const string EndTagLeftChars = "</";
		public const char EqualsChar = '=';
		public const string EqualsDoubleQuoteString = "=\"";
		public const string SelfClosingChars = " /";
		public const string SelfClosingTagEnd = " />";
		public const char SemicolonChar = ';';
		public const char SingleQuoteChar = '\'';
		public const char SlashChar = '/';
		public const char SpaceChar = ' ';
		public const char StyleEqualsChar = ':';
		public const char TagLeftChar = '<';
		public const char TagRightChar = '>';
		public const string StyleDeclaringString = "style";

		//
		// Members
		//

		private readonly string tabString = DefaultTabString;
		private Stack<string> openTags;
		private List<KeyValuePair<string, string>> attributes;
		private List<KeyValuePair<string, string>> styleAttributes;
		private int indent;
		private bool lineWasIndented;
		private bool pendingCloseTag;

		//
		// Constructors
		//

		public HtmlTextWriter(TextWriter writer) : this(writer, DefaultTabString)
		{
		}

		public HtmlTextWriter(TextWriter writer, string tabString)
		{
			InnerWriter = writer;
			this.tabString = tabString;
		}

		//
		// Properties
		//

		public TextWriter InnerWriter { get; set; }

		public int Indent
		{
			get => indent;
			set
			{
				if (value < 0)
				{
					value = 0;
				}

				indent = value;
			}
		}
		public override string NewLine => InnerWriter.NewLine;
		public override Encoding Encoding => InnerWriter.Encoding;

		//
		// Begin, end
		//

		public void BeginRender() { }
		public void EndRender() { }

		//
		// AddAttribute
		//

		public void AddAttribute(HtmlTextWriterAttribute key, string value)
		{
			AddAttribute(key, value, true);
		}

		public void AddAttribute(HtmlTextWriterAttribute key, string value, bool encode)
		{
			AddAttribute(key.ToName(), value, encode);
		}

		public void AddAttribute(string name, string value)
		{
			AddAttribute(name, value, true);
		}

		public void AddAttribute(string name, string value, bool encode)
		{
			if (encode)
			{
				value = WebUtility.HtmlEncode(value);
			}

			if (attributes == null)
			{
				attributes = new List<KeyValuePair<string, string>>();
			}

			attributes.Add(new KeyValuePair<string, string>(name, value));
		}
		public void AddStyleAttribute(HtmlTextWriterStyle key, string value)
		{
			AddStyleAttribute(key, value, true);
		}

		public void AddStyleAttribute(HtmlTextWriterStyle key, string value, bool encode)
		{
			AddStyleAttribute(key.ToName(), value, encode);
		}

		public void AddStyleAttrbiute(string name, string value)
		{
			AddStyleAttribute(name, value, true);
		}

		public void AddStyleAttribute(string name, string value, bool encode)
		{
			if (encode)
			{
				value = WebUtility.HtmlEncode(value);
			}

			if (styleAttributes == null)
			{
				styleAttributes = new List<KeyValuePair<string, string>>();
			}

			styleAttributes.Add(new KeyValuePair<string, string>(name, value));
		}

		//
		// Tags
		//

		public void RenderBeginTag(HtmlTextWriterTag tagKey)
		{
			RenderBeginTag(tagKey.ToName());
		}

		public void RenderBeginTag(string name)
		{
			WriteBeginTag(name);

			if (attributes != null)
			{
				foreach (var attribute in attributes)
				{
					WriteAttribute(attribute.Key, attribute.Value, false); // Already encoded
				}

				attributes.Clear();
			}

			if (styleAttributes != null && styleAttributes.Any())
			{
				Write($"{SpaceChar}{StyleDeclaringString}{EqualsDoubleQuoteString}");
				foreach (var styleAttribute in styleAttributes)
				{
					WriteStyleAttribute(styleAttribute.Key, styleAttribute.Value, false);
				}

				Write(DoubleQuoteChar);
				styleAttributes.Clear();
			}

			if (openTags == null)
			{
				openTags = new Stack<string>();
			}

			openTags.Push(name);

			Indent++;
			pendingCloseTag = true;
		}

		public void RenderEndTag()
		{
			if (openTags == null || !openTags.Any())
			{
				throw new InvalidOperationException();
			}

			var tag = openTags.Pop();
			Indent--;

			if (pendingCloseTag)
			{
				InnerWriter.WriteLine(SelfClosingTagEnd);
				AfterWriteLine();
			}
			else
			{
				if (lineWasIndented)
				{
					WriteLine();
				}

				WriteLine($"{EndTagLeftChars}{tag}{TagRightChar}");
			}

			pendingCloseTag = false;
		}

		private void CloseTagIfNecessary(bool newline = true)
		{
			if (pendingCloseTag)
			{
				InnerWriter.Write(TagRightChar);
				pendingCloseTag = false;

				if (newline)
				{
					WriteLine();
				}
			}
		}

		private async Task CloseTagIfNecessaryAsync(bool newline = true)
		{
			if (pendingCloseTag)
			{
				await InnerWriter.WriteAsync(TagRightChar);
				pendingCloseTag = false;

				if (newline)
				{
					await WriteLineAsync();
				}
			}
		}

		//
		// Indents
		//

		private void IndentIfNecessary()
		{
			if (!lineWasIndented)
			{
				for (var i = 0; i < Indent; i++)
				{
					InnerWriter.Write(tabString);
				}

				lineWasIndented = true;
			}
		}

		private async Task IndentIfNecessaryAsync()
		{
			if (!lineWasIndented)
			{
				for (var i = 0; i < Indent; i++)
				{
					await InnerWriter.WriteAsync(tabString);
				}

				lineWasIndented = true;
			}
		}

		private void ResetIndent()
		{
			lineWasIndented = false;
		}

		//
		// Coordination
		//

		private void BeforeWrite(bool indent = true, bool newLineIfClosingTag = true)
		{
			CloseTagIfNecessary(newLineIfClosingTag);
			if (indent)
			{
				IndentIfNecessary();
			}
		}

		private async Task BeforeWriteAsync(bool indent = true, bool newLineIfClosingTag = true)
		{
			await CloseTagIfNecessaryAsync(newLineIfClosingTag);
			if (indent)
			{
				await IndentIfNecessaryAsync();
			}
		}

		private void AfterWriteLine()
		{
			ResetIndent();
		}

		//
		// HTML-specific writes
		//

		public void WriteAttribute(string name, string value)
		{
			WriteAttribute(name, value, true);
		}

		public void WriteAttribute(string name, string value, bool encode)
		{
			Write($"{SpaceChar}{name}");

			if (value != null)
			{
				if (encode)
				{
					value = WebUtility.HtmlEncode(value);
				}

				Write($"{EqualsDoubleQuoteString}{value}{DoubleQuoteChar}");
			}
		}

		public void WriteStyleAttribute(string name, string value)
		{
			WriteStyleAttribute(name, value, true);
		}

		public void WriteStyleAttribute(string name, string value, bool encode)
		{
			if (name != null && value != null)
			{
				Write($"{name}{StyleEqualsChar}");
				if (encode)
				{
					value = WebUtility.HtmlEncode(value);
				}

				Write($"{value}{SemicolonChar}{SpaceChar}");
			}
		}

		public void WriteBeginTag(string name)
		{
			Write($"{TagLeftChar}{name}");
		}

		public void WriteBreak()
		{
			Write($"{TagLeftChar}{HtmlTextWriterTag.Br.ToName()}{SelfClosingTagEnd}");
		}

		public void WriteEncodedText(string text)
		{
			Write(WebUtility.HtmlEncode(text));
		}

		public void WriteEncodedUrl(string url)
		{
			var index = url.IndexOf('?');
			if (index != -1)
			{
				Write($"{Uri.EscapeUriString(url.Substring(0, index))}{url.Substring(index)}");
			}
			else
			{
				Write(Uri.EscapeUriString(url));
			}
		}

		public void WriteEncodedUrlParameter(string urlText)
		{
			Write(Uri.EscapeUriString(urlText));
		}

		public void WriteEndTag(string tagName)
		{
			Write($"{TagLeftChar}{SlashChar}{tagName}{TagRightChar}");
		}

		public void WriteFullBeginTag(string tagName)
		{
			Write($"{TagLeftChar}{tagName}{TagRightChar}");
		}

		public void WriteLineNoTabs(string line)
		{
			WriteLine(line);
		}

		//
		// Close/Flush
		//

#if NETSTANDARD1_4
        public void Close() { }
#else
		public override void Close()
		{
			InnerWriter.Close();
		}
#endif
		public override void Flush()
		{
			InnerWriter.Flush();
		}

		public override Task FlushAsync()
		{
			return InnerWriter.FlushAsync();
		}

		//
		// Write
		//

		public override void Write(ulong value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override void Write(uint value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override void Write(string format, params object[] arg)
		{
			BeforeWrite();
			InnerWriter.Write(format, arg);
		}

		public override void Write(string format, object arg0, object arg1, object arg2)
		{
			BeforeWrite();
			InnerWriter.Write(format, arg0, arg1, arg2);
		}

		public override void Write(string format, object arg0, object arg1)
		{
			BeforeWrite();
			InnerWriter.Write(format, arg0, arg1);
		}

		public override void Write(string format, object arg0)
		{
			BeforeWrite();
			InnerWriter.Write(format, arg0);
		}

		public override void Write(string value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override void Write(object value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override void Write(long value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override void Write(int value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override void Write(double value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override void Write(decimal value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override void Write(char[] buffer, int index, int count)
		{
			BeforeWrite();
			InnerWriter.Write(buffer, index, count);
		}

		public override void Write(char[] buffer)
		{
			BeforeWrite();
			InnerWriter.Write(buffer);
		}

		public override void Write(char value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override void Write(bool value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override void Write(float value)
		{
			BeforeWrite();
			InnerWriter.Write(value);
		}

		public override async Task WriteAsync(string value)
		{
			await BeforeWriteAsync();
			await InnerWriter.WriteAsync(value);
		}

		public override async Task WriteAsync(char value)
		{
			await BeforeWriteAsync();
			await InnerWriter.WriteAsync(value);
		}

		public override async Task WriteAsync(char[] buffer, int index, int count)
		{
			await BeforeWriteAsync();
			await InnerWriter.WriteAsync(buffer, index, count);
		}

		//
		// WriteLine
		//

		public override void WriteLine(string format, object arg0)
		{
			BeforeWrite();
			InnerWriter.WriteLine(format, arg0);
			AfterWriteLine();
		}

		public override void WriteLine(ulong value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override void WriteLine(uint value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override void WriteLine(string format, params object[] arg)
		{
			BeforeWrite();
			InnerWriter.WriteLine(format, arg);
			AfterWriteLine();
		}

		public override void WriteLine(string format, object arg0, object arg1, object arg2)
		{
			BeforeWrite();
			InnerWriter.WriteLine(format, arg0, arg1, arg2);
			AfterWriteLine();
		}

		public override void WriteLine(string format, object arg0, object arg1)
		{
			BeforeWrite();
			InnerWriter.WriteLine(format, arg0, arg1);
			AfterWriteLine();
		}

		public override void WriteLine(string value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override void WriteLine(float value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override void WriteLine()
		{
			BeforeWrite(indent: false, newLineIfClosingTag: false);
			InnerWriter.WriteLine();
			AfterWriteLine();
		}

		public override void WriteLine(long value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override void WriteLine(int value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override void WriteLine(double value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override void WriteLine(decimal value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override void WriteLine(char[] buffer, int index, int count)
		{
			BeforeWrite();
			InnerWriter.WriteLine(buffer, index, count);
			AfterWriteLine();
		}

		public override void WriteLine(char[] buffer)
		{
			BeforeWrite();
			InnerWriter.WriteLine(buffer);
			AfterWriteLine();
		}

		public override void WriteLine(char value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override void WriteLine(bool value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override void WriteLine(object value)
		{
			BeforeWrite();
			InnerWriter.WriteLine(value);
			AfterWriteLine();
		}

		public override async Task WriteLineAsync()
		{
			await BeforeWriteAsync();
			await InnerWriter.WriteLineAsync();
			AfterWriteLine();
		}

		public override async Task WriteLineAsync(char value)
		{
			await BeforeWriteAsync();
			await InnerWriter.WriteLineAsync(value);
			AfterWriteLine();
		}

		public override async Task WriteLineAsync(char[] buffer, int index, int count)
		{
			await BeforeWriteAsync();
			await InnerWriter.WriteLineAsync(buffer, index, count);
			AfterWriteLine();
		}

		public override async Task WriteLineAsync(string value)
		{
			await BeforeWriteAsync();
			await InnerWriter.WriteLineAsync(value);
			AfterWriteLine();
		}
	}

	public enum HtmlTextWriterAttribute
	{
		Accesskey = 0,
		Align = 1,
		Alt = 2,
		Background = 3,
		Bgcolor = 4,
		Border = 5,
		Bordercolor = 6,
		Cellpadding = 7,
		Cellspacing = 8,
		Checked = 9,
		Class = 10,
		Cols = 11,
		Colspan = 12,
		Disabled = 13,
		For = 14,
		Height = 15,
		Href = 16,
		Id = 17,
		Maxlength = 18,
		Multiple = 19,
		Name = 20,
		Nowrap = 21,
		Onchange = 22,
		Onclick = 23,
		ReadOnly = 24,
		Rows = 25,
		Rowspan = 26,
		Rules = 27,
		Selected = 28,
		Size = 29,
		Src = 30,
		Style = 31,
		Tabindex = 32,
		Target = 33,
		Title = 34,
		Type = 35,
		Valign = 36,
		Value = 37,
		Width = 38,
		Wrap = 39,
		Abbr = 40,
		AutoComplete = 41,
		Axis = 42,
		Content = 43,
		Coords = 44,
		DesignerRegion = 45,
		Dir = 46,
		Headers = 47,
		Longdesc = 48,
		Rel = 49,
		Scope = 50,
		Shape = 51,
		Usemap = 52,
		VCardName = 53
	}

	public static class HtmlTextWriterAttributeExtensions
	{
		private static readonly Dictionary<HtmlTextWriterAttribute, string> s_attributes = new Dictionary<HtmlTextWriterAttribute, string>
		{
			{ HtmlTextWriterAttribute.Accesskey, "accesskey" },
			{ HtmlTextWriterAttribute.Align, "align" },
			{ HtmlTextWriterAttribute.Alt, "alt" },
			{ HtmlTextWriterAttribute.Background, "background" },
			{ HtmlTextWriterAttribute.Bgcolor, "bgcolor" },
			{ HtmlTextWriterAttribute.Border, "border" },
			{ HtmlTextWriterAttribute.Bordercolor, "bordercolor" },
			{ HtmlTextWriterAttribute.Cellpadding, "cellpadding" },
			{ HtmlTextWriterAttribute.Cellspacing, "cellspacing" },
			{ HtmlTextWriterAttribute.Checked, "checked" },
			{ HtmlTextWriterAttribute.Class, "class" },
			{ HtmlTextWriterAttribute.Cols, "cols" },
			{ HtmlTextWriterAttribute.Colspan, "colspan" },
			{ HtmlTextWriterAttribute.Disabled, "disabled" },
			{ HtmlTextWriterAttribute.For, "for" },
			{ HtmlTextWriterAttribute.Height, "height" },
			{ HtmlTextWriterAttribute.Href, "href" },
			{ HtmlTextWriterAttribute.Id, "id" },
			{ HtmlTextWriterAttribute.Maxlength, "maxlength" },
			{ HtmlTextWriterAttribute.Multiple, "multiple" },
			{ HtmlTextWriterAttribute.Name, "name" },
			{ HtmlTextWriterAttribute.Nowrap, "nowrap" },
			{ HtmlTextWriterAttribute.Onchange, "onchange" },
			{ HtmlTextWriterAttribute.Onclick, "onclick" },
			{ HtmlTextWriterAttribute.ReadOnly, "readonly" },
			{ HtmlTextWriterAttribute.Rows, "rows" },
			{ HtmlTextWriterAttribute.Rowspan, "rowspan" },
			{ HtmlTextWriterAttribute.Rules, "rules" },
			{ HtmlTextWriterAttribute.Selected, "selected" },
			{ HtmlTextWriterAttribute.Size, "size" },
			{ HtmlTextWriterAttribute.Src, "src" },
			{ HtmlTextWriterAttribute.Style, "style" },
			{ HtmlTextWriterAttribute.Tabindex, "tabindex" },
			{ HtmlTextWriterAttribute.Target, "target" },
			{ HtmlTextWriterAttribute.Title, "title" },
			{ HtmlTextWriterAttribute.Type, "type" },
			{ HtmlTextWriterAttribute.Valign, "valign" },
			{ HtmlTextWriterAttribute.Value, "value" },
			{ HtmlTextWriterAttribute.Width, "width" },
			{ HtmlTextWriterAttribute.Wrap, "wrap" },
			{ HtmlTextWriterAttribute.Abbr, "abbr" },
			{ HtmlTextWriterAttribute.AutoComplete, "autocomplete" },
			{ HtmlTextWriterAttribute.Axis, "axis" },
			{ HtmlTextWriterAttribute.Content, "content" },
			{ HtmlTextWriterAttribute.Coords, "coords" },
			{ HtmlTextWriterAttribute.DesignerRegion, "designerregion" },
			{ HtmlTextWriterAttribute.Dir, "dir" },
			{ HtmlTextWriterAttribute.Headers, "headers" },
			{ HtmlTextWriterAttribute.Longdesc, "longdesc" },
			{ HtmlTextWriterAttribute.Rel, "rel" },
			{ HtmlTextWriterAttribute.Scope, "scope" },
			{ HtmlTextWriterAttribute.Shape, "shape" },
			{ HtmlTextWriterAttribute.Usemap, "usemap" },
			{ HtmlTextWriterAttribute.VCardName, "vcardname" },
		};

		public static string ToName(this HtmlTextWriterAttribute attribute)
		{
			return s_attributes[attribute];
		}
	}

	public enum HtmlTextWriterStyle
	{
		BackgroundColor = 0,
		BackgroundImage = 1,
		BorderCollapse = 2,
		BorderColor = 3,
		BorderStyle = 4,
		BorderWidth = 5,
		Color = 6,
		FontFamily = 7,
		FontSize = 8,
		FontStyle = 9,
		FontWeight = 10,
		Height = 11,
		TextDecoration = 12,
		Width = 13,
		ListStyleImage = 14,
		ListStyleType = 15,
		Cursor = 16,
		Direction = 17,
		Display = 18,
		Filter = 19,
		FontVariant = 20,
		Left = 21,
		Margin = 22,
		MarginBottom = 23,
		MarginLeft = 24,
		MarginRight = 25,
		MarginTop = 26,
		Overflow = 27,
		OverflowX = 28,
		OverflowY = 29,
		Padding = 30,
		PaddingBottom = 31,
		PaddingLeft = 32,
		PaddingRight = 33,
		PaddingTop = 34,
		Position = 35,
		TextAlign = 36,
		VerticalAlign = 37,
		TextOverflow = 38,
		Top = 39,
		Visibility = 40,
		WhiteSpace = 41,
		ZIndex = 42
	}

	public static class HtmlTextWriterStyleExtensions
	{
		private static readonly Dictionary<HtmlTextWriterStyle, string> s_attributes = new Dictionary<HtmlTextWriterStyle, string>
		{
			{HtmlTextWriterStyle.BackgroundColor, "Background-Color" },
			{HtmlTextWriterStyle.BackgroundImage, "Background-Image" },
			{HtmlTextWriterStyle.BorderCollapse, "BorderCollapse" },
			{HtmlTextWriterStyle.BorderColor, "Border-Color" },
			{HtmlTextWriterStyle.BorderStyle, "Border-Style" },
			{HtmlTextWriterStyle.BorderWidth, "Border-Width" },
			{HtmlTextWriterStyle.Color, "Color" },
			{HtmlTextWriterStyle.Cursor, "Cursor" },
			{HtmlTextWriterStyle.Direction, "Direction" },
			{HtmlTextWriterStyle.Display, "Display" },
			{HtmlTextWriterStyle.Filter, "Filter" },
			{HtmlTextWriterStyle.FontFamily, "Font-Family" },
			{HtmlTextWriterStyle.FontSize, "Font-Size" },
			{HtmlTextWriterStyle.FontStyle, "Font-Style" },
			{HtmlTextWriterStyle.FontVariant, "Font-Variant" },
			{HtmlTextWriterStyle.FontWeight, "Font-Weight" },
			{HtmlTextWriterStyle.Height, "Height" },
			{HtmlTextWriterStyle.Left, "Left" },
			{HtmlTextWriterStyle.ListStyleImage, "List-Style-Image" },
			{HtmlTextWriterStyle.ListStyleType, "List-Style-Type" },
			{HtmlTextWriterStyle.Margin, "Margin" },
			{HtmlTextWriterStyle.MarginBottom, "Margin-Bottom" },
			{HtmlTextWriterStyle.MarginLeft, "Margin-Left" },
			{HtmlTextWriterStyle.MarginRight, "Margin-Right" },
			{HtmlTextWriterStyle.MarginTop, "Margin-Top" },
			{HtmlTextWriterStyle.Overflow, "Overflow" },
			{HtmlTextWriterStyle.OverflowX, "OverflowX" },
			{HtmlTextWriterStyle.OverflowY, "OverflowY" },
			{HtmlTextWriterStyle.Padding, "Padding" },
			{HtmlTextWriterStyle.PaddingBottom, "Padding-Bottom" },
			{HtmlTextWriterStyle.PaddingLeft, "Padding-Left" },
			{HtmlTextWriterStyle.PaddingRight, "Padding-Right" },
			{HtmlTextWriterStyle.PaddingTop, "Padding-Top" },
			{HtmlTextWriterStyle.Position, "Position" },
			{HtmlTextWriterStyle.TextAlign, "Text-Align" },
			{HtmlTextWriterStyle.TextDecoration, "Text-Decoration" },
			{HtmlTextWriterStyle.TextOverflow, "Text-Overflow" },
			{HtmlTextWriterStyle.Top, "Top" },
			{HtmlTextWriterStyle.VerticalAlign, "Vertical-Align" },
			{HtmlTextWriterStyle.Visibility, "Visibility" },
			{HtmlTextWriterStyle.WhiteSpace, "White-Space" },
			{HtmlTextWriterStyle.Width, "Width" },
			{HtmlTextWriterStyle.ZIndex, "ZIndex" },
		};
		public static string ToName(this HtmlTextWriterStyle attributeVal)
		{
			return s_attributes[attributeVal];
		}
	}

	public enum HtmlTextWriterTag
	{
		Unknown = 0,
		A = 1,
		Acronym = 2,
		Address = 3,
		Area = 4,
		B = 5,
		Base = 6,
		Basefont = 7,
		Bdo = 8,
		Bgsound = 9,
		Big = 10,
		Blockquote = 11,
		Body = 12,
		Br = 13,
		Button = 14,
		Caption = 15,
		Center = 16,
		Cite = 17,
		Code = 18,
		Col = 19,
		Colgroup = 20,
		Dd = 21,
		Del = 22,
		Dfn = 23,
		Dir = 24,
		Div = 25,
		Dl = 26,
		Dt = 27,
		Em = 28,
		Embed = 29,
		Fieldset = 30,
		Font = 31,
		Form = 32,
		Frame = 33,
		Frameset = 34,
		H1 = 35,
		H2 = 36,
		H3 = 37,
		H4 = 38,
		H5 = 39,
		H6 = 40,
		Head = 41,
		Hr = 42,
		Html = 43,
		I = 44,
		Iframe = 45,
		Img = 46,
		Input = 47,
		Ins = 48,
		Isindex = 49,
		Kbd = 50,
		Label = 51,
		Legend = 52,
		Li = 53,
		Link = 54,
		Map = 55,
		Marquee = 56,
		Menu = 57,
		Meta = 58,
		Nobr = 59,
		Noframes = 60,
		Noscript = 61,
		Object = 62,
		Ol = 63,
		Option = 64,
		P = 65,
		Param = 66,
		Pre = 67,
		Q = 68,
		Rt = 69,
		Ruby = 70,
		S = 71,
		Samp = 72,
		Script = 73,
		Select = 74,
		Small = 75,
		Span = 76,
		Strike = 77,
		Strong = 78,
		Style = 79,
		Sub = 80,
		Sup = 81,
		Table = 82,
		Tbody = 83,
		Td = 84,
		Textarea = 85,
		Tfoot = 86,
		Th = 87,
		Thead = 88,
		Title = 89,
		Tr = 90,
		Tt = 91,
		U = 92,
		Ul = 93,
		Var = 94,
		Wbr = 95,
		Xml = 96
	}

	public static class HtmlTextWriterTagExtensions
	{
		private static readonly Dictionary<HtmlTextWriterTag, string> s_attributes = new Dictionary<HtmlTextWriterTag, string>
		{
			{ HtmlTextWriterTag.A, "a" },
			{ HtmlTextWriterTag.Acronym, "acronym" },
			{ HtmlTextWriterTag.Address, "address" },
			{ HtmlTextWriterTag.Area, "area" },
			{ HtmlTextWriterTag.B, "b" },
			{ HtmlTextWriterTag.Base, "base" },
			{ HtmlTextWriterTag.Basefont, "basefont" },
			{ HtmlTextWriterTag.Bdo, "bdo" },
			{ HtmlTextWriterTag.Bgsound, "bgsound" },
			{ HtmlTextWriterTag.Big, "big" },
			{ HtmlTextWriterTag.Blockquote, "blockquote" },
			{ HtmlTextWriterTag.Body, "body" },
			{ HtmlTextWriterTag.Br, "br" },
			{ HtmlTextWriterTag.Button, "button" },
			{ HtmlTextWriterTag.Caption, "caption" },
			{ HtmlTextWriterTag.Center, "center" },
			{ HtmlTextWriterTag.Cite, "cite" },
			{ HtmlTextWriterTag.Code, "code" },
			{ HtmlTextWriterTag.Col, "col" },
			{ HtmlTextWriterTag.Colgroup, "colgroup" },
			{ HtmlTextWriterTag.Dd, "dd" },
			{ HtmlTextWriterTag.Del, "del" },
			{ HtmlTextWriterTag.Dfn, "dfn" },
			{ HtmlTextWriterTag.Dir, "dir" },
			{ HtmlTextWriterTag.Div, "div" },
			{ HtmlTextWriterTag.Dl, "dl" },
			{ HtmlTextWriterTag.Dt, "dt" },
			{ HtmlTextWriterTag.Em, "em" },
			{ HtmlTextWriterTag.Embed, "embed" },
			{ HtmlTextWriterTag.Fieldset, "fieldset" },
			{ HtmlTextWriterTag.Font, "font" },
			{ HtmlTextWriterTag.Form, "form" },
			{ HtmlTextWriterTag.Frame, "frame" },
			{ HtmlTextWriterTag.Frameset, "frameset" },
			{ HtmlTextWriterTag.H1, "h1" },
			{ HtmlTextWriterTag.H2, "h2" },
			{ HtmlTextWriterTag.H3, "h3" },
			{ HtmlTextWriterTag.H4, "h4" },
			{ HtmlTextWriterTag.H5, "h5" },
			{ HtmlTextWriterTag.H6, "h6" },
			{ HtmlTextWriterTag.Head, "head" },
			{ HtmlTextWriterTag.Hr, "hr" },
			{ HtmlTextWriterTag.Html, "html" },
			{ HtmlTextWriterTag.I, "i" },
			{ HtmlTextWriterTag.Iframe, "iframe" },
			{ HtmlTextWriterTag.Img, "img" },
			{ HtmlTextWriterTag.Input, "input" },
			{ HtmlTextWriterTag.Ins, "ins" },
			{ HtmlTextWriterTag.Isindex, "isindex" },
			{ HtmlTextWriterTag.Kbd, "kbd" },
			{ HtmlTextWriterTag.Label, "label" },
			{ HtmlTextWriterTag.Legend, "legend" },
			{ HtmlTextWriterTag.Li, "li" },
			{ HtmlTextWriterTag.Link, "link" },
			{ HtmlTextWriterTag.Map, "map" },
			{ HtmlTextWriterTag.Marquee, "marquee" },
			{ HtmlTextWriterTag.Menu, "menu" },
			{ HtmlTextWriterTag.Meta, "meta" },
			{ HtmlTextWriterTag.Nobr, "nobr" },
			{ HtmlTextWriterTag.Noframes, "noframes" },
			{ HtmlTextWriterTag.Noscript, "noscript" },
			{ HtmlTextWriterTag.Object, "object" },
			{ HtmlTextWriterTag.Ol, "ol" },
			{ HtmlTextWriterTag.Option, "option" },
			{ HtmlTextWriterTag.P, "p" },
			{ HtmlTextWriterTag.Param, "param" },
			{ HtmlTextWriterTag.Pre, "pre" },
			{ HtmlTextWriterTag.Q, "q" },
			{ HtmlTextWriterTag.Rt, "rt" },
			{ HtmlTextWriterTag.Ruby, "ruby" },
			{ HtmlTextWriterTag.S, "s" },
			{ HtmlTextWriterTag.Samp, "samp" },
			{ HtmlTextWriterTag.Script, "script" },
			{ HtmlTextWriterTag.Select, "select" },
			{ HtmlTextWriterTag.Small, "small" },
			{ HtmlTextWriterTag.Span, "span" },
			{ HtmlTextWriterTag.Strike, "strike" },
			{ HtmlTextWriterTag.Strong, "strong" },
			{ HtmlTextWriterTag.Style, "style" },
			{ HtmlTextWriterTag.Sub, "sub" },
			{ HtmlTextWriterTag.Sup, "sup" },
			{ HtmlTextWriterTag.Table, "table" },
			{ HtmlTextWriterTag.Tbody, "tbody" },
			{ HtmlTextWriterTag.Td, "td" },
			{ HtmlTextWriterTag.Textarea, "textarea" },
			{ HtmlTextWriterTag.Tfoot, "tfoot" },
			{ HtmlTextWriterTag.Th, "th" },
			{ HtmlTextWriterTag.Thead, "thead" },
			{ HtmlTextWriterTag.Title, "title" },
			{ HtmlTextWriterTag.Tr, "tr" },
			{ HtmlTextWriterTag.Tt, "tt" },
			{ HtmlTextWriterTag.U, "u" },
			{ HtmlTextWriterTag.Ul, "ul" },
			{ HtmlTextWriterTag.Var, "var" },
			{ HtmlTextWriterTag.Wbr, "wbr" },
			{ HtmlTextWriterTag.Xml, "xml" },
		};

		public static string ToName(this HtmlTextWriterTag attribute)
		{
			return s_attributes[attribute];
		}
	}
}