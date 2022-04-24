using BenchmarkDotNet.Attributes;
using WojciechMikołajewicz.SortedList;

namespace SortedListBenchmarks;

[MemoryDiagnoser]
public class ReadOnlyListBenchamrks
{
	const int SampleListLength = 1_000_000;

	public readonly int[] SampleList;

	public ReadOnlyListBenchamrks()
	{
		SampleList = new int[SampleListLength];
		for(int i=0; i < SampleListLength; i++)
			SampleList[i] = i;
	}

	[Benchmark(Baseline = true)]
	[Arguments(557)]
	public Range StateParameter(int searchingValue)
	{
		var range = SampleList.BinaryFindEqual(Range.All, searchingValue, (item, searching) => item.CompareTo(searching));

		return range;
	}

	[Benchmark(Description = "StateParameterLclFnc")]
	[Arguments(557)]
	public Range StateParameterLocalFunction(int searchingValue)
	{
		var range = SampleList.BinaryFindEqual(Range.All, searchingValue, Comparison);

		return range;

		static int Comparison(int item, int searching)
		{
			return item.CompareTo(searching);
		}
	}

	[Benchmark]
	[Arguments(557)]
	public Range CapturedContext(int searchingValue)
	{
		var range = SampleList.BinaryFindEqual(Range.All, item => item.CompareTo(searchingValue));

		return range;
	}

	[Benchmark(Description = "CapturedContextLclFnc")]
	[Arguments(557)]
	public Range CapturedContextLocalFunction(int searchingValue)
	{
		var range = SampleList.BinaryFindEqual(Range.All, Comparison);

		return range;

		int Comparison(int item)
		{
			return item.CompareTo(searchingValue);
		}
	}
}