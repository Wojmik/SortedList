using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList
{
	public readonly struct KeyData<T, K> : IKeyData<T>
	{
		public Func<T, K> GetMember { get; }

		public Comparison<K> Comparison { get; }

		public KeyData(Func<T, K> getMember, Comparison<K> comparison)
		{
			this.GetMember = getMember;
			this.Comparison = comparison;
		}

		public KeyData(Func<T, K> getMember, Comparer<K> comparer)
		{
			this.GetMember = getMember;
			this.Comparison = comparer.Compare;
		}

		public KeyData(Func<T, K> getMember)
		{
			this.GetMember = getMember;
			this.Comparison = Comparer<K>.Default.Compare;
		}

		public void Deconstruct(out Func<T, K> getMember, out Comparison<K> comparison)
		{
			getMember=this.GetMember;
			comparison=this.Comparison;
		}

		public int Compare(T x, T y)
		{
			return this.Comparison(this.GetMember(x), this.GetMember(y));
		}

		public int Compare(T x, K value)
		{
			return this.Comparison(this.GetMember(x), value);
		}

		int IKeyData<T>.Compare(T x, object value)
		{
			return this.Comparison(this.GetMember(x), (K)value);
		}
	}
}