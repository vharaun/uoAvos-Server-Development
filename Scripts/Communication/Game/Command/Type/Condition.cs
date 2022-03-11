
using System;
using System.Collections;

namespace Server.Commands.Generic
{
	public class ConditionCommand : BaseCommand
	{
		public ConditionCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.Simple | CommandSupport.Complex | CommandSupport.Self;
			Commands = new string[] { "Condition" };
			ObjectTypes = ObjectTypes.All;
			Usage = "Condition <condition>";
			Description = "Checks that the given condition matches a targeted object.";
			ListOptimized = true;
		}

		public override void ExecuteList(CommandEventArgs e, ArrayList list)
		{
			try
			{
				var args = e.Arguments;
				var condition = ObjectConditional.Parse(e.Mobile, ref args);

				for (var i = 0; i < list.Count; ++i)
				{
					if (condition.CheckCondition(list[i]))
					{
						AddResponse("True - that object matches the condition.");
					}
					else
					{
						AddResponse("False - that object does not match the condition.");
					}
				}
			}
			catch (Exception ex)
			{
				e.Mobile.SendMessage(ex.Message);
			}
		}
	}
}