namespace Server.Commands.Generic
{
	public class GetCommand : BaseCommand
	{
		public GetCommand()
		{
			AccessLevel = AccessLevel.Counselor;
			Supports = CommandSupport.All;
			Commands = new string[] { "Get" };
			ObjectTypes = ObjectTypes.All;
			Usage = "Get <propertyName>";
			Description = "Gets one or more property values by name of a targeted object.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			if (e.Length >= 1)
			{
				for (var i = 0; i < e.Length; ++i)
				{
					var result = Props.GetValue(e.Mobile, obj, e.GetString(i));

					if (result == "Property not found." || result == "Property is write only." || result.StartsWith("Getting this property"))
					{
						LogFailure(result);
					}
					else
					{
						AddResponse(result);
					}
				}
			}
			else
			{
				LogFailure("Format: Get <propertyName>");
			}
		}
	}
}