﻿using Server.Items;
using Server.Targeting;

using System;

namespace Server.Commands
{
	public class Dupe
	{
		public static void Initialize()
		{
			CommandSystem.Register("Dupe", AccessLevel.GameMaster, new CommandEventHandler(Dupe_OnCommand));
			CommandSystem.Register("DupeInBag", AccessLevel.GameMaster, new CommandEventHandler(DupeInBag_OnCommand));
		}

		[Usage("Dupe [amount]")]
		[Description("Dupes a targeted item.")]
		private static void Dupe_OnCommand(CommandEventArgs e)
		{
			var amount = 1;
			if (e.Length >= 1)
			{
				amount = e.GetInt32(0);
			}

			e.Mobile.Target = new DupeTarget(false, amount > 0 ? amount : 1);
			e.Mobile.SendMessage("What do you wish to dupe?");
		}

		[Usage("DupeInBag <count>")]
		[Description("Dupes an item at it's current location (count) number of times.")]
		private static void DupeInBag_OnCommand(CommandEventArgs e)
		{
			var amount = 1;
			if (e.Length >= 1)
			{
				amount = e.GetInt32(0);
			}

			e.Mobile.Target = new DupeTarget(true, amount > 0 ? amount : 1);
			e.Mobile.SendMessage("What do you wish to dupe?");
		}

		private class DupeTarget : Target
		{
			private readonly bool m_InBag;
			private readonly int m_Amount;

			public DupeTarget(bool inbag, int amount)
				: base(15, false, TargetFlags.None)
			{
				m_InBag = inbag;
				m_Amount = amount;
			}

			protected override void OnTarget(Mobile from, object targ)
			{
				var done = false;
				if (!(targ is Item))
				{
					from.SendMessage("You can only dupe items.");
					return;
				}

				CommandLogging.WriteLine(from, "{0} {1} duping {2} (inBag={3}; amount={4})", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(targ), m_InBag, m_Amount);

				var copy = (Item)targ;
				Container pack;

				if (m_InBag)
				{
					if (copy.Parent is Container)
					{
						pack = (Container)copy.Parent;
					}
					else if (copy.Parent is Mobile)
					{
						pack = ((Mobile)copy.Parent).Backpack;
					}
					else
					{
						pack = null;
					}
				}
				else
				{
					pack = from.Backpack;
				}

				var t = copy.GetType();

				//ConstructorInfo[] info = t.GetConstructors();

				var c = t.GetConstructor(Type.EmptyTypes);

				if (c != null)
				{
					try
					{
						from.SendMessage("Duping {0}...", m_Amount);
						for (var i = 0; i < m_Amount; i++)
						{
							var o = c.Invoke(null);

							if (o != null && o is Item)
							{
								var newItem = (Item)o;
								CopyProperties(newItem, copy);//copy.Dupe( item, copy.Amount );
								copy.OnAfterDuped(newItem);
								newItem.Parent = null;

								if (pack != null)
								{
									pack.DropItem(newItem);
								}
								else
								{
									newItem.MoveToWorld(from.Location, from.Map);
								}

								newItem.InvalidateProperties();

								CommandLogging.WriteLine(from, "{0} {1} duped {2} creating {3}", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(targ), CommandLogging.Format(newItem));
							}
						}
						from.SendMessage("Done");
						done = true;
					}
					catch
					{
						from.SendMessage("Error!");
						return;
					}
				}

				if (!done)
				{
					from.SendMessage("Unable to dupe.  Item must have a 0 parameter constructor.");
				}
			}
		}

		public static void CopyProperties(Item dest, Item src)
		{
			var props = src.GetType().GetProperties();

			for (var i = 0; i < props.Length; i++)
			{
				try
				{
					if (props[i].CanRead && props[i].CanWrite)
					{
						//Console.WriteLine( "Setting {0} = {1}", props[i].Name, props[i].GetValue( src, null ) );
						props[i].SetValue(dest, props[i].GetValue(src, null), null);
					}
				}
				catch
				{
					//Console.WriteLine( "Denied" );
				}
			}
		}
	}
}