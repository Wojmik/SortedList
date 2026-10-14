using System.Collections;
using System.Collections.Generic;

namespace WojciechMikołajewicz.AdvancedListDotNetCoreMSUnitTest
{
	class EnumerableOnly<T> : IEnumerable<T>
	{
		private IEnumerable<T> Enumerable { get; }

		public EnumerableOnly(IEnumerable<T> enumerable)
		{
			Enumerable = enumerable;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return Enumerable.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}