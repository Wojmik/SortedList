using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WojciechMiko³ajewicz.SortedList;

namespace WojciechMiko³ajewicz.AdvancedListDotNetCoreMSUnitTest
{
	[TestClass]
	public class BinarySearchUnitTest
	{
		const int NumberCount = 100000;
		const int Divider = 5;
		static IReadOnlyList<Data> Datas { get; set; }

		static BinarySearchUnitTest()
		{
			//Preparing testing table
			Datas=Enumerable.Range((int)'A', (int)'Z'-(int)'A'+1)
				.SelectMany(ch => Enumerable.Range(0, NumberCount), (ch, nmbr) => new Data()
				{
					Code=new string((char)ch, 3),
					Number=nmbr/Divider,
				})
				.ToArray();
		}

		#region BinarySearchEqual
		[TestMethod]
		public void TestFindCode()
		{
			const string SeekCode = "FFF";
			Data dFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			var range=FindCode(seekCode: SeekCode);
			Test(firstExpected: dFirst, lastExpected: dLast, lengthExpected: NumberCount, datas: Datas, range: range);
		}

		[TestMethod]
		public void TestFindCodeLeft()
		{
			const string SeekCode = "AAA";
			Data dFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			var range = FindCode(seekCode: SeekCode);
			Test(firstExpected: dFirst, lastExpected: dLast, lengthExpected: NumberCount, datas: Datas, range: range);
		}

		[TestMethod]
		public void TestFindCodeRight()
		{
			const string SeekCode = "ZZZ";
			Data dFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			var range = FindCode(seekCode: SeekCode);
			Test(firstExpected: dFirst, lastExpected: dLast, lengthExpected: NumberCount, datas: Datas, range: range);
		}

		[TestMethod]
		public void TestFindCodeNotFoundLeft()
		{
			const string SeekCode = "AA";
			Data dFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			var range = FindCode(seekCode: SeekCode);
			(_, int length)=range.GetOffsetAndLength(Datas.Count);
			Assert.AreEqual(0, length, "{0} should be zero, and is: {1}", nameof(length), length);
		}

		[TestMethod]
		public void TestFindCodeNotFoundRight()
		{
			const string SeekCode = "ZZZZ";
			Data dFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			var range = FindCode(seekCode: SeekCode);
			(_, int length)=range.GetOffsetAndLength(Datas.Count);
			Assert.AreEqual(0, length, "{0} should be zero, and is: {1}", nameof(length), length);
		}
		#endregion

		#region BinaryFindLessOrEqual
		[TestMethod]
		public void TestFindLessOrEquals()
		{
			const string SeekCode = "PPP";
			const int LessOrEquals = 17537;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dLast = new Data() { Code=SeekCode, Number=LessOrEquals, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//LessOrEquals
			var range2=Datas.BinaryFindLessOrEqual(range: range1, comparison: data => data.Number.CompareTo(LessOrEquals));
			Test(firstExpected: dCodeFirst, lastExpected: dLast, lengthExpected: (LessOrEquals+1)*Divider, datas: Datas, range: range2);
		}

		[TestMethod]
		public void TestFindLessOrEqualsBoundRight1()
		{
			const string SeekCode = "YYY";
			const int LessOrEquals = NumberCount/Divider-1;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dLast = new Data() { Code=SeekCode, Number=LessOrEquals, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//LessOrEquals
			var range2 = Datas.BinaryFindLessOrEqual(range: range1, comparison: data => data.Number.CompareTo(LessOrEquals));
			Test(firstExpected: dCodeFirst, lastExpected: dLast, lengthExpected: (LessOrEquals+1)*Divider, datas: Datas, range: range2);
		}

		[TestMethod]
		public void TestFindLessOrEqualsBoundRight2()
		{
			const string SeekCode = "DDD";
			const int LessOrEquals = int.MaxValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dLast = new Data() { Code=SeekCode, Number=NumberCount/Divider-1, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//LessOrEquals
			var range2 = Datas.BinaryFindLessOrEqual(range: range1, comparison: data => data.Number.CompareTo(LessOrEquals));
			Test(firstExpected: dCodeFirst, lastExpected: dLast, lengthExpected: NumberCount, datas: Datas, range: range2);
		}

		[TestMethod]
		public void TestFindLessOrEqualsBoundRight3()
		{
			const string SeekCode = "ZZZ";
			const int LessOrEquals = NumberCount/Divider-1;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dLast = new Data() { Code=SeekCode, Number=LessOrEquals, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//LessOrEquals
			var range2 = Datas.BinaryFindLessOrEqual(range: range1, comparison: data => data.Number.CompareTo(LessOrEquals));
			Test(firstExpected: dCodeFirst, lastExpected: dLast, lengthExpected: (LessOrEquals+1)*Divider, datas: Datas, range: range2);
		}

		[TestMethod]
		public void TestFindLessOrEqualsBoundRight4()
		{
			const string SeekCode = "ZZZ";
			const int LessOrEquals = int.MaxValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dLast = new Data() { Code=SeekCode, Number=NumberCount/Divider-1, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//LessOrEquals
			var range2 = Datas.BinaryFindLessOrEqual(range: range1, comparison: data => data.Number.CompareTo(LessOrEquals));
			Test(firstExpected: dCodeFirst, lastExpected: dLast, lengthExpected: NumberCount, datas: Datas, range: range2);
		}

		[TestMethod]
		public void TestFindLessOrEqualsBoundRightNotFound1()
		{
			const string SeekCode = "BBB";
			const int LessOrEquals = -1;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//LessOrEquals
			var range2 = Datas.BinaryFindLessOrEqual(range: range1, comparison: data => data.Number.CompareTo(LessOrEquals));
			(_, int length)=range2.GetOffsetAndLength(Datas.Count);
			Assert.AreEqual(0, length, "{0} should be zero, and is: {1}", nameof(length), length);
		}
		[TestMethod]
		public void TestFindLessOrEqualsBoundRightNotFound2()
		{
			const string SeekCode = "AAA";
			const int LessOrEquals = -1;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//LessOrEquals
			var range2 = Datas.BinaryFindLessOrEqual(range: range1, comparison: data => data.Number.CompareTo(LessOrEquals));
			(_, int length)=range2.GetOffsetAndLength(Datas.Count);
			Assert.AreEqual(0, length, "{0} should be zero, and is: {1}", nameof(length), length);
		}
		#endregion

		#region BinaryFindLess
		[TestMethod]
		public void TestFindLess()
		{
			const string SeekCode = "UUU";
			const int Less = 17537;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dLast = new Data() { Code=SeekCode, Number=Less-1, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//Less
			var range2 = Datas.BinaryFindLess(range: range1, comparison: data => data.Number.CompareTo(Less));
			Test(firstExpected: dCodeFirst, lastExpected: dLast, lengthExpected: Less*Divider, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindLessBoundRight2()
		{
			const string SeekCode = "JJJ";
			const int Less = int.MaxValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dLast = new Data() { Code=SeekCode, Number=NumberCount/Divider-1, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//LessOrEquals
			var range2 = Datas.BinaryFindLess(range: range1, comparison: data => data.Number.CompareTo(Less));
			Test(firstExpected: dCodeFirst, lastExpected: dLast, lengthExpected: NumberCount, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindLessBoundRight4()
		{
			const string SeekCode = "ZZZ";
			const int Less = int.MaxValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dLast = new Data() { Code=SeekCode, Number=NumberCount/Divider-1, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//Less
			var range2 = Datas.BinaryFindLess(range: range1, comparison: data => data.Number.CompareTo(Less));
			Test(firstExpected: dCodeFirst, lastExpected: dLast, lengthExpected: NumberCount, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindLessBoundRightNotFound1()
		{
			const string SeekCode = "KKK";
			const int Less = 0;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//Less
			var range2 = Datas.BinaryFindLess(range: range1, comparison: data => data.Number.CompareTo(Less));
			(_, int length)=range2.GetOffsetAndLength(Datas.Count);
			Assert.AreEqual(0, length, "{0} should be zero, and is: {1}", nameof(length), length);
		}
		[TestMethod]
		public void TestFindLessBoundRightNotFound2()
		{
			const string SeekCode = "AAA";
			const int Less = 0;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//Less
			var range2 = Datas.BinaryFindLess(range: range1, comparison: data => data.Number.CompareTo(Less));
			(_, int length)=range2.GetOffsetAndLength(Datas.Count);
			Assert.AreEqual(0, length, "{0} should be zero, and is: {1}", nameof(length), length);
		}
		#endregion

		#region BinaryFindGreaterOrEqual
		[TestMethod]
		public void TestFindGreaterOrEquals()
		{
			const string SeekCode = "TTT";
			const int GreaterOrEquals = 17537;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dFirst = new Data() { Code=SeekCode, Number=GreaterOrEquals, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//GreaterOrEquals
			var range2 = Datas.BinaryFindGreaterOrEqual(range: range1, comparison: data => data.Number.CompareTo(GreaterOrEquals));
			Test(firstExpected: dFirst, lastExpected: dCodeLast, lengthExpected: NumberCount-GreaterOrEquals*Divider, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeft1()
		{
			const string SeekCode = "XXX";
			const int GreaterOrEquals = 0;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dFirst = new Data() { Code=SeekCode, Number=GreaterOrEquals, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//GreaterOrEquals
			var range2 = Datas.BinaryFindGreaterOrEqual(range: range1, comparison: data => data.Number.CompareTo(GreaterOrEquals));
			Test(firstExpected: dFirst, lastExpected: dCodeLast, lengthExpected: NumberCount-GreaterOrEquals*Divider, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeft2()
		{
			const string SeekCode = "CCC";
			const int GreaterOrEquals = int.MinValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dFirst = new Data() { Code=SeekCode, Number=0, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//GreaterOrEquals
			var range2 = Datas.BinaryFindGreaterOrEqual(range: range1, comparison: data => data.Number.CompareTo(GreaterOrEquals));
			Test(firstExpected: dFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeft3()
		{
			const string SeekCode = "AAA";
			const int GreaterOrEquals = 0;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dFirst = new Data() { Code=SeekCode, Number=GreaterOrEquals, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//GreaterOrEquals
			var range2 = Datas.BinaryFindGreaterOrEqual(range: range1, comparison: data => data.Number.CompareTo(GreaterOrEquals));
			Test(firstExpected: dFirst, lastExpected: dCodeLast, lengthExpected: NumberCount-GreaterOrEquals*Divider, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeft4()
		{
			const string SeekCode = "AAA";
			const int GreaterOrEquals = int.MinValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dFirst = new Data() { Code=SeekCode, Number=0, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//GreaterOrEquals
			var range2 = Datas.BinaryFindGreaterOrEqual(range: range1, comparison: data => data.Number.CompareTo(GreaterOrEquals));
			Test(firstExpected: dFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeftNotFound1()
		{
			const string SeekCode = "PPP";
			const int GreaterOrEquals = int.MaxValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//GreaterOrEquals
			var range2 = Datas.BinaryFindGreaterOrEqual(range: range1, comparison: data => data.Number.CompareTo(GreaterOrEquals));
			(_, int length)=range2.GetOffsetAndLength(Datas.Count);
			Assert.AreEqual(0, length, "{0} should be zero, and is: {1}", nameof(length), length);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeftNotFound2()
		{
			const string SeekCode = "ZZZ";
			const int GreaterOrEquals = int.MaxValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//GreaterOrEquals
			var range2 = Datas.BinaryFindGreaterOrEqual(range: range1, comparison: data => data.Number.CompareTo(GreaterOrEquals));
			(_, int length)=range2.GetOffsetAndLength(Datas.Count);
			Assert.AreEqual(0, length, "{0} should be zero, and is: {1}", nameof(length), length);
		}
		#endregion

		#region BinaryFindGreater
		[TestMethod]
		public void TestFindGreater()
		{
			const string SeekCode = "LLL";
			const int Greater = 17537;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dFirst = new Data() { Code=SeekCode, Number=Greater+1, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//Greater
			var range2 = Datas.BinaryFindGreater(range: range1, comparison: data => data.Number.CompareTo(Greater));
			Test(firstExpected: dFirst, lastExpected: dCodeLast, lengthExpected: NumberCount-(Greater+1)*Divider, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindGreaterBoundLeft2()
		{
			const string SeekCode = "FFF";
			const int Greater = int.MinValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dFirst = new Data() { Code=SeekCode, Number=0, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//Greater
			var range2 = Datas.BinaryFindGreater(range: range1, comparison: data => data.Number.CompareTo(Greater));
			Test(firstExpected: dFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindGreaterBoundLeft4()
		{
			const string SeekCode = "AAA";
			const int Greater = int.MinValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, }, dFirst = new Data() { Code=SeekCode, Number=0, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//Greater
			var range2 = Datas.BinaryFindGreater(range: range1, comparison: data => data.Number.CompareTo(Greater));
			Test(firstExpected: dFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range2);
		}
		[TestMethod]
		public void TestFindGreaterBoundLeftNotFound1()
		{
			const string SeekCode = "VVV";
			const int Greater = int.MaxValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//Greater
			var range2 = Datas.BinaryFindGreater(range: range1, comparison: data => data.Number.CompareTo(Greater));
			(_, int length)=range2.GetOffsetAndLength(Datas.Count);
			Assert.AreEqual(0, length, "{0} should be zero, and is: {1}", nameof(length), length);
		}
		[TestMethod]
		public void TestFindGreaterBoundLeftNotFound2()
		{
			const string SeekCode = "ZZZ";
			const int Greater = int.MaxValue;
			Data dCodeFirst = new Data() { Code=SeekCode, Number=0/Divider, }, dCodeLast = new Data() { Code=SeekCode, Number=(NumberCount-1)/Divider, };

			//First search code only
			var range1 = FindCode(seekCode: SeekCode);
			Test(firstExpected: dCodeFirst, lastExpected: dCodeLast, lengthExpected: NumberCount, datas: Datas, range: range1);

			//Greater
			var range2 = Datas.BinaryFindGreater(range: range1, comparison: data => data.Number.CompareTo(Greater));
			(_, int length)=range2.GetOffsetAndLength(Datas.Count);
			Assert.AreEqual(0, length, "{0} should be zero, and is: {1}", nameof(length), length);
		}
		#endregion

		#region Helper methods
		private bool Test(Data firstExpected, Data lastExpected, int lengthExpected, IReadOnlyList<Data> datas, Range range)
		{
			Data first, beforeFirst, last, afterLast;
			bool bLength, bFirst, bLast, bBeforeFirst = true, bAfterLast = true;

			first=datas[range.Start];
			Assert.IsTrue(bFirst=(0==DataCompare(first, firstExpected)), "The first item should be: {0} {1}, and is: {2} {3}", firstExpected.Code, firstExpected.Number, first.Code, first.Number);

			last=datas[range.End.GetOffset(datas.Count)-1];
			Assert.IsTrue(bLast=(0==DataCompare(last, lastExpected)), "The last item should be: {0} {1}, and is: {2} {3}", lastExpected.Code, lastExpected.Number, last.Code, last.Number);

			(int offset, int length)=range.GetOffsetAndLength(datas.Count);

			if(offset>0)
			{
				beforeFirst=datas[offset-1];
				Assert.IsTrue(bBeforeFirst=(0>DataCompare(beforeFirst, firstExpected)), "Item before the first one should be less than: {0} {1}, and is: {2} {3}", firstExpected.Code, firstExpected.Number, beforeFirst.Code, beforeFirst.Number);
			}

			if(offset+length<datas.Count)
			{
				afterLast=datas[offset+length];
				Assert.IsTrue(bAfterLast=(0>DataCompare(lastExpected, afterLast)), "Item after the last one should be greather than: {0} {1}, and is: {2} {3}", lastExpected.Code, lastExpected.Number, afterLast.Code, afterLast.Number);
			}

			Assert.IsTrue(bLength=(lengthExpected==length), "Bad count of array items. Should be: {0}, and is: {1}", lengthExpected, length);

			return bLength && bFirst && bLast && bBeforeFirst && bAfterLast;
		}

		protected Range FindCode(string seekCode)
		{
			return Datas.BinaryFindEqual(range: Range.All, comparison: data => string.Compare(data.Code, seekCode, StringComparison.InvariantCultureIgnoreCase));
		}

		private int DataCodeCompare(Data x, Data y)
		{
			return string.Compare(x.Code, y.Code, StringComparison.CurrentCultureIgnoreCase);
		}
		private int DataCompare(Data x, Data y)
		{
			int iCmp;

			if(0==(iCmp=DataCodeCompare(x, y)))
				iCmp=x.Number.CompareTo(y.Number);

			return iCmp;
		}
		#endregion

		#region Helper classes
		class Data
		{
			public string Code { get; set; }
			public int Number { get; set; }
		}
		#endregion
	}
}