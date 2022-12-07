
namespace Server.Items
{
	public class DruidFamiliarScroll : SpellScroll
	{
		[Constructable]
		public DruidFamiliarScroll() : this(1)
		{
		}

		[Constructable]
		public DruidFamiliarScroll(int amount) : base(SpellName.DruidFamiliar, 0x1F6D, amount)
		{
		}

		public DruidFamiliarScroll(Serial serial) : base(serial)
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
