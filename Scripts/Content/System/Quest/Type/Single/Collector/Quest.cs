using Server.Engines.Quests.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.Quests.Definitions
{
	public class CollectorQuest : QuestSystem
	{
		private static readonly Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( DontOfferConversation_CollectorQuest ),
				typeof( DeclineConversation_CollectorQuest ),
				typeof( CollectorAcceptConversation_CollectorQuest ),
				typeof( ElwoodDuringFishConversation_CollectorQuest ),
				typeof( ReturnPearlsConversation_CollectorQuest ),
				typeof( AlbertaPaintingConversation_CollectorQuest ),
				typeof( AlbertaStoolConversation_CollectorQuest ),
				typeof( AlbertaEndPaintingConversation_CollectorQuest ),
				typeof( AlbertaAfterPaintingConversation_CollectorQuest ),
				typeof( ElwoodDuringPainting1Conversation_CollectorQuest ),
				typeof( ElwoodDuringPainting2Conversation_CollectorQuest ),
				typeof( ReturnPaintingConversation_CollectorQuest ),
				typeof( GabrielAutographConversation_CollectorQuest ),
				typeof( GabrielNoSheetMusicConversation_CollectorQuest ),
				typeof( NoSheetMusicConversation_CollectorQuest ),
				typeof( GetSheetMusicConversation_CollectorQuest ),
				typeof( GabrielSheetMusicConversation_CollectorQuest ),
				typeof( GabrielIgnoreConversation_CollectorQuest ),
				typeof( ElwoodDuringAutograph1Conversation_CollectorQuest ),
				typeof( ElwoodDuringAutograph2Conversation_CollectorQuest ),
				typeof( ElwoodDuringAutograph3Conversation_CollectorQuest ),
				typeof( ReturnAutographConversation_CollectorQuest ),
				typeof( TomasToysConversation_CollectorQuest ),
				typeof( TomasDuringCollectingConversation_CollectorQuest ),
				typeof( ReturnImagesConversation_CollectorQuest ),
				typeof( ElwoodDuringToys1Conversation_CollectorQuest ),
				typeof( ElwoodDuringToys2Conversation_CollectorQuest ),
				typeof( ElwoodDuringToys3Conversation_CollectorQuest ),
				typeof( FullEndConversation_CollectorQuest ),
				typeof( FishPearlsObjective_CollectorQuest ),
				typeof( ReturnPearlsObjective_CollectorQuest ),
				typeof( FindAlbertaObjective_CollectorQuest ),
				typeof( SitOnTheStoolObjective_CollectorQuest ),
				typeof( ReturnPaintingObjective_CollectorQuest ),
				typeof( FindGabrielObjective_CollectorQuest ),
				typeof( FindSheetMusicObjective_CollectorQuest ),
				typeof( ReturnSheetMusicObjective_CollectorQuest ),
				typeof( ReturnAutographObjective_CollectorQuest ),
				typeof( FindTomasObjective_CollectorQuest ),
				typeof( CaptureImagesObjective_CollectorQuest ),
				typeof( ReturnImagesObjective_CollectorQuest ),
				typeof( ReturnToysObjective_CollectorQuest ),
				typeof( MakeRoomObjective_CollectorQuest )
			};

		public override Type[] TypeReferenceTable => m_TypeReferenceTable;

		public override object Name =>
				//return 1020549; // This localized message seems broken...
				"Collector's Quest";

		public override object OfferMessage =>
				/* <I>Elwood greets you warmly, like an old friend he's not
* quite sure he ever had.</I><BR><BR>
* 
* Hello. Yes. Sit down. Please. Good. Okay, stand. Up to you.<BR><BR>
* 
* So, what brings you to these parts... hey, wait. Just had a thought.
* Would you like to do me a favor? Yes, really. You know, for old
* times sake. The good ole days. You were always one of my best
* suppliers. Or maybe you weren't, who knows any more. Anyway,
* could use some help supplementing my stock. You know me. Always
* looking for something new to add to the collection. Or sometimes
* not so new - just more of the same. But don't have to tell you that.
* You know, don't you. Yes. Just like old times. That's what it'll be.
* You and me - together again. Ah, it's been too long.<BR><BR>
* 
* So what do you think? The fee will be the same as always. I'm a fair
* man. You know that. So what do you say?
*/
				1055081;

		public override TimeSpan RestartDelay => TimeSpan.Zero;
		public override bool IsTutorial => false;

		public override int Picture => 0x15A9;

		public CollectorQuest(PlayerMobile from) : base(from)
		{
		}

		// Serialization
		public CollectorQuest()
		{
		}

		public override void Accept()
		{
			base.Accept();

			AddConversation(new CollectorAcceptConversation_CollectorQuest());
		}

		public override void Decline()
		{
			base.Decline();

			AddConversation(new DeclineConversation_CollectorQuest());
		}
	}

	#region Conversation

	public class DontOfferConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood looks up from his ale as you greet him.</I><BR><BR>
* 
* What's that? Who me? No, no. You must be looking for someone else.
*/
				1055080;

		public override bool Logged => false;

		public DontOfferConversation_CollectorQuest()
		{
		}
	}

	public class DeclineConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood looks a bit flustered and nearly knocks over his
* bottle of ale.</I><BR><BR>
* 
* Well, I see. It's like that, is it? Yes. Well then. Okay.
* You've changed. Yes. Yes, you have. Something's changed. I know
* I haven't. Not me. Not good ole Elwood.<BR><BR>
* 
* <I>Elwood trails off, though you can still hear him muttering softly.</I>
*/
				1055082;

		public override bool Logged => false;

		public DeclineConversation_CollectorQuest()
		{
		}
	}

	public class CollectorAcceptConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood slaps his knee and grins at you.</I><BR><BR>
* 
* Yes. Yes. That's the spirit. I knew it. Knew it when I
* first saw you. You remind me so much of your dear departed
* father. Or someone. Not sure. Maybe no one. But that's okay.
* Ah, good times.<BR><BR>
* 
* Anyway, so as you know, I'm a collector. Got all kinds of
* interesting things laying around back at my warehouse.
* You know. You've seen it. Haven't you? Yes? No? Nevermind.
* Not important.<BR><BR>
* 
* Right. So, always trying to add new things to my collection.
* Or sometimes just get more of something. Can't have too many.
* Right? Yeah? Sure.<BR><BR>
* 
* Let's see. Where to start. Oh, I know. Pearls. Yes. But not
* just any pearls. Rainbow pearls. Yes. From the lake here in
* Haven. Seems all that magic Uzeraan was throwing around when
* he transformed the island had an interesting effect on some
* of the shellfish down there. Exactly, rainbow pearls. Useless
* for magic, but an item worth collecting. Trust me on this.
* Trust me.<BR><BR>
* 
* Need you to go fish some up for me. Down at the lake. Lake Haven.
* Off ya go. Happy fishing!<BR><BR>
* 
* <I>Elwood turns back to his ale and now seems oblivious to you.</I>
*/
				1055083;

		public CollectorAcceptConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FishPearlsObjective_CollectorQuest());
		}
	}

	public class ElwoodDuringFishConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood looks up as you tap him on the shoulder.</I><BR><BR>
* 
* Good. Good. You're back. Wait. You don't have the rainbow pearls I
* need. Taking a break? Yeah. Sure. There's no hurry. Let me know when
* you've got all those pearls, though. I'll be here.
*/
				1055089;

		public override bool Logged => false;

		public ElwoodDuringFishConversation_CollectorQuest()
		{
		}
	}

	public class ReturnPearlsConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood jumps slightly when you call his name.</I><BR><BR>
* 
* What. I'm awake. Oh, It's you. Hey, look at those pearls.
* Beautiful. Wow. Where'd you get those... oh right. I sent you to get
* them. From the lake. Lake Haven. Great job. Gotta love rainbow
* pearls. Oooh, Colors.<BR><BR>
* 
* Okay, let's see. Next. Need a painting. Go to the Colored Canvas and
* speak to Alberta. Alberta Giacco. Best painter I've ever met. Ask
* her to do a painting of you. Yes. Of you. A portrait. Never know if
* you might up and become famous one day. Need to have a painting of you
* in my collection. From now. Before all the fame. Go. Alberta awaits.
* She's in Vesper.<BR><BR>
* 
* <I>Elwood starts playing with the pearls you brought him and seems
* to have forgotten you're there.</I>
*/
				1055090;

		public ReturnPearlsConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindAlbertaObjective_CollectorQuest());
		}
	}

	public class AlbertaPaintingConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Alberta looks up from the painting she is working on and
* faces you.</I><BR><BR>
* 
* Excuse me. I don't mean to be rude, but I'm in the middle
* of something, and can't... oh wait, I see. You must be the one
* Elwood sent over.<BR><BR>
* 
* Very well. If you'll have a seat on the stool over there, we'll
* get started. This will just take a few seconds. I paint quite
* quickly, you see. I'll start once you are seated.<BR><BR>
* 
* <I>Alberta exchanges the painting she was working on for a blank canvas.</I>
*/
				1055092;

		public AlbertaPaintingConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new SitOnTheStoolObjective_CollectorQuest());
		}
	}

	public class AlbertaStoolConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Alberta looks at you sympathetically.</I><BR><BR>
* 
* Don't worry, this will only take a few seconds. I realize
* that stool can be uncomfortable, and I apologize for that.
* Perhaps I should replace it with a more comfortable chair.
* But then again, it's that very discomfort that helps produce
* such wonderful facial expressions for my paintings. Ah well.
*/
				1055096;

		public override bool Logged => false;

		public AlbertaStoolConversation_CollectorQuest()
		{
		}
	}

	public class AlbertaEndPaintingConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Alberta stands back from the canvas and surveys her
* work.</I><BR><BR>
* 
* Not too bad. Quite good even, if I do say so myself. As always,
* of course.<BR><BR>
* 
* Oh, you're still here. Please let Elwood know that the painting
* has been completed. I'll have it sent to him once it dries.<BR><BR>
* 
* <I>Alberta removes the portrait from her easel and sets
* it aside to dry.</I>
*/
				1055098;

		public AlbertaEndPaintingConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new ReturnPaintingObjective_CollectorQuest());
		}
	}

	public class AlbertaAfterPaintingConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Alberta stops cleaning her brushes and looks your way.</I><BR><BR>
* 
* Don't worry, I'll send the painting to Elwood once it's dry. Please
* let him know that the painting has been finished.
*/
				1055102;

		public override bool Logged => false;

		public AlbertaAfterPaintingConversation_CollectorQuest()
		{
		}
	}

	public class ElwoodDuringPainting1Conversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood yawns and stretches, then focuses his gaze
* on you.</I><BR><BR>
* 
* Hello. Do I know you? Hold on a second. Yes. Yes, I do.
* You were going to bring me some rainbow pearls. Wait. No.
* You already did that. I remember now. Right. So go get that
* portrait painted. Alberta is in Vesper. Go to her. Alberta
* Giacco. Come back when she's done.
*/
				1055094;

		public override bool Logged => false;

		public ElwoodDuringPainting1Conversation_CollectorQuest()
		{
		}
	}

	public class ElwoodDuringPainting2Conversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood drums his fingers on the counter then looks
* up at you expectantly.</I><BR><BR>
* 
* Ah, finally. I'm famished. This so-called tavern doesn't
* even serve pizza, so one must have it delivered. It's an
* outrage. Er... wait. Where's my pizza? Yes, my pizza.
* What kind of delivery is this? Didn't even bring my pizza.
* This will severely impact your tip, I'm afraid.<BR><BR>
* 
* Hold on a moment. You were helping me with something else,
* weren't you? Ah. Yes. I've got it now. You were to have a
* portrait done. Well. Good. Yes. But let's not dawdle.
* Off you go. If you happen to see anyone with my pizza,
* please insist they hurry.<BR><BR>
*/
				1055097;

		public override bool Logged => false;

		public ElwoodDuringPainting2Conversation_CollectorQuest()
		{
		}
	}

	public class ReturnPaintingConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood notices you immediately and waves you over.</I><BR><BR>
* 
* You're back. Good. That's good. Hmm. You don't seem to have that
* painting yet. Don't tell me Alberta refused. That's no good. I made
* her what she is! She was living in the gutter when I found her. The
* gutter. And she has the... what's that? Oh, she finished the portrait.
* Right. Good. Can always count on Alberta. Always. Best painter in
* the land.<BR><BR>
* 
* Just have a couple... er... wait... make that... two more task for you.
* Then our business will be concluded. For now. Old chums like us will
* always work together again. Yes. We go so far back. Right. I think.<BR><BR>
* 
* Anyway. There's a musician. A minstrel. His name's Gabriel Piete. Quite
* the good singer. One of my favorites. Absolute favorite. What I'd like
* is his autograph. Simple. Just his autograph. You're likely to find him
* at the Conservatory of Music in Britain. He's often there. Often. Between
* performances. Hurry now. There ya go.<BR><BR>
* 
* <I>Elwood falls silent though his lips are still  moving. It looks like
* he's quietly repeating the word, "autograph."</I>
*/
				1055100;

		public ReturnPaintingConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindGabrielObjective_CollectorQuest());
		}
	}

	public class GabrielAutographConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Gabriel sighs loudly as you address him and stops whatever
* it was that he was doing.</I><BR><BR>
* 
* WHAT?!? Can you not see that I'm working here?  Ugh, sometimes
* I wish they'd just lock the outer doors to anyone who doesn't
* belong here. So go ahead and fawn. Get it over with, and then
* leave. Sooner you're out of here, the sooner I'm back to work.<BR><BR>
* 
* I see. So you want an autograph. Fine. If it'll get rid of you,
* I'll give you my autograph. But I'll only sign some sheet music
* for one of my songs. Until then, please let me get back to work.<BR><BR>
* 
* You can probably find some of my sheet music at one of the theaters
* in the land. When I perform there, they often sell it as a souvenir.
* Speak to the impresario... the theater manager. My last three
* performances were in Nujel'm, Jhelom, and here in Britian.
*/
				1055103;

		public GabrielAutographConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindSheetMusicObjective_CollectorQuest(true));
		}
	}

	public class GabrielNoSheetMusicConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Gabriel does not look happy to see you.</I><BR><BR>
* 
* Do you have any sheet music? No. Please return when you do,
* but until then please leave me to my work.
*/
				1055111;

		public override bool Logged => false;

		public GabrielNoSheetMusicConversation_CollectorQuest()
		{
		}
	}

	public class NoSheetMusicConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* Sheet music for a Gabriel Piete song? No, I'm sorry, but we've run out.
* We might get some more after he performs here again, but right now
* we don't have any. My apologies.
*/
				1055106;

		public override bool Logged => false;

		public NoSheetMusicConversation_CollectorQuest()
		{
		}
	}

	public class GetSheetMusicConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				// The theater impresario hands you some sheet of music for one of Gabriel Piete's songs.
				1055109;

		public GetSheetMusicConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new ReturnSheetMusicObjective_CollectorQuest());
		}
	}

	public class GabrielSheetMusicConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Gabriel looks up impatiently as you approach.</I><BR><BR>
* 
* Good. We can finally be done with one another. Here, let me
* sign that and have this business completed.<BR><BR>
* 
* <I>Gabriel takes the sheet music, autographs it, and then hands it back to you.</I>
*/
				1055113;

		public GabrielSheetMusicConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new ReturnAutographObjective_CollectorQuest());
		}
	}

	public class GabrielIgnoreConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				// <I>Gabriel ignores you.</I>
				1055118;

		public override bool Logged => false;

		public GabrielIgnoreConversation_CollectorQuest()
		{
		}
	}

	public class ElwoodDuringAutograph1Conversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood jumps and almost falls from his stool when you
* tap his shoulder.</I><BR><BR>
* 
* Oh my. Don't do that. Scared me half to death. Sneaking up on
* people like that. I don't even know you. Yes, I do. I do know you.
* Ordered a pizza from you and never received it. I'm rather miffed
* about that.<BR><BR>
* 
* No. No. Wait. Of course. Not the pizza. You're here with the
* moonfire brew I wanted. Magical moonfire brew. Not sure what it is.
* Just want some.<BR><BR>
* 
* What's that? Oh. The autograph. Gabriel Piete. Yes. Of course.
* Do you have it? No. Well. Hmm. Don't sneak up on people like that. Not polite.
*/
				1055105;

		public override bool Logged => false;

		public ElwoodDuringAutograph1Conversation_CollectorQuest()
		{
		}
	}

	public class ElwoodDuringAutograph2Conversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood seems to be studying the bottom of his bottle of ale
* as you approach.</I><BR><BR>
* 
* What's this? Strange. Quite strange. I could have sworn I was
* drinking wine.<BR><BR>
* 
* Oh, hello. Yes. Good to see you. Any luck with that autograph?
* Bet you thought I'd forgotten. No. Not me. Mind like a steel trap.
* Can't get it open no matter how hard you try. Or something. No luck
* yet? Ah well. keep trying. I have faith in you. Whoever you are.
*/
				1055112;

		public override bool Logged => false;

		public ElwoodDuringAutograph2Conversation_CollectorQuest()
		{
		}
	}

	public class ElwoodDuringAutograph3Conversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood scratches his ear then notices you.</I><BR><BR>
* 
* Good day. What brings you to the Albatross? Me? An autograph?
* You want my autograph? Well, I suppose. What's that? Oh. Yes.
* Gabriel Piete. Yes. Get his autograph and return to me. Good day.
*/
				1055115;

		public override bool Logged => false;

		public ElwoodDuringAutograph3Conversation_CollectorQuest()
		{
		}
	}

	public class ReturnAutographConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood looks up eagerly as you tell him about the autographed
* sheet music.</I><BR><BR>
* 
* Quite good work. Not an easy one to deal with, that one. Gabriel Piete.
* Yes. Well done. Nice autograph.<BR><BR>
* 
* One last task. I would like a set of toy monster figurines made by the
* famous toymaker, Tomas O'Neerlan. You'll find him in Trinsic. He's often
* at the Tinker's Guild. Try looking there.<BR><BR>
* 
* You're doing quite well. Quite well indeed. Knew you would. Just like old
* times. Yes. Quite good.
*/
				1055116;

		public ReturnAutographConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindTomasObjective_CollectorQuest());
		}
	}

	public class TomasToysConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Tomas smiles freely as you speak to him.</I><BR><BR>
* 
* Ah, to be sure I can make you some toy monster figurines.
* That's my work, making toys. Worry not, we'll put together
* a good set of monsters for you and your figurines.<BR><BR>
* 
* But I'll be needing something from you before I can begin.
* Here, take these enchanted paints. Using them, you can capture
* a set of images of the creatures you wish me to make into toys.
* It'll only work on the group of creatures I select for your
* set of figurines. Oh, and I'll be needing those enchanted paints
* back when all is said and done.<BR><BR>
*/
				1055119;

		public TomasToysConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new CaptureImagesObjective_CollectorQuest(true));
		}
	}

	public class TomasDuringCollectingConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Tomas greets you warmly as you approach.</I><BR><BR>
* 
* 'Tis good to see you. I see that you have not yet collected
* all of the images we need. 'Tis fine, but I'll be needing
* those before I can make the toy figurines. Return when you have
* the complete set of images.<BR><BR>
*/
				1055129;

		public override bool Logged => false;

		public TomasDuringCollectingConversation_CollectorQuest()
		{
		}
	}

	public class ReturnImagesConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Tomas grins as you walk toward him.</I><BR><BR>
* 
* I see that you have collected all of the images we need.
* 'Tis good. I'll begin straight away on the toy figurines.
* I'll have them delivered to you when ready. Where shall I send
* them? To Elwood in Haven? Yes, I know him. We've done business
* in the past. Odd fellow.<BR><BR>Tomas smiles as you return his
* enchanted paints back to him.<BR><BR>
*/
				1055131;

		public ReturnImagesConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new ReturnToysObjective_CollectorQuest());
		}
	}

	public class ElwoodDuringToys1Conversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>You watch as Elwood spins around blissfully on his stool.</I><BR><BR>
* 
* Oh. Forgive me. Didn't see you there. Whoo. Dizzy. Can't see straight.
* Have you gotten those figurines yet? No. Ah. Not to worry. Keep at it.
* No doubt you'll come through with those.<BR><BR>
* 
* Excuse me a moment. I think I need to sit down. Wait. I am sitting down.
* Good then. Yes. Sitting down.<BR><BR><I>Elwood reaches out and takes hold
* of the counter as if to steady himself.</I>
*/
				1055123;

		public override bool Logged => false;

		public ElwoodDuringToys1Conversation_CollectorQuest()
		{
		}
	}

	public class ElwoodDuringToys2Conversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood suddenly stops and beckons you over to him.</I><BR><BR>
* 
* Over here. Come here. Don't be alarmed, but I think one of the
* tavernkeepers used to be a wandering healer. Said something about
* the good ole days when people would just walk up and hand gold to
* them. Piles of gold. Out of the blue. Can you imagine? Got so much
* gold, this ex-healer decided to buy a tavern and settle down. Kind
* of sad really. Can't even cure my hangover now. Nice tavern though.<BR><BR>
* 
* Right. Anyway. Let me know when those toy figurines are ready.
* I'll be here. As always.
*/
				1055130;

		public override bool Logged => false;

		public ElwoodDuringToys2Conversation_CollectorQuest()
		{
		}
	}

	public class ElwoodDuringToys3Conversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood is singing as you greet him.</I><BR><BR>
* 
* Come. Join in. It's a Gabriel Piete song. I have the sheet music
* for it. It's even autographed by Gabriel Piete himself. Yes.
* One of his songs. Brilliant.<BR><BR>
* 
* So let me see the toys. Figurines. Let's see them. Oh. You don't
* have them yet. I see. Well. Okay. That's too bad.
*/
				1055133;

		public override bool Logged => false;

		public ElwoodDuringToys3Conversation_CollectorQuest()
		{
		}
	}

	public class CollectorEndConversation_CollectorQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Elwood takes a sip of his ale as you address him.</I><BR><BR>
* 
* Ah. That's the stuff. Ale. Nothing better. What's that? Toy figurines
* will be delivered. Right. Yes. Perhaps better than Ale. Tough one.<BR><BR>
* 
* Very good work. Quite. Think we're all done now. You completed everything
* I asked. Would work with you again. Yes. We should.<BR><BR>
* 
* Ah. Yes. your payment. The usual. I think you'll be pleased.<BR><BR>
* 
* <I>With that Elwood rummages around in his backpack. He eventually
* pulls out a small bag and hands it to you.</I>
*/
				1055134;

		public CollectorEndConversation_CollectorQuest()
		{
		}

		public override void OnRead()
		{
			System.Complete();
		}
	}

	public class FullEndConversation_CollectorQuest : QuestConversation
	{
		private readonly bool m_Logged;

		public override object Message =>
				/* <I>Elwood stares at you as you approach.</I><BR><BR>
* 
* I know you. Oh yes. You've been running some errands for me.
* We are about done. Noticed that your backpack is a bit full.
* Might want to make some room. Won't be able to hold your payment.
* Come back when you have more room, and we'll conclude our business.
*/
				1055135;

		public override bool Logged => m_Logged;

		public FullEndConversation_CollectorQuest(bool logged)
		{
			m_Logged = logged;
		}

		public FullEndConversation_CollectorQuest()
		{
			m_Logged = true;
		}

		public override void OnRead()
		{
			if (m_Logged)
			{
				System.AddObjective(new MakeRoomObjective_CollectorQuest());
			}
		}
	}

	#endregion

	#region Objective

	public class FishPearlsObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				// Fish up shellfish from Lake Haven and collect rainbow pearls.
				1055084;

		public override int MaxProgress => 6;

		public FishPearlsObjective_CollectorQuest()
		{
		}

		public override void RenderProgress(BaseQuestGump gump)
		{
			if (!Completed)
			{
				// Rainbow pearls collected:
				gump.AddHtmlObject(70, 260, 270, 100, 1055085, BaseQuestGump.Blue, false, false);

				gump.AddLabel(70, 280, 0x64, CurProgress.ToString());
				gump.AddLabel(100, 280, 0x64, "/");
				gump.AddLabel(130, 280, 0x64, MaxProgress.ToString());
			}
			else
			{
				base.RenderProgress(gump);
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new ReturnPearlsObjective_CollectorQuest());
		}
	}

	public class ReturnPearlsObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				/* You've collected enough rainbow pearls. Speak to
* Elwood to give them to him and get your next task.
*/
				1055088;

		public ReturnPearlsObjective_CollectorQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new ReturnPearlsConversation_CollectorQuest());
		}
	}

	public class FindAlbertaObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				// Go to Vesper and speak to Alberta Giacco at the Colored Canvas.
				1055091;

		public FindAlbertaObjective_CollectorQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new AlbertaPaintingConversation_CollectorQuest());
		}
	}

	public class SitOnTheStoolObjective_CollectorQuest : QuestObjective
	{
		private static readonly Point3D m_StoolLocation = new Point3D(2899, 706, 0);
		private static readonly Map m_StoolMap = Map.Trammel;

		private DateTime m_Begin;

		public override object Message =>
				/* Sit on the stool in front of Alberta's easel so that she can
* paint your portrait. You'll need to sit there for about 30 seconds.
*/
				1055093;

		public SitOnTheStoolObjective_CollectorQuest()
		{
			m_Begin = DateTime.MaxValue;
		}

		public override void CheckProgress()
		{
			var pm = System.From;

			if (pm.Map == m_StoolMap && pm.Location == m_StoolLocation)
			{
				if (m_Begin == DateTime.MaxValue)
				{
					m_Begin = DateTime.UtcNow;
				}
				else if (DateTime.UtcNow - m_Begin > TimeSpan.FromSeconds(30.0))
				{
					Complete();
				}
			}
			else if (m_Begin != DateTime.MaxValue)
			{
				m_Begin = DateTime.MaxValue;
				pm.SendLocalizedMessage(1055095, "", 0x26); // You must remain seated on the stool until the portrait is complete. Alberta will now have to start again with a fresh canvas.
			}
		}

		public override void OnComplete()
		{
			System.AddConversation(new AlbertaEndPaintingConversation_CollectorQuest());
		}
	}

	public class ReturnPaintingObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				// Return to Elwood and let him know that the painting is complete.
				1055099;

		public ReturnPaintingObjective_CollectorQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new ReturnPaintingConversation_CollectorQuest());
		}
	}

	public class FindGabrielObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				/* Go to Britain and obtain the autograph of renowned
* minstrel, Gabriel Piete. He is often found at the Conservatory of Music.
*/
				1055101;

		public FindGabrielObjective_CollectorQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new GabrielAutographConversation_CollectorQuest());
		}
	}

	public enum Theater
	{
		Britain,
		Nujelm,
		Jhelom
	}

	public class FindSheetMusicObjective_CollectorQuest : QuestObjective
	{
		private Theater m_Theater;

		public override object Message =>
				/* Find some sheet music for one of Gabriel's songs.
* Try speaking to an impresario from one of the theaters in the land.
*/
				1055104;

		public FindSheetMusicObjective_CollectorQuest(bool init)
		{
			if (init)
			{
				InitTheater();
			}
		}

		public FindSheetMusicObjective_CollectorQuest()
		{
		}

		public void InitTheater()
		{
			switch (Utility.Random(3))
			{
				case 1: m_Theater = Theater.Britain; break;
				case 2: m_Theater = Theater.Nujelm; break;
				default: m_Theater = Theater.Jhelom; break;
			}
		}

		public bool IsInRightTheater()
		{
			var player = System.From;

			var region = Region.Find(player.Location, player.Map);

			if (region == null)
			{
				return false;
			}

			switch (m_Theater)
			{
				case Theater.Britain: return region.IsPartOf("Britain");
				case Theater.Nujelm: return region.IsPartOf("Nujel'm");
				case Theater.Jhelom: return region.IsPartOf("Jhelom");

				default: return false;
			}
		}

		public override void OnComplete()
		{
			System.AddConversation(new GetSheetMusicConversation_CollectorQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_Theater = (Theater)reader.ReadEncodedInt();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.WriteEncodedInt((int)m_Theater);
		}
	}

	public class ReturnSheetMusicObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				// Speak to Gabriel to have him autograph the sheet music.
				1055110;

		public ReturnSheetMusicObjective_CollectorQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new GabrielSheetMusicConversation_CollectorQuest());
		}
	}

	public class ReturnAutographObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				// Speak to Elwood to give him the autographed sheet music.
				1055114;

		public ReturnAutographObjective_CollectorQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new ReturnAutographConversation_CollectorQuest());
		}
	}

	public class FindTomasObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				// Go to Trinsic and speak to Tomas O'Neerlan, the famous toymaker.
				1055117;

		public FindTomasObjective_CollectorQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new TomasToysConversation_CollectorQuest());
		}
	}

	public enum CaptureResponse
	{
		Valid,
		AlreadyDone,
		Invalid
	}

	public class CaptureImagesObjective_CollectorQuest : QuestObjective
	{
		private ImageType[] m_Images;
		private bool[] m_Done;

		public override object Message =>
				// Use the enchanted paints to capture the image of all of the creatures listed below.
				1055120;

		public override bool Completed
		{
			get
			{
				for (var i = 0; i < m_Done.Length; i++)
				{
					if (!m_Done[i])
					{
						return false;
					}
				}

				return true;
			}
		}

		public CaptureImagesObjective_CollectorQuest(bool init)
		{
			if (init)
			{
				m_Images = ImageTypeInfo.RandomList(4);
				m_Done = new bool[4];
			}
		}

		public CaptureImagesObjective_CollectorQuest()
		{
		}

		public override bool IgnoreYoungProtection(Mobile from)
		{
			if (Completed)
			{
				return false;
			}

			var fromType = from.GetType();

			for (var i = 0; i < m_Images.Length; i++)
			{
				var info = ImageTypeInfo.Get(m_Images[i]);

				if (info.Type == fromType)
				{
					return true;
				}
			}

			return false;
		}

		public CaptureResponse CaptureImage(Type type, out ImageType image)
		{
			for (var i = 0; i < m_Images.Length; i++)
			{
				var info = ImageTypeInfo.Get(m_Images[i]);

				if (info.Type == type)
				{
					image = m_Images[i];

					if (m_Done[i])
					{
						return CaptureResponse.AlreadyDone;
					}
					else
					{
						m_Done[i] = true;

						CheckCompletionStatus();

						return CaptureResponse.Valid;
					}
				}
			}

			image = 0;
			return CaptureResponse.Invalid;
		}

		public override void RenderProgress(BaseQuestGump gump)
		{
			if (!Completed)
			{
				for (var i = 0; i < m_Images.Length; i++)
				{
					var info = ImageTypeInfo.Get(m_Images[i]);

					gump.AddHtmlObject(70, 260 + 20 * i, 200, 100, info.Name, BaseQuestGump.Blue, false, false);
					gump.AddLabel(200, 260 + 20 * i, 0x64, " : ");
					gump.AddHtmlObject(220, 260 + 20 * i, 100, 100, m_Done[i] ? 1055121 : 1055122, BaseQuestGump.Blue, false, false);
				}
			}
			else
			{
				base.RenderProgress(gump);
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new ReturnImagesObjective_CollectorQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			var count = reader.ReadEncodedInt();

			m_Images = new ImageType[count];
			m_Done = new bool[count];

			for (var i = 0; i < count; i++)
			{
				m_Images[i] = (ImageType)reader.ReadEncodedInt();
				m_Done[i] = reader.ReadBool();
			}
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.WriteEncodedInt(m_Images.Length);

			for (var i = 0; i < m_Images.Length; i++)
			{
				writer.WriteEncodedInt((int)m_Images[i]);
				writer.Write(m_Done[i]);
			}
		}
	}

	public class ReturnImagesObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				/* You now have all of the creature images you need.
* Return to Tomas O'Neerlan so that he can make the toy figurines.
*/
				1055128;

		public ReturnImagesObjective_CollectorQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new ReturnImagesConversation_CollectorQuest());
		}
	}

	public class ReturnToysObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				// Return to Elwood with news that the toy figurines will be delivered when ready.
				1055132;

		public ReturnToysObjective_CollectorQuest()
		{
		}
	}

	public class MakeRoomObjective_CollectorQuest : QuestObjective
	{
		public override object Message =>
				// Return to Elwood for your reward when you have some room in your backpack.
				1055136;

		public MakeRoomObjective_CollectorQuest()
		{
		}
	}

	#endregion
}