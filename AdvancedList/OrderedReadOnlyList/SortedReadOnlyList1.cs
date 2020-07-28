using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace WojciechMikołajewicz.AdvancedList
{
	public class SortedReadOnlyList<T, K1> : SortedReadOnlyList<T>
	{
		private const int KeyIndex = 1;

		public Func<T, K1> Key1Getter { get; }

		public Comparison<K1> Key1Comparison { get; }

		protected override int KeysCount { get => KeyIndex; }

		public SortedReadOnlyList(IEnumerable<T> collection
			, KeyData<T, K1> keyData1
			)
			: this(collection, new KeyData<T>[] { keyData1, })
		{ }

		public SortedReadOnlyList(IEnumerable<T> collection, IEnumerable<KeyData<T>> keysData)
			: base(collection, keysData)
		{
			try
			{
				this.Key1Getter=((KeyData<T, K1>)this.KeysData[KeyIndex-1]).GetMember;
				this.Key1Comparison=((KeyData<T, K1>)this.KeysData[KeyIndex-1]).Comparison;
			}
			catch(InvalidCastException)
			{
				throw new InvalidCastException($"{nameof(keysData)}[{KeyIndex-1}] cannot be cast to KeyData<T, K{KeyIndex}>");
			}
		}
	}
}