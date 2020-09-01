using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal.Comparer
{
	readonly struct ItemComparer<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15>
	{
		private readonly Func<T, K1> Key1Getter;
		private readonly Func<T, K2> Key2Getter;
		private readonly Func<T, K3> Key3Getter;
		private readonly Func<T, K4> Key4Getter;
		private readonly Func<T, K5> Key5Getter;
		private readonly Func<T, K6> Key6Getter;
		private readonly Func<T, K7> Key7Getter;
		private readonly Func<T, K8> Key8Getter;
		private readonly Func<T, K9> Key9Getter;
		private readonly Func<T, K10> Key10Getter;
		private readonly Func<T, K11> Key11Getter;
		private readonly Func<T, K12> Key12Getter;
		private readonly Func<T, K13> Key13Getter;
		private readonly Func<T, K14> Key14Getter;
		private readonly Func<T, K15> Key15Getter;

		private readonly Comparison<K1> Key1Comparison;
		private readonly Comparison<K2> Key2Comparison;
		private readonly Comparison<K3> Key3Comparison;
		private readonly Comparison<K4> Key4Comparison;
		private readonly Comparison<K5> Key5Comparison;
		private readonly Comparison<K6> Key6Comparison;
		private readonly Comparison<K7> Key7Comparison;
		private readonly Comparison<K8> Key8Comparison;
		private readonly Comparison<K9> Key9Comparison;
		private readonly Comparison<K10> Key10Comparison;
		private readonly Comparison<K11> Key11Comparison;
		private readonly Comparison<K12> Key12Comparison;
		private readonly Comparison<K13> Key13Comparison;
		private readonly Comparison<K14> Key14Comparison;
		private readonly Comparison<K15> Key15Comparison;

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

		public ItemComparer(
			Comparison<K1> key1Comparison, Func<T, K1> key1Getter, K1 key1,
			Comparison<K2> key2Comparison, Func<T, K2> key2Getter, K2 key2,
			Comparison<K3> key3Comparison, Func<T, K3> key3Getter, K3 key3,
			Comparison<K4> key4Comparison, Func<T, K4> key4Getter, K4 key4,
			Comparison<K5> key5Comparison, Func<T, K5> key5Getter, K5 key5,
			Comparison<K6> key6Comparison, Func<T, K6> key6Getter, K6 key6,
			Comparison<K7> key7Comparison, Func<T, K7> key7Getter, K7 key7,
			Comparison<K8> key8Comparison, Func<T, K8> key8Getter, K8 key8,
			Comparison<K9> key9Comparison, Func<T, K9> key9Getter, K9 key9,
			Comparison<K10> key10Comparison, Func<T, K10> key10Getter,K10 key10,
			Comparison<K11> key11Comparison, Func<T, K11> key11Getter,K11 key11,
			Comparison<K12> key12Comparison, Func<T, K12> key12Getter,K12 key12,
			Comparison<K13> key13Comparison, Func<T, K13> key13Getter,K13 key13,
			Comparison<K14> key14Comparison, Func<T, K14> key14Getter,K14 key14,
			Comparison<K15> key15Comparison, Func<T, K15> key15Getter,K15 key15
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
			this.Key5Comparison = key5Comparison;
			this.Key5Getter = key5Getter;
			this.Key5 = key5;
			this.Key6Comparison = key6Comparison;
			this.Key6Getter = key6Getter;
			this.Key6 = key6;
			this.Key7Comparison = key7Comparison;
			this.Key7Getter = key7Getter;
			this.Key7 = key7;
			this.Key8Comparison = key8Comparison;
			this.Key8Getter = key8Getter;
			this.Key8 = key8;
			this.Key9Comparison = key9Comparison;
			this.Key9Getter = key9Getter;
			this.Key9 = key9;
			this.Key10Comparison = key10Comparison;
			this.Key10Getter = key10Getter;
			this.Key10 = key10;
			this.Key11Comparison = key11Comparison;
			this.Key11Getter = key11Getter;
			this.Key11 = key11;
			this.Key12Comparison = key12Comparison;
			this.Key12Getter = key12Getter;
			this.Key12 = key12;
			this.Key13Comparison = key13Comparison;
			this.Key13Getter = key13Getter;
			this.Key13 = key13;
			this.Key14Comparison = key14Comparison;
			this.Key14Getter = key14Getter;
			this.Key14 = key14;
			this.Key15Comparison = key15Comparison;
			this.Key15Getter = key15Getter;
			this.Key15 = key15;
		}

		public int Compare(T item)
		{
			int cmp;

			if(0==(cmp=Key1Comparison(Key1, Key1Getter(item))))
				if(0==(cmp=Key2Comparison(Key2, Key2Getter(item))))
					if(0==(cmp=Key3Comparison(Key3, Key3Getter(item))))
						if(0==(cmp=Key4Comparison(Key4, Key4Getter(item))))
							if(0==(cmp=Key5Comparison(Key5, Key5Getter(item))))
								if(0==(cmp=Key6Comparison(Key6, Key6Getter(item))))
									if(0==(cmp=Key7Comparison(Key7, Key7Getter(item))))
										if(0==(cmp=Key8Comparison(Key8, Key8Getter(item))))
											if(0==(cmp=Key9Comparison(Key9, Key9Getter(item))))
												if(0==(cmp=Key10Comparison(Key10, Key10Getter(item))))
													if(0==(cmp=Key11Comparison(Key11, Key11Getter(item))))
														if(0==(cmp=Key12Comparison(Key12, Key12Getter(item))))
															if(0==(cmp=Key13Comparison(Key13, Key13Getter(item))))
																if(0==(cmp=Key14Comparison(Key14, Key14Getter(item))))
																	cmp=Key15Comparison(Key15, Key15Getter(item));

			return cmp;
		}
	}
}