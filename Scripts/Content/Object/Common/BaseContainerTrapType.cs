
using System;

namespace Server.Items
{
	public enum TrapType
	{
		None,
		MagicTrap,
		ExplosionTrap,
		DartTrap,
		PoisonTrap
	}

	public abstract partial class TrapableContainer : BaseContainer, ITelekinesisable
	{
		public virtual bool ExecuteTrap(Mobile from)
		{
			if (m_TrapType != TrapType.None)
			{
				var loc = GetWorldLocation();
				var facet = Map;

				if (from.AccessLevel >= AccessLevel.GameMaster)
				{
					SendMessageTo(from, "That is trapped, but you open it with your godly powers.", 0x3B2);
					return false;
				}

				switch (m_TrapType)
				{
					case TrapType.ExplosionTrap:
						{
							SendMessageTo(from, 502999, 0x3B2); // You set off a trap!

							if (from.InRange(loc, 3))
							{
								int damage;

								if (m_TrapLevel > 0)
								{
									damage = Utility.RandomMinMax(10, 30) * m_TrapLevel;
								}
								else
								{
									damage = m_TrapPower;
								}

								AOS.Damage(from, damage, 0, 100, 0, 0, 0);

								// Your skin blisters from the heat!
								from.LocalOverheadMessage(Network.MessageType.Regular, 0x2A, 503000);
							}

							Effects.SendLocationEffect(loc, facet, 0x36BD, 15, 10);
							Effects.PlaySound(loc, facet, 0x307);

							break;
						}
					case TrapType.MagicTrap:
						{
							if (from.InRange(loc, 1))
							{
								from.Damage(m_TrapPower);
							}
							//AOS.Damage( from, m_TrapPower, 0, 100, 0, 0, 0 );

							Effects.PlaySound(loc, Map, 0x307);

							Effects.SendLocationEffect(new Point3D(loc.X - 1, loc.Y, loc.Z), Map, 0x36BD, 15);
							Effects.SendLocationEffect(new Point3D(loc.X + 1, loc.Y, loc.Z), Map, 0x36BD, 15);

							Effects.SendLocationEffect(new Point3D(loc.X, loc.Y - 1, loc.Z), Map, 0x36BD, 15);
							Effects.SendLocationEffect(new Point3D(loc.X, loc.Y + 1, loc.Z), Map, 0x36BD, 15);

							Effects.SendLocationEffect(new Point3D(loc.X + 1, loc.Y + 1, loc.Z + 11), Map, 0x36BD, 15);

							break;
						}
					case TrapType.DartTrap:
						{
							SendMessageTo(from, 502999, 0x3B2); // You set off a trap!

							if (from.InRange(loc, 3))
							{
								int damage;

								if (m_TrapLevel > 0)
								{
									damage = Utility.RandomMinMax(5, 15) * m_TrapLevel;
								}
								else
								{
									damage = m_TrapPower;
								}

								AOS.Damage(from, damage, 100, 0, 0, 0, 0);

								// A dart imbeds itself in your flesh!
								from.LocalOverheadMessage(Network.MessageType.Regular, 0x62, 502998);
							}

							Effects.PlaySound(loc, facet, 0x223);

							break;
						}
					case TrapType.PoisonTrap:
						{
							SendMessageTo(from, 502999, 0x3B2); // You set off a trap!

							if (from.InRange(loc, 3))
							{
								Poison poison;

								if (m_TrapLevel > 0)
								{
									poison = Poison.GetPoison(Math.Max(0, Math.Min(4, m_TrapLevel - 1)));
								}
								else
								{
									AOS.Damage(from, m_TrapPower, 0, 0, 0, 100, 0);
									poison = Poison.Greater;
								}

								from.ApplyPoison(from, poison);

								// You are enveloped in a noxious green cloud!
								from.LocalOverheadMessage(Network.MessageType.Regular, 0x44, 503004);
							}

							Effects.SendLocationEffect(loc, facet, 0x113A, 10, 20);
							Effects.PlaySound(loc, facet, 0x231);

							break;
						}
				}

				m_TrapType = TrapType.None;
				m_TrapPower = 0;
				m_TrapLevel = 0;
				return true;
			}

			return false;
		}
	}
}