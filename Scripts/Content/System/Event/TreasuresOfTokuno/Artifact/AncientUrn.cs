namespace Server.Engines.Events
{
	public class AncientUrn : Item
	{
		private static readonly string[] m_Names = new string[]
			{
				"Akira",
				"Avaniaga",
				"Aya",
				"Chie",
				"Emiko",
				"Fumiyo",
				"Gennai",
				"Gennosuke",
				"Genjo",
				"Hamato",
				"Harumi",
				"Ikuyo",
				"Juri",
				"Kaori",
				"Kaoru",
				"Kiyomori",
				"Mayako",
				"Motoki",
				"Musashi",
				"Nami",
				"Nobukazu",
				"Roku",
				"Romi",
				"Ryo",
				"Sanzo",
				"Sakamae",
				"Satoshi",
				"Takamori",
				"Takuro",
				"Teruyo",
				"Toshiro",
				"Yago",
				"Yeijiro",
				"Yoshi",
				"Zeshin"
			};

		public static string[] Names => m_Names;

		private string m_UrnName;

		[CommandProperty(AccessLevel.GameMaster)]
		public string UrnName
		{
			get => m_UrnName;
			set => m_UrnName = value;
		}

		public override int LabelNumber => 1071014;  // Ancient Urn

		[Constructable]
		public AncientUrn(string urnName) : base(0x241D)
		{
			m_UrnName = urnName;
			Weight = 1.0;
		}

		[Constructable]
		public AncientUrn() : this(m_Names[Utility.Random(m_Names.Length)])
		{
		}

		public AncientUrn(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
			writer.Write(m_UrnName);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
			m_UrnName = reader.ReadString();

			Utility.Intern(ref m_UrnName);
		}

		public override void AddNameProperty(ObjectPropertyList list)
		{
			list.Add(1070935, m_UrnName); // Ancient Urn of ~1_name~
		}

		public override void OnSingleClick(Mobile from)
		{
			LabelTo(from, 1070935, m_UrnName); // Ancient Urn of ~1_name~
		}
	}
}