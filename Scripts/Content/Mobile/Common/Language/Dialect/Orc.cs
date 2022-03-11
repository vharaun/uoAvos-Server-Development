namespace Server.Misc
{
	public partial class InhumanSpeech
	{
		private static InhumanSpeech m_OrcSpeech;

		public static InhumanSpeech Orc
		{
			get
			{
				if (m_OrcSpeech == null)
				{
					m_OrcSpeech = new InhumanSpeech {
						Hue = 34,
						Sound = 432,

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
							"bu", "du", "fu", "ju", "gu",
							"ulg", "gug", "gub", "gur", "oog",
							"gub", "log", "ru", "stu", "glu",
							"ug", "ud", "og", "log", "ro", "flu",
							"bo", "duf", "fun", "nog", "dun", "bog",
							"dug", "gh", "ghu", "gho", "nug", "ig",
							"igh", "ihg", "luh", "duh", "bug", "dug",
							"dru", "urd", "gurt", "grut", "grunt",
							"snarf", "urgle", "igg", "glu", "glug",
							"foo", "bar", "baz", "ghat", "ab", "ad",
							"gugh", "guk", "ag", "alm", "thu", "log",
							"bilge", "augh", "gha", "gig", "goth",
							"zug", "pig", "auh", "gan", "azh", "bag",
							"hig", "oth", "dagh", "gulg", "ugh", "ba",
							"bid", "gug", "bug", "rug", "hat", "brui",
							"gagh", "buad", "buil", "buim", "bum",
							"hug", "hug", "buo", "ma", "buor", "ghed",
							"buu", "ca", "guk", "clog", "thurg", "car",
							"cro", "thu", "da", "cuk", "gil", "cur", "dak",
							"dar", "deak", "der", "dil", "dit", "at", "ag",
							"dor", "gar", "dre", "tk", "dri", "gka", "rim",
							"eag", "egg", "ha", "rod", "eg", "lat", "eichel",
							"ek", "ep", "ka", "it", "ut", "ewk", "ba", "dagh",
							"faugh", "foz", "fog", "fid", "fruk", "gag", "fub",
							"fud", "fur", "bog", "fup", "hagh", "gaa", "kt",
							"rekk", "lub", "lug", "tug", "gna", "urg", "l",
							"gno", "gnu", "gol", "gom", "kug", "ukk", "jak",
							"jek", "rukk", "jja", "akt", "nuk", "hok", "hrol",
							"olm", "natz", "i", "i", "o", "u", "ikk", "ign",
							"juk", "kh", "kgh", "ka", "hig", "ke", "ki", "klap",
							"klu", "knod", "kod", "knu", "thnu", "krug", "nug",
							"nar", "nag", "neg", "neh", "oag", "ob", "ogh", "oh",
							"om", "dud", "oo", "pa", "hrak", "qo", "quad", "quil",
							"ghig", "rur", "sag", "sah", "sg"
						}
					};
				}

				return m_OrcSpeech;
			}
		}
	}
}