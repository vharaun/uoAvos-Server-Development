using Server.Items;
using Server.Spells;

namespace Server.Commands.Generic
{
	public class TeleCommand : BaseCommand
	{
		public TeleCommand()
		{
			AccessLevel = AccessLevel.Counselor;
			Supports = CommandSupport.Simple;
			Commands = new string[] { "Teleport", "Tele" };
			ObjectTypes = ObjectTypes.All;
			Usage = "Teleport";
			Description = "Teleports your character to a targeted location.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			var p = obj as IPoint3D;

			if (p == null)
			{
				return;
			}

			var from = e.Mobile;

			SpellHelper.GetSurfaceTop(ref p);

			//CommandLogging.WriteLine( from, "{0} {1} teleporting to {2}", from.AccessLevel, CommandLogging.Format( from ), new Point3D( p ) );

			var fromLoc = from.Location;
			var toLoc = new Point3D(p);

			from.Location = toLoc;
			from.ProcessDelta();

			if (!from.Hidden)
			{
				Effects.SendLocationParticles(EffectItem.Create(fromLoc, from.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
				Effects.SendLocationParticles(EffectItem.Create(toLoc, from.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 5023);

				from.PlaySound(0x1FE);
			}
		}
	}
}