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
	public class KeysData<T, K1, K2, K3, K4, K5, K6, K7> : KeysData<T, K1, K2, K3, K4, K5, K6>
	{
		/// <summary>
		/// Key7 data
		/// </summary>
		public KeyData<T, K7> Key7Data { get; }

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
		public KeysData(
			in KeyData<T, K1> key1Data,
			in KeyData<T, K2> key2Data,
			in KeyData<T, K3> key3Data,
			in KeyData<T, K4> key4Data,
			in KeyData<T, K5> key5Data,
			in KeyData<T, K6> key6Data,
			in KeyData<T, K7> key7Data
			)
			: base(
				  key1Data: key1Data,
				  key2Data: key2Data,
				  key3Data: key3Data,
				  key4Data: key4Data,
				  key5Data: key5Data,
				  key6Data: key6Data
				  )
		{
			this.Key7Data = key7Data;
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
									cmp=Key7Data.Comparison(Key7Data.GetMember(x), Key7Data.GetMember(y));

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
		/// <returns>Compare result: -1 if <paramref name="item"/> is less than keys, 1 if <paramref name="item"/> is greater than keys, 0 if <paramref name="item"/> is equal to keys</returns>
		public int Compare(T item, K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			int cmp;

			if(0==(cmp=Key1Data.Comparison(Key1Data.GetMember(item), key1)))
				if(0==(cmp=Key2Data.Comparison(Key2Data.GetMember(item), key2)))
					if(0==(cmp=Key3Data.Comparison(Key3Data.GetMember(item), key3)))
						if(0==(cmp=Key4Data.Comparison(Key4Data.GetMember(item), key4)))
							if(0==(cmp=Key5Data.Comparison(Key5Data.GetMember(item), key5)))
								if(0==(cmp=Key6Data.Comparison(Key6Data.GetMember(item), key6)))
									cmp=Key7Data.Comparison(Key7Data.GetMember(item), key7);

			return cmp;
		}
	}
}