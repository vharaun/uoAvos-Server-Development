namespace Server.Items
{
	public class TowerLanternArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 3;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsOn
		{
			get => ItemID == 0x24BF;
			set => ItemID = value ? 0x24BF : 0x24C0;
		}

		[Constructable]
		public TowerLanternArtifact() : base(0x24C0)
		{
			Light = LightType.Circle225;
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (from.InRange(GetWorldLocation(), 2))
			{
				if (IsOn)
				{
					IsOn = false;
					from.PlaySound(0x3BE);
				}
				else
				{
					IsOn = true;
					from.PlaySound(0x47);
				}
			}
			else
			{
				from.LocalOverheadMessage(Network.MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
			}
		}

		public TowerLanternArtifact(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();

			if (version == 0)
			{
				Light = LightType.Circle225;
			}
		}
	}
}