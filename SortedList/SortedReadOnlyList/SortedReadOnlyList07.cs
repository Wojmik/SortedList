using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WojciechMikołajewicz.SortedList.KeysData;

namespace WojciechMikołajewicz.SortedList
{
	/// <summary>
	/// Sorted read only list with binary search based on items compare (not items equality)
	/// </summary>
	/// <typeparam name="T">Items type</typeparam>
	/// <typeparam name="K1">Key1 type</typeparam>
	/// <typeparam name="K2">Key2 type</typeparam>
	/// <typeparam name="K3">Key3 type</typeparam>
	/// <typeparam name="K4">Key4 type</typeparam>
	/// <typeparam name="K5">Key5 type</typeparam>
	/// <typeparam name="K6">Key6 type</typeparam>
	/// <typeparam name="K7">Key7 type</typeparam>
	public class SortedReadOnlyList<T, K1, K2, K3, K4, K5, K6, K7> : KeysData<T, K1, K2, K3, K4, K5, K6, K7>, IReadOnlyList<T>
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
		/// <param name="keyData2">Key 2 data</param>
		/// <param name="keyData3">Key 3 data</param>
		/// <param name="keyData4">Key 4 data</param>
		/// <param name="keyData5">Key 5 data</param>
		/// <param name="keyData6">Key 6 data</param>
		/// <param name="keyData7">Key 7 data</param>
		public SortedReadOnlyList(IEnumerable<T> collection,
			in KeyData<T, K1> keyData1,
			in KeyData<T, K2> keyData2,
			in KeyData<T, K3> keyData3,
			in KeyData<T, K4> keyData4,
			in KeyData<T, K5> keyData5,
			in KeyData<T, K6> keyData6,
			in KeyData<T, K7> keyData7
			)
			: base(keyData1, keyData2, keyData3, keyData4, keyData5, keyData6, keyData7)
		{
			this._Array=CreateSortedArray(collection: collection, keysData: this);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="collection">Collection base on which array is created</param>
		/// <param name="keysData">Keys data</param>
		public SortedReadOnlyList(IEnumerable<T> collection, KeysData<T, K1, K2, K3, K4, K5, K6, K7> keysData)
			: this(collection,
				  keysData.Key1Data,
				  keysData.Key2Data,
				  keysData.Key3Data,
				  keysData.Key4Data,
				  keysData.Key5Data,
				  keysData.Key6Data,
				  keysData.Key7Data
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

		/// <summary>
		/// Gets a read-only reference to the element at the specified <paramref name="index"/> in the read-only list
		/// </summary>
		/// <param name="index">The zero-based index of the element to get a reference to</param>
		/// <returns>A read-only reference to the element at the specified <paramref name="index"/> in the read-only list</returns>
		public ref readonly T ItemRef(int index)
		{
			return ref this._Array[index];
		}

		#region Equal
		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindEqual(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindEqual(key1);
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindEqual(K1 key1, K2 key2)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindEqual(key1, key2);
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindEqual(K1 key1, K2 key2, K3 key3)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindEqual(key1, key2, key3);
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindEqual(key1, key2, key3, key4);
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindEqual(key1, key2, key3, key4, key5);
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6);
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <param name="key7">Key 7 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7);
		}
		#endregion

		#region LessOrEqual
		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLessOrEqual(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLessOrEqual(key1);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLessOrEqual(K1 key1, K2 key2)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLessOrEqual(key1, key2);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLessOrEqual(key1, key2, key3);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLessOrEqual(key1, key2, key3, key4);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <param name="key7">Key 7 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7);
		}
		#endregion

		#region Less
		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLess(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLess(key1);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLess(K1 key1, K2 key2)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLess(key1, key2);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLess(K1 key1, K2 key2, K3 key3)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLess(key1, key2, key3);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLess(key1, key2, key3, key4);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLess(key1, key2, key3, key4, key5);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <param name="key7">Key 7 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7);
		}
		#endregion

		#region GreaterOrEqual
		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreaterOrEqual(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreaterOrEqual(key1);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreaterOrEqual(K1 key1, K2 key2)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreaterOrEqual(key1, key2);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreaterOrEqual(key1, key2, key3);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <param name="key7">Key 7 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7);
		}
		#endregion

		#region Greater
		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreater(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreater(key1);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreater(K1 key1, K2 key2)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreater(key1, key2);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreater(K1 key1, K2 key2, K3 key3)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreater(key1, key2, key3);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreater(key1, key2, key3, key4);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreater(key1, key2, key3, key4, key5);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <param name="key7">Key 7 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7);
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

		/// <summary>
		/// Get range in which items are equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2);
			}
		}

		/// <summary>
		/// Get range in which items are equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3);
			}
		}

		/// <summary>
		/// Get range in which items are equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4);
			}
		}

		/// <summary>
		/// Get range in which items are equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5);
			}
		}

		/// <summary>
		/// Get range in which items are equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6);
			}
		}

		/// <summary>
		/// Get range in which items are equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <param name="key7">Key 7 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7);
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

		/// <summary>
		/// Get range in which items are less or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2);
			}
		}

		/// <summary>
		/// Get range in which items are less or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3);
			}
		}

		/// <summary>
		/// Get range in which items are less or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4);
			}
		}

		/// <summary>
		/// Get range in which items are less or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5);
			}
		}

		/// <summary>
		/// Get range in which items are less or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6);
			}
		}

		/// <summary>
		/// Get range in which items are less or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <param name="key7">Key 7 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7);
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

		/// <summary>
		/// Get range in which items are less than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2);
			}
		}

		/// <summary>
		/// Get range in which items are less than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3);
			}
		}

		/// <summary>
		/// Get range in which items are less than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4);
			}
		}

		/// <summary>
		/// Get range in which items are less than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5);
			}
		}

		/// <summary>
		/// Get range in which items are less than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6);
			}
		}

		/// <summary>
		/// Get range in which items are less than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <param name="key7">Key 7 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7);
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

		/// <summary>
		/// Get range in which items are greater or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2);
			}
		}

		/// <summary>
		/// Get range in which items are greater or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3);
			}
		}

		/// <summary>
		/// Get range in which items are greater or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4);
			}
		}

		/// <summary>
		/// Get range in which items are greater or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5);
			}
		}

		/// <summary>
		/// Get range in which items are greater or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6);
			}
		}

		/// <summary>
		/// Get range in which items are greater or equal to specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <param name="key7">Key 7 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7);
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

		/// <summary>
		/// Get range in which items are greater than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2);
			}
		}

		/// <summary>
		/// Get range in which items are greater than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3);
			}
		}

		/// <summary>
		/// Get range in which items are greater than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4);
			}
		}

		/// <summary>
		/// Get range in which items are greater than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5);
			}
		}

		/// <summary>
		/// Get range in which items are greater than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6);
			}
		}

		/// <summary>
		/// Get range in which items are greater than specified keys values. Only items in <paramref name="range"/> are considered.
		/// </summary>
		/// <param name="range">Source range, in which we are searching</param>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <param name="key6">Key 6 value</param>
		/// <param name="key7">Key 7 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7);
			}
		}
		#endregion
	}
}