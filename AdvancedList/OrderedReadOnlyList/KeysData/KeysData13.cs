using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.KeysData
{
	public class KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13> : KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12>
	{
		public KeyData<T, K13> Key13Data { get; }

		public KeysData(
			in KeyData<T, K1> key1Data,
			in KeyData<T, K2> key2Data,
			in KeyData<T, K3> key3Data,
			in KeyData<T, K4> key4Data,
			in KeyData<T, K5> key5Data,
			in KeyData<T, K6> key6Data,
			in KeyData<T, K7> key7Data,
			in KeyData<T, K8> key8Data,
			in KeyData<T, K9> key9Data,
			in KeyData<T, K10> key10Data,
			in KeyData<T, K11> key11Data,
			in KeyData<T, K12> key12Data,
			in KeyData<T, K13> key13Data
			)
			: base(
				  key1Data: key1Data,
				  key2Data: key2Data,
				  key3Data: key3Data,
				  key4Data: key4Data,
				  key5Data: key5Data,
				  key6Data: key6Data,
				  key7Data: key7Data,
				  key8Data: key8Data,
				  key9Data: key9Data,
				  key10Data: key10Data,
				  key11Data: key11Data,
				  key12Data: key12Data
				  )
		{
			this.Key13Data = key13Data;
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
											if(0==(cmp=Key9Data.Comparison(Key9Data.GetMember(x), Key9Data.GetMember(y))))
												if(0==(cmp=Key10Data.Comparison(Key10Data.GetMember(x), Key10Data.GetMember(y))))
													if(0==(cmp=Key11Data.Comparison(Key11Data.GetMember(x), Key11Data.GetMember(y))))
														if(0==(cmp=Key12Data.Comparison(Key12Data.GetMember(x), Key12Data.GetMember(y))))
															cmp=Key13Data.Comparison(Key13Data.GetMember(x), Key13Data.GetMember(y));

			return cmp;
		}

		public int Compare(T item, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
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
											if(0==(cmp=Key9Data.Comparison(Key9Data.GetMember(item), key9)))
												if(0==(cmp=Key10Data.Comparison(Key10Data.GetMember(item), key10)))
													if(0==(cmp=Key11Data.Comparison(Key11Data.GetMember(item), key11)))
														if(0==(cmp=Key12Data.Comparison(Key12Data.GetMember(item), key12)))
															cmp=Key13Data.Comparison(Key13Data.GetMember(item), key13);

			return cmp;
		}
	}
}