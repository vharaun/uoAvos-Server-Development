
using System;

namespace Server.Items
{
	public class StrengthPotion : BaseStrengthPotion
	{
		public override int StrOffset => 10;
		public override TimeSpan Duration => TimeSpan.FromMinutes(2.0);

		[Constructable]
		public StrengthPotion() : base(PotionEffect.Strength)
		{
		}

		public StrengthPotion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	public class GreaterStrengthPotion : BaseStrengthPotion
	{
		public override int StrOffset => 20;
		public override TimeSpan Duration => TimeSpan.FromMinutes(2.0);

		[Constructable]
		public GreaterStrengthPotion() : base(PotionEffect.StrengthGreater)
		{
		}

		public GreaterStrengthPotion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}