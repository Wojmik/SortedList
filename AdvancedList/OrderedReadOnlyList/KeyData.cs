using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList
{
	public abstract class KeyData<T> : IComparer<T>
	{
		public static KeyData<T> Create<K>(Func<T, K> getMember, Comparison<K> comparison = null)
		{
			return new KeyData<T, K>(getMember: getMember, comparison: comparison);
		}

		public abstract int Compare(T x, T y);
	}

	public class KeyData<T, K> : KeyData<T>
	{
		public static implicit operator KeyData<T, K>(Func<T, K> func) => new KeyData<T, K>(func);

		public Func<T, K> GetMember { get; }

		public Comparison<K> Comparison { get; }

		public KeyData(Func<T, K> getMember, Comparison<K> comparison = null)
		{
			this.GetMember=getMember;
			this.Comparison=comparison??Comparer<K>.Default.Compare;
		}

		public override int Compare(T x, T y)
		{
			return this.Comparison(this.GetMember(x), this.GetMember(y));
		}

		public int Compare(T x, K value)
		{
			return this.Comparison(this.GetMember(x), value);
		}
	}
}