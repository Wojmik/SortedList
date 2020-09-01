using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal.Comparer
{
	readonly struct ItemComparer<T, K1, K2, K3, K4>
	{
		private readonly Func<T, K1> Key1Getter;
		private readonly Func<T, K2> Key2Getter;
		private readonly Func<T, K3> Key3Getter;
		private readonly Func<T, K4> Key4Getter;

		private readonly Comparison<K1> Key1Comparison;
		private readonly Comparison<K2> Key2Comparison;
		private readonly Comparison<K3> Key3Comparison;
		private readonly Comparison<K4> Key4Comparison;

		private readonly K1 Key1;
		private readonly K2 Key2;
		private readonly K3 Key3;
		private readonly K4 Key4;

		public ItemComparer(
			Comparison<K1> key1Comparison, Func<T, K1> key1Getter, K1 key1,
			Comparison<K2> key2Comparison, Func<T, K2> key2Getter, K2 key2,
			Comparison<K3> key3Comparison, Func<T, K3> key3Getter, K3 key3,
			Comparison<K4> key4Comparison, Func<T, K4> key4Getter, K4 key4
			)
		{
			this.Key1Comparison = key1Comparison;
			this.Key1Getter = key1Getter;
			this.Key1 = key1;
			this.Key2Comparison = key2Comparison;
			this.Key2Getter = key2Getter;
			this.Key2 = key2;
			this.Key3Comparison = key3Comparison;
			this.Key3Getter = key3Getter;
			this.Key3 = key3;
			this.Key4Comparison = key4Comparison;
			this.Key4Getter = key4Getter;
			this.Key4 = key4;
		}

		public int Compare(T item)
		{
			int cmp;

			if(0==(cmp=Key1Comparison(Key1, Key1Getter(item))))
				if(0==(cmp=Key2Comparison(Key2, Key2Getter(item))))
					if(0==(cmp=Key3Comparison(Key3, Key3Getter(item))))
						cmp=Key4Comparison(Key4, Key4Getter(item));

			return cmp;
		}
	}
}