namespace Server.Misc
{
	public partial class InhumanSpeech
	{
		private static InhumanSpeech m_WispSpeech;

		public static InhumanSpeech Wisp
		{
			get
			{
				if (m_WispSpeech == null)
				{
					m_WispSpeech = new InhumanSpeech {
						Hue = 89,
						Sound = 466,

						Flags = IHSFlags.OnMovement,

						Syllables = new string[]
						{
							"b", "c", "d", "f", "g", "h", "i",
							"j", "k", "l", "m", "n", "p", "r",
							"s", "t", "v", "w", "x", "z", "c",
							"c", "x", "x", "x", "x", "x", "y",
							"y", "y", "y", "t", "t", "k", "k",
							"l", "l", "m", "m", "m", "m", "z"
						}
					};
				}

				return m_WispSpeech;
			}
		}
	}
}