using Server.Engines.Publishing;

namespace Server.Items
{
	public class DimensionalTravel : BaseBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Dimensional Travel, a Monograph", "Dryus Doost, Mage",
				new BookPageInfo
				(
					"  'Tis beyond the",
					"scope of this small",
					"monograph to discuss",
					"the details of",
					"moongates, and the",
					"manners in which",
					"they distort the",
					"fabric of reality in"
				),
				new BookPageInfo
				(
					"such a manner as to",
					"permit the passage of",
					"living flesh from",
					"place to place, world to",
					"world, or indeed from",
					"dimension to",
					"dimension.",
					"  Instead, allow me to"
				),
				new BookPageInfo
				(
					"bring thy attention,",
					"Gentle Reader, to the",
					"curious",
					"characteristics that",
					"are shared by certain",
					"individuals within",
					"our realm.",
					"  Long has it been"
				),
				new BookPageInfo
				(
					"known that the blue",
					"moongate permits",
					"travel from place to",
					"place, and none have",
					"trouble in taking this",
					"path. Yet 'tis also",
					"known, albeit only to a",
					"few, that certain"
				),
				new BookPageInfo
				(
					"individuals are unable",
					"to traverse the black",
					"moongates that permit",
					"travel from one",
					"dimension to another.",
					"  The noted mage and",
					"peer of our realm,",
					"Lord Blackthorn, once"
				),
				new BookPageInfo
				(
					"told me in",
					"conversation that his",
					"arcane research had",
					"indicated that the",
					"issue was one of",
					"conversation of ether.",
					"To wit, given the",
					"postulate that matter"
				),
				new BookPageInfo
				(
					"within a given",
					"dimension may be but",
					"a cross-section of",
					"ethereal matter that",
					"exists in multiple",
					"dimensions, it",
					"becomes obvious that",
					"said ethereal"
				),
				new BookPageInfo
				(
					"structure cannot",
					"enter dimensions in",
					"which it is already",
					"present.",
					"  Imagine an",
					"individual (and the",
					"Lord Blackthorn",
					"hinted that he was"
				),
				new BookPageInfo
				(
					"one such) who exists",
					"already in some form",
					"in multiple",
					"dimensions; said",
					"individual would not",
					"be able to cross into",
					"another dimension",
					"because HE IS"
				),
				new BookPageInfo
				(
					"ALREADY THERE.",
					"  The implications of",
					"this are staggering,",
					"and merit further",
					"study. 'Tis well",
					"known by theorists in",
					"the field that",
					"divisions in the"
				),
				new BookPageInfo
				(
					"ethereal structure of",
					"an individual are",
					"already implicit at the",
					"temporal level, as",
					"causality forces",
					"divisions upon the",
					"ether. This is the",
					"basic operating"
				),
				new BookPageInfo
				(
					"mechanism by which",
					"white moongates",
					"function, permitting",
					"time travel.",
					"  As time travel is",
					"not barred by the",
					"presence of an earlier",
					"self (though"
				),
				new BookPageInfo
				(
					"encountering said",
					"earlier self can prove",
					"arcanely perilous),",
					"there must be some",
					"rigidity to the",
					"ethereal structure",
					"that bars multiple",
					"instantiations of"
				),
				new BookPageInfo
				(
					"structures from",
					"manifesting within",
					"the same context.",
					"  If one regards time",
					"and causal bifurcation",
					"as a web, perhaps the",
					"appropriate analogy",
					"for dimensional"
				),
				new BookPageInfo
				(
					"matrices is that of a",
					"crystalline structure,",
					"with rigid linkages.",
					"The only way in",
					"which an individual",
					"such as Lord",
					"Blackthorn, who",
					"exists in multiple"
				),
				new BookPageInfo
				(
					"dimensional matrices,",
					"can cross worlds via",
					"a black moongate,",
					"would be for the",
					"entire crystalline",
					"structure of the",
					"dimension to",
					"perfectly match the"
				),
				new BookPageInfo
				(
					"ethereal resonance of",
					"the destination",
					"dimension.",
					"  The problem of why",
					"certain individuals",
					"are already replicated",
					"in multiple crystalline",
					"matrices is one that I"
				),
				new BookPageInfo
				(
					"fail to provide any",
					"schema for in these",
					"poor theories. It is",
					"my fondest hope that",
					"someday someone",
					"shall conquer that",
					"thorny problem and",
					"enlighten the world."
				)
			);

		public override BookContent DefaultContent => Content;

		[Constructable]
		public DimensionalTravel() : base(Utility.Random(0xFEF, 2), false)
		{
		}

		public DimensionalTravel(Serial serial) : base(serial)
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