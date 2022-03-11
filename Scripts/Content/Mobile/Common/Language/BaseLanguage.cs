
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Misc
{
	[Flags]
	public enum IHSFlags
	{
		None = 0x00,
		OnDamaged = 0x01,
		OnDeath = 0x02,
		OnMovement = 0x04,
		OnSpeech = 0x08,
		All = OnDamaged | OnDeath | OnMovement
	} // NOTE: To enable monster conversations, add " | OnSpeech" to the "All" line

	public partial class InhumanSpeech
	{
		private string[] m_Syllables;
		private string[] m_Keywords;
		private string[] m_Responses;

		private Dictionary<string, string> m_KeywordHash;

		private int m_Hue;
		private int m_Sound;

		private IHSFlags m_Flags;

		public string[] Syllables
		{
			get => m_Syllables;
			set => m_Syllables = value;
		}

		public string[] Keywords
		{
			get => m_Keywords;
			set
			{
				m_Keywords = value;
				m_KeywordHash = new Dictionary<string, string>(m_Keywords.Length, StringComparer.OrdinalIgnoreCase);
				for (var i = 0; i < m_Keywords.Length; ++i)
				{
					m_KeywordHash[m_Keywords[i]] = m_Keywords[i];
				}
			}
		}

		public string[] Responses
		{
			get => m_Responses;
			set => m_Responses = value;
		}

		public int Hue
		{
			get => m_Hue;
			set => m_Hue = value;
		}

		public int Sound
		{
			get => m_Sound;
			set => m_Sound = value;
		}

		public IHSFlags Flags
		{
			get => m_Flags;
			set => m_Flags = value;
		}

		public string GetRandomSyllable()
		{
			return m_Syllables[Utility.Random(m_Syllables.Length)];
		}

		public string ConstructWord(int syllableCount)
		{
			var syllables = new string[syllableCount];

			for (var i = 0; i < syllableCount; ++i)
			{
				syllables[i] = GetRandomSyllable();
			}

			return String.Concat(syllables);
		}

		public string ConstructSentance(int wordCount)
		{
			var sentance = new StringBuilder();

			var needUpperCase = true;

			for (var i = 0; i < wordCount; ++i)
			{
				if (i > 0) // not first word )
				{
					var random = Utility.RandomMinMax(1, 15);

					if (random < 11)
					{
						sentance.Append(' ');
					}
					else
					{
						needUpperCase = true;

						if (random > 13)
						{
							sentance.Append("! ");
						}
						else
						{
							sentance.Append(". ");
						}
					}
				}

				int syllableCount;

				if (30 > Utility.Random(100))
				{
					syllableCount = Utility.Random(1, 5);
				}
				else
				{
					syllableCount = Utility.Random(1, 3);
				}

				var word = ConstructWord(syllableCount);

				sentance.Append(word);

				if (needUpperCase)
				{
					sentance.Replace(word[0], Char.ToUpper(word[0]), sentance.Length - word.Length, 1);
				}

				needUpperCase = false;
			}

			if (Utility.RandomMinMax(1, 5) == 1)
			{
				sentance.Append('!');
			}
			else
			{
				sentance.Append('.');
			}

			return sentance.ToString();
		}

		public void SayRandomTranslate(Mobile mob, params string[] sentancesInEnglish)
		{
			SaySentance(mob, Utility.RandomMinMax(2, 3));
			mob.Say(sentancesInEnglish[Utility.Random(sentancesInEnglish.Length)]);
		}

		private string GetRandomResponseWord(List<string> keywordsFound)
		{
			var random = Utility.Random(keywordsFound.Count + m_Responses.Length);

			if (random < keywordsFound.Count)
			{
				return keywordsFound[random];
			}

			return m_Responses[random - keywordsFound.Count];
		}

		public bool OnSpeech(Mobile mob, Mobile speaker, string text)
		{
			if ((m_Flags & IHSFlags.OnSpeech) == 0 || m_Keywords == null || m_Responses == null || m_KeywordHash == null)
			{
				return false; // not enabled
			}

			if (!speaker.Alive)
			{
				return false;
			}

			if (!speaker.InRange(mob, 3))
			{
				return false;
			}

			if ((speaker.Direction & Direction.Mask) != speaker.GetDirectionTo(mob))
			{
				return false;
			}

			if ((mob.Direction & Direction.Mask) != mob.GetDirectionTo(speaker))
			{
				return false;
			}

			var split = text.Split(' ');
			var keywordsFound = new List<string>();

			for (var i = 0; i < split.Length; ++i)
			{
				string keyword;
				m_KeywordHash.TryGetValue(split[i], out keyword);

				if (keyword != null)
				{
					keywordsFound.Add(keyword);
				}
			}

			if (keywordsFound.Count > 0)
			{
				string responseWord;

				if (Utility.RandomBool())
				{
					responseWord = GetRandomResponseWord(keywordsFound);
				}
				else
				{
					responseWord = keywordsFound[Utility.Random(keywordsFound.Count)];
				}

				var secondResponseWord = GetRandomResponseWord(keywordsFound);

				var response = new StringBuilder();

				switch (Utility.Random(6))
				{
					default:
					case 0:
						{
							response.Append("Me ").Append(responseWord).Append('?');
							break;
						}
					case 1:
						{
							response.Append(responseWord).Append(" thee!");
							response.Replace(responseWord[0], Char.ToUpper(responseWord[0]), 0, 1);
							break;
						}
					case 2:
						{
							response.Append(responseWord).Append('?');
							response.Replace(responseWord[0], Char.ToUpper(responseWord[0]), 0, 1);
							break;
						}
					case 3:
						{
							response.Append(responseWord).Append("! ").Append(secondResponseWord).Append('.');
							response.Replace(responseWord[0], Char.ToUpper(responseWord[0]), 0, 1);
							response.Replace(secondResponseWord[0], Char.ToUpper(secondResponseWord[0]), responseWord.Length + 2, 1);
							break;
						}
					case 4:
						{
							response.Append(responseWord).Append('.');
							response.Replace(responseWord[0], Char.ToUpper(responseWord[0]), 0, 1);
							break;
						}
					case 5:
						{
							response.Append(responseWord).Append("? ").Append(secondResponseWord).Append('.');
							response.Replace(responseWord[0], Char.ToUpper(responseWord[0]), 0, 1);
							response.Replace(secondResponseWord[0], Char.ToUpper(secondResponseWord[0]), responseWord.Length + 2, 1);
							break;
						}
				}

				var maxWords = (split.Length / 2) + 1;

				if (maxWords < 2)
				{
					maxWords = 2;
				}
				else if (maxWords > 6)
				{
					maxWords = 6;
				}

				SaySentance(mob, Utility.RandomMinMax(2, maxWords));
				mob.Say(response.ToString());

				return true;
			}

			return false;
		}

		public void OnDeath(Mobile mob)
		{
			if ((m_Flags & IHSFlags.OnDeath) == 0)
			{
				return; // not enabled
			}

			if (90 > Utility.Random(100))
			{
				return; // 90% chance to do nothing; 10% chance to talk
			}

			#region OnDeath Speech

			SayRandomTranslate(mob,
				"Revenge!",
				"NOOooo!",
				"I... I...",
				"Me no die!",
				"Me die!",
				"Must... not die...",
				"Oooh, me hurt...",
				"Me dying?");

			#endregion
		}

		public void OnMovement(Mobile mob, Mobile mover, Point3D oldLocation)
		{
			if ((m_Flags & IHSFlags.OnMovement) == 0)
			{
				return; // not enabled
			}

			if (!mover.Player || (mover.Hidden && mover.AccessLevel > AccessLevel.Player))
			{
				return;
			}

			if (!mob.InRange(mover, 5) || mob.InRange(oldLocation, 5))
			{
				return; // only talk when they enter 5 tile range
			}

			if (90 > Utility.Random(100))
			{
				return; // 90% chance to do nothing; 10% chance to talk
			}

			SaySentance(mob, 6);
		}

		public void OnDamage(Mobile mob, int amount)
		{
			if ((m_Flags & IHSFlags.OnDamaged) == 0)
			{
				return; // not enabled
			}

			if (90 > Utility.Random(100))
			{
				return; // 90% chance to do nothing; 10% chance to talk
			}

			#region OnDamage Speech

			if (amount < 5)
			{
				SayRandomTranslate(mob,
					"Ouch!",
					"Me not hurt bad!",
					"Thou fight bad.",
					"Thy blows soft!",
					"You bad with weapon!");
			}
			else
			{
				SayRandomTranslate(mob,
					"Ouch! Me hurt!",
					"No, kill me not!",
					"Me hurt!",
					"Away with thee!",
					"Oof! That hurt!",
					"Aaah! That hurt...",
					"Good blow!");
			}

			#endregion
		}

		public void OnConstruct(Mobile mob)
		{
			mob.SpeechHue = m_Hue;
		}

		public void SaySentance(Mobile mob, int wordCount)
		{
			mob.Say(ConstructSentance(wordCount));
			mob.PlaySound(m_Sound);
		}

		public InhumanSpeech()
		{
		}
	}
}