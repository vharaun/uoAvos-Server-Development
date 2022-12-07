
namespace Server.Items
{
	public class TrialByFireScroll : SpellScroll
	{
		[Constructable]
		public TrialByFireScroll() : this(1)
		{
		}

		[Constructable]
		public TrialByFireScroll(int amount) : base(SpellName.TrialByFire, 0x1F6D, amount)
		{
		}

		public TrialByFireScroll(Serial serial) : base(serial)
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
