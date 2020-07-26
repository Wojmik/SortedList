using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace WojciechMikołajewicz.AdvancedList
{
	public class OrderedReadOnlyList<T, K1, K2, K3> : OrderedReadOnlyList<T, K1, K2>
	{
		private const int KeyIndex = 3;

		public Func<T, K3> Key3Getter { get; }

		public Comparison<K3> Key3Comparison { get; }

		protected override int KeysCount { get => KeyIndex; }

		public OrderedReadOnlyList(IEnumerable<T> collection
			, KeyData<T, K1> keyData1
			, KeyData<T, K2> keyData2
			, KeyData<T, K3> keyData3
			)
			: this(collection, new KeyData<T>[] { keyData1, keyData2, keyData3, })
		{ }

		public OrderedReadOnlyList(IEnumerable<T> collection, IEnumerable<KeyData<T>> keyData)
			: base(collection, keyData)
		{
			try
			{
				this.Key3Getter=((KeyData<T, K3>)this.KeysData[KeyIndex-1]).GetMember;
				this.Key3Comparison=((KeyData<T, K3>)this.KeysData[KeyIndex-1]).Comparison;
			}
			catch(InvalidCastException)
			{
				throw new InvalidCastException($"{nameof(keyData)}[{KeyIndex-1}] cannot be cast to KeyData<T, K{KeyIndex}>");
			}
		}
	}
}