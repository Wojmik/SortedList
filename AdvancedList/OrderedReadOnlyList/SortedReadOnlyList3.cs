using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.KeysData;

namespace WojciechMikołajewicz.AdvancedList
{
	public class SortedReadOnlyList<T, K1, K2, K3> : KeysData<T, K1, K2, K3>, IReadOnlyList<T>
	{
		internal readonly T[] _Array;

		public T this[int index] { get => this._Array[index]; }

		public int Count { get => this._Array.Length; }

		public SortedReadOnlyList(IEnumerable<T> collection,
			in KeyData<T, K1> keyData1,
			in KeyData<T, K2> keyData2,
			in KeyData<T, K3> keyData3
			)
			: base(keyData1, keyData2, keyData3)
		{
			this._Array=CreateSortedArray(collection: collection, keysData: this);
		}

		public SortedReadOnlyList(IEnumerable<T> collection, KeysData<T, K1, K2, K3> keysData)
			: this(collection,
				  keysData.Key1Data,
				  keysData.Key2Data,
				  keysData.Key3Data
				  )
		{ }

		public ReadOnlyMemory<T> AsMemory()
		{
			return new ReadOnlyMemory<T>(this._Array);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this._Array).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}