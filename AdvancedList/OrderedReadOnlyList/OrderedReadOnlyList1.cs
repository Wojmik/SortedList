using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace WojciechMikołajewicz.AdvancedList
{
	public class OrderedReadOnlyList<T, K1> : OrderedReadOnlyList<T>
	{
		private protected readonly Internal.KeyData<T, K1> _K1;

		public OrderedReadOnlyList(IEnumerable<T> collection
			, KeyData<T, K1> keyData1
			)
			: base(collection, new KeyData<T>[] { keyData1 })
		{
			this._K1=keyData1;
		}

		public OrderedReadOnlyList(IEnumerable<T> collection, IEnumerable<KeyData<T>> keyData)
			: base(collection, keyData)
		{
			const int keys = 1;
			int i = 0;

			try
			{
				foreach(var kd in keyData)
				{
					this._K1=(KeyData<T, K1>)kd;
					i++;
				}
			}
			catch(InvalidCastException)
			{
				throw new InvalidCastException($"{nameof(keyData)}[{i}] cannot be cast to KeyData<T, K{i+1}>");
			}
			catch(IndexOutOfRangeException)
			{
				throw new ArgumentException($"{nameof(keyData)} argument should be {keys} length", nameof(keyData));
			}

			if(i!=keys)
				throw new ArgumentException($"{nameof(keyData)} argument should be {keys} length", nameof(keyData));
		}
	}
}