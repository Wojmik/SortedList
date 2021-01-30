using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.SortedList.Internal;

namespace WojciechMikołajewicz.SortedList.KeysData
{
	/// <summary>
	/// Keys data
	/// </summary>
	/// <typeparam name="T">Type of items</typeparam>
	public abstract class KeysData<T> : IComparer<T>
	{
		/// <summary>
		/// Compare items
		/// </summary>
		/// <param name="x">Item to compare</param>
		/// <param name="y">Item to compare</param>
		/// <returns>Compare result: -1 if <paramref name="x"/> is less than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/>, 0 if <paramref name="x"/> is equal to <paramref name="y"/></returns>
		public abstract int Compare(T x, T y);
	}
}