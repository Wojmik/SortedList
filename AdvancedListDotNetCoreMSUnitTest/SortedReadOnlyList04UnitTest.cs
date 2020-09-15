using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WojciechMikołajewicz.AdvancedList;

namespace WojciechMikołajewicz.AdvancedListDotNetCoreMSUnitTest
{
	[TestClass]
	public class SortedReadOnlyList04UnitTest
	{
		const int KeysCount = 4;

		private static SortedReadOnlyList<SortedListItem, string, int, double, decimal> CreateSortedReadOnlyList(IEnumerable<SortedListItem> list)
		{
			return new SortedReadOnlyList<SortedListItem, string, int, double, decimal>(list, SortedReadOnlyListSampleSourceArray.AllKeysData);
		}

		private static SortedReadOnlyList<SortedListItem, string, int, double, decimal> SampleList { get; set; }

		private static SortedListTestHelper SortedListTestHelper { get; set; }

		[ClassInitialize]
		public static void Init(TestContext testContext)
		{
			SampleList=CreateSortedReadOnlyList(SortedReadOnlyListSampleSourceArray.SampleArray);
			SortedListTestHelper=new SortedListTestHelper(sampleList: SampleList);
		}

		[ClassCleanup]
		public static void Destroy()
		{
			SortedListTestHelper=null;
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
		public void Equal01Find()
		{
			var comparer = new SortedListItemComparer(depth: 1);

			var equal=SampleList.BinaryFindEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1
				);

			var equalRange=SampleList.BinaryFindEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1
				);

			SortedListTestHelper.EqualTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void Equal02Find()
		{
			var comparer = new SortedListItemComparer(depth: 2);

			var equal=SampleList.BinaryFindEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2
				);

			var equalRange=SampleList.BinaryFindEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2
				);

			SortedListTestHelper.EqualTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void Equal03Find()
		{
			var comparer = new SortedListItemComparer(depth: 3);

			var equal=SampleList.BinaryFindEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3
				);

			var equalRange=SampleList.BinaryFindEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3
				);

			SortedListTestHelper.EqualTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void Equal04Find()
		{
			var comparer = new SortedListItemComparer(depth: 4);

			var equal=SampleList.BinaryFindEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4
				);

			var equalRange=SampleList.BinaryFindEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4
				);

			SortedListTestHelper.EqualTest(comparer, equal, equalRange);
		}
		#endregion

		#region LessOrEquals
		[TestMethod]
		public void LessOrEqual01Find()
		{
			var comparer = new SortedListItemComparer(depth: 1);

			var equal=SampleList.BinaryFindLessOrEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1
				);

			var equalRange=SampleList.BinaryFindLessOrEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1
				);

			SortedListTestHelper.LessOrEqualTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void LessOrEqual02Find()
		{
			var comparer = new SortedListItemComparer(depth: 2);

			var equal=SampleList.BinaryFindLessOrEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2
				);

			var equalRange=SampleList.BinaryFindLessOrEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2
				);

			SortedListTestHelper.LessOrEqualTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void LessOrEqual03Find()
		{
			var comparer = new SortedListItemComparer(depth: 3);

			var equal=SampleList.BinaryFindLessOrEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3
				);

			var equalRange=SampleList.BinaryFindLessOrEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3
				);

			SortedListTestHelper.LessOrEqualTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void LessOrEqual04Find()
		{
			var comparer = new SortedListItemComparer(depth: 4);

			var equal=SampleList.BinaryFindLessOrEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4
				);

			var equalRange=SampleList.BinaryFindLessOrEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4
				);

			SortedListTestHelper.LessOrEqualTest(comparer, equal, equalRange);
		}
		#endregion

		#region Less
		[TestMethod]
		public void Less01Find()
		{
			var comparer = new SortedListItemComparer(depth: 1);

			var equal=SampleList.BinaryFindLess(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1
				);

			var equalRange=SampleList.BinaryFindLessRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1
				);

			SortedListTestHelper.LessTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void Less02Find()
		{
			var comparer = new SortedListItemComparer(depth: 2);

			var equal=SampleList.BinaryFindLess(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2
				);

			var equalRange=SampleList.BinaryFindLessRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2
				);

			SortedListTestHelper.LessTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void Less03Find()
		{
			var comparer = new SortedListItemComparer(depth: 3);

			var equal=SampleList.BinaryFindLess(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3
				);

			var equalRange=SampleList.BinaryFindLessRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3
				);

			SortedListTestHelper.LessTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void Less04Find()
		{
			var comparer = new SortedListItemComparer(depth: 4);

			var equal=SampleList.BinaryFindLess(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4
				);

			var equalRange=SampleList.BinaryFindLessRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4
				);

			SortedListTestHelper.LessTest(comparer, equal, equalRange);
		}
		#endregion

		#region GreaterOrEquals
		[TestMethod]
		public void GreaterOrEqual01Find()
		{
			var comparer = new SortedListItemComparer(depth: 1);

			var equal = SampleList.BinaryFindGreaterOrEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1
				);

			var equalRange = SampleList.BinaryFindGreaterOrEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1
				);

			SortedListTestHelper.GreaterOrEqualTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void GreaterOrEqual02Find()
		{
			var comparer = new SortedListItemComparer(depth: 2);

			var equal = SampleList.BinaryFindGreaterOrEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2
				);

			var equalRange = SampleList.BinaryFindGreaterOrEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2
				);

			SortedListTestHelper.GreaterOrEqualTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void GreaterOrEqual03Find()
		{
			var comparer = new SortedListItemComparer(depth: 3);

			var equal = SampleList.BinaryFindGreaterOrEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3
				);

			var equalRange = SampleList.BinaryFindGreaterOrEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3
				);

			SortedListTestHelper.GreaterOrEqualTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void GreaterOrEqual04Find()
		{
			var comparer = new SortedListItemComparer(depth: 4);

			var equal = SampleList.BinaryFindGreaterOrEqual(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4
				);

			var equalRange = SampleList.BinaryFindGreaterOrEqualRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4
				);

			SortedListTestHelper.GreaterOrEqualTest(comparer, equal, equalRange);
		}
		#endregion

		#region Greater
		[TestMethod]
		public void Greater01Find()
		{
			var comparer = new SortedListItemComparer(depth: 1);

			var equal = SampleList.BinaryFindGreater(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1
				);

			var equalRange = SampleList.BinaryFindGreaterRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1
				);

			SortedListTestHelper.GreaterTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void Greater02Find()
		{
			var comparer = new SortedListItemComparer(depth: 2);

			var equal = SampleList.BinaryFindGreater(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2
				);

			var equalRange = SampleList.BinaryFindGreaterRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2
				);

			SortedListTestHelper.GreaterTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void Greater03Find()
		{
			var comparer = new SortedListItemComparer(depth: 3);

			var equal = SampleList.BinaryFindGreater(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3
				);

			var equalRange = SampleList.BinaryFindGreaterRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3
				);

			SortedListTestHelper.GreaterTest(comparer, equal, equalRange);
		}

		[TestMethod]
		public void Greater04Find()
		{
			var comparer = new SortedListItemComparer(depth: 4);

			var equal = SampleList.BinaryFindGreater(
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4
				);

			var equalRange = SampleList.BinaryFindGreaterRange(
				range: Range.All,
				key1: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key1,
				key2: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key2,
				key3: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key3,
				key4: SortedReadOnlyListSampleSourceArray.ExistingItemExample.Key4
				);

			SortedListTestHelper.GreaterTest(comparer, equal, equalRange);
		}
		#endregion
	}
}