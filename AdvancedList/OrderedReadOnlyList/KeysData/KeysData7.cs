using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.KeysData
{
	public class KeysData<T, K1, K2, K3, K4, K5, K6, K7> : KeysData<T, K1, K2, K3, K4, K5, K6>
	{
		public KeyData<T, K7> Key7Data { get; }

		public KeysData(
			in KeyData<T, K1> key1Data,
			in KeyData<T, K2> key2Data,
			in KeyData<T, K3> key3Data,
			in KeyData<T, K4> key4Data,
			in KeyData<T, K5> key5Data,
			in KeyData<T, K6> key6Data,
			in KeyData<T, K7> key7Data
			)
			: base(
				  key1Data: key1Data,
				  key2Data: key2Data,
				  key3Data: key3Data,
				  key4Data: key4Data,
				  key5Data: key5Data,
				  key6Data: key6Data
				  )
		{
			this.Key7Data = key7Data;
		}

		public override int Compare(T x, T y)
		{
			int cmp;

			if(0==(cmp=Key1Data.Comparison(Key1Data.GetMember(x), Key1Data.GetMember(y))))
				if(0==(cmp=Key2Data.Comparison(Key2Data.GetMember(x), Key2Data.GetMember(y))))
					if(0==(cmp=Key3Data.Comparison(Key3Data.GetMember(x), Key3Data.GetMember(y))))
						if(0==(cmp=Key4Data.Comparison(Key4Data.GetMember(x), Key4Data.GetMember(y))))
							if(0==(cmp=Key5Data.Comparison(Key5Data.GetMember(x), Key5Data.GetMember(y))))
								if(0==(cmp=Key6Data.Comparison(Key6Data.GetMember(x), Key6Data.GetMember(y))))
									cmp=Key7Data.Comparison(Key7Data.GetMember(x), Key7Data.GetMember(y));

			return cmp;
		}

		public int Compare(T item, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			int cmp;

			if(0==(cmp=Key1Data.Comparison(Key1Data.GetMember(item), key1)))
				if(0==(cmp=Key2Data.Comparison(Key2Data.GetMember(item), key2)))
					if(0==(cmp=Key3Data.Comparison(Key3Data.GetMember(item), key3)))
						if(0==(cmp=Key4Data.Comparison(Key4Data.GetMember(item), key4)))
							if(0==(cmp=Key5Data.Comparison(Key5Data.GetMember(item), key5)))
								if(0==(cmp=Key6Data.Comparison(Key6Data.GetMember(item), key6)))
									cmp=Key7Data.Comparison(Key7Data.GetMember(item), key7);

			return cmp;
		}
	}
}