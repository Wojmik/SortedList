using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.KeysData;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal.Comparer
{
	readonly struct ItemComparer<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>
	{
		private readonly KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> KeysData;

		private readonly K1 Key1;
		private readonly K2 Key2;
		private readonly K3 Key3;
		private readonly K4 Key4;
		private readonly K5 Key5;
		private readonly K6 Key6;
		private readonly K7 Key7;
		private readonly K8 Key8;
		private readonly K9 Key9;
		private readonly K10 Key10;
		private readonly K11 Key11;
		private readonly K12 Key12;
		private readonly K13 Key13;
		private readonly K14 Key14;
		private readonly K15 Key15;
		private readonly K16 Key16;

		public ItemComparer(
			KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> keysData,
			K1 key1,
			K2 key2,
			K3 key3,
			K4 key4,
			K5 key5,
			K6 key6,
			K7 key7,
			K8 key8,
			K9 key9,
			K10 key10,
			K11 key11,
			K12 key12,
			K13 key13,
			K14 key14,
			K15 key15,
			K16 key16
			)
		{
			this.KeysData = keysData;

			this.Key1 = key1;
			this.Key2 = key2;
			this.Key3 = key3;
			this.Key4 = key4;
			this.Key5 = key5;
			this.Key6 = key6;
			this.Key7 = key7;
			this.Key8 = key8;
			this.Key9 = key9;
			this.Key10 = key10;
			this.Key11 = key11;
			this.Key12 = key12;
			this.Key13 = key13;
			this.Key14 = key14;
			this.Key15 = key15;
			this.Key16 = key16;
		}

		public int Compare(T item)
		{
			int cmp;

			if(0==(cmp=KeysData.Key1Data.Comparison(Key1, KeysData.Key1Data.GetMember(item))))
				if(0==(cmp=KeysData.Key2Data.Comparison(Key2, KeysData.Key2Data.GetMember(item))))
					if(0==(cmp=KeysData.Key3Data.Comparison(Key3, KeysData.Key3Data.GetMember(item))))
						if(0==(cmp=KeysData.Key4Data.Comparison(Key4, KeysData.Key4Data.GetMember(item))))
							if(0==(cmp=KeysData.Key5Data.Comparison(Key5, KeysData.Key5Data.GetMember(item))))
								if(0==(cmp=KeysData.Key6Data.Comparison(Key6, KeysData.Key6Data.GetMember(item))))
									if(0==(cmp=KeysData.Key7Data.Comparison(Key7, KeysData.Key7Data.GetMember(item))))
										if(0==(cmp=KeysData.Key8Data.Comparison(Key8, KeysData.Key8Data.GetMember(item))))
											if(0==(cmp=KeysData.Key9Data.Comparison(Key9, KeysData.Key9Data.GetMember(item))))
												if(0==(cmp=KeysData.Key10Data.Comparison(Key10, KeysData.Key10Data.GetMember(item))))
													if(0==(cmp=KeysData.Key11Data.Comparison(Key11, KeysData.Key11Data.GetMember(item))))
														if(0==(cmp=KeysData.Key12Data.Comparison(Key12, KeysData.Key12Data.GetMember(item))))
															if(0==(cmp=KeysData.Key13Data.Comparison(Key13, KeysData.Key13Data.GetMember(item))))
																if(0==(cmp=KeysData.Key14Data.Comparison(Key14, KeysData.Key14Data.GetMember(item))))
																	if(0==(cmp=KeysData.Key15Data.Comparison(Key15, KeysData.Key15Data.GetMember(item))))
																		cmp=KeysData.Key16Data.Comparison(Key16, KeysData.Key16Data.GetMember(item));

			return cmp;
		}
	}
}