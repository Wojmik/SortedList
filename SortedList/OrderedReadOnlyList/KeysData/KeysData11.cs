using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.SortedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.SortedList.OrderedReadOnlyList.KeysData
{
	/// <summary>
	/// Keys data
	/// </summary>
	/// <typeparam name="T">Type of items</typeparam>
	/// <typeparam name="K1">Key1 type</typeparam>
	/// <typeparam name="K2">Key2 type</typeparam>
	/// <typeparam name="K3">Key3 type</typeparam>
	/// <typeparam name="K4">Key4 type</typeparam>
	/// <typeparam name="K5">Key5 type</typeparam>
	/// <typeparam name="K6">Key6 type</typeparam>
	/// <typeparam name="K7">Key7 type</typeparam>
	/// <typeparam name="K8">Key8 type</typeparam>
	/// <typeparam name="K9">Key9 type</typeparam>
	/// <typeparam name="K10">Key10 type</typeparam>
	/// <typeparam name="K11">Key11 type</typeparam>
	public class KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11> : KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10>
	{
		/// <summary>
		/// Key11 data
		/// </summary>
		public KeyData<T, K11> Key11Data { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="key1Data">Key1 data</param>
		/// <param name="key2Data">Key2 data</param>
		/// <param name="key3Data">Key3 data</param>
		/// <param name="key4Data">Key4 data</param>
		/// <param name="key5Data">Key5 data</param>
		/// <param name="key6Data">Key6 data</param>
		/// <param name="key7Data">Key7 data</param>
		/// <param name="key8Data">Key8 data</param>
		/// <param name="key9Data">Key9 data</param>
		/// <param name="key10Data">Key10 data</param>
		/// <param name="key11Data">Key11 data</param>
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
			in KeyData<T, K11> key11Data
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
				  key10Data: key10Data
				  )
		{
			this.Key11Data = key11Data;
		}

		/// <summary>
		/// Compare items
		/// </summary>
		/// <param name="x">Item to compare</param>
		/// <param name="y">Item to compare</param>
		/// <returns>Compare result: -1 if <paramref name="x"/> is less than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/>, 0 if <paramref name="x"/> is equal to <paramref name="y"/></returns>
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
													cmp=Key11Data.Comparison(Key11Data.GetMember(x), Key11Data.GetMember(y));

			return cmp;
		}

		/// <summary>
		/// Compare item with keys values
		/// </summary>
		/// <param name="item">Item to compare</param>
		/// <param name="key1">Key1 to compare</param>
		/// <param name="key2">Key2 to compare</param>
		/// <param name="key3">Key3 to compare</param>
		/// <param name="key4">Key4 to compare</param>
		/// <param name="key5">Key5 to compare</param>
		/// <param name="key6">Key6 to compare</param>
		/// <param name="key7">Key7 to compare</param>
		/// <param name="key8">Key8 to compare</param>
		/// <param name="key9">Key9 to compare</param>
		/// <param name="key10">Key10 to compare</param>
		/// <param name="key11">Key11 to compare</param>
		/// <returns>Compare result: -1 if <paramref name="item"/> is less than keys, 1 if <paramref name="item"/> is greater than keys, 0 if <paramref name="item"/> is equal to keys</returns>
		public int Compare(T item, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
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
													cmp=Key11Data.Comparison(Key11Data.GetMember(item), key11);

			return cmp;
		}
	}
}