using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList
{
//	public readonly struct SortedReadOnlyListRange<T, K1, K2> : IReadOnlyList<T>
//	{
//		#region Common
//		public static implicit operator SortedReadOnlyListRange<T, K1, K2>(SortedReadOnlyList<T, K1, K2> orderedReadOnlyList) => new SortedReadOnlyListRange<T, K1, K2>(orderedReadOnlyList, new Range(0, orderedReadOnlyList.Count));

//		private SortedReadOnlyList<T, K1, K2> OrderedList { get; }

//		public ReadOnlyMemory<T> Memory { get; }

//		public int Start { get; }

//		public int Count { get => this.Memory.Length; }

//		public bool IsEmpty { get => this.Memory.IsEmpty; }

//		public T this[int index] { get => this.Memory.Span[index]; }

//		public SortedReadOnlyListRange(SortedReadOnlyList<T, K1, K2> orderedList, Range range)
//		{
//			(int start, int count) = range.GetOffsetAndLength(orderedList.Count);
//			this.OrderedList=orderedList;
//			this.Memory=orderedList.AsMemory().Slice(start, count);
//			this.Start=start;
//		}

//		public ReadOnlyMemory<T> AsMemory()
//		{
//			return this.Memory;
//		}

//		public IEnumerator<T> GetEnumerator()
//		{
//			return new OrderedReadOnlyList.Internal.OrderedReadOnlyListRangeEnumerator<T>(this.Memory);
//		}

//		IEnumerator IEnumerable.GetEnumerator()
//		{
//			return this.GetEnumerator();
//		}
//#endregion

//		#region Equal
//		public SortedReadOnlyListRange<T, K1, K2> BinaryFindEqual(K1 key1)
//		{
//			var k1Comparison = this.OrderedList.Key1Comparison;
//			var k1Getter = this.OrderedList.Key1Getter;

//			var range = this.OrderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

//			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

//			int Comparison(T item)
//			{
//				int cmp;

//				cmp=k1Comparison(key1, k1Getter(item));

//				return cmp;
//			}
//		}

//		public SortedReadOnlyListRange<T, K1, K2> BinaryFindEqual(K1 key1, K2 key2)
//		{
//			var k1Comparison = this.OrderedList.Key1Comparison;
//			var k1Getter = this.OrderedList.Key1Getter;
//			var k2Comparison = this.OrderedList.Key2Comparison;
//			var k2Getter = this.OrderedList.Key2Getter;

//			var range = this.OrderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

//			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

//			int Comparison(T item)
//			{
//				int cmp;

//				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
//					cmp=k2Comparison(key2, k2Getter(item));

//				return cmp;
//			}
//		}
//		#endregion

//		#region LessOrEqual
//		public SortedReadOnlyListRange<T, K1, K2> BinaryFindLessOrEqual(K1 key1)
//		{
//			var k1Comparison = this.OrderedList.Key1Comparison;
//			var k1Getter = this.OrderedList.Key1Getter;

//			var range = this.OrderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

//			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

//			int Comparison(T item)
//			{
//				int cmp;

//				cmp=k1Comparison(key1, k1Getter(item));

//				return cmp;
//			}
//		}

//		public SortedReadOnlyListRange<T, K1, K2> BinaryFindLessOrEqual(K1 key1, K2 key2)
//		{
//			var k1Comparison = this.OrderedList.Key1Comparison;
//			var k1Getter = this.OrderedList.Key1Getter;
//			var k2Comparison = this.OrderedList.Key2Comparison;
//			var k2Getter = this.OrderedList.Key2Getter;

//			var range = this.OrderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

//			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

//			int Comparison(T item)
//			{
//				int cmp;

//				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
//					cmp=k2Comparison(key2, k2Getter(item));

//				return cmp;
//			}
//		}
//		#endregion

//		#region Less
//		public SortedReadOnlyListRange<T, K1, K2> BinaryFindLess(K1 key1)
//		{
//			var k1Comparison = this.OrderedList.Key1Comparison;
//			var k1Getter = this.OrderedList.Key1Getter;

//			var range = this.OrderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

//			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

//			int Comparison(T item)
//			{
//				int cmp;

//				cmp=k1Comparison(key1, k1Getter(item));

//				return cmp;
//			}
//		}

//		public SortedReadOnlyListRange<T, K1, K2> BinaryFindLess(K1 key1, K2 key2)
//		{
//			var k1Comparison = this.OrderedList.Key1Comparison;
//			var k1Getter = this.OrderedList.Key1Getter;
//			var k2Comparison = this.OrderedList.Key2Comparison;
//			var k2Getter = this.OrderedList.Key2Getter;

//			var range = this.OrderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

//			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

//			int Comparison(T item)
//			{
//				int cmp;

//				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
//					cmp=k2Comparison(key2, k2Getter(item));

//				return cmp;
//			}
//		}
//		#endregion

//		#region GreaterOrEqual
//		public SortedReadOnlyListRange<T, K1, K2> BinaryFindGreaterOrEqual(K1 key1)
//		{
//			var k1Comparison = this.OrderedList.Key1Comparison;
//			var k1Getter = this.OrderedList.Key1Getter;

//			var range = this.OrderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

//			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

//			int Comparison(T item)
//			{
//				int cmp;

//				cmp=k1Comparison(key1, k1Getter(item));

//				return cmp;
//			}
//		}

//		public SortedReadOnlyListRange<T, K1, K2> BinaryFindGreaterOrEqual(K1 key1, K2 key2)
//		{
//			var k1Comparison = this.OrderedList.Key1Comparison;
//			var k1Getter = this.OrderedList.Key1Getter;
//			var k2Comparison = this.OrderedList.Key2Comparison;
//			var k2Getter = this.OrderedList.Key2Getter;

//			var range = this.OrderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

//			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

//			int Comparison(T item)
//			{
//				int cmp;

//				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
//					cmp=k2Comparison(key2, k2Getter(item));

//				return cmp;
//			}
//		}
//		#endregion

//		#region Greater
//		public SortedReadOnlyListRange<T, K1, K2> BinaryFindGreater(K1 key1)
//		{
//			var k1Comparison = this.OrderedList.Key1Comparison;
//			var k1Getter = this.OrderedList.Key1Getter;

//			var range = this.OrderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

//			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

//			int Comparison(T item)
//			{
//				int cmp;

//				cmp=k1Comparison(key1, k1Getter(item));

//				return cmp;
//			}
//		}

//		public SortedReadOnlyListRange<T, K1, K2> BinaryFindGreater(K1 key1, K2 key2)
//		{
//			var k1Comparison = this.OrderedList.Key1Comparison;
//			var k1Getter = this.OrderedList.Key1Getter;
//			var k2Comparison = this.OrderedList.Key2Comparison;
//			var k2Getter = this.OrderedList.Key2Getter;

//			var range = this.OrderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

//			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

//			int Comparison(T item)
//			{
//				int cmp;

//				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
//					cmp=k2Comparison(key2, k2Getter(item));

//				return cmp;
//			}
//		}
//		#endregion
//	}
}