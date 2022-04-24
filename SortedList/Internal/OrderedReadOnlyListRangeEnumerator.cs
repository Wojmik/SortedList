﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.SortedList.Internal
{
	class OrderedReadOnlyListRangeEnumerator<T> : IEnumerator<T>
	{
		private readonly ReadOnlyMemory<T> Memory;

		private int Index;

		public T Current { get => Memory.Span[Index]; }

		object? IEnumerator.Current { get => Current; }

		public OrderedReadOnlyListRangeEnumerator(in ReadOnlyMemory<T> memory)
		{
			Memory = memory;
			Index = -1;
		}

		public bool MoveNext()
		{
			Index = Math.Min(Index+1, Memory.Length);

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