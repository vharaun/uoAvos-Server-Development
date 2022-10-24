namespace Server.Spells.Bushido
{
	public abstract class BushidoAbility : SpecialMove
	{
		public override SkillName MoveSkill => SkillName.Bushido;

		public override void CheckGain(Mobile m)
		{
			m.CheckSkill(MoveSkill, RequiredSkill - 12.5, RequiredSkill + 37.5);    //Per five on friday 02/16/07
		}
	}
}