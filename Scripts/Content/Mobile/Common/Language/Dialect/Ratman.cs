namespace Server.Misc
{
	public partial class InhumanSpeech
	{
		private static InhumanSpeech m_RatmanSpeech;

		public static InhumanSpeech Ratman
		{
			get
			{
				if (m_RatmanSpeech == null)
				{
					m_RatmanSpeech = new InhumanSpeech {
						Hue = 149,
						Sound = 438,

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
							"skrit",

							"ch", "ch",
							"it", "ti", "it", "ti",

							"ak", "ek", "ik", "ok", "uk", "yk",
							"ka", "ke", "ki", "ko", "ku", "ky",
							"at", "et", "it", "ot", "ut", "yt",

							"cha", "che", "chi", "cho", "chu", "chy",
							"ach", "ech", "ich", "och", "uch", "ych",
							"att", "ett", "itt", "ott", "utt", "ytt",
							"tat", "tet", "tit", "tot", "tut", "tyt",
							"tta", "tte", "tti", "tto", "ttu", "tty",
							"tak", "tek", "tik", "tok", "tuk", "tyk",
							"ack", "eck", "ick", "ock", "uck", "yck",
							"cka", "cke", "cki", "cko", "cku", "cky",
							"rak", "rek", "rik", "rok", "ruk", "ryk",

							"tcha", "tche", "tchi", "tcho", "tchu", "tchy",
							"rach", "rech", "rich", "roch", "ruch", "rych",
							"rrap", "rrep", "rrip", "rrop", "rrup", "rryp",
							"ccka", "ccke", "ccki", "ccko", "ccku", "ccky"
						}
					};
				}

				return m_RatmanSpeech;
			}
		}
	}
}