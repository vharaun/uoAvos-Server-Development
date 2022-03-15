using Server;
using Server.Commands;
using Server.Commands.Generic;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Engine.Facet
{
	public class MoveStaticCommand : BaseCommand
	{
		public MoveStaticCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.Single;
			Commands = new string[] { "MoveStatic" };
			ObjectTypes = ObjectTypes.All;
			Usage = "MoveStatic";
			Description = "Move a static.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			int newID = e.GetInt32(0);

			if (obj is StaticTarget)
			{
				e.Mobile.Target = new MoveStaticDestinationTarget((StaticTarget)obj, e.Mobile.Map.MapID);
			}
		}

		private class MoveStaticDestinationTarget : Target
		{
			protected StaticTarget m_StaticTarget;
			protected int m_MapID;

			public MoveStaticDestinationTarget(StaticTarget statTarget, int mapID) : base(-1, true, TargetFlags.None)
			{
				m_StaticTarget = statTarget;
				m_MapID = mapID;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (m_MapID != from.Map.MapID)
				{
					from.SendMessage("The targets must be in the same map.");

					return;
				}

				if (o is IPoint3D)
				{
					IPoint3D location = (IPoint3D)o;

					MoveStatic ms = new MoveStatic(from.Map.MapID, m_StaticTarget, location.X, location.Y);
					ms.DoOperation();
				}
			}
		}
	}
}