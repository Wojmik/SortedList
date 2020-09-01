using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.KeysData
{
	public class KeysData<T, K1, K2> : KeysData<T, K1>
	{
		public KeyData<T, K2> Key2Data { get; }

		public KeysData(
			in KeyData<T, K1> key1Data,
			in KeyData<T, K2> key2Data
			)
			: base(key1Data: key1Data)
		{
			this.Key2Data = key2Data;
		}

		public override int Compare(T x, T y)
		{
			int cmp;

			if(0==(cmp=Key1Data.Comparison(Key1Data.GetMember(x), Key1Data.GetMember(y))))
				cmp=Key2Data.Comparison(Key2Data.GetMember(x), Key2Data.GetMember(y));

			return cmp;
		}

		public int Compare(T item, K1 key1, K2 key2)
		{
			int cmp;

			if(0==(cmp=Key1Data.Comparison(Key1Data.GetMember(item), key1)))
				cmp=Key2Data.Comparison(Key2Data.GetMember(item), key2);

			return cmp;
		}
	}
}