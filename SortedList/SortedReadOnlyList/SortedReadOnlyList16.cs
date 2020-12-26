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
	/// <typeparam name="K8">Key8 type</typeparam>
	/// <typeparam name="K9">Key9 type</typeparam>
	/// <typeparam name="K10">Key10 type</typeparam>
	/// <typeparam name="K11">Key11 type</typeparam>
	/// <typeparam name="K12">Key12 type</typeparam>
	/// <typeparam name="K13">Key13 type</typeparam>
	/// <typeparam name="K14">Key14 type</typeparam>
	/// <typeparam name="K15">Key15 type</typeparam>
	/// <typeparam name="K16">Key16 type</typeparam>
	public class SortedReadOnlyList<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> : KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>, IReadOnlyList<T>
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
		/// <param name="keyData8">Key 8 data</param>
		/// <param name="keyData9">Key 9 data</param>
		/// <param name="keyData10">Key 10 data</param>
		/// <param name="keyData11">Key 11 data</param>
		/// <param name="keyData12">Key 12 data</param>
		/// <param name="keyData13">Key 13 data</param>
		/// <param name="keyData14">Key 14 data</param>
		/// <param name="keyData15">Key 15 data</param>
		/// <param name="keyData16">Key 16 data</param>
		public SortedReadOnlyList(IEnumerable<T> collection,
			in KeyData<T, K1> keyData1,
			in KeyData<T, K2> keyData2,
			in KeyData<T, K3> keyData3,
			in KeyData<T, K4> keyData4,
			in KeyData<T, K5> keyData5,
			in KeyData<T, K6> keyData6,
			in KeyData<T, K7> keyData7,
			in KeyData<T, K8> keyData8,
			in KeyData<T, K9> keyData9,
			in KeyData<T, K10> keyData10,
			in KeyData<T, K11> keyData11,
			in KeyData<T, K12> keyData12,
			in KeyData<T, K13> keyData13,
			in KeyData<T, K14> keyData14,
			in KeyData<T, K15> keyData15,
			in KeyData<T, K16> keyData16
			)
			: base(keyData1, keyData2, keyData3, keyData4, keyData5, keyData6, keyData7, keyData8, keyData9, keyData10, keyData11, keyData12, keyData13, keyData14, keyData15, keyData16)
		{
			this._Array=CreateSortedArray(collection: collection, keysData: this);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="collection">Collection base on which array is created</param>
		/// <param name="keysData">Keys data</param>
		public SortedReadOnlyList(IEnumerable<T> collection, KeysData<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> keysData)
			: this(collection,
				  keysData.Key1Data,
				  keysData.Key2Data,
				  keysData.Key3Data,
				  keysData.Key4Data,
				  keysData.Key5Data,
				  keysData.Key6Data,
				  keysData.Key7Data,
				  keysData.Key8Data,
				  keysData.Key9Data,
				  keysData.Key10Data,
				  keysData.Key11Data,
				  keysData.Key12Data,
				  keysData.Key13Data,
				  keysData.Key14Data,
				  keysData.Key15Data,
				  keysData.Key16Data
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1);
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2);
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3);
		}

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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6);
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
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7);
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7, key8);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
		}
		#endregion

		#region LessOrEqual
		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1);
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7, key8);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLessOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
		}
		#endregion

		#region Less
		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1);
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7, key8);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7, key8, key9);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindLess(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
		}
		#endregion

		#region GreaterOrEqual
		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1);
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7, key8);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreaterOrEqual(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
		}
		#endregion

		#region Greater
		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1);
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2)
		{
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7, key8);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7, key8, key9);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
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
			return ((SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>)this).BinaryFindGreater(key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <param name="key16">Key 16 value</param>
		/// <returns>Range in which items are equal to specified keys values</returns>
		public Range BinaryFindEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			return this._Array.BinaryFindEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <param name="key16">Key 16 value</param>
		/// <returns>Range in which items are less or equal to specified keys values</returns>
		public Range BinaryFindLessOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			return this._Array.BinaryFindLessOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <param name="key16">Key 16 value</param>
		/// <returns>Range in which items are less than specified keys values</returns>
		public Range BinaryFindLessRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			return this._Array.BinaryFindLess(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <param name="key16">Key 16 value</param>
		/// <returns>Range in which items are greater or equal to specified keys values</returns>
		public Range BinaryFindGreaterOrEqualRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			return this._Array.BinaryFindGreaterOrEqual(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
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
		/// <param name="key8">Key 8 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
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
		/// <param name="key8">Key 8 value</param>
		/// <param name="key9">Key 9 value</param>
		/// <param name="key10">Key 10 value</param>
		/// <param name="key11">Key 11 value</param>
		/// <param name="key12">Key 12 value</param>
		/// <param name="key13">Key 13 value</param>
		/// <param name="key14">Key 14 value</param>
		/// <param name="key15">Key 15 value</param>
		/// <param name="key16">Key 16 value</param>
		/// <returns>Range in which items are greater than specified keys values</returns>
		public Range BinaryFindGreaterRange(Range range, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			return this._Array.BinaryFindGreater(range, Comparison);

			int Comparison(T item)
			{
				return this.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
			}
		}
		#endregion

		//#region EqualRangeTuple
		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14, keys.key15);
		//}

		//public Range BinaryFindEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16) keys)
		//{
		//	return BinaryFindEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14, keys.key15, keys.key16);
		//}
		//#endregion

		//#region LessOrEqualRangeTuple
		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14, keys.key15);
		//}

		//public Range BinaryFindLessOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16) keys)
		//{
		//	return BinaryFindLessOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14, keys.key15, keys.key16);
		//}
		//#endregion

		//#region LessRangeTuple
		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14, keys.key15);
		//}

		//public Range BinaryFindLessRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16) keys)
		//{
		//	return BinaryFindLessRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14, keys.key15, keys.key16);
		//}
		//#endregion

		//#region GreaterOrEqualRangeTuple
		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14, keys.key15);
		//}

		//public Range BinaryFindGreaterOrEqualRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16) keys)
		//{
		//	return BinaryFindGreaterOrEqualRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14, keys.key15, keys.key16);
		//}
		//#endregion

		//#region GreaterRangeTuple
		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14, keys.key15);
		//}

		//public Range BinaryFindGreaterRange(Range range, in (K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16) keys)
		//{
		//	return BinaryFindGreaterRange(range, keys.key1, keys.key2, keys.key3, keys.key4, keys.key5, keys.key6, keys.key7, keys.key8, keys.key9, keys.key10, keys.key11, keys.key12, keys.key13, keys.key14, keys.key15, keys.key16);
		//}
		//#endregion
	}
}