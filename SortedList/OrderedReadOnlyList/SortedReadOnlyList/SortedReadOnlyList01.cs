using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WojciechMikołajewicz.SortedList.OrderedReadOnlyList;
using WojciechMikołajewicz.SortedList.OrderedReadOnlyList.KeysData;

namespace WojciechMikołajewicz.SortedList
{
	/// <summary>
	/// Sorted read only list with binary search based on items compare (not items equality)
	/// </summary>
	/// <typeparam name="T">Items type</typeparam>
	/// <typeparam name="K1">Key1 type</typeparam>
	public class SortedReadOnlyList<T, K1> : KeysData<T, K1>, IReadOnlyList<T>
	{
		/// <summary>
		/// Internal sorted array
		/// </summary>
		private readonly T[] _Array;

		/// <summary>
		/// Returns an item of <paramref name="index"/>
		/// </summary>
		/// <param name="index">Index of the item to return</param>
		/// <returns>Item of specified <paramref name="index"/></returns>
		public T this[int index] { get => this._Array[index]; }

		/// <summary>
		/// Number of items
		/// </summary>
		public int Count { get => this._Array.Length; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="collection">Collection base on which array is created</param>
		/// <param name="keyData1">Key 1 data</param>
		public SortedReadOnlyList(IEnumerable<T> collection,
			in KeyData<T, K1> keyData1
			)
			: base(keyData1)
		{
			this._Array=CreateSortedArray(collection: collection, keysData: this);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="collection">Collection base on which array is created</param>
		/// <param name="keysData">Keys data</param>
		public SortedReadOnlyList(IEnumerable<T> collection, KeysData<T, K1> keysData)
			: this(collection,
				  keysData.Key1Data
				  )
		{ }

		/// <summary>
		/// Get ReadOnlyMemory from internal array
		/// </summary>
		/// <returns>ReadOnlyMemory from internal array</returns>
		public ReadOnlyMemory<T> AsMemory()
		{
			return new ReadOnlyMemory<T>(this._Array);
		}

		/// <summary>
		/// Get enumerator
		/// </summary>
		/// <returns>Enumerator</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this._Array).GetEnumerator();
		}

		/// <summary>
		/// Get enumerator
		/// </summary>
		/// <returns>Enumerator</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#region Equal
		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1> BinaryFindEqual(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1>)this).BinaryFindEqual(key1);
		}
		#endregion

		#region LessOrEqual
		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1> BinaryFindLessOrEqual(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1>)this).BinaryFindLessOrEqual(key1);
		}
		#endregion

		#region Less
		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1> BinaryFindLess(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1>)this).BinaryFindLess(key1);
		}
		#endregion

		#region GreaterOrEqual
		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1> BinaryFindGreaterOrEqual(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1>)this).BinaryFindGreaterOrEqual(key1);
		}
		#endregion

		#region Greater
		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1> BinaryFindGreater(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1>)this).BinaryFindGreater(key1);
		}
		#endregion

		#region EqualRange
		/// <summary>
		/// Get range in which items are equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1);
			}
		}
		#endregion

		#region LessOrEqualRange
		/// <summary>
		/// Get range in which items are less or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1);
			}
		}
		#endregion

		#region LessRange
		/// <summary>
		/// Get range in which items are less than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1);
			}
		}
		#endregion

		#region GreaterOrEqualRange
		/// <summary>
		/// Get range in which items are greater or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1);
			}
		}
		#endregion

		#region GreaterRange
		/// <summary>
		/// Get range in which items are greater than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1);
			}
		}
		#endregion
	}
}