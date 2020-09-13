using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList
{
	/// <summary>
	/// Key data interface
	/// </summary>
	/// <typeparam name="T">Type of item</typeparam>
	public interface IKeyData<T>
	{
		/// <summary>
		/// Compare item's keys
		/// </summary>
		/// <param name="x">Item to compare its key</param>
		/// <param name="y">Item to compare its key</param>
		/// <returns>Compare result: -1 if key of <paramref name="x"/> is less than key of <paramref name="y"/>, 1 if key of <paramref name="x"/> is greater than key of <paramref name="y"/>, 0 if key of <paramref name="x"/> is equal to key of <paramref name="y"/></returns>
		int Compare(T x, T y);

		/// <summary>
		/// Compare item's key to <paramref name="value"/>
		/// </summary>
		/// <param name="x">Item to compare its key with <paramref name="value"/></param>
		/// <param name="value">Key value to compare</param>
		/// <returns>Compare result: -1 if key of <paramref name="x"/> is less than <paramref name="value"/>, 1 if key of <paramref name="x"/> is greater than <paramref name="value"/>, 0 if key of <paramref name="x"/> is equal to <paramref name="value"/></returns>
		int Compare(T x, object value);
	}
}