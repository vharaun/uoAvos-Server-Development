
using System;

namespace Server
{
	public interface IEntity : IPoint3D, IComparable, IComparable<IEntity>
	{
		string Name { get; set; }
		Serial Serial { get; }
		Point3D Location { get; }
		Map Map { get; }
		bool Deleted { get; }

		void Delete();
		void ProcessDelta();
		void InvalidateProperties();
	}

	public class Entity : IEntity, IComparable<Entity>
	{
		public int CompareTo(IEntity other)
		{
			if (other == null)
			{
				return -1;
			}

			return m_Serial.CompareTo(other.Serial);
		}

		public int CompareTo(Entity other)
		{
			return CompareTo((IEntity)other);
		}

		public int CompareTo(object other)
		{
			if (other == null || other is IEntity)
			{
				return CompareTo((IEntity)other);
			}

			throw new ArgumentException();
		}

		private string m_Name;
		private readonly Serial m_Serial;
		private Point3D m_Location;
		private readonly Map m_Map;
		private bool m_Deleted;

		public Entity(Serial serial, Point3D loc, Map map)
		{
			m_Name = null;
			m_Serial = serial;
			m_Location = loc;
			m_Map = map;
			m_Deleted = false;
		}

		public string Name
		{
			get => m_Name;
			set => m_Name = value;
		}

		public Serial Serial => m_Serial;

		public Point3D Location => m_Location;

		public int X => m_Location.X;

		public int Y => m_Location.Y;

		public int Z => m_Location.Z;

		public Map Map => m_Map;

		public bool Deleted => m_Deleted;

		public void Delete()
		{
			m_Deleted = true;
		}

		public void ProcessDelta()
		{
		}

		public void InvalidateProperties()
		{
		}
	}
}