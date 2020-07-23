using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal
{
	class ItemComparer<T> : IComparer<T>
	{
		private readonly IEnumerable<KeyData<T>> KeyData;

		public ItemComparer(IEnumerable<KeyData<T>> keyData)
		{
			this.KeyData=keyData;
		}

		public int Compare(T x, T y)
		{
			int cmp = 0;

			foreach(var kd in this.KeyData)
				if(0!=(cmp=kd.Compare(x, y)))
					break;

			return cmp;
		}
	}
}