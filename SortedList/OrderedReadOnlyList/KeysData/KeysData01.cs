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
	public class KeysData<T, K1> : KeysData<T>
	{
		/// <summary>
		/// Key1 data
		/// </summary>
		public KeyData<T, K1> Key1Data { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="key1Data">Key1 data</param>
		public KeysData(
			in KeyData<T, K1> key1Data
			)
		{
			this.Key1Data = key1Data;
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

			cmp=Key1Data.Comparison(Key1Data.GetMember(x), Key1Data.GetMember(y));

			return cmp;
		}

		/// <summary>
		/// Compare item with keys values
		/// </summary>
		/// <param name="item">Item to compare</param>
		/// <param name="key1">Key1 to compare</param>
		/// <returns>Compare result: -1 if <paramref name="item"/> is less than keys, 1 if <paramref name="item"/> is greater than keys, 0 if <paramref name="item"/> is equal to keys</returns>
		public int Compare(T item, K1 key1)
		{
			int cmp;

			cmp=Key1Data.Comparison(Key1Data.GetMember(item), key1);

			return cmp;
		}
	}
}