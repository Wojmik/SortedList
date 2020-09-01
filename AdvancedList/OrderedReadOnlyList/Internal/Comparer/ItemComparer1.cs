using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal.Comparer
{
	readonly struct ItemComparer<T, K1>
	{
		private readonly Func<T, K1> Key1Getter;

		private readonly Comparison<K1> Key1Comparison;

		private readonly K1 Key1;

		public ItemComparer(
			Comparison<K1> key1Comparison, Func<T, K1> key1Getter, K1 key1
			)
		{
			this.Key1Comparison = key1Comparison;
			this.Key1Getter = key1Getter;
			this.Key1 = key1;
		}

		public int Compare(T item)
		{
			int cmp;

			cmp=Key1Comparison(Key1, Key1Getter(item));

			return cmp;
		}
	}
}