using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal
{
	class OrderedReadOnlyListRangeEnumerator<T> : IEnumerator<T>
	{
		private readonly ReadOnlyMemory<T> Memory;

		private int Index;

		public T Current { get => Memory.Span[Index]; }

		object IEnumerator.Current { get => this.Current; }

		public OrderedReadOnlyListRangeEnumerator(OrderedReadOnlyListRange<T> orderedReadOnlyListRange)
		{
			this.Memory=orderedReadOnlyListRange.AsMemory();
			this.Index=-1;
		}

		public bool MoveNext()
		{
			Index=Math.Min(Index+1, Memory.Length);

			return Index<Memory.Length;
		}

		public void Reset()
		{
			Index=-1;
		}

		public void Dispose()
		{ }
	}
}