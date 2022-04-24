using System;
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
	/// <typeparam name="K4">Key4 type</typeparam>
	/// <typeparam name="K5">Key5 type</typeparam>
	/// <typeparam name="K6">Key6 type</typeparam>
	/// <typeparam name="K7">Key7 type</typeparam>
	/// <typeparam name="K8">Key8 type</typeparam>
	/// <typeparam name="K9">Key9 type</typeparam>
	/// <typeparam name="K10">Key10 type</typeparam>
	/// <typeparam name="K11">Key11 type</typeparam>
	/// <typeparam name="K12">Key12 type</typeparam>
	/// <typeparam name="K13">Key13 type</typeparam>
	/// <typeparam name="K14">Key14 type</typeparam>
	/// <typeparam name="K15">Key15 type</typeparam>
	/// <typeparam name="K16">Key16 type</typeparam>
	public readonly struct SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> : IReadOnlyList<T>
	{
		#region Common
		/// <summary>
		/// Implicit cast operator
		/// </summary>
		/// <param name="orderedReadOnlyList">Sorted read only list</param>
		public static implicit operator SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(SortedReadOnlyList<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> orderedReadOnlyList) => new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedReadOnlyList, new Range(0, orderedReadOnlyList.Count));

		/// <summary>
		/// Keys data
		/// </summary>
		private KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> KeysData { get; }

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
		public SortedReadOnlyListRange(SortedReadOnlyList<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> orderedList, Range range)
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
		private SortedReadOnlyListRange(KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> keysData, ReadOnlyMemory<T> memory)
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1),
				(item, s) => s.orderedList.Compare(item, s.key1));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1),
				(item, s) => s.orderedList.Compare(item, s.key1));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1),
				(item, s) => s.orderedList.Compare(item, s.key1));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1),
				(item, s) => s.orderedList.Compare(item, s.key1));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1),
				(item, s) => s.orderedList.Compare(item, s.key1));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 2 keys
		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 4 keys
		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 5 keys
		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 6 keys
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 7 keys
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6, key7),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6, key7),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 8 keys
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 9 keys
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 10 keys
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 11 keys
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 12 keys
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 13 keys
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 14 keys
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 15 keys
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14, s.key15));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14, s.key15));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14, s.key15));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14, s.key15));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14, s.key15));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion

		#region 16 keys
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <param name="key16">Key 16 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14, s.key15, s.key16));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <param name="key16">Key 16 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14, s.key15, s.key16));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <param name="key16">Key 16 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14, s.key15, s.key16));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <param name="key16">Key 16 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14, s.key15, s.key16));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <param name="key16">Key 16 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(
				(orderedList, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16),
				(item, s) => s.orderedList.Compare(item, s.key1, s.key2, s.key3, s.key4, s.key5, s.key6, s.key7, s.key8, s.key9, s.key10, s.key11, s.key12, s.key13, s.key14, s.key15, s.key16));

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, newMemory);
		}
		#endregion
	}
}