namespace Server
{
	public interface ISpell
	{
		bool IsCasting { get; }
		void OnCasterHurt();
		void OnCasterKilled();
		void OnConnectionChanged();
		bool OnCasterMoving(Direction d);
		bool OnCasterEquiping(Item item);
		bool OnCasterUsingObject(object o);
		bool OnCastInTown(Region r);
	}
}