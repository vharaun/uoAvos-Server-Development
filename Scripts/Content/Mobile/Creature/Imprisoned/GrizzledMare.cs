using Server.Mobiles;

using System;

namespace Server.Items
{
	public class GrizzledMareStatuette : BaseImprisonedMobile
	{
		public override int LabelNumber => 1074475;  // Grizzled Mare Statuette
		public override BaseCreature Summon => new GrizzledMare();

		[Constructable]
		public GrizzledMareStatuette() : base(0x2617)
		{
			Weight = 1.0;
		}

		public GrizzledMareStatuette(Serial serial) : base(serial)
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

namespace Server.Mobiles
{
	public class GrizzledMare : HellSteed
	{
		public override bool DeleteOnRelease => true;

		private static readonly string m_Myname = "a grizzled mare";

		[Constructable]
		public GrizzledMare()
			: base(m_Myname)
		{
		}

		public virtual void OnAfterDeserialize_Callback()
		{
			HellSteed.SetStats(this);

			Name = m_Myname;
		}

		public GrizzledMare(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version < 1)
			{
				Timer.DelayCall(TimeSpan.FromSeconds(0), OnAfterDeserialize_Callback);
			}
		}
	}
}