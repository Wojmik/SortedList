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
		static IReadOnlyList<Data> DataSamples { get; set; }

		static BinarySearchUnitTest()
		{
			//Preparing testing table
			DataSamples = Enumerable.Range((int)'A', (int)'Z' - (int)'A' + 1)
				.SelectMany(ch => Enumerable.Range(0, NumberCount), (ch, number) => new Data(new string((char)ch, 3), number / Divider))
				.ToArray();
		}

		#region BinarySearchEqual
		[TestMethod]
		public void TestFindCode()
		{
			const string SeekCode = "FFF";
			Data firstExpected = new Data(SeekCode, 0 / Divider), lastExpected = new Data(SeekCode, (NumberCount - 1) / Divider);

			var range = FindCode(SeekCode);
			Test(firstExpected, lastExpected, NumberCount, DataSamples, range);
		}

		[TestMethod]
		public void TestFindCodeLeft()
		{
			const string SeekCode = "AAA";
			Data firstExpected = new Data(SeekCode, 0 / Divider), lastExpected = new Data(SeekCode, (NumberCount - 1) / Divider);

			var range = FindCode(SeekCode);
			Test(firstExpected, lastExpected, NumberCount, DataSamples, range);
		}

		[TestMethod]
		public void TestFindCodeRight()
		{
			const string SeekCode = "ZZZ";
			Data firstExpected = new Data(SeekCode, 0 / Divider), lastExpected = new Data(SeekCode, (NumberCount - 1) / Divider);

			var range = FindCode(SeekCode);
			Test(firstExpected, lastExpected, NumberCount, DataSamples, range);
		}

		[TestMethod]
		public void TestFindCodeNotFoundLeft()
		{
			const string SeekCode = "AA";

			var range = FindCode(SeekCode);
			(_, int length) = range.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}

		[TestMethod]
		public void TestFindCodeNotFoundRight()
		{
			const string SeekCode = "ZZZZ";

			var range = FindCode(SeekCode);
			(_, int length) = range.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}

		[TestMethod]
		public void TestFindCodeNotFoundMiddle()
		{
			const string SeekCode = "PP";

			var range = FindCode(SeekCode);
			(_, int length) = range.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}
		#endregion

		#region BinarySearchEqualFirstIndex
		[TestMethod]
		public void TestFindCodeFirstIndex()
		{
			const string SeekCode = "FFF";
			Data firstExpected = new Data(SeekCode, 0 / Divider);

			var actualIndexOfFirst = FindCodeFirstIndex(SeekCode);
			TestFirst(firstExpected, DataSamples, actualIndexOfFirst);
		}

		[TestMethod]
		public void TestFindCodeFirstIndexLeft()
		{
			const string SeekCode = "AAA";
            Data firstExpected = new Data(SeekCode, 0 / Divider);

            var actualIndexOfFirst = FindCodeFirstIndex(SeekCode);
            TestFirst(firstExpected, DataSamples, actualIndexOfFirst);
        }

		[TestMethod]
		public void TestFindCodeFirstIndexRight()
		{
			const string SeekCode = "ZZZ";
            Data firstExpected = new Data(SeekCode, 0 / Divider);

            var actualIndexOfFirst = FindCodeFirstIndex(SeekCode);
            TestFirst(firstExpected, DataSamples, actualIndexOfFirst);
        }

		[TestMethod]
		public void TestFindCodeFirstIndexNotFoundLeft()
		{
			const string SeekCode = "AA";

			var actualIndexOfFirst = FindCodeFirstIndex(SeekCode);
			Assert.AreEqual(-1, actualIndexOfFirst);
		}

		[TestMethod]
		public void TestFindCodeFirstIndexNotFoundRight()
		{
			const string SeekCode = "ZZZZ";

            var actualIndexOfFirst = FindCodeFirstIndex(SeekCode);
            Assert.AreEqual(-1, actualIndexOfFirst);
        }

		[TestMethod]
		public void TestFindCodeFirstIndexNotFoundMiddle()
		{
			const string SeekCode = "PP";

            var actualIndexOfFirst = FindCodeFirstIndex(SeekCode);
            Assert.AreEqual(-1, actualIndexOfFirst);
        }
        #endregion

        #region BinarySearchEqualLastIndex
        [TestMethod]
        public void TestFindCodeLastIndex()
        {
            const string SeekCode = "FFF";
            Data lastExpected = new Data(SeekCode, (NumberCount - 1) / Divider);

            var actualIndexOfLast = FindCodeLastIndex(SeekCode);
            TestLast(lastExpected, DataSamples, actualIndexOfLast);
        }

        [TestMethod]
        public void TestFindCodeLastIndexLeft()
        {
            const string SeekCode = "AAA";
            Data lastExpected = new Data(SeekCode, (NumberCount - 1) / Divider);

            var actualIndexOfLast = FindCodeLastIndex(SeekCode);
            TestLast(lastExpected, DataSamples, actualIndexOfLast);
        }

        [TestMethod]
        public void TestFindCodeLastIndexRight()
        {
            const string SeekCode = "ZZZ";
            Data lastExpected = new Data(SeekCode, (NumberCount - 1) / Divider);

            var actualIndexOfLast = FindCodeLastIndex(SeekCode);
            TestLast(lastExpected, DataSamples, actualIndexOfLast);
        }

        [TestMethod]
        public void TestFindCodeLastIndexNotFoundLeft()
        {
            const string SeekCode = "AA";

            var actualIndexOfLast = FindCodeLastIndex(SeekCode);
            Assert.AreEqual(-1, actualIndexOfLast);
        }

        [TestMethod]
        public void TestFindCodeLastIndexNotFoundRight()
        {
            const string SeekCode = "ZZZZ";

            var actualIndexOfLast = FindCodeLastIndex(SeekCode);
            Assert.AreEqual(-1, actualIndexOfLast);
        }

        [TestMethod]
        public void TestFindCodeLastIndexNotFoundMiddle()
        {
            const string SeekCode = "PP";

            var actualIndexOfLast = FindCodeLastIndex(SeekCode);
            Assert.AreEqual(-1, actualIndexOfLast);
        }
        #endregion

        #region BinaryFindLessOrEqual
        [TestMethod]
		public void TestFindLessOrEquals()
		{
			const string SeekCode = "PPP";
			const int LessOrEquals = 17537;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dLast = new Data(SeekCode, LessOrEquals);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//LessOrEquals
			var range2 = DataSamples.BinaryFindLessOrEqual(range1, data => data.Number.CompareTo(LessOrEquals));
			Test(dCodeFirst, dLast, (LessOrEquals + 1) * Divider, DataSamples, range2);
		}

		[TestMethod]
		public void TestFindLessOrEqualsBoundRight1()
		{
			const string SeekCode = "YYY";
			const int LessOrEquals = NumberCount / Divider - 1;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dLast = new Data(SeekCode, LessOrEquals);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//LessOrEquals
			var range2 = DataSamples.BinaryFindLessOrEqual(range1, data => data.Number.CompareTo(LessOrEquals));
			Test(dCodeFirst, dLast, (LessOrEquals + 1) * Divider, DataSamples, range2);
		}

		[TestMethod]
		public void TestFindLessOrEqualsBoundRight2()
		{
			const string SeekCode = "DDD";
			const int LessOrEquals = int.MaxValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dLast = new Data(SeekCode, NumberCount / Divider - 1);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//LessOrEquals
			var range2 = DataSamples.BinaryFindLessOrEqual(range1, data => data.Number.CompareTo(LessOrEquals));
			Test(dCodeFirst, dLast, NumberCount, DataSamples, range2);
		}

		[TestMethod]
		public void TestFindLessOrEqualsBoundRight3()
		{
			const string SeekCode = "ZZZ";
			const int LessOrEquals = NumberCount / Divider - 1;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dLast = new Data(SeekCode, LessOrEquals);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//LessOrEquals
			var range2 = DataSamples.BinaryFindLessOrEqual(range1, data => data.Number.CompareTo(LessOrEquals));
			Test(dCodeFirst, dLast, (LessOrEquals + 1) * Divider, DataSamples, range2);
		}

		[TestMethod]
		public void TestFindLessOrEqualsBoundRight4()
		{
			const string SeekCode = "ZZZ";
			const int LessOrEquals = int.MaxValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dLast = new Data(SeekCode, NumberCount / Divider - 1);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//LessOrEquals
			var range2 = DataSamples.BinaryFindLessOrEqual(range1, data => data.Number.CompareTo(LessOrEquals));
			Test(dCodeFirst, dLast, NumberCount, DataSamples, range2);
		}

		[TestMethod]
		public void TestFindLessOrEqualsBoundRightNotFound1()
		{
			const string SeekCode = "BBB";
			const int LessOrEquals = -1;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//LessOrEquals
			var range2 = DataSamples.BinaryFindLessOrEqual(range1, data => data.Number.CompareTo(LessOrEquals));
			(_, int length) = range2.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}
		[TestMethod]
		public void TestFindLessOrEqualsBoundRightNotFound2()
		{
			const string SeekCode = "AAA";
			const int LessOrEquals = -1;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//LessOrEquals
			var range2 = DataSamples.BinaryFindLessOrEqual(range1, data => data.Number.CompareTo(LessOrEquals));
			(_, int length) = range2.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}
		#endregion

		#region BinaryFindLess
		[TestMethod]
		public void TestFindLess()
		{
			const string SeekCode = "UUU";
			const int Less = 17537;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dLast = new Data(SeekCode, Less - 1);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//Less
			var range2 = DataSamples.BinaryFindLess(range1, data => data.Number.CompareTo(Less));
			Test(dCodeFirst, dLast, Less * Divider, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindLessBoundRight2()
		{
			const string SeekCode = "JJJ";
			const int Less = int.MaxValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dLast = new Data(SeekCode, NumberCount / Divider - 1);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//LessOrEquals
			var range2 = DataSamples.BinaryFindLess(range1, data => data.Number.CompareTo(Less));
			Test(dCodeFirst, dLast, NumberCount, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindLessBoundRight4()
		{
			const string SeekCode = "ZZZ";
			const int Less = int.MaxValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dLast = new Data(SeekCode, NumberCount / Divider - 1);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//Less
			var range2 = DataSamples.BinaryFindLess(range1, data => data.Number.CompareTo(Less));
			Test(dCodeFirst, dLast, NumberCount, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindLessBoundRightNotFound1()
		{
			const string SeekCode = "KKK";
			const int Less = 0;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//Less
			var range2 = DataSamples.BinaryFindLess(range1, data => data.Number.CompareTo(Less));
			(_, int length) = range2.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}
		[TestMethod]
		public void TestFindLessBoundRightNotFound2()
		{
			const string SeekCode = "AAA";
			const int Less = 0;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//Less
			var range2 = DataSamples.BinaryFindLess(range1, data => data.Number.CompareTo(Less));
			(_, int length) = range2.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}
		#endregion

		#region BinaryFindGreaterOrEqual
		[TestMethod]
		public void TestFindGreaterOrEquals()
		{
			const string SeekCode = "TTT";
			const int GreaterOrEquals = 17537;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dFirst = new Data(SeekCode, GreaterOrEquals);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//GreaterOrEquals
			var range2 = DataSamples.BinaryFindGreaterOrEqual(range1, data => data.Number.CompareTo(GreaterOrEquals));
			Test(dFirst, dCodeLast, NumberCount - GreaterOrEquals * Divider, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeft1()
		{
			const string SeekCode = "XXX";
			const int GreaterOrEquals = 0;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dFirst = new Data(SeekCode, GreaterOrEquals);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//GreaterOrEquals
			var range2 = DataSamples.BinaryFindGreaterOrEqual(range1, data => data.Number.CompareTo(GreaterOrEquals));
			Test(dFirst, dCodeLast, NumberCount - GreaterOrEquals * Divider, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeft2()
		{
			const string SeekCode = "CCC";
			const int GreaterOrEquals = int.MinValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dFirst = new Data(SeekCode, 0);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//GreaterOrEquals
			var range2 = DataSamples.BinaryFindGreaterOrEqual(range1, data => data.Number.CompareTo(GreaterOrEquals));
			Test(dFirst, dCodeLast, NumberCount, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeft3()
		{
			const string SeekCode = "AAA";
			const int GreaterOrEquals = 0;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dFirst = new Data(SeekCode, GreaterOrEquals);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//GreaterOrEquals
			var range2 = DataSamples.BinaryFindGreaterOrEqual(range1, data => data.Number.CompareTo(GreaterOrEquals));
			Test(dFirst, dCodeLast, NumberCount - GreaterOrEquals * Divider, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeft4()
		{
			const string SeekCode = "AAA";
			const int GreaterOrEquals = int.MinValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dFirst = new Data(SeekCode, 0);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//GreaterOrEquals
			var range2 = DataSamples.BinaryFindGreaterOrEqual(range1, data => data.Number.CompareTo(GreaterOrEquals));
			Test(dFirst, dCodeLast, NumberCount, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeftNotFound1()
		{
			const string SeekCode = "PPP";
			const int GreaterOrEquals = int.MaxValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//GreaterOrEquals
			var range2 = DataSamples.BinaryFindGreaterOrEqual(range1, data => data.Number.CompareTo(GreaterOrEquals));
			(_, int length) = range2.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}
		[TestMethod]
		public void TestFindGreaterOrEqualsBoundLeftNotFound2()
		{
			const string SeekCode = "ZZZ";
			const int GreaterOrEquals = int.MaxValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//GreaterOrEquals
			var range2 = DataSamples.BinaryFindGreaterOrEqual(range1, data => data.Number.CompareTo(GreaterOrEquals));
			(_, int length) = range2.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}
		#endregion

		#region BinaryFindGreater
		[TestMethod]
		public void TestFindGreater()
		{
			const string SeekCode = "LLL";
			const int Greater = 17537;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dFirst = new Data(SeekCode, Greater + 1);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//Greater
			var range2 = DataSamples.BinaryFindGreater(range1, data => data.Number.CompareTo(Greater));
			Test(dFirst, dCodeLast, NumberCount - (Greater + 1) * Divider, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindGreaterBoundLeft2()
		{
			const string SeekCode = "FFF";
			const int Greater = int.MinValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dFirst = new Data(SeekCode, 0);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//Greater
			var range2 = DataSamples.BinaryFindGreater(range1, data => data.Number.CompareTo(Greater));
			Test(dFirst, dCodeLast, NumberCount, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindGreaterBoundLeft4()
		{
			const string SeekCode = "AAA";
			const int Greater = int.MinValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider), dFirst = new Data(SeekCode, 0);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//Greater
			var range2 = DataSamples.BinaryFindGreater(range1, data => data.Number.CompareTo(Greater));
			Test(dFirst, dCodeLast, NumberCount, DataSamples, range2);
		}
		[TestMethod]
		public void TestFindGreaterBoundLeftNotFound1()
		{
			const string SeekCode = "VVV";
			const int Greater = int.MaxValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//Greater
			var range2 = DataSamples.BinaryFindGreater(range1, data => data.Number.CompareTo(Greater));
			(_, int length) = range2.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}
		[TestMethod]
		public void TestFindGreaterBoundLeftNotFound2()
		{
			const string SeekCode = "ZZZ";
			const int Greater = int.MaxValue;
			Data dCodeFirst = new Data(SeekCode, 0 / Divider), dCodeLast = new Data(SeekCode, (NumberCount - 1) / Divider);

			//First search code only
			var range1 = FindCode(SeekCode);
			Test(dCodeFirst, dCodeLast, NumberCount, DataSamples, range1);

			//Greater
			var range2 = DataSamples.BinaryFindGreater(range1, data => data.Number.CompareTo(Greater));
			(_, int length) = range2.GetOffsetAndLength(DataSamples.Count);
			Assert.AreEqual(0, length);
		}
		#endregion

		#region Helper methods
		private void Test(Data firstExpected, Data lastExpected, int lengthExpected, IReadOnlyList<Data> dataSamples, Range actualRange)
		{
			var (offset, length) = actualRange.GetOffsetAndLength(dataSamples.Count);

			TestFirst(firstExpected, dataSamples, offset);
			TestLast(lastExpected, dataSamples, offset + length - 1);
			Assert.IsTrue(lengthExpected == length, $"Bad count of array items. Should be: {lengthExpected}, and is: {length}");
		}

		private void TestFirst(Data firstExpected, IReadOnlyList<Data> dataSamples, int actualIndex)
        {
            //First
            var actualFirst = dataSamples[actualIndex];
            Assert.IsTrue(0 == DataCompare(actualFirst, firstExpected), $"The first item should be: {firstExpected.Code} {firstExpected.Number}, and is: {actualFirst.Code} {actualFirst.Number}");

            //Before first
            if (actualIndex > 0)
            {
                var beforeFirst = dataSamples[actualIndex - 1];
                Assert.IsTrue(0 > DataCompare(beforeFirst, firstExpected), $"Item before the first one should be less than: {firstExpected.Code} {firstExpected.Number}, and is: {beforeFirst.Code} {beforeFirst.Number}");
            }
        }

		private void TestLast(Data lastExpected, IReadOnlyList<Data> dataSamples, int actualIndex)
		{
            //Last
            var actualLast = dataSamples[actualIndex];
            Assert.IsTrue(0 == DataCompare(actualLast, lastExpected), $"The last item should be: {lastExpected.Code} {lastExpected.Number}, and is: {actualLast.Code} {actualLast.Number}");

            //After last
            if (actualIndex + 1 < dataSamples.Count)
            {
                var afterLast = dataSamples[actualIndex + 1];
                Assert.IsTrue(0 > DataCompare(lastExpected, afterLast), $"Item after the last one should be greater than: {lastExpected.Code} {lastExpected.Number}, and is: {afterLast.Code} {afterLast.Number}");
            }
        }

        private Range FindCode(string seekCode)
		{
			return DataSamples.BinaryFindEqual(Range.All, data => string.Compare(data.Code, seekCode, StringComparison.OrdinalIgnoreCase));
		}

		private int FindCodeFirstIndex(string seekCode)
        {
            return DataSamples.BinaryFindEqualFirstIndex(Range.All, data => string.Compare(data.Code, seekCode, StringComparison.OrdinalIgnoreCase));
        }

		private int FindCodeLastIndex(string seekCode)
        {
            return DataSamples.BinaryFindEqualLastIndex(Range.All, data => string.Compare(data.Code, seekCode, StringComparison.OrdinalIgnoreCase));
        }

        private static int DataCodeCompare(Data x, Data y)
		{
			return string.Compare(x.Code, y.Code, StringComparison.CurrentCultureIgnoreCase);
		}
		private static int DataCompare(Data x, Data y)
		{
			int iCmp;

			if (0 == (iCmp = DataCodeCompare(x, y)))
				iCmp = x.Number.CompareTo(y.Number);

			return iCmp;
		}
		#endregion

		#region Helper classes
		class Data
		{
			public string Code { get; }
			public int Number { get; }

			public Data(string code, int number)
			{
				Code = code;
				Number = number;
			}
		}
		#endregion
	}
}