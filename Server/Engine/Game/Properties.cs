#region References
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
#endregion

namespace Server
{
	public interface INotifyPropertyUpdate
	{
	}

	public static class PropertyNotifier
	{
		public static event Action<INotifyPropertyUpdate, object> OnPropertyChanged;

		public static void Notify(INotifyPropertyUpdate sender, object state)
		{
			OnPropertyChanged?.Invoke(sender, state);
		}
	}

	public interface ITypeAmountImpl
	{ 
		TypeAmounts Types { get; }
	}

	[PropertyObject, StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TypeAmount : IEquatable<TypeAmount>, IEquatable<Type>
	{
		public static readonly TypeAmount Empty = new();

		private Type _Type;
		private int _Amount;
		private bool _Inherit;

		[CommandProperty(AccessLevel.Counselor, true)]
		public Type Type => _Type;

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public int Amount { get => _Amount; set => _Amount = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool Inherit { get => _Inherit; set => _Inherit = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public bool IsValid => _Type != null;

		[CommandProperty(AccessLevel.Counselor)]
		public bool IsActive => IsValid && _Amount > 0;

		[CommandProperty(AccessLevel.Counselor)]
		public bool IsEmpty => Equals(Empty);

		public TypeAmount(Type type)
			: this(type, 1)
		{ }

		public TypeAmount(Type type, int amount)
			: this(type, amount, type.IsAbstract)
		{ }

		public TypeAmount(Type type, int amount, bool inherit)
		{
			_Type = type;
			_Amount = amount;
			_Inherit = inherit;
		}

		public TypeAmount(GenericReader reader)
			: this()
		{
			Deserialize(reader);
		}

		public void SetAmount(int amount)
		{
			_Amount = amount;
		}

		public void SetInherit(bool inherit)
		{
			_Inherit = inherit;
		}

		public void Set(int amount, bool inherit)
		{
			SetAmount(amount);
			SetInherit(inherit);
		}

		public override string ToString()
		{
			return $"({_Type?.Name ?? "(null)"}, {_Amount}, {_Inherit})";
		}

		public override int GetHashCode()
		{
			return Type?.GetHashCode() ?? base.GetHashCode();
		}

		public override bool Equals(object o)
		{
			return (o is TypeAmount e && Equals(e)) || (o is Type t && Equals(t));
		}

		public bool Equals(TypeAmount t)
		{
			return Equals(t._Type);
		}

		public bool Equals(Type t)
		{
			return _Type?.Equals(t) ?? false;
		}

		public bool Inherited(Type t)
		{
			return Inherit && (_Type?.IsAssignableFrom(t) ?? false);
		}

		public bool Match(object o)
		{
			if (o == null)
			{
				return false;
			}

			var t = o.GetType();

			return Equals(t) || Inherited(t);
		}

		public void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0);

			writer.WriteObjectType(_Type);
			writer.WriteEncodedInt(_Amount);
			writer.Write(_Inherit);
		}

		public void Deserialize(GenericReader reader)
		{
			reader.ReadEncodedInt();

			_Type = reader.ReadObjectType();
			_Amount = reader.ReadEncodedInt();
			_Inherit = reader.ReadBool();
		}

		public static bool operator ==(TypeAmount l, TypeAmount r)
		{
			return l.Equals(r);
		}

		public static bool operator !=(TypeAmount l, TypeAmount r)
		{
			return !l.Equals(r);
		}

		public static implicit operator Type(TypeAmount t)
		{
			return t._Type;
		}

		public static implicit operator int(TypeAmount t)
		{
			return t._Amount;
		}
	}

	public class TypeAmounts : ICollection<TypeAmount>, INotifyPropertyUpdate
	{
		private readonly List<TypeAmount> _Entries = new();

		bool ICollection<TypeAmount>.IsReadOnly => ((ICollection<TypeAmount>)_Entries).IsReadOnly;

		public TypeAmount this[int index] => index >=0 && index < _Entries.Count ? _Entries[index] : TypeAmount.Empty;

		public int this[Type type] { get => _Entries.Find(t => t.Type == type); set => Set(type, value); }

		public IEnumerable<Type> Types => _Entries.Select(e => e.Type);
		public IEnumerable<int> Amounts => _Entries.Select(e => e.Amount);

		public int Count => _Entries.Count;

		[CommandProperty(AccessLevel.GameMaster)]
		public string AddTypeByName
		{
			get => "Add ->";
			set
			{
				if (value == null || value == "Add ->")
				{
					return;
				}

				value = value.Replace("Add ->", String.Empty);

				var type = ScriptCompiler.FindTypeByName(value, true);

				if (type != null && IndexOf(type) < 0)
				{
					Set(type, 1, type.IsAbstract);
				}
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public string RemoveTypeByName
		{
			get => "Remove ->";
			set
			{
				if (value == null || value == "Remove ->")
				{
					return;
				}

				value = value.Replace("Remove ->", String.Empty);

				var type = ScriptCompiler.FindTypeByName(value, true);

				if (type != null)
				{
					Unset(type);
				}
			}
		}

		public TypeAmounts()
		{ }

		public TypeAmounts(params TypeAmount[] entries)
		{
			_Entries.AddRange(entries);
		}

		public TypeAmounts(IEnumerable<TypeAmount> entries)
		{
			_Entries.AddRange(entries);
		}

		void ICollection<TypeAmount>.Add(TypeAmount t)
		{
			Set(t.Type, t.Amount, t.Inherit);
		}

		bool ICollection<TypeAmount>.Remove(TypeAmount t)
		{
			if (_Entries.Remove(t))
			{
				PropertyNotifier.Notify(this, _Entries);
				return true;
			}

			return false;
		}

		bool ICollection<TypeAmount>.Contains(TypeAmount t)
		{
			return _Entries.Contains(t);
		}

		public int IndexOf(Type type)
		{
			return IndexOf(type, true);
		}

		public int IndexOf(Type type, bool inherited)
		{
			return _Entries.FindIndex(e => e.IsValid && (e.Equals(type) || (inherited && e.Inherited(type))));
		}

		public bool TryGetEntry(Type type, out int index, out TypeAmount t)
		{
			index = IndexOf(type);

			if (index < 0)
			{
				t = TypeAmount.Empty;
			}
			else
			{
				t = _Entries[index];
			}

			return index >= 0;
		}

		public bool TryGetAmount(Type type, out int amount)
		{
			var success = TryGetEntry(type, out _, out var e);

			if (success)
			{
				amount = e.Amount;
			}
			else
			{
				amount = default;
			}

			return success;
		}

		public bool TryGetInherit(Type type, out bool inherit)
		{
			var success = TryGetEntry(type, out _, out var e);

			if (success)
			{
				inherit = e.Inherit;
			}
			else
			{
				inherit = default;
			}

			return success;
		}

		public bool Set(Type type, int amount, bool inherit)
		{
			if (type == null || amount < 0)
			{
				return false;
			}

			var index = IndexOf(type);

			if (index >= 0)
			{
				_Entries[index].Set(amount, inherit);
			}
			else
			{
				_Entries.Add(new TypeAmount(type, amount, inherit));

				PropertyNotifier.Notify(this, _Entries);
			}

			return true;
		}

		public bool Set(Type type, int amount)
		{
			if (type == null || amount < 0)
			{
				return false;
			}

			var index = IndexOf(type);

			if (index >= 0)
			{
				_Entries[index].SetAmount(amount);
			}
			else
			{
				_Entries.Add(new TypeAmount(type, amount));

				PropertyNotifier.Notify(this, _Entries);
			}

			return true;
		}

		public void SetInherit(Type type, bool inherit)
		{
			if (type == null)
			{
				return;
			}

			var index = IndexOf(type);

			if (index >= 0)
			{
				_Entries[index].SetInherit(inherit);
			}
			else
			{
				_Entries.Add(new TypeAmount(type, 1, inherit));

				PropertyNotifier.Notify(this, _Entries);
			}
		}

		public void Unset(Type type)
		{
			var index = IndexOf(type);

			if (index >= 0)
			{
				_Entries.RemoveAt(index);

				PropertyNotifier.Notify(this, _Entries);
			}
		}

		public void Clear()
		{
			_Entries.Clear();

			PropertyNotifier.Notify(this, _Entries);
		}

		public void CopyTo(TypeAmounts obj)
		{
			foreach (var o in _Entries)
			{
				obj.Set(o.Type, o.Amount, o.Inherit);
			}
		}

		public void CopyTo(TypeAmount[] array, int arrayIndex)
		{
			_Entries.CopyTo(array, arrayIndex);
		}

		public IEnumerator<TypeAmount> GetEnumerator()
		{
			return _Entries.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _Entries.GetEnumerator();
		}

		public override string ToString()
		{
			return $"Types[{Count}]";
		}

		public void Serialize(GenericWriter writer)
		{
			writer.Write(0);

			writer.Write(_Entries.Count);

			foreach (var e in _Entries)
			{
				e.Serialize(writer);
			}
		}

		public void Deserialize(GenericReader reader)
		{
			reader.ReadInt();

			var count = reader.ReadInt();

			while (--count >= 0)
			{
				_Entries.Add(new TypeAmount(reader));
			}

			_Entries.RemoveAll(e => e.Type == null);
		}
	}

	[PropertyObject, StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TypeEntry : IEquatable<TypeEntry>, IEquatable<Type>
	{
		public static readonly TypeEntry Empty = new();

		private Type _Type;
		private bool _State;
		private bool _Inherit;

		[CommandProperty(AccessLevel.Counselor, true)]
		public Type Type => _Type;

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool State { get => _State; set => _State = value; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool Inherit { get => _Inherit; set => _Inherit = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public bool IsValid => _Type != null;

		[CommandProperty(AccessLevel.Counselor)]
		public bool IsActive => IsValid && _State;

		[CommandProperty(AccessLevel.Counselor)]
		public bool IsEmpty => Equals(Empty);

		public TypeEntry(Type type)
			: this(type, true)
		{ }

		public TypeEntry(Type type, bool state)
			: this(type, state, type.IsAbstract)
		{ }

		public TypeEntry(Type type, bool state, bool inherit)
		{
			_Type = type;
			_State = state;
			_Inherit = inherit;
		}

		public TypeEntry(GenericReader reader)
			: this()
		{
			Deserialize(reader);
		}

		public void SetState(bool state)
		{
			_State = state;
		}

		public void SetInherit(bool inherit)
		{
			_Inherit = inherit;
		}

		public void Set(bool state, bool inherit)
		{
			SetState(state);
			SetInherit(inherit);
		}

		public override string ToString()
		{
			return $"({_Type?.Name ?? "(null)"}, {_State}, {_Inherit})";
		}

		public override int GetHashCode()
		{
			return Type?.GetHashCode() ?? base.GetHashCode();
		}

		public override bool Equals(object o)
		{
			return (o is TypeEntry e && Equals(e)) || (o is Type t && Equals(t));
		}

		public bool Equals(TypeEntry t)
		{
			return Equals(t._Type);
		}

		public bool Equals(Type t)
		{
			return _Type?.Equals(t) ?? false;
		}

		public bool Inherited(Type t)
		{
			return Inherit && (_Type?.IsAssignableFrom(t) ?? false);
		}

		public bool Match(object o)
		{
			if (o == null)
			{
				return false;
			}

			var t = o.GetType();

			return Equals(t) || Inherited(t);
		}

		public void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0);

			writer.WriteObjectType(_Type);
			writer.Write(_State);
			writer.Write(_Inherit);
		}

		public void Deserialize(GenericReader reader)
		{
			reader.ReadEncodedInt();

			_Type = reader.ReadObjectType();
			_State = reader.ReadBool();
			_Inherit = reader.ReadBool();
		}

		public static bool operator ==(TypeEntry l, TypeEntry r)
		{
			return l.Equals(r);
		}

		public static bool operator !=(TypeEntry l, TypeEntry r)
		{
			return !l.Equals(r);
		}

		public static implicit operator Type(TypeEntry t)
		{
			return t._Type;
		}

		public static implicit operator bool(TypeEntry t)
		{
			return t._State;
		}
	}

	public class TypeList : ICollection<TypeEntry>, INotifyPropertyUpdate
	{
		private readonly List<TypeEntry> _Entries = new();

		bool ICollection<TypeEntry>.IsReadOnly => ((ICollection<TypeEntry>)_Entries).IsReadOnly;

		public TypeEntry this[int index] => index >= 0 && index < _Entries.Count ? _Entries[index] : TypeEntry.Empty;

		public bool this[Type type] { get => _Entries.Find(t => t.Type == type); set => Set(type, value); }

		public IEnumerable<Type> Types => _Entries.Select(e => e.Type);
		public IEnumerable<bool> States => _Entries.Select(e => e.State);

		public int Count => _Entries.Count;

		[CommandProperty(AccessLevel.GameMaster)]
		public string AddTypeByName
		{
			get => "Add ->";
			set
			{
				if (value == null || value == "Add ->")
				{
					return;
				}

				value = value.Replace("Add ->", String.Empty);

				var type = ScriptCompiler.FindTypeByName(value, true);

				if (type != null && IndexOf(type) < 0)
				{
					Set(type, true, type.IsAbstract);
				}
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public string RemoveTypeByName
		{
			get => "Remove ->";
			set
			{
				if (value == null || value == "Remove ->")
				{
					return;
				}

				value = value.Replace("Remove ->", String.Empty);

				var type = ScriptCompiler.FindTypeByName(value, true);

				if (type != null)
				{
					Unset(type);
				}
			}
		}

		public TypeList()
		{ }

		public TypeList(params TypeEntry[] entries)
		{
			_Entries.AddRange(entries);
		}

		public TypeList(IEnumerable<TypeEntry> entries)
		{
			_Entries.AddRange(entries);
		}

		void ICollection<TypeEntry>.Add(TypeEntry t)
		{
			Set(t.Type, t.State, t.Inherit);
		}

		bool ICollection<TypeEntry>.Remove(TypeEntry t)
		{
			if (_Entries.Remove(t))
			{
				PropertyNotifier.Notify(this, _Entries);
				return true;
			}

			return false;
		}

		bool ICollection<TypeEntry>.Contains(TypeEntry t)
		{
			return _Entries.Contains(t);
		}

		public int IndexOf(Type type)
		{
			return IndexOf(type, true);
		}

		public int IndexOf(Type type, bool inherited)
		{
			return _Entries.FindIndex(e => e.IsValid && (e.Equals(type) || (inherited && e.Inherited(type))));
		}

		public bool TryGetEntry(Type type, out int index, out TypeEntry t)
		{
			index = IndexOf(type);

			if (index < 0)
			{
				t = TypeEntry.Empty;
			}
			else
			{
				t = _Entries[index];
			}

			return index >= 0;
		}

		public bool TryGetState(Type type, out bool state)
		{
			var success = TryGetEntry(type, out _, out var e);

			if (success)
			{
				state = e.State;
			}
			else
			{
				state = default;
			}

			return success;
		}

		public bool TryGetInherit(Type type, out bool inherit)
		{
			var success = TryGetEntry(type, out _, out var e);

			if (success)
			{
				inherit = e.Inherit;
			}
			else
			{
				inherit = default;
			}

			return success;
		}

		public bool Set(Type type, bool state, bool inherit)
		{
			if (type == null)
			{
				return false;
			}

			var index = IndexOf(type);

			if (index >= 0)
			{
				_Entries[index].Set(state, inherit);
			}
			else
			{
				_Entries.Add(new TypeEntry(type, state, inherit));

				PropertyNotifier.Notify(this, _Entries);
			}

			return true;
		}

		public bool Set(Type type, bool state)
		{
			if (type == null)
			{
				return false;
			}

			var index = IndexOf(type);

			if (index >= 0)
			{
				_Entries[index].SetState(state);
			}
			else
			{
				_Entries.Add(new TypeEntry(type, state));

				PropertyNotifier.Notify(this, _Entries);
			}

			return true;
		}

		public void SetInherit(Type type, bool inherit)
		{
			if (type == null)
			{
				return;
			}

			var index = IndexOf(type);

			if (index >= 0)
			{
				_Entries[index].SetInherit(inherit);
			}
			else
			{
				_Entries.Add(new TypeEntry(type, true, inherit));

				PropertyNotifier.Notify(this, _Entries);
			}
		}

		public void Unset(Type type)
		{
			var index = IndexOf(type);

			if (index >= 0)
			{
				_Entries.RemoveAt(index);

				PropertyNotifier.Notify(this, _Entries);
			}
		}

		public void Clear()
		{
			_Entries.Clear();

			PropertyNotifier.Notify(this, _Entries);
		}

		public void CopyTo(TypeList obj)
		{
			foreach (var o in _Entries)
			{
				obj.Set(o.Type, o.State, o.Inherit);
			}
		}

		public void CopyTo(TypeEntry[] array, int arrayIndex)
		{
			_Entries.CopyTo(array, arrayIndex);
		}

		public IEnumerator<TypeEntry> GetEnumerator()
		{
			return _Entries.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _Entries.GetEnumerator();
		}

		public override string ToString()
		{
			return $"Types[{Count}]";
		}

		public void Serialize(GenericWriter writer)
		{
			writer.Write(0);

			writer.Write(_Entries.Count);

			foreach (var e in _Entries)
			{
				e.Serialize(writer);
			}
		}

		public void Deserialize(GenericReader reader)
		{
			reader.ReadInt();

			var count = reader.ReadInt();

			while (--count >= 0)
			{
				_Entries.Add(new TypeEntry(reader));
			}

			_Entries.RemoveAll(e => e.Type == null);
		}
	}
}
