using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace WojciechMikołajewicz.AdvancedListDotNetCoreMSUnitTest
{
	class SortedListTestHelper
	{
		private IReadOnlyList<SortedListItem> SampleList { get; }

		public SortedListTestHelper(IReadOnlyList<SortedListItem> sampleList)
		{
			this.SampleList = sampleList;
		}

		public void EqualTest(SortedListItemComparer comparer, IReadOnlyList<SortedListItem> resultList, Range resultRange)
		{
			int cmp;

			cmp = comparer.Compare(resultList[0], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.AreEqual(0, cmp, $"resultList[0] should be equal to sample and is {CompareResult(cmp)}");

			cmp = comparer.Compare(resultList[resultList.Count - 1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.AreEqual(0, cmp, $"resultList[^1] should be equal to sample and is {CompareResult(cmp)}");

			Assert.ThrowsExactly<IndexOutOfRangeException>(() => resultList[-1]);
			Assert.ThrowsExactly<IndexOutOfRangeException>(() => resultList[resultList.Count]);

			(int offset, int length) = resultRange.GetOffsetAndLength(SampleList.Count);
			cmp = comparer.Compare(SampleList[offset], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.AreEqual(0, cmp, $"SampleList[resultRange.Start] should be equal to sample and is {CompareResult(cmp)}");

			if (0 < resultRange.Start.GetOffset(SampleList.Count))
			{
				cmp = comparer.Compare(SampleList[resultRange.Start.GetOffset(SampleList.Count) - 1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
				Assert.IsTrue(cmp < 0, $"SampleList[resultRange.Start-1] should be less to sample and is {CompareResult(cmp)}");
			}

			cmp = comparer.Compare(SampleList[resultRange.End.GetOffset(SampleList.Count) - 1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.AreEqual(0, cmp, $"SampleList[resultRange.Start+resultRange.Count-1] should be equal to sample and is {CompareResult(cmp)}");

			if (resultRange.End.GetOffset(SampleList.Count) < SampleList.Count)
			{
				cmp = comparer.Compare(SampleList[resultRange.End.GetOffset(SampleList.Count)], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
				Assert.IsTrue(0 < cmp, $"SampleList[resultRange.Start+resultRange.Count] should be greater to sample and is {CompareResult(cmp)}");
			}

			(_, int expectedLength) = resultRange.GetOffsetAndLength(SampleList.Count);
			Assert.HasCount(expectedLength, resultList);
		}

		public void LessOrEqualTest(SortedListItemComparer comparer, IReadOnlyList<SortedListItem> resultList, Range resultRange)
		{
			int cmp;

			cmp = comparer.Compare(resultList[resultList.Count - 1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.IsTrue(cmp <= 0, $"resultList[^1] should be less or equal to sample and is {CompareResult(cmp)}");

			Assert.ThrowsExactly<IndexOutOfRangeException>(() => resultList[-1]);
			Assert.ThrowsExactly<IndexOutOfRangeException>(() => resultList[resultList.Count]);

			var (offset, length) = resultRange.GetOffsetAndLength(SampleList.Count);
			Assert.IsTrue(length == 0 || offset == 0, $"resultRange.Start should be zero or resultRange should be empty and is {offset}, length {length}");

			cmp = comparer.Compare(SampleList[resultRange.End.GetOffset(SampleList.Count) - 1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.IsTrue(cmp <= 0, $"SampleList[resultRange.Start+resultRange.Count-1] should be less or equal to sample and is {CompareResult(cmp)}");

			if (resultRange.End.GetOffset(SampleList.Count) < SampleList.Count)
			{
				cmp = comparer.Compare(SampleList[resultRange.End.GetOffset(SampleList.Count)], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
				Assert.IsTrue(0 < cmp, $"SampleList[resultRange.Start+resultRange.Count] should be greater to sample and is {CompareResult(cmp)}");
			}

			Assert.HasCount(length, resultList);
		}

		public void LessTest(SortedListItemComparer comparer, IReadOnlyList<SortedListItem> resultList, Range resultRange)
		{
			int cmp;

			cmp = comparer.Compare(resultList[resultList.Count - 1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.IsTrue(cmp < 0, $"resultList[^1] should be less to sample and is {CompareResult(cmp)}");

			Assert.ThrowsExactly<IndexOutOfRangeException>(() => resultList[-1]);
			Assert.ThrowsExactly<IndexOutOfRangeException>(() => resultList[resultList.Count]);

			(int offset, int length) = resultRange.GetOffsetAndLength(SampleList.Count);
			Assert.IsTrue(length == 0 || offset == 0, $"resultRange.Start should be zero or resultRange should be empty and is {offset}, length {length}");

			cmp = comparer.Compare(SampleList[resultRange.End.GetOffset(SampleList.Count) - 1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.IsTrue(cmp < 0, $"SampleList[resultRange.Start+resultRange.Count-1] should be less to sample and is {CompareResult(cmp)}");

			if (resultRange.End.GetOffset(SampleList.Count) < SampleList.Count)
			{
				cmp = comparer.Compare(SampleList[resultRange.End.GetOffset(SampleList.Count)], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
				Assert.IsTrue(0 <= cmp, $"SampleList[resultRange.Start+resultRange.Count] should be greater or equal to sample and is {CompareResult(cmp)}");
			}

			Assert.HasCount(length, resultList);
		}

		public void GreaterOrEqualTest(SortedListItemComparer comparer, IReadOnlyList<SortedListItem> resultList, Range resultRange)
		{
			int cmp;

			cmp = comparer.Compare(resultList[0], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.IsTrue(0 <= cmp, $"resultList[0] should be greater or equal to sample and is {CompareResult(cmp)}");

			Assert.ThrowsExactly<IndexOutOfRangeException>(() => resultList[-1]);
			Assert.ThrowsExactly<IndexOutOfRangeException>(() => resultList[resultList.Count]);

			var (offset, length) = resultRange.GetOffsetAndLength(SampleList.Count);
			cmp = comparer.Compare(SampleList[offset], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.IsTrue(0 <= cmp, $"SampleList[resultRange.Start] should be greater or equal to sample and is {CompareResult(cmp)}");

			if (0 < resultRange.Start.GetOffset(SampleList.Count))
			{
				cmp = comparer.Compare(SampleList[resultRange.Start.GetOffset(SampleList.Count) - 1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
				Assert.IsTrue(cmp < 0, $"SampleList[resultRange.Start-1] should be less to sample and is {CompareResult(cmp)}");
			}

			(offset, length) = resultRange.GetOffsetAndLength(SampleList.Count);
			Assert.IsTrue(length == 0 || offset + length == SampleList.Count, $"resultRange.Start+resultRange.Count should be {SampleList.Count} or resultRange should be empty and is {CompareResult(cmp)}, length {length}");

			Assert.HasCount(length, resultList);
		}

		public void GreaterTest(SortedListItemComparer comparer, IReadOnlyList<SortedListItem> resultList, Range resultRange)
		{
			int cmp;

			cmp = comparer.Compare(resultList[0], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.IsTrue(0 < cmp, $"resultList[0] should be greater to sample and is {CompareResult(cmp)}");

			Assert.ThrowsExactly<IndexOutOfRangeException>(() => resultList[-1]);
			Assert.ThrowsExactly<IndexOutOfRangeException>(() => resultList[resultList.Count]);

			var (offset, length) = resultRange.GetOffsetAndLength(SampleList.Count);
			cmp = comparer.Compare(SampleList[offset], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.IsTrue(0 < cmp, $"SampleList[resultRange.Start] should be greater to sample and is {CompareResult(cmp)}");

			if (0 < resultRange.Start.GetOffset(SampleList.Count))
			{
				cmp = comparer.Compare(SampleList[resultRange.Start.GetOffset(SampleList.Count) - 1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
				Assert.IsTrue(cmp <= 0, $"SampleList[resultRange.Start-1] should be less or equal to sample and is {CompareResult(cmp)}");
			}

			(offset, length) = resultRange.GetOffsetAndLength(SampleList.Count);
			Assert.IsTrue(length == 0 || offset + length == SampleList.Count, $"resultRange.Start+resultRange.Count should be {SampleList.Count} or resultRange should be empty and is {CompareResult(cmp)}, length {length}");

			Assert.HasCount(length, resultList);
		}

		private string CompareResult(int cmp)
		{
			string result;

			if (cmp < 0)
				result = "less";
			else if (cmp > 0)
				result = "greater";
			else
				result = "equal";

			return result;
		}
	}
}