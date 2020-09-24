using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.SortedList;
using WojciechMikołajewicz.SortedList.KeysData;

namespace WojciechMikołajewicz.AdvancedListDotNetCoreMSUnitTest
{
	static class SortedReadOnlyListSampleSourceArray
	{
		public static IReadOnlyList<SortedListItem> SampleArray { get; }

		public static IEnumerable<SortedListItem> SampleEnumerable { get; }

		public static KeyData<SortedListItem, string> Key1Data { get; }

		public static KeyData<SortedListItem, int> Key2Data { get; }

		public static KeyData<SortedListItem, double> Key3Data { get; }

		public static KeyData<SortedListItem, decimal> Key4Data { get; }

		public static KeyData<SortedListItem, short> Key5Data { get; }

		public static KeyData<SortedListItem, float> Key6Data { get; }

		public static KeyData<SortedListItem, long> Key7Data { get; }

		public static KeyData<SortedListItem, byte> Key8Data { get; }

		public static KeyData<SortedListItem, char> Key9Data { get; }

		public static KeyData<SortedListItem, sbyte> Key10Data { get; }

		public static KeyData<SortedListItem, DateTime> Key11Data { get; }

		public static KeyData<SortedListItem, TimeSpan> Key12Data { get; }

		public static KeyData<SortedListItem, ulong> Key13Data { get; }

		public static KeyData<SortedListItem, uint> Key14Data { get; }

		public static KeyData<SortedListItem, ushort> Key15Data { get; }

		public static KeyData<SortedListItem, Guid> Key16Data { get; }

		public static KeyData<SortedListItem, Version> Key17Data { get; }

		public static KeysData<SortedListItem, string, int, double, decimal, short, float, long, byte, char, sbyte, DateTime, TimeSpan, ulong, uint, ushort, Guid> AllKeysData { get; }

		public static IReadOnlyList<IKeyData<SortedListItem>> AllKeysDataList { get; }

		static SortedReadOnlyListSampleSourceArray()
		{
			string[] a1 = new string[] { "PPP", "CCC", "UUU", };
			int[] a2 = new int[] { 8, 4, 6, };
			double[] a3 = new double[] { 2.5, 4.1, };
			decimal[] a4 = new decimal[] { 8.11m, 12.3m, };
			short[] a5 = new short[] { 12, 7, };
			float[] a6 = new float[] { 4.2f, 5.3f, };
			long[] a7 = new long[] { 18, 12, };
			byte[] a8 = new byte[] { 5, 6, };
			char[] a9 = new char[] { 'w', 'd', };
			sbyte[] a10 = new sbyte[] { -5, 2, };
			DateTime[] a11 = new DateTime[] { new DateTime(2020, 2, 29), new DateTime(2020, 2, 13), };
			TimeSpan[] a12 = new TimeSpan[] { new TimeSpan(8, 0, 0), new TimeSpan(4, 0, 0), };
			ulong[] a13 = new ulong[] { 85, 7, };
			uint[] a14 = new uint[] { 6, 9, };
			ushort[] a15 = new ushort[] { 25, 28, };
			Guid[] a16 = new Guid[] { new Guid(7, 4, 5, 5, 8, 20, 21, 88, 64, 7, 3), new Guid(15, 5, 87, 3, 17, 27, 13, 72, 85, 6, 14), };
			Version[] a17 = new Version[] { new Version(8, 4, 5218, 17), new Version(8, 2, 2115, 13), };
			int i, i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15, i16, i17;

			var sampleArray = new SortedListItem[a1.Length*a2.Length*a3.Length*a4.Length*a5.Length*a6.Length*a7.Length*a8.Length*a9.Length*a10.Length*a11.Length*a12.Length*a13.Length*a14.Length*a15.Length*a16.Length*a17.Length];

			for(i1=0, i=0; i1<a1.Length; i1++)
				for(i2=0; i2<a2.Length; i2++)
					for(i3=0; i3<a3.Length; i3++)
						for(i4=0; i4<a4.Length; i4++)
							for(i5=0; i5<a5.Length; i5++)
								for(i6=0; i6<a6.Length; i6++)
									for(i7=0; i7<a7.Length; i7++)
										for(i8=0; i8<a8.Length; i8++)
											for(i9=0; i9<a9.Length; i9++)
												for(i10=0; i10<a10.Length; i10++)
													for(i11=0; i11<a11.Length; i11++)
														for(i12=0; i12<a12.Length; i12++)
															for(i13=0; i13<a13.Length; i13++)
																for(i14=0; i14<a14.Length; i14++)
																	for(i15=0; i15<a15.Length; i15++)
																		for(i16=0; i16<a16.Length; i16++)
																			for(i17=0; i17<a17.Length; i17++, i++)
																			{
																				sampleArray[i]=new SortedListItem()
																				{
																					Key1=a1[i1],
																					Key2=a2[i2],
																					Key3=a3[i3],
																					Key4=a4[i4],
																					Key5=a5[i5],
																					Key6=a6[i6],
																					Key7=a7[i7],
																					Key8=a8[i8],
																					Key9=a9[i9],
																					Key10=a10[i10],
																					Key11=a11[i11],
																					Key12=a12[i12],
																					Key13=a13[i13],
																					Key14=a14[i14],
																					Key15=a15[i15],
																					Key16=a16[i16],
																					Key17=a17[i17],
																				};
																			}
			SampleArray=sampleArray;


			Key1Data = new KeyData<SortedListItem, string>(item => item.Key1, StringComparer.InvariantCultureIgnoreCase.Compare);
			Key2Data = new KeyData<SortedListItem, int>(item => item.Key2, Comparer<int>.Default.Compare);
			Key3Data = new KeyData<SortedListItem, double>(item => item.Key3, Comparer<double>.Default.Compare);
			Key4Data = new KeyData<SortedListItem, decimal>(item => item.Key4, Comparer<decimal>.Default.Compare);
			Key5Data = new KeyData<SortedListItem, short>(item => item.Key5, Comparer<short>.Default.Compare);
			Key6Data = new KeyData<SortedListItem, float>(item => item.Key6, Comparer<float>.Default.Compare);
			Key7Data = new KeyData<SortedListItem, long>(item => item.Key7, Comparer<long>.Default.Compare);
			Key8Data = new KeyData<SortedListItem, byte>(item => item.Key8, Comparer<byte>.Default.Compare);
			Key9Data = new KeyData<SortedListItem, char>(item => item.Key9, Comparer<char>.Default.Compare);
			Key10Data = new KeyData<SortedListItem, sbyte>(item => item.Key10, Comparer<sbyte>.Default.Compare);
			Key11Data = new KeyData<SortedListItem, DateTime>(item => item.Key11, Comparer<DateTime>.Default.Compare);
			Key12Data = new KeyData<SortedListItem, TimeSpan>(item => item.Key12, Comparer<TimeSpan>.Default.Compare);
			Key13Data = new KeyData<SortedListItem, ulong>(item => item.Key13, Comparer<ulong>.Default.Compare);
			Key14Data = new KeyData<SortedListItem, uint>(item => item.Key14, Comparer<uint>.Default.Compare);
			Key15Data = new KeyData<SortedListItem, ushort>(item => item.Key15, Comparer<ushort>.Default.Compare);
			Key16Data = new KeyData<SortedListItem, Guid>(item => item.Key16, Comparer<Guid>.Default.Compare);
			Key17Data = new KeyData<SortedListItem, Version>(item => item.Key17, Comparer<Version>.Default.Compare);

			AllKeysData=new KeysData<SortedListItem, string, int, double, decimal, short, float, long, byte, char, sbyte, DateTime, TimeSpan, ulong, uint, ushort, Guid>(
				Key1Data,
				Key2Data,
				Key3Data,
				Key4Data,
				Key5Data,
				Key6Data,
				Key7Data,
				Key8Data,
				Key9Data,
				Key10Data,
				Key11Data,
				Key12Data,
				Key13Data,
				Key14Data,
				Key15Data,
				Key16Data
				);

			var allKeyComparisons = new IKeyData<SortedListItem>[]
			{
				Key1Data,
				Key2Data,
				Key3Data,
				Key4Data,
				Key5Data,
				Key6Data,
				Key7Data,
				Key8Data,
				Key9Data,
				Key10Data,
				Key11Data,
				Key12Data,
				Key13Data,
				Key14Data,
				Key15Data,
				Key16Data,
				Key17Data,
			};
			AllKeysDataList=allKeyComparisons;
		}

		#region Example items
		public static SortedListItem ExistingItemExample { get; } = new SortedListItem
		{
			Key1="PPP",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=5,
			Key9='w',
			Key10=-5,
			Key11=new DateTime(2020, 2, 29),
			Key12=new TimeSpan(8, 0, 0),
			Key13=85,
			Key14=9,
			Key15=25,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 88, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 13),
		};

		public static SortedListItem NotExistingItemExample1 { get; } = new SortedListItem
		{
			Key1="FFF",
			Key2=5,
			Key3=2.4,
			Key4=7.03m,
			Key5=13,
			Key6=4.8f,
			Key7=20,
			Key8=2,
			Key9='y',
			Key10=25,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample2 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=5,
			Key3=2.4,
			Key4=7.03m,
			Key5=13,
			Key6=4.8f,
			Key7=20,
			Key8=2,
			Key9='y',
			Key10=25,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample3 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=2.4,
			Key4=7.03m,
			Key5=13,
			Key6=4.8f,
			Key7=20,
			Key8=2,
			Key9='y',
			Key10=25,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample4 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=7.03m,
			Key5=13,
			Key6=4.8f,
			Key7=20,
			Key8=2,
			Key9='y',
			Key10=25,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample5 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=13,
			Key6=4.8f,
			Key7=20,
			Key8=2,
			Key9='y',
			Key10=25,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample6 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=4.8f,
			Key7=20,
			Key8=2,
			Key9='y',
			Key10=25,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample7 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=20,
			Key8=2,
			Key9='y',
			Key10=25,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample8 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=2,
			Key9='y',
			Key10=25,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample9 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=5,
			Key9='y',
			Key10=25,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample10 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=5,
			Key9='w',
			Key10=25,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample11 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=5,
			Key9='w',
			Key10=-5,
			Key11=new DateTime(2020, 2, 19),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample12 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=5,
			Key9='w',
			Key10=-5,
			Key11=new DateTime(2020, 2, 29),
			Key12=new TimeSpan(2, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample13 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=5,
			Key9='w',
			Key10=-5,
			Key11=new DateTime(2020, 2, 29),
			Key12=new TimeSpan(8, 0, 0),
			Key13=40,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample14 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=5,
			Key9='w',
			Key10=-5,
			Key11=new DateTime(2020, 2, 29),
			Key12=new TimeSpan(8, 0, 0),
			Key13=85,
			Key14=17,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample15 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=5,
			Key9='w',
			Key10=-5,
			Key11=new DateTime(2020, 2, 29),
			Key12=new TimeSpan(8, 0, 0),
			Key13=85,
			Key14=9,
			Key15=26,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample16 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=5,
			Key9='w',
			Key10=-5,
			Key11=new DateTime(2020, 2, 29),
			Key12=new TimeSpan(8, 0, 0),
			Key13=85,
			Key14=9,
			Key15=25,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 112, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		public static SortedListItem NotExistingItemExample17 { get; } = new SortedListItem
		{
			Key1="UUU",
			Key2=4,
			Key3=4.1,
			Key4=8.11m,
			Key5=12,
			Key6=5.3f,
			Key7=18,
			Key8=5,
			Key9='w',
			Key10=-5,
			Key11=new DateTime(2020, 2, 29),
			Key12=new TimeSpan(8, 0, 0),
			Key13=85,
			Key14=9,
			Key15=25,
			Key16=new Guid(7, 4, 5, 5, 8, 20, 21, 88, 64, 7, 3),
			Key17=new Version(8, 2, 2115, 8),
		};
		#endregion
	}
}