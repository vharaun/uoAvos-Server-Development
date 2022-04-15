using System;

using BunnyHole = Server.Mobiles.VorpalBunny.BunnyHole;

namespace Server.Mobiles
{
	public class SummonedVorpalBunny : BaseTalismanSummon
	{
		[Constructable]
		public SummonedVorpalBunny() : base()
		{
			Name = "a vorpal bunny";
			Body = 205;
			Hue = 0x480;
			BaseSoundID = 0xC9;

			Timer.DelayCall(TimeSpan.FromMinutes(30.0), BeginTunnel);
		}

		public SummonedVorpalBunny(Serial serial) : base(serial)
		{
		}

		public virtual void BeginTunnel()
		{
			if (Deleted)
			{
				return;
			}

			new BunnyHole().MoveToWorld(Location, Map);

			Frozen = true;
			Say("* The bunny begins to dig a tunnel back to its underground lair *");
			PlaySound(0x247);

			Timer.DelayCall(TimeSpan.FromSeconds(5.0), Delete);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}