
using System;

namespace Server.Items
{
	/// Brazier
	public class Brazier : BaseLight
	{
		public override int LitItemID => 0xE31;

		[Constructable]
		public Brazier() : base(0xE31)
		{
			Movable = false;
			Duration = TimeSpan.Zero; // Never burnt out
			Burning = true;
			Light = LightType.Circle225;
			Weight = 20.0;
		}

		public Brazier(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	/// BrazierTall
	public class BrazierTall : BaseLight
	{
		public override int LitItemID => 0x19AA;

		[Constructable]
		public BrazierTall() : base(0x19AA)
		{
			Movable = false;
			Duration = TimeSpan.Zero; // Never burnt out
			Burning = true;
			Light = LightType.Circle300;
			Weight = 25.0;
		}

		public BrazierTall(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}