using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

		public ReadOnlyMemory<T> AsMemory()
		{
			return this.Memory;
		}

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
		public SortedReadOnlyListRange<T, K1> BinaryFindEqual(K1 key1)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;

			var range = this.OrderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				cmp=k1Comparison(key1, k1Getter(item));

				return cmp;
			}
		}

		public SortedReadOnlyListRange<T, K1, K2> BinaryFindEqual(K1 key1, K2 key2)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;
			var k2Comparison = this.OrderedList.Key2Comparison;
			var k2Getter = this.OrderedList.Key2Getter;

			var range = this.OrderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
					cmp=k2Comparison(key2, k2Getter(item));

				return cmp;
			}
		}

		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11, K12 key12, K13 key13, K14 key14, K15 key15, K16 key16)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;
			var k2Comparison = this.OrderedList.Key2Comparison;
			var k2Getter = this.OrderedList.Key2Getter;
			var k3Comparison = this.OrderedList.Key3Comparison;
			var k3Getter = this.OrderedList.Key3Getter;
			var k4Comparison = this.OrderedList.Key4Comparison;
			var k4Getter = this.OrderedList.Key4Getter;
			var k5Comparison = this.OrderedList.Key5Comparison;
			var k5Getter = this.OrderedList.Key5Getter;
			var k6Comparison = this.OrderedList.Key6Comparison;
			var k6Getter = this.OrderedList.Key6Getter;
			var k7Comparison = this.OrderedList.Key7Comparison;
			var k7Getter = this.OrderedList.Key7Getter;
			var k8Comparison = this.OrderedList.Key8Comparison;
			var k8Getter = this.OrderedList.Key8Getter;
			var k9Comparison = this.OrderedList.Key9Comparison;
			var k9Getter = this.OrderedList.Key9Getter;
			var k10Comparison = this.OrderedList.Key10Comparison;
			var k10Getter = this.OrderedList.Key10Getter;
			var k11Comparison = this.OrderedList.Key11Comparison;
			var k11Getter = this.OrderedList.Key11Getter;
			var k12Comparison = this.OrderedList.Key12Comparison;
			var k12Getter = this.OrderedList.Key12Getter;
			var k13Comparison = this.OrderedList.Key13Comparison;
			var k13Getter = this.OrderedList.Key13Getter;
			var k14Comparison = this.OrderedList.Key14Comparison;
			var k14Getter = this.OrderedList.Key14Getter;
			var k15Comparison = this.OrderedList.Key15Comparison;
			var k15Getter = this.OrderedList.Key15Getter;
			var k16Comparison = this.OrderedList.Key16Comparison;
			var k16Getter = this.OrderedList.Key16Getter;

			var range = this.OrderedList._Array.BinaryFindEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
					if(0==(cmp=k2Comparison(key1, k2Getter(item))))
						if(0==(cmp=k3Comparison(key1, k3Getter(item))))
							if(0==(cmp=k4Comparison(key1, k4Getter(item))))
								if(0==(cmp=k5Comparison(key1, k5Getter(item))))
									if(0==(cmp=k6Comparison(key1, k6Getter(item))))
										if(0==(cmp=k7Comparison(key1, k7Getter(item))))
											if(0==(cmp=k8Comparison(key1, k8Getter(item))))
												if(0==(cmp=k9Comparison(key1, k9Getter(item))))
													if(0==(cmp=k10Comparison(key1, k10Getter(item))))
														if(0==(cmp=k11Comparison(key1, k11Getter(item))))
															if(0==(cmp=k12Comparison(key1, k12Getter(item))))
																if(0==(cmp=k13Comparison(key1, k13Getter(item))))
																	if(0==(cmp=k14Comparison(key1, k14Getter(item))))
																		if(0==(cmp=k15Comparison(key1, k15Getter(item))))
																			cmp=k2Comparison(key16, k16Getter(item));

				return cmp;
			}
		}
		#endregion

		#region LessOrEqual
		public SortedReadOnlyListRange<T, K1> BinaryFindLessOrEqual(K1 key1)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;

			var range = this.OrderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				cmp=k1Comparison(key1, k1Getter(item));

				return cmp;
			}
		}

		public SortedReadOnlyListRange<T, K1, K2> BinaryFindLessOrEqual(K1 key1, K2 key2)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;
			var k2Comparison = this.OrderedList.Key2Comparison;
			var k2Getter = this.OrderedList.Key2Getter;

			var range = this.OrderedList._Array.BinaryFindLessOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
					cmp=k2Comparison(key2, k2Getter(item));

				return cmp;
			}
		}
		#endregion

		#region Less
		public SortedReadOnlyListRange<T, K1> BinaryFindLess(K1 key1)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;

			var range = this.OrderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				cmp=k1Comparison(key1, k1Getter(item));

				return cmp;
			}
		}

		public SortedReadOnlyListRange<T, K1, K2> BinaryFindLess(K1 key1, K2 key2)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;
			var k2Comparison = this.OrderedList.Key2Comparison;
			var k2Getter = this.OrderedList.Key2Getter;

			var range = this.OrderedList._Array.BinaryFindLess(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
					cmp=k2Comparison(key2, k2Getter(item));

				return cmp;
			}
		}
		#endregion

		#region GreaterOrEqual
		public SortedReadOnlyListRange<T, K1> BinaryFindGreaterOrEqual(K1 key1)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;

			var range = this.OrderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				cmp=k1Comparison(key1, k1Getter(item));

				return cmp;
			}
		}

		public SortedReadOnlyListRange<T, K1, K2> BinaryFindGreaterOrEqual(K1 key1, K2 key2)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;
			var k2Comparison = this.OrderedList.Key2Comparison;
			var k2Getter = this.OrderedList.Key2Getter;

			var range = this.OrderedList._Array.BinaryFindGreaterOrEqual(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
					cmp=k2Comparison(key2, k2Getter(item));

				return cmp;
			}
		}
		#endregion

		#region Greater
		public SortedReadOnlyListRange<T, K1> BinaryFindGreater(K1 key1)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;

			var range = this.OrderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				cmp=k1Comparison(key1, k1Getter(item));

				return cmp;
			}
		}

		public SortedReadOnlyListRange<T, K1, K2> BinaryFindGreater(K1 key1, K2 key2)
		{
			var k1Comparison = this.OrderedList.Key1Comparison;
			var k1Getter = this.OrderedList.Key1Getter;
			var k2Comparison = this.OrderedList.Key2Comparison;
			var k2Getter = this.OrderedList.Key2Getter;

			var range = this.OrderedList._Array.BinaryFindGreater(new Range(this.Start, this.Count), Comparison);

			return new SortedReadOnlyListRange<T, K1, K2>(this.OrderedList, range);

			int Comparison(T item)
			{
				int cmp;

				if(0==(cmp=k1Comparison(key1, k1Getter(item))))
					cmp=k2Comparison(key2, k2Getter(item));

				return cmp;
			}
		}
		#endregion
	}
}