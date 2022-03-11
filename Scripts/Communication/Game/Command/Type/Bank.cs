using Server.Targeting;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("Bank")]
		[Description("Opens the bank box of a given target.")]
		public static void Bank_OnCommand(CommandEventArgs e)
		{
			e.Mobile.Target = new BankTarget();
		}

		private class BankTarget : Target
		{
			public BankTarget() : base(-1, false, TargetFlags.None)
			{
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (targeted is Mobile)
				{
					var m = (Mobile)targeted;

					var box = (m.Player ? m.BankBox : m.FindBankNoCreate());

					if (box != null)
					{
						CommandLogging.WriteLine(from, "{0} {1} opening bank box of {2}", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(targeted));

						if (from == targeted)
						{
							box.Open();
						}
						else
						{
							box.DisplayTo(from);
						}
					}
					else
					{
						from.SendMessage("They have no bank box.");
					}
				}
			}
		}
	}
}