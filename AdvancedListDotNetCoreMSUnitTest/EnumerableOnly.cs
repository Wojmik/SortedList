using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedListDotNetCoreMSUnitTest
{
	class EnumerableOnly<T> : IEnumerable<T>
	{
		public IEnumerable<T> Enumerable { get; }

		public EnumerableOnly(IEnumerable<T> enumerable)
		{
			this.Enumerable=enumerable;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this.Enumerable.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}