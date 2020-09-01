using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal.Comparer;

namespace WojciechMikołajewicz.AdvancedList
{
	public readonly struct SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> : IReadOnlyList<T>
	{
		#region Common
		public static implicit operator SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(SortedReadOnlyList<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> orderedReadOnlyList) => new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedReadOnlyList, new Range(0, orderedReadOnlyList.Count));

		private SortedReadOnlyList<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> OrderedList { get; }

		public ReadOnlyMemory<T> Memory { get; }

		public int Start { get; }

		public int Count { get => this.Memory.Length; }

		public bool IsEmpty { get => this.Memory.IsEmpty; }

		public T this[int index] { get => this.Memory.Span[index]; }

		public SortedReadOnlyListRange(SortedReadOnlyList<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> orderedList, Range range)
		{
			(int start, int count) = range.GetOffsetAndLength(orderedList.Count);
			this.OrderedList=orderedList;
			this.Memory=orderedList.AsMemory().Slice(start, count);
			this.Start=start;
		}

		//private SortedReadOnlyListRange(SortedReadOnlyList<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> orderedList, ReadOnlyMemory<T> memory)
		//{
		//	this.OrderedList=orderedList;
		//	this.Memory=memory;
		//}

		public IEnumerator<T> GetEnumerator()
		{
			return new OrderedReadOnlyList.Internal.OrderedReadOnlyListRangeEnumerator<T>(this.Memory);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		#endregion

		#region Equal
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
			}
		}
		#endregion

		#region LessOrEqual
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
			}
		}
		#endregion

		#region Less
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
			}
		}
		#endregion

		#region GreaterOrEqual
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
			}
		}
		#endregion

		#region Greater
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15);
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var orderedList = this.OrderedList;

			var range = orderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(orderedList, range);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16);
			}
		}
		#endregion
	}
}