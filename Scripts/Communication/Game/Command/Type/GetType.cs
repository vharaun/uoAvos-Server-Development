
using System;

namespace Server.Commands.Generic
{
	public class GetTypeCommand : BaseCommand
	{
		public GetTypeCommand()
		{
			AccessLevel = AccessLevel.Counselor;
			Supports = CommandSupport.All;
			Commands = new string[] { "GetType" };
			ObjectTypes = ObjectTypes.All;
			Usage = "GetType";
			Description = "Gets the type name of a targeted object.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			if (obj == null)
			{
				AddResponse("The object is null.");
			}
			else
			{
				var type = obj.GetType();

				if (type.DeclaringType == null)
				{
					AddResponse(String.Format("The type of that object is {0}.", type.Name));
				}
				else
				{
					AddResponse(String.Format("The type of that object is {0}.", type.FullName));
				}
			}
		}
	}
}