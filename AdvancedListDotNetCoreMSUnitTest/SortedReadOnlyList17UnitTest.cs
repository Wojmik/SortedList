using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WojciechMikołajewicz.AdvancedList;

namespace WojciechMikołajewicz.AdvancedListDotNetCoreMSUnitTest
{
	//[TestClass]
	//public class SortedReadOnlyList17UnitTest
	//{
	//	public static SortedReadOnlyList<SortedListItem> SampleList { get; set; }

	//	[ClassInitialize]
	//	public static void Init(TestContext testContext)
	//	{
	//		SampleList=new SortedReadOnlyList<SortedListItem>(SortedReadOnlyListSampleSourceArray.SampleArray, SortedReadOnlyListSampleSourceArray.AllKeyComparisons);
	//	}

	//	[ClassCleanup]
	//	public static void Destroy()
	//	{
	//		SampleList=null;
	//	}

	//	[TestMethod]
	//	public void CheckOrderUnitTest()
	//	{
	//		var comparer = new SortedListItemComparer(SortedReadOnlyListSampleSourceArray.AllKeyComparisons.Count);

	//		Assert.AreEqual(SortedReadOnlyListSampleSourceArray.SampleArray.Count, SampleList.Count, "{0} shoud have {1} count and is {2} count", nameof(SampleList), SortedReadOnlyListSampleSourceArray.SampleArray.Count, SampleList.Count);

	//		for(int i = 1; i<SampleList.Count; i++)
	//			if(0<comparer.Compare(SampleList[i-1], SampleList[i]))
	//			{
	//				Assert.Fail("Sorted list should be sorted and is not");
	//				break;
	//			}
	//	}

	//	[TestMethod]
	//	public void CheckOrderFromEnumerableUnitTest()
	//	{
	//		var comparer = new SortedListItemComparer(SortedReadOnlyListSampleSourceArray.AllKeyComparisons.Count);

	//		var sampleList = new SortedReadOnlyList<SortedListItem>(new EnumerableOnly<SortedListItem>(SortedReadOnlyListSampleSourceArray.SampleArray), SortedReadOnlyListSampleSourceArray.AllKeyComparisons);

	//		Assert.AreEqual(SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count, "{0} shoud have {1} count and is {2} count", nameof(sampleList), SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count);

	//		for(int i = 1; i<sampleList.Count; i++)
	//			if(0<comparer.Compare(sampleList[i-1], sampleList[i]))
	//			{
	//				Assert.Fail("Sorted list should be sorted and is not");
	//				break;
	//			}
	//	}

	//	[TestMethod]
	//	public void CheckOrderSourceSortedUnitTest()
	//	{
	//		var sortedArray = SortedReadOnlyListSampleSourceArray.SampleArray.ToArray();
	//		var comparer = new SortedListItemComparer(SortedReadOnlyListSampleSourceArray.AllKeyComparisons.Count);

	//		Array.Sort(sortedArray, comparer);
	//		var sampleList = new SortedReadOnlyList<SortedListItem>(sortedArray, SortedReadOnlyListSampleSourceArray.AllKeyComparisons);

	//		Assert.AreEqual(SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count, "{0} shoud have {1} count and is {2} count", nameof(sampleList), SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count);

	//		for(int i = 1; i<sampleList.Count; i++)
	//			if(0<comparer.Compare(sampleList[i-1], sampleList[i]))
	//			{
	//				Assert.Fail("Sorted list should be sorted and is not");
	//				break;
	//			}
	//	}

	//	[TestMethod]
	//	public void CheckOrderSourceSortedFromEnumerableUnitTest()
	//	{
	//		var sortedArray = SortedReadOnlyListSampleSourceArray.SampleArray.ToArray();
	//		var comparer = new SortedListItemComparer(SortedReadOnlyListSampleSourceArray.AllKeyComparisons.Count);

	//		Array.Sort(sortedArray, comparer);
	//		var sampleList = new SortedReadOnlyList<SortedListItem>(new EnumerableOnly<SortedListItem>(sortedArray), SortedReadOnlyListSampleSourceArray.AllKeyComparisons);

	//		Assert.AreEqual(SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count, "{0} shoud have {1} count and is {2} count", nameof(sampleList), SortedReadOnlyListSampleSourceArray.SampleArray.Count, sampleList.Count);

	//		for(int i = 1; i<sampleList.Count; i++)
	//			if(0<comparer.Compare(sampleList[i-1], sampleList[i]))
	//			{
	//				Assert.Fail("Sorted list should be sorted and is not");
	//				break;
	//			}
	//	}
	//}
}