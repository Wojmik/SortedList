using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WojciechMikołajewicz.AdvancedList;

namespace WojciechMikołajewicz.AdvancedListDotNetCoreMSUnitTest
{
	[TestClass]
	public class SortedReadOnlyList16UnitTest
	{
		const int KeysCount = 16;

		public static SortedReadOnlyList<SortedListItem, string, int, double, decimal, short, float, long, byte, char, sbyte, DateTime, TimeSpan, ulong, uint, ushort, Guid> CreateSortedReadOnlyList(IEnumerable<SortedListItem> list)
		{
			return new SortedReadOnlyList<SortedListItem, string, int, double, decimal, short, float, long, byte, char, sbyte, DateTime, TimeSpan, ulong, uint, ushort, Guid>(list, SortedReadOnlyListSampleSourceArray.AllKeysData);
		}

		public static SortedReadOnlyList<SortedListItem, string, int, double, decimal, short, float, long, byte, char, sbyte, DateTime, TimeSpan, ulong, uint, ushort, Guid> SampleList { get; set; }

		[ClassInitialize]
		public static void Init(TestContext testContext)
		{
			SampleList=CreateSortedReadOnlyList(SortedReadOnlyListSampleSourceArray.SampleArray);
		}

		[ClassCleanup]
		public static void Destroy()
		{
			SampleList=null;
		}

		#region Sorting
		[TestMethod]
		public void CheckOrderUnitTest()
		{
			var comparer = new SortedListItemComparer(depth: KeysCount);

			Assert.AreEqual(SortedReadOnlyListSampleSourceArray.SampleArray.Count, SampleList.Count, "{0} shoud have {1} count and is {2} count", nameof(SampleList), SortedReadOnlyListSampleSourceArray.SampleArray.Count, SampleList.Count);

			for(int i = 1; i<SampleList.Count; i++)
				if(0<comparer.Compare(SampleList[i-1], SampleList[i]))
				{
					Assert.Fail("Sorted list should be sorted and is not");
					break;
				}
		}

		[TestMethod]
		public void CheckOrderFromEnumerableUnitTest()
		{
			var comparer = new SortedListItemComparer(depth: KeysCount);

			var sampleList = CreateSortedReadOnlyList(new EnumerableOnly<SortedListItem>(SortedReadOnlyListSampleSourceArray.SampleArray));

			Assert.AreEqual(SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count, "{0} shoud have {1} count and is {2} count", nameof(sampleList), SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count);

			for(int i = 1; i<sampleList.Count; i++)
				if(0<comparer.Compare(sampleList[i-1], sampleList[i]))
				{
					Assert.Fail("Sorted list should be sorted and is not");
					break;
				}
		}

		[TestMethod]
		public void CheckOrderSourceSortedUnitTest()
		{
			var sortedArray = SortedReadOnlyListSampleSourceArray.SampleArray.ToArray();
			var comparer = new SortedListItemComparer(depth: KeysCount);

			Array.Sort(sortedArray, comparer);
			var sampleList = CreateSortedReadOnlyList(sortedArray);

			Assert.AreEqual(SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count, "{0} shoud have {1} count and is {2} count", nameof(sampleList), SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count);

			for(int i = 1; i<sampleList.Count; i++)
				if(0<comparer.Compare(sampleList[i-1], sampleList[i]))
				{
					Assert.Fail("Sorted list should be sorted and is not");
					break;
				}
		}

		[TestMethod]
		public void CheckOrderSourceSortedFromEnumerableUnitTest()
		{
			var sortedArray = SortedReadOnlyListSampleSourceArray.SampleArray.ToArray();
			var comparer = new SortedListItemComparer(depth: KeysCount);

			Array.Sort(sortedArray, comparer);
			var sampleList = CreateSortedReadOnlyList(new EnumerableOnly<SortedListItem>(sortedArray));

			Assert.AreEqual(SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count, "{0} shoud have {1} count and is {2} count", nameof(sampleList), SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count);

			for(int i = 1; i<sampleList.Count; i++)
				if(0<comparer.Compare(sampleList[i-1], sampleList[i]))
				{
					Assert.Fail("Sorted list should be sorted and is not");
					break;
				}
		}
		#endregion

		#region Equals
		[TestMethod]
		public void Equal16Find()
		{
			var comparer = new SortedListItemComparer(depth: KeysCount);
			int cmp;

			var equal=SampleList.BinaryFindEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4,
				key5: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key5,
				key6: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key6,
				key7: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key7,
				key8: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key8,
				key9: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key9,
				key10: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key10,
				key11: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key11,
				key12: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key12,
				key13: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key13,
				key14: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key14,
				key15: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key15,
				key16: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key16
				);

			cmp=comparer.Compare(equal[0], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.AreEqual(0, cmp, "equal[0] should be equal to sample and is {0}", CompareResult(cmp));

			cmp=comparer.Compare(equal[^1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.AreEqual(0, cmp, "equal[^1] should be equal to sample and is {0}", CompareResult(cmp));

			Assert.ThrowsException<IndexOutOfRangeException>(() => equal[-1]);
			Assert.ThrowsException<IndexOutOfRangeException>(() => equal[^0]);

			cmp=comparer.Compare(SampleList[equal.Start], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.AreEqual(0, cmp, "SampleList[equal.Start] should be equal to sample and is {0}", CompareResult(cmp));

			if(0<equal.Start)
			{
				cmp=comparer.Compare(SampleList[equal.Start-1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
				Assert.IsTrue(cmp<0, "SampleList[equal.Start-1] should be less to sample and is {0}", CompareResult(cmp));
			}

			cmp=comparer.Compare(SampleList[equal.Start+equal.Count-1], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
			Assert.AreEqual(0, cmp, "SampleList[equal.Start+equal.Count-1] should be equal to sample and is {0}", CompareResult(cmp));

			if(equal.Start+equal.Count<SampleList.Count)
			{
				cmp=comparer.Compare(SampleList[equal.Start+equal.Count], SortedReadOnlyListSampleSourceArray.ExistingItemExample);
				Assert.IsTrue(0<cmp, "SampleList[equal.Start+equal.Count] should be greather to sample and is {0}", CompareResult(cmp));
			}
		}

		#endregion
		private string CompareResult(int cmp)
		{
			return cmp switch
			{
				_ when cmp<0 => "less",
				_ when cmp>0 => "greather",
				_ => "equal",
			};
		}
	}
}