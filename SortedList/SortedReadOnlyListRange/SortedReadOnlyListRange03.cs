﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.SortedList.KeysData;

namespace WojciechMikołajewicz.SortedList
{
	/// <summary>
	/// Part of sorted read only list with binary search based on items compare (not items equality)
	/// </summary>
	/// <typeparam name="T">Items type</typeparam>
	/// <typeparam name="K1">Key1 type</typeparam>
	/// <typeparam name="K2">Key2 type</typeparam>
	/// <typeparam name="K3">Key3 type</typeparam>
	public readonly struct SortedReadOnlyListRange<T, K1, K2, K3> : IReadOnlyList<T>
	{
		#region Common
		/// <summary>
		/// Implicit cast operator
		/// </summary>
		/// <param name="orderedReadOnlyList">Sorted read only list</param>
		public static implicit operator SortedReadOnlyListRange<T, K1, K2, K3>(SortedReadOnlyList<T, K1, K2, K3> orderedReadOnlyList) => new SortedReadOnlyListRange<T, K1, K2, K3>(orderedReadOnlyList, new Range(0, orderedReadOnlyList.Count));

		/// <summary>
		/// Keys data
		/// </summary>
		private KeysData<T, K1, K2, K3> KeysData { get; }

		/// <summary>
		/// Memory of the part of source sorted read only list
		/// </summary>
		public ReadOnlyMemory<T> Memory { get; }

		/// <summary>
		/// Number of items
		/// </summary>
		public int Count { get => this.Memory.Length; }

		/// <summary>
		/// Is empty
		/// </summary>
		public bool IsEmpty { get => this.Memory.IsEmpty; }

		/// <summary>
		/// Returns an item of <paramref name="index"/>
		/// </summary>
		/// <param name="index">Index of the item to return</param>
		/// <returns>Item of specified <paramref name="index"/></returns>
		public T this[int index] { get => this.Memory.Span[index]; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="orderedList">Source sorted read only list</param>
		/// <param name="range">Range in the <paramref name="orderedList"/></param>
		public SortedReadOnlyListRange(SortedReadOnlyList<T, K1, K2, K3> orderedList, Range range)
		{
			(int start, int count) = range.GetOffsetAndLength(orderedList.Count);
			this.KeysData=orderedList.KeysData;
			this.Memory=orderedList.AsMemory().Slice(start, count);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="keysData">Keys data</param>
		/// <param name="memory">Read only memory of sorted read only list</param>
		private SortedReadOnlyListRange(KeysData<T, K1, K2, K3> keysData, ReadOnlyMemory<T> memory)
		{
			this.KeysData=keysData;
			this.Memory=memory;
		}

		/// <summary>
		/// Get enumerator
		/// </summary>
		/// <returns>Enumerator</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return new Internal.OrderedReadOnlyListRangeEnumerator<T>(this.Memory);
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
			return ref this.Memory.Span[index];
		}
		#endregion

		#region 1 key
		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindEqual(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1),
				(item, s) => s.orderedList.Compare(item, s.key1));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindLessOrEqual(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1),
				(item, s) => s.orderedList.Compare(item, s.key1));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindLess(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1),
				(item, s) => s.orderedList.Compare(item, s.key1));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindGreaterOrEqual(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1),
				(item, s) => s.orderedList.Compare(item, s.key1));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindGreater(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1),
				(item, s) => s.orderedList.Compare(item, s.key1));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}
		#endregion

		#region 2 keys
		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindEqual(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindLessOrEqual(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindLess(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindGreaterOrEqual(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindGreater(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}
		#endregion

		#region 3 keys
		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindLess(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3> BinaryFindGreater(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3));

			return new SortedReadOnlyListRange<T, K1, K2, K3>(orderedList, newMemory);
		}
		#endregion
	}
}