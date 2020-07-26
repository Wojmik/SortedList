using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace WojciechMikołajewicz.AdvancedList
{
	public abstract class OrderedReadOnlyListRange<T> : IReadOnlyList<T>
	{
		protected OrderedReadOnlyList<T> OrderedList { get; }

		public int Start { get; }

		public int Count { get => this.Memory.Length; }

		protected readonly ReadOnlyMemory<T> Memory;

		public bool IsEmpty { get => this.Memory.IsEmpty; }

		public T this[int index] { get => this.Memory.Span[index]; }

		protected OrderedReadOnlyListRange(OrderedReadOnlyList<T> orderedList, int start, int count)
		{
			this.Memory=orderedList.AsMemory().Slice(start, count);
			this.OrderedList=orderedList;
			this.Start=start;
		}

		public ReadOnlyMemory<T> AsMemory()
		{
			return this.Memory;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new OrderedReadOnlyList.Internal.OrderedReadOnlyListRangeEnumerator<T>(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}