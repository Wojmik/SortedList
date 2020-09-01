using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.KeysData
{
	public class KeysData<T, K1> : KeysData<T>
	{
		public KeyData<T, K1> Key1Data { get; }

		public KeysData(
			in KeyData<T, K1> key1Data
			)
		{
			this.Key1Data = key1Data;
		}

		public override int Compare(T x, T y)
		{
			int cmp;

			cmp=Key1Data.Comparison(Key1Data.GetMember(x), Key1Data.GetMember(y));

			return cmp;
		}

		public int Compare(T item, K1 key1)
		{
			int cmp;

			cmp=Key1Data.Comparison(Key1Data.GetMember(item), key1);

			return cmp;
		}
	}
}