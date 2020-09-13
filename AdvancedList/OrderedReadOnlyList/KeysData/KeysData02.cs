using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.KeysData
{
	/// <summary>
	/// Keys data
	/// </summary>
	/// <typeparam name="T">Type of items</typeparam>
	/// <typeparam name="K1">Key1 type</typeparam>
	/// <typeparam name="K2">Key2 type</typeparam>
	public class KeysData<T, K1, K2> : KeysData<T, K1>
	{
		/// <summary>
		/// Key2 data
		/// </summary>
		public KeyData<T, K2> Key2Data { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="key1Data">Key1 data</param>
		/// <param name="key2Data">Key2 data</param>
		public KeysData(
			in KeyData<T, K1> key1Data,
			in KeyData<T, K2> key2Data
			)
			: base(key1Data: key1Data)
		{
			this.Key2Data = key2Data;
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
				cmp=Key2Data.Comparison(Key2Data.GetMember(x), Key2Data.GetMember(y));

			return cmp;
		}

		/// <summary>
		/// Compare item with keys values
		/// </summary>
		/// <param name="item">Item to compare</param>
		/// <param name="key1">Key1 to compare</param>
		/// <param name="key2">Key2 to compare</param>
		/// <returns>Compare result: -1 if <paramref name="item"/> is less than keys, 1 if <paramref name="item"/> is greater than keys, 0 if <paramref name="item"/> is equal to keys</returns>
		public int Compare(T item, K1 key1, K2 key2)
		{
			int cmp;

			if(0==(cmp=Key1Data.Comparison(Key1Data.GetMember(item), key1)))
				cmp=Key2Data.Comparison(Key2Data.GetMember(item), key2);

			return cmp;
		}
	}
}