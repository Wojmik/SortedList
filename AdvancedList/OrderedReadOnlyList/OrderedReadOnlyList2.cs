using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace WojciechMikołajewicz.AdvancedList
{
	public class OrderedReadOnlyList<T, K1, K2> : OrderedReadOnlyList<T, K1>
	{
		private const int KeyIndex = 2;

		public Func<T, K2> Key2Getter { get; }

		public Comparison<K2> Key2Comparison { get; }

		protected override int KeysCount { get => KeyIndex; }

		public OrderedReadOnlyList(IEnumerable<T> collection
			, KeyData<T, K1> keyData1
			, KeyData<T, K2> keyData2
			)
			: this(collection, new KeyData<T>[] { keyData1, keyData2, })
		{ }

		public OrderedReadOnlyList(IEnumerable<T> collection, IEnumerable<KeyData<T>> keyData)
			: base(collection, keyData)
		{
			try
			{
				this.Key2Getter=((KeyData<T, K2>)this.KeysData[KeyIndex-1]).GetMember;
				this.Key2Comparison=((KeyData<T, K2>)this.KeysData[KeyIndex-1]).Comparison;
			}
			catch(InvalidCastException)
			{
				throw new InvalidCastException($"{nameof(keyData)}[{KeyIndex-1}] cannot be cast to KeyData<T, K{KeyIndex}>");
			}
		}
	}
}