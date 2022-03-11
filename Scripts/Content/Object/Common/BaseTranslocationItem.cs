namespace Server.Items
{
	public interface TranslocationItem
	{
		int Charges { get; set; }
		int Recharges { get; set; }
		int MaxCharges { get; }
		int MaxRecharges { get; }
		string TranslocationItemName { get; }
	}
}