using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList
{
	public class OrderedReadOnlyListRange<T, K1> : OrderedReadOnlyListRange<T>
	{
		public static implicit operator OrderedReadOnlyListRange<T, K1>(OrderedReadOnlyList<T, K1> orderedReadOnlyList) => new OrderedReadOnlyListRange<T, K1>(orderedReadOnlyList, 0, orderedReadOnlyList.Count);

		public OrderedReadOnlyListRange(OrderedReadOnlyList<T> orderedList, int start, int count)
			: base(orderedList: orderedList, start: start, count: count)
		{ }
	}
}