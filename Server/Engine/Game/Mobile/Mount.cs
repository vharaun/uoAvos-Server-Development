namespace Server.Mobiles
{
	public interface IMount
	{
		Mobile Rider { get; set; }
		void OnRiderDamaged(int amount, Mobile from, bool willKill);
	}

	public interface IMountItem
	{
		IMount Mount { get; }
	}
}