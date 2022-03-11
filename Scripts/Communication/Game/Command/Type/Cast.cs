using Server.Spells;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("Cast <name>")]
		[Description("Casts a spell by name.")]
		public static void Cast_OnCommand(CommandEventArgs e)
		{
			if (e.Length == 1)
			{
				if (!Multis.DesignContext.Check(e.Mobile))
				{
					return; // They are customizing
				}

				var spell = SpellRegistry.NewSpell(e.GetString(0), e.Mobile, null);

				if (spell != null)
				{
					spell.Cast();
				}
				else
				{
					e.Mobile.SendMessage("That spell was not found.");
				}
			}
			else
			{
				e.Mobile.SendMessage("Format: Cast <name>");
			}
		}
	}
}