
using System;

namespace Server
{
	public interface IWeapon
	{
		int MaxRange { get; }
		void OnBeforeSwing(Mobile attacker, Mobile defender);
		TimeSpan OnSwing(Mobile attacker, Mobile defender);
		void GetStatusDamage(Mobile from, out int min, out int max);
	}
}