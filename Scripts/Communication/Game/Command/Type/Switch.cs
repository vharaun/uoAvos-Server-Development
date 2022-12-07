using System;

namespace Server.Commands.Generic
{
	public class SwitchCommand : BaseCommand
	{
		public SwitchCommand()
		{
			AccessLevel = AccessLevel.Counselor;
			Supports = CommandSupport.All;
			Commands = new string[] { "Switch" };
			ObjectTypes = ObjectTypes.All;
			Usage = "Switch <propertyName> [...]";
			Description = "Switch one or more boolean property values to their opposite states by name of a targeted object.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			if (e.Length >= 1)
			{
				for (var i = 0; i < e.Length; i++)
				{
					var prop = e.GetString(i);

					var value = Props.GetValue(e.Mobile, obj, prop);

					if (Boolean.TryParse(value, out var state))
					{
						state = !state;

						var result = Props.SetValue(e.Mobile, obj, prop, state.ToString());

						if (result == "Property has been set.")
						{
							AddResponse("Property has been switched.");
						}
						else
						{
							LogFailure(result);
						}
					}
					else
					{
						LogFailure("Property is not a boolean type.");
					}
				}
			}
			else
			{
				LogFailure("Format: Switch <propertyName>");
			}
		}
	}
}