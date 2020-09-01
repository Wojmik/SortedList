using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList
{
	public interface IKeyData<T>
	{
		int Compare(T x, T y);

		int Compare(T x, object value);
	}
}