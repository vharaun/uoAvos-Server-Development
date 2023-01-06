using Server.Items;
using Server.Mobiles;

using System.Collections.Generic;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Hamato : BaseVendor
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078134); // Seek me to learn the way of the samurai.
		}

		[Constructable]
		public Hamato()
			: base("the Bushido Instructor")
		{
			Name = "Hamato";
			Hue = 0x8403;

			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Parry, 120.0);
			SetSkill(SkillName.Healing, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Swords, 120.0);
			SetSkill(SkillName.Bushido, 120.0);
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBSamurai());
		}

		public override bool GetGender()
		{
			return false;
		}

		public override void InitOutfit()
		{
			HairItemID = 0x203D;
			HairHue = 0x497;

			AddItem(new Backpack());
			AddItem(new NoDachi());
			AddItem(new NinjaTabi());
			AddItem(new PlateSuneate());
			AddItem(new LightPlateJingasa());
			AddItem(new LeatherDo());
			AddItem(new LeatherHiroSode());

			PackGold(100, 200);
		}

		public Hamato(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}