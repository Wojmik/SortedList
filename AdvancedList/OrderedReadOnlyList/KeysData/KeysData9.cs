using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.KeysData
{
	public class KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9> : KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8>
	{
		public KeyData<T, K9> Key9Data { get; }

		public KeysData(
			in KeyData<T, K1> key1Data,
			in KeyData<T, K2> key2Data,
			in KeyData<T, K3> key3Data,
			in KeyData<T, K4> key4Data,
			in KeyData<T, K5> key5Data,
			in KeyData<T, K6> key6Data,
			in KeyData<T, K7> key7Data,
			in KeyData<T, K8> key8Data,
			in KeyData<T, K9> key9Data
			)
			: base(
				  key1Data: key1Data,
				  key2Data: key2Data,
				  key3Data: key3Data,
				  key4Data: key4Data,
				  key5Data: key5Data,
				  key6Data: key6Data,
				  key7Data: key7Data,
				  key8Data: key8Data
				  )
		{
			this.Key9Data = key9Data;
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
									if(0==(cmp=Key7Data.Comparison(Key7Data.GetMember(x), Key7Data.GetMember(y))))
										if(0==(cmp=Key8Data.Comparison(Key8Data.GetMember(x), Key8Data.GetMember(y))))
											cmp=Key9Data.Comparison(Key9Data.GetMember(x), Key9Data.GetMember(y));

			return cmp;
		}

		public int Compare(T item, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			int cmp;

			if(0==(cmp=Key1Data.Comparison(Key1Data.GetMember(item), key1)))
				if(0==(cmp=Key2Data.Comparison(Key2Data.GetMember(item), key2)))
					if(0==(cmp=Key3Data.Comparison(Key3Data.GetMember(item), key3)))
						if(0==(cmp=Key4Data.Comparison(Key4Data.GetMember(item), key4)))
							if(0==(cmp=Key5Data.Comparison(Key5Data.GetMember(item), key5)))
								if(0==(cmp=Key6Data.Comparison(Key6Data.GetMember(item), key6)))
									if(0==(cmp=Key7Data.Comparison(Key7Data.GetMember(item), key7)))
										if(0==(cmp=Key8Data.Comparison(Key8Data.GetMember(item), key8)))
											cmp=Key9Data.Comparison(Key9Data.GetMember(item), key9);

			return cmp;
		}
	}
}