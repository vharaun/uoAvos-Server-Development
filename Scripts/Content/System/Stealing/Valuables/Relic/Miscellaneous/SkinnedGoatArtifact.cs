﻿namespace Server.Items
{
	public class SkinnedGoatArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 5;

		[Constructable]
		public SkinnedGoatArtifact() : base(0x1E88)
		{
		}

		public SkinnedGoatArtifact(Serial serial) : base(serial)
		{
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