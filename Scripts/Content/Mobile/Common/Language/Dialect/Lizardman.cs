namespace Server.Misc
{
	public partial class InhumanSpeech
	{
		private static InhumanSpeech m_LizardmanSpeech;

		public static InhumanSpeech Lizardman
		{
			get
			{
				if (m_LizardmanSpeech == null)
				{
					m_LizardmanSpeech = new InhumanSpeech {
						Hue = 58,
						Sound = 418,

						Flags = IHSFlags.All,

						Keywords = new string[]
						{
							"meat", "gold", "kill", "killing", "slay",
							"sword", "axe", "spell", "magic", "spells",
							"swords", "axes", "mace", "maces", "monster",
							"monsters", "food", "run", "escape", "away",
							"help", "dead", "die", "dying", "lose",
							"losing", "life", "lives", "death", "ghost",
							"ghosts", "british", "blackthorn", "guild",
							"guilds", "dragon", "dragons", "game", "games",
							"ultima", "silly", "stupid", "dumb", "idiot",
							"idiots", "cheesy", "cheezy", "crazy", "dork",
							"jerk", "fool", "foolish", "ugly", "insult", "scum"
						},

						Responses = new string[]
						{
							"meat", "kill", "pound", "crush", "yum yum",
							"crunch", "destroy", "murder", "eat", "munch",
							"massacre", "food", "monster", "evil", "run",
							"die", "lose", "dumb", "idiot", "fool", "crazy",
							"dinner", "lunch", "breakfast", "fight", "battle",
							"doomed", "rip apart", "tear apart", "smash",
							"edible?", "shred", "disembowel", "ugly", "smelly",
							"stupid", "hideous", "smell", "tasty", "invader",
							"attack", "raid", "plunder", "pillage", "treasure",
							"loser", "lose", "scum"
						},

						Syllables = new string[]
						{
							"ss", "sth", "iss", "is", "ith", "kth",
							"sith", "this", "its", "sit", "tis", "tsi",
							"ssi", "sil", "lis", "sis", "lil", "thil",
							"lith", "sthi", "lish", "shi", "shash", "sal",
							"miss", "ra", "tha", "thes", "ses", "sas", "las",
							"les", "sath", "sia", "ais", "isa", "asi", "asth",
							"stha", "sthi", "isth", "asa", "ath", "tha", "als",
							"sla", "thth", "ci", "ce", "cy", "yss", "ys", "yth",
							"syth", "thys", "yts", "syt", "tys", "tsy", "ssy",
							"syl", "lys", "sys", "lyl", "thyl", "lyth", "sthy",
							"lysh", "shy", "myss", "ysa", "sthy", "ysth"
						}
					};
				}

				return m_LizardmanSpeech;
			}
		}
	}
}