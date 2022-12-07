namespace Server.Items
{
	public class EnhancementAttributes
	{
		public Mobile Owner { get; }

		public string Title { get; }

		private AosAttributes _Attributes;

		public AosAttributes Attributes => _Attributes ??= new AosAttributes(Owner);

		private AosWeaponAttributes _WeaponAttributes;

		public AosWeaponAttributes WeaponAttributes => _WeaponAttributes ??= new AosWeaponAttributes(Owner);

		private AosArmorAttributes _ArmorAttributes;

		public AosArmorAttributes ArmorAttributes => _ArmorAttributes ??= new AosArmorAttributes(Owner);

		public EnhancementAttributes(Mobile owner, string title)
		{
			Owner = owner;
			Title = title;
		}
	}
}